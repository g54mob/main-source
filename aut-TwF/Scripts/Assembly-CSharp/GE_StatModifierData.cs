using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "GE_statModifierData_default", menuName = "Tower Factory/GameplayEffect/StatModifier")]
public class GE_StatModifierData : GameplayEffectData
{
	[Header("Stat modifier")]
	[SerializeField]
	private bool hasCustomDescription;

	[SerializeField]
	private EStats stat;

	[SerializeField]
	private bool modifyStatBase;

	[SerializeField]
	private ModifierOperation modifierOperation;

	[SerializeField]
	private float statValue;

	public EStats Stat => stat;

	public bool ModifyStatBase => modifyStatBase;

	public ModifierOperation ModifierOperation => modifierOperation;

	public float StatValue => statValue;

	public int StatValuePercentage => Mathf.RoundToInt(FunctionLibrary.RoundToDecimals(StatValue, 2) * 100f);

	public int AbsStatValuePercentage => Mathf.Abs(Mathf.RoundToInt(FunctionLibrary.RoundToDecimals(StatValue, 2) * 100f));

	public string StatName => LTFunctionLibrary.GetStatDisplayName(Stat);

	public override string Description
	{
		get
		{
			if (hasCustomDescription)
			{
				return base.Description;
			}
			if (modifyStatBase)
			{
				if (modifierOperation == ModifierOperation.Additive)
				{
					Dictionary<string, object> dictionary = new Dictionary<string, object>
					{
						{
							"stat-name",
							LTFunctionLibrary.GetStatDisplayName(Stat)
						},
						{
							"value",
							Mathf.Abs(FunctionLibrary.RoundToDecimals(StatValue, 2))
						},
						{ "stat", Stat }
					};
					return new LocalizedString("GameplayEffects", "GE_statModifier_description_base_add").GetLocalizedString(dictionary);
				}
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>
				{
					{
						"stat-name",
						LTFunctionLibrary.GetStatDisplayName(Stat)
					},
					{
						"value",
						Mathf.Abs(Mathf.RoundToInt(FunctionLibrary.RoundToDecimals(StatValue, 2) * 100f))
					},
					{ "stat", Stat }
				};
				return new LocalizedString("GameplayEffects", "GE_statModifier_description_base_multiply").GetLocalizedString(dictionary2);
			}
			if (modifierOperation == ModifierOperation.Additive)
			{
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>
				{
					{
						"stat-name",
						LTFunctionLibrary.GetStatDisplayName(Stat)
					},
					{
						"value",
						Mathf.Abs(FunctionLibrary.RoundToDecimals(StatValue, 2))
					},
					{ "stat", Stat },
					{ "max-stacks", base.MaxStacks }
				};
				return new LocalizedString("GameplayEffects", "GE_statModifier_description_add").GetLocalizedString(dictionary3);
			}
			Dictionary<string, object> dictionary4 = new Dictionary<string, object>
			{
				{
					"stat-name",
					LTFunctionLibrary.GetStatDisplayName(Stat)
				},
				{
					"value",
					Mathf.Abs(Mathf.RoundToInt(FunctionLibrary.RoundToDecimals(StatValue, 2) * 100f))
				},
				{ "stat", Stat },
				{ "max-stacks", base.MaxStacks }
			};
			return new LocalizedString("GameplayEffects", "GE_statModifier_description_multiply").GetLocalizedString(dictionary4);
		}
	}

	public StatModifier GetStatModifier()
	{
		return new StatModifier(Stat, ModifierOperation, StatValue);
	}

	protected override bool ShowDescriptionInInspector()
	{
		return hasCustomDescription;
	}

	public override GameplayEffect InstantiateEffect()
	{
		return new GE_StatModifier();
	}

	protected override bool ShowTickInInspector()
	{
		return false;
	}

	protected override bool ShowMaxStacksInInspector()
	{
		return true;
	}
}
