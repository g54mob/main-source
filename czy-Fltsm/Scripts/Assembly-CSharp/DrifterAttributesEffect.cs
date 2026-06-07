using I2.Loc;
using PajamaLlama.SurvivalGuide;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Attribute Effect")]
public class DrifterAttributesEffect : PersistentProperties, ISurvivalGuideIdentifiable
{
	public LocalizedString Name = null;

	public LocalizedString Description = null;

	public DrifterLookProperties Look;

	public bool ForceGender;

	[ConditionalHide("ForceGender")]
	public Agent.EGender Gender;

	public IconProperties IconProperties;

	public DrifterAttributeModifier[] Modifiers;

	[Header("Assignment")]
	public AssignmentType Assignment;

	public AssignmentPriority AssignmentPriority = AssignmentPriority.Lowest;

	[Header("Quirks")]
	[SerializeField]
	private QuirkBase[] _quirks;

	[Header("Scouting")]
	[SerializeField]
	private WorldMapScoutingId _scoutingId;

	public override Types Type => Types.DrifterAttributeEffect;

	public string SurvivalGuideIdentifier => "drifterattributeeffect-" + base.name.ToLower();

	public WorldMapScoutingId ScoutingId => _scoutingId;

	public int ReturnModifier(DrifterAttributes.AttributeType attributeType)
	{
		if (Modifiers == null)
		{
			return 0;
		}
		DrifterAttributeModifier[] modifiers = Modifiers;
		foreach (DrifterAttributeModifier drifterAttributeModifier in modifiers)
		{
			if (drifterAttributeModifier.Type == attributeType)
			{
				return drifterAttributeModifier.Modifier;
			}
		}
		return 0;
	}

	public int ReturnAffinity(DrifterAttributes.AttributeType attributeType)
	{
		if (Modifiers == null)
		{
			return 0;
		}
		DrifterAttributeModifier[] modifiers = Modifiers;
		foreach (DrifterAttributeModifier drifterAttributeModifier in modifiers)
		{
			if (drifterAttributeModifier.Type == attributeType)
			{
				return drifterAttributeModifier.Affinity;
			}
		}
		return 0;
	}

	public bool ReturnContainsAttributeType(DrifterAttributes.AttributeType attributeType)
	{
		if (Modifiers == null)
		{
			return false;
		}
		DrifterAttributeModifier[] modifiers = Modifiers;
		for (int i = 0; i < modifiers.Length; i++)
		{
			if (modifiers[i].Type == attributeType)
			{
				return true;
			}
		}
		return false;
	}

	public void ApplyQuirks(Agent agent)
	{
		if (!_quirks.IsNullOrEmpty())
		{
			QuirkBase[] quirks = _quirks;
			for (int i = 0; i < quirks.Length; i++)
			{
				quirks[i].ApplyToDrifter(agent);
			}
		}
	}

	public void RemoveQuirks(Agent agent)
	{
		if (!_quirks.IsNullOrEmpty())
		{
			QuirkBase[] quirks = _quirks;
			for (int i = 0; i < quirks.Length; i++)
			{
				quirks[i].RemoveFromDrifter(agent);
			}
		}
	}
}
