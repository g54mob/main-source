using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.Platform;
using Newtonsoft.Json;
using UnityEngine;

namespace ModIO.Implementation.API
{
	internal static class WebRequestRunner
	{
		public static RequestHandle<Result> Download(string url, Stream downloadTo, ProgressHandle progressHandle)
		{
			RequestHandle<Result> requestHandle = new RequestHandle<Result>();
			Task<Result> task = RunDownload(url, downloadTo, requestHandle, progressHandle);
			requestHandle.task = task;
			return requestHandle;
		}

		private static async Task<Result> RunDownload(string url, Stream downloadTo, RequestHandle<Result> handle, ProgressHandle progressHandle)
		{
			Logger.Log(LogLevel.Verbose, "DOWNLOADING [" + url + "]");
			Result result = ResultBuilder.Success;
			WebRequest request = null;
			WebResponse response = null;
			handle.progress = progressHandle;
			try
			{
				request = BuildWebRequestForDownload(url);
				handle.cancel = request.Abort;
				response = await request.GetDownloadResponse(downloadTo, progressHandle);
			}
			catch (WebException ex)
			{
				response = ex.Response;
				if (ex.Status == WebExceptionStatus.RequestCanceled)
				{
					result = ResultBuilder.Create(20506u);
				}
			}
			catch (Exception ex2)
			{
				if (ModIOUnityImplementation.shuttingDown)
				{
					result = ResultBuilder.Create(20506u);
					Logger.Log(LogLevel.Error, "SHUTDOWN EXCEPTION\n" + ex2.Message + "\n" + ex2.StackTrace);
				}
				else
				{
					result = ResultBuilder.Unknown;
					Logger.Log(LogLevel.Error, "Unhandled exception when downloading\n" + ex2.Message + "\n" + ex2.StackTrace);
				}
			}
			if (request != null)
			{
				WebRequestManager.ShutdownEvent -= request.Abort;
			}
			if (result.Succeeded())
			{
				result = await ProcessDownloadResponse(request, response, url);
			}
			else
			{
				Logger.Log(LogLevel.Verbose, "DOWNLOAD FAILED [" + url + "]");
			}
			if (!result.Succeeded() && progressHandle != null)
			{
				progressHandle.Failed = true;
			}
			if (progressHandle != null)
			{
				progressHandle.Completed = true;
			}
			return result;
		}

		public static RequestHandle<ResultAnd<T>> Upload<T>(WebRequestConfig config, ProgressHandle progressHandle)
		{
			RequestHandle<ResultAnd<T>> requestHandle = new RequestHandle<ResultAnd<T>>();
			Task<ResultAnd<T>> task = Execute(config, requestHandle, progressHandle);
			requestHandle.task = task;
			return requestHandle;
		}

		public static async Task<ResultAnd<TResult>> Execute<TResult>(WebRequestConfig config, RequestHandle<ResultAnd<TResult>> handle, ProgressHandle progressHandle)
		{
			WebRequest request = null;
			if (handle != null)
			{
				handle.progress = progressHandle;
			}
			WebResponse response;
			try
			{
				WebRequest webRequest = ((!config.IsUpload) ? (await BuildWebRequest(config, progressHandle)) : BuildWebRequestForUpload(config, progressHandle));
				request = webRequest;
				request.Timeout = (config.ShouldRequestTimeout ? 30000 : (-1));
				if (handle != null)
				{
					handle.cancel = request.Abort;
				}
				request.LogRequestBeingSent(config);
				WebResponse webResponse = ((!config.IsUpload) ? (await request.GetResponseAsync()) : (await request.GetUploadResponse(config, progressHandle)));
				response = webResponse;
			}
			catch (Exception ex)
			{
				if (request != null)
				{
					WebRequestManager.ShutdownEvent -= request.Abort;
				}
				if (ex is WebException ex2)
				{
					response = ex2.Response;
					if (ex2.Status == WebExceptionStatus.RequestCanceled)
					{
						WebRequest webRequest2 = request;
						if (webRequest2 != null)
						{
							webRequest2.LogRequestBeingAborted(config);
						}
						return ResultAnd.Create(20506u, default(TResult));
					}
				}
				else
				{
					response = null;
				}
			}
			if (progressHandle != null)
			{
				progressHandle.Progress = 1f;
				progressHandle.Completed = true;
			}
			ResultAnd<TResult> resultAnd;
			try
			{
				if (ModIOUnityImplementation.shuttingDown)
				{
					WebRequest webRequest3 = request;
					if (webRequest3 != null)
					{
						webRequest3.LogRequestBeingAborted(config);
					}
					resultAnd = ResultAnd.Create(20506u, default(TResult));
				}
				else
				{
					resultAnd = await ProcessResponse<TResult>(request, response, config);
				}
			}
			catch (Exception ex3)
			{
				if (ex3 is WebException ex4)
				{
					ex4.Response?.Close();
				}
				Logger.Log(LogLevel.Error, "Unknown exception caught trying to process web request response.\nException: " + ex3.Message + "\nStacktrace: " + ex3.StackTrace);
				resultAnd = ResultAnd.Create(1u, default(TResult));
			}
			if (request != null)
			{
				WebRequestManager.ShutdownEvent -= request.Abort;
			}
			if (progressHandle != null)
			{
				progressHandle.Failed = !resultAnd.result.Succeeded();
			}
			return resultAnd;
		}

