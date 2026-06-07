using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public class CustomControllerElementTargetSetForFloat : CustomControllerElementTargetSet
	{
		[CustomObfuscation]
		[SerializeField]
		private bool _splitValue;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTarget _target;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTarget _positiveTarget;

		[CustomObfuscation]
		[SerializeField]
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
