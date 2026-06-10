using System;
using Rewired.ComponentControls.Data;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class CustomControllerControl : ComponentControl
	{
		internal CustomController controller => null;

		internal override bool hasController => false;

		[CustomObfuscation(rename = false)]
		internal CustomControllerControl()
		{
		}

		internal override void zZvUXvigSJSyudmZqKMfzEpXBSj()
		{
		}

		internal override void ARKxKpVNqBlBYALxhmjYIBkRyuM()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return null;
		}

		internal void NXmjYamjlcaKMZIWTjTmbbcXCcB(CustomControllerElementTargetSet P_0, float P_1, float P_2)
		{
		}

		internal void NXmjYamjlcaKMZIWTjTmbbcXCcB(CustomControllerElementTargetSet P_0, bool P_1)
		{
		}

		internal abstract void iagGGZhzoHvsifYztDyhsUjnGQZ();

		private void NXmjYamjlcaKMZIWTjTmbbcXCcB(CustomControllerElementTarget P_0, float P_1, float P_2)
		{
		}

		private void NXmjYamjlcaKMZIWTjTmbbcXCcB(CustomControllerElementTarget P_0, bool P_1)
		{
		}

		private void fhHsOFeQDGqUEtnrsXTOrvEpHIl()
		{
		}
	}
}
