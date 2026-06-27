using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/DeviceDisassembleModeRotation", fileName = "Tutorial - 00 - DeviceDisassembleModeRotation", order = 0)]
	public class DeviceDisassembleModeRotationTutorial : TutorialBase
	{
		[SerializeField]
		private DeviceDisassembleModeRotationTutorialSettings settings;

		public DeviceDisassembleModeRotationTutorialSettings Settings => settings;
	}
}
