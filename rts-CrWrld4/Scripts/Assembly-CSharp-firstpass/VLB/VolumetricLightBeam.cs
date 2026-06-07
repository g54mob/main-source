using System;
using System.Collections;
using UnityEngine;

namespace VLB
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[SelectionBase]
	public class VolumetricLightBeam : MonoBehaviour
	{
		public bool colorFromLight;

		public ColorMode colorMode;

		public Color color;

		public Gradient colorGradient;

		public float alphaInside;

		public float alphaOutside;

		public BlendingMode blendingMode;

		public bool spotAngleFromLight;

		public float spotAngle;

		public float coneRadiusStart;

		public MeshType geomMeshType;

		public int geomCustomSides;

		public int geomCustomSegments;

		public bool geomCap;

		public bool fadeEndFromLight;

		public AttenuationEquation attenuationEquation;

		public float attenuationCustomBlending;

		public float fadeStart;

		public float fadeEnd;

		public float depthBlendDistance;

		public float cameraClippingDistance;

		public float glareFrontal;

		public float glareBehind;

		[Obsolete]
		public float boostDistanceInside;

		[Obsolete]
		public float fresnelPowInside;

		public float fresnelPow;

		public bool noiseEnabled;

		public float noiseIntensity;

		public bool noiseScaleUseGlobal;

		public float noiseScaleLocal;

		public bool noiseVelocityUseGlobal;

		public Vector3 noiseVelocityLocal;

		private Plane m_PlaneWS;

		[SerializeField]
		private int pluginVersion;

		[SerializeField]
		private bool _TrackChangesDuringPlaytime;

		[SerializeField]
		private int _SortingLayerID;

		[SerializeField]
		private int _SortingOrder;

		private BeamGeometry m_BeamGeom;

		private Coroutine m_CoPlaytimeUpdate;

		private Light _CachedLight;

		public float coneAngle => 0f;

		public float coneRadiusEnd => 0f;

		public float coneVolume => 0f;

		public float coneApexOffsetZ => 0f;

		public int geomSides
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int geomSegments
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float attenuationLerpLinearQuad => 0f;

		public int sortingLayerID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string sortingLayerName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int sortingOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool trackChangesDuringPlaytime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isCurrentlyTrackingChanges => false;

		public bool hasGeometry => false;

		public Bounds bounds => default(Bounds);

		public int blendingModeAsInt => 0;

		public string meshStats => null;

		public int meshVerticesCount => 0;

		public int meshTrianglesCount => 0;

		private Light lightSpotAttached => null;

		public void SetClippingPlane(Plane planeWS)
		{
		}

		public void SetClippingPlaneOff()
		{
		}

		public bool IsColliderHiddenByDynamicOccluder(Collider collider)
		{
			return false;
		}

		public float GetInsideBeamFactor(Vector3 posWS)
		{
			return 0f;
		}

		public float GetInsideBeamFactorFromObjectSpacePos(Vector3 posOS)
		{
			return 0f;
		}

		[Obsolete]
		public void Generate()
		{
		}

		public virtual void GenerateGeometry()
		{
		}

		public virtual void UpdateAfterManualPropertyChange()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void StartPlaytimeUpdateIfNeeded()
		{
		}

		private IEnumerator CoPlaytimeUpdate()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void DestroyBeam()
		{
		}

		private void AssignPropertiesFromSpotLight(Light lightSpot)
		{
		}

		private void ClampProperties()
		{
		}

		private void ValidateProperties()
		{
		}

		private void HandleBackwardCompatibility(int serializedVersion, int newVersion)
		{
		}
	}
}
