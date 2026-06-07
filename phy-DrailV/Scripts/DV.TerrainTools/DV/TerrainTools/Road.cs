using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.TerrainTools
{
	public class Road : MonoBehaviour
	{
		private const string CONTROL_POINTS_GAMEOBJECT_NAME = "control points";

		private const string AUX_POINTS_GAMEOBJECT_NAME = "aux points";

		private Transform _controlPointsTransform;

		private Transform _auxPointsTransform;

		public int NumPoints => ControlPointsTransform.childCount;

		public ControlPoint First
		{
			get
			{
				if (NumPoints != 0)
				{
					return GetControlPoint(0);
				}
				return null;
			}
		}

		public ControlPoint Last
		{
			get
			{
				if (NumPoints != 0)
				{
					return GetControlPoint(-1);
				}
				return null;
			}
		}

		public int NumAuxPoints => AuxPointsTransform.childCount;

		internal Transform ControlPointsTransform
		{
			get
			{
				if (_controlPointsTransform == null)
				{
					_controlPointsTransform = base.transform.Find("control points");
				}
				if (_controlPointsTransform == null)
				{
					GameObject gameObject = new GameObject("control points");
					gameObject.transform.SetParent(base.transform, worldPositionStays: false);
					_controlPointsTransform = gameObject.transform;
				}
				return _controlPointsTransform;
			}
		}

		internal Transform AuxPointsTransform
		{
			get
			{
				if (_auxPointsTransform == null)
				{
					_auxPointsTransform = base.transform.Find("aux points");
				}
				if (_auxPointsTransform == null)
				{
					GameObject gameObject = new GameObject("aux points");
					gameObject.transform.SetParent(base.transform, worldPositionStays: false);
					_auxPointsTransform = gameObject.transform;
				}
				return _auxPointsTransform;
			}
		}

		public ControlPoint AddControlPoint(Vector3 pos, Quaternion rot, int index)
		{
			GameObject obj = new GameObject($"point {NumPoints + 1}");
			ControlPoint controlPoint = obj.AddComponent<ControlPoint>();
			if (NumPoints != 0)
			{
				controlPoint.CopyDataFrom(GetControlPoint(index - 1));
			}
			obj.transform.SetParent(ControlPointsTransform);
			obj.transform.position = pos;
			obj.transform.rotation = rot;
			obj.transform.SetSiblingIndex(index);
			return controlPoint;
		}

		public AuxPoint AddAuxPoint(Vector3 pos, Quaternion rot, int index)
		{
			GameObject obj = new GameObject($"aux point {NumPoints + 1}");
			AuxPoint result = obj.AddComponent<AuxPoint>();
			obj.transform.SetParent(AuxPointsTransform);
			obj.transform.position = pos;
			obj.transform.rotation = rot;
			obj.transform.SetSiblingIndex(index);
			return result;
		}

		public ControlPoint GetControlPoint(int index)
		{
			if (index < 0)
			{
				index = ControlPointsTransform.childCount + index;
			}
			Transform child = ControlPointsTransform.GetChild(index);
			ControlPoint controlPoint = child.GetComponent<ControlPoint>();
			if (!controlPoint)
			{
				controlPoint = child.gameObject.AddComponent<ControlPoint>();
			}
			return controlPoint;
		}

		public List<ControlPoint> GetControlPoints()
		{
			List<ControlPoint> list = new List<ControlPoint>();
			for (int i = 0; i < NumPoints; i++)
			{
				list.Add(GetControlPoint(i));
			}
			return list;
		}

		public AuxPoint GetAuxPoint(int index)
		{
			if (index < 0)
			{
				index = AuxPointsTransform.childCount + index;
			}
			Transform child = AuxPointsTransform.GetChild(index);
			AuxPoint auxPoint = child.GetComponent<AuxPoint>();
			if (!auxPoint)
			{
				auxPoint = child.gameObject.AddComponent<AuxPoint>();
			}
			return auxPoint;
		}

		public List<AuxPoint> GetAuxPoints()
		{
			List<AuxPoint> list = new List<AuxPoint>();
			for (int i = 0; i < NumAuxPoints; i++)
			{
				list.Add(GetAuxPoint(i));
			}
			return list;
		}

		public int GetControlPointIndex(ControlPoint point)
		{
			if (!point.transform.IsChildOf(ControlPointsTransform))
			{
				throw new InvalidProgramException("Given point doesn't belong to this road");
			}
			return point.transform.GetSiblingIndex();
		}

		public int GetAuxPointIndex(AuxPoint point)
		{
			if (!point.transform.IsChildOf(AuxPointsTransform))
			{
				throw new InvalidProgramException("Given point doesn't belong to this road");
			}
			return point.transform.GetSiblingIndex();
		}

		public bool IsEnd(ControlPoint point)
		{
			int controlPointIndex = GetControlPointIndex(point);
			if (controlPointIndex != 0)
			{
				return controlPointIndex == NumPoints - 1;
			}
			return true;
		}

		public RoadProximityData Query(Vector3 queryPoint)
		{
			return (from prox in GetControlPoints().Pairwise(delegate(ControlPoint p1, ControlPoint p2)
				{
					float num = VectorUtils.DistancePointLine(queryPoint, p1.position, p2.position);
					float num2 = Vector3.Distance(p1.position, queryPoint);
					float num3 = Vector3.Distance(p2.position, queryPoint);
					ControlPoint closest = ((num2 < num3) ? p1 : p2);
					ControlPoint secondClosest = ((num2 < num3) ? p2 : p1);
					int num4 = 1;
					bool isPastEnd = false;
					if (num == num2)
					{
						num4--;
						isPastEnd = true;
					}
					else if (num == num3)
					{
						num4++;
						isPastEnd = true;
					}
					return new RoadProximityData(queryPoint, closest, secondClosest, num, isPastEnd, num4);
				}).Select(delegate(RoadProximityData prox, int i)
				{
					prox.insertIndex += i;
					return prox;
				})
				orderby prox.distToLine
				select prox).FirstOrDefault();
		}

		public Vector3 GetTangent(Point point)
		{
			return point.transform.forward;
		}
	}
}
