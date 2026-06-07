using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.Extensions;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer
{
	public class AsyncFlightSceneNetworkRequest<TRequestData, TResultData> : AsyncNetworkRequest<TRequestData, TResultData>, IDisposable
	{
		public delegate void CallbackDelegate(TResultData resultData);

		public delegate TRequestData DeserializeRequestDataDelegate(PooledReader reader);

		public delegate TResultData DeserializeResultDataDelegate(PooledReader reader);

		public delegate void ProcessRequestDelegate(TRequestData requestData, CallbackDelegate callback);

		public delegate void SerializeRequestDataDelegate(TRequestData requestData, PooledWriter writer);

		public delegate void SerializeResultDataDelegate(TResultData resultData, PooledWriter writer);

		private FlightSceneClientRpcType _callbackRpcType;

		private DeserializeRequestDataDelegate _deserializeRequestDelegate;

		private DeserializeResultDataDelegate _deserializeResultDelegate;

		private bool _disposed;

		private FlightSceneNetworkScript _flightSceneNetwork;

		private ProcessRequestDelegate _processRequestDelegate;

		private FlightSceneClientRpcType? _requestClientRpcType;

		private FlightSceneServerRpcType? _requestServerRpcType;

		private SerializeRequestDataDelegate _serializeRequestDelegate;

		private SerializeResultDataDelegate _serializeResultDelegate;

		public bool IsServerRequest => _requestServerRpcType.HasValue;

		protected override string DebugLogRequestName => base.DebugLogRequestName + ", " + (IsServerRequest ? $"ServerRequestType: {_requestServerRpcType}" : $"ClientRequestType: {_requestClientRpcType}") + ", " + $"CallbackType: {_callbackRpcType}";

		public AsyncFlightSceneNetworkRequest(FlightSceneServerRpcType requestRpcType, FlightSceneClientRpcType callbackRpcType, ProcessRequestDelegate processRequestDelegate, int timeout)
			: this(timeout, processRequestDelegate)
		{
			_requestServerRpcType = requestRpcType;
			_callbackRpcType = callbackRpcType;
			_flightSceneNetwork.SubscribeToServerRpc(requestRpcType, OnServerRequest);
			_flightSceneNetwork.SubscribeToClientRpc(callbackRpcType, OnClientCallback);
		}

		public AsyncFlightSceneNetworkRequest(FlightSceneClientRpcType requestRpcType, FlightSceneClientRpcType callbackRpcType, ProcessRequestDelegate processRequestDelegate, int timeout)
			: this(timeout, processRequestDelegate)
		{
			_requestClientRpcType = requestRpcType;
			_callbackRpcType = callbackRpcType;
			_flightSceneNetwork.SubscribeToClientRpc(requestRpcType, OnClientRequest);
			_flightSceneNetwork.SubscribeToClientRpc(callbackRpcType, OnClientCallback);
		}

		protected AsyncFlightSceneNetworkRequest(int timeout, ProcessRequestDelegate processRequestDelegate)
			: base(timeout)
		{
			_flightSceneNetwork = FlightSceneScript.Instance?.FlightSceneNetwork;
			if (_flightSceneNetwork == null)
			{
				throw new Exception("Unable to setup a flight scene networked callback because the flight scene network script is unavailable.");
			}
			_processRequestDelegate = processRequestDelegate;
			_serializeRequestDelegate = delegate(TRequestData data, PooledWriter writer)
			{
				writer.Write(data);
			};
			_deserializeRequestDelegate = (PooledReader reader) => reader.Read<TRequestData>();
			_serializeResultDelegate = delegate(TResultData data, PooledWriter writer)
			{
				writer.Write(data);
			};
			_deserializeResultDelegate = (PooledReader reader) => reader.Read<TResultData>();
		}

		public void ConfigureRequestSerialization(SerializeRequestDataDelegate serializeDelegate, DeserializeRequestDataDelegate deserializeDelegate)
		{
			_serializeRequestDelegate = serializeDelegate;
			_deserializeRequestDelegate = deserializeDelegate;
		}

		public void ConfigureResultSerialization(SerializeResultDataDelegate serializeDelegate, DeserializeResultDataDelegate deserializeDelegate)
		{
			_serializeResultDelegate = serializeDelegate;
			_deserializeResultDelegate = deserializeDelegate;
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_flightSceneNetwork.UnsubscribeFromClientRpc(_callbackRpcType);
				if (_requestServerRpcType.HasValue)
				{
					_flightSceneNetwork.UnsubscribeFromServerRpc(_requestServerRpcType.Value);
				}
				if (_requestClientRpcType.HasValue)
				{
					_flightSceneNetwork.UnsubscribeFromClientRpc(_requestClientRpcType.Value);
				}
			}
		}

		public UniTask<Result> SendRequest(TRequestData data, NetworkConnection targetClient = null)
		{
			if (IsServerRequest && targetClient != null)
			{
				throw new NotSupportedException("The flight scene network callback is set up as a server request. A target client cannot be specified.");
			}
			if (!IsServerRequest && targetClient == null)
			{
				throw new NotSupportedException("The flight scene network callback is set up as a client request. A target client must be specified.");
			}
			return SendRequestAsync(data, targetClient);
		}

		protected override void SendNetworkRequest(int requestId, TRequestData requestData, NetworkConnection targetClient = null)
		{
			using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _flightSceneNetwork.GetPooledWriter();
			pooledWriterDisposableWrapper.Writer.WriteInt32(requestId);
			_serializeRequestDelegate(requestData, pooledWriterDisposableWrapper);
			if (IsServerRequest)
			{
				_flightSceneNetwork.SendServerRpc(_requestServerRpcType.Value, pooledWriterDisposableWrapper.GetData());
				return;
			}
			pooledWriterDisposableWrapper.Writer.WriteNetworkConnection(_flightSceneNetwork.LocalConnection);
			_flightSceneNetwork.SendTargetRpc(_requestClientRpcType.Value, pooledWriterDisposableWrapper.GetData(), targetClient);
		}

		private void OnClientCallback(ArraySegment<byte> data)
		{
			int requestId;
			TResultData resultData;
			using (PooledReaderDisposableWrapper pooledReaderDisposableWrapper = _flightSceneNetwork.GetPooledReader(data))
			{
				requestId = pooledReaderDisposableWrapper.Reader.ReadInt32();
				resultData = _deserializeResultDelegate(pooledReaderDisposableWrapper);
			}
			ReceiveResult(requestId, resultData);
		}

		private void OnClientRequest(ArraySegment<byte> data)
		{
			(int, TRequestData, NetworkConnection) tuple = ReadRequestData(data, readSender: true);
			ProcessRequest(tuple.Item1, tuple.Item2, tuple.Item3);
		}

		private void OnServerRequest(ArraySegment<byte> data, NetworkConnection sender)
		{
			(int, TRequestData, NetworkConnection) tuple = ReadRequestData(data, readSender: false);
			ProcessRequest(tuple.Item1, tuple.Item2, sender);
		}

		private void ProcessRequest(int requestId, TRequestData requestData, NetworkConnection sender)
		{
			_processRequestDelegate(requestData, delegate(TResultData resultData)
			{
				using PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _flightSceneNetwork.GetPooledWriter();
				pooledWriterDisposableWrapper.Writer.WriteInt32(requestId);
				_serializeResultDelegate(resultData, pooledWriterDisposableWrapper);
				_flightSceneNetwork.SendTargetRpc(_callbackRpcType, pooledWriterDisposableWrapper.GetData(), sender);
			});
		}

		private (int Id, TRequestData Data, NetworkConnection Sender) ReadRequestData(ArraySegment<byte> data, bool readSender)
		{
			using PooledReaderDisposableWrapper pooledReaderDisposableWrapper = _flightSceneNetwork.GetPooledReader(data);
			int item = pooledReaderDisposableWrapper.Reader.ReadInt32();
			TRequestData item2 = _deserializeRequestDelegate(pooledReaderDisposableWrapper);
			NetworkConnection item3 = (readSender ? pooledReaderDisposableWrapper.Reader.ReadNetworkConnection() : null);
			return (Id: item, Data: item2, Sender: item3);
		}
	}
}
