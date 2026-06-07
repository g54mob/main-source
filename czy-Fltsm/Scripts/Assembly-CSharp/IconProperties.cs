using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/UI/Icon Properties")]
public class IconProperties : ScriptableObject
{
	[Tooltip("Sprite for this icon.")]
	public Sprite Sprite;

	[Tooltip("Text displayed when hovering over this icon. Leave empty if you don't want any tooltip.")]
	public LocalizedString TooltipText = "";
}
