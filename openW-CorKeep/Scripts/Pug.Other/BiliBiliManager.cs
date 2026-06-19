using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NativeWebSocket;
using Newtonsoft.Json;
using OpenBLive.Runtime;
using OpenBLive.Runtime.Data;
using OpenBLive.Runtime.Utilities;
using PimDeWitte.UnityMainThreadDispatcher;
using QFSW.QC;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

public class BiliBiliManager : IStreamIntegrationManager
{
	private enum LinkResult
	{
		None = 0,
		Success = 1,
		Failure = 2,
		Canceled = 3
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct danmuCommands
	{
		public const string none = "none";

		public const string buff = "buff";

		public const string buff2 = "666";

		public const string debuff = "debuff";

		public const string summon = "summon";

		public const string summon2 = "召唤";

		public const string bomb = "bomb";

		public const string bomb2 = "炸弹";
	}

	private const string ErrorBilibiliConnectionFailed = "Error/BiliBiliConnectionFailed";

	private BilibiliConfiguration bilibiliConfiguration;

	private string accessKeySecret;

	private string accessKeyId;

	private string appId;

	public static int currentConnectDelay;

	private bool roomIsConnected;

	private bool saveCode;

	private bool isConnecting;

	private bool isClosing;

	private bool quitRequested;

	private bool canceled;

	private bool triedToConnectAtStartup;

	private LinkResult linkResult;

	private WebSocketBLiveClient mWebSocketBLiveClient;

	private InteractivePlayHeartBeat playHeartBeat;

	private string gameId;

	private float lastConnectTime = -90f;

