using UnityEngine;

public class GlobalQuickOutline : MonoBehaviour
{
	public Color selectedColor;

	public Color failColor;

	public Color highlightColor;

	public Color scopeColor;

	public Color tiePointColor;

	public float outlineThickness;

	public static float Thickness => 0f;

	private static GlobalQuickOutline inst { get; set; }

	public static Color SelectedColor => default(Color);

	public static Color FailColor => default(Color);

	public static Color HighlightColor => default(Color);

	public static Color ScopeColor => default(Color);

	public static Color TiePointColor => default(Color);

	private void Awake()
	{
	}
}
