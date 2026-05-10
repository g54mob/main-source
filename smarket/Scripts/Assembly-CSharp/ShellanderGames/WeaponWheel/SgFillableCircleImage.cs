using UnityEngine;
using UnityEngine.UI;

namespace ShellanderGames.WeaponWheel
{
	public class SgFillableCircleImage : Image
	{
		private static readonly Vector3[] s_Xy;

		private static readonly Vector3[] s_Uv;

		public float uvRotation;

		private Sprite activeSprite => null;

		protected override void OnPopulateMesh(VertexHelper toFill)
		{
		}

		private void GenerateFilledSprite(VertexHelper toFill)
		{
		}

		private static Vector2 RotatePoint(Vector2 pointToRotate, Vector2 centerPoint, float angleInDegrees, float c1, float c2)
		{
			return default(Vector2);
		}

		private Vector4 GetDrawingDimensions()
		{
			return default(Vector4);
		}

		private static bool RadialCut(Vector3[] xy, Vector3[] uv, float fill, bool invert, int corner)
		{
			return false;
		}

		private static void RadialCut(Vector3[] xy, float cos, float sin, bool invert, int corner)
		{
		}

		private static void AddQuad(VertexHelper vertexHelper, Vector3[] quadPositions, Color32 color, Vector3[] quadUVs)
		{
		}
	}
}
