using System;
using System.Collections;
using UnityEngine;

namespace Photon.Realtime
{
	internal class MonoBehaviourEmpty : MonoBehaviour
	{
		internal Action<RegionHandler> onCompleteCall;

		private RegionHandler obj;

		public static MonoBehaviourEmpty BuildInstance(string id = null)
		{
			return null;
		}

		public void SelfDestroy()
		{
		}

		private void Update()
		{
		}

		public void CompleteOnMainThread(RegionHandler obj)
		{
		}

		public void StartCoroutineAndDestroy(IEnumerator coroutine)
		{
		}
	}
}
