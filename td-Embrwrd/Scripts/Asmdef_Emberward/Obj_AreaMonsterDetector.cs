using System;
using System.Collections.Generic;
using UnityEngine;

public class Obj_AreaMonsterDetector : MonoBehaviour
{
	public delegate bool ExtraMonsterRequirementsDelegate(AMonsterBase monster);

	public enum eDisplayType
	{
		NONE = 0,
		OUTLINE = 1,
		FULL = 2
	}

	[SerializeField]
	private GameObject node_Range;

	[SerializeField]
	private SpriteRenderer spriteRenderer_Range_Outline;

	[SerializeField]
	private SpriteRenderer spriteRenderer_Range_Area;

	[SerializeField]
	private bool showRangeIndicator;

	[SerializeField]
	[Header("效果範圍")]
	private Vector2Int range;

	private ExtraMonsterRequirementsDelegate conditionDelegate;

	private Action<List<AMonsterBase>> callback;

	private List<AMonsterBase> list_MonstersInArea;

	private void Awake()
	{
	}

	public void Setup(ExtraMonsterRequirementsDelegate requirementsDelegate, Action<List<AMonsterBase>> callback)
	{
	}

	public void SetRange(Vector2Int range)
	{
	}

	public void ToggleRangeIndicator(bool isOn)
	{
	}

	public void SwitchDisplayType(eDisplayType displayType)
	{
	}

	public bool CheckMonsterInArea(out List<AMonsterBase> list_Monsters, ExtraMonsterRequirementsDelegate requirementsDelegate = null, bool attackAbleOnly = false, bool ignoreVision = true, bool includeMonsterSizeRange = true)
	{
		list_Monsters = null;
		return false;
	}

	public bool IsPointInBounds(Vector3 point, Vector3 center, Vector3 size, float monsterSizeOffset)
	{
		return false;
	}
}
