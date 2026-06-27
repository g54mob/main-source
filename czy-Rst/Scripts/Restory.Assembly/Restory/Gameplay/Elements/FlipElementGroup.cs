using System.Collections.Generic;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class FlipElementGroup : MonoBehaviour, IAnimatedElementGroup
	{
		private enum StartingOptions
		{
			StartOpened = 0,
			StartClosed = 1
		}

		[Header("Sockets")]
		[SerializeField]
		private FlipElementSocket flipElementSocket;

		[SerializeField]
		private List<ElementSocket> activeOnOpeningSockets;

		[SerializeField]
		private List<ElementSocket> inactiveOnOpeningSockets;

		[SerializeField]
		private List<ElementSocket> activeOnClosingSockets;

		[SerializeField]
		private List<ElementSocket> inactiveOnClosingSockets;

		[SerializeField]
		private List<ElementSocket> hiddenOnOpeningSockets;

		[SerializeField]
		private List<ElementSocket> hiddenOnClosingSockets;

		[SerializeField]
		private ElementSocket openTriggerSocket;

		[Space]
		[Header("Animation settings")]
		[SerializeField]
		private FlipAnimationSettings openingSettings;

		[SerializeField]
		private FlipAnimationSettings closingSettings;

		[Space]
		[Header("Starting options")]
		[SerializeField]
		private StartingOptions startingOptionIfDisassembled = StartingOptions.StartClosed;

		[SerializeField]
		private StartingOptions startingOptionIfAssembled = StartingOptions.StartClosed;

		[SerializeField]
		private StartingOptions startingOptionOnDeviceCheck = StartingOptions.StartClosed;

		private TweenSequencesService tweenSequences;

		private Vector3 initialPosition;

		private bool isOpen;

		private Sequence transitionSequence;

		private ElementButton openTrigger;

		public bool IsOpen => isOpen;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
			initialPosition = base.transform.localPosition;
		}

		private void OnEnable()
		{
			flipElementSocket.OnInteract += ResolveFlipElementInteraction;
			flipElementSocket.OnNestedElementChanged += ResolveGroupElementChanged;
			foreach (ElementSocket activeOnOpeningSocket in activeOnOpeningSockets)
			{
				activeOnOpeningSocket.OnNestedElementChanged += ResolveGroupElementChanged;
			}
			foreach (ElementSocket inactiveOnOpeningSocket in inactiveOnOpeningSockets)
			{
				inactiveOnOpeningSocket.OnNestedElementChanged += ResolveGroupElementChanged;
			}
			foreach (ElementSocket activeOnClosingSocket in activeOnClosingSockets)
			{
				activeOnClosingSocket.OnNestedElementChanged += ResolveGroupElementChanged;
			}
			foreach (ElementSocket inactiveOnClosingSocket in inactiveOnClosingSockets)
			{
				inactiveOnClosingSocket.OnNestedElementChanged += ResolveGroupElementChanged;
			}
			if (!openTriggerSocket)
			{
				return;
			}
			openTriggerSocket.OnNestedElementChanged += ResolveOpenTriggerSocketChanged;
			if ((bool)openTriggerSocket.NestedElement)
			{
				openTrigger = openTriggerSocket.NestedElement.GetComponentInChildren<ElementButton>();
				if ((bool)openTrigger)
				{
					openTrigger.OnActivated += ResolveOpenTriggerActivated;
				}
			}
		}

		private void OnDisable()
		{
			flipElementSocket.OnInteract -= ResolveFlipElementInteraction;
			flipElementSocket.OnNestedElementChanged -= ResolveGroupElementChanged;
			foreach (ElementSocket activeOnOpeningSocket in activeOnOpeningSockets)
			{
				activeOnOpeningSocket.OnNestedElementChanged -= ResolveGroupElementChanged;
			}
			foreach (ElementSocket inactiveOnOpeningSocket in inactiveOnOpeningSockets)
			{
				inactiveOnOpeningSocket.OnNestedElementChanged -= ResolveGroupElementChanged;
			}
			foreach (ElementSocket activeOnClosingSocket in activeOnClosingSockets)
			{
				activeOnClosingSocket.OnNestedElementChanged -= ResolveGroupElementChanged;
			}
			foreach (ElementSocket inactiveOnClosingSocket in inactiveOnClosingSockets)
			{
				inactiveOnClosingSocket.OnNestedElementChanged -= ResolveGroupElementChanged;
			}
			if ((bool)openTriggerSocket)
			{
				openTriggerSocket.OnNestedElementChanged -= ResolveOpenTriggerSocketChanged;
				if ((bool)openTrigger)
				{
					openTrigger.OnActivated -= ResolveOpenTriggerActivated;
					openTrigger = null;
				}
			}
		}

		public void Init()
		{
			isOpen = (CheckGroupIntegrity() ? (startingOptionIfAssembled == StartingOptions.StartOpened) : (startingOptionIfDisassembled == StartingOptions.StartOpened));
			ApplyTransformFromSettings(isOpen ? openingSettings : closingSettings);
			UpdateHiddenSockets(isVisible: false, isOpen ? hiddenOnOpeningSockets : hiddenOnClosingSockets);
			UpdateHiddenSockets(isVisible: true, isOpen ? hiddenOnClosingSockets : hiddenOnOpeningSockets);
		}

		public void Activate()
		{
			flipElementSocket.ChangeInteractivity(isInteractable: true);
			if (isOpen)
			{
				return;
			}
			BlockSockets(inactiveOnClosingSockets);
			if (!flipElementSocket.NestedElement)
			{
				if (startingOptionIfDisassembled == StartingOptions.StartOpened)
				{
					ApplyTransformFromSettings(openingSettings);
					isOpen = true;
				}
			}
			else if ((bool)openTriggerSocket)
			{
				flipElementSocket.ChangeInteractivity(isInteractable: false);
				if (!isOpen && !flipElementSocket.IsBlocked && startingOptionIfDisassembled == StartingOptions.StartOpened)
				{
					isOpen = true;
					PlayTransitionSequence(openingSettings);
				}
			}
		}

		public void Deactivate(bool isDeviceCheck)
		{
			if (!CheckGroupIntegrity())
			{
				return;
			}
			if (isDeviceCheck && startingOptionOnDeviceCheck == StartingOptions.StartOpened)
			{
				if (!isOpen)
				{
					isOpen = true;
					PlayTransitionSequence(openingSettings);
				}
			}
			else if (isOpen)
			{
				isOpen = false;
				PlayTransitionSequence(closingSettings);
			}
		}

		private bool CheckGroupIntegrity()
		{
			if (!flipElementSocket.NestedElement)
			{
				return false;
			}
			foreach (ElementSocket activeOnOpeningSocket in activeOnOpeningSockets)
			{
				if (!activeOnOpeningSocket.NestedElement)
				{
					return false;
				}
			}
			foreach (ElementSocket inactiveOnOpeningSocket in inactiveOnOpeningSockets)
			{
				if (!inactiveOnOpeningSocket.NestedElement)
				{
					return false;
				}
			}
			foreach (ElementSocket activeOnClosingSocket in activeOnClosingSockets)
			{
				if (!activeOnClosingSocket.NestedElement)
				{
					return false;
				}
			}
			foreach (ElementSocket inactiveOnClosingSocket in inactiveOnClosingSockets)
			{
				if (!inactiveOnClosingSocket.NestedElement)
				{
					return false;
				}
			}
			return true;
		}

		private void ResolveGroupElementChanged(ElementSocket changedSocket)
		{
			flipElementSocket.ChangeInteractivity(CheckGroupIntegrity());
			if (!flipElementSocket.NestedElement)
			{
				UnblockSockets(inactiveOnOpeningSockets);
				UnblockSockets(inactiveOnClosingSockets);
				if (startingOptionIfDisassembled == StartingOptions.StartOpened)
				{
					ApplyTransformFromSettings(openingSettings);
					isOpen = true;
				}
			}
		}

		private void ResolveFlipElementInteraction()
		{
			if (isOpen)
			{
				isOpen = false;
				PlayTransitionSequence(closingSettings);
				BlockSockets(inactiveOnClosingSockets);
				UnblockSockets(activeOnClosingSockets);
				if ((bool)openTriggerSocket)
				{
					flipElementSocket.ChangeInteractivity(isInteractable: false);
				}
			}
			else if (!openTriggerSocket)
			{
				isOpen = true;
				PlayTransitionSequence(openingSettings);
				BlockSockets(inactiveOnOpeningSockets);
				UnblockSockets(activeOnOpeningSockets);
			}
		}

		private void ResolveOpenTriggerSocketChanged(ElementSocket _)
		{
			if (!openTriggerSocket)
			{
				return;
			}
			if ((bool)openTrigger)
			{
				openTrigger.OnActivated -= ResolveOpenTriggerActivated;
				openTrigger = null;
			}
			if ((bool)openTriggerSocket.NestedElement)
			{
				openTrigger = openTriggerSocket.NestedElement.GetComponentInChildren<ElementButton>();
				if ((bool)openTrigger)
				{
					openTrigger.OnActivated += ResolveOpenTriggerActivated;
				}
			}
		}

		private void ResolveOpenTriggerActivated()
		{
			if (!isOpen)
			{
				isOpen = true;
				PlayTransitionSequence(openingSettings);
				BlockSockets(inactiveOnOpeningSockets);
				UnblockSockets(activeOnOpeningSockets);
			}
		}

		private void UnblockSockets(ICollection<ElementSocket> sockets)
		{
			flipElementSocket.UnblockExternalSockets(sockets);
		}

		private void BlockSockets(ICollection<ElementSocket> sockets)
		{
			flipElementSocket.BlockExternalSockets(sockets);
		}

		private void ApplyTransformFromSettings(FlipAnimationSettings settings)
		{
			base.transform.SetLocalPositionAndRotation(initialPosition + settings.TargetOffset, Quaternion.Euler(settings.TargetRotation));
		}

		private void PlayTransitionSequence(FlipAnimationSettings settings)
		{
			StartTransition();
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(base.transform.DOLocalRotate(settings.TargetRotation, settings.Duration).SetEase(settings.Ease)).Join(base.transform.DOLocalMove(initialPosition + settings.TargetOffset, settings.Duration).SetEase(settings.Ease)).OnComplete(CompleteTransition);
		}

		private void StartTransition()
		{
			UpdateHiddenSockets(isVisible: false, isOpen ? hiddenOnOpeningSockets : hiddenOnClosingSockets);
		}

		private void CompleteTransition()
		{
			if (isOpen && (bool)openTriggerSocket)
			{
				flipElementSocket.ChangeInteractivity(isInteractable: true);
			}
			UpdateHiddenSockets(isVisible: true, isOpen ? hiddenOnClosingSockets : hiddenOnOpeningSockets);
		}

		private void UpdateHiddenSockets(bool isVisible, ICollection<ElementSocket> sockets)
		{
			foreach (ElementSocket socket in sockets)
			{
				if ((bool)socket.NestedElement)
				{
					socket.NestedElement.gameObject.SetActive(isVisible);
				}
			}
		}
	}
}
