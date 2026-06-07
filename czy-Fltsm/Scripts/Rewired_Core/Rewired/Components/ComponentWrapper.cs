using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T OMNAqdbESpDrjXrpyfcvDpHFTdNLA;

		[NonSerialized]
		private bool IJTRkCZiIpwHquJngbJTKOXAMvYEA;

		protected T source => OMNAqdbESpDrjXrpyfcvDpHFTdNLA;

		protected bool initialized => IJTRkCZiIpwHquJngbJTKOXAMvYEA;

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
			ReInput.InitializedEvent += JnOVtassNFErkHrLMlwsHuZrcTdl;
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
			ReInput.InitializedEvent -= JnOVtassNFErkHrLMlwsHuZrcTdl;
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
				IJTRkCZiIpwHquJngbJTKOXAMvYEA = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (IJTRkCZiIpwHquJngbJTKOXAMvYEA)
			{
				return false;
			}
			OMNAqdbESpDrjXrpyfcvDpHFTdNLA = CreateSource(GetCreateSourceArgs());
			if (OMNAqdbESpDrjXrpyfcvDpHFTdNLA == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			IJTRkCZiIpwHquJngbJTKOXAMvYEA = true;
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
			IJTRkCZiIpwHquJngbJTKOXAMvYEA = false;
			Unsubscribe();
			OMNAqdbESpDrjXrpyfcvDpHFTdNLA = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += vnIPSLhboMNFADJgudgHCypMOLP;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= vnIPSLhboMNFADJgudgHCypMOLP;
		}

		private void vnIPSLhboMNFADJgudgHCypMOLP()
		{
			Deinitialize();
		}

		private void JnOVtassNFErkHrLMlwsHuZrcTdl()
		{
			Initialize();
		}
	}
}
