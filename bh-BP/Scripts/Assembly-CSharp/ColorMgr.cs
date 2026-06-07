using UnityEngine;

public class ColorMgr : MonoBehaviour
{
	public static ColorMgr I;

	[NamedArray(typeof(DamageType))]
	public Color[] DamageColors;

	[NamedArray(typeof(ResourceType))]
	public Color[] ResourceColors;

	[NamedArray(typeof(UIColorType))]
	public Color[] UIColors;

	public Color StaminaColor;

	public Color HealthColor;

	private void Awake()
	{
	}

	public Color GetColor(DamageType dt)
	{
		return default(Color);
	}

	public Color GetColor(ResourceType dt)
	{
		return default(Color);
	}

	public Color GetColor(UIColorType c)
	{
		return default(Color);
	}

	public string GetUIColorTag(UIColorType c, string str)
	{
		return null;
	}
}