		private static void LogRequestBeingSent(this WebRequest request, WebRequestConfig config)
		{
			string text = "\n" + config.Url + "\nMETHOD: " + config.RequestMethodType + "\n" + GenerateLogForRequestMessage(request) + "\n" + GenerateLogForWebRequestConfig(config);
			Logger.Log(LogLevel.Verbose, "SENDING" + text);
		}

		private static void LogRequestBeingAborted(this WebRequest request, WebRequestConfig config)
		{
			string text = "\n" + config.Url + "\nMETHOD: " + config.RequestMethodType + "\n" + GenerateLogForRequestMessage(request) + "\n" + GenerateLogForWebRequestConfig(config);
			Logger.Log(LogLevel.Verbose, "ABORTED" + text);
		}

		private static async Task<Result> ProcessDownloadResponse(WebRequest request, WebResponse response, string url)
		{
			_ = ResultBuilder.Unknown;
			int num = (int)((response != null) ? ((HttpWebResponse)response).StatusCode : ((HttpStatusCode)0));
			Stream stream = null;
			if (response != null)
			{
				stream = response.GetResponseStream();
			}
			string completeRequestLog = GenerateLogForStatusCode(num) + "\n" + url + "\nMETHOD: GET\n" + GenerateLogForRequestMessage(request) + "\n" + GenerateLogForResponseMessage(response);
			Result result;
			if (IsSuccessStatusCode(num))
			{
				result = ResultBuilder.Success;
				Logger.Log(LogLevel.Verbose, "DOWNLOAD SUCCEEDED " + completeRequestLog);
			}
			else
			{
				result = await HttpStatusCodeError(stream, completeRequestLog, num);
				Logger.Log(LogLevel.Verbose, "DOWNLOAD FAILED [" + completeRequestLog + "]");
			}
			stream?.Dispose();
			response?.Close();
			return result;
		}

		private static async Task<ResultAnd<TResult>> ProcessResponse<TResult>(WebRequest request, WebResponse response, WebRequestConfig config)
		{
			int num = (int)((response != null) ? ((HttpWebResponse)response).StatusCode : ((HttpStatusCode)0));
			Stream stream = null;
			if (response != null && num != 204)
			{
				stream = response.GetResponseStream();
			}
			string text = GenerateLogForStatusCode(num) + "\n" + config.Url + "\nMETHOD: " + config.RequestMethodType + "\n" + GenerateLogForRequestMessage(request) + "\n" + GenerateLogForWebRequestConfig(config) + "\n" + GenerateLogForResponseMessage(response);
			ResultAnd<TResult> result;
			if (IsSuccessStatusCode(num))
			{
				Logger.Log(LogLevel.Verbose, "SUCCEEDED " + text);
				result = await FormatResult<TResult>(stream);
			}
			else
			{
				result = ResultAnd.Create(await HttpStatusCodeError(stream, text, num), default(TResult));
			}
			stream?.Dispose();
			response?.Close();
			return result;
		}

		private static bool IsSuccessStatusCode(int code)
		{
			if (code >= 200)
			{
				return code < 300;
			}
			return false;
		}

