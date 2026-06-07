using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class ADAMessages
{
	private class QueuedRM
	{
		public string key;

		public ADAMessageLogRow.MESSAGE_TYPE messageType;

		public List<Vector2> positions;

		public List<int> units;

		public QueuedRM(string key, ADAMessageLogRow.MESSAGE_TYPE messageType, List<Vector2> positions, List<int> units)
		{
		}
	}

	public class RevealedMessage
	{
		public string key;

		public ADAMessageLogRow.MESSAGE_TYPE messageType;

		public bool read;

		public List<Vector2> positions;

		public List<int> units;

		public RevealedMessage()
		{
		}

		public RevealedMessage(string key, ADAMessageLogRow.MESSAGE_TYPE messageType)
		{
		}

		public void AddPosition(Vector3 pos)
		{
		}

		public void AddUnit(UnitManager unit)
		{
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	private List<RevealedMessage> revealedMessages;

	private OrderedDictionary2<string, ADAMessage> messages;

	private List<QueuedRM> queuedRMs;

	public int GetQueuedMessageCount()
	{
		return 0;
	}

	public void ScanDone()
	{
	}

	public OrderedDictionary2<string, ADAMessage> GetMessages()
	{
		return null;
	}

	public void GetMessageKeys(List<string> keys)
	{
	}

	public void GetRevealedMessageCounts(out int readMessages, out int totalMessages)
	{
		readMessages = default(int);
		totalMessages = default(int);
	}

	public void MarkRevealedMessageRead(string key)
	{
	}

	public RevealedMessage GetRevealedMessage(string key)
	{
		return null;
	}

	public bool IsRevealedMessageRead(string key)
	{
		return false;
	}

	private void MergePositions(List<Vector2> currentPositions, List<Vector2> newPositions)
	{
	}

	private void MergeUnits(List<int> currentUnits, List<int> newUnits)
	{
	}

	public bool AddRevealedMessage(string key, ADAMessageLogRow.MESSAGE_TYPE messageType, List<Vector2> positions, List<int> units)
	{
		return false;
	}

	public List<RevealedMessage> GetRevealedMessages()
	{
		return null;
	}

	public void ClearAllRevealedMessages()
	{
	}

	public ADAMessage GetMessage(string key)
	{
		return null;
	}

	public void AddMessage(string key, ADAMessage message)
	{
	}

	public bool RenameMessage(string key, string newKey)
	{
		return false;
	}

	public bool RemoveMessage(string key)
	{
		return false;
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}
