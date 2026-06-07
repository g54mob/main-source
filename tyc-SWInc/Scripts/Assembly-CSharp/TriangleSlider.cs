using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class TriangleSlider : MaskableGraphic, IPointerDownHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ILayoutController, ICursorOverride
{
	public Texture MainTex;

	public bool ReadOnly;

	public bool AutoSize;

	public float MaxWidth = 512f;

	private bool _isDragging;

	public UnityEvent OnValueChanged;

	public Vector2 NormalizedCursorPos = new Vector2(0.5f, 0.5f);

	[NonSerialized]
	public List<ValueTuple<Vector2, Color, SoftwareProduct>> ExtraPoints = new List<ValueTuple<Vector2, Color, SoftwareProduct>>();

	[NonSerialized]
	private bool _isInside;

	[NonSerialized]
	private string _cursor;

	private bool _tipping;

	[Range(0f, 1f)]
	public float A;

	[Range(0f, 1f)]
	public float B;

	[Range(0f, 1f)]
	public float C;

	public float Sum;

	private static Vector2[] Corners = new Vector2[3]
	{
		new Vector2(0f, 1f),
		new Vector2(1f, 1f),
		new Vector2(0.5f, 0f)
	};

	public override Texture mainTexture
	{
		get
		{
			return MainTex;
		}
	}

	public string CursorOverrideName
	{
		get
		{
			return _cursor;
		}
	}

	public void UpdateGraphics()
	{
		SetVerticesDirty();
	}

	public void ApplyRatio(float x, float y, float z)
	{
		NormalizedCursorPos = RatioToVector(x, y, z);
		UpdateValues();
		SetVerticesDirty();
	}

	public static Vector2 RatioToVector(float x, float y, float z)
	{
		float num = x + y + z;
		x /= num;
		y /= num;
		z /= num;
		Vector2 vector = (Corners[0] + (Corners[2] - Corners[0]) * DivVals(z, z + x)) * (z + x);
		Vector2 vector2 = (Corners[1] + (Corners[0] - Corners[1]) * DivVals(x, x + y)) * (x + y);
		Vector2 vector3 = (Corners[2] + (Corners[1] - Corners[2]) * DivVals(y, z + y)) * (z + y);
		return new Vector2((vector.x + vector2.x + vector3.x) / 2f, (vector.y + vector2.y + vector3.y) / 2f);
	}

	public float GetValue(int idx)
	{
		switch (idx)
		{
		case 0:
			return A;
		case 1:
			return B;
		case 2:
			return C;
		default:
			return -1f;
		}
	}

	private static float DivVals(float a, float b)
	{
		if (b == 0f)
		{
			return 0f;
		}
		return a / b;
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		Vector2 corner;
		Vector2 corner2;
		base.rectTransform.GetCorners(out corner, out corner2);
		vh.Clear();
		Vector2 uv = new Vector2(0.5f, 0.5f);
		vh.AddVert(new Vector3(corner.x, corner2.y, 0f), new Color32(byte.MaxValue, 10, 10, byte.MaxValue), uv);
		vh.AddVert(new Vector3(corner2.x, corner2.y, 0f), new Color32(10, byte.MaxValue, 10, byte.MaxValue), uv);
		vh.AddVert(new Vector3((corner.x + corner2.x) / 2f, corner.y, 0f), new Color32(10, 10, byte.MaxValue, byte.MaxValue), uv);
		vh.AddVert(new Vector3((corner.x + corner2.x) / 2f, corner.y + (corner2.y - corner.y) * (2f / 3f), 0f), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), uv);
		vh.AddTriangle(0, 1, 3);
		vh.AddTriangle(1, 2, 3);
		vh.AddTriangle(2, 0, 3);
		Vector2 vector = corner + Vector2.Scale(corner2 - corner, NormalizedCursorPos);
		float num = Mathf.Max(A, B, C);
		Color color = new Color(A / num, B / num, C / num);
		float num2 = Mathf.Clamp(Mathf.Min(base.rectTransform.rect.width, base.rectTransform.rect.height) / 24f, 4f, 8f);
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				position = new Vector3(vector.x - num2, vector.y - num2),
				color = color,
				uv0 = new Vector2(0f, 0f)
			},
			new UIVertex
			{
				position = new Vector3(vector.x + num2, vector.y - num2),
				color = color,
				uv0 = new Vector2(1f, 0f)
			},
			new UIVertex
			{
				position = new Vector3(vector.x + num2, vector.y + num2),
				color = color,
				uv0 = new Vector2(1f, 1f)
			},
			new UIVertex
			{
				position = new Vector3(vector.x - num2, vector.y + num2),
				color = color,
				uv0 = new Vector2(0f, 1f)
			}
		});
		num2 /= 2f;
		for (int i = 0; i < ExtraPoints.Count; i++)
		{
			vector = corner + Vector2.Scale(corner2 - corner, ExtraPoints[i].Item1);
			Color item = ExtraPoints[i].Item2;
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					position = new Vector3(vector.x - num2, vector.y - num2),
					color = item,
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(vector.x + num2, vector.y - num2),
					color = item,
					uv0 = new Vector2(1f, 0f)
				},
				new UIVertex
				{
					position = new Vector3(vector.x + num2, vector.y + num2),
					color = item,
					uv0 = new Vector2(1f, 1f)
				},
				new UIVertex
				{
					position = new Vector3(vector.x - num2, vector.y + num2),
					color = item,
					uv0 = new Vector2(0f, 1f)
				}
			});
		}
	}

	private Vector2 GetCorner(Vector2 s, Vector2 v, bool a)
	{
		Vector2 vector = v.Turn90() * 0.1f;
		if (a)
		{
			return new Vector2(s.x + v.x + vector.x, s.y + v.y + vector.y);
		}
		return new Vector2(s.x + v.x - vector.x, s.y + v.y - vector.y);
	}

	private void UpdateValues()
	{
		A = GetSideValue(Corners[0], Corners[1], Corners[2]);
		B = GetSideValue(Corners[1], Corners[2], Corners[0]);
		C = GetSideValue(Corners[2], Corners[0], Corners[1]);
		Sum = (A + B + C) * 100f;
		OnValueChanged.Invoke();
	}

	private void Update()
	{
		if (_tipping)
		{
			if (Tooltip.CurrentRect == base.rectTransform)
			{
				UpdateTooltip();
			}
			else
			{
				_tipping = false;
			}
		}
		if (_isDragging)
		{
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
				_cursor = "Finger";
			}
			else
			{
				Vector2 localPoint;
				if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
				{
					return;
				}
				Vector2 corner;
				Vector2 corner2;
				base.rectTransform.GetCorners(out corner, out corner2);
				Vector2 vector = corner2 - corner;
				Vector2 vector2 = new Vector2((localPoint.x - corner.x) / vector.x, (localPoint.y - corner.y) / vector.y);
				if (!TriangleNode.InsideTriangle(vector2, Corners[0], Corners[1], Corners[2]))
				{
					Vector2 vector3 = vector2;
					float num = 500f;
					for (int i = 0; i < 3; i++)
					{
						Vector2 a = Corners[i];
						Vector2 b = Corners[(i + 1) % 3];
						Vector2 vector4 = Utilities.ProjectToLineEndlessClamped(vector3, a, b);
						float sqrMagnitude = (vector4 - vector3).sqrMagnitude;
						if (sqrMagnitude < num)
						{
							num = sqrMagnitude;
							vector2 = vector4;
						}
					}
				}
				NormalizedCursorPos = vector2;
				UpdateValues();
				SetVerticesDirty();
			}
		}
		else
		{
			if (!_isInside || ReadOnly)
			{
				return;
			}
			Vector2 localPoint2;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint2))
			{
				Vector2 corner3;
				Vector2 corner4;
				base.rectTransform.GetCorners(out corner3, out corner4);
				Vector2 vector5 = corner4 - corner3;
				if (TriangleNode.InsideTriangle(new Vector2((localPoint2.x - corner3.x) / vector5.x, (localPoint2.y - corner3.y) / vector5.y), Corners[0], Corners[1], Corners[2]))
				{
					_cursor = "Finger";
					return;
				}
			}
			_cursor = null;
		}
	}

	private float GetSideValue(Vector2 p, Vector2 p2, Vector2 p3)
	{
		float magnitude = (p - p2).magnitude;
		float magnitude2 = (NormalizedCursorPos - p).magnitude;
		float angle = GetAngle(p2, NormalizedCursorPos, p);
		float angle2 = GetAngle(p, p3, p2);
		float f = (float)Math.PI - angle - angle2;
		float num = magnitude / Mathf.Sin(f) * Mathf.Sin(angle2);
		return 1f - magnitude2 / num;
	}

	private float GetAngle(Vector2 a, Vector2 b, Vector2 pivot)
	{
		return Vector2.Angle(a - pivot, b - pivot) / 180f * (float)Math.PI;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Vector2 localPoint;
		if (!ReadOnly && eventData.button == PointerEventData.InputButton.Left && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, eventData.position, UICamSize.GetUICam(), out localPoint))
		{
			Vector2 corner;
			Vector2 corner2;
			base.rectTransform.GetCorners(out corner, out corner2);
			Vector2 b = corner2 - corner;
			Vector2 v = corner + Vector2.Scale(Corners[0], b);
			Vector2 v2 = corner + Vector2.Scale(Corners[1], b);
			Vector2 v3 = corner + Vector2.Scale(Corners[2], b);
			if (TriangleNode.InsideTriangle(localPoint, v, v2, v3))
			{
				_isDragging = true;
				_cursor = "Grab";
			}
		}
	}

	public void SetLayoutHorizontal()
	{
		if (AutoSize)
		{
			base.rectTransform.sizeDelta = new Vector2(Mathf.Min(MaxWidth, base.rectTransform.rect.height * 1.1547f), base.rectTransform.sizeDelta.y);
		}
	}

	public void SetLayoutVertical()
	{
	}

	private void UpdateTooltip()
	{
		Vector2 localPoint;
		if (ExtraPoints.Count > 0 && RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			Vector2 corner;
			Vector2 corner2;
			base.rectTransform.GetCorners(out corner, out corner2);
			bool flag = false;
			for (int num = ExtraPoints.Count - 1; num >= 0; num--)
			{
				if ((corner + Vector2.Scale(corner2 - corner, ExtraPoints[num].Item1) - localPoint).sqrMagnitude < 16f)
				{
					Tooltip.SetToolTip(ExtraPoints[num].Item3.Name, null, base.rectTransform);
					flag = true;
					if (Input.GetMouseButtonUp(1))
					{
						HUD.Instance.GetProductWindow(null).ShowProductDetails(ExtraPoints[num].Item3);
					}
					break;
				}
			}
			if (!flag)
			{
				Tooltip.CurrentRect = base.rectTransform;
				Tooltip.Hide();
			}
		}
		else
		{
			Tooltip.Hide();
			_tipping = false;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_isInside = true;
		_tipping = true;
		UpdateTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_isInside = false;
	}
}
