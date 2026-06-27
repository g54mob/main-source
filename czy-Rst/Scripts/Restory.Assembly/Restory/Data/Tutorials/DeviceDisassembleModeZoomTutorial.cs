using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/DeviceDisassembleModeZoom", fileName = "Tutorial - 00 - DeviceDisassembleModeZoom", order = 0)]
	public class DeviceDisassembleModeZoomTutorial : TutorialBase
	{
		[SerializeField]
		private DeviceDisassembleModeZoomTutorialSettings settings;

		public DeviceDisassembleModeZoomTutorialSettings Settings => settings;
	}
}
