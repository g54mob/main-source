using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	[AddComponentMenu("MagicaCloth2/MagicaCloth")]
	[HelpURL("https://magicasoft.jp/en/mc2_magicaclothcomponent/")]
	public class MagicaCloth : ClothBehaviour, IValid
	{
		[SerializeField]
		private ClothSerializeData serializeData;

		[SerializeField]
		internal ClothSerializeData2 serializeData2;

		private ClothProcess process;

		[HideInInspector]
		public float animationPoseRatioProperty;

		private float _animationPoseRatioProperty;

		[HideInInspector]
		public float gravityProperty;

		private float _gravityProperty;

		[HideInInspector]
		public float dampingProperty;

		private float _dampingProperty;

		[HideInInspector]
		public float worldInertiaProperty;

		private float _worldInertiaProperty;

		[HideInInspector]
		public float localInertiaProperty;

		private float _localInertiaProperty;

		[HideInInspector]
		public float windInfluenceProperty;

		private float _windInfluenceProperty;

		[HideInInspector]
		public float blendWeightProperty;

		private float _blendWeightProperty;

		public Action<MagicaCloth, bool> OnBuildComplete;

		public Action<MagicaCloth, Renderer, bool> OnRendererMeshChange;

		public ClothSerializeData SerializeData => null;

		public ClothProcess Process => null;

		public Transform ClothTransform => null;

		public MagicaCloth SyncPartnerCloth => null;

		public bool IsValid()
		{
			return false;
		}

		protected void Reset()
		{
		}

		protected void OnValidate()
		{
		}

		protected void Awake()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		protected void Start()
		{
		}

		protected void OnDestroy()
		{
		}

		public override int GetMagicaHashCode()
		{
			return 0;
		}

		internal void InitAnimationProperty()
		{
		}

		private void OnDidApplyAnimationProperties()
		{
		}

		public ClothSerializeData2 GetSerializeData2()
		{
			return null;
		}

		public void Initialize()
		{
		}

		public void DisableAutoBuild()
		{
		}

		public bool BuildAndRun()
		{
			return false;
		}

		public void ReplaceTransform(Dictionary<string, Transform> targetTransformDict)
		{
		}

		public HashSet<Transform> GetUsedTransform()
		{
			return null;
		}

		public void SetParameterChange()
		{
		}

		public void SetTimeScale(float timeScale)
		{
		}

		public float GetTimeScale()
		{
			return 0f;
		}

		public void ResetCloth(bool keepPose = false)
		{
		}

		public Vector3 GetCenterPosition()
		{
			return default(Vector3);
		}

		public void AddForce(Vector3 forceDirection, float forceVelocity, ClothForceMode fmode = ClothForceMode.VelocityAdd)
		{
		}

		public void SetSkipWriting(bool sw)
		{
		}

		private RenderData GetRenderData(Renderer ren)
		{
			return null;
		}

		public Mesh GetOriginalMesh(Renderer ren)
		{
			return null;
		}

		public Mesh GetCustomMesh(Renderer ren)
		{
			return null;
		}

		public List<Transform> GetCustomBones(Renderer ren)
		{
			return null;
		}
	}
}
