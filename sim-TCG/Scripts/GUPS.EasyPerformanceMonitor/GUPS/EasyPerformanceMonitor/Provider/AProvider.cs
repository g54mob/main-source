using System;
using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Observer;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Serializable]
	[Obfuscation(Exclude = true)]
	public abstract class AProvider<TProvidedData> : MonoBehaviour, IProvider, IObservable<IProvidedData>, IDisposable where TProvidedData : IProvidedData
	{
		private class Unsubscriber : IDisposable
		{
			private List<IObserver<IProvidedData>> observers;

			private IObserver<IProvidedData> observer;

			public Unsubscriber(List<IObserver<IProvidedData>> _Observers, IObserver<IProvidedData> _Observer)
			{
				observers = _Observers;
				observer = _Observer;
			}

			public void Dispose()
			{
				if (observer != null && observers.Contains(observer))
				{
					observers.Remove(observer);
				}
			}
		}

		protected List<IObserver<IProvidedData>> ObserverList { get; } = new List<IObserver<IProvidedData>>();

		public abstract string Name { get; }

		public abstract bool IsSupported { get; }

		public bool IsActive { get; private set; } = true;

		public Type ProvidedDataType => typeof(TProvidedData);

		protected virtual void Awake()
		{
			if (!IsSupported)
			{
				IsActive = false;
			}
		}

		public IDisposable Subscribe(IObserver<IProvidedData> _Observer)
		{
			if (!ObserverList.Contains(_Observer))
			{
				ObserverList.Add(_Observer);
			}
			return new Unsubscriber(ObserverList, _Observer);
		}

		public void Dispose()
		{
			foreach (IObserver<IProvidedData> observer in ObserverList)
			{
				observer.OnCompleted();
			}
		}
	}
}
