using System;
using System.Collections.Generic;
using UnityEngine;

namespace Libs
{
	public class DisposableContainer : MonoBehaviour
	{
		private List<IDisposable> _disposables;

		public void Add(IDisposable disposable)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
