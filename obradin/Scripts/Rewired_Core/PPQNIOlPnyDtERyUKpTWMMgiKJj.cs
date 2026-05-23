using System;
using Rewired.Utils;
using Rewired.Utils.UI;
using UnityEngine;

internal static class PPQNIOlPnyDtERyUKpTWMMgiKJj
{
	public static Vector2 jjXGghIXZrRSMthukGSsSaDDllE(RectTransform P_0, RectTransform P_1, Vector2 P_2)
	{
		return cQRXzfGypQicMcIGncOvjOxyqBuA(P_1, UnityTools.TransformPoint(P_0, P_1, P_2));
	}

	public static Vector2 cxWwquuRtieAXMVHTrOaYPAsRuB(RectTransform P_0)
	{
		return pfuLsrfCuUHqFrDhfQndrwtqorP(P_0).center;
	}

	public static Rect pfuLsrfCuUHqFrDhfQndrwtqorP(RectTransform P_0)
	{
		Vector2 vector = Vector2.Scale(P_0.rect.size, P_0.lossyScale);
		Rect result = new Rect(P_0.position.x, (float)Screen.height - P_0.position.y, vector.x, vector.y);
		result.x -= P_0.pivot.x * vector.x;
		while (true)
		{
			int num = 925465295;
			while (true)
			{
				switch (num ^ 0x37297ACE)
				{
				case 2:
					break;
				case 1:
					goto IL_0090;
				default:
					return result;
				}
				break;
				IL_0090:
				result.y -= (1f - P_0.pivot.y) * vector.y;
				num = 925465294;
			}
		}
	}

	public static Vector2 GKxnYoGyGjBRzUqwywRMFVQZwPk(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		return cQRXzfGypQicMcIGncOvjOxyqBuA(P_1, yrmpiQKoHoELPfnQUspISjBYwMx(P_0, P_1, P_2));
	}

	public static Vector2 yrmpiQKoHoELPfnQUspISjBYwMx(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		if (P_0 == null)
		{
			goto IL_0033;
		}
		if (P_0.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			goto IL_0011;
		}
		goto IL_003c;
		IL_003c:
		Camera cam = P_0.worldCamera;
		int num = 965560992;
		goto IL_0016;
		IL_0011:
		num = 965560995;
		goto IL_0016;
		IL_0016:
		switch (num ^ 0x398D4AA1)
		{
		case 0:
			break;
		case 2:
			goto IL_0033;
		case 3:
			goto IL_003c;
		default:
		{
			Vector2 localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(P_1, P_2, cam, out localPoint);
			return localPoint;
		}
		}
		goto IL_0011;
		IL_0033:
		cam = null;
		num = 965560992;
		goto IL_0016;
	}

	public static Vector2 cQRXzfGypQicMcIGncOvjOxyqBuA(RectTransform P_0, Vector3 P_1)
	{
		if (P_0 == null)
		{
			while (true)
			{
				switch (-1465390216 ^ -1465390214)
				{
				case 0:
					continue;
				case 2:
					throw new ArgumentNullException("rectTransform");
				}
				break;
			}
		}
		return new Vector2(P_1.x, P_1.y) + JKMeunIyaDAITUXmQDkDrkXyaAoB(P_0.rect, P_0.pivot);
	}

	private static Vector2 JKMeunIyaDAITUXmQDkDrkXyaAoB(Rect P_0, Vector2 P_1)
	{
		return new Vector2(P_0.width * P_1.x + P_0.xMin, P_0.height * P_1.y + P_0.yMin);
	}

	public static Vector3 BFYAtvgPUJNLjuOWcquIuXIEhUS(Transform P_0, PositionType P_1)
	{
		switch (P_1)
		{
		default:
			while (true)
			{
				switch (0x39CAA0FA ^ 0x39CAA0FB)
				{
				case 2:
					continue;
				case 1:
					throw new NotImplementedException();
				}
				break;
			}
			goto case PositionType.UMtjEaOogDDwQiplOLpTuwxTdbQ;
		case PositionType.UMtjEaOogDDwQiplOLpTuwxTdbQ:
			return (P_0 as RectTransform).localPosition;
		case PositionType.GGTSFVietfXEJqUNBOrLtjJMCol:
			return (P_0 as RectTransform).anchoredPosition;
		case PositionType.gbIGURScZMMDqBcnBvfwgThcPco:
			return (P_0 as RectTransform).position;
		}
	}

	public static void AwbDNgzQKwyuEBeAcQzspJfsFFt(Transform P_0, Vector3 P_1, PositionType P_2)
	{
		switch (P_2)
		{
		case PositionType.GGTSFVietfXEJqUNBOrLtjJMCol:
			while (true)
			{
				(P_0 as RectTransform).anchoredPosition = P_1;
				int num = 1257118380;
				while (true)
				{
					switch (num ^ 0x4AEE1AAD)
					{
					case 0:
						num = 1257118382;
						continue;
					case 1:
						return;
					case 2:
						break;
					case 5:
						goto end_IL_0048;
					case 3:
						goto IL_0074;
					default:
						goto end_IL_0003;
					}
					break;
				}
				continue;
				end_IL_0048:
				break;
			}
			goto case PositionType.gbIGURScZMMDqBcnBvfwgThcPco;
		case PositionType.gbIGURScZMMDqBcnBvfwgThcPco:
			(P_0 as RectTransform).position = P_1;
			return;
		case PositionType.UMtjEaOogDDwQiplOLpTuwxTdbQ:
			goto IL_0074;
			IL_0074:
			(P_0 as RectTransform).localPosition = P_1;
			return;
			end_IL_0003:
			break;
		}
		throw new NotImplementedException();
	}
}
