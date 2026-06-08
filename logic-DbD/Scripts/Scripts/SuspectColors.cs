using UnityEngine;

public class SuspectColors
{
	public static readonly Color32 BLACK = new Color32(32, 32, 32, byte.MaxValue);

	public static readonly Color32 GRAY = new Color32(159, 159, 159, byte.MaxValue);

	public static readonly Color32 WHITE = Color.white;

	public static readonly Color32 BLONDE = new Color32(230, 239, 123, byte.MaxValue);

	public static readonly Color32 DARK_BROWN = new Color32(87, 54, 0, byte.MaxValue);

	public static readonly Color32 LIGHT_BROWN = new Color32(162, 121, 58, byte.MaxValue);

	public static readonly Color32 GREEN = new Color32(19, 107, 17, byte.MaxValue);

	public static readonly Color32 BLUE = new Color32(10, 64, 140, byte.MaxValue);

	public static readonly Color32 BLACK_SKIN = new Color32(114, 89, 63, byte.MaxValue);

	public static readonly Color32 BROWN_SKIN = new Color32(150, 110, 80, byte.MaxValue);

	public static readonly Color32 PEACH_SKIN = new Color32(byte.MaxValue, 220, 190, byte.MaxValue);

	public static readonly Color32[] EYE_COLORS = new Color32[4] { GREEN, BLUE, DARK_BROWN, BLACK };

	public static readonly Color32[] SKIN_COLORS = new Color32[4] { BLACK_SKIN, BROWN_SKIN, PEACH_SKIN, PEACH_SKIN };
}
