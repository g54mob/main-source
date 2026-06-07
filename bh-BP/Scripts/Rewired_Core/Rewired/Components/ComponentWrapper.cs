using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu(null)]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T OnFsCuNyFhzCJeKXdtUMoWXygxLJ;

		[NonSerialized]
		private bool UmBtsDthyrgXYEXDjzGkSHTtiuQqA;

		protected T source => null;

		protected bool initialized => false;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		private void Reset()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
		}

		protected virtual void OnAwake()
		{
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
		}

		protected virtual void OnReset()
		{
		}

		protected virtual void OnValidated()
		{
		}

		protected virtual void Initialize()
		{
		}

		protected virtual bool TryInitialize()
		{
			return false;
		}

		protected abstract T CreateSource(object args);

		protected abstract object GetCreateSourceArgs();

		protected virtual void PostInitialize()
		{
		}

		protected virtual void Deinitialize()
		{
		}

		protected virtual void Subscribe()
		{
		}

		protected virtual void Unsubscribe()
		{
		}

		private void nHtcPLdFXaZVfxnntHuJOZaOANJQ()
		{
		}

		private void NQIsndCEjXSpYmElHybTWdBWLzvo()
		{
		}
	}
}
