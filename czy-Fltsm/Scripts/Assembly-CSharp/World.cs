using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;

public class World : IPersistentReference
{
	private IWorldTileProvider _tileProvider;

	private WorldTile _nextTile;

	public List<WorldTile> Tiles { get; } = new List<WorldTile>();

	public Vector3 TownheartWorldPosition { get; private set; } = Vector3.zero;

	public Vector2 TownheartMapPosition { get; private set; } = Vector2.zero;

	public float TownheartMaxX { get; private set; }

	public Quaternion TownheartRotation { get; private set; } = Quaternion.identity;

	public TileProperties TileProperties { get; private set; }

	public int SalvagedItemCount { get; private set; }

	public float FirstTileOffsetX { get; private set; }

	public bool HasEndTile { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public World(TileProperties tileProperties, int salvagedItemCount = 0, float firstTileOffsetX = 0f)
	{
		Initialize(tileProperties, Vector3.zero, Quaternion.identity);
		SalvagedItemCount = salvagedItemCount;
		FirstTileOffsetX = firstTileOffsetX;
	}

	public WorldTile Spawn()
	{
		WorldTile worldTile = new WorldTile(TileProperties.TileGenerator, TileProperties.ReturnStartSubTileGenerator(), startingTile: true);
		worldTile.Initialize(synchronous: true);
		Tiles.Clear();
		Tiles.Add(worldTile);
		RepositionTownheart(worldTile.StartPosition, TownheartRotation);
		return worldTile;
	}

	public void RestoreTile(WorldTile tile)
	{
		if (0 < Tiles.Count)
		{
			List<WorldTile> tiles = Tiles;
			tile.SetAntecede(tiles[tiles.Count - 1]);
		}
		if (tile.IsEndTile)
		{
			HasEndTile = true;
		}
		Tiles.Add(tile);
	}

	public void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMove, OnTownheartMove);
	}

	public bool UpdateTileProperties(TileProperties tileProperties)
	{
		if (tileProperties == TileProperties)
		{
			return false;
		}
		foreach (WorldTile tile in Tiles)
		{
			tile.Dispose();
		}
		Initialize(tileProperties, Vector3.zero, Quaternion.identity);
		Spawn().Activate();
		return true;
	}

	public void UpdateTiles(Vector2 townheartMapPosition)
	{
		if (!HasEndTile)
		{
			TownheartMapPosition = townheartMapPosition;
			if (_nextTile == null && TryGetNextWorldTile(out var nextWorldtile, townheartMapPosition))
			{
				AddNextTile(nextWorldtile);
			}
		}
	}

	public bool RepositionTownheart(Vector3 toPosition, Quaternion toRotation, float distance = 0f)
	{
		if (IsPositionInWorldBounds(toPosition))
		{
			Vector3 townheartWorldPosition = TownheartWorldPosition;
			Quaternion townheartRotation = TownheartRotation;
			TownheartWorldPosition = toPosition;
			TownheartRotation = toRotation;
			if (TownheartMaxX < TownheartWorldPosition.x)
			{
				TownheartMaxX = TownheartWorldPosition.x;
			}
			foreach (WorldTile tile in Tiles)
			{
				tile.RepositionTownheart(toPosition, toRotation);
			}
			PruneWorldTiles();
			MovementEvent.DispatchTownheartMoved(townheartWorldPosition, toPosition, townheartRotation, toRotation, distance);
			return true;
		}
		Debug.LogException(new Exception($"Unable to move townheart to position {toPosition}. It is outside the world bounds."));
		return false;
	}

	public void PruneWorldTiles()
	{
		if (TileProperties.PreferredActiveTileCount < Tiles.Count)
		{
			WorldTile worldTile = Tiles[0];
			WorldTile worldTile2 = Tiles[1];
			if (!worldTile.WorldBounds.Contains(TownheartMapPosition) && !worldTile2.WorldBounds.Contains(TownheartMapPosition) && WorldManager.CanPruneWorldTile(worldTile))
			{
				worldTile.Dispose();
				Tiles.RemoveAt(0);
				MapEvent.DispatchWorldTileRemovedEvent(worldTile);
			}
		}
	}

	public void AddFlotsam(Flotsam flotsam)
	{
	}

	public void OnItemSalvaged(Item item)
	{
		SalvagedItemCount++;
	}

	private void Initialize(TileProperties tileProperties, Vector3 townheartPosition, Quaternion townheartRotation, bool resetTownheartMaxX = false)
	{
		TileProperties = tileProperties;
		TownheartWorldPosition = townheartPosition;
		TownheartRotation = townheartRotation;
		if (TownheartMaxX < townheartPosition.x || resetTownheartMaxX)
		{
			TownheartMaxX = townheartPosition.x;
		}
		GameEventDispatcher.AddListener(GameEventType.TownheartMove, OnTownheartMove);
	}

	private void OnTownheartMove(GameEvent gameEvent)
	{
		if (gameEvent is MovementEvent movementEvent)
		{
			RepositionTownheart(movementEvent.PositionTo, movementEvent.RotationTo, movementEvent.Distance);
		}
	}

	public void SetWorldTileProvider(IWorldTileProvider tileProvider)
	{
		_tileProvider = tileProvider;
	}

	public void ClearWorldTileProvider()
	{
		_tileProvider = null;
	}

	public bool TryGetNextWorldTile(out WorldTile nextWorldtile, Vector2 townheartPosition)
	{
		nextWorldtile = null;
		if (CanAddNextTile())
		{
			if (!Tiles.IsNullOrEmpty())
			{
				List<WorldTile> tiles = Tiles;
				if (!(tiles[tiles.Count - 1].WorldBounds.xMax - townheartPosition.x < WorldMapManager.ReturnTileSpawningRange(1500f)))
				{
					goto IL_0054;
				}
			}
			nextWorldtile = GetNextWorldTile();
		}
		goto IL_0054;
		IL_0054:
		return nextWorldtile != null;
	}

	public WorldTile GetNextWorldTile(ILandmarkPicker landmarkPicker = null)
	{
		WorldTile worldTile = null;
		if (_tileProvider != null)
		{
			worldTile = _tileProvider.GetNextWorldTile(this, landmarkPicker);
			if (worldTile != null)
			{
				return worldTile;
			}
		}
		return TileProperties.FallbackWorldTileProvider.GetNextWorldTile(this, landmarkPicker);
	}

	private bool TryForceNextTile(ILandmarkPicker landmarkPicker)
	{
		if (!CanAddNextTile())
		{
			return false;
		}
		if (landmarkPicker == null)
		{
			Debug.LogException(new ArgumentException("Landmark picker is NULL!"));
			return false;
		}
		WorldTile tile = null;
		if (!landmarkPicker.TryGetNextWorldTile(out tile, this))
		{
			tile = GetNextWorldTile(landmarkPicker);
		}
		if (tile == null)
		{
			Debug.LogException(new Exception("Unable to force new WorldTile!"));
			return false;
		}
		AddNextTile(tile, synchronous: true);
		return true;
	}

	public void AddNextTile(WorldTile nextTile, bool synchronous = false)
	{
		if (nextTile == null)
		{
			Debug.LogException(new ArgumentException("Trying to add NULL as next world tile."));
		}
		else if (CanAddNextTile())
		{
			_nextTile = nextTile;
			_nextTile.OnInitialized.AddListener(OnWorldTileInitialized);
			_nextTile.Initialize(synchronous);
		}
	}

	private void OnWorldTileInitialized(WorldTile worldTile)
	{
		worldTile.OnInitialized.RemoveListener(OnWorldTileInitialized);
		object antecede;
		if (!Tiles.IsNullOrEmpty())
		{
			List<WorldTile> tiles = Tiles;
			antecede = tiles[tiles.Count - 1];
		}
		else
		{
			antecede = null;
		}
		worldTile.SetAntecede((WorldTile)antecede);
		Tiles.Add(worldTile);
		if (worldTile.IsEndTile)
		{
			HasEndTile = true;
		}
		MapEvent.DispatchWorldTiledAddedEvent(worldTile);
		FinalUpdate.RegisterOneShot(PruneWorldTiles);
		_nextTile = null;
	}

	public bool TrySetScoutingStateInRegion(out IWorldRegion region, Vector3 position, ScoutingState scoutingState, Agent agent = null)
	{
		Vector2 worldPosition = position.Vector2TopDown();
		foreach (WorldTile tile in Tiles)
		{
			if (!tile.TryReturnRegionContainingPosition(out region, worldPosition))
			{
				continue;
			}
			foreach (LandmarkSpawner landmark in tile.Landmarks)
			{
				if (region.ReturnContainsPosition3D(landmark.WorldPosition))
				{
					landmark.SetScoutingState(scoutingState);
				}
			}
			foreach (PointOfInterestSpawner item in tile.PointsOfInterest)
			{
				if (region.ReturnContainsPosition3D(item.WorldPosition))
				{
					item.SetScoutingState(scoutingState);
				}
			}
			ScoutingEvent.DispatchRegionScouted(agent, region);
			return true;
		}
		region = null;
		return false;
	}

	public bool SpawnDrifter(ILandmarkPicker landmarkPicker, ActorDescriptor drifterDescriptor, QuestProperties questToAssign = null, ILandmarkBehaviourProvider landmarkBehaviourProvider = null)
	{
		switch (TileProperties.GameMode)
		{
		case GameMode.Classic:
			return SpawnDrifterClassic(landmarkPicker, drifterDescriptor, questToAssign);
		case GameMode.Narrative:
			return SpawnDrifterNarrative(landmarkPicker, drifterDescriptor, questToAssign, landmarkBehaviourProvider);
		default:
			Debug.LogException(new NotImplementedException());
			return false;
		}
	}

	private bool SpawnDrifterClassic(ILandmarkPicker landmarkPicker, ActorDescriptor actorDescriptor, QuestProperties questToAssign)
	{
		if (TryReturnLandmarkActionRescue(out var rescueAction, landmarkPicker))
		{
			rescueAction.AddDescriptor(actorDescriptor);
			if (questToAssign != null)
			{
				rescueAction.AssignDrifterQuest(questToAssign);
			}
			return true;
		}
		return false;
	}

	private bool SpawnDrifterNarrative(ILandmarkPicker landmarkPicker, ActorDescriptor actorDescriptor, QuestProperties questToAssign = null, ILandmarkBehaviourProvider landmarkBehaviourProvider = null)
	{
		if (TryReturnDisabledLandmarkSpawner(landmarkPicker))
		{
			LandmarkSpawner bestPick = landmarkPicker.BestPick;
			ILandmarkBehaviourProvider landmarkBehaviourProvider3;
			if (landmarkBehaviourProvider == null)
			{
				ILandmarkBehaviourProvider landmarkBehaviourProvider2 = TileProperties.ReturnLandmarkBehaviour(landmarkPicker.BestPick.Region);
				landmarkBehaviourProvider3 = landmarkBehaviourProvider2;
			}
			else
			{
				landmarkBehaviourProvider3 = landmarkBehaviourProvider;
			}
			if (bestPick.SetActorDescriptor(actorDescriptor, questToAssign, landmarkBehaviourProvider3))
			{
				LandmarkNotificationEvent.Spawned(landmarkPicker.BestPick);
				return true;
			}
		}
		return false;
	}

	public bool SpawnLandmark(ILandmarkPicker landmarkPicker, ILandmarkBehaviourProvider landmarkBehaviourProvider)
	{
		if (TileProperties.GameMode != GameMode.Narrative)
		{
			Debug.LogException(new NotImplementedException());
		}
		else if (TryReturnDisabledLandmarkSpawner(landmarkPicker))
		{
			landmarkPicker.BestPick.SetLandmarkBehaviour(landmarkBehaviourProvider.ReturnLandmarkBehaviour(landmarkPicker.BestPick.Region.Type), null);
			LandmarkNotificationEvent.Spawned(landmarkPicker.BestPick);
			return true;
		}
		return false;
	}

	public bool TrySpawnPointOfInterest(out PointOfInterestSpawner spawner, PointOfInterestProperties pointOfInterestProperties, float distanceX, float distanceY, float radius = 250f, int itterations = 100, float LandmarkRadius = 150f)
	{
		Vector2 vector = new Vector2(ClampPositionX(TownheartWorldPosition.x + distanceX), ClampPositionY(TownheartWorldPosition.z + UnityEngine.Random.Range(0f - distanceY, distanceY)));
		for (int i = 0; i < itterations; i++)
		{
			Vector2 vector2 = vector + UnityEngine.Random.insideUnitCircle * radius;
			if (!TryReturnTileContainingPositionX(out var tile, vector2.x))
			{
				continue;
			}
			vector2.y = Mathf.Clamp(vector2.y, tile.WorldBounds.yMin + pointOfInterestProperties.Radius, tile.WorldBounds.yMax - pointOfInterestProperties.Radius);
			bool flag = false;
			foreach (LandmarkSpawner landmark in tile.Landmarks)
			{
				if (landmark.WorldPosition2D.IsInRange(vector2, pointOfInterestProperties.Radius + LandmarkRadius))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				spawner = new PointOfInterestSpawner(pointOfInterestProperties, (vector2 - tile.Offset).Vector3TopDown());
				tile.AddPointOfInterestSpawner(spawner);
				spawner.SetWorldTileOffset(tile.Offset);
				return true;
			}
		}
		Debug.LogException(new Exception($"Unable to spawn Point of Interest '{pointOfInterestProperties}'"));
		spawner = null;
		return false;
	}

	public bool TrySpawnPointOfInterest(out PointOfInterestSpawner spawner, PointOfInterestProperties pointOfInterestProperties, Vector3 worldPosition, float radius = 250f, int itterations = 100, float LandmarkRadius = 150f)
	{
		Vector2 vector = worldPosition.Vector2TopDown();
		for (int i = 0; i < itterations; i++)
		{
			Vector2 vector2 = vector + UnityEngine.Random.insideUnitCircle * radius;
			if (!TryReturnTileContainingPosition(out var tile, vector2))
			{
				continue;
			}
			bool flag = false;
			foreach (LandmarkSpawner landmark in tile.Landmarks)
			{
				if (landmark.WorldPosition2D.IsInRange(vector2, pointOfInterestProperties.Radius + LandmarkRadius))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				spawner = new PointOfInterestSpawner(pointOfInterestProperties, (vector2 - tile.Offset).Vector3TopDown());
				tile.AddPointOfInterestSpawner(spawner);
				spawner.SetWorldTileOffset(tile.Offset);
				return true;
			}
		}
		Debug.LogException(new Exception($"Unable to spawn Point of Interest '{pointOfInterestProperties}'"));
		spawner = null;
		return false;
	}

	public void ClearFogOfWar(ISpawner spawner, float clearRadius = 200f, float scoutRadius = 300f)
	{
		Rect other = new Rect(spawner.WorldPosition2D.x - scoutRadius, spawner.WorldPosition2D.y - scoutRadius, scoutRadius * 2f, scoutRadius * 2f);
		spawner.SetScoutingState(ScoutingState.Scouted);
		foreach (WorldTile tile in Tiles)
		{
			if (!tile.WorldBounds.Overlaps(other))
			{
				continue;
			}
			foreach (LandmarkSpawner landmark in tile.Landmarks)
			{
				if (other.Contains(landmark.WorldPosition2D))
				{
					landmark.SetScoutingState(ScoutingState.Scouted);
				}
			}
			foreach (PointOfInterestSpawner item in tile.PointsOfInterest)
			{
				if (other.Contains(item.WorldPosition2D))
				{
					item.SetScoutingState(ScoutingState.Scouted);
				}
			}
		}
		WorldMapFogOfWar.ScoutArea(spawner.WorldPosition2D.Vector3TopDown(), clearRadius);
	}

	public bool TryReturnLandmarkActionRescue(out LandmarkActionRescue rescueAction, ILandmarkPicker landmarkPicker, int itteration = 0)
	{
		rescueAction = null;
		foreach (WorldTile tile in Tiles)
		{
			if (tile.WorldBounds.xMax < TownheartMaxX)
			{
				continue;
			}
			foreach (LandmarkSpawner landmark in tile.Landmarks)
			{
				if (landmarkPicker.IsBetterPick(landmark) && landmark.LandmarkBehaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.ReturnHasAction<LandmarkActionRescue>())
				{
					landmarkPicker.ConfirmBestPick(landmark);
				}
			}
		}
		if (rescueAction != null)
		{
			return true;
		}
		if (TryForceNextTile(landmarkPicker))
		{
			return TryReturnLandmarkActionRescue(out rescueAction, landmarkPicker, itteration++);
		}
		return false;
	}

	private bool TryReturnDisabledLandmarkSpawner(ILandmarkPicker landmarkPicker, int itteration = 0)
	{
		Vector2 worldPosition = TownheartWorldPosition.Vector2TopDown();
		int num = Tiles.Count;
		using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
		for (int i = 0; i < Tiles.Count; i++)
		{
			WorldTile worldTile = Tiles[i];
			if (worldTile.TryReturnRegionContainingPosition(out var _, worldPosition))
			{
				num = i;
			}
			else if (i < num)
			{
				continue;
			}
			PopulateDisabledSpawners(worldTile, landmarkPicker, list);
		}
		if (landmarkPicker.SetBestPick(list))
		{
			return true;
		}
		return TryForceNextTile(landmarkPicker) && TryReturnDisabledLandmarkSpawner(landmarkPicker);
	}

	private void PopulateDisabledSpawners(WorldTile worldTile, ILandmarkPicker landmarkPicker, List<LandmarkSpawner> disabledSpawners)
	{
		foreach (IWorldRegion region in worldTile.Regions)
		{
			if (!landmarkPicker.SkipRegion(region))
			{
				region.PopulateDisabledLandmarkSpawners(disabledSpawners, landmarkPicker.MaximumScoutingState);
			}
		}
	}

	private float ClampPositionX(float positionX)
	{
		if (Tiles.Count == 0)
		{
			return 0f;
		}
		float xMin = Tiles[0].WorldBounds.xMin;
		List<WorldTile> tiles = Tiles;
		return Mathf.Clamp(positionX, xMin, tiles[tiles.Count - 1].WorldBounds.xMax);
	}

	private float ClampPositionY(float positionY)
	{
		foreach (WorldTile tile in Tiles)
		{
			positionY = Mathf.Clamp(positionY, tile.WorldBounds.yMin, tile.WorldBounds.yMax);
		}
		return positionY;
	}

	public bool CanAddNextTile()
	{
		if (HasEndTile)
		{
			return false;
		}
		if (Tiles.Count >= TileProperties.MaximumActiveTileCount)
		{
			Debug.LogException(new Exception($"Unable to add next tile, the maximum active tile count ({TileProperties.MaximumActiveTileCount}) would be surpassed."));
			return false;
		}
		if (TryReturnWorldTileSpawningBlocker(out var _))
		{
			return false;
		}
		return true;
	}

	private bool IsPositionInWorldBounds(Vector3 position)
	{
		WorldTile worldTile = Tiles[0];
		List<WorldTile> tiles = Tiles;
		WorldTile worldTile2 = tiles[tiles.Count - 1];
		if (worldTile.WorldBounds.xMin <= position.x && position.x <= worldTile2.WorldBounds.xMax && worldTile.WorldBounds.yMin <= position.y)
		{
			return position.y <= worldTile.WorldBounds.yMax;
		}
		return false;
	}

	public bool TryReturnTileContainingPosition(out WorldTile tile, Vector2 position)
	{
		for (int i = 0; i < Tiles.Count; i++)
		{
			tile = Tiles[i];
			if (tile.WorldBounds.Contains(position))
			{
				return true;
			}
		}
		tile = null;
		return false;
	}

	public bool TryReturnTileContainingPositionX(out WorldTile tile, float positionX)
	{
		for (int i = 0; i < Tiles.Count; i++)
		{
			tile = Tiles[i];
			if (tile.WorldBounds.xMin <= positionX && positionX < tile.WorldBounds.xMax)
			{
				return true;
			}
		}
		tile = null;
		return false;
	}

	public bool TryReturnRegionContainingPosition(out IWorldRegion region, Vector2 worldPosition)
	{
		foreach (WorldTile tile in Tiles)
		{
			if (tile.TryReturnRegionContainingPosition(out region, worldPosition))
			{
				return true;
			}
		}
		region = null;
		return false;
	}

	public bool TryReturnClosestSpawnerWithLandmarkAction<T>(out LandmarkSpawner spawner, float range, ScoutingState maximumScouting) where T : LandmarkAction
	{
		return TryReturnClosestSpawnerWithLandmarkAction<T>(out spawner, TownheartWorldPosition, TownheartMaxX, range, maximumScouting);
	}

	private bool TryReturnClosestSpawnerWithLandmarkAction<T>(out LandmarkSpawner closestSpawner, Vector3 position, float minimumX, float range, ScoutingState maximumScouting) where T : LandmarkAction
	{
		float num = ((range == float.MaxValue) ? float.MaxValue : (position.x + range));
		float num2 = range * range;
		closestSpawner = null;
		foreach (WorldTile tile in Tiles)
		{
			Rect worldBounds = tile.WorldBounds;
			if (worldBounds.xMax < minimumX || num < worldBounds.xMin)
			{
				continue;
			}
			foreach (LandmarkSpawner landmark in tile.Landmarks)
			{
				if (SkipLandmark(landmark, minimumX, maximumScouting) || landmark.LandmarkBehaviour.ReturnIsCompleted())
				{
					continue;
				}
				ActionsBehaviour actionsBehaviour = landmark.LandmarkBehaviour as ActionsBehaviour;
				if ((bool)actionsBehaviour && actionsBehaviour.ReturnHasAction<T>())
				{
					float num3 = position.DistanceToSquared(landmark.WorldPosition);
					if (num3 < num2)
					{
						num2 = num3;
						closestSpawner = landmark;
					}
				}
			}
		}
		return closestSpawner != null;
	}

	public bool TryReturnClosestUnscoutedLandmarkInRange(out LandmarkSpawner closestLandmarkSpawner, float range, float offsetMinX = 0f, WorldMapScoutingId filter = WorldMapScoutingId.None)
	{
		float num = TownheartMaxX + offsetMinX;
		float num2 = TownheartWorldPosition.x + range;
		float num3 = range * range;
		closestLandmarkSpawner = null;
		foreach (WorldTile tile in Tiles)
		{
			Rect worldBounds = tile.WorldBounds;
			if (worldBounds.xMax < num || num2 < worldBounds.xMin)
			{
				continue;
			}
			using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
			GameManager.WorldManager.World.ReturnAllLandmarks(list);
			foreach (LandmarkSpawner item in list)
			{
				if (!SkipLandmark(item, num, ScoutingState.None) && item.MatchesScoutingFilter(filter))
				{
					float num4 = item.WorldPosition.DistanceToSquared(TownheartWorldPosition);
					if (num4 < num3)
					{
						num3 = num4;
						closestLandmarkSpawner = item;
					}
				}
			}
		}
		return closestLandmarkSpawner != null;
	}

	public bool TryReturnLandmarkSpawner(out LandmarkSpawner landmarkSpawner, int tileIndex, int spawnerIndex)
	{
		foreach (WorldTile tile in Tiles)
		{
			if (tile.Index == tileIndex)
			{
				return tile.Landmarks.TryGetValue(spawnerIndex, out landmarkSpawner);
			}
		}
		landmarkSpawner = null;
		return false;
	}

	public bool ReturnIsProcedural()
	{
		if (Tiles != null && Tiles.Count == 1)
		{
			return Tiles[0].Regions.IsNullOrEmpty();
		}
		return false;
	}

	public IReadOnlyList<LandmarkSpawner> ReturnAllLandmarks(List<LandmarkSpawner> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<LandmarkSpawner>();
		}
		foreach (WorldTile tile in Tiles)
		{
			listToPopulate.AddRange(tile.Landmarks);
		}
		return listToPopulate;
	}

	public IReadOnlyList<LandmarkSpawner> GetAllScoutingLandmarks(List<LandmarkSpawner> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<LandmarkSpawner>();
		}
		foreach (WorldTile tile in Tiles)
		{
			foreach (IWorldRegion region in tile.Regions)
			{
				region.GetScoutingLandmarks(listToPopulate);
			}
		}
		return listToPopulate;
	}

	public LandmarkSpawner GetNearestLandmarkOfType(ILandmarkBehaviourProvider landmarkType, GameEventType requiredLandmarkActionType = GameEventType.None)
	{
		using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
		GameManager.WorldManager.World.ReturnAllLandmarks(list);
		return list.IsNullOrEmpty() ? null : SelectNearestLandmark(list, landmarkType, requiredLandmarkActionType);
	}

	private LandmarkSpawner SelectNearestLandmark(IReadOnlyList<LandmarkSpawner> landmarks, ILandmarkBehaviourProvider landmarkType, GameEventType requiredLandmarkActionType)
	{
		Vector3 position = GameManager.WorldMapManager.WorldMap.Townheart.Position;
		LandmarkSpawner result = null;
		float num = float.MaxValue;
		foreach (LandmarkSpawner landmark in landmarks)
		{
			if (landmark != null && (landmarkType == null || landmarkType.ReturnIsLandmarkBehaviour(landmark.LandmarkBehaviour)) && (requiredLandmarkActionType == GameEventType.None || (landmark.LandmarkBehaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.ReturnHasLandmarkAction(requiredLandmarkActionType))))
			{
				float sqrMagnitude = (landmark.WorldPosition - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					result = landmark;
					num = sqrMagnitude;
				}
			}
		}
		return result;
	}

	public IReadOnlyList<PointOfInterestSpawner> ReturnAllPOIs(List<PointOfInterestSpawner> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<PointOfInterestSpawner>();
		}
		foreach (WorldTile tile in Tiles)
		{
			listToPopulate.AddRange(tile.PointsOfInterest);
		}
		return listToPopulate;
	}

	public PointOfInterestSpawner GetNearestPOIOfType(PointOfInterestProperties poiType)
	{
		using ListPool<PointOfInterestSpawner>.List list = ListPool<PointOfInterestSpawner>.Get();
		GameManager.WorldManager.World.ReturnAllPOIs(list);
		return list.IsNullOrEmpty() ? null : SelectNearestPOI(list, poiType);
	}

	private PointOfInterestSpawner SelectNearestPOI(IReadOnlyList<PointOfInterestSpawner> pois, PointOfInterestProperties poiType)
	{
		Vector3 position = GameManager.WorldMapManager.WorldMap.Townheart.Position;
		PointOfInterestSpawner result = null;
		float num = float.MaxValue;
		foreach (PointOfInterestSpawner poi in pois)
		{
			if (poi != null && (!(poiType != null) || !(poi.Properties != poiType)))
			{
				float sqrMagnitude = (poi.WorldPosition - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					result = poi;
					num = sqrMagnitude;
				}
			}
		}
		return result;
	}

	public int GetScoutedRegionsCount()
	{
		int num = 0;
		foreach (WorldTile tile in Tiles)
		{
			foreach (IWorldRegion region in tile.Regions)
			{
				if (region.Flags.HasFlag(WorldRegionFlags.Scouted))
				{
					num++;
				}
			}
		}
		return num;
	}

	public IReadOnlyList<PointOfInterestSpawner> ReturnOverlappingPointsOfInterest(Vector3 spawnPosition, List<PointOfInterestSpawner> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<PointOfInterestSpawner>(512);
		}
		foreach (WorldTile tile in Tiles)
		{
			tile.ReturnOverlappingPointsOfInterest(spawnPosition, listToPopulate);
		}
		return listToPopulate;
	}

	private bool SkipLandmark(LandmarkSpawner landmarkSpawner, float minimumX, ScoutingState maximumScouting)
	{
		if (!TileProperties.IsCorridor || !(landmarkSpawner.WorldPosition.x < minimumX))
		{
			return maximumScouting < landmarkSpawner.ScoutingState;
		}
		return true;
	}

	private Vector3 ReturnTileOffset(WorldTile tile, WorldTile antecede)
	{
		return new Vector3((antecede?.WorldBounds.xMax ?? 0f) + tile.WorldBounds.size.x / 2f, 0f, 0f);
	}

	public bool TryReturnWorldTileSpawningBlocker(out WorldTileSpawningBlocker worldTileSpawningBlocker)
	{
		if (Tiles.IsNullOrEmpty())
		{
			worldTileSpawningBlocker = null;
			return false;
		}
		for (int i = 0; i < WorldManager.SpawningBlockers.Count; i++)
		{
			worldTileSpawningBlocker = WorldManager.SpawningBlockers[i];
			WorldTileSpawningBlocker obj = worldTileSpawningBlocker;
			List<WorldTile> tiles = Tiles;
			if (obj.BlocksSpawning(tiles[tiles.Count - 1]))
			{
				return true;
			}
		}
		worldTileSpawningBlocker = null;
		return false;
	}
}
