using System.Collections.Generic;
using UnityEngine;

public class Obj_RuneTrap_MonsterEffect : MonoBehaviour
{
	public enum eTrapType
	{
		Heal = 0,
		Speed = 1,
		Shield = 2
	}

	[SerializeField]
	private eTrapType trapType;

	[SerializeField]
	private SpriteRenderer spriteRenderer_Ground;

	[SerializeField]
	private Obj_AreaMonsterDetector monsterDetector;

	[SerializeField]
	private float healPercentPerSecond;

	private float detectInterval;

	private float detectTimer;

	private List<AMonsterBase> list_DetectedMonsters;

	private void Update()
	{
	}

	private void DetectAndApplyEffect()
	{
	}
}
