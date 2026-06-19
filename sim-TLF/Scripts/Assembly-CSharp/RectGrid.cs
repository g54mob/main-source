using UnityEngine;

public class RectGrid : MonoBehaviour
{
	[SerializeField]
	private RectTransform rectTransform;

	[SerializeField]
	private int cols = 5;

	[SerializeField]
	private int rows = 5;

	private object[,] array;

	private void Awake()
	{
		array = new object[cols, rows];
	}

	public Vector2 GetRectPosAt(int x, int y)
	{
		Rect rect = rectTransform.rect;
		float num = rect.width / (float)cols;
		float num2 = rect.height / (float)rows;
		float x2 = rect.xMin + ((float)x + 0.5f) * num;
		float y2 = rect.yMin + ((float)y + 0.5f) * num2;
		return new Vector2(x2, y2);
	}

	public Vector3 GetWorldPosAt(int x, int y)
	{
		Vector2 rectPosAt = GetRectPosAt(x, y);
		return rectTransform.TransformPoint(rectPosAt);
	}

	public Vector2 GetCellSize()
	{
		Rect rect = rectTransform.rect;
		return new Vector2(rect.width / (float)cols, rect.height / (float)rows);
	}

	private void OnDrawGizmos()
	{
		if (rectTransform == null)
		{
			return;
		}
		Rect rect = rectTransform.rect;
		float num = rect.width / (float)cols;
		float num2 = rect.height / (float)rows;
		Gizmos.color = Color.green;
		for (int i = 0; i < cols; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				Vector3 center = rectTransform.TransformPoint(rect.xMin + ((float)i + 0.5f) * num, rect.yMin + ((float)j + 0.5f) * num2, 0f);
				Gizmos.DrawSphere(center, 3f);
				Vector3 size = new Vector3(num * rectTransform.lossyScale.x, num2 * rectTransform.lossyScale.y, 0f);
				Gizmos.DrawWireCube(center, size);
			}
		}
	}
}