	[Preserve]
	[Command("bilibili.connect", "Connects to a BiliBili stream", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void ConnectToRoom(string code, bool save)
	{
		if (!(Manager.stream.StreamIntegrationManager is BiliBiliManager))
		{
			Manager.menu.quantumConsole.LogToConsole("BiliBili stream integration is not enabled");
		}
		else
		{
			Manager.stream.StreamIntegrationManager.ConnectToRoom(code, save, null);
		}
	}

	public void ConnectToRoom(string code, bool save, Action<bool> onConnect)
	{
		Connect(code, save, onConnect);
	}

	public void Disconnect()
	{
		CloseWebsocket();
		roomIsConnected = false;
	}

	public bool TriedToConnectAtStartup(out bool result)
	{
		result = linkResult == LinkResult.Success;
		return triedToConnectAtStartup;
	}

	public bool IsConnecting()
	{
		return isConnecting;
	}

	public bool IsConnected()
	{
		if (!isConnecting)
		{
			return mWebSocketBLiveClient != null;
		}
		return false;
	}

	public void CancelConnect()
	{
		canceled = true;
	}

	public bool IsRoomConnected()
	{
		return roomIsConnected;
	}

	public bool Init()
	{
		string bilibiliCode = Manager.prefs.BilibiliCode;
		if (!string.IsNullOrEmpty(bilibiliCode) && CommandLineArgs.Has("-bilibili"))
		{
			Debug.Log("connecting to bilibili room with saved code");
			triedToConnectAtStartup = true;
			Connect(bilibiliCode, save: true, null);
		}
		bilibiliConfiguration = Resources.Load<BilibiliConfiguration>("Platform/BilibiliConfiguration");
		appId = bilibiliConfiguration.appID;
		accessKeySecret = bilibiliConfiguration.accesKeySecret;
		accessKeyId = bilibiliConfiguration.accesKeyID;
		Manager.wantsToQuit += WantsToQuitHandler;
		return true;
	}

	public void Update()
	{
		WebSocketBLiveClient webSocketBLiveClient = mWebSocketBLiveClient;
		if (webSocketBLiveClient != null)
		{
			WebSocket ws = webSocketBLiveClient.ws;
			if (ws != null && ws.State == WebSocketState.Open)
			{
				mWebSocketBLiveClient.ws.DispatchMessageQueue();
			}
		}
	}

	private bool WantsToQuitHandler()
	{
		if (mWebSocketBLiveClient != null)
		{
			Debug.Log("waiting for bilibili session to close before exit");
			quitRequested = true;
			CloseWebsocket();
			return false;
		}
		return true;
	}

	private void CloseWebsocket()
	{
		if (mWebSocketBLiveClient != null && !isClosing)
		{
			isClosing = true;
			playHeartBeat.Dispose();
			UnityMainThreadDispatcher.Instance().StartCoroutine(LinkCloseRoutine(mWebSocketBLiveClient));
			mWebSocketBLiveClient = null;
		}
	}

	private void Connect(string code, bool save, Action<bool> onConnect)
	{
		if (isConnecting)
		{
			Debug.Log("ignoring new bilibili code, already connecting");
			return;
		}
		canceled = false;
		if (mWebSocketBLiveClient != null)
		{
			CloseWebsocket();
		}
		if (!string.IsNullOrEmpty(Manager.prefs.BilibiliCode))
		{
			Debug.Log("bilibili code cleared");
			Manager.prefs.BilibiliCode = "";
		}
		isConnecting = true;
		saveCode = save;
		UnityMainThreadDispatcher.Instance().StartCoroutine(LinkStartRoutine(code, onConnect));
	}

	private IEnumerator LinkStartRoutine(string code, Action<bool> onConnect)
	{
		while (isClosing)
		{
			yield return null;
		}
		currentConnectDelay = 0;
		float num = 90f - (Time.realtimeSinceStartup - lastConnectTime);
		Debug.Log($"waiting {num} seconds before bilibili connect to avoid triggering rate limit");
		float remainingDelay = num;
		while (remainingDelay > 0f && !canceled)
		{
			currentConnectDelay = (int)math.round(remainingDelay);
			yield return new WaitForSecondsRealtime(1f);
			remainingDelay -= 1f;
		}
		if (canceled)
		{
			isConnecting = false;
			linkResult = LinkResult.Canceled;
			onConnect?.Invoke(obj: false);
			yield break;
		}
		yield return null;
		linkResult = LinkResult.None;
		lastConnectTime = Time.realtimeSinceStartup;
		LinkStart(code);
		while (linkResult == LinkResult.None && !canceled)
		{
			yield return null;
		}
		if (canceled)
		{
			Debug.Log("bilibili connection canceled");
			CloseWebsocket();
			linkResult = LinkResult.Canceled;
		}
		if (linkResult == LinkResult.Success && saveCode)
		{
			Manager.prefs.BilibiliCode = code;
			Debug.Log("bilibili code saved");
		}
		isConnecting = false;
		onConnect?.Invoke(linkResult == LinkResult.Success);
	}

	private void CloseNow(WebSocketBLiveClient client)
	{
		Task<string> task = BApi.EndInteractivePlay(appId, gameId);
		task.Wait(5000);
		if (!task.IsCompletedSuccessfully)
		{
			Debug.LogError("failed to end bilibili session: " + task.Result);
		}
		client.Dispose();
	}

	private IEnumerator LinkCloseRoutine(WebSocketBLiveClient client)
	{
		Task<string> closeTask = BApi.EndInteractivePlay(appId, gameId);
		while (!closeTask.IsCompleted)
		{
			yield return null;
		}
		if (!closeTask.IsCompletedSuccessfully)
		{
			Debug.LogError("failed to end bilibili session: " + closeTask.Result);
		}
		client.Dispose();
		isClosing = false;
		if (quitRequested)
		{
			Manager.QuitGame();
		}
	}

	private async void LinkStart(string code)
	{
		SignUtility.accessKeySecret = accessKeySecret;
		SignUtility.accessKeyId = accessKeyId;
		AppStartInfo appStartInfo = JsonConvert.DeserializeObject<AppStartInfo>(await BApi.StartInteractivePlay(code, appId));
		if (appStartInfo.Code != 0)
		{
			linkResult = LinkResult.Failure;
			isConnecting = false;
			Debug.LogError(appStartInfo.Message);
			return;
		}
		mWebSocketBLiveClient = new WebSocketBLiveClient(appStartInfo.GetWssLink(), appStartInfo.GetAuthBody());
		mWebSocketBLiveClient.OnDanmaku += WebSocketBLiveClientOnDanmaku;
		mWebSocketBLiveClient.OnGift += WebSocketBLiveClientOnGift;
		mWebSocketBLiveClient.OnLike += WebSocketBLiveClientOnLike;
		mWebSocketBLiveClient.OnGuardBuy += WebSocketBLiveClientOnGuardBuy;
		mWebSocketBLiveClient.OnSuperChat += WebSocketBLiveClientOnSuperChat;
		try
		{
			mWebSocketBLiveClient.Connect(TimeSpan.FromSeconds(1.0), 1000000);
		}
		catch (Exception exception)
		{
			linkResult = LinkResult.Failure;
			isConnecting = false;
			Debug.LogException(exception);
			return;
		}
		Debug.Log("successfully connected to bilibili room");
		gameId = appStartInfo.GetGameId();
		playHeartBeat = new InteractivePlayHeartBeat(gameId);
		playHeartBeat.HeartBeatError += PlayHeartBeatHeartBeatError;
		playHeartBeat.HeartBeatSucceed += PlayHeartBeatHeartBeatSucceed;
		playHeartBeat.Start();
		linkResult = LinkResult.Success;
		roomIsConnected = true;
	}

	public Task LinkEnd()
	{
		mWebSocketBLiveClient.Dispose();
		playHeartBeat.Dispose();
		return Task.CompletedTask;
	}

	[Preserve]
	[Command("bilibili.PlayDanmuSummonCommand", "Plays danmu summon command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayDanmuSummonCommand(int amount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			for (int i = 0; i < amount; i++)
			{
				biliBiliManager.WebSocketBLiveClientOnDanmaku(new Dm
				{
					msg = "summon"
				});
			}
		}
	}

	[Preserve]
	[Command("bilibili.PlayDanmuBuffCommand", "Plays danmu buff command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayDanmuBuffCommand(int amount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			for (int i = 0; i < amount; i++)
			{
				biliBiliManager.WebSocketBLiveClientOnDanmaku(new Dm
				{
					msg = "buff"
				});
			}
		}
	}

	[Preserve]
	[Command("bilibili.PlayDanmuSpawnBombsCommand", "Plays danmu spawn bombs command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayDanmuSpawnBombsCommand(int amount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			for (int i = 0; i < amount; i++)
			{
				biliBiliManager.WebSocketBLiveClientOnDanmaku(new Dm
				{
					msg = "bomb"
				});
			}
		}
	}

	[Preserve]
	[Command("bilibili.PlayGiftSummonCommand", "Plays gift summon command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayGiftSummonCommand(int giftAmount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			biliBiliManager.WebSocketBLiveClientOnGift(new SendGift
			{
				userName = "TestGiftPerson",
				giftId = 34660L,
				giftName = "Monster Summoning Card",
				giftNum = giftAmount,
				paid = true
			});
		}
	}

	[Preserve]
	[Command("bilibili.PlayGiftBuffCommand", "Plays gift buff command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayGiftBuffCommand(int giftAmount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			biliBiliManager.WebSocketBLiveClientOnGift(new SendGift
			{
				userName = "TestGiftPerson",
				giftId = 34661L,
				giftName = "Buff Potion",
				giftNum = giftAmount,
				paid = true
			});
		}
	}

