using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	[ExecuteInEditMode]
	public class UMAMountedItem : MonoBehaviour
	{
		[Tooltip("The name of the bone. Case must match.")]
		public string BoneName;

		[Tooltip("Unique ID for this object. Example: 'RightHandMount")]
		public string ID;

		public Vector3 Position;

		public Quaternion Orientation;

		public string IgnoreTag;

		[Tooltip("If true the object will scale to bone DNA")]
		public bool setScale;

		[Tooltip("Mount this item in startup. Useful when instantiating prefabs.")]
		public bool MountOnStart;

		private int BoneHash;

		private DynamicCharacterAvatar avatar;

		private Transform MountPoint;

		private UMAData lastUmaData;

		private void Start()
		{
		}

		private bool Initialize()
		{
			return false;
		}

		public bool MountItem()
		{
			return false;
		}

		public void ResetMountPoint()
		{
		}

		public Transform FindOrCreateMountpoint(UMAData umaData)
		{
			return null;
		}

		private void UpdateMountPoint(Transform newRoot)
		{
		}

		private Transform CreateMountpoint(Transform BoneTransform, int Layer)
		{
			return null;
		}

		public void CharacterUpdated(UMAData umaData)
		{
		}

		private void LateUpdate()
		{
		}

		private void SetMountTransform()
		{
		}
	}
}
