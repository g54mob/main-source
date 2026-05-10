using System;
using CTS.Core;
using CTS.Core.Utilities;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	public abstract class LockWithCurrentDialogueBase : CTSBehaviour
	{
		[Flags]
		private enum EType
		{
			Feedback = 0,
			MainDialogue = 1
		}

		[SerializeField]
		private EType _lockType = EType.MainDialogue;

		private readonly LockToggle _lock = new LockToggle();

		private void Start()
		{
			_lock.Add(GetLockable());
			SceneManager.sceneLoaded += OnSceneLoaded;
			OnSceneLoaded(base.gameObject.scene, LoadSceneMode.Single);
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
		{
			if ((bool)DialogueManager.Instance)
			{
				if (DialogueManager.IsConversationActive)
				{
					OnConversationStarted(null);
				}
				DialogueManager.Instance.conversationStarted -= OnConversationStarted;
				DialogueManager.Instance.conversationEnded -= OnConversationEnded;
				DialogueManager.Instance.conversationStarted += OnConversationStarted;
				DialogueManager.Instance.conversationEnded += OnConversationEnded;
			}
		}

		private void OnDestroy()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
			if ((bool)DialogueManager.Instance)
			{
				DialogueManager.Instance.conversationStarted -= OnConversationStarted;
				DialogueManager.Instance.conversationEnded -= OnConversationEnded;
			}
		}

		protected abstract ILockable GetLockable();

		private void OnConversationStarted(Transform t)
		{
			if (DialogueManager.MasterDatabase.GetConversation(DialogueManager.lastConversationStarted).LookupBool("Is a dialogue"))
			{
				if (_lockType.HasFlagNonAlloc(EType.MainDialogue))
				{
					_lock.Lock();
				}
			}
			else if (_lockType.HasFlagNonAlloc(EType.Feedback))
			{
				_lock.Lock();
			}
		}

		private void OnConversationEnded(Transform t)
		{
			_lock.Unlock();
		}
	}
}
