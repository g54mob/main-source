using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class CoroutineWrapper
	{
		private class AutoStopOnDisable : MonoBehaviour
		{
			public List<CoroutineWrapper> coroutinesToStop = new List<CoroutineWrapper>();

			public void OnDisable()
			{
				foreach (CoroutineWrapper item in coroutinesToStop)
				{
					item.Stop();
				}
			}
		}

		protected readonly string name;

		protected readonly MonoBehaviour mb;

		protected Coroutine coroutine;

		public CoroutineWrapper(MonoBehaviour mb, string name = "", bool addAutoStopComponent = false)
		{
			this.mb = mb;
			this.name = name;
			if (addAutoStopComponent)
			{
				AutoStopOnDisable autoStopOnDisable = mb.GetComponent<AutoStopOnDisable>();
				if (autoStopOnDisable == null)
				{
					autoStopOnDisable = mb.gameObject.AddComponent<AutoStopOnDisable>();
				}
				autoStopOnDisable.coroutinesToStop.Add(this);
			}
		}

		public virtual void Start(IEnumerator newCoroutine)
		{
			Stop();
			coroutine = mb.StartCoroutine(newCoroutine);
		}

		public virtual void Stop()
		{
			if (coroutine != null)
			{
				mb.StopCoroutine(coroutine);
				coroutine = null;
			}
		}
	}
}
