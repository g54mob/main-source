using System.IO;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Logging
{
	public class LogTesterScript : MonoBehaviour
	{
		public string FirstError;

		public string LastRootError;

		[Range(0f, 1000f)]
		public int LogCapacity = 500;

		public bool LogClear;

		public int LogCount;

		public int RootErrorCount;

		private bool _logErrorsNextFrame;

		public void Update()
		{
			LogHistory.Instance.LogCapacity = LogCapacity;
			LogCount = LogHistory.Instance.LogCount;
			LastRootError = LogHistory.Instance.LastRootError?.Condition;
			RootErrorCount = LogHistory.Instance.RootErrors.Count;
			FirstError = LogHistory.Instance.FirstError?.Condition;
			if (LogClear)
			{
				LogClear = false;
				LogHistory.Instance.Clear();
			}
			if (DebugInput.GetKeyDown(KeyCode.Space))
			{
				File.WriteAllText("C:/temp/Log.txt", LogHistory.Instance.GenerateReport(rootErrorsOnly: false, clearAfter: false));
			}
			if (DebugInput.GetKeyDown(KeyCode.RightArrow))
			{
				Debug.LogFormat("Regular Message: {0}", Time.frameCount);
			}
			if (DebugInput.GetKeyDown(KeyCode.LeftArrow))
			{
				Debug.LogErrorFormat("Error Message: {0}", Time.frameCount);
			}
			if (_logErrorsNextFrame)
			{
				_logErrorsNextFrame = false;
				Debug.LogErrorFormat("Error Message: {0}-1", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-2", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-3", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-4", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-5", Time.frameCount);
				Debug.LogWarningFormat("Warning Message: {0}-3", Time.frameCount);
				Debug.LogFormat("Regular Message: {0}-4", Time.frameCount);
				Debug.LogFormat("Regular Message: {0}-5", Time.frameCount);
			}
			if (DebugInput.GetKeyDown(KeyCode.DownArrow))
			{
				Debug.LogErrorFormat("Error Message: {0}-1", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-2", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-3", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-4", Time.frameCount);
				Debug.LogErrorFormat("Error Message: {0}-5", Time.frameCount);
				Debug.LogWarningFormat("Warning Message: {0}-3", Time.frameCount);
				Debug.LogFormat("Regular Message: {0}-4", Time.frameCount);
				Debug.LogFormat("Regular Message: {0}-5", Time.frameCount);
				_logErrorsNextFrame = true;
			}
			if (DebugInput.GetKeyDown(KeyCode.UpArrow))
			{
				for (int i = 0; i < 500; i++)
				{
					Debug.LogFormat("Log message: {0}", i);
				}
			}
		}
	}
}
