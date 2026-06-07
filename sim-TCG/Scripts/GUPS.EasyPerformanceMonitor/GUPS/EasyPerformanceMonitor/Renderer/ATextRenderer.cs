using System;
using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Observer;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public abstract class ATextRenderer<TProvidedData> : MonoBehaviour, ITextRenderer, IRenderer, IObserver<IProvidedData>, IDisposable where TProvidedData : IProvidedData
	{
		private List<IDisposable> unsubscriber;

		[SerializeField]
		private bool scale;

		public List<IProvider> Provider { get; private set; }

		public bool Scale => scale;

		protected virtual void Awake()
		{
			Provider = new List<IProvider>(GetComponents<IProvider>());
			unsubscriber = new List<IDisposable>();
			foreach (IProvider item in Provider)
			{
				if (typeof(TProvidedData).IsAssignableFrom(item.ProvidedDataType))
				{
					unsubscriber.Add(item.Subscribe(this));
				}
			}
		}

		public virtual void RefreshText()
		{
		}

		public abstract void OnNext(TProvidedData _Next);

		void IObserver<IProvidedData>.OnNext(IProvidedData _Next)
		{
			if (_Next is TProvidedData)
			{
				OnNext((TProvidedData)_Next);
			}
		}

		public virtual void OnError(Exception _Error)
		{
		}

		public virtual void OnCompleted()
		{
		}

		public virtual void Dispose()
		{
			foreach (IDisposable item in unsubscriber)
			{
				item.Dispose();
			}
		}

		protected virtual void OnDestroy()
		{
			foreach (IDisposable item in unsubscriber)
			{
				item.Dispose();
			}
		}
	}
}
