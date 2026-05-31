using System;
using Rewired.Utils;
using Rewired.Utils.UI;
using UnityEngine;

internal static class lOjEgNUYKDaLCggmFifXLItFlte
{
	public static Vector2 TIIwMllRsqacKAZRdBGTNlxqpUu(RectTransform P_0, RectTransform P_1, Vector2 P_2)
	{
		return MwglqspEgpJYQLkPyMgUZarFqxZ(P_1, UnityTools.TransformPoint(P_0, P_1, P_2));
	}

	public static Vector2 GijsEzZMWZraJjfLASatHHDRNbQ(RectTransform P_0)
	{
		return VHVlDkCJZzVmDMzRerMisaiNgOS(P_0).center;
	}

	public static Rect VHVlDkCJZzVmDMzRerMisaiNgOS(RectTransform P_0)
	{
		Vector2 vector = Vector2.Scale(P_0.rect.size, P_0.lossyScale);
		Rect result = new Rect(P_0.position.x, (float)Screen.height - P_0.position.y, vector.x, vector.y);
		result.x -= P_0.pivot.x * vector.x;
		result.y -= (1f - P_0.pivot.y) * vector.y;
		return result;
	}

	public static Vector2 auCIIhbejKeibpjCjdDRUvPizkd(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		return MwglqspEgpJYQLkPyMgUZarFqxZ(P_1, YpTdmPpDeBhqHDMyLNbFAREIvbkg(P_0, P_1, P_2));
	}

	public static Vector2 YpTdmPpDeBhqHDMyLNbFAREIvbkg(Canvas P_0, RectTransform P_1, Vector2 P_2)
	{
		Camera cam = ((!(P_0 == null) && P_0.renderMode != RenderMode.ScreenSpaceOverlay) ? P_0.worldCamera : null);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(P_1, P_2, cam, out var localPoint);
		return localPoint;
	}

	public static Vector2 MwglqspEgpJYQLkPyMgUZarFqxZ(RectTransform P_0, Vector3 P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("rectTransform");
		}
		return new Vector2(P_1.x, P_1.y) + rYnoagzRRunaPlCSTkqMuLYXDzn(P_0.rect, P_0.pivot);
	}

	private static Vector2 rYnoagzRRunaPlCSTkqMuLYXDzn(Rect P_0, Vector2 P_1)
	{
		return new Vector2(P_0.width * P_1.x + P_0.xMin, P_0.height * P_1.y + P_0.yMin);
	}

	public static Vector3 hibndcJYzaEsrXIwpugDlXRbtYB(Transform P_0, PositionType P_1)
	{
		return P_1 switch
		{
			PositionType.aXQImphWLsNyAXlPBncGlpmgAAN => (P_0 as RectTransform).localPosition, 
			PositionType.kZazSODdPWKkPNqkEMQEeHglNjy => (P_0 as RectTransform).anchoredPosition, 
			PositionType.CejjSUAfgfefyGoVDAjnJbgmNcpZ => (P_0 as RectTransform).position, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static void kPSRPhEgnLVfCczyndEheCeBcby(Transform P_0, Vector3 P_1, PositionType P_2)
	{
		switch (P_2)
		{
		case PositionType.aXQImphWLsNyAXlPBncGlpmgAAN:
			(P_0 as RectTransform).localPosition = P_1;
			break;
		case PositionType.kZazSODdPWKkPNqkEMQEeHglNjy:
			(P_0 as RectTransform).anchoredPosition = P_1;
			break;
		case PositionType.CejjSUAfgfefyGoVDAjnJbgmNcpZ:
			(P_0 as RectTransform).position = P_1;
			break;
		default:
			throw new NotImplementedException();
		}
	}
}
