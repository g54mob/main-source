using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public class HandMadeWorldRegion : IWorldRegion, IRegion
	{
		private readonly List<IWorldRegion> _neighbors = new List<IWorldRegion>();

		private List<LandmarkSpawner> _landmarks;

		public WorldTile WorldTile { get; private set; }

		public WorldRegionType Type { get; private set; }

		public PollutionLevels PollutionLevel => PollutionLevels.None;

		public Dictionary<Vector2, int> Vertices { get; private set; }

		public Polygon Polygon { get; private set; }

		public IReadOnlyList<LandmarkSpawner> Landmarks => _landmarks;

		public Rect Bounds => Polygon.Bounds;

		public Rect WorldTileBounds => Polygon.Bounds;

		public WorldRegionBorderSegment[] Border
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public IRegion DataRegion => null;

		public WorldRegionFlags Flags { get; private set; }

		public WorldRegionTypeFlags TypeFlags => WorldRegionTypeFlags.None;

		public IReadOnlyList<IWorldRegion> Neighbors => _neighbors;

		internal HandMadeWorldRegion(HandmadeTileGenerator.Region region)
		{
			Type = region.Type;
			Polygon = new Polygon(region.Polygon);
		}

		public void SetWorldTile(WorldTile worldTile)
		{
			WorldTile = worldTile;
			throw new NotImplementedException();
		}

		public void PopulateDisabledLandmarkSpawners(List<LandmarkSpawner> disabledSpawners, ScoutingState maximumScoutingState)
		{
			throw new NotImplementedException();
		}

		public bool TryAddLandmarkSpawner(LandmarkSpawner landmarkSpawner)
		{
			if (ReturnContainsPosition3D(landmarkSpawner.WorldPosition))
			{
				if (_landmarks == null)
				{
					_landmarks = new List<LandmarkSpawner>(32);
				}
				landmarkSpawner.SetRegion(this);
				_landmarks.Add(landmarkSpawner);
				return true;
			}
			return false;
		}

		public bool RemoveLandmarkSpawner(LandmarkSpawner landmarkSpawner)
		{
			if (_landmarks != null)
			{
				return _landmarks.Remove(landmarkSpawner);
			}
			return false;
		}

		public void Enter()
		{
			MapEvent.DispatchRegionEntered(this);
			Flags |= WorldRegionFlags.Visited;
		}

		public void Scout(Agent agent, bool scoutNeighbors = true)
		{
			WorldMapFogOfWar.ScoutRegion(this);
			RevealLandmarksWithAction<LandmarkActionRevealMap>();
			Flags |= WorldRegionFlags.Scouted;
		}

		public bool StartQuest(AgentDescriptor interactor = null)
		{
			return false;
		}

		private void RevealLandmarksWithAction<T>() where T : LandmarkAction
		{
			using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
			GameManager.WorldManager.World.ReturnAllLandmarks(list);
			foreach (LandmarkSpawner item in list)
			{
				if (item.ScoutingState != ScoutingState.Scouted && !item.LandmarkBehaviour.ReturnIsCompleted())
				{
					ActionsBehaviour actionsBehaviour = item.LandmarkBehaviour as ActionsBehaviour;
					if (!(actionsBehaviour == null) && actionsBehaviour.ReturnHasAction<T>())
					{
						item.SetScoutingState(ScoutingState.Rumored);
					}
				}
			}
		}

		public void Restore(WorldRegionFlags flags)
		{
			Flags = flags;
		}

		public float ReturnSurface()
		{
			return 0f;
		}

		public float ReturnOverlap(Polygon2DBase polygon)
		{
			if (!Polygon.TryGetOverlap(polygon, out var overlap))
			{
				return 0f;
			}
			return overlap;
		}

		public bool ReturnContainsPosition(Vector2 position)
		{
			return Polygon.ReturnPointIsOverlapping(position);
		}

		public bool ReturnContainsPosition3D(Vector3 position)
		{
			return ReturnContainsPosition(position.Vector2TopDown());
		}

		public bool ReturnIsBorderVertex(Vector2 vertex)
		{
			Dictionary<Vector2, int>.Enumerator enumerator = Vertices.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Key.Approximately(vertex, 1f))
				{
					return true;
				}
			}
			return false;
		}

		public bool TryReturnDistanceToBorder(out float distanceToBorder, Vector2 point, float margin)
		{
			if (ReturnContainsPosition(point))
			{
				distanceToBorder = Polygon.ReturnPointDistanceToBorder(point, out var _);
				return true;
			}
			distanceToBorder = float.MaxValue;
			return false;
		}

		public bool TryReturnScoutingLandmark(out LandmarkSpawner scoutingLandmark)
		{
			for (int i = 0; i < _landmarks.Count; i++)
			{
				scoutingLandmark = _landmarks[i];
				if (scoutingLandmark != null && scoutingLandmark.LandmarkBehaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.ReturnHasAction<LandmarkActionRevealMap>())
				{
					return true;
				}
			}
			scoutingLandmark = null;
			return false;
		}

		public IReadOnlyList<LandmarkSpawner> GetScoutingLandmarks(List<LandmarkSpawner> listToPopulate = null)
		{
			if (listToPopulate == null)
			{
				listToPopulate = new List<LandmarkSpawner>();
			}
			foreach (LandmarkSpawner landmark in _landmarks)
			{
				if (landmark != null && landmark.ScoutingState != ScoutingState.Scouted && !landmark.LandmarkBehaviour.ReturnIsCompleted() && landmark.LandmarkBehaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.ReturnHasAction<LandmarkActionRevealMap>())
				{
					listToPopulate.Add(landmark);
				}
			}
			return listToPopulate;
		}

		public bool IsFirstWithFlags(WorldRegionFlags flags)
		{
			Debug.LogException(new NotImplementedException());
			return false;
		}

		public bool IsScouted()
		{
			if (_landmarks.Count == 0)
			{
				return false;
			}
			foreach (LandmarkSpawner landmark in _landmarks)
			{
				if (landmark != null && landmark.LandmarkBehaviour is ActionsBehaviour { RequiresScouting: not false } actionsBehaviour && actionsBehaviour.Actions.Find((LandmarkAction action) => action.IsCompleted && (action is LandmarkActionScout || action is LandmarkActionRevealMap)) != null)
				{
					return false;
				}
			}
			return true;
		}

		public bool IsGeneratedFromDataRegion(IRegion region)
		{
			return false;
		}

		public bool HasUnscoutedDisabledLandmarks()
		{
			return false;
		}

		public Vector2 ReturnPositionInRegion()
		{
			return default(Vector2);
		}
	}
}
