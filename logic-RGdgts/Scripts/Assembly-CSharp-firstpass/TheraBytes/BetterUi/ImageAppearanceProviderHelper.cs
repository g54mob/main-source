using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public static class ImageAppearanceProviderHelper
	{
		public static void SetMaterialType(string value, Graphic graphic, VertexMaterialData materialProperties, ref MaterialEffect effect, ref string materialType)
		{
		}

		public static void SetMaterialEffect(MaterialEffect value, Graphic graphic, VertexMaterialData materialProperties, ref MaterialEffect effect, ref string materialType)
		{
		}

		private static void UpdateMaterial(Graphic graphic, VertexMaterialData materialProperties, ref MaterialEffect effect, ref string materialType)
		{
		}

		public static void SetMaterialProperty(int propertyIndex, float value, Graphic graphic, VertexMaterialData materialProperties, ref float materialProperty1, ref float materialProperty2, ref float materialProperty3)
		{
		}

		public static float GetMaterialPropertyValue(int propertyIndex, ref float materialProperty1, ref float materialProperty2, ref float materialProperty3)
		{
			return 0f;
		}

		public static void AddQuad(VertexHelper vertexHelper, Rect bounds, Vector2 posMin, Vector2 posMax, ColorMode mode, Color colorA, Color colorB, Vector2 uvMin, Vector2 uvMax, VertexMaterialData materialProperties)
		{
		}

		private static Color32 GetColor(ColorMode mode, Color a, Color b, Rect bounds, float x, float y)
		{
			return default(Color32);
		}
	}
}
