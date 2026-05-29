using System.ComponentModel;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	public class InputAction : ScriptableObject
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SerializeField]
		private InputActionType type;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[SerializeField]
		private string actionName;

		public InputActionType Type => type;

		public string ActionName => actionName;

		public InputAnalogActionHandle_t AnalogHandle => Input.Client.GetAnalogActionHandle(actionName);

		public InputDigitalActionHandle_t DigitalHandle => Input.Client.GetDigitalActionHandle(actionName);

		public InputActionData GetActionData(InputHandle_t controller)
		{
			return Input.Client.GetActionData(controller, actionName);
		}

		public InputActionData GetActionData()
		{
			return Input.Client.GetActionData(actionName);
		}

		public Texture2D[] GetInputGlyphs(InputHandle_t controller, InputActionSet set)
		{
			return GetInputGlyphs(controller, set.Data);
		}

		public Texture2D[] GetInputGlyphs(InputHandle_t controller, InputActionSetLayer set)
		{
			return GetInputGlyphs(controller, set.Data);
		}

		public Texture2D[] GetInputGlyphs(InputHandle_t controller, InputActionSetHandle_t set)
		{
			if (type == InputActionType.Analog)
			{
				EInputActionOrigin[] analogActionOrigins = Input.Client.GetAnalogActionOrigins(controller, set, AnalogHandle);
				Texture2D[] array = new Texture2D[analogActionOrigins.Length];
				for (int i = 0; i < analogActionOrigins.Length; i++)
				{
					array[i] = Input.Client.GetGlyphActionOrigin(analogActionOrigins[i]);
				}
				return array;
			}
			EInputActionOrigin[] digitalActionOrigins = Input.Client.GetDigitalActionOrigins(controller, set, DigitalHandle);
			Texture2D[] array2 = new Texture2D[digitalActionOrigins.Length];
			for (int j = 0; j < digitalActionOrigins.Length; j++)
			{
				array2[j] = Input.Client.GetGlyphActionOrigin(digitalActionOrigins[j]);
			}
			return array2;
		}

		public string[] GetInputNames(InputHandle_t controller, InputActionSet set)
		{
			return GetInputNames(controller, set.Data);
		}

		public string[] GetInputNames(InputHandle_t controller, InputActionSetLayer set)
		{
			return GetInputNames(controller, set.Data);
		}

		public string[] GetInputNames(InputHandle_t controller, InputActionSetHandle_t set)
		{
			if (type == InputActionType.Analog)
			{
				EInputActionOrigin[] analogActionOrigins = Input.Client.GetAnalogActionOrigins(controller, set, AnalogHandle);
				string[] array = new string[analogActionOrigins.Length];
				for (int i = 0; i < analogActionOrigins.Length; i++)
				{
					array[i] = Input.Client.GetStringForActionOrigin(analogActionOrigins[i]);
				}
				return array;
			}
			EInputActionOrigin[] digitalActionOrigins = Input.Client.GetDigitalActionOrigins(controller, set, DigitalHandle);
			string[] array2 = new string[digitalActionOrigins.Length];
			for (int j = 0; j < digitalActionOrigins.Length; j++)
			{
				array2[j] = Input.Client.GetStringForActionOrigin(digitalActionOrigins[j]);
			}
			return array2;
		}
	}
}
