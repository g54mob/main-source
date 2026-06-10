using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("SocketComponentInstance", "")]
	public class SocketComponentInstance : BaseComponentInstance
	{
		[SerializeField]
		private Dictionary<ObjectSide, int> socketObjectUniqueId = new Dictionary<ObjectSide, int>();

		[NonSerialized]
		private readonly Dictionary<ObjectSide, BaseBuildingInstance> socketDictionary = new Dictionary<ObjectSide, BaseBuildingInstance>();

		public IEnumerable<BaseBuildingInstance> SocketedItems => socketDictionary.Values;

		public SocketComponentInstance(BaseBuildingInstance ownerBuilding)
			: base(ownerBuilding)
		{
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
			base.OwnerBuilding.ReachabilityChangedEvent += OnReachabilityChanged;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed && base.OwnerBuilding != null)
			{
				if (MonoSingleton<World>.IsInstantiated())
				{
					MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
				}
				ObjectSide[] array = socketDictionary.Keys.ToArray();
				foreach (ObjectSide key in array)
				{
					base.OwnerBuilding.Map.BuildingsManagerMain.DestroySocketBuilding(socketDictionary[key]);
				}
				socketDictionary.Clear();
				socketObjectUniqueId.Clear();
				base.Map.SocketComponentManager.RemoveFromCache(this);
				base.OwnerBuilding.RequestHasStabilityToBuildEvent -= OnRequestHasStabilityToBuild;
				base.Dispose();
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			base.SetupAfterLoading(baseBuildingInstance);
			VillageInstance activeVillage = VillageManager.ActiveVillage;
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
			base.OwnerBuilding.ReachabilityChangedEvent += OnReachabilityChanged;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			ObjectSide[] array = socketObjectUniqueId.Keys.ToArray();
			foreach (ObjectSide objectSide in array)
			{
				int num = socketObjectUniqueId[objectSide];
				bool isEnabled;
				if (!(activeVillage.WorldObjectStorage.GetWorldObjectByUniqueId(num) is BaseBuildingInstance baseBuildingInstance2))
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(94, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponentInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Cannot find building to attach to a socket ");
						messageBuilder.AppendFormatted(base.UniqueID);
						messageBuilder.AppendLiteral(". Building unique id is ");
						messageBuilder.AppendFormatted(num);
						messageBuilder.AppendLiteral("; socket owner position is ");
						messageBuilder.AppendFormatted(base.GridDataPosition);
					}
					Log.Error(messageBuilder);
					socketObjectUniqueId.Remove(objectSide);
				}
				else
				{
					if (baseBuildingInstance2.Blueprint.BuildingType == BuildingType.Beam)
					{
						continue;
					}
					if (Vec3Int.Distance(base.GridDataPosition, baseBuildingInstance2.GridDataPosition) > 1.01f)
					{
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(113, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponentInstance.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Found wrong building ");
							messageBuilder.AppendFormatted(baseBuildingInstance2.BlueprintId);
							messageBuilder.AppendLiteral(" (unique id: ");
							messageBuilder.AppendFormatted(num);
							messageBuilder.AppendLiteral(") at ");
							messageBuilder.AppendFormatted(baseBuildingInstance2.GridDataPosition);
							messageBuilder.AppendLiteral(" to attach to a socket at ");
							messageBuilder.AppendFormatted(base.GridDataPosition);
							messageBuilder.AppendLiteral(" (socket unique id: ");
							messageBuilder.AppendFormatted(base.UniqueID);
							messageBuilder.AppendLiteral("). This should never happen.");
						}
						Log.Error(messageBuilder);
						socketObjectUniqueId.Remove(objectSide);
					}
					else
					{
						AttachToSocket(baseBuildingInstance2, objectSide, afterLoading: true);
					}
				}
			}
		}

		public bool SocketOccupied(ObjectSide socket)
		{
			return socketDictionary.ContainsKey(socket);
		}

		public void AttachToSocket(BaseBuildingInstance item, ObjectSide socket, bool afterLoading = false)
		{
			if (!socketDictionary.ContainsKey(socket))
			{
				if (!afterLoading)
				{
					socketObjectUniqueId.Remove(socket);
					socketObjectUniqueId.Add(socket, item.UniqueId);
				}
				socketDictionary.Add(socket, item);
				item.OnDisposedEvent += OnSocketableItemDisposed;
				item.SetAttachedToSocketComponent(attachedToSocketComponent: true);
				item.HasStabilityToBuild = base.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished && base.OwnerBuilding.Stability > 0;
			}
		}

		public void RefreshSocketHasStabilityToBuild()
		{
			ObjectSide[] array = socketDictionary.Keys.ToArray();
			foreach (ObjectSide key in array)
			{
				BaseBuildingInstance baseBuildingInstance = socketDictionary[key];
				if (baseBuildingInstance == null || baseBuildingInstance.HasDisposed)
				{
					continue;
				}
				if (string.IsNullOrEmpty(baseBuildingInstance.Blueprint.BeamComponentID))
				{
					baseBuildingInstance.HasStabilityToBuild = base.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished && base.OwnerBuilding.Stability > 0;
					continue;
				}
				BeamComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<BeamComponentInstance>();
				if (componentInstance != null)
				{
					baseBuildingInstance.HasStabilityToBuild = componentInstance.HasStabilityToBuild();
				}
			}
		}

		private void OnReachabilityChanged()
		{
			RefreshSocketHasStabilityToBuild();
		}

		private void OnRequestHasStabilityToBuild()
		{
			RefreshSocketHasStabilityToBuild();
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			base.OnBaseBuildingEnterFinishedState(afterLoading);
			RefreshSocketHasStabilityToBuild();
		}

		public void ReattachToVoxelAndDisposeComponent()
		{
			ObjectSide[] array = socketDictionary.Keys.ToArray();
			foreach (ObjectSide objectSide in array)
			{
				BaseBuildingInstance baseBuildingInstance = socketDictionary[objectSide];
				MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(baseBuildingInstance, objectSide, base.GridDataPosition);
				baseBuildingInstance.SetAttachedToSocketComponent(attachedToSocketComponent: true);
				base.OwnerBuilding.Map.BeamComponentManager.GetComponentInstance(baseBuildingInstance)?.BuildingToVoxelConversionRefresh(base.OwnerBuilding);
			}
			socketDictionary.Clear();
		}

		private void OnSocketableItemDisposed(IGameDisposable item)
		{
			RemoveFromSocket(item as BaseBuildingInstance);
		}

		public void RemoveFromSocket(BaseBuildingInstance item)
		{
			if (item == null)
			{
				Log.Error("RemoveFromSocket error. Item is null. This should never happen!", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponentInstance.cs");
				return;
			}
			bool isEnabled;
			foreach (KeyValuePair<ObjectSide, BaseBuildingInstance> item2 in socketDictionary)
			{
				if (item2.Value.UniqueId == item.UniqueId)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(53, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponentInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Removing ");
						messageBuilder.AppendFormatted(item.BlueprintId);
						messageBuilder.AppendLiteral("; position ");
						messageBuilder.AppendFormatted(item.GridDataPosition);
						messageBuilder.AppendLiteral("; unique id: ");
						messageBuilder.AppendFormatted(item.UniqueId);
						messageBuilder.AppendLiteral("; socket unique id: ");
						messageBuilder.AppendFormatted(base.UniqueID);
					}
					Log.Info(messageBuilder);
					socketDictionary.Remove(item2.Key);
					break;
				}
			}
			foreach (KeyValuePair<ObjectSide, int> item3 in socketObjectUniqueId)
			{
				if (item3.Value == item.UniqueId)
				{
					socketObjectUniqueId.Remove(item3.Key);
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(50, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponentInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Removing building ");
						messageBuilder.AppendFormatted(item.BlueprintId);
						messageBuilder.AppendLiteral("; unique id ");
						messageBuilder.AppendFormatted(item.UniqueId);
						messageBuilder.AppendLiteral("; socket unique id: ");
						messageBuilder.AppendFormatted(base.UniqueID);
					}
					Log.Info(messageBuilder);
					break;
				}
			}
			item.SetAttachedToSocketComponent(attachedToSocketComponent: false);
		}

		public void UpdateBeamStability(int stability)
		{
			ObjectSide[] array = socketDictionary.Keys.ToArray();
			foreach (ObjectSide key in array)
			{
				if (socketDictionary[key].BuildingType == BuildingType.Beam)
				{
					base.OwnerBuilding.Map.BeamComponentManager.GetComponentInstance(socketDictionary[key])?.BeamCarriedStabilityChanged(stability);
				}
			}
		}

		private void OnMapLoaded(bool fromSave)
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (!fromSave)
			{
				return;
			}
			VillageInstance activeVillage = VillageManager.ActiveVillage;
			ObjectSide[] array = socketObjectUniqueId.Keys.ToArray();
			foreach (ObjectSide key in array)
			{
				if (!socketDictionary.ContainsKey(key))
				{
					int id = socketObjectUniqueId[key];
					BaseComponentInstance baseComponentInstanceByUniqueId = activeVillage.WorldObjectStorage.GetBaseComponentInstanceByUniqueId(id);
					if (baseComponentInstanceByUniqueId == null || baseComponentInstanceByUniqueId.HasDisposed || baseComponentInstanceByUniqueId.OwnerBuilding == null || baseComponentInstanceByUniqueId.OwnerBuilding.HasDisposed)
					{
						socketObjectUniqueId.Remove(key);
					}
				}
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("socketObjectUniqueId", socketObjectUniqueId);
		}

		public SocketComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			socketObjectUniqueId = deserializer.ReadEnumIntDict("socketObjectUniqueId", socketObjectUniqueId);
		}

		public void AttachToSocketMigration(BaseBuildingInstance item, ObjectSide socket)
		{
			if (!socketObjectUniqueId.TryAdd(socket, item.UniqueId))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\BuildingSockets\\SocketComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Socket already attached ");
					messageBuilder.AppendFormatted(item.BlueprintId);
					messageBuilder.AppendLiteral(" id ");
					messageBuilder.AppendFormatted(item.GetUniqueId());
					messageBuilder.AppendLiteral(".");
				}
				Log.Debug(messageBuilder);
			}
		}
	}
}
