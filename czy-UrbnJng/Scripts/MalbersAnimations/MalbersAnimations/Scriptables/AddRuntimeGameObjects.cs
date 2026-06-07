using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Runtime Vars/Add Runtime GameObjects")]
	public class AddRuntimeGameObjects : MonoBehaviour
	{
		[CreateScriptableAsset]
		public RuntimeGameObjects Collection;

		private void OnEnable()
		{
			Collection?.Item_Add(base.gameObject);
		}

		private void OnDisable()
		{
			Collection?.Item_Remove(base.gameObject);
		}
	}
}
