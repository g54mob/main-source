using System.Collections.Generic;
using System.Threading.Tasks;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Motorways.UI;
using Motorways.Views.MeshGeneration;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Motorways.Views
{
	[SelectionBase]
	public class DraftDestination : MonoBehaviour, IReusable, ICreativeModeEditableObject
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DraftDestination");

		[SerializeField]
		private EditMenuButtonType _editOptions;

		[FormerlySerializedAs("BoatTerminalEditOptions")]
		[SerializeField]
		private EditMenuButtonType _boatTerminalEditOptions;

		[SerializeField]
		private MeshFilter _destinationMesh1;

		[SerializeField]
		private MeshFilter _destinationMesh2;

		[SerializeField]
		private DraftDestinationCarparkMeshes _carparkMeshes;

		[SerializeField]
		private RawImage _renderTextureImage;

		[SerializeField]
		private float _ghostPreviewNormalOpacity = 0.8f;

		[SerializeField]
		private float _ghostPreviewInvalidOpacity = 0.5f;

		[SerializeField]
		private Animator _animator;

		private IScope _scope;

		private Mesh _mesh;

		private bool _isConfirmable;

		private bool _hasOriginal;

		public readonly DraftDestinationCarparkViewModel viewModel = new DraftDestinationCarparkViewModel();

		private readonly DraftDestinationCarparkViewModel _originalViewModel = new DraftDestinationCarparkViewModel();

		private static readonly int TriggerRotateClockWise = Animator.StringToHash("RotateCW");

		private static readonly int TriggerRotateCounterClockWise = Animator.StringToHash("RotateCCW");

		private static readonly int TriggerFlipHorizontal = Animator.StringToHash("FlipHorizontal");

		private static readonly int TriggerFlipVertical = Animator.StringToHash("FlipVertical");

		public Vector2Int BottomLeftCoordinate => viewModel.bottomLeft;

		public bool IsDouble => viewModel.isDouble;

		public bool IsTrainStation => viewModel.isTrainStation;

		public bool IsBoatTerminal => viewModel.isBoatTerminal;

		public void Initialize(IScope scope, bool isDouble)
		{
			_scope = scope;
			_hasOriginal = false;
			viewModel.InitializeNew(isDouble, scope.Get<ColourWidget>().CurrentColour);
			_isConfirmable = true;
			UpdateView(isReplacement: false);
		}

		public void InitializeWithExistingView(IScope scope, DestinationView view)
		{
			_scope = scope;
			_hasOriginal = true;
			_isConfirmable = true;
			viewModel.InitializeExisting(view.Model);
			_originalViewModel.InitializeExisting(view.Model);
			UpdateView(isReplacement: true);
		}

		public void UpdatePosition(Vector2Int bottomLeftCoordinate, bool isReplacement)
		{
			viewModel.bottomLeft = bottomLeftCoordinate;
			Vector3 worldPositionForCoordinates = TilemapView.GetWorldPositionForCoordinates(bottomLeftCoordinate);
			base.transform.position = worldPositionForCoordinates;
			UpdateView(isReplacement);
		}

		public void Reset()
		{
			viewModel.Reset();
			_originalViewModel.Reset();
			_hasOriginal = false;
			_isConfirmable = true;
			Transform obj = base.transform;
			obj.localPosition = Vector3.zero;
			obj.localRotation = Quaternion.identity;
			obj.localScale = Vector3.one;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public Bounds GetBounds()
		{
			float num = (float)TilemapModel.TileWidth;
			Vector3 vector = ((!viewModel.isDouble) ? ((viewModel.buildingLayout == BuildingLayout.BuildingAbove) ? (viewModel.GetWorldPositionBuilding1() + new Vector3(0f - num, -2f * num)) : (viewModel.GetWorldPositionBuilding1() + new Vector3(-2f * num, 0f - num))) : ((viewModel.buildingLayout == BuildingLayout.BuildingAbove) ? (viewModel.GetWorldPositionBuilding1() + new Vector3(0f - num, -2f * num)) : (viewModel.GetWorldPositionBuilding2() + new Vector3(-2f * num, 0f - num))));
			Vector3 max = vector + ((!viewModel.isDouble) ? ((viewModel.buildingLayout == BuildingLayout.BuildingAbove) ? new Vector3(2f * num, 3f * num) : new Vector3(3f * num, 2f * num)) : ((viewModel.buildingLayout == BuildingLayout.BuildingAbove) ? new Vector3(4f * num, 3f * num) : new Vector3(3f * num, 4f * num)));
			return new Bounds
			{
				min = vector,
				max = max
			};
		}

		public void Delete(bool isReplacement)
		{
			if (!viewModel.isDouble || !viewModel.hasSecondDestination)
			{
				_scope.Release(this);
				return;
			}
			UpdateView(isReplacement);
			if (viewModel.activeBuilding == viewModel.building1)
			{
				RemoveFirstDestination(isReplacement);
			}
			else
			{
				RemoveSecondDestination(isReplacement);
			}
		}

		public bool IsConfirmable()
		{
			return _isConfirmable;
		}

		public BuildingLayout GetBuildingLayout()
		{
			return viewModel.buildingLayout;
		}

		public Vector2 GetWorldPosition()
		{
			return base.transform.position + (viewModel.isDouble ? new Vector3(2f, 3f) : new Vector3(2f, 0f));
		}

		public Vector2Int GetTilePosition()
		{
			return viewModel.bottomLeft;
		}

		public Vector2 GetCenterForEditMenuPosition()
		{
			Vector3 worldPositionForActiveBuilding = viewModel.GetWorldPositionForActiveBuilding();
			if (viewModel.isTrainStation && viewModel.carparkSide == TileDirection.North)
			{
				worldPositionForActiveBuilding += 0.75f * (float)TilemapModel.TileWidth * Vector3.up;
			}
			else if (viewModel.isTrainStation && viewModel.carparkSide == TileDirection.West)
			{
				worldPositionForActiveBuilding += 0.75f * (float)TilemapModel.TileWidth * Vector3.left;
			}
			return worldPositionForActiveBuilding;
		}

		public bool CompletelyOutOfPlayArea(City city)
		{
			if (city == null || viewModel == null)
			{
				return false;
			}
			for (int i = viewModel.minCoordinates.x; i <= viewModel.maxCoordinates.x; i++)
			{
				for (int j = viewModel.minCoordinates.y; j <= viewModel.maxCoordinates.y; j++)
				{
					if (city.IsTileInPlayableArea(new Vector2Int(i, j), Fix64.MaxValue))
					{
						return false;
					}
				}
			}
			return !city.IsTileInPlayableArea(viewModel.drivewayCoordinates, Fix64.MaxValue);
		}

		public EditMenuButtonType GetEditOptions()
		{
			if (IsBoatTerminal)
			{
				if (viewModel.isDouble && viewModel.hasSecondDestination)
				{
					return _boatTerminalEditOptions | EditMenuButtonType.Delete;
				}
				return _boatTerminalEditOptions;
			}
			return _editOptions;
		}

		public void Confirm()
		{
			if (Diagnostics.Verify(IsConfirmable(), "We should only confirm if the destination has a valid placement!"))
			{
				SpawnDestination(viewModel);
				_scope.Release(this);
			}
		}

		private void StartUnplaceableView()
		{
			Log.Info("Start unplaceable ghost view for" + ToString());
			_isConfirmable = false;
			_renderTextureImage.color = new Color(_renderTextureImage.color.r, _renderTextureImage.color.g, _renderTextureImage.color.b, _ghostPreviewInvalidOpacity);
		}

		private void EndUnplaceableView()
		{
			Log.Info("End unplaceable ghost view for" + ToString());
			_isConfirmable = true;
			_renderTextureImage.color = new Color(_renderTextureImage.color.r, _renderTextureImage.color.g, _renderTextureImage.color.b, _ghostPreviewNormalOpacity);
		}

		public void MakeDestinationTrainStation(bool isReplacement, TileDirection carparkSide)
		{
			viewModel.isTrainStation = true;
			viewModel.carparkSide = carparkSide;
			UpdateView(isReplacement);
		}

		public void MakeDestinationNotTrainStation(bool isReplacement)
		{
			viewModel.isTrainStation = false;
			if (viewModel.carparkSide == TileDirection.North || viewModel.carparkSide == TileDirection.East)
			{
				viewModel.carparkSide = TileUtilities.GetOppositeDirection(viewModel.carparkSide);
			}
			UpdateView(isReplacement);
		}

		private void SpawnDestination(DraftDestinationCarparkViewModel viewModel)
		{
			CityPlanModel.ScheduledBuilding scheduled = _scope.Get<CityPlanModel.ScheduledBuilding>();
			viewModel.BuildScheduled(viewModel.building1, ref scheduled);
			CityPlanModel cityPlanModel = _scope.Get<CityPlanModel>();
			cityPlanModel.ScheduleBuilding(scheduled);
			if (viewModel.hasSecondDestination)
			{
				CityPlanModel.ScheduledBuilding scheduled2 = _scope.Get<CityPlanModel.ScheduledBuilding>();
				viewModel.BuildScheduled(viewModel.building2, ref scheduled2);
				cityPlanModel.ScheduleBuilding(scheduled2);
			}
		}

		public void Cancel()
		{
			if (_hasOriginal)
			{
				SpawnDestination(_originalViewModel);
			}
			_scope.Release(this);
		}

		public int GetGroupIndex()
		{
			return viewModel.activeBuilding.groupIndex;
		}

		public void SetGroupIndex(int groupIndex, bool isReplacement)
		{
			viewModel.activeBuilding.groupIndex = groupIndex;
			UpdateView(isReplacement);
		}

		public ICreativeModeEditableObject GetGhostPreview(out bool isOriginalDeleted)
		{
			isOriginalDeleted = false;
			return this;
		}

		private void UpdateMesh(MeshFilter meshFilter, DestinationMesh.Type type, TileDirection direction, int groupIndex, int visualVariantIndex)
		{
			if (Diagnostics.Verify(meshFilter != null, "DestinationMesh is null, set it in prefab"))
			{
				DestinationMeshCombiner destinationMeshCombiner = _scope.Get<DestinationMeshCombiner>();
				if (Diagnostics.Verify(destinationMeshCombiner != null, "Cannot find DestinationMeshCombiner in scope"))
				{
					Mesh combinedMesh = destinationMeshCombiner.GetCombinedMesh(type, direction, groupIndex, visualVariantIndex);
					meshFilter.mesh = combinedMesh;
				}
			}
		}

		public void Flip(bool isReplacement)
		{
			if (Diagnostics.Verify(!viewModel.isDouble, "Flip called on a double destination, but it only makes sense on Single Destinations!"))
			{
				viewModel.singleDestinationAboveDrivewayDirections = ((viewModel.singleDestinationAboveDrivewayDirections != DrivewayDirection.East) ? DrivewayDirection.East : DrivewayDirection.West);
				viewModel.singleDestinationToSideDrivewayDirections = ((viewModel.singleDestinationToSideDrivewayDirections == DrivewayDirection.North) ? DrivewayDirection.South : DrivewayDirection.North);
				_animator.SetTrigger((viewModel.buildingLayout == BuildingLayout.BuildingAbove) ? TriggerFlipHorizontal : TriggerFlipVertical);
				UpdateView(isReplacement);
			}
		}

		public void UpgradeOrDowngrade(bool isReplacement)
		{
			viewModel.activeBuilding.upgradeLevel = ((viewModel.activeBuilding.upgradeLevel == 0) ? 1 : 0);
			UpdateView(isReplacement);
		}

		public void Rotate(bool isReplacement)
		{
			switch (viewModel.carparkSide)
			{
			case TileDirection.North:
				viewModel.carparkSide = TileDirection.West;
				_animator.SetTrigger(TriggerRotateCounterClockWise);
				break;
			case TileDirection.East:
				viewModel.carparkSide = TileDirection.South;
				_animator.SetTrigger(TriggerRotateClockWise);
				break;
			case TileDirection.South:
				viewModel.carparkSide = TileDirection.West;
				_animator.SetTrigger(TriggerRotateClockWise);
				break;
			case TileDirection.West:
				viewModel.carparkSide = TileDirection.South;
				_animator.SetTrigger(TriggerRotateCounterClockWise);
				break;
			default:
				Log.Error("Invalid carpark side {0}!", viewModel.carparkSide);
				break;
			}
			viewModel.buildingLayout = ((viewModel.buildingLayout == BuildingLayout.BuildingAbove) ? BuildingLayout.BuildingToSide : BuildingLayout.BuildingAbove);
			if (IsDouble && viewModel.hasSecondDestination && viewModel.activeBuilding == viewModel.building2)
			{
				if (viewModel.buildingLayout == BuildingLayout.BuildingToSide)
				{
					viewModel.bottomLeft += new Vector2Int(2, 2);
				}
				else
				{
					viewModel.bottomLeft += new Vector2Int(-2, -2);
				}
			}
			UpdateView(isReplacement);
		}

		private void UpdateView(bool isReplacement)
		{
			TileDirection? trainStationCarparkSide;
			bool flag = PlaceDestination(isReplacement, out trainStationCarparkSide);
			if (flag && !_isConfirmable)
			{
				EndUnplaceableView();
			}
			else if (!flag && _isConfirmable)
			{
				StartUnplaceableView();
			}
			EditMenuPanel editMenuPanel = _scope.Get<EditMenuPanel>();
			if (editMenuPanel.IsOpen && editMenuPanel.isActiveAndEnabled)
			{
				editMenuPanel.RefreshView();
			}
			if (trainStationCarparkSide.HasValue && (!viewModel.isTrainStation || viewModel.carparkSide != trainStationCarparkSide) && viewModel.isDouble)
			{
				MakeDestinationTrainStation(isReplacement, trainStationCarparkSide.Value);
			}
			else if (!trainStationCarparkSide.HasValue && viewModel.isTrainStation && viewModel.isDouble)
			{
				MakeDestinationNotTrainStation(isReplacement);
			}
			DrivewayDirection drivewayDirection = ((viewModel.buildingLayout == BuildingLayout.BuildingAbove) ? viewModel.singleDestinationAboveDrivewayDirections : viewModel.singleDestinationToSideDrivewayDirections);
			_carparkMeshes.SetVisibleCarparkMesh(viewModel.isDouble, drivewayDirection, viewModel.carparkSide, viewModel.isBoatTerminal, viewModel.activeBuilding == viewModel.building2);
			DraftDestinationBuildingViewModel building = viewModel.building1;
			_destinationMesh1.gameObject.SetActive(value: true);
			_destinationMesh1.transform.localPosition = viewModel.GetLocalPositionBuilding1();
			base.transform.position = viewModel.GetWorldPositionForActiveBuilding();
			UpdateMesh(_destinationMesh1, building.GetMeshType(viewModel.isTrainStation, viewModel.buildingLayout), viewModel.carparkSide, building.groupIndex, 0);
			bool flag2 = viewModel.isDouble && viewModel.hasSecondDestination;
			_destinationMesh2.gameObject.SetActive(flag2);
			if (flag2)
			{
				DraftDestinationBuildingViewModel building2 = viewModel.building2;
				_destinationMesh2.transform.localPosition = viewModel.GetLocalPositionBuilding2();
				UpdateMesh(_destinationMesh2, building2.GetMeshType(viewModel.isTrainStation, viewModel.buildingLayout), viewModel.carparkSide, building2.groupIndex, 0);
			}
		}

		private async Task RemoveFirstDestination(bool isPreplacement, bool animation = true)
		{
			viewModel.RemoveBuilding(viewModel.building1);
			if (animation)
			{
				await ShiftingAnimation();
			}
			UpdateView(isPreplacement);
			SpawnDestination(viewModel);
			_scope.Release(this);
		}

		private async Task RemoveSecondDestination(bool isPreplacement, bool animation = true)
		{
			viewModel.RemoveBuilding(viewModel.building2);
			if (animation)
			{
				await ShrinkingAnimation(_destinationMesh2);
			}
			UpdateView(isPreplacement);
			SpawnDestination(viewModel);
			_scope.Release(this);
		}

		private async Task ShiftingAnimation()
		{
			await ShrinkingAnimation(_destinationMesh1);
			Vector3 startPosition = _destinationMesh2.transform.localPosition;
			Vector3 endPosition = _destinationMesh1.transform.localPosition;
			float duration = 0.25f;
			float elapsedTime = 0f;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				float t = Mathf.Clamp01(elapsedTime / duration);
				_destinationMesh2.transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);
				await Task.Yield();
			}
		}

		private async Task ShrinkingAnimation(MeshFilter meshFilter)
		{
			Vector3 startScale = meshFilter.transform.localScale;
			Vector3 endScale = new Vector3(0.1f, 0.1f, 0.1f);
			float duration = 0.15f;
			float elapsedTime = 0f;
			while (elapsedTime < duration)
			{
				elapsedTime += Time.deltaTime;
				float t = Mathf.Clamp01(elapsedTime / duration);
				meshFilter.transform.localScale = Vector3.Lerp(startScale, endScale, t);
				await Task.Yield();
			}
			meshFilter.gameObject.SetActive(value: false);
			meshFilter.transform.localScale = startScale;
		}

		private bool PlaceDestination(bool isReplacement, out TileDirection? trainStationCarparkSide)
		{
			bool flag = true;
			string errorMessage = "";
			City city = _scope.Get<City>();
			TilemapModel tilemapModel = _scope.Get<TilemapModel>();
			TilemapView tilemapView = _scope.Get<TilemapView>();
			Fix64 expansionTime = _scope.Get<ClockModel>().ExpansionTime;
			Vector2Int drivewayCoordinates = viewModel.drivewayCoordinates;
			Vector2Int secondDrivewayCoordinates = viewModel.secondDrivewayCoordinates;
			Vector2Int minCoordinates = viewModel.minCoordinates;
			Vector2Int maxCoordinates = viewModel.maxCoordinates;
			List<Vector2Int> list = new List<Vector2Int>();
			trainStationCarparkSide = null;
			if (viewModel.SetCoordinateData(ref errorMessage))
			{
				for (int i = viewModel.minCoordinates.x; i <= viewModel.maxCoordinates.x; i++)
				{
					for (int j = viewModel.minCoordinates.y; j <= viewModel.maxCoordinates.y; j++)
					{
						Vector2Int vector2Int = new Vector2Int(i, j);
						Vector2Int vector2Int2;
						if (!city.Definition.TileIsBuildable(vector2Int) || city.Definition.TileIsOverWater(vector2Int) || city.Definition.TileIsUnderAMountain(vector2Int))
						{
							vector2Int2 = vector2Int;
							errorMessage = "Can't place destination over tile at " + vector2Int2.ToString() + " because it's " + ((!city.Definition.TileIsBuildable(vector2Int)) ? " not buildable" : "Water or Mountain");
							flag = false;
						}
						Tile tile = tilemapView.GetTile(vector2Int);
						if (tile != null && (tile.IsCenterOfRoundabout || tile.HasRoundabout(RoadState.VisiblyActive | RoadState.Mothballed)))
						{
							Log.Info("Cannot build destination on tile {0} as it contains a roundabout", tile.Coordinates);
							flag = false;
						}
						if (tile != null && tile.HasRailConnection)
						{
							list.Add(vector2Int);
						}
						if (tile != null && tile.ContentType != TileContentType.None)
						{
							if (isReplacement)
							{
								TileContentType contentType = tile.ContentType;
								if ((contentType == TileContentType.Destination || contentType == TileContentType.Carpark) && vector2Int.x >= minCoordinates.x && vector2Int.x <= maxCoordinates.x && vector2Int.y >= minCoordinates.y && vector2Int.y <= maxCoordinates.y)
								{
									Log.Info("Allowing placement over {0} because it's the old self which hasn't deleted yet.", vector2Int);
									continue;
								}
							}
							if (tile.ContentType == TileContentType.Tree && city.Rules.ShouldBuildingsBulldozeTrees)
							{
								Log.Info("Allowing placement over tree at {0} as this will get bulldozed", vector2Int);
								continue;
							}
							vector2Int2 = vector2Int;
							errorMessage = "Can't place destination over tile at " + vector2Int2.ToString() + " with content type " + tile.ContentType;
							flag = false;
						}
						int num = tile?.GetTwoLaneRoadCount(RoadState.VisiblyActive | RoadState.Mothballed, Tile.MotorwayInclusion.Include) ?? 0;
						if (tile == null || num <= 0)
						{
							continue;
						}
						if (isReplacement)
						{
							TileDirection direction = ((viewModel.DrivewayDirection != TileDirection.East) ? TileDirection.East : TileDirection.North);
							if (num == 1 && vector2Int == drivewayCoordinates)
							{
								TileDirectionBitfield twoLaneRoads = tile.GetTwoLaneRoads();
								if (vector2Int == drivewayCoordinates && twoLaneRoads[direction])
								{
									Log.Info("Allowing placement at {0} because the only lane is the old driveway", vector2Int);
									continue;
								}
							}
							else if (num == 1 && IsDouble && vector2Int == secondDrivewayCoordinates)
							{
								TileDirectionBitfield twoLaneRoads2 = tile.GetTwoLaneRoads();
								if (vector2Int == secondDrivewayCoordinates && twoLaneRoads2[TileUtilities.GetOppositeDirection(direction)])
								{
									Log.Info("Allowing placement at {0} because the only lane is the old (second) driveway", vector2Int);
									continue;
								}
							}
						}
						string[] obj = new string[5] { "Can't place destination over tile at ", null, null, null, null };
						vector2Int2 = vector2Int;
						obj[1] = vector2Int2.ToString();
						obj[2] = " because it has ";
						obj[3] = num.ToString();
						obj[4] = " roads";
						errorMessage = string.Concat(obj);
						flag = false;
					}
				}
				flag &= list.Count == 0 || list.Count == 4;
				if ((1u | (flag ? 1u : 0u)) != 0 && list.Count == 4)
				{
					foreach (Vector2Int item in list)
					{
						if (viewModel.buildingLayout == BuildingLayout.BuildingAbove)
						{
							if (item.y == viewModel.minCoordinates.y)
							{
								if (!trainStationCarparkSide.HasValue)
								{
									trainStationCarparkSide = TileDirection.North;
								}
								else if (trainStationCarparkSide != TileDirection.North)
								{
									Log.Info("Not making train station at {0} because train track at {1} is not at the correct y coordinate {2}", viewModel.minCoordinates, item, viewModel.minCoordinates.y + 2);
									flag = false;
									trainStationCarparkSide = null;
									break;
								}
								continue;
							}
							if (item.y != viewModel.minCoordinates.y + 2)
							{
								Log.Info("Not making train station at {0} because train track at {1} is not at a y coordinate {2} or {3}", viewModel.minCoordinates, item, viewModel.minCoordinates.y, viewModel.minCoordinates.y + 2);
								flag = false;
								trainStationCarparkSide = null;
								break;
							}
							if (!trainStationCarparkSide.HasValue)
							{
								trainStationCarparkSide = TileDirection.South;
							}
							else if (trainStationCarparkSide != TileDirection.South)
							{
								Log.Info("Not making train station at {0} because train track at {1} is not at the correct y coordinate {2}", viewModel.minCoordinates, item, viewModel.minCoordinates.y);
								flag = false;
								trainStationCarparkSide = null;
								break;
							}
						}
						else
						{
							if (viewModel.buildingLayout != BuildingLayout.BuildingToSide)
							{
								continue;
							}
							if (item.x == viewModel.minCoordinates.x)
							{
								if (!trainStationCarparkSide.HasValue)
								{
									trainStationCarparkSide = TileDirection.East;
								}
								else if (trainStationCarparkSide != TileDirection.East)
								{
									Log.Info("Not making train station at {0} because train track at {1} is not at the correct x coordinate {2}", viewModel.minCoordinates, item, viewModel.minCoordinates.x + 2);
									flag = false;
									trainStationCarparkSide = null;
									break;
								}
								continue;
							}
							if (item.x != viewModel.minCoordinates.x + 2)
							{
								Log.Info("Not making train station at {0} because train track at {1} is not at a x coordinate {2} or {3}", viewModel.minCoordinates, item, viewModel.minCoordinates.x, viewModel.minCoordinates.x + 2);
								flag = false;
								trainStationCarparkSide = null;
								break;
							}
							if (!trainStationCarparkSide.HasValue)
							{
								trainStationCarparkSide = TileDirection.West;
							}
							else if (trainStationCarparkSide != TileDirection.West)
							{
								Log.Info("Not making train station at {0} because train track at {1} is not at the correct x coordinate {2}", viewModel.minCoordinates, item, viewModel.minCoordinates.x);
								flag = false;
								trainStationCarparkSide = null;
								break;
							}
						}
					}
				}
				TileDirection? tileDirection = trainStationCarparkSide;
				if (tileDirection.HasValue && tileDirection.GetValueOrDefault() == TileDirection.North)
				{
					viewModel.drivewayCoordinates += 2 * Vector2Int.up;
					viewModel.secondDrivewayCoordinates += 2 * Vector2Int.up;
				}
				else
				{
					tileDirection = trainStationCarparkSide;
					if (tileDirection.HasValue && tileDirection == TileDirection.East)
					{
						viewModel.drivewayCoordinates += 2 * Vector2Int.right;
						viewModel.secondDrivewayCoordinates += 2 * Vector2Int.right;
					}
				}
				if (city.IsTileInPlayableArea(viewModel.minCoordinates, expansionTime) && city.IsTileInPlayableArea(viewModel.maxCoordinates, expansionTime) && city.IsTileInPlayableArea(viewModel.drivewayCoordinates, expansionTime) && (!viewModel.isDouble || city.IsTileInPlayableArea(viewModel.secondDrivewayCoordinates, expansionTime)))
				{
					Tile tile2 = tilemapView.GetTile(viewModel.drivewayCoordinates);
					TileContentType tileContentType = tile2?.ContentType ?? TileContentType.None;
					if (tileContentType != TileContentType.None)
					{
						if (isReplacement && (tileContentType == TileContentType.Destination || tileContentType == TileContentType.Carpark) && viewModel.drivewayCoordinates.x >= minCoordinates.x && viewModel.drivewayCoordinates.x <= maxCoordinates.x && viewModel.drivewayCoordinates.y >= minCoordinates.y && viewModel.drivewayCoordinates.y <= maxCoordinates.y)
						{
							Log.Info("Allowing driveway over {0} because it's the old self which hasn't deleted yet.", viewModel.drivewayCoordinates);
						}
						else if (tileContentType == TileContentType.Tree && city.Rules.ShouldBuildingsBulldozeTrees)
						{
							Log.Info("Allowing placement over tree at {0} as this will get bulldozed", viewModel.drivewayCoordinates);
						}
						else
						{
							Vector2Int vector2Int2 = viewModel.drivewayCoordinates;
							errorMessage = "Not allowing placement at " + vector2Int2.ToString() + " because driveway tile has content type " + tileContentType;
							flag = false;
						}
					}
					else if (tile2 != null && tile2.HasRailConnection)
					{
						Vector2Int vector2Int2 = viewModel.drivewayCoordinates;
						errorMessage = "Not allowing placement at " + vector2Int2.ToString() + " because driveway tile has rail connection";
						flag = false;
					}
					else
					{
						Tile tile3 = tilemapView.GetTile(viewModel.secondDrivewayCoordinates);
						TileContentType tileContentType2 = tile3?.ContentType ?? TileContentType.None;
						if (viewModel.isDouble && tileContentType2 != TileContentType.None)
						{
							if (isReplacement && (tileContentType2 == TileContentType.Destination || tileContentType2 == TileContentType.Carpark) && viewModel.secondDrivewayCoordinates.x >= minCoordinates.x && viewModel.secondDrivewayCoordinates.x <= maxCoordinates.x && viewModel.secondDrivewayCoordinates.y >= minCoordinates.y && viewModel.secondDrivewayCoordinates.y <= maxCoordinates.y)
							{
								Log.Info("Allowing second driveway over {0} because it's the old self which hasn't deleted yet.", viewModel.drivewayCoordinates);
							}
							else if (tileContentType2 == TileContentType.Tree && city.Rules.ShouldBuildingsBulldozeTrees)
							{
								Log.Info("Allowing placement over tree at {0} as this will get bulldozed", viewModel.secondDrivewayCoordinates);
							}
							else
							{
								Vector2Int vector2Int2 = viewModel.secondDrivewayCoordinates;
								errorMessage = "Not allowing placement at " + vector2Int2.ToString() + " because second driveway tile has content type " + tileContentType2;
								flag = false;
							}
						}
						else if (viewModel.isDouble && tile3 != null && tile3.HasRailConnection)
						{
							Vector2Int vector2Int2 = viewModel.secondDrivewayCoordinates;
							errorMessage = "Not allowing placement at " + vector2Int2.ToString() + " because second driveway tile has rail connection";
							flag = false;
						}
					}
					if (!city.Definition.TileIsBuildable(viewModel.drivewayCoordinates) || city.Definition.TileIsOverWater(viewModel.drivewayCoordinates) || city.Definition.TileIsUnderAMountain(viewModel.drivewayCoordinates))
					{
						Vector2Int vector2Int2 = viewModel.drivewayCoordinates;
						errorMessage = "Can't place destination driveway over tile at " + vector2Int2.ToString() + " because it's " + (tilemapModel.IsTileReserved(viewModel.drivewayCoordinates) ? "Reserved" : "Water or Mountain");
						flag = false;
					}
					if (viewModel.isDouble && (!city.Definition.TileIsBuildable(viewModel.secondDrivewayCoordinates) || city.Definition.TileIsOverWater(viewModel.secondDrivewayCoordinates) || city.Definition.TileIsUnderAMountain(viewModel.secondDrivewayCoordinates)))
					{
						Vector2Int vector2Int2 = viewModel.secondDrivewayCoordinates;
						errorMessage = "Can't place destination driveway over tile at " + vector2Int2.ToString() + " because it's " + ((!city.Definition.TileIsBuildable(viewModel.secondDrivewayCoordinates)) ? "Not buildable" : "Water or Mountain");
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
			}
			if (errorMessage != "")
			{
				Diagnostics.Log.Info("DraftDestination", errorMessage);
			}
			return flag;
		}
	}
}
