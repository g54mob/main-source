using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/BillOpen", fileName = "Tutorial - 00 - BillOpen", order = 0)]
	public class BillOpenTutorial : TutorialBase
	{
		[SerializeField]
		private BillOpenTutorialSettings settings;

		public BillOpenTutorialSettings Settings => settings;
	}
}
