using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrifterAttributeTooltipElement : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _attributeLabelText;

	[SerializeField]
	private TextMeshProUGUI _atttributeModifierText;

	[SerializeField]
	private DrifterAttributeModifierTooltip _attributeModifierTooltip;

	[SerializeField]
	private GroupPrefabDisplay _affinityDisplay;

	public Selectable Selectable { get; private set; }

	private void Awake()
	{
		Selectable = GetComponent<Selectable>();
	}

	public void SetModifier(DrifterAttributes attributes, DrifterAttributeModifier modifier, Color color)
	{
		_attributeLabelText.text = attributes.ReturnAttributeName(modifier.Type);
		if (_attributeModifierTooltip != null)
		{
			_attributeModifierTooltip.SetAttributes(attributes, modifier);
		}
		if (modifier.Modifier != 0)
		{
			_atttributeModifierText.text = modifier.ToString();
			_atttributeModifierText.color = color;
			_atttributeModifierText.gameObject.SetActive(value: true);
		}
		else
		{
			_atttributeModifierText.gameObject.SetActive(value: false);
		}
		_affinityDisplay.Display(modifier.Affinity);
	}

	public void SetModifier(string label, int modifier, int affinity, Color color)
	{
		_attributeLabelText.text = label;
		string text = "";
		if (modifier > 0)
		{
			text += "+";
		}
		text += modifier;
		_atttributeModifierText.gameObject.SetActive(modifier != 0);
		_atttributeModifierText.text = text;
		_atttributeModifierText.color = color;
		_affinityDisplay.Display(affinity);
	}
}
