using System;
using System.Collections.Generic;
using System.Reflection;
using GUPS.EasyPerformanceMonitor.Observer;
using GUPS.EasyPerformanceMonitor.Platform;
using GUPS.EasyPerformanceMonitor.Provider;
using UnityEngine;
using UnityEngine.UI;

namespace GUPS.EasyPerformanceMonitor.Renderer
{
	[Obfuscation(Exclude = true)]
	public class BarRenderer : MonoBehaviour, IBarRenderer, IRenderer, IObserver<IProvidedData>, IDisposable
	{
		private List<IDisposable> unsubscriber;

		[SerializeField]
		private float[] lowerBoundValues;

		private float lowerBoundValueActivePlatform;

		[SerializeField]
		private float[] upperBoundValues;

		private float upperBoundValueActivePlatform;

		[SerializeField]
		private Slider uiValueSlider;

		[SerializeField]
		public Text uiValuePercentageText;

		public List<IProvider> Provider { get; private set; }

		protected virtual void Awake()
		{
			Provider = new List<IProvider>(GetComponents<IProvider>());
			unsubscriber = new List<IDisposable>();
			foreach (IProvider item in Provider)
			{
				if (typeof(PerformanceData).IsAssignableFrom(item.ProvidedDataType))
				{
					unsubscriber.Add(item.Subscribe(this));
				}
			}
		}

		protected virtual void Start()
		{
			switch (PlatformHelper.GetCurrentPlatform())
			{
			case EPlatform.Desktop:
				lowerBoundValueActivePlatform = lowerBoundValues[0];
				upperBoundValueActivePlatform = upperBoundValues[0];
				break;
			case EPlatform.Mobile:
				lowerBoundValueActivePlatform = lowerBoundValues[1];
				upperBoundValueActivePlatform = upperBoundValues[1];
				break;
			case EPlatform.Console:
				lowerBoundValueActivePlatform = lowerBoundValues[2];
				upperBoundValueActivePlatform = upperBoundValues[2];
				break;
			default:
				lowerBoundValueActivePlatform = lowerBoundValues[0];
				upperBoundValueActivePlatform = upperBoundValues[0];
				break;
			}
		}

		public void OnNext(PerformanceData _Next)
		{
			float b = (_Next.Value - lowerBoundValueActivePlatform) / (upperBoundValueActivePlatform - lowerBoundValueActivePlatform);
			b = Mathf.Max(0f, Mathf.Min(1f, b));
			float num = b * 100f;
			if (uiValueSlider != null)
			{
				uiValueSlider.value = Mathf.Max(0.1f, b);
			}
			if (uiValuePercentageText != null)
			{
				uiValuePercentageText.text = $"{num:0.0}%";
			}
		}

		void IObserver<IProvidedData>.OnNext(IProvidedData _Next)
		{
			if (_Next is PerformanceData)
			{
				OnNext((PerformanceData)(object)_Next);
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

		public void RefreshBar()
		{
			switch (PlatformHelper.GetCurrentPlatform())
			{
			case EPlatform.Desktop:
				lowerBoundValueActivePlatform = lowerBoundValues[0];
				upperBoundValueActivePlatform = upperBoundValues[0];
				break;
			case EPlatform.Mobile:
				lowerBoundValueActivePlatform = lowerBoundValues[1];
				upperBoundValueActivePlatform = upperBoundValues[1];
				break;
			case EPlatform.Console:
				lowerBoundValueActivePlatform = lowerBoundValues[2];
				upperBoundValueActivePlatform = upperBoundValues[2];
				break;
			default:
				lowerBoundValueActivePlatform = lowerBoundValues[0];
				upperBoundValueActivePlatform = upperBoundValues[0];
				break;
			}
		}
	}
}
