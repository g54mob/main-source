using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T fzzXbvFoZzdAqHDolrszRhFTkOz;

		[NonSerialized]
		private bool rXobafaxvUDrItlgWahiaYSKJqn;

		protected T source => fzzXbvFoZzdAqHDolrszRhFTkOz;

		protected bool initialized => rXobafaxvUDrItlgWahiaYSKJqn;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			OnAwake();
			OnAwakeFinished();
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			OnStart();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			OnEnabled();
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			OnDisabled();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			OnDestroyed();
		}

		[CustomObfuscation(rename = false)]
		private void Reset()
		{
			OnReset();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			OnValidated();
		}

		protected virtual void OnAwake()
		{
			ReInput.InitializedEvent += tksdcCCbhfzlqtDCWKAPHIWJyQxb;
			Initialize();
		}

		protected virtual void OnAwakeFinished()
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void OnEnabled()
		{
		}

		protected virtual void OnDisabled()
		{
		}

		protected virtual void OnDestroyed()
		{
			Unsubscribe();
			ReInput.InitializedEvent -= tksdcCCbhfzlqtDCWKAPHIWJyQxb;
		}

		protected virtual void OnReset()
		{
		}

		protected virtual void OnValidated()
		{
		}

		protected virtual void Initialize()
		{
			if (TryInitialize())
			{
				rXobafaxvUDrItlgWahiaYSKJqn = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return false;
			}
			fzzXbvFoZzdAqHDolrszRhFTkOz = CreateSource(GetCreateSourceArgs());
			if (fzzXbvFoZzdAqHDolrszRhFTkOz == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			rXobafaxvUDrItlgWahiaYSKJqn = true;
			return true;
		}

		protected abstract T CreateSource(object args);

		protected abstract object GetCreateSourceArgs();

		protected virtual void PostInitialize()
		{
			Subscribe();
		}

		protected virtual void Deinitialize()
		{
			rXobafaxvUDrItlgWahiaYSKJqn = false;
			Unsubscribe();
			fzzXbvFoZzdAqHDolrszRhFTkOz = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += vLQNgphjCVeTGsUhfdGmIMkvRUC;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= vLQNgphjCVeTGsUhfdGmIMkvRUC;
		}

		private void vLQNgphjCVeTGsUhfdGmIMkvRUC()
		{
			Deinitialize();
		}

		private void tksdcCCbhfzlqtDCWKAPHIWJyQxb()
		{
			Initialize();
		}
	}
}
