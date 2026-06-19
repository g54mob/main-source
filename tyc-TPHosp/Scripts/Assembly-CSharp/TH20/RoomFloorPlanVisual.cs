using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class RoomFloorPlanVisual : MustCallDestroy
	{
		private readonly string _roomName;

		private readonly GameObject _floorTilePrefab;

		protected RoomWallDefinition _wallDefinition;

		private readonly VisualManager _visualManager;

		private readonly BuildEvents _buildEvents;

		private readonly Material _valueMaterial;

		private readonly RoomItemVisualEdit.Config _roomItemEditConfig;

		private WorldState _worldState;

		protected FloorPlan _floorPlan;

		private Vector3 _origin;

		[DontSave]
		private MaterialPropertyBlock _sharedMaterialPropertyBlock;

		[DontSave]
		private Transform _container;

		[DontSave]
		protected Transform _wallsContainer;

		[DontSave]
		protected Transform _floorsContainer;

		[DontSave]
		protected List<Transform> _floorTileObjects;

		[DontSave]
		protected List<Renderer> _floorTileRenderers;

		private int _previousNumActiveFloorTileObjects;

		[DontSave]
		protected List<KeyValuePair<Transform, Transform>> _wallObjects;

		[DontSave]
		private List<KeyValuePair<Transform, Transform>> _inactiveWallObjects;

		[DontSave]
		protected List<Transform> _activeWallBackPieces;

		[DontSave]
		private List<RoomItemVisual> _roomItems;

		private IFloorVisualOverrideDefinition _floorVisualOverride;

		private IWallVisualOverrideDefinition _wallVisualOverride;

		private string _debugName;

		private static int _roomID;

		[DontSave]
		public static bool ShouldAddBackFaceProgrammatically = true;

		private static Vector2[] WallOffsets = new Vector2[5]
		{
			Vector2.zero,
			Vector2.left,
			Vector2.right,
			Vector2.down,
			Vector2.up
		};

		private static readonly int OutdoorLayer = LayerMask.NameToLayer("Outdoor");

		public IFloorVisualOverrideDefinition FloorVisualOverride
		{
			get
			{
				return _floorVisualOverride;
			}
			set
			{
				_floorVisualOverride = value;
				_sharedMaterialPropertyBlock.Clear();
				if (_floorVisualOverride != null && _floorVisualOverride.GetDiffuseTexture() != null)
				{
					_sharedMaterialPropertyBlock.SetTexture("_MainTex", _floorVisualOverride.GetDiffuseTexture());
					SetDefaultMaterialValues(_sharedMaterialPropertyBlock);
				}
				foreach (Renderer floorTileRenderer in _floorTileRenderers)
				{
					floorTileRenderer.SetPropertyBlock(_sharedMaterialPropertyBlock);
				}
			}
		}

		public IWallVisualOverrideDefinition WallVisualOverride
		{
			get
			{
				return _wallVisualOverride;
			}
			set
			{
				_wallVisualOverride = value;
				_sharedMaterialPropertyBlock.Clear();
				if (_wallVisualOverride != null && _wallVisualOverride.GetDiffuseTexture() != null)
				{
					_sharedMaterialPropertyBlock.SetTexture("_MainTex", _wallVisualOverride.GetDiffuseTexture());
					SetDefaultMaterialValues(_sharedMaterialPropertyBlock);
				}
				for (int i = 0; i < _wallObjects.Count; i++)
				{
					Transform key = _wallObjects[i].Key;
					SetPropertyBlockOnWall(key.gameObject, _sharedMaterialPropertyBlock);
				}
			}
		}

		public GameObject GameObject
		{
			get
			{
				if (!(_container != null))
				{
					return null;
				}
				return _container.gameObject;
			}
		}

		public Transform WallsContainer => _wallsContainer;

		public List<RoomItemVisual> RoomItems => _roomItems;

		public RoomFloorPlanVisual(WorldState worldState, VisualManager visualManager, string roomName, GameObject floorTilePrefab, Material valueMaterial, RoomItemVisualEdit.Config roomItemEditConfig, RoomWallDefinition wallDefinition, BuildEvents buildEvents)
		{
			_worldState = worldState;
			_roomName = roomName;
			_visualManager = visualManager;
			_buildEvents = buildEvents;
			_floorTilePrefab = floorTilePrefab;
			_wallDefinition = wallDefinition;
			_valueMaterial = valueMaterial;
			_roomItemEditConfig = roomItemEditConfig;
			_sharedMaterialPropertyBlock = new MaterialPropertyBlock();
			_debugName = "Room_" + _roomID.ToString().PadLeft(3, '0') + ": " + _roomName;
			_roomID++;
			CreateGameObjects();
		}

		public void RestoreFromSave(WorldState worldState, Level level)
		{
			if (_floorVisualOverride is FloorVisualOverrideDefinitionUGC)
			{
				((FloorVisualOverrideDefinitionUGC)_floorVisualOverride).RestoreFromSave(level.App.UGCFloorVisualOverrideDefinitionDatabase);
			}
			if (_wallVisualOverride is WallVisualOverrideDefinitionUGC)
			{
				((WallVisualOverrideDefinitionUGC)_wallVisualOverride).RestoreFromSave(level.App.UGCWallVisualOverrideDefinitionDatabase);
			}
			_worldState = worldState;
			_sharedMaterialPropertyBlock = new MaterialPropertyBlock();
			CreateGameObjects();
			CreateFloorTileObjects();
			CreateWallObjects(restoringFromSave: true);
			CreateRoomItems(default(Vector3), 0f, level);
		}

		private void CreateGameObjects()
		{
			_container = new GameObject(_debugName).transform;
			_wallsContainer = new GameObject("Walls").transform;
			_wallsContainer.SetParent(_container);
			_floorsContainer = new GameObject("Floors").transform;
			_floorsContainer.SetParent(_container);
			_floorTileObjects = new List<Transform>();
			_floorTileRenderers = new List<Renderer>();
			_wallObjects = new List<KeyValuePair<Transform, Transform>>();
			_inactiveWallObjects = new List<KeyValuePair<Transform, Transform>>();
			_activeWallBackPieces = new List<Transform>();
			_roomItems = new List<RoomItemVisual>();
			_container.position = _origin;
		}

		public override void Destroy()
		{
			DestroyMaterials(_wallObjects);
			DestroyMaterials(_inactiveWallObjects);
			if (_roomItems != null)
			{
				_roomItems.ClearAndCallDestroy();
			}
			if (_container != null)
			{
				UnityEngine.Object.Destroy(_container.gameObject);
			}
			base.Destroy();
		}

		private void DestroyMaterials(List<KeyValuePair<Transform, Transform>> objects)
		{
			if (objects == null)
			{
				return;
			}
			foreach (KeyValuePair<Transform, Transform> @object in objects)
			{
				Transform key = @object.Key;
				Transform value = @object.Value;
				if (key != null)
				{
					MeshRenderer component = key.GetComponent<MeshRenderer>();
					if (component != null)
					{
						Material[] materials = component.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							UnityEngine.Object.Destroy(materials[i]);
						}
					}
				}
				if (!(value != null))
				{
					continue;
				}
				MeshRenderer component2 = value.GetComponent<MeshRenderer>();
				if (component2 != null)
				{
					Material[] materials = component2.materials;
					for (int i = 0; i < materials.Length; i++)
					{
						UnityEngine.Object.Destroy(materials[i]);
					}
				}
			}
		}

		public virtual void UpdateFromRoom(FloorPlan floorPlan, Vector3 cellOffset = default(Vector3), float rotationOffset = 0f)
		{
			_floorPlan = floorPlan;
			_origin = floorPlan.WorldBounds.Center.ToWorldPosition();
			_container.position = _origin + cellOffset;
			_container.rotation = Quaternion.Euler(0f, rotationOffset, 0f);
			CreateFloorTileObjects();
			CreateWallObjects(restoringFromSave: false);
			CreateRoomItems(cellOffset, rotationOffset);
		}

		public void CreateWallObjects(bool restoringFromSave, bool animateWalls = false, Vector3 animateAnchor = default(Vector3))
		{
			List<WallCoord> walls = _floorPlan.Walls;
			List<Matrix4x4> list = new List<Matrix4x4>();
			if (animateWalls)
			{
				foreach (KeyValuePair<Transform, Transform> wallObject in _wallObjects)
				{
					list.Add(wallObject.Key.localToWorldMatrix);
				}
			}
			while (_wallObjects.Count > walls.Count)
			{
				KeyValuePair<Transform, Transform> item = _wallObjects[_wallObjects.Count - 1];
				_wallObjects.RemoveAt(_wallObjects.Count - 1);
				_inactiveWallObjects.Add(item);
				GameObjectUtils.SetActive(item.Key.gameObject, isActive: false);
			}
			while (_wallObjects.Count < walls.Count && _inactiveWallObjects.Count != 0)
			{
				_wallObjects.Add(_inactiveWallObjects[_inactiveWallObjects.Count - 1]);
				_inactiveWallObjects.RemoveAt(_inactiveWallObjects.Count - 1);
			}
			GameObject backPieceWall = _wallDefinition.GetBackPieceWall();
			GameObject backPieceWindow = _wallDefinition.GetBackPieceWindow();
			if (_wallVisualOverride != null)
			{
				_sharedMaterialPropertyBlock.Clear();
				if (_wallVisualOverride.GetDiffuseTexture() != null)
				{
					_sharedMaterialPropertyBlock.SetTexture("_MainTex", _wallVisualOverride.GetDiffuseTexture());
					SetDefaultMaterialValues(_sharedMaterialPropertyBlock);
				}
			}
			for (int i = _wallObjects.Count; i < walls.Count; i++)
			{
				GameObject gameObject = MeshUtils.CreateStaticMeshObject();
				gameObject.name = "Wall";
				gameObject.transform.SetParent(_wallsContainer, worldPositionStays: false);
				Transform transform = MeshUtils.CreateStaticMeshObject().transform;
				transform.gameObject.name = "Wall Back";
				transform.SetParent(gameObject.transform, worldPositionStays: false);
				MeshUtils.SetStaticMeshFromPrefab(transform.gameObject, backPieceWall);
				transform.GetComponentInChildren<MeshRenderer>().shadowCastingMode = _wallDefinition.WallShadowCastingMode;
				GameObjectUtils.SetActive(transform.gameObject, ShouldAddBackFaceProgrammatically);
				_wallObjects.Add(new KeyValuePair<Transform, Transform>(gameObject.transform, transform));
			}
			List<Bounds> list2 = new List<Bounds>();
			if (_floorPlan.Door != null && !(this is BlueprintFloorPlanVisual) && _floorPlan.Door.TryGetClipBounds(out var clipBounds))
			{
				Vector3 translation = ((_floorPlan.Door.Visual != null) ? _floorPlan.Door.Visual.WorldPosition : _floorPlan.Door.WorldPosition);
				list2.Add(clipBounds.Transform(translation, Quaternion.Euler(0f, _floorPlan.Door.Rotation, 0f)));
			}
			_activeWallBackPieces.Clear();
			GridCoord anchor = _floorPlan.Anchor;
			for (int num = walls.Count - 1; num >= 0; num--)
			{
				WallCoord wallCoord = walls[num];
				Transform key = _wallObjects[num].Key;
				Vector3 vector = GridCoord.GridCoordToWorldPosition(anchor.X + wallCoord._position.X, anchor.Y + wallCoord._position.Y);
				key.localPosition = vector - _origin + wallCoord._rotation.DirectionVector() * 2f * 0.5f;
				key.localEulerAngles = new Vector3(0f, wallCoord._rotation.YawRotation(), 0f);
				GameObject piece = _wallDefinition.GetPiece(wallCoord._type);
				bool flag = MeshUtils.SetStaticMeshFromPrefab(key.gameObject, piece);
				GameObjectUtils.SetActive(key.gameObject, flag);
				if (flag)
				{
					key.gameObject.layer = piece.layer;
					key.GetComponent<MeshRenderer>().shadowCastingMode = _wallDefinition.WallShadowCastingMode;
					Transform value = _wallObjects[num].Value;
					if (value != null)
					{
						bool flag2 = wallCoord.RequiresBackPiece() && ShouldAddBackFaceProgrammatically && !restoringFromSave;
						GameObjectUtils.SetActive(value.gameObject, flag2);
						if (flag2)
						{
							MeshUtils.SetStaticMeshFromPrefab(value.gameObject, wallCoord.IsWindow() ? backPieceWindow : backPieceWall);
							value.gameObject.layer = piece.layer;
							value.gameObject.GetOrAddComponent<HideBackPieceGameObjectComponent>();
							if (wallCoord.IsWall() || wallCoord.IsWindow())
							{
								_activeWallBackPieces.Add(value);
							}
						}
					}
				}
				else
				{
					_inactiveWallObjects.Add(_wallObjects[num]);
					_wallObjects.RemoveAt(num);
				}
				if (list2.Count > 0)
				{
					foreach (Bounds item2 in list2)
					{
						List<MeshRenderer> list3 = new List<MeshRenderer>();
						key.GetComponentsInChildren(list3);
						foreach (MeshRenderer item3 in list3)
						{
							if (!item2.Intersects(item3.bounds))
							{
								continue;
							}
							Material[] sharedMaterials = item3.sharedMaterials;
							for (int j = 0; j < sharedMaterials.Length; j++)
							{
								if (!sharedMaterials[j].name.Contains("M_Wall_Top"))
								{
									Material material = new Material(sharedMaterials[j]);
									material.EnableKeyword("_AACLIPBOX_ON");
									material.SetVector("_AAClipBoxPos", item2.center);
									material.SetVector("_AAClipBoxExtents", item2.extents);
									sharedMaterials[j] = material;
								}
							}
							item3.sharedMaterials = sharedMaterials;
						}
					}
				}
				if (_wallVisualOverride != null)
				{
					SetPropertyBlockOnWall(key.gameObject, _sharedMaterialPropertyBlock);
				}
			}
			if (animateWalls)
			{
				foreach (KeyValuePair<Transform, Transform> wallObject2 in _wallObjects)
				{
					bool flag3 = false;
					Transform key2 = wallObject2.Key;
					Transform value2 = wallObject2.Value;
					foreach (Matrix4x4 item4 in list)
					{
						Vector4 column = item4.GetColumn(3);
						if (Math.Abs(key2.position.x - column.x) < 0.001f && Math.Abs(key2.position.z - column.z) < 0.001f && key2.rotation == item4.rotation)
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						SetMaterialBuildParams(animateAnchor, key2.GetComponent<Renderer>());
						if (value2 != null)
						{
							SetMaterialBuildParams(animateAnchor, value2.GetComponent<Renderer>());
						}
					}
				}
			}
			if (_floorPlan.Definition == null || !_floorPlan.Definition.IsLowWallRoom() || _floorPlan.HospitalMap == null || !_floorPlan.HospitalMap.FloorPlan.HasNoExteriorWalls())
			{
				return;
			}
			foreach (KeyValuePair<Transform, Transform> wallObject3 in _wallObjects)
			{
				Transform key3 = wallObject3.Key;
				Transform value3 = wallObject3.Value;
				if (key3.gameObject.layer != OutdoorLayer)
				{
					key3.gameObject.layer = OutdoorLayer;
				}
				if (value3.gameObject.layer != OutdoorLayer)
				{
					value3.gameObject.layer = OutdoorLayer;
				}
			}
		}

		public void CreateFloorTileObjects(GameObject floorTilePrefabOverride = null)
		{
			if (floorTilePrefabOverride == null && _floorTilePrefab == null)
			{
				return;
			}
			GameObject original = ((floorTilePrefabOverride != null) ? floorTilePrefabOverride : _floorTilePrefab);
			int num = 0;
			for (int i = 0; i < _floorPlan.Height(); i++)
			{
				for (int j = 0; j < _floorPlan.Width(); j++)
				{
					if (_floorPlan[j, i])
					{
						num++;
					}
				}
			}
			for (int k = _previousNumActiveFloorTileObjects; k < _floorTileObjects.Count; k++)
			{
				_floorTileObjects[k].gameObject.SetActive(value: true);
			}
			List<Renderer> list = new List<Renderer>();
			for (int l = _floorTileObjects.Count; l < num; l++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(original);
				gameObject.transform.SetParent(_floorsContainer, worldPositionStays: false);
				gameObject.name = "Floor tile";
				_floorTileObjects.Add(gameObject.transform);
				gameObject.GetComponentsInChildren(includeInactive: false, list);
				if (list.Count > 0)
				{
					_floorTileRenderers.Add(list[0]);
				}
			}
			_previousNumActiveFloorTileObjects = num;
			for (int m = num; m < _floorTileObjects.Count; m++)
			{
				_floorTileObjects[m].gameObject.SetActive(value: false);
			}
			int num2 = 0;
			GridCoord anchor = _floorPlan.Anchor;
			_sharedMaterialPropertyBlock.Clear();
			if (_floorVisualOverride != null && _floorVisualOverride.GetDiffuseTexture() != null)
			{
				_sharedMaterialPropertyBlock.SetTexture("_MainTex", _floorVisualOverride.GetDiffuseTexture());
				SetDefaultMaterialValues(_sharedMaterialPropertyBlock);
			}
			for (int n = 0; n < _floorPlan.Height(); n++)
			{
				for (int num3 = 0; num3 < _floorPlan.Width(); num3++)
				{
					if (_floorPlan[num3, n])
					{
						_floorTileObjects[num2].localScale = new Vector3(2f, 1f, 2f);
						_floorTileObjects[num2].localPosition = GridCoord.GridCoordToWorldPosition(anchor.X + num3, anchor.Y + n) - _origin;
						if (_floorTileRenderers.Count > num2)
						{
							_floorTileRenderers[num2].SetPropertyBlock(_sharedMaterialPropertyBlock);
						}
						num2++;
					}
				}
			}
		}

		public void CreateRoomItems(Vector3 cellOffset = default(Vector3), float rotationOffset = 0f, Level levelBeingLoaded = null)
		{
			bool flag = this is BlueprintFloorPlanVisual;
			_roomItems.Clear();
			for (int num = _floorPlan.Items.Count - 1; num >= 0; num--)
			{
				if (MathUtils.IsInRange(num, 0, _floorPlan.Items.Count - 1))
				{
					RoomItem roomItem = _floorPlan.Items[num];
					if (roomItem.Visual == null)
					{
						GameObject prefab = (flag ? roomItem.BlueprintPrefab : roomItem.Prefab);
						GameObject addOnPrefab = (flag ? roomItem.UpgradeAddOnBlueprintPrefab : roomItem.UpgradeAddOnPrefab);
						roomItem.Visual = new RoomItemVisual(_visualManager, prefab, addOnPrefab, _container, _valueMaterial, _roomItemEditConfig, _buildEvents);
						if (levelBeingLoaded != null && roomItem.Definition.ItemType == RoomItemDefinition.Type.Ambulance && roomItem.Definition.BaseAmbulanceConfig != null)
						{
							levelBeingLoaded.ChallengeManager.PlayerAmbulanceDepartment.RestoreAmbulanceFromSave(roomItem);
						}
					}
					else if (roomItem.Visual.GameObject.transform.parent != _container)
					{
						roomItem.Visual.GameObject.transform.SetParent(_container);
					}
					if (flag)
					{
						roomItem.Visual.Animator.Pause();
					}
					if (roomItem.IsHospitalWindow)
					{
						roomItem.Visual.SetActive(active: false);
					}
					roomItem.Visual.UpdateFrom(roomItem, snap: true, itemOnCursor: false, newItemOnCursor: false, cellOffset, rotationOffset);
					_roomItems.Add(roomItem.Visual);
				}
			}
			if (_floorPlan.LandscapeItems == null)
			{
				return;
			}
			foreach (LandscapeRoomItem landscapeItem in _floorPlan.LandscapeItems)
			{
				if (_worldState.ShouldCreateBaseLandscapeItems() || landscapeItem.Layer != HospitalPlotLayer.Base)
				{
					if (landscapeItem.Visual == null)
					{
						landscapeItem.Visual = new RoomItemVisual(_visualManager, landscapeItem.Prefab, landscapeItem.UpgradeAddOnPrefab, _container, _valueMaterial, _roomItemEditConfig, _buildEvents);
					}
					landscapeItem.Visual.UpdateFrom(landscapeItem, snap: true, itemOnCursor: false, newItemOnCursor: false, cellOffset, rotationOffset);
					_roomItems.Add(landscapeItem.Visual);
				}
			}
		}

		public void TriggerConstructionAnimations(GridCoord roomAnchor)
		{
			Vector3 vector = roomAnchor.ToWorldPosition();
			foreach (KeyValuePair<Transform, Transform> wallObject in _wallObjects)
			{
				Renderer component = wallObject.Key.GetComponent<Renderer>();
				SetMaterialBuildParams(vector, component);
				if (wallObject.Value != null)
				{
					component = wallObject.Value.GetComponent<Renderer>();
					SetMaterialBuildParams(vector, component);
				}
			}
			List<RoomFloorPlanVisual> list = new List<RoomFloorPlanVisual>();
			foreach (WallCoord wall in _floorPlan.Walls)
			{
				if (!wall.IsWall() && !wall.IsWindow())
				{
					continue;
				}
				GridCoord gridCoord = wall._position + _floorPlan.Anchor;
				Vector2[] wallOffsets = WallOffsets;
				for (int i = 0; i < wallOffsets.Length; i++)
				{
					Vector2 vector2 = wallOffsets[i];
					GridCoord worldCoord = gridCoord + new GridCoord((int)vector2.x, (int)vector2.y);
					Room roomAtWorldCoord = _worldState.GetRoomAtWorldCoord(worldCoord, includeHospital: true, includeClosedPlots: true);
					if (roomAtWorldCoord != null && roomAtWorldCoord.FloorPlanVisual != null && roomAtWorldCoord.FloorPlan != _floorPlan)
					{
						list.AddUnique(roomAtWorldCoord.FloorPlanVisual);
					}
				}
			}
			foreach (RoomFloorPlanVisual item in list)
			{
				item.ShowWallBackPieces();
			}
			foreach (RoomItemVisual roomItem in _roomItems)
			{
				roomItem.SetMaterialBuildParams(vector);
			}
		}

		public void TriggerFloorConstructionAnimations(GridCoord roomAnchor)
		{
			Vector3 origin = roomAnchor.ToWorldPosition();
			foreach (Transform floorTileObject in _floorTileObjects)
			{
				if (floorTileObject.gameObject.activeSelf)
				{
					floorTileObject.gameObject.GetOrAddComponent<PlotBuildingEffectComponent>().Initialise(origin, 2f, popup: true);
				}
			}
		}

		private void SetMaterialBuildParams(Vector3 origin, Renderer renderer)
		{
			MeshFilter component = renderer.GetComponent<MeshFilter>();
			if (!(component == null) && !(component.sharedMesh == null))
			{
				for (int i = 0; i < component.sharedMesh.subMeshCount; i++)
				{
					renderer.GetPropertyBlock(_sharedMaterialPropertyBlock, i);
					_sharedMaterialPropertyBlock.SetVector("_Origin", origin);
					_sharedMaterialPropertyBlock.SetFloat("_StartTime", VisualManager.ElapsedTime);
					renderer.SetPropertyBlock(_sharedMaterialPropertyBlock, i);
				}
			}
		}

		private void SetPropertyBlockOnWall(GameObject gameObject, MaterialPropertyBlock materialPropertyBlock)
		{
			Renderer component = gameObject.GetComponent<Renderer>();
			MeshFilter component2 = gameObject.GetComponent<MeshFilter>();
			UGCWallMeshOverridesConfig.OverrideDefinition[] overrideDefinitions = _visualManager.VisualManagerConfig.UGCWallMeshOverridesConfig.OverrideDefinitions;
			for (int i = 0; i < overrideDefinitions.Length; i++)
			{
				if (overrideDefinitions[i].Mesh == component2.sharedMesh)
				{
					component.SetPropertyBlock(materialPropertyBlock, overrideDefinitions[i].MaterialIndex);
					return;
				}
			}
			component.SetPropertyBlock(materialPropertyBlock, 0);
		}

		public void SetVisible(bool visible)
		{
			if (!_container)
			{
				return;
			}
			if (visible)
			{
				_container.gameObject.SetActive(value: true);
				for (int i = 0; i < _roomItems.Count; i++)
				{
					_roomItems[i].RestoreAnimatorState();
				}
			}
			else
			{
				for (int j = 0; j < _roomItems.Count; j++)
				{
					_roomItems[j].SaveAnimatorState();
				}
				_container.gameObject.SetActive(value: false);
			}
		}

		public bool IsVisible()
		{
			if (_container != null)
			{
				return _container.gameObject.activeSelf;
			}
			return false;
		}

		public void GetHightlightWallFloorRenderers(List<Renderer> renderers)
		{
			List<Renderer> list = new List<Renderer>(128);
			_wallsContainer.GetComponentsInChildren(list);
			renderers.AddRange(list);
			_floorsContainer.GetComponentsInChildren(list);
			renderers.AddRange(list);
		}

		public void DisableParticleEffects()
		{
			foreach (RoomItemVisual roomItem in _roomItems)
			{
				GameObject gameObject = roomItem.GameObject;
				if (!(gameObject != null) || !(gameObject.GetComponent<ParticleEffectControlComponent>() == null))
				{
					continue;
				}
				ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
				foreach (ParticleSystem particleSystem in componentsInChildren)
				{
					if (!particleSystem.main.loop)
					{
						particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
					}
				}
			}
		}

		private void ShowWallBackPieces()
		{
			foreach (Transform activeWallBackPiece in _activeWallBackPieces)
			{
				GameObjectUtils.SetActive(activeWallBackPiece.gameObject, isActive: true);
				activeWallBackPiece.gameObject.GetOrAddComponent<HideBackPieceGameObjectComponent>();
			}
		}

		private void SetDefaultMaterialValues(MaterialPropertyBlock materialPropertyBlock)
		{
			materialPropertyBlock.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
			materialPropertyBlock.SetFloat("_BumpScale", 0f);
			materialPropertyBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, 0f, 0f));
			materialPropertyBlock.SetFloat("_Metallic", 0f);
			materialPropertyBlock.SetFloat("_Glossiness", 0f);
			materialPropertyBlock.SetFloat("_GlossMapScale", 0f);
			materialPropertyBlock.SetColor("_EmissionColor", Color.clear);
			materialPropertyBlock.SetTexture("_MetallicGlossMap", Texture2D.blackTexture);
		}
	}
}
