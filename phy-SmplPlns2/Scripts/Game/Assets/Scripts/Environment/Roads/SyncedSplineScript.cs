using System.Collections.Generic;
using System.Linq;
using EasyRoads3Dv3;
using JBooth.MicroVerseCore;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace Assets.Scripts.Environment.Roads
{
	[ExecuteInEditMode]
	public class SyncedSplineScript : MonoBehaviour
	{
		[SerializeField]
		private bool _isTrack;

		[SerializeField]
		private Transform _road;

		public Transform Road
		{
			get
			{
				return _road;
			}
			set
			{
				_road = value;
			}
		}

		public bool Track
		{
			get
			{
				return _isTrack;
			}
			set
			{
				_isTrack = value;
			}
		}

		public void DestroySpline()
		{
			Object.DestroyImmediate(base.gameObject);
			MicroVerse.instance.Invalidate();
		}

		public void Sync(Vector3 offset)
		{
			GameObject gameObject = _road.gameObject;
			base.gameObject.name = "Spline " + gameObject.name;
			JBooth.MicroVerseCore.SplinePath component = GetComponent<JBooth.MicroVerseCore.SplinePath>();
			ERModularRoad component2 = _road.GetComponent<ERModularRoad>();
			float roadWidth = component2.roadWidth;
			float num = component2.surrounding - 2f;
			component.smoothness = (component.width = num * roadWidth);
			Spline spline = component.spline.Spline;
			spline.Clear();
			int count = component2.roadShape.Count;
			count += component2.hardEdge.Count((bool h) => h);
			List<Vector3> meshVecs = component2.meshVecs;
			int count2 = component2.meshVecs.Count;
			if (_isTrack)
			{
				component.modifySplatMap = false;
				float num2 = float.MinValue;
				for (int num3 = 0; num3 < count; num3++)
				{
					if (meshVecs[num3].y > num2)
					{
						num2 = meshVecs[num3].y;
					}
				}
				float num4 = Mathf.Max(0f, num2 - meshVecs[0].y - 0.1f);
				List<float3> list = new List<float3>(count2 / count);
				for (int num5 = 0; num5 < count2; num5 += count)
				{
					Vector3 vector = offset;
					vector.y += Mathf.Max(0f, num4 - 0.5f * Mathf.Abs(meshVecs[num5].y - meshVecs[num5 + count - 1].y));
					Vector3 vector2 = 2f * (meshVecs[num5] - meshVecs[num5 + count - 1]).normalized;
					spline.Add(new BezierKnot(meshVecs[num5] + vector + vector2));
					list.Add(meshVecs[num5 + count - 1] + vector - vector2);
				}
				list.Reverse();
				spline.AddRange(list);
			}
			else
			{
				component.splatWidth = 0.1f * roadWidth;
				component.splatSmoothness = 0.7f * component.smoothness;
				Vector3 vector5 = default(Vector3);
				for (int num6 = 0; num6 < count2; num6 += count)
				{
					int index = num6 + count - 1;
					Vector3 vector3 = meshVecs[num6];
					Vector3 vector4 = meshVecs[index];
					vector5.x = (vector3.x + vector4.x) * 0.5f;
					vector5.z = (vector3.z + vector4.z) * 0.5f;
					vector5.y = ((vector3.y < vector4.y) ? vector3.y : vector4.y);
					vector5 += offset;
					spline.Add(new BezierKnot(vector5));
				}
			}
			spline.SetTangentMode(TangentMode.Linear);
		}
	}
}
