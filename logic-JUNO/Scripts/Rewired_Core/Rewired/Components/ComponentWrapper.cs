using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T EuDemDtkIKgUHngdnyTOwGQSFZEN;

		[NonSerialized]
		private bool AALiHqDFWIbYIAftlrRuTSITLPTu;

		protected T source => EuDemDtkIKgUHngdnyTOwGQSFZEN;

		protected bool initialized => AALiHqDFWIbYIAftlrRuTSITLPTu;

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
			ReInput.InitializedEvent += BqGlsSqTdoqUCfRMXiLJICHgWxge;
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
			ReInput.InitializedEvent -= BqGlsSqTdoqUCfRMXiLJICHgWxge;
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
				AALiHqDFWIbYIAftlrRuTSITLPTu = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (AALiHqDFWIbYIAftlrRuTSITLPTu)
			{
				return false;
			}
			EuDemDtkIKgUHngdnyTOwGQSFZEN = CreateSource(GetCreateSourceArgs());
			if (EuDemDtkIKgUHngdnyTOwGQSFZEN == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			AALiHqDFWIbYIAftlrRuTSITLPTu = true;
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
			AALiHqDFWIbYIAftlrRuTSITLPTu = false;
			Unsubscribe();
			EuDemDtkIKgUHngdnyTOwGQSFZEN = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += bhbENmdFzDkWhEeJJdvXSIhtuqQmB;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= bhbENmdFzDkWhEeJJdvXSIhtuqQmB;
		}

		private void bhbENmdFzDkWhEeJJdvXSIhtuqQmB()
		{
			Deinitialize();
		}

		private void BqGlsSqTdoqUCfRMXiLJICHgWxge()
		{
			Initialize();
		}
	}
}
