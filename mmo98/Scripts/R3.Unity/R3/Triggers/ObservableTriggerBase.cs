using UnityEngine;

namespace R3.Triggers
{
	public abstract class ObservableTriggerBase : MonoBehaviour
	{
		private bool calledDestroy;

		private void OnDestroy()
		{
			if (!calledDestroy)
			{
				calledDestroy = true;
				RaiseOnCompletedOnDestroy();
			}
		}

		protected abstract void RaiseOnCompletedOnDestroy();
	}
}
