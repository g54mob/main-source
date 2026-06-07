using System;
using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	public class CallbackDispatcher : PrivateSingletonBehaviour<CallbackDispatcher>
	{
		private Queue<Action> m_queue;

		private readonly object queueLock;

		public static CallbackDispatcher Initialize()
		{
			return null;
		}

		public static void InvokeOnMainThread(Callback callback)
		{
		}

		public static void InvokeOnMainThread<TArg>(Callback<TArg> callback, TArg arg)
		{
		}

		public static void InvokeOnMainThread<TResult>(SuccessCallback<TResult> callback, TResult result)
		{
		}

		public static void InvokeOnMainThread(ErrorCallback callback, Error error)
		{
		}

		public static void InvokeOnMainThread(CompletionCallback callback, bool success, Error error)
		{
		}

		public static void InvokeOnMainThread<TResult>(CompletionCallback<TResult> callback, TResult result, Error error)
		{
		}

		public static void InvokeOnMainThread<TResult>(EventCallback<TResult> callback, IOperationResultContainer<TResult> resultContainer)
		{
		}

		public static void InvokeOnMainThread<TResult>(EventCallback<TResult> callback, TResult result, Error error)
		{
		}

		protected override void OnSingletonAwake()
		{
		}

		private void LateUpdate()
		{
		}

		private void AddAction(Action action)
		{
		}
	}
}
