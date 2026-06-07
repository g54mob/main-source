using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrifterAttributeTooltipPanel : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _descriptionText;

	[SerializeField]
	private DrifterAttributeTooltipElement _attributePreviewPrefab;

	[Header("Colors")]
	[SerializeField]
	private Color _defaultColor = Color.white;

	[SerializeField]
	private Color _negativeColor = Color.white;

	[SerializeField]
	private Color _positiveColor = Color.white;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString _expertiseLabel = "";

	private DrifterAttributes _attributes;

	private RectTransform _rectTransform;

	private List<DrifterAttributeTooltipElement> _previews = new List<DrifterAttributeTooltipElement>();

	private void Awake()
	{
		_rectTransform = base.transform as RectTransform;
	}

	private void Update()
	{
		if (base.gameObject.activeSelf)
		{
			_rectTransform.position = FlotsamInputManager.MousePosition;
		}
	}

	public void Show(DrifterAttributesEffect effect)
	{
		base.gameObject.SetActive(value: true);
		_descriptionText.text = effect.Description;
		SetAttributes(effect);
		LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
	}

	public void Show(Agent agent, DrifterAttributes.AttributeType type)
	{
		base.gameObject.SetActive(value: true);
		DrifterAttributes.Attribute attribute = agent.Attributes.ReturnAttribute(type);
		string text = attribute.Description;
		text += "\n\n";
		text += DrifterAttributes.ReturnDetailedTooltipText(agent.Attributes, attribute, type, agent.Attributes.ReturnTotalAttributePoints(type), agent.Attributes.ReturnAffinityAmount(type));
		_descriptionText.text = text;
		SetModifiers(agent, type);
		LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void SetAttributes(DrifterAttributesEffect effect)
	{
		if (_attributes == null)
		{
			_attributes = GameManager.Settings.AgentSettings.GetActorProperties<AgentProperties>().AttributeProperties;
		}
		foreach (DrifterAttributeTooltipElement preview in _previews)
		{
			preview.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < effect.Modifiers.Length; i++)
		{
			DrifterAttributeModifier drifterAttributeModifier = effect.Modifiers[i];
			ReturnTooltipElement().SetModifier(_attributes, drifterAttributeModifier, ReturnColor(drifterAttributeModifier.Modifier));
		}
	}

	private void SetModifiers(Agent agent, DrifterAttributes.AttributeType type)
	{
		foreach (DrifterAttributeTooltipElement preview in _previews)
		{
			preview.gameObject.SetActive(value: false);
		}
		AddExpertise(agent, type);
		foreach (DrifterAttributesEffect effect in agent.Attributes.Effects)
		{
			AddStatusEffect(effect, type);
		}
	}

	private void AddExpertise(Agent agent, DrifterAttributes.AttributeType type)
	{
		int num = agent.Attributes.ReturnExpertise(type);
		if (num != 0)
		{
			ReturnTooltipElement().SetModifier(_expertiseLabel, num, 0, ReturnColor(num));
		}
	}

	private void AddStatusEffect(DrifterAttributesEffect effect, DrifterAttributes.AttributeType type)
	{
		if (effect.ReturnContainsAttributeType(type))
		{
			DrifterAttributeTooltipElement drifterAttributeTooltipElement = ReturnTooltipElement();
			int modifier = effect.ReturnModifier(type);
			int affinity = effect.ReturnAffinity(type);
			_ = "" + modifier;
			drifterAttributeTooltipElement.SetModifier(effect.Name, modifier, affinity, ReturnColor(modifier));
		}
	}

	private DrifterAttributeTooltipElement ReturnTooltipElement()
	{
		foreach (DrifterAttributeTooltipElement preview in _previews)
		{
			if (!preview.gameObject.activeSelf)
			{
				preview.gameObject.SetActive(value: true);
				return preview;
			}
		}
		DrifterAttributeTooltipElement drifterAttributeTooltipElement = Object.Instantiate(_attributePreviewPrefab, base.transform);
		_previews.Add(drifterAttributeTooltipElement);
		return drifterAttributeTooltipElement;
	}

	private Color ReturnColor(int modifier)
	{
		if (modifier < 0)
		{
			return _negativeColor;
		}
		if (modifier > 0)
		{
			return _positiveColor;
		}
		return _defaultColor;
	}
}
