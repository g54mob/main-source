using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SimplySVG
{
	public class PathElement : GraphicalElement
	{
		public delegate Vector2 MakePathPointDelegate(float t);

		[Serializable]
		public class SubPath
		{
			public bool closed;

			public List<PathComponent> path;

			public SubPath()
			{
				closed = false;
				path = new List<PathComponent>();
			}
		}

		[Serializable]
		public class PathComponent
		{
			public enum SegmentType
			{
				line = 0,
				cubic = 1,
				quadratic = 2,
				arc = 3
			}

			public SegmentType segmentType;

			public Vector3 pos;

			public Vector3 startCurvePos;

			public Vector3 endCurvePos;

			public bool useStartCurvePos;

			public bool useEndCurvePos;

			public Vector2 arcRadius;

			public float arcRotation;

			public bool arcLarge;

			public bool arcSweep;

			public PathComponent(float x, float y, float startCurveX, float startCurveY, float endCurveX, float endCurveY)
			{
				segmentType = SegmentType.cubic;
				pos = new Vector3(x, y);
				startCurvePos = new Vector3(startCurveX, startCurveY);
				endCurvePos = new Vector3(endCurveX, endCurveY);
				useEndCurvePos = true;
				useStartCurvePos = true;
			}

			public PathComponent(float x, float y, float startCurveX, float startCurveY)
			{
				segmentType = SegmentType.quadratic;
				pos = new Vector3(x, y);
				startCurvePos = new Vector3(startCurveX, startCurveY);
				endCurvePos = pos;
				useEndCurvePos = false;
				useStartCurvePos = true;
			}

			public PathComponent(Vector3 penPos)
			{
				segmentType = SegmentType.line;
				pos = (startCurvePos = (endCurvePos = penPos));
				useEndCurvePos = false;
				useStartCurvePos = false;
				useEndCurvePos = false;
				useStartCurvePos = false;
			}

			public PathComponent(Vector2 position, Vector2 radius, float rotation, bool largeArc, bool sweep)
			{
				segmentType = SegmentType.arc;
				pos = new Vector3(position.x, position.y);
				arcRadius = radius;
				arcRotation = rotation;
				arcLarge = largeArc;
				arcSweep = sweep;
			}

			public static PathComponent LineTo(float x, float y)
			{
				return new PathComponent(new Vector3(x, y));
			}

			public void MirrorStartPointToEndpoint()
			{
				if (useStartCurvePos)
				{
					Vector3 vector = startCurvePos - pos;
					vector = -vector;
					endCurvePos = pos + vector;
					useEndCurvePos = true;
				}
			}

			public Vector3 GetMirroredCurveEndControlPoint()
			{
				if (!useEndCurvePos)
				{
					return pos;
				}
				return pos - (endCurvePos - pos);
			}

			public Vector3 GetMirroredCurveStartControlPoint()
			{
				if (!useStartCurvePos)
				{
					return pos;
				}
				return pos - (startCurvePos - pos);
			}
		}

		public List<SubPath> subPaths;

		public PathElement()
		{
			subPaths = new List<SubPath>();
		}

		public override bool AddShapeAttribute(string attributeName, string attributeValue)
		{
			bool flag = true;
			if (!(attributeName == "d"))
			{
				return false;
			}
			if (!ParseControlPoints(attributeValue))
			{
				throw new Exception("Failed to parse Path attribute " + attributeName + " with value " + attributeValue);
			}
			return true;
		}

		protected override List<ContourPath> BuildShape(ImportSettings options)
		{
			List<ContourPath> list = new List<ContourPath>();
			foreach (SubPath subPath in subPaths)
			{
				ContourPath contourPath = new ContourPath(subPath.closed);
				list.Add(contourPath);
				for (int i = 1; i < subPath.path.Count; i++)
				{
					PathComponent pathComponent = subPath.path[i];
					PathComponent pathComponent2 = subPath.path[i - 1];
					if (contourPath.path.Count < 1)
					{
						contourPath.path.Add(pathComponent2.pos);
					}
					if (pathComponent.segmentType == PathComponent.SegmentType.arc)
					{
						float x = pathComponent2.pos.x;
						float y = pathComponent2.pos.y;
						float x2 = pathComponent.pos.x;
						float y2 = pathComponent.pos.y;
						float rho = pathComponent.arcRotation;
						float num = Mathf.Cos(rho) * ((x - x2) / 2f) + Mathf.Sin(rho) * ((y - y2) / 2f);
						float num2 = (0f - Mathf.Sin(rho)) * ((x - x2) / 2f) + Mathf.Cos(rho) * ((y - y2) / 2f);
						float num3 = num * num;
						float num4 = num2 * num2;
						float rx = pathComponent.arcRadius.x;
						float ry = pathComponent.arcRadius.y;
						float num5 = num3 / (rx * rx) + num4 / (ry * ry);
						if (num5 > 1f)
						{
							float num6 = Mathf.Sqrt(num5);
							rx *= num6;
							ry *= num6;
						}
						float num7 = rx * rx;
						float num8 = ry * ry;
						float num9 = Mathf.Sqrt(Mathf.Abs((num7 * num8 - num7 * num4 - num8 * num3) / (num7 * num4 + num8 * num3)));
						float num10 = num9 * (rx * num2 / ry);
						float num11 = num9 * (0f - ry * num / rx);
						if (pathComponent.arcLarge == pathComponent.arcSweep)
						{
							num10 = 0f - num10;
							num11 = 0f - num11;
						}
						float cx = Mathf.Cos(rho) * num10 + (0f - Mathf.Sin(rho)) * num11 + (x + x2) / 2f;
						float cy = Mathf.Sin(rho) * num10 + Mathf.Cos(rho) * num11 + (y + y2) / 2f;
						float theta1 = GeneralUtilities.AngleBetweenVectors(new Vector2(1f, 0f), new Vector2((num - num10) / rx, (num2 - num11) / ry));
						float dtheta = GeneralUtilities.AngleBetweenVectors(new Vector2((num - num10) / rx, (num2 - num11) / ry), new Vector2((0f - num - num10) / rx, (0f - num2 - num11) / ry)) % ((float)Math.PI * 2f);
						if (!pathComponent.arcSweep && dtheta > 0f)
						{
							dtheta -= (float)Math.PI * 2f;
						}
						else if (pathComponent.arcSweep && dtheta < 0f)
						{
							dtheta += (float)Math.PI * 2f;
						}
						DynamicallySubdivide(options, delegate(float t)
						{
							float f = theta1 + t * dtheta;
							float x3 = Mathf.Cos(rho) * rx * Mathf.Cos(f) + (0f - Mathf.Sin(rho)) * ry * Mathf.Sin(f) + cx;
							float y3 = Mathf.Sin(rho) * rx * Mathf.Cos(f) + Mathf.Cos(rho) * ry * Mathf.Sin(f) + cy;
							return new Vector2(x3, y3);
						}, 0, 0f, 1f, pathComponent2.pos, pathComponent.pos, ref contourPath.path);
					}
					else if (pathComponent.segmentType == PathComponent.SegmentType.cubic)
					{
						Vector2 p_0 = pathComponent2.pos;
						Vector2 p_1 = (pathComponent.useStartCurvePos ? pathComponent.startCurvePos : pathComponent.pos);
						Vector2 p_2 = (pathComponent.useEndCurvePos ? pathComponent.endCurvePos : pathComponent.pos);
						Vector2 p_3 = pathComponent.pos;
						DynamicallySubdivide(options, (float t) => Mathf.Pow(1f - t, 3f) * p_0 + 3f * Mathf.Pow(1f - t, 2f) * t * p_1 + 3f * (1f - t) * Mathf.Pow(t, 2f) * p_2 + Mathf.Pow(t, 3f) * p_3, 0, 0f, 1f, p_0, p_3, ref contourPath.path);
					}
					else if (pathComponent.segmentType == PathComponent.SegmentType.quadratic)
					{
						Vector3 p_4 = pathComponent2.pos;
						Vector3 p_5 = pathComponent.startCurvePos;
						Vector3 p_6 = pathComponent.pos;
						DynamicallySubdivide(options, (float t) => Mathf.Pow(1f - t, 2f) * p_4 + 2f * (1f - t) * t * p_5 + Mathf.Pow(t, 2f) * p_6, 0, 0f, 1f, p_4, p_6, ref contourPath.path);
					}
					contourPath.path.Add(pathComponent.pos);
				}
			}
			return list;
		}

		private bool ParseControlPoints(string data)
		{
			string pattern = "(?=[MZLHVCSQTAmzlhvcsqta])";
			IEnumerable<string> enumerable = from t in Regex.Split(data, pattern)
				where !string.IsNullOrEmpty(t)
				select t;
			Vector3 vector = Vector3.zero;
			List<char> list = new List<char>(ImportUtilities.wps) { ',' };
			subPaths.Add(new SubPath());
			SubPath subPath = new SubPath();
			subPaths.Add(subPath);
			foreach (string item2 in enumerable)
			{
				char c = item2[0];
				LinkedList<string> linkedList = new LinkedList<string>(item2.Substring(1).Replace("-", ",-").Replace("e,-", "e-")
					.Split(list.ToArray(), StringSplitOptions.RemoveEmptyEntries));
				for (LinkedListNode<string> linkedListNode = linkedList.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					if (linkedListNode.Value.Length - linkedListNode.Value.Replace(".", "").Length > 1)
					{
						string[] array = linkedListNode.Value.Split('.');
						linkedListNode.Value = array[0] + "." + array[1];
						for (int num = 2; num < array.Length; num++)
						{
							linkedListNode = linkedList.AddAfter(linkedListNode, "." + array[num]);
						}
					}
				}
				string[] array2 = linkedList.ToArray();
				bool flag = false;
				switch (c)
				{
				case 'M':
				case 'm':
				{
					flag = c == 'M';
					if (subPath.path.Count != 0)
					{
						subPath = new SubPath();
						subPaths.Add(subPath);
						if (flag)
						{
							vector = Vector3.zero;
						}
					}
					for (int num6 = 0; num6 < array2.Length; num6 += 2)
					{
						vector = new Vector3(float.Parse(array2[num6]) + (flag ? 0f : vector.x), float.Parse(array2[num6 + 1]) + (flag ? 0f : vector.y));
						PathComponent item = new PathComponent(vector);
						subPath.path.Add(item);
					}
					break;
				}
				case 'Z':
				case 'z':
					subPath.closed = true;
					subPath.path.Add(new PathComponent(subPath.path[0].pos));
					vector = subPath.path[0].pos;
					break;
				case 'L':
				case 'l':
				{
					flag = c == 'L';
					for (int num2 = 0; num2 < array2.Length; num2 += 2)
					{
						subPath.path.Add(PathComponent.LineTo(float.Parse(array2[num2]) + (flag ? 0f : vector.x), float.Parse(array2[num2 + 1]) + (flag ? 0f : vector.y)));
						vector = subPath.path.Last().pos;
					}
					break;
				}
				case 'H':
				case 'h':
				{
					flag = c == 'H';
					for (int num8 = 0; num8 < array2.Length; num8++)
					{
						subPath.path.Add(PathComponent.LineTo(float.Parse(array2[num8]) + (flag ? 0f : vector.x), vector.y));
						vector = subPath.path.Last().pos;
					}
					break;
				}
				case 'V':
				case 'v':
				{
					flag = c == 'V';
					for (int num4 = 0; num4 < array2.Length; num4++)
					{
						subPath.path.Add(PathComponent.LineTo(vector.x, float.Parse(array2[num4]) + (flag ? 0f : vector.y)));
						vector = subPath.path.Last().pos;
					}
					break;
				}
				case 'C':
				case 'c':
				{
					flag = c == 'C';
					for (int num10 = 0; num10 < array2.Length; num10 += 6)
					{
						PathComponent pathComponent5 = new PathComponent(float.Parse(array2[num10 + 4]) + (flag ? 0f : vector.x), float.Parse(array2[num10 + 5]) + (flag ? 0f : vector.y), float.Parse(array2[num10]) + (flag ? 0f : vector.x), float.Parse(array2[num10 + 1]) + (flag ? 0f : vector.y), float.Parse(array2[num10 + 2]) + (flag ? 0f : vector.x), float.Parse(array2[num10 + 3]) + (flag ? 0f : vector.y));
						subPath.path.Add(pathComponent5);
						vector = pathComponent5.pos;
					}
					break;
				}
				case 'S':
				case 's':
				{
					flag = c == 'S';
					for (int num9 = 0; num9 < array2.Length; num9 += 4)
					{
						Vector3 vector4 = ((subPath.path.Count >= 1) ? subPath.path.Last().GetMirroredCurveEndControlPoint() : vector);
						PathComponent pathComponent4 = new PathComponent(float.Parse(array2[num9 + 2]) + (flag ? 0f : vector.x), float.Parse(array2[num9 + 3]) + (flag ? 0f : vector.y), vector4.x, vector4.y, float.Parse(array2[num9]) + (flag ? 0f : vector.x), float.Parse(array2[num9 + 1]) + (flag ? 0f : vector.y));
						subPath.path.Add(pathComponent4);
						vector = pathComponent4.pos;
					}
					break;
				}
				case 'Q':
				case 'q':
				{
					flag = c == 'Q';
					for (int num7 = 0; num7 < array2.Length; num7 += 4)
					{
						PathComponent pathComponent3 = new PathComponent(float.Parse(array2[num7 + 2]) + (flag ? 0f : vector.x), float.Parse(array2[num7 + 3]) + (flag ? 0f : vector.y), float.Parse(array2[num7]) + (flag ? 0f : vector.x), float.Parse(array2[num7 + 1]) + (flag ? 0f : vector.y));
						if (subPath.path.Count != 0)
						{
							subPath.path.Last().endCurvePos = new Vector3(float.Parse(array2[num7]), float.Parse(array2[num7 + 1]));
						}
						subPath.path.Add(pathComponent3);
						vector = pathComponent3.pos;
					}
					break;
				}
				case 'A':
				case 'a':
				{
					flag = c == 'A';
					for (int num5 = 0; num5 < array2.Length; num5 += 7)
					{
						Vector2 vector3 = new Vector2(float.Parse(array2[num5 + 5]) + (flag ? 0f : vector.x), float.Parse(array2[num5 + 6]) + (flag ? 0f : vector.y));
						Vector2 radius = new Vector2(Mathf.Abs(float.Parse(array2[num5])), Mathf.Abs(float.Parse(array2[num5 + 1])));
						PathComponent pathComponent2 = ((!(radius.x > 0f) || !(radius.y > 0f)) ? new PathComponent(vector3) : new PathComponent(vector3, radius, float.Parse(array2[num5 + 2]) % 360f / 360f * ((float)Math.PI * 2f), int.Parse(array2[num5 + 3]) > 0, int.Parse(array2[num5 + 4]) > 0));
						subPath.path.Add(pathComponent2);
						vector = pathComponent2.pos;
					}
					break;
				}
				case 'T':
				case 't':
				{
					flag = c == 'T';
					for (int num3 = 0; num3 < array2.Length; num3 += 4)
					{
						float x = float.Parse(array2[num3]) + (flag ? 0f : vector.x);
						float y = float.Parse(array2[num3 + 1]) + (flag ? 0f : vector.y);
						Vector3 vector2 = ((subPath.path.Count >= 1) ? subPath.path.Last().GetMirroredCurveStartControlPoint() : new Vector3(x, y, 0f));
						PathComponent pathComponent = new PathComponent(x, y, vector2.x, vector2.y);
						if (subPath.path.Count != 0)
						{
							subPath.path.Last().endCurvePos = new Vector3(float.Parse(array2[num3]), float.Parse(array2[num3 + 1]));
						}
						subPath.path.Add(pathComponent);
						vector = pathComponent.pos;
					}
					break;
				}
				default:
					if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_WARNINGS_AND_INFO)
					{
						Debug.LogWarning("There's no use for " + c + " command in path");
					}
					break;
				case ' ':
					break;
				}
			}
			return true;
		}

		public static void DynamicallySubdivide(ImportSettings options, MakePathPointDelegate pointMaker, int depth, float t1, float t2, Vector2 v1, Vector2 v2, ref List<Vector2> path)
		{
			float num = t2 - (t2 - t1) / 2f;
			Vector2 vector = pointMaker(num);
			Vector2 u = vector - v1;
			if ((Mathf.Abs(Mathf.Sin(GeneralUtilities.AngleBetweenVectors(u, v2 - v1)) * u.magnitude) > options.minSubdivisionDistanceDelta && depth <= options.maxSubdivisonDepth) || depth < 1)
			{
				DynamicallySubdivide(options, pointMaker, depth + 1, t1, num, v1, vector, ref path);
				path.Add(new Vector2(vector.x, vector.y));
				DynamicallySubdivide(options, pointMaker, depth + 1, num, t2, vector, v2, ref path);
			}
		}
	}
}
