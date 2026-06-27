using Restory.Gameplay.Tutorials.Settings;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/ExitDisassemble", fileName = "Tutorial - 00 - ExitDisassemble", order = 0)]
	public class ExitDisassembleTutorial : TutorialBase
	{
		[SerializeField]
		private ExitDisassembleTutorialSettings settings;

		public ExitDisassembleTutorialSettings Settings => settings;
	}
}
