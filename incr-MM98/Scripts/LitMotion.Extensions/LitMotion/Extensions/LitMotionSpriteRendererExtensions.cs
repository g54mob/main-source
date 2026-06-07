using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionSpriteRendererExtensions
	{
		public static MotionHandle BindToColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, SpriteRenderer spriteRenderer) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(spriteRenderer);
			return builder.Bind(spriteRenderer, delegate(Color x, SpriteRenderer m)
			{
				m.color = x;
			});
		}

		public static MotionHandle BindToColorR<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, SpriteRenderer spriteRenderer) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(spriteRenderer);
			return builder.Bind(spriteRenderer, delegate(float x, SpriteRenderer m)
			{
				Color color = m.color;
				color.r = x;
				m.color = color;
			});
		}

		public static MotionHandle BindToColorG<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, SpriteRenderer spriteRenderer) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(spriteRenderer);
			return builder.Bind(spriteRenderer, delegate(float x, SpriteRenderer m)
			{
				Color color = m.color;
				color.g = x;
				m.color = color;
			});
		}

		public static MotionHandle BindToColorB<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, SpriteRenderer spriteRenderer) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(spriteRenderer);
			return builder.Bind(spriteRenderer, delegate(float x, SpriteRenderer m)
			{
				Color color = m.color;
				color.b = x;
				m.color = color;
			});
		}

		public static MotionHandle BindToColorA<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, SpriteRenderer spriteRenderer) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(spriteRenderer);
			return builder.Bind(spriteRenderer, delegate(float x, SpriteRenderer m)
			{
				Color color = m.color;
				color.a = x;
				m.color = color;
			});
		}
	}
}
