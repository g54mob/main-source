using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cpp2ILInjected;
using Rewired.Utils.Libraries.CLZF2;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data;

public class UserDataStore_File : UserDataStore_KeyValue
{
	private sealed class DataStore : IDataStore
	{
		private Dictionary<string, object> _data;

		private readonly string _absFilePath;

		private IDataHandler _dataHandler;

		public DataStore(string fileName, string absDirectory, IDataHandler dataHandler)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			string absFilePath = Path.Combine(absDirectory, fileName);
			_absFilePath = absFilePath;
			if (dataHandler != null)
			{
				_dataHandler = dataHandler;
				Dictionary<string, object> data = new Dictionary<string, object>();
				_data = data;
				bool flag = Load();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			ArgumentNullException ex = new ArgumentNullException("dataHandler");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}

		public unsafe bool TryGetValue(string key, out object value)
		{
			//IL_005d: Expected I4, but got O
			if (!string.IsNullOrEmpty(key))
			{
				if (_data != null)
				{
					return ((Dictionary<object, object>)(object)_data).TryGetValue((object)key, out value);
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			ref object reference = ref *(object*)null;
			return false;
		}

		public bool SetValue(string key, object value)
		{
			//IL_0051: Expected I4, but got O
			if (!string.IsNullOrEmpty(key))
			{
				if (_data != null)
				{
					((Dictionary<object, object>)(object)_data).set_Item((object)key, value);
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}

		public bool Save()
		{
			//IL_0036: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1817B2820");
			string data = default(string);
			if (_dataHandler != null)
			{
				return _dataHandler.Save(_absFilePath, data);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		public bool Load()
		{
			//IL_00aa: Expected I4, but got O
			if (_dataHandler != null)
			{
				bool flag = _dataHandler.Load(_absFilePath, out var data);
				if (flag)
				{
					Dictionary<string, object> dictionary = JsonParser.FromJson<Dictionary<string, object>>(data);
					bool flag2 = dictionary != null;
					Dictionary<string, object> data2 = dictionary;
					if (!flag2)
					{
						Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
						data2 = dictionary2;
					}
					_data = data2;
				}
				return flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		public bool Clear()
		{
			//IL_0061: Expected I4, but got O
			if (_dataHandler != null)
			{
				bool result = _dataHandler.Clear(_absFilePath);
				_data.Clear();
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class LocalFileDataHandler : IDataHandler
	{
		private readonly Func<DataFormat> _dataFormatDelegate;

		private readonly Codec _codec;

		public LocalFileDataHandler(Func<DataFormat> dataFormatDelegate, Codec codec)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			if (dataFormatDelegate != null)
			{
				_dataFormatDelegate = dataFormatDelegate;
				bool flag = codec != null;
				UTF8Text codec2 = (UTF8Text)codec;
				if (!flag)
				{
					UTF8Text uTF8Text = new UTF8Text();
					codec2 = uTF8Text;
				}
				_codec = codec2;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			ArgumentNullException ex = new ArgumentNullException("dataFormatDelegate");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}

		public unsafe bool Load(string absoluteFilePath, out string data)
		{
			//IL_01f3: Expected I4, but got O
			ref string reference = ref *(string*)null;
			bool result;
			if (!string.IsNullOrEmpty(absoluteFilePath) && File.Exists(absoluteFilePath))
			{
				Func<DataFormat> dataFormatDelegate = _dataFormatDelegate;
				if (_dataFormatDelegate == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v107 @ rax_v7 (System.Func`1<Rewired.Data.UserDataStore_File+DataFormat>)+18] (should have been resolved before IL gen)");
				object obj = default(object);
				if (obj == null)
				{
					string text = File.ReadAllText(absoluteFilePath);
					reference = ref *(string*)text;
					bool flag = string.IsNullOrEmpty(data);
					result = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
				}
				else
				{
					if ((nint)obj != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						NotImplementedException ex2 = new NotImplementedException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
						throw ex2;
					}
					byte[] array = File.ReadAllBytes(absoluteFilePath);
					string text2 = _codec.Decode(array);
					reference = ref *(string*)text2;
					bool flag2 = array == null;
					result = false;
					if (!flag2)
					{
						bool flag3 = array.Length < 0;
						bool flag4 = array.Length == 0;
						bool flag5 = !flag3;
						bool flag6 = !flag4;
						result = flag6 & flag5;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool Save(string absoluteFilePath, string data)
		{
			//IL_0175: Expected I4, but got O
			if (!string.IsNullOrEmpty(absoluteFilePath))
			{
				string directoryName = Path.GetDirectoryName(absoluteFilePath);
				if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
				{
					DirectoryInfo directoryInfo = Directory.CreateDirectory(directoryName);
				}
				Func<DataFormat> dataFormatDelegate = _dataFormatDelegate;
				if (_dataFormatDelegate != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v182 @ rax_v9 (System.Func`1<Rewired.Data.UserDataStore_File+DataFormat>)+18] (should have been resolved before IL gen)");
					object obj = default(object);
					if (obj == null)
					{
						File.WriteAllText(absoluteFilePath, data);
					}
					else
					{
						if ((nint)obj != 1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							NotImplementedException ex = new NotImplementedException();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
							throw ex;
						}
						byte[] bytes = _codec.Encode(data);
						File.WriteAllBytes(absoluteFilePath, bytes);
					}
					return true;
				}
				NullReferenceException ex2 = new NullReferenceException();
				return (byte)(int)ex2 != 0;
			}
			return false;
		}

		public bool Clear(string absoluteFilePath)
		{
			if (!string.IsNullOrEmpty(absoluteFilePath) && File.Exists(absoluteFilePath))
			{
				File.Delete(absoluteFilePath);
				return true;
			}
			return false;
		}
	}

	private abstract class Codec
	{
		public abstract byte[] Encode(string @string);

		public abstract string Decode(byte[] data);
	}

	private sealed class UTF8Text : Codec
	{
		public override byte[] Encode(string @string)
		{
			Encoding uTF = Encoding.UTF8;
			if (uTF != null)
			{
				return uTF.GetBytes(@string);
			}
			return (byte[])(object)new NullReferenceException();
		}

		public override string Decode(byte[] data)
		{
			Encoding uTF = Encoding.UTF8;
			if (uTF != null)
			{
				return uTF.GetString(data);
			}
			return (string)(object)new NullReferenceException();
		}
	}

	private sealed class CLZF2 : Codec
	{
		private readonly Rewired.Utils.Libraries.CLZF2.CLZF2 _cLZF2;

		public CLZF2()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			Rewired.Utils.Libraries.CLZF2.CLZF2 cLZF = new Rewired.Utils.Libraries.CLZF2.CLZF2();
			_cLZF2 = cLZF;
		}

		public override byte[] Encode(string @string)
		{
			Encoding uTF = Encoding.UTF8;
			if (uTF != null)
			{
				byte[] bytes = uTF.GetBytes(@string);
				if (_cLZF2 != null)
				{
					return _cLZF2.Compress(bytes);
				}
			}
			return (byte[])(object)new NullReferenceException();
		}

		public override string Decode(byte[] data)
		{
			Encoding uTF = Encoding.UTF8;
			if (_cLZF2 != null)
			{
				byte[] bytes = _cLZF2.Decompress(data);
				if (uTF != null)
				{
					return uTF.GetString(bytes);
				}
			}
			return (string)(object)new NullReferenceException();
		}
	}

	public interface IDataHandler
	{
		bool Load(string absoluteFilePath, out string data);

		bool Save(string absoluteFilePath, string data);

		bool Clear(string absoluteFilePath);
	}

	public enum DataFormat
	{
		Text,
		Binary
	}

	private static readonly string thisScriptName;

	private const string logPrefix = "Rewired: ";

	private const string defaultExtensionText = ".json";

	private const string defaultExtensionBinary = ".bin";

	private const string defaultFileName = "RewiredSaveData.json";

	private string _fileName = "RewiredSaveData.json";

	private DataFormat _dataFormat;

	[NonSerialized]
	private string __directory;

	[NonSerialized]
	private DataStore _dataStore;

	[NonSerialized]
	private IDataHandler __dataHandler;

	[NonSerialized]
	private bool _initialized;

	public string directory
	{
		get
		{
			if (!string.IsNullOrEmpty(__directory))
			{
				return __directory;
			}
			return __directory = Application.persistentDataPath;
		}
		set
		{
			__directory = value;
			if (_initialized)
			{
				OnDataSourceChanged();
			}
		}
	}

	public string fileName
	{
		get
		{
			return _fileName;
		}
		set
		{
			_fileName = value;
			if (_initialized)
			{
				OnDataSourceChanged();
			}
		}
	}

	public DataFormat dataFormat
	{
		get
		{
			return _dataFormat;
		}
		set
		{
			bool flag = !_initialized;
			_dataFormat = value;
			if (!flag)
			{
				OnDataSourceChanged();
			}
		}
	}

	protected IDataHandler dataHandler
	{
		get
		{
			//IL_0045: Expected O, but got I
			if (__dataHandler != null)
			{
				return __dataHandler;
			}
			Func<DataFormat> func = () => _dataFormat;
			CLZF2 cLZF = new CLZF2();
			Rewired.Utils.Libraries.CLZF2.CLZF2 cLZF2 = new Rewired.Utils.Libraries.CLZF2.CLZF2();
			cLZF._cLZF2 = cLZF2;
			LocalFileDataHandler localFileDataHandler = new LocalFileDataHandler(null, (Codec)0);
			if (func != null)
			{
				localFileDataHandler._dataFormatDelegate = func;
				localFileDataHandler._codec = cLZF;
				__dataHandler = localFileDataHandler;
				return localFileDataHandler;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			ArgumentNullException ex = new ArgumentNullException("dataFormatDelegate");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
		set
		{
			__dataHandler = value;
			if (_initialized)
			{
				OnDataSourceChanged();
			}
		}
	}

	protected override IDataStore dataStore => _dataStore;

	protected virtual void SetInitialValues()
	{
	}

	protected override void OnInitialize()
	{
		SetInitialValues();
		_initialized = true;
		OnDataSourceChanged();
		if (!base._loadDataOnStart)
		{
			return;
		}
		Load();
		if (base._loadKeyboardAssignments || base._loadMouseAssignments || base._loadJoystickAssignments)
		{
			ReInput.ControllerHelper controllers = ReInput.controllers;
			int joystickCount = controllers.joystickCount;
			if (joystickCount > 0)
			{
				base._wasJoystickEverDetected = true;
				bool flag = SaveControllerAssignments();
			}
		}
	}

	private void OnDataSourceChanged()
	{
		//IL_006a: Expected O, but got I
		//IL_0104: Expected O, but got I4
		//IL_00aa: Expected O, but got I4
		string path = (string.IsNullOrEmpty(_fileName) ? "RewiredSaveData.json" : _fileName);
		string path2 = directory;
		LocalFileDataHandler localFileDataHandler;
		if (__dataHandler != null)
		{
			localFileDataHandler = (LocalFileDataHandler)__dataHandler;
		}
		else
		{
			Func<DataFormat> func = () => _dataFormat;
			CLZF2 cLZF = new CLZF2();
			Rewired.Utils.Libraries.CLZF2.CLZF2 cLZF2 = new Rewired.Utils.Libraries.CLZF2.CLZF2();
			cLZF._cLZF2 = cLZF2;
			LocalFileDataHandler localFileDataHandler2 = new LocalFileDataHandler(null, (Codec)0);
			if (func == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				ArgumentNullException ex = new ArgumentNullException("dataFormatDelegate");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
			localFileDataHandler2._dataFormatDelegate = func;
			localFileDataHandler2._codec = cLZF;
			__dataHandler = localFileDataHandler2;
			object obj = 0;
			localFileDataHandler = localFileDataHandler2;
		}
		DataStore dataStore = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		string text = (dataStore._absFilePath = Path.Combine(path2, path));
		bool flag = localFileDataHandler == null;
		string text2 = text;
		object obj2 = 0;
		if (!flag)
		{
			dataStore._dataHandler = localFileDataHandler;
			Dictionary<string, object> data = new Dictionary<string, object>();
			dataStore._data = data;
			bool flag2 = dataStore.Load();
			_dataStore = dataStore;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentNullException ex2 = new ArgumentNullException("dataHandler");
		ex2._002Ector("dataHandler");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex2;
	}

	public UserDataStore_File()
	{
		base._isEnabled = true;
		base._loadMouseAssignments = true;
		base._allowImpreciseJoystickAssignmentMatching = true;
		StringBuilder sb = new StringBuilder();
		base._sb = sb;
		((UserDataStore)this)._002Ector();
	}

	static UserDataStore_File()
	{
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(UserDataStore_File));
		string text = typeFromHandle.Name;
		thisScriptName = text;
	}

	private DataFormat _003Cget_dataHandler_003Eb__17_0()
	{
		return _dataFormat;
	}
}
