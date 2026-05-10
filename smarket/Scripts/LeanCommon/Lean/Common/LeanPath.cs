using System.Collections.Generic;
using UnityEngine;

namespace Lean.Common
{
	[ExecuteInEditMode]
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanPath")]
	[AddComponentMenu("Lean/Common/Lean Path")]
	public class LeanPath : MonoBehaviour
	{
		[Tooltip("The points along the path.")]
		public List<Vector3> Points;

		[Tooltip("Do these points loop back to the start?")]
		public bool Loop;

		[Tooltip("The coordinate system for the points.")]
		public Space Space;

		[Tooltip("The amount of lines between each path point when read from LeanScreenDepth.")]
		public int Smoothing;

		[Tooltip("This allows you to draw a visual of the path using a LineRenderer.")]
		public LineRenderer Visual;

		public static Vector3 LastWorldNormal;

		public int PointCount => 0;

		public int GetPointCount(int smoothing = -1)
		{
			return 0;
		}

		public Vector3 GetSmoothedPoint(float index)
		{
			return default(Vector3);
		}

		public Vector3 GetPoint(int index, int smoothing = -1)
		{
			return default(Vector3);
		}

		private Vector3 GetPointRaw(int index, int count)
		{
			return default(Vector3);
		}

		public void SetLine(Vector3 a, Vector3 b)
		{
		}

		public bool TryGetClosest(Vector3 position, ref Vector3 closestPoint, ref int closestIndexA, ref int closestIndexB, int smoothing = -1)
		{
			return false;
		}

		public bool TryGetClosest(Vector3 position, ref Vector3 closestPoint, int smoothing = -1)
		{
			return false;
		}

		public bool TryGetClosest(Ray ray, ref Vector3 closestPoint, ref int closestIndexA, ref int closestIndexB, int smoothing = -1)
		{
			return false;
		}

		public bool TryGetClosest(Ray ray, ref Vector3 currentPoint, int smoothing = -1)
		{
			return false;
		}

		public bool TryGetClosest(Ray ray, ref Vector3 currentPoint, int smoothing = -1, float maximumDelta = -1f)
		{
			return false;
		}

		private Vector3 GetClosestPoint(Vector3 position, Vector3 origin, Vector3 direction)
		{
			return default(Vector3);
		}

		private Vector3 GetClosestPoint(Ray ray, Vector3 origin, Vector3 direction)
		{
			return default(Vector3);
		}

		private float GetClosestDistance(Ray ray, Vector3 point)
		{
			return 0f;
		}

		private int Mod(int a, int b)
		{
			return 0;
		}

		private float CubicInterpolate(float a, float b, float c, float d, float t)
		{
			return 0f;
		}

		public void UpdateVisual()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
