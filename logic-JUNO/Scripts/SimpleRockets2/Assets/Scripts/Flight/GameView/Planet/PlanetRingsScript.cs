using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.PlanetStudio;
using ModApi;
using ModApi.CelestialData;
using ModApi.Flight.GameView;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Planet
{
	public class PlanetRingsScript : MonoBehaviour
	{
		public enum RenderModeType
		{
			QuadSphere = 0,
			ScaledSpace = 1
		}

		private const double OuterRadiusLocal = 0.95;

		private Material _backMaterial;

		private Transform _cameraTransform;

		private Material _frontMaterial;

		private double _innerRadiusLocal;

		private Transform _lightTransform;

		private double _meshScale;

		private double _planetRadiusLocal;

		private Transform _quadSphereTransform;

		private RenderModeType _renderMode;

		private int _renderQueueAfterAtmosphere = 3050;

		private int _renderQueueBeforeAtmosphere = 2999;

		[SerializeField]
		private Transform _ringTransform;

		private Transform _scaledSpacePlanetTransform;

		private Texture2D _texture;

		private bool _updateRenderMode;

		public RenderModeType RenderMode
		{
			get
			{
				return _renderMode;
			}
			private set
			{
				_renderMode = value;
				int num = 0;
				double num2 = 1.0;
				if (_renderMode == RenderModeType.QuadSphere)
				{
					if (Game.InFlightScene)
					{
						IGameView gameView = Game.Instance.FlightScene.ViewManager.GameView;
						_cameraTransform = gameView.GameCamera.Transform;
						_lightTransform = gameView.SunLight.transform;
					}
					else if (Game.InPlanetStudioScene)
					{
						CelestialBodyViewerScript celestialBodyViewerScript = PlanetStudioScript.Instance?.CelestialBodyDesignerScript?.CelestialBodyViewer;
						_cameraTransform = celestialBodyViewerScript.NearCamera.transform;
						_lightTransform = celestialBodyViewerScript.SunLight.transform;
					}
					num = 0;
					_backMaterial.renderQueue = _renderQueueBeforeAtmosphere;
					_frontMaterial.renderQueue = _renderQueueAfterAtmosphere;
					num2 = _meshScale;
				}
				else
				{
					_cameraTransform = ScaledSpaceScript.Instance.Camera.transform;
					_lightTransform = ScaledSpaceScript.Instance.Sun.transform;
					num = 8;
					_backMaterial.renderQueue = _renderQueueBeforeAtmosphere;
					_frontMaterial.renderQueue = _renderQueueAfterAtmosphere;
					num2 = _meshScale * 0.0001;
				}
				base.transform.localScale = new Vector3((float)num2, (float)num2, (float)num2);
				Utilities.SetLayerRecursive(base.gameObject, num);
			}
		}

		public void Initialize(IPlanetData data, Transform scaledSpacePlanetTransform, Transform parent)
		{
			IPlanetRingsData ringsData = data.RingsData;
			double radius = data.Radius;
			base.transform.SetParent(parent, worldPositionStays: false);
			base.transform.position = Vector3.zero;
			_scaledSpacePlanetTransform = scaledSpacePlanetTransform;
			_meshScale = ringsData.OuterRadius / 0.95;
			_innerRadiusLocal = ringsData.InnerRadius / _meshScale;
			_planetRadiusLocal = radius / _meshScale;
			base.transform.localRotation = Quaternion.Euler(ringsData.Rotation);
			_updateRenderMode = true;
			CelestialFile celestialFile = (string.IsNullOrEmpty(ringsData.Texture) ? null : data.FileData.GetSupportFile(ringsData.Texture));
			if (celestialFile == null)
			{
				Debug.LogError("Unable to find planet rings texture '" + ringsData.Texture + "' for planet '" + data.Name + "'");
			}
			else
			{
				_texture = celestialFile.LoadTexture(mipmaps: true, linear: false, markNonReadable: true);
			}
		}

		public void SetQuadSphere(Transform quadSphereTransform)
		{
			_quadSphereTransform = quadSphereTransform;
			_updateRenderMode = true;
		}

		protected virtual void LateUpdate()
		{
			if (_updateRenderMode)
			{
				_updateRenderMode = false;
				RenderMode = ((_quadSphereTransform == null) ? RenderModeType.ScaledSpace : RenderModeType.QuadSphere);
			}
			UpdateRingsBasedOnCameraPosition();
			Vector3 direction;
			if (RenderMode == RenderModeType.QuadSphere)
			{
				base.transform.position = _quadSphereTransform.position;
				direction = _lightTransform.forward;
			}
			else
			{
				base.transform.position = _scaledSpacePlanetTransform.position;
				direction = base.transform.position - _lightTransform.position;
			}
			Vector3 vector = _ringTransform.InverseTransformDirection(direction);
			_frontMaterial.SetVector("_localLightDirection", vector);
			_backMaterial.SetVector("_localLightDirection", vector);
		}

		protected virtual void OnDestroy()
		{
			if (_texture != null)
			{
				Object.Destroy(_texture);
				_texture = null;
			}
		}

		protected virtual void Start()
		{
			MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
				component.mesh.bounds = new Bounds(Vector3.zero, Vector3.one);
				if (component.gameObject.name.StartsWith("Front"))
				{
					_frontMaterial = meshRenderer.material;
				}
				else
				{
					_backMaterial = meshRenderer.material;
				}
			}
			InitializeMaterial(_backMaterial);
			InitializeMaterial(_frontMaterial);
		}

		private void InitializeMaterial(Material m)
		{
			m.mainTexture = _texture;
			m.SetFloat("_innerRadius", (float)_innerRadiusLocal);
			m.SetFloat("_outerRadius", 0.95f);
			m.SetFloat("_planetRadius", (float)_planetRadiusLocal);
		}

		private void UpdateRingsBasedOnCameraPosition()
		{
			Vector3 vector = base.transform.InverseTransformPoint(_cameraTransform.position);
			float y = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			_ringTransform.localRotation = Quaternion.Euler(0f, y, 0f);
			if (RenderMode == RenderModeType.QuadSphere)
			{
				if (new Vector3(vector.x, 0f, vector.z).magnitude < (float)_innerRadiusLocal)
				{
					_frontMaterial.renderQueue = _renderQueueBeforeAtmosphere;
				}
				else
				{
					_frontMaterial.renderQueue = _renderQueueAfterAtmosphere;
				}
			}
		}
	}
}
