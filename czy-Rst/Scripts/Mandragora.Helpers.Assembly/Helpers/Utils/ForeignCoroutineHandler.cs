using System.Collections;
using System.Collections.Generic;
using Helpers.Singletons;
using UnityEngine;

namespace Helpers.Utils
{
	public class ForeignCoroutineHandler : SingletonBehaviour<ForeignCoroutineHandler>
	{
		private Dictionary<Object, Coroutine> ownerCoroutineDictionary = new Dictionary<Object, Coroutine>();

		public void StartCoroutine(Object owner, IEnumerator routineDelegate)
		{
			StopCoroutine(owner);
			ownerCoroutineDictionary[owner] = StartCoroutine(routineDelegate);
		}

		public void StopCoroutine(Object owner)
		{
			if (ownerCoroutineDictionary.ContainsKey(owner))
			{
				StopCoroutine(ownerCoroutineDictionary[owner]);
			}
		}
	}
}
