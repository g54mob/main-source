using UnityEngine;

namespace DV.Booklets.Testing
{
	public class StaticBookletTest : ABookletTest
	{
		public string prefabName;

		protected override GameObject CreateBooklet()
		{
			return BookletCreator.CreateStaticBooklet(prefabName, base.transform.position, base.transform.rotation, base.transform);
		}
	}
}
