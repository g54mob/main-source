using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CW.Common
{
	[ExecuteInEditMode]
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwDemoButton")]
	[AddComponentMenu("Common/CW Demo Button")]
	public class CwDemoButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		public enum LinkType
		{
			PreviousScene = 0,
			NextScene = 1,
			Publisher = 2,
			URL = 3,
			Isolate = 4
		}

		public enum ToggleType
		{
			KeepSelected = 0,
			ToggleSelection = 1,
			SelectPrevious = 2
		}

		[SerializeField]
		private LinkType link;

		[SerializeField]
		private string urlTarget;

		[SerializeField]
		private Transform isolateTarget;

		[SerializeField]
		private ToggleType isolateToggle;

		[NonSerialized]
		private CanvasGroup cachedCanvasGroup;

		[NonSerialized]
		private Transform previousChild;

		public LinkType Link
		{
			get
			{
				return default(LinkType);
			}
			set
			{
			}
		}

		public string UrlTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform IsolateTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ToggleType IsolateToggle
		{
			get
			{
				return default(ToggleType);
			}
			set
			{
			}
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void Update()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		private static int GetCurrentLevel()
		{
			return 0;
		}

		private static int GetLevelCount()
		{
			return 0;
		}

		private static void LoadLevel(int index)
		{
		}
	}
}
