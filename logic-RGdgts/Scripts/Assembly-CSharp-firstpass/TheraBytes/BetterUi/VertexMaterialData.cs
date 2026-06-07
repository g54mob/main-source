using System;
using System.Collections.Generic;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class VertexMaterialData
	{
		[Serializable]
		public abstract class Property<T>
		{
			public string Name;

			public T Value;

			public abstract void SetValue(ref float uvX, ref float uvY, ref float tangentW);

			public abstract Property<T> Clone();
		}

		[Serializable]
		public class FloatProperty : Property<float>
		{
			public enum Mapping
			{
				TexcoordX = 0,
				TexcoordY = 1,
				TangentW = 2
			}

			public Mapping PropertyMap;

			public float Min;

			public float Max;

			public bool IsRestricted => false;

			public override void SetValue(ref float uvX, ref float uvY, ref float tangentW)
			{
			}

			public override Property<float> Clone()
			{
				return null;
			}
		}

		public FloatProperty[] FloatProperties;

		public void Apply(ref float uvX, ref float uvY, ref float tangentW)
		{
		}

		private static void Apply<T>(IEnumerable<Property<T>> prop, ref float uvX, ref float uvY, ref float tangentW)
		{
		}

		public void Clear()
		{
		}

		public void CopyTo(VertexMaterialData target)
		{
		}

		public VertexMaterialData Clone()
		{
			return null;
		}

		private static T[] CloneArray<T, TValue>(T[] array) where T : Property<TValue>
		{
			return null;
		}
	}
}
