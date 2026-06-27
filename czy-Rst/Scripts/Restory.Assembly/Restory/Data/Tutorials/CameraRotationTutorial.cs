using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/CameraRotation", fileName = "Tutorial - 00 - CameraRotation", order = 0)]
	public class CameraRotationTutorial : TutorialBase
	{
		[SerializeField]
		private CameraRotationTutorialSettings settings;

		public CameraRotationTutorialSettings Settings => settings;
	}
}
