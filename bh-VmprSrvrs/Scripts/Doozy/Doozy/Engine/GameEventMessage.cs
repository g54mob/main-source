using System.Collections.Generic;
using UnityEngine;

namespace Doozy.Engine
{
	public class GameEventMessage : Message
	{
		private const string NO_GAME_EVENT = "None";

		public readonly string EventName;

		public GameObject Source;

		public Object CustomObject;

		public bool HasCustomObject => false;

		public bool HasGameEvent => false;

		public bool HasSource => false;

		public bool IsSystemEvent { get; private set; }

		public GameEventMessage(SystemGameEvent systemGameEvent)
		{
		}

		public GameEventMessage(string gameEvent)
		{
		}

		public GameEventMessage(GameObject source)
		{
		}

		public GameEventMessage(SystemGameEvent systemGameEvent, GameObject source, Object customObject = null)
		{
		}

		public GameEventMessage(string gameEvent, GameObject source)
		{
		}

		public GameEventMessage(GameObject source, Object customObject)
		{
		}

		public GameEventMessage(string gameEvent, Object customObject)
		{
		}

		public GameEventMessage(string gameEvent, GameObject source, Object customObject)
		{
		}

		public static void SendEvent(SystemGameEvent systemGameEvent)
		{
		}

		public static void SendEvent(string gameEvent)
		{
		}

		public static void SendEvent(GameObject source)
		{
		}

		public static void SendEvent(SystemGameEvent systemGameEvent, GameObject source)
		{
		}

		public static void SendEvent(string gameEvent, GameObject source)
		{
		}

		public static void SendEvent(string gameEvent, Object customObject)
		{
		}

		public static void SendEvent(GameObject source, Object customObject)
		{
		}

		public static void SendEvent(string gameEvent, GameObject source, Object customObject)
		{
		}

		public static void SendEvents(List<string> gameEvents, GameObject source = null, Object customObject = null)
		{
		}

		private static void SendEvent(GameEventMessage gameEventMessage)
		{
		}
	}
}
