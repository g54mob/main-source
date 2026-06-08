using System;
using UnityEngine;

namespace GRP
{
	public class MaterialBlockContainer
	{
		public Renderer renderer;

		public MaterialPropertyBlock[] materialBlocks;

		public Material[] materials;

		public MaterialBlockContainer(Renderer renderer, int length)
		{
		}

		public void UpdateMaterialBlocks()
		{
		}

		public void UpdateMaterialBlock(int index)
		{
		}

		public void For(Action<MaterialPropertyBlock> call)
		{
		}

		public void SetMaterial(MaterialRowConfig material)
		{
		}

		public void SetMaterial(Material material)
		{
		}

		public void SetMaterial(int index, Material material)
		{
		}

		public void SetEdgeCornerAll()
		{
		}

		public void SetEdgeCornerAll(int index)
		{
		}

		public void SetEdgeAll()
		{
		}

		public void SetEdgeAll(int index)
		{
		}

		public void SetCornerAll()
		{
		}

		public void SetCornerAll(int index)
		{
		}

		public void SetEdgeTopBottom()
		{
		}

		public void SetEdgeTopBottom(int index)
		{
		}

		public void SetEdge(bool top, bool bottom, bool right, bool left)
		{
		}

		public void SetEdge(int index, bool bottom, bool top, bool left, bool right)
		{
		}

		public void SetCorner(bool bottomLeft, bool topLeft, bool topRight, bool bottomRight)
		{
		}

		public void SetCorner(int index, bool bottomLeft, bool topLeft, bool topRight, bool bottomRight)
		{
		}

		public void SetMagic(float scale, float power)
		{
		}

		public void SetMagic(int index, float scale, float power)
		{
		}

		public void SetMagicPower(float power)
		{
		}

		public void SetMagicPower(int index, float power)
		{
		}

		public void SetMotorInverted(bool inverted)
		{
		}

		public void SetMotorInverted(int index, bool inverted)
		{
		}

		public void SetMotorMirror(bool mirror)
		{
		}

		public void SetMotorMirror(int index, bool mirror)
		{
		}

		public void SetColor(Color color)
		{
		}

		public void SetTiling(int index, Vector2 tiling)
		{
		}

		public void SetWearTiling(int index, Vector2 tiling)
		{
		}

		public void SetOffset(Vector2 offset)
		{
		}

		public void SetOffset(int index, Vector2 offset)
		{
		}

		public void SetMagicOffset(Vector2 offset)
		{
		}

		public void SetMagicOffset(int index, Vector2 offset)
		{
		}

		public void SetOffsetWithId(Id id)
		{
		}

		public static Vector2 GetOffsetWithId(Id id)
		{
			return default(Vector2);
		}

		public static Vector2 GetMagicOffsetWithId(Id id)
		{
			return default(Vector2);
		}
	}
}
