using UnityEngine;

public class Shape : MonoBehaviour
{
	public Color lineColor = Color.green;

	public bool drawAxes = true;

	private void OnDrawGizmos()
	{
		if (drawAxes)
		{
			Gizmos.color = Color.green * 0.5f;
			Gizmos.DrawLine(base.transform.position + base.transform.up * 4f, base.transform.position - base.transform.up * 4f);
			Gizmos.color = Color.red * 0.5f;
			Gizmos.DrawLine(base.transform.position + base.transform.right * 4f, base.transform.position - base.transform.right * 4f);
		}
		int childCount = base.transform.childCount;
		if (childCount >= 2)
		{
			for (int i = 1; i < childCount; i++)
			{
				Gizmos.color = lineColor;
				Gizmos.DrawLine(base.transform.GetChild(i - 1).position, base.transform.GetChild(i).position);
			}
		}
	}

	public Vector2[] GetPoints2D(float scale = 1f)
	{
		Vector3[] points = GetPoints(scale);
		Vector2[] array = new Vector2[points.Length];
		for (int i = 0; i < points.Length; i++)
		{
			array[i] = points[i];
		}
		return array;
	}

	public Vector3[] GetPoints(float scale = 1f)
	{
		if (base.transform.childCount == 0)
		{
			return null;
		}
		Vector3[] array = new Vector3[base.transform.childCount];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = base.transform.GetChild(i).localPosition * scale;
		}
		return array;
	}

	public void Mirror()
	{
		if (base.transform.childCount != 0)
		{
			int childCount = base.transform.childCount;
			Transform[] array = new Transform[childCount];
			for (int num = childCount - 1; num >= 0; num--)
			{
				Transform child = base.transform.GetChild(num);
				GameObject gameObject = new GameObject("m_" + child.name);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localPosition = new Vector3(0f - child.localPosition.x, child.localPosition.y, child.localPosition.z);
				array[num] = gameObject.transform;
			}
		}
	}

	public void Reverse()
	{
		for (int i = 0; i < base.transform.childCount; i++)
		{
			base.transform.GetChild(0).SetSiblingIndex(base.transform.childCount - (i + 1));
		}
	}
}
