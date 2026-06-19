using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class RoomItemVisual : MustCallDestroy
	{
		private struct ForwardLightingInfo
		{
			public Color AmbientRoomLightColor;

			public float AmbientRoomLightIntensity;

			public Color DirectionalRoomLightColor;

			public float DirectionalRoomLightIntensity;

			public Vector3 DirectionalRoomLightDirection;

			public Cubemap RoomReflectionCubemap;
		}

		private string DebugNameOnDestroy;

		private GameObject _gameObject;

		private bool _useEditingMaterials;

		private bool _useValueMaterials;

		private readonly VisualManager _visualManager;

		private readonly Material _valueMaterial;

		private readonly RoomItemVisualEdit.Config _roomItemEditConfig;

		private readonly BuildEvents _buidEvents;

		private Bounds[] _bounds;

		private readonly List<Bounds> _worldBounds = new List<Bounds>();

		private readonly MeshCollider[] _meshColliders;

		private readonly List<RoomItemRendererInstance> _rendererInstances;

		[DontSave]
		private List<ItemIgnoreDataViewComponent> _ignoreDataViewComponentsCached;

		private readonly bool _requiresRoomLightUpdates;

		private Vector3 _positionDampVelocity = Vector3.zero;

		private float _rotationDampVelocity;

		private AnimatorSavedState _savedAnimatorState;

		private static int _nextID;

		private bool _forwardLightingDefined;

		private ForwardLightingInfo _forwardLightingInfo;

		[DontSave]
		private Color _valueColor;

		[DontSave]
		private Texture2D _overrideTextureDiffuse;

		private RoomItemVisualEdit _boundsVisual;

		private Dictionary<string, Transform> _startTransforms;

		private static readonly int OutdoorLayer = LayerMask.NameToLayer("Outdoor");

		public GameObject GameObject => _gameObject;

		public bool ActiveSelf
		{
			get
			{
				if (_gameObject != null)
				{
					return _gameObject.activeSelf;
				}
				return false;
			}
		}

		public Texture2D OverrideTextureDiffuse
		{
			get
			{
				return _overrideTextureDiffuse;
			}
			set
			{
				_overrideTextureDiffuse = value;
				foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
				{
					rendererInstance.OriginalPropertyBlock.SetTexture("_MainTex", _overrideTextureDiffuse);
					if (!_useValueMaterials & !_useValueMaterials)
					{
						SetPropertyBlockOnInstance(rendererInstance, null);
						rendererInstance.Renderer.SetPropertyBlock(rendererInstance.OriginalPropertyBlock);
					}
				}
			}
		}

		public Animator Animator { get; private set; }

		public bool RequiresRoomLightUpdates => _requiresRoomLightUpdates;

		public RuntimeAnimatorController AnimationGraph
		{
			get
			{
				if (!(Animator != null))
				{
					return null;
				}
				return Animator.runtimeAnimatorController;
			}
			set
			{
				if (Animator != null)
				{
					Animator.runtimeAnimatorController = value;
				}
			}
		}

		public Vector3 WorldPosition
		{
			get
			{
				return _gameObject.transform.position;
			}
			set
			{
				_gameObject.transform.position = value;
			}
		}

		private Vector3 DesiredPosition { get; set; }

		public Quaternion Rotation => _gameObject.transform.rotation;

		private Quaternion DesiredRotation { get; set; }

		public Dictionary<string, Transform> StartTransforms => _startTransforms;

		public GameObject StealGameObject()
		{
			GameObject gameObject = _gameObject;
			_gameObject = null;
			return gameObject;
		}

		public RoomItemVisual(VisualManager visualManager, GameObject prefab, GameObject addOnPrefab, Transform parent, Material valueMaterial, RoomItemVisualEdit.Config roomItemEditConfig, BuildEvents buildEvents)
		{
			_valueColor = Color.white;
			_buidEvents = buildEvents;
			_valueMaterial = valueMaterial;
			_roomItemEditConfig = roomItemEditConfig;
			if (parent != null)
			{
				_gameObject = Object.Instantiate(prefab, parent);
			}
			else
			{
				_gameObject = Object.Instantiate(prefab);
			}
			if (addOnPrefab != null)
			{
				Object.Instantiate(addOnPrefab, _gameObject.transform);
			}
			_gameObject.name = "RoomItemVisual_" + _nextID.ToString().PadLeft(3, '0') + ": " + prefab.name;
			_visualManager = visualManager;
			BlobShadowDecal[] componentsInChildren = _gameObject.GetComponentsInChildren<BlobShadowDecal>();
			foreach (BlobShadowDecal decal in componentsInChildren)
			{
				_visualManager.BlobShadowManager.RegisterDecal(decal);
			}
			Animator = _gameObject.GetComponentInChildren<Animator>();
			_meshColliders = _gameObject.GetComponentsInChildren<MeshCollider>();
			_rendererInstances = new List<RoomItemRendererInstance>();
			Renderer[] componentsInChildren2 = _gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren2)
			{
				if (!(renderer is ParticleSystemRenderer))
				{
					RoomItemRendererInstance roomItemRendererInstance = new RoomItemRendererInstance
					{
						Renderer = renderer,
						OriginalPropertyBlock = new MaterialPropertyBlock(),
						OriginalMaterials = renderer.sharedMaterials,
						IgnoreHighlight = (renderer.GetComponent<RoomItemRendererIgnoreHighlightComponent>() != null)
					};
					if (_overrideTextureDiffuse != null)
					{
						roomItemRendererInstance.OriginalPropertyBlock.SetTexture("_MainTex", _overrideTextureDiffuse);
					}
					roomItemRendererInstance.Renderer.SetPropertyBlock(roomItemRendererInstance.OriginalPropertyBlock);
					_rendererInstances.Add(roomItemRendererInstance);
				}
			}
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				Material[] originalMaterials = rendererInstance.OriginalMaterials;
				foreach (Material material in originalMaterials)
				{
					if (material != null && material.HasProperty("_ApplyRoomLighting") && material.GetFloat("_ApplyRoomLighting") > 0f)
					{
						_requiresRoomLightUpdates = true;
					}
				}
			}
			_nextID++;
			_buidEvents.OnRoomItemVisualCreated.InvokeSafe(this);
		}

		public void UpdateOriginalMaterials(Renderer renderer, Material[] materials)
		{
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (rendererInstance.Renderer == renderer)
				{
					rendererInstance.OriginalMaterials = materials;
				}
			}
		}

		public Material[] GetOriginalMaterials(Renderer renderer)
		{
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (rendererInstance.Renderer == renderer)
				{
					return rendererInstance.OriginalMaterials;
				}
			}
			return null;
		}

		public void SetEditAlpha(float alpha)
		{
			if (!_useEditingMaterials || _useValueMaterials)
			{
				return;
			}
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				for (int i = 0; i < rendererInstance.OriginalMaterials.Length; i++)
				{
					Material material = rendererInstance.OriginalMaterials[i];
					if (material != null && material.HasProperty("_Color"))
					{
						Color color = material.color;
						color.a *= alpha;
						rendererInstance.EditPropertyBlock.SetColor("_Color", color);
						rendererInstance.Renderer.SetPropertyBlock(rendererInstance.EditPropertyBlock, i);
					}
				}
			}
		}

		public void SetPropertyBlock(MaterialPropertyBlock propertyBlock)
		{
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				for (int i = 0; i < rendererInstance.OriginalMaterials.Length; i++)
				{
					rendererInstance.Renderer.SetPropertyBlock(propertyBlock, i);
				}
			}
		}

		private void SetPropertyBlockOnInstance(RoomItemRendererInstance instance, MaterialPropertyBlock propertyBlock)
		{
			for (int i = 0; i < instance.OriginalMaterials.Length; i++)
			{
				instance.Renderer.SetPropertyBlock(propertyBlock, i);
			}
		}

		public void SetupEditingVisuals(RoomItem roomItem)
		{
			if (roomItem is LandscapeRoomItem)
			{
				return;
			}
			EnableEditingMaterials();
			ShowBoundsVisual(roomItem, thinking: false);
			if (Animator != null)
			{
				Animator.Pause();
			}
			if (_gameObject != null && _gameObject.activeInHierarchy)
			{
				LODGroup component = _gameObject.GetComponent<LODGroup>();
				if (component != null)
				{
					component.ForceLOD(0);
				}
			}
		}

		public void ShowBoundsVisual(RoomItem roomItem, bool thinking)
		{
			if (_boundsVisual == null && _gameObject != null)
			{
				_boundsVisual = new RoomItemVisualEdit(_roomItemEditConfig, this, roomItem);
			}
			if (_boundsVisual != null)
			{
				_boundsVisual.UpdateFrom(roomItem, thinking);
				_boundsVisual.SetVisible(visible: true);
			}
		}

		public void GetHighlightRenderers(List<Renderer> renderers)
		{
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (!rendererInstance.IgnoreHighlight && rendererInstance.Renderer != null && rendererInstance.Renderer.enabled && rendererInstance.Renderer.gameObject.activeInHierarchy)
				{
					renderers.Add(rendererInstance.Renderer);
				}
			}
		}

		private bool IgnoreForValueMaterials(RoomItemRendererInstance instance)
		{
			if (_ignoreDataViewComponentsCached == null)
			{
				_ignoreDataViewComponentsCached = new List<ItemIgnoreDataViewComponent>();
			}
			instance.Renderer.GetComponents(_ignoreDataViewComponentsCached);
			bool result = _ignoreDataViewComponentsCached.Count > 0;
			_ignoreDataViewComponentsCached.Clear();
			return result;
		}

		public void EnableValueMaterial()
		{
			if (_useEditingMaterials || _useValueMaterials || !(_valueMaterial != null))
			{
				return;
			}
			_useValueMaterials = true;
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (!(rendererInstance.Renderer is ParticleSystemRenderer) && !IgnoreForValueMaterials(rendererInstance))
				{
					if (rendererInstance.ValuePropertyBlock == null)
					{
						rendererInstance.ValuePropertyBlock = new MaterialPropertyBlock();
					}
					else
					{
						rendererInstance.ValuePropertyBlock.Clear();
					}
					rendererInstance.ValuePropertyBlock.SetColor("_Color", _valueColor);
					Material[] array = new Material[rendererInstance.OriginalMaterials.Length];
					ArrayUtils.Populate(array, _valueMaterial);
					rendererInstance.Renderer.materials = array;
					SetPropertyBlockOnInstance(rendererInstance, rendererInstance.ValuePropertyBlock);
				}
			}
		}

		public void DisableValueMaterial()
		{
			if (_useEditingMaterials || !(_valueMaterial != null))
			{
				return;
			}
			_useValueMaterials = false;
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (!(rendererInstance.Renderer == null) && !(rendererInstance.Renderer is ParticleSystemRenderer))
				{
					SetPropertyBlockOnInstance(rendererInstance, null);
					rendererInstance.Renderer.SetPropertyBlock(rendererInstance.OriginalPropertyBlock);
					rendererInstance.Renderer.materials = rendererInstance.OriginalMaterials;
				}
			}
		}

		public void SetValueMaterial(Color valueColor)
		{
			_valueColor = valueColor;
			if (_useEditingMaterials || !_useValueMaterials || _useEditingMaterials || !(_valueMaterial != null))
			{
				return;
			}
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (!IgnoreForValueMaterials(rendererInstance))
				{
					if (rendererInstance.ValuePropertyBlock == null)
					{
						rendererInstance.ValuePropertyBlock = new MaterialPropertyBlock();
					}
					rendererInstance.ValuePropertyBlock.SetColor("_Color", _valueColor);
					SetPropertyBlockOnInstance(rendererInstance, rendererInstance.ValuePropertyBlock);
				}
			}
		}

		public void EnableEditingMaterials()
		{
			if (_useEditingMaterials)
			{
				return;
			}
			DisableValueMaterial();
			_useEditingMaterials = true;
			string name = "_Color";
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (rendererInstance.EditPropertyBlock == null)
				{
					rendererInstance.EditPropertyBlock = new MaterialPropertyBlock();
				}
				else
				{
					rendererInstance.EditPropertyBlock.Clear();
				}
				if (_forwardLightingDefined)
				{
					rendererInstance.EditPropertyBlock.SetColor("_AmbientRoomLightColor", _forwardLightingInfo.AmbientRoomLightColor);
					rendererInstance.EditPropertyBlock.SetFloat("_AmbientRoomLightIntensity", _forwardLightingInfo.AmbientRoomLightIntensity);
					rendererInstance.EditPropertyBlock.SetColor("_DirectionalRoomLightColor", _forwardLightingInfo.DirectionalRoomLightColor);
					rendererInstance.EditPropertyBlock.SetFloat("_DirectionalRoomLightIntensity", _forwardLightingInfo.DirectionalRoomLightIntensity);
					rendererInstance.EditPropertyBlock.SetVector("_DirectionalRoomLightDirection", _forwardLightingInfo.DirectionalRoomLightDirection);
					rendererInstance.EditPropertyBlock.SetTexture("_ForwardRoomLightCubemapTexture", _forwardLightingInfo.RoomReflectionCubemap);
				}
				DitheredRendererManager.Instance.Register(rendererInstance.Renderer);
				rendererInstance.ValidMaterials = new Material[rendererInstance.OriginalMaterials.Length];
				rendererInstance.SellMaterials = new Material[rendererInstance.OriginalMaterials.Length];
				if (_overrideTextureDiffuse != null)
				{
					rendererInstance.EditPropertyBlock.SetTexture("_MainTex", _overrideTextureDiffuse);
				}
				SetPropertyBlockOnInstance(rendererInstance, rendererInstance.EditPropertyBlock);
				for (int i = 0; i < rendererInstance.OriginalMaterials.Length; i++)
				{
					Material material = rendererInstance.OriginalMaterials[i];
					if (material != null)
					{
						Material material2 = new Material(rendererInstance.OriginalMaterials[i]);
						Material material3 = new Material(rendererInstance.OriginalMaterials[i]);
						if (material.HasProperty(name))
						{
							Color color = material.color;
							int renderQueue = material.renderQueue;
							TH20Standard.BlendMode blendMode = ((renderQueue >= 3000 && renderQueue < 4000) ? TH20Standard.BlendMode.Transparent : TH20Standard.BlendMode.Dithered);
							TH20Standard.SetBlendMode(material2, blendMode);
							SetEditMaterialColorSettings(material2, color, material);
							TH20Standard.SetBlendMode(material3, blendMode);
							SetEditMaterialColorSettings(material3, new Color(color.r, color.g, color.b, color.a * _roomItemEditConfig.SellInvalidItemAlpha), material);
						}
						SetEditMaterialBlendSettings(material2);
						SetEditMaterialBlendSettings(material3);
						rendererInstance.ValidMaterials[i] = material2;
						rendererInstance.SellMaterials[i] = material3;
					}
				}
			}
		}

		public void SetMaterialBuildParams(Vector3 origin)
		{
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				rendererInstance.OriginalPropertyBlock.SetVector("_Origin", origin);
				rendererInstance.OriginalPropertyBlock.SetFloat("_StartTime", VisualManager.ElapsedTime);
				if (!_useEditingMaterials && !_useValueMaterials)
				{
					SetPropertyBlockOnInstance(rendererInstance, rendererInstance.OriginalPropertyBlock);
					rendererInstance.Renderer.SetPropertyBlock(rendererInstance.OriginalPropertyBlock);
				}
			}
		}

		private void SetEditMaterialColorSettings(Material editMaterial, Color editColor, Material originalMaterial)
		{
			if (TH20Standard.IsTH20Standard(originalMaterial))
			{
				switch (TH20Standard.GetBlendMode(editMaterial))
				{
				case TH20Standard.BlendMode.Opaque:
					editColor.a = GameAlgorithms.Config.BlueprintItemAlpha;
					break;
				case TH20Standard.BlendMode.Fade:
				case TH20Standard.BlendMode.Transparent:
					editColor.a = Mathf.Clamp(editColor.a, 0f, GameAlgorithms.Config.BlueprintItemMaxAlphaForTransparentParts);
					break;
				}
				TH20Standard.SetMaterialKeywords(editMaterial);
			}
			editMaterial.color = editColor;
		}

		private void SetEditMaterialBlendSettings(Material editMaterial)
		{
			if (TH20Standard.IsTH20Standard(editMaterial))
			{
				switch (TH20Standard.GetBlendMode(editMaterial))
				{
				case TH20Standard.BlendMode.Opaque:
					TH20Standard.SetBlendMode(editMaterial, TH20Standard.BlendMode.Dithered);
					break;
				case TH20Standard.BlendMode.Fade:
					TH20Standard.SetBlendMode(editMaterial, TH20Standard.GetBlendMode(editMaterial));
					break;
				case TH20Standard.BlendMode.Transparent:
					TH20Standard.SetBlendMode(editMaterial, TH20Standard.GetBlendMode(editMaterial));
					break;
				default:
					TH20Standard.SetBlendMode(editMaterial, TH20Standard.GetBlendMode(editMaterial));
					break;
				}
				TH20Standard.SetMaterialKeywords(editMaterial);
			}
		}

		public void DisableAndDestroyEditingVisuals()
		{
			if (_useEditingMaterials)
			{
				RoomItemVisualInvalidComponent component = _gameObject.GetComponent<RoomItemVisualInvalidComponent>();
				if (component != null)
				{
					Object.Destroy(component);
				}
				foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
				{
					DitheredRendererManager.Instance.Unregister(rendererInstance.Renderer);
					if (_useValueMaterials)
					{
						Material[] array = new Material[rendererInstance.OriginalMaterials.Length];
						ArrayUtils.Populate(array, _valueMaterial);
						rendererInstance.Renderer.materials = array;
						if (rendererInstance.ValuePropertyBlock == null)
						{
							rendererInstance.ValuePropertyBlock = new MaterialPropertyBlock();
						}
						rendererInstance.ValuePropertyBlock.SetColor("_Color", _valueColor);
						SetPropertyBlockOnInstance(rendererInstance, rendererInstance.ValuePropertyBlock);
					}
					else
					{
						rendererInstance.Renderer.materials = rendererInstance.OriginalMaterials;
						SetPropertyBlockOnInstance(rendererInstance, null);
						rendererInstance.Renderer.SetPropertyBlock(rendererInstance.OriginalPropertyBlock);
					}
					for (int i = 0; i < rendererInstance.OriginalMaterials.Length; i++)
					{
						Object.Destroy(rendererInstance.ValidMaterials[i]);
						Object.Destroy(rendererInstance.SellMaterials[i]);
					}
					rendererInstance.ValidMaterials = null;
					rendererInstance.SellMaterials = null;
				}
				_useEditingMaterials = false;
			}
			if (Animator != null)
			{
				Animator.Resume();
			}
			HideBoundsVisual();
			if ((bool)_gameObject && _gameObject.activeInHierarchy)
			{
				LODGroup component2 = _gameObject.GetComponent<LODGroup>();
				if (component2 != null)
				{
					component2.ForceLOD(-1);
				}
			}
		}

		public void HideBoundsVisual()
		{
			if (_boundsVisual != null)
			{
				_boundsVisual.SetVisible(visible: false);
			}
		}

		public override void Destroy()
		{
			_buidEvents.OnRoomItemVisualDestroyed.InvokeSafe(this);
			DisableAndDestroyEditingVisuals();
			if (_boundsVisual != null)
			{
				_boundsVisual.Destroy();
				_boundsVisual = null;
			}
			if (_gameObject != null)
			{
				DebugNameOnDestroy = _gameObject.name;
				BlobShadowDecal[] components = _gameObject.GetComponents<BlobShadowDecal>();
				foreach (BlobShadowDecal decal in components)
				{
					_visualManager.BlobShadowManager.UnregisterDecal(decal);
				}
				Object.Destroy(_gameObject);
				_gameObject = null;
			}
			base.Destroy();
		}

		public void SetActive(bool active)
		{
			if (_gameObject != null)
			{
				bool activeSelf = _gameObject.activeSelf;
				if (activeSelf && !active && Animator != null && AnimationGraph != null)
				{
					_savedAnimatorState = new AnimatorSavedState(Animator);
				}
				GameObjectUtils.SetActive(_gameObject, active);
				if (!activeSelf && active && _savedAnimatorState != null)
				{
					_savedAnimatorState.Restore(Animator);
				}
			}
		}

		public void UpdateRoomLighting(Color ambientRoomLightColor, float ambientRoomLightIntensity, Color directionalRoomLightColor, float directionalRoomLightIntensity, Vector3 directionalRoomLightDirection, Cubemap roomReflectionCubemap)
		{
			_forwardLightingDefined = true;
			_forwardLightingInfo.AmbientRoomLightColor = ambientRoomLightColor;
			_forwardLightingInfo.AmbientRoomLightIntensity = ambientRoomLightIntensity;
			_forwardLightingInfo.DirectionalRoomLightColor = directionalRoomLightColor;
			_forwardLightingInfo.DirectionalRoomLightIntensity = directionalRoomLightIntensity;
			_forwardLightingInfo.DirectionalRoomLightDirection = directionalRoomLightDirection;
			_forwardLightingInfo.RoomReflectionCubemap = roomReflectionCubemap;
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				rendererInstance.OriginalPropertyBlock.SetColor("_AmbientRoomLightColor", _forwardLightingInfo.AmbientRoomLightColor);
				rendererInstance.OriginalPropertyBlock.SetFloat("_AmbientRoomLightIntensity", _forwardLightingInfo.AmbientRoomLightIntensity);
				rendererInstance.OriginalPropertyBlock.SetColor("_DirectionalRoomLightColor", _forwardLightingInfo.DirectionalRoomLightColor);
				rendererInstance.OriginalPropertyBlock.SetFloat("_DirectionalRoomLightIntensity", _forwardLightingInfo.DirectionalRoomLightIntensity);
				rendererInstance.OriginalPropertyBlock.SetVector("_DirectionalRoomLightDirection", _forwardLightingInfo.DirectionalRoomLightDirection);
				rendererInstance.OriginalPropertyBlock.SetTexture("_ForwardRoomLightCubemapTexture", _forwardLightingInfo.RoomReflectionCubemap);
				if (!_useValueMaterials && !_useEditingMaterials)
				{
					SetPropertyBlockOnInstance(rendererInstance, null);
					rendererInstance.Renderer.SetPropertyBlock(rendererInstance.OriginalPropertyBlock);
				}
			}
		}

		public void UpdateFrom(RoomItem item, bool snap, bool itemOnCursor = false, bool newItemOnCursor = false, Vector3 cellOffset = default(Vector3), float cellRotation = 0f)
		{
			if (_gameObject == null)
			{
				return;
			}
			_bounds = item.CachedBounds;
			_gameObject.name = item.ToString();
			if (item.OwningRoom != null)
			{
				Transform transform = item.OwningRoom.FloorPlanVisual.GameObject.transform;
				if (_gameObject.transform.parent != transform)
				{
					_gameObject.transform.SetParent(transform);
				}
			}
			Vector3 vector = ((_gameObject.transform.parent == null) ? Vector3.zero : _gameObject.transform.parent.position);
			DesiredPosition = item.WorldPosition - vector + cellOffset;
			DesiredRotation = Quaternion.Euler(0f, item.Rotation + cellRotation, 0f);
			if (snap)
			{
				_gameObject.transform.localPosition = DesiredPosition;
				_gameObject.transform.rotation = DesiredRotation;
			}
			if (_useEditingMaterials)
			{
				bool flag = item.GetComponent<RoomItemSellInvalidComponent>() != null;
				foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
				{
					rendererInstance.Renderer.materials = (flag ? rendererInstance.SellMaterials : rendererInstance.ValidMaterials);
				}
				if (itemOnCursor && _rendererInstances.Count != 0)
				{
					RoomItemVisualInvalidComponent roomItemVisualInvalidComponent = _gameObject.GetComponent<RoomItemVisualInvalidComponent>();
					if (roomItemVisualInvalidComponent == null)
					{
						roomItemVisualInvalidComponent = _gameObject.AddComponent<RoomItemVisualInvalidComponent>();
						roomItemVisualInvalidComponent.Initialise(this, _roomItemEditConfig);
					}
					if (newItemOnCursor)
					{
						roomItemVisualInvalidComponent.Reset();
					}
					roomItemVisualInvalidComponent.SetValid(item.IsValid);
				}
			}
			if (item.MaintenanceLevel != null)
			{
				RoomItemMaintenanceVisualComponent orAddComponent = GameObject.GetOrAddComponent<RoomItemMaintenanceVisualComponent>();
				if (orAddComponent != null)
				{
					orAddComponent.Initialise(item.MaintenanceLevel);
				}
			}
			if (_startTransforms == null)
			{
				_startTransforms = new Dictionary<string, Transform>();
				foreach (string startSocketName in item.StartSocketNames)
				{
					Transform transform2 = _gameObject.transform.FindChildRecursively(startSocketName);
					if (transform2 != null)
					{
						_startTransforms.Add(startSocketName, transform2);
					}
				}
			}
			Vector3 position = GameObject.transform.position;
			Quaternion rotation = GameObject.transform.rotation;
			_worldBounds.Clear();
			for (int i = 0; i < _bounds.Length; i++)
			{
				Bounds item2 = _bounds[i].Transform(position, rotation);
				_worldBounds.Add(item2);
			}
			UpdateRenderLayer(item);
		}

		private void UpdateRenderLayer(RoomItem item)
		{
			if (item.Definition.ItemType == RoomItemDefinition.Type.Landscape)
			{
				return;
			}
			FloorPlan floorPlan = item.FloorPlan;
			if (floorPlan.HospitalMap == null || !floorPlan.HospitalMap.FloorPlan.HasNoVisibleExteriorWalls())
			{
				return;
			}
			int num = ((floorPlan.Definition.IsHospitalOrBay || floorPlan.Definition.IsLowWallRoom()) ? OutdoorLayer : 0);
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				GameObject gameObject = rendererInstance.Renderer.gameObject;
				if (gameObject.layer != num)
				{
					gameObject.layer = num;
				}
			}
		}

		public void CursorUpdate()
		{
			Transform transform = _gameObject.transform;
			float y = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, DesiredRotation.eulerAngles.y, ref _rotationDampVelocity, GameAlgorithms.Config.CursorRotationDampTime, float.PositiveInfinity, Time.unscaledDeltaTime);
			transform.rotation = Quaternion.Euler(0f, y, 0f);
			transform.localPosition = Vector3.SmoothDamp(transform.localPosition, DesiredPosition, ref _positionDampVelocity, GameAlgorithms.Config.CursorPositionDampTime, float.PositiveInfinity, Time.unscaledDeltaTime);
		}

		public void SaveAnimatorState()
		{
			if (Animator != null && AnimationGraph != null)
			{
				_savedAnimatorState = new AnimatorSavedState(Animator);
			}
		}

		public void RestoreAnimatorState()
		{
			if (Animator != null && AnimationGraph != null && _savedAnimatorState != null)
			{
				_savedAnimatorState.Restore(Animator);
			}
		}

		public void CopyAnimatorStateFrom(RoomItemVisual sourceItem)
		{
			if (Animator != null && sourceItem.Animator != null)
			{
				new AnimatorSavedState(sourceItem.Animator).Restore(Animator);
			}
		}

		public bool RayCast(Ray ray, out float distance)
		{
			if (_meshColliders.Length == 0)
			{
				foreach (Bounds worldBound in _worldBounds)
				{
					if (worldBound.IntersectRay(ray, out distance))
					{
						return true;
					}
				}
			}
			else
			{
				MeshCollider[] meshColliders = _meshColliders;
				foreach (MeshCollider meshCollider in meshColliders)
				{
					if (meshCollider != null && meshCollider.Raycast(ray, out var hitInfo, 400f))
					{
						distance = hitInfo.distance;
						return true;
					}
				}
			}
			distance = 0f;
			return false;
		}

		public Vector3 GetMenuAnchorPosition()
		{
			Bounds bounds = ((_meshColliders.Length == 0) ? _worldBounds[0] : _meshColliders[0].bounds);
			return new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);
		}

		public void SetMaintenanceMaterials(Material[] materials)
		{
			if (_rendererInstances.Count != 0)
			{
				RoomItemRendererInstance roomItemRendererInstance = _rendererInstances[0];
				roomItemRendererInstance.OriginalMaterials = materials;
				if (!_useValueMaterials)
				{
					roomItemRendererInstance.Renderer.sharedMaterials = materials;
				}
			}
		}

		public void SwapMaterials(Material[] oldMaterials, Material[] newMaterials)
		{
			if (_rendererInstances.Count == 0)
			{
				return;
			}
			foreach (RoomItemRendererInstance rendererInstance in _rendererInstances)
			{
				if (rendererInstance.OriginalMaterials.Contains(oldMaterials[0]))
				{
					rendererInstance.OriginalMaterials = newMaterials;
					if (!_useValueMaterials)
					{
						rendererInstance.Renderer.sharedMaterials = newMaterials;
					}
				}
			}
		}
	}
}
