using System.Linq;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	public class InputActionSetLayer : ScriptableObject
	{
		public string layerName;

		public InputActionSetData Data { get; private set; }

		public bool IsActive(InputHandle_t controller)
		{
			if (Data == 0uL)
			{
				Data = InputActionSetData.Get(layerName);
			}
			if (Data != 0uL)
			{
				if (Input.Client.GetActiveActionSetLayers(controller).Any((InputActionSetHandle_t p) => p.m_InputActionSetHandle == Data))
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
				Data = InputActionSetData.Get(layerName);
			}
			if (Data != 0uL)
			{
				Input.Client.ActivateActionSetLayer(controller, Data);
			}
		}

		public void Activate()
		{
			if (Data == 0uL)
			{
				Data = InputActionSetData.Get(layerName);
			}
			if (Data != 0uL)
			{
				Input.Client.ActivateActionSetLayer(Data);
			}
		}
	}
}
