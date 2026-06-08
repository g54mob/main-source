using System;
using Rewired.Utils;
using Rewired.Utils.UI;
using UnityEngine;

internal static class LOMeYMhHKyjSwUDqvWYJlrErQKH
{
	public static Vector2 jjbEkoGOuTdtgosBVVbDWrCUidFI(RectTransform P_0, RectTransform P_1, Vector2 P_2)
	{
		return yxZHAzCCQSGYmzkdYlbchIDlJDC(P_1, UnityTools.TransformPoint(P_0, P_1, P_2));
	}

	public static Vector2 wiAQTskjGyizrRupulRxnIgfqOl(RectTransform P_0)
	{
		return vHsehbvBLEhEjeuJGCWyhOZrptfg(P_0).center;
	}

	public static Rect vHsehbvBLEhEjeuJGCWyhOZrptfg(RectTransform P_0)
	{
		Vector2 vector = Vector2.Scale(P_0.rect.size, P_0.lossyScale);
		Rect result = new Rect(P_0.position.x, (float)Screen.height - P_0.position.y, vector.x, vector.y);
		while (true)
		{
			int num = -759620748;
			while (true)
			{
				switch (num ^ -759620746)
				{
				case 0:
					break;
				case 2:
					goto IL_006f;
				default:
					result.y -= (1f - P_0.pivot.y) * vector.y;
					return result;
				}
				break;
				IL_006f:
				result.x -= P_0.pivot.x * vector.x;
				num = -759620745;
			}
		}
	}

	public static Vector2 KTbmzeAAdhrTBJRYRmgLkeyURAQ(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		return yxZHAzCCQSGYmzkdYlbchIDlJDC(P_1, wNaIZGSpgwpXpwwUzSBRpejVUBJ(P_0, P_1, P_2));
	}

	public static Vector2 wNaIZGSpgwpXpwwUzSBRpejVUBJ(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		if (P_0 == null)
		{
			goto IL_0037;
		}
		if (P_0.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			goto IL_0011;
		}
		goto IL_0047;
		IL_0037:
		Camera cam = null;
		int num = -1651389857;
		goto IL_0016;
		IL_0011:
		num = -1651389858;
		goto IL_0016;
		IL_0016:
		while (true)
		{
			switch (num ^ -1651389859)
			{
			case 0:
				break;
			case 3:
				goto IL_0037;
			case 2:
				num = -1651389863;
				continue;
			case 1:
				goto IL_0047;
			default:
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(P_1, P_2, cam, out var localPoint);
				return localPoint;
			}
			}
			break;
		}
		goto IL_0011;
		IL_0047:
		cam = P_0.worldCamera;
		num = -1651389863;
		goto IL_0016;
	}

	public static Vector2 yxZHAzCCQSGYmzkdYlbchIDlJDC(RectTransform P_0, Vector3 P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("rectTransform");
		}
		return new Vector2(P_1.x, P_1.y) + RYIQfdQzXXehlNhKjTLCUvjtAhY(P_0.rect, P_0.pivot);
	}

	private static Vector2 RYIQfdQzXXehlNhKjTLCUvjtAhY(Rect P_0, Vector2 P_1)
	{
		return new Vector2(P_0.width * P_1.x + P_0.xMin, P_0.height * P_1.y + P_0.yMin);
	}

	public static Vector3 RHSfXhsPjZpvTnuaRtDNJQoXDno(Transform P_0, PositionType P_1)
	{
		switch (P_1)
		{
		case PositionType.AXriQuEBFZCYarVPplCATARGxpw:
			return (P_0 as RectTransform).localPosition;
		case PositionType.WALjqDIkNzPxbhnsjcnYTAHDFKBY:
			return (P_0 as RectTransform).anchoredPosition;
		case PositionType.ceABmLEGmOviSWYJwNMdENNdWZYj:
			return (P_0 as RectTransform).position;
		default:
			throw new NotImplementedException();
		}
	}

	public static void UprvgqxthkUgaQeUXArWMBZlDPh(Transform P_0, Vector3 P_1, PositionType P_2)
	{
		while (true)
		{
			int num = 2084919907;
			while (true)
			{
				switch (num ^ 0x7C455A61)
				{
				case 5:
					break;
				case 3:
					(P_0 as RectTransform).anchoredPosition = P_1;
					return;
				case 4:
					return;
				case 1:
					goto IL_0051;
				case 6:
					goto IL_0064;
				case 2:
					switch (P_2)
					{
					case PositionType.WALjqDIkNzPxbhnsjcnYTAHDFKBY:
						break;
					case PositionType.AXriQuEBFZCYarVPplCATARGxpw:
						goto IL_0051;
					case PositionType.ceABmLEGmOviSWYJwNMdENNdWZYj:
						goto IL_0064;
					default:
						goto IL_008a;
					}
					goto case 3;
				default:
					{
						throw new NotImplementedException();
					}
					IL_008a:
					num = 2084919905;
					continue;
					IL_0064:
					(P_0 as RectTransform).position = P_1;
					return;
					IL_0051:
					(P_0 as RectTransform).localPosition = P_1;
					num = 2084919909;
					continue;
				}
				break;
			}
		}
	}
}
