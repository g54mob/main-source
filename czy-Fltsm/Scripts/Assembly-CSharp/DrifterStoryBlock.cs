using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrifterStoryBlock : MonoBehaviour, ILocalizationGenderProvider, ILocalizationParamsManager
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private TextMeshProUGUI _description;

	[SerializeField]
	private ChildBehaviourCache<DrifterAttributeTooltipElement> _attributeModifierPrefab;

	[SerializeField]
	private Color _attributeModifierColor;

	private AgentDescriptor _drifterDescriptor;

	Agent.EGender ILocalizationGenderProvider.LocalizationGender
	{
		get
		{
			if (!(_drifterDescriptor != null))
			{
				return Agent.EGender.Male;
			}
			return _drifterDescriptor.Gender;
		}
	}

	private void OnEnable()
	{
		LocalizationManager.ParamManagers.AddUnique(this);
	}

	private void OnDisable()
	{
		LocalizationManager.ParamManagers.Remove(this);
	}

	public void Initialize(Agent agent, DrifterAttributesEffect background)
	{
		_drifterDescriptor = agent.Descriptor;
		_icon.sprite = background.IconProperties.Sprite;
		_title.text = background.Name;
		_description.text = background.Description;
		_attributeModifierPrefab.Reset();
		DrifterAttributeModifier[] modifiers = background.Modifiers;
		foreach (DrifterAttributeModifier modifier in modifiers)
		{
			_attributeModifierPrefab.Get(active: true).SetModifier(agent.Attributes, modifier, _attributeModifierColor);
		}
		_attributeModifierPrefab.Trim();
	}
}
