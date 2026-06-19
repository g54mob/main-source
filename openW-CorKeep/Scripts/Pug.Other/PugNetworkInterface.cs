using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Networking.Transport;

[BurstCompile]
public struct PugNetworkInterface : INetworkInterface, IDisposable
{
	[BurstCompile]
	private struct ReceiveJob : IJob
	{
		public NativeQueue<QueuedSendMessage> incommingReceiveQueue;

		public PacketsQueue outgoingReceiveQueue;

		public OperationResult ReceiveResult;

		public unsafe void Execute()
		{
			while (incommingReceiveQueue.Count > 0)
			{
				QueuedSendMessage queuedSendMessage = incommingReceiveQueue.Peek();
				if (outgoingReceiveQueue.EnqueuePacket(out var packetProcessor))
				{
					if (packetProcessor.Capacity < queuedSendMessage.DataLength)
					{
						ReceiveResult.ErrorCode = -10040;
						break;
					}
					packetProcessor.EndpointRef = queuedSendMessage.Source;
					packetProcessor.AppendToPayload(queuedSendMessage.Data, queuedSendMessage.DataLength);
					incommingReceiveQueue.Dequeue();
					continue;
				}
				break;
			}
		}
	}

	[BurstCompile]
	private struct SendJob : IJob
	{
		public NetworkEndpoint localEndPoint;

		public PacketsQueue inputSendQueue;

		public NativeQueue<QueuedSendMessage> sendQueue;

		public NativeQueue<QueuedSendMessage> localQueue;

		public unsafe void Execute()
		{
			for (int i = 0; i < inputSendQueue.Count; i++)
			{
				PacketProcessor packetProcessor = inputSendQueue[i];
				if (packetProcessor.Length != 0)
				{
					QueuedSendMessage value = default(QueuedSendMessage);
					packetProcessor.CopyPayload(value.Data, 1200);
					value.DataLength = packetProcessor.Length;
					value.Dest = packetProcessor.EndpointRef;
					value.Source = localEndPoint;
					if (value.Dest == localEndPoint)
					{
						localQueue.Enqueue(value);
					}
					else
					{
						sendQueue.Enqueue(value);
					}
				}
			}
		}
	}

	public NativeQueue<QueuedSendMessage> sendQueue;

	public NativeQueue<QueuedSendMessage> receiveQueue;

	public NativeQueue<QueuedSendMessage> localQueue;

	private NativeReference<JobHandle> sendDependency;

	private NativeReference<JobHandle> receiveDependency;

	public bool IsCreated => sendQueue.IsCreated;

	public NetworkEndpoint LocalEndpoint { get; set; }

	public bool CanSendAndReceiveBeCompletedWithoutWaiting()
	{
		if (sendDependency.Value.IsCompleted)
		{
			return receiveDependency.Value.IsCompleted;
		}
		return false;
	}

	public void CompleteSend()
	{
		sendDependency.Value.Complete();
		sendDependency.Value = default(JobHandle);
	}

	public void CompleteReceive()
	{
		receiveDependency.Value.Complete();
		receiveDependency.Value = default(JobHandle);
	}

	public void Dispose()
	{
		CompleteSend();
		CompleteReceive();
		if (sendQueue.IsCreated)
		{
			sendQueue.Dispose();
		}
		if (receiveQueue.IsCreated)
		{
			receiveQueue.Dispose();
		}
		if (localQueue.IsCreated)
		{
			localQueue.Dispose();
		}
		if (sendDependency.IsCreated)
		{
			sendDependency.Dispose();
		}
		if (receiveDependency.IsCreated)
		{
			receiveDependency.Dispose();
		}
		sendQueue = default(NativeQueue<QueuedSendMessage>);
		receiveQueue = default(NativeQueue<QueuedSendMessage>);
		localQueue = default(NativeQueue<QueuedSendMessage>);
		sendDependency = default(NativeReference<JobHandle>);
		receiveDependency = default(NativeReference<JobHandle>);
	}

	public int Initialize(ref NetworkSettings settings, ref int packetPadding)
	{
		sendDependency = new NativeReference<JobHandle>(Allocator.Persistent);
		receiveDependency = new NativeReference<JobHandle>(Allocator.Persistent);
		sendQueue = new NativeQueue<QueuedSendMessage>(Allocator.Persistent);
		receiveQueue = new NativeQueue<QueuedSendMessage>(Allocator.Persistent);
		localQueue = new NativeQueue<QueuedSendMessage>(Allocator.Persistent);
		return 0;
	}

	public JobHandle ScheduleReceive(ref ReceiveJobArguments arguments, JobHandle dep)
	{
		ReceiveJob jobData = new ReceiveJob
		{
			outgoingReceiveQueue = arguments.ReceiveQueue,
			incommingReceiveQueue = receiveQueue,
			ReceiveResult = arguments.ReceiveResult
		};
		dep = JobHandle.CombineDependencies(receiveDependency.Value, dep);
		JobHandle jobHandle = (receiveDependency.Value = jobData.Schedule(dep));
		dep = jobHandle;
		return dep;
	}

	public JobHandle ScheduleSend(ref SendJobArguments arguments, JobHandle dep)
	{
		SendJob jobData = new SendJob
		{
			localEndPoint = LocalEndpoint,
			inputSendQueue = arguments.SendQueue,
			sendQueue = sendQueue,
			localQueue = localQueue
		};
		dep = JobHandle.CombineDependencies(sendDependency.Value, dep);
		JobHandle jobHandle = (sendDependency.Value = jobData.Schedule(dep));
		dep = jobHandle;
		return dep;
	}

	public int Bind(NetworkEndpoint endpoint)
	{
		return 0;
	}

	public int Listen()
	{
		return 0;
	}
}
