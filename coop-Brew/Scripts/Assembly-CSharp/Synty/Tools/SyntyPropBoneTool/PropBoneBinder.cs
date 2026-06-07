using System.Collections.Generic;
using UnityEngine;

namespace Synty.Tools.SyntyPropBoneTool
{
	[ExecuteInEditMode]
	public class PropBoneBinder : MonoBehaviour
	{
		[Tooltip("Reference to the animator for this character")]
		public Animator animator;

		[Tooltip("Configures how the bones are set up on the rig.")]
		public PropBoneConfig propBoneConfig;

		[Tooltip("Determins when this script will update the transforms. For best results run this script later than the animator.")]
		public UpdateType updateType;

		public bool updateInEditMode;

		[Tooltip("Rebinds all the bones on awake. Useful if your rigs change often, saves needing to rebind them at edit time.")]
		public bool rebindOnAwake;

		[Space]
		[Tooltip("Bindings and offset values applied at runtime.")]
		[SerializeField]
		private List<PropBoneBinding> _propBoneBindings;

		public bool IsConfigured => false;

		public bool AreReferencesConfigured()
		{
			return false;
		}

		public bool IsPropBoneHierarchyConfigured()
		{
			return false;
		}

		public bool AreBindingsConfigured()
		{
			return false;
		}

		private void Awake()
		{
		}

		private PropBoneBinding CreateBoneBinding(PropBoneDefinition boneDefinition)
		{
			return null;
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		public void UpdateBones()
		{
		}

		public void UpdateBone(PropBoneBinding boneInstance)
		{
		}

		public void SetupAnimatorReference()
		{
		}

		public void Reset()
		{
		}

		public void BindPropBones()
		{
		}

		public void ClearPropBoneBindings()
		{
		}

		public void CreatePropBones()
		{
		}

		private void CreatePropBones(GameObject editScope, PropBoneDefinition boneDefinition)
		{
		}

		private Transform CreatePropBone(string name, Transform parent)
		{
			return null;
		}

		public void DestroyPropBones()
		{
		}

		private void DestroyPropBones(GameObject editScope)
		{
		}
	}
}
