using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		[SerializeField]
		[Tooltip("Splits the value into positive and negative sides which can be assigned to different Custom Controller elements.")]
		[CustomObfuscation(rename = false)]
		private bool _splitValue;

		[Tooltip("The target element. This is unused if Split Value is enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _target;

		[Tooltip("The positive target element. This is unused if Split Value is not enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _positiveTarget;

		[Tooltip("The negative target element. This is unused if Split Value is not enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _negativeTarget;

		public bool splitValue
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CustomControllerElementTarget target => null;

		public CustomControllerElementTarget positiveTarget => null;

		public CustomControllerElementTarget negativeTarget => null;

		internal override int targetCount => 0;

		internal override CustomControllerElementTarget this[int index] => null;

		internal CustomControllerElementTargetSetForFloat()
		{
		}

		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget P_0)
		{
		}

		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget P_0, CustomControllerElementTarget P_1)
		{
		}

		internal override void ClearElementCaches()
		{
		}
	}
}
