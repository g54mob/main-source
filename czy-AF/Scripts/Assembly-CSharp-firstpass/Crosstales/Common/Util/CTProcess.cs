using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using UnityEngine;

namespace Crosstales.Common.Util
{
	public class CTProcess : IDisposable
	{
		private uint exitCode = 123456u;

		private CTProcessStartInfo startInfo = new CTProcessStartInfo();

		private EventHandler _onExited;

		private DataReceivedEventHandler _onOutputDataReceived;

		private DataReceivedEventHandler _onErrorDataReceived;

		private IntPtr threadHandle = IntPtr.Zero;

		private static readonly FieldInfo[] eventFields = typeof(DataReceivedEventArgs).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic);

		private const uint Infinite = uint.MaxValue;

		private const uint CREATE_NO_WINDOW = 134217728u;

		public IntPtr Handle { get; private set; }

		public int Id { get; private set; }

		public CTProcessStartInfo StartInfo
		{
			get
			{
				return startInfo;
			}
			set
			{
				if (value != null)
				{
					startInfo = value;
				}
			}
		}

		public bool HasExited { get; private set; }

		public uint ExitCode => exitCode;

		public DateTime StartTime { get; private set; }

		public DateTime ExitTime { get; private set; }

		public StreamReader StandardOutput { get; private set; }

		public StreamReader StandardError { get; private set; }

		public bool isBusy { get; private set; }

		public event EventHandler Exited
		{
			add
			{
				_onExited = (EventHandler)Delegate.Combine(_onExited, value);
			}
			remove
			{
				_onExited = (EventHandler)Delegate.Remove(_onExited, value);
			}
		}

		public event DataReceivedEventHandler OutputDataReceived
		{
			add
			{
				_onOutputDataReceived = (DataReceivedEventHandler)Delegate.Combine(_onOutputDataReceived, value);
			}
			remove
			{
				_onOutputDataReceived = (DataReceivedEventHandler)Delegate.Remove(_onOutputDataReceived, value);
			}
		}

		public event DataReceivedEventHandler ErrorDataReceived
		{
			add
			{
				_onErrorDataReceived = (DataReceivedEventHandler)Delegate.Combine(_onErrorDataReceived, value);
			}
			remove
			{
				_onErrorDataReceived = (DataReceivedEventHandler)Delegate.Remove(_onErrorDataReceived, value);
			}
		}

		private void onExited()
		{
			if (BaseConstants.DEV_DEBUG)
			{
				UnityEngine.Debug.Log("onExited: " + ExitCode);
			}
			if (_onExited != null)
			{
				_onExited(this, new EventArgs());
			}
		}

		public void Start()
		{
			cleanup();
			isBusy = true;
			HasExited = false;
			if (StartInfo.UseThread)
			{
				new Thread((ThreadStart)delegate
				{
					createProcess();
				}).Start();
				Thread.Sleep(200);
			}
			else
			{
				createProcess();
			}
		}

		public void Start(CTProcessStartInfo info)
		{
			if (info != null)
			{
				StartInfo = info;
			}
			Start();
		}

		public void Kill()
		{
			if (Handle != IntPtr.Zero)
			{
				uint num = 99999u;
				NativeMethods.TerminateProcess(Handle, ref num);
				Dispose();
			}
		}

		public void WaitForExit(int milliseconds = 0)
		{
			if (milliseconds > 0)
			{
				NativeMethods.WaitForSingleObject(Handle, (uint)milliseconds);
			}
			else
			{
				NativeMethods.WaitForSingleObject(Handle, uint.MaxValue);
			}
		}

		public void BeginOutputReadLine()
		{
			new Thread((ThreadStart)delegate
			{
				watchStdOut();
			}).Start();
		}

		public void BeginErrorReadLine()
		{
			new Thread((ThreadStart)delegate
			{
				watchStdErr();
			}).Start();
		}

		public void Dispose()
		{
			if (BaseConstants.DEV_DEBUG)
			{
				UnityEngine.Debug.LogWarning("Dispose called!");
			}
			if (Handle != IntPtr.Zero)
			{
				NativeMethods.CloseHandle(Handle);
			}
			if (threadHandle != IntPtr.Zero)
			{
				NativeMethods.CloseHandle(threadHandle);
			}
			Handle = IntPtr.Zero;
			threadHandle = IntPtr.Zero;
			Id = 0;
			isBusy = false;
			HasExited = true;
			if (StandardOutput != null)
			{
				StandardOutput.Dispose();
			}
			if (StandardError != null)
			{
				StandardError.Dispose();
			}
		}

