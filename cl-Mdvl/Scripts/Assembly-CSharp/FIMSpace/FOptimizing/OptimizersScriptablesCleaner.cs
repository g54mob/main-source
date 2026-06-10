using UnityEngine;

namespace FIMSpace.FOptimizing
{
	[AddComponentMenu("FImpossible Creations/Optimizers 2/Optimizers Scriptables Cleaner")]
	public class OptimizersScriptablesCleaner : MonoBehaviour
	{
		public GameObject PrefabWithOptimizers;

		private void Reset()
		{
			PrefabWithOptimizers = base.gameObject;
		}
	}
}
