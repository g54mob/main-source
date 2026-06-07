using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class EventSystemManager : Singleton<EventSystemManager>
	{
		[field: NonSerialized]
		private EventSystem EventSystem { get; set; }

		[field: NonSerialized]
		private BaseInputModule InputModule { get; set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void RuntimeInitialize()
		{
			Singleton<EventSystemManager>.Instance.WakeUp();
		}

		protected override void OnCreate()
		{
			base.OnCreate();
			SceneManager.sceneLoaded += OnSceneLoad;
			Initialize();
		}

		private void OnSceneLoad(Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
		{
			Initialize();
		}

		public static bool RequestEventSystem()
		{
			if (Singleton<EventSystemManager>.Instance.EventSystem != null && Singleton<EventSystemManager>.Instance.InputModule != null)
			{
				return true;
			}
			Singleton<EventSystemManager>.Instance.EventSystem = UnityEngine.Object.FindAnyObjectByType<EventSystem>();
			Singleton<EventSystemManager>.Instance.InputModule = UnityEngine.Object.FindAnyObjectByType<BaseInputModule>();
			if (Singleton<EventSystemManager>.Instance.EventSystem == null)
			{
				Debug.LogError("<b>Event System:</b> No instance found");
				return false;
			}
			if (Singleton<EventSystemManager>.Instance.InputModule == null)
			{
				Debug.LogError("<b>Event System:</b> No module found");
				return false;
			}
			return true;
		}

		public static void Select(GameObject target)
		{
			if (RequestEventSystem() && !(Singleton<EventSystemManager>.Instance.EventSystem.currentSelectedGameObject == target))
			{
				Singleton<EventSystemManager>.Instance.EventSystem.SetSelectedGameObject(target);
			}
		}

		public static void Deselect()
		{
			if (RequestEventSystem() && !(Singleton<EventSystemManager>.Instance.EventSystem.currentSelectedGameObject == null))
			{
				Singleton<EventSystemManager>.Instance.EventSystem.SetSelectedGameObject(null);
			}
		}

		private void Initialize()
		{
			GameObject instance = ShortcutMainCamera.Instance;
			if (!(instance == null))
			{
				PhysicsRaycaster physicsRaycaster = instance.Get<PhysicsRaycaster>();
				Physics2DRaycaster physics2DRaycaster = instance.Get<Physics2DRaycaster>();
				if (physicsRaycaster == null)
				{
					instance.gameObject.Add<PhysicsRaycaster>();
				}
				if (physics2DRaycaster == null)
				{
					instance.gameObject.Add<Physics2DRaycaster>();
				}
			}
		}
	}
}
