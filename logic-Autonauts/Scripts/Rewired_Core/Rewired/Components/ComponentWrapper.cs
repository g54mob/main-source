using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T osAcqhQGqUOKZMlJKgeajFWwmnz;

		[NonSerialized]
		private bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		protected T source
		{
			get
			{
				return osAcqhQGqUOKZMlJKgeajFWwmnz;
			}
		}

		protected bool initialized
		{
			get
			{
				return uvRIxvvRCxrfpiSXpAlvYqJtnEz;
			}
		}

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
			ReInput.InitializedEvent += eiLxEeqImUlBcUbTnAGjsRdFuir;
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
			ReInput.InitializedEvent -= eiLxEeqImUlBcUbTnAGjsRdFuir;
		}

		protected virtual void OnReset()
		{
		}

		protected virtual void OnValidated()
		{
		}

		protected virtual void Initialize()
		{
			if (!TryInitialize())
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 1043121994;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x3E2CC749)
			{
			case 2:
				break;
			case 3:
				return;
			case 0:
				goto IL_0032;
			default:
				PostInitialize();
				return;
			}
			goto IL_0008;
			IL_0032:
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
			num = 1043121992;
			goto IL_000d;
		}

		protected virtual bool TryInitialize()
		{
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return false;
			}
			osAcqhQGqUOKZMlJKgeajFWwmnz = CreateSource(GetCreateSourceArgs());
			if (osAcqhQGqUOKZMlJKgeajFWwmnz == null)
			{
				Logger.LogError("Failed to create source object.");
				goto IL_0033;
			}
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
			int num = -801584316;
			goto IL_0038;
			IL_0033:
			num = -801584315;
			goto IL_0038;
			IL_0038:
			switch (num ^ -801584316)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0033;
		}

		protected abstract T CreateSource(object args);

		protected abstract object GetCreateSourceArgs();

		protected virtual void PostInitialize()
		{
			Subscribe();
		}

		protected virtual void Deinitialize()
		{
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = false;
			Unsubscribe();
			osAcqhQGqUOKZMlJKgeajFWwmnz = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += wNlxCrylfaCqnlFSCpzlwOdUttG;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= wNlxCrylfaCqnlFSCpzlwOdUttG;
		}

		private void wNlxCrylfaCqnlFSCpzlwOdUttG()
		{
			Deinitialize();
		}

		private void eiLxEeqImUlBcUbTnAGjsRdFuir()
		{
			Initialize();
		}
	}
}
