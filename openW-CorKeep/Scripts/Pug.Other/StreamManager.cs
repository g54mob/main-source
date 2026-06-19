using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pug.UnityExtensions;
using PugTilemap;
using QFSW.QC;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Scripting;

public class StreamManager : ManagerBase
{
	public enum Command
	{
		None = 0,
		TextMessageBuff = 1,
		PaidGiftBuff = 2,
		TextMessageDebuff = 3,
		PaidGiftDebuff = 4,
		TextMessageSummon = 5,
		PaidGiftSummon = 6,
		PaidGiftKillAllEnemies = 7,
		TextMessageBombsOnPlayer = 8,
		PaidGiftSpawnBombsOnPlayer = 9,
		LikesSent = 10,
		UserSubscribed = 11,
		SuperChatMessage = 12
	}

	private struct GeneratedEnemyToSpawn
	{
		public ObjectID EnemyID;

		public StreamIntegrationEventRarity Rarity;
	}

	private struct GeneratedDebuffBuffPotionToApply
	{
		public ObjectID PotionID;

		public ConditionData Condition;

		public float DurationForTextMessages;

		public float DurationForSentGifts;

		public StreamIntegrationEventRarity Rarity;
	}

	private struct GeneratedBombToSpawn
	{
		public ObjectID BombID;

		public int2 PositionArea;
	}

	private struct GeneratedCommandsContainer
	{
		public GeneratedEnemyToSpawn GeneratedEnemyToSpawn;

		public GeneratedDebuffBuffPotionToApply GeneratedDebuffBuffPotionToApply;

		public GeneratedBombToSpawn GeneratedBombToSpawn;
	}

	private struct SpawnedEnemyCounts
	{
		public int CommonEnemiesCount;

		public int RareEnemiesCount;

		public int SpecialEnemiesCount;
	}

	[Serializable]
	public struct CommandData
	{
		public Command command;

		public string userName;

		public bool isTextMessage;

		public bool isGift;

		public string giftName;
	}

	private class WebSocketServer : IDisposable
	{
		private readonly HttpListener _listener = new HttpListener();

		private readonly ConcurrentQueue<CommandData> _commandQueue;

		private bool _isRunning = true;

		private bool _hasStopped;

		private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

		public WebSocketServer(string url, ConcurrentQueue<CommandData> commandQueue)
		{
			_commandQueue = commandQueue;
			_listener.Prefixes.Add(url);
			_listener.Start();
			Task.Run((Action)RequestHandler);
			Debug.Log("started stream command listener at " + url);
		}

		private async void RequestHandler()
		{
			_ = 1;
			try
			{
				while (_isRunning)
				{
					HttpListenerContext httpListenerContext = await _listener.GetContextAsync();
					if (httpListenerContext.Request.IsWebSocketRequest)
					{
						await HandleWebSocketConnectionAsync(httpListenerContext, _cancellationTokenSource.Token, _commandQueue);
						continue;
					}
					httpListenerContext.Response.StatusCode = 400;
					httpListenerContext.Response.Close();
				}
				_cancellationTokenSource.Cancel();
				_listener.Stop();
			}
			finally
			{
				_hasStopped = true;
			}
		}

		private static async Task HandleWebSocketConnectionAsync(HttpListenerContext context, CancellationToken token, ConcurrentQueue<CommandData> commandQueue)
		{
			WebSocket webSocket = (await context.AcceptWebSocketAsync(null)).WebSocket;
			Console.WriteLine("WebSocket connection established.");
			byte[] buffer = new byte[1024];
			try
			{
				while (webSocket.State == WebSocketState.Open)
				{
					WebSocketReceiveResult webSocketReceiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), token);
					if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
					{
						await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", token);
						Debug.Log("stream command webSocket connection closed.");
					}
					else if (webSocketReceiveResult.MessageType == WebSocketMessageType.Text)
					{
						string text = Encoding.UTF8.GetString(buffer, 0, webSocketReceiveResult.Count);
						Debug.Log("stream command Received:\n" + text);
						CommandData item;
						try
						{
							item = JsonUtility.FromJson<CommandData>(text);
						}
						catch (Exception ex)
						{
							Debug.LogError("error parsing command: " + ex.Message);
							string s = "Unrecognized command: " + text + "\nUse one of: " + string.Join(", ", Enum.GetNames(typeof(Command))) + " in a message formatted like {\"command\": \"<command>\"}";
							byte[] bytes = Encoding.UTF8.GetBytes(s);
							await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, token);
							continue;
						}
						commandQueue.Enqueue(item);
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine("Error: " + ex2.Message);
			}
			finally
			{
				webSocket.Dispose();
			}
		}

