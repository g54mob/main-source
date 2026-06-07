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
	public abstract class AGraphRenderer : MonoBehaviour, IGraphRenderer, IRenderer, IObserver<IProvidedData>, IDisposable
	{
		private List<IDisposable> unsubscriber;

		[SerializeField]
		private Image target;

		[SerializeField]
		private Shader graphShader;

		[SerializeField]
		private Shader graphShaderMobile;

		[SerializeField]
		private bool isLine;

		[SerializeField]
		private bool isSmooth;

		[SerializeField]
		private bool hasAntiAliasing;

		public const int CMaxGraphValues = 1024;

		public const int CMaxGraphValuesMobile = 512;

		[SerializeField]
		private int graphValues = 128;

		public static readonly int LinePropertyId = Shader.PropertyToID("_Line");

		public static readonly int SmoothPropertyId = Shader.PropertyToID("_Smooth");

		public static readonly int AntiAliasingPropertyId = Shader.PropertyToID("_AntiAliasing");

		public static readonly int ValuesPropertyId = Shader.PropertyToID("_Values");

		public static readonly int ValueCountPropertyId = Shader.PropertyToID("_ValueCount");

		public List<IProvider> Provider { get; private set; }

		public Image Target => target;

		public Shader GraphShader
		{
			get
			{
				if (PlatformHelper.GetCurrentPlatform() != EPlatform.Mobile)
				{
					return graphShader;
				}
				return graphShaderMobile;
			}
		}

		public bool IsLine => isLine;

		public bool IsSmooth => isSmooth;

		public bool HasAntiAliasing => hasAntiAliasing;

		public int GraphValues => graphValues;

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
			InitializeGraph(GraphShader);
		}

		public void InitializeGraph(Shader _Shader)
		{
			Target.material = new Material(_Shader);
			Target.material.SetFloat(LinePropertyId, IsLine ? 1f : 0f);
			Target.material.SetFloat(SmoothPropertyId, IsSmooth ? 1f : 0f);
			Target.material.SetFloat(AntiAliasingPropertyId, HasAntiAliasing ? 1f : 0f);
			Target.material.SetFloatArray(ValuesPropertyId, new float[512]);
			Target.material.SetFloat(ValueCountPropertyId, GraphValues);
			OnInitializeGraph(_Shader);
		}

		protected virtual void OnInitializeGraph(Shader _Shader)
		{
		}

		public virtual void RefreshGraph()
		{
			Target.material.SetFloat(LinePropertyId, IsLine ? 1f : 0f);
			Target.material.SetFloat(SmoothPropertyId, IsSmooth ? 1f : 0f);
			Target.material.SetFloat(AntiAliasingPropertyId, HasAntiAliasing ? 1f : 0f);
			Target.material.SetFloatArray(ValuesPropertyId, new float[512]);
			Target.material.SetFloat(ValueCountPropertyId, GraphValues);
		}

		public abstract void OnNext(PerformanceData _Next);

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
	}
}