		private static async Task<WebResponse> GetDownloadResponse(this WebRequest request, Stream downloadStream, ProgressHandle progressHandle)
		{
			WebResponse response = await request.GetResponseAsync();
			using (Stream responseStream = response.GetResponseStream())
			{
				long totalSize = response.ContentLength;
				byte[] buffer = new byte[4096];
				long bytesDownloaded = 0L;
				long bytesDownloadedForThisSample = 0L;
				Stopwatch progressMeasure = new Stopwatch();
				Stopwatch yieldMeasure = new Stopwatch();
				progressMeasure.Start();
				yieldMeasure.Start();
				int num;
				while ((num = responseStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					downloadStream.Write(buffer, 0, num);
					bytesDownloaded += num;
					if (progressHandle != null)
					{
						bytesDownloadedForThisSample += num;
						if (progressMeasure.ElapsedMilliseconds >= 1000)
						{
							progressHandle.Progress = (float)((decimal)bytesDownloaded / (decimal)totalSize);
							progressHandle.BytesPerSecond = (long)((float)bytesDownloadedForThisSample * ((float)progressMeasure.ElapsedMilliseconds / 1000f));
							bytesDownloadedForThisSample = 0L;
							progressMeasure.Restart();
						}
						if (yieldMeasure.ElapsedMilliseconds >= 16)
						{
							await Task.Yield();
							yieldMeasure.Restart();
						}
					}
				}
				progressMeasure.Stop();
				yieldMeasure.Stop();
			}
			return response;
		}

		private static async Task<WebResponse> GetUploadResponse(this WebRequest request, WebRequestConfig config, ProgressHandle progressHandle)
		{
			await request.SetupMultipartRequest(config, progressHandle);
			return await request.GetResponseAsync();
		}

		private static async Task<WebRequest> BuildWebRequest(WebRequestConfig config, ProgressHandle progressHandle)
		{
			if (UserData.instance.IsOAuthTokenValid() && !config.DontUseAuthToken)
			{
				config.AddHeader("Authorization", "Bearer " + UserData.instance.oAuthToken);
			}
			else
			{
				config.Url = config.Url + "&api_key=" + Settings.server.gameKey;
			}
			HttpWebRequest request = WebRequest.Create(config.Url) as HttpWebRequest;
			request.Method = config.RequestMethodType;
			request.SetModioHeaders();
			request.SetConfigHeaders(config);
			WebRequestManager.ShutdownEvent += request.Abort;
			request.ContentType = "application/x-www-form-urlencoded";
			if (config.HasStringData)
			{
				await request.SetupUrlEncodedRequest(config);
			}
			return request;
		}

		private static WebRequest BuildWebRequestForUpload(WebRequestConfig config, ProgressHandle progressHandle)
		{
			HttpWebRequest httpWebRequest = WebRequest.Create(config.Url) as HttpWebRequest;
			httpWebRequest.Method = config.RequestMethodType;
			httpWebRequest.SetModioHeaders();
			httpWebRequest.SetConfigHeaders(config);
			if (UserData.instance.IsOAuthTokenValid())
			{
				httpWebRequest.Headers.Add("Authorization", "Bearer " + UserData.instance.oAuthToken);
			}
			WebRequestManager.ShutdownEvent += httpWebRequest.Abort;
			return httpWebRequest;
		}

		private static WebRequest BuildWebRequestForDownload(string url)
		{
			HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
			httpWebRequest.Method = "GET";
			httpWebRequest.SetModioHeaders();
			httpWebRequest.Timeout = -1;
			if (UserData.instance.IsOAuthTokenValid())
			{
				httpWebRequest.Headers.Add("Authorization", "Bearer " + UserData.instance.oAuthToken);
			}
			WebRequestManager.ShutdownEvent += httpWebRequest.Abort;
			return httpWebRequest;
		}

		private static void SetModioHeaders(this WebRequest webRequest)
		{
			HttpWebRequest obj = (HttpWebRequest)webRequest;
			obj.Accept = "application/json";
			obj.UserAgent = "unity-" + Application.unityVersion + "-" + ModIOVersion.Current.ToHeaderString();
			obj.Connection = "true";
			obj.Headers.Add("accept-language", Settings.server.languageCode ?? "en");
			obj.Headers.Add("x-modio-platform", PlatformConfiguration.RESTAPI_HEADER);
			obj.Headers.Add("x-modio-portal", ServerConstants.ConvertUserPortalToHeaderValue(Settings.build.userPortal));
		}

		private static void SetConfigHeaders(this WebRequest request, WebRequestConfig config)
		{
			foreach (KeyValuePair<string, string> headerDatum in config.HeaderData)
			{
				request.Headers.Add(headerDatum.Key, headerDatum.Value);
			}
		}

		private static async Task SetupUrlEncodedRequest(this WebRequest request, WebRequestConfig config)
		{
			string text = "";
			foreach (KeyValuePair<string, string> stringKvpDatum in config.StringKvpData)
			{
				text = text + Uri.EscapeDataString(stringKvpDatum.Key) + "=" + Uri.EscapeDataString(stringKvpDatum.Value) + "&";
			}
			text = text.Trim('&');
			using Stream requestStream = request.GetRequestStream();
			using StreamWriter writer = new StreamWriter(requestStream);
			await writer.WriteAsync(text);
		}

		private static async Task SetupMultipartRequest(this WebRequest request, WebRequestConfig config, ProgressHandle progressHandle)
		{
			string text = "---------------------------" + DateTime.Now.Ticks.ToString("x");
			request.ContentType = "multipart/form-data; boundary=" + text;
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent(text);
			foreach (BinaryDataContainer binaryDatum in config.BinaryData)
			{
				ByteArrayContent content = new ByteArrayContent(binaryDatum.data);
				multipartFormDataContent.Add(content, binaryDatum.key, binaryDatum.fileName);
			}
			foreach (KeyValuePair<string, string> stringKvpDatum in config.StringKvpData)
			{
				StringContent content2 = new StringContent(stringKvpDatum.Value);
				multipartFormDataContent.Add(content2, stringKvpDatum.Key);
			}
			using Stream requestStream = request.GetRequestStream();
			using Stream content3 = await multipartFormDataContent.ReadAsStreamAsync();
			long totalBytesRead = 0L;
			long bytesUploadedForThisSample = 0L;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			byte[] buffer = new byte[4096];
			while (true)
			{
				int num;
				int bytesRead = (num = await content3.ReadAsync(buffer, 0, buffer.Length));
				if (num <= 0)
				{
					break;
				}
				await requestStream.WriteAsync(buffer, 0, bytesRead);
				totalBytesRead += bytesRead;
				if (progressHandle != null)
				{
					progressHandle.Progress = (float)((decimal)totalBytesRead / ((decimal)content3.Length * 1.01m));
					bytesUploadedForThisSample += bytesRead;
					if (stopwatch.ElapsedMilliseconds >= 1000)
					{
						progressHandle.BytesPerSecond = bytesUploadedForThisSample;
						bytesUploadedForThisSample = 0L;
						stopwatch.Restart();
					}
				}
			}
			stopwatch.Stop();
		}

		public static async Task<ResultAnd<T>> FormatResult<T>(Stream response)
		{
			if (typeof(T) == typeof(int?))
			{
				return ResultAnd.Create(0u, default(T));
			}
			if (response == null)
			{
				return ResultAnd.Create(ResultBuilder.Success, default(T));
			}
			try
			{
				T value = await Task.Run(() => Deserialize<T>(response));
				return ResultAnd.Create(ResultBuilder.Success, value);
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Error, "UNRECOGNISED RESPONSE\nFailed to deserialize a response from the mod.io server.\nThe data may have been corrupted or isnt a valid Json format.\n\n[JsonUtility:" + $" {ex.Message}] - {ex.InnerException}");
				return ResultAnd.Create(ResultBuilder.Create(20300u), default(T));
			}
		}

