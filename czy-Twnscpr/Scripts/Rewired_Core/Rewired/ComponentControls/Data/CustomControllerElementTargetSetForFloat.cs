using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		[SerializeField]
		[CustomObfuscation]
		private bool _splitValue;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTarget _target;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTarget _positiveTarget;

		[SerializeField]
		[CustomObfuscation]
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

		internal override CustomControllerElementTarget Item => null;

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
