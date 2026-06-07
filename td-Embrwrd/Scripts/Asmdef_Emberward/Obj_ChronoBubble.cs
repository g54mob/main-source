using System.Collections.Generic;
using UnityEngine;

public class Obj_ChronoBubble : MonoBehaviour
{
	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private float radius;

	[SerializeField]
	private float detectInterval;

	[SerializeField]
	private ParticleSystem particle_LockMonster;

	private float detectTimer;

	private float duration;

	private float effectTimer;

	private bool isOn;

	private List<AMonsterBase> list_EffectedMonsters;

	private void Update()
	{
	}

	private void DetectMonsters()
	{
	}

	private void OnEnable()
	{
	}

	public void Setup(float duration)
	{
	}
}
