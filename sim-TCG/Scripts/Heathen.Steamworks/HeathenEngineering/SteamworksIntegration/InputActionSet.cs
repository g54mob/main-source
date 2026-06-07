using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	public class InputActionSet : ScriptableObject
	{
		public string setName;

		public InputActionSetData Data { get; private set; }

		public bool IsActive(InputHandle_t controller)
		{
			if (Data == 0uL)
			{
				Data = InputActionSetData.Get(setName);
			}
			if (Data != 0uL)
			{
				if (Input.Client.GetCurrentActionSet(controller).m_InputActionSetHandle == Data)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public void Activate(InputHandle_t controller)
		{
			if (Data == 0uL)
			{
				Data = InputActionSetData.Get(setName);
			}
			if (Data != 0uL)
			{
				Input.Client.ActivateActionSet(controller, Data);
			}
		}

		public void Activate()
		{
			if (Data == 0uL)
			{
				Data = InputActionSetData.Get(setName);
			}
			if (Data != 0uL)
			{
				Input.Client.ActivateActionSet(Data);
			}
		}
	}
}
