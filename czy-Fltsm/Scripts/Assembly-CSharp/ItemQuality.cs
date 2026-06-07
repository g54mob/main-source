using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Items/Quality")]
public class ItemQuality : ScriptableObject
{
	[SerializeField]
	private LocalizedString _name = "";

	[SerializeField]
	private Color _color = Color.green;

	[SerializeField]
	private Color _labelColor = Color.green;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private int _value;

	public LocalizedString Name => _name;

	public Color Color => _color;

	public Color LabelColor => _labelColor;

	public Sprite Icon => _icon;

	public int Value => _value;
}
