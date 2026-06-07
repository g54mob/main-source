using System.Collections.Generic;
using Jundroo.Common.Platform;

namespace Jundroo.Common.Settings
{
	public delegate IEnumerable<(DeviceFlags DeviceFlags, IEnumerable<SettingsCategoryPreset> Presets)> GetRegisteredSettingsCategoryPresets(SettingsCategory category);
}
