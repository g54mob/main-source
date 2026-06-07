using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Fuselage
{
	public class GridScript : MonoBehaviour
	{
		public float GridSize { get; private set; }

		public Vector3 Offset { get; private set; }

		public static GridScript Create(float gridSize, Vector2 min, Vector2 max, float originLineSize, Vector3 offset)
		{
			Material material = Game.Instance.ResourceLoader.LoadMaterial("Design/Materials/GridLine");
			Material material2 = Game.Instance.ResourceLoader.LoadMaterial("Design/Materials/GridLineBold");
			GameObject gameObject = new GameObject("Grid");
			GridScript gridScript = gameObject.AddComponent<GridScript>();
			gridScript.GridSize = gridSize;
			gridScript.Offset = Vector3.Scale(offset, new Vector3(1f, 0f, 1f));
			Transform transform = new GameObject("Lines").transform;
			transform.SetParent(gameObject.transform, worldPositionStays: false);
			transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
			transform.localScale = Vector3.one;
			transform.localPosition = Vector3.zero;
			Vector2 vector = max - min;
			Vector2 vector2 = (min + max) * 0.5f;
			CreateQuadLine(transform, new Vector2(0f, 0f), new Vector2(0.025f, originLineSize * 2f), material2);
			CreateQuadLine(transform, new Vector2(0f, 0f), new Vector2(originLineSize * 2f, 0.025f), material2);
			if (gridSize > 0f)
			{
				float num;
				for (num = gridSize; num < 0.2f; num *= 2f)
				{
				}
				for (float num2 = num; num2 <= originLineSize; num2 += num)
				{
					CreateQuadLine(transform, new Vector2(num2, 0f), new Vector2(0.025f, originLineSize * 2f), material);
					CreateQuadLine(transform, new Vector2(0f - num2, 0f), new Vector2(0.025f, originLineSize * 2f), material);
				}
				for (float num3 = num; num3 <= originLineSize; num3 += num)
				{
					CreateQuadLine(transform, new Vector2(0f, num3), new Vector2(originLineSize * 2f, 0.025f), material);
					CreateQuadLine(transform, new Vector2(0f, 0f - num3), new Vector2(originLineSize * 2f, 0.025f), material);
				}
			}
			CreateQuadLine(transform, new Vector2(vector2.x, vector2.y + vector.y / 2f), new Vector2(vector.x, 0.025f), material2);
			CreateQuadLine(transform, new Vector2(vector2.x + vector.x / 2f, vector2.y), new Vector2(0.025f, vector.y), material2);
			CreateQuadLine(transform, new Vector2(vector2.x, vector2.y - vector.y / 2f), new Vector2(vector.x, 0.025f), material2);
			CreateQuadLine(transform, new Vector2(vector2.x - vector.x / 2f, vector2.y), new Vector2(0.025f, vector.y), material2);
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.transform.SetParent(gridScript.transform, worldPositionStays: false);
			obj.transform.localScale = new Vector3(vector.x, 0.025f, vector.y);
			obj.transform.SetLocalPositionAndRotation(new Vector3(vector2.x, 0f, vector2.y), Quaternion.identity);
			obj.GetComponent<MeshRenderer>().material = material;
			return gridScript;
		}

		public Vector3 GetGridPosition(Vector3 position, Vector3? startingPosition = null)
		{
			if (GridSize > 0f)
			{
				Vector3 vector = Vector3.zero;
				if (startingPosition.HasValue)
				{
					Vector3 vector2 = base.transform.InverseTransformPoint(startingPosition.Value);
					vector = vector2.normalized;
					vector *= vector2.magnitude % GridSize - 2f * (vector2 + Offset).magnitude % GridSize;
				}
				Vector3 vector3 = base.transform.InverseTransformPoint(position) - vector;
				vector3 = MathUtils.RoundToGrid(vector3, GridSize);
				return base.transform.TransformPoint(vector3 + vector);
			}
			return position;
		}

		private static void CreateQuadLine(Transform parent, Vector2 position, Vector2 scale, Material material)
		{
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
			obj.transform.SetParent(parent);
			obj.transform.localScale = new Vector3(scale.x, scale.y, 1f);
			obj.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			obj.transform.localPosition = new Vector3(position.x, position.y, 0f);
			obj.GetComponent<MeshRenderer>().material = material;
		}
	}
}
