using UnityEngine;

namespace DV.Game.Tutorial.ItemTracker
{
	public class CustomDropOntoHint : MonoBehaviour
	{
		[Header("Non-VR")]
		[SerializeField]
		private ControlHint nonVRHint;

		[SerializeField]
		private Transform nonVRTarget;

		[SerializeField]
		[Header("VR")]
		private ControlHint VRHint;

		[SerializeField]
		private Transform VRTarget;

		public ControlHint Hint
		{
			get
			{
				if (!VRManager.IsVREnabled())
				{
					return nonVRHint;
				}
				return VRHint;
			}
		}

		public Transform Target
		{
			get
			{
				if (!VRManager.IsVREnabled())
				{
					return nonVRTarget;
				}
				return VRTarget;
			}
		}
	}
}
