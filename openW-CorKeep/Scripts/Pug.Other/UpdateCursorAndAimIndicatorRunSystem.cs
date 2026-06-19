using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PlacementIndicator;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

[UpdateAfter(typeof(CameraUpdateSystem))]
[UpdateBefore(typeof(CameraDrawSystem))]
[UpdateInGroup(typeof(PresentationSystemGroup), OrderLast = true)]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public struct UpdateCursorAndAimIndicatorRunSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_501789139_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			public IntPtr item3_IntPtr;

			public IntPtr item4_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (InternalCompilerInterface.UncheckedRefRO<AimIndicatorCachedStatesCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicationVisualStateCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorCurrentStateCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorInterpolatedValueCD>) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetUncheckedRefRO<AimIndicatorCachedStatesCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlacementIndicationVisualStateCD>(item2_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlacementIndicatorCurrentStateCD>(item3_IntPtr, index), InternalCompilerInterface.UnsafeGetUncheckedRefRO<PlacementIndicatorInterpolatedValueCD>(item4_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<AimIndicatorCachedStatesCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<PlacementIndicationVisualStateCD> item2_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<PlacementIndicatorCurrentStateCD> item3_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<PlacementIndicatorInterpolatedValueCD> item4_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<AimIndicatorCachedStatesCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlacementIndicationVisualStateCD>(isReadOnly: true);
				item3_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlacementIndicatorCurrentStateCD>(isReadOnly: true);
				item4_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PlacementIndicatorInterpolatedValueCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
				item3_ComponentTypeHandle_RO.Update(ref systemState);
				item4_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO),
					item3_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item3_ComponentTypeHandle_RO),
					item4_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item4_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRO<AimIndicatorCachedStatesCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicationVisualStateCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorCurrentStateCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorInterpolatedValueCD>)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (InternalCompilerInterface.UncheckedRefRO<AimIndicatorCachedStatesCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicationVisualStateCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorCurrentStateCD>, InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorInterpolatedValueCD>) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<AimIndicatorCachedStatesCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementIndicationVisualStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementIndicatorCurrentStateCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlacementIndicatorInterpolatedValueCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_501789139_0.TypeHandle __IFE_501789139_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_501789139_0_TypeHandle = new IFE_501789139_0.TypeHandle(ref state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_501789139_0;

	public void OnUpdate(ref SystemState state)
	{
		bool flag = !Manager.input.SystemPrefersKeyboardAndMouse();
		bool flag2 = Manager.main.currentSceneHandler != null && Manager.main.currentSceneHandler.isInGame;
		bool flag3 = Manager.ui.isAnyInventoryShowing || Manager.ui.isShowingMap;
		foreach (var item5 in IFE_501789139_0.Query(__query_501789139_0, __TypeHandle.__IFE_501789139_0_TypeHandle, ref state))
		{
			InternalCompilerInterface.UncheckedRefRO<AimIndicatorCachedStatesCD> item = item5.Item1;
			InternalCompilerInterface.UncheckedRefRO<PlacementIndicationVisualStateCD> item2 = item5.Item2;
			InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorCurrentStateCD> item3 = item5.Item3;
			InternalCompilerInterface.UncheckedRefRO<PlacementIndicatorInterpolatedValueCD> item4 = item5.Item4;
			PlayerController player = Manager.main.player;
			if (player == null)
			{
				continue;
			}
			UISpecialAim specialAim = Manager.ui.specialAim;
			if (!flag2 || Manager.menu.IsAnyMenuActive() || !item.ValueRO.hasAimValidStateAndIntactWeapon || !item.ValueRO.hasAnyAimIndicatorActive || flag3)
			{
				specialAim.HideAll();
				player.aimUI.HideAim();
				continue;
			}
			PlayerInput inputModule = player.inputModule;
			Color color = ((inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.INTERACT) || inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.SECOND_INTERACT)) ? UIMouse.mouseDownColor : Color.white);
			float pointerFade = Manager.ui.CalcMouseFadeValue();
			if (item.ValueRO.isRanged || item.ValueRO.isBeamWeapon)
			{
				specialAim.HideMortarAim();
				specialAim.HideMortarCollider();
				if (flag)
				{
					player.UpdateAim();
					player.aimUI.ShowAim(color, pointerFade);
					player.aimUI.UpdateAimPosition();
				}
				else
				{
					player.aimUI.HideAim();
				}
			}
			else if (item.ValueRO.isMortar || item.ValueRO.isCommandMinion)
			{
				float3 float5;
				if (flag)
				{
					specialAim.ShowMortarAim(color, pointerFade);
					specialAim.ShowMortarCollider(color, pointerFade);
					Vector2 mortarAimPosition = Manager.ui.mouse.ToMouseViewSpace(EntityMonoBehaviour.ToRenderFromWorld(item4.ValueRO.AimPosition.X0Y()));
					specialAim.SetMortarAimPosition(mortarAimPosition);
					float5 = item4.ValueRO.CollisionPosition.X0Y();
				}
				else
				{
					specialAim.HideMortarAim();
					specialAim.ShowMortarCollider(color, pointerFade);
					float5 = item3.ValueRO.collisionPosition;
				}
				player.aimUI.HideAim();
				Vector2 mortarColliderPosition = Manager.ui.mouse.ToMouseViewSpace(EntityMonoBehaviour.ToRenderFromWorld(float5));
				specialAim.SetMortarColliderPosition(mortarColliderPosition);
				specialAim.UpdateMortarAimState(item2.ValueRO.isEquipmentOnCooldown, item2.ValueRO.hasManaForDefaultUsage);
			}
		}
		bool showControllerMapAim = flag && Manager.ui.isShowingMap;
		bool showMouseIcon = !flag || (Manager.ui.currentSelectedUIElement != null && !Manager.ui.currentSelectedUIElement.keepMouseActiveButHiddenOnHoverWhenUsingController) || flag3;
		Manager.ui.mouse.UpdateMouseVisibility(showControllerMapAim, showMouseIcon);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostOwnerIsLocal>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AimIndicatorCachedStatesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementIndicationVisualStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementIndicatorCurrentStateCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlacementIndicatorInterpolatedValueCD>();
		__query_501789139_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((UpdateCursorAndAimIndicatorRunSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateCursorAndAimIndicatorRunSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
