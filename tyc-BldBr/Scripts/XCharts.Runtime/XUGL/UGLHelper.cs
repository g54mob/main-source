using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUGL
{
	public static class UGLHelper
	{
		public static bool IsValueEqualsColor(Color32 color1, Color32 color2)
		{
			if (color1.a == color2.a && color1.b == color2.b && color1.g == color2.g)
			{
				return color1.r == color2.r;
			}
			return false;
		}

		public static bool IsValueEqualsColor(Color color1, Color color2)
		{
			if (color1.a == color2.a && color1.b == color2.b && color1.g == color2.g)
			{
				return color1.r == color2.r;
			}
			return false;
		}

		public static bool IsValueEqualsString(string str1, string str2)
		{
			if (str1 == null && str2 == null)
			{
				return true;
			}
			if (str1 != null && str2 != null)
			{
				return str1.Equals(str2);
			}
			return false;
		}

		public static bool IsValueEqualsVector2(Vector2 v1, Vector2 v2)
		{
			if (v1.x == v2.x)
			{
				return v1.y == v2.y;
			}
			return false;
		}

		public static bool IsValueEqualsVector3(Vector3 v1, Vector3 v2)
		{
			if (v1.x == v2.x && v1.y == v2.y)
			{
				return v1.z == v2.z;
			}
			return false;
		}

		public static bool IsValueEqualsVector3(Vector3 v1, Vector2 v2)
		{
			if (v1.x == v2.x)
			{
				return v1.y == v2.y;
			}
			return false;
		}

		public static bool IsValueEqualsList<T>(List<T> list1, List<T> list2)
		{
			if (list1 == null || list2 == null)
			{
				return false;
			}
			if (list1.Count != list2.Count)
			{
				return false;
			}
			for (int i = 0; i < list1.Count; i++)
			{
				if (list1[i] == null && list2[i] == null)
				{
					continue;
				}
				if (list1[i] != null)
				{
					if (!list1[i].Equals(list2[i]))
					{
						return false;
					}
				}
				else if (!list2[i].Equals(list1[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsClearColor(Color32 color)
		{
			if (color.a == 0 && color.b == 0 && color.g == 0)
			{
				return color.r == 0;
			}
			return false;
		}

		public static bool IsClearColor(Color color)
		{
			if (color.a == 0f && color.b == 0f && color.g == 0f)
			{
				return color.r == 0f;
			}
			return false;
		}

		public static bool IsZeroVector(Vector3 pos)
		{
			if (pos.x == 0f && pos.y == 0f)
			{
				return pos.z == 0f;
			}
			return false;
		}

		public static Vector3 RotateRound(Vector3 position, Vector3 center, Vector3 axis, float angle)
		{
			Vector3 vector = Quaternion.AngleAxis(angle, axis) * (position - center);
			return center + vector;
		}

		public static void GetBezierList(ref List<Vector3> posList, Vector3 sp, Vector3 ep, Vector3 lsp, Vector3 nep, float smoothness = 2f, float k = 2f, bool limit = false, bool randomDire = false)
		{
			float num = Vector3.Distance(sp, ep);
			_ = (ep - sp).normalized;
			float num2 = (randomDire ? num : Mathf.Abs(sp.x - ep.x)) / k;
			Vector3 cp;
			if (lsp == sp)
			{
				cp = sp + (nep - ep).normalized * num2;
				if (limit)
				{
					cp.y = sp.y;
				}
			}
			else
			{
				cp = sp + (ep - lsp).normalized * num2;
				if (limit)
				{
					cp.y = sp.y;
				}
			}
			Vector3 cp2;
			if (nep == ep)
			{
				cp2 = ep;
			}
			else
			{
				cp2 = ep - (nep - sp).normalized * num2;
				if (limit)
				{
					cp2.y = ep.y;
				}
			}
			int num3 = (int)(num / ((smoothness <= 0f) ? 2f : smoothness));
			if (num3 < 1)
			{
				num3 = (int)(num / 0.5f);
			}
			if (num3 < 4)
			{
				num3 = 4;
			}
			GetBezierList2(ref posList, sp, ep, num3, cp, cp2);
			if (posList.Count < 2)
			{
				posList.Clear();
				posList.Add(sp);
				posList.Add(ep);
			}
		}

		public static void GetBezierListVertical(ref List<Vector3> posList, Vector3 sp, Vector3 ep, float smoothness = 2f, float k = 2f)
		{
			Vector3 normalized = (ep - sp).normalized;
			float num = Vector3.Distance(sp, ep);
			Vector3 cp = sp + num / k * normalized * 1f;
			Vector3 cp2 = sp + num / k * normalized * (k - 1f);
			cp.x = sp.x;
			cp2.x = ep.x;
			int segment = (int)(num / ((smoothness <= 0f) ? 2f : smoothness));
			GetBezierList2(ref posList, sp, ep, segment, cp, cp2);
			if (posList.Count < 2)
			{
				posList.Clear();
				posList.Add(sp);
				posList.Add(ep);
			}
		}

		public static List<Vector3> GetBezierList(Vector3 sp, Vector3 ep, int segment, Vector3 cp)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < segment; i++)
			{
				list.Add(GetBezier((float)i / (float)segment, sp, cp, ep));
			}
			list.Add(ep);
			return list;
		}

		public static void GetBezierList2(ref List<Vector3> posList, Vector3 sp, Vector3 ep, int segment, Vector3 cp, Vector3 cp2)
		{
			posList.Clear();
			if (posList.Capacity < segment + 1)
			{
				posList.Capacity = segment + 1;
			}
			for (int i = 0; i < segment; i++)
			{
				posList.Add(GetBezier2((float)i / (float)segment, sp, cp, cp2, ep));
			}
			posList.Add(ep);
		}

		public static Vector3 GetBezier(float t, Vector3 sp, Vector3 cp, Vector3 ep)
		{
			Vector3 vector = sp + (cp - sp) * t;
			Vector3 vector2 = cp + (ep - cp) * t;
			return vector + (vector2 - vector) * t;
		}

		public static Vector3 GetBezier2(float t, Vector3 sp, Vector3 p1, Vector3 p2, Vector3 ep)
		{
			t = Mathf.Clamp01(t);
			float num = 1f - t;
			return num * num * num * sp + 3f * num * num * t * p1 + 3f * num * t * t * p2 + t * t * t * ep;
		}

		public static Vector3 GetDire(float angle, bool isDegree = false)
		{
			angle = (isDegree ? (angle * (MathF.PI / 180f)) : angle);
			return new Vector3(Mathf.Sin(angle), Mathf.Cos(angle));
		}

		public static Vector3 GetVertialDire(Vector3 dire)
		{
			if (dire.x == 0f)
			{
				return new Vector3(-1f, 0f, 0f);
			}
			if (dire.y == 0f)
			{
				return new Vector3(0f, -1f, 0f);
			}
			return new Vector3((0f - dire.y) / dire.x, 1f, 0f).normalized;
		}

		public static float GetAngle360(Vector2 from, Vector2 to)
		{
			Vector3 vector = Vector3.Cross(from, to);
			float num = Vector2.Angle(from, to);
			num = ((vector.z > 0f) ? (0f - num) : num);
			return (num + 360f) % 360f;
		}

		public static Vector3 GetPos(Vector3 center, float radius, float angle, bool isDegree = false)
		{
			angle = (isDegree ? (angle * (MathF.PI / 180f)) : angle);
			return new Vector3(center.x + radius * Mathf.Sin(angle), center.y + radius * Mathf.Cos(angle));
		}

		public static bool GetIntersection(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, ref Vector3 intersection)
		{
			float num = (p2.x - p1.x) * (p4.y - p3.y) - (p2.y - p1.y) * (p4.x - p3.x);
			if (num == 0f)
			{
				return false;
			}
			float num2 = ((p3.x - p1.x) * (p4.y - p3.y) - (p3.y - p1.y) * (p4.x - p3.x)) / num;
			float num3 = ((p3.x - p1.x) * (p2.y - p1.y) - (p3.y - p1.y) * (p2.x - p1.x)) / num;
			if (num2 < 0f || num2 > 1f || num3 < 0f || num3 > 1f)
			{
				return false;
			}
			intersection.x = p1.x + num2 * (p2.x - p1.x);
			intersection.y = p1.y + num2 * (p2.y - p1.y);
			return true;
		}

		public static bool GetIntersection(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, ref List<Vector3> intersection)
		{
			float num = (p2.x - p1.x) * (p4.y - p3.y) - (p2.y - p1.y) * (p4.x - p3.x);
			if (num == 0f)
			{
				return false;
			}
			float num2 = ((p3.x - p1.x) * (p4.y - p3.y) - (p3.y - p1.y) * (p4.x - p3.x)) / num;
			float num3 = ((p3.x - p1.x) * (p2.y - p1.y) - (p3.y - p1.y) * (p2.x - p1.x)) / num;
			if (num2 < 0f || num2 > 1f || num3 < 0f || num3 > 1f)
			{
				return false;
			}
			intersection.Add(new Vector3(p1.x + num2 * (p2.x - p1.x), p1.y + num2 * (p2.y - p1.y)));
			return true;
		}

		internal static void GetLinePoints(Vector3 lp, Vector3 cp, Vector3 np, float width, ref Vector3 ltp, ref Vector3 lbp, ref Vector3 ntp, ref Vector3 nbp, ref Vector3 itp, ref Vector3 ibp, ref Vector3 clp, ref Vector3 crp, ref bool bitp, ref bool bibp, int debugIndex = 0)
		{
			Vector3 normalized = (cp - lp).normalized;
			Vector3 vector = Vector3.Cross(normalized, Vector3.forward).normalized * width;
			ltp = lp - vector;
			lbp = lp + vector;
			if (debugIndex == 1 && cp == np)
			{
				ntp = np - vector;
				nbp = np + vector;
				clp = cp - vector;
				crp = cp + vector;
				return;
			}
			Vector3 normalized2 = (cp - np).normalized;
			Vector3 vector2 = Vector3.Cross(normalized2, Vector3.back).normalized * width;
			ntp = np - vector2;
			nbp = np + vector2;
			clp = cp - vector2;
			crp = cp + vector2;
			if (Vector3.Cross(normalized, normalized2) == Vector3.zero && np != cp)
			{
				itp = clp;
				ibp = crp;
				return;
			}
			Vector3 vector3 = (Vector3.Distance(cp, lp) + 1f) * normalized;
			Vector3 vector4 = (Vector3.Distance(cp, np) + 1f) * normalized2;
			bitp = true;
			if (!GetIntersection(ltp, ltp + vector3, ntp, ntp + vector4, ref itp))
			{
				itp = cp - vector;
				clp = cp - vector;
				crp = cp - vector2;
				bitp = false;
			}
			bibp = true;
			if (!GetIntersection(lbp, lbp + vector3, nbp, nbp + vector4, ref ibp))
			{
				ibp = cp + vector;
				clp = cp + vector;
				crp = cp + vector2;
				bibp = false;
			}
			if (!bitp && !bibp && cp == np)
			{
				ltp = cp - vector;
				clp = cp + vector;
				crp = cp + vector;
			}
		}

		public static bool IsPointInTriangle(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 check)
		{
			Vector3 vector = check - p1;
			Vector3 vector2 = check - p2;
			Vector3 vector3 = check - p3;
			float num = vector.x * vector2.y - vector.y * vector2.x;
			float num2 = vector2.x * vector3.y - vector2.y * vector3.x;
			float num3 = vector3.x * vector.y - vector3.y * vector.x;
			if (num * num2 >= 0f)
			{
				return num * num3 >= 0f;
			}
			return false;
		}

		public static bool IsPointInPolygon(Vector3 p, List<Vector3> polyons)
		{
			if (polyons.Count == 0)
			{
				return false;
			}
			bool flag = false;
			int index = polyons.Count - 1;
			int num = 0;
			while (num < polyons.Count)
			{
				Vector3 vector = polyons[num];
				Vector3 vector2 = polyons[index];
				if (((vector.y <= p.y && p.y < vector2.y) || (vector2.y <= p.y && p.y < vector.y)) && p.x < (vector2.x - vector.x) * (p.y - vector.y) / (vector2.y - vector.y) + vector.x)
				{
					flag = !flag;
				}
				index = num++;
			}
			return flag;
		}

		public static bool IsPointInPolygon(Vector3 p, List<Vector2> polyons)
		{
			if (polyons.Count == 0)
			{
				return false;
			}
			bool flag = false;
			int index = polyons.Count - 1;
			int num = 0;
			while (num < polyons.Count)
			{
				Vector2 vector = polyons[num];
				Vector2 vector2 = polyons[index];
				if (((vector.y <= p.y && p.y < vector2.y) || (vector2.y <= p.y && p.y < vector.y)) && p.x < (vector2.x - vector.x) * (p.y - vector.y) / (vector2.y - vector.y) + vector.x)
				{
					flag = !flag;
				}
				index = num++;
			}
			return flag;
		}
	}
}
