using System;
using System.Collections.Generic;
using StatementParser;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIArrow : MonoBehaviour
{
	public GameObject RingPrefab;

	public RectTransform ParentR;

	public RectTransform MyRect;

	public RectTransform BoundRect;

	public Vector2 Offset;

	public TutorialMessage.HorizontalAnchor HorizontalAlign;

	public TutorialMessage.VerticalAnchor VerticalAlign;

	public bool AnyAngle;

	public bool ThreeD;

	public bool ScreenParent;

	public bool FloorRel;

	public bool ForceShow;

	public Vector3 ThreeDP;

	public float Angle;

	public RawImage Img;

	public Texture2D NormalArrow;

	public Texture2D BehindArrow;

	public Texture2D ClampedArrow;

	[NonSerialized]
	public LineParse.TreeNode Completion;

	public string Anchor;

	private bool RingAdded;

	private float offset;

	private bool rising = true;

	private float _checkCompletion = -1f;

	private void Start()
	{
		MyRect = GetComponent<RectTransform>();
		MyRect.SetParent(WindowManager.Instance.Canvas.transform, false);
	}

	public static Rect RectTransformToScreenSpace(RectTransform transform)
	{
		Vector2 vector = Vector2.Scale(transform.rect.size, transform.lossyScale);
		Vector2 vector2 = new Vector2((0f - vector.x) * transform.pivot.x, (0f - vector.y) * (1f - transform.pivot.y));
		Vector2 uIScreenPosition = transform.GetUIScreenPosition();
		return new Rect(uIScreenPosition.x / Options.UISize + vector2.x / Options.UISize, ((float)Screen.height - uIScreenPosition.y) / Options.UISize + vector2.y / Options.UISize, vector.x / Options.UISize, vector.y / Options.UISize);
	}

	private static RectTransform FindMask(RectTransform start)
	{
		Transform parent = start.parent;
		while (parent != null)
		{
			if (parent.GetComponent<RectMask2D>() != null)
			{
				return parent.GetComponent<RectTransform>();
			}
			parent = parent.parent;
		}
		return null;
	}

	public bool ClampToBounds(ref Vector2 p, Rect bounds)
	{
		bool result = false;
		float num = p.x;
		float num2 = 0f - p.y;
		if (num < bounds.xMin)
		{
			num = bounds.xMin;
			result = true;
		}
		else if (num > bounds.xMax)
		{
			num = bounds.xMax;
			result = true;
		}
		if (num2 < bounds.yMin)
		{
			num2 = bounds.yMin;
			result = true;
		}
		else if (num2 > bounds.yMax)
		{
			num2 = bounds.yMax;
			result = true;
		}
		p = new Vector2(num, num2);
		return result;
	}

	private Vector2 TransformPoint(Vector2 topLeft, Vector2 topRight, Vector2 bottomLeft, Vector2 off, Vector2 anchor)
	{
		Vector2 uIScreenPosition = Utilities.GetUIScreenPosition(Vector2.zero);
		topLeft += uIScreenPosition;
		topRight += uIScreenPosition;
		bottomLeft += uIScreenPosition;
		float num = 1f / Options.UISize;
		topLeft = new Vector2(topLeft.x, (float)Screen.height - topLeft.y) * num;
		topRight = new Vector2(topRight.x, (float)Screen.height - topRight.y) * num;
		bottomLeft = new Vector2(bottomLeft.x, (float)Screen.height - bottomLeft.y) * num;
		Vector2 vector = topRight - topLeft;
		Vector2 vector2 = bottomLeft - topLeft;
		Vector2 vector3 = topLeft + vector * anchor.x + vector2 * anchor.y;
		vector = vector.normalized;
		vector2 = vector2.normalized;
		return vector3 + vector * off.x + vector2 * off.y;
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull() && Completion != null)
		{
			_checkCompletion -= Time.deltaTime;
			if (_checkCompletion < 0f)
			{
				_checkCompletion = UnityEngine.Random.Range(0.5f, 1f);
				try
				{
					if ((bool)LineParse.Execute(Completion, ScriptSystem.TaskScope.Scope))
					{
						UnityEngine.Object.Destroy(base.gameObject);
						return;
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Completion = null;
				}
			}
		}
		if (!ThreeD && !ScreenParent && ParentR == null)
		{
			RectTransform rectTransform = WindowManager.FindElementPath(Anchor);
			if (!(rectTransform != null))
			{
				Img.enabled = false;
				return;
			}
			ParentR = rectTransform;
			BoundRect = FindMask(rectTransform);
		}
		Img.enabled = true;
		if (!ThreeD)
		{
			Rect rect = new Rect(0f, 0f, (float)Screen.width / Options.UISize, (float)Screen.height / Options.UISize);
			Rect rect2 = rect;
			Vector2 p;
			float num;
			if (!ScreenParent)
			{
				if (!ForceShow && !ParentR.gameObject.activeInHierarchy)
				{
					Img.enabled = false;
					return;
				}
				Img.enabled = true;
				Vector3[] array = new Vector3[4];
				ParentR.GetWorldCorners(array);
				p = TransformPoint(array[1], array[2], array[0], Offset, new Vector2((HorizontalAlign == TutorialMessage.HorizontalAnchor.Right) ? 0f : ((HorizontalAlign == TutorialMessage.HorizontalAnchor.Left) ? 1f : 0.5f), (VerticalAlign == TutorialMessage.VerticalAnchor.Top) ? 0f : ((VerticalAlign == TutorialMessage.VerticalAnchor.Bottom) ? 1f : 0.5f)));
				rect = RectTransformToScreenSpace(ParentR);
				num = (AnyAngle ? (0f - Utilities.EulerAngleY((float)Screen.width / Options.UISize / 2f, p.y, p.x, (float)Screen.height / Options.UISize / 2f)) : (0f - Angle));
				num += ParentR.rotation.eulerAngles.z;
			}
			else
			{
				float y = ((VerticalAlign == TutorialMessage.VerticalAnchor.Top) ? 0f : ((VerticalAlign == TutorialMessage.VerticalAnchor.Bottom) ? rect.height : (rect.height / 2f)));
				float x = ((HorizontalAlign == TutorialMessage.HorizontalAnchor.Right) ? 0f : ((HorizontalAlign == TutorialMessage.HorizontalAnchor.Left) ? rect.width : (rect.width / 2f)));
				p = rect.position + Offset + new Vector2(x, y);
				num = (AnyAngle ? (0f - Utilities.EulerAngleY((float)Screen.width / Options.UISize / 2f, p.y, p.x, (float)Screen.height / Options.UISize / 2f)) : (0f - Angle));
			}
			if (BoundRect != null)
			{
				rect2 = RectTransformToScreenSpace(BoundRect);
			}
			rect2 = Rect.MinMaxRect(rect2.xMin, 0f - rect2.yMax, rect2.xMax, 0f - rect2.yMin);
			Vector2 point = new Vector2(p.x, 0f - p.y);
			bool flag = ClampToBounds(ref p, rect2);
			bool flag2 = false;
			if (ParentR != null && !flag)
			{
				Vector2 vector = new Vector2(Mathf.Clamp(p.x, rect.xMin + 1f, rect.xMax - 1f), Mathf.Clamp(0f - p.y, rect.yMin + 1f, rect.yMax - 1f));
				PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
				pointerEventData.pointerId = -1;
				pointerEventData.position = new Vector2(vector.x, (float)Screen.height / Options.UISize - vector.y) * Options.UISize;
				List<RaycastResult> list = new List<RaycastResult>();
				EventSystem.current.RaycastAll(pointerEventData, list);
				for (int i = 0; i < list.Count; i++)
				{
					RaycastResult raycastResult = list[i];
					RectTransform component = raycastResult.gameObject.GetComponent<RectTransform>();
					if (component == ParentR || component.parent.GetComponent<RectTransform>() == ParentR)
					{
						break;
					}
					if (BelongsToWindow(raycastResult.gameObject.transform))
					{
						Rect rect3 = RectTransformToScreenSpace(component);
						float num2 = ((rect3.xMin > 64f) ? Mathf.Abs(p.x - rect3.xMin) : float.MaxValue);
						float num3 = ((rect3.xMax < (float)Screen.width / Options.UISize - 64f) ? Mathf.Abs(p.x - rect3.xMax) : float.MaxValue);
						float num4 = ((rect3.yMin > 64f) ? Mathf.Abs(0f - p.y - rect3.yMin) : float.MaxValue);
						float num5 = ((rect3.yMax < (float)Screen.height / Options.UISize - 64f) ? Mathf.Abs(0f - p.y - rect3.yMax) : float.MaxValue);
						if (num2 < num3 && num2 < num4 && num2 < num5)
						{
							p = new Vector2(rect3.xMin, p.y);
							MyRect.rotation = Quaternion.Euler(0f, 0f, 270f);
						}
						else if (num3 < num2 && num3 < num4 && num3 < num5)
						{
							p = new Vector2(rect3.xMax, p.y);
							MyRect.rotation = Quaternion.Euler(0f, 0f, 90f);
						}
						else if (num4 < num2 && num4 < num3 && num4 < num5)
						{
							p = new Vector2(p.x, 0f - rect3.yMin);
							MyRect.rotation = Quaternion.Euler(0f, 0f, 180f);
						}
						else
						{
							p = new Vector2(p.x, 0f - rect3.yMax);
							MyRect.rotation = Quaternion.Euler(0f, 0f, 0f);
						}
						flag2 = true;
						break;
					}
				}
			}
			MyRect.anchoredPosition = p;
			if (flag2)
			{
				Img.texture = BehindArrow;
			}
			else if (flag)
			{
				Img.texture = ClampedArrow;
			}
			else
			{
				Img.texture = NormalArrow;
			}
			if (!flag2)
			{
				if (rect2.Contains(point))
				{
					MyRect.rotation = Quaternion.Euler(0f, 0f, num);
				}
				else
				{
					MyRect.rotation = Quaternion.Euler(0f, 0f, 0f - Utilities.EulerAngleY(p.x, p.y, point.x, point.y));
				}
			}
		}
		else
		{
			Vector3 threeDP = ThreeDP;
			if (FloorRel)
			{
				threeDP += Vector3.up * GameSettings.Instance.ActiveFloor * 2f;
			}
			Vector3 vector2;
			if (string.IsNullOrEmpty(Anchor))
			{
				vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(threeDP);
			}
			else
			{
				Transform transform = Utilities.FindTransformPath(Anchor);
				if (transform == null || !transform.gameObject.activeSelf)
				{
					Img.enabled = false;
					return;
				}
				vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(transform.transform.position + threeDP);
			}
			Vector2 anchoredPosition = new Vector2(vector2.x / Options.UISize, ((float)(-Screen.height) + vector2.y) / Options.UISize);
			float z = 180f;
			bool flag3 = false;
			PointerEventData pointerEventData2 = new PointerEventData(EventSystem.current);
			pointerEventData2.pointerId = -1;
			pointerEventData2.position = vector2;
			List<RaycastResult> list2 = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData2, list2);
			if (list2.Count > 0)
			{
				float num6 = float.MaxValue;
				float num7 = float.MinValue;
				float num8 = float.MaxValue;
				float num9 = float.MinValue;
				for (int j = 0; j < list2.Count; j++)
				{
					Rect rect4 = RectTransformToScreenSpace(list2[j].gameObject.GetComponent<RectTransform>());
					num6 = Mathf.Min(num6, rect4.xMin);
					num7 = Mathf.Max(num7, rect4.xMax);
					num8 = Mathf.Min(num8, rect4.yMin);
					num9 = Mathf.Max(num9, rect4.yMax);
				}
				Rect rect5 = Rect.MinMaxRect(num6, num8, num7, num9);
				float num10 = ((rect5.xMin > 64f) ? Mathf.Abs(anchoredPosition.x - rect5.xMin) : float.MaxValue);
				float num11 = ((rect5.xMax < (float)(Screen.width - 64)) ? Mathf.Abs(anchoredPosition.x - rect5.xMax) : float.MaxValue);
				float num12 = ((rect5.yMin > 64f) ? Mathf.Abs(0f - anchoredPosition.y - rect5.yMin) : float.MaxValue);
				float num13 = ((rect5.yMax < (float)(Screen.height - 64)) ? Mathf.Abs(0f - anchoredPosition.y - rect5.yMax) : float.MaxValue);
				if (num10 < num11 && num10 < num12 && num10 < num13)
				{
					anchoredPosition = new Vector2(rect5.xMin, anchoredPosition.y);
					z = 270f;
				}
				else if (num11 < num10 && num11 < num12 && num11 < num13)
				{
					anchoredPosition = new Vector2(rect5.xMax, anchoredPosition.y);
					z = 90f;
				}
				else if (num12 < num10 && num12 < num11 && num12 < num13)
				{
					anchoredPosition = new Vector2(anchoredPosition.x, 0f - rect5.yMin);
				}
				else
				{
					anchoredPosition = new Vector2(anchoredPosition.x, 0f - rect5.yMax);
					z = 0f;
				}
				flag3 = true;
			}
			Img.texture = (flag3 ? BehindArrow : NormalArrow);
			MyRect.anchoredPosition = anchoredPosition;
			MyRect.rotation = Quaternion.Euler(0f, 0f, z);
		}
		if (rising)
		{
			offset += Time.deltaTime * 16f;
			if (offset >= 16f)
			{
				rising = false;
			}
		}
		else
		{
			offset -= Time.deltaTime * 32f;
			if (offset <= 0f)
			{
				rising = true;
			}
		}
		Vector3 vector3 = MyRect.rotation * Vector3.right * offset;
		MyRect.anchoredPosition += new Vector2(vector3.y, 0f - vector3.x);
		MyRect.anchoredPosition = new Vector2(Mathf.Round(MyRect.anchoredPosition.x), Mathf.Round(MyRect.anchoredPosition.y));
		if (!RingAdded)
		{
			GameObject obj = UnityEngine.Object.Instantiate(RingPrefab);
			obj.transform.SetParent(base.transform, false);
			RingScript component2 = obj.GetComponent<RingScript>();
			component2.rect.anchoredPosition = new Vector2(32f, 0f);
			component2.size = 256;
			RingAdded = true;
			float pan = (MyRect.anchoredPosition.x / (float)Screen.width - 0.5f) * 2f;
			UISoundFX.PlaySFX("TutorialBlep", -1f, pan);
		}
	}

	public static bool BelongsToWindow(Transform t)
	{
		for (int i = 0; i < 2; i++)
		{
			if (t.GetComponent<GUIWindow>() != null)
			{
				return true;
			}
			if (t.parent == null)
			{
				break;
			}
			t = t.parent;
		}
		return false;
	}
}
