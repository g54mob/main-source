using System;
using Rewired.Utils;
using Rewired.Utils.UI;
using UnityEngine;

internal static class eNAeLDLTbmAsdtyVgrjCdfsiFPci
{
	public static Vector2 QGvZDzoHqRwxpTqLWKpUlqVHoSu(RectTransform P_0, RectTransform P_1, Vector2 P_2)
	{
		return NZZcusBkbOFDzVSPFEQxwzjwbMrh(P_1, UnityTools.TransformPoint(P_0, P_1, P_2));
	}

	public static Vector2 NpQgrnaSbgDrocsGdlCePdGjadYN(RectTransform P_0)
	{
		return ODoAviRJiMLHoJjyXHjxQcjiAyC(P_0).center;
	}

	public static Rect ODoAviRJiMLHoJjyXHjxQcjiAyC(RectTransform P_0)
	{
		Rect rect = P_0.rect;
		Rect result = default(Rect);
		Vector2 vector = default(Vector2);
		while (true)
		{
			int num = -591988306;
			while (true)
			{
				switch (num ^ -591988305)
				{
				case 0:
					break;
				case 1:
					goto IL_0025;
				default:
					result.x -= P_0.pivot.x * vector.x;
					result.y -= (1f - P_0.pivot.y) * vector.y;
					return result;
				}
				break;
				IL_0025:
				vector = Vector2.Scale(rect.size, P_0.lossyScale);
				result = new Rect(P_0.position.x, (float)Screen.height - P_0.position.y, vector.x, vector.y);
				num = -591988307;
			}
		}
	}

	public static Vector2 dtpDXxeWSzCwUaZpUNVCeFQTgWhH(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		return NZZcusBkbOFDzVSPFEQxwzjwbMrh(P_1, DseKlDkkNmcmsDeTaDjKFrBMTXcs(P_0, P_1, P_2));
	}

	public static Vector2 DseKlDkkNmcmsDeTaDjKFrBMTXcs(Canvas P_0, RectTransform P_1, Vector2 P_2)
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
		int num = 982833471;
		goto IL_0016;
		IL_0011:
		num = 982833470;
		goto IL_0016;
		IL_0016:
		switch (num ^ 0x3A94D93F)
		{
		case 3:
			break;
		case 1:
			goto IL_0033;
		case 2:
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
		num = 982833471;
		goto IL_0016;
	}

	public static Vector2 NZZcusBkbOFDzVSPFEQxwzjwbMrh(RectTransform P_0, Vector3 P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("rectTransform");
		}
		return new Vector2(P_1.x, P_1.y) + eyMLbswIkVldwelbmwgDWMZcyXb(P_0.rect, P_0.pivot);
	}

	private static Vector2 eyMLbswIkVldwelbmwgDWMZcyXb(Rect P_0, Vector2 P_1)
	{
		return new Vector2(P_0.width * P_1.x + P_0.xMin, P_0.height * P_1.y + P_0.yMin);
	}

	public static Vector3 sDAkhoYrEZafWItRCkMCXhQGsTL(Transform P_0, PositionType P_1)
	{
		switch (P_1)
		{
		case PositionType.hWboZvyXoJNhfSvesxqLLWrBcgF:
			return (P_0 as RectTransform).localPosition;
		case PositionType.huHVQQAcuxcYyCLZjEIJOChEJYa:
			return (P_0 as RectTransform).anchoredPosition;
		case PositionType.TWIRJUiXJWfCNfaOvtAkZbNqGid:
			return (P_0 as RectTransform).position;
		default:
			throw new NotImplementedException();
		}
	}

	public static void rRhYUvPnCuVwprINEAdgWHfmPUy(Transform P_0, Vector3 P_1, PositionType P_2)
	{
		switch (P_2)
		{
		case PositionType.hWboZvyXoJNhfSvesxqLLWrBcgF:
			while (true)
			{
				(P_0 as RectTransform).localPosition = P_1;
				int num = 1192824818;
				while (true)
				{
					switch (num ^ 0x47190FF2)
					{
					case 3:
						num = 1192824819;
						continue;
					case 1:
						break;
					case 2:
						goto end_IL_0040;
					case 5:
						goto IL_006c;
					case 0:
						return;
					default:
						goto end_IL_0003;
					}
					break;
				}
				continue;
				end_IL_0040:
				break;
			}
			goto case PositionType.huHVQQAcuxcYyCLZjEIJOChEJYa;
		case PositionType.huHVQQAcuxcYyCLZjEIJOChEJYa:
			(P_0 as RectTransform).anchoredPosition = P_1;
			return;
		case PositionType.TWIRJUiXJWfCNfaOvtAkZbNqGid:
			goto IL_006c;
			IL_006c:
			(P_0 as RectTransform).position = P_1;
			return;
			end_IL_0003:
			break;
		}
		throw new NotImplementedException();
	}
}
