using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		[Tooltip("Splits the value into positive and negative sides which can be assigned to different Custom Controller elements.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _splitValue;

		[CustomObfuscation(rename = false)]
		[Tooltip("The target element. This is unused if Split Value is enabled.")]
		[SerializeField]
		private CustomControllerElementTarget _target;

		[SerializeField]
		[Tooltip("The positive target element. This is unused if Split Value is not enabled.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _positiveTarget;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The negative target element. This is unused if Split Value is not enabled.")]
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

		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget target)
		{
		}

		internal CustomControllerElementTargetSetForFloat(CustomControllerElementTarget positiveTarget, CustomControllerElementTarget negativeTarget)
		{
		}

		internal override void ClearElementCaches()
		{
		}
	}
}
