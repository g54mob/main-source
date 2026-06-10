using UnityEngine;
using UnityEngine.AddressableAssets;

namespace NSMedieval.Controllers
{
	internal class ReleaseOnDestroy : MonoBehaviour
	{
		private void OnDestroy()
		{
			Addressables.ReleaseInstance(base.gameObject);
		}
	}
}
