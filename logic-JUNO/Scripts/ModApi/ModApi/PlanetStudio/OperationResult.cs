using System;
using UnityEngine;

namespace ModApi.PlanetStudio
{
	public class OperationResult
	{
		public string ErrorMessage { get; }

		public Exception Exception { get; }

		public string InfoMessage { get; }

		public bool IsCanceled { get; private set; }

		public bool IsSuccess { get; }

		public string Message
		{
			get
			{
				string text = string.Empty;
				if (Exception != null)
				{
					text = text + "Exception: " + Exception.Message + ", ";
				}
				if (ErrorMessage != null)
				{
					text = text + "Error: " + WarningMessage + ", ";
				}
				if (WarningMessage != null)
				{
					text = text + "Warning: " + WarningMessage;
				}
				return text;
			}
		}

		public string WarningMessage { get; }

		public OperationResult(bool success, string infoMessage = null, string warningMessage = null, string errorMessage = null, Exception exception = null)
		{
			IsSuccess = success;
			InfoMessage = infoMessage;
			WarningMessage = warningMessage;
			ErrorMessage = errorMessage;
			Exception = exception;
		}

		public static OperationResult Cancel()
		{
			return new OperationResult(success: false)
			{
				IsCanceled = true
			};
		}

		public static OperationResult Failure(string errorMessage = null, string warningMessage = null)
		{
			return new OperationResult(success: false, null, warningMessage, errorMessage);
		}

		public static OperationResult Failure(Exception exception, string errorMessage = null, string warningMessage = null)
		{
			return new OperationResult(success: false, null, warningMessage, errorMessage ?? exception.Message, exception);
		}

		public static OperationResult Success(string infoMessage = null, string warningMessage = null)
		{
			return new OperationResult(success: true, infoMessage, warningMessage);
		}

		public void Log()
		{
			if (!string.IsNullOrEmpty(InfoMessage))
			{
				Debug.Log(InfoMessage);
			}
			if (!string.IsNullOrEmpty(WarningMessage))
			{
				Debug.LogWarning(WarningMessage);
			}
			if (!string.IsNullOrEmpty(ErrorMessage))
			{
				Debug.LogError(ErrorMessage);
			}
			if (Exception != null)
			{
				Debug.LogException(Exception);
			}
		}
	}
}
