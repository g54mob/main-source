using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace emotiontheory
{
	[ExecuteInEditMode]
	public class ETLine : MonoBehaviour
	{
		[Serializable]
		public class WaypointList
		{
			public ETLine circuit;

			public Transform[] items = new Transform[0];
		}

		public struct RoutePoint
		{
			public Vector3 position;

			public Vector3 direction;

			public RoutePoint(Vector3 position, Vector3 direction)
			{
				this.position = position;
				this.direction = direction;
			}
		}

		public class TransformNameComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				return ((Transform)x).name.CompareTo(((Transform)y).name);
			}
		}

		[HideInInspector]
		public WaypointList waypointList = new WaypointList();

		[Tooltip("If the line is straight or smooth/curved.")]
		[SerializeField]
		private bool smoothRoute = true;

		[HideInInspector]
		public List<Vector3> points;

		private float[] distances;

		[Tooltip("Loops the shape or not.")]
		public bool Loop;

		private bool UseChildren = true;

		[Tooltip("How smooth the line is based on math calculations (higher number = more smooth).")]
		public float editorVisualisationSubsteps = 1000f;

		private int p0n;

		private int p1n;

		private int p2n;

		private int p3n;

		private float i;

		private Vector3 P0;

		private Vector3 P1;

		private Vector3 P2;

		private Vector3 P3;

		[Tooltip("The parent of the created objects.")]
		public Transform ParentTarget;

		[Tooltip("Tick this if you want to set your total number.")]
		public bool UseFrequency = true;

		[Tooltip("The total number of objects spread evenly.")]
		[Range(-1f, 1000f)]
		public int Frequency = 3;

		[Tooltip("The distances between objects along the line. Untick UseFrequency to set this manually.")]
		[Range(0f, 100f)]
		public float StepSize;

		[Tooltip("Check this to set objects to look along the line.")]
		public bool LookForward;

		[Tooltip("The positional offset.")]
		public Vector3 posOffset;

		[Tooltip("Randomized positional variance.")]
		public Vector3 randomPosVariance;

		[Tooltip("The Prefabs you wish to create.")]
		public Transform[] Items;

		[HideInInspector]
		[SerializeField]
		private List<Transform> Children = new List<Transform>();

		[Tooltip("Run automatically. (Right-click the script name to Run manually)")]
		public bool UpdateInRealTime = true;

		public Transform ClosestPointTarget;

		private int numPoints
		{
			get
			{
				return Waypoints.Length;
			}
		}

		public float Length
		{
			get
			{
				if (distances != null && distances.Length != 0)
				{
					return distances[distances.Length - 1];
				}
				return 0f;
			}
		}

		public Transform[] Waypoints
		{
			get
			{
				return waypointList.items;
			}
		}

		public ETLine circuit
		{
			get
			{
				return this;
			}
		}

		public Vector3 RandomPosVariance
		{
			get
			{
				return new Vector3(UnityEngine.Random.Range(0f - randomPosVariance.x, randomPosVariance.x), UnityEngine.Random.Range(0f - randomPosVariance.y, randomPosVariance.y), UnityEngine.Random.Range(0f - randomPosVariance.z, randomPosVariance.z));
			}
		}

		[ContextMenu("Run")]
		public void Run()
		{
			if (Children == null)
			{
				Children = new List<Transform>();
			}
			foreach (Transform child in Children)
			{
				if (!(child == null))
				{
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(child.gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(child.gameObject);
					}
				}
			}
			Children.Clear();
			if (!ParentTarget && base.transform != circuit.transform)
			{
				ParentTarget = base.transform;
			}
			if (!ParentTarget || Items == null || Items.Length == 0 || (Frequency <= 0 && StepSize <= 0f))
			{
				return;
			}
			if (UseFrequency && Frequency > 0)
			{
				StepSize = circuit.Length / (float)Frequency;
			}
			else
			{
				Frequency = (int)(circuit.Length / StepSize);
			}
			if (UseChildren)
			{
				AssignChildren();
				CachePositionsAndDistances();
			}
			for (int i = 0; i < Frequency; i++)
			{
				float dist = StepSize * (float)i;
				Transform transform = UnityEngine.Object.Instantiate(Items[UnityEngine.Random.Range(0, Items.Length)]);
				RoutePoint routePoint = circuit.GetRoutePoint(dist);
				transform.transform.position = routePoint.position;
				if (LookForward)
				{
					transform.transform.forward = routePoint.direction;
				}
				transform.transform.position = transform.transform.TransformPoint(posOffset);
				transform.transform.position = transform.transform.TransformPoint(RandomPosVariance);
				transform.transform.SetParent(ParentTarget, true);
				Children.Add(transform);
			}
		}

		private void Start()
		{
			if (Application.isPlaying)
			{
				base.enabled = false;
			}
		}

		public Vector3 GetRoutPositionNormalized(float normDist)
		{
			normDist = Mathf.Clamp01(normDist);
			float dist = Length * normDist;
			return GetRoutePosition(dist);
		}

		public RoutePoint GetRoutePointNormalized(float normDist)
		{
			normDist = Mathf.Clamp01(normDist);
			float dist = Length * normDist;
			return GetRoutePoint(dist);
		}

		public RoutePoint GetRoutePoint(float dist)
		{
			Vector3 routePosition = GetRoutePosition(dist);
			Vector3 routePosition2 = GetRoutePosition(dist + 0.01f);
			Vector3 routePosition3 = GetRoutePosition(dist - 0.01f);
			Vector3 vector = routePosition2 - routePosition;
			if (!Loop && dist >= Length)
			{
				vector = routePosition - routePosition3;
			}
			return new RoutePoint(routePosition, vector.normalized);
		}

		public Vector3 GetRoutePosition(float dist)
		{
			int i = 0;
			if (Loop || dist > Length)
			{
				dist = Mathf.Repeat(dist, Length);
			}
			for (; distances[i] < dist; i++)
			{
			}
			p1n = (i - 1 + numPoints) % numPoints;
			p2n = i;
			this.i = Mathf.InverseLerp(distances[p1n], distances[p2n], dist);
			if (smoothRoute)
			{
				if (Loop)
				{
					p0n = (i - 2 + numPoints) % numPoints;
					p3n = (i + 1) % numPoints;
					p2n %= numPoints;
				}
				else
				{
					p0n = Mathf.Clamp(i - 2, 0, numPoints - 1);
					p3n = Mathf.Clamp(i + 1, 0, numPoints - 1);
				}
				P0 = points[p0n];
				P1 = points[p1n];
				P2 = points[p2n];
				P3 = points[p3n];
				return CatmullRom(P0, P1, P2, P3, this.i);
			}
			p1n = (i - 1 + numPoints) % numPoints;
			p2n = i;
			return Vector3.Lerp(points[p1n], points[p2n], this.i);
		}

		private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float i)
		{
			return 0.5f * (2f * p1 + (-p0 + p2) * i + (2f * p0 - 5f * p1 + 4f * p2 - p3) * i * i + (-p0 + 3f * p1 - 3f * p2 + p3) * i * i * i);
		}

		private void CachePositionsAndDistances()
		{
			int num = Waypoints.Length;
			if (Loop)
			{
				num++;
			}
			points = new List<Vector3>();
			distances = new float[num];
			float num2 = 0f;
			for (int i = 0; i < num; i++)
			{
				Transform transform = Waypoints[i % Waypoints.Length];
				Transform transform2 = Waypoints[(i + 1) % Waypoints.Length];
				if (transform != null && transform2 != null)
				{
					Vector3 position = transform.position;
					Vector3 position2 = transform2.position;
					points.Add(Waypoints[i % Waypoints.Length].position);
					distances[i] = num2;
					num2 += (position - position2).magnitude;
				}
			}
		}

		public void AssignChildren()
		{
			Transform[] array = new Transform[this.transform.childCount];
			int num = 0;
			foreach (Transform item in this.transform)
			{
				array[num++] = item;
			}
			Array.Sort(array, new TransformNameComparer());
			waypointList.items = new Transform[array.Length];
			for (num = 0; num < array.Length; num++)
			{
				waypointList.items[num] = array[num];
			}
			UseChildren = true;
		}

		private void OnDrawGizmos()
		{
			DrawGizmos(false);
		}

		private void OnDrawGizmosSelected()
		{
			DrawGizmos(true);
		}

		public static Vector3 ClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint)
		{
			Vector3 rhs = vPoint - vA;
			Vector3 normalized = (vB - vA).normalized;
			float num = Vector3.Distance(vA, vB);
			float num2 = Vector3.Dot(normalized, rhs);
			if (num2 <= 0f)
			{
				return vA;
			}
			if (num2 >= num)
			{
				return vB;
			}
			Vector3 vector = normalized * num2;
			return vA + vector;
		}

		private void DrawGizmos(bool selected)
		{
			if ((bool)ClosestPointTarget)
			{
				Vector3 to = ClosestPointOnLine(points[0], points[1], ClosestPointTarget.position);
				Gizmos.DrawLine(ClosestPointTarget.position, to);
			}
			if (!UseChildren)
			{
				if (numPoints < 2)
				{
					return;
				}
				float num = 0f;
				distances = new float[numPoints];
				distances[0] = num;
				for (int i = 1; i < numPoints; i++)
				{
					Vector3 vector = points[i];
					Vector3 vector2 = points[i - 1];
					num += (vector - vector2).magnitude;
					distances[i] = num;
				}
				Gizmos.color = (selected ? Color.yellow : new Color(1f, 1f, 0f, 0.5f));
				Vector3 vector3 = points[0];
				if (smoothRoute)
				{
					for (float num2 = 0f; num2 < Length; num2 += Length / editorVisualisationSubsteps)
					{
						Vector3 routePosition = GetRoutePosition(num2 + 1f);
						if (Loop)
						{
							Gizmos.DrawLine(vector3, routePosition);
						}
						else if (!Loop && num2 + 1f <= Length)
						{
							Gizmos.DrawLine(vector3, routePosition);
						}
						vector3 = routePosition;
					}
					if (Loop)
					{
						Gizmos.DrawLine(vector3, points[0]);
					}
					return;
				}
				for (int j = 0; j < points.Count; j++)
				{
					if (Loop || j != points.Count - 1)
					{
						Vector3 vector4 = points[(j + 1) % points.Count];
						Gizmos.DrawLine(vector3, vector4);
						vector3 = vector4;
					}
				}
				return;
			}
			waypointList.circuit = this;
			AssignChildren();
			if (Waypoints.Length < 2)
			{
				return;
			}
			CachePositionsAndDistances();
			Gizmos.color = (selected ? Color.yellow : new Color(1f, 1f, 0f, 0.5f));
			Vector3 vector5 = Waypoints[0].position;
			if (smoothRoute)
			{
				for (float num3 = 0f; num3 < Length; num3 += Length / editorVisualisationSubsteps)
				{
					Vector3 routePosition2 = GetRoutePosition(num3 + 1f);
					if (Loop)
					{
						Gizmos.DrawLine(vector5, routePosition2);
					}
					else if (!Loop && num3 + 1f <= Length)
					{
						Gizmos.DrawLine(vector5, routePosition2);
					}
					vector5 = routePosition2;
				}
				if (Loop)
				{
					Gizmos.DrawLine(vector5, Waypoints[0].position);
				}
				return;
			}
			for (int k = 0; k < Waypoints.Length; k++)
			{
				if (Loop || k != Waypoints.Length - 1)
				{
					Vector3 position = Waypoints[(k + 1) % Waypoints.Length].position;
					Gizmos.DrawLine(vector5, position);
					vector5 = position;
				}
			}
		}
	}
}
