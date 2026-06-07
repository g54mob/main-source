using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class SpriteRendererEx
	{
		public static Vector3 GetWorldCenterPoint(this SpriteRenderer spriteRenderer)
		{
			return spriteRenderer.transform.TransformPoint(spriteRenderer.GetModelSpaceAABB().Center);
		}

		public static Vector3 GetModelSpaceSize(this SpriteRenderer spriteRenderer)
		{
			return spriteRenderer.GetModelSpaceAABB().Size;
		}

		public static AABB GetModelSpaceAABB(this SpriteRenderer spriteRenderer)
		{
			Sprite sprite = spriteRenderer.sprite;
			if (sprite == null)
			{
				return AABB.GetInvalid();
			}
			return new AABB(new List<Vector2>(sprite.vertices));
		}

		public static bool IsPixelFullyTransparent(this SpriteRenderer spriteRenderer, Vector3 worldPos)
		{
			Sprite sprite = spriteRenderer.sprite;
			if (sprite == null)
			{
				return true;
			}
			Texture2D texture = sprite.texture;
			if (texture == null)
			{
				return true;
			}
			Vector3 pt = spriteRenderer.transform.InverseTransformPoint(worldPos);
			Plane plane = new Plane(Vector3.forward, 0f);
			Vector3 vector = plane.ProjectPoint(pt);
			AABB modelSpaceAABB = spriteRenderer.GetModelSpaceAABB();
			modelSpaceAABB.Size = new Vector3(modelSpaceAABB.Size.x, modelSpaceAABB.Size.y, 1f);
			if (!modelSpaceAABB.ContainsPoint(vector))
			{
				return true;
			}
			Vector3 vector2 = plane.ProjectPoint(modelSpaceAABB.Min);
			Vector3 vector3 = vector - vector2;
			Vector2 vector4 = new Vector2(vector3.x * sprite.pixelsPerUnit, vector3.y * sprite.pixelsPerUnit);
			vector4 += sprite.textureRectOffset;
			try
			{
				return texture.GetPixel((int)(vector4.x + 0.5f), (int)(vector4.y + 0.5f)).a <= 0.001f;
			}
			catch (UnityException ex)
			{
				return ex != null && false;
			}
		}
	}
}
