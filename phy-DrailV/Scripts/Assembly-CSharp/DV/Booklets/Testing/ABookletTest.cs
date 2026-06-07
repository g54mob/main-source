using DV.Utils;
using UnityEngine;

namespace DV.Booklets.Testing
{
	[DisallowMultipleComponent]
	[ExecuteAfter(typeof(LocoResourceModule))]
	public abstract class ABookletTest : MonoBehaviour
	{
		private void Start()
		{
			CreateBooklet().AddComponent<PageFlippingKeyboardControls>();
		}

		protected abstract GameObject CreateBooklet();
	}
}
