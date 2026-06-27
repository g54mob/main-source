using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/FirstRegularPayment", fileName = "Tutorial - 00 - FirstRegularPayment", order = 0)]
	public class FirstRegularPaymentTutorial : TutorialBase
	{
		[SerializeField]
		private FirstRegularPaymentTutorialSettings settings;

		public FirstRegularPaymentTutorialSettings Settings => settings;
	}
}
