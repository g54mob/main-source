using CTS.Core;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(500)]
	public class LevelSettingsFreemode : CTSBehaviour
	{
		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private LevelSettingsApplier _applier;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is FreemodeProfile freemodeProfile)
			{
				_applier.CustomSettings = freemodeProfile.Settings;
			}
		}
	}
}
