using System;
using RSG;
using UnityEngine;
using Zenject;

namespace Restory.Utils
{
	public class PromisesErrorHandler : IInitializable, IDisposable
	{
		public void Initialize()
		{
			Promise.UnhandledException += OnUnhandledPromiseException;
		}

		public void Dispose()
		{
			Promise.UnhandledException -= OnUnhandledPromiseException;
		}

		private void OnUnhandledPromiseException(object sender, ExceptionEventArgs e)
		{
			Debug.LogException(new Exception("Unhandled RSG Promise Exception: " + e.Exception.Message + "\nStack Trace: " + e.Exception.StackTrace));
		}
	}
}
