using System;
using NSEipix.Base;

namespace NSMedieval.StructurePresets
{
	public class StructurePresetModeController : MonoSingleton<StructurePresetModeController>
	{
		public event Action<bool> StructurePresetModeVisibleEvent;

		public void ToggleStructurePresetMode(bool visible)
		{
			this.StructurePresetModeVisibleEvent?.Invoke(visible);
		}
	}
}
