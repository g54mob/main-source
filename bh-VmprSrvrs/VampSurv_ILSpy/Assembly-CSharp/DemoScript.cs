using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Cpp2ILInjected;
using PartyCSharpSDK;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Party;
using UnityEngine;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{
	public InputField networkIdTextBox;

	public Text output;

	private void Start()
	{
		//IL_01e7: Expected O, but got F4
		//IL_0058: Expected O, but got I4
		//IL_0217->IL011e: Incompatible stack heights: 1 vs 0
		PlayFabMultiplayerManager playFabMultiplayerManager = PlayFabMultiplayerManager.Get();
		LoginWithCustomIDRequest loginWithCustomIDRequest = new LoginWithCustomIDRequest();
		object obj = UnityEngine.Random.value;
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		float value = default(float);
		string customId = System.Number.FormatSingle(value, null, currentInfo);
		loginWithCustomIDRequest.CustomId = customId;
		loginWithCustomIDRequest.CreateAccount = (bool?)(object)257;
		Action<LoginResult> resultCallback = OnLoginSuccess;
		Action<PlayFabError> errorCallback = OnLoginFailure;
		Dictionary<string, string> extraHeaders = default(Dictionary<string, string>);
		PlayFabClientAPI.LoginWithCustomID(loginWithCustomIDRequest, resultCallback, errorCallback, null, extraHeaders);
		PlayFabMultiplayerManager.OnNetworkJoinedHandler value2 = OnNetworkJoined;
		playFabMultiplayerManager.OnNetworkJoined += value2;
		PlayFabMultiplayerManager.OnDataMessageReceivedHandler b = OnDataMessageReceived;
		Delegate obj2 = playFabMultiplayerManager.OnDataMessageReceived;
		bool flag5;
		do
		{
			Delegate obj3 = Delegate.Combine(obj2, b);
			bool flag = (object)obj3 == null;
			Delegate obj4 = null;
			if (!flag)
			{
				bool flag2 = (object)obj3.GetType() != typeof(PlayFabMultiplayerManager.OnDataMessageReceivedHandler);
				obj4 = null;
				if (!flag2)
				{
					obj4 = obj3;
				}
				bool flag3 = (object)obj4 == null;
			}
			bool flag4 = (object)obj2 == playFabMultiplayerManager.OnDataMessageReceived;
			Delegate obj5;
			if ((object)obj2 == playFabMultiplayerManager.OnDataMessageReceived)
			{
				playFabMultiplayerManager.OnDataMessageReceived = (PlayFabMultiplayerManager.OnDataMessageReceivedHandler)obj4;
				obj5 = obj2;
			}
			else
			{
				obj5 = playFabMultiplayerManager.OnDataMessageReceived;
			}
			Delegate obj6 = obj2;
			if (!flag4)
			{
				obj6 = obj5;
			}
			flag5 = (object)obj6 != obj2;
			obj2 = obj6;
		}
		while (flag5);
		PlayFabMultiplayerManager.OnDataMessageReceivedNoCopyHandler value3 = OnDataMessageNoCopyReceived;
		playFabMultiplayerManager.OnDataMessageNoCopyReceived += value3;
	}

	public void CreateAndJoinToNetwork()
	{
		PlayFabMultiplayerManager playFabMultiplayerManager = PlayFabMultiplayerManager.Get();
		if ((object)playFabMultiplayerManager == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
			return;
		}
		PlayFabNetworkConfiguration playFabNetworkConfiguration = new PlayFabNetworkConfiguration();
		playFabNetworkConfiguration._maxPlayerCount = 32u;
		playFabNetworkConfiguration._directPeerConnectivityOptions = (PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS)15u;
		playFabNetworkConfiguration.MaxPlayerCount = 32u;
		playFabMultiplayerManager.CreateAndJoinNetworkImplStart(playFabNetworkConfiguration);
	}

	public void JoinNetwork()
	{
		PlayFabMultiplayerManager playFabMultiplayerManager = PlayFabMultiplayerManager.Get();
		InputField inputField = networkIdTextBox;
		playFabMultiplayerManager.JoinNetworkImplStart(inputField.m_Text);
	}

	private void OnDataMessageReceived(object sender, PlayFabPlayer from, byte[] buffer)
	{
		Debug.Log("Got a message (simple).");
		if ((object)output != null)
		{
			string text = output.text;
			string text2 = text + "\r\n Got a message (simple).";
			output.text = text2;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
		}
	}

	private void OnDataMessageNoCopyReceived(object sender, PlayFabPlayer from, IntPtr buffer, uint bufferSize)
	{
		Debug.Log("Got a message (no copy).");
		if ((object)output != null)
		{
			string text = output.text;
			string text2 = text + "\r\n Got a message (no copy).";
			output.text = text2;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
		}
	}

	private void OnNetworkJoined(object sender, string networkId)
	{
		//IL_0077: Expected I, but got O
		//IL_0087: Expected O, but got I
		//IL_00f8: Expected I, but got O
		//IL_0101: Expected O, but got I4
		//IL_0124: Expected I, but got O
		//IL_0144: Expected O, but got I
		//IL_02a6: Expected I, but got O
		//IL_02c6: Expected O, but got I
		//IL_023b: Expected I, but got O
		//IL_0248: Expected O, but got I4
		//IL_0374: Expected O, but got I
		//IL_03ba: Expected O, but got I
		//IL_0441: Expected I, but got O
		//IL_0468: Expected I4, but got O
		Debug.Log("Joined the network.");
		Text text = output;
		bool flag = (object)output == null;
		string text2 = networkId;
		string text3 = null;
		object obj = "Joined the network.";
		byte[] array = default(byte[]);
		if (!flag)
		{
			string text4 = output.text;
			string text5 = text4 + "\r\n Joined the network.";
			nint num = (nint)text;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r9_v5 (Il2CppMethodInfo)+5F0]");
			text2 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v102 @ r9_v5 (Il2CppMethodInfo)+5E8] (should have been resolved before IL gen)");
			bool flag2 = (object)networkIdTextBox == null;
			text3 = text5;
			obj = networkIdTextBox;
			if (!flag2)
			{
				networkIdTextBox.SetText(networkId, true);
				Encoding aSCII = Encoding.ASCII;
				bool flag3 = aSCII == null;
				num = unchecked((nint)null);
				text2 = (string)1;
				text3 = networkId;
				obj = null;
				if (!flag3)
				{
					nint num2 = (nint)aSCII;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ r8_v5 (Il2CppClass<System.Text.Encoding>)+268]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ r8_v5 (Il2CppClass<System.Text.Encoding>)+270]");
					text2 = (string)0;
					byte[] bytes = aSCII.GetBytes("Hello world (simple message).");
					PlayFabMultiplayerManager playFabMultiplayerManager = PlayFabMultiplayerManager.Get();
					bool flag4 = (object)playFabMultiplayerManager == null;
					text3 = "Hello world (simple message).";
					obj = null;
					if (!flag4)
					{
						PlayFabMultiplayerManager._LogInfo("PlayFabMultiplayerManager:_SendDataMessageToAllPlayers(byte[] buffer)");
						string message;
						if (playFabMultiplayerManager._playFabMultiplayerManagerState >= PlayFabMultiplayerManager._InternalPlayFabMultiplayerManagerState.ConnectedToNetwork)
						{
							if (Enumerable.Count(bytes) != 0)
							{
								uint num3 = SDK.PartyEndpointSendMessage(playFabMultiplayerManager._localEndPointHandle, null, playFabMultiplayerManager._defaultSendOptions, playFabMultiplayerManager._defaultQueuingConfiguration, array);
								bool flag5 = playFabMultiplayerManager.PartySucceeded(num3);
								num = (nint)playFabMultiplayerManager._defaultQueuingConfiguration;
								text2 = null;
								text3 = (string)num3;
								goto IL_0273;
							}
							message = "Data message cannot be empty.";
						}
						else
						{
							message = "You need to connect to a network before you can call this method.";
						}
						PlayFabMultiplayerManager._LogError(message);
						text3 = null;
						goto IL_0273;
					}
				}
			}
		}
		goto IL_04ae;
		IL_0273:
		Encoding aSCII2 = Encoding.ASCII;
		bool flag6 = aSCII2 == null;
		obj = null;
		if (!flag6)
		{
			nint num4 = (nint)aSCII2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r8_v8 (Il2CppClass<System.Text.Encoding>)+268]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r8_v8 (Il2CppClass<System.Text.Encoding>)+270]");
			text2 = (string)0;
			byte[] bytes2 = aSCII2.GetBytes("Hello world (no garbage collection method).");
			bool flag7 = bytes2 == null;
			text3 = "Hello world (no garbage collection method).";
			obj = aSCII2;
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [187A213B0] (should have been resolved before IL gen)");
				int num5 = bytes2.Length;
				IntPtr intPtr = default(IntPtr);
				Marshal.Copy(bytes2, 0, intPtr, bytes2.Length);
				PlayFabMultiplayerManager playFabMultiplayerManager2 = PlayFabMultiplayerManager.Get();
				PlayFabMultiplayerManager playFabMultiplayerManager3 = PlayFabMultiplayerManager.Get();
				bool flag8 = (object)playFabMultiplayerManager3 == null;
				num = bytes2.Length;
				text2 = (string)(nint)intPtr;
				text3 = null;
				obj = null;
				if (!flag8)
				{
					IList<PlayFabPlayer> remotePlayers = playFabMultiplayerManager3.RemotePlayers;
					bool flag9 = (object)playFabMultiplayerManager2 == null;
					num = bytes2.Length;
					text2 = (string)(nint)intPtr;
					text3 = null;
					obj = playFabMultiplayerManager3;
					if (!flag9)
					{
						PlayFabMultiplayerManager._LogInfo("PlayFabMultiplayerManager:_SendDataMessage(IntPtr buffer, uint bufferSize, IEnumerable<PlayFabPlayer> recipients, DeliveryOption deliveryOption)");
						if (bytes2.Length != 0)
						{
							PARTY_ENDPOINT_HANDLE[] targetEndpoints = playFabMultiplayerManager2.EndPointHandlesFromPlayFabPlayerListNoGC((IEnumerable<PlayFabPlayer>)remotePlayers);
							uint dataBufferSize = default(uint);
							uint num6 = SDK.PartyEndpointSendMessage(playFabMultiplayerManager2._localEndPointHandle, targetEndpoints, PARTY_SEND_MESSAGE_OPTIONS.PARTY_SEND_MESSAGE_OPTIONS_SEQUENTIAL_DELIVERY, playFabMultiplayerManager2._defaultQueuingConfiguration, (IntPtr)array, dataBufferSize);
							bool flag10 = playFabMultiplayerManager2.PartySucceeded(num6);
							num5 = (int)playFabMultiplayerManager2._defaultQueuingConfiguration;
							nint num7 = 0;
							uint num8 = num6;
						}
						else
						{
							PlayFabMultiplayerManager._LogError("Data message cannot be empty.");
							nint num7 = intPtr;
							uint num8 = 0u;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [187A213A8] (should have been resolved before IL gen)");
						return;
					}
				}
			}
		}
		goto IL_04ae;
		IL_04ae:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
	}

	private void OnLoginSuccess(LoginResult result)
	{
		Debug.Log("Logged into PlayFab.");
		if ((object)output != null)
		{
			string text = output.text;
			string text2 = text + "\r\n Logged into PlayFab.";
			output.text = text2;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
		}
	}

	private void OnLoginFailure(PlayFabError error)
	{
		string message = "Error logging into PlayFab: " + error.ErrorMessage;
		Debug.Log(message);
		string text = output.text;
		string text2 = text + "\r\n Error logging into PlayFab: " + error.ErrorMessage;
		output.text = text2;
	}

	private void Update()
	{
	}

	public DemoScript()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
