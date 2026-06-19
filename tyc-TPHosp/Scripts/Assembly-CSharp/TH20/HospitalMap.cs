#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class HospitalMap : MustCallDestroy
	{
		[DontSave]
		private CorridorWallsVisual _corridorWallsVisual;

		private List<WallCoord> _externalWalls;

		[DontSave]
		public Room[,] WorldRooms;

		[DontSave]
		private BoolArray2D _indoorState;

		[DontSave]
		private BoolArray2D _indoorOrPathState;

		[DontSave]
		private BoolArray2D _connectedToDoorMap;

		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly VisualManager _visualManager;

		private readonly Material _valueMaterial;

		private readonly RoomItemVisualEdit.Config _roomItemEditConfig;

		private readonly DemolishLandscapeItemEffect.Config _demolishLandscapeItemConfig;

		[DontSave]
		private Transform _demolishRoot;

		private List<HospitalPlot> _mergedPlots;

		[DontSave]
		private Texture2D _floorImage;

		[DontSave]
		private HospitalPlotFootprintPerimeter _footprintPerimeter;

		public HospitalPlot Plot { get; private set; }

		public int Width => IndoorState.GetLength(0);

		public int Height => IndoorState.GetLength(1);

		public GridCoord Anchor { get; private set; }

		public GridBounds Bounds => new GridBounds
		{
			Min = Anchor,
			Max = new GridCoord(Anchor.X + FloorPlan.Width() - 1, Anchor.Y + FloorPlan.Height() - 1)
		};

		public FloorPlan FloorPlan { get; private set; }

		public RoomFloorPlanVisual RoomVisual { get; private set; }

		public Room Room { get; private set; }

		public FloorPlan CorridorFloorPlan { get; private set; }

		public bool[,] IndoorState
		{
			get
			{
				return _indoorState.Values;
			}
			private set
			{
				_indoorState.Values = value;
			}
		}

		public bool[,] IndoorOrPathState
		{
			get
			{
				return _indoorOrPathState.Values;
			}
			private set
			{
				_indoorOrPathState.Values = value;
			}
		}

		[DontSave]
		public List<GridCoord> HospitalEntrances { get; private set; }

		public CorridorWallsVisual CorridorWallsVisual => _corridorWallsVisual;

		public Vector3 MainEntranceWorldPosition => RoomItemAlgorithms.CalculateDoorEnter(FloorPlan.Doors[0]);

		private Texture2D FloorImage
		{
			get
			{
				if (!(_floorImage != null))
				{
					return Plot.Definition.FloorImage;
				}
				return _floorImage;
			}
		}

		public bool HasMergedPlots
		{
			get
			{
				if (_mergedPlots != null)
				{
					return _mergedPlots.Count != 0;
				}
				return false;
			}
		}

		public List<WallCoord> ExternalWalls => _externalWalls;

		public HospitalPlotFootprintPerimeter FootprintPerimeter => _footprintPerimeter;

		public HospitalMap(HospitalPlot plot, Level level, WorldState worldState, VisualManager visualManager, Material valueMaterial, RoomItemVisualEdit.Config roomItemEditConfig, bool animateWalls)
		{
			Plot = plot;
			_level = level;
			_worldState = worldState;
			_visualManager = visualManager;
			_valueMaterial = valueMaterial;
			_roomItemEditConfig = roomItemEditConfig;
			_demolishLandscapeItemConfig = _level.Config.GetDemolishLandscapeItemEffectConfig();
			_mergedPlots = new List<HospitalPlot>();
			CreateDemolishRoot();
			CreateFootprintPerimeter();
			HospitalEntrances = new List<GridCoord>();
			Build(animateWalls);
		}

		private void CreateDemolishRoot()
		{
			_demolishRoot = new GameObject("Demolish Root").transform;
		}

		private void CreateFootprintPerimeter()
		{
			_footprintPerimeter = new HospitalPlotFootprintPerimeter(_worldState.PerimeterPrefabs, _worldState.PerimeterOffset, _worldState.PerimeterNoRotation);
		}

		public void PreRestoreFromSave()
		{
			if (_mergedPlots == null)
			{
				_mergedPlots = new List<HospitalPlot>();
			}
			else
			{
				foreach (HospitalPlot mergedPlot in _mergedPlots)
				{
					MergeFloorImage(mergedPlot.Definition.FloorImage);
				}
			}
			CreateIndoorState();
			RebuildWorldRooms();
			HospitalEntrances = new List<GridCoord>();
			AddHospitalEntrancesFromImage(FloorImage);
			if (FloorPlan.HasNoExteriorWalls())
			{
				DestroyRedundantDoors();
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			CreateDemolishRoot();
			CreateFootprintPerimeter();
			AddLandscapeObjects(HospitalPlotLayer.Base, restoringFromSave: true);
			AddLandscapeObjects(HospitalPlotLayer.Built, restoringFromSave: true);
			AddLandscapeObjects(HospitalPlotLayer.Unbuilt, restoringFromSave: true);
			foreach (HospitalPlot mergedPlot in _mergedPlots)
			{
				CreateItems(HospitalPlotLayer.Built, restoringFromSave: true, mergedPlot.Definition.GetItems(HospitalPlotLayer.Built));
			}
			List<WallCoord> walls = FloorPlan.Walls;
			FloorPlan.Walls = _externalWalls;
			RoomVisual.UpdateFromRoom(FloorPlan);
			FloorPlan.Walls = walls;
			FloorPlan.RecalculateBounds();
			GridBounds recalcBounds = Bounds - Anchor;
			CorridorFloorPlan.RestoreFromSave();
			List<WallCoord> walls2 = RoomAlgorithms.CalculateWalls(CorridorFloorPlan, Bounds - Anchor, this, Plot.Definition.AmbulanceBayEntranceSide);
			_corridorWallsVisual = new CorridorWallsVisual(Plot.GetRoomDefinition()._wallsInterior, _worldState.GetCorridorWallDefinition(), RoomVisual.GameObject.transform);
			_corridorWallsVisual.CreateWallObjects(walls2, Anchor, recalcBounds, _worldState, animateWalls: false, null, Vector3.zero);
			List<Room> list = new List<Room>();
			for (int i = recalcBounds.Min.X; i < recalcBounds.Max.X; i++)
			{
				for (int j = recalcBounds.Min.Y; j < recalcBounds.Max.Y; j++)
				{
					if (WorldRooms[i, j] != null)
					{
						list.AddUnique(WorldRooms[i, j]);
					}
				}
			}
			foreach (Room item in list)
			{
				_corridorWallsVisual.UpdateWallDoorClipBounds(item, Anchor);
			}
			RemoveTerrainDetailMeshes();
			BuildPerimeter();
		}

		private void RebuildWorldRooms()
		{
			WorldRooms = new Room[Width, Height];
			ArrayUtils.Populate(WorldRooms, null);
			foreach (Room allRoom in _worldState.AllRooms)
			{
				FloorPlan floorPlan = allRoom.FloorPlan;
				if (floorPlan.HospitalMap == this && floorPlan != FloorPlan)
				{
					AddRoomToWorldRooms(allRoom, addRoom: true, floorPlan);
				}
			}
		}

		public void RebuildConnectedToDoorMap()
		{
			bool[,] array = new bool[Width, Height];
			CacheArrivalDeparturePositions();
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					if (FloorPlan[i, j] && RoomAlgorithms.PositionConnectsToEntrance(new GridCoord(i, j), this))
					{
						array[i, j] = true;
					}
				}
			}
			_connectedToDoorMap.Values = array;
		}

		public bool PositionConnectsToEntrance(GridCoord worldCoord)
		{
			GridCoord gridCoord = worldCoord - FloorPlan.Anchor;
			return _connectedToDoorMap.Values[gridCoord.X, gridCoord.Y];
		}

		private void CreateIndoorState()
		{
			CalculateIndoorStateFromImage(FloorImage, out var indoorState, out var indoorOrPathState, out var anchor);
			Anchor = anchor;
			IndoorState = indoorState;
			IndoorOrPathState = indoorOrPathState;
		}

		private void SaveIndoorStateAsPNG()
		{
			Texture2D texture2D = new Texture2D(IndoorState.GetLength(0), IndoorState.GetLength(1), TextureFormat.ARGB32, mipChain: false);
			Color32[] pixels = texture2D.GetPixels32();
			for (int i = 0; i < IndoorState.GetLength(0); i++)
			{
				for (int j = 0; j < IndoorState.GetLength(0); j++)
				{
					pixels[j + i * IndoorState.GetLength(1)] = (IndoorState[j, i] ? Color.white : Color.black);
				}
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			texture2D.SaveAsPNG(Application.dataPath + "/../IndoorState.png");
		}

		public void Build(bool animateWalls)
		{
			Demolish();
			Texture2D floorImage = FloorImage;
			RoomDefinition roomDefinition = Plot.GetRoomDefinition();
			CreateIndoorState();
			FloorPlan = new FloorPlan(roomDefinition, _level, this)
			{
				Anchor = Anchor,
				Tiles = (bool[,])IndoorState.Clone()
			};
			AddHospitalEntrancesFromImage(floorImage);
			AddWindowAndDoorItems(floorImage);
			AddLandscapeObjects(HospitalPlotLayer.Base, restoringFromSave: false);
			AddLandscapeObjects(HospitalPlotLayer.Built, restoringFromSave: false);
			AddLandscapeObjects(HospitalPlotLayer.Unbuilt, restoringFromSave: false);
			GridBounds recalcBounds = FloorPlan.WorldBounds - Anchor;
			recalcBounds.Grow(-2);
			FloorPlan.Invert();
			FloorPlan.Walls = RoomAlgorithms.CalculateWalls(FloorPlan, recalcBounds, null, Plot.Definition.AmbulanceBayEntranceSide);
			if (FloorPlan.HasNoExteriorWalls())
			{
				HospitalNoWallFixups.FixupExteriorWalls(FloorPlan.Walls);
			}
			RemoveAdjoiningWalls(floorImage, FloorPlan.Walls);
			_externalWalls = FloorPlan.Walls;
			if (FloorPlan.Walls.Count != 0)
			{
				FloorPlan.RecalculateBounds();
			}
			FloorPlan.Invert();
			if (FloorPlan.Walls.Count == 0)
			{
				FloorPlan.RecalculateBounds();
			}
			AddPillars(floorImage);
			WorldRooms = new Room[Width, Height];
			ArrayUtils.Populate(WorldRooms, null);
			RoomVisual = new RoomFloorPlanVisual(_worldState, _visualManager, roomDefinition.ToString(), roomDefinition.GetFloorTile(_worldState), _valueMaterial, _roomItemEditConfig, roomDefinition._wallsExterior, _level.BuildEvents);
			RoomVisual.UpdateFromRoom(FloorPlan);
			if (animateWalls)
			{
				RoomVisual.TriggerConstructionAnimations(FloorPlan.WorldBounds.Min);
			}
			Room = new Room(_level, FloorPlan, RoomVisual);
			_corridorWallsVisual = new CorridorWallsVisual(roomDefinition._wallsInterior, _worldState.GetCorridorWallDefinition(), RoomVisual.GameObject.transform);
			CalculateCorridors(FloorPlan.WorldBounds - Anchor, animateWalls, null);
			RebuildConnectedToDoorMap();
			_worldState.AllRooms.Add(Room);
			_worldState.BuildRoom(Room, GameAlgorithms.CalculatePurchaseCostOfRoom(Room.FloorPlan, isNewRoom: true));
			RemoveTerrainDetailMeshes();
			BuildPerimeter();
		}

		private void BuildPerimeter()
		{
			if (Plot.Bought && Plot.Built)
			{
				_footprintPerimeter.Refresh(IndoorState, Anchor);
			}
		}

		private void RemoveAdjoiningWalls(Texture2D image, List<WallCoord> walls)
		{
			Color[] pixels = image.GetPixels();
			int width = image.width;
			foreach (WallCoord wall in walls)
			{
				GridCoord position = wall._position;
				if (wall.IsWall())
				{
					if (IsAdjoiningWall(position.X, position.Y, pixels, width))
					{
						wall._type = RoomWallDefinition.Type.Blank;
					}
					else if (wall._type == RoomWallDefinition.Type.WallCornerLeft)
					{
						position += wall._rotation.RotateClockwise().DirectionCoord();
						if (IsAdjoiningWall(position.X, position.Y, pixels, width))
						{
							wall._type = RoomWallDefinition.Type.Wall;
						}
					}
					else if (wall._type == RoomWallDefinition.Type.WallCornerRight)
					{
						position += wall._rotation.RotateAntiClockwise().DirectionCoord();
						if (IsAdjoiningWall(position.X, position.Y, pixels, width))
						{
							wall._type = RoomWallDefinition.Type.Wall;
						}
					}
				}
				else if (wall.IsCorner() && IsAdjoiningWall(position.X, position.Y, pixels, width))
				{
					wall._type = RoomWallDefinition.Type.Blank;
				}
			}
		}

		public void DemolishUnbuiltLandscapeItems(float timeToDemolish)
		{
			if (FloorPlan == null)
			{
				return;
			}
			List<LandscapeRoomItem> list = new List<LandscapeRoomItem>();
			foreach (LandscapeRoomItem landscapeItem in FloorPlan.LandscapeItems)
			{
				if (landscapeItem.Layer == HospitalPlotLayer.Unbuilt)
				{
					list.Add(landscapeItem);
				}
			}
			list.Sort(delegate(LandscapeRoomItem item1, LandscapeRoomItem item2)
			{
				float num3 = item1.WorldPosition.x + item1.WorldPosition.z;
				float value = item2.WorldPosition.x + item2.WorldPosition.z;
				return num3.CompareTo(value);
			});
			timeToDemolish *= _demolishLandscapeItemConfig.MaxStartTime;
			float num = timeToDemolish / (float)list.Count;
			float num2 = 0f;
			foreach (LandscapeRoomItem item in list)
			{
				GameObject gameObject = item.Visual.StealGameObject();
				item.FloorPlan.RemoveItemNoValidation(item);
				item.Visual.Destroy();
				item.Destroy();
				gameObject.transform.SetParent(_demolishRoot, worldPositionStays: true);
				gameObject.AddComponent<DemolishLandscapeItemEffect>().Initialise(_demolishLandscapeItemConfig, num2);
				num2 += num;
			}
		}

		public void ApplyBuildingEffectToWalls()
		{
			Transform transform = RoomVisual.WallsContainer.transform;
			Vector3 origin = FloorPlan.WorldBounds.Min.ToWorldPosition();
			transform.IterateChildren(delegate(Transform transform2)
			{
				if (transform2.gameObject.activeSelf)
				{
					transform2.gameObject.GetOrAddComponent<PlotBuildingEffectComponent>().Initialise(origin);
				}
			});
		}

		public void ApplyRemoveWallsEffect()
		{
			Transform transform = RoomVisual.WallsContainer.transform;
			Vector3 origin = FloorPlan.WorldBounds.Min.ToWorldPosition();
			transform.IterateChildren(delegate(Transform transform2)
			{
				if (transform2.gameObject.activeSelf)
				{
					GameObject gameObject = Object.Instantiate(transform2.gameObject);
					gameObject.transform.position = transform2.position;
					gameObject.GetOrAddComponent<PlotRemoveEffectComponent>().Initialise(origin);
				}
			});
		}

		public void ApplyRemoveInteriorWallEffect()
		{
			Transform transform = CorridorWallsVisual.Container.transform;
			Vector3 origin = FloorPlan.WorldBounds.Min.ToWorldPosition();
			transform.IterateChildren(delegate(Transform transform2)
			{
				if (transform2.gameObject.activeSelf)
				{
					GameObject gameObject = Object.Instantiate(transform2.gameObject);
					gameObject.transform.position = transform2.position;
					gameObject.GetOrAddComponent<PlotRemoveEffectComponent>().Initialise(origin);
				}
			});
		}

		private void AddLandscapeObjects(HospitalPlotLayer layer, bool restoringFromSave)
		{
			if (Plot.IsLayerVisible(layer))
			{
				CreateItems(layer, restoringFromSave, Plot.Definition.GetItems(layer));
			}
		}

		private void CreateItems(HospitalPlotLayer layer, bool restoringFromSave, List<HospitalPlotItem> items)
		{
			if (items == null)
			{
				return;
			}
			foreach (HospitalPlotItem item in items)
			{
				RoomItemDefinition instance = item.Definition.Instance;
				if (restoringFromSave && instance.ItemType != RoomItemDefinition.Type.Landscape)
				{
					continue;
				}
				if (!VerifyRoomItem(item.Definition))
				{
					item.Definition = _level.Config.GetLevelDebugConfig().ErrorItemDefinition;
				}
				if (!instance.IsExcludedFromGameMode(_level))
				{
					RoomItem roomItem;
					if (instance.ItemType == RoomItemDefinition.Type.Landscape)
					{
						roomItem = new LandscapeRoomItem(instance, FloorPlan, _level, layer)
						{
							Rotation = item.Rotation,
							LocalPosition = item.Position
						};
					}
					else
					{
						roomItem = new RoomItem(instance, FloorPlan, _level)
						{
							Rotation = item.Rotation,
							LocalPosition = item.Position
						};
						roomItem.AddRoomModifiers();
						roomItem.EnableAttributes(enabled: true);
						_worldState.AddNeedSatisfyingRoomItem(roomItem);
					}
					FloorPlan.AddItem(roomItem);
				}
			}
		}

		public override void Destroy()
		{
			if (Room != null)
			{
				_worldState.AllRooms.Remove(Room);
				Room.FloorPlan.RemoveItemsFromWorld();
				_level.BuildEvents.OnCursorHoverStop.InvokeSafe(Room);
				_level.BuildEvents.OnRoomDeleted.InvokeSafe(Room);
				Room.Destroy();
				Room = null;
			}
			if (_footprintPerimeter != null)
			{
				_footprintPerimeter.Destroy();
			}
			DestroyCorridorFloorPlan();
			if (_corridorWallsVisual != null)
			{
				_corridorWallsVisual.Destroy();
				_corridorWallsVisual = null;
			}
			if (_floorImage != null)
			{
				Object.Destroy(_floorImage);
			}
			base.Destroy();
		}

		private void Demolish()
		{
			if (Room != null)
			{
				_level.BuildEvents.OnCursorHoverStop.InvokeSafe(Room);
				_level.BuildEvents.DeleteRoom(Room);
				Room = null;
			}
			DestroyCorridorFloorPlan();
			if (_corridorWallsVisual != null)
			{
				_corridorWallsVisual.Destroy();
				_corridorWallsVisual = null;
			}
		}

		private static bool PixelIsInDoors(Color col)
		{
			if (!HospitalMapTile.IsType(col, HospitalMapTile.Type.Floor) && !HospitalMapTile.IsType(col, HospitalMapTile.Type.Pillar))
			{
				return HospitalMapTile.IsType(col, HospitalMapTile.Type.Window);
			}
			return true;
		}

		private static bool PixelIsPath(Color col)
		{
			if (!HospitalMapTile.IsType(col, HospitalMapTile.Type.Path) && !HospitalMapTile.IsType(col, HospitalMapTile.Type.Driveway))
			{
				return HospitalMapTile.IsType(col, HospitalMapTile.Type.ArrivalPoint);
			}
			return true;
		}

		private static bool PixelIsAdjoining(Color col)
		{
			return HospitalMapTile.IsType(col, HospitalMapTile.Type.Adjoining);
		}

		private static bool IsAdjoiningWall(int x, int y, Color[] pixels, int width)
		{
			return PixelIsAdjoining(pixels[x + y * width]);
		}

		private void AddWindowAndDoorItems(Texture2D image)
		{
			Color[] pixels = image.GetPixels();
			int width = image.width;
			int height = image.height;
			RoomItemDefinition mainEntranceDefinition = Plot.GetMainEntranceDefinition();
			RoomItemDefinition sideEntranceDefinition = Plot.GetSideEntranceDefinition();
			RoomItemDefinition internalEntranceDefinition = Plot.GetInternalEntranceDefinition();
			RoomItemDefinition windowDefinition = Plot.GetWindowDefinition();
			for (int i = 1; i < height - 1; i++)
			{
				for (int j = 1; j < width - 1; j++)
				{
					Color col = pixels[j + i * width];
					bool num = PixelIsPath(col);
					bool flag = PixelIsInDoors(pixels[j - 1 + i * width]);
					bool flag2 = PixelIsInDoors(pixels[j + 1 + i * width]);
					bool flag3 = PixelIsInDoors(pixels[j + (i - 1) * width]);
					bool flag4 = PixelIsInDoors(pixels[j + (i + 1) * width]);
					if (num)
					{
						bool flag5 = PixelIsPath(pixels[j - 1 + i * width]);
						bool flag6 = PixelIsPath(pixels[j + 1 + i * width]);
						bool flag7 = PixelIsPath(pixels[j + (i - 1) * width]);
						bool flag8 = PixelIsPath(pixels[j + (i + 1) * width]);
						bool num2 = IsAdjoiningWall(j - 1, i, pixels, width);
						bool flag9 = IsAdjoiningWall(j + 1, i, pixels, width);
						bool flag10 = IsAdjoiningWall(j, i - 1, pixels, width);
						bool flag11 = IsAdjoiningWall(j, i + 1, pixels, width);
						RoomItemDefinition roomItemDefinition = (HospitalMapTile.IsType(col, HospitalMapTile.Type.Driveway) ? mainEntranceDefinition : sideEntranceDefinition);
						if (num2 || flag9 || flag11 || flag10)
						{
							roomItemDefinition = internalEntranceDefinition;
						}
						if (roomItemDefinition != null)
						{
							Vector3 vector = new GridCoord(j, i).ToWorldPosition();
							if (flag && flag7 && !flag8)
							{
								AddRoomItem(vector + new Vector3(0f, 0f, -1f), roomItemDefinition, GridDirection.NegX.YawRotation());
							}
							else if (flag2 && flag8 && !flag7)
							{
								AddRoomItem(vector + new Vector3(0f, 0f, 1f), roomItemDefinition, GridDirection.PosX.YawRotation());
							}
							else if (flag3 && flag6 && !flag5)
							{
								AddRoomItem(vector + new Vector3(1f, 0f, 0f), roomItemDefinition, GridDirection.NegY.YawRotation());
							}
							else if (flag4 && flag5 && !flag6)
							{
								AddRoomItem(vector + new Vector3(-1f, 0f, 0f), roomItemDefinition, GridDirection.PosY.YawRotation());
							}
						}
					}
					if (windowDefinition != null && HospitalMapTile.IsType(col, HospitalMapTile.Type.Window))
					{
						if (!flag)
						{
							AddRoomItem(j - 1, i, windowDefinition, GridDirection.PosX);
						}
						else if (!flag2)
						{
							AddRoomItem(j + 1, i, windowDefinition, GridDirection.NegX);
						}
						else if (!flag3)
						{
							AddRoomItem(j, i - 1, windowDefinition, GridDirection.PosY);
						}
						else if (!flag4)
						{
							AddRoomItem(j, i + 1, windowDefinition, GridDirection.NegY);
						}
					}
				}
			}
		}

		private void AddRoomItem(int x, int y, RoomItemDefinition itemDefinition, GridDirection gridDirection)
		{
			AddRoomItem(new GridCoord(x, y).ToWorldPosition(), itemDefinition, gridDirection.YawRotation());
		}

		private void AddRoomItem(Vector3 position, RoomItemDefinition itemDefinition, float rotation)
		{
			RoomItem roomItem = new RoomItem(itemDefinition, FloorPlan, _level)
			{
				Rotation = rotation,
				LocalPosition = position
			};
			roomItem.SetValidDebug(valid: true, "OK");
			FloorPlan.AddItem(roomItem);
		}

		private void AddPillars(Texture2D image)
		{
			Color[] pixels = image.GetPixels();
			int width = image.width;
			foreach (WallCoord wall in FloorPlan.Walls)
			{
				if (!wall.IsCorner() && !wall.IsDoor())
				{
					GridCoord gridCoord = wall._position + wall._rotation.DirectionCoord();
					if (HospitalMapTile.IsType(pixels[gridCoord.X + gridCoord.Y * width], HospitalMapTile.Type.Pillar))
					{
						wall._type = wall._type - 0 + 14;
					}
				}
			}
		}

		public static void CalculateIndoorStateFromImage(Texture2D image, out bool[,] indoorState, out bool[,] indoorOrPathState, out GridCoord anchor)
		{
			Color[] pixels = image.GetPixels();
			int width = image.width;
			int height = image.height;
			indoorState = new bool[width, height];
			indoorOrPathState = new bool[width, height];
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					Color col = pixels[j + i * width];
					bool flag = PixelIsInDoors(col);
					indoorState[j, i] = flag;
					indoorOrPathState[j, i] = flag || PixelIsPath(col);
				}
			}
			anchor = new GridCoord(-width / 2, -height / 2);
		}

		private void AddHospitalEntrancesFromImage(Texture2D image)
		{
			Color[] pixels = image.GetPixels();
			int width = image.width;
			int height = image.height;
			HospitalEntrances.Clear();
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (HospitalMapTile.IsType(pixels[j + i * width], HospitalMapTile.Type.ArrivalPoint))
					{
						HospitalEntrances.Add(new GridCoord(j, i) + Anchor);
					}
				}
			}
		}

		public void DebugGUI()
		{
			if (!DebugVars.ShowHospitalEntrances.Value)
			{
				return;
			}
			foreach (GridCoord hospitalEntrance in HospitalEntrances)
			{
				DebugDrawUtils.Marker(hospitalEntrance.ToWorldPosition(), Color.red);
			}
		}

		public void ModifyHospitalFloorPlan(Room room, bool addRoom, bool animateWalls, bool affectNavigation)
		{
			FloorPlan floorPlan = room.FloorPlan;
			if (floorPlan != null)
			{
				AddRoomToWorldRooms(room, addRoom, floorPlan);
				RoomVisual.CreateFloorTileObjects();
				CalculateCorridors(FloorPlan.WorldBounds - Anchor, animateWalls, room);
				if (affectNavigation)
				{
					_worldState.UpdateNavigation();
				}
				RebuildConnectedToDoorMap();
			}
		}

		private void AddRoomToWorldRooms(Room room, bool addRoom, FloorPlan modifyingFloorPlan)
		{
			GridCoord anchor = modifyingFloorPlan.Anchor;
			for (int i = 0; i < modifyingFloorPlan.Height(); i++)
			{
				for (int j = 0; j < modifyingFloorPlan.Width(); j++)
				{
					if (modifyingFloorPlan[j, i])
					{
						int num = j + anchor.X;
						int num2 = i + anchor.Y;
						int num3 = num - Anchor.X;
						int num4 = num2 - Anchor.Y;
						if (addRoom)
						{
							WorldRooms[num3, num4] = room;
							FloorPlan[num3, num4] = false;
						}
						else
						{
							WorldRooms[num3, num4] = null;
							FloorPlan[num3, num4] = true;
						}
					}
				}
			}
		}

		public Room GetRoomAtWorldCoord(GridCoord worldCoord, bool includeHospital)
		{
			GridCoord gridCoord = worldCoord - Anchor;
			Room room = ArrayUtils.Get(WorldRooms, gridCoord.X, gridCoord.Y, null);
			if (room == null && includeHospital && RoomAlgorithms.RoomContainsWorldCoord(FloorPlan, worldCoord))
			{
				room = Room;
			}
			return room;
		}

		private void CalculateCorridors(GridBounds recalcBounds, bool animateWalls, Room roomWallsToAnimate)
		{
			int num = FloorPlan.Width();
			int num2 = FloorPlan.Height();
			DestroyCorridorFloorPlan();
			CorridorFloorPlan = new FloorPlan(_level)
			{
				Tiles = new bool[num, num2],
				Anchor = FloorPlan.Anchor
			};
			List<KeyValuePair<GridCoord, RoomItem>> list = new List<KeyValuePair<GridCoord, RoomItem>>();
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					Room room = WorldRooms[j, i];
					if (room == null)
					{
						if (FloorPlan[j, i])
						{
							CorridorFloorPlan[j, i] = true;
						}
						room = Room;
					}
					else if (!room.Definition.HasExteriorWalls())
					{
						CorridorFloorPlan[j, i] = true;
					}
					GridCoord anchor = room.FloorPlan.Anchor;
					GridCoord localCoord = new GridCoord(j, i) + Anchor - anchor;
					List<RoomItem> itemsAtCoord = room.FloorPlan.GetItemsAtCoord(localCoord);
					if (itemsAtCoord == null)
					{
						continue;
					}
					foreach (RoomItem item in itemsAtCoord)
					{
						if (item.Definition.ItemType == RoomItemDefinition.Type.Door || item.Definition.ItemType == RoomItemDefinition.Type.Window || item.Definition.RemoveWalls)
						{
							list.AddUnique(new KeyValuePair<GridCoord, RoomItem>(anchor - Anchor, item));
						}
					}
				}
			}
			CorridorFloorPlan.CountFloorTiles();
			foreach (KeyValuePair<GridCoord, RoomItem> item2 in list)
			{
				RoomItem roomItem = new RoomItem(item2.Value, item2.Value.FloorPlan);
				Vector3 localPosition = GridCoord.GridCoordToWorldPosition(item2.Key);
				localPosition += roomItem.LocalPosition;
				localPosition += roomItem.GridRotation.DirectionVector() * 2f;
				roomItem.LocalPosition = localPosition;
				roomItem.Rotation += 180f;
				CorridorFloorPlan.AddItem(roomItem);
			}
			List<WallCoord> list2 = RoomAlgorithms.CalculateWalls(CorridorFloorPlan, recalcBounds, this, Plot.Definition.AmbulanceBayEntranceSide);
			Vector3 animateOrigin = roomWallsToAnimate?.FloorPlan.WorldBounds.Min.ToWorldPosition() ?? (recalcBounds.Min + Anchor).ToWorldPosition();
			_corridorWallsVisual.CreateWallObjects(list2, Anchor, recalcBounds, _worldState, animateWalls, roomWallsToAnimate, animateOrigin);
			List<Room> list3 = new List<Room>();
			GridBounds gridBounds = recalcBounds;
			gridBounds.Min.X = Mathf.Max(0, recalcBounds.Min.X - 1);
			gridBounds.Min.Y = Mathf.Max(0, recalcBounds.Min.Y - 1);
			gridBounds.Max.X = Mathf.Min(WorldRooms.GetLength(0) - 1, recalcBounds.Max.X + 1);
			gridBounds.Max.Y = Mathf.Min(WorldRooms.GetLength(1) - 1, recalcBounds.Max.Y + 1);
			for (int k = gridBounds.Min.X; k < gridBounds.Max.X; k++)
			{
				for (int l = gridBounds.Min.Y; l < gridBounds.Max.Y; l++)
				{
					if (WorldRooms[k, l] != null)
					{
						list3.AddUnique(WorldRooms[k, l]);
					}
				}
			}
			foreach (Room item3 in list3)
			{
				_corridorWallsVisual.UpdateWallDoorClipBounds(item3, Anchor);
			}
			List<WallCoord> list4 = new List<WallCoord>(FloorPlan.Walls);
			for (int m = 0; m < FloorPlan.Walls.Count; m++)
			{
				WallCoord wallCoord = FloorPlan.Walls[m];
				if (recalcBounds.IsInBounds(wallCoord._position))
				{
					list4.Remove(wallCoord);
				}
			}
			list4.AddRange(list2);
			FloorPlan.Walls = list4;
		}

		private void DestroyCorridorFloorPlan()
		{
			if (CorridorFloorPlan != null)
			{
				CorridorFloorPlan.Destroy();
				CorridorFloorPlan = null;
			}
		}

		private bool VerifyRoomItem(SharedInstance<RoomItemDefinition> definition)
		{
			if (definition == null)
			{
				Logging.Error(LogChannels.Debug, "Trying to add RoomItemDefinition is NULL");
				return false;
			}
			if (definition.Instance == null)
			{
				Logging.Error(LogChannels.Debug, "Trying to add RoomItemDefinition {0}, but the SharedInstance instance is NULL", definition.name);
				return false;
			}
			if (definition.Instance.GetPrefab() == null)
			{
				Logging.Error(LogChannels.Debug, "Trying to get the RoomItemDefinition {0}, but base Prefab is NULL", definition.name);
				return false;
			}
			return true;
		}

		private void RemoveTerrainDetailMeshes()
		{
			if (!DebugVars.AllowTerrainModification.Value || !Plot.Built || !(Terrain.activeTerrain != null) || !(Terrain.activeTerrain.terrainData != null))
			{
				return;
			}
			Terrain activeTerrain = Terrain.activeTerrain;
			TerrainData terrainData = activeTerrain.terrainData;
			int detailWidth = terrainData.detailWidth;
			int detailHeight = terrainData.detailHeight;
			Vector3 position = activeTerrain.gameObject.transform.position;
			int num = terrainData.detailPrototypes.Length;
			for (int i = 0; i < num; i++)
			{
				int[,] detailLayer = terrainData.GetDetailLayer(0, 0, detailWidth, detailHeight, i);
				for (int j = 0; j < detailLayer.GetLength(0); j++)
				{
					for (int k = 0; k < detailLayer.GetLength(1); k++)
					{
						Vector3 detailCoord = new Vector3(j, 0f, k);
						Vector3 source = terrainData.DetailCoordToWorld(detailCoord);
						source.x += position.x;
						source.z += position.z;
						if (RoomAlgorithms.RoomContainsWorldCoord(FloorPlan, source.ToGridCoord()))
						{
							detailLayer[k, j] = 0;
						}
					}
				}
				terrainData.SetDetailLayer(0, 0, i, detailLayer);
			}
		}

		private void DestroyDoorsAndWindows()
		{
			for (int num = FloorPlan.Items.Count - 1; num >= 0; num--)
			{
				RoomItem roomItem = FloorPlan.Items[num];
				RoomItemDefinition.Type itemType = roomItem.Definition.ItemType;
				if (itemType == RoomItemDefinition.Type.Door || itemType == RoomItemDefinition.Type.SideDoor || itemType == RoomItemDefinition.Type.Window)
				{
					if (roomItem.Visual != null)
					{
						roomItem.Visual.Destroy();
					}
					roomItem.RemoveFromWorld(updateNavigation: false);
					FloorPlan.RemoveItem(roomItem);
					roomItem.Destroy();
				}
			}
		}

		private void DestroyRedundantDoors()
		{
			RoomItemDefinition mainEntranceDefinition = Plot.GetMainEntranceDefinition(force: true);
			RoomItemDefinition sideEntranceDefinition = Plot.GetSideEntranceDefinition(force: true);
			RoomItemDefinition internalEntranceDefinition = Plot.GetInternalEntranceDefinition(force: true);
			for (int num = FloorPlan.Items.Count - 1; num >= 0; num--)
			{
				RoomItem roomItem = FloorPlan.Items[num];
				if (roomItem.Definition == mainEntranceDefinition || roomItem.Definition == sideEntranceDefinition || roomItem.Definition == internalEntranceDefinition)
				{
					if (roomItem.Visual != null)
					{
						roomItem.Visual.Destroy();
					}
					roomItem.RemoveFromWorld(updateNavigation: false);
					FloorPlan.RemoveItem(roomItem);
					roomItem.Destroy();
				}
			}
		}

		public void Merge(HospitalPlot plotToMerge, bool build = true)
		{
			if (_mergedPlots.AddUnique(plotToMerge))
			{
				if (plotToMerge.HospitalMap != null)
				{
					HospitalEntrances.AddRange(plotToMerge.HospitalMap.HospitalEntrances);
				}
				if (build)
				{
					CreateItems(HospitalPlotLayer.Built, restoringFromSave: false, plotToMerge.Definition.GetItems(HospitalPlotLayer.Built));
				}
			}
			MergeFloorImage(plotToMerge.Definition.FloorImage);
			if (build)
			{
				RebuildWalls();
			}
		}

		private void MergeFloorImage(Texture2D imageToMerge)
		{
			if (_floorImage == null)
			{
				Texture2D floorImage = Plot.Definition.FloorImage;
				_floorImage = new Texture2D(floorImage.width, floorImage.height, floorImage.format, mipChain: false);
				_floorImage.SetPixels32(floorImage.GetPixels32());
				_floorImage.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			}
			Color32[] pixels = _floorImage.GetPixels32();
			Color32[] pixels2 = imageToMerge.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				Color32 color = pixels[i];
				Color32 color2 = pixels2[i];
				color.r |= color2.r;
				color.g |= color2.g;
				color.b |= color2.b;
				color.a = byte.MaxValue;
				pixels[i] = color;
			}
			_floorImage.SetPixels32(pixels);
			_floorImage.Apply(updateMipmaps: false, makeNoLongerReadable: false);
		}

		public void RebuildWalls()
		{
			CreateIndoorState();
			FloorPlan.Tiles = (bool[,])IndoorState.Clone();
			GridBounds recalcBounds = new GridBounds(0, 0, _floorImage.width, _floorImage.height);
			recalcBounds.Grow(-2);
			DestroyDoorsAndWindows();
			AddWindowAndDoorItems(_floorImage);
			FloorPlan.Invert();
			FloorPlan.Walls = RoomAlgorithms.CalculateWalls(FloorPlan, recalcBounds, null, Plot.Definition.AmbulanceBayEntranceSide);
			if (FloorPlan.HasNoExteriorWalls())
			{
				HospitalNoWallFixups.FixupExteriorWalls(FloorPlan.Walls);
			}
			RemoveAdjoiningWalls(_floorImage, FloorPlan.Walls);
			_externalWalls = FloorPlan.Walls;
			FloorPlan.RecalculateBounds();
			FloorPlan.Invert();
			foreach (Room allRoom in _worldState.AllRooms)
			{
				FloorPlan floorPlan = allRoom.FloorPlan;
				if (floorPlan.Definition.IsHospitalOrBay || floorPlan.Definition.IsHospitalUnbuilt)
				{
					continue;
				}
				GridCoord anchor = floorPlan.Anchor;
				for (int i = 0; i < floorPlan.Height(); i++)
				{
					for (int j = 0; j < floorPlan.Width(); j++)
					{
						if (floorPlan[j, i])
						{
							int num = j + anchor.X;
							int num2 = i + anchor.Y;
							int x = num - Anchor.X;
							int y = num2 - Anchor.Y;
							FloorPlan[x, y] = false;
						}
					}
				}
			}
			RoomVisual.UpdateFromRoom(FloorPlan);
			CalculateCorridors(recalcBounds, animateWalls: false, null);
			BuildPerimeter();
			_worldState.UpdateNavigationFromHospitalMap(this);
			_worldState.UpdateNavigation();
			RebuildConnectedToDoorMap();
			_worldState.CalculateLighting();
			SellInvalidWallItems();
		}

		private void SellInvalidWallItems()
		{
			foreach (RoomItem item in RoomAlgorithms.ValidateRoomItems(ItemValidateMode.Set, null, FloorPlan, _worldState, null, null))
			{
				if (item.Cost != 0 && item.Definition.PlaceOnWall)
				{
					if (item.HasBeenPurchased)
					{
						_level.BuildEvents.OnRoomItemSold.InvokeSafe(item);
					}
					_level.BuildEvents.OnRoomItemDestroy.InvokeSafe(item);
				}
			}
		}

		public void CacheArrivalDeparturePositions()
		{
		}

		public bool PositionConnectsToArrivalsAndDepartures(Vector3 startWorldPos)
		{
			return true;
		}
	}
}
