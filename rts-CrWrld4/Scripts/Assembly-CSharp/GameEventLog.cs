using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using UnityEngine.UI;

public class GameEventLog
{
	public class GameEvent
	{
		public enum EVENT_TYPE
		{
			GENERIC = 0,
			UNIT_DESTROYED = 1
		}

		public EVENT_TYPE eventType;

		public int time;

		public bool enemy;

		public GameEvent()
		{
		}

		public GameEvent(bool enemy)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public virtual void SetText(Text text)
		{
		}

		public virtual void ReadData(Tag data)
		{
		}

		public virtual TagCompound WriteData()
		{
			return null;
		}
	}

	public class GameEvent_UnitDestroyed : GameEvent
	{
		public string unitName;

		public Vector3 location;

		public bool userInitiated;

		public bool unitWasBuilding;

		public GameEvent_UnitDestroyed()
		{
		}

		public GameEvent_UnitDestroyed(bool enemy)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void SetText(Text text)
		{
		}

		public override void ReadData(Tag data)
		{
		}

		public override TagCompound WriteData()
		{
			return null;
		}
	}

	private List<GameEvent> eventList;

	public void AddEvent(GameEvent gameEvent)
	{
	}

	public List<GameEvent> GetEvents()
	{
		return null;
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}

	public static void Log_UnitDestroyed(UnitManager unit, bool userInitiated)
	{
	}
}
