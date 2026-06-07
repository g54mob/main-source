using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Unity.Collections;
using UnityEngine;

namespace FFmpegOut
{
	public sealed class FFmpegPipe : IDisposable
	{
		private Process _subprocess;

		private Thread _copyThread;

		private Thread _pipeThread;

		private AutoResetEvent _copyPing = new AutoResetEvent(initialState: false);

		private AutoResetEvent _copyPong = new AutoResetEvent(initialState: false);

		private AutoResetEvent _pipePing = new AutoResetEvent(initialState: false);

		private AutoResetEvent _pipePong = new AutoResetEvent(initialState: false);

		private bool _terminate;

		private Queue<NativeArray<byte>> _copyQueue = new Queue<NativeArray<byte>>();

		private Queue<byte[]> _pipeQueue = new Queue<byte[]>();

		private Queue<byte[]> _freeBuffer = new Queue<byte[]>();

		public static bool IsAvailable => File.Exists(ExecutablePath);

		public static string ExecutablePath
		{
			get
			{
				string streamingAssetsPath = Application.streamingAssetsPath;
				switch (Application.platform)
				{
				case RuntimePlatform.OSXEditor:
				case RuntimePlatform.OSXPlayer:
					return streamingAssetsPath + "/FFmpegOut/macOS/ffmpeg";
				case RuntimePlatform.LinuxPlayer:
				case RuntimePlatform.LinuxEditor:
					return streamingAssetsPath + "/FFmpegOut/Linux/ffmpeg";
				default:
					return streamingAssetsPath + "/FFmpegOut/Windows/ffmpeg.exe";
				}
			}
		}

		public FFmpegPipe(string arguments)
		{
			_subprocess = Process.Start(new ProcessStartInfo
			{
				FileName = ExecutablePath,
				Arguments = arguments,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			});
			_copyThread = new Thread(CopyThread);
			_pipeThread = new Thread(PipeThread);
			_copyThread.Start();
			_pipeThread.Start();
		}

		public void PushFrameData(NativeArray<byte> data)
		{
			lock (_copyQueue)
			{
				_copyQueue.Enqueue(data);
			}
			_copyPing.Set();
		}

		public void SyncFrameData()
		{
			while (_copyQueue.Count > 0)
			{
				_copyPong.WaitOne();
			}
			while (_pipeQueue.Count > 4)
			{
				_pipePong.WaitOne();
			}
		}

		public string CloseAndGetOutput()
		{
			_terminate = true;
			_copyPing.Set();
			_pipePing.Set();
			_copyThread.Join();
			_pipeThread.Join();
			_subprocess.StandardInput.Close();
			_subprocess.WaitForExit();
			StreamReader standardError = _subprocess.StandardError;
			string result = standardError.ReadToEnd();
			_subprocess.Close();
			_subprocess.Dispose();
			standardError.Close();
			standardError.Dispose();
			_subprocess = null;
			_copyThread = null;
			_pipeThread = null;
			_copyQueue = null;
			_pipeQueue = (_freeBuffer = null);
			return result;
		}

		public void Dispose()
		{
			if (!_terminate)
			{
				CloseAndGetOutput();
			}
		}

		~FFmpegPipe()
		{
			if (!_terminate)
			{
				UnityEngine.Debug.LogError("An unfinalized FFmpegPipe object was detected. It should be explicitly closed or disposed before being garbage-collected.");
			}
		}

		private void CopyThread()
		{
			while (!_terminate)
			{
				_copyPing.WaitOne();
				while (_copyQueue.Count > 0)
				{
					NativeArray<byte> nativeArray;
					lock (_copyQueue)
					{
						nativeArray = _copyQueue.Peek();
					}
					byte[] array = null;
					if (_freeBuffer.Count > 0)
					{
						lock (_freeBuffer)
						{
							array = _freeBuffer.Dequeue();
						}
					}
					if (array == null || array.Length != nativeArray.Length)
					{
						array = nativeArray.ToArray();
					}
					else
					{
						nativeArray.CopyTo(array);
					}
					lock (_pipeQueue)
					{
						_pipeQueue.Enqueue(array);
					}
					_pipePing.Set();
					lock (_copyQueue)
					{
						_copyQueue.Dequeue();
					}
					_copyPong.Set();
				}
			}
		}

		private void PipeThread()
		{
			Stream baseStream = _subprocess.StandardInput.BaseStream;
			while (!_terminate)
			{
				_pipePing.WaitOne();
				while (_pipeQueue.Count > 0)
				{
					byte[] array;
					lock (_pipeQueue)
					{
						array = _pipeQueue.Dequeue();
					}
					try
					{
						baseStream.Write(array, 0, array.Length);
						baseStream.Flush();
					}
					catch
					{
					}
					lock (_freeBuffer)
					{
						_freeBuffer.Enqueue(array);
					}
					_pipePong.Set();
				}
			}
		}
	}
}
