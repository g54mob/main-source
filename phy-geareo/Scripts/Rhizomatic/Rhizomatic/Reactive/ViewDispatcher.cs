using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.Reactive
{
	public class ViewDispatcher : MonoBehaviour
	{
		private static ViewDispatcher _instance;

		private List<View> views;

		private List<View> rendering;

		public static ViewDispatcher instance => null;

		private void LateUpdate()
		{
		}

		public void Enqueue(View view)
		{
		}
	}
}
