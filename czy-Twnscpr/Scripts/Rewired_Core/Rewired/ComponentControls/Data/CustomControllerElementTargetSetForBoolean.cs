using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public class CustomControllerElementTargetSetForBoolean : CustomControllerElementTargetSet
	{
		private const int BIMDPTJrYmoPXkJsYgYmADJHImju = 1;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTarget _target;

		public CustomControllerElementTarget target => null;

		internal override int targetCount => 0;

		internal override CustomControllerElementTarget Item => null;

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
