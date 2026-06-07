using UnityEngine;

namespace DV.Booklets.Testing
{
	public class DebtBookletTest : ABookletTest
	{
		public Debt_data data;

		protected override GameObject CreateBooklet()
		{
			return BookletCreator_Debt.Create(data, base.transform.position, base.transform.rotation, base.transform).gameObject;
		}
	}
}
