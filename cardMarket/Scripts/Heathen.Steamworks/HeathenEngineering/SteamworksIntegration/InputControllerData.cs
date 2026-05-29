using System;
using System.Linq;
using Steamworks;
using Unity.Mathematics;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct InputControllerData
	{
		public InputHandle_t handle;

		public InputActionData[] inputs;

		public InputActionUpdate[] changes;

		public InputActionData GetActionData(InputAction action)
		{
			return GetActionData(action.ActionName);
		}

		public InputActionData GetActionData(string name)
		{
			return inputs.FirstOrDefault((InputActionData p) => p.name == name);
		}

		public bool GetActive(string name)
		{
			return inputs.FirstOrDefault((InputActionData p) => p.name == name).active;
		}

		public bool GetState(string name)
		{
			return inputs.FirstOrDefault((InputActionData p) => p.name == name).state;
		}

		public float GetFloat(string name)
		{
			return inputs.FirstOrDefault((InputActionData p) => p.name == name).x;
		}

		public float2 GetFloat2(string name)
		{
			InputActionData inputActionData = inputs.FirstOrDefault((InputActionData p) => p.name == name);
			return new float2(inputActionData.x, inputActionData.y);
		}

		public EInputSourceMode GetMode(string name)
		{
			return inputs.FirstOrDefault((InputActionData p) => p.name == name).mode;
		}
	}
}
