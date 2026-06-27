using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T VRcNmommLnWFKxJxDHXxAtSaHJgU;

		[NonSerialized]
		private bool LAuaSHGgJxFtBYxdXogLftCbNBrq;

		protected T source => VRcNmommLnWFKxJxDHXxAtSaHJgU;

		protected bool initialized => LAuaSHGgJxFtBYxdXogLftCbNBrq;

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
			ReInput.InitializedEvent += UOdnrxpGnDXHQbBjdZgGgQxCGONB;
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
			ReInput.InitializedEvent -= UOdnrxpGnDXHQbBjdZgGgQxCGONB;
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
				LAuaSHGgJxFtBYxdXogLftCbNBrq = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (LAuaSHGgJxFtBYxdXogLftCbNBrq)
			{
				return false;
			}
			VRcNmommLnWFKxJxDHXxAtSaHJgU = CreateSource(GetCreateSourceArgs());
			if (VRcNmommLnWFKxJxDHXxAtSaHJgU == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			LAuaSHGgJxFtBYxdXogLftCbNBrq = true;
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
			LAuaSHGgJxFtBYxdXogLftCbNBrq = false;
			Unsubscribe();
			VRcNmommLnWFKxJxDHXxAtSaHJgU = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += wzMzXHKZqyOfgaoXBQGsambQnqyW;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= wzMzXHKZqyOfgaoXBQGsambQnqyW;
		}

		private void wzMzXHKZqyOfgaoXBQGsambQnqyW()
		{
			Deinitialize();
		}

		private void UOdnrxpGnDXHQbBjdZgGgQxCGONB()
		{
			Initialize();
		}
	}
}
