using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Orbits;
using ModApi;
using ModApi.Flight.Sim;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.Flight.MapView.MapDebug
{
	internal class ClosestPointScript : MonoBehaviour
	{
		private GameObject _closestPoint;

		private VectorLine _connectingLine;

		private VectorLine _ellipse;

		private IOrbit _orbit;

		private GameObject _plane;

		private GameObject _spherePoint;

		private float _xRadius = 10f;

		private float _yRadius = 5f;

		public MapViewScript MapViewScript { get; private set; }

		public static Vector2 ClosestPointToEllipse(Vector3 center, float xRadius, float yRadius, Vector2 point)
		{
			Vector2 vector = new Vector2(center.x, center.z);
			Vector2 vector2 = point - vector;
			bool flag = false;
			bool flag2 = false;
			if (vector2.x < 0f)
			{
				vector2.x = 0f - vector2.x;
				flag = true;
			}
			if (vector2.y < 0f)
			{
				vector2.y = 0f - vector2.y;
				flag2 = true;
			}
			float num = yRadius * yRadius - xRadius * xRadius;
			float num2 = xRadius * vector2.x / num;
			float num3 = num2 * num2;
			float num4 = yRadius * vector2.y / num;
			float num5 = num4 * num4;
			float num6 = (num3 + num5 - 1f) / 3f;
			float num7 = num6 * num6 * num6;
			float num8 = num7 + num5 * num3 * 2f;
			float num9 = num7 + num5 * num3;
			float num10 = num2 + num2 * num5;
			float num15;
			if (num9 < 0f)
			{
				float f = Mathf.Acos(num8 / num7) / 3f;
				float num11 = Mathf.Cos(f);
				float num12 = Mathf.Sin(f) * Mathf.Sqrt(3f);
				float num13 = Mathf.Sqrt((0f - num6) * (num11 + num12 + 2f) + num3);
				float num14 = Mathf.Sqrt((0f - num6) * (num11 - num12 + 2f) + num3);
				num15 = (num14 + ((num > 0f) ? num13 : (0f - num13)) + Mathf.Abs(num10) / (num13 * num14) - num2) / 2f;
			}
			else
			{
				float num16 = 2f * num2 * num4 * Mathf.Sqrt(num9);
				float num17 = Mathf.Pow(num8 + num16, 1f / 3f);
				float num18 = Mathf.Pow(num8 - num16, 1f / 3f);
				float num19 = 0f - num17 - num18 - num6 * 4f + 2f * num3;
				float num20 = (num17 - num18) * Mathf.Sqrt(3f);
				float num21 = Mathf.Sqrt(num19 * num19 + num20 * num20);
				num15 = (num20 / Mathf.Sqrt(num21 - num19) + 2f * num10 / num21 - num2) / 2f;
			}
			if (num15 > 1f)
			{
				num15 = 1f;
			}
			float num22 = Mathf.Sqrt(1f - num15 * num15);
			Debug.LogFormat("d: {0}, co: {1}, si: {2}", num9, num15, num22);
			float num23 = xRadius * num15;
			float num24 = yRadius * num22;
			if (flag)
			{
				num23 = 0f - num23;
			}
			if (flag2)
			{
				num24 = 0f - num24;
			}
			return new Vector2(num23, num24) + vector;
		}

		public static Vector2 ClosestPointToEllipseOriginal(Vector3 center, float xRadius, float yRadius, Vector2 point)
		{
			Vector2 vector = new Vector2(center.x, center.z);
			Vector2 vector2 = point - vector;
			float num = yRadius * yRadius - xRadius * xRadius;
			float num2 = xRadius * vector2.x / num;
			float num3 = num2 * num2;
			float num4 = yRadius * vector2.y / num;
			float num5 = num4 * num4;
			float num6 = (num3 + num5 - 1f) / 3f;
			float num7 = num6 * num6 * num6;
			float num8 = num7 + num5 * num3 * 2f;
			float num9 = num7 + num5 * num3;
			float num10 = num2 + num2 * num5;
			float num15;
			if (num9 < 0f)
			{
				float f = Mathf.Acos(num8 / num7) / 3f;
				float num11 = Mathf.Cos(f);
				float num12 = Mathf.Sin(f) * Mathf.Sqrt(3f);
				float num13 = Mathf.Sqrt((0f - num6) * (num11 + num12 + 2f) + num3);
				float num14 = Mathf.Sqrt((0f - num6) * (num11 - num12 + 2f) + num3);
				num15 = (num14 + ((num > 0f) ? num13 : (0f - num13)) + Mathf.Abs(num10) / (num13 * num14) - num2) / 2f;
			}
			else
			{
				float num16 = 2f * num2 * num4 * Mathf.Sqrt(num9);
				float num17 = Mathf.Pow(num8 + num16, 1f / 3f);
				float num18 = Mathf.Pow(num8 - num16, 1f / 3f);
				float num19 = 0f - num17 - num18 - num6 * 4f + 2f * num3;
				float num20 = (num17 - num18) * Mathf.Sqrt(3f);
				float num21 = Mathf.Sqrt(num19 * num19 + num20 * num20);
				num15 = (num20 / Mathf.Sqrt(num21 - num19) + 2f * num10 / num21 - num2) / 2f;
			}
			if (num15 > 1f)
			{
				num15 = 1f;
			}
			float num22 = Mathf.Sqrt(1f - num15 * num15);
			Debug.LogFormat("d: {0}, co: {1}, si: {2}", num9, num15, num22);
			return new Vector2(xRadius * num15, yRadius * num22) + vector;
		}

		public void Update()
		{
			if (_orbit == null)
			{
				UpdateEllipse();
			}
			UpdatePointerPoint();
			UpdateClosestPoint();
			_connectingLine.points3 = new List<Vector3>
			{
				_closestPoint.transform.position,
				_spherePoint.transform.position
			};
			_connectingLine.rectTransform.gameObject.transform.SetParent(base.transform);
			_connectingLine.rectTransform.gameObject.layer = base.gameObject.layer;
			_connectingLine.color = Color.cyan;
			_connectingLine.Draw3DAuto();
		}

		private void Awake()
		{
			MapOrbitLine component = GetComponent<MapOrbitLine>();
			if (component != null)
			{
				_orbit = component.OrbitInfo.OrbitNode.Orbit;
			}
			if (_orbit == null)
			{
				List<Vector3> points = new List<Vector3>(400);
				_ellipse = new VectorLine("Ellipse", points, 2f);
			}
			List<Vector3> points2 = new List<Vector3>(6);
			_connectingLine = new VectorLine("ConnectingLine", points2, 1f);
			_plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			_plane.transform.SetParent(base.transform);
			_plane.transform.localScale = Vector3.one * 1000f;
			_plane.GetComponent<MeshRenderer>().enabled = false;
			UnityEngine.Object.DestroyImmediate(_plane.GetComponent<Collider>());
			_plane.AddComponent<BoxCollider>();
			_plane.layer = base.gameObject.layer;
			_spherePoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			UnityEngine.Object.DestroyImmediate(_spherePoint.GetComponent<Collider>());
			_spherePoint.transform.SetParent(base.transform);
			_spherePoint.transform.localScale = Vector3.one * 4f;
			_spherePoint.layer = base.gameObject.layer;
			_spherePoint.GetComponent<MeshRenderer>().material.color = Color.blue;
			_closestPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			UnityEngine.Object.DestroyImmediate(_closestPoint.GetComponent<Collider>());
			_closestPoint.transform.SetParent(base.transform);
			_closestPoint.transform.localScale = Vector3.one * 4f;
			_closestPoint.layer = base.gameObject.layer;
			_closestPoint.GetComponent<MeshRenderer>().material.color = Color.green;
		}

		private Vector2 GetManeuverNodePointFromMouse(IOrbit orbit, Vector2 pointerPosition)
		{
			throw new NotImplementedException();
		}

		private void UpdateClosestPoint()
		{
			Vector2 vector = new Vector2(_spherePoint.transform.position.x, _spherePoint.transform.position.z);
			Vector2 vector2 = ((_orbit == null) ? ClosestPointToEllipse(base.transform.position, _xRadius, _yRadius, vector) : GetManeuverNodePointFromMouse(_orbit, vector));
			_closestPoint.transform.position = new Vector3(vector2.x, 0f, vector2.y);
		}

		private void UpdateEllipse()
		{
			_ellipse.MakeEllipse(base.transform.position, Vector3.up, _xRadius, _yRadius);
			_ellipse.rectTransform.gameObject.transform.SetParent(base.transform);
			_ellipse.rectTransform.gameObject.layer = base.gameObject.layer;
			_ellipse.Draw3DAuto();
		}

		private void UpdatePointerPoint()
		{
			if (Physics.Raycast(Utilities.ScreenPointToRay(MapViewScript.MapCamera, UnityEngine.Input.mousePosition), out var hitInfo))
			{
				_spherePoint.transform.position = hitInfo.point;
			}
		}
	}
}
