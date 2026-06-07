using System;
using System.Collections.Generic;
using External.Zalgo2462.VoronoiLib.Structures;
using PajamaLlama.Enums;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Math;
using PajamaLlama.Procedural;
using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public class VoronoiWorldRegion : IWorldRegion, IRegion
	{
		private class TileBorderEdge
		{
			private float _min;

			private float _max;

			public CardinalDirectionFlags Border { get; private set; }

			public TileBorderEdge(CardinalDirectionFlags border)
			{
				Border = border;
				_min = float.MaxValue;
				_max = float.MinValue;
			}

			public void AddEdge(Vector2 start, Vector2 end)
			{
				switch (Border)
				{
				case CardinalDirectionFlags.East:
				case CardinalDirectionFlags.West:
					_min = Mathf.Min(_min, start.y, end.y);
					_max = Mathf.Max(_max, start.y, end.y);
					break;
				case CardinalDirectionFlags.North:
				case CardinalDirectionFlags.South:
					_min = Mathf.Min(_min, start.x, end.x);
					_max = Mathf.Max(_max, start.x, end.x);
					break;
				default:
					Debug.LogException(new NotImplementedException());
					break;
				}
			}

			public bool Overlaps(TileBorderEdge other)
			{
				if (!ContainsValue(other._min) && !ContainsValue(other._max) && !other.ContainsValue(_min))
				{
					return other.ContainsValue(_max);
				}
				return true;
			}

			private bool ContainsValue(float value)
			{
				if (_min <= value)
				{
					return value <= _max;
				}
				return false;
			}
		}

		private readonly List<VoronoiSite> _sites = new List<VoronoiSite>();

		private Rect _worldBounds;

		private Vector2 _worldTileOffset;

		private readonly List<VoronoiWorldRegion> _neighbors = new List<VoronoiWorldRegion>();

		private readonly List<LandmarkSpawner> _landmarks = new List<LandmarkSpawner>(32);

		private readonly List<TileBorderEdge> _tileBorderEdges = new List<TileBorderEdge>();

		private readonly ScenarioTriggerableBase[] _enterTriggerables;

		public WorldTile WorldTile { get; private set; }

		public WorldRegionType Type { get; private set; }

		public PollutionLevels PollutionLevel { get; private set; }

		public QuestProperties QuestProperties { get; private set; }

		public QuestGiver QuestGiver { get; private set; }

		public IReadOnlyList<LandmarkSpawner> Landmarks => _landmarks;

		public Rect Bounds => _worldBounds;

		public WorldRegionBorderSegment[] Border { get; private set; }

		public CardinalDirectionFlags TileBorders { get; private set; }

		public IReadOnlyList<IWorldRegion> Neighbors => _neighbors;

		public LandmarkSpawner ScoutingLandmark { get; private set; }

		public IRegion DataRegion { get; private set; }

		public WorldRegionFlags Flags { get; private set; }

		public WorldRegionTypeFlags TypeFlags { get; private set; }

		public VoronoiWorldRegion(VoronoiRegion region, Rect voronoiBounds)
		{
			region.UpdateBorderEdges(sort: true);
			DataRegion = region;
			Type = region.Type;
			TypeFlags |= Type.ToWorldRegionTypeFlags();
			PollutionLevel = region.PollutionLevel;
			QuestProperties = region.QuestProperties;
			QuestGiver = region.QuestGiver;
			Border = new WorldRegionBorderSegment[region.BorderEdges.Count];
			for (int i = 0; i < region.BorderEdges.Count; i++)
			{
				WorldRegionBorderSegment worldRegionBorderSegment = new WorldRegionBorderSegment(region.BorderEdges[i], this, _sites, GameSettings.Instance.GameplaySettings.FogOfWarRegionMargin);
				Border[i] = worldRegionBorderSegment;
				AddTileBorderEdge(worldRegionBorderSegment.Start, worldRegionBorderSegment.End, voronoiBounds);
			}
			Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
			Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
			foreach (int siteIndex in region.SiteIndices)
			{
				VoronoiSite voronoiSite = Voronoi.Sites[siteIndex];
				_sites.Add(voronoiSite);
				vector = Vector2.Min(vector, voronoiSite.Polygon.Bounds.min);
				vector2 = Vector2.Max(vector2, voronoiSite.Polygon.Bounds.max);
			}
			_worldBounds = new Rect(vector, vector2 - vector);
			_enterTriggerables = region.EnterTriggerables;
		}

		public void SetWorldTile(WorldTile worldTile)
		{
			WorldTile = worldTile;
			_worldTileOffset = worldTile.Offset;
			_worldBounds.center += worldTile.Offset;
			if (worldTile.Antecede == null || !TryReturnTileBorderEdge(out var tileBorderEdge, CardinalDirectionFlags.West))
			{
				return;
			}
			foreach (VoronoiWorldRegion region in worldTile.Antecede.Regions)
			{
				if (region.TryReturnTileBorderEdge(out var tileBorderEdge2, CardinalDirectionFlags.East) && tileBorderEdge2.Overlaps(tileBorderEdge))
				{
					_neighbors.AddUnique(region);
					region._neighbors.AddUnique(this);
				}
			}
		}

		private void AddTileBorderEdge(Vector2 edgeStart, Vector2 edgeEnd, Rect tileBounds)
		{
			CardinalDirectionFlags cardinalDirectionFlags = ReturnTileBorder(edgeStart, edgeEnd, tileBounds);
			if (cardinalDirectionFlags != CardinalDirectionFlags.None)
			{
				TileBorders |= cardinalDirectionFlags;
				if (!TryReturnTileBorderEdge(out var tileBorderEdge, cardinalDirectionFlags))
				{
					tileBorderEdge = new TileBorderEdge(cardinalDirectionFlags);
					_tileBorderEdges.Add(tileBorderEdge);
				}
				tileBorderEdge.AddEdge(edgeStart, edgeEnd);
			}
		}

		public void PopulateDisabledLandmarkSpawners(List<LandmarkSpawner> disabledSpawners, ScoutingState maximumScoutingState)
		{
			foreach (LandmarkSpawner landmark in _landmarks)
			{
				if (!landmark.Enabled && landmark.ScoutingState <= maximumScoutingState)
				{
					disabledSpawners.Add(landmark);
				}
			}
		}

		public bool TryAddLandmarkSpawner(LandmarkSpawner landmarkSpawner)
		{
			if (ReturnContainsPosition3D(landmarkSpawner.WorldPosition))
			{
				landmarkSpawner.SetRegion(this);
				_landmarks.Add(landmarkSpawner);
				if (IsScoutingLandmark(landmarkSpawner))
				{
					ScoutingLandmark = landmarkSpawner;
				}
				return true;
			}
			return false;
		}

		public bool RemoveLandmarkSpawner(LandmarkSpawner landmarkSpawner)
		{
			if (_landmarks.Remove(landmarkSpawner))
			{
				WorldTile.RemoveLandmarkSpawner(landmarkSpawner);
				return true;
			}
			return false;
		}

		public void PopulateNeighbors(List<VoronoiWorldRegion> regions)
		{
			_neighbors.Clear();
			foreach (VoronoiWorldRegion region in regions)
			{
				if (region == this)
				{
					continue;
				}
				bool flag = false;
				WorldRegionBorderSegment[] border = Border;
				for (int i = 0; i < border.Length; i++)
				{
					if (border[i].SetNeighbor(region))
					{
						flag = true;
					}
				}
				if (flag)
				{
					_neighbors.AddUnique(region);
				}
			}
		}

		public void Enter()
		{
			MapEvent.DispatchRegionEntered(this);
			ScenarioTriggerableBase[] enterTriggerables = _enterTriggerables;
			for (int i = 0; i < enterTriggerables.Length; i++)
			{
				enterTriggerables[i]?.TryTrigger();
			}
			Flags |= WorldRegionFlags.Visited;
		}

		public void Scout(Agent agent, bool scoutNeighbors = true)
		{
			if (!IsScoutable())
			{
				return;
			}
			ScoutingEvent.DispatchScoutRegion(agent, this);
			SetScoutingState(agent);
			Flags |= WorldRegionFlags.Scouted;
			if (!scoutNeighbors)
			{
				return;
			}
			foreach (VoronoiWorldRegion neighbor in _neighbors)
			{
				neighbor.SetScoutingState(agent);
				neighbor.Flags |= WorldRegionFlags.Scouted;
			}
		}

		private void SetScoutingState(Agent agent, ScoutingState scoutingState = ScoutingState.Scouted)
		{
			if (!IsScoutable())
			{
				return;
			}
			WorldMapFogOfWar.ScoutRegion(this);
			foreach (LandmarkSpawner landmark in Landmarks)
			{
				landmark.SetScoutingState(scoutingState);
			}
			foreach (PointOfInterestSpawner item in WorldTile.PointsOfInterest)
			{
				if (ReturnContainsPosition3D(item.WorldPosition))
				{
					item.SetScoutingState(scoutingState);
				}
			}
			ScoutingEvent.DispatchRegionScouted(agent, this);
		}

		public bool StartQuest(AgentDescriptor interactor = null)
		{
			if (QuestProperties == null || StoryManager.TryGetQuest(QuestProperties, out var _))
			{
				return false;
			}
			StoryManager.StartQuest(QuestProperties, QuestGiver.GetActorDescriptor(interactor));
			return true;
		}

		private void PopulateScoutableScoutingLandmarks(List<LandmarkSpawner> scoutables, WorldTile worldTile, List<LandmarkSpawner> scoutedLandmarks)
		{
			foreach (VoronoiWorldRegion region in worldTile.Regions)
			{
				if (region.ScoutingLandmark != null && !scoutedLandmarks.Contains(region.ScoutingLandmark) && !(region.ScoutingLandmark.WorldPosition.x <= ScoutingLandmark.WorldPosition.x))
				{
					scoutables.Add(region.ScoutingLandmark);
				}
			}
		}

		private bool TryReturnClosestScoutableScoutingLandmarkIndex(List<LandmarkSpawner> scoutables, out int index)
		{
			float num = float.MaxValue;
			index = -1;
			for (int i = 0; i < scoutables.Count; i++)
			{
				LandmarkSpawner landmarkSpawner = scoutables[i];
				float num2 = ScoutingLandmark.WorldPosition.DistanceToSquared(landmarkSpawner.WorldPosition);
				if (num2 < num)
				{
					num = num2;
					index = i;
				}
			}
			return 0 <= index;
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
				listToPopulate = ListPool<LandmarkSpawner>.Get(1);
			}
			if (IsScoutingLandmark(ScoutingLandmark))
			{
				listToPopulate.Add(ScoutingLandmark);
			}
			return listToPopulate;
		}

		public bool IsFirstWithFlags(WorldRegionFlags flags)
		{
			if (0 < WorldTile.Index)
			{
				return false;
			}
			foreach (IWorldRegion region in WorldTile.Regions)
			{
				if (region != this && region.TryReturnScoutingLandmark(out var _) && region.Flags.IsFlagSet(flags))
				{
					return false;
				}
			}
			return true;
		}

		public void Restore(WorldRegionFlags flags)
		{
			Flags = flags;
		}

		public float ReturnSurface()
		{
			float num = 0f;
			foreach (VoronoiSite site in _sites)
			{
				num += site.ComputeSurface();
			}
			return num;
		}

		public float ReturnOverlap(Polygon2DBase polygon)
		{
			float num = 0f;
			foreach (VoronoiSite site in _sites)
			{
				if (site.Polygon.TryGetOverlap(polygon, out var overlap))
				{
					num += overlap;
				}
			}
			return num;
		}

		public bool ReturnContainsTilePosition(Vector2 tilePosition)
		{
			foreach (VoronoiSite site in _sites)
			{
				if (site.Polygon != null && site.Polygon.Bounds.Contains(tilePosition) && site.Polygon.ReturnPointIsOverlapping(tilePosition))
				{
					return true;
				}
			}
			return false;
		}

		public bool ReturnContainsPosition(Vector2 worldPosition)
		{
			return ReturnContainsTilePosition(worldPosition - _worldTileOffset);
		}

		public bool ReturnContainsPosition3D(Vector3 position)
		{
			return ReturnContainsPosition(position.Vector2TopDown());
		}

		public bool TryReturnDistanceToBorder(out float distance, Vector2 tilePosition, float margin = 0f)
		{
			Vector2 projection;
			foreach (VoronoiSite site in _sites)
			{
				if (site.Polygon.Bounds.Contains(tilePosition) && site.Polygon.ReturnPointIsOverlapping(tilePosition))
				{
					distance = ReturnDistanceToBorder(tilePosition, out projection) + margin;
					return true;
				}
			}
			distance = 0f - ReturnDistanceToBorder(tilePosition, out projection) + margin;
			return distance >= 0f;
		}

		private float ReturnDistanceToBorder(VoronoiSite site, Vector2 position, out Vector2 projection)
		{
			projection = Vector2.zero;
			if (Border == null)
			{
				return 0f;
			}
			float num = float.MaxValue;
			foreach (VEdge item in site.Cell)
			{
				if (TryReturnBorderSegment(out var borderSegment, item))
				{
					Vector2 vector = borderSegment.Line.ReturnProjection(position);
					float num2 = position.DistanceToSquared(vector);
					if (num2 < num)
					{
						projection = vector;
						num = num2;
					}
				}
			}
			return Mathf.Sqrt(num);
		}

		private float ReturnDistanceToBorder(Vector2 position, out Vector2 projection)
		{
			projection = Vector2.zero;
			if (Border.IsNullOrEmpty())
			{
				return 0f;
			}
			float num = float.MaxValue;
			WorldRegionBorderSegment[] border = Border;
			foreach (WorldRegionBorderSegment worldRegionBorderSegment in border)
			{
				if (worldRegionBorderSegment.MarginRect.Contains(position))
				{
					Vector2 vector = worldRegionBorderSegment.Line.ReturnProjection(position);
					float num2 = position.DistanceToSquared(vector);
					if (num2 < num)
					{
						projection = vector;
						num = num2;
					}
				}
			}
			return Mathf.Sqrt(num);
		}

		private static bool IsScoutingLandmark(LandmarkSpawner landmark)
		{
			if (landmark != null && landmark.LandmarkBehaviour is ActionsBehaviour actionsBehaviour)
			{
				return actionsBehaviour.ReturnHasAction<LandmarkActionRevealMap>();
			}
			return false;
		}

		public bool IsGeneratedFromDataRegion(IRegion region)
		{
			return DataRegion == region;
		}

		public bool HasUnscoutedDisabledLandmarks()
		{
			foreach (LandmarkSpawner landmark in Landmarks)
			{
				if (!landmark.Enabled && landmark.ScoutingState == ScoutingState.None)
				{
					return true;
				}
			}
			return false;
		}

		public Vector2 ReturnPositionInRegion()
		{
			return Bounds.center;
		}

		private CardinalDirectionFlags ReturnTileBorder(Vector2 edgeStart, Vector2 edgeEnd, Rect tileBounds)
		{
			if (Mathf.Approximately(edgeStart.y, tileBounds.yMax) && Mathf.Approximately(edgeEnd.y, tileBounds.yMax))
			{
				return CardinalDirectionFlags.North;
			}
			if (Mathf.Approximately(edgeStart.x, tileBounds.xMax) && Mathf.Approximately(edgeEnd.x, tileBounds.xMax))
			{
				return CardinalDirectionFlags.East;
			}
			if (Mathf.Approximately(edgeStart.y, tileBounds.yMin) && Mathf.Approximately(edgeEnd.y, tileBounds.yMin))
			{
				return CardinalDirectionFlags.South;
			}
			if (Mathf.Approximately(edgeStart.x, tileBounds.xMin) && Mathf.Approximately(edgeEnd.x, tileBounds.xMin))
			{
				return CardinalDirectionFlags.West;
			}
			return CardinalDirectionFlags.None;
		}

		private bool TryReturnTileBorderEdge(out TileBorderEdge tileBorderEdge, CardinalDirectionFlags border)
		{
			int count = _tileBorderEdges.Count;
			while (0 < count--)
			{
				tileBorderEdge = _tileBorderEdges[count];
				if (tileBorderEdge.Border == border)
				{
					return true;
				}
			}
			tileBorderEdge = null;
			return false;
		}

		private bool TryReturnBorderSegment(out WorldRegionBorderSegment borderSegment, VEdge edge)
		{
			int num = Border.Length;
			while (0 < num--)
			{
				borderSegment = Border[num];
				if (borderSegment.Edge == edge)
				{
					return true;
				}
			}
			borderSegment = null;
			return false;
		}

		private bool IsScoutable()
		{
			if (Type == WorldRegionType.Shallow && (TileBorders & (CardinalDirectionFlags)5) != CardinalDirectionFlags.None)
			{
				return false;
			}
			return true;
		}
	}
}
