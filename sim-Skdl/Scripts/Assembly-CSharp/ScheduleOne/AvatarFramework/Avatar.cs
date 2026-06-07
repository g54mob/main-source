using System;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.AvatarFramework.Emotions;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.AvatarFramework.Impostors;
using ScheduleOne.Core;
using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework
{
	public class Avatar : MonoBehaviour, IThirdPersonReferencesProvider
	{
		public const int MAX_ACCESSORIES = 9;

		public const bool CombinedLayersEnabled = true;

		public const float DEFAULT_SMOOTHNESS = 0.25f;

		private static float maleShoulderScale;

		private static float femaleShoulderScale;

		[Header("References")]
		public AvatarAnimation Animation;

		public AvatarLookController LookController;

		public SkinnedMeshRenderer[] BodyMeshes;

		public SkinnedMeshRenderer[] ShapeKeyMeshes;

		public SkinnedMeshRenderer FaceMesh;

		public EyeController Eyes;

		public EyebrowController EyeBrows;

		public Transform BodyContainer;

		public Transform Armature;

		public Transform LeftShoulder;

		public Transform RightShoulder;

		public Transform HeadBone;

		public Transform HipBone;

		public Transform LeftFootBone;

		public Transform RightFootBone;

		public Rigidbody[] RagdollRBs;

		public Collider[] RagdollColliders;

		public Rigidbody MiddleSpineRB;

		public Rigidbody[] ImpactForceRBs;

		public AvatarEmotionManager EmotionManager;

		public AvatarEffects Effects;

		public Transform MiddleSpine;

		public Transform LowerSpine;

		public Transform LowestSpine;

		public AvatarImpostor Impostor;

		public ParticleSystem BloodParticles;

		[Header("Settings")]
		public AvatarSettings InitialAvatarSettings;

		public Material DefaultAvatarMaterial;

		public bool UseCombinedLayer;

		public UnityEvent<bool, bool, bool> onRagdollChange;

		[SerializeField]
		[Header("Data - readonly")]
		protected float appliedGender;

		[SerializeField]
		protected float appliedWeight;

		[SerializeField]
		protected Hair appliedHair;

		[SerializeField]
		protected Color appliedHairColor;

		[SerializeField]
		protected Accessory[] appliedAccessories;

		[SerializeField]
		protected bool wearingHairBlockingAccessory;

		private float additionalWeight;

		private float additionalGender;

		[Header("Runtime loading")]
		public AvatarSettings SettingsToLoad;

		public UnityEvent onSettingsLoaded;

		private Vector3 originalHipPos;

		private bool usingCombinedLayer;

		private bool blockEyeFaceLayers;

		public Transform RightHandContainer => null;

		public Transform LeftHandContainer => null;

		public Transform RightHandAlignmentPoint => null;

		public Transform LeftHandAlignmentPoint => null;

		public bool Ragdolled { get; protected set; }

		public AvatarEquippable CurrentEquippable { get; protected set; }

		public AvatarSettings CurrentSettings { get; protected set; }

		public Transform CenterPointTransform => null;

		public Vector3 CenterPoint => default(Vector3);

		[Button]
		public void Load()
		{
		}

		[Button]
		public void LoadNaked()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Update()
		{
		}

		public void SetVisible(bool vis)
		{
		}

		public void GetMugshot(Action<Texture2D> callback)
		{
		}

		public void SetEmission(Color color)
		{
		}

		public bool IsMale()
		{
			return false;
		}

		public bool IsWhite()
		{
			return false;
		}

		public string GetFormalAddress(bool capitalized = true)
		{
			return null;
		}

		public string GetThirdPersonAddress(bool capitalized = true)
		{
			return null;
		}

		public string GetThirdPersonPronoun(bool capitalized = true)
		{
			return null;
		}

		public void SetAnimationBool(string name, bool value)
		{
		}

		public void SetAnimationTrigger(string name)
		{
		}

		private void ApplyShapeKeys(float gender, float weight, bool bodyOnly = false)
		{
		}

		private void SetFeetShrunk(bool shrink, float reduction)
		{
		}

		private void SetWearingHairBlockingAccessory(bool blocked)
		{
		}

		public void LoadAvatarSettings(AvatarSettings settings)
		{
		}

		public void LoadNakedSettings(AvatarSettings settings, int maxLayerOrder = 19)
		{
		}

		public void ApplyBodySettings(AvatarSettings settings)
		{
		}

		public void SetAdditionalWeight(float weight)
		{
		}

		public void SetAdditionalGender(float gender)
		{
		}

		public void SetSkinColor(Color color)
		{
		}

		public void ApplyHairSettings(AvatarSettings settings)
		{
		}

		public void SetHairVisible(bool visible)
		{
		}

		public void ApplyHairColorSettings(AvatarSettings settings)
		{
		}

		public void OverrideHairColor(Color color)
		{
		}

		public void ResetHairColor()
		{
		}

		public void ApplyEyeBallSettings(AvatarSettings settings)
		{
		}

		public void ApplyEyeLidSettings(AvatarSettings settings)
		{
		}

		public void ApplyEyeLidColorSettings(AvatarSettings settings)
		{
		}

		public void ApplyEyebrowSettings(AvatarSettings settings)
		{
		}

		public void SetBlockEyeFaceLayers(bool block)
		{
		}

		public void ApplyFaceLayerSettings(AvatarSettings settings)
		{
		}

		private void SetFaceLayer(int index, string assetPath, Color color)
		{
		}

		public void SetFaceTexture(Texture2D tex, Color color)
		{
		}

		public void ApplyBodyLayerSettings(AvatarSettings settings, int maxOrder = -1)
		{
		}

		private void SetBodyLayer(int index, string assetPath, Color color)
		{
		}

		public void ApplyAccessorySettings(AvatarSettings settings)
		{
		}

		private void DestroyAccessories()
		{
		}

		public virtual void SetRagdollPhysicsEnabled(bool ragdollEnabled, bool playStandUpAnim = true)
		{
		}

		public virtual AvatarEquippable SetEquippable(string assetPath)
		{
			return null;
		}

		public virtual void ReceiveEquippableMessage(string message, object data)
		{
		}
	}
}
