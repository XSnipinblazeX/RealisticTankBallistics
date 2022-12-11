using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
        bool HasBlowOutPannel;
	 bool CookingOff;
        public float HP;
	public float ChanceOfCookOff;	
	public float CookOffHp;
	public float ChanceOfExplosion;
        public float ExplosionHp;
	public float maxCookOffTimeBeforeExplosion;
	public float minCookOffTimeBeforeExplosion;
	public float TurretPopOffChance;
	public float FATALexplosionChance;
	public GameObject cookOff;
	public GameObject explosionNormal;
	public GameObject explosionNoMoreTank;
	public GameObject tankBits;
	public TankComponentManager parentTank;
	public Transform[] hatches;
	[HideInInspector] public GameObject _cookOff;
	[HideInInspector] public GameObject  _explosion2;   // Start is called before the first frame update
	[HideInInspector] public GameObject  _explosion;   // Start is called before the first frame update
    void Start()
    {
        
    }

	public void DestroyParticle()
	{
		Destroy(_cookOff.gameObject);
		Destroy(_explosion2.gameObject);
		Destroy(_explosion.gameObject);
		Destroy(gameObject);
	}

     void CookOff()
	{
		print("Ammo cooking off");
		 for (int i = 0; i < hatches.Length; i++)
		{
		 _cookOff = Instantiate(cookOff, hatches[i].position, hatches[i].rotation) as GameObject;
		}
		parentTank.cookOff();
	}
	void Explode()
	{
		print("Ammo exploded");
		 _explosion = Instantiate(explosionNormal, transform.position, Quaternion.identity) as GameObject;
		parentTank.Exploded();
	}
	void FatalExplode()
	{
		print(" ALL Ammo exploded");
		 _explosion2 = Instantiate(explosionNormal, transform.position, Quaternion.identity) as GameObject;
		Destroy(gameObject);
		Destroy(_cookOff);
		parentTank.FatalExploded();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Damage(float _damage)
	{
		HP -= _damage;
		if(ChanceOfCookOff > Random.Range(0, 100))
		{
			CookOff();
		}
		if(ChanceOfExplosion > Random.Range(0, 100))
		{
			Explode();
		}
		if(TurretPopOffChance > Random.Range(0, 100))
		{

		}
		if(FATALexplosionChance > Random.Range(0, 100))
		{
			FatalExplode();
		}
	}
}
