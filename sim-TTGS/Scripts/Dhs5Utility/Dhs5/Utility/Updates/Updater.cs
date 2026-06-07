using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Dhs5.Utility.PlayerLoops;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Dhs5.Utility.Updates
{
	public sealed class Updater : IPlayerLoopModifier
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct AfterEarlyUpdate
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(AfterEarlyUpdate),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct BeforeUpdate
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(BeforeUpdate),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct AfterUpdate
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(AfterUpdate),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct AfterLateUpdate
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(AfterLateUpdate),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct UpdaterTimeUpdate
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(UpdaterTimeUpdate),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct UpdaterInitialization
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(UpdaterInitialization),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct UpdaterEndFrame
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(UpdaterEndFrame),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct BeforeFixedUpdate
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(BeforeFixedUpdate),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct AfterPhysicsFixedUpdate
		{
			public static PlayerLoopSystem GetSystem(PlayerLoopSystem.UpdateFunction updateFunction)
			{
				return new PlayerLoopSystem
				{
					type = typeof(AfterPhysicsFixedUpdate),
					updateDelegate = updateFunction
				};
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct DefaultUpdateChannel
		{
		}

		private class UpdateChannel
		{
			public readonly EUpdateChannel channel;

			public readonly Type type;

			public readonly EUpdatePass pass;

			public readonly ushort order;

			public readonly EUpdateCondition condition;

			public readonly bool realtime;

			private bool customFrequency;

			private float frequency;

			public bool Enabled { get; set; }

			public float Timescale { get; set; }

			public float TimeSinceLastUpdate { get; private set; }

			public float Frequency
			{
				get
				{
					return frequency;
				}
				set
				{
					frequency = value;
					customFrequency = value > 0f;
				}
			}

			public bool HasFixedDeltaTime
			{
				get
				{
					EUpdatePass eUpdatePass = pass;
					return eUpdatePass == EUpdatePass.BEFORE_FIXED_UPDATE || eUpdatePass == EUpdatePass.AFTER_PHYSICS_FIXED_UPDATE;
				}
			}

			public UpdateChannel(IUpdateChannel updateChannel)
			{
				channel = updateChannel.Channel;
				type = channel.GetChannelType();
				pass = updateChannel.Pass;
				order = updateChannel.Order;
				condition = updateChannel.Condition;
				realtime = updateChannel.Realtime;
				Enabled = updateChannel.EnabledByDefault;
				Frequency = updateChannel.Frequency;
				Timescale = updateChannel.TimeScale;
				TimeSinceLastUpdate = 0f;
			}

			public bool Update(float deltaTime, out float actualDeltaTime)
			{
				if (HasFixedDeltaTime)
				{
					actualDeltaTime = UnityEngine.Time.fixedDeltaTime;
					return true;
				}
				if (!customFrequency)
				{
					actualDeltaTime = deltaTime;
					return true;
				}
				TimeSinceLastUpdate += deltaTime * Timescale;
				actualDeltaTime = TimeSinceLastUpdate;
				if (TimeSinceLastUpdate >= Frequency)
				{
					TimeSinceLastUpdate -= Frequency;
					return true;
				}
				return false;
			}
		}

		private abstract class DelayedCall
		{
			public readonly EUpdatePass pass;

			public readonly EUpdateCondition condition;

			protected Action m_callback;

			public DelayedCall(EUpdatePass pass, EUpdateCondition condition, Action callback)
			{
				this.pass = pass;
				this.condition = condition;
				m_callback = callback;
			}

			public abstract bool Update(float deltaTime);
		}

		private class TimedDelayedCall : DelayedCall
		{
			private float m_remainingTime;

			public TimedDelayedCall(float delay, EUpdatePass pass, EUpdateCondition condition, Action callback)
				: base(pass, condition, callback)
			{
				m_remainingTime = delay;
			}

			public override bool Update(float deltaTime)
			{
				m_remainingTime -= deltaTime;
				if (m_remainingTime <= 0f)
				{
					m_callback?.Invoke();
					return true;
				}
				return false;
			}

			public float GetRemainingTime()
			{
				return m_remainingTime;
			}
		}

		private class FrameDelayedCall : DelayedCall
		{
			private int m_remainingFrames;

			public FrameDelayedCall(int framesToWait, EUpdatePass pass, EUpdateCondition condition, Action callback)
				: base(pass, condition, callback)
			{
				m_remainingFrames = framesToWait;
			}

			public override bool Update(float deltaTime)
			{
				m_remainingFrames--;
				if (m_remainingFrames == 0)
				{
					m_callback?.Invoke();
					return true;
				}
				return false;
			}

			public int GetRemainingFrames()
			{
				return m_remainingFrames;
			}
		}

		private class WaitDelayedCall : DelayedCall
		{
			private Func<bool> m_predicate;

			private bool m_waitUntil;

			public WaitDelayedCall(Func<bool> predicate, bool waitUntil, EUpdatePass pass, EUpdateCondition condition, Action callback)
				: base(pass, condition, callback)
			{
				m_predicate = predicate;
				m_waitUntil = waitUntil;
			}

			public override bool Update(float deltaTime)
			{
				if (m_predicate() == m_waitUntil)
				{
					m_callback?.Invoke();
					return true;
				}
				return false;
			}
		}

		private List<EUpdatePass> m_currentFramePasses = new List<EUpdatePass>();

		private readonly Dictionary<int, UpdateChannel> m_channels = new Dictionary<int, UpdateChannel>();

		private readonly Dictionary<int, UpdateCallback> m_channelCallbacks = new Dictionary<int, UpdateCallback>();

		private readonly Dictionary<ulong, UpdateTimelineInstance> m_updateTimelineInstances = new Dictionary<ulong, UpdateTimelineInstance>();

		private readonly Dictionary<ulong, DelayedCall> m_delayedCalls = new Dictionary<ulong, DelayedCall>();

		private readonly Dictionary<ulong, DelayedCall> m_delayedCallsToRegister = new Dictionary<ulong, DelayedCall>();

		private static ulong _registrationCount;

		internal static Updater Instance { get; private set; }

		public static float Time { get; private set; }

		public static float DeltaTime { get; private set; }

		public static float RealTime { get; private set; }

		public static float RealDeltaTime { get; private set; }

		public static int Frame { get; private set; }

		public static bool TimePaused { get; private set; }

		public static IUpdaterOverrider Overrider { get; set; }

		public int Priority => 0;

		public static event UpdateCallback OnUpdateAfterEarly;

		public static event UpdateCallback OnUpdateClassic;

		public static event UpdateCallback OnUpdateAfterClassic;

		public static event UpdateCallback OnUpdateAfterLate;

		public static event UpdateCallback OnUpdateBeforeFixed;

		public static event UpdateCallback OnUpdateAfterPhysicsFixed;

		public static event Action OneShotAfterEarlyUpdate;

		public static event Action OneShotClassicUpdate;

		public static event Action OneShotAfterClassicUpdate;

		public static event Action OneShotAfterLateUpdate;

		public static event Action OneShotBeforeFixedUpdate;

		public static event Action OneShotAfterPhysicsFixedUpdate;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitBeforeSceneLoad()
		{
			Instance = new Updater();
			PlayerLoopManager.RegisterModifier(Instance);
		}

		private Updater()
		{
			PlayerLoopManager.PlayerLoopInitialized += OnPlayerLoopInitialized;
			InitChannels();
		}

		public PlayerLoopSystem ModifyPlayerLoop(PlayerLoopSystem playerLoopSystem)
		{
			List<PlayerLoopSystem> list = playerLoopSystem.subSystemList.ToList();
			PlayerLoopSystem value = list[0];
			List<PlayerLoopSystem> list2 = list[0].subSystemList.ToList();
			list2.Add(UpdaterTimeUpdate.GetSystem(OnTimeUpdate));
			value.subSystemList = list2.ToArray();
			list[0] = value;
			PlayerLoopSystem value2 = list[1];
			List<PlayerLoopSystem> list3 = list[1].subSystemList.ToList();
			list3.Add(UpdaterInitialization.GetSystem(OnInitializationUpdate));
			value2.subSystemList = list3.ToArray();
			list[1] = value2;
			PlayerLoopSystem value3 = list[3];
			List<PlayerLoopSystem> list4 = value3.subSystemList.ToList();
			list4.Insert(4, BeforeFixedUpdate.GetSystem(OnBeforeFixedUpdate));
			int num = 5;
			foreach (PlayerLoopSystem item in GetChannelsSystemsForPass(EUpdatePass.BEFORE_FIXED_UPDATE))
			{
				list4.Insert(num, item);
				num++;
			}
			list4.Add(AfterPhysicsFixedUpdate.GetSystem(OnAfterPhysicsFixedUpdate));
			foreach (PlayerLoopSystem item2 in GetChannelsSystemsForPass(EUpdatePass.AFTER_PHYSICS_FIXED_UPDATE))
			{
				list4.Add(item2);
			}
			value3.subSystemList = list4.ToArray();
			list[3] = value3;
			PlayerLoopSystem system = AfterLateUpdate.GetSystem(OnAfterLateUpdate);
			system.subSystemList = GetChannelsSystemsForPass(EUpdatePass.AFTER_LATE_UPDATE).ToArray();
			list.Insert(7, system);
			PlayerLoopSystem system2 = AfterUpdate.GetSystem(OnAfterUpdate);
			system2.subSystemList = GetChannelsSystemsForPass(EUpdatePass.AFTER_UPDATE).ToArray();
			list.Insert(6, system2);
			PlayerLoopSystem system3 = BeforeUpdate.GetSystem(OnBeforeUpdate);
			system3.subSystemList = GetChannelsSystemsForPass(EUpdatePass.CLASSIC_UPDATE).ToArray();
			list.Insert(5, system3);
			PlayerLoopSystem system4 = AfterEarlyUpdate.GetSystem(OnAfterEarlyUpdate);
			system4.subSystemList = GetChannelsSystemsForPass(EUpdatePass.AFTER_EARLY_UPDATE).ToArray();
			list.Insert(3, system4);
			playerLoopSystem.subSystemList = list.ToArray();
			return playerLoopSystem;
		}

		private void OnPlayerLoopInitialized()
		{
			InitUpdateChannelEnabling();
		}

		private List<PlayerLoopSystem> GetChannelsSystemsForPass(EUpdatePass pass)
		{
			List<UpdateChannel> list = new List<UpdateChannel>();
			foreach (UpdateChannel value in m_channels.Values)
			{
				if (value.pass == pass)
				{
					list.Add(value);
				}
			}
			list.Sort((UpdateChannel c1, UpdateChannel c2) => c1.order.CompareTo(c2.order));
			List<PlayerLoopSystem> list2 = new List<PlayerLoopSystem>();
			foreach (UpdateChannel item in list)
			{
				list2.Add(new PlayerLoopSystem
				{
					type = item.type,
					updateDelegate = GetChannelUpdate((int)item.channel)
				});
			}
			return list2;
		}

		private void InitUpdateChannelEnabling()
		{
			foreach (UpdateChannel value in m_channels.Values)
			{
				if (!value.Enabled)
				{
					PlayerLoopManager.DisableSystem(value.type);
				}
			}
		}

		private void EnableUpdateChannel(bool enable, int index)
		{
			if (m_channels.TryGetValue(index, out var value))
			{
				if (enable)
				{
					PlayerLoopManager.ReenableSystem(value.type);
				}
				else
				{
					PlayerLoopManager.DisableSystem(value.type);
				}
			}
		}

		public static void RegisterCustomPlayerLoopSystem(PlayerLoopSystem customSystem, EUpdatePass pass)
		{
			switch (pass)
			{
			case EUpdatePass.AFTER_EARLY_UPDATE:
				PlayerLoopManager.AddCustomSubSystemAtLast(customSystem, typeof(AfterEarlyUpdate));
				break;
			case EUpdatePass.CLASSIC_UPDATE:
				PlayerLoopManager.AddCustomSubSystemAtLast(customSystem, typeof(BeforeUpdate));
				break;
			case EUpdatePass.AFTER_UPDATE:
				PlayerLoopManager.AddCustomSubSystemAtLast(customSystem, typeof(AfterUpdate));
				break;
			case EUpdatePass.AFTER_LATE_UPDATE:
				PlayerLoopManager.AddCustomSubSystemAtLast(customSystem, typeof(AfterLateUpdate));
				break;
			case EUpdatePass.BEFORE_FIXED_UPDATE:
				PlayerLoopManager.AddCustomSubSystemAtIndex(customSystem, typeof(FixedUpdate), 5);
				break;
			case EUpdatePass.AFTER_PHYSICS_FIXED_UPDATE:
				PlayerLoopManager.AddCustomSubSystemAtLast(customSystem, typeof(FixedUpdate));
				break;
			}
		}

		private void OnTimeUpdate()
		{
			Time = UnityEngine.Time.time;
			DeltaTime = UnityEngine.Time.deltaTime;
			RealTime = UnityEngine.Time.realtimeSinceStartup;
			RealDeltaTime = UnityEngine.Time.unscaledDeltaTime;
			Frame = UnityEngine.Time.frameCount;
			TimePaused = DeltaTime != 0f;
		}

		private void OnInitializationUpdate()
		{
			ResetCurrentFramePasses();
			PerformDelayedCallsRegistraton();
		}

		private void OnFrameEndUpdate()
		{
		}

		private void OnAfterEarlyUpdate()
		{
			UpdateDelayedCalls(EUpdatePass.AFTER_EARLY_UPDATE, DeltaTime);
			Updater.OnUpdateAfterEarly?.Invoke(DeltaTime);
			Updater.OneShotAfterEarlyUpdate?.Invoke();
			Updater.OneShotAfterEarlyUpdate = null;
			m_currentFramePasses.Add(EUpdatePass.AFTER_EARLY_UPDATE);
		}

		private void OnBeforeUpdate()
		{
			UpdateDelayedCalls(EUpdatePass.CLASSIC_UPDATE, DeltaTime);
			Updater.OnUpdateClassic?.Invoke(DeltaTime);
			Updater.OneShotClassicUpdate?.Invoke();
			Updater.OneShotClassicUpdate = null;
			m_currentFramePasses.Add(EUpdatePass.CLASSIC_UPDATE);
		}

		private void OnAfterUpdate()
		{
			UpdateDelayedCalls(EUpdatePass.AFTER_UPDATE, DeltaTime);
			Updater.OnUpdateAfterClassic?.Invoke(DeltaTime);
			Updater.OneShotAfterClassicUpdate?.Invoke();
			Updater.OneShotAfterClassicUpdate = null;
			m_currentFramePasses.Add(EUpdatePass.AFTER_UPDATE);
		}

		private void OnAfterLateUpdate()
		{
			UpdateDelayedCalls(EUpdatePass.AFTER_LATE_UPDATE, DeltaTime);
			Updater.OnUpdateAfterLate?.Invoke(DeltaTime);
			Updater.OneShotAfterLateUpdate?.Invoke();
			Updater.OneShotAfterLateUpdate = null;
			m_currentFramePasses.Add(EUpdatePass.AFTER_LATE_UPDATE);
		}

		private void OnBeforeFixedUpdate()
		{
			UpdateDelayedCalls(EUpdatePass.BEFORE_FIXED_UPDATE, UnityEngine.Time.fixedDeltaTime);
			Updater.OnUpdateBeforeFixed?.Invoke(UnityEngine.Time.fixedDeltaTime);
			Updater.OneShotBeforeFixedUpdate?.Invoke();
			Updater.OneShotBeforeFixedUpdate = null;
			m_currentFramePasses.Add(EUpdatePass.BEFORE_FIXED_UPDATE);
		}

		private void OnAfterPhysicsFixedUpdate()
		{
			UpdateDelayedCalls(EUpdatePass.AFTER_PHYSICS_FIXED_UPDATE, UnityEngine.Time.fixedDeltaTime);
			Updater.OnUpdateAfterPhysicsFixed?.Invoke(UnityEngine.Time.fixedDeltaTime);
			Updater.OneShotAfterPhysicsFixedUpdate?.Invoke();
			Updater.OneShotAfterPhysicsFixedUpdate = null;
			m_currentFramePasses.Add(EUpdatePass.AFTER_PHYSICS_FIXED_UPDATE);
		}

		private PlayerLoopSystem.UpdateFunction GetChannelUpdate(int index)
		{
			return index switch
			{
				0 => OnChannel0Update, 
				1 => OnChannel1Update, 
				2 => OnChannel2Update, 
				3 => OnChannel3Update, 
				4 => OnChannel4Update, 
				5 => OnChannel5Update, 
				6 => OnChannel6Update, 
				7 => OnChannel7Update, 
				8 => OnChannel8Update, 
				9 => OnChannel9Update, 
				10 => OnChannel10Update, 
				11 => OnChannel11Update, 
				12 => OnChannel12Update, 
				13 => OnChannel13Update, 
				14 => OnChannel14Update, 
				15 => OnChannel15Update, 
				16 => OnChannel16Update, 
				17 => OnChannel17Update, 
				18 => OnChannel18Update, 
				19 => OnChannel19Update, 
				20 => OnChannel20Update, 
				21 => OnChannel21Update, 
				22 => OnChannel22Update, 
				23 => OnChannel23Update, 
				24 => OnChannel24Update, 
				25 => OnChannel25Update, 
				26 => OnChannel26Update, 
				27 => OnChannel27Update, 
				28 => OnChannel28Update, 
				29 => OnChannel29Update, 
				30 => OnChannel30Update, 
				31 => OnChannel31Update, 
				_ => null, 
			};
		}

		private void OnChannel0Update()
		{
			UpdateChannelByIndex(0, DeltaTime, RealDeltaTime);
		}

		private void OnChannel1Update()
		{
			UpdateChannelByIndex(1, DeltaTime, RealDeltaTime);
		}

		private void OnChannel2Update()
		{
			UpdateChannelByIndex(2, DeltaTime, RealDeltaTime);
		}

		private void OnChannel3Update()
		{
			UpdateChannelByIndex(3, DeltaTime, RealDeltaTime);
		}

		private void OnChannel4Update()
		{
			UpdateChannelByIndex(4, DeltaTime, RealDeltaTime);
		}

		private void OnChannel5Update()
		{
			UpdateChannelByIndex(5, DeltaTime, RealDeltaTime);
		}

		private void OnChannel6Update()
		{
			UpdateChannelByIndex(6, DeltaTime, RealDeltaTime);
		}

		private void OnChannel7Update()
		{
			UpdateChannelByIndex(7, DeltaTime, RealDeltaTime);
		}

		private void OnChannel8Update()
		{
			UpdateChannelByIndex(8, DeltaTime, RealDeltaTime);
		}

		private void OnChannel9Update()
		{
			UpdateChannelByIndex(9, DeltaTime, RealDeltaTime);
		}

		private void OnChannel10Update()
		{
			UpdateChannelByIndex(10, DeltaTime, RealDeltaTime);
		}

		private void OnChannel11Update()
		{
			UpdateChannelByIndex(11, DeltaTime, RealDeltaTime);
		}

		private void OnChannel12Update()
		{
			UpdateChannelByIndex(12, DeltaTime, RealDeltaTime);
		}

		private void OnChannel13Update()
		{
			UpdateChannelByIndex(13, DeltaTime, RealDeltaTime);
		}

		private void OnChannel14Update()
		{
			UpdateChannelByIndex(14, DeltaTime, RealDeltaTime);
		}

		private void OnChannel15Update()
		{
			UpdateChannelByIndex(15, DeltaTime, RealDeltaTime);
		}

		private void OnChannel16Update()
		{
			UpdateChannelByIndex(16, DeltaTime, RealDeltaTime);
		}

		private void OnChannel17Update()
		{
			UpdateChannelByIndex(17, DeltaTime, RealDeltaTime);
		}

		private void OnChannel18Update()
		{
			UpdateChannelByIndex(18, DeltaTime, RealDeltaTime);
		}

		private void OnChannel19Update()
		{
			UpdateChannelByIndex(19, DeltaTime, RealDeltaTime);
		}

		private void OnChannel20Update()
		{
			UpdateChannelByIndex(20, DeltaTime, RealDeltaTime);
		}

		private void OnChannel21Update()
		{
			UpdateChannelByIndex(21, DeltaTime, RealDeltaTime);
		}

		private void OnChannel22Update()
		{
			UpdateChannelByIndex(22, DeltaTime, RealDeltaTime);
		}

		private void OnChannel23Update()
		{
			UpdateChannelByIndex(23, DeltaTime, RealDeltaTime);
		}

		private void OnChannel24Update()
		{
			UpdateChannelByIndex(24, DeltaTime, RealDeltaTime);
		}

		private void OnChannel25Update()
		{
			UpdateChannelByIndex(25, DeltaTime, RealDeltaTime);
		}

		private void OnChannel26Update()
		{
			UpdateChannelByIndex(26, DeltaTime, RealDeltaTime);
		}

		private void OnChannel27Update()
		{
			UpdateChannelByIndex(27, DeltaTime, RealDeltaTime);
		}

		private void OnChannel28Update()
		{
			UpdateChannelByIndex(28, DeltaTime, RealDeltaTime);
		}

		private void OnChannel29Update()
		{
			UpdateChannelByIndex(29, DeltaTime, RealDeltaTime);
		}

		private void OnChannel30Update()
		{
			UpdateChannelByIndex(30, DeltaTime, RealDeltaTime);
		}

		private void OnChannel31Update()
		{
			UpdateChannelByIndex(31, DeltaTime, RealDeltaTime);
		}

		private void ResetCurrentFramePasses()
		{
			m_currentFramePasses.Clear();
		}

		public static bool PassHasBeenTriggeredThisFrame(EUpdatePass pass)
		{
			return Instance.m_currentFramePasses.Contains(pass);
		}

		private void RegisterOneShotCallback(EUpdatePass pass, Action callback)
		{
			switch (pass)
			{
			case EUpdatePass.AFTER_EARLY_UPDATE:
				OneShotAfterEarlyUpdate += callback;
				break;
			case EUpdatePass.CLASSIC_UPDATE:
				OneShotClassicUpdate += callback;
				break;
			case EUpdatePass.AFTER_UPDATE:
				OneShotAfterClassicUpdate += callback;
				break;
			case EUpdatePass.AFTER_LATE_UPDATE:
				OneShotAfterLateUpdate += callback;
				break;
			case EUpdatePass.BEFORE_FIXED_UPDATE:
				OneShotBeforeFixedUpdate += callback;
				break;
			case EUpdatePass.AFTER_PHYSICS_FIXED_UPDATE:
				OneShotAfterPhysicsFixedUpdate += callback;
				break;
			}
		}

		private void InitChannels()
		{
			foreach (EUpdateChannel value2 in Enum.GetValues(typeof(EUpdateChannel)))
			{
				IUpdateChannel value = value2.GetValue();
				m_channels[(int)value.Channel] = new UpdateChannel(value);
			}
		}

		private void ClearChannels()
		{
			m_channels.Clear();
			m_channelCallbacks.Clear();
		}

		public static void RegisterChannelCallback(bool register, EUpdateChannel channel, UpdateCallback callback)
		{
			if (register)
			{
				Instance.RegisterChannelCallback((int)channel, callback);
			}
			else
			{
				Instance.UnregisterChannelCallback((int)channel, callback);
			}
		}

		private void RegisterChannelCallback(int channelIndex, UpdateCallback callback)
		{
			if (m_channelCallbacks.ContainsKey(channelIndex))
			{
				Dictionary<int, UpdateCallback> channelCallbacks = m_channelCallbacks;
				channelCallbacks[channelIndex] = (UpdateCallback)Delegate.Combine(channelCallbacks[channelIndex], callback);
			}
			else
			{
				m_channelCallbacks.Add(channelIndex, callback);
			}
		}

		private void UnregisterChannelCallback(int channelIndex, UpdateCallback callback)
		{
			if (m_channelCallbacks.ContainsKey(channelIndex))
			{
				Dictionary<int, UpdateCallback> channelCallbacks = m_channelCallbacks;
				channelCallbacks[channelIndex] = (UpdateCallback)Delegate.Remove(channelCallbacks[channelIndex], callback);
			}
		}

		private void TriggerChannelCallback(int channelIndex, float deltaTime)
		{
			if (m_channelCallbacks.TryGetValue(channelIndex, out var value))
			{
				value?.Invoke(deltaTime);
			}
		}

		private void UpdateChannelByIndex(int index, float deltaTime, float realDeltaTime)
		{
			if (m_channels.TryGetValue(index, out var value) && IsChannelValid(value) && value.Update(value.realtime ? realDeltaTime : deltaTime, out var actualDeltaTime))
			{
				TriggerChannelCallback(index, actualDeltaTime);
			}
		}

		public static void SetChannelEnable(EUpdateChannel channel, bool enabled)
		{
			if (Instance.m_channels.TryGetValue((int)channel, out var value) && value.Enabled != enabled)
			{
				value.Enabled = enabled;
				Instance.EnableUpdateChannel(enabled, (int)channel);
			}
		}

		public static void SetChannelTimescale(EUpdateChannel channel, float timescale)
		{
			if (Instance.m_channels.TryGetValue((int)channel, out var value))
			{
				value.Timescale = timescale;
			}
		}

		public static void SetChannelFrequency(EUpdateChannel channel, float frequency)
		{
			if (Instance.m_channels.TryGetValue((int)channel, out var value))
			{
				value.Frequency = Mathf.Max(frequency, 0f);
			}
		}

		private bool IsChannelValid(UpdateChannel channel)
		{
			if (channel.Enabled)
			{
				return IsConditionFulfilled(channel.condition);
			}
			return false;
		}

		private bool IsConditionFulfilled(EUpdateCondition condition)
		{
			if (Overrider != null && Overrider.OverrideConditionFulfillment(condition, out var fulfilled))
			{
				return fulfilled;
			}
			return condition switch
			{
				EUpdateCondition.ALWAYS => true, 
				EUpdateCondition.GAME_PLAYING => UnityEngine.Time.timeScale > 0f, 
				EUpdateCondition.GAME_PAUSED => UnityEngine.Time.timeScale == 0f, 
				EUpdateCondition.GAME_OVER => false, 
				_ => false, 
			};
		}

		private bool CreateUpdateTimelineInstance(IUpdateTimeline updateTimeline, ulong key)
		{
			if (updateTimeline == null || m_updateTimelineInstances.ContainsKey(key))
			{
				return false;
			}
			if (updateTimeline.Duration > 0f)
			{
				UpdateTimelineInstance updateTimelineInstance = new UpdateTimelineInstance(updateTimeline);
				m_updateTimelineInstances[key] = updateTimelineInstance;
				RegisterChannelCallback((int)updateTimeline.UpdateChannel, updateTimelineInstance.OnUpdate);
				return true;
			}
			Debug.LogError("You tried to register an UpdateTimeline that has no valid update or a duration equal to 0");
			return false;
		}

		private void DestroyUpdateTimelineInstance(ulong key)
		{
			if (m_updateTimelineInstances.TryGetValue(key, out var value))
			{
				UnregisterChannelCallback((int)value.updateChannel, value.OnUpdate);
				m_updateTimelineInstances.Remove(key);
			}
		}

		private void ClearUpdateTimelineInstances()
		{
			foreach (ulong key in m_updateTimelineInstances.Keys)
			{
				DestroyUpdateTimelineInstance(key);
			}
			m_updateTimelineInstances.Clear();
		}

		public static bool CreateTimelineInstance(EUpdateChannel channel, float duration, out UpdateTimelineInstanceHandle handle, bool loop = false, float timescale = 1f, List<IUpdateTimeline.Event> events = null, int uid = 0)
		{
			return CreateTimelineInstance(new ScriptedUpdateTimeline(channel, duration, loop, timescale, events, uid), out handle);
		}

		public static bool CreateTimelineInstance(IUpdateTimeline timeline, out UpdateTimelineInstanceHandle handle)
		{
			ulong uniqueRegistrationKey = GetUniqueRegistrationKey();
			handle = new UpdateTimelineInstanceHandle(uniqueRegistrationKey);
			return Instance.CreateUpdateTimelineInstance(timeline, uniqueRegistrationKey);
		}

		public static void KillTimelineInstance(UpdateTimelineInstanceHandle handle)
		{
			Instance.DestroyUpdateTimelineInstance(handle.key);
		}

		internal bool TimelineInstanceExist(ulong key)
		{
			return m_updateTimelineInstances.ContainsKey(key);
		}

		internal bool TryGetUpdateTimelineInstance(ulong key, out UpdateTimelineInstance state)
		{
			return m_updateTimelineInstances.TryGetValue(key, out state);
		}

		public static bool TryGetUpdateTimelineInstanceHandle(int timelineUID, out UpdateTimelineInstanceHandle handle)
		{
			foreach (var (key, updateTimelineInstance2) in Instance.m_updateTimelineInstances)
			{
				if (updateTimelineInstance2.timelineUID == timelineUID)
				{
					handle = new UpdateTimelineInstanceHandle(key);
					return true;
				}
			}
			handle = UpdateTimelineInstanceHandle.Empty;
			return false;
		}

		private void PreRegisterDelayedCall(ulong key, DelayedCall delayedCall)
		{
			m_delayedCallsToRegister.Add(key, delayedCall);
		}

		private void PerformDelayedCallsRegistraton()
		{
			foreach (var (key, value) in m_delayedCallsToRegister)
			{
				m_delayedCalls.Add(key, value);
			}
			m_delayedCallsToRegister.Clear();
		}

		private void UnregisterDelayedCall(ulong key)
		{
			m_delayedCalls.Remove(key);
		}

		private void RegisterTimedDelayedCall(ulong key, float delay, EUpdatePass pass, EUpdateCondition condition, Action callback)
		{
			if (delay == 0f && IsConditionFulfilled(condition))
			{
				if (PassHasBeenTriggeredThisFrame(pass))
				{
					callback?.Invoke();
				}
				else
				{
					RegisterOneShotCallback(pass, callback);
				}
			}
			else
			{
				PreRegisterDelayedCall(key, new TimedDelayedCall(delay, pass, condition, callback));
			}
		}

		private void RegisterFrameDelayedCall(ulong key, int framesToWait, EUpdatePass pass, EUpdateCondition condition, Action callback)
		{
			if (framesToWait == 0 && IsConditionFulfilled(condition))
			{
				if (PassHasBeenTriggeredThisFrame(pass))
				{
					callback?.Invoke();
				}
				else
				{
					RegisterOneShotCallback(pass, callback);
				}
			}
			else
			{
				PreRegisterDelayedCall(key, new FrameDelayedCall(framesToWait, pass, condition, callback));
			}
		}

		private void RegisterWaitUntilDelayedCall(ulong key, Func<bool> predicate, EUpdatePass pass, EUpdateCondition condition, Action callback)
		{
			if (predicate() && IsConditionFulfilled(condition))
			{
				if (PassHasBeenTriggeredThisFrame(pass))
				{
					callback?.Invoke();
				}
				else
				{
					RegisterOneShotCallback(pass, callback);
				}
			}
			else
			{
				PreRegisterDelayedCall(key, new WaitDelayedCall(predicate, waitUntil: true, pass, condition, callback));
			}
		}

		private void RegisterWaitWhileDelayedCall(ulong key, Func<bool> predicate, EUpdatePass pass, EUpdateCondition condition, Action callback)
		{
			if (!predicate() && IsConditionFulfilled(condition))
			{
				if (PassHasBeenTriggeredThisFrame(pass))
				{
					callback?.Invoke();
				}
				else
				{
					RegisterOneShotCallback(pass, callback);
				}
			}
			else
			{
				PreRegisterDelayedCall(key, new WaitDelayedCall(predicate, waitUntil: false, pass, condition, callback));
			}
		}

		public static void CallInXFrames(int framesToWait, Action callback, out DelayedCallHandle handle, EUpdatePass pass = EUpdatePass.CLASSIC_UPDATE, EUpdateCondition condition = EUpdateCondition.ALWAYS)
		{
			if (callback == null || framesToWait < 0)
			{
				handle = DelayedCallHandle.Empty;
				return;
			}
			ulong uniqueRegistrationKey = GetUniqueRegistrationKey();
			Instance.RegisterFrameDelayedCall(uniqueRegistrationKey, framesToWait, pass, condition, callback);
			handle = new DelayedCallHandle(uniqueRegistrationKey);
		}

		public static void CallInXSeconds(float time, Action callback, out DelayedCallHandle handle, EUpdatePass pass = EUpdatePass.CLASSIC_UPDATE, EUpdateCondition condition = EUpdateCondition.ALWAYS)
		{
			if (callback == null || time < 0f)
			{
				handle = DelayedCallHandle.Empty;
				return;
			}
			ulong uniqueRegistrationKey = GetUniqueRegistrationKey();
			Instance.RegisterTimedDelayedCall(uniqueRegistrationKey, time, pass, condition, callback);
			handle = new DelayedCallHandle(uniqueRegistrationKey);
		}

		public static void CallWhenTrue(Func<bool> predicate, Action callback, out DelayedCallHandle handle, EUpdatePass pass = EUpdatePass.CLASSIC_UPDATE, EUpdateCondition condition = EUpdateCondition.ALWAYS)
		{
			if (callback == null || predicate == null)
			{
				handle = DelayedCallHandle.Empty;
				return;
			}
			ulong uniqueRegistrationKey = GetUniqueRegistrationKey();
			Instance.RegisterWaitUntilDelayedCall(uniqueRegistrationKey, predicate, pass, condition, callback);
			handle = new DelayedCallHandle(uniqueRegistrationKey);
		}

		public static void CallWhenFalse(Func<bool> predicate, Action callback, out DelayedCallHandle handle, EUpdatePass pass = EUpdatePass.CLASSIC_UPDATE, EUpdateCondition condition = EUpdateCondition.ALWAYS)
		{
			if (callback == null || predicate == null)
			{
				handle = DelayedCallHandle.Empty;
				return;
			}
			ulong uniqueRegistrationKey = GetUniqueRegistrationKey();
			Instance.RegisterWaitWhileDelayedCall(uniqueRegistrationKey, predicate, pass, condition, callback);
			handle = new DelayedCallHandle(uniqueRegistrationKey);
		}

		public static void KillDelayedCall(DelayedCallHandle handle)
		{
			Instance.UnregisterDelayedCall(handle.key);
		}

		private void UpdateDelayedCalls(EUpdatePass pass, float deltaTime)
		{
			List<ulong> list = new List<ulong>();
			foreach (var (item, delayedCall2) in m_delayedCalls)
			{
				if (IsConditionFulfilled(delayedCall2.condition) && delayedCall2.pass == pass && delayedCall2.Update(deltaTime))
				{
					list.Add(item);
				}
			}
			foreach (ulong item2 in list)
			{
				UnregisterDelayedCall(item2);
			}
		}

		internal bool DoesDelayedCallExist(ulong key)
		{
			if (!m_delayedCalls.ContainsKey(key))
			{
				return m_delayedCallsToRegister.ContainsKey(key);
			}
			return true;
		}

		internal bool GetDelayedCallTimeLeft(ulong key, out float timeLeft)
		{
			if (m_delayedCalls.TryGetValue(key, out var value) && value is TimedDelayedCall timedDelayedCall)
			{
				timeLeft = timedDelayedCall.GetRemainingTime();
				return true;
			}
			timeLeft = -1f;
			return false;
		}

		internal bool GetDelayedCallFramesLeft(ulong key, out int framesLeft)
		{
			if (m_delayedCalls.TryGetValue(key, out var value) && value is FrameDelayedCall frameDelayedCall)
			{
				framesLeft = frameDelayedCall.GetRemainingFrames();
				return true;
			}
			framesLeft = -1;
			return false;
		}

		private void ClearDelayedCalls()
		{
			m_delayedCalls.Clear();
			m_delayedCallsToRegister.Clear();
		}

		private static ulong GetUniqueRegistrationKey()
		{
			_registrationCount++;
			return _registrationCount;
		}

		public static void PauseTime(bool pause)
		{
			UnityEngine.Time.timeScale = (pause ? 0f : 1f);
		}

		internal void Clear()
		{
			m_currentFramePasses.Clear();
			ClearChannels();
			ClearDelayedCalls();
			ClearUpdateTimelineInstances();
			Updater.OnUpdateAfterEarly = null;
			Updater.OnUpdateAfterLate = null;
			Updater.OnUpdateAfterPhysicsFixed = null;
			Updater.OnUpdateAfterClassic = null;
			Updater.OnUpdateBeforeFixed = null;
			Updater.OnUpdateClassic = null;
			_registrationCount = 0uL;
		}
	}
}
