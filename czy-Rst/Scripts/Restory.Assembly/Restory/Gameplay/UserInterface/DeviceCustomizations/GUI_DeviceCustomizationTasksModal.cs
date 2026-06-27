using System.Collections.Generic;
using Mandragora.PWS;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using TMPro;
using UnityEngine;

namespace Restory.Gameplay.UserInterface.DeviceCustomizations
{
	public class GUI_DeviceCustomizationTasksModal : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text deviceNameText;

		[SerializeField]
		private GUI_PaintingProgressSection paintingSection;

		private readonly List<DeviceWorkType> expectedWorkTypes = new List<DeviceWorkType>();

		private PaintingProgressInPercentage currentPaintingProgress;

		private PaintableDevice paintableDevice;

		public bool InAnimation => paintingSection.IsInAnimation;

		private void Awake()
		{
			DeactivatePaintingSections();
		}

		public void Init(string elementName, PaintableDevice paintableDevice, IReadOnlyCollection<DeviceWorkType> expectedWorkTypes)
		{
			this.paintableDevice = paintableDevice;
			deviceNameText.text = elementName;
			DeactivatePaintingSections();
			this.expectedWorkTypes.Clear();
			this.expectedWorkTypes.AddRange(expectedWorkTypes);
			foreach (DeviceWorkType expectedWorkType in expectedWorkTypes)
			{
				if (!(expectedWorkType is DeviceWorkTypePaintAnyColors))
				{
					if (expectedWorkType is DeviceWorkTypePaintConcretePalette deviceWorkTypePaintConcretePalette)
					{
						if (!paintingSection.gameObject.activeSelf)
						{
							paintingSection.gameObject.SetActive(value: true);
						}
						paintingSection.Initialize(1, paintableDevice, expectedWorkType, deviceWorkTypePaintConcretePalette.ConcretePalette, PaintingProgressInPercentage.ZeroProgress.PaintedArea);
					}
				}
				else
				{
					if (!paintingSection.gameObject.activeSelf)
					{
						paintingSection.gameObject.SetActive(value: true);
					}
					paintingSection.Initialize(1, paintableDevice, expectedWorkType, null, PaintingProgressInPercentage.ZeroProgress.PaintedArea);
				}
			}
		}

		public void UpdatePaintingProgress(PaintingProgressInPercentage paintingProgress)
		{
			currentPaintingProgress = paintingProgress;
			if (paintingSection.gameObject.activeSelf)
			{
				paintingSection.UpdateProgress(currentPaintingProgress.PaintedArea);
			}
		}

		private void DeactivatePaintingSections()
		{
			paintingSection.gameObject.SetActive(value: false);
		}
	}
}
