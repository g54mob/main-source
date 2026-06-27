using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/ReplaceDevice", fileName = "Tutorial - 00 - ReplaceDevice", order = 0)]
	public class ReplaceDeviceTutorial : TutorialBase
	{
		[SerializeField]
		private ReplaceDeviceTutorialSettings settings;

		public ReplaceDeviceTutorialSettings Settings => settings;
	}
}
