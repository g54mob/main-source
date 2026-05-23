using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T jZfaHLnsJrbcqmDmSDAABjonxlCTA;

		[NonSerialized]
		private bool vlrONwLvBbBApHpwIJbaCEooIxNz;

		protected T source => jZfaHLnsJrbcqmDmSDAABjonxlCTA;

		protected bool initialized => vlrONwLvBbBApHpwIJbaCEooIxNz;

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
			ReInput.InitializedEvent += uDiXSUqjKRBwtqEAeeSHNRcFGwifA;
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
			ReInput.InitializedEvent -= uDiXSUqjKRBwtqEAeeSHNRcFGwifA;
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
				vlrONwLvBbBApHpwIJbaCEooIxNz = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (vlrONwLvBbBApHpwIJbaCEooIxNz)
			{
				return false;
			}
			jZfaHLnsJrbcqmDmSDAABjonxlCTA = CreateSource(GetCreateSourceArgs());
			if (jZfaHLnsJrbcqmDmSDAABjonxlCTA == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			vlrONwLvBbBApHpwIJbaCEooIxNz = true;
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
			vlrONwLvBbBApHpwIJbaCEooIxNz = false;
			Unsubscribe();
			jZfaHLnsJrbcqmDmSDAABjonxlCTA = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += ILPwBcPaVaIFWhWCKBONHNTDOPKe;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= ILPwBcPaVaIFWhWCKBONHNTDOPKe;
		}

		private void ILPwBcPaVaIFWhWCKBONHNTDOPKe()
		{
			Deinitialize();
		}

		private void uDiXSUqjKRBwtqEAeeSHNRcFGwifA()
		{
			Initialize();
		}
	}
}
