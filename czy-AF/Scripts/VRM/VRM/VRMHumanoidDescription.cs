using UniHumanoid;
using UnityEngine;

namespace VRM
{
	public class VRMHumanoidDescription : MonoBehaviour
	{
		[SerializeField]
		public Avatar Avatar;

		[SerializeField]
		public AvatarDescription Description;

		public AvatarDescription GetDescription(out bool isCreated)
		{
			isCreated = false;
			if (Description != null)
			{
				return Description;
			}
			return null;
		}

		private void OnValidate()
		{
			if (Avatar != null && (!Avatar.isValid || !Avatar.isHuman))
			{
				Avatar = null;
			}
		}

		private void Reset()
		{
			Animator component = GetComponent<Animator>();
			if (!(component == null))
			{
				Avatar = component.avatar;
				_ = Avatar == null;
			}
		}
	}
}
