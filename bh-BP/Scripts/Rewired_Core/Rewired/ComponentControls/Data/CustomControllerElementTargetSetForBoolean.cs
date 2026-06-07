using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForBoolean : CustomControllerElementTargetSet
	{
		private const int zkgbfkVsKcOEaMvGAHkPLgJOFcyQ = 1;

		[Tooltip("The target element.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTarget _target;

		public CustomControllerElementTarget target => null;

		internal override int targetCount => 0;

		internal override CustomControllerElementTarget this[int index] => null;

		internal CustomControllerElementTargetSetForBoolean()
		{
		}

		internal CustomControllerElementTargetSetForBoolean(CustomControllerElementTarget P_0)
		{
		}

		internal override void ClearElementCaches()
		{
		}
	}
}
