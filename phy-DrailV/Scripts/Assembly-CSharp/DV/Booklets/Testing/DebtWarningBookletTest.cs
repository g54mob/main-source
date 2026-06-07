using UnityEngine;

namespace DV.Booklets.Testing
{
	public class DebtWarningBookletTest : ABookletTest
	{
		protected override GameObject CreateBooklet()
		{
			return BookletCreator.CreateDebtWarningReport(base.transform.position, base.transform.rotation, base.transform);
		}
	}
}
