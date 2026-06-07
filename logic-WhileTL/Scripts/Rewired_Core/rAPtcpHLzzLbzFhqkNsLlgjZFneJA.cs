using System;
using Rewired.Utils;
using Rewired.Utils.UI;
using UnityEngine;

internal static class rAPtcpHLzzLbzFhqkNsLlgjZFneJA
{
	public static Vector2 HfoaKLiZpGjRvpJyQJUBfvfkUnsd(RectTransform P_0, RectTransform P_1, Vector2 P_2)
	{
		return AAUVFSyQdNkItkWsBRUmdAoZIuzv(P_1, UnityTools.TransformPoint(P_0, P_1, P_2));
	}

	public static Vector2 ImBUELKxnhDwcYMrxaVznXPXlBWu(RectTransform P_0)
	{
		return VqvBrMRYuJTUazDNPysuEguBYYIn(P_0).center;
	}

	public static Rect VqvBrMRYuJTUazDNPysuEguBYYIn(RectTransform P_0)
	{
		Vector2 vector = Vector2.Scale(P_0.rect.size, P_0.lossyScale);
		Rect result = new Rect(P_0.position.x, (float)Screen.height - P_0.position.y, vector.x, vector.y);
		result.x -= P_0.pivot.x * vector.x;
		result.y -= (1f - P_0.pivot.y) * vector.y;
		return result;
	}

	public static Vector2 aVeQeJyQMkcxEOFWMrKPqFXiQgnw(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		return AAUVFSyQdNkItkWsBRUmdAoZIuzv(P_1, SgnmCnknRrphshQsybuTdsGjQtuR(P_0, P_1, P_2));
	}

	public static Vector2 SgnmCnknRrphshQsybuTdsGjQtuR(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		Camera cam = ((!(P_0 == null) && P_0.renderMode != RenderMode.ScreenSpaceOverlay) ? P_0.worldCamera : null);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(P_1, P_2, cam, out var localPoint);
		return localPoint;
	}

	public static Vector2 AAUVFSyQdNkItkWsBRUmdAoZIuzv(RectTransform P_0, Vector3 P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("rectTransform");
		}
		return new Vector2(P_1.x, P_1.y) + zvBgAKirgSgXwMXOujlSIbUDttlf(P_0.rect, P_0.pivot);
	}

	private static Vector2 zvBgAKirgSgXwMXOujlSIbUDttlf(Rect P_0, Vector2 P_1)
	{
		return new Vector2(P_0.width * P_1.x + P_0.xMin, P_0.height * P_1.y + P_0.yMin);
	}

	public static Vector3 jqVCRSYgYAAfCassUTnRPsBnBSBcA(Transform P_0, PositionType P_1)
	{
		return P_1 switch
		{
			PositionType.Local => (P_0 as RectTransform).localPosition, 
			PositionType.Anchored => (P_0 as RectTransform).anchoredPosition, 
			PositionType.World => (P_0 as RectTransform).position, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static void ggeBfXdXMzUKfWJqSCynZUgDwusiA(Transform P_0, Vector3 P_1, PositionType P_2)
	{
		switch (P_2)
		{
		case PositionType.Local:
			(P_0 as RectTransform).localPosition = P_1;
			break;
		case PositionType.Anchored:
			(P_0 as RectTransform).anchoredPosition = P_1;
			break;
		case PositionType.World:
			(P_0 as RectTransform).position = P_1;
			break;
		default:
			throw new NotImplementedException();
		}
	}
}
