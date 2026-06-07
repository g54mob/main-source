using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Behaviour.Util
{
	public class CoroutineHandler : MonoBehaviour
	{
		private Queue<IEnumerator> _coroutines = new Queue<IEnumerator>();

		private void OnDisable()
		{
			while ((bool)base.gameObject && _coroutines.Count > 0)
			{
				IEnumerator enumerator = _coroutines.Dequeue();
				while (enumerator.MoveNext())
				{
				}
			}
		}

		public void AddCoroutine(IEnumerator coroutine)
		{
			_coroutines.Enqueue(coroutine);
		}
	}
}
