using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T UQIufBaMDsLDIxaqLwBVWxwFpvgt;

		[NonSerialized]
		private bool IuUbGmCXSknPPOwRPiBblcBIbXbC;

		protected T source => UQIufBaMDsLDIxaqLwBVWxwFpvgt;

		protected bool initialized => IuUbGmCXSknPPOwRPiBblcBIbXbC;

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
			ReInput.InitializedEvent += BMPmKCvXAUXPTzDIfFvKudgfiYIJ;
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
			ReInput.InitializedEvent -= BMPmKCvXAUXPTzDIfFvKudgfiYIJ;
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
				IuUbGmCXSknPPOwRPiBblcBIbXbC = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (IuUbGmCXSknPPOwRPiBblcBIbXbC)
			{
				return false;
			}
			UQIufBaMDsLDIxaqLwBVWxwFpvgt = CreateSource(GetCreateSourceArgs());
			if (UQIufBaMDsLDIxaqLwBVWxwFpvgt == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			IuUbGmCXSknPPOwRPiBblcBIbXbC = true;
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
			IuUbGmCXSknPPOwRPiBblcBIbXbC = false;
			Unsubscribe();
			UQIufBaMDsLDIxaqLwBVWxwFpvgt = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += xaunCuABgxPhyiEMXQKKspZleWqiA;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= xaunCuABgxPhyiEMXQKKspZleWqiA;
		}

		private void xaunCuABgxPhyiEMXQKKspZleWqiA()
		{
			Deinitialize();
		}

		private void BMPmKCvXAUXPTzDIfFvKudgfiYIJ()
		{
			Initialize();
		}
	}
}
