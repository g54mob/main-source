using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[DefaultExecutionOrder(-1001)]
	[AddComponentMenu("Malbers/Runtime Vars/Hook GameObject")]
	public class GameObjectHook : MonoBehaviour
	{
		[RequiredField]
		[Tooltip("Scriptable Asset to Store this GameObject as a reference to avoid Scene Dependencies")]
		public GameObjectVar Hook;

		private void OnEnable()
		{
			UpdateHook();
		}

		private void OnDisable()
		{
			if ((bool)Hook && Hook.Value == base.gameObject)
			{
				DisableHook();
			}
		}

		public virtual void UpdateHook()
		{
			Hook.Value = base.gameObject;
		}

		public virtual void DisableHook()
		{
			Hook.Value = null;
		}
	}
}
