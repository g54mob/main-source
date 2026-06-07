using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T CLFHWOuPSRLahPSSrSHZoiqMbYrk;

		[NonSerialized]
		private bool UKOJIKREswByZtkIQEUQJcfFaZxF;

		protected T source => CLFHWOuPSRLahPSSrSHZoiqMbYrk;

		protected bool initialized => UKOJIKREswByZtkIQEUQJcfFaZxF;

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
			ReInput.InitializedEvent += SeMTFnIHwVXLrRisSUdthilpxQrP;
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
			ReInput.InitializedEvent -= SeMTFnIHwVXLrRisSUdthilpxQrP;
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
				UKOJIKREswByZtkIQEUQJcfFaZxF = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				return false;
			}
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = CreateSource(GetCreateSourceArgs());
			if (CLFHWOuPSRLahPSSrSHZoiqMbYrk == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			UKOJIKREswByZtkIQEUQJcfFaZxF = true;
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
			UKOJIKREswByZtkIQEUQJcfFaZxF = false;
			Unsubscribe();
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += KuwbyEONRjkODmpFxXUGtXNcKXAQ;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= KuwbyEONRjkODmpFxXUGtXNcKXAQ;
		}

		private void KuwbyEONRjkODmpFxXUGtXNcKXAQ()
		{
			Deinitialize();
		}

		private void SeMTFnIHwVXLrRisSUdthilpxQrP()
		{
			Initialize();
		}
	}
}
