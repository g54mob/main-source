using AK.Wwise;
using UnityEngine;

namespace Gh.Tk
{
	public class ObjectStateSoundPlayer : SimpleSoundPlayer
	{
		public AK.Wwise.Event DisabledEventData;

		public GameObject TargetObject;

		private bool _isDisabled;

		public override AK.Wwise.Event GetCurrentEvent()
		{
			return null;
		}

		protected override void LateUpdate()
		{
		}

		private void StopSounds()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
