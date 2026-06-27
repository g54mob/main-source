using System.Collections;
using Restory.Gameplay.PlayerInput;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public class GUI_PcWindowsXpMouseCursor : MonoBehaviour
	{
		[SerializeField]
		private RectTransform pcCursor;

		private GUI_PcWindowsXpScreen windowsXpScreen;

		private IPlayerInput input;

		private Coroutine mouseTrackingCoroutine;

		[Inject]
		private void Construct(GUI_PcWindowsXpScreen windowsXpScreen, IPlayerInput input)
		{
			this.input = input;
			this.windowsXpScreen = windowsXpScreen;
			if (base.isActiveAndEnabled)
			{
				Init();
			}
		}

		private void OnEnable()
		{
			if ((bool)windowsXpScreen)
			{
				Init();
			}
		}

		private void Init()
		{
			ChangeCursorActiveState(windowsXpScreen.IsVisible);
			windowsXpScreen.OnIsVisibleChanged += ResolvePcScreenVisibilityChanged;
		}

		private void OnDisable()
		{
			if (windowsXpScreen.MonoShellExists())
			{
				windowsXpScreen.OnIsVisibleChanged -= ResolvePcScreenVisibilityChanged;
			}
			KillMouseTrackingCoroutine();
		}

		private void ResolvePcScreenVisibilityChanged()
		{
			ChangeCursorActiveState(windowsXpScreen.IsVisible);
		}

		private void ChangeCursorActiveState(bool shouldCursorBeActive)
		{
			if (shouldCursorBeActive)
			{
				if (mouseTrackingCoroutine == null)
				{
					mouseTrackingCoroutine = StartCoroutine(MouseTrackingCoroutine());
				}
			}
			else
			{
				KillMouseTrackingCoroutine();
				pcCursor.anchoredPosition = Vector2.negativeInfinity;
			}
		}

		private void KillMouseTrackingCoroutine()
		{
			if (mouseTrackingCoroutine != null)
			{
				StopCoroutine(mouseTrackingCoroutine);
				mouseTrackingCoroutine = null;
			}
		}

		private IEnumerator MouseTrackingCoroutine()
		{
			RectTransform pcScreenRect = base.transform as RectTransform;
			while (true)
			{
				Vector2 mousePosition = input.GetMousePosition();
				if (RectTransformUtility.RectangleContainsScreenPoint(pcScreenRect, mousePosition))
				{
					RectTransformUtility.ScreenPointToLocalPointInRectangle(pcScreenRect, mousePosition, null, out var localPoint);
					pcCursor.anchoredPosition = localPoint;
				}
				else
				{
					pcCursor.anchoredPosition = Vector2.negativeInfinity;
				}
				yield return null;
			}
		}
	}
}
