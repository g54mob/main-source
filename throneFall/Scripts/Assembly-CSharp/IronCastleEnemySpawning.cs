using System.Collections.Generic;
using UnityEngine;

public class IronCastleEnemySpawning : MonoBehaviour
{
	[SerializeField]
	private List<Wave> waves;

	[SerializeField]
	private Hp hp;

	private void Start()
	{
		foreach (Wave wave in waves)
		{
			wave.Reset();
		}
	}

	private void Update()
	{
		if (hp.HpPercentage < 0.75f)
		{
			waves[0].Update();
		}
		if (hp.HpPercentage < 0.5f)
		{
			waves[1].Update();
		}
		if (hp.HpPercentage < 0.25f)
		{
			waves[2].Update();
		}
	}
}
