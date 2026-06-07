using TMPro;
using UnityEngine;

public class CrewExpertisePanelEntry : MonoBehaviour
{
	[SerializeField]
	private DrifterAttributes _attributeProperties;

	[SerializeField]
	private TMP_Text _name;

	[SerializeField]
	private TMP_Text _modifier;

	[SerializeField]
	private GroupPrefabDisplay _affinity;

	[Header("Color")]
	[SerializeField]
	private Color _positiveColor = Color.black;

	[SerializeField]
	private Color _neutralColor = Color.black;

	public DrifterAttributes.AttributeType Type { get; private set; }

	public void Initialize(DrifterAttributes.AttributeType type, int modifier, int affinity)
	{
		Type = type;
		DrifterAttributes.Attribute attribute = _attributeProperties.ReturnAttribute(type);
		_name.text = attribute.Name;
		_modifier.text = modifier.ToString();
		_affinity.Display(affinity);
		_modifier.color = ((modifier == 0) ? _neutralColor : _positiveColor);
	}
}
