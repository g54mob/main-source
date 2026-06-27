using System;
using System.Collections.Generic;
using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_StickerModePanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_SlidingPanelTweener panelTweener;

		[SerializeField]
		private List<GUI_DeviceStickerHolder> stickerHolders;

		private SlidingPanelState panelLastState;

		private void OnEnable()
		{
			panelLastState = panelTweener.State;
			if (panelLastState == SlidingPanelState.Hidden)
			{
				SetStickersToBottom();
			}
			else
			{
				SetStickersToCenter();
			}
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.OnStickerStartDrag = (Action<GUI_DeviceStickerHolder>)Delegate.Combine(stickerHolder.OnStickerStartDrag, new Action<GUI_DeviceStickerHolder>(ResolveStickerStartDrag));
				stickerHolder.OnStickerStopDrag = (Action<GUI_DeviceStickerHolder>)Delegate.Combine(stickerHolder.OnStickerStopDrag, new Action<GUI_DeviceStickerHolder>(ResolveStickerStopDrag));
			}
			panelTweener.OnTransitionStarted += ResolvePanelTweenerStartTransition;
			panelTweener.OnTransitionComplete += ResolvePanelTweenerCompleteTransition;
		}

		private void OnDisable()
		{
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.OnStickerStartDrag = (Action<GUI_DeviceStickerHolder>)Delegate.Remove(stickerHolder.OnStickerStartDrag, new Action<GUI_DeviceStickerHolder>(ResolveStickerStartDrag));
				stickerHolder.OnStickerStopDrag = (Action<GUI_DeviceStickerHolder>)Delegate.Remove(stickerHolder.OnStickerStopDrag, new Action<GUI_DeviceStickerHolder>(ResolveStickerStopDrag));
			}
			panelTweener.OnTransitionStarted -= ResolvePanelTweenerStartTransition;
			panelTweener.OnTransitionComplete -= ResolvePanelTweenerCompleteTransition;
		}

		public void Activate()
		{
			base.gameObject.SetActive(value: true);
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.Visualizer.PlayScaleAnimation();
			}
		}

		public void Deactivate()
		{
			base.gameObject.SetActive(value: false);
		}

		private void ResolveStickerStartDrag(GUI_DeviceStickerHolder stickerHolder)
		{
			stickerHolder.PickSticker(base.transform);
		}

		private void ResolveStickerStopDrag(GUI_DeviceStickerHolder stickerHolder)
		{
			stickerHolder.ReleaseSticker();
		}

		private void ResolvePanelTweenerStartTransition()
		{
			switch (panelTweener.State)
			{
			case SlidingPanelState.Hidden:
			case SlidingPanelState.Peeking:
				MoveStickersToForward();
				break;
			case SlidingPanelState.Open:
				if (panelLastState == SlidingPanelState.Hidden)
				{
					SetStickersToBottom();
				}
				else
				{
					MoveStickersToBackward();
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private void ResolvePanelTweenerCompleteTransition()
		{
			panelLastState = panelTweener.State;
			if (panelLastState == SlidingPanelState.Hidden)
			{
				SetStickersToBottom();
			}
			else
			{
				MoveStickersToCenter();
			}
		}

		private void MoveStickersToForward()
		{
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.Visualizer.PlayForwardMovementAnimation();
			}
		}

		private void MoveStickersToCenter()
		{
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.Visualizer.PlayCenterMovementAnimation();
			}
		}

		private void MoveStickersToBackward()
		{
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.Visualizer.PlayBackwardMovementAnimation();
			}
		}

		private void SetStickersToCenter()
		{
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.Visualizer.SetCentralPosition();
			}
		}

		private void SetStickersToBottom()
		{
			foreach (GUI_DeviceStickerHolder stickerHolder in stickerHolders)
			{
				stickerHolder.Visualizer.SetBottomPosition();
			}
		}
	}
}
