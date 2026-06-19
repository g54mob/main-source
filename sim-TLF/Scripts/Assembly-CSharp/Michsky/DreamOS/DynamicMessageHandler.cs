using System.Collections;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class DynamicMessageHandler : MonoBehaviour
	{
		[HideInInspector]
		public MessagingManager manager;

		private GameObject messageTimerObject;

		public IEnumerator HandleDynamicMessage(float timer, int layoutIndex)
		{
			yield return new WaitForSeconds(timer);
			GameObject gameObject = Object.Instantiate(manager.chatMessageTimer, new Vector3(0f, 0f, 0f), Quaternion.identity);
			ChatLayoutPreset component = manager.chatViewer.Find(manager.chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			gameObject.transform.SetParent(component.messageParent, worldPositionStays: false);
			messageTimerObject = gameObject;
			StartCoroutine(FinishDynamicMessage(manager.chatList[layoutIndex].chatAsset.dynamicMessages[manager.dynamicMessageIndex].replyTimer, layoutIndex));
		}

		private IEnumerator FinishDynamicMessage(float timer, int layoutIndex)
		{
			yield return new WaitForSeconds(timer);
			manager.allowInputSubmit = true;
			manager.CreateDynamicMessage(layoutIndex, waitingForTimer: false);
			if (manager.chatList[layoutIndex].chatAsset.dynamicMessages[manager.dynamicMessageIndex].replyBehavior == MessagingChat.DynamicMessageReplyBehavior.DisableReply)
			{
				manager.chatList[layoutIndex].chatAsset.dynamicMessages[manager.dynamicMessageIndex].enableReply = false;
			}
			Object.Destroy(messageTimerObject);
			Object.Destroy(base.gameObject);
		}

		public IEnumerator HandleStoryTeller(float timer, int layoutIndex, bool isIndividual)
		{
			yield return new WaitForSeconds(timer);
			GameObject gameObject = Object.Instantiate(manager.chatMessageTimer, new Vector3(0f, 0f, 0f), Quaternion.identity);
			ChatLayoutPreset component = manager.chatViewer.Find(manager.chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			gameObject.transform.SetParent(component.messageParent, worldPositionStays: false);
			messageTimerObject = gameObject;
			StartCoroutine(CreateStoryTellerMessage(manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].messageTimer, layoutIndex, isIndividual));
		}

		private IEnumerator CreateStoryTellerMessage(float timer, int layoutIndex, bool isIndividual)
		{
			yield return new WaitForSeconds(timer);
			Object.Destroy(messageTimerObject);
			ChatLayoutPreset component = manager.chatViewer.Find(manager.chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			string messageKey = manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].messageKey;
			if (isIndividual)
			{
				manager.CreateCustomIndividualMessage(component, manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].messageContent, manager.GetTimeData(), messageKey);
			}
			else
			{
				manager.CreateCustomMessage(component, manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].messageContent, manager.GetTimeData(), messageKey);
			}
			if (manager.stIndexHelper == manager.currentLayout && manager.storyTellerAnimator.gameObject.activeInHierarchy)
			{
				manager.ShowStorytellerPanel();
			}
			manager.isStoryTellerOpen = true;
		}

		public IEnumerator HandleStoryTellerLatency(float timer, int layoutIndex, int itemIndex)
		{
			yield return new WaitForSeconds(timer);
			StartCoroutine(FinishStoryTeller(manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].replies[itemIndex].feedbackTimer, layoutIndex));
			GameObject gameObject = Object.Instantiate(manager.chatMessageTimer, new Vector3(0f, 0f, 0f), Quaternion.identity);
			ChatLayoutPreset component = manager.chatViewer.Find(manager.chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			gameObject.transform.SetParent(component.messageParent, worldPositionStays: false);
			messageTimerObject = gameObject;
		}

		private IEnumerator FinishStoryTeller(float timer, int layoutIndex)
		{
			yield return new WaitForSeconds(timer);
			ChatLayoutPreset component = manager.chatViewer.Find(manager.chatList[layoutIndex].chatTitle).GetComponent<ChatLayoutPreset>();
			string feedbackKey = manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].replies[manager.stItemIndex].feedbackKey;
			manager.CreateIndividualMessage(component, manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].replies[manager.stItemIndex].replyFeedback, feedbackKey);
			if (!string.IsNullOrEmpty(manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].replies[manager.stItemIndex].callAfter))
			{
				manager.CreateStoryTeller(manager.chatList[layoutIndex].chatTitle, manager.chatList[layoutIndex].chatAsset.storyTeller[manager.storyTellerIndex].replies[manager.stItemIndex].callAfter);
			}
			Object.Destroy(messageTimerObject);
			Object.Destroy(base.gameObject);
		}
	}
}
