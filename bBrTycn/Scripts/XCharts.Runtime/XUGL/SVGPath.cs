using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace XUGL
{
	public class SVGPath
	{
		private static Regex s_PathRegex = new Regex("(([a-z]|[A-Z])(\\d|\\.|,|-)*)");

		private static Regex s_PathValueRegex = new Regex("(^[a-z]|[A-Z])\\s*(-?\\d+\\.*\\d*)*[\\s|,|-]*(\\d+\\.*\\d*)*");

		private static Regex s_PathValueRegex2 = new Regex("(-?\\d+\\.?\\d*)");

		public bool mirrorY = true;

		public List<SVGPathSeg> segs = new List<SVGPathSeg>();

		public void AddSegment(SVGPathSeg seg)
		{
			segs.Add(seg);
		}

		public static SVGPath Parse(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return new SVGPath();
			}
			if (path.StartsWith("path://"))
			{
				path = path.Substring(7);
			}
			path = path.Replace(' ', ',');
			MatchCollection matchCollection = s_PathRegex.Matches(path);
			SVGPath sVGPath = new SVGPath();
			foreach (object item in matchCollection)
			{
				string text = item.ToString();
				if (text.Equals("Z") || text.Equals("z"))
				{
					SVGPathSeg sVGPathSeg = new SVGPathSeg(SVGPathSegType.Z);
					sVGPathSeg.raw = text;
					sVGPathSeg.relative = text.Equals("z");
					sVGPath.AddSegment(sVGPathSeg);
					continue;
				}
				char c = s_PathValueRegex.Match(text).Groups[1].ToString().ToCharArray()[0];
				MatchCollection matchCollection2 = s_PathValueRegex2.Matches(text);
				SVGPathSeg sVGPathSeg2 = null;
				switch (c)
				{
				case 'M':
				case 'm':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.M);
					sVGPathSeg2.relative = c == 'm';
					break;
				case 'L':
				case 'l':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.L);
					sVGPathSeg2.relative = c == 'l';
					break;
				case 'H':
				case 'h':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.H);
					sVGPathSeg2.relative = c == 'h';
					break;
				case 'V':
				case 'v':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.V);
					sVGPathSeg2.relative = c == 'v';
					break;
				case 'C':
				case 'c':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.C);
					sVGPathSeg2.relative = c == 'c';
					break;
				case 'S':
				case 's':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.S);
					sVGPathSeg2.relative = c == 's';
					break;
				case 'Q':
				case 'q':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.Q);
					sVGPathSeg2.relative = c == 'q';
					break;
				case 'T':
				case 't':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.T);
					sVGPathSeg2.relative = c == 't';
					break;
				case 'A':
				case 'a':
					sVGPathSeg2 = new SVGPathSeg(SVGPathSegType.A);
					sVGPathSeg2.relative = c == 'a';
					break;
				}
				if (sVGPathSeg2 == null)
				{
					continue;
				}
				sVGPathSeg2.raw = text;
				foreach (object item2 in matchCollection2)
				{
					if (float.TryParse(item2.ToString(), out var result))
					{
						sVGPathSeg2.parameters.Add(result);
					}
				}
				sVGPath.AddSegment(sVGPathSeg2);
			}
			return sVGPath;
		}

		public void Draw(VertexHelper vh)
		{
			Vector2 vector = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			List<Vector3> list = new List<Vector3>();
			List<Vector3> posList = new List<Vector3>();
			Vector2 vector3 = Vector2.zero;
			foreach (SVGPathSeg seg in segs)
			{
				switch (seg.type)
				{
				case SVGPathSegType.M:
					vector = (vector2 = (seg.relative ? (vector2 + seg.p1) : seg.p1));
					if (list.Count > 0)
					{
						DrawPosList(vh, list);
					}
					list.Add(vector2);
					break;
				case SVGPathSegType.L:
					vector2 = (seg.relative ? (vector2 + seg.p1) : seg.p1);
					list.Add(vector2);
					break;
				case SVGPathSegType.H:
					vector2 = (seg.relative ? (vector2 + new Vector2(seg.value, 0f)) : new Vector2(seg.value, vector2.y));
					list.Add(vector2);
					break;
				case SVGPathSegType.V:
					vector2 = (seg.relative ? (vector2 + new Vector2(0f, seg.value)) : new Vector2(vector2.x, seg.value));
					list.Add(vector2);
					break;
				case SVGPathSegType.C:
				{
					Vector2 vector4 = (seg.relative ? (vector2 + seg.p1) : seg.p1);
					vector3 = (seg.relative ? (vector2 + seg.p2) : seg.p2);
					Vector2 vector6 = (seg.relative ? (vector2 + seg.p3) : seg.p3);
					int num = (int)Vector2.Distance(vector2, vector6) * 2;
					if (num < 2)
					{
						num = 2;
					}
					UGLHelper.GetBezierList2(ref posList, vector2, vector6, num, vector4, vector3);
					for (int j = 1; j < posList.Count; j++)
					{
						list.Add(posList[j]);
					}
					vector2 = vector6;
					break;
				}
				case SVGPathSegType.S:
				{
					Vector2 vector4 = vector2 + (vector2 - vector3).normalized * Vector2.Distance(vector2, vector3);
					Vector2 vector5 = (seg.relative ? (vector2 + seg.p1) : seg.p1);
					Vector2 vector6 = (seg.relative ? (vector2 + seg.p2) : seg.p2);
					int num = (int)Vector2.Distance(vector2, vector6) * 2;
					if (num < 2)
					{
						num = 2;
					}
					UGLHelper.GetBezierList2(ref posList, vector2, vector6, num, vector4, vector5);
					for (int i = 1; i < posList.Count; i++)
					{
						list.Add(posList[i]);
					}
					break;
				}
				case SVGPathSegType.Z:
					list.Add(vector);
					DrawPosList(vh, list);
					break;
				default:
					Debug.LogError("unknow seg:" + seg.type);
					break;
				}
			}
			if (list.Count > 0)
			{
				DrawPosList(vh, list);
			}
		}

		private void DrawPosList(VertexHelper vh, List<Vector3> posList)
		{
			if (mirrorY)
			{
				for (int num = posList.Count - 1; num >= 0; num--)
				{
					Vector3 vector = posList[num];
					posList[num] = new Vector3(vector.x, 0f - vector.y);
				}
			}
			UGL.DrawLine(vh, posList, 1f, Color.red, smooth: false);
			posList.Clear();
		}
	}
}
