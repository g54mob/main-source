using System;
using System.Collections;
using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class PlayerMessageManager : MonoBehaviour, IInputController
{
	public struct Message : IEquatable<Message>
	{
		public string LocID;

		public bool isError;

		public Message(string LocID, bool isError = false)
		{
			this.LocID = LocID;
			this.isError = isError;
		}

		public bool Equals(Message other)
		{
			if (LocID == other.LocID)
			{
				return isError == other.isError;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Message other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(LocID, isError);
		}
	}

	public static LinkedList<Message> messageQueue = new LinkedList<Message>();

	public GameObject container;

	public GameObject clickCatch;

	public bool proceed;

	public bool busy;

	public EaseUI easeUI;

	public GameObject errorTitle;

	public static PlayerMessageManager instance;

	public LocalizedText locText;

	private void Awake()
	{
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public IEnumerator NoticeCo(Message msg)
	{
		busy = true;
		container.SetActive(value: true);
		clickCatch.SetActive(value: true);
		easeUI.transform.localScale = Vector3.zero;
		easeUI.EaseIn();
		AggroInputManager.PushController(this);
		proceed = false;
		while (!proceed)
		{
			if (AggroInputManager.enabled && !AggroInputManager.HasControl(this) && !Platform.ShouldPause())
			{
				AggroInputManager.PushController(this);
			}
			if (AggroInputManager.input.QuotaReport.Continue.WasPerformedThisFrame())
			{
				proceed = true;
				if (messageQueue.Count > 0)
				{
					messageQueue.RemoveFirst();
				}
			}
			if (!messageQueue.Contains(msg))
			{
				proceed = true;
			}
			yield return null;
		}
		easeUI.EaseOut();
		yield return new WaitForSecondsRealtime(0.5f);
		AggroInputManager.RemoveController(this);
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
		busy = false;
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.QuotaReport.Enable();
		AggroInputManager.EnableUIModule();
	}

	public void OnContinue()
	{
		proceed = true;
		if (messageQueue.Count > 0)
		{
			messageQueue.RemoveFirst();
		}
	}

	public static void DequeueMessage(Message message)
	{
		if (messageQueue.Contains(message))
		{
			messageQueue.Remove(message);
		}
	}

	public static void PauseMessages()
	{
		instance.proceed = true;
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.QuotaReport.Disable();
	}

	public static void ProcessQueuedMessages()
	{
		if (!GameUtil.isGym)
		{
			if (!AggroInputManager.enabled || instance.busy || FadeManager.instance.busy)
			{
				return;
			}
		}
		else if (!AggroInputManager.enabled || instance.busy)
		{
			return;
		}
		if (messageQueue.Count > 0)
		{
			Message value = messageQueue.First.Value;
			instance.locText.index = value.LocID;
			instance.errorTitle.SetActive(value.isError);
			instance.StartCoroutine(instance.NoticeCo(value));
		}
	}

	public static Message QueueMessage(string locID, bool highPriority = false, bool isError = false, bool allowDuplicates = false)
	{
		Message message = new Message(locID, isError);
		if (messageQueue.Contains(message) && !allowDuplicates)
		{
			return message;
		}
		if (highPriority)
		{
			instance.proceed = true;
			messageQueue.AddFirst(message);
		}
		else
		{
			messageQueue.AddLast(message);
		}
		return message;
	}

	public static Message QueueErrorMessage(GameError error)
	{
		return QueueMessage(error switch
		{
			GameError.None => throw new NotImplementedException(), 
			GameError.ClientDisconnected => "ERRORCLIENTDISCONNECTED", 
			GameError.ClientCantConnect => "ERRORCLIENTCANNOTCONNECT", 
			GameError.ClientVersionMismatch => "ERRORCLIENTMIXMATCH", 
			GameError.ClientCantConnectLobbyFull => "ERRORLOBBY", 
			GameError.HostFailed => "ERRORHOSTFAILED", 
			_ => throw new NotImplementedException(), 
		}, highPriority: true, isError: true);
	}

	public static Message QueueErrorMessage(Platform.JoinListError error)
	{
		return QueueMessage(error switch
		{
			Platform.JoinListError.None => throw new NotImplementedException(), 
			Platform.JoinListError.NoJoinAvailable => "NOJOIN", 
			Platform.JoinListError.NotInitialized => "ERRORCLIENTCANNOTCONNECT", 
			_ => throw new NotImplementedException(), 
		}, highPriority: true, isError: true);
	}

	public static void ClearMessageQueue()
	{
		messageQueue.Clear();
	}

	public void TestQueueMessage()
	{
		QueueMessage("Test!! \n Message: " + messageQueue.Count);
	}

	public void TestQueueMessageHighPriority()
	{
		QueueMessage("HIGH PRIORITY TEST!!", highPriority: true);
	}

	public void TestErrorMessage()
	{
		QueueErrorMessage(GameError.ClientDisconnected);
	}

	public void TestClearMessageQueue()
	{
		ClearMessageQueue();
	}
}
