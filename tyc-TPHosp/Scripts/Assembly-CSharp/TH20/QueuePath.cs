using System;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	[DontSave]
	public class QueuePath
	{
		private struct QueuePoint
		{
			public Vector3 Position;

			public float Rotation;
		}

		private class IterateTilesSpiralParams : RoomAlgorithms.FreeTileDelegateParams
		{
			public HospitalMap HospitalMap;

			public FloorPlan HospitalFloorPlan;

			public HospitalAttributeMap HospitalAttributeMap;

			public Vector3 QueuePosition;

			public float Attractiveness;

			public override void Clear()
			{
				HospitalMap = null;
				HospitalFloorPlan = null;
				HospitalAttributeMap = null;
			}
		}

		private static IterateTilesSpiralParams _iterateTilesSpiralParams = new IterateTilesSpiralParams();

		private const int kMaxPoints = 32;

		private FloorPlan _floorPlan;

		private readonly QueuePoint[] _points;

		public FloorPlan FloorPlan
		{
			get
			{
				return _floorPlan;
			}
			set
			{
				_floorPlan = value;
			}
		}

		public QueuePath()
		{
			_points = new QueuePoint[32];
			for (int i = 0; i < 32; i++)
			{
				_points[i] = default(QueuePoint);
			}
		}

		public void CalculateQueue()
		{
			RoomItem door = _floorPlan.Door;
			if (door != null)
			{
				float rotation = door.Rotation;
				Vector3 startPosition = door.WorldPosition + MathUtils.MakeDirectionVector(rotation) * 2f;
				rotation -= 90f;
				startPosition += MathUtils.MakeDirectionVector(rotation) * 0.5f;
				Calculate(_floorPlan.WorldState, startPosition, rotation);
			}
		}

		private void Calculate(WorldState worldState, Vector3 startPosition, float startRotation)
		{
			Vector3 vector = startPosition;
			float num = startRotation;
			HospitalMap hospitalMapAtWorldPosition = worldState.GetHospitalMapAtWorldPosition(vector);
			if (hospitalMapAtWorldPosition == null)
			{
				return;
			}
			FloorPlan floorPlan = hospitalMapAtWorldPosition.FloorPlan;
			System.Random random = new System.Random(vector.GetHashCode());
			_iterateTilesSpiralParams.HospitalMap = hospitalMapAtWorldPosition;
			_iterateTilesSpiralParams.HospitalFloorPlan = floorPlan;
			_iterateTilesSpiralParams.HospitalAttributeMap = worldState.HospitalAttributeMaps[1];
			for (int i = 0; i < 32; i++)
			{
				bool flag = false;
				int num2 = 0;
				while (!flag && num2 < 4)
				{
					Vector3 vector2 = MathUtils.MakeDirectionVector(num);
					if (ValidPosition(floorPlan, vector, vector2))
					{
						vector += vector2;
						flag = true;
					}
					if (!flag)
					{
						num += num2 switch
						{
							3 => 270f, 
							1 => -180f, 
							0 => 90f, 
							_ => 0f, 
						};
					}
					num2++;
				}
				_iterateTilesSpiralParams.Attractiveness = _iterateTilesSpiralParams.HospitalAttributeMap.GetMapAttribute(vector);
				_iterateTilesSpiralParams.QueuePosition = vector;
				if (_iterateTilesSpiralParams.Attractiveness >= GameAlgorithms.Config.QueueUnattractiveThreshold)
				{
					_iterateTilesSpiralParams.QueuePosition += MathUtils.MakeDirectionVector(num + 90f) * 0.2f;
				}
				else
				{
					RoomAlgorithms.IterateTilesSpiral(floorPlan, vector, _iterateTilesSpiralParams, delegate(int xp, int yp, RoomAlgorithms.FreeTileDelegateParams inParam)
					{
						IterateTilesSpiralParams iterateTilesSpiralParams = (IterateTilesSpiralParams)inParam;
						if (iterateTilesSpiralParams.HospitalFloorPlan[xp, yp])
						{
							Vector3 vector3 = (iterateTilesSpiralParams.HospitalFloorPlan.Anchor + new GridCoord(xp, yp)).ToWorldPosition();
							if (iterateTilesSpiralParams.HospitalAttributeMap.GetMapAttribute(vector3) > iterateTilesSpiralParams.Attractiveness && iterateTilesSpiralParams.HospitalMap.PositionConnectsToEntrance(vector3.ToGridCoord()))
							{
								iterateTilesSpiralParams.QueuePosition = vector3;
								return true;
							}
						}
						return false;
					});
					_iterateTilesSpiralParams.QueuePosition += RandomUtils.RandomXZVector(-0.5f, 0.5f, random);
				}
				_points[i].Position = _iterateTilesSpiralParams.QueuePosition;
				_points[i].Rotation = num + 180f;
			}
			_iterateTilesSpiralParams.Clear();
		}

		private bool ValidPosition(FloorPlan floorPlan, Vector3 position, Vector3 moveVector)
		{
			Vector3 vector = position + moveVector;
			if (RoomAlgorithms.RoomContainsWorldCoord(floorPlan, vector.ToGridCoord()))
			{
				if (!UnityEngine.AI.NavMesh.Raycast(position, vector, out var _, -1))
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public bool GetPoint(int queuePosition, out Vector3 position, out float rotation)
		{
			if (queuePosition < 32)
			{
				position = _points[queuePosition].Position;
				rotation = _points[queuePosition].Rotation;
				return true;
			}
			position = Vector3.zero;
			rotation = 0f;
			return false;
		}

		public void DebugDraw()
		{
			Vector3 vector = Vector3.up * 0.25f;
			for (int i = 0; i < 31; i++)
			{
				QueuePoint queuePoint = _points[i];
				QueuePoint queuePoint2 = _points[i + 1];
				DebugDrawUtils.Line(queuePoint.Position + vector, queuePoint2.Position + vector, ((i & 1) == 0) ? Color.yellow : Color.magenta, 1f);
			}
		}
	}
}
