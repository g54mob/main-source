using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T NsRIQHseimotuEJGoIuiBqmlsEN;

		[NonSerialized]
		private bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		protected T source => NsRIQHseimotuEJGoIuiBqmlsEN;

		protected bool initialized => XrAXpRFFCZWxSkTUXpVlgetwinP;

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
			ReInput.InitializedEvent += HeENNkIJQkBGwOzoLlSIGCnWWUJ;
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
			ReInput.InitializedEvent -= HeENNkIJQkBGwOzoLlSIGCnWWUJ;
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
				XrAXpRFFCZWxSkTUXpVlgetwinP = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return false;
			}
			NsRIQHseimotuEJGoIuiBqmlsEN = CreateSource(GetCreateSourceArgs());
			if (NsRIQHseimotuEJGoIuiBqmlsEN == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			XrAXpRFFCZWxSkTUXpVlgetwinP = true;
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
			XrAXpRFFCZWxSkTUXpVlgetwinP = false;
			Unsubscribe();
			NsRIQHseimotuEJGoIuiBqmlsEN = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += VYmcoBWBvOfLKtsTqLjfGsJRXHc;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= VYmcoBWBvOfLKtsTqLjfGsJRXHc;
		}

		private void VYmcoBWBvOfLKtsTqLjfGsJRXHc()
		{
			Deinitialize();
		}

		private void HeENNkIJQkBGwOzoLlSIGCnWWUJ()
		{
			Initialize();
		}
	}
}
