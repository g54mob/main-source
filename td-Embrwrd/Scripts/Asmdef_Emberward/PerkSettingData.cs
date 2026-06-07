using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/PerkSettingData/PerkSettingData", order = 1)]
public class PerkSettingData : AItemSettingData
{
	[Serializable]
	public class ActivateRequirement
	{
		public ePerkActivateRequirement requirementType;

		public int value;
	}

	[Serializable]
	public class MapActivateRequirement
	{
		public ePerkActivateRequirementForMap requirementType;

		public int value;
	}

	[SerializeField]
	protected ePerkType perkType;

	[SerializeField]
	protected bool doHaveParam;

	[SerializeField]
	protected int paramValue;

	[SerializeField]
	protected bool doShowPerkIcon;

	[SerializeField]
	protected bool doHaveDuration;

	[SerializeField]
	protected int duration;

	[SerializeField]
	[Header("無盡模式中的啟動條件")]
	protected List<ActivateRequirement> list_ActivateRequirement;

	[SerializeField]
	[Header("地圖上可以出現的條件")]
	protected List<MapActivateRequirement> list_MapActivateRequirement;

	[SerializeField]
	protected bool doShowTooltipName;

	[FormerlySerializedAs("perkScenarioV2")]
	[SerializeField]
	protected ePerkScenario perkScenario;

	[Header("Perk的效果類型, 用來避免同時出現相同類型效果")]
	[SerializeField]
	protected ePerkCategory perkCategory;

	public ePerkType PerkType => default(ePerkType);

	public bool DoHaveParam => false;

	public int ParamValue => 0;

	public bool DoShowPerkIcon => false;

	public bool DoHaveDuration => false;

	public int Duration => 0;

	public bool DoShowTooltipName => false;

	public ePerkScenario PerkScenario => default(ePerkScenario);

	public ePerkCategory PerkCategory => default(ePerkCategory);

	public void Inititalize(int seed)
	{
	}

	protected virtual void InitializeProc(int seed)
	{
	}

	private bool CheckShowActivateRequirement()
	{
		return false;
	}

	private bool CheckShowMapActivateRequirement()
	{
		return false;
	}

	private Color GetColorByPerkScenario()
	{
		return default(Color);
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}

	public bool CheckActivateRequirementForEndlessMode(ePerkScenario perkScenario)
	{
		return false;
	}

	public bool CheckActivateRequirementForRogueliteMap(ePerkScenario perkScenario, int step)
	{
		return false;
	}
}
