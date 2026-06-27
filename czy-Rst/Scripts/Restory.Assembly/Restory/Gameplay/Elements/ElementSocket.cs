using System;
using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Disassemble.Tooltips;
using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementSocket : MonoBehaviour
	{
		[SerializeField]
		private ElementInfo compatibleElementInfo;

		[SerializeField]
		private List<ElementSocket> blockers = new List<ElementSocket>();

		[SerializeField]
		private CustomDisassembleTooltipBehaviorBase customDisassembleTooltipBehavior;

		[SerializeField]
		private CustomAssembleTooltipBehaviorBase customAssembleTooltipBehavior;

		private readonly HashSet<ElementSocket> blockedSockets = new HashSet<ElementSocket>();

		private readonly HashSet<ElementSocket> additionalBlockers = new HashSet<ElementSocket>();

		private WorkSurface workSurface;

		private ElementProjectionFactory projectionFactory;

		private DisassembleStateMachine disassembleStateMachine;

		private ElementProjection smallElementProjection;

		private ElementBase nestedElement;

		private ElementBase lastNestedElement;

		public ElementInfo CompatibleElementInfo => compatibleElementInfo;

		public IReadOnlyCollection<ElementSocket> Blockers => blockers;

		public IReadOnlyCollection<ElementSocket> BlockedSockets => blockedSockets;

		public ElementBase NestedElement => nestedElement;

		public ElementBase LastNestedElement => lastNestedElement;

		public bool IsCoupled
		{
			get
			{
				if (!nestedElement)
				{
					return lastNestedElement;
				}
				return true;
			}
		}

		public CustomDisassembleTooltipBehaviorBase CustomDisassembleTooltipBehavior => customDisassembleTooltipBehavior;

		public CustomAssembleTooltipBehaviorBase CustomAssembleTooltipBehavior => customAssembleTooltipBehavior;

		public virtual bool IsBlocked
		{
			get
			{
				if (!nestedElement)
				{
					return false;
				}
				foreach (ElementSocket blocker in blockers)
				{
					if ((bool)blocker.nestedElement)
					{
						return true;
					}
				}
				foreach (ElementSocket additionalBlocker in additionalBlockers)
				{
					if ((bool)additionalBlocker.nestedElement)
					{
						return true;
					}
				}
				return false;
			}
		}

		public virtual bool IsAvailable
		{
			get
			{
				if ((bool)nestedElement || lastNestedElement is INonInstallableElement)
				{
					return false;
				}
				foreach (ElementSocket blockedSocket in blockedSockets)
				{
					if (!blockedSocket)
					{
						Debug.LogError("Reference to blocked socket was lost", base.gameObject);
					}
					else if (!blockedSocket.nestedElement || blockedSocket.nestedElement.Progress > 0f)
					{
						return false;
					}
				}
				return true;
			}
		}

		public event Action<ElementSocket> OnNestedElementChanged;

		[Inject]
		private void Construct(WorkSurface workSurface, ElementProjectionFactory projectionFactory, DisassembleStateMachine disassembleStateMachine)
		{
			this.workSurface = workSurface;
			this.projectionFactory = projectionFactory;
			this.disassembleStateMachine = disassembleStateMachine;
			Init();
		}

		private void Init()
		{
			foreach (ElementSocket blocker in blockers)
			{
				blocker.AddBlockedSocket(this);
			}
			ElementBase componentInChildren = base.transform.GetComponentInChildren<ElementBase>();
			if ((bool)componentInChildren)
			{
				SetNestedElement(componentInChildren);
			}
		}

		private void OnDestroy()
		{
			if ((bool)nestedElement)
			{
				nestedElement.OnDetached.RemoveListener(ResolveElementDetached);
			}
			HideSmallElementProjection();
		}

		public void Activate()
		{
			if ((bool)compatibleElementInfo && compatibleElementInfo.Category == ElementCategory.Small && (bool)lastNestedElement && IsAvailable)
			{
				ShowSmallElementProjection(lastNestedElement);
			}
			else if ((bool)nestedElement)
			{
				nestedElement.IsBlocked = IsBlocked;
				nestedElement.Activate();
			}
		}

		public void Deactivate()
		{
			if ((bool)compatibleElementInfo && compatibleElementInfo.Category == ElementCategory.Small && (bool)lastNestedElement)
			{
				HideSmallElementProjection();
			}
			else if ((bool)nestedElement)
			{
				nestedElement.IsBlocked = true;
				nestedElement.Deactivate();
			}
		}

		public void AttachElement(ElementBase element)
		{
			SetNestedElement(element);
			workSurface.RemoveElement(element);
			element.transform.SetParent(base.transform);
			element.AttachToDevice();
			NotifySockets();
		}

		public void DetachElement()
		{
			ResolveElementDetached();
		}

		public void DetachAndUnblockElementWithoutNotifyingLinkedSockets()
		{
			if (!nestedElement)
			{
				Debug.LogError("Reference to nested element was lost");
				return;
			}
			nestedElement.OnDetached.RemoveListener(ResolveElementDetached);
			workSurface.AddElement(nestedElement);
			lastNestedElement = nestedElement;
			nestedElement.InSocket = false;
			nestedElement.IsBlocked = false;
			nestedElement = null;
			if (lastNestedElement.Info.Category == ElementCategory.Small)
			{
				ShowSmallElementProjection(lastNestedElement);
			}
			this.OnNestedElementChanged?.Invoke(this);
		}

		public void DestroyNestedElement()
		{
			if (!nestedElement)
			{
				Debug.LogError("Reference to nested element was lost");
				return;
			}
			nestedElement.OnDetached.RemoveListener(ResolveElementDetached);
			UnityEngine.Object.Destroy(nestedElement.gameObject);
			nestedElement = null;
			this.OnNestedElementChanged?.Invoke(this);
		}

		public void CoupleSmallElement(ElementBase element)
		{
			if ((bool)nestedElement)
			{
				Debug.LogError("Socket has nested element attached");
			}
			else if (element.Info != compatibleElementInfo)
			{
				Debug.LogError("Element for couple is not compatible");
			}
			else if (compatibleElementInfo.Category != ElementCategory.Small)
			{
				Debug.LogError("Element for couple is not small");
			}
			else if ((bool)lastNestedElement)
			{
				Debug.LogError("Socket coupled with detached element already");
			}
			else
			{
				lastNestedElement = element;
			}
		}

		public bool TryHighlightSmallElementProjection()
		{
			if (!smallElementProjection)
			{
				return false;
			}
			smallElementProjection.Highlight();
			return true;
		}

		protected virtual void SetNestedElement(ElementBase element)
		{
			if (!element || (bool)nestedElement || !ValidateElementCompatibility(element))
			{
				Debug.LogError("Failed to set nested element");
				return;
			}
			nestedElement = element;
			nestedElement.InSocket = true;
			nestedElement.OnDetached.AddListener(ResolveElementDetached);
			nestedElement.BehaviorSwitcher.SwitchToInstalledBehavior();
			lastNestedElement = null;
			this.OnNestedElementChanged?.Invoke(this);
		}

		protected virtual void ResolveElementDetached()
		{
			if (!nestedElement)
			{
				Debug.LogError("Reference to nested element was lost");
				return;
			}
			nestedElement.OnDetached.RemoveListener(ResolveElementDetached);
			workSurface.AddElement(nestedElement);
			lastNestedElement = nestedElement;
			nestedElement.InSocket = false;
			nestedElement = null;
			NotifySockets();
			if (lastNestedElement.Info.Category == ElementCategory.Small)
			{
				ShowSmallElementProjection(lastNestedElement);
			}
			this.OnNestedElementChanged?.Invoke(this);
		}

		private void AddBlockedSocket(ElementSocket blockedSocket)
		{
			blockedSockets.Add(blockedSocket);
		}

		protected void AddExternalBlockedSocket(ElementSocket blockedSocket)
		{
			blockedSockets.Add(blockedSocket);
			blockedSocket.additionalBlockers.Add(this);
		}

		protected void RemoveExternalBlockedSocket(ElementSocket socketToUnblock)
		{
			blockedSockets.Remove(socketToUnblock);
			socketToUnblock.additionalBlockers.Remove(this);
		}

		protected void NotifySockets()
		{
			foreach (ElementSocket blocker in blockers)
			{
				blocker.BlockedSocketChanged();
			}
			foreach (ElementSocket additionalBlocker in additionalBlockers)
			{
				additionalBlocker.BlockerChanged();
			}
			foreach (ElementSocket blockedSocket in blockedSockets)
			{
				blockedSocket.BlockerChanged();
			}
		}

		protected void NotifyExternalSocket(ElementSocket socket)
		{
			socket.BlockerChanged();
		}

		private void BlockedSocketChanged()
		{
			foreach (ElementSocket blockedSocket in blockedSockets)
			{
				if (!blockedSocket.nestedElement)
				{
					Deactivate();
					return;
				}
			}
			Activate();
			if ((bool)smallElementProjection)
			{
				smallElementProjection.Highlight();
			}
		}

		private void BlockerChanged()
		{
			if ((bool)nestedElement)
			{
				nestedElement.IsBlocked = IsBlocked;
			}
		}

		private void ResolveProjectionActivated()
		{
			HideSmallElementProjection();
			if (!lastNestedElement)
			{
				Debug.LogError("Reference to last nested element was lost");
				return;
			}
			AttachElement(lastNestedElement);
			disassembleStateMachine.Enter<InstallingDisassembleState, ElementBase>(nestedElement);
		}

		private void ShowSmallElementProjection(ElementBase targetElement)
		{
			HideSmallElementProjection();
			smallElementProjection = projectionFactory.CreateSmallElementProjection(detectable: true, targetElement.ProjectionData, base.transform);
			smallElementProjection.MakeDim();
			smallElementProjection.OnActivated += ResolveProjectionActivated;
		}

		private void HideSmallElementProjection()
		{
			if ((bool)smallElementProjection)
			{
				smallElementProjection.OnActivated -= ResolveProjectionActivated;
				projectionFactory.DestroySmallElementProjection(smallElementProjection);
				smallElementProjection = null;
			}
		}

		private bool ValidateElementCompatibility(ElementBase element)
		{
			if (!element)
			{
				return false;
			}
			if (!element.Info)
			{
				Debug.LogError($"{typeof(ElementInfo)} was lost on element {element.name}");
				return false;
			}
			bool num = element.Info == compatibleElementInfo;
			if (!num)
			{
				Debug.LogError($"Element {element.name} has not compatible {typeof(ElementInfo)}");
			}
			return num;
		}
	}
}
