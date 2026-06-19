using System;
using FMOD;
using FMODUnity;

namespace Aggro.Core
{
	public sealed class FMODAudioInputSetting : AggroSettingBase
	{
		public Guid driverGuid { get; private set; }

		public override void SetToDefault()
		{
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
		}

		public void SetDriverGuid(Guid guid)
		{
			driverGuid = guid;
		}

		public bool TryGetRecordDriverInfo(out string driverName, out DRIVER_STATE driverState)
		{
			RuntimeManager.CoreSystem.getRecordNumDrivers(out var numdrivers, out var numconnected);
			for (int i = 0; i < numdrivers; i++)
			{
				if (RuntimeManager.CoreSystem.getRecordDriverInfo(i, out driverName, 256, out var guid, out numconnected, out var _, out var _, out driverState) == RESULT.OK && guid == driverGuid)
				{
					return true;
				}
			}
			driverName = null;
			driverState = (DRIVER_STATE)0u;
			return false;
		}
	}
}
