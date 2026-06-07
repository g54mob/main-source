using UnityEngine;

namespace DV.Booklets.Testing
{
	public class TutorialWarningBookletTest : ABookletTest
	{
		protected override GameObject CreateBooklet()
		{
			return BookletCreator.CreateTutorialWarningReport(base.transform.position, base.transform.rotation, base.transform);
		}
	}
}
