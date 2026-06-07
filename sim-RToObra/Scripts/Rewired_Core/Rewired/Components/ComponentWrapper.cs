using System;
using UnityEngine;

namespace Rewired.Components
{
	[Serializable]
	[AddComponentMenu("")]
	public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
	{
		[NonSerialized]
		private T PESlCqcuFEdCgwfIyyIoKbUwani;

		[NonSerialized]
		private bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		protected T source
		{
			get
			{
				return PESlCqcuFEdCgwfIyyIoKbUwani;
			}
		}

		protected bool initialized
		{
			get
			{
				return PkVqugVNIpoYIMpSDcpjdJRrnVs;
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
			ReInput.InitializedEvent += VRJiPTIEqUKfqksUVQNARBzDfgy;
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
			ReInput.InitializedEvent -= VRJiPTIEqUKfqksUVQNARBzDfgy;
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
				return;
			}
			while (true)
			{
				PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
				PostInitialize();
				int num = -2134075559;
				while (true)
				{
					switch (num ^ -2134075559)
					{
					case 2:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0009:
					num = -2134075560;
				}
			}
		}

		protected virtual bool TryInitialize()
		{
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				goto IL_0008;
			}
			PESlCqcuFEdCgwfIyyIoKbUwani = CreateSource(GetCreateSourceArgs());
			int num;
			if (PESlCqcuFEdCgwfIyyIoKbUwani == null)
			{
				num = -1178695324;
				goto IL_000d;
			}
			PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
			return true;
			IL_0008:
			num = -1178695321;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1178695322)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				Logger.LogError("Failed to create source object.");
				return false;
			}
			goto IL_0008;
		}

		protected abstract T CreateSource(object args);

		protected abstract object GetCreateSourceArgs();

		protected virtual void PostInitialize()
		{
			Subscribe();
		}

		protected virtual void Deinitialize()
		{
			PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
			Unsubscribe();
			PESlCqcuFEdCgwfIyyIoKbUwani = null;
		}

		protected virtual void Subscribe()
		{
			Unsubscribe();
			ReInput.ShutDownEvent += RStBZqOHvmAJGGJHihpzCVhaEmNk;
		}

		protected virtual void Unsubscribe()
		{
			ReInput.ShutDownEvent -= RStBZqOHvmAJGGJHihpzCVhaEmNk;
		}

		private void RStBZqOHvmAJGGJHihpzCVhaEmNk()
		{
			Deinitialize();
		}

		private void VRJiPTIEqUKfqksUVQNARBzDfgy()
		{
			Initialize();
		}
	}
}
