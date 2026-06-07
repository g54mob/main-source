using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Oculus.Platform
{
	public class CAPI
	{
		public struct ovrKeyValuePair
		{
			public string key_;

			private KeyValuePairType valueType_;

			public string stringValue_;

			public int intValue_;

			public double doubleValue_;

			public ovrKeyValuePair(string key, string value)
			{
				key_ = key;
				valueType_ = KeyValuePairType.String;
				stringValue_ = value;
				intValue_ = 0;
				doubleValue_ = 0.0;
			}

			public ovrKeyValuePair(string key, int value)
			{
				key_ = key;
				valueType_ = KeyValuePairType.Int;
				intValue_ = value;
				stringValue_ = null;
				doubleValue_ = 0.0;
			}

			public ovrKeyValuePair(string key, double value)
			{
				key_ = key;
				valueType_ = KeyValuePairType.Double;
				doubleValue_ = value;
				stringValue_ = null;
				intValue_ = 0;
			}
		}

		public struct ovrNetSyncVec3
		{
			public float x;

			public float y;

			public float z;
		}

		public struct ovrMatchmakingCriterion
		{
			public string key_;

			public MatchmakingCriterionImportance importance_;

			public IntPtr parameterArray;

			public uint parameterArrayCount;

			public ovrMatchmakingCriterion(string key, MatchmakingCriterionImportance importance)
			{
				key_ = key;
				importance_ = importance;
				parameterArray = IntPtr.Zero;
				parameterArrayCount = 0u;
			}
		}

		public struct ovrMatchmakingCustomQueryData
		{
			public IntPtr dataArray;

			public uint dataArrayCount;

			public IntPtr criterionArray;

			public uint criterionArrayCount;
		}

		public struct OculusInitParams
		{
			public int sType;

			public string email;

			public string password;

			public ulong appId;

			public string uriPrefixOverride;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void FilterCallback([In][Out][MarshalAs(UnmanagedType.LPArray, SizeConst = 480)] short[] pcmData, UIntPtr pcmDataLength, int frequency, int numChannels);

		public const string DLL_NAME = "LibOVRPlatform64_1";

		private static UTF8Encoding nativeStringEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

		public const int VoipFilterBufferSize = 480;

		public static IntPtr ArrayOfStructsToIntPtr(Array ar)
		{
			int num = 0;
			for (int i = 0; i < ar.Length; i++)
			{
				num += Marshal.SizeOf(ar.GetValue(i));
			}
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			IntPtr intPtr2 = intPtr;
			for (int j = 0; j < ar.Length; j++)
			{
				Marshal.StructureToPtr(ar.GetValue(j), intPtr2, fDeleteOld: false);
				intPtr2 = (IntPtr)((long)intPtr2 + Marshal.SizeOf(ar.GetValue(j)));
			}
			return intPtr;
		}

		public static ovrKeyValuePair[] DictionaryToOVRKeyValuePairs(Dictionary<string, object> dict)
		{
			if (dict == null || dict.Count == 0)
			{
				return null;
			}
			ovrKeyValuePair[] array = new ovrKeyValuePair[dict.Count];
			int num = 0;
			foreach (KeyValuePair<string, object> item in dict)
			{
				if (item.Value.GetType() == typeof(int))
				{
					array[num] = new ovrKeyValuePair(item.Key, (int)item.Value);
				}
				else if (item.Value.GetType() == typeof(string))
				{
					array[num] = new ovrKeyValuePair(item.Key, (string)item.Value);
				}
				else
				{
					if (!(item.Value.GetType() == typeof(double)))
					{
						throw new Exception("Only int, double or string are allowed types in CustomQuery.data");
					}
					array[num] = new ovrKeyValuePair(item.Key, (double)item.Value);
				}
				num++;
			}
			return array;
		}

		public static byte[] IntPtrToByteArray(IntPtr data, ulong size)
		{
			byte[] array = new byte[size];
			Marshal.Copy(data, array, 0, (int)size);
			return array;
		}

		public static Dictionary<string, string> DataStoreFromNative(IntPtr pointer)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			int num = (int)(uint)ovr_DataStore_GetNumKeys(pointer);
			for (int i = 0; i < num; i++)
			{
				string key = ovr_DataStore_GetKey(pointer, i);
				dictionary[key] = ovr_DataStore_GetValue(pointer, key);
			}
			return dictionary;
		}

		public static string StringFromNative(IntPtr pointer)
		{
			if (pointer == IntPtr.Zero)
			{
				return null;
			}
			int nativeStringLengthNotIncludingNullTerminator = GetNativeStringLengthNotIncludingNullTerminator(pointer);
			byte[] array = new byte[nativeStringLengthNotIncludingNullTerminator];
			Marshal.Copy(pointer, array, 0, nativeStringLengthNotIncludingNullTerminator);
			return nativeStringEncoding.GetString(array);
		}

		public static int GetNativeStringLengthNotIncludingNullTerminator(IntPtr pointer)
		{
			int i;
			for (i = 0; Marshal.ReadByte(pointer, i) != 0; i++)
			{
			}
			return i;
		}

		public static DateTime DateTimeFromNative(ulong seconds_since_the_one_true_epoch)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(seconds_since_the_one_true_epoch).ToLocalTime();
		}

		public static ulong DateTimeToNative(DateTime dt)
		{
			DateTime obj = ((dt.Kind != DateTimeKind.Utc) ? dt.ToUniversalTime() : dt);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return (ulong)(obj - dateTime).TotalSeconds;
		}

		public static byte[] BlobFromNative(uint size, IntPtr pointer)
		{
			byte[] array = new byte[size];
			for (int i = 0; i < (int)size; i++)
			{
				array[i] = Marshal.ReadByte(pointer, i);
			}
			return array;
		}

		public static byte[] FiledataFromNative(uint size, IntPtr pointer)
		{
			byte[] array = new byte[size];
			Marshal.Copy(pointer, array, 0, (int)size);
			return array;
		}

		public static IntPtr StringToNative(string s)
		{
			if (s == null)
			{
				throw new Exception("StringFromNative: null argument");
			}
			int byteCount = nativeStringEncoding.GetByteCount(s);
			byte[] array = new byte[byteCount + 1];
			nativeStringEncoding.GetBytes(s, 0, s.Length, array, 0);
			IntPtr intPtr = Marshal.AllocCoTaskMem(byteCount + 1);
			Marshal.Copy(array, 0, intPtr, byteCount + 1);
			return intPtr;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UnityInitWrapper(string appId);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_UnityInitGlobals(IntPtr loggingCB);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_UnityInitWrapperAsynchronous(string appId);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UnityInitWrapperStandalone(string accessToken, IntPtr loggingCB);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Platform_InitializeStandaloneOculus(ref OculusInitParams init);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_PlatformInitializeWithAccessToken(ulong appId, string accessToken);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UnityInitWrapperWindows(string appId, IntPtr loggingCB);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_UnityInitWrapperWindowsAsynchronous(string appId, IntPtr loggingCB);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_SetDeveloperAccessToken(string accessToken);

		public static string ovr_GetLoggedInUserLocale()
		{
			return StringFromNative(ovr_GetLoggedInUserLocale_Native());
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GetLoggedInUserLocale")]
		private static extern IntPtr ovr_GetLoggedInUserLocale_Native();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_PopMessage();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_FreeMessage(IntPtr message);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Voip_CreateEncoder();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_DestroyEncoder(IntPtr encoder);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Voip_CreateDecoder();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_DestroyDecoder(IntPtr decoder);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_VoipDecoder_Decode(IntPtr obj, byte[] compressedData, ulong compressedSize);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Microphone_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Microphone_Destroy(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_SetSystemVoipPassthrough(bool passthrough);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_SetSystemVoipMicrophoneMuted(VoipMuteState muted);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_UnityResetTestPlatform();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_HTTP_GetWithMessageType(string url, int messageType);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_CrashApplication();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_SetMicrophoneFilterCallback(FilterCallback cb);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_SetMicrophoneFilterCallbackWithFixedSizeBuffer(FilterCallback cb, UIntPtr bufferSizeElements);

		public static void LogNewEvent(string eventName, Dictionary<string, string> values)
		{
			IntPtr intPtr = StringToNative(eventName);
			int num = values?.Count ?? 0;
			IntPtr[] array = new IntPtr[num * 2];
			if (num > 0)
			{
				int num2 = 0;
				foreach (KeyValuePair<string, string> value in values)
				{
					array[num2 * 2] = StringToNative(value.Key);
					array[num2 * 2 + 1] = StringToNative(value.Value);
					num2++;
				}
			}
			ovr_Log_NewEvent(intPtr, array, (UIntPtr)(ulong)num);
			Marshal.FreeCoTaskMem(intPtr);
			IntPtr[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				Marshal.FreeCoTaskMem(array2[i]);
			}
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Log_NewEvent(IntPtr eventName, IntPtr[] values, UIntPtr length);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ApplicationLifecycle_GetLaunchDetails();

		public static void ovr_ApplicationLifecycle_LogDeeplinkResult(string trackingID, LaunchResult result)
		{
			IntPtr intPtr = StringToNative(trackingID);
			ovr_ApplicationLifecycle_LogDeeplinkResult_Native(intPtr, result);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationLifecycle_LogDeeplinkResult")]
		private static extern void ovr_ApplicationLifecycle_LogDeeplinkResult_Native(IntPtr trackingID, LaunchResult result);

		public static ulong ovr_HTTP_StartTransfer(string url, ovrKeyValuePair[] headers)
		{
			IntPtr intPtr = StringToNative(url);
			UIntPtr numItems = (UIntPtr)(ulong)headers.Length;
			ulong result = ovr_HTTP_StartTransfer_Native(intPtr, headers, numItems);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_HTTP_StartTransfer")]
		private static extern ulong ovr_HTTP_StartTransfer_Native(IntPtr url, ovrKeyValuePair[] headers, UIntPtr numItems);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_HTTP_Write(ulong transferId, byte[] bytes, UIntPtr length);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_HTTP_WriteEOM(ulong transferId);

		public static string ovr_Message_GetStringForJavascript(IntPtr message)
		{
			return StringFromNative(ovr_Message_GetStringForJavascript_Native(message));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Message_GetStringForJavascript")]
		private static extern IntPtr ovr_Message_GetStringForJavascript_Native(IntPtr message);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSync_GetAmbisonicFloatPCM(long connection_id, float[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSync_GetAmbisonicInt16PCM(long connection_id, short[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSync_GetAmbisonicInterleavedFloatPCM(long connection_id, float[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSync_GetAmbisonicInterleavedInt16PCM(long connection_id, short[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_NetSync_GetListenerPosition(long connection_id, ulong sessionId, ref ovrNetSyncVec3 position);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSync_GetMonostreamFloatPCM(long connection_id, ulong sessionId, float[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSync_GetMonostreamInt16PCM(long connection_id, ulong session_id, short[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSync_GetPcmBufferMaxSamples();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_NetSync_GetVoipAmplitude(long connection_id, ulong sessionId, ref float amplitude);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_NetSync_SetListenerPosition(long connection_id, ref ovrNetSyncVec3 position);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Net_Accept(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_Net_AcceptForCurrentRoom();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Net_Close(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Net_CloseForCurrentRoom();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Net_Connect(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_Net_IsConnected(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Net_Ping(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Net_ReadPacket();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_Net_SendPacket(ulong userID, UIntPtr length, byte[] bytes, SendPolicy policy);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_Net_SendPacketToCurrentRoom(UIntPtr length, byte[] bytes, SendPolicy policy);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_Party_PluginGetSharedMemHandle();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern VoipMuteState ovr_Party_PluginGetVoipMicrophoneMuted();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_Party_PluginGetVoipPassthrough();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern SystemVoipStatus ovr_Party_PluginGetVoipStatus();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_Accept(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern VoipDtxState ovr_Voip_GetIsConnectionUsingDtx(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern VoipBitrate ovr_Voip_GetLocalBitrate(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Voip_GetOutputBufferMaxSize();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Voip_GetPCM(ulong senderID, short[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Voip_GetPCMFloat(ulong senderID, float[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Voip_GetPCMSize(ulong senderID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Voip_GetPCMWithTimestamp(ulong senderID, short[] outputBuffer, UIntPtr outputBufferNumElements, uint[] timestamp);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Voip_GetPCMWithTimestampFloat(ulong senderID, float[] outputBuffer, UIntPtr outputBufferNumElements, uint[] timestamp);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern VoipBitrate ovr_Voip_GetRemoteBitrate(ulong peerID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_Voip_GetSyncTimestamp(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_Voip_GetSyncTimestampDifference(uint lhs, uint rhs);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern VoipMuteState ovr_Voip_GetSystemVoipMicrophoneMuted();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern SystemVoipStatus ovr_Voip_GetSystemVoipStatus();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_SetMicrophoneMuted(VoipMuteState state);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_SetNewConnectionOptions(IntPtr voipOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_SetOutputSampleRate(VoipSampleRate rate);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_Start(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Voip_Stop(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AbuseReport_LaunchAdvancedReportFlow(ulong content_id, IntPtr abuse_report_options);

		public static ulong ovr_Achievements_AddCount(string name, ulong count)
		{
			IntPtr intPtr = StringToNative(name);
			ulong result = ovr_Achievements_AddCount_Native(intPtr, count);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Achievements_AddCount")]
		private static extern ulong ovr_Achievements_AddCount_Native(IntPtr name, ulong count);

		public static ulong ovr_Achievements_AddFields(string name, string fields)
		{
			IntPtr intPtr = StringToNative(name);
			IntPtr intPtr2 = StringToNative(fields);
			ulong result = ovr_Achievements_AddFields_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Achievements_AddFields")]
		private static extern ulong ovr_Achievements_AddFields_Native(IntPtr name, IntPtr fields);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Achievements_GetAllDefinitions();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Achievements_GetAllProgress();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Achievements_GetDefinitionsByName(string[] names, int count);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Achievements_GetProgressByName(string[] names, int count);

		public static ulong ovr_Achievements_Unlock(string name)
		{
			IntPtr intPtr = StringToNative(name);
			ulong result = ovr_Achievements_Unlock_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Achievements_Unlock")]
		private static extern ulong ovr_Achievements_Unlock_Native(IntPtr name);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Application_ExecuteCoordinatedLaunch(ulong appID, ulong roomID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Application_GetInstalledApplications();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Application_GetVersion();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Application_LaunchOtherApp(ulong appID, IntPtr deeplink_options);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_ApplicationLifecycle_GetRegisteredPIDs();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_ApplicationLifecycle_GetSessionKey();

		public static ulong ovr_ApplicationLifecycle_RegisterSessionKey(string sessionKey)
		{
			IntPtr intPtr = StringToNative(sessionKey);
			ulong result = ovr_ApplicationLifecycle_RegisterSessionKey_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationLifecycle_RegisterSessionKey")]
		private static extern ulong ovr_ApplicationLifecycle_RegisterSessionKey_Native(IntPtr sessionKey);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_Delete(ulong assetFileID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_DeleteById(ulong assetFileID);

		public static ulong ovr_AssetFile_DeleteByName(string assetFileName)
		{
			IntPtr intPtr = StringToNative(assetFileName);
			ulong result = ovr_AssetFile_DeleteByName_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetFile_DeleteByName")]
		private static extern ulong ovr_AssetFile_DeleteByName_Native(IntPtr assetFileName);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_Download(ulong assetFileID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_DownloadById(ulong assetFileID);

		public static ulong ovr_AssetFile_DownloadByName(string assetFileName)
		{
			IntPtr intPtr = StringToNative(assetFileName);
			ulong result = ovr_AssetFile_DownloadByName_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetFile_DownloadByName")]
		private static extern ulong ovr_AssetFile_DownloadByName_Native(IntPtr assetFileName);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_DownloadCancel(ulong assetFileID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_DownloadCancelById(ulong assetFileID);

		public static ulong ovr_AssetFile_DownloadCancelByName(string assetFileName)
		{
			IntPtr intPtr = StringToNative(assetFileName);
			ulong result = ovr_AssetFile_DownloadCancelByName_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetFile_DownloadCancelByName")]
		private static extern ulong ovr_AssetFile_DownloadCancelByName_Native(IntPtr assetFileName);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_GetList();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_Status(ulong assetFileID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFile_StatusById(ulong assetFileID);

		public static ulong ovr_AssetFile_StatusByName(string assetFileName)
		{
			IntPtr intPtr = StringToNative(assetFileName);
			ulong result = ovr_AssetFile_StatusByName_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetFile_StatusByName")]
		private static extern ulong ovr_AssetFile_StatusByName_Native(IntPtr assetFileName);

		public static ulong ovr_Avatar_UpdateMetaData(string avatarMetaData, string imageFilePath)
		{
			IntPtr intPtr = StringToNative(avatarMetaData);
			IntPtr intPtr2 = StringToNative(imageFilePath);
			ulong result = ovr_Avatar_UpdateMetaData_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Avatar_UpdateMetaData")]
		private static extern ulong ovr_Avatar_UpdateMetaData_Native(IntPtr avatarMetaData, IntPtr imageFilePath);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Cal_FinalizeApplication(ulong groupingObject, ulong[] userIDs, int numUserIDs, ulong finalized_application_ID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Cal_GetSuggestedApplications(ulong groupingObject, ulong[] userIDs, int numUserIDs);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Cal_ProposeApplication(ulong groupingObject, ulong[] userIDs, int numUserIDs, ulong proposed_application_ID);

		public static ulong ovr_Challenges_Create(string leaderboardName, IntPtr challengeOptions)
		{
			IntPtr intPtr = StringToNative(leaderboardName);
			ulong result = ovr_Challenges_Create_Native(intPtr, challengeOptions);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Challenges_Create")]
		private static extern ulong ovr_Challenges_Create_Native(IntPtr leaderboardName, IntPtr challengeOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_DeclineInvite(ulong challengeID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_Delete(ulong challengeID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_Get(ulong challengeID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetEntries(ulong challengeID, int limit, LeaderboardFilterType filter, LeaderboardStartAt startAt);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetEntriesAfterRank(ulong challengeID, int limit, ulong afterRank);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetEntriesByIds(ulong challengeID, int limit, LeaderboardStartAt startAt, ulong[] userIDs, uint userIDLength);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetList(IntPtr challengeOptions, int limit);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetNextChallenges(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetNextEntries(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetPreviousChallenges(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_GetPreviousEntries(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_Join(ulong challengeID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_Leave(ulong challengeID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenges_UpdateInfo(ulong challengeID, IntPtr challengeOptions);

		public static ulong ovr_CloudStorage_Delete(string bucket, string key)
		{
			IntPtr intPtr = StringToNative(bucket);
			IntPtr intPtr2 = StringToNative(key);
			ulong result = ovr_CloudStorage_Delete_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_Delete")]
		private static extern ulong ovr_CloudStorage_Delete_Native(IntPtr bucket, IntPtr key);

		public static ulong ovr_CloudStorage_Load(string bucket, string key)
		{
			IntPtr intPtr = StringToNative(bucket);
			IntPtr intPtr2 = StringToNative(key);
			ulong result = ovr_CloudStorage_Load_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_Load")]
		private static extern ulong ovr_CloudStorage_Load_Native(IntPtr bucket, IntPtr key);

		public static ulong ovr_CloudStorage_LoadBucketMetadata(string bucket)
		{
			IntPtr intPtr = StringToNative(bucket);
			ulong result = ovr_CloudStorage_LoadBucketMetadata_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_LoadBucketMetadata")]
		private static extern ulong ovr_CloudStorage_LoadBucketMetadata_Native(IntPtr bucket);

		public static ulong ovr_CloudStorage_LoadConflictMetadata(string bucket, string key)
		{
			IntPtr intPtr = StringToNative(bucket);
			IntPtr intPtr2 = StringToNative(key);
			ulong result = ovr_CloudStorage_LoadConflictMetadata_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_LoadConflictMetadata")]
		private static extern ulong ovr_CloudStorage_LoadConflictMetadata_Native(IntPtr bucket, IntPtr key);

		public static ulong ovr_CloudStorage_LoadHandle(string handle)
		{
			IntPtr intPtr = StringToNative(handle);
			ulong result = ovr_CloudStorage_LoadHandle_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_LoadHandle")]
		private static extern ulong ovr_CloudStorage_LoadHandle_Native(IntPtr handle);

		public static ulong ovr_CloudStorage_LoadMetadata(string bucket, string key)
		{
			IntPtr intPtr = StringToNative(bucket);
			IntPtr intPtr2 = StringToNative(key);
			ulong result = ovr_CloudStorage_LoadMetadata_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_LoadMetadata")]
		private static extern ulong ovr_CloudStorage_LoadMetadata_Native(IntPtr bucket, IntPtr key);

		public static ulong ovr_CloudStorage_ResolveKeepLocal(string bucket, string key, string remoteHandle)
		{
			IntPtr intPtr = StringToNative(bucket);
			IntPtr intPtr2 = StringToNative(key);
			IntPtr intPtr3 = StringToNative(remoteHandle);
			ulong result = ovr_CloudStorage_ResolveKeepLocal_Native(intPtr, intPtr2, intPtr3);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			Marshal.FreeCoTaskMem(intPtr3);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_ResolveKeepLocal")]
		private static extern ulong ovr_CloudStorage_ResolveKeepLocal_Native(IntPtr bucket, IntPtr key, IntPtr remoteHandle);

		public static ulong ovr_CloudStorage_ResolveKeepRemote(string bucket, string key, string remoteHandle)
		{
			IntPtr intPtr = StringToNative(bucket);
			IntPtr intPtr2 = StringToNative(key);
			IntPtr intPtr3 = StringToNative(remoteHandle);
			ulong result = ovr_CloudStorage_ResolveKeepRemote_Native(intPtr, intPtr2, intPtr3);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			Marshal.FreeCoTaskMem(intPtr3);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_ResolveKeepRemote")]
		private static extern ulong ovr_CloudStorage_ResolveKeepRemote_Native(IntPtr bucket, IntPtr key, IntPtr remoteHandle);

		public static ulong ovr_CloudStorage_Save(string bucket, string key, byte[] data, uint dataSize, long counter, string extraData)
		{
			IntPtr intPtr = StringToNative(bucket);
			IntPtr intPtr2 = StringToNative(key);
			IntPtr intPtr3 = StringToNative(extraData);
			ulong result = ovr_CloudStorage_Save_Native(intPtr, intPtr2, data, dataSize, counter, intPtr3);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			Marshal.FreeCoTaskMem(intPtr3);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage_Save")]
		private static extern ulong ovr_CloudStorage_Save_Native(IntPtr bucket, IntPtr key, byte[] data, uint dataSize, long counter, IntPtr extraData);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_CloudStorage2_GetUserDirectoryPath();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Colocation_GetCurrentMapUuid();

		public static ulong ovr_Colocation_RequestMap(string uuid)
		{
			IntPtr intPtr = StringToNative(uuid);
			ulong result = ovr_Colocation_RequestMap_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Colocation_RequestMap")]
		private static extern ulong ovr_Colocation_RequestMap_Native(IntPtr uuid);

		public static ulong ovr_Colocation_ShareMap(string uuid)
		{
			IntPtr intPtr = StringToNative(uuid);
			ulong result = ovr_Colocation_ShareMap_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Colocation_ShareMap")]
		private static extern ulong ovr_Colocation_ShareMap_Native(IntPtr uuid);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Entitlement_GetIsViewerEntitled();

		public static ulong ovr_GraphAPI_Get(string url)
		{
			IntPtr intPtr = StringToNative(url);
			ulong result = ovr_GraphAPI_Get_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GraphAPI_Get")]
		private static extern ulong ovr_GraphAPI_Get_Native(IntPtr url);

		public static ulong ovr_GraphAPI_Post(string url)
		{
			IntPtr intPtr = StringToNative(url);
			ulong result = ovr_GraphAPI_Post_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GraphAPI_Post")]
		private static extern ulong ovr_GraphAPI_Post_Native(IntPtr url);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_Clear();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_GetInvitableUsers(IntPtr options);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_GetSentInvites();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_LaunchInvitePanel(IntPtr options);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_LaunchMultiplayerErrorDialog(IntPtr options);

		public static ulong ovr_GroupPresence_LaunchRejoinDialog(string lobby_session_id, string match_session_id, string destination_api_name)
		{
			IntPtr intPtr = StringToNative(lobby_session_id);
			IntPtr intPtr2 = StringToNative(match_session_id);
			IntPtr intPtr3 = StringToNative(destination_api_name);
			ulong result = ovr_GroupPresence_LaunchRejoinDialog_Native(intPtr, intPtr2, intPtr3);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			Marshal.FreeCoTaskMem(intPtr3);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresence_LaunchRejoinDialog")]
		private static extern ulong ovr_GroupPresence_LaunchRejoinDialog_Native(IntPtr lobby_session_id, IntPtr match_session_id, IntPtr destination_api_name);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_LaunchRosterPanel(IntPtr options);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_SendInvites(ulong[] userIDs, uint userIDLength);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_Set(IntPtr groupPresenceOptions);

		public static ulong ovr_GroupPresence_SetDestination(string api_name)
		{
			IntPtr intPtr = StringToNative(api_name);
			ulong result = ovr_GroupPresence_SetDestination_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresence_SetDestination")]
		private static extern ulong ovr_GroupPresence_SetDestination_Native(IntPtr api_name);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_GroupPresence_SetIsJoinable(bool is_joinable);

		public static ulong ovr_GroupPresence_SetLobbySession(string id)
		{
			IntPtr intPtr = StringToNative(id);
			ulong result = ovr_GroupPresence_SetLobbySession_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresence_SetLobbySession")]
		private static extern ulong ovr_GroupPresence_SetLobbySession_Native(IntPtr id);

		public static ulong ovr_GroupPresence_SetMatchSession(string id)
		{
			IntPtr intPtr = StringToNative(id);
			ulong result = ovr_GroupPresence_SetMatchSession_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresence_SetMatchSession")]
		private static extern ulong ovr_GroupPresence_SetMatchSession_Native(IntPtr id);

		public static ulong ovr_HTTP_Get(string url)
		{
			IntPtr intPtr = StringToNative(url);
			ulong result = ovr_HTTP_Get_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_HTTP_Get")]
		private static extern ulong ovr_HTTP_Get_Native(IntPtr url);

		public static ulong ovr_HTTP_GetToFile(string url, string diskFile)
		{
			IntPtr intPtr = StringToNative(url);
			IntPtr intPtr2 = StringToNative(diskFile);
			ulong result = ovr_HTTP_GetToFile_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_HTTP_GetToFile")]
		private static extern ulong ovr_HTTP_GetToFile_Native(IntPtr url, IntPtr diskFile);

		public static ulong ovr_HTTP_MultiPartPost(string url, string filepath_param_name, string filepath, string access_token, ovrKeyValuePair[] post_params)
		{
			IntPtr intPtr = StringToNative(url);
			IntPtr intPtr2 = StringToNative(filepath_param_name);
			IntPtr intPtr3 = StringToNative(filepath);
			IntPtr intPtr4 = StringToNative(access_token);
			UIntPtr numItems = (UIntPtr)(ulong)post_params.Length;
			ulong result = ovr_HTTP_MultiPartPost_Native(intPtr, intPtr2, intPtr3, intPtr4, post_params, numItems);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			Marshal.FreeCoTaskMem(intPtr3);
			Marshal.FreeCoTaskMem(intPtr4);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_HTTP_MultiPartPost")]
		private static extern ulong ovr_HTTP_MultiPartPost_Native(IntPtr url, IntPtr filepath_param_name, IntPtr filepath, IntPtr access_token, ovrKeyValuePair[] post_params, UIntPtr numItems);

		public static ulong ovr_HTTP_Post(string url)
		{
			IntPtr intPtr = StringToNative(url);
			ulong result = ovr_HTTP_Post_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_HTTP_Post")]
		private static extern ulong ovr_HTTP_Post_Native(IntPtr url);

		public static ulong ovr_IAP_ConsumePurchase(string sku)
		{
			IntPtr intPtr = StringToNative(sku);
			ulong result = ovr_IAP_ConsumePurchase_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_IAP_ConsumePurchase")]
		private static extern ulong ovr_IAP_ConsumePurchase_Native(IntPtr sku);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_IAP_GetProductsBySKU(string[] skus, int count);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_IAP_GetViewerPurchases();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_IAP_GetViewerPurchasesDurableCache();

		public static ulong ovr_IAP_LaunchCheckoutFlow(string sku)
		{
			IntPtr intPtr = StringToNative(sku);
			ulong result = ovr_IAP_LaunchCheckoutFlow_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_IAP_LaunchCheckoutFlow")]
		private static extern ulong ovr_IAP_LaunchCheckoutFlow_Native(IntPtr sku);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_LanguagePack_GetCurrent();

		public static ulong ovr_LanguagePack_SetCurrent(string tag)
		{
			IntPtr intPtr = StringToNative(tag);
			ulong result = ovr_LanguagePack_SetCurrent_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LanguagePack_SetCurrent")]
		private static extern ulong ovr_LanguagePack_SetCurrent_Native(IntPtr tag);

		public static ulong ovr_Leaderboard_Get(string leaderboardName)
		{
			IntPtr intPtr = StringToNative(leaderboardName);
			ulong result = ovr_Leaderboard_Get_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Leaderboard_Get")]
		private static extern ulong ovr_Leaderboard_Get_Native(IntPtr leaderboardName);

		public static ulong ovr_Leaderboard_GetEntries(string leaderboardName, int limit, LeaderboardFilterType filter, LeaderboardStartAt startAt)
		{
			IntPtr intPtr = StringToNative(leaderboardName);
			ulong result = ovr_Leaderboard_GetEntries_Native(intPtr, limit, filter, startAt);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Leaderboard_GetEntries")]
		private static extern ulong ovr_Leaderboard_GetEntries_Native(IntPtr leaderboardName, int limit, LeaderboardFilterType filter, LeaderboardStartAt startAt);

		public static ulong ovr_Leaderboard_GetEntriesAfterRank(string leaderboardName, int limit, ulong afterRank)
		{
			IntPtr intPtr = StringToNative(leaderboardName);
			ulong result = ovr_Leaderboard_GetEntriesAfterRank_Native(intPtr, limit, afterRank);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Leaderboard_GetEntriesAfterRank")]
		private static extern ulong ovr_Leaderboard_GetEntriesAfterRank_Native(IntPtr leaderboardName, int limit, ulong afterRank);

		public static ulong ovr_Leaderboard_GetEntriesByIds(string leaderboardName, int limit, LeaderboardStartAt startAt, ulong[] userIDs, uint userIDLength)
		{
			IntPtr intPtr = StringToNative(leaderboardName);
			ulong result = ovr_Leaderboard_GetEntriesByIds_Native(intPtr, limit, startAt, userIDs, userIDLength);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Leaderboard_GetEntriesByIds")]
		private static extern ulong ovr_Leaderboard_GetEntriesByIds_Native(IntPtr leaderboardName, int limit, LeaderboardStartAt startAt, ulong[] userIDs, uint userIDLength);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Leaderboard_GetNextEntries(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Leaderboard_GetPreviousEntries(IntPtr handle);

		public static ulong ovr_Leaderboard_WriteEntry(string leaderboardName, long score, byte[] extraData, uint extraDataLength, bool forceUpdate)
		{
			IntPtr intPtr = StringToNative(leaderboardName);
			ulong result = ovr_Leaderboard_WriteEntry_Native(intPtr, score, extraData, extraDataLength, forceUpdate);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Leaderboard_WriteEntry")]
		private static extern ulong ovr_Leaderboard_WriteEntry_Native(IntPtr leaderboardName, long score, byte[] extraData, uint extraDataLength, bool forceUpdate);

		public static ulong ovr_Leaderboard_WriteEntryWithSupplementaryMetric(string leaderboardName, long score, long supplementaryMetric, byte[] extraData, uint extraDataLength, bool forceUpdate)
		{
			IntPtr intPtr = StringToNative(leaderboardName);
			ulong result = ovr_Leaderboard_WriteEntryWithSupplementaryMetric_Native(intPtr, score, supplementaryMetric, extraData, extraDataLength, forceUpdate);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Leaderboard_WriteEntryWithSupplementaryMetric")]
		private static extern ulong ovr_Leaderboard_WriteEntryWithSupplementaryMetric_Native(IntPtr leaderboardName, long score, long supplementaryMetric, byte[] extraData, uint extraDataLength, bool forceUpdate);

		public static ulong ovr_Livestreaming_IsAllowedForApplication(string packageName)
		{
			IntPtr intPtr = StringToNative(packageName);
			ulong result = ovr_Livestreaming_IsAllowedForApplication_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Livestreaming_IsAllowedForApplication")]
		private static extern ulong ovr_Livestreaming_IsAllowedForApplication_Native(IntPtr packageName);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Livestreaming_StartPartyStream();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Livestreaming_StartStream(LivestreamingAudience audience, LivestreamingMicrophoneStatus micStatus);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Livestreaming_StopPartyStream();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Livestreaming_StopStream();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Livestreaming_UpdateMicStatus(LivestreamingMicrophoneStatus micStatus);

		public static ulong ovr_Matchmaking_Browse(string pool, IntPtr customQueryData)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_Browse_Native(intPtr, customQueryData);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_Browse")]
		private static extern ulong ovr_Matchmaking_Browse_Native(IntPtr pool, IntPtr customQueryData);

		public static ulong ovr_Matchmaking_Browse2(string pool, IntPtr matchmakingOptions)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_Browse2_Native(intPtr, matchmakingOptions);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_Browse2")]
		private static extern ulong ovr_Matchmaking_Browse2_Native(IntPtr pool, IntPtr matchmakingOptions);

		public static ulong ovr_Matchmaking_Cancel(string pool, string requestHash)
		{
			IntPtr intPtr = StringToNative(pool);
			IntPtr intPtr2 = StringToNative(requestHash);
			ulong result = ovr_Matchmaking_Cancel_Native(intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_Cancel")]
		private static extern ulong ovr_Matchmaking_Cancel_Native(IntPtr pool, IntPtr requestHash);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Matchmaking_Cancel2();

		public static ulong ovr_Matchmaking_CreateAndEnqueueRoom(string pool, uint maxUsers, bool subscribeToUpdates, IntPtr customQueryData)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_CreateAndEnqueueRoom_Native(intPtr, maxUsers, subscribeToUpdates, customQueryData);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_CreateAndEnqueueRoom")]
		private static extern ulong ovr_Matchmaking_CreateAndEnqueueRoom_Native(IntPtr pool, uint maxUsers, bool subscribeToUpdates, IntPtr customQueryData);

		public static ulong ovr_Matchmaking_CreateAndEnqueueRoom2(string pool, IntPtr matchmakingOptions)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_CreateAndEnqueueRoom2_Native(intPtr, matchmakingOptions);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_CreateAndEnqueueRoom2")]
		private static extern ulong ovr_Matchmaking_CreateAndEnqueueRoom2_Native(IntPtr pool, IntPtr matchmakingOptions);

		public static ulong ovr_Matchmaking_CreateRoom(string pool, uint maxUsers, bool subscribeToUpdates)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_CreateRoom_Native(intPtr, maxUsers, subscribeToUpdates);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_CreateRoom")]
		private static extern ulong ovr_Matchmaking_CreateRoom_Native(IntPtr pool, uint maxUsers, bool subscribeToUpdates);

		public static ulong ovr_Matchmaking_CreateRoom2(string pool, IntPtr matchmakingOptions)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_CreateRoom2_Native(intPtr, matchmakingOptions);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_CreateRoom2")]
		private static extern ulong ovr_Matchmaking_CreateRoom2_Native(IntPtr pool, IntPtr matchmakingOptions);

		public static ulong ovr_Matchmaking_Enqueue(string pool, IntPtr customQueryData)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_Enqueue_Native(intPtr, customQueryData);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_Enqueue")]
		private static extern ulong ovr_Matchmaking_Enqueue_Native(IntPtr pool, IntPtr customQueryData);

		public static ulong ovr_Matchmaking_Enqueue2(string pool, IntPtr matchmakingOptions)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_Enqueue2_Native(intPtr, matchmakingOptions);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_Enqueue2")]
		private static extern ulong ovr_Matchmaking_Enqueue2_Native(IntPtr pool, IntPtr matchmakingOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Matchmaking_EnqueueRoom(ulong roomID, IntPtr customQueryData);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Matchmaking_EnqueueRoom2(ulong roomID, IntPtr matchmakingOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Matchmaking_GetAdminSnapshot();

		public static ulong ovr_Matchmaking_GetStats(string pool, uint maxLevel, MatchmakingStatApproach approach)
		{
			IntPtr intPtr = StringToNative(pool);
			ulong result = ovr_Matchmaking_GetStats_Native(intPtr, maxLevel, approach);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_GetStats")]
		private static extern ulong ovr_Matchmaking_GetStats_Native(IntPtr pool, uint maxLevel, MatchmakingStatApproach approach);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Matchmaking_JoinRoom(ulong roomID, bool subscribeToUpdates);

		public static ulong ovr_Matchmaking_ReportResultInsecure(ulong roomID, ovrKeyValuePair[] data)
		{
			UIntPtr numItems = (UIntPtr)(ulong)data.Length;
			return ovr_Matchmaking_ReportResultInsecure_Native(roomID, data, numItems);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Matchmaking_ReportResultInsecure")]
		private static extern ulong ovr_Matchmaking_ReportResultInsecure_Native(ulong roomID, ovrKeyValuePair[] data, UIntPtr numItems);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Matchmaking_StartMatch(ulong roomID);

		public static ulong ovr_Media_ShareToFacebook(string postTextSuggestion, string filePath, MediaContentType contentType)
		{
			IntPtr intPtr = StringToNative(postTextSuggestion);
			IntPtr intPtr2 = StringToNative(filePath);
			ulong result = ovr_Media_ShareToFacebook_Native(intPtr, intPtr2, contentType);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Media_ShareToFacebook")]
		private static extern ulong ovr_Media_ShareToFacebook_Native(IntPtr postTextSuggestion, IntPtr filePath, MediaContentType contentType);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_Connect(IntPtr connect_options);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_Disconnect(long connection_id);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_GetSessions(long connection_id);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_GetVoipAttenuation(long connection_id);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_GetVoipAttenuationDefault();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_SetVoipAttenuation(long connection_id, float[] distances, float[] decibels, UIntPtr count);

		public static ulong ovr_NetSync_SetVoipAttenuationModel(long connection_id, string name, float[] distances, float[] decibels, UIntPtr count)
		{
			IntPtr intPtr = StringToNative(name);
			ulong result = ovr_NetSync_SetVoipAttenuationModel_Native(connection_id, intPtr, distances, decibels, count);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_NetSync_SetVoipAttenuationModel")]
		private static extern ulong ovr_NetSync_SetVoipAttenuationModel_Native(long connection_id, IntPtr name, float[] distances, float[] decibels, UIntPtr count);

		public static ulong ovr_NetSync_SetVoipChannelCfg(long connection_id, string channel_name, string attnmodel, bool disable_spatialization)
		{
			IntPtr intPtr = StringToNative(channel_name);
			IntPtr intPtr2 = StringToNative(attnmodel);
			ulong result = ovr_NetSync_SetVoipChannelCfg_Native(connection_id, intPtr, intPtr2, disable_spatialization);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_NetSync_SetVoipChannelCfg")]
		private static extern ulong ovr_NetSync_SetVoipChannelCfg_Native(long connection_id, IntPtr channel_name, IntPtr attnmodel, bool disable_spatialization);

		public static ulong ovr_NetSync_SetVoipGroup(long connection_id, string group_id)
		{
			IntPtr intPtr = StringToNative(group_id);
			ulong result = ovr_NetSync_SetVoipGroup_Native(connection_id, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_NetSync_SetVoipGroup")]
		private static extern ulong ovr_NetSync_SetVoipGroup_Native(long connection_id, IntPtr group_id);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_SetVoipListentoChannels(long connection_id, string[] listento_channels, UIntPtr count);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_SetVoipMicSource(long connection_id, NetSyncVoipMicSource mic_source);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_SetVoipSessionMuted(long connection_id, ulong session_id, bool muted);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_SetVoipSpeaktoChannels(long connection_id, string[] speakto_channels, UIntPtr count);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSync_SetVoipStreamMode(long connection_id, ulong sessionId, NetSyncVoipStreamMode streamMode);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Notification_GetRoomInvites();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Notification_MarkAsRead(ulong notificationID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_GatherInApplication(ulong partyID, ulong appID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_Get(ulong partyID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_GetCurrent();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_GetCurrentForUser(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_Invite(ulong partyID, ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_Join(ulong partyID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_Leave(ulong partyID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_RichPresence_Clear();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_RichPresence_GetDestinations();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_RichPresence_Set(IntPtr richPresenceOptions);

		public static ulong ovr_RichPresence_SetDestination(string api_name)
		{
			IntPtr intPtr = StringToNative(api_name);
			ulong result = ovr_RichPresence_SetDestination_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresence_SetDestination")]
		private static extern ulong ovr_RichPresence_SetDestination_Native(IntPtr api_name);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_RichPresence_SetIsJoinable(bool is_joinable);

		public static ulong ovr_RichPresence_SetLobbySession(string id)
		{
			IntPtr intPtr = StringToNative(id);
			ulong result = ovr_RichPresence_SetLobbySession_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresence_SetLobbySession")]
		private static extern ulong ovr_RichPresence_SetLobbySession_Native(IntPtr id);

		public static ulong ovr_RichPresence_SetMatchSession(string id)
		{
			IntPtr intPtr = StringToNative(id);
			ulong result = ovr_RichPresence_SetMatchSession_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresence_SetMatchSession")]
		private static extern ulong ovr_RichPresence_SetMatchSession_Native(IntPtr id);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_CreateAndJoinPrivate(RoomJoinPolicy joinPolicy, uint maxUsers, bool subscribeToUpdates);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_CreateAndJoinPrivate2(RoomJoinPolicy joinPolicy, uint maxUsers, IntPtr roomOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_Get(ulong roomID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetCurrent();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetCurrentForUser(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetInvitableUsers();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetInvitableUsers2(IntPtr roomOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetModeratedRooms();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetSocialRooms(ulong appID);

		public static ulong ovr_Room_InviteUser(ulong roomID, string inviteToken)
		{
			IntPtr intPtr = StringToNative(inviteToken);
			ulong result = ovr_Room_InviteUser_Native(roomID, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Room_InviteUser")]
		private static extern ulong ovr_Room_InviteUser_Native(ulong roomID, IntPtr inviteToken);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_Join(ulong roomID, bool subscribeToUpdates);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_Join2(ulong roomID, IntPtr roomOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_KickUser(ulong roomID, ulong userID, int kickDurationSeconds);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_LaunchInvitableUserFlow(ulong roomID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_Leave(ulong roomID);

		public static ulong ovr_Room_SetDescription(ulong roomID, string description)
		{
			IntPtr intPtr = StringToNative(description);
			ulong result = ovr_Room_SetDescription_Native(roomID, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Room_SetDescription")]
		private static extern ulong ovr_Room_SetDescription_Native(ulong roomID, IntPtr description);

		public static ulong ovr_Room_UpdateDataStore(ulong roomID, ovrKeyValuePair[] data)
		{
			UIntPtr numItems = (UIntPtr)(ulong)data.Length;
			return ovr_Room_UpdateDataStore_Native(roomID, data, numItems);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Room_UpdateDataStore")]
		private static extern ulong ovr_Room_UpdateDataStore_Native(ulong roomID, ovrKeyValuePair[] data, UIntPtr numItems);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_UpdateMembershipLockStatus(ulong roomID, RoomMembershipLockStatus membershipLockStatus);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_UpdateOwner(ulong roomID, ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_UpdatePrivateRoomJoinPolicy(ulong roomID, RoomJoinPolicy newJoinPolicy);

		public static ulong ovr_User_CancelRecordingForReportFlow(string recordingUUID)
		{
			IntPtr intPtr = StringToNative(recordingUUID);
			ulong result = ovr_User_CancelRecordingForReportFlow_Native(intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_CancelRecordingForReportFlow")]
		private static extern ulong ovr_User_CancelRecordingForReportFlow_Native(IntPtr recordingUUID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_Get(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetAccessToken();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetLinkedAccounts(IntPtr userOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetLoggedInUser();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetLoggedInUserFriends();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetLoggedInUserFriendsAndRooms();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetLoggedInUserRecentlyMetUsersAndRooms(IntPtr userOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetOrgScopedID(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetSdkAccounts();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetUserCapabilities();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetUserProof();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_LaunchBlockFlow(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_LaunchFriendRequestFlow(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_LaunchReportFlow(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_LaunchReportFlow2(ulong optionalUserID, IntPtr abuseReportOptions);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_LaunchUnblockFlow(ulong userID);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_NewEntitledTestUser();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_NewTestUser();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_NewTestUserFriends();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_StartRecordingForReportFlow();

		public static ulong ovr_User_StopRecordingAndLaunchReportFlow(ulong optionalUserID, string optionalRecordingUUID)
		{
			IntPtr intPtr = StringToNative(optionalRecordingUUID);
			ulong result = ovr_User_StopRecordingAndLaunchReportFlow_Native(optionalUserID, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_StopRecordingAndLaunchReportFlow")]
		private static extern ulong ovr_User_StopRecordingAndLaunchReportFlow_Native(ulong optionalUserID, IntPtr optionalRecordingUUID);

		public static ulong ovr_User_StopRecordingAndLaunchReportFlow2(ulong optionalUserID, string optionalRecordingUUID, IntPtr abuseReportOptions)
		{
			IntPtr intPtr = StringToNative(optionalRecordingUUID);
			ulong result = ovr_User_StopRecordingAndLaunchReportFlow2_Native(optionalUserID, intPtr, abuseReportOptions);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_StopRecordingAndLaunchReportFlow2")]
		private static extern ulong ovr_User_StopRecordingAndLaunchReportFlow2_Native(ulong optionalUserID, IntPtr optionalRecordingUUID, IntPtr abuseReportOptions);

		public static ulong ovr_User_TestUserCreateDeviceManifest(string deviceID, ulong[] appIDs, int numAppIDs)
		{
			IntPtr intPtr = StringToNative(deviceID);
			ulong result = ovr_User_TestUserCreateDeviceManifest_Native(intPtr, appIDs, numAppIDs);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_TestUserCreateDeviceManifest")]
		private static extern ulong ovr_User_TestUserCreateDeviceManifest_Native(IntPtr deviceID, ulong[] appIDs, int numAppIDs);

		public static ulong ovr_UserDataStore_PrivateDeleteEntryByKey(ulong userID, string key)
		{
			IntPtr intPtr = StringToNative(key);
			ulong result = ovr_UserDataStore_PrivateDeleteEntryByKey_Native(userID, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserDataStore_PrivateDeleteEntryByKey")]
		private static extern ulong ovr_UserDataStore_PrivateDeleteEntryByKey_Native(ulong userID, IntPtr key);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_UserDataStore_PrivateGetEntries(ulong userID);

		public static ulong ovr_UserDataStore_PrivateGetEntryByKey(ulong userID, string key)
		{
			IntPtr intPtr = StringToNative(key);
			ulong result = ovr_UserDataStore_PrivateGetEntryByKey_Native(userID, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserDataStore_PrivateGetEntryByKey")]
		private static extern ulong ovr_UserDataStore_PrivateGetEntryByKey_Native(ulong userID, IntPtr key);

		public static ulong ovr_UserDataStore_PrivateWriteEntry(ulong userID, string key, string value)
		{
			IntPtr intPtr = StringToNative(key);
			IntPtr intPtr2 = StringToNative(value);
			ulong result = ovr_UserDataStore_PrivateWriteEntry_Native(userID, intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserDataStore_PrivateWriteEntry")]
		private static extern ulong ovr_UserDataStore_PrivateWriteEntry_Native(ulong userID, IntPtr key, IntPtr value);

		public static ulong ovr_UserDataStore_PublicDeleteEntryByKey(ulong userID, string key)
		{
			IntPtr intPtr = StringToNative(key);
			ulong result = ovr_UserDataStore_PublicDeleteEntryByKey_Native(userID, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserDataStore_PublicDeleteEntryByKey")]
		private static extern ulong ovr_UserDataStore_PublicDeleteEntryByKey_Native(ulong userID, IntPtr key);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_UserDataStore_PublicGetEntries(ulong userID);

		public static ulong ovr_UserDataStore_PublicGetEntryByKey(ulong userID, string key)
		{
			IntPtr intPtr = StringToNative(key);
			ulong result = ovr_UserDataStore_PublicGetEntryByKey_Native(userID, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserDataStore_PublicGetEntryByKey")]
		private static extern ulong ovr_UserDataStore_PublicGetEntryByKey_Native(ulong userID, IntPtr key);

		public static ulong ovr_UserDataStore_PublicWriteEntry(ulong userID, string key, string value)
		{
			IntPtr intPtr = StringToNative(key);
			IntPtr intPtr2 = StringToNative(value);
			ulong result = ovr_UserDataStore_PublicWriteEntry_Native(userID, intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserDataStore_PublicWriteEntry")]
		private static extern ulong ovr_UserDataStore_PublicWriteEntry_Native(ulong userID, IntPtr key, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Voip_GetMicrophoneAvailability();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Voip_SetSystemVoipSuppressed(bool suppressed);

		public static string ovr_AbuseReportRecording_GetRecordingUuid(IntPtr obj)
		{
			return StringFromNative(ovr_AbuseReportRecording_GetRecordingUuid_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AbuseReportRecording_GetRecordingUuid")]
		private static extern IntPtr ovr_AbuseReportRecording_GetRecordingUuid_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_AchievementDefinition_GetBitfieldLength(IntPtr obj);

		public static string ovr_AchievementDefinition_GetName(IntPtr obj)
		{
			return StringFromNative(ovr_AchievementDefinition_GetName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AchievementDefinition_GetName")]
		private static extern IntPtr ovr_AchievementDefinition_GetName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AchievementDefinition_GetTarget(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern AchievementType ovr_AchievementDefinition_GetType(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_AchievementDefinitionArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_AchievementDefinitionArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_AchievementDefinitionArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AchievementDefinitionArray_GetNextUrl")]
		private static extern IntPtr ovr_AchievementDefinitionArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_AchievementDefinitionArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_AchievementDefinitionArray_HasNextPage(IntPtr obj);

		public static string ovr_AchievementProgress_GetBitfield(IntPtr obj)
		{
			return StringFromNative(ovr_AchievementProgress_GetBitfield_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AchievementProgress_GetBitfield")]
		private static extern IntPtr ovr_AchievementProgress_GetBitfield_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AchievementProgress_GetCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_AchievementProgress_GetIsUnlocked(IntPtr obj);

		public static string ovr_AchievementProgress_GetName(IntPtr obj)
		{
			return StringFromNative(ovr_AchievementProgress_GetName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AchievementProgress_GetName")]
		private static extern IntPtr ovr_AchievementProgress_GetName_Native(IntPtr obj);

		public static DateTime ovr_AchievementProgress_GetUnlockTime(IntPtr obj)
		{
			return DateTimeFromNative(ovr_AchievementProgress_GetUnlockTime_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AchievementProgress_GetUnlockTime")]
		private static extern ulong ovr_AchievementProgress_GetUnlockTime_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_AchievementProgressArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_AchievementProgressArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_AchievementProgressArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AchievementProgressArray_GetNextUrl")]
		private static extern IntPtr ovr_AchievementProgressArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_AchievementProgressArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_AchievementProgressArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_AchievementUpdate_GetJustUnlocked(IntPtr obj);

		public static string ovr_AchievementUpdate_GetName(IntPtr obj)
		{
			return StringFromNative(ovr_AchievementUpdate_GetName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AchievementUpdate_GetName")]
		private static extern IntPtr ovr_AchievementUpdate_GetName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Application_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ApplicationInvite_GetDestination(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_ApplicationInvite_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_ApplicationInvite_GetIsActive(IntPtr obj);

		public static string ovr_ApplicationInvite_GetLobbySessionId(IntPtr obj)
		{
			return StringFromNative(ovr_ApplicationInvite_GetLobbySessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationInvite_GetLobbySessionId")]
		private static extern IntPtr ovr_ApplicationInvite_GetLobbySessionId_Native(IntPtr obj);

		public static string ovr_ApplicationInvite_GetMatchSessionId(IntPtr obj)
		{
			return StringFromNative(ovr_ApplicationInvite_GetMatchSessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationInvite_GetMatchSessionId")]
		private static extern IntPtr ovr_ApplicationInvite_GetMatchSessionId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ApplicationInvite_GetRecipient(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ApplicationInviteArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_ApplicationInviteArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_ApplicationInviteArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationInviteArray_GetNextUrl")]
		private static extern IntPtr ovr_ApplicationInviteArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_ApplicationInviteArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_ApplicationInviteArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_ApplicationVersion_GetCurrentCode(IntPtr obj);

		public static string ovr_ApplicationVersion_GetCurrentName(IntPtr obj)
		{
			return StringFromNative(ovr_ApplicationVersion_GetCurrentName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationVersion_GetCurrentName")]
		private static extern IntPtr ovr_ApplicationVersion_GetCurrentName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_ApplicationVersion_GetLatestCode(IntPtr obj);

		public static string ovr_ApplicationVersion_GetLatestName(IntPtr obj)
		{
			return StringFromNative(ovr_ApplicationVersion_GetLatestName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationVersion_GetLatestName")]
		private static extern IntPtr ovr_ApplicationVersion_GetLatestName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetDetails_GetAssetId(IntPtr obj);

		public static string ovr_AssetDetails_GetAssetType(IntPtr obj)
		{
			return StringFromNative(ovr_AssetDetails_GetAssetType_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetDetails_GetAssetType")]
		private static extern IntPtr ovr_AssetDetails_GetAssetType_Native(IntPtr obj);

		public static string ovr_AssetDetails_GetDownloadStatus(IntPtr obj)
		{
			return StringFromNative(ovr_AssetDetails_GetDownloadStatus_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetDetails_GetDownloadStatus")]
		private static extern IntPtr ovr_AssetDetails_GetDownloadStatus_Native(IntPtr obj);

		public static string ovr_AssetDetails_GetFilepath(IntPtr obj)
		{
			return StringFromNative(ovr_AssetDetails_GetFilepath_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetDetails_GetFilepath")]
		private static extern IntPtr ovr_AssetDetails_GetFilepath_Native(IntPtr obj);

		public static string ovr_AssetDetails_GetIapStatus(IntPtr obj)
		{
			return StringFromNative(ovr_AssetDetails_GetIapStatus_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetDetails_GetIapStatus")]
		private static extern IntPtr ovr_AssetDetails_GetIapStatus_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_AssetDetails_GetLanguage(IntPtr obj);

		public static string ovr_AssetDetails_GetMetadata(IntPtr obj)
		{
			return StringFromNative(ovr_AssetDetails_GetMetadata_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetDetails_GetMetadata")]
		private static extern IntPtr ovr_AssetDetails_GetMetadata_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_AssetDetailsArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_AssetDetailsArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDeleteResult_GetAssetFileId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDeleteResult_GetAssetId(IntPtr obj);

		public static string ovr_AssetFileDeleteResult_GetFilepath(IntPtr obj)
		{
			return StringFromNative(ovr_AssetFileDeleteResult_GetFilepath_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetFileDeleteResult_GetFilepath")]
		private static extern IntPtr ovr_AssetFileDeleteResult_GetFilepath_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_AssetFileDeleteResult_GetSuccess(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDownloadCancelResult_GetAssetFileId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDownloadCancelResult_GetAssetId(IntPtr obj);

		public static string ovr_AssetFileDownloadCancelResult_GetFilepath(IntPtr obj)
		{
			return StringFromNative(ovr_AssetFileDownloadCancelResult_GetFilepath_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetFileDownloadCancelResult_GetFilepath")]
		private static extern IntPtr ovr_AssetFileDownloadCancelResult_GetFilepath_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_AssetFileDownloadCancelResult_GetSuccess(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDownloadResult_GetAssetId(IntPtr obj);

		public static string ovr_AssetFileDownloadResult_GetFilepath(IntPtr obj)
		{
			return StringFromNative(ovr_AssetFileDownloadResult_GetFilepath_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AssetFileDownloadResult_GetFilepath")]
		private static extern IntPtr ovr_AssetFileDownloadResult_GetFilepath_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDownloadUpdate_GetAssetFileId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDownloadUpdate_GetAssetId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_AssetFileDownloadUpdate_GetBytesTotal(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_AssetFileDownloadUpdate_GetBytesTotalLong(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_AssetFileDownloadUpdate_GetBytesTransferred(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_AssetFileDownloadUpdate_GetBytesTransferredLong(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_AssetFileDownloadUpdate_GetCompleted(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_CalApplicationFinalized_GetCountdownMS(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_CalApplicationFinalized_GetID(IntPtr obj);

		public static string ovr_CalApplicationFinalized_GetLaunchDetails(IntPtr obj)
		{
			return StringFromNative(ovr_CalApplicationFinalized_GetLaunchDetails_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CalApplicationFinalized_GetLaunchDetails")]
		private static extern IntPtr ovr_CalApplicationFinalized_GetLaunchDetails_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_CalApplicationProposed_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_CalApplicationSuggestion_GetID(IntPtr obj);

		public static string ovr_CalApplicationSuggestion_GetSocialContext(IntPtr obj)
		{
			return StringFromNative(ovr_CalApplicationSuggestion_GetSocialContext_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CalApplicationSuggestion_GetSocialContext")]
		private static extern IntPtr ovr_CalApplicationSuggestion_GetSocialContext_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_CalApplicationSuggestionArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_CalApplicationSuggestionArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ChallengeCreationType ovr_Challenge_GetCreationType(IntPtr obj);

		public static string ovr_Challenge_GetDescription(IntPtr obj)
		{
			return StringFromNative(ovr_Challenge_GetDescription_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Challenge_GetDescription")]
		private static extern IntPtr ovr_Challenge_GetDescription_Native(IntPtr obj);

		public static DateTime ovr_Challenge_GetEndDate(IntPtr obj)
		{
			return DateTimeFromNative(ovr_Challenge_GetEndDate_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Challenge_GetEndDate")]
		private static extern ulong ovr_Challenge_GetEndDate_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Challenge_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Challenge_GetInvitedUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Challenge_GetLeaderboard(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Challenge_GetParticipants(IntPtr obj);

		public static DateTime ovr_Challenge_GetStartDate(IntPtr obj)
		{
			return DateTimeFromNative(ovr_Challenge_GetStartDate_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Challenge_GetStartDate")]
		private static extern ulong ovr_Challenge_GetStartDate_Native(IntPtr obj);

		public static string ovr_Challenge_GetTitle(IntPtr obj)
		{
			return StringFromNative(ovr_Challenge_GetTitle_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Challenge_GetTitle")]
		private static extern IntPtr ovr_Challenge_GetTitle_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ChallengeVisibility ovr_Challenge_GetVisibility(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ChallengeArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_ChallengeArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_ChallengeArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeArray_GetNextUrl")]
		private static extern IntPtr ovr_ChallengeArray_GetNextUrl_Native(IntPtr obj);

		public static string ovr_ChallengeArray_GetPreviousUrl(IntPtr obj)
		{
			return StringFromNative(ovr_ChallengeArray_GetPreviousUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeArray_GetPreviousUrl")]
		private static extern IntPtr ovr_ChallengeArray_GetPreviousUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_ChallengeArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_ChallengeArray_GetTotalCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_ChallengeArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_ChallengeArray_HasPreviousPage(IntPtr obj);

		public static string ovr_ChallengeEntry_GetDisplayScore(IntPtr obj)
		{
			return StringFromNative(ovr_ChallengeEntry_GetDisplayScore_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeEntry_GetDisplayScore")]
		private static extern IntPtr ovr_ChallengeEntry_GetDisplayScore_Native(IntPtr obj);

		public static byte[] ovr_ChallengeEntry_GetExtraData(IntPtr obj)
		{
			return BlobFromNative(ovr_LeaderboardEntry_GetExtraDataLength(obj), ovr_ChallengeEntry_GetExtraData_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeEntry_GetExtraData")]
		private static extern IntPtr ovr_ChallengeEntry_GetExtraData_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_ChallengeEntry_GetExtraDataLength(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_ChallengeEntry_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_ChallengeEntry_GetRank(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_ChallengeEntry_GetScore(IntPtr obj);

		public static DateTime ovr_ChallengeEntry_GetTimestamp(IntPtr obj)
		{
			return DateTimeFromNative(ovr_ChallengeEntry_GetTimestamp_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeEntry_GetTimestamp")]
		private static extern ulong ovr_ChallengeEntry_GetTimestamp_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ChallengeEntry_GetUser(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ChallengeEntryArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_ChallengeEntryArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_ChallengeEntryArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeEntryArray_GetNextUrl")]
		private static extern IntPtr ovr_ChallengeEntryArray_GetNextUrl_Native(IntPtr obj);

		public static string ovr_ChallengeEntryArray_GetPreviousUrl(IntPtr obj)
		{
			return StringFromNative(ovr_ChallengeEntryArray_GetPreviousUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeEntryArray_GetPreviousUrl")]
		private static extern IntPtr ovr_ChallengeEntryArray_GetPreviousUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_ChallengeEntryArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_ChallengeEntryArray_GetTotalCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_ChallengeEntryArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_ChallengeEntryArray_HasPreviousPage(IntPtr obj);

		public static string ovr_CloudStorage2UserDirectoryPathResponse_GetPath(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorage2UserDirectoryPathResponse_GetPath_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorage2UserDirectoryPathResponse_GetPath")]
		private static extern IntPtr ovr_CloudStorage2UserDirectoryPathResponse_GetPath_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_CloudStorageConflictMetadata_GetLocal(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_CloudStorageConflictMetadata_GetRemote(IntPtr obj);

		public static string ovr_CloudStorageData_GetBucket(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageData_GetBucket_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageData_GetBucket")]
		private static extern IntPtr ovr_CloudStorageData_GetBucket_Native(IntPtr obj);

		public static byte[] ovr_CloudStorageData_GetData(IntPtr obj)
		{
			return FiledataFromNative(ovr_CloudStorageData_GetDataSize(obj), ovr_CloudStorageData_GetData_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageData_GetData")]
		private static extern IntPtr ovr_CloudStorageData_GetData_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_CloudStorageData_GetDataSize(IntPtr obj);

		public static string ovr_CloudStorageData_GetKey(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageData_GetKey_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageData_GetKey")]
		private static extern IntPtr ovr_CloudStorageData_GetKey_Native(IntPtr obj);

		public static string ovr_CloudStorageMetadata_GetBucket(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageMetadata_GetBucket_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageMetadata_GetBucket")]
		private static extern IntPtr ovr_CloudStorageMetadata_GetBucket_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_CloudStorageMetadata_GetCounter(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_CloudStorageMetadata_GetDataSize(IntPtr obj);

		public static string ovr_CloudStorageMetadata_GetExtraData(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageMetadata_GetExtraData_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageMetadata_GetExtraData")]
		private static extern IntPtr ovr_CloudStorageMetadata_GetExtraData_Native(IntPtr obj);

		public static string ovr_CloudStorageMetadata_GetKey(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageMetadata_GetKey_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageMetadata_GetKey")]
		private static extern IntPtr ovr_CloudStorageMetadata_GetKey_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_CloudStorageMetadata_GetSaveTime(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern CloudStorageDataStatus ovr_CloudStorageMetadata_GetStatus(IntPtr obj);

		public static string ovr_CloudStorageMetadata_GetVersionHandle(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageMetadata_GetVersionHandle_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageMetadata_GetVersionHandle")]
		private static extern IntPtr ovr_CloudStorageMetadata_GetVersionHandle_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_CloudStorageMetadataArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_CloudStorageMetadataArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageMetadataArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageMetadataArray_GetNextUrl")]
		private static extern IntPtr ovr_CloudStorageMetadataArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_CloudStorageMetadataArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_CloudStorageMetadataArray_HasNextPage(IntPtr obj);

		public static string ovr_CloudStorageUpdateResponse_GetBucket(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageUpdateResponse_GetBucket_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageUpdateResponse_GetBucket")]
		private static extern IntPtr ovr_CloudStorageUpdateResponse_GetBucket_Native(IntPtr obj);

		public static string ovr_CloudStorageUpdateResponse_GetKey(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageUpdateResponse_GetKey_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageUpdateResponse_GetKey")]
		private static extern IntPtr ovr_CloudStorageUpdateResponse_GetKey_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern CloudStorageUpdateStatus ovr_CloudStorageUpdateResponse_GetStatus(IntPtr obj);

		public static string ovr_CloudStorageUpdateResponse_GetVersionHandle(IntPtr obj)
		{
			return StringFromNative(ovr_CloudStorageUpdateResponse_GetVersionHandle_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_CloudStorageUpdateResponse_GetVersionHandle")]
		private static extern IntPtr ovr_CloudStorageUpdateResponse_GetVersionHandle_Native(IntPtr obj);

		public static uint ovr_DataStore_Contains(IntPtr obj, string key)
		{
			IntPtr intPtr = StringToNative(key);
			uint result = ovr_DataStore_Contains_Native(obj, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_DataStore_Contains")]
		private static extern uint ovr_DataStore_Contains_Native(IntPtr obj, IntPtr key);

		public static string ovr_DataStore_GetKey(IntPtr obj, int index)
		{
			return StringFromNative(ovr_DataStore_GetKey_Native(obj, index));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_DataStore_GetKey")]
		private static extern IntPtr ovr_DataStore_GetKey_Native(IntPtr obj, int index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_DataStore_GetNumKeys(IntPtr obj);

		public static string ovr_DataStore_GetValue(IntPtr obj, string key)
		{
			IntPtr intPtr = StringToNative(key);
			string result = StringFromNative(ovr_DataStore_GetValue_Native(obj, intPtr));
			Marshal.FreeCoTaskMem(intPtr);
			return result;
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_DataStore_GetValue")]
		private static extern IntPtr ovr_DataStore_GetValue_Native(IntPtr obj, IntPtr key);

		public static string ovr_Destination_GetApiName(IntPtr obj)
		{
			return StringFromNative(ovr_Destination_GetApiName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Destination_GetApiName")]
		private static extern IntPtr ovr_Destination_GetApiName_Native(IntPtr obj);

		public static string ovr_Destination_GetDeeplinkMessage(IntPtr obj)
		{
			return StringFromNative(ovr_Destination_GetDeeplinkMessage_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Destination_GetDeeplinkMessage")]
		private static extern IntPtr ovr_Destination_GetDeeplinkMessage_Native(IntPtr obj);

		public static string ovr_Destination_GetDisplayName(IntPtr obj)
		{
			return StringFromNative(ovr_Destination_GetDisplayName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Destination_GetDisplayName")]
		private static extern IntPtr ovr_Destination_GetDisplayName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_DestinationArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_DestinationArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_DestinationArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_DestinationArray_GetNextUrl")]
		private static extern IntPtr ovr_DestinationArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_DestinationArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_DestinationArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_Error_GetCode(IntPtr obj);

		public static string ovr_Error_GetDisplayableMessage(IntPtr obj)
		{
			return StringFromNative(ovr_Error_GetDisplayableMessage_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Error_GetDisplayableMessage")]
		private static extern IntPtr ovr_Error_GetDisplayableMessage_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_Error_GetHttpCode(IntPtr obj);

		public static string ovr_Error_GetMessage(IntPtr obj)
		{
			return StringFromNative(ovr_Error_GetMessage_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Error_GetMessage")]
		private static extern IntPtr ovr_Error_GetMessage_Native(IntPtr obj);

		public static string ovr_GroupPresenceJoinIntent_GetDeeplinkMessage(IntPtr obj)
		{
			return StringFromNative(ovr_GroupPresenceJoinIntent_GetDeeplinkMessage_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceJoinIntent_GetDeeplinkMessage")]
		private static extern IntPtr ovr_GroupPresenceJoinIntent_GetDeeplinkMessage_Native(IntPtr obj);

		public static string ovr_GroupPresenceJoinIntent_GetDestinationApiName(IntPtr obj)
		{
			return StringFromNative(ovr_GroupPresenceJoinIntent_GetDestinationApiName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceJoinIntent_GetDestinationApiName")]
		private static extern IntPtr ovr_GroupPresenceJoinIntent_GetDestinationApiName_Native(IntPtr obj);

		public static string ovr_GroupPresenceJoinIntent_GetLobbySessionId(IntPtr obj)
		{
			return StringFromNative(ovr_GroupPresenceJoinIntent_GetLobbySessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceJoinIntent_GetLobbySessionId")]
		private static extern IntPtr ovr_GroupPresenceJoinIntent_GetLobbySessionId_Native(IntPtr obj);

		public static string ovr_GroupPresenceJoinIntent_GetMatchSessionId(IntPtr obj)
		{
			return StringFromNative(ovr_GroupPresenceJoinIntent_GetMatchSessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceJoinIntent_GetMatchSessionId")]
		private static extern IntPtr ovr_GroupPresenceJoinIntent_GetMatchSessionId_Native(IntPtr obj);

		public static string ovr_GroupPresenceLeaveIntent_GetDestinationApiName(IntPtr obj)
		{
			return StringFromNative(ovr_GroupPresenceLeaveIntent_GetDestinationApiName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceLeaveIntent_GetDestinationApiName")]
		private static extern IntPtr ovr_GroupPresenceLeaveIntent_GetDestinationApiName_Native(IntPtr obj);

		public static string ovr_GroupPresenceLeaveIntent_GetLobbySessionId(IntPtr obj)
		{
			return StringFromNative(ovr_GroupPresenceLeaveIntent_GetLobbySessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceLeaveIntent_GetLobbySessionId")]
		private static extern IntPtr ovr_GroupPresenceLeaveIntent_GetLobbySessionId_Native(IntPtr obj);

		public static string ovr_GroupPresenceLeaveIntent_GetMatchSessionId(IntPtr obj)
		{
			return StringFromNative(ovr_GroupPresenceLeaveIntent_GetMatchSessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceLeaveIntent_GetMatchSessionId")]
		private static extern IntPtr ovr_GroupPresenceLeaveIntent_GetMatchSessionId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_HttpTransferUpdate_GetBytes(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_HttpTransferUpdate_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_HttpTransferUpdate_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_HttpTransferUpdate_IsCompleted(IntPtr obj);

		public static string ovr_InstalledApplication_GetApplicationId(IntPtr obj)
		{
			return StringFromNative(ovr_InstalledApplication_GetApplicationId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_InstalledApplication_GetApplicationId")]
		private static extern IntPtr ovr_InstalledApplication_GetApplicationId_Native(IntPtr obj);

		public static string ovr_InstalledApplication_GetPackageName(IntPtr obj)
		{
			return StringFromNative(ovr_InstalledApplication_GetPackageName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_InstalledApplication_GetPackageName")]
		private static extern IntPtr ovr_InstalledApplication_GetPackageName_Native(IntPtr obj);

		public static string ovr_InstalledApplication_GetStatus(IntPtr obj)
		{
			return StringFromNative(ovr_InstalledApplication_GetStatus_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_InstalledApplication_GetStatus")]
		private static extern IntPtr ovr_InstalledApplication_GetStatus_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_InstalledApplication_GetVersionCode(IntPtr obj);

		public static string ovr_InstalledApplication_GetVersionName(IntPtr obj)
		{
			return StringFromNative(ovr_InstalledApplication_GetVersionName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_InstalledApplication_GetVersionName")]
		private static extern IntPtr ovr_InstalledApplication_GetVersionName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_InstalledApplicationArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_InstalledApplicationArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_InvitePanelResultInfo_GetInvitesSent(IntPtr obj);

		public static string ovr_LanguagePackInfo_GetEnglishName(IntPtr obj)
		{
			return StringFromNative(ovr_LanguagePackInfo_GetEnglishName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LanguagePackInfo_GetEnglishName")]
		private static extern IntPtr ovr_LanguagePackInfo_GetEnglishName_Native(IntPtr obj);

		public static string ovr_LanguagePackInfo_GetNativeName(IntPtr obj)
		{
			return StringFromNative(ovr_LanguagePackInfo_GetNativeName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LanguagePackInfo_GetNativeName")]
		private static extern IntPtr ovr_LanguagePackInfo_GetNativeName_Native(IntPtr obj);

		public static string ovr_LanguagePackInfo_GetTag(IntPtr obj)
		{
			return StringFromNative(ovr_LanguagePackInfo_GetTag_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LanguagePackInfo_GetTag")]
		private static extern IntPtr ovr_LanguagePackInfo_GetTag_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LaunchBlockFlowResult_GetDidBlock(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LaunchBlockFlowResult_GetDidCancel(IntPtr obj);

		public static string ovr_LaunchDetails_GetDeeplinkMessage(IntPtr obj)
		{
			return StringFromNative(ovr_LaunchDetails_GetDeeplinkMessage_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LaunchDetails_GetDeeplinkMessage")]
		private static extern IntPtr ovr_LaunchDetails_GetDeeplinkMessage_Native(IntPtr obj);

		public static string ovr_LaunchDetails_GetDestinationApiName(IntPtr obj)
		{
			return StringFromNative(ovr_LaunchDetails_GetDestinationApiName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LaunchDetails_GetDestinationApiName")]
		private static extern IntPtr ovr_LaunchDetails_GetDestinationApiName_Native(IntPtr obj);

		public static string ovr_LaunchDetails_GetLaunchSource(IntPtr obj)
		{
			return StringFromNative(ovr_LaunchDetails_GetLaunchSource_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LaunchDetails_GetLaunchSource")]
		private static extern IntPtr ovr_LaunchDetails_GetLaunchSource_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern LaunchType ovr_LaunchDetails_GetLaunchType(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_LaunchDetails_GetRoomID(IntPtr obj);

		public static string ovr_LaunchDetails_GetTrackingID(IntPtr obj)
		{
			return StringFromNative(ovr_LaunchDetails_GetTrackingID_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LaunchDetails_GetTrackingID")]
		private static extern IntPtr ovr_LaunchDetails_GetTrackingID_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_LaunchDetails_GetUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LaunchFriendRequestFlowResult_GetDidCancel(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LaunchFriendRequestFlowResult_GetDidSendRequest(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_LaunchInvitePanelFlowResult_GetInvitedUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LaunchReportFlowResult_GetDidCancel(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_LaunchReportFlowResult_GetUserReportId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LaunchUnblockFlowResult_GetDidCancel(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LaunchUnblockFlowResult_GetDidUnblock(IntPtr obj);

		public static string ovr_Leaderboard_GetApiName(IntPtr obj)
		{
			return StringFromNative(ovr_Leaderboard_GetApiName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Leaderboard_GetApiName")]
		private static extern IntPtr ovr_Leaderboard_GetApiName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Leaderboard_GetDestination(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Leaderboard_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_LeaderboardArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_LeaderboardArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_LeaderboardArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LeaderboardArray_GetNextUrl")]
		private static extern IntPtr ovr_LeaderboardArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_LeaderboardArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LeaderboardArray_HasNextPage(IntPtr obj);

		public static string ovr_LeaderboardEntry_GetDisplayScore(IntPtr obj)
		{
			return StringFromNative(ovr_LeaderboardEntry_GetDisplayScore_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LeaderboardEntry_GetDisplayScore")]
		private static extern IntPtr ovr_LeaderboardEntry_GetDisplayScore_Native(IntPtr obj);

		public static byte[] ovr_LeaderboardEntry_GetExtraData(IntPtr obj)
		{
			return BlobFromNative(ovr_LeaderboardEntry_GetExtraDataLength(obj), ovr_LeaderboardEntry_GetExtraData_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LeaderboardEntry_GetExtraData")]
		private static extern IntPtr ovr_LeaderboardEntry_GetExtraData_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_LeaderboardEntry_GetExtraDataLength(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_LeaderboardEntry_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_LeaderboardEntry_GetRank(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_LeaderboardEntry_GetScore(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_LeaderboardEntry_GetSupplementaryMetric(IntPtr obj);

		public static DateTime ovr_LeaderboardEntry_GetTimestamp(IntPtr obj)
		{
			return DateTimeFromNative(ovr_LeaderboardEntry_GetTimestamp_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LeaderboardEntry_GetTimestamp")]
		private static extern ulong ovr_LeaderboardEntry_GetTimestamp_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_LeaderboardEntry_GetUser(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_LeaderboardEntryArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_LeaderboardEntryArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_LeaderboardEntryArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LeaderboardEntryArray_GetNextUrl")]
		private static extern IntPtr ovr_LeaderboardEntryArray_GetNextUrl_Native(IntPtr obj);

		public static string ovr_LeaderboardEntryArray_GetPreviousUrl(IntPtr obj)
		{
			return StringFromNative(ovr_LeaderboardEntryArray_GetPreviousUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LeaderboardEntryArray_GetPreviousUrl")]
		private static extern IntPtr ovr_LeaderboardEntryArray_GetPreviousUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_LeaderboardEntryArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_LeaderboardEntryArray_GetTotalCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LeaderboardEntryArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LeaderboardEntryArray_HasPreviousPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LeaderboardUpdateStatus_GetDidUpdate(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_LeaderboardUpdateStatus_GetUpdatedChallengeId(IntPtr obj, uint index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_LeaderboardUpdateStatus_GetUpdatedChallengeIdsSize(IntPtr obj);

		public static string ovr_LinkedAccount_GetAccessToken(IntPtr obj)
		{
			return StringFromNative(ovr_LinkedAccount_GetAccessToken_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LinkedAccount_GetAccessToken")]
		private static extern IntPtr ovr_LinkedAccount_GetAccessToken_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ServiceProvider ovr_LinkedAccount_GetServiceProvider(IntPtr obj);

		public static string ovr_LinkedAccount_GetUserId(IntPtr obj)
		{
			return StringFromNative(ovr_LinkedAccount_GetUserId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LinkedAccount_GetUserId")]
		private static extern IntPtr ovr_LinkedAccount_GetUserId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_LinkedAccountArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_LinkedAccountArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LivestreamingApplicationStatus_GetStreamingEnabled(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern LivestreamingStartStatus ovr_LivestreamingStartResult_GetStreamingResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LivestreamingStatus_GetCommentsVisible(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LivestreamingStatus_GetIsPaused(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LivestreamingStatus_GetLivestreamingEnabled(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_LivestreamingStatus_GetLivestreamingType(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_LivestreamingStatus_GetMicEnabled(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_LivestreamingVideoStats_GetCommentCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_LivestreamingVideoStats_GetReactionCount(IntPtr obj);

		public static string ovr_LivestreamingVideoStats_GetTotalViews(IntPtr obj)
		{
			return StringFromNative(ovr_LivestreamingVideoStats_GetTotalViews_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_LivestreamingVideoStats_GetTotalViews")]
		private static extern IntPtr ovr_LivestreamingVideoStats_GetTotalViews_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingAdminSnapshot_GetCandidates(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern double ovr_MatchmakingAdminSnapshot_GetMyCurrentThreshold(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_MatchmakingAdminSnapshotCandidate_GetCanMatch(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern double ovr_MatchmakingAdminSnapshotCandidate_GetMyTotalScore(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern double ovr_MatchmakingAdminSnapshotCandidate_GetTheirCurrentThreshold(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern double ovr_MatchmakingAdminSnapshotCandidate_GetTheirTotalScore(IntPtr obj);

		public static string ovr_MatchmakingAdminSnapshotCandidate_GetTraceId(IntPtr obj)
		{
			return StringFromNative(ovr_MatchmakingAdminSnapshotCandidate_GetTraceId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingAdminSnapshotCandidate_GetTraceId")]
		private static extern IntPtr ovr_MatchmakingAdminSnapshotCandidate_GetTraceId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingAdminSnapshotCandidateArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_MatchmakingAdminSnapshotCandidateArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingBrowseResult_GetEnqueueResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingBrowseResult_GetRooms(IntPtr obj);

		public static string ovr_MatchmakingCandidate_GetEntryHash(IntPtr obj)
		{
			return StringFromNative(ovr_MatchmakingCandidate_GetEntryHash_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingCandidate_GetEntryHash")]
		private static extern IntPtr ovr_MatchmakingCandidate_GetEntryHash_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_MatchmakingCandidate_GetUserId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingCandidateArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_MatchmakingCandidateArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_MatchmakingCandidateArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingCandidateArray_GetNextUrl")]
		private static extern IntPtr ovr_MatchmakingCandidateArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_MatchmakingCandidateArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_MatchmakingCandidateArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingEnqueueResult_GetAdminSnapshot(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingEnqueueResult_GetAverageWait(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingEnqueueResult_GetMatchesInLastHourCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingEnqueueResult_GetMaxExpectedWait(IntPtr obj);

		public static string ovr_MatchmakingEnqueueResult_GetPool(IntPtr obj)
		{
			return StringFromNative(ovr_MatchmakingEnqueueResult_GetPool_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingEnqueueResult_GetPool")]
		private static extern IntPtr ovr_MatchmakingEnqueueResult_GetPool_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingEnqueueResult_GetRecentMatchPercentage(IntPtr obj);

		public static string ovr_MatchmakingEnqueueResult_GetRequestHash(IntPtr obj)
		{
			return StringFromNative(ovr_MatchmakingEnqueueResult_GetRequestHash_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingEnqueueResult_GetRequestHash")]
		private static extern IntPtr ovr_MatchmakingEnqueueResult_GetRequestHash_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingEnqueueResultAndRoom_GetMatchmakingEnqueueResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingEnqueueResultAndRoom_GetRoom(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_MatchmakingEnqueuedUser_GetAdditionalUserID(IntPtr obj, uint index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingEnqueuedUser_GetAdditionalUserIDsSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingEnqueuedUser_GetCustomData(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingEnqueuedUser_GetUser(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingEnqueuedUserArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_MatchmakingEnqueuedUserArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_MatchmakingNotification_GetAddedByUserId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingNotification_GetRoom(IntPtr obj);

		public static string ovr_MatchmakingNotification_GetTraceId(IntPtr obj)
		{
			return StringFromNative(ovr_MatchmakingNotification_GetTraceId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingNotification_GetTraceId")]
		private static extern IntPtr ovr_MatchmakingNotification_GetTraceId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingRoom_GetPingTime(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingRoom_GetRoom(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_MatchmakingRoom_HasPingTime(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingRoomArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_MatchmakingRoomArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingStats_GetDrawCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingStats_GetLossCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingStats_GetSkillLevel(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern double ovr_MatchmakingStats_GetSkillMean(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern double ovr_MatchmakingStats_GetSkillStandardDeviation(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_MatchmakingStats_GetWinCount(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAbuseReportRecording(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAchievementDefinitionArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAchievementProgressArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAchievementUpdate(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetApplicationInviteArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetApplicationVersion(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAssetDetails(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAssetDetailsArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAssetFileDeleteResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAssetFileDownloadCancelResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAssetFileDownloadResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetAssetFileDownloadUpdate(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCalApplicationFinalized(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCalApplicationProposed(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCalApplicationSuggestionArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetChallenge(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetChallengeArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetChallengeEntryArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCloudStorageConflictMetadata(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCloudStorageData(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCloudStorageMetadata(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCloudStorageMetadataArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetCloudStorageUpdateResponse(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetDataStore(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetDestinationArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetError(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetGroupPresenceJoinIntent(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetGroupPresenceLeaveIntent(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetHttpTransferUpdate(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetInstalledApplicationArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetInvitePanelResultInfo(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLaunchBlockFlowResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLaunchFriendRequestFlowResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLaunchInvitePanelFlowResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLaunchReportFlowResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLaunchUnblockFlowResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLeaderboardArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLeaderboardEntryArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLeaderboardUpdateStatus(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLinkedAccountArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLivestreamingApplicationStatus(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLivestreamingStartResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLivestreamingStatus(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetLivestreamingVideoStats(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetMatchmakingAdminSnapshot(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetMatchmakingBrowseResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetMatchmakingEnqueueResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetMatchmakingEnqueueResultAndRoom(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetMatchmakingRoomArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetMatchmakingStats(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetMicrophoneAvailabilityState(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetNativeMessage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetNetSyncConnection(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetNetSyncSessionArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetNetSyncSessionsChangedNotification(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetNetSyncSetSessionPropertyResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetNetSyncVoipAttenuationValueArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetNetworkingPeer(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetOrgScopedID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetParty(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetPartyID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetPartyUpdateNotification(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetPidArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetPingResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetPlatformInitialize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetProductArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetPurchase(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetPurchaseArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetRejoinDialogResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Message_GetRequestID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetRoom(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetRoomArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetRoomInviteNotification(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetRoomInviteNotificationArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetSdkAccountArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetSendInvitesResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetShareMediaResult(IntPtr obj);

		public static string ovr_Message_GetString(IntPtr obj)
		{
			return StringFromNative(ovr_Message_GetString_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Message_GetString")]
		private static extern IntPtr ovr_Message_GetString_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetSystemVoipState(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern Message.MessageType ovr_Message_GetType(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetUser(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetUserAndRoomArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetUserArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetUserCapabilityArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetUserDataStoreUpdateResponse(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetUserProof(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Message_GetUserReportID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_Message_IsError(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Microphone_GetNumSamplesAvailable(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Microphone_GetOutputBufferMaxSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Microphone_GetPCM(IntPtr obj, short[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Microphone_GetPCMFloat(IntPtr obj, float[] outputBuffer, UIntPtr outputBufferNumElements);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Microphone_ReadData(IntPtr obj, float[] outputBuffer, UIntPtr outputBufferSize);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Microphone_SetAcceptableRecordingDelayHint(IntPtr obj, UIntPtr delayMs);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Microphone_Start(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Microphone_Stop(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_MicrophoneAvailabilityState_GetMicrophoneAvailable(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_NetSyncConnection_GetConnectionId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern NetSyncDisconnectReason ovr_NetSyncConnection_GetDisconnectReason(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSyncConnection_GetSessionId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern NetSyncConnectionStatus ovr_NetSyncConnection_GetStatus(IntPtr obj);

		public static string ovr_NetSyncConnection_GetZoneId(IntPtr obj)
		{
			return StringFromNative(ovr_NetSyncConnection_GetZoneId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_NetSyncConnection_GetZoneId")]
		private static extern IntPtr ovr_NetSyncConnection_GetZoneId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_NetSyncSession_GetConnectionId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_NetSyncSession_GetMuted(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSyncSession_GetSessionId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetSyncSession_GetUserId(IntPtr obj);

		public static string ovr_NetSyncSession_GetVoipGroup(IntPtr obj)
		{
			return StringFromNative(ovr_NetSyncSession_GetVoipGroup_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_NetSyncSession_GetVoipGroup")]
		private static extern IntPtr ovr_NetSyncSession_GetVoipGroup_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_NetSyncSessionArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSyncSessionArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_NetSyncSessionsChangedNotification_GetConnectionId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_NetSyncSessionsChangedNotification_GetSessions(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_NetSyncSetSessionPropertyResult_GetSession(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovr_NetSyncVoipAttenuationValue_GetDecibels(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ovr_NetSyncVoipAttenuationValue_GetDistance(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_NetSyncVoipAttenuationValueArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_NetSyncVoipAttenuationValueArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_NetworkingPeer_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern PeerConnectionState ovr_NetworkingPeer_GetState(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_OrgScopedID_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_Packet_Free(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Packet_GetBytes(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern SendPolicy ovr_Packet_GetSendPolicy(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Packet_GetSenderID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_Packet_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Party_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Party_GetInvitedUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Party_GetLeader(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Party_GetRoom(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Party_GetUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_PartyID_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern PartyUpdateAction ovr_PartyUpdateNotification_GetAction(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_PartyUpdateNotification_GetPartyId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_PartyUpdateNotification_GetSenderId(IntPtr obj);

		public static string ovr_PartyUpdateNotification_GetUpdateTimestamp(IntPtr obj)
		{
			return StringFromNative(ovr_PartyUpdateNotification_GetUpdateTimestamp_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_PartyUpdateNotification_GetUpdateTimestamp")]
		private static extern IntPtr ovr_PartyUpdateNotification_GetUpdateTimestamp_Native(IntPtr obj);

		public static string ovr_PartyUpdateNotification_GetUserAlias(IntPtr obj)
		{
			return StringFromNative(ovr_PartyUpdateNotification_GetUserAlias_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_PartyUpdateNotification_GetUserAlias")]
		private static extern IntPtr ovr_PartyUpdateNotification_GetUserAlias_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_PartyUpdateNotification_GetUserId(IntPtr obj);

		public static string ovr_PartyUpdateNotification_GetUserName(IntPtr obj)
		{
			return StringFromNative(ovr_PartyUpdateNotification_GetUserName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_PartyUpdateNotification_GetUserName")]
		private static extern IntPtr ovr_PartyUpdateNotification_GetUserName_Native(IntPtr obj);

		public static string ovr_Pid_GetId(IntPtr obj)
		{
			return StringFromNative(ovr_Pid_GetId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Pid_GetId")]
		private static extern IntPtr ovr_Pid_GetId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_PidArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_PidArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_PingResult_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_PingResult_GetPingTimeUsec(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_PingResult_IsTimeout(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern PlatformInitializeResult ovr_PlatformInitialize_GetResult(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_Price_GetAmountInHundredths(IntPtr obj);

		public static string ovr_Price_GetCurrency(IntPtr obj)
		{
			return StringFromNative(ovr_Price_GetCurrency_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Price_GetCurrency")]
		private static extern IntPtr ovr_Price_GetCurrency_Native(IntPtr obj);

		public static string ovr_Price_GetFormatted(IntPtr obj)
		{
			return StringFromNative(ovr_Price_GetFormatted_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Price_GetFormatted")]
		private static extern IntPtr ovr_Price_GetFormatted_Native(IntPtr obj);

		public static string ovr_Product_GetDescription(IntPtr obj)
		{
			return StringFromNative(ovr_Product_GetDescription_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Product_GetDescription")]
		private static extern IntPtr ovr_Product_GetDescription_Native(IntPtr obj);

		public static string ovr_Product_GetFormattedPrice(IntPtr obj)
		{
			return StringFromNative(ovr_Product_GetFormattedPrice_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Product_GetFormattedPrice")]
		private static extern IntPtr ovr_Product_GetFormattedPrice_Native(IntPtr obj);

		public static string ovr_Product_GetName(IntPtr obj)
		{
			return StringFromNative(ovr_Product_GetName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Product_GetName")]
		private static extern IntPtr ovr_Product_GetName_Native(IntPtr obj);

		public static string ovr_Product_GetSKU(IntPtr obj)
		{
			return StringFromNative(ovr_Product_GetSKU_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Product_GetSKU")]
		private static extern IntPtr ovr_Product_GetSKU_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ProductArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_ProductArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_ProductArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ProductArray_GetNextUrl")]
		private static extern IntPtr ovr_ProductArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_ProductArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_ProductArray_HasNextPage(IntPtr obj);

		public static DateTime ovr_Purchase_GetExpirationTime(IntPtr obj)
		{
			return DateTimeFromNative(ovr_Purchase_GetExpirationTime_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Purchase_GetExpirationTime")]
		private static extern ulong ovr_Purchase_GetExpirationTime_Native(IntPtr obj);

		public static DateTime ovr_Purchase_GetGrantTime(IntPtr obj)
		{
			return DateTimeFromNative(ovr_Purchase_GetGrantTime_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Purchase_GetGrantTime")]
		private static extern ulong ovr_Purchase_GetGrantTime_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Purchase_GetPurchaseID(IntPtr obj);

		public static string ovr_Purchase_GetPurchaseStrID(IntPtr obj)
		{
			return StringFromNative(ovr_Purchase_GetPurchaseStrID_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Purchase_GetPurchaseStrID")]
		private static extern IntPtr ovr_Purchase_GetPurchaseStrID_Native(IntPtr obj);

		public static string ovr_Purchase_GetSKU(IntPtr obj)
		{
			return StringFromNative(ovr_Purchase_GetSKU_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Purchase_GetSKU")]
		private static extern IntPtr ovr_Purchase_GetSKU_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_PurchaseArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_PurchaseArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_PurchaseArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_PurchaseArray_GetNextUrl")]
		private static extern IntPtr ovr_PurchaseArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_PurchaseArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_PurchaseArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_RejoinDialogResult_GetRejoinSelected(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetApplicationID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Room_GetDataStore(IntPtr obj);

		public static string ovr_Room_GetDescription(IntPtr obj)
		{
			return StringFromNative(ovr_Room_GetDescription_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Room_GetDescription")]
		private static extern IntPtr ovr_Room_GetDescription_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_Room_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Room_GetInvitedUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_Room_GetIsMembershipLocked(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern RoomJoinPolicy ovr_Room_GetJoinPolicy(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern RoomJoinability ovr_Room_GetJoinability(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Room_GetMatchedUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_Room_GetMaxUsers(IntPtr obj);

		public static string ovr_Room_GetName(IntPtr obj)
		{
			return StringFromNative(ovr_Room_GetName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Room_GetName")]
		private static extern IntPtr ovr_Room_GetName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Room_GetOwner(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Room_GetTeams(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern RoomType ovr_Room_GetType(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Room_GetUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ovr_Room_GetVersion(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_RoomArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_RoomArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_RoomArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RoomArray_GetNextUrl")]
		private static extern IntPtr ovr_RoomArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_RoomArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_RoomArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_RoomInviteNotification_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_RoomInviteNotification_GetRoomID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_RoomInviteNotification_GetSenderID(IntPtr obj);

		public static DateTime ovr_RoomInviteNotification_GetSentTime(IntPtr obj)
		{
			return DateTimeFromNative(ovr_RoomInviteNotification_GetSentTime_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RoomInviteNotification_GetSentTime")]
		private static extern ulong ovr_RoomInviteNotification_GetSentTime_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_RoomInviteNotificationArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_RoomInviteNotificationArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_RoomInviteNotificationArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RoomInviteNotificationArray_GetNextUrl")]
		private static extern IntPtr ovr_RoomInviteNotificationArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_RoomInviteNotificationArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_RoomInviteNotificationArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern SdkAccountType ovr_SdkAccount_GetAccountType(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_SdkAccount_GetUserId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_SdkAccountArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_SdkAccountArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_SendInvitesResult_GetInvites(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ShareMediaStatus ovr_ShareMediaResult_GetStatus(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_SupplementaryMetric_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ovr_SupplementaryMetric_GetMetric(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern VoipMuteState ovr_SystemVoipState_GetMicrophoneMuted(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern SystemVoipStatus ovr_SystemVoipState_GetStatus(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_Team_GetAssignedUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_Team_GetMaxUsers(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ovr_Team_GetMinUsers(IntPtr obj);

		public static string ovr_Team_GetName(IntPtr obj)
		{
			return StringFromNative(ovr_Team_GetName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_Team_GetName")]
		private static extern IntPtr ovr_Team_GetName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_TeamArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_TeamArray_GetSize(IntPtr obj);

		public static string ovr_TestUser_GetAccessToken(IntPtr obj)
		{
			return StringFromNative(ovr_TestUser_GetAccessToken_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_TestUser_GetAccessToken")]
		private static extern IntPtr ovr_TestUser_GetAccessToken_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_TestUser_GetAppAccessArray(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_TestUser_GetFbAppAccessArray(IntPtr obj);

		public static string ovr_TestUser_GetFriendAccessToken(IntPtr obj)
		{
			return StringFromNative(ovr_TestUser_GetFriendAccessToken_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_TestUser_GetFriendAccessToken")]
		private static extern IntPtr ovr_TestUser_GetFriendAccessToken_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_TestUser_GetFriendAppAccessArray(IntPtr obj);

		public static string ovr_TestUser_GetUserAlias(IntPtr obj)
		{
			return StringFromNative(ovr_TestUser_GetUserAlias_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_TestUser_GetUserAlias")]
		private static extern IntPtr ovr_TestUser_GetUserAlias_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_TestUser_GetUserFbid(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_TestUser_GetUserId(IntPtr obj);

		public static string ovr_TestUserAppAccess_GetAccessToken(IntPtr obj)
		{
			return StringFromNative(ovr_TestUserAppAccess_GetAccessToken_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_TestUserAppAccess_GetAccessToken")]
		private static extern IntPtr ovr_TestUserAppAccess_GetAccessToken_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_TestUserAppAccess_GetAppId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_TestUserAppAccess_GetUserId(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_TestUserAppAccessArray_GetElement(IntPtr obj, UIntPtr index);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_TestUserAppAccessArray_GetSize(IntPtr obj);

		public static string ovr_User_GetDisplayName(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetDisplayName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetDisplayName")]
		private static extern IntPtr ovr_User_GetDisplayName_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_User_GetID(IntPtr obj);

		public static string ovr_User_GetImageUrl(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetImageUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetImageUrl")]
		private static extern IntPtr ovr_User_GetImageUrl_Native(IntPtr obj);

		public static string ovr_User_GetInviteToken(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetInviteToken_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetInviteToken")]
		private static extern IntPtr ovr_User_GetInviteToken_Native(IntPtr obj);

		public static string ovr_User_GetOculusID(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetOculusID_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetOculusID")]
		private static extern IntPtr ovr_User_GetOculusID_Native(IntPtr obj);

		public static string ovr_User_GetPresence(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetPresence_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetPresence")]
		private static extern IntPtr ovr_User_GetPresence_Native(IntPtr obj);

		public static string ovr_User_GetPresenceDeeplinkMessage(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetPresenceDeeplinkMessage_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetPresenceDeeplinkMessage")]
		private static extern IntPtr ovr_User_GetPresenceDeeplinkMessage_Native(IntPtr obj);

		public static string ovr_User_GetPresenceDestinationApiName(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetPresenceDestinationApiName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetPresenceDestinationApiName")]
		private static extern IntPtr ovr_User_GetPresenceDestinationApiName_Native(IntPtr obj);

		public static string ovr_User_GetPresenceLobbySessionId(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetPresenceLobbySessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetPresenceLobbySessionId")]
		private static extern IntPtr ovr_User_GetPresenceLobbySessionId_Native(IntPtr obj);

		public static string ovr_User_GetPresenceMatchSessionId(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetPresenceMatchSessionId_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetPresenceMatchSessionId")]
		private static extern IntPtr ovr_User_GetPresenceMatchSessionId_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UserPresenceStatus ovr_User_GetPresenceStatus(IntPtr obj);

		public static string ovr_User_GetSmallImageUrl(IntPtr obj)
		{
			return StringFromNative(ovr_User_GetSmallImageUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_User_GetSmallImageUrl")]
		private static extern IntPtr ovr_User_GetSmallImageUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_UserAndRoom_GetRoom(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_UserAndRoom_GetUser(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_UserAndRoomArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_UserAndRoomArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_UserAndRoomArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserAndRoomArray_GetNextUrl")]
		private static extern IntPtr ovr_UserAndRoomArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_UserAndRoomArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UserAndRoomArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_UserArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_UserArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_UserArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserArray_GetNextUrl")]
		private static extern IntPtr ovr_UserArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_UserArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UserArray_HasNextPage(IntPtr obj);

		public static string ovr_UserCapability_GetDescription(IntPtr obj)
		{
			return StringFromNative(ovr_UserCapability_GetDescription_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserCapability_GetDescription")]
		private static extern IntPtr ovr_UserCapability_GetDescription_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UserCapability_GetIsEnabled(IntPtr obj);

		public static string ovr_UserCapability_GetName(IntPtr obj)
		{
			return StringFromNative(ovr_UserCapability_GetName_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserCapability_GetName")]
		private static extern IntPtr ovr_UserCapability_GetName_Native(IntPtr obj);

		public static string ovr_UserCapability_GetReasonCode(IntPtr obj)
		{
			return StringFromNative(ovr_UserCapability_GetReasonCode_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserCapability_GetReasonCode")]
		private static extern IntPtr ovr_UserCapability_GetReasonCode_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_UserCapabilityArray_GetElement(IntPtr obj, UIntPtr index);

		public static string ovr_UserCapabilityArray_GetNextUrl(IntPtr obj)
		{
			return StringFromNative(ovr_UserCapabilityArray_GetNextUrl_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserCapabilityArray_GetNextUrl")]
		private static extern IntPtr ovr_UserCapabilityArray_GetNextUrl_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_UserCapabilityArray_GetSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UserCapabilityArray_HasNextPage(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UserDataStoreUpdateResponse_GetSuccess(IntPtr obj);

		public static string ovr_UserProof_GetNonce(IntPtr obj)
		{
			return StringFromNative(ovr_UserProof_GetNonce_Native(obj));
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_UserProof_GetNonce")]
		private static extern IntPtr ovr_UserProof_GetNonce_Native(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool ovr_UserReportID_GetDidCancel(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ovr_UserReportID_GetID(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_VoipDecoder_Decode(IntPtr obj, byte[] compressedData, UIntPtr compressedSize);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_VoipDecoder_GetDecodedPCM(IntPtr obj, float[] outputBuffer, UIntPtr outputBufferSize);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_VoipEncoder_AddPCM(IntPtr obj, float[] inputData, uint inputSize);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_VoipEncoder_GetCompressedData(IntPtr obj, byte[] outputBuffer, UIntPtr intputSize);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern UIntPtr ovr_VoipEncoder_GetCompressedDataSize(IntPtr obj);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_AbuseReportOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_AbuseReportOptions_Destroy(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_AbuseReportOptions_SetPreventPeopleChooser(IntPtr handle, bool value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_AbuseReportOptions_SetReportType(IntPtr handle, AbuseReportType value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_AdvancedAbuseReportOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_AdvancedAbuseReportOptions_Destroy(IntPtr handle);

		public static void ovr_AdvancedAbuseReportOptions_SetObjectType(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_AdvancedAbuseReportOptions_SetObjectType_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_AdvancedAbuseReportOptions_SetObjectType")]
		private static extern void ovr_AdvancedAbuseReportOptions_SetObjectType_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_AdvancedAbuseReportOptions_SetReportType(IntPtr handle, AbuseReportType value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_AdvancedAbuseReportOptions_SetVideoMode(IntPtr handle, AbuseReportVideoMode value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ApplicationOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_ApplicationOptions_Destroy(IntPtr handle);

		public static void ovr_ApplicationOptions_SetDeeplinkMessage(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_ApplicationOptions_SetDeeplinkMessage_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ApplicationOptions_SetDeeplinkMessage")]
		private static extern void ovr_ApplicationOptions_SetDeeplinkMessage_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_ChallengeOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_ChallengeOptions_Destroy(IntPtr handle);

		public static void ovr_ChallengeOptions_SetDescription(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_ChallengeOptions_SetDescription_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeOptions_SetDescription")]
		private static extern void ovr_ChallengeOptions_SetDescription_Native(IntPtr handle, IntPtr value);

		public static void ovr_ChallengeOptions_SetEndDate(IntPtr handle, DateTime value)
		{
			ulong value2 = DateTimeToNative(value);
			ovr_ChallengeOptions_SetEndDate_Native(handle, value2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeOptions_SetEndDate")]
		private static extern void ovr_ChallengeOptions_SetEndDate_Native(IntPtr handle, ulong value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_ChallengeOptions_SetIncludeActiveChallenges(IntPtr handle, bool value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_ChallengeOptions_SetIncludeFutureChallenges(IntPtr handle, bool value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_ChallengeOptions_SetIncludePastChallenges(IntPtr handle, bool value);

		public static void ovr_ChallengeOptions_SetLeaderboardName(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_ChallengeOptions_SetLeaderboardName_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeOptions_SetLeaderboardName")]
		private static extern void ovr_ChallengeOptions_SetLeaderboardName_Native(IntPtr handle, IntPtr value);

		public static void ovr_ChallengeOptions_SetStartDate(IntPtr handle, DateTime value)
		{
			ulong value2 = DateTimeToNative(value);
			ovr_ChallengeOptions_SetStartDate_Native(handle, value2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeOptions_SetStartDate")]
		private static extern void ovr_ChallengeOptions_SetStartDate_Native(IntPtr handle, ulong value);

		public static void ovr_ChallengeOptions_SetTitle(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_ChallengeOptions_SetTitle_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_ChallengeOptions_SetTitle")]
		private static extern void ovr_ChallengeOptions_SetTitle_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_ChallengeOptions_SetViewerFilter(IntPtr handle, ChallengeViewerFilter value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_ChallengeOptions_SetVisibility(IntPtr handle, ChallengeVisibility value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_GroupPresenceOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_GroupPresenceOptions_Destroy(IntPtr handle);

		public static void ovr_GroupPresenceOptions_SetDestinationApiName(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_GroupPresenceOptions_SetDestinationApiName_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceOptions_SetDestinationApiName")]
		private static extern void ovr_GroupPresenceOptions_SetDestinationApiName_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_GroupPresenceOptions_SetIsJoinable(IntPtr handle, bool value);

		public static void ovr_GroupPresenceOptions_SetLobbySessionId(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_GroupPresenceOptions_SetLobbySessionId_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceOptions_SetLobbySessionId")]
		private static extern void ovr_GroupPresenceOptions_SetLobbySessionId_Native(IntPtr handle, IntPtr value);

		public static void ovr_GroupPresenceOptions_SetMatchSessionId(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_GroupPresenceOptions_SetMatchSessionId_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_GroupPresenceOptions_SetMatchSessionId")]
		private static extern void ovr_GroupPresenceOptions_SetMatchSessionId_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_InviteOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_InviteOptions_Destroy(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_InviteOptions_AddSuggestedUser(IntPtr handle, ulong value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_InviteOptions_ClearSuggestedUsers(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MatchmakingOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_Destroy(IntPtr handle);

		public static void ovr_MatchmakingOptions_SetCreateRoomDataStoreString(IntPtr handle, string key, string value)
		{
			IntPtr intPtr = StringToNative(key);
			IntPtr intPtr2 = StringToNative(value);
			ovr_MatchmakingOptions_SetCreateRoomDataStoreString_Native(handle, intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingOptions_SetCreateRoomDataStoreString")]
		private static extern void ovr_MatchmakingOptions_SetCreateRoomDataStoreString_Native(IntPtr handle, IntPtr key, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_ClearCreateRoomDataStore(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_SetCreateRoomJoinPolicy(IntPtr handle, RoomJoinPolicy value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_SetCreateRoomMaxUsers(IntPtr handle, uint value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_AddEnqueueAdditionalUser(IntPtr handle, ulong value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_ClearEnqueueAdditionalUsers(IntPtr handle);

		public static void ovr_MatchmakingOptions_SetEnqueueDataSettingsInt(IntPtr handle, string key, int value)
		{
			IntPtr intPtr = StringToNative(key);
			ovr_MatchmakingOptions_SetEnqueueDataSettingsInt_Native(handle, intPtr, value);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingOptions_SetEnqueueDataSettingsInt")]
		private static extern void ovr_MatchmakingOptions_SetEnqueueDataSettingsInt_Native(IntPtr handle, IntPtr key, int value);

		public static void ovr_MatchmakingOptions_SetEnqueueDataSettingsDouble(IntPtr handle, string key, double value)
		{
			IntPtr intPtr = StringToNative(key);
			ovr_MatchmakingOptions_SetEnqueueDataSettingsDouble_Native(handle, intPtr, value);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingOptions_SetEnqueueDataSettingsDouble")]
		private static extern void ovr_MatchmakingOptions_SetEnqueueDataSettingsDouble_Native(IntPtr handle, IntPtr key, double value);

		public static void ovr_MatchmakingOptions_SetEnqueueDataSettingsString(IntPtr handle, string key, string value)
		{
			IntPtr intPtr = StringToNative(key);
			IntPtr intPtr2 = StringToNative(value);
			ovr_MatchmakingOptions_SetEnqueueDataSettingsString_Native(handle, intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingOptions_SetEnqueueDataSettingsString")]
		private static extern void ovr_MatchmakingOptions_SetEnqueueDataSettingsString_Native(IntPtr handle, IntPtr key, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_ClearEnqueueDataSettings(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MatchmakingOptions_SetEnqueueIsDebug(IntPtr handle, bool value);

		public static void ovr_MatchmakingOptions_SetEnqueueQueryKey(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_MatchmakingOptions_SetEnqueueQueryKey_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_MatchmakingOptions_SetEnqueueQueryKey")]
		private static extern void ovr_MatchmakingOptions_SetEnqueueQueryKey_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_MultiplayerErrorOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MultiplayerErrorOptions_Destroy(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_MultiplayerErrorOptions_SetErrorKey(IntPtr handle, MultiplayerErrorErrorKey value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_NetSyncOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_NetSyncOptions_Destroy(IntPtr handle);

		public static void ovr_NetSyncOptions_SetVoipGroup(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_NetSyncOptions_SetVoipGroup_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_NetSyncOptions_SetVoipGroup")]
		private static extern void ovr_NetSyncOptions_SetVoipGroup_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_NetSyncOptions_SetVoipStreamDefault(IntPtr handle, NetSyncVoipStreamMode value);

		public static void ovr_NetSyncOptions_SetZoneId(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_NetSyncOptions_SetZoneId_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_NetSyncOptions_SetZoneId")]
		private static extern void ovr_NetSyncOptions_SetZoneId_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_RichPresenceOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RichPresenceOptions_Destroy(IntPtr handle);

		public static void ovr_RichPresenceOptions_SetApiName(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_RichPresenceOptions_SetApiName_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetApiName")]
		private static extern void ovr_RichPresenceOptions_SetApiName_Native(IntPtr handle, IntPtr value);

		public static void ovr_RichPresenceOptions_SetArgsString(IntPtr handle, string key, string value)
		{
			IntPtr intPtr = StringToNative(key);
			IntPtr intPtr2 = StringToNative(value);
			ovr_RichPresenceOptions_SetArgsString_Native(handle, intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetArgsString")]
		private static extern void ovr_RichPresenceOptions_SetArgsString_Native(IntPtr handle, IntPtr key, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RichPresenceOptions_ClearArgs(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RichPresenceOptions_SetCurrentCapacity(IntPtr handle, uint value);

		public static void ovr_RichPresenceOptions_SetDeeplinkMessageOverride(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_RichPresenceOptions_SetDeeplinkMessageOverride_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetDeeplinkMessageOverride")]
		private static extern void ovr_RichPresenceOptions_SetDeeplinkMessageOverride_Native(IntPtr handle, IntPtr value);

		public static void ovr_RichPresenceOptions_SetEndTime(IntPtr handle, DateTime value)
		{
			ulong value2 = DateTimeToNative(value);
			ovr_RichPresenceOptions_SetEndTime_Native(handle, value2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetEndTime")]
		private static extern void ovr_RichPresenceOptions_SetEndTime_Native(IntPtr handle, ulong value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RichPresenceOptions_SetExtraContext(IntPtr handle, RichPresenceExtraContext value);

		public static void ovr_RichPresenceOptions_SetInstanceId(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_RichPresenceOptions_SetInstanceId_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetInstanceId")]
		private static extern void ovr_RichPresenceOptions_SetInstanceId_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RichPresenceOptions_SetIsIdle(IntPtr handle, bool value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RichPresenceOptions_SetIsJoinable(IntPtr handle, bool value);

		public static void ovr_RichPresenceOptions_SetJoinableId(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_RichPresenceOptions_SetJoinableId_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetJoinableId")]
		private static extern void ovr_RichPresenceOptions_SetJoinableId_Native(IntPtr handle, IntPtr value);

		public static void ovr_RichPresenceOptions_SetLobbySessionId(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_RichPresenceOptions_SetLobbySessionId_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetLobbySessionId")]
		private static extern void ovr_RichPresenceOptions_SetLobbySessionId_Native(IntPtr handle, IntPtr value);

		public static void ovr_RichPresenceOptions_SetMatchSessionId(IntPtr handle, string value)
		{
			IntPtr intPtr = StringToNative(value);
			ovr_RichPresenceOptions_SetMatchSessionId_Native(handle, intPtr);
			Marshal.FreeCoTaskMem(intPtr);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetMatchSessionId")]
		private static extern void ovr_RichPresenceOptions_SetMatchSessionId_Native(IntPtr handle, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RichPresenceOptions_SetMaxCapacity(IntPtr handle, uint value);

		public static void ovr_RichPresenceOptions_SetStartTime(IntPtr handle, DateTime value)
		{
			ulong value2 = DateTimeToNative(value);
			ovr_RichPresenceOptions_SetStartTime_Native(handle, value2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RichPresenceOptions_SetStartTime")]
		private static extern void ovr_RichPresenceOptions_SetStartTime_Native(IntPtr handle, ulong value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_RoomOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_Destroy(IntPtr handle);

		public static void ovr_RoomOptions_SetDataStoreString(IntPtr handle, string key, string value)
		{
			IntPtr intPtr = StringToNative(key);
			IntPtr intPtr2 = StringToNative(value);
			ovr_RoomOptions_SetDataStoreString_Native(handle, intPtr, intPtr2);
			Marshal.FreeCoTaskMem(intPtr);
			Marshal.FreeCoTaskMem(intPtr2);
		}

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ovr_RoomOptions_SetDataStoreString")]
		private static extern void ovr_RoomOptions_SetDataStoreString_Native(IntPtr handle, IntPtr key, IntPtr value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_ClearDataStore(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_SetExcludeRecentlyMet(IntPtr handle, bool value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_SetMaxUserResults(IntPtr handle, uint value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_SetOrdering(IntPtr handle, UserOrdering value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_SetRecentlyMetTimeWindow(IntPtr handle, TimeWindow value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_SetRoomId(IntPtr handle, ulong value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RoomOptions_SetTurnOffUpdates(IntPtr handle, bool value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_RosterOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RosterOptions_Destroy(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RosterOptions_AddSuggestedUser(IntPtr handle, ulong value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_RosterOptions_ClearSuggestedUsers(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_UserOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_UserOptions_Destroy(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_UserOptions_SetMaxUsers(IntPtr handle, uint value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_UserOptions_AddServiceProvider(IntPtr handle, ServiceProvider value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_UserOptions_ClearServiceProviders(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_UserOptions_SetTimeWindow(IntPtr handle, TimeWindow value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ovr_VoipOptions_Create();

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_VoipOptions_Destroy(IntPtr handle);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_VoipOptions_SetBitrateForNewConnections(IntPtr handle, VoipBitrate value);

		[DllImport("LibOVRPlatform64_1", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ovr_VoipOptions_SetCreateNewConnectionUseDtx(IntPtr handle, VoipDtxState value);
	}
}
