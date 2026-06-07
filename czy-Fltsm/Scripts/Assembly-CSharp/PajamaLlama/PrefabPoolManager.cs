using UnityEngine;

namespace PajamaLlama
{
	public class PrefabPoolManager : MonoBehaviour
	{
		private void Awake()
		{
			PrefabPool.InitializeStaticPools(base.transform);
		}

		private void OnDestroy()
		{
			PrefabPool.ClearStaticPools();
		}
	}
}