		private static T Deserialize<T>(Stream content)
		{
			JsonSerializer jsonSerializer = new JsonSerializer();
			using StreamReader reader = new StreamReader(content);
			using JsonTextReader reader2 = new JsonTextReader(reader);
			return jsonSerializer.Deserialize<T>(reader2);
		}

		private static bool IsJson(string input)
		{
			if (input == null)
			{
				return false;
			}
			input = input.Trim();
			if (!input.StartsWith("{") || !input.EndsWith("}"))
			{
				if (input.StartsWith("["))
				{
					return input.EndsWith("]");
				}
				return false;
			}
			return true;
		}

		private static async Task<Result> HttpStatusCodeError(Stream response, string requestLog, int status)
		{
			ResultAnd<ErrorObject> resultAnd = await FormatResult<ErrorObject>(response);
			string text = GenerateErrorsIntoSingleLog(resultAnd.value.error.errors);
			object arg = status;
			HttpStatusCode httpStatusCode = (HttpStatusCode)status;
			Logger.Log(LogLevel.Error, $"HTTP ERROR [{arg} {httpStatusCode.ToString()}]" + $"\n Error ref [{resultAnd.value.error.code}] {resultAnd.value.error.error_ref} - {resultAnd.value.error.message}\n{text}\n\n{requestLog}");
			if (ResultCode.IsInvalidSession(resultAnd.value))
			{
				UserData.instance?.SetOAuthTokenAsRejected();
				ResponseCache.ClearCache();
				return ResultBuilder.Create(20101u, (uint)resultAnd.value.error.error_ref);
			}
			return ResultBuilder.Create(20303u, (uint)resultAnd.value.error.error_ref);
		}

