using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace ModIO.Implementation.API
{
	internal static class WebRequestManager
	{
		private static Dictionary<string, object> liveTasks = new Dictionary<string, object>();

		private static HashSet<Task> onGoingRequests = new HashSet<Task>();

		internal static event Action ShutdownEvent;

		public static async Task Shutdown()
		{
			WebRequestManager.ShutdownEvent();
			await Task.WhenAll(onGoingRequests);
			WebRequestManager.ShutdownEvent = null;
			WebRequestManager.ShutdownEvent = delegate
			{
			};
		}

		public static RequestHandle<Result> Download(string url, Stream downloadTo, ProgressHandle progressHandle)
		{
			RequestHandle<Result> requestHandle = WebRequestRunner.Download(url, downloadTo, progressHandle);
			onGoingRequests.Add(requestHandle.task);
			RemoveTaskFromListWhenComplete(requestHandle.task);
			return requestHandle;
		}

		private static async void RemoveTaskFromListWhenComplete(Task task)
		{
			await task;
			if (onGoingRequests.Contains(task))
			{
				onGoingRequests.Remove(task);
			}
		}

		public static async Task<ResultAnd<TOutput>> Request<TOutput>(WebRequestConfig config, ProgressHandle progressHandle = null)
		{
			Task<ResultAnd<TOutput>> task = null;
			if (liveTasks.ContainsKey(config.Url))
			{
				Debug.LogWarning("request already running: " + config.Url);
				return null;
			}
			if (!PreexistingGetRequest(config, out task))
			{
				task = NewRequest<TOutput>(config, progressHandle);
				onGoingRequests.Add(task);
			}
			if (!(config.RequestMethodType != "GET"))
			{
				await task;
			}
			else
			{
				liveTasks.Add(config.Url, task);
				await task;
				liveTasks.Remove(config.Url);
			}
			if (onGoingRequests.Contains(task))
			{
				onGoingRequests.Remove(task);
			}
			return task.Result;
		}

		public static async Task<Result> Request(WebRequestConfig config)
		{
			return (await Request<int?>(config)).result;
		}

		private static Task<ResultAnd<TOutput>> NewRequest<TOutput>(WebRequestConfig config, ProgressHandle progressHandle = null)
		{
			return WebRequestRunner.Execute<TOutput>(config, null, progressHandle);
		}

		private static bool PreexistingGetRequest<TOutput>(WebRequestConfig config, out Task<ResultAnd<TOutput>> task)
		{
			task = null;
			if (config.RequestMethodType == "GET")
			{
				return false;
			}
			if (liveTasks.TryGetValue(config.Url, out var value))
			{
				task = (Task<ResultAnd<TOutput>>)value;
				return true;
			}
			return false;
		}

		static WebRequestManager()
		{
			WebRequestManager.ShutdownEvent = delegate
			{
			};
		}
	}
}
