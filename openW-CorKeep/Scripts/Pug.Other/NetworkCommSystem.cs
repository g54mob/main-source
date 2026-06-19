using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using I2.Loc;
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
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class NetworkCommSystem : PugSimulationSystemBase
{
	public struct Message
	{
		public byte platform;

		public ulong platformID;

		public int messageNumber;

		public string message;

		public string[] formatFields;

		public bool isStreamIntegrationMessage;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1420672931_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public NetworkCommMessageRPC Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<NetworkCommMessageRPC>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<NetworkCommMessageRPC> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<NetworkCommMessageRPC>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<NetworkCommMessageRPC>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public NetworkCommMessageRPC Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<NetworkCommMessageRPC>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1420672931_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public NetworkCommDataMessageRPC Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<NetworkCommDataMessageRPC>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<NetworkCommDataMessageRPC> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<NetworkCommDataMessageRPC>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<NetworkCommDataMessageRPC>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public NetworkCommDataMessageRPC Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<NetworkCommDataMessageRPC>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1420672931_0.TypeHandle __IFE_1420672931_0_TypeHandle;

		public IFE_1420672931_1.TypeHandle __IFE_1420672931_1_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1420672931_0_TypeHandle = new IFE_1420672931_0.TypeHandle(ref state);
			__IFE_1420672931_1_TypeHandle = new IFE_1420672931_1.TypeHandle(ref state);
		}
	}

	private const int maxReceivedMessages = 10;

	private EntityArchetype messageRpcArchetype;

	private EntityArchetype messageDataRpcArchetype;

	private int messageCount;

	private Dictionary<int, NetworkCommMessageRPC> receivedMessages = new Dictionary<int, NetworkCommMessageRPC>();

	private Dictionary<int, byte[]> partialMessages = new Dictionary<int, byte[]>();

	private Queue<Message> receivedMessageStrings = new Queue<Message>();

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1420672931_0;

	private EntityQuery __query_1420672931_1;

	private EntityQuery __query_1420672931_2;

	private EntityQuery __query_1420672931_3;

	public Queue<Message> ReceivedMessages => receivedMessageStrings;

	public unsafe void SendChatMessage(string message, bool isStreamIntegrationMessage = false)
	{
		NetworkCommMessageRPC componentData = new NetworkCommMessageRPC
		{
			messageNumber = ++messageCount,
			messageType = NetworkCommMessageType.Chat,
			platform = (byte)Manager.platform.Platform,
			platformID = Manager.platform.platformImpl.GetPlatformUserID().GetPlatformOnlineId(),
			isStreamIntegrationMessage = isStreamIntegrationMessage
		};
		NetworkCommDataMessageRPC componentData2 = default(NetworkCommDataMessageRPC);
		byte[] bytes = Encoding.UTF8.GetBytes(message);
		int num = bytes.Length;
		int entityCount = (num - 1) / componentData2.messagePart.Size + 1;
		componentData.totalSize = num;
		Entity entity = base.EntityManager.CreateEntity(messageRpcArchetype);
		base.EntityManager.SetComponentData(entity, componentData);
		using NativeArray<Entity> nativeArray = base.EntityManager.CreateEntity(messageDataRpcArchetype, entityCount, Allocator.Temp);
		componentData2.messageNumber = componentData.messageNumber;
		fixed (byte* ptr = bytes)
		{
			int num2 = num;
			for (ushort num3 = 0; num3 < nativeArray.Length; num3++)
			{
				componentData2.startByte = num3 * componentData2.messagePart.Size;
				UnsafeUtility.MemCpy(componentData2.messagePart.GetUnsafePtr(), ptr + componentData2.startByte, math.min(componentData2.messagePart.Size, num2));
				base.EntityManager.SetComponentData(nativeArray[num3], componentData2);
				num2 -= componentData2.messagePart.Size;
			}
		}
	}

	[Preserve]
	protected override void OnCreate()
	{
		AllowToRunBeforeInit();
		messageRpcArchetype = base.EntityManager.CreateArchetype(typeof(NetworkCommMessageRPC), typeof(SendRpcCommandRequest));
		messageDataRpcArchetype = base.EntityManager.CreateArchetype(typeof(NetworkCommDataMessageRPC), typeof(SendRpcCommandRequest));
		base.OnCreate();
	}

	[Preserve]
	protected unsafe override void OnUpdate()
	{
		foreach (NetworkCommMessageRPC item in IFE_1420672931_0.Query(__query_1420672931_0, __TypeHandle.__IFE_1420672931_0_TypeHandle, ref base.CheckedStateRef))
		{
			if (receivedMessages.ContainsKey(item.messageNumber))
			{
				Debug.LogError("Got message with same number twice");
				continue;
			}
			receivedMessages.Add(item.messageNumber, item);
			partialMessages.Add(item.messageNumber, new byte[item.totalSize]);
		}
		foreach (NetworkCommDataMessageRPC item2 in IFE_1420672931_1.Query(__query_1420672931_1, __TypeHandle.__IFE_1420672931_1_TypeHandle, ref base.CheckedStateRef))
		{
			if (!partialMessages.ContainsKey(item2.messageNumber))
			{
				Debug.LogError("Got data message without meta message");
				continue;
			}
			byte[] array = partialMessages[item2.messageNumber];
			FixedArray64 messagePart;
			fixed (byte* ptr = array)
			{
				byte* destination = ptr + item2.startByte;
				messagePart = item2.messagePart;
				byte* unsafePtr = messagePart.GetUnsafePtr();
				messagePart = item2.messagePart;
				UnsafeUtility.MemCpy(destination, unsafePtr, math.min(messagePart.Size, array.Length - item2.startByte));
			}
			int startByte = item2.startByte;
			messagePart = item2.messagePart;
			if (startByte + messagePart.Size < array.Length)
			{
				continue;
			}
			NetworkCommMessageRPC networkCommMessageRPC = receivedMessages[item2.messageNumber];
			switch (networkCommMessageRPC.messageType)
			{
			case NetworkCommMessageType.Chat:
			{
				string message2 = Encoding.UTF8.GetString(partialMessages[item2.messageNumber]);
				receivedMessageStrings.Enqueue(new Message
				{
					messageNumber = item2.messageNumber,
					message = message2,
					platform = networkCommMessageRPC.platform,
					platformID = networkCommMessageRPC.platformID,
					isStreamIntegrationMessage = networkCommMessageRPC.isStreamIntegrationMessage
				});
				break;
			}
			case NetworkCommMessageType.PlayerConnected:
			{
				string arg2 = Encoding.UTF8.GetString(partialMessages[item2.messageNumber]);
				string text2 = LocalizationManager.GetTranslation("Error/UserConnected");
				if (text2 == null)
				{
					text2 = "{0} connected.";
				}
				receivedMessageStrings.Enqueue(new Message
				{
					messageNumber = item2.messageNumber,
					message = string.Format(text2, arg2),
					platform = networkCommMessageRPC.platform,
					platformID = networkCommMessageRPC.platformID
				});
				break;
			}
			case NetworkCommMessageType.PlayerDisconnected:
			{
				string arg = Encoding.UTF8.GetString(partialMessages[item2.messageNumber]);
				string text = LocalizationManager.GetTranslation("Error/UserDisconnected");
				if (text == null)
				{
					text = "{0} disconnected.";
				}
				receivedMessageStrings.Enqueue(new Message
				{
					messageNumber = item2.messageNumber,
					message = string.Format(text, arg),
					platform = networkCommMessageRPC.platform,
					platformID = networkCommMessageRPC.platformID
				});
				break;
			}
			case NetworkCommMessageType.System:
			{
				string[] array2 = Encoding.UTF8.GetString(partialMessages[item2.messageNumber]).Split('\t');
				string[] array3 = new string[array2.Length - 1];
				Array.Copy(array2, 1, array3, 0, array3.Length);
				string message = PugText.ProcessText(array2[0], array3, shouldLocalize: true, shouldLocalizeFormatFields: false);
				receivedMessageStrings.Enqueue(new Message
				{
					messageNumber = item2.messageNumber,
					message = message
				});
				break;
			}
			default:
				Debug.LogError($"Received unknown comm rpc {networkCommMessageRPC.messageType}");
				break;
			}
			if (receivedMessageStrings.Count > 10)
			{
				receivedMessageStrings.Dequeue();
			}
			partialMessages.Remove(item2.messageNumber);
			receivedMessages.Remove(item2.messageNumber);
		}
		base.EntityManager.DestroyEntity(__query_1420672931_2);
		base.EntityManager.DestroyEntity(__query_1420672931_3);
		base.OnUpdate();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkCommMessageRPC>();
		__query_1420672931_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<NetworkCommDataMessageRPC>();
		__query_1420672931_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkCommMessageRPC, ReceiveRpcCommandRequest>();
		__query_1420672931_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkCommDataMessageRPC, ReceiveRpcCommandRequest>();
		__query_1420672931_3 = entityQueryBuilder2.Build(ref state);
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
	public NetworkCommSystem()
	{
	}
}
