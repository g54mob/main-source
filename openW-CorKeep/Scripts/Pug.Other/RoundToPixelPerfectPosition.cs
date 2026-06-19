using UnityEngine;

public static class RoundToPixelPerfectPosition
{
	public static float RoundFloat(float f, float ppu = 16f)
	{
		return Mathf.Round(f * ppu) / ppu;
	}

	public static Vector3 RoundPosition(Vector3 p, float ppu = 16f)
	{
		return new Vector3(RoundFloat(p.x, ppu), RoundFloat(p.y, ppu), RoundFloat(p.z, ppu));
	}
}
