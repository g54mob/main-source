using System;
using System.Collections.Generic;
using Assets.Dev.Scripts.Performance;
using Jundroo.Common.Platform;
using Jundroo.Juicy;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	public class UserInterfaceScript : MonoBehaviour
	{
		private GraphicRaycaster _raycaster;

		public WidgetContext Context { get; private set; }

		public GameObject FindGameObjectAtPosition(Vector3 position)
		{
			PointerEventData eventData = new PointerEventData(EventSystem.current)
			{
				position = position
			};
			List<RaycastResult> list = new List<RaycastResult>();
			_raycaster.Raycast(eventData, list);
			if (list.Count > 0)
			{
				return list[0].gameObject;
			}
			return null;
		}

		public void InitializeContext(UserInterface userInterface)
		{
			Context = userInterface.CreateContext(GetComponent<RectTransform>(), null);
			Context.LoadWidgetFromXml("Xml/RootUserInterface", null);
			_raycaster = base.gameObject.AddComponent<GraphicRaycaster>();
		}

		protected virtual void LateUpdate()
		{
			Context.LateUpdate();
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			if (!UnityEngine.Input.GetKeyDown(KeyCode.F11) || !UnityEngine.Input.GetKey(KeyCode.LeftControl))
			{
				return;
			}
			if ((Device.IsDebugBuild || Device.IsUnityEditor) && UnityEngine.Input.GetKey(KeyCode.LeftShift))
			{
				GameObject persistentScriptsContainer = Game.Instance.PersistentScriptsContainer;
				Type typeFromHandle = typeof(PerformanceDebugScript);
				Component component = persistentScriptsContainer.GetComponent(typeFromHandle);
				if (component == null)
				{
					persistentScriptsContainer.AddComponent(typeFromHandle);
				}
				else
				{
					UnityEngine.Object.Destroy(component);
				}
			}
			else
			{
				Game.Instance.UserInterface.CreatePerformanceStatsDialog();
			}
		}
	}
}
