using UnityEngine;

namespace RootMotion.FinalIK
{
	[ExecuteInEditMode]
	public class EditorIK : MonoBehaviour
	{
		[Tooltip("If slot assigned, will update Animator before IK.")]
		public Animator animator;

		[Tooltip("Create/Final IK/Editor IK Pose")]
		public EditorIKPose defaultPose;

		[HideInInspector]
		public Transform[] bones;

		public IK ik { get; private set; }

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		public void StoreDefaultPose()
		{
		}

		public bool Initiate()
		{
			return false;
		}

		public void Update()
		{
		}
	}
}
