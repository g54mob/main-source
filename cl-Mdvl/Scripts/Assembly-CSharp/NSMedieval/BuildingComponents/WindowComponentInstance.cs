using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("WindowComponentInstance", "")]
	public class WindowComponentInstance : BaseComponentInstance, ILockable
	{
		[SerializeField]
		private WindowOrder windowOrder;

		[SerializeField]
		private LockState lockState;

		[NonSerialized]
		private readonly WindowComponentBlueprint blueprint;

		public bool HasOrders => windowOrder != WindowOrder.None;

		public WindowOrder WindowOrder => windowOrder;

		public List<LockStateData> LockStates => Blueprint.LockStates;

		public LockState LockState => lockState;

		public WindowComponentBlueprint Blueprint => blueprint;

		public event Action WindowLockStatusChangedEvent;

		public WindowComponentInstance(BaseBuildingInstance ownerBuilding, WindowComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			lockState = this.blueprint.DefaultLockState;
			if (ShouldClose() || ShouldOpen())
			{
				MonoSingleton<ConstructionController>.Instance.WindowLockOrderChanged(this);
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance ownerBuilding)
		{
			base.SetupAfterLoading(ownerBuilding);
			if (windowOrder != WindowOrder.None)
			{
				base.Map.WindowComponentManager.HasWindowsWithOrder.Add(this);
			}
		}

		public void SetupLocksAfterLoading()
		{
			switch (lockState)
			{
			case LockState.Locked:
				CloseWindow(afterLoading: true);
				return;
			case LockState.AlwaysOpen:
				OpenWindow(afterLoading: true);
				return;
			}
			bool isEnabled;
			FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Windows\\WindowComponentInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Missing lock state for window building at grid position ");
				messageBuilder.AppendFormatted(base.GridPosition);
			}
			Log.Warning(messageBuilder);
		}

		public LockState GetLockStateForOrder()
		{
			return windowOrder switch
			{
				WindowOrder.Close => LockState.Locked, 
				WindowOrder.Open => LockState.AlwaysOpen, 
				_ => LockState.Undefined, 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldChangeLockState()
		{
			if (!ShouldClose())
			{
				return ShouldOpen();
			}
			return true;
		}

		public void CloseWindow(bool afterLoading = false)
		{
			if (afterLoading || lockState != LockState.Locked)
			{
				lockState = LockState.Locked;
				base.OwnerBuilding.OverrideLockState(lockState);
				base.OwnerBuilding.OverrideThermalModel(Blueprint.ThermalModel);
				base.OwnerBuilding.OverrideCombatCover(blueprint.CoverClosed);
				this.WindowLockStatusChangedEvent?.Invoke();
				GetNode()?.ForceRefreshWithNeighbours();
				MonoSingleton<ConstructionController>.Instance.WindowLockOrderChanged(this);
				MonoSingleton<ConstructionController>.Instance.LockStateChanged(base.OwnerBuilding);
			}
		}

		public void OpenWindow(bool afterLoading = false)
		{
			if (afterLoading || lockState != LockState.AlwaysOpen)
			{
				lockState = LockState.AlwaysOpen;
				base.OwnerBuilding.OverrideLockState(lockState);
				base.OwnerBuilding.LoadDefaultThermalModel();
				base.OwnerBuilding.LoadDefaultCombatCover();
				this.WindowLockStatusChangedEvent?.Invoke();
				GetNode().ForceRefreshWithNeighbours();
				MonoSingleton<ConstructionController>.Instance.WindowLockOrderChanged(this);
				MonoSingleton<ConstructionController>.Instance.LockStateChanged(base.OwnerBuilding);
			}
		}

		public void SetWindowOrder(WindowOrder windowOrder)
		{
			if (this.windowOrder != windowOrder)
			{
				this.windowOrder = windowOrder;
				base.Map.WindowComponentManager.HasWindowsWithOrder.Add(this);
				if (ShouldOpen() || ShouldClose())
				{
					MonoSingleton<ConstructionController>.Instance.WindowLockOrderChanged(this);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldClose()
		{
			if (windowOrder == WindowOrder.Close)
			{
				return lockState != LockState.Locked;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ShouldOpen()
		{
			if (windowOrder == WindowOrder.Open)
			{
				return lockState != LockState.AlwaysOpen;
			}
			return false;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				this.WindowLockStatusChangedEvent = null;
				base.Map.WindowComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.WriteEnum("windowOrder", windowOrder);
			serializer.WriteEnum("lockState", lockState);
		}

		public WindowComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<WindowComponentRepository, WindowComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Windows\\WindowComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in WindowComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				windowOrder = (WindowOrder)deserializer.ReadInt("windowOrder");
				lockState = (LockState)deserializer.ReadInt("lockState", (int)blueprint.DefaultLockState);
			}
		}
	}
}
