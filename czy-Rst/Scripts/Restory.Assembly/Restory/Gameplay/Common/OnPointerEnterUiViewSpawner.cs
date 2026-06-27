using System.Collections;
using System.Linq;
using Helpers.Extensions;
using Restory.UserInterface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.Gameplay.Common
{
	public class OnPointerEnterUiViewSpawner : UiViewSpawnerBase, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IActiveStateSwitchable
	{
		[SerializeField]
		private float displayDelay;

		[SerializeField]
		private bool hideOnPointerExit = true;

		private bool pointerEntered;

		private bool isActive = true;

		public bool IsActive
		{
			get
			{
				return isActive;
			}
			set
			{
				if (isActive != value)
				{
					isActive = value;
					CheckPointerAndActiveState();
				}
			}
		}

		public bool PointerEntered => pointerEntered;

		public bool HideOnPointerExit
		{
			get
			{
				return hideOnPointerExit;
			}
			set
			{
				hideOnPointerExit = value;
			}
		}

		private void OnDisable()
		{
			Dispose(views);
		}

		protected override void Instantiate(GameObject[] viewPrefabs)
		{
			base.Instantiate(viewPrefabs);
			GameObject[] array = views;
			foreach (GameObject viewPrefab in array)
			{
				GUI_ScreenObjectBase viewInstance = guiGameplayOverlayCanvas.GetViewInstance(base.gameObject, viewPrefab);
				if ((bool)viewInstance && viewInstance.TryGetComponent<EventTrigger>(out var component))
				{
					EventTrigger.Entry entry = component.triggers.FirstOrDefault((EventTrigger.Entry x) => x.eventID == EventTriggerType.PointerExit);
					if (entry == null)
					{
						break;
					}
					entry.callback.AddListener(OnPointerExit);
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointerEntered = true;
			CheckPointerAndActiveState();
		}

		private void OnPointerExit(BaseEventData baseEvent)
		{
			OnPointerExit(baseEvent as PointerEventData);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (eventData == null)
			{
				Debug.LogWarning("[OnPointerEnterUiViewSpawner] OnPointerExit skipped.Reason: eventData is null");
				return;
			}
			pointerEntered = false;
			GameObject gameObject = eventData.pointerCurrentRaycast.gameObject;
			if ((bool)gameObject)
			{
				GameObject[] array = views;
				foreach (GameObject gameObject2 in array)
				{
					if (!(gameObject2 == null))
					{
						GUI_ScreenObjectBase viewInstance = guiGameplayOverlayCanvas.GetViewInstance(base.gameObject, gameObject2);
						if ((bool)viewInstance && viewInstance.gameObject != null && gameObject.transform.ContainsInParent(viewInstance.transform))
						{
							return;
						}
					}
				}
			}
			if (hideOnPointerExit)
			{
				DisposeViews();
			}
		}

		public void CheckPointerAndActiveState()
		{
			if (isActive && pointerEntered)
			{
				ProcessPointerEnteredActiveUiViewSpawner();
			}
		}

		private void ProcessPointerEnteredActiveUiViewSpawner()
		{
			if (displayDelay > 0f)
			{
				StartCoroutine(PostponedViewSpawn());
			}
			else
			{
				InstantiateViews();
			}
		}

		private IEnumerator PostponedViewSpawn()
		{
			yield return new WaitForSecondsRealtime(displayDelay);
			if (!hideOnPointerExit || pointerEntered)
			{
				InstantiateViews();
			}
		}

		public void InstantiateViews()
		{
			Instantiate(views);
		}

		public void DisposeViews()
		{
			Dispose(views);
		}

		protected override void Dispose(GameObject[] viewPrefabs)
		{
			if (!guiGameplayOverlayCanvas)
			{
				return;
			}
			GameObject[] array = views;
			foreach (GameObject viewPrefab in array)
			{
				GUI_ScreenObjectBase viewInstance = guiGameplayOverlayCanvas.GetViewInstance(base.gameObject, viewPrefab);
				if ((bool)viewInstance && viewInstance.TryGetComponent<EventTrigger>(out var component))
				{
					EventTrigger.Entry entry = component.triggers.FirstOrDefault((EventTrigger.Entry x) => x.eventID == EventTriggerType.PointerExit);
					if (entry == null)
					{
						return;
					}
					entry.callback.RemoveListener(OnPointerExit);
				}
			}
			base.Dispose(viewPrefabs);
		}
	}
}
