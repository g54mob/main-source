using System.Collections;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.PlayerInput;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_DisassembleLongActionProgressBar : MonoBehaviour
	{
		[SerializeField]
		private GUI_ScreenObjectBase progressBarPanel;

		[SerializeField]
		private GUI_ImageBar imageBar;

		[SerializeField]
		private int verticalOffset;

		[SerializeField]
		[Range(0f, 0.9f)]
		private float filledPercentageAtStart = 0.2f;

		[SerializeField]
		private float delayBeforeHiding = 1f;

		private readonly List<ThreadedElement> longActionElements = new List<ThreadedElement>();

		private readonly List<ElementSocket> longActionElementSockets = new List<ElementSocket>();

		private IPlayerInput playerInput;

		private ThreadedElement currentLongActionElement;

		private float progressMultiplier;

		private Coroutine awaitFullShowCoroutine;

		private Coroutine hideAfterFullyShownCoroutine;

		[Inject]
		private void Construct(IPlayerInput playerInput)
		{
			this.playerInput = playerInput;
		}

		private void Awake()
		{
			progressMultiplier = 1f - filledPercentageAtStart;
			progressBarPanel.Hide();
		}

		private void LateUpdate()
		{
			if (!(currentLongActionElement == null) && !(currentLongActionElement.Progress >= 1f))
			{
				UpdateProgressBarView();
			}
		}

		private void OnDestroy()
		{
			Clear();
		}

		public void Init(Device placedDevice)
		{
			if (longActionElements.Count > 0 || longActionElementSockets.Count > 0)
			{
				Clear();
			}
			foreach (ElementSocket elementSocket in placedDevice.ElementSockets)
			{
				if (!(elementSocket.CompatibleElementInfo.Prefab is ThreadedElement))
				{
					continue;
				}
				longActionElementSockets.Add(elementSocket);
				if ((bool)elementSocket.NestedElement)
				{
					if (!(elementSocket.NestedElement is ThreadedElement item))
					{
						Debug.LogError(string.Format("Nested {0} of {1} is not {2}", "element", "socket", typeof(ThreadedElement)));
						longActionElementSockets.Remove(elementSocket);
					}
					else
					{
						longActionElements.Add(item);
					}
				}
			}
			SubscribeElements();
		}

		public void Hide()
		{
			progressBarPanel.Hide();
			Clear();
		}

		private void Clear()
		{
			UnsubscribeElements();
			longActionElements.Clear();
			longActionElementSockets.Clear();
			if (awaitFullShowCoroutine != null)
			{
				StopCoroutine(awaitFullShowCoroutine);
				awaitFullShowCoroutine = null;
			}
			if (hideAfterFullyShownCoroutine != null)
			{
				StopCoroutine(hideAfterFullyShownCoroutine);
				hideAfterFullyShownCoroutine = null;
			}
		}

		private void SubscribeElements()
		{
			foreach (ElementSocket longActionElementSocket in longActionElementSockets)
			{
				longActionElementSocket.OnNestedElementChanged += ResolveLongActionSocketChanged;
			}
			foreach (ThreadedElement longActionElement in longActionElements)
			{
				SubscribeElement(longActionElement);
			}
		}

		private void SubscribeElement(ThreadedElement element)
		{
			element.OnStartedHolding.AddListener(ResolveLongActionStarted);
			element.OnStoppedHolding.AddListener(ResolveLongActionStopped);
			element.OnInteractionComplete.AddListener(ResolveLongActionStopped);
		}

		private void UnsubscribeElements()
		{
			foreach (ElementSocket longActionElementSocket in longActionElementSockets)
			{
				if (!longActionElementSocket)
				{
					return;
				}
				longActionElementSocket.OnNestedElementChanged -= ResolveLongActionSocketChanged;
			}
			foreach (ThreadedElement longActionElement in longActionElements)
			{
				if (!longActionElement)
				{
					break;
				}
				UnsubscribeElement(longActionElement);
			}
		}

		private void UnsubscribeElement(ThreadedElement element)
		{
			element.OnStartedHolding.RemoveListener(ResolveLongActionStarted);
			element.OnStoppedHolding.RemoveListener(ResolveLongActionStopped);
			element.OnInteractionComplete.RemoveListener(ResolveLongActionStopped);
		}

		private void ResolveLongActionSocketChanged(ElementSocket socket)
		{
			if (!socket.NestedElement)
			{
				foreach (ThreadedElement longActionElement in longActionElements)
				{
					if (!longActionElement.InSocket)
					{
						UnsubscribeElement(longActionElement);
						longActionElements.Remove(longActionElement);
						ResolveLongActionStopped();
						break;
					}
				}
				return;
			}
			if (!(socket.NestedElement is ThreadedElement threadedElement))
			{
				Debug.LogError(string.Format("Nested {0} of {1} is not {2}", "element", "socket", typeof(ThreadedElement)));
				longActionElementSockets.Remove(socket);
			}
			else
			{
				longActionElements.Add(threadedElement);
				SubscribeElement(threadedElement);
			}
		}

		private void ResolveLongActionStarted(ThreadedElement longActionElement, ToolInfo toolUsed)
		{
			currentLongActionElement = longActionElement;
			if (currentLongActionElement == null || currentLongActionElement.IsBlocked)
			{
				return;
			}
			imageBar.SetBaseValue(1f, filledPercentageAtStart + currentLongActionElement.HoldElementProgress * progressMultiplier, isReversed_in: true);
			if (awaitFullShowCoroutine == null)
			{
				progressBarPanel.Show();
				FollowCursorDetectorPosition();
				if (hideAfterFullyShownCoroutine != null)
				{
					StopCoroutine(hideAfterFullyShownCoroutine);
					hideAfterFullyShownCoroutine = null;
				}
				awaitFullShowCoroutine = StartCoroutine(AwaitFullyShownCoroutine());
			}
		}

		private void ResolveLongActionStopped()
		{
			currentLongActionElement = null;
			hideAfterFullyShownCoroutine = StartCoroutine(HideAfterFullyShownCoroutine());
		}

		private IEnumerator AwaitFullyShownCoroutine()
		{
			while (progressBarPanel.IsCurrentlyTweening)
			{
				yield return null;
			}
			awaitFullShowCoroutine = null;
		}

		private IEnumerator HideAfterFullyShownCoroutine()
		{
			yield return awaitFullShowCoroutine;
			yield return new WaitForSeconds(delayBeforeHiding);
			progressBarPanel.Hide();
			hideAfterFullyShownCoroutine = null;
		}

		private void UpdateProgressBarView()
		{
			imageBar.SetValue(filledPercentageAtStart + currentLongActionElement.HoldElementProgress * progressMultiplier);
		}

		private void FollowCursorDetectorPosition()
		{
			if (playerInput != null)
			{
				float num = 1080f;
				float num2 = (float)(verticalOffset * Screen.height) / num;
				base.transform.position = playerInput.GetMousePosition() + Vector2.up * num2;
			}
		}
	}
}
