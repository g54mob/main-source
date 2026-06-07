using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace RLD
{
	public class RTScene : MonoSingleton<RTScene>
	{
		public SceneCanRenderCameraIconHandler CanRenderCameraIcon;

		private static readonly float _nullCleanupTargetTime = 1f;

		private float _elapsedNullCleanupTime;

		private YesNoAnswer _yesNoAnswer = new YesNoAnswer();

		[SerializeField]
		private SceneSettings _settings = new SceneSettings();

		[SerializeField]
		private SceneLookAndFeel _lookAndFeel = new SceneLookAndFeel();

		private List<Camera> _iconRenderIgnoreCamera = new List<Camera>();

		private HashSet<GameObject> _ignoredRootObjects = new HashSet<GameObject>();

		private List<IHoverableSceneEntityContainer> _hoverableSceneEntityContainers = new List<IHoverableSceneEntityContainer>();

		private SceneTree _sceneTree = new SceneTree();

		private List<GameObject> _childrenAndSelf = new List<GameObject>(100);

		private List<GameObject> _rootGameObjects = new List<GameObject>();

		private List<Light> _lights = new List<Light>();

		private List<ParticleSystem> _particleSystems = new List<ParticleSystem>();

		private List<Camera> _cameras = new List<Camera>();

		public SceneSettings Settings => _settings;

		public SceneLookAndFeel LookAndFeel => _lookAndFeel;

		public void SetRootObjectIgnored(GameObject root, bool ignored)
		{
			if (ignored)
			{
				_ignoredRootObjects.Add(root);
			}
			else
			{
				_ignoredRootObjects.Remove(root);
			}
		}

		public void AddIconRenderIgnoreCamera(Camera camera)
		{
			if (!IsIconRenderIgnoreCamera(camera))
			{
				_iconRenderIgnoreCamera.Add(camera);
			}
		}

		public bool IsIconRenderIgnoreCamera(Camera camera)
		{
			return _iconRenderIgnoreCamera.Contains(camera);
		}

		public AABB CalculateBounds()
		{
			List<GameObject> list = new List<GameObject>(Mathf.Max(10, SceneManager.GetActiveScene().rootCount));
			SceneManager.GetActiveScene().GetRootGameObjects(list);
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				NoVolumeSize = Vector3.zero,
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			};
			AABB result = default(AABB);
			foreach (GameObject item in list)
			{
				foreach (GameObject item2 in item.GetAllChildrenAndSelf())
				{
					AABB aABB = ObjectBounds.CalcWorldAABB(item2, queryConfig);
					if (aABB.IsValid)
					{
						if (result.IsValid)
						{
							result.Encapsulate(aABB);
						}
						else
						{
							result = aABB;
						}
					}
				}
			}
			return result;
		}

		public bool IsAnySceneEntityHovered()
		{
			foreach (IHoverableSceneEntityContainer hoverableSceneEntityContainer in _hoverableSceneEntityContainers)
			{
				if (hoverableSceneEntityContainer.HasHoveredSceneEntity)
				{
					return true;
				}
			}
			return IsAnyUIElementHovered();
		}

		public void RegisterHoverableSceneEntityContainer(IHoverableSceneEntityContainer container)
		{
			if (!_hoverableSceneEntityContainers.Contains(container))
			{
				_hoverableSceneEntityContainers.Add(container);
			}
		}

		public bool IsAnyUIElementHovered()
		{
			return GetHoveredUIElements().Count != 0;
		}

		public List<RaycastResult> GetHoveredUIElements()
		{
			if (EventSystem.current == null)
			{
				return new List<RaycastResult>();
			}
			IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
			if (!device.HasPointer())
			{
				return new List<RaycastResult>();
			}
			Vector2 vector = device.GetPositionYAxisUp();
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = new Vector2(vector.x, vector.y);
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			list.RemoveAll((RaycastResult item) => item.gameObject.GetComponent<RectTransform>() == null);
			return list;
		}

		public GameObject[] GetSceneObjects()
		{
			return Object.FindObjectsOfType<GameObject>();
		}

		public List<GameObject> OverlapBox(OBB obb)
		{
			if (Settings.PhysicsMode == ScenePhysicsMode.UnityColliders)
			{
				Collider[] array = Physics.OverlapBox(obb.Center, obb.Extents, obb.Rotation);
				List<GameObject> list = new List<GameObject>(50);
				Collider[] array2 = array;
				foreach (Collider collider in array2)
				{
					list.Add(collider.gameObject);
				}
				List<Vector3> pointCloud = new Plane(Vector3.forward, 0f).ProjectAllPoints(obb.GetCornerPoints());
				AABB aABB = new AABB(pointCloud);
				Collider2D[] array3 = Physics2D.OverlapAreaAll(aABB.Min, aABB.Max);
				foreach (Collider2D collider2D in array3)
				{
					list.Add(collider2D.gameObject);
				}
				return list;
			}
			return _sceneTree.OverlapBox(obb);
		}

		public List<GameObject> OverlapBox(OBB obb, SceneOverlapFilter overlapFilter)
		{
			List<GameObject> list = OverlapBox(obb);
			overlapFilter.FilterOverlaps(list);
			return list;
		}

		public SceneRaycastHit Raycast(Ray ray, SceneRaycastPrecision rtRaycastPrecision, SceneRaycastFilter raycastFilter)
		{
			List<GameObjectRayHit> list = RaycastAllObjectsSorted(ray, rtRaycastPrecision, raycastFilter);
			GameObjectRayHit objectRayHit = ((list.Count != 0) ? list[0] : null);
			XZGridRayHit gridRayHit = RaycastSceneGridIfVisible(ray);
			return new SceneRaycastHit(objectRayHit, gridRayHit);
		}

		public List<GameObjectRayHit> RaycastAllObjects(Ray ray, SceneRaycastPrecision rtRaycastPrecision)
		{
			if (Settings.PhysicsMode == ScenePhysicsMode.UnityColliders)
			{
				RaycastHit[] hits3D = Physics.RaycastAll(ray, float.MaxValue);
				RaycastHit2D[] rayIntersectionAll = Physics2D.GetRayIntersectionAll(ray, float.MaxValue);
				List<GameObjectRayHit> list = new List<GameObjectRayHit>(GameObjectRayHit.Create(ray, hits3D));
				list.AddRange(GameObjectRayHit.Create(ray, rayIntersectionAll));
				return list;
			}
			return _sceneTree.RaycastAll(ray, rtRaycastPrecision);
		}

		public List<GameObjectRayHit> RaycastAllObjectsSorted(Ray ray, SceneRaycastPrecision raycastPresicion)
		{
			List<GameObjectRayHit> list = RaycastAllObjects(ray, raycastPresicion);
			GameObjectRayHit.SortByHitDistance(list);
			return list;
		}

		public List<GameObjectRayHit> RaycastAllObjectsSorted(Ray ray, SceneRaycastPrecision rtRaycastPrecision, SceneRaycastFilter raycastFilter)
		{
			if (raycastFilter != null && raycastFilter.AllowedObjectTypes.Count == 0)
			{
				return new List<GameObjectRayHit>();
			}
			List<GameObjectRayHit> list = RaycastAllObjectsSorted(ray, rtRaycastPrecision);
			raycastFilter?.FilterHits(list);
			return list;
		}

		public GameObjectRayHit RaycastMeshObject(Ray ray, GameObject meshObject)
		{
			if (Settings.PhysicsMode == ScenePhysicsMode.UnityColliders)
			{
				Collider collider = null;
				MeshCollider component = meshObject.GetComponent<MeshCollider>();
				if (component != null)
				{
					collider = component;
				}
				if (collider == null)
				{
					collider = meshObject.GetComponent<Collider>();
				}
				if (collider != null && collider.Raycast(ray, out var hitInfo, float.MaxValue))
				{
					return new GameObjectRayHit(ray, hitInfo);
				}
				return null;
			}
			return _sceneTree.RaycastMeshObject(ray, meshObject);
		}

		public GameObjectRayHit RaycastMeshObjectReverseIfFail(Ray ray, GameObject meshObject)
		{
			GameObjectRayHit gameObjectRayHit = RaycastMeshObject(ray, meshObject);
			if (gameObjectRayHit == null)
			{
				gameObjectRayHit = RaycastMeshObject(new Ray(ray.origin, -ray.direction), meshObject);
			}
			return gameObjectRayHit;
		}

		public GameObjectRayHit RaycastSpriteObject(Ray ray, GameObject spriteObject)
		{
			return _sceneTree.RaycastSpriteObject(ray, spriteObject);
		}

		public GameObjectRayHit RaycastTerrainObject(Ray ray, GameObject terrainObject)
		{
			TerrainCollider component = terrainObject.GetComponent<TerrainCollider>();
			if (component == null)
			{
				return null;
			}
			if (component.Raycast(ray, out var hitInfo, float.MaxValue))
			{
				return new GameObjectRayHit(ray, hitInfo);
			}
			return null;
		}

		public GameObjectRayHit RaycastTerrainObject(Ray ray, GameObject terrainObject, TerrainCollider terrainCollider)
		{
			if (terrainCollider.Raycast(ray, out var hitInfo, float.MaxValue))
			{
				return new GameObjectRayHit(ray, hitInfo);
			}
			return null;
		}

		public GameObjectRayHit RaycastTerrainObjectReverseIfFail(Ray ray, GameObject terrainObject)
		{
			GameObjectRayHit gameObjectRayHit = RaycastTerrainObject(ray, terrainObject);
			if (gameObjectRayHit == null)
			{
				gameObjectRayHit = RaycastTerrainObject(new Ray(ray.origin, -ray.direction), terrainObject);
			}
			return gameObjectRayHit;
		}

		public XZGridRayHit RaycastSceneGridIfVisible(Ray ray)
		{
			if (!MonoSingleton<RTSceneGrid>.Get.Settings.IsVisible)
			{
				return null;
			}
			if (MonoSingleton<RTSceneGrid>.Get.Raycast(ray, out var t))
			{
				XZGridCell hitCell = MonoSingleton<RTSceneGrid>.Get.CellFromWorldPoint(ray.GetPoint(t));
				return new XZGridRayHit(ray, hitCell, t);
			}
			return null;
		}

		public void Update_SystemCall()
		{
			_elapsedNullCleanupTime += Time.deltaTime;
			if (_elapsedNullCleanupTime >= _nullCleanupTargetTime)
			{
				_sceneTree.RemoveNodesWithNullObjects();
				Singleton<RTMeshDb>.Get.RemoveNullMeshEntries();
				_lights.RemoveAll((Light light) => light == null);
				_particleSystems.RemoveAll((ParticleSystem particleSystem) => particleSystem == null);
				_cameras.RemoveAll((Camera camera) => camera == null);
				_elapsedNullCleanupTime = 0f;
			}
			Scene activeScene = SceneManager.GetActiveScene();
			int rootCount = activeScene.rootCount;
			if (_rootGameObjects.Capacity <= rootCount)
			{
				_rootGameObjects.Capacity = rootCount + 100;
			}
			activeScene.GetRootGameObjects(_rootGameObjects);
			for (int num = 0; num < rootCount; num++)
			{
				GameObject item = _rootGameObjects[num];
				if (_ignoredRootObjects.Contains(item))
				{
					continue;
				}
				item.GetAllChildrenAndSelf(_childrenAndSelf);
				int count = _childrenAndSelf.Count;
				for (int num2 = 0; num2 < count; num2++)
				{
					GameObject gameObject = _childrenAndSelf[num2];
					if (!_sceneTree.IsObjectRegistered(gameObject))
					{
						_sceneTree.RegisterObject(gameObject);
						Light component = gameObject.GetComponent<Light>();
						if (component != null)
						{
							_lights.Add(component);
						}
						ParticleSystem component2 = gameObject.GetComponent<ParticleSystem>();
						if (component2 != null)
						{
							_particleSystems.Add(component2);
						}
						Camera component3 = gameObject.GetComponent<Camera>();
						if (component3 != null && !MonoSingleton<RTGizmosEngine>.Get.IsSceneGizmoCamera(component3))
						{
							_cameras.Add(component3);
						}
					}
					else
					{
						Transform transform = gameObject.transform;
						if (transform.hasChanged)
						{
							_sceneTree.OnObjectTransformChanged(transform);
							transform.hasChanged = false;
						}
					}
				}
			}
		}

		public void Render_SystemCall()
		{
			Material tintedTexture = Singleton<MaterialPool>.Get.TintedTexture;
			Mesh unitQuadXY = Singleton<MeshPool>.Get.UnitQuadXY;
			Camera current = Camera.current;
			if (IsIconRenderIgnoreCamera(current))
			{
				return;
			}
			Transform transform = current.transform;
			_ = transform.position;
			_ = transform.rotation;
			if (LookAndFeel.DrawCameraIcons && LookAndFeel.CameraIcon != null)
			{
				tintedTexture.SetTexture("_MainTex", LookAndFeel.CameraIcon);
				tintedTexture.SetColor(Color.white.KeepAllButAlpha(LookAndFeel.CameraIconAlpha));
				tintedTexture.SetZTestAlways();
				tintedTexture.SetPass(0);
				Camera targetCamera = MonoSingleton<RTFocusCamera>.Get.TargetCamera;
				Vector3 s = new Vector3(Settings.NonMeshObjectSize, Settings.NonMeshObjectSize, 1f);
				for (int i = 0; i < _cameras.Count; i++)
				{
					Camera camera = _cameras[i];
					if (!(camera != null) || !camera.gameObject.activeInHierarchy || (object)targetCamera == camera)
					{
						continue;
					}
					if (CanRenderCameraIcon != null)
					{
						CanRenderCameraIcon(camera, _yesNoAnswer);
						if (_yesNoAnswer.HasNo)
						{
							continue;
						}
					}
					Vector3 position = camera.gameObject.transform.position;
					Quaternion rotation = transform.rotation;
					Matrix4x4 matrix = Matrix4x4.TRS(position, rotation, s);
					Graphics.DrawMeshNow(unitQuadXY, matrix);
				}
			}
			if (LookAndFeel.DrawParticleSystemIcons && LookAndFeel.ParticleSystemIcon != null)
			{
				tintedTexture.SetTexture("_MainTex", LookAndFeel.ParticleSystemIcon);
				tintedTexture.SetColor(Color.white.KeepAllButAlpha(LookAndFeel.ParticleSystemIconAlpha));
				tintedTexture.SetZTestAlways();
				tintedTexture.SetPass(0);
				Vector3 s2 = new Vector3(Settings.NonMeshObjectSize, Settings.NonMeshObjectSize, 1f);
				for (int j = 0; j < _particleSystems.Count; j++)
				{
					ParticleSystem particleSystem = _particleSystems[j];
					if (particleSystem != null && particleSystem.gameObject.activeInHierarchy)
					{
						Vector3 position2 = particleSystem.gameObject.transform.position;
						Quaternion rotation2 = transform.rotation;
						Matrix4x4 matrix2 = Matrix4x4.TRS(position2, rotation2, s2);
						Graphics.DrawMeshNow(unitQuadXY, matrix2);
					}
				}
			}
			if (!LookAndFeel.DrawLightIcons || !(LookAndFeel.LightIcon != null))
			{
				return;
			}
			tintedTexture.SetTexture("_MainTex", LookAndFeel.LightIcon);
			tintedTexture.SetZTestAlways();
			Vector3 s3 = new Vector3(Settings.NonMeshObjectSize, Settings.NonMeshObjectSize, 1f);
			for (int k = 0; k < _lights.Count; k++)
			{
				Light light = _lights[k];
				if (light != null && light.enabled && light.gameObject.activeInHierarchy)
				{
					Vector3 position3 = light.gameObject.transform.position;
					Quaternion rotation3 = transform.rotation;
					Matrix4x4 matrix3 = Matrix4x4.TRS(position3, rotation3, s3);
					tintedTexture.SetColor(light.color.KeepAllButAlpha(LookAndFeel.LightIconAlpha));
					tintedTexture.SetPass(0);
					Graphics.DrawMeshNow(unitQuadXY, matrix3);
				}
			}
		}
	}
}
