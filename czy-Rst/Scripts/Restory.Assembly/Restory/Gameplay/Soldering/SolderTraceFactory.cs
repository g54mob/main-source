using System;
using System.Collections.Generic;
using Restory.Data.Soldering;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Soldering
{
	public class SolderTraceFactory
	{
		private readonly SolderTraceFactorySettings settings;

		private readonly float circleRadius;

		private readonly float angleStep;

		[Inject]
		public SolderTraceFactory(SolderTraceFactorySettings settings)
		{
			this.settings = settings;
			circleRadius = settings.TraceWidth * 0.5f;
			angleStep = MathF.PI * 2f / (float)settings.CircleSegments;
		}

		public SolderTrace Create(int traceIndex, IReadOnlyList<SolderPoint> tracePoints, Transform parent)
		{
			if (tracePoints.Count < 2)
			{
				Debug.LogError("tracePoints should contains at least two points to be generated");
				return null;
			}
			GameObject gameObject = new GameObject(string.Format("{0} ({1})", "SolderTrace", traceIndex));
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			Mesh traceMesh = BuildMergedPivotTraceMesh(tracePoints);
			SolderTrace solderTrace = gameObject.AddComponent<SolderTrace>();
			solderTrace.Init(traceMesh, settings.SolderMaterial);
			return solderTrace;
		}

		public void Destroy(SolderTrace solderTrace)
		{
			if ((bool)solderTrace)
			{
				MeshFilter component = solderTrace.GetComponent<MeshFilter>();
				if (component?.sharedMesh != null)
				{
					DestroyObject(component.sharedMesh);
				}
				DestroyObject(solderTrace);
			}
		}

		private Mesh BuildMergedPivotTraceMesh(IReadOnlyList<SolderPoint> tracePoints)
		{
			List<Vector3> value;
			using (CollectionPool<List<Vector3>, Vector3>.Get(out value))
			{
				List<int> value2;
				using (CollectionPool<List<int>, int>.Get(out value2))
				{
					bool flag = false;
					Vector3 start = Vector3.zero;
					foreach (SolderPoint tracePoint in tracePoints)
					{
						if (tracePoint.IsPivot)
						{
							Vector3 position = tracePoint.Data.Transform.Position;
							AddCircle(position, value, value2);
							if (flag)
							{
								AddBridgeQuad(start, position, value, value2);
							}
							start = position;
							flag = true;
						}
					}
					Mesh mesh = new Mesh();
					mesh.name = "TraceMesh";
					mesh.SetVertices(value);
					mesh.SetTriangles(value2, 0);
					mesh.RecalculateNormals();
					mesh.RecalculateBounds();
					return mesh;
				}
			}
		}

		private void AddCircle(Vector3 center, List<Vector3> vertices, List<int> triangles)
		{
			int count = vertices.Count;
			vertices.Add(center);
			for (int i = 0; i < settings.CircleSegments; i++)
			{
				float f = (float)i * angleStep;
				Vector3 vector = new Vector3(Mathf.Cos(f) * circleRadius, Mathf.Sin(f) * circleRadius, 0f);
				vertices.Add(center + vector);
			}
			for (int j = 0; j < settings.CircleSegments; j++)
			{
				int item = count + 1 + j;
				int item2 = count + 1 + (j + 1) % settings.CircleSegments;
				triangles.Add(count);
				triangles.Add(item2);
				triangles.Add(item);
			}
		}

		private void AddBridgeQuad(Vector3 start, Vector3 end, List<Vector3> vertices, List<int> triangles)
		{
			Vector3 vector = end - start;
			if (!(vector.sqrMagnitude <= Mathf.Epsilon))
			{
				Vector3 normalized = vector.normalized;
				Vector3 vector2 = new Vector3(0f - normalized.y, normalized.x, 0f) * circleRadius;
				Vector3 item = start - vector2;
				Vector3 item2 = start + vector2;
				Vector3 item3 = end + vector2;
				Vector3 item4 = end - vector2;
				int count = vertices.Count;
				vertices.Add(item);
				vertices.Add(item2);
				vertices.Add(item3);
				vertices.Add(item4);
				triangles.Add(count);
				triangles.Add(count + 1);
				triangles.Add(count + 2);
				triangles.Add(count);
				triangles.Add(count + 2);
				triangles.Add(count + 3);
			}
		}

		private static void DestroyObject(UnityEngine.Object objectToDestroy)
		{
			if ((bool)objectToDestroy)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(objectToDestroy);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(objectToDestroy);
				}
			}
		}
	}
}
