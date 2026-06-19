using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T OnFsCuNyFhzCJeKXdtUMoWXygxLJ;

		[NonSerialized]
		private bool UmBtsDthyrgXYEXDjzGkSHTtiuQqA;

		protected T source => OnFsCuNyFhzCJeKXdtUMoWXygxLJ;

		protected bool initialized => UmBtsDthyrgXYEXDjzGkSHTtiuQqA;

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
			ReInput.InitializedEvent += NQIsndCEjXSpYmElHybTWdBWLzvo;
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
			ReInput.InitializedEvent -= NQIsndCEjXSpYmElHybTWdBWLzvo;
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
				UmBtsDthyrgXYEXDjzGkSHTtiuQqA = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (UmBtsDthyrgXYEXDjzGkSHTtiuQqA)
			{
				return false;
			}
			OnFsCuNyFhzCJeKXdtUMoWXygxLJ = CreateSource(GetCreateSourceArgs());
			if (OnFsCuNyFhzCJeKXdtUMoWXygxLJ == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			UmBtsDthyrgXYEXDjzGkSHTtiuQqA = true;
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
			UmBtsDthyrgXYEXDjzGkSHTtiuQqA = false;
			Unsubscribe();
			OnFsCuNyFhzCJeKXdtUMoWXygxLJ = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += nHtcPLdFXaZVfxnntHuJOZaOANJQ;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= nHtcPLdFXaZVfxnntHuJOZaOANJQ;
		}

		private void nHtcPLdFXaZVfxnntHuJOZaOANJQ()
		{
			Deinitialize();
		}

		private void NQIsndCEjXSpYmElHybTWdBWLzvo()
		{
			Initialize();
		}
	}
}
