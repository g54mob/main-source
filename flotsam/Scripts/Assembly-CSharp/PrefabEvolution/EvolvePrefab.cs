using PajamaLlama.Debugs;
using UnityEngine;

namespace PrefabEvolution
{
	public class EvolvePrefab : MonoBehaviour
	{
		private void Awake()
		{
			Debugger.Error($"Found EvolvePrefab component on object {base.gameObject.name}. Try reimporting the object in the editor if it is a model.", base.gameObject);
			Object.Destroy(this);
		}
	}
}
