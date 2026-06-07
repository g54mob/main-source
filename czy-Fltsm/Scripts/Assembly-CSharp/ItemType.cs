using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Items/Types")]
public class ItemType : ScriptableObject
{
	[SerializeField]
	private Color _color = Color.white;

	[SerializeField]
	private Color _labelColor = Color.white;

	[SerializeField]
	private LocalizedString _name = "";

	[SerializeField]
	private Sprite _icon;

	public Color Color => _color;

	public Color LabelColor => _labelColor;

	public LocalizedString Name => _name;

	public Sprite Icon => _icon;
}
