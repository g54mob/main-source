using System.Collections.Generic;
using UnityEngine;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/Managers/UIPopup Manager", 13)]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-200)]
	public class UIPopupManager : MonoBehaviour
	{
		private static UIPopupManager s_instance;

		public static UIPopup CurrentVisibleQueuePopup;

		public static readonly List<UIPopupQueueData> PopupQueue;

		public static UIPopupManager Instance => null;

		public static UIPopupDatabase PopupDatabase => null;

		public static bool QueueIsEmpty => false;

		private static bool ApplicationIsQuitting { get; set; }

		private bool DebugComponent => false;

		protected UIPopupManager()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Awake()
		{
		}

		private void OnApplicationQuit()
		{
		}

		public static void AddToQueue(UIPopup popup, bool instantAction = false)
		{
		}

		public static void ClearQueue(bool instantAction = false)
		{
		}

		public static UIPopup GetPopup(string popupName)
		{
			return null;
		}

		private static UIPopupQueueData GetPopupData(string popupName)
		{
			return null;
		}

		private static UIPopupQueueData GetPopupData(UIPopup popup)
		{
			return null;
		}

		public static bool HideCurrentVisiblePopup(bool instantAction = false)
		{
			return false;
		}

		public static bool IsInQueue(string popupName)
		{
			return false;
		}

		public static bool IsInQueue(UIPopup popup)
		{
			return false;
		}

		public static void RemoveFromQueue(string popupName, bool showNextInQueue = true)
		{
		}

		public static void RemoveFromQueue(UIPopup popup, bool showNextInQueue = true)
		{
		}

		public static void ShowNextInQueue()
		{
		}

		public static void ShowPopup(UIPopup popup, bool addToPopupQueue, bool instantAction, string targetCanvasName)
		{
		}

		public static void ShowPopup(UIPopup popup, bool addToPopupQueue, bool instantAction)
		{
		}

		public static UIPopup ShowPopup(string popupName, bool addToPopupQueue, bool instantAction, string targetCanvasName)
		{
			return null;
		}

		public static UIPopup ShowPopup(string popupName, bool addToPopupQueue, bool instantAction)
		{
			return null;
		}

		private static UIPopupManager AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