		public void Dispose()
		{
			_isRunning = false;
			while (!_hasStopped)
			{
				Thread.Sleep(25);
			}
			_cancellationTokenSource.Dispose();
		}
	}

	private Unity.Mathematics.Random rnd;

	private StreamIntegrationEventsConfiguration streamIntegrationConfig;

	private ThreadSafeTimerSimple leaveSafeZoneTimer;

	private float safeZoneFadeTime;

	private int safeZoneState;

	private bool wasConnected;

	private ThreadSafeTimerSimple giftCoolDownTimer;

	private ThreadSafeTimerSimple giftKillAllCoolDownTimer;

	private ThreadSafeTimerSimple likesCoolDownTimer;

	private ThreadSafeTimerSimple textMessagesSummonTimer;

	private ThreadSafeTimerSimple textMessagesBuffTimer;

	private ThreadSafeTimerSimple textMessagesDebuffTimer;

	private ThreadSafeTimerSimple textMessagesBombsTimer;

	private float textMessagesSummonAggregationTime;

	private float textMessagesBuffAggregationTime;

	private float textMessagesDebuffAggregationTime;

	private float textMessagesBombsAggregationTime;

	private int textMessagesBuffAggregationCounter;

	private int textMessagesDebuffAggregationCounter;

	private int textMessagesSummonAggregationCounter;

	private int textMessagesBombsAggregationCounter;

	private Queue<CommandData> commandSummonQueue = new Queue<CommandData>();

	private Queue<CommandData> commandBuffQueue = new Queue<CommandData>();

	private Queue<CommandData> commandDebuffQueue = new Queue<CommandData>();

	private Queue<CommandData> killAllEnemiesQueue = new Queue<CommandData>();

	private Queue<CommandData> spawnBombsOnPlayerQueue = new Queue<CommandData>();

	private Queue<CommandData> likesQueue = new Queue<CommandData>();

	private int sumOfAllQueuedCommands;

	private SpawnedEnemyCounts spawnedEnemyCounts;

	private Dictionary<ObjectID, AreaLevel> itemLevelEnemyLookupCommon = new Dictionary<ObjectID, AreaLevel>();

	private Dictionary<ObjectID, AreaLevel> itemLevelEnemyLookupRare = new Dictionary<ObjectID, AreaLevel>();

	private Dictionary<ObjectID, AreaLevel> itemLevelEnemyLookupSpecial = new Dictionary<ObjectID, AreaLevel>();

	private bool generalInitDone;

	private NativeParallelHashMap<float3, float> occupiedBombPositions;

	private float bombPositionCleanUpInterval;

	private float bombPositionExpirationTime;

	private int addedLikeHpValue;

	private int addedLikeMpValue;

	private const string danmuCommandSummonI2 = "StreamIntegration/DanmuCommandSummon";

	private const string danmuCommandBuffI2 = "StreamIntegration/DanmuCommandBuff";

	private const string danmuCommandDebuffI2 = "StreamIntegration/DanmuCommandDebuff";

	private const string danmuCommandBombI2 = "StreamIntegration/DanmuCommandBomb";

	private const string giftCommandSummonI2 = "StreamIntegration/GiftCommandSummon";

	private const string giftCommandBuffI2 = "StreamIntegration/GiftCommandBuff";

	private const string giftCommandDebuffI2 = "StreamIntegration/GiftCommandDebuff";

	private const string giftCommandBombI2 = "StreamIntegration/GiftCommandBomb";

	private const string subscribedCommandI2 = "StreamIntegration/CommandSubscribe";

	private const string killAllEnemiesCommandI2 = "StreamIntegration/CommandKillAllEnemies";

	private const string supermanCommandI2 = "StreamIntegration/CommandSuperman";

	private const string likeCommandI2 = "StreamIntegration/CommandRestoreHealth";

	private const string itemCategoryI2 = "Items/";

	private const string nameCategoryI2 = "Names/";

	private const string conditionsCategoryI2 = "Conditions/";

	private const string streamerSafeZoneDesc = "StreamIntegration/StreamerSafeZoneDesc";

	private const string streamerLeavingSafeZoneDesc = "StreamIntegration/StreamerLeavingSafeZoneDesc";

	private const string streamInteractionPausedDesc = "StreamIntegration/StreamInteractionPausedDesc";

	private const string streamInteractionActiveDesc = "StreamIntegration/StreamInteractionActiveDesc";

	private const string interactionStreamDisconnectedDesc = "StreamIntegration/InteractionStreamDisconnectedDesc";

	private const string giftQueueTextI2 = "StreamIntegration/GiftQueueDesc";

	private const string streamInteractionIsNotEnabledByHost = "StreamIntegration/StreamInteractionNotActivatedByHost";

	private WebSocketServer _server;

	private Dictionary<Command, Action<CommandData>> _commandHandlers = new Dictionary<Command, Action<CommandData>>();

	private ConcurrentQueue<CommandData> _commandQueue = new ConcurrentQueue<CommandData>();

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("StreamManager.Init");

	public IStreamIntegrationManager StreamIntegrationManager { get; private set; }

	public bool IsStreamIntegrationEnabled { get; private set; }

	[Preserve]
	[Command("streamCommand.trigger", "Triggers a stream command for testing Twitch/BiliBili/etc integration", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void TriggerCommand(Command command)
	{
		Manager.stream.EnqueueCommand(new CommandData
		{
			command = command
		});
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			_commandHandlers.Add(Command.TextMessageBuff, DefaultCommandHandler);
			_commandHandlers.Add(Command.TextMessageSummon, DefaultCommandHandler);
			_commandHandlers.Add(Command.PaidGiftBuff, DefaultCommandHandler);
			_commandHandlers.Add(Command.PaidGiftSummon, DefaultCommandHandler);
			_commandHandlers.Add(Command.LikesSent, DefaultCommandHandler);
			_commandHandlers.Add(Command.PaidGiftKillAllEnemies, DefaultCommandHandler);
			_commandHandlers.Add(Command.UserSubscribed, DefaultCommandHandler);
			_commandHandlers.Add(Command.SuperChatMessage, DefaultCommandHandler);
			_commandHandlers.Add(Command.TextMessageBombsOnPlayer, DefaultCommandHandler);
			_commandHandlers.Add(Command.PaidGiftSpawnBombsOnPlayer, DefaultCommandHandler);
			if (CommandLineArgs.Has("-streamcommandserver"))
			{
				string text = CommandLineArgs.GetParam("-streamcommandserver");
				if (string.IsNullOrEmpty(text))
				{
					text = "http://localhost:4660/";
				}
				try
				{
					_server = new WebSocketServer(text, _commandQueue);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				IsStreamIntegrationEnabled = true;
			}
			else if (CommandLineArgs.Has("-bilibili"))
			{
				StreamIntegrationManager = new BiliBiliManager();
				if (!StreamIntegrationManager.Init())
				{
					Debug.LogError("StreamManager: stream integration manager init failed.");
					return false;
				}
				IsStreamIntegrationEnabled = true;
			}
			else
			{
				StreamIntegrationManager = new DummyStreamIntegrationManager();
			}
			return true;
		}
	}

	public override void Deinit()
	{
		if (_server != null)
		{
			_server.Dispose();
			_server = null;
		}
		base.Deinit();
	}

	public void InitsAfterConnect()
	{
		LoadConfigsAndVariables();
		InitsEnemyItemLevelLookups();
		StartCoroutine(CleanUpOccupiedBombPositionsRoutine());
		generalInitDone = true;
	}

	public void DeinitsAfterDisconnect()
	{
		StopCoroutine(CleanUpOccupiedBombPositionsRoutine());
		occupiedBombPositions.Dispose();
		generalInitDone = false;
	}

	public void AddCustomCommandHandler(Command command, Action<CommandData> handler)
	{
		_commandHandlers[command] = handler;
	}

	public void EnqueueCommand(CommandData command)
	{
		_commandQueue.Enqueue(command);
	}

	private void Update()
	{
		if (StreamIntegrationManager == null || !StreamIntegrationManager.IsRoomConnected())
		{
			return;
		}
		StreamIntegrationManager.Update();
		if (Manager.main.player != null)
		{
			if (!generalInitDone)
			{
				InitsAfterConnect();
			}
			CheckSurroundingEnemies(Manager.main.player);
			if (giftCoolDownTimer.IsTimerElapsed(Time.time))
			{
				if (commandSummonQueue.TryPeek(out var result))
				{
					HandlePaidGiftCommands(result);
				}
				if (commandBuffQueue.TryPeek(out var result2))
				{
					HandlePaidGiftCommands(result2);
				}
				if (commandDebuffQueue.TryPeek(out var result3))
				{
					HandlePaidGiftCommands(result3);
				}
				if (killAllEnemiesQueue.TryPeek(out var result4))
				{
					HandlePaidGiftCommands(result4);
				}
				if (spawnBombsOnPlayerQueue.TryPeek(out var result5))
				{
					HandlePaidGiftCommands(result5);
				}
				if (likesQueue.TryPeek(out var result6))
				{
					TryToPlayCommand(result6);
				}
			}
			HandleTextMessageCommands();
		}
		CommandData result7;
		while (_commandQueue.TryDequeue(out result7))
		{
			RunCommand(result7);
		}
	}

	private void LateUpdate()
	{
		UpdateStreamInformationTextsForHost();
		CheckIfPlayerIsInSafeZone();
	}

	private void CheckIfPlayerIsInSafeZone()
	{
		if (!StreamIntegrationManager.IsRoomConnected() || !Manager.networking.serverHasStreamIntegration || Manager.main.player == null)
		{
			return;
		}
		if (Vector3.Distance(Vector3.zero, Manager.main.player.WorldPosition) <= (float)streamIntegrationConfig.safeZoneRadius)
		{
			Manager.main.player.isInSafeZone = true;
			safeZoneState = 0;
			return;
		}
		if (safeZoneState == 0)
		{
			leaveSafeZoneTimer.Start(Time.time, safeZoneFadeTime);
			safeZoneState = 1;
		}
		if (leaveSafeZoneTimer.IsTimerElapsed(Time.time) && safeZoneState == 1)
		{
			Manager.main.player.isInSafeZone = false;
		}
	}

	private void UpdateStreamInformationTextsForHost()
	{
		string text = "";
		string str = "";
		if (StreamIntegrationManager.IsRoomConnected() && Manager.menu.menuStackCount <= 1)
		{
			wasConnected = true;
			if ((Manager.sceneHandler != null && !Manager.sceneHandler.isInGame && Manager.main.player == null) || Time.timeScale == 0f || Manager.load.IsSceneTransitionOrLoading())
			{
				str = "StreamIntegration/StreamInteractionPausedDesc";
				safeZoneState = 0;
			}
			else if (!Manager.networking.serverHasStreamIntegration)
			{
				str = "StreamIntegration/StreamInteractionNotActivatedByHost";
			}
			else if (safeZoneState == 0)
			{
				str = "StreamIntegration/StreamerSafeZoneDesc";
			}
			else if (safeZoneState == 1)
			{
				str = "StreamIntegration/StreamerLeavingSafeZoneDesc";
				if (leaveSafeZoneTimer.IsTimerElapsed(Time.time))
				{
					str = "StreamIntegration/StreamInteractionActiveDesc";
				}
			}
			text = PugText.ProcessText(str, new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
			sumOfAllQueuedCommands = commandBuffQueue.Count + commandSummonQueue.Count + commandDebuffQueue.Count + killAllEnemiesQueue.Count + spawnBombsOnPlayerQueue.Count;
			string text2 = PugText.ProcessText("StreamIntegration/GiftQueueDesc", new string[1] { sumOfAllQueuedCommands.ToString() }, shouldLocalize: true, shouldLocalizeFormatFields: false);
			Manager.ui.OnStreamIntegrationOpen(text + " - " + text2);
		}
		else if (!StreamIntegrationManager.IsRoomConnected() && wasConnected && Manager.menu.menuStackCount <= 1)
		{
			text = PugText.ProcessText("StreamIntegration/InteractionStreamDisconnectedDesc", new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
			Manager.ui.OnStreamIntegrationOpen(text);
			if (generalInitDone)
			{
				DeinitsAfterDisconnect();
			}
		}
		else if (Manager.ui.streamIntegrationInfoText.gameObject.activeSelf)
		{
			Manager.ui.OnStreamIntegrationClose();
		}
	}

	private void DefaultCommandHandler(CommandData commandData)
	{
		if (commandData.isTextMessage)
		{
			AggregateTextMessages(commandData);
		}
		if (commandData.isGift)
		{
			SortAndQueueGiftCommands(commandData);
		}
		if (commandData.command == Command.UserSubscribed)
		{
			SortAndQueueGiftCommands(commandData);
		}
		if (commandData.command == Command.LikesSent && !Manager.main.player.isInSafeZone)
		{
			likesQueue.Enqueue(commandData);
		}
		if (commandData.command == Command.SuperChatMessage)
		{
			Debug.Log(commandData.userName + " sent a SuperChat message.");
		}
	}

	private void HandleTextMessageCommands()
	{
		bool num = textMessagesBuffTimer.IsTimerElapsed(Time.realtimeSinceStartupAsDouble) && textMessagesBuffAggregationCounter > 0;
		bool flag = textMessagesDebuffTimer.IsTimerElapsed(Time.realtimeSinceStartupAsDouble) && textMessagesDebuffAggregationCounter > 0;
		bool flag2 = textMessagesSummonTimer.IsTimerElapsed(Time.realtimeSinceStartupAsDouble) && textMessagesSummonAggregationCounter > 0;
		bool flag3 = textMessagesBombsTimer.IsTimerElapsed(Time.realtimeSinceStartupAsDouble) && textMessagesBombsAggregationCounter > 0;
		if (num)
		{
			textMessagesBuffAggregationCounter = 0;
			CommandData commandData = new CommandData
			{
				command = Command.TextMessageBuff,
				isTextMessage = true
			};
			GeneratedDebuffBuffPotionToApply generatedDebuffBuffPotionToApply = GenerateDebuffBuffToApply(streamIntegrationConfig.buffPotionGroupsConfigurations, streamIntegrationConfig.debuffBuffPotionTextMessageProbability);
			if (generatedDebuffBuffPotionToApply.PotionID != ObjectID.None || generatedDebuffBuffPotionToApply.Condition.conditionID != ConditionID.None)
			{
				TryToPlayCommand(commandData, new GeneratedCommandsContainer
				{
					GeneratedDebuffBuffPotionToApply = generatedDebuffBuffPotionToApply
				});
			}
		}
		if (flag)
		{
			textMessagesDebuffAggregationCounter = 0;
			CommandData commandData2 = new CommandData
			{
				command = Command.TextMessageDebuff,
				isTextMessage = true
			};
			GeneratedDebuffBuffPotionToApply generatedDebuffBuffPotionToApply2 = GenerateDebuffBuffToApply(streamIntegrationConfig.debuffConfigurations, streamIntegrationConfig.debuffBuffPotionTextMessageProbability);
			if (generatedDebuffBuffPotionToApply2.PotionID != ObjectID.None || generatedDebuffBuffPotionToApply2.Condition.conditionID != ConditionID.None)
			{
				TryToPlayCommand(commandData2, new GeneratedCommandsContainer
				{
					GeneratedDebuffBuffPotionToApply = generatedDebuffBuffPotionToApply2
				});
			}
		}
		if (flag2)
		{
			textMessagesSummonAggregationCounter = 0;
			CommandData commandData3 = new CommandData
			{
				command = Command.TextMessageSummon,
				isTextMessage = true
			};
			GeneratedEnemyToSpawn generatedEnemyToSpawn = GenerateEnemyToSpawn(streamIntegrationConfig.enemyGroupsTextMessageProbability);
			if (generatedEnemyToSpawn.EnemyID != ObjectID.None)
			{
				TryToPlayCommand(commandData3, new GeneratedCommandsContainer
				{
					GeneratedEnemyToSpawn = generatedEnemyToSpawn
				});
			}
		}
		if (flag3)
		{
			textMessagesBombsAggregationCounter = 0;
			CommandData commandData4 = new CommandData
			{
				command = Command.TextMessageBombsOnPlayer,
				isTextMessage = true
			};
			GeneratedBombToSpawn generatedBombToSpawn = GenerateBombToSpawn(streamIntegrationConfig.bombsPoolTextMessageConfigurations);
			if (generatedBombToSpawn.BombID != ObjectID.None)
			{
				TryToPlayCommand(commandData4, new GeneratedCommandsContainer
				{
					GeneratedBombToSpawn = generatedBombToSpawn
				});
			}
		}
	}

	private void HandlePaidGiftCommands(CommandData commandData)
	{
		if (commandData.command == Command.PaidGiftBuff)
		{
			GeneratedDebuffBuffPotionToApply generatedDebuffBuffPotionToApply = GenerateDebuffBuffToApply(streamIntegrationConfig.buffPotionGroupsConfigurations, streamIntegrationConfig.debuffBuffPotionPaidGiftProbability);
			if ((generatedDebuffBuffPotionToApply.PotionID != ObjectID.None || generatedDebuffBuffPotionToApply.Condition.conditionID != ConditionID.None) && TryToPlayCommand(commandData, new GeneratedCommandsContainer
			{
				GeneratedDebuffBuffPotionToApply = generatedDebuffBuffPotionToApply
			}))
			{
				giftCoolDownTimer.Start(Time.time, 0.1f);
			}
		}
		if (commandData.command == Command.PaidGiftDebuff)
		{
			GeneratedDebuffBuffPotionToApply generatedDebuffBuffPotionToApply2 = GenerateDebuffBuffToApply(streamIntegrationConfig.debuffConfigurations, streamIntegrationConfig.debuffBuffPotionPaidGiftProbability);
			if ((generatedDebuffBuffPotionToApply2.PotionID != ObjectID.None || generatedDebuffBuffPotionToApply2.Condition.conditionID != ConditionID.None) && TryToPlayCommand(commandData, new GeneratedCommandsContainer
			{
				GeneratedDebuffBuffPotionToApply = generatedDebuffBuffPotionToApply2
			}))
			{
				giftCoolDownTimer.Start(Time.time, 0.1f);
			}
		}
		if (commandData.command == Command.PaidGiftSummon)
		{
			GeneratedEnemyToSpawn generatedEnemyToSpawn = GenerateEnemyToSpawn(streamIntegrationConfig.enemyGroupsPaidGiftProbability);
			if (generatedEnemyToSpawn.EnemyID != ObjectID.None && TryToPlayCommand(commandData, new GeneratedCommandsContainer
			{
				GeneratedEnemyToSpawn = generatedEnemyToSpawn
			}))
			{
				giftCoolDownTimer.Start(Time.time, 0.1f);
			}
		}
		if (commandData.command == Command.PaidGiftSpawnBombsOnPlayer)
		{
			GeneratedBombToSpawn generatedBombToSpawn = GenerateBombToSpawn(streamIntegrationConfig.bombsPoolPaidGiftConfigurations);
			if (generatedBombToSpawn.BombID != ObjectID.None && TryToPlayCommand(commandData, new GeneratedCommandsContainer
			{
				GeneratedBombToSpawn = generatedBombToSpawn
			}))
			{
				giftCoolDownTimer.Start(Time.time, 0.1f);
			}
		}
		if (commandData.command == Command.PaidGiftKillAllEnemies && TryToPlayCommand(commandData))
		{
			giftCoolDownTimer.Start(Time.time, 0.1f);
		}
		if (commandData.command == Command.UserSubscribed && TryToPlayCommand(commandData))
		{
			giftCoolDownTimer.Start(Time.time, 0.1f);
		}
	}

	private void SortAndQueueGiftCommands(CommandData commandData)
	{
		if (commandData.command == Command.PaidGiftBuff)
		{
			commandBuffQueue.Enqueue(commandData);
		}
		if (commandData.command == Command.PaidGiftDebuff)
		{
			commandDebuffQueue.Enqueue(commandData);
		}
		if (commandData.command == Command.PaidGiftSummon)
		{
			commandSummonQueue.Enqueue(commandData);
		}
		if (commandData.command == Command.PaidGiftKillAllEnemies)
		{
			killAllEnemiesQueue.Enqueue(commandData);
		}
		if (commandData.command == Command.UserSubscribed)
		{
			killAllEnemiesQueue.Enqueue(commandData);
		}
		if (commandData.command == Command.PaidGiftSpawnBombsOnPlayer)
		{
			spawnBombsOnPlayerQueue.Enqueue(commandData);
		}
	}

	private GeneratedEnemyToSpawn GenerateEnemyToSpawn(List<StreamIntegrationEventsConfiguration.EnemyGroupsProbability> probabilityForEnemyGroups)
	{
		float num = rnd.NextFloat(0f, 100f);
		int currItemLevel = GetItemLevelOfPlayer();
		if (num < probabilityForEnemyGroups[0].probability && streamIntegrationConfig.enemyPoolConfigurations.commonEnemies.Length != 0)
		{
			KeyValuePair<ObjectID, AreaLevel>[] array = itemLevelEnemyLookupCommon.Where((KeyValuePair<ObjectID, AreaLevel> pair) => (int)pair.Value <= currItemLevel).ToArray();
			ObjectID key = array[rnd.NextInt(0, array.Length)].Key;
			return new GeneratedEnemyToSpawn
			{
				EnemyID = key,
				Rarity = StreamIntegrationEventRarity.Common
			};
		}
		if (num < probabilityForEnemyGroups[0].probability + probabilityForEnemyGroups[1].probability && streamIntegrationConfig.enemyPoolConfigurations.rareEnemies.Length != 0)
		{
			KeyValuePair<ObjectID, AreaLevel>[] array2 = itemLevelEnemyLookupRare.Where((KeyValuePair<ObjectID, AreaLevel> pair) => (int)pair.Value <= currItemLevel).ToArray();
			ObjectID key2 = array2[rnd.NextInt(0, array2.Length)].Key;
			return new GeneratedEnemyToSpawn
			{
				EnemyID = key2,
				Rarity = StreamIntegrationEventRarity.Rare
			};
		}
		if (num < probabilityForEnemyGroups[0].probability + probabilityForEnemyGroups[1].probability + probabilityForEnemyGroups[2].probability && streamIntegrationConfig.enemyPoolConfigurations.specialEnemies.Length != 0)
		{
			KeyValuePair<ObjectID, AreaLevel>[] array3 = itemLevelEnemyLookupSpecial.Where((KeyValuePair<ObjectID, AreaLevel> pair) => (int)pair.Value <= currItemLevel).ToArray();
			ObjectID key3 = array3[rnd.NextInt(0, array3.Length)].Key;
			return new GeneratedEnemyToSpawn
			{
				EnemyID = key3,
				Rarity = StreamIntegrationEventRarity.Special
			};
		}
		return new GeneratedEnemyToSpawn
		{
			EnemyID = ObjectID.None
		};
	}

	private GeneratedDebuffBuffPotionToApply GenerateDebuffBuffToApply(StreamIntegrationEventsConfiguration.DebuffBuffPotionGroupsConfigurations debuffBuffPotionDebuffConfig, List<StreamIntegrationEventsConfiguration.DebuffBuffPotionGroupsProbability> probabilityForDebuffBuffPotionGroups)
	{
		float num = rnd.NextFloat(0f, 100f);
		if (num < probabilityForDebuffBuffPotionGroups[0].probability && debuffBuffPotionDebuffConfig.commonDebuffBuffPotions.Length != 0)
		{
			return DrawDebuffBuffFromConfigStructure(debuffBuffPotionDebuffConfig.commonDebuffBuffPotions, StreamIntegrationEventRarity.Common);
		}
		if (num < probabilityForDebuffBuffPotionGroups[0].probability + probabilityForDebuffBuffPotionGroups[1].probability && debuffBuffPotionDebuffConfig.rareDebuffBuffsPotions.Length != 0)
		{
			return DrawDebuffBuffFromConfigStructure(debuffBuffPotionDebuffConfig.rareDebuffBuffsPotions, StreamIntegrationEventRarity.Rare);
		}
		if (num < probabilityForDebuffBuffPotionGroups[0].probability + probabilityForDebuffBuffPotionGroups[1].probability + probabilityForDebuffBuffPotionGroups[2].probability && debuffBuffPotionDebuffConfig.specialDebuffBuffsPotions.Length != 0)
		{
			return DrawDebuffBuffFromConfigStructure(debuffBuffPotionDebuffConfig.specialDebuffBuffsPotions, StreamIntegrationEventRarity.Special);
		}
		return new GeneratedDebuffBuffPotionToApply
		{
			PotionID = ObjectID.None,
			Condition = default(ConditionData)
		};
	}

	private GeneratedBombToSpawn GenerateBombToSpawn(StreamIntegrationEventsConfiguration.BombGroupsConfigurations probabilityForBombGroups)
	{
		float num = rnd.NextFloat(0f, 100f);
		float num2 = 0f;
		StreamIntegrationEventsConfiguration.BombGroupsConfigurations.BombDataWithProbability[] bombs = probabilityForBombGroups.bombs;
		for (int i = 0; i < bombs.Length; i++)
		{
			StreamIntegrationEventsConfiguration.BombGroupsConfigurations.BombDataWithProbability bombDataWithProbability = bombs[i];
			num2 += bombDataWithProbability.probability;
			if (num < num2)
			{
				return new GeneratedBombToSpawn
				{
					BombID = bombDataWithProbability.objectId,
					PositionArea = probabilityForBombGroups.bombSpawnArea
				};
			}
		}
		return new GeneratedBombToSpawn
		{
			BombID = ObjectID.None,
			PositionArea = int2.zero
		};
	}

	private GeneratedDebuffBuffPotionToApply DrawDebuffBuffFromConfigStructure(StreamIntegrationEventsConfiguration.DebuffBuffPotionGroupsConfigurations.DebuffBuffPotionDataWithProbability[] debuffBuffData, StreamIntegrationEventRarity buffPotionRarity)
	{
		float num = rnd.NextFloat(0f, 100f);
		float num2 = 0f;
		for (int i = 0; i < debuffBuffData.Length; i++)
		{
			StreamIntegrationEventsConfiguration.DebuffBuffPotionGroupsConfigurations.DebuffBuffPotionDataWithProbability debuffBuffPotionDataWithProbability = debuffBuffData[i];
			num2 += debuffBuffPotionDataWithProbability.probabilityToBeApplied;
			if (num < num2)
			{
				return new GeneratedDebuffBuffPotionToApply
				{
					PotionID = debuffBuffPotionDataWithProbability.objectId,
					Condition = debuffBuffPotionDataWithProbability.condition,
					DurationForTextMessages = debuffBuffPotionDataWithProbability.durationForTextMessages,
					DurationForSentGifts = debuffBuffPotionDataWithProbability.durationForSentGifts,
					Rarity = buffPotionRarity
				};
			}
		}
		return new GeneratedDebuffBuffPotionToApply
		{
			PotionID = ObjectID.None,
			Condition = default(ConditionData)
		};
	}

	private bool ApplyDebuffBuff(CommandData commandData, GeneratedDebuffBuffPotionToApply debuffBuffPotionData)
	{
		List<ConditionData> list = new List<ConditionData>();
		bool result = false;
		if (debuffBuffPotionData.PotionID != ObjectID.None)
		{
			foreach (GivesConditionsWhenConsumedBuffer item in PugDatabase.GetBuffer<GivesConditionsWhenConsumedBuffer>(debuffBuffPotionData.PotionID))
			{
				ConditionData conditionData = item.conditionDataContainer.conditionData;
				conditionData.duration = ChangeDurationDependingOnCommandType(commandData, debuffBuffPotionData, conditionData);
				list.Add(conditionData);
			}
		}
		else if (debuffBuffPotionData.Condition.conditionID != ConditionID.None)
		{
			ConditionData condition = debuffBuffPotionData.Condition;
			condition.duration = ChangeDurationDependingOnCommandType(commandData, debuffBuffPotionData, condition);
			list.Add(condition);
		}
		if (list.Count > 0)
		{
			foreach (PlayerController allPlayer in Manager.main.allPlayers)
			{
				foreach (ConditionData item2 in list)
				{
					if (item2.conditionID == ConditionID.Superman)
					{
						Manager.main.player.playerCommandSystem.EnableSuperManForStreamIntegration(allPlayer.entity, 1f, item2.duration);
					}
					else
					{
						Manager.main.player.playerCommandSystem.AddOrRefreshCondition(allPlayer.entity, item2.conditionID, item2.value, item2.duration);
					}
				}
				result = true;
			}
		}
		return result;
	}

	private float ChangeDurationDependingOnCommandType(CommandData commandData, GeneratedDebuffBuffPotionToApply debuffBuffPotionData, ConditionData conditionData)
	{
		if (commandData.isTextMessage && debuffBuffPotionData.DurationForTextMessages > 0f)
		{
			return debuffBuffPotionData.DurationForTextMessages;
		}
		if (commandData.isGift && debuffBuffPotionData.DurationForSentGifts > 0f)
		{
			return debuffBuffPotionData.DurationForSentGifts;
		}
		return conditionData.duration;
	}

	private bool TryToPlayCommand(CommandData commandData, GeneratedCommandsContainer generatedContainer = default(GeneratedCommandsContainer))
	{
		if (Time.timeScale != 0f && Manager.sceneHandler != null && Manager.sceneHandler.isInGame && !Manager.main.player.isInSafeZone && Manager.main.player != null && !Manager.load.IsSceneTransitionOrLoading() && Manager.networking.serverHasStreamIntegration && leaveSafeZoneTimer.IsTimerElapsed(Time.time))
		{
			string text = "";
			switch (commandData.command)
			{
			case Command.TextMessageBuff:
				if (ApplyDebuffBuff(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply))
				{
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetItemOrConditionBuffDebuffText(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply));
					return true;
				}
				return false;
			case Command.TextMessageDebuff:
				if (ApplyDebuffBuff(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply))
				{
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetItemOrConditionBuffDebuffText(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply));
					return true;
				}
				return false;
			case Command.TextMessageSummon:
				if (SpawnEnemy(generatedContainer.GeneratedEnemyToSpawn))
				{
					IncrementEnemiesCount(generatedContainer.GeneratedEnemyToSpawn.Rarity);
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetEnemyToSpawnText(commandData, generatedContainer.GeneratedEnemyToSpawn));
					return true;
				}
				return false;
			case Command.TextMessageBombsOnPlayer:
				if (SpawnBombAroundPlayer(generatedContainer.GeneratedBombToSpawn))
				{
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetBombToSpawnText(commandData, generatedContainer.GeneratedBombToSpawn));
					return true;
				}
				return false;
			case Command.PaidGiftSummon:
				if (SpawnEnemy(generatedContainer.GeneratedEnemyToSpawn))
				{
					IncrementEnemiesCount(generatedContainer.GeneratedEnemyToSpawn.Rarity);
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetEnemyToSpawnText(commandData, generatedContainer.GeneratedEnemyToSpawn));
					commandSummonQueue.Dequeue();
					return true;
				}
				return false;
			case Command.PaidGiftBuff:
				if (ApplyDebuffBuff(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply))
				{
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetItemOrConditionBuffDebuffText(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply));
					commandBuffQueue.Dequeue();
					return true;
				}
				return false;
			case Command.PaidGiftDebuff:
				if (ApplyDebuffBuff(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply))
				{
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetItemOrConditionBuffDebuffText(commandData, generatedContainer.GeneratedDebuffBuffPotionToApply));
					commandDebuffQueue.Dequeue();
					return true;
				}
				return false;
			case Command.PaidGiftKillAllEnemies:
				if (KillEnemies())
				{
					killAllEnemiesQueue.Dequeue();
					text = PugText.ProcessText("StreamIntegration/CommandKillAllEnemies", new string[4]
					{
						commandData.userName,
						commandData.giftName,
						"",
						Manager.main.player.playerName
					}, shouldLocalize: true, shouldLocalizeFormatFields: false);
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(text);
					return true;
				}
				return false;
			case Command.PaidGiftSpawnBombsOnPlayer:
				if (SpawnBombAroundPlayer(generatedContainer.GeneratedBombToSpawn))
				{
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(GetBombToSpawnText(commandData, generatedContainer.GeneratedBombToSpawn));
					spawnBombsOnPlayerQueue.Dequeue();
					return true;
				}
				return false;
			case Command.UserSubscribed:
				if (KillEnemies())
				{
					killAllEnemiesQueue.Dequeue();
					text = PugText.ProcessText("StreamIntegration/CommandSubscribe", new string[4]
					{
						commandData.userName,
						"",
						"",
						Manager.main.player.playerName
					}, shouldLocalize: true, shouldLocalizeFormatFields: false);
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(text);
					return true;
				}
				return false;
			case Command.LikesSent:
				if (ApplyHealthRestoreThroughLikes())
				{
					text = PugText.ProcessText("StreamIntegration/CommandRestoreHealth", new string[4]
					{
						commandData.userName,
						addedLikeHpValue.ToString(),
						addedLikeMpValue.ToString(),
						Manager.main.player.playerName
					}, shouldLocalize: true, shouldLocalizeFormatFields: false);
					Manager.ui.chatWindow.BroadcastStreamIntegrationInfoTextToAllPlayers(text);
					return true;
				}
				return false;
			}
		}
		return false;
	}

	private bool SpawnEnemy(GeneratedEnemyToSpawn generatedEnemyToSpawn)
	{
		if (spawnedEnemyCounts.CommonEnemiesCount >= streamIntegrationConfig.maxEnemiesOnScreenPerRarity.maximumCommonEnemies && generatedEnemyToSpawn.Rarity == StreamIntegrationEventRarity.Common)
		{
			return false;
		}
		if (spawnedEnemyCounts.RareEnemiesCount >= streamIntegrationConfig.maxEnemiesOnScreenPerRarity.maximumRareEnemies && generatedEnemyToSpawn.Rarity == StreamIntegrationEventRarity.Rare)
		{
			return false;
		}
		if (spawnedEnemyCounts.SpecialEnemiesCount >= streamIntegrationConfig.maxEnemiesOnScreenPerRarity.maximumSpecialEnemies && generatedEnemyToSpawn.Rarity == StreamIntegrationEventRarity.Special)
		{
			return false;
		}
		if (generatedEnemyToSpawn.EnemyID != ObjectID.None)
		{
			int num = ((generatedEnemyToSpawn.EnemyID == ObjectID.SlimeBoss) ? 6 : 2);
			Vector3 vector = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 0f, UnityEngine.Random.Range(-0.5f, 0.5f));
			PlayerController player = Manager.main.player;
			player.playerCommandSystem.CreateEntityForStreamIntegration(generatedEnemyToSpawn.EnemyID, player.transform.position + player.facingDirection.vec3 * num + vector);
			return true;
		}
		return false;
	}

	private bool SpawnBombAroundPlayer(GeneratedBombToSpawn generatedBombToSpawn)
	{
		PlayerController player = Manager.main.player;
		List<float3> freePositionsForBombSpawn = GetFreePositionsForBombSpawn(player.WorldPosition.RoundToInt2(), generatedBombToSpawn.PositionArea);
		if (freePositionsForBombSpawn.Count == 0)
		{
			return false;
		}
		float3 float5 = freePositionsForBombSpawn[rnd.NextInt(0, freePositionsForBombSpawn.Count)];
		occupiedBombPositions.Add(float5, Time.time);
		player.playerCommandSystem.CreateMortarEntityForStreamIntegration(generatedBombToSpawn.BombID, EntityMonoBehaviour.ToRenderFromWorld(float5), 30);
		return true;
	}

	private bool ApplyHealthRestoreThroughLikes()
	{
		PlayerController player = Manager.main.player;
		if (player.currentHealth != player.GetMaxHealth())
		{
			if (likesCoolDownTimer.IsTimerElapsed(Time.time))
			{
				likesCoolDownTimer.Start(Time.time, 0.4f);
				likesQueue.Dequeue();
				if (streamIntegrationConfig.amountOfHpMpToRestoreWhenLiked.convertToPercentage)
				{
					addedLikeHpValue = (int)math.round((float)player.GetMaxHealth() * streamIntegrationConfig.amountOfHpMpToRestoreWhenLiked.amountOfHP / 100f);
					addedLikeMpValue = (int)math.round((float)player.GetMaxMana() * streamIntegrationConfig.amountOfHpMpToRestoreWhenLiked.amountOfMP / 100f);
				}
				else
				{
					addedLikeHpValue = (int)math.round(streamIntegrationConfig.amountOfHpMpToRestoreWhenLiked.amountOfHP);
					addedLikeMpValue = (int)math.round(streamIntegrationConfig.amountOfHpMpToRestoreWhenLiked.amountOfMP);
				}
				player.playerCommandSystem.SetHealthForStreamIntegration(player.entity, player.currentHealth + addedLikeHpValue);
				player.playerCommandSystem.SetPlayerManaForStreamIntegration(player.entity, player.GetMana() + addedLikeMpValue);
				return true;
			}
		}
		else
		{
			likesQueue.Dequeue();
		}
		return false;
	}

	private bool KillEnemies()
	{
		if ((spawnedEnemyCounts.CommonEnemiesCount > 0 || spawnedEnemyCounts.RareEnemiesCount > 0 || spawnedEnemyCounts.SpecialEnemiesCount > 0) && giftKillAllCoolDownTimer.IsTimerElapsed(Time.time))
		{
			Manager.main.player.playerCommandSystem.DestroyAllEntitiesForStreamIntegration(Manager.main.player.RenderPosition);
			spawnedEnemyCounts.CommonEnemiesCount = 0;
			spawnedEnemyCounts.RareEnemiesCount = 0;
			spawnedEnemyCounts.SpecialEnemiesCount = 0;
			giftKillAllCoolDownTimer.Start(Time.time, 0.4f);
			return true;
		}
		return false;
	}

	private void CheckSurroundingEnemies(PlayerController player)
	{
		CollisionWorld collisionWorld = PhysicsManager.GetCollisionWorld();
		NativeList<ColliderCastHit> outHits = new NativeList<ColliderCastHit>(Allocator.Temp);
		spawnedEnemyCounts.CommonEnemiesCount = 0;
		spawnedEnemyCounts.RareEnemiesCount = 0;
		spawnedEnemyCounts.SpecialEnemiesCount = 0;
		if (!collisionWorld.SphereCastAll(player.WorldPosition, 10f, float3.zero, 0f, ref outHits, new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 16u
		}))
		{
			return;
		}
		foreach (ColliderCastHit item in outHits)
		{
			if (EntityUtility.TryGetComponentData<ObjectDataCD>(item.Entity, Manager.ecs.ClientWorld, out var value))
			{
				if (streamIntegrationConfig.enemyPoolConfigurations.commonEnemies.Contains(value.objectID))
				{
					IncrementEnemiesCount(StreamIntegrationEventRarity.Common);
				}
				else if (streamIntegrationConfig.enemyPoolConfigurations.rareEnemies.Contains(value.objectID))
				{
					IncrementEnemiesCount(StreamIntegrationEventRarity.Rare);
				}
				else if (streamIntegrationConfig.enemyPoolConfigurations.specialEnemies.Contains(value.objectID))
				{
					IncrementEnemiesCount(StreamIntegrationEventRarity.Special);
				}
			}
		}
		outHits.Dispose();
	}

	private void IncrementEnemiesCount(StreamIntegrationEventRarity rarity)
	{
		switch (rarity)
		{
		case StreamIntegrationEventRarity.Common:
			spawnedEnemyCounts.CommonEnemiesCount++;
			break;
		case StreamIntegrationEventRarity.Rare:
			spawnedEnemyCounts.RareEnemiesCount++;
			break;
		case StreamIntegrationEventRarity.Special:
			spawnedEnemyCounts.SpecialEnemiesCount++;
			break;
		}
	}

	private string GetItemOrConditionBuffDebuffText(CommandData commandData, GeneratedDebuffBuffPotionToApply debuffBuffPotionData)
	{
		string result = "";
		string text = "";
		string text2 = "";
		if (commandData.command == Command.PaidGiftDebuff || commandData.command == Command.TextMessageDebuff)
		{
			text = "StreamIntegration/DanmuCommandDebuff";
			text2 = "StreamIntegration/GiftCommandDebuff";
		}
		else
		{
			text = "StreamIntegration/DanmuCommandBuff";
			text2 = "StreamIntegration/GiftCommandBuff";
		}
		if (debuffBuffPotionData.PotionID != ObjectID.None)
		{
			string text3 = "";
			if (commandData.isTextMessage)
			{
				text3 = PugText.ProcessText("Items/" + debuffBuffPotionData.PotionID, new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
				result = PugText.ProcessText(text, new string[1] { text3 }, shouldLocalize: true, shouldLocalizeFormatFields: false);
			}
			else if (commandData.isGift)
			{
				text3 = PugText.ProcessText("Items/" + debuffBuffPotionData.PotionID, new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
				result = PugText.ProcessText(text2, new string[3] { commandData.userName, commandData.giftName, text3 }, shouldLocalize: true, shouldLocalizeFormatFields: false);
			}
		}
		else if (debuffBuffPotionData.Condition.conditionID != ConditionID.None)
		{
			string text4 = "";
			ConditionID useSameDescAsId = Manager.ui.conditionsIconsTable.GetConditionInfo(debuffBuffPotionData.Condition.conditionID).useSameDescAsId;
			ConditionID conditionID = debuffBuffPotionData.Condition.conditionID;
			if (useSameDescAsId != ConditionID.None)
			{
				conditionID = useSameDescAsId;
			}
			if (commandData.isTextMessage)
			{
				if (debuffBuffPotionData.Condition.conditionID == ConditionID.Superman)
				{
					text4 = PugText.ProcessText("StreamIntegration/CommandSuperman", new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
					result = PugText.ProcessText(text, new string[1] { text4 }, shouldLocalize: true, shouldLocalizeFormatFields: false);
				}
				else
				{
					text4 = PugText.ProcessText("Conditions/" + conditionID, new string[1] { debuffBuffPotionData.Condition.value.ToString() }, shouldLocalize: true, shouldLocalizeFormatFields: false);
					result = PugText.ProcessText(text, new string[1] { text4 }, shouldLocalize: true, shouldLocalizeFormatFields: false);
				}
			}
			else if (commandData.isGift)
			{
				if (debuffBuffPotionData.Condition.conditionID == ConditionID.Superman)
				{
					text4 = PugText.ProcessText("StreamIntegration/CommandSuperman", new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
					result = PugText.ProcessText(text2, new string[3] { commandData.userName, commandData.giftName, text4 }, shouldLocalize: true, shouldLocalizeFormatFields: false);
				}
				else
				{
					text4 = PugText.ProcessText("Conditions/" + conditionID, new string[1] { debuffBuffPotionData.Condition.value.ToString() }, shouldLocalize: true, shouldLocalizeFormatFields: false);
					result = PugText.ProcessText(text2, new string[3] { commandData.userName, commandData.giftName, text4 }, shouldLocalize: true, shouldLocalizeFormatFields: false);
				}
			}
		}
		return result;
	}

	private string GetEnemyToSpawnText(CommandData commandData, GeneratedEnemyToSpawn generatedEnemyToSpawn)
	{
		string text = "Items/";
		string text2 = "";
		if (PugDatabase.HasComponent<BossCD>(generatedEnemyToSpawn.EnemyID))
		{
			text = "Names/";
		}
		string text3 = PugText.ProcessText(text + generatedEnemyToSpawn.EnemyID, new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
		if (commandData.isGift)
		{
			return PugText.ProcessText("StreamIntegration/GiftCommandSummon", new string[4]
			{
				commandData.userName,
				commandData.giftName,
				text3,
				Manager.main.player.playerName
			}, shouldLocalize: true, shouldLocalizeFormatFields: false);
		}
		return PugText.ProcessText("StreamIntegration/DanmuCommandSummon", new string[2]
		{
			text3,
			Manager.main.player.playerName
		}, shouldLocalize: true, shouldLocalizeFormatFields: false);
	}

	private string GetBombToSpawnText(CommandData commandData, GeneratedBombToSpawn generatedBombToSpawn)
	{
		string text = "";
		string text2 = PugText.ProcessText("Items/" + PugDatabase.GetComponent<SpawnEntityOnDeathCD>(generatedBombToSpawn.BombID).objectToSpawn, new string[0], shouldLocalize: true, shouldLocalizeFormatFields: false);
		if (commandData.isGift)
		{
			return PugText.ProcessText("StreamIntegration/GiftCommandBomb", new string[4]
			{
				commandData.userName,
				commandData.giftName,
				text2,
				Manager.main.player.playerName
			}, shouldLocalize: true, shouldLocalizeFormatFields: false);
		}
		return PugText.ProcessText("StreamIntegration/DanmuCommandBomb", new string[2]
		{
			text2,
			Manager.main.player.playerName
		}, shouldLocalize: true, shouldLocalizeFormatFields: false);
	}

	private List<float3> GetFreePositionsForBombSpawn(int2 playerPosition, int2 size)
	{
		CollisionWorld collisionWorld = PhysicsManager.GetCollisionWorld();
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		List<float3> list = new List<float3>();
		int2 int5 = math.ceil(size / 2).RoundToInt2();
		for (int i = 0; i < size.y; i++)
		{
			for (int j = 0; j < size.x; j++)
			{
				int x = j - int5.x;
				int y = i - int5.y;
				int2 worldPosition = playerPosition + new int2(x, y);
				if (!tileLayerLookup.GetTopTile(worldPosition).tileType.IsWalkableTile())
				{
					continue;
				}
				CollisionFilter filter = new CollisionFilter
				{
					BelongsTo = uint.MaxValue,
					CollidesWith = 131413u
				};
				if (!collisionWorld.CheckSphere(new float3(worldPosition.x, 0.25f, worldPosition.y), 0.49f, filter))
				{
					float3 float5 = new float3(worldPosition.x, 0f, worldPosition.y);
					if (!occupiedBombPositions.ContainsKey(float5))
					{
						list.Add(float5);
					}
				}
			}
		}
		return list;
	}

	private int GetItemLevelOfPlayer()
	{
		return (from handler in Manager.main.player.equipmentHandler.getAllItemInventoryHandlers()
			where handler.GetContainedObjectData(0).amount > 0
			select handler.GetObjectData(0)).Sum((ObjectDataCD objectData) => (objectData.variation <= 0) ? PugDatabase.GetComponent<LevelCD>(objectData).level : objectData.variation);
	}

	private IEnumerator CleanUpOccupiedBombPositionsRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(bombPositionCleanUpInterval);
			if (!occupiedBombPositions.IsCreated)
			{
				break;
			}
			List<float3> list = new List<float3>();
			foreach (KeyValue<float3, float> occupiedBombPosition in occupiedBombPositions)
			{
				if (Time.time - occupiedBombPosition.Value > bombPositionExpirationTime)
				{
					list.Add(occupiedBombPosition.Key);
				}
			}
			foreach (float3 item in list)
			{
				occupiedBombPositions.Remove(item);
			}
		}
	}

	private void InitsEnemyItemLevelLookups()
	{
		ObjectID[] commonEnemies = streamIntegrationConfig.enemyPoolConfigurations.commonEnemies;
		foreach (ObjectID objectID in commonEnemies)
		{
			LevelCD component = PugDatabase.GetComponent<LevelCD>(objectID);
			itemLevelEnemyLookupCommon.TryAdd(objectID, component.areaLevel);
		}
		commonEnemies = streamIntegrationConfig.enemyPoolConfigurations.rareEnemies;
		foreach (ObjectID objectID2 in commonEnemies)
		{
			LevelCD component2 = PugDatabase.GetComponent<LevelCD>(objectID2);
			itemLevelEnemyLookupRare.TryAdd(objectID2, component2.areaLevel);
		}
		commonEnemies = streamIntegrationConfig.enemyPoolConfigurations.specialEnemies;
		foreach (ObjectID objectID3 in commonEnemies)
		{
			LevelCD component3 = PugDatabase.GetComponent<LevelCD>(objectID3);
			itemLevelEnemyLookupSpecial.TryAdd(objectID3, component3.areaLevel);
		}
	}

	private void LoadConfigsAndVariables()
	{
		rnd = PugRandom.GetRng();
		streamIntegrationConfig = Resources.Load<StreamIntegrationEventsConfiguration>("Platform/StreamIntegrationEventsConfiguration");
		safeZoneFadeTime = streamIntegrationConfig.safeZoneFadeTime;
		occupiedBombPositions = new NativeParallelHashMap<float3, float>(32, Allocator.Persistent);
		bombPositionCleanUpInterval = streamIntegrationConfig.bombPositionCleanUpConfigurations.cleanUpInterval;
		bombPositionExpirationTime = streamIntegrationConfig.bombPositionCleanUpConfigurations.posExpirationTime;
		textMessagesBuffAggregationCounter = 0;
		textMessagesDebuffAggregationCounter = 0;
		textMessagesSummonAggregationCounter = 0;
		textMessagesSummonAggregationTime = streamIntegrationConfig.textMessagesSummonAggregationTime;
		textMessagesBuffAggregationTime = streamIntegrationConfig.textMessagesBuffAggregationTime;
		textMessagesDebuffAggregationTime = streamIntegrationConfig.textMessagesDebuffAggregationTime;
		textMessagesBombsAggregationTime = streamIntegrationConfig.textMessagesBombsAggregationTime;
	}

	private void RunCommand(CommandData command)
	{
		if (_commandHandlers.TryGetValue(command.command, out var value))
		{
			value(command);
		}
		else
		{
			Debug.Log($"No handler for stream command: {command}");
		}
	}

	private void AggregateTextMessages(CommandData commandData)
	{
		switch (commandData.command)
		{
		case Command.TextMessageBuff:
			StartTextMessageAggregationTimer(ref textMessagesBuffTimer, textMessagesBuffAggregationTime);
			textMessagesBuffAggregationCounter++;
			break;
		case Command.TextMessageDebuff:
			StartTextMessageAggregationTimer(ref textMessagesDebuffTimer, textMessagesDebuffAggregationTime);
			textMessagesDebuffAggregationCounter++;
			break;
		case Command.TextMessageSummon:
			StartTextMessageAggregationTimer(ref textMessagesSummonTimer, textMessagesSummonAggregationTime);
			textMessagesSummonAggregationCounter++;
			break;
		case Command.TextMessageBombsOnPlayer:
			StartTextMessageAggregationTimer(ref textMessagesBombsTimer, textMessagesBombsAggregationTime);
			textMessagesBombsAggregationCounter++;
			break;
		}
	}

	private void StartTextMessageAggregationTimer(ref ThreadSafeTimerSimple timer, float aggregationTime)
	{
		double realtimeSinceStartupAsDouble = Time.realtimeSinceStartupAsDouble;
		if (timer.IsTimerElapsed(realtimeSinceStartupAsDouble) || !timer.isRunning)
		{
			timer.Start(realtimeSinceStartupAsDouble, aggregationTime);
		}
	}
}
