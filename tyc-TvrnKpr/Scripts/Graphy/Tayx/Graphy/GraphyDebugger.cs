using System;
using System.Collections.Generic;
using Tayx.Graphy.Audio;
using Tayx.Graphy.Fps;
using Tayx.Graphy.Ram;
using Tayx.Graphy.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Tayx.Graphy
{
	public class GraphyDebugger : Singleton<GraphyDebugger>
	{
		public enum DebugVariable
		{
			Fps = 0,
			Fps_Min = 1,
			Fps_Max = 2,
			Fps_Avg = 3,
			Ram_Allocated = 4,
			Ram_Reserved = 5,
			Ram_Mono = 6,
			Audio_DB = 7
		}

		public enum DebugComparer
		{
			Less_than = 0,
			Equals_or_less_than = 1,
			Equals = 2,
			Equals_or_greater_than = 3,
			Greater_than = 4
		}

		public enum ConditionEvaluation
		{
			All_conditions_must_be_met = 0,
			Only_one_condition_has_to_be_met = 1
		}

		public enum MessageType
		{
			Log = 0,
			Warning = 1,
			Error = 2
		}

		[Serializable]
		public struct DebugCondition
		{
			[Tooltip("Variable to compare against")]
			public DebugVariable Variable;

			[Tooltip("Comparer operator to use")]
			public DebugComparer Comparer;

			[Tooltip("Value to compare against the chosen variable")]
			public float Value;
		}

		[Serializable]
		public class DebugPacket
		{
			[Tooltip("If false, it won't be checked")]
			public bool Active;

			[Tooltip("Optional Id. It's used to get or remove DebugPackets in runtime")]
			public int Id;

			[Tooltip("If true, once the actions are executed, this DebugPacket will delete itself")]
			public bool ExecuteOnce;

			[Tooltip("Time to wait before checking if conditions are met (use this to avoid low fps drops triggering the conditions when loading the game)")]
			public float InitSleepTime;

			[Tooltip("Time to wait before checking if conditions are met again (once they have already been met and if ExecuteOnce is false)")]
			public float ExecuteSleepTime;

			public ConditionEvaluation ConditionEvaluation;

			[Tooltip("List of conditions that will be checked each frame")]
			public List<DebugCondition> DebugConditions;

			public MessageType MessageType;

			[Multiline]
			public string Message;

			public bool TakeScreenshot;

			public string ScreenshotFileName;

			[Tooltip("If true, it pauses the editor")]
			public bool DebugBreak;

			public UnityEvent UnityEvents;

			public List<Action> Callbacks;

			private bool canBeChecked;

			private bool executed;

			private float timePassed;

			public bool Check => false;

			public void Update()
			{
			}

			public void Executed()
			{
			}
		}

		private FpsMonitor m_fpsMonitor;

		private RamMonitor m_ramMonitor;

		private AudioMonitor m_audioMonitor;

		[SerializeField]
		private List<DebugPacket> m_debugPackets;

		protected GraphyDebugger()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void AddNewDebugPacket(DebugPacket newDebugPacket)
		{
		}

		public void AddNewDebugPacket(int newId, DebugCondition newDebugCondition, MessageType newMessageType, string newMessage, bool newDebugBreak, Action newCallback)
		{
		}

		public void AddNewDebugPacket(int newId, List<DebugCondition> newDebugConditions, MessageType newMessageType, string newMessage, bool newDebugBreak, Action newCallback)
		{
		}

		public void AddNewDebugPacket(int newId, DebugCondition newDebugCondition, MessageType newMessageType, string newMessage, bool newDebugBreak, List<Action> newCallbacks)
		{
		}

		public void AddNewDebugPacket(int newId, List<DebugCondition> newDebugConditions, MessageType newMessageType, string newMessage, bool newDebugBreak, List<Action> newCallbacks)
		{
		}

		public DebugPacket GetFirstDebugPacketWithId(int packetId)
		{
			return null;
		}

		public List<DebugPacket> GetAllDebugPacketsWithId(int packetId)
		{
			return null;
		}

		public void RemoveFirstDebugPacketWithId(int packetId)
		{
		}

		public void RemoveAllDebugPacketsWithId(int packetId)
		{
		}

		public void AddCallbackToFirstDebugPacketWithId(Action callback, int id)
		{
		}

		public void AddCallbackToAllDebugPacketWithId(Action callback, int id)
		{
		}

		private void CheckDebugPackets()
		{
		}

		private bool CheckIfConditionIsMet(DebugCondition debugCondition)
		{
			return false;
		}

		private float GetRequestedValueFromDebugVariable(DebugVariable debugVariable)
		{
			return 0f;
		}

		private void ExecuteOperationsInDebugPacket(DebugPacket debugPacket)
		{
		}
	}
}
