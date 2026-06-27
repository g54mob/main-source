using System.Collections;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class LogosIntroSceneCursorVisibilitySetter : MonoBehaviour
	{
		private VirtualCursorView virtualCursor;

		private Coroutine makeCursorInvisibleAfterInjectionCoroutine;

		[Inject]
		private void Construct(VirtualCursorView virtualCursor)
		{
			this.virtualCursor = virtualCursor;
		}

		private void OnEnable()
		{
			makeCursorInvisibleAfterInjectionCoroutine = StartCoroutine(MakeCursorInvisibleAfterInjectionCoroutine());
		}

		private void OnDisable()
		{
			if (makeCursorInvisibleAfterInjectionCoroutine != null)
			{
				StopCoroutine(makeCursorInvisibleAfterInjectionCoroutine);
				makeCursorInvisibleAfterInjectionCoroutine = null;
			}
		}

		private IEnumerator MakeCursorInvisibleAfterInjectionCoroutine()
		{
			yield return new WaitUntil(() => virtualCursor != null);
			virtualCursor.Visible = false;
		}
	}
}
