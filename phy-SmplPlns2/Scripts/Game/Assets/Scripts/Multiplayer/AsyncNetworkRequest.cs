using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using Jundroo.Common.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class AsyncNetworkRequest<TRequestData, TResultData>
	{
		public delegate void SendClientRequestDelegate(NetworkConnection targetClient, int requestId, TRequestData requestData);

		public delegate void SendClientResultDelegate(NetworkConnection client, int requestId, TResultData resultData);

		public delegate void SendServerRequestDelegate(int requestId, TRequestData requestData, NetworkConnection targetClient = null);

		public delegate void SendServerResultDelegate(int requestId, TResultData resultData, NetworkConnection client = null);

		public class Result
		{
			public TResultData ResultData { get; }

			public bool TimedOut { get; }

			public Result(TResultData data, bool timedOut)
			{
				ResultData = data;
				TimedOut = timedOut;
			}
		}

		protected class Request
		{
			public TRequestData Data { get; private set; }

			public bool HasResult { get; private set; }

			public int Id { get; private set; }

			public TResultData ResultData { get; private set; }

			public Request(int id, TRequestData data)
			{
				Id = id;
				Data = data;
			}

			public void SetResult(TResultData resultData)
			{
				ResultData = resultData;
				HasResult = true;
			}
		}

		private Dictionary<int, Request> _activeRequests;

		private Stack<int> _availableIds;

		private int _nextUnusedId;

		private SendClientResultDelegate _sendClientResultDelegate;

		private SendServerRequestDelegate _sendServerRequestDelegate;

		private SendServerResultDelegate _sendServerResultDelegate;

		private SendClientRequestDelegate _sendTargetRequestDelegate;

		private HashSet<int> _timedoutIds;

		public int Timeout { get; }

		protected virtual string DebugLogRequestName => GetType().FullName;

		protected AsyncNetworkRequest(int timeout, SendServerRequestDelegate sendRequestDelegate, SendClientResultDelegate sendResultDelegate = null)
			: this(timeout)
		{
			_sendServerRequestDelegate = sendRequestDelegate;
			_sendClientResultDelegate = sendResultDelegate;
		}

		protected AsyncNetworkRequest(int timeout, SendClientRequestDelegate sendRequestDelegate, SendServerResultDelegate sendResultDelegate = null)
			: this(timeout)
		{
			_sendTargetRequestDelegate = sendRequestDelegate;
			_sendServerResultDelegate = sendResultDelegate;
		}

		protected AsyncNetworkRequest(int timeout)
		{
			Timeout = timeout;
			_availableIds = new Stack<int>();
			_timedoutIds = new HashSet<int>();
			_activeRequests = new Dictionary<int, Request>();
		}

		public UniTask<Result>[] CreateResultArray(int count)
		{
			return new UniTask<Result>[count];
		}

		public virtual void ReceiveResult(int requestId, TResultData resultData)
		{
			if (_activeRequests.TryGetValue(requestId, out var value))
			{
				value.SetResult(resultData);
			}
			else if (_timedoutIds.Contains(requestId))
			{
				_timedoutIds.Remove(requestId);
				_availableIds.Push(requestId);
			}
			else
			{
				Debug.LogError($"Received an async network callback but no active request could be found. RequestId: {requestId} {System.Environment.NewLine}{DebugLogRequestName}");
			}
		}

		protected virtual void SendNetworkRequest(int requestId, TRequestData requestData, NetworkConnection targetClient = null)
		{
			if (_sendServerRequestDelegate != null)
			{
				_sendServerRequestDelegate(requestId, requestData, targetClient);
			}
			else if (_sendTargetRequestDelegate != null)
			{
				_sendTargetRequestDelegate(targetClient, requestId, requestData);
			}
			else
			{
				Debug.LogError("Unable to send the async network request because the send request delegate has not been configured (its null).");
			}
		}

		protected virtual void SendNetworkResult(int requestId, TResultData resultData, NetworkConnection targetClient = null)
		{
			if (_sendClientResultDelegate != null)
			{
				_sendClientResultDelegate(targetClient, requestId, resultData);
			}
			else if (_sendServerResultDelegate != null)
			{
				_sendServerResultDelegate(requestId, resultData);
			}
			else
			{
				Debug.LogError("Unable to send the result of the async network request because the send result delegate has not been configured (its null).");
			}
		}

		protected virtual async UniTask<Result> SendRequestAsync(TRequestData data, NetworkConnection targetClient = null)
		{
			Request request = CreateRequest(data);
			_activeRequests.Add(request.Id, request);
			SendNetworkRequest(request.Id, data, targetClient);
			bool flag = await UniTaskEx.WaitUntilWithTimeout(() => request.HasResult, Timeout);
			_activeRequests.Remove(request.Id);
			if (flag)
			{
				_availableIds.Push(request.Id);
			}
			else
			{
				_timedoutIds.Add(request.Id);
			}
			return new Result(request.ResultData, !flag);
		}

		private Request CreateRequest(TRequestData data)
		{
			int result;
			return new Request(_availableIds.TryPop(out result) ? result : _nextUnusedId++, data);
		}
	}
}
