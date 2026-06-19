using System;

namespace Loxodon.Framework.Localizations
{
	[Serializable]
	public enum ValueType
	{
		String = 0,
		Boolean = 1,
		Int = 2,
		Float = 3,
		Color = 4,
		Vector2 = 5,
		Vector3 = 6,
		Vector4 = 7,
		Sprite = 8,
		Texture2D = 9,
		Texture3D = 10,
		AudioClip = 11,
		VideoClip = 12,
		Material = 13,
		Font = 14,
		GameObject = 15
	}
}
