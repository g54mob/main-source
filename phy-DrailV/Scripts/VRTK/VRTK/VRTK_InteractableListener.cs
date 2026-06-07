using System.Collections;
using UnityEngine;

namespace VRTK
{
	public abstract class VRTK_InteractableListener : MonoBehaviour
	{
		protected Coroutine setupInteractableListenersRoutine;

		protected abstract bool SetupListeners(bool throwError);

		protected abstract void TearDownListeners();

		protected virtual void EnableListeners()
		{
			if (!SetupListeners(throwError: false))
			{
				setupInteractableListenersRoutine = StartCoroutine(SetupListenersAtEndOfFrame());
			}
		}

		protected virtual void DisableListeners()
		{
			if (setupInteractableListenersRoutine != null)
			{
				StopCoroutine(setupInteractableListenersRoutine);
				setupInteractableListenersRoutine = null;
			}
			TearDownListeners();
		}

		protected virtual IEnumerator SetupListenersAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			SetupListeners(throwError: true);
		}
	}
}