		private static ResultAnd<TResult> TimeOutError<TResult>(WebRequestConfig requestConfig, WebException ex)
		{
			Logger.Log(LogLevel.Error, $"REQUEST TIMED OUT\nDid not receive a request within {30000} milliseconds. " + "Check your Internet connection and/or Firewall settings.\n URL: " + requestConfig.Url + "\nERROR: " + ex.ToString());
			return ResultAnd.Create(ResultBuilder.Create(20302u), default(TResult));
		}

		private static string GenerateLogForWebRequestConfig(WebRequestConfig config)
		{
			string text = "\nFORM BODY\n------------------------\n";
			if (config.StringKvpData.Count > 0)
			{
				text += "String Kvps\n";
				foreach (KeyValuePair<string, string> stringKvpDatum in config.StringKvpData)
				{
					text = text + stringKvpDatum.Key + ": " + stringKvpDatum.Value + "\n";
				}
			}
			else
			{
				text += "--No String Data\n";
			}
			if (config.BinaryData.Count > 0)
			{
				text += "Binary files\n";
				foreach (BinaryDataContainer binaryDatum in config.BinaryData)
				{
					text += $"{binaryDatum.key}: {binaryDatum.data.Length} bytes\n";
				}
			}
			else
			{
				text += "--No Binary Data\n";
			}
			return text;
		}

		private static string GenerateLogForRequestMessage(WebRequest request)
		{
			if (request == null)
			{
				return "\n\n------------------------ \nWebRequest is null";
			}
			string text = "\n\n------------------------";
			string text2 = "\nREQUEST HEADERS";
			string[] allKeys = request.Headers.AllKeys;
			foreach (string text3 in allKeys)
			{
				text2 = ((!(text3 == "Authorization")) ? (text2 + "\n" + text3 + ": " + request.Headers[text3]) : (text2 + "\nAuthorization: [OAUTHTOKEN]"));
			}
			return text + text2;
		}

		private static string GenerateLogForResponseMessage(WebResponse response)
		{
			if (response == null)
			{
				return "\n\n------------------------\n WebResponse is null";
			}
			string text = "\n\n------------------------";
			string text2 = "\nRESPONSE HEADERS";
			string[] allKeys = response.Headers.AllKeys;
			foreach (string text3 in allKeys)
			{
				text2 = text2 + "\n" + text3 + ": " + response.Headers[text3];
			}
			return text + text2;
		}

		private static string GenerateLogForStatusCode(int code)
		{
			return $"[Http: {code} {(HttpStatusCode)code}]";
		}

		private static string GenerateErrorsIntoSingleLog(Dictionary<string, string> errors)
		{
			if (errors == null || errors.Count == 0)
			{
				return "";
			}
			string text = "errors:";
			int num = 1;
			foreach (KeyValuePair<string, string> error in errors)
			{
				text += $"\n{num}. {error.Key}: {error.Value}";
				num++;
			}
			return text;
		}
	}
}
