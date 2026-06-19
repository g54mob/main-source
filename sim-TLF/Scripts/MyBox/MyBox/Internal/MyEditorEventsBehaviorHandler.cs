using System;
using UnityEngine;

namespace MyBox.Internal
{
	public class MyEditorEventsBehaviorHandler : MonoBehaviour
	{
		private static MyEditorEventsBehaviorHandler _instance;

		public static event Action OnGUIEvent;

		public static event Action OnUpdate;

		public static void InitializeInstance()
		{
			if (!(_instance != null))
			{
				GameObject obj = new GameObject("MyEditorEventsBehaviorHandler");
				_instance = obj.AddComponent<MyEditorEventsBehaviorHandler>();
				if (Application.isPlaying)
				{
					UnityEngine.Object.DontDestroyOnLoad(_instance.gameObject);
				}
				obj.hideFlags = HideFlags.HideAndDontSave;
			}
		}

		private void OnGUI()
		{
			MyEditorEventsBehaviorHandler.OnGUIEvent?.Invoke();
		}

		private void Update()
		{
			MyEditorEventsBehaviorHandler.OnUpdate?.Invoke();
		}

		private void OnDisable()
		{
			MyEditorEventsBehaviorHandler.OnGUIEvent = null;
		}
	}
}
