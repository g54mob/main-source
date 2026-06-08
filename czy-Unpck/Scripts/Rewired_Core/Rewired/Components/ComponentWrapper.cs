using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T FzAfZmFeJSmPEcrqFTJfQfeHdrSY;

		[NonSerialized]
		private bool PwPWygBTznyByBIyaAyqEfnsXBM;

		protected T source => FzAfZmFeJSmPEcrqFTJfQfeHdrSY;

		protected bool initialized => PwPWygBTznyByBIyaAyqEfnsXBM;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			OnAwake();
			while (true)
			{
				int num = -1013545677;
				while (true)
				{
					switch (num ^ -1013545678)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					OnAwakeFinished();
					num = -1013545680;
				}
			}
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
			ReInput.InitializedEvent += DkBvIPUFnCdgGjvEcwfTcsvWErSm;
			while (true)
			{
				int num = 1484184366;
				while (true)
				{
					switch (num ^ 0x5876DB2C)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002f;
					case 1:
						return;
					}
					break;
					IL_002f:
					Initialize();
					num = 1484184365;
				}
			}
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
			ReInput.InitializedEvent -= DkBvIPUFnCdgGjvEcwfTcsvWErSm;
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
				PwPWygBTznyByBIyaAyqEfnsXBM = true;
				PostInitialize();
			}
		}

		protected virtual bool TryInitialize()
		{
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return false;
			}
			FzAfZmFeJSmPEcrqFTJfQfeHdrSY = CreateSource(GetCreateSourceArgs());
			if (FzAfZmFeJSmPEcrqFTJfQfeHdrSY == null)
			{
				Logger.LogError("Failed to create source object.");
				return false;
			}
			PwPWygBTznyByBIyaAyqEfnsXBM = true;
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
			PwPWygBTznyByBIyaAyqEfnsXBM = false;
			Unsubscribe();
			FzAfZmFeJSmPEcrqFTJfQfeHdrSY = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += FLfrwSAKoehkgCjfNADkiVeVsZl;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= FLfrwSAKoehkgCjfNADkiVeVsZl;
		}

		private void FLfrwSAKoehkgCjfNADkiVeVsZl()
		{
			Deinitialize();
		}

		private void DkBvIPUFnCdgGjvEcwfTcsvWErSm()
		{
			Initialize();
		}
	}
}
