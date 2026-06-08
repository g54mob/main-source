using Kitchen.Layouts;
using UnityEngine;

namespace Kitchen
{
	public static class LayoutMapGenerator
	{
		public static Texture2D GenerateFor(LayoutBlueprint blueprint, bool setShaderGlobal = true)
		{
			int num = 32;
			Bounds bounds = blueprint.GetBounds();
			int offset_x = (int)bounds.center.x - num / 2;
			int offset_y = (int)bounds.center.y - num / 2;
			int width = num;
			int num2 = num;
			Texture2D texture2D = new Texture2D(width, num2)
			{
				filterMode = FilterMode.Point,
				wrapMode = TextureWrapMode.Clamp
			};
			Color[] pixels = texture2D.GetPixels();
			for (int i = offset_x; i < offset_x + width; i++)
			{
				for (int j = offset_y; j < offset_y + num2; j++)
				{
					Room room = blueprint[new Vector2(i, j)];
					if (LayoutHelpers.IsInside(room))
					{
						pixels[pixel(i, j)] = new Color((float)room.ID * 0.05f + 0.025f, 0f, (float)room.Type * 0.05f + 0.025f);
					}
					else
					{
						pixels[pixel(i, j)] = new Color(0f, 1f, (float)room.Type * 0.05f + 0.025f);
					}
				}
			}
			texture2D.SetPixels(pixels);
			texture2D.Apply();
			if (setShaderGlobal)
			{
				Shader.SetGlobalTexture("_RoomLayout", texture2D);
			}
			return texture2D;
			int pixel(int x, int y)
			{
				return (y - offset_y) * width + (x - offset_x);
			}
		}
	}
}
