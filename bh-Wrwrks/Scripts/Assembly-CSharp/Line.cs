using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
	public bool noHitbox;

	public LineRenderer line;

	public LineRenderer shadow;

	public LineRenderer highlight;

	public PolygonCollider2D hitbox;

	public bool branchable;

	public bool encloser;

	private List<Vector2> points;

	public int maxLength = -1;

	public Plug plug;

	public int order;

	public int orderUp => order + 21000;

	public int orderShadow => order - 2;

	public int orderShadowUp => orderShadow + 21000;

	public int orderHigh => order - 1;

	public int orderHighUp => orderHigh + 21000;

	private void Start()
	{
	}

	public void Clear()
	{
		points = null;
		line.positionCount = 0;
		Vector3[] positions = new Vector3[0];
		line.SetPositions(positions);
	}

	public void Die()
	{
		hitbox.attachedRigidbody.simulated = false;
		hitbox.points = new List<Vector2>().ToArray();
		StartCoroutine(death());
	}

	private IEnumerator death()
	{
		for (int i = 0; i < 5; i++)
		{
			line.startColor -= new Color(0f, 0f, 0f, 0.2f);
			line.endColor -= new Color(0f, 0f, 0f, 0.2f);
			yield return null;
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void UpdateLine(Vector2 mousePos)
	{
		if (points == null)
		{
			points = new List<Vector2>();
			SetPoint(mousePos);
		}
		else if (Vector2.Distance(points.Last(), mousePos) > 0.1f)
		{
			if (maxLength != -1)
			{
				LengthCheck(mousePos);
			}
			SetPoint(mousePos);
		}
	}

	private float TotalLength()
	{
		Vector3[] array = new Vector3[line.positionCount];
		line.GetPositions(array);
		List<float> list = new List<float>();
		list.Add(0f);
		for (int i = 0; i < array.Length - 1; i++)
		{
			float item = list[i] + Vector2.Distance(array[i], array[i + 1]);
			list.Add(item);
		}
		return list.Last();
	}

	private void LengthCheck(Vector2 newPoint)
	{
		Vector3[] array = new Vector3[line.positionCount];
		line.GetPositions(array);
		List<float> list = new List<float>();
		list.Add(0f);
		for (int i = 0; i < array.Length - 1; i++)
		{
			float item = list[i] + Vector2.Distance(array[i], array[i + 1]);
			list.Add(item);
		}
		if (!(list.Last() + Vector2.Distance(array.Last(), newPoint) > (float)maxLength))
		{
			return;
		}
		bool flag = false;
		int num = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (list.Last() - list[j] + Vector2.Distance(array.Last(), newPoint) <= (float)maxLength)
			{
				flag = true;
				num = j;
				break;
			}
		}
		if (!flag)
		{
			points.Clear();
			points.Add(newPoint);
			line.SetPosition(0, newPoint);
			line.positionCount = 1;
			return;
		}
		List<Vector2> list2 = new List<Vector2>();
		int num2 = 0;
		for (int k = num; k < array.Length; k++)
		{
			list2.Add(array[k]);
			line.SetPosition(num2, array[k]);
			num2++;
		}
		line.positionCount = list2.Count;
		points = list2;
	}

	private void SetPoint(Vector2 point)
	{
		points.Add(point);
		float num = line.startWidth / 2f;
		line.positionCount = points.Count;
		line.SetPosition(points.Count - 1, point);
		shadow.sortingLayerName = line.sortingLayerName;
		shadow.sortingOrder = line.sortingOrder - 2;
		LineRenderer lineRenderer = shadow;
		float startWidth = (shadow.endWidth = line.startWidth);
		lineRenderer.startWidth = startWidth;
		shadow.numCapVertices = line.numCapVertices;
		shadow.numCornerVertices = line.numCornerVertices;
		LineRenderer lineRenderer2 = shadow;
		Color endColor = (shadow.startColor = Utils.GetColor("0E071B"));
		lineRenderer2.endColor = endColor;
		shadow.positionCount = points.Count;
		shadow.SetPosition(points.Count - 1, point + new Vector2(0f, -0.0625f));
		highlight.material = Dungeon.Instance.shadowMat;
		highlight.sortingLayerName = line.sortingLayerName;
		highlight.sortingOrder = line.sortingOrder - 1;
		LineRenderer lineRenderer3 = highlight;
		startWidth = (highlight.endWidth = line.startWidth + 0.125f);
		lineRenderer3.startWidth = startWidth;
		highlight.numCapVertices = line.numCapVertices;
		highlight.numCornerVertices = line.numCornerVertices;
		LineRenderer lineRenderer4 = highlight;
		endColor = (highlight.startColor = new Color(1f, 1f, 1f, 0f));
		lineRenderer4.endColor = endColor;
		highlight.positionCount = points.Count;
		highlight.SetPosition(points.Count - 1, point);
		if (noHitbox)
		{
			return;
		}
		List<Vector2> list = new List<Vector2>();
		List<Vector2> list2 = new List<Vector2>();
		if (points.Count > 1 && encloser)
		{
			hitbox.points = points.ToArray();
		}
		if (points.Count <= 1 || encloser)
		{
			return;
		}
		for (int i = 0; i < points.Count; i++)
		{
			Vector2 vector = points[i];
			bool flag = false;
			Vector2 vector2;
			if (i == points.Count - 1)
			{
				flag = true;
				vector2 = points[i - 1];
			}
			else
			{
				vector2 = points[i + 1];
			}
			float num3 = Mathf.Atan(Mathf.Abs(vector2.y - vector.y) / Mathf.Abs(vector2.x - vector.x));
			num3 = MathF.PI / 2f - num3;
			Vector2 vector3 = num * new Vector2(Mathf.Cos(num3), Mathf.Sin(num3));
			Vector2 item;
			Vector2 item2;
			if (vector2.x >= vector.x && vector2.y >= vector.y)
			{
				item = vector + new Vector2(vector3.x, 0f - vector3.y);
				item2 = vector + new Vector2(0f - vector3.x, vector3.y);
			}
			else if (vector2.x < vector.x && vector2.y > vector.y)
			{
				item = vector + new Vector2(vector3.x, vector3.y);
				item2 = vector + new Vector2(0f - vector3.x, 0f - vector3.y);
			}
			else if (vector2.x < vector.x && vector2.y < vector.y)
			{
				item = vector + new Vector2(0f - vector3.x, vector3.y);
				item2 = vector + new Vector2(vector3.x, 0f - vector3.y);
			}
			else
			{
				flag = !flag;
				item = vector + new Vector2(0f - vector3.x, 0f - vector3.y);
				item2 = vector + new Vector2(vector3.x, vector3.y);
			}
			if (flag)
			{
				list.Add(item2);
				list2.Add(item);
			}
			else
			{
				list.Add(item);
				list2.Add(item2);
			}
		}
		List<Vector2> list3 = new List<Vector2>(list);
		list2.Reverse();
		list3.AddRange(list2);
		hitbox.points = list3.ToArray();
		if (GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Kinematic)
		{
			GetComponent<Rigidbody2D>().simulated = true;
		}
	}

	public void EndLine()
	{
		line.endWidth = line.startWidth;
		if (GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
		{
			GetComponent<Rigidbody2D>().simulated = true;
			GetComponent<Rigidbody2D>().mass = TotalLength() * 0.3f;
		}
		if (encloser)
		{
			if (!(Vector2.Distance(points.First(), points.Last()) < 20f))
			{
				return;
			}
			GetComponent<Rigidbody2D>().simulated = true;
			line.loop = true;
		}
		if (points.Count == 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
	}

	private void OnMouseDown()
	{
		float num = Vector3.Distance(Plug.GetMousePos(), plug.transform.position - new Vector3(0f, 0f, plug.transform.position.z));
		float num2 = ((plug.connectedPlug == null) ? 999f : Vector3.Distance(Plug.GetMousePos(), plug.connectedPlug.transform.position - new Vector3(0f, 0f, plug.connectedPlug.transform.position.z)));
		if (num < 0.5f && num2 < 0.5f)
		{
			if (num > num2)
			{
				num = 1f;
			}
			else
			{
				num2 = 1f;
			}
		}
		if (num < 0.5f)
		{
			plug.dungeon.ClickPlug(plug);
		}
		else if (num2 < 0.5f)
		{
			plug.dungeon.ClickPlug(plug.connectedPlug);
		}
	}

	private void OnMouseEnter()
	{
		if (!(plug == null))
		{
			plug.dungeon.hoveredModule = plug.owner;
			Highlight();
			plug.Highlight();
			if (plug.connectedPlug != null)
			{
				plug.connectedPlug.Highlight();
			}
		}
	}

	private void OnMouseExit()
	{
		if (!(plug == null))
		{
			plug.dungeon.hoveredModule = null;
			Unhighlight();
			plug.Unhighlight();
			if (plug.connectedPlug != null)
			{
				plug.connectedPlug.Unhighlight();
			}
		}
	}

	public void Highlight()
	{
		LineRenderer lineRenderer = highlight;
		Color startColor = (highlight.endColor = Color.white);
		lineRenderer.startColor = startColor;
	}

	public void Unhighlight()
	{
		LineRenderer lineRenderer = highlight;
		Color startColor = (highlight.endColor = new Color(1f, 1f, 1f, 0f));
		lineRenderer.startColor = startColor;
	}

	private void OnMouseOver()
	{
		if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse2))
		{
			if (Dungeon.Instance.state == Dungeon.State.Combat)
			{
				plug.owner.board.CombatError(plug.owner);
				return;
			}
			plug.dungeon.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f);
			plug.Disconnect();
		}
	}
}
