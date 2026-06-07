using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionMaterialExtensions
	{
		public static MotionHandle BindToMaterialFloat<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Material material, string name) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(material);
			return builder.Bind(material, name, delegate(float x, Material material2, string name2)
			{
				material2.SetFloat(name2, x);
			});
		}

		public static MotionHandle BindToMaterialFloat<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Material material, int nameID) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(material);
			return builder.Bind(material, Box.Create(nameID), delegate(float x, Material material2, Box<int> box)
			{
				material2.SetFloat(box.Value, x);
			});
		}

		public static MotionHandle BindToMaterialInt<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, Material material, string name) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(material);
			return builder.Bind(material, name, delegate(int x, Material material2, string name2)
			{
				material2.SetInteger(name2, x);
			});
		}

		public static MotionHandle BindToMaterialInt<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, Material material, int nameID) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(material);
			return builder.Bind(material, Box.Create(nameID), delegate(int x, Material material2, Box<int> box)
			{
				material2.SetInteger(box.Value, x);
			});
		}

		public static MotionHandle BindToMaterialColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, Material material, string name) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(material);
			return builder.Bind(material, name, delegate(Color x, Material material2, string name2)
			{
				material2.SetColor(name2, x);
			});
		}

		public static MotionHandle BindToMaterialColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, Material material, int nameID) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(material);
			return builder.Bind(material, Box.Create(nameID), delegate(Color x, Material material2, Box<int> box)
			{
				material2.SetColor(box.Value, x);
			});
		}
	}
}
