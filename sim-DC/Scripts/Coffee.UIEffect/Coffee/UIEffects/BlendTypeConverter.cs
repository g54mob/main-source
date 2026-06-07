using UnityEngine.Rendering;

namespace Coffee.UIEffects
{
	internal static class BlendTypeConverter
	{
		public static (BlendMode, BlendMode) Convert(this (BlendType type, BlendMode src, BlendMode dst) self)
		{
			return default((BlendMode, BlendMode));
		}

		public static BlendType Convert(this (BlendMode src, BlendMode dst) self)
		{
			return default(BlendType);
		}
	}
}
