using System.Collections.Generic;
using Restory.Gameplay.Elements;
using Restory.Gameplay.TextureMasks;

namespace Restory.Data.Devices.Condition
{
	public interface IDeviceCondition : IInteractiveObjectInfo
	{
		DeviceInfo DeviceInfo { get; }

		MaskPresetInfoBase DirtMaskGenerationPreset { get; }

		bool IsPartOfCompetition { get; }

		List<ElementData> GetElementsCondition();

		bool DoesDeviceContainQuestItem();
	}
}
