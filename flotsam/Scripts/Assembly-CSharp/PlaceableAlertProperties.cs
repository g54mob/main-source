using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Malfunction Properties")]
public class PlaceableAlertProperties : ScriptableObject
{
	public enum AlertType
	{
		Minor = 0,
		Major = 1
	}

	[Tooltip("Minor malfunctions will only show in the buildable panel, while major will also show in the in-game world.")]
	public AlertType Alert;

	[Tooltip("Text displayed when Icon is a malfunction and appears in malfunction's panel.")]
	[FormerlySerializedAs("TooltipSummary")]
	public LocalizedString Summary = "";

	[Tooltip("Icon properties for this.")]
	[FormerlySerializedAs("IconProperties")]
	public IconProperties UIIconProperties;

	[Tooltip("Icon to show in world.")]
	[ConditionalEnumHide("Alert", 1, false)]
	public IconProperties WorldIconProperties;
}
