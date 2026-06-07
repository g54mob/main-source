using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class GLRenderer
	{
		public static void DrawQuads2D(List<Vector2> quadPoints, Camera camera)
		{
			int num = quadPoints.Count / 4;
			if (num >= 1)
			{
				GL.PushMatrix();
				GL.LoadOrtho();
				GL.Begin(7);
				for (int i = 0; i < num; i++)
				{
					int num2 = i * 4;
					GL.Vertex(camera.ScreenToViewportPoint(quadPoints[num2]));
					GL.Vertex(camera.ScreenToViewportPoint(quadPoints[num2 + 1]));
					GL.Vertex(camera.ScreenToViewportPoint(quadPoints[num2 + 2]));
					GL.Vertex(camera.ScreenToViewportPoint(quadPoints[num2 + 3]));
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		public static void DrawLineLoop2D(List<Vector2> linePoints, Camera camera)
		{
			if (linePoints.Count >= 2)
			{
				GL.PushMatrix();
				GL.LoadOrtho();
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count; i++)
				{
					Vector3 position = linePoints[i];
					Vector3 position2 = linePoints[(i + 1) % linePoints.Count];
					position = camera.ScreenToViewportPoint(position);
					position2 = camera.ScreenToViewportPoint(position2);
					GL.Vertex(new Vector3(position.x, position.y, 0f));
					GL.Vertex(new Vector3(position2.x, position2.y, 0f));
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		public static void DrawLineLoop2D(List<Vector2> linePoints, Vector2 translation, Vector2 scale, Camera camera)
		{
			if (linePoints.Count >= 2)
			{
				GL.PushMatrix();
				GL.LoadOrtho();
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count; i++)
				{
					Vector3 position = Vector2.Scale(linePoints[i], scale) + translation;
					Vector3 position2 = Vector2.Scale(linePoints[(i + 1) % linePoints.Count], scale) + translation;
					position = camera.ScreenToViewportPoint(position);
					position2 = camera.ScreenToViewportPoint(position2);
					GL.Vertex(new Vector3(position.x, position.y, 0f));
					GL.Vertex(new Vector3(position2.x, position2.y, 0f));
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		public static void DrawLines2D(List<Vector2> linePoints, Camera camera)
		{
			if (linePoints.Count >= 2)
			{
				GL.PushMatrix();
				GL.LoadOrtho();
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count - 1; i++)
				{
					Vector3 position = linePoints[i];
					Vector3 position2 = linePoints[i + 1];
					position = camera.ScreenToViewportPoint(position);
					position2 = camera.ScreenToViewportPoint(position2);
					GL.Vertex(new Vector3(position.x, position.y, 0f));
					GL.Vertex(new Vector3(position2.x, position2.y, 0f));
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		public static void DrawLines2D(List<Vector2> linePoints, Vector2 translation, Vector2 scale, Camera camera)
		{
			if (linePoints.Count >= 2)
			{
				GL.PushMatrix();
				GL.LoadOrtho();
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count - 1; i++)
				{
					Vector3 position = Vector2.Scale(linePoints[i], scale) + translation;
					Vector3 position2 = Vector2.Scale(linePoints[i + 1], scale) + translation;
					position = camera.ScreenToViewportPoint(position);
					position2 = camera.ScreenToViewportPoint(position2);
					GL.Vertex(new Vector3(position.x, position.y, 0f));
					GL.Vertex(new Vector3(position2.x, position2.y, 0f));
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		public static void DrawLine2D(Vector2 startPoint, Vector2 endPoint, Camera camera)
		{
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Begin(1);
			GL.Vertex(camera.ScreenToViewportPoint(startPoint));
			GL.Vertex(camera.ScreenToViewportPoint(endPoint));
			GL.End();
			GL.PopMatrix();
		}

		public static void DrawLine3D(Vector3 startPoint, Vector3 endPoint)
		{
			GL.Begin(1);
			GL.Vertex(startPoint);
			GL.Vertex(endPoint);
			GL.End();
		}

		public static void DrawLines3D(List<Vector3> linePoints)
		{
			if (linePoints.Count >= 2)
			{
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count - 1; i++)
				{
					Vector3 v = linePoints[i];
					Vector3 v2 = linePoints[i + 1];
					GL.Vertex(v);
					GL.Vertex(v2);
				}
				GL.End();
			}
		}

		public static void DrawLineLoop3D(List<Vector3> linePoints)
		{
			if (linePoints.Count >= 2)
			{
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count; i++)
				{
					Vector3 v = linePoints[i];
					Vector3 v2 = linePoints[(i + 1) % linePoints.Count];
					GL.Vertex(v);
					GL.Vertex(v2);
				}
				GL.End();
			}
		}

		public static void DrawLineStrip3D(List<Vector3> linePoints)
		{
			if (linePoints.Count >= 2)
			{
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count - 1; i++)
				{
					GL.Vertex(linePoints[i]);
					GL.Vertex(linePoints[i + 1]);
				}
				GL.End();
			}
		}

		public static void DrawLineLoop3D(List<Vector3> linePoints, Vector3 pointOffset)
		{
			if (linePoints.Count >= 2)
			{
				GL.Begin(1);
				for (int i = 0; i < linePoints.Count; i++)
				{
					Vector3 v = linePoints[i] + pointOffset;
					Vector3 v2 = linePoints[(i + 1) % linePoints.Count] + pointOffset;
					GL.Vertex(v);
					GL.Vertex(v2);
				}
				GL.End();
			}
		}

		public static void DrawLinePairs3D(List<Vector3> pairPoints)
		{
			if (pairPoints.Count >= 2 && pairPoints.Count % 2 == 0)
			{
				GL.Begin(1);
				for (int i = 0; i < pairPoints.Count; i += 2)
				{
					Vector3 v = pairPoints[i];
					Vector3 v2 = pairPoints[i + 1];
					GL.Vertex(v);
					GL.Vertex(v2);
				}
				GL.End();
			}
		}

		public static void DrawRectBorder2D(Rect rect, Camera camera)
		{
			DrawLineLoop2D(rect.GetCornerPoints(), camera);
		}

		public static void DrawRect2D(Rect rect, Camera camera)
		{
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Begin(7);
			List<Vector2> cornerPoints = rect.GetCornerPoints();
			cornerPoints[0] = camera.ScreenToViewportPoint(cornerPoints[0]);
			cornerPoints[1] = camera.ScreenToViewportPoint(cornerPoints[1]);
			cornerPoints[2] = camera.ScreenToViewportPoint(cornerPoints[2]);
			cornerPoints[3] = camera.ScreenToViewportPoint(cornerPoints[3]);
			GL.Vertex(cornerPoints[0]);
			GL.Vertex(cornerPoints[1]);
			GL.Vertex(cornerPoints[2]);
			GL.Vertex(cornerPoints[3]);
			GL.End();
			GL.PopMatrix();
		}

		public static void DrawCircleBorder2D(Vector2 circleCenter, float circleRadius, int numPoints, Camera camera)
		{
			DrawLineLoop2D(PrimitiveFactory.Generate2DCircleBorderPointsCW(circleCenter, circleRadius, numPoints), camera);
		}

		public static void DrawCircle2D(Vector2 circleCenter, float circleRadius, int numPoints, Camera camera)
		{
			List<Vector2> points = PrimitiveFactory.Generate2DCircleBorderPointsCW(circleCenter, circleRadius, numPoints);
			DrawTriangleFan2D(circleCenter, points, camera);
		}

		public static void DrawCircleBorder3D(Vector3 circleCenter, float circleRadius, Vector3 circleRight, Vector3 circleUp, int numPoints)
		{
			DrawLineLoop3D(PrimitiveFactory.Generate3DCircleBorderPoints(circleCenter, circleRadius, circleRight, circleUp, numPoints));
		}

		public static void DrawCircle3D(Vector2 circleCenter, float circleRadius, Vector3 circleRight, Vector3 circleUp, int numPoints)
		{
			List<Vector3> points = PrimitiveFactory.Generate3DCircleBorderPoints(circleCenter, circleRadius, circleRight, circleUp, numPoints);
			DrawTriangleFan3D(circleCenter, points);
		}

		public static void DrawSphereBorder(Camera camera, Vector3 sphereCenter, float sphereRadius, int numPoints)
		{
			DrawLineLoop3D(PrimitiveFactory.GenerateSphereBorderPoints(camera, sphereCenter, sphereRadius, numPoints));
		}

		public static void DrawTriangleFan2D(Vector2 origin, List<Vector2> points, Vector2 translation, Vector2 scale, Camera camera)
		{
			int num = points.Count - 1;
			if (num >= 1)
			{
				GL.PushMatrix();
				GL.LoadOrtho();
				GL.Begin(4);
				origin = camera.ScreenToViewportPoint(Vector2.Scale(origin, scale) + translation);
				for (int i = 0; i < num; i++)
				{
					GL.Vertex(origin);
					GL.Vertex(camera.ScreenToViewportPoint(Vector2.Scale(points[i], scale) + translation));
					GL.Vertex(camera.ScreenToViewportPoint(Vector2.Scale(points[i + 1], scale) + translation));
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		public static void DrawTriangleFan2D(Vector2 origin, List<Vector2> points, Camera camera)
		{
			int num = points.Count - 1;
			if (num >= 1)
			{
				GL.PushMatrix();
				GL.LoadOrtho();
				GL.Begin(4);
				origin = camera.ScreenToViewportPoint(origin);
				for (int i = 0; i < num; i++)
				{
					GL.Vertex(origin);
					GL.Vertex(camera.ScreenToViewportPoint(points[i]));
					GL.Vertex(camera.ScreenToViewportPoint(points[i + 1]));
				}
				GL.End();
				GL.PopMatrix();
			}
		}

		public static void DrawTriangleFan3D(Vector3 origin, List<Vector3> points, Vector3 translation, Vector3 scale)
		{
			int num = points.Count - 1;
			if (num >= 1)
			{
				GL.Begin(4);
				origin = Vector3.Scale(origin, scale) + translation;
				for (int i = 0; i < num; i++)
				{
					GL.Vertex(origin);
					GL.Vertex(Vector3.Scale(points[i], scale) + translation);
					GL.Vertex(Vector3.Scale(points[i + 1], scale) + translation);
				}
				GL.End();
			}
		}

		public static void DrawTriangleFan3D(Vector3 origin, List<Vector3> points)
		{
			int num = points.Count - 1;
			if (num >= 1)
			{
				GL.Begin(4);
				for (int i = 0; i < num; i++)
				{
					GL.Vertex(origin);
					GL.Vertex(points[i]);
					GL.Vertex(points[i + 1]);
				}
				GL.End();
			}
		}
	}
}
