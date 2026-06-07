using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		[NonSerialized]
		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		protected T source => null;

		protected bool initialized => false;

		[CustomObfuscation]
		private void Awake()
		{
		}

		[CustomObfuscation]
		private void Start()
		{
		}

		[CustomObfuscation]
		private void OnEnable()
		{
		}

		[CustomObfuscation]
		private void OnDisable()
		{
		}

		[CustomObfuscation]
		private void OnDestroy()
		{
		}

		[CustomObfuscation]
		private void Reset()
		{
		}

		[CustomObfuscation]
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

		private void hDmgtPCkrzKndLBpCOyahighENGwA()
		{
		}

		private void hHCSKcwjKLwcLiGIneBPuFEiLUbU()
		{
		}
	}
}
