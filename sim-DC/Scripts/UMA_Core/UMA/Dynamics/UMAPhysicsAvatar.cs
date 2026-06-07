using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.Events;

namespace UMA.Dynamics
{
	public class UMAPhysicsAvatar : MonoBehaviour
	{
		private struct CachedBone
		{
			public Transform boneTransform;

			public Vector3 localPosition;

			public Quaternion localRotation;

			public Vector3 localScale;

			public CachedBone(Transform transform)
			{
				boneTransform = null;
				localPosition = default(Vector3);
				localRotation = default(Quaternion);
				localScale = default(Vector3);
			}
		}

		private bool _ragdolled;

		[Tooltip("Set this to true if you know the player will use a capsule collider and rigidbody")]
		public bool simplePlayerCollider;

		[Tooltip("Set this to have your body collider act as triggers when not ragdolled")]
		public bool enableColliderTriggers;

		[Tooltip("Experimental, for blending animations with physics")]
		[HideInInspector]
		[Range(0f, 1f)]
		public float ragdollBlendAmount;

		[Tooltip("Set this to snap the Avatar to the position of it's hip after ragdoll is finished")]
		public bool UpdateTransformAfterRagdoll;

		[Tooltip("Check this to set the player layer to the current layer, and read the 'ragdoll' layer from the settings")]
		public bool AutoSetLayers;

		[Tooltip("Layer to set the ragdoll colliders on. See layer based collision")]
		public int ragdollLayer;

		[Tooltip("Layer to set the player collider on. See layer based collision")]
		public int playerLayer;

		[Tooltip("List of Physics Elements, see UMAPhysicsElement class")]
		public List<UMAPhysicsElement> elements;

		public UnityEvent onRagdollStarted;

		public UnityEvent onRagdollEnded;

		private DynamicCharacterAvatar _avatar;

		private UMAData _umaData;

		private GameObject _rootBone;

		private List<Rigidbody> _rigidbodies;

		private bool[] SaveRagdollStates;

		private List<BoxCollider> _BoxColliders;

		private List<ClothSphereColliderPair> _SphereColliders;

		private List<CapsuleCollider> _CapsuleColliders;

		private CapsuleCollider _playerCollider;

		private Rigidbody _playerRigidbody;

		private List<CachedBone> cachedBones;

		public bool ragdolled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<BoxCollider> BoxColliders => null;

		public List<ClothSphereColliderPair> SphereColliders => null;

		public List<CapsuleCollider> CapsuleColliders => null;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void FixedUpdate()
		{
		}

		public void OnCharacterCreatedCallback(UMAData umaData)
		{
		}

		public void OnCharacterBegunCallback(UMAData umaData)
		{
		}

		public void OnCharacterUpdatedCallback(UMAData umaData)
		{
		}

		public void CreatePhysicsObjects()
		{
		}

		public void UpdateClothColliders()
		{
		}

		private void SetRagdolled(bool ragdollState)
		{
		}

		private void SetAllKinematic(bool flag)
		{
		}

		private void SetBodyColliders(bool flag)
		{
		}

		private void SetRendereroffscreenStates()
		{
		}

		private void SetUpdateWhenOffscreen(bool flag)
		{
		}
	}
}
