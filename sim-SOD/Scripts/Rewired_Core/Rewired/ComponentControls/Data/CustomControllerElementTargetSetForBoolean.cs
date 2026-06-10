using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTargetSetForBoolean : CustomControllerElementTargetSet
	{
		private const int KWxdcTFwAAYZoHgOYjSmfqFlepr = 1;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target element.")]
		private CustomControllerElementTarget _target;

		public CustomControllerElementTarget target => null;

		internal override int targetCount => 0;

		internal override CustomControllerElementTarget this[int index] => null;

		internal CustomControllerElementTargetSetForBoolean()
		{
		}

		internal CustomControllerElementTargetSetForBoolean(CustomControllerElementTarget target)
		{
		}

		internal override void ClearElementCaches()
		{
		}
	}
}
