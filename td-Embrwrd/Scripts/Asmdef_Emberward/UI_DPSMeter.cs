using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class UI_DPSMeter : MonoBehaviour
{
	private class TowerDamageEntry
	{
		public eItemType towerType;

		public int damage;
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private List<UI_Obj_DPSMeter_Bar> list_Bars;

	[SerializeField]
	private Transform node_DPSMeterBarAnchor;

	[SerializeField]
	private float updateInterval;

	[SerializeField]
	private GameObject perfab_DPSMeterBar;

	private float updateTimer;

	private List<TowerDamageEntry> list_TowerDamageEntry;

	private Dictionary<eItemType, int> dict_TowerDamage;

	private int totalFireSourceDamage;

	private UI_Obj_DPSMeter_Bar fireSourceBar;

	private bool isHaveEmberSparkTalent;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void OnToggleDpsMeter(bool isOn)
	{
	}

	private void FireSourceDealDamageToMonster(AMonsterBase monster, int value)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private bool IsHaveTowerTypeInEntry(eItemType towerType)
	{
		return false;
	}
}
