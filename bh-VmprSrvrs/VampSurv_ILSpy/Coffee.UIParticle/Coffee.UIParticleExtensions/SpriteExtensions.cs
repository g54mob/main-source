using System;
using UnityEngine;

namespace Coffee.UIParticleExtensions;

internal static class SpriteExtensions
{
	internal static Texture2D GetActualTexture(Sprite self)
	{
		if ((object)self != null && ((UnityEngine.Object)self).m_CachedPtr != (IntPtr)0)
		{
			return self.texture;
		}
		return null;
	}
}
