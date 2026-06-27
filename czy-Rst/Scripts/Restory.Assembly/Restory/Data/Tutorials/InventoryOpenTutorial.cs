using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/InventoryOpen", fileName = "Tutorial - 00 - InventoryOpen", order = 0)]
	public class InventoryOpenTutorial : TutorialBase
	{
		[SerializeField]
		private InventoryOpenTutorialSettings settings;

		public InventoryOpenTutorialSettings Settings => settings;
	}
}
