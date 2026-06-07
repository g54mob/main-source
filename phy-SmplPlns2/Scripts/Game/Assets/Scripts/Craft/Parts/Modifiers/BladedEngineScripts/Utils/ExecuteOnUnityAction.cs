using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Utils
{
	public class ExecuteOnUnityAction : MonoBehaviour
	{
		public event ExecuteOnUnityActionHandler Destroyed;

		protected virtual void OnDestroy()
		{
			this.Destroyed?.Invoke(this);
		}
	}
}
