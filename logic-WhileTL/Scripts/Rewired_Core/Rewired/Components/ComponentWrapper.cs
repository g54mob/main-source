using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		[NonSerialized]
		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		protected T source => vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		protected bool initialized => juAmOHdlEuZcdEbopfsigKMAJgtHb;

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
			ReInput.InitializedEvent += hHCSKcwjKLwcLiGIneBPuFEiLUbU;
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
			ReInput.InitializedEvent -= hHCSKcwjKLwcLiGIneBPuFEiLUbU;
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
				juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return false;
			}
			vPTVBGMeTSLLhqcGnbvGjLFkMncb = CreateSource(GetCreateSourceArgs());
			if (vPTVBGMeTSLLhqcGnbvGjLFkMncb == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
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
			juAmOHdlEuZcdEbopfsigKMAJgtHb = false;
			Unsubscribe();
			vPTVBGMeTSLLhqcGnbvGjLFkMncb = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += hDmgtPCkrzKndLBpCOyahighENGwA;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= hDmgtPCkrzKndLBpCOyahighENGwA;
		}

		private void hDmgtPCkrzKndLBpCOyahighENGwA()
		{
			Deinitialize();
		}

		private void hHCSKcwjKLwcLiGIneBPuFEiLUbU()
		{
			Initialize();
		}
	}
}