	[Preserve]
	[Command("bilibili.PlayGiftKillAllCommand", "Plays gift kill all enemies command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayGiftKillAllCommand(int giftAmount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			biliBiliManager.WebSocketBLiveClientOnGift(new SendGift
			{
				userName = "TestGiftPerson",
				giftId = 34662L,
				giftName = "Kill all enemies",
				giftNum = giftAmount,
				paid = true
			});
		}
	}

	[Preserve]
	[Command("bilibili.PlayGiftSpawnBombs", "Plays gift spawn bombs on player", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayGiftSpawnBombsOnPlayers(int giftAmount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			biliBiliManager.WebSocketBLiveClientOnGift(new SendGift
			{
				userName = "TestGiftPerson",
				giftId = 34831L,
				giftName = "Spawn bombs on players",
				giftNum = giftAmount,
				paid = true
			});
		}
	}

	[Preserve]
	[Command("bilibili.PlayLikeCommand", "Plays like command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlayLikeCommand(int likeAmount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			for (int i = 0; i < likeAmount; i++)
			{
				biliBiliManager.WebSocketBLiveClientOnLike(new Like
				{
					uname = "TestLikePerson"
				});
			}
		}
	}

	[Preserve]
	[Command("bilibili.PlaySubscribeCommand", "Plays subscribe command", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void PlaySubscribeCommand(int subAmount)
	{
		if (Manager.stream.StreamIntegrationManager is BiliBiliManager biliBiliManager)
		{
			for (int i = 0; i < subAmount; i++)
			{
				biliBiliManager.WebSocketBLiveClientOnGuardBuy(new Guard
				{
					userInfo = new UserInfo
					{
						userName = "TestSubUser"
					}
				});
			}
		}
	}

	private void WebSocketBLiveClientOnSuperChat(SuperChat superChat)
	{
		Manager.stream.EnqueueCommand(new StreamManager.CommandData
		{
			command = StreamManager.Command.SuperChatMessage,
			userName = superChat.userName
		});
	}

	private void WebSocketBLiveClientOnGuardBuy(Guard guard)
	{
		Manager.stream.EnqueueCommand(new StreamManager.CommandData
		{
			command = StreamManager.Command.UserSubscribed,
			userName = guard.userInfo.userName
		});
	}

	private void WebSocketBLiveClientOnGift(SendGift sendGift)
	{
		for (int i = 0; i < sendGift.giftNum; i++)
		{
			if (sendGift.giftId == 34660)
			{
				Manager.stream.EnqueueCommand(new StreamManager.CommandData
				{
					command = StreamManager.Command.PaidGiftSummon,
					userName = sendGift.userName,
					giftName = sendGift.giftName,
					isGift = true
				});
			}
			else if (sendGift.giftId == 34661)
			{
				Manager.stream.EnqueueCommand(new StreamManager.CommandData
				{
					command = StreamManager.Command.PaidGiftBuff,
					userName = sendGift.userName,
					giftName = sendGift.giftName,
					isGift = true
				});
			}
			else if (sendGift.giftId == 34662)
			{
				Manager.stream.EnqueueCommand(new StreamManager.CommandData
				{
					command = StreamManager.Command.PaidGiftKillAllEnemies,
					userName = sendGift.userName,
					giftName = sendGift.giftName,
					isGift = true
				});
			}
			else if (sendGift.giftId == 34831)
			{
				Manager.stream.EnqueueCommand(new StreamManager.CommandData
				{
					command = StreamManager.Command.PaidGiftSpawnBombsOnPlayer,
					userName = sendGift.userName,
					giftName = sendGift.giftName,
					isGift = true
				});
			}
		}
	}

	private void WebSocketBLiveClientOnDanmaku(Dm dm)
	{
		switch (dm.msg)
		{
		case "666":
		case "buff":
			Manager.stream.EnqueueCommand(new StreamManager.CommandData
			{
				command = StreamManager.Command.TextMessageBuff,
				isTextMessage = true
			});
			break;
		case "召唤":
		case "summon":
			Manager.stream.EnqueueCommand(new StreamManager.CommandData
			{
				command = StreamManager.Command.TextMessageSummon,
				isTextMessage = true
			});
			break;
		case "炸弹":
		case "bomb":
			Manager.stream.EnqueueCommand(new StreamManager.CommandData
			{
				command = StreamManager.Command.TextMessageBombsOnPlayer,
				isTextMessage = true
			});
			break;
		}
	}

	private void WebSocketBLiveClientOnLike(Like like)
	{
		Manager.stream.EnqueueCommand(new StreamManager.CommandData
		{
			command = StreamManager.Command.LikesSent,
			userName = like.uname
		});
	}

	private static void PlayHeartBeatHeartBeatSucceed()
	{
		Debug.Log("bilibili heart beat succeeded");
	}

	private void PlayHeartBeatHeartBeatError(string json)
	{
		Debug.Log("bilibili heart beat error:\n" + json);
		CloseWebsocket();
	}
}
