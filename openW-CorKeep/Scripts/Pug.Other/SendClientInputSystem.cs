using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlayerEquipment;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup), OrderLast = true)]
public class SendClientInputSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1646233471_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public BufferAccessor<UIActionBuffer> item2_BufferAccessor;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRW<ClientInputHistoryCD>, DynamicBuffer<UIActionBuffer>, InternalCompilerInterface.UncheckedRefRW<ClientInputData>, InternalCompilerInterface.UncheckedRefRW<ClientInputForLatestFrameCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRW<ClientInputHistoryCD>(item1_IntPtr, index), item2_BufferAccessor[index], InternalCompilerInterface.UnsafeGetUncheckedRefRW<ClientInputData>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRW<ClientInputForLatestFrameCD>(item4_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			private ComponentTypeHandle<ClientInputHistoryCD> item1_ComponentTypeHandle_RW;

			private BufferTypeHandle<UIActionBuffer> item2_BufferTypeHandle_RW;

			private ComponentTypeHandle<ClientInputData> item3_ComponentTypeHandle_RW;

			private ComponentTypeHandle<ClientInputForLatestFrameCD> item4_ComponentTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ClientInputHistoryCD>();
				item2_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<UIActionBuffer>();
				item3_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ClientInputData>();
				item4_ComponentTypeHandle_RW = systemState.GetComponentTypeHandle<ClientInputForLatestFrameCD>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RW.Update(ref systemState);
				item2_BufferTypeHandle_RW.Update(ref systemState);
				item3_ComponentTypeHandle_RW.Update(ref systemState);
				item4_ComponentTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RW),
					item2_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item2_BufferTypeHandle_RW),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RW),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<ClientInputHistoryCD>, DynamicBuffer<UIActionBuffer>, InternalCompilerInterface.UncheckedRefRW<ClientInputData>, InternalCompilerInterface.UncheckedRefRW<ClientInputForLatestFrameCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRW<ClientInputHistoryCD>, DynamicBuffer<UIActionBuffer>, InternalCompilerInterface.UncheckedRefRW<ClientInputData>, InternalCompilerInterface.UncheckedRefRW<ClientInputForLatestFrameCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<ClientInputHistoryCD>();
			state.EntityManager.CompleteDependencyBeforeRW<UIActionBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<ClientInputData>();
			state.EntityManager.CompleteDependencyBeforeRW<ClientInputForLatestFrameCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1646233471_0.TypeHandle __IFE_1646233471_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1646233471_0_TypeHandle = new IFE_1646233471_0.TypeHandle(ref state);
		}
	}

	private Direction facingDirection;

	private float3 targetingDirection;

	private float3 aimDirection;

	private EntityArchetype _inputActionRPCArchetype;

	private NetworkTick _lastTick;

	private NetworkTick _lastInputActionFetchTick;

	private Vector3 previousMouseScreenPosition;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1646233471_0;

	private EntityQuery __query_1646233471_1;

	[Preserve]
	protected override void OnCreate()
	{
		_inputActionRPCArchetype = base.EntityManager.CreateArchetype(ComponentType.ReadWrite<SendRpcCommandRequest>(), ComponentType.ReadWrite<UIInputActionDataRPC>());
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(base.World.UpdateAllocator.ToAllocator);
		__query_1646233471_1.TryGetSingleton<NetworkTime>(out var value);
		EntityArchetype inputActionRPCArchetype = _inputActionRPCArchetype;
		foreach (var item5 in IFE_1646233471_0.Query(__query_1646233471_0, __TypeHandle.__IFE_1646233471_0_TypeHandle, ref base.CheckedStateRef))
		{
			InternalCompilerInterface.UncheckedRefRW<ClientInputHistoryCD> item = item5.Item1;
			DynamicBuffer<UIActionBuffer> item2 = item5.Item2;
			InternalCompilerInterface.UncheckedRefRW<ClientInputData> item3 = item5.Item3;
			InternalCompilerInterface.UncheckedRefRW<ClientInputForLatestFrameCD> item4 = item5.Item4;
			NetworkTick serverTick = value.ServerTick;
			bool flag = !_lastTick.IsValid || serverTick.IsNewerThan(_lastTick);
			ClientInput clientInput = default(ClientInput);
			if (Manager.main.player == null)
			{
				continue;
			}
			if ((!_lastInputActionFetchTick.IsValid || serverTick.IsNewerThan(_lastInputActionFetchTick)) && Manager.main.player.TryPopUIInputActionData(out var uiInputActionData))
			{
				NetworkTick tick = serverTick;
				tick.Add(1u);
				Entity e = entityCommandBuffer.CreateEntity(inputActionRPCArchetype);
				entityCommandBuffer.SetComponent(e, new UIInputActionDataRPC
				{
					tick = tick,
					actionData = uiInputActionData
				});
				item2.Add(new UIActionBuffer
				{
					tick = tick,
					actionData = uiInputActionData
				});
				_lastInputActionFetchTick = serverTick;
			}
			if (flag)
			{
				Manager.main.player.clientInput.SetAllButtonsFalse();
			}
			PlayerController player = Manager.main.player;
			PlayerInput inputModule = Manager.main.player.inputModule;
			NetworkTick interpolationTick = value.InterpolationTick;
			clientInput = Manager.main.player.clientInput;
			clientInput.Tick = serverTick;
			clientInput.deterministicInterpolationDelay = (byte)math.clamp(serverTick.TicksSince(interpolationTick), 0, 255);
			PlayerController playerController = Manager.camera.playerToFollow;
			if (playerController == null)
			{
				playerController = Manager.main.player;
			}
			clientInput.cameraPosition = ((Manager.camera.currentCameraStyle == CameraManager.CameraControlStyle.FollowPlayer) ? playerController.WorldPosition.ToFloat2() : Manager.camera.GetCameraTargetPosition().ToFloat2());
			PlayerController.UpdateAim(ref aimDirection, player.RenderPosition, isAimingBlocked: false, inputModule, player.aimUI);
			CalculateDirection(ref facingDirection, ref targetingDirection, in aimDirection);
			ref ClientInputHistoryCD valueRW = ref item.ValueRW;
			if (!player.PlayerInputBlockedThisFrame() && !PlayerInputBlocked())
			{
				clientInput.movementDirection = PlayerController.ProcessMovementInput(inputModule.GetInputAxisValue(PlayerInput.InputAxisType.CHARACTER_MOVEMENT_HORIZONTAL, PlayerInput.InputAxisType.CHARACTER_MOVEMENT_VERTICAL));
				valueRW.interactBlockedUntilRelease = valueRW.interactBlockedUntilRelease && inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.INTERACT);
				valueRW.secondInteractBlockedUntilRelease = valueRW.secondInteractBlockedUntilRelease && inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.SECOND_INTERACT);
				valueRW.useOffHandBlockedUntilRelease = valueRW.useOffHandBlockedUntilRelease && inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.USE_OFF_HAND);
				if (inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.INTERACT))
				{
					Manager.input.touchpadInUse = inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.TOUCHPAD);
				}
				if (!PlayerInteractionBlocked() && !player.AnyInventoryOrMapWasActiveThisFrame())
				{
					if (!player.mouseUIInputWasDone)
					{
						clientInput.SetButtonState(CommandInputButtonStateNames.Interact_HeldDown, !valueRW.interactBlockedUntilRelease && inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.INTERACT));
						clientInput.SetButtonState(CommandInputButtonStateNames.SecondInteract_HeldDown, !valueRW.secondInteractBlockedUntilRelease && inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.SECOND_INTERACT));
						clientInput.SetButtonState(CommandInputButtonStateNames.InteractWithObject_Pressed, inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.INTERACT_WITH_OBJECT));
						clientInput.SetButtonState(CommandInputButtonStateNames.Interact_Pressed, inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.INTERACT));
						clientInput.SetButtonState(CommandInputButtonStateNames.SecondInteract_Pressed, inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.SECOND_INTERACT));
					}
					clientInput.SetButtonState(CommandInputButtonStateNames.UseOffHand_HeldDown, !valueRW.useOffHandBlockedUntilRelease && inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.USE_OFF_HAND));
				}
				else
				{
					valueRW.useOffHandBlockedUntilRelease |= inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.USE_OFF_HAND);
				}
				if (valueRW.secondInteractUITriggered)
				{
					clientInput.SetButtonState(CommandInputButtonStateNames.SecondInteract_HeldDown, val: true);
					valueRW.secondInteractUITriggered = false;
				}
				clientInput.SetButtonState(CommandInputButtonStateNames.Honk_Pressed, inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.HONK));
				clientInput.SetButtonState(CommandInputButtonStateNames.MoveFaster_HeldDown, inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.MOVE_FASTER));
				clientInput.SetButtonState(CommandInputButtonStateNames.SpeedupNoClip_HeldDown, Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
				clientInput.SetButtonState(CommandInputButtonStateNames.AccelerateVehicle_HeldDown, inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.ACCELERATE_VEHICLE));
				clientInput.SetButtonState(CommandInputButtonStateNames.ReverseVehicle_HeldDown, inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.REVERSE_VEHICLE));
				clientInput.SetButtonState(CommandInputButtonStateNames.QuickSwapTorch_HeldDown, inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.QUICK_SWAP_TORCH));
				clientInput.SetButtonState(CommandInputButtonStateNames.StopPlayingInstrument_Pressed, inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.STOP_PLAYING_INSTRUMENT));
				if (Manager.main.player.stopPlayingInstrument)
				{
					clientInput.SetButtonState(CommandInputButtonStateNames.StopPlayingInstrument_Pressed, val: true);
					Manager.main.player.stopPlayingInstrument = false;
				}
				if (!player.RotateInteractionIsConflicting())
				{
					clientInput.SetButtonState(CommandInputButtonStateNames.Rotate_Pressed, inputModule.WasButtonPressedDownThisFrame(PlayerInput.InputType.ROTATE));
				}
				if (!Manager.ui.isShowingMap)
				{
					float2 float5 = Manager.main.player.inputModule.GetInputAxisValue(PlayerInput.InputAxisType.CHARACTER_AIM_HORIZONTAL, PlayerInput.InputAxisType.CHARACTER_AIM_VERTICAL).ToFloat2();
					clientInput.wasAiming = math.length(float5) > 0.1f;
					clientInput.targetingDirection = targetingDirection.ToFloat2();
					clientInput.aimDirection = aimDirection.ToFloat2();
					clientInput.facingDirection = facingDirection;
					clientInput.joystickDirection = float5;
					valueRW.targetingDirection = targetingDirection.ToFloat2();
					valueRW.aimDirection = aimDirection.ToFloat2();
					valueRW.facingDirection = facingDirection;
					valueRW.joystickDirection = clientInput.joystickDirection;
				}
				else
				{
					clientInput.targetingDirection = valueRW.targetingDirection;
					clientInput.aimDirection = valueRW.aimDirection;
					clientInput.facingDirection = valueRW.facingDirection;
					clientInput.joystickDirection = valueRW.joystickDirection;
				}
			}
			else
			{
				valueRW.interactBlockedUntilRelease |= inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.INTERACT);
				valueRW.secondInteractBlockedUntilRelease |= inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.SECOND_INTERACT);
				valueRW.useOffHandBlockedUntilRelease |= inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.USE_OFF_HAND);
				clientInput.movementDirection = 0;
				clientInput.targetingDirection = valueRW.targetingDirection;
				clientInput.aimDirection = valueRW.aimDirection;
				clientInput.facingDirection = valueRW.facingDirection;
			}
			clientInput.SetButtonState(CommandInputButtonStateNames.SecondInteract_Released, inputModule.WasButtonReleasedThisFrame(PlayerInput.InputType.SECOND_INTERACT));
			short buttonSetMask = (short)(Manager.main.player.clientInput.buttonSetMask | clientInput.buttonSetMask);
			Manager.main.player.clientInput.buttonSetMask = buttonSetMask;
			clientInput.buttonSetMask = buttonSetMask;
			clientInput.prefersKeyboardAndMouse = Manager.input.SystemPrefersKeyboardAndMouse();
			clientInput.mouseOrJoystickWorldPoint = CalculateMouseOrJoystickWorldPoint(player);
			item3.ValueRW = UnsafeUtility.As<ClientInput, ClientInputData>(ref clientInput);
			item4.ValueRW.clientInput = clientInput;
		}
		_lastTick = value.ServerTick;
		entityCommandBuffer.Playback(base.EntityManager);
	}

	public static bool PlayerInteractionBlocked()
	{
		if (!Manager.ui.isAnyInventoryShowing && !Manager.ui.isShowingMap && !Manager.main.player.guestMode)
		{
			return Manager.menu.IsAnyMenuActive();
		}
		return true;
	}

	public static bool PlayerInputBlocked()
	{
		_ = Manager.main.player;
		if (UnityEngine.Time.timeScale != 0f && Manager.main.currentSceneHandler.isSceneHandlerReady && !Manager.load.IsLoadingAndScreenBlack() && !Manager.ui.isAnyInventoryShowing && !Manager.menu.IsAnyMenuActive() && Manager.main.player.GetLastUIInputAction().action == UIInputAction.None)
		{
			return Manager.main.player.GetNextUIInputAction().action != UIInputAction.None;
		}
		return true;
	}

	private void CalculateDirection(ref Direction facingDirection, ref float3 targetingDirection, in float3 aimDirection)
	{
		PlayerController player = Manager.main.player;
		PlayerInput inputModule = player.inputModule;
		Vector2 vector = PlayerController.ProcessMovementInput(inputModule.GetInputAxisValue(PlayerInput.InputAxisType.CHARACTER_MOVEMENT_HORIZONTAL, PlayerInput.InputAxisType.CHARACTER_MOVEMENT_VERTICAL));
		Vector3 vec = new Vector3(vector.x, 0f, vector.y);
		Direction direction = Direction.FromVector(vec, 0.01f);
		if (inputModule.PrefersKeyboardAndMouse())
		{
			Vector3 vector2 = Manager.camera.uiCamera.WorldToScreenPoint(Manager.ui.mouse.pointer.transform.position);
			targetingDirection = aimDirection;
			if (Manager.prefs.faceMouseDirection)
			{
				EquipmentSlot equippedSlot = player.GetEquippedSlot();
				Direction direction2;
				if (equippedSlot != null && equippedSlot.GetSlotType() == EquipmentSlotType.RangeWeaponSlot)
				{
					direction2 = Direction.FromVector(aimDirection);
				}
				else
				{
					Vector3 vector3 = Manager.camera.gameCamera.WorldToScreenPoint(player.RenderPosition + Vector3.up * 0.5f);
					Vector3 vector4 = vector2 - vector3;
					vector4 = new Vector3(vector4.x, 0f, vector4.y).normalized;
					direction2 = Direction.FromVector(vector4);
				}
				if (vector2 != previousMouseScreenPosition)
				{
					facingDirection = direction2;
					previousMouseScreenPosition = vector2;
				}
			}
			else
			{
				if (!direction.is0)
				{
					facingDirection = direction;
				}
				if (Vector3.Angle(facingDirection.vec3, aimDirection) > 90f)
				{
					targetingDirection = facingDirection.vec3;
				}
			}
			return;
		}
		Vector2 inputAxisValue = inputModule.GetInputAxisValue(PlayerInput.InputAxisType.CHARACTER_AIM_HORIZONTAL, PlayerInput.InputAxisType.CHARACTER_AIM_VERTICAL);
		vector = PlayerController.ProcessMovementInput(inputAxisValue);
		Direction direction3 = Direction.FromVector(new Vector3(vector.x, 0f, vector.y), 0.01f);
		if (vec.sqrMagnitude > 0.1f)
		{
			targetingDirection = vec.normalized;
		}
		if (!direction3.is0)
		{
			facingDirection = direction3;
			if (inputAxisValue.sqrMagnitude > 0.1f)
			{
				targetingDirection = new Vector3(inputAxisValue.x, 0f, inputAxisValue.y);
			}
		}
		else if (!direction.is0)
		{
			facingDirection = direction;
		}
	}

	private float2 CalculateMouseOrJoystickWorldPoint(PlayerController playerController)
	{
		if (playerController.inputModule.PrefersKeyboardAndMouse())
		{
			return EntityMonoBehaviour.ToWorldFromRender(Manager.ui.mouse.GetMouseGameViewPosition()).ToFloat2();
		}
		return EntityMonoBehaviour.ToWorldFromRender(CalculateJoystickScreenPoint(playerController)).ToFloat2();
	}

	private float3 CalculateJoystickScreenPoint(PlayerController playerController)
	{
		Vector2 inputAxisValue = playerController.inputModule.GetInputAxisValue(PlayerInput.InputAxisType.CHARACTER_AIM_HORIZONTAL, PlayerInput.InputAxisType.CHARACTER_AIM_VERTICAL);
		if (inputAxisValue.magnitude <= 0.1f)
		{
			return float3.zero;
		}
		Plane plane = new Plane(Vector3.up, Vector3.zero);
		inputAxisValue.x /= Manager.camera.gameCamera.aspect;
		Vector3 pos = Vector3.one * 0.5f + (Vector3)inputAxisValue * 0.25f;
		Ray ray = Manager.camera.gameCamera.ViewportPointToRay(pos);
		if (!plane.Raycast(ray, out var enter))
		{
			return float3.zero;
		}
		return ray.GetPoint(enter);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ClientInputHistoryCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<UIActionBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ClientInputData>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ClientInputForLatestFrameCD>();
		__query_1646233471_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1646233471_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public SendClientInputSystem()
	{
	}
}
