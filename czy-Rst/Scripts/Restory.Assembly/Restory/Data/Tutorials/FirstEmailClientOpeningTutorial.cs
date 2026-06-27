using Restory.Data.PC;
using UnityEngine;

namespace Restory.Data.Tutorials
{
	[CreateAssetMenu(menuName = "Restory/Tutorials/FirstEmailClientOpeningTutorial", fileName = "Tutorial - 00 - FirstEmailClientOpening", order = 0)]
	public class FirstEmailClientOpeningTutorial : TutorialBase
	{
		[SerializeField]
		private PcAppInfo mailClientAppInfo;

		public PcAppInfo MailClientAppInfo => mailClientAppInfo;
	}
}
