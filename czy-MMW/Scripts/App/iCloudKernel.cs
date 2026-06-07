using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

public class iCloudKernel
{
	private bool _hasConnected;

	private float _connectionStartTime;

	private bool _haveFilesChanged;

	private bool _hasLoadCompleted;

	private bool _wasLoadSuccessful;

	private string _userId;

	private bool _hasUserChanged;

	private string _messageStringKey;

	private readonly List<string> _deletedFiles = new List<string>();

	private static iCloudKernel _instance = null;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("iCloudKernel");

	public static iCloudKernel Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new iCloudKernel();
			}
			return _instance;
		}
	}

	public float TimeSinceConnection => Time.realtimeSinceStartup - _connectionStartTime;

	private event Action<string> _userChanged;

	private event Action _filesChanged;

	private event Action<bool> _loadCompleted;

	private event Action<string> _fileDeleted;

	private event Action<string> _userMessageChanged;

	public event Action<string> UserChanged
	{
		add
		{
			if (_hasUserChanged)
			{
				value(_userId);
			}
			lock (this)
			{
				_userChanged += value;
			}
		}
		remove
		{
			lock (this)
			{
				_userChanged -= value;
			}
		}
	}

	public event Action FilesChanged
	{
		add
		{
			if (_haveFilesChanged)
			{
				value();
			}
			lock (this)
			{
				_filesChanged += value;
			}
		}
		remove
		{
			lock (this)
			{
				_filesChanged -= value;
			}
		}
	}

	public event Action<bool> LoadCompleted
	{
		add
		{
			if (_hasLoadCompleted)
			{
				value(_wasLoadSuccessful);
			}
			lock (this)
			{
				_loadCompleted += value;
			}
		}
		remove
		{
			lock (this)
			{
				_loadCompleted -= value;
			}
		}
	}

	public event Action<string> FileDeleted
	{
		add
		{
			foreach (string deletedFile in _deletedFiles)
			{
				value(deletedFile);
			}
			lock (this)
			{
				_fileDeleted += value;
			}
		}
		remove
		{
			lock (this)
			{
				_fileDeleted -= value;
			}
		}
	}

	public event Action<string> UserMessageChanged
	{
		add
		{
			if (!string.IsNullOrEmpty(_messageStringKey))
			{
				value(_messageStringKey);
			}
			lock (this)
			{
				_userMessageChanged += value;
			}
		}
		remove
		{
			lock (this)
			{
				_userMessageChanged -= value;
			}
		}
	}

	public event Action<string> FileStored;

	public void Connect()
	{
		if (!_hasConnected)
		{
			_hasConnected = true;
			IntPtr zero = IntPtr.Zero;
			zero = Marshal.GetFunctionPointerForDelegate<Action<string>>(OnLogMessageDelegate);
			iCloudAttemptLogin(Marshal.GetFunctionPointerForDelegate<Action<string>>(OnUserChangedDelegate), Marshal.GetFunctionPointerForDelegate<Action<string>>(OnFileWriteCompletedDelegate), Marshal.GetFunctionPointerForDelegate<Action>(OnFilesChangedDelegate), Marshal.GetFunctionPointerForDelegate<Action<string>>(OnFileDeletedDelegate), Marshal.GetFunctionPointerForDelegate<Action<bool>>(OnLoadCompletedDelegate), zero, Marshal.GetFunctionPointerForDelegate<Action<string>>(OnUserMessageDelegate), "iCloud.com.dinopoloclub.minimotorways");
			_connectionStartTime = Time.realtimeSinceStartup;
			appDelegateSetNotificationCallback(iCloudGetFunctionPointerToNotificationCallback());
		}
	}

	private void OnUserChanged(string newUserId)
	{
		if (!(_userId == newUserId) || !_hasUserChanged)
		{
			_hasUserChanged = true;
			_userId = newUserId;
			if (string.IsNullOrEmpty(_userId))
			{
				Log.Info("iCloud user disconnected.");
			}
			else
			{
				Log.Info("iCloud user connected with id {0}.", _userId);
			}
			this._userChanged?.Invoke(_userId);
		}
	}

	private void OnFilesChanged()
	{
		Log.Info("Data changed, processing new files.");
		_haveFilesChanged = true;
		this._filesChanged?.Invoke();
	}

	private void OnLoadCompleted(bool didSucceed)
	{
		if (didSucceed)
		{
			Log.Info("Load completed with no errors.");
		}
		else
		{
			Log.Info("Load completed with errors.");
		}
		_hasLoadCompleted = true;
		_wasLoadSuccessful = didSucceed;
		this._loadCompleted?.Invoke(_wasLoadSuccessful);
	}

	private void OnFileDeleted(string deletedFilename)
	{
		Log.Info("File {0} has been deleted from the database.", deletedFilename);
		_deletedFiles.Add(deletedFilename);
		this._fileDeleted?.Invoke(deletedFilename);
	}

	private void OnUserMessage(string messageStringKey)
	{
		Log.Info("Received message {0}.", messageStringKey);
		_messageStringKey = messageStringKey;
		this._userMessageChanged?.Invoke(messageStringKey);
	}

	private void OnFileStored(string filename)
	{
		Log.Info("File {0} was stored successfully.", filename);
		this.FileStored?.Invoke(filename);
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnUserChangedDelegate(string userId)
	{
		Instance?.OnUserChanged(userId);
	}

	[MonoPInvokeCallback(typeof(Action))]
	private static void OnFilesChangedDelegate()
	{
		Instance?.OnFilesChanged();
	}

	[MonoPInvokeCallback(typeof(Action<bool>))]
	private static void OnLoadCompletedDelegate(bool didSucceed)
	{
		Instance?.OnLoadCompleted(didSucceed);
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnFileDeletedDelegate(string deletedFilename)
	{
		Instance?.OnFileDeleted(deletedFilename);
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnUserMessageDelegate(string messageStringKey)
	{
		Instance?.OnUserMessage(messageStringKey);
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnLogMessageDelegate(string logMessage)
	{
		Log.Info(logMessage);
	}

	[MonoPInvokeCallback(typeof(Action<string>))]
	private static void OnFileWriteCompletedDelegate(string filename)
	{
		Instance?.OnFileStored(filename);
	}

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern void iCloudAttemptLogin(IntPtr userChangedCallback, IntPtr fileWriteCompletedCallback, IntPtr filesChangedCallback, IntPtr fileDeletedCallback, IntPtr loadCompletedCallback, IntPtr logCallback, IntPtr errorCallback, string containerId);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	private static extern long iCloudGetFunctionPointerToNotificationCallback();

	private static void appDelegateSetNotificationCallback(long functionAddress)
	{
	}
}
