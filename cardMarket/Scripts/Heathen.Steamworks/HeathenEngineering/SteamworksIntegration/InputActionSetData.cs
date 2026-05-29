using System;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct InputActionSetData : IEquatable<InputActionSetHandle_t>, IComparable<InputActionSetHandle_t>, IEquatable<ulong>, IComparable<ulong>
	{
		[SerializeField]
		private InputActionSetHandle_t handle;

		public ulong Handle => handle.m_InputActionSetHandle;

		public bool IsActive(InputControllerData controller)
		{
			return IsActive(controller.handle);
		}

		public bool IsActive(InputHandle_t controller)
		{
			if (handle.m_InputActionSetHandle != 0L)
			{
				if (Input.Client.GetCurrentActionSet(controller).m_InputActionSetHandle == handle.m_InputActionSetHandle)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public void Activate(InputControllerData controller)
		{
			Activate(controller.handle);
		}

		public void Activate(InputHandle_t controller)
		{
			if (handle.m_InputActionSetHandle != 0L)
			{
				Input.Client.ActivateActionSet(controller, handle);
			}
		}

		public static InputActionSetData Get(string setName)
		{
			return new InputActionSetData
			{
				handle = Input.Client.GetActionSetHandle(setName)
			};
		}

		public static InputActionSetData Get(InputActionSetHandle_t handle)
		{
			return new InputActionSetData
			{
				handle = handle
			};
		}

		public static InputActionSetData Get(ulong handleValue)
		{
			return new InputActionSetData
			{
				handle = new InputActionSetHandle_t(handleValue)
			};
		}

		public bool Equals(InputActionSetHandle_t other)
		{
			return handle.Equals(other);
		}

		public int CompareTo(InputActionSetHandle_t other)
		{
			return handle.CompareTo(other);
		}

		public bool Equals(ulong other)
		{
			return handle.m_InputActionSetHandle.Equals(other);
		}

		public int CompareTo(ulong other)
		{
			return handle.m_InputActionSetHandle.CompareTo(other);
		}

		public override bool Equals(object obj)
		{
			return handle.Equals(obj);
		}

		public override int GetHashCode()
		{
			return handle.GetHashCode();
		}

		public static bool operator ==(InputActionSetData l, InputActionSetHandle_t r)
		{
			return l.handle == r;
		}

		public static bool operator ==(InputActionSetData l, ulong r)
		{
			return l.handle == new InputActionSetHandle_t(r);
		}

		public static bool operator ==(InputActionSetHandle_t l, InputActionSetData r)
		{
			return l == r.handle;
		}

		public static bool operator ==(ulong l, InputActionSetData r)
		{
			return new InputActionSetHandle_t(l) == r.handle;
		}

		public static bool operator !=(InputActionSetData l, InputActionSetHandle_t r)
		{
			return l.handle != r;
		}

		public static bool operator !=(InputActionSetData l, ulong r)
		{
			return l.handle != new InputActionSetHandle_t(r);
		}

		public static bool operator !=(InputActionSetHandle_t l, InputActionSetData r)
		{
			return l != r.handle;
		}

		public static bool operator !=(ulong l, InputActionSetData r)
		{
			return new InputActionSetHandle_t(l) != r.handle;
		}

		public static implicit operator ulong(InputActionSetData c)
		{
			return c.handle.m_InputActionSetHandle;
		}

		public static implicit operator InputActionSetData(ulong id)
		{
			return Get(id);
		}

		public static implicit operator InputActionSetHandle_t(InputActionSetData c)
		{
			return c.handle;
		}

		public static implicit operator InputActionSetData(InputActionSetHandle_t id)
		{
			return Get(id);
		}
	}
}
