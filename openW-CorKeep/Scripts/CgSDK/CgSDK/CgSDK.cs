using System;
using System.Diagnostics;
using System.Text;
using UnityEngine;

namespace CgSDK
{
	public static class CgSDK
	{
		private static byte[][] stateAsciiStrings;

		private static byte[][] eventAsciiStrings;

		private static string[] errorNames;

		public unsafe static bool Initialize(string gameName, string[] stateNames, string[] eventNames)
		{
			errorNames = Enum.GetNames(typeof(Error));
			if (Bindings.CgSdkPerformProtocolHandshake().serverVersion == IntPtr.Zero)
			{
				UnityEngine.Debug.Log("No iCUE server detected");
				return false;
			}
			if (!Bindings.CgSdkRequestControl())
			{
				return false;
			}
			byte[] array = new byte[Encoding.ASCII.GetByteCount(gameName) + 1];
			Encoding.ASCII.GetBytes(gameName, 0, gameName.Length, array, 0);
			fixed (byte* gameName2 = array)
			{
				if (!Bindings.CgSdkSetGame(gameName2))
				{
					Deinitialize();
					return false;
				}
			}
			stateAsciiStrings = new byte[stateNames.Length][];
			for (int i = 0; i < stateNames.Length; i++)
			{
				stateAsciiStrings[i] = new byte[Encoding.ASCII.GetByteCount(stateNames[i]) + 1];
				Encoding.ASCII.GetBytes(stateNames[i], 0, stateNames[i].Length, stateAsciiStrings[i], 0);
			}
			eventAsciiStrings = new byte[stateNames.Length][];
			for (int j = 0; j < eventNames.Length; j++)
			{
				eventAsciiStrings[j] = new byte[Encoding.ASCII.GetByteCount(eventNames[j]) + 1];
				Encoding.ASCII.GetBytes(eventNames[j], 0, eventNames[j].Length, eventAsciiStrings[j], 0);
			}
			return true;
		}

		public static void Deinitialize()
		{
			Bindings.CgSdkReleaseControl();
		}

		public unsafe static void StartState(int stateIndex)
		{
			fixed (byte* stateName = stateAsciiStrings[stateIndex])
			{
				Bindings.CgSdkSetState(stateName);
			}
		}

		public unsafe static void EndState(int stateIndex)
		{
			fixed (byte* stateName = stateAsciiStrings[stateIndex])
			{
				Bindings.CgSdkClearState(stateName);
			}
		}

		public unsafe static void TriggerEvent(int eventIndex)
		{
			fixed (byte* eventName = eventAsciiStrings[eventIndex])
			{
				Bindings.CgSdkSetEvent(eventName);
			}
		}

		public static void EndAllStates()
		{
			Bindings.CgSdkClearAllStates();
		}

		public static void EndAllEvents()
		{
			Bindings.CgSdkClearAllEvents();
		}

		[Conditional("UNITY_EDITOR")]
		private static void PrintLastError()
		{
			Error error = Bindings.CgSdkGetLastError();
			UnityEngine.Debug.LogError(errorNames[(int)error]);
		}
	}
}
