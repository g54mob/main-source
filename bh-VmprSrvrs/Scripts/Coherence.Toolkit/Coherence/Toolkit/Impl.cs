using System;
using System.ComponentModel;
using Coherence.Core;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.SimulationFrame;
using UnityEngine;

namespace Coherence.Toolkit
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class Impl
	{
		public static Func<uint, string> ComponentNameFromTypeId;

		public static Func<ICoherenceSync, string, bool, AbsoluteSimulationFrame, ICoherenceComponentData[]> CreateInitialComponents;

		public static Func<CoherenceBridge.EventsToken, IEntityCommand, Coherence.Log.Logger, bool> ReceiveInternalCommand;

		public static Func<Entity, Vector3, Quaternion, Vector3, AbsoluteSimulationFrame, ICoherenceComponentData> CreateConnectedEntityUpdateInternal;

		public static Func<uint> GetConnectedEntityComponentIdInternal;

		public static Action<IClient, Entity, string, AbsoluteSimulationFrame> UpdateTag;

		public static Action<IClient, Entity> RemoveTag;

		public static Func<IClient, IncomingEntityUpdate, Coherence.Log.Logger, (bool, SpawnInfo)> GetSpawnInfo;

		public static Func<IDefinition> GetRootDefinition;

		public static Func<uint> AssetId;

		public static Func<uint, AbsoluteSimulationFrame, ICoherenceComponentData> CreateConnectionSceneUpdateInternal;

		public static Func<IDataInteropHandler> GetDataInteropHandler;

		public static Func<IClient, Entity> CreateGlobalQuery;

		public static Action<IClient, Entity> AddGlobalQuery;

		public static Action<IClient, Entity> RemoveGlobalQuery;

		public static Func<IClient, float, Vector3, AbsoluteSimulationFrame, Entity> CreateLiveQuery;

		public static Action<IClient, Entity, float, Vector3, AbsoluteSimulationFrame> UpdateLiveQuery;

		public static Action<IClient, Entity, string, AbsoluteSimulationFrame> UpdateTagQuery;

		public static Action<IClient, Entity> RemoveTagQuery;
	}
}
