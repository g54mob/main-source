using System;
using System.Collections.Generic;
using DG.Tweening;
using Dhs5.Utility.Databases;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace Simulator.GameWorld
{
	public class PlayerCharacter : Character, IPlayerInputReceiver
	{
		[SerializeField]
		private ObjectStack m_stack;

		[SerializeField]
		private GameObject m_handsContentParent;

		[SerializeField]
		private BroomGrabber m_broomGrabber;

		[Header("Camera")]
		[SerializeField]
		private POVCamera m_camera;

		[Header("Movement")]
		[SerializeField]
		private PlayerCharacterMovement m_movement;

		[Header("Furnitures")]
		[SerializeField]
		private FurnitureMover m_mover;

		[Header("Context")]
		[SerializeField]
		[ReadOnly(false, false)]
		private EPlayerCharacterContext m_context;

		private object m_mainHoldInteractable;

		private object m_secondHoldInteractable;

		private Broom m_currentBroom;

		private bool m_isLeftClickAvailable = true;

		private Tween m_delayActionLeftClick;

		private bool m_stackableBoxEventsRegistered;

		private StackableBox m_stackableBox;

		public override bool IsPlayer => true;

		public EPlayerCharacterContext CharacterContext
		{
			get
			{
				return m_context;
			}
			set
			{
				if (m_context != value)
				{
					EPlayerCharacterContext context = m_context;
					m_context = value;
					this.CharacterContextChanged?.Invoke(context, m_context);
				}
			}
		}

		public PlayerCharacterMovement Movement => m_movement;

		public BroomGrabber BroomGrabber => m_broomGrabber;

		public bool MainHoldInteractableStarted { get; private set; }

		public bool SecondHoldInteractableStarted { get; private set; }

		public override CinemachineCamera Camera => m_camera.CinemachineCamera;

		public static event Action CameraDeactivated;

		public event Action<InputManager.ESide> OnHoldInputProcess;

		public event Action<InputManager.ESide> OnHoldInputCancel;

		public event Action<EPlayerCharacterContext, EPlayerCharacterContext> CharacterContextChanged;

		public event Action HandContentChanged;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_camera.SetEnable(enable: false);
			EventManager.OnWorldEvent += OnWorldEvent;
			EventManager.OnGameEvent += OnGameEvent;
			CameraManager.CamDeactivated += OnCameraDeactivated;
			RegisterToHandStackEvents(register: true);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			EventManager.OnWorldEvent -= OnWorldEvent;
			EventManager.OnGameEvent -= OnGameEvent;
			CameraManager.CamDeactivated -= OnCameraDeactivated;
			RegisterToHandStackEvents(register: false);
			RegisterToStackableBoxEvents(register: false);
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.WORLD_REGISTRATION:
				World.RegisterSingletonStatic(this);
				break;
			case EWorldEvent.LOADING_PHASE1:
				Load();
				break;
			case EWorldEvent.INITIALISATION:
				Init();
				break;
			case EWorldEvent.START:
				m_camera.SetEnable(enable: true);
				break;
			case EWorldEvent.SAVE:
				Save();
				break;
			case EWorldEvent.LOADING_PHASE2:
			case EWorldEvent.PAUSE:
			case EWorldEvent.UNPAUSE:
				break;
			}
		}

		private void OnGameEvent(EGameEvent gameEvent)
		{
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				m_camera.SetEnable(enable: true);
				Anchor(World.PlayerStart.transform);
				break;
			case EGameEvent.DAY_END:
				m_camera.SetEnable(enable: false);
				break;
			}
		}

		public virtual void Load()
		{
			SaveClass_Player player = SaveManager.CurrentSave.player;
			if (player.productsQuantity > 0)
			{
				switch (player.stackableType)
				{
				case IStackable.EType.PRODUCT:
					m_stack.Fill(ProductDatabase.Get(player.productsUID), player.productsQuantity);
					break;
				case IStackable.EType.TRASH:
				{
					if (Database.GetDataByUID<DirtDatabase, TrashData>(player.productsUID, out var data))
					{
						m_stack.Fill(data, player.productsQuantity);
					}
					break;
				}
				}
			}
			else
			{
				if (!player.productsUIDs.IsValid())
				{
					return;
				}
				switch (player.stackableType)
				{
				case IStackable.EType.PRODUCT:
				{
					List<ProductData> list2 = new List<ProductData>();
					for (int num2 = player.productsUIDs.Count - 1; num2 >= 0; num2--)
					{
						ProductData item = ProductDatabase.Get(player.productsUIDs[num2]);
						list2.Add(item);
					}
					m_stack.PreciseFill(list2);
					break;
				}
				case IStackable.EType.TRASH:
				{
					List<TrashData> list = new List<TrashData>();
					for (int num = player.productsUIDs.Count - 1; num >= 0; num--)
					{
						if (Database.GetDataByUID<DirtDatabase, TrashData>(player.productsUIDs[num], out var data2))
						{
							list.Add(data2);
						}
					}
					if (list.Count > 0)
					{
						m_stack.PreciseFill(list);
					}
					break;
				}
				}
			}
		}

		public virtual void Init()
		{
			Anchor(SaveManager.CurrentSave.player.position, SaveManager.CurrentSave.player.yRotation);
		}

		public virtual void Save()
		{
			SaveManager.CurrentSave.player.position = base.transform.position;
			SaveManager.CurrentSave.player.yRotation = m_camera.PanTilt.PanAxis.Value;
			if (HasStackable(out var stackable))
			{
				List<int> uids;
				if (m_stack.IsStackHomogeneous())
				{
					SaveManager.CurrentSave.player.productsUID = m_stack.GetCurrentUID();
					SaveManager.CurrentSave.player.productsQuantity = m_stack.ActualCount;
				}
				else if (m_stack.TryGetStackUIDs(out uids))
				{
					SaveManager.CurrentSave.player.productsUIDs = uids;
				}
				SaveManager.CurrentSave.player.stackableType = stackable.StackableData.StackableType;
			}
			else
			{
				SaveManager.CurrentSave.player.productsUID = 0;
				SaveManager.CurrentSave.player.productsQuantity = 0;
			}
		}

		public override void OnControlledBy(Controller controller)
		{
			base.OnControlledBy(controller);
			m_camera.SetEnable(enable: true);
		}

		public override void OnUncontrolledBy(Controller controller)
		{
			base.OnUncontrolledBy(controller);
			m_camera.SetEnable(enable: false);
		}

		public virtual void OnPlayerInput_Look(Vector2 delta)
		{
		}

		public virtual void OnPlayerInput_Move(Vector3 moveInput)
		{
			m_movement.Move(moveInput);
		}

		public virtual void OnPlayerInput_Jump()
		{
			m_movement.Jump();
		}

		public void OnPlayerInput_Crouch()
		{
			m_movement.Crouch();
		}

		public void OnPlayerInput_NextDayHoldProcessing(HoldInteraction holdInteraction)
		{
			if (World.CanEndDay())
			{
				this.OnHoldInputProcess?.Invoke(InputManager.ESide.JUMP);
			}
		}

		public void OnPlayerInput_NextDayHoldStart()
		{
			if (World.CanEndDay())
			{
				World.DayEnd();
			}
		}

		public void OnPlayerInput_NextDayHoldStop()
		{
		}

		public void OnPlayerInput_NextDayHoldCancel()
		{
			this.OnHoldInputCancel?.Invoke(InputManager.ESide.JUMP);
		}

		public virtual void OnPlayerInput_SprintStarted()
		{
			m_movement.Sprint(sprint: true);
		}

		public virtual void OnPlayerInput_SprintEnded()
		{
			m_movement.Sprint(sprint: false);
		}

		public void LockLeftClickForXSeconds(float seconds = 0.6f)
		{
			m_delayActionLeftClick?.Kill();
			m_isLeftClickAvailable = false;
			m_delayActionLeftClick = DOVirtual.DelayedCall(seconds, delegate
			{
				m_isLeftClickAvailable = true;
			});
			m_delayActionLeftClick.Play();
		}

		public virtual void OnPlayerInput_MainInteractTap(ISensable sensable)
		{
			if (!m_isLeftClickAvailable)
			{
				return;
			}
			if (CharacterContext == EPlayerCharacterContext.MOVING_FURNITURE)
			{
				if (!(sensable is Bin) || !TryMainInteract(sensable))
				{
					PutFurniture();
				}
				return;
			}
			IGrabbable grabbable3;
			if (CharacterContext == EPlayerCharacterContext.GRABBING)
			{
				if (HasGrabbable(out var grabbable) && grabbable is IOpenable openable && openable.CanBeToggled())
				{
					Open(openable);
					LockLeftClickForXSeconds();
					return;
				}
			}
			else if (sensable is IGrabbable grabbable2 && !HasGrabbable(out grabbable3))
			{
				Grab(grabbable2);
				return;
			}
			if (CharacterContext == EPlayerCharacterContext.USING_BROOM && m_currentBroom != null)
			{
				m_currentBroom.DoSingleSweep();
			}
			else if (!TryMainInteract(sensable) && CanOpenObject())
			{
				IOpenable openableObject = GetOpenableObject();
				if (openableObject.CanBeToggled())
				{
					Open(openableObject);
					LockLeftClickForXSeconds();
				}
			}
		}

		protected virtual bool TryMainInteract(ISensable sensable)
		{
			if (!(sensable is ReserveBroom reserveBroom))
			{
				if (sensable is IMainInteractable mainInteractable)
				{
					return mainInteractable.TryMainInteract(this);
				}
				if (sensable is Trash stackable && CanHandleStackable(stackable))
				{
					OnHandleStackable(stackable);
					return true;
				}
			}
			else
			{
				Broom broom;
				bool flag = BroomGrabber.IsHoldingBroom(out broom);
				reserveBroom.TakeBroom();
				ToggleBroom(!flag);
			}
			return false;
		}

		protected virtual object GetMainHoldInteractable(ISensable sensable)
		{
			if (CharacterContext == EPlayerCharacterContext.MOVING_FURNITURE)
			{
				return null;
			}
			if (CharacterContext == EPlayerCharacterContext.USING_BROOM)
			{
				return m_currentBroom;
			}
			IHoldInteractable holdInteractable = GetHoldInteractable();
			if (holdInteractable != null && holdInteractable.CanMainHoldInteractBy(this))
			{
				return holdInteractable;
			}
			if (sensable is IHoldInteractable holdInteractable2 && holdInteractable2.CanMainHoldInteractBy(this))
			{
				return holdInteractable2;
			}
			return null;
		}

		private bool CanMainHoldInteractable(ISensable sensable, out object holdInteractable)
		{
			holdInteractable = GetMainHoldInteractable(sensable);
			return holdInteractable != null;
		}

		public void OnPlayerInput_MainHoldProcessing(HoldInteraction holdInteraction, ISensable sensable)
		{
			if (CanMainHoldInteractable(sensable, out var holdInteractable))
			{
				m_mainHoldInteractable = holdInteractable;
				this.OnHoldInputProcess?.Invoke(InputManager.ESide.MAIN);
			}
		}

		public virtual void OnPlayerInput_MainHoldInteractStart(ISensable sensable)
		{
			if (m_mainHoldInteractable == null || m_mainHoldInteractable != GetMainHoldInteractable(sensable))
			{
				return;
			}
			MainHoldInteractableStarted = true;
			object mainHoldInteractable = m_mainHoldInteractable;
			if (!(mainHoldInteractable is IHoldInteractable holdInteractable))
			{
				if (!(mainHoldInteractable is IOpenable openable))
				{
					if (mainHoldInteractable is Broom broom)
					{
						broom.TryStartCleaning();
					}
				}
				else
				{
					Open(openable);
				}
			}
			else
			{
				holdInteractable.OnMainHoldInteractStartBy(this);
			}
		}

		public virtual void OnPlayerInput_MainHoldInteractStop(ISensable sensable)
		{
			if (m_mainHoldInteractable == null)
			{
				return;
			}
			object mainHoldInteractable = m_mainHoldInteractable;
			if (!(mainHoldInteractable is IHoldInteractable holdInteractable))
			{
				if (mainHoldInteractable is Broom broom)
				{
					broom.StopCleaning();
				}
			}
			else
			{
				holdInteractable.OnMainHoldInteractStopBy(this);
			}
		}

		public void OnPlayerInput_MainHoldInteractCancel(ISensable sensable)
		{
			this.OnHoldInputCancel?.Invoke(InputManager.ESide.MAIN);
			m_mainHoldInteractable = null;
			MainHoldInteractableStarted = false;
		}

		public virtual void OnPlayerInput_SecondInteractTap(ISensable sensable)
		{
			if (CharacterContext == EPlayerCharacterContext.MOVING_FURNITURE)
			{
				CancelFurnitureMove();
			}
			else if (CharacterContext == EPlayerCharacterContext.USING_BROOM)
			{
				ToggleBroom(value: false);
			}
			else if (sensable is ISecondInteractable secondInteractable)
			{
				secondInteractable.TrySecondInteract(this);
			}
		}

		protected virtual object GetSecondHoldInteractable(ISensable sensable)
		{
			if (CharacterContext == EPlayerCharacterContext.MOVING_FURNITURE)
			{
				return null;
			}
			IHoldInteractable holdInteractable = GetHoldInteractable();
			if (holdInteractable != null && holdInteractable.CanSecondHoldInteractBy(this))
			{
				return holdInteractable;
			}
			if (CanDrop())
			{
				return GetGrabbable();
			}
			if (!(sensable is IHoldInteractable holdInteractable2))
			{
				if (sensable is Furniture furniture && m_mover.CanMove(furniture))
				{
					return furniture;
				}
			}
			else if (holdInteractable2.CanSecondHoldInteractBy(this))
			{
				return holdInteractable2;
			}
			if (HasStackable(out var stackable) && stackable is Trash result)
			{
				return result;
			}
			return null;
		}

		private IHoldInteractable GetHoldInteractable()
		{
			IHoldInteractable result = null;
			Broom broom;
			if (HasGrabbable(out var grabbable) && grabbable is IHoldInteractable holdInteractable)
			{
				result = holdInteractable;
			}
			else if (BroomGrabber.IsHoldingBroom(out broom) && broom is IHoldInteractable holdInteractable2)
			{
				result = holdInteractable2;
			}
			return result;
		}

		private bool CanSecondHoldInteractable(ISensable sensable, out object interactable)
		{
			interactable = GetSecondHoldInteractable(sensable);
			return interactable != null;
		}

		public void OnPlayerInput_SecondHoldProcessing(HoldInteraction holdInteraction, ISensable sensable)
		{
			if (CanSecondHoldInteractable(sensable, out m_secondHoldInteractable))
			{
				this.OnHoldInputProcess?.Invoke(InputManager.ESide.SECOND);
			}
		}

		public void OnPlayerInput_SecondHoldInteractStart(ISensable sensable)
		{
			if (m_secondHoldInteractable == null || m_secondHoldInteractable != GetSecondHoldInteractable(sensable))
			{
				return;
			}
			SecondHoldInteractableStarted = true;
			object secondHoldInteractable = m_secondHoldInteractable;
			if (!(secondHoldInteractable is IHoldInteractable holdInteractable))
			{
				IGrabbable grabbable = secondHoldInteractable as IGrabbable;
				if (grabbable == null)
				{
					if (!(secondHoldInteractable is IOpenable openable))
					{
						if (!(secondHoldInteractable is Furniture furniture))
						{
							if (secondHoldInteractable is Trash)
							{
								GiveStackable();
							}
						}
						else
						{
							MoveFurniture(furniture, cancellable: true);
						}
					}
					else
					{
						Open(openable);
					}
				}
				else
				{
					Drop(out grabbable);
				}
			}
			else
			{
				holdInteractable.OnSecondHoldInteractStartBy(this);
			}
		}

		public void OnPlayerInput_SecondHoldInteractStop(ISensable sensable)
		{
			if (m_secondHoldInteractable != null && m_secondHoldInteractable is IHoldInteractable holdInteractable)
			{
				holdInteractable.OnSecondHoldInteractStopBy(this);
			}
		}

		public void OnPlayerInput_SecondHoldInteractCancel(ISensable sensable)
		{
			this.OnHoldInputCancel?.Invoke(InputManager.ESide.SECOND);
			m_secondHoldInteractable = null;
			SecondHoldInteractableStarted = false;
		}

		public void OnPlayerInput_ThirdInteractTap(ISensable sensable)
		{
			if (!CanSecondHoldInteractable(sensable, out m_secondHoldInteractable))
			{
				return;
			}
			object secondHoldInteractable = m_secondHoldInteractable;
			if (!(secondHoldInteractable is IHoldInteractable holdInteractable))
			{
				IGrabbable grabbable = secondHoldInteractable as IGrabbable;
				if (grabbable == null)
				{
					if (!(secondHoldInteractable is Furniture furniture))
					{
						if (secondHoldInteractable is Trash)
						{
							DropStackable();
						}
					}
					else
					{
						MoveFurniture(furniture, cancellable: true);
					}
				}
				else
				{
					Drop(out grabbable);
				}
			}
			else
			{
				holdInteractable.OnSecondHoldInteractStartBy(this);
			}
			m_secondHoldInteractable = null;
		}

		private bool CanDrop()
		{
			IGrabbable grabbable;
			return HasGrabbable(out grabbable);
		}

		private bool TryDrop()
		{
			if (CanDrop())
			{
				Drop(out var _);
				return true;
			}
			return false;
		}

		public void OnPlayerInput_Rotate(float rotateInput)
		{
			if (m_mover.IsActive && World.PlayerController.Sensor.SensePhysicTarget)
			{
				m_mover.ModifyPhantomOrientation(rotateInput);
			}
		}

		private IOpenable GetOpenableObject()
		{
			IStackable stackable;
			if (HasGrabbable(out var grabbable))
			{
				if (grabbable is IOpenable { IsOpen: false } openable)
				{
					return openable;
				}
			}
			else if (HasStackable(out stackable) && stackable is IOpenable result)
			{
				return result;
			}
			return null;
		}

		private bool CanOpenObject()
		{
			return GetOpenableObject()?.CanBeToggled() ?? false;
		}

		private bool TryOpenObject()
		{
			if (!CanOpenObject())
			{
				return false;
			}
			Open(GetOpenableObject());
			return true;
		}

		public virtual void OnPlayerInput_Pause()
		{
			World.Pause();
		}

		public void OnLoseReceiver()
		{
			OnPlayerInput_Move(Vector3.zero);
		}

		protected override void OnGave(IGrabbable grabbable)
		{
			base.OnGave(grabbable);
			RegisterToStackableBoxEvents(register: false);
			CharacterContext = EPlayerCharacterContext.NONE;
		}

		protected override void OnGrab(IGrabbable grabbable)
		{
			base.OnGrab(grabbable);
			CharacterContext = EPlayerCharacterContext.GRABBING;
			if (grabbable is StackableBox stackableBox)
			{
				m_stackableBox = stackableBox;
				RegisterToStackableBoxEvents(register: true);
			}
		}

		protected override void OnDrop(IGrabbable grabbable)
		{
			base.OnDrop(grabbable);
			RegisterToStackableBoxEvents(register: false);
			CharacterContext = EPlayerCharacterContext.NONE;
		}

		private void RegisterToStackableBoxEvents(bool register)
		{
			if (m_stackableBoxEventsRegistered != register && !(m_stackableBox == null))
			{
				m_stackableBoxEventsRegistered = register;
				if (register)
				{
					m_stackableBox.ObjectStack.Stacked += OnObjectStackedInBox;
					m_stackableBox.ObjectStack.Poped += OnObjectPopedFromBox;
				}
				else
				{
					m_stackableBox.ObjectStack.Stacked -= OnObjectStackedInBox;
					m_stackableBox.ObjectStack.Poped -= OnObjectPopedFromBox;
					m_stackableBox = null;
				}
			}
		}

		protected virtual void OnObjectStackedInBox()
		{
			this.HandContentChanged?.Invoke();
		}

		protected virtual void OnObjectPopedFromBox()
		{
			this.HandContentChanged?.Invoke();
		}

		public override bool CanHandleStackable(IStackable stackable)
		{
			if (base.CanHandleStackable(stackable) && m_stack.CanWelcome(stackable.StackableData))
			{
				return m_stack.HasSpaceLeft();
			}
			return false;
		}

		public override void OnHandleStackable(IStackable stackable)
		{
			m_stack.AnimatedStack(stackable, default(AnimationPath));
		}

		public override bool HasStackable(out IStackable stackable)
		{
			return m_stack.TryPeek(out stackable);
		}

		public override bool CanGiveStackable()
		{
			return m_stack.CanPop();
		}

		public override IStackable GiveStackable()
		{
			IStackable result = m_stack.Pop();
			if (m_stack.Count == 0)
			{
				CharacterContext = EPlayerCharacterContext.NONE;
			}
			return result;
		}

		public virtual IStackable DropStackable()
		{
			if (m_stack.TryPeek(out var stackable) && stackable.StackableData.StackableType == IStackable.EType.TRASH)
			{
				Trash trash = m_stack.Pop() as Trash;
				if (m_grabber.FindDropPosition(out var worldPosition))
				{
					trash.Drop(worldPosition);
					CharacterContext = EPlayerCharacterContext.NONE;
				}
				return trash;
			}
			return null;
		}

		private void RegisterToHandStackEvents(bool register)
		{
			if (register)
			{
				m_stack.Stacked += OnObjectStackedInHand;
				m_stack.Poped += OnObjectPopedFromHand;
			}
			else
			{
				m_stack.Stacked -= OnObjectStackedInHand;
				m_stack.Poped -= OnObjectPopedFromHand;
			}
		}

		protected virtual void OnObjectStackedInHand()
		{
			CharacterContext = EPlayerCharacterContext.GRABBING;
			this.HandContentChanged?.Invoke();
		}

		protected virtual void OnObjectPopedFromHand()
		{
			this.HandContentChanged?.Invoke();
		}

		public bool IsMovingFurniture(out Furniture furniture)
		{
			if (m_mover.IsActive)
			{
				furniture = m_mover.MovingFurniture;
				return true;
			}
			furniture = null;
			return false;
		}

		protected void MoveFurniture(Furniture furniture, bool cancellable)
		{
			m_mover.StartMoving(furniture, cancellable);
			CharacterContext = EPlayerCharacterContext.MOVING_FURNITURE;
		}

		protected void PutFurniture()
		{
			if (m_mover.Put())
			{
				CharacterContext = (HasGrabbable(out var _) ? EPlayerCharacterContext.GRABBING : EPlayerCharacterContext.NONE);
			}
		}

		protected void CancelFurnitureMove()
		{
			IGrabbable grabbable2;
			if (m_mover.LetGo())
			{
				CharacterContext = (HasGrabbable(out var _) ? EPlayerCharacterContext.GRABBING : EPlayerCharacterContext.NONE);
			}
			else if (HasGrabbable(out grabbable2) && grabbable2 is FurnitureBox { IsOpen: not false } furnitureBox)
			{
				m_mover.ForceLetGo();
				furnitureBox.ToggleOpenState();
				CharacterContext = EPlayerCharacterContext.GRABBING;
			}
		}

		public void ThrowFurniture()
		{
			m_mover.ForceLetGo();
			CharacterContext = (HasGrabbable(out var _) ? EPlayerCharacterContext.GRABBING : EPlayerCharacterContext.NONE);
		}

		public void Open(IOpenable openable)
		{
			if (openable.CanBeToggled())
			{
				if (openable.ToggleOpenState())
				{
					OnOpen(openable);
				}
				else
				{
					OnClose(openable);
				}
			}
		}

		protected virtual void OnOpen(IOpenable openable)
		{
			if (openable is FurnitureBox furnitureBox)
			{
				MoveFurniture(furnitureBox.Furniture, cancellable: false);
			}
		}

		protected virtual void OnClose(IOpenable openable)
		{
		}

		private void ToggleBroom(bool value)
		{
			m_broomGrabber.ToggleBroom(value, out var broom);
			CharacterContext = (value ? EPlayerCharacterContext.USING_BROOM : EPlayerCharacterContext.NONE);
			m_currentBroom = broom;
		}

		private void OnCameraDeactivated(ICinemachineCamera camera)
		{
			if (camera as UnityEngine.Object == Camera)
			{
				PlayerCharacter.CameraDeactivated?.Invoke();
			}
		}

		public void ShowHandsContent(bool show)
		{
			Renderer[] componentsInChildren = m_handsContentParent.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = show;
			}
		}

		public void Anchor(Transform anchor)
		{
			Anchor(anchor.position, anchor.eulerAngles.y);
		}

		private void Anchor(Vector3 position, float yRotation)
		{
			m_movement.SetPosition(position);
			m_camera.PanTilt.PanAxis.Value = m_camera.PanTilt.PanAxis.ClampValue(yRotation);
			m_camera.PanTilt.TiltAxis.Value = 0f;
		}
	}
}
