using UnityEngine;

[CreateAssetMenu(fileName = "New Font Data", menuName = "Super Text Mesh/Font Data", order = 1)]
public class STMFontData : ScriptableObject
{
	public Font font;

	[Tooltip("if new quality level should be used, or to use mesh default. Automatically disabled for non-dynamic fonts.")]
	public bool overrideQuality;

	[Tooltip("Only affects dynamic fonts.")]
	[Range(1f, 512f)]
	public int quality = 64;

	[Tooltip("Whether or not the filter mode should be overridden for this font. Be wary that having the same font use different filter modes in a scene might render strange.")]
	public bool overrideFilterMode;

	public FilterMode filterMode = FilterMode.Bilinear;

	public STMFontData(Font font)
	{
		this.font = font;
	}
}
