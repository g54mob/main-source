using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Buildable Category")]
public class BuildableCategory : ScriptableObject, IPanelContext
{
	[SerializeField]
	private Sprite _iconSprite;

	[SerializeField]
	private LocalizedString _name;

	[SerializeField]
	private Color _uiColor = Color.black;

	public Sprite IconSprite => _iconSprite;

	public LocalizedString Name => _name;

	public Color UIColor => _uiColor;

	PanelID IPanelContext.PanelID => PanelID.BuildableCreation;
}
