using System;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace CTS.BBT
{
	[DefaultExecutionOrder(-1)]
	internal sealed class ContextualActionsInput : MonoSingleton<ContextualActionsInput>, IContextActor, ILockable
	{
		[SerializeField]
		private float _rayDistance = 30f;

		[SerializeField]
		private LayerMask _layerMask = -1;

		[SerializeField]
		[NavArea(true)]
		private int _navmeshArea;

		[SerializeField]
		private SelectionModes _validSelectionModes;

		[SerializeField]
		private bool _debug;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public ContextActorData ContextActorData { get; } = new ContextActorData();

		public Vector3? SelectionHitPoint { get; private set; }

		public static event Action<IContextActor> OnRightClickContextActor;

		private void EnableInputs()
		{
			InputManager.game.live.contextAction.onComplete += InputContextAction;
		}

		private void DisableInputs()
		{
			InputManager.game.live.contextAction.onComplete -= InputContextAction;
		}

		private void InputContextAction(InputAction.CallbackContext ctx)
		{
			if (CTSSingleton<WorldSelector>.TryGetInstance(out var outInstance) && outInstance.IsActive() && _validSelectionModes.CanBeSelectedBy(outInstance.CurrentSelectionMode) && !TryContextAction())
			{
				TryGroundContextAction();
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnEnable()
		{
			EnableInputs();
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}

		private void OnDisable()
		{
			DisableInputs();
		}

		private bool TryContextAction()
		{
			IContextActor hovered = WorldSelector.GetHovered<IContextActor>();
			if (hovered == null)
			{
				return false;
			}
			ContextualActionsInput.OnRightClickContextActor?.Invoke(hovered);
			return true;
		}

		private void TryGroundContextAction()
		{
			Vector3 pos = Input.mousePosition.ToScreenPoint();
			NavMeshHit hit;
			if (!Physics.Raycast(MainCamera.CameraReference.ScreenPointToRay(pos), out var hitInfo, _rayDistance, _layerMask, QueryTriggerInteraction.Ignore))
			{
				SelectionHitPoint = null;
			}
			else if (NavMesh.SamplePosition(hitInfo.point, out hit, 0.5f, _navmeshArea))
			{
				SelectionHitPoint = hit.position;
				ContextualActionsInput.OnRightClickContextActor?.Invoke(this);
			}
			else
			{
				SelectionHitPoint = null;
			}
		}
	}
}
