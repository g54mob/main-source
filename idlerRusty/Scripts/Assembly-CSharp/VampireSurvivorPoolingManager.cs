using System.Collections.Generic;
using UnityEngine;

public class VampireSurvivorPoolingManager : MonoBehaviour
{
	public static VampireSurvivorPoolingManager ins;

	[Header("EXP POINTS")]
	public List<VampireSurvivorExperiencePoint> pooledExp;

	private List<float> pooledExpLastTimeUsed;

	public VampireSurvivorExperiencePoint expToPool;

	public int amountToPoolExp = 10;

	[Header("DMG NUMBERS")]
	public List<VampireSurvivorDamageNumber> pooledDmg;

	private List<float> pooledDmgLastTimeUsed;

	public VampireSurvivorDamageNumber dmgToPool;

	public int amountToPoolDmg = 10;

	private void Awake()
	{
		ins = this;
	}

	private void Start()
	{
		pooledExp = new List<VampireSurvivorExperiencePoint>();
		pooledExpLastTimeUsed = new List<float>();
		for (int i = 0; i < amountToPoolExp; i++)
		{
			VampireSurvivorExperiencePoint vampireSurvivorExperiencePoint = Object.Instantiate(expToPool, base.transform);
			vampireSurvivorExperiencePoint.gameObject.SetActive(value: false);
			pooledExp.Add(vampireSurvivorExperiencePoint);
			pooledExpLastTimeUsed.Add(0f);
		}
		pooledDmg = new List<VampireSurvivorDamageNumber>();
		pooledDmgLastTimeUsed = new List<float>();
		for (int j = 0; j < amountToPoolDmg; j++)
		{
			VampireSurvivorDamageNumber vampireSurvivorDamageNumber = Object.Instantiate(dmgToPool, base.transform);
			vampireSurvivorDamageNumber.gameObject.SetActive(value: false);
			pooledDmg.Add(vampireSurvivorDamageNumber);
			pooledDmgLastTimeUsed.Add(0f);
		}
	}

	public VampireSurvivorExperiencePoint GetPooledExp()
	{
		VampireSurvivorExperiencePoint result = null;
		float num = float.MaxValue;
		for (int i = 0; i < amountToPoolExp; i++)
		{
			if (!pooledExp[i].gameObject.activeInHierarchy)
			{
				pooledExpLastTimeUsed[i] = Time.time;
				return pooledExp[i];
			}
			float num2 = pooledExpLastTimeUsed[i];
			if (num2 < num)
			{
				num = num2;
				result = pooledExp[i];
			}
		}
		return result;
	}

	public VampireSurvivorDamageNumber GetPooledDmg()
	{
		VampireSurvivorDamageNumber result = null;
		float num = float.MaxValue;
		for (int i = 0; i < amountToPoolDmg; i++)
		{
			if (!pooledDmg[i].gameObject.activeInHierarchy)
			{
				pooledDmgLastTimeUsed[i] = Time.time;
				return pooledDmg[i];
			}
			float num2 = pooledDmgLastTimeUsed[i];
			if (num2 < num)
			{
				num = num2;
				result = pooledDmg[i];
			}
		}
		return result;
	}
}