		private void createProcess()
		{
			StartTime = DateTime.Now;
			string text = StartInfo.FileName;
			string text2 = StartInfo.Arguments;
			if (BaseConstants.DEV_DEBUG)
			{
				UnityEngine.Debug.LogWarning("createProcess: " + StartTime);
			}
			NativeMethods.STARTUPINFOEX lpStartupInfo = default(NativeMethods.STARTUPINFOEX);
			try
			{
				if ((StartInfo.RedirectStandardOutput || StartInfo.RedirectStandardError || StartInfo.UseCmdExecute) && !StartInfo.FileName.CTContains("cmd"))
				{
					text = BaseConstants.CMD_WINDOWS_PATH;
					text2 = "/c call \"" + StartInfo.FileName + "\" " + StartInfo.Arguments;
				}
				if (StartInfo.RedirectStandardOutput)
				{
					string tempFileName = Path.GetTempFileName();
					text2 = text2 + " > \"" + tempFileName + "\"";
					if (BaseConstants.DEV_DEBUG)
					{
						UnityEngine.Debug.Log("tempStdFile: " + tempFileName);
					}
					StandardOutput = new StreamReader(new FileStream(tempFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), StartInfo.StandardOutputEncoding);
				}
				else
				{
					StandardOutput = new StreamReader(new MemoryStream(), StartInfo.StandardOutputEncoding);
				}
				if (StartInfo.RedirectStandardError)
				{
					string tempFileName2 = Path.GetTempFileName();
					text2 = text2 + " 2> \"" + tempFileName2 + "\"";
					if (BaseConstants.DEV_DEBUG)
					{
						UnityEngine.Debug.Log("tempErrFile: " + tempFileName2);
					}
					StandardError = new StreamReader(new FileStream(tempFileName2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), StartInfo.StandardOutputEncoding);
				}
				else
				{
					StandardError = new StreamReader(new MemoryStream(), StartInfo.StandardOutputEncoding);
				}
				NativeMethods.SECURITY_ATTRIBUTES lpProcessAttributes = default(NativeMethods.SECURITY_ATTRIBUTES);
				NativeMethods.SECURITY_ATTRIBUTES lpThreadAttributes = default(NativeMethods.SECURITY_ATTRIBUTES);
				lpProcessAttributes.nLength = Marshal.SizeOf(lpProcessAttributes);
				lpThreadAttributes.nLength = Marshal.SizeOf(lpThreadAttributes);
				if (BaseConstants.DEV_DEBUG)
				{
					UnityEngine.Debug.Log("application: " + text + Environment.NewLine + "arguments: " + text2);
				}
				if (NativeMethods.CreateProcess(text, " " + text2, ref lpProcessAttributes, ref lpThreadAttributes, bInheritHandles: true, StartInfo.CreateNoWindow ? 134217728u : 0u, IntPtr.Zero, StartInfo.WorkingDirectory, ref lpStartupInfo, out var lpProcessInformation))
				{
					Handle = lpProcessInformation.hProcess;
					threadHandle = lpProcessInformation.hThread;
					Id = lpProcessInformation.dwProcessId;
					WaitForExit();
					return;
				}
				UnityEngine.Debug.LogError("Could not start process: '" + StartInfo.FileName + "'" + Environment.NewLine + "Arguments: '" + StartInfo.Arguments + "'" + Environment.NewLine + "working dir: '" + StartInfo.WorkingDirectory + "'" + Environment.NewLine + "Last error: " + NativeMethods.GetLastError());
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogError("Process threw an error: " + ex);
				Dispose();
			}
			finally
			{
				Thread.Sleep(200);
				NativeMethods.GetExitCodeProcess(Handle, ref exitCode);
				ExitTime = DateTime.Now;
				if (Handle != IntPtr.Zero)
				{
					NativeMethods.CloseHandle(Handle);
				}
				if (threadHandle != IntPtr.Zero)
				{
					NativeMethods.CloseHandle(threadHandle);
				}
				Handle = IntPtr.Zero;
				threadHandle = IntPtr.Zero;
				Id = 0;
				if (!HasExited)
				{
					onExited();
				}
				isBusy = false;
				HasExited = true;
			}
		}

		private void cleanup()
		{
			Kill();
			Dispose();
		}

		private void watchStdOut()
		{
			using StreamReader streamReader = StandardOutput;
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				if (BaseConstants.DEV_DEBUG)
				{
					UnityEngine.Debug.Log("watchStdOut: " + text);
				}
				if (_onOutputDataReceived != null)
				{
					_onOutputDataReceived(this, createMockDataReceivedEventArgs(text));
				}
			}
		}

		private void watchStdErr()
		{
			using StreamReader streamReader = StandardError;
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				if (BaseConstants.DEV_DEBUG)
				{
					UnityEngine.Debug.Log("watchStdErr: " + text);
				}
				if (_onErrorDataReceived != null)
				{
					_onErrorDataReceived(this, createMockDataReceivedEventArgs(text));
				}
			}
		}

		private static DataReceivedEventArgs createMockDataReceivedEventArgs(string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				throw new ArgumentException("Data is null or empty.", "data");
			}
			DataReceivedEventArgs e = (DataReceivedEventArgs)FormatterServices.GetUninitializedObject(typeof(DataReceivedEventArgs));
			if (eventFields.Length != 0)
			{
				eventFields[0].SetValue(e, data);
			}
			else
			{
				UnityEngine.Debug.LogError("Could not create 'DataReceivedEventArgs'!");
			}
			return e;
		}
	}
}
