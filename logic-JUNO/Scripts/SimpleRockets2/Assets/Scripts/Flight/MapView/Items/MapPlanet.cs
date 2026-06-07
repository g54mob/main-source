using System;
using System.Linq;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Terrain;
using Assets.Scripts.Terrain.Rendering;
using ModApi.Common;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapPlanet : MapOrbitNode, ITargetableItem, ICameraFocusable
	{
		private static class ShaderPropertyIds
		{
			public static readonly int VertexDisplacementLod = Shader.PropertyToID("_VertexDisplacementLod");
		}

		private CameraFocusableItemDestroyedHandler _cameraFocusableDestroyed;

		private Texture _colorsCubemapTex;

		private PlanetCubemapsRequest _cubemapRequest;

		private PlanetShaderDynamicData _dynamicShaderData;

		private bool _inPlanetStudio;

		private bool _isCameraTargetsAssociatedPlanet;

		private ILightPosition _lightPosition;

		private ICurrentCameraTarget _mapCamera;

		private IMapOptions _mapOptions;

		private float _mapScaledPlanetRadius;

		private Texture _normalCubemapTex;

		private Material _orbitLineMaterial;

		private Shader _orbitLineShader;

		private PlanetCubemapData _planetCubemapData;

		private PlanetMeshes.PlanetMeshQuality _planetMeshQuality;

		private PlanetRenderingData _planetRenderingData;

		private bool _renderIcon;

		private GameObject _scaledSpacePlanetMesh;

		private MeshFilter _scaledSpacePlanetMeshFilter;

		private Material _scaledSpacePlanetMeshMaterial;

		private bool _shaderUsesVertexDisplacement;

		private GameObject _sphereOfInfluence;

		private PlanetShaderStaticData _staticShaderData;

		IPlanetNode ICameraFocusable.AssociatedPlanet => base.OrbitInfo.OrbitNode as IPlanetNode;

		string ITargetableItem.ClosestEncounterIcon => "PlanetIconAlternative";

		public override bool DisplayManeuverNodeAdderOnMouseHover => true;

		bool ICameraFocusable.FocusByClick => true;

		ICameraFocusable ICameraFocusable.ItemToFocusOnWhenDeleted => base.ItemRegistry.GetPlanet(base.OrbitInfo.OrbitNode.Parent);

		float ICameraFocusable.MinZoomDistance => (float)(PlanetNode.PlanetData.Radius * base.CoordinateConverter.MapScale * 1.5);

		string ITargetableItem.Name => base.OrbitInfo.OrbitNode.Name;

		public INavigationTargetProvider NavigationTargetProvider { get; private set; }

		IOrbitNode ICameraFocusable.OrbitNode => base.OrbitInfo.OrbitNode;

		public float PixelSize { get; private set; }

		public PlanetNode PlanetNode { get; set; }

		Vector3 ICameraFocusable.Position => (Vector3)WorldPosition;

		public Vector3d WorldPosition => base.CoordinateConverter.ConvertSolarToMapView(PlanetNode.SolarPosition);

		protected override bool ShowTooltipOnHover
		{
			get
			{
				if (base.ItemIcon.enabled)
				{
					return base.UiVisibilityAtItemPosition > 0f;
				}
				return false;
			}
		}

		event CameraFocusableItemDestroyedHandler ICameraFocusable.Destroyed
		{
			add
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Combine(_cameraFocusableDestroyed, value);
			}
			remove
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Remove(_cameraFocusableDestroyed, value);
			}
		}

		public static MapPlanet Create(IIocContainer ioc, IMapViewContext mapViewContext, PlanetNode planetNode, Camera mapCamera)
		{
			Sprite distanceIcon = UiUtils.LoadIconSprite("PlanetIcon");
			IObjectContainerProvider objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(mapViewContext);
			MapPlanet mapPlanet = MapItem.Create<MapPlanet>(ioc, mapViewContext, planetNode, planetNode.PlanetData.Name, objectContainerProvider.PlanetsCanvases, mapCamera, objectContainerProvider.Planets, distanceIcon);
			mapPlanet.name = planetNode.PlanetData.Name;
			mapPlanet.Initialize(planetNode, ioc.Resolve<ILightPosition>(mapViewContext), ioc.Resolve<IMapOptions>());
			return mapPlanet;
		}

		public void Delete()
		{
			base.OrbitLine?.Destroy();
			foreach (IPlanetNode item in PlanetNode.ChildPlanets.ToList())
			{
				base.ItemRegistry.GetPlanet(item).Delete();
			}
			Destroy();
			PlanetNode.Parent?.RemoveChildNode(PlanetNode);
		}

		public override void Destroy()
		{
			base.Destroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
		}

		double ITargetableItem.GetSphereOfInfluence(MapOrbitInfo other)
		{
			return (base.OrbitInfo.OrbitNode as PlanetNode).SphereOfInfluence;
		}

		public override void OnAfterCameraPositioned()
		{
			base.OnAfterCameraPositioned();
			UpdateShaderDynamicData(_scaledSpacePlanetMeshMaterial);
			if (_renderIcon)
			{
				ICurrentCameraTarget mapCamera = _mapCamera;
				float num = Mathf.Min(Mathf.Min(mapCamera.DistanceFromTarget, mapCamera.DistanceFromTargetsAssociatedPlanet), base.UiCameraDist);
				base.UiMaxRenderDist = num * num / (40f * _mapScaledPlanetRadius);
			}
			else
			{
				base.UiMaxRenderDist = float.Epsilon;
			}
			if (_orbitLineMaterial != null)
			{
				base.OrbitLine.UiMaxRenderDist = base.UiMaxRenderDist;
				_orbitLineMaterial.SetFloat("_maxDist", base.OrbitLine.UiMaxRenderDist);
			}
			float num2 = 1f - base.UiVisibilityAtItemPosition;
			if ((double)num2 > 0.05)
			{
				if (!_scaledSpacePlanetMesh.activeSelf)
				{
					_scaledSpacePlanetMesh.SetActive(value: true);
				}
				Vector3 normalized = base.transform.InverseTransformDirection(_lightPosition.LightPosition - base.transform.position).normalized;
				_scaledSpacePlanetMeshMaterial.SetVector("_lightDir", normalized);
				_scaledSpacePlanetMeshMaterial.SetFloat("_Alpha", num2);
			}
			else if (_scaledSpacePlanetMesh.activeSelf)
			{
				_scaledSpacePlanetMesh.SetActive(value: false);
			}
			if (base.UiVisibilityAtItemPositionUnclamped < -1000f)
			{
				if (base.OrbitLine != null)
				{
					base.OrbitLine.SetDrawingAllowed(allowed: false);
				}
			}
			else if (base.OrbitLine != null)
			{
				base.OrbitLine.SetDrawingAllowed(allowed: true);
			}
			if (!_renderIcon)
			{
				return;
			}
			UpdateIconPosition();
			UpdateTooltip();
			if (base.Data.ShowIcons)
			{
				if (base.UiVisibilityAtItemPosition > 0.1f)
				{
					if (!base.ItemIcon.enabled)
					{
						base.ItemIcon.enabled = true;
					}
				}
				else if (base.ItemIcon.enabled)
				{
					base.ItemIcon.enabled = false;
				}
			}
			else if (base.ItemIcon.enabled)
			{
				base.ItemIcon.enabled = false;
			}
		}

		public override void OnBeforeCameraPositioned()
		{
			base.OnBeforeCameraPositioned();
			base.transform.SetPositionAndRotation((Vector3)WorldPosition, PlanetNode?.Rotation.ToQuaternion() ?? Quaternion.identity);
			if (ModApi.Common.Game.InPlanetStudioScene && _mapCamera.Target == this)
			{
				base.OrbitLine?.ForceUpdate();
			}
		}

		public void OnCameraTargetsAssociatedPlanetStateChanged(bool isCameraTargetsAssociatedPlanet)
		{
			_isCameraTargetsAssociatedPlanet = isCameraTargetsAssociatedPlanet;
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.QualitySettings.Terrain.CubemapSettings;
			int requestedSize = (isCameraTargetsAssociatedPlanet ? cubemapSettings.MapViewHighDetailSize : cubemapSettings.MapViewLowDetailSize);
			_cubemapRequest?.UpdateRequestedSize(requestedSize);
		}

		public void SetSoi(double newSoi)
		{
			PlanetNode.SetSoi(newSoi);
		}

		protected override void Awake()
		{
			base.Awake();
			base.gameObject.AddComponent<ClickableGameObjectScript>();
			_inPlanetStudio = ModApi.Common.Game.InPlanetStudioScene;
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
			UpdatePixelSize(base.Camera);
			UpdateLod();
			if (_inPlanetStudio && _cubemapRequest.PlanetData != PlanetNode.PlanetData)
			{
				Debug.Log("MapPlanet: PlanetData has changed, creating new cubemap request.");
				_cubemapRequest.Cancel();
				CreateCubemapRequest();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ModApi.Common.Game.Instance.Settings.Quality.Map.PlanetVertexDisplacement.Changed -= PlanetVertexDataDisplacementSettingChanged;
			ModApi.Common.Game.Instance.QualitySettings.VisualEffects.Atmosphere.Changed -= OnAtmosphereQualityChanged;
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
			if (_scaledSpacePlanetMeshMaterial != null)
			{
				UnityEngine.Object.Destroy(_scaledSpacePlanetMeshMaterial);
				_scaledSpacePlanetMeshMaterial = null;
			}
			if (base.Data != null)
			{
				base.Data.ShowSphereOfInfluenceChanged -= OnShowSphereOfInfluenceChanged;
			}
		}

		protected override void Start()
		{
			base.Start();
			PlanetMeshes.Initialize();
			_scaledSpacePlanetMesh = CreatePlanetMesh(PlanetNode, base.transform, base.CoordinateConverter, out _scaledSpacePlanetMeshMaterial);
			_scaledSpacePlanetMeshFilter = _scaledSpacePlanetMesh.GetComponent<MeshFilter>();
			_scaledSpacePlanetMeshFilter.mesh = PlanetMeshes.MeshQualityHigh;
			_planetMeshQuality = PlanetMeshes.PlanetMeshQuality.High;
			if (PlanetNode.Parent != null)
			{
				_orbitLineShader = Shader.Find("Jundroo/MapView/PlanetOrbitLine");
				_orbitLineMaterial = new Material(_orbitLineShader);
				base.Color = PlanetNode.PlanetData.PlanetarySystemDefinedData.OrbitColor;
				SetOrbitLine(MapOrbitLine.Create(base.Ioc, base.MapViewContext, PlanetNode, base.Data, base.Color, base.name + " Orbit", base.Camera, _orbitLineMaterial, isSharedMaterial: false));
				_sphereOfInfluence = MapUtils.CreateSoiSphere(base.OrbitInfo.OrbitNode as PlanetNode, base.ItemName, base.gameObject.layer, base.transform, base.CoordinateConverter);
				_sphereOfInfluence.gameObject.SetActive(ModApi.Common.Game.InPlanetStudioScene || base.Data.ShowSphereOfInfluence);
			}
			if (PlanetNode.Orbit == null)
			{
				_scaledSpacePlanetMeshMaterial.DisableKeyword("SR_LIGHTING_LOW");
				_scaledSpacePlanetMeshMaterial.DisableKeyword("SR_LIGHTING_MEDIUM");
				_scaledSpacePlanetMeshMaterial.DisableKeyword("SR_LIGHTING_HIGH");
				_scaledSpacePlanetMeshMaterial.EnableKeyword("SR_LIGHTING_NONE");
			}
			ModApi.Common.Game.Instance.Settings.Quality.Map.PlanetVertexDisplacement.Changed += PlanetVertexDataDisplacementSettingChanged;
			ModApi.Common.Game.Instance.QualitySettings.VisualEffects.Atmosphere.Changed += OnAtmosphereQualityChanged;
		}

		private void CreateCubemapRequest()
		{
			TerrainQualitySettings.CubemapQualitySettings cubemapSettings = ModApi.Common.Game.Instance.QualitySettings.Terrain.CubemapSettings;
			int size = (_isCameraTargetsAssociatedPlanet ? cubemapSettings.MapViewHighDetailSize : cubemapSettings.MapViewLowDetailSize);
			_cubemapRequest = PlanetNode.PlanetData.RequestCubemaps("Map View", size, delegate(PlanetCubemapsRequest request)
			{
				_colorsCubemapTex = request.CubemapColor;
				_normalCubemapTex = request.CubemapNormals;
				if (_scaledSpacePlanetMeshMaterial != null)
				{
					UpdateShaderData(_scaledSpacePlanetMeshMaterial);
				}
			});
		}

		private Material CreatePlanetMaterial()
		{
			CreateCubemapRequest();
			return UnityEngine.Object.Instantiate(ModApi.Common.Game.Instance.ResourceLoader.LoadMaterial("Planets/Materials/GroundFromSpace"));
		}

		private GameObject CreatePlanetMesh(PlanetNode planetNode, Transform parent, IMapViewCoordinateConverter coordinateConverter, out Material material)
		{
			GameObject gameObject = null;
			if (true)
			{
				gameObject = ModApi.Common.Game.Instance.ResourceLoader.InstantiatePrefab("Planets/PlanetSphere");
				gameObject.AddComponent<SphereCollider>().isTrigger = true;
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				_planetRenderingData = new PlanetRenderingData(planetNode.PlanetData, gameObject.transform, base.Camera.transform, _lightPosition.Transform);
				_staticShaderData = new PlanetShaderStaticData(_planetRenderingData, gameObject.transform, skyShader: false, scaledSpaceShader: true, fadeSkyboxDuringDay: false);
				_dynamicShaderData = new PlanetShaderDynamicData(_staticShaderData);
				_planetCubemapData = PlanetCubemapUtility.GetCubemapData(planetNode.PlanetData, create: true);
				Material material2 = CreatePlanetMaterial();
				component.material = material2;
				material = component.material;
			}
			else
			{
				gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject.name = "Mesh";
				gameObject.GetComponent<Collider>().isTrigger = true;
				_planetCubemapData = PlanetCubemapData.GetDefault();
				MeshRenderer component2 = gameObject.GetComponent<MeshRenderer>();
				material = component2.sharedMaterial;
			}
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			gameObject.layer = parent.gameObject.layer;
			float num = (float)(planetNode.PlanetData.Radius * coordinateConverter.MapScale);
			gameObject.transform.localScale = Vector3.one * num;
			return gameObject;
		}

		private void Initialize(PlanetNode planetNode, ILightPosition lightPosition, IMapOptions mapOptions)
		{
			IIocContainer ioc = base.Ioc;
			PlanetNode = planetNode;
			base.Selectable = true;
			NavigationTargetProvider = ioc.Resolve<INavigationTargetProvider>(base.MapViewContext);
			_mapCamera = ioc.Resolve<ICurrentCameraTarget>(base.MapViewContext);
			_lightPosition = lightPosition;
			_mapOptions = mapOptions;
			base.Data.ShowSphereOfInfluenceChanged += OnShowSphereOfInfluenceChanged;
			_renderIcon = base.OrbitInfo.OrbitNode.Orbit != null || ModApi.Common.Game.InPlanetStudioScene;
			if (_renderIcon)
			{
				_mapScaledPlanetRadius = (float)(PlanetNode.PlanetData.Radius * base.CoordinateConverter.MapScale);
			}
			else
			{
				base.ItemIcon.enabled = false;
			}
		}

		private void OnAtmosphereQualityChanged(object sender, SettingChangedEventArgs<VisualEffectsQualitySettings.AtmosphereQuality> e)
		{
			UpdateAtmosphereQuality(_scaledSpacePlanetMeshMaterial);
		}

		private void OnShowSphereOfInfluenceChanged(bool newValue)
		{
			if (_sphereOfInfluence != null)
			{
				_sphereOfInfluence.gameObject.SetActive(ModApi.Common.Game.InPlanetStudioScene || base.Data.ShowSphereOfInfluence);
			}
		}

		private void PlanetVertexDataDisplacementSettingChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			UpdateShaderData(_scaledSpacePlanetMeshMaterial);
		}

		private void UpdateAtmosphereQuality(Material material)
		{
			ScaledSpaceRenderer.UpdateShaderKeywords(material, ScaledSpaceRenderer.GetAtmosphereQuality(_planetRenderingData));
		}

		private void UpdateLod()
		{
			float pixelSize = PixelSize;
			if (_shaderUsesVertexDisplacement && _normalCubemapTex != null)
			{
				int num = _normalCubemapTex.width;
				int num2 = -1;
				while (pixelSize >= 8f)
				{
					num2++;
					num /= 2;
					if (pixelSize > (float)num)
					{
						break;
					}
				}
				if (num2 == -1)
				{
					Material scaledSpacePlanetMeshMaterial = _scaledSpacePlanetMeshMaterial;
					if (scaledSpacePlanetMeshMaterial.IsKeywordEnabled("NORMALMAP_WITH_VERTEX_DISPLACEMENT"))
					{
						scaledSpacePlanetMeshMaterial.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
						scaledSpacePlanetMeshMaterial.EnableKeyword("NORMALMAP");
					}
				}
				else
				{
					Material scaledSpacePlanetMeshMaterial2 = _scaledSpacePlanetMeshMaterial;
					scaledSpacePlanetMeshMaterial2.SetFloat(ShaderPropertyIds.VertexDisplacementLod, num2);
					if (!scaledSpacePlanetMeshMaterial2.IsKeywordEnabled("NORMALMAP_WITH_VERTEX_DISPLACEMENT"))
					{
						scaledSpacePlanetMeshMaterial2.DisableKeyword("NORMALMAP");
						scaledSpacePlanetMeshMaterial2.EnableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
					}
				}
			}
			if (pixelSize >= 32f)
			{
				UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality.High);
			}
			else if (pixelSize >= 8f)
			{
				UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality.Medium);
			}
			else
			{
				UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality.Low);
			}
		}

		private void UpdatePixelSize(Camera camera)
		{
			Transform transform = camera.transform;
			Vector3 position = base.transform.position;
			Vector3 position2 = transform.position;
			float magnitude = (position - position2).magnitude;
			Vector3 vector = position2 + transform.forward * magnitude;
			Vector3 position3 = vector + transform.right * (float)(PlanetNode.PlanetData.Radius * base.CoordinateConverter.MapScale);
			Vector3 vector2 = camera.WorldToScreenPoint(vector);
			PixelSize = (camera.WorldToScreenPoint(position3).x - vector2.x) * 2f;
		}

		private void UpdatePlanetMeshLod(PlanetMeshes.PlanetMeshQuality quality)
		{
			if (_planetMeshQuality != quality)
			{
				_planetMeshQuality = quality;
				_scaledSpacePlanetMeshFilter.mesh = PlanetMeshes.GetMesh(quality);
			}
		}

		private void UpdateShaderData(Material material)
		{
			IPlanetData planetData = PlanetNode.PlanetData;
			material.SetTexture("_Cube", _colorsCubemapTex);
			material.SetVector("_MaxColors", _planetCubemapData.MaxColor);
			_shaderUsesVertexDisplacement = false;
			if ((object)_normalCubemapTex != null)
			{
				material.SetTexture("_BumpCube", _normalCubemapTex);
				if (ModApi.Common.Game.Instance.QualitySettings.Map.PlanetVertexDisplacement.Value)
				{
					double radius = planetData.Radius;
					material.SetFloat("_MinASL", (float)((radius + (double)_planetCubemapData.MinHeight) / radius));
					material.SetFloat("_MaxASL", (float)((radius + (double)_planetCubemapData.MaxHeight) / radius));
					material.DisableKeyword("NORMALMAP");
					material.EnableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
					_shaderUsesVertexDisplacement = true;
				}
				else
				{
					material.EnableKeyword("NORMALMAP");
					material.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
				}
			}
			else
			{
				material.DisableKeyword("NORMALMAP");
				material.DisableKeyword("NORMALMAP_WITH_VERTEX_DISPLACEMENT");
			}
			UpdateAtmosphereQuality(material);
			UpdateShaderStaticData(material);
			UpdateShaderDynamicData(material);
		}

		private void UpdateShaderDynamicData(Material material)
		{
			_dynamicShaderData.RadiusScale = base.CoordinateConverter.MapScale;
			_dynamicShaderData.Update(_isCameraTargetsAssociatedPlanet);
			_dynamicShaderData.SetShaderProperties(material);
		}

		private void UpdateShaderStaticData(Material material)
		{
			_staticShaderData.Update();
			_staticShaderData.SetShaderProperties(material);
		}
	}
}
