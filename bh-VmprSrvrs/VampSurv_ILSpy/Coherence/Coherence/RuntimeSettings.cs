using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Coherence.Common;
using Coherence.Plugins.NativeUtils;
using Coherence.Transport;
using Cpp2ILInjected;
using UnityEngine;

namespace Coherence;

public class RuntimeSettings : PreloadedSingleton<RuntimeSettings>, IRuntimeSettings
{
	[Serializable]
	public class AdvancedSettings
	{
		internal static bool Enabled = ThreadResumerSettings.SteamDetected;

		public ThreadResumerSettings ThreadResumer = new ThreadResumerSettings
		{
			Enabled = ThreadResumerSettings.SteamDetected,
			SearchIntervalMs = 50u,
			LongSearchWarnThresholdMs = 50u,
			WarnOnSuspension = true
		};
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SchemaAsset, string> _003C_003E9__107_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CInit_003Eb__107_0(SchemaAsset s)
		{
			if ((object)s != null)
			{
				return s.raw;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	private string _003CCombinedSchemaText_003Ek__BackingField;

	private string schemaID;

	private VersionInfo versionInfo;

	private string runtimeKey;

	private string simulatorSlug;

	private string localHost = Constants.localHost;

	private int localWorldUDPPort = Constants.localWorldUDPPort;

	private int localWorldWebPort = Constants.localWorldWebPort;

	private int remoteWebPort = Constants.remoteWebPort;

	private int localRoomsUDPPort = Constants.localRoomsUDPPort;

	private int localRoomsWebPort = Constants.localRoomsWebPort;

	private int apiPort = Constants.apiPort;

	private int worldsAPIPort = Constants.worldsApiPort;

	private string localHttpServerHost = Constants.localHttpServerHost;

	private int localHttpServerPort = Constants.localHttpServerPort;

	private bool localDevelopmentMode = true;

	private bool useDebugStreams;

	private string organizationID;

	private string projectID;

	private string projectName;

	private string organizationName;

	private TransportType transportType;

	private TransportConfiguration transportConfiguration;

	private AdvancedSettings advancedSettings;

	private string replicationServerToken;

	private string playApiEndpoint = Constants.apiEndpoint;

	private string webSocketEndpoint;

	internal SchemaAsset[] schemas;

	public SchemaAsset[] extraSchemas;

	internal DefaultTransportMode defaultTransportMode;

	internal bool defaultTransportModeMigrated;

	[NonSerialized]
	private bool disableKeepAlive;

	public bool IsWebGL
	{
		get
		{
			//IL_0018: Expected O, but got I4
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			object obj = Application.platform;
			object obj2 = obj - 17;
			return obj2 == null;
		}
	}

	public string ApiEndpoint => playApiEndpoint;

	public string WebSocketEndpoint => webSocketEndpoint;

	public string LocalHost => localHost;

	public int LocalWorldUDPPort => localWorldUDPPort;

	public int LocalWorldWebPort => localWorldWebPort;

	public int RemoteWebPort => remoteWebPort;

	public int LocalRoomsUDPPort => localRoomsUDPPort;

	public int LocalRoomsWebPort => localRoomsWebPort;

	public int APIPort => apiPort;

	public int WorldsAPIPort => worldsAPIPort;

	public string LocalHttpServerHost => localHttpServerHost;

	public int LocalHttpServerPort => localHttpServerPort;

	public bool LocalDevelopmentMode => localDevelopmentMode;

	public bool UseDebugStreams => useDebugStreams;

	public AdvancedSettings Advanced => advancedSettings;

	public string RuntimeKey
	{
		get
		{
			return runtimeKey;
		}
		internal set
		{
			runtimeKey = value;
		}
	}

	public string SimulatorSlug
	{
		get
		{
			return simulatorSlug;
		}
		set
		{
			simulatorSlug = value;
		}
	}

	public string SchemaID
	{
		get
		{
			return schemaID;
		}
		internal set
		{
			schemaID = value;
		}
	}

	public IVersionInfo VersionInfo
	{
		get
		{
			return versionInfo;
		}
		set
		{
			//IL_014e: Expected I, but got O
			//IL_001c: Expected I, but got O
			//IL_002c: Expected O, but got I
			//IL_0068: Expected O, but got I
			//IL_00ad: Expected I, but got O
			//IL_00b5: Expected I, but got O
			//IL_00c5: Expected O, but got I
			//IL_0101: Expected O, but got I
			nint num = (nint)typeof(VersionInfo);
			if (value == null)
			{
				versionInfo = (VersionInfo)value;
				return;
			}
			nint num2 = (nint)value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1 (Il2CppClass<Coherence.VersionInfo>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v7 (Il2CppClass<Coherence.Common.IVersionInfo>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1 (Il2CppClass<Coherence.VersionInfo>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v7 (Il2CppClass<Coherence.Common.IVersionInfo>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v15+FFFFFFF8+v46 @ rax_v10*8]");
				if (0 == (nint)typeof(VersionInfo))
				{
					versionInfo = (VersionInfo)value;
					nint num4 = (nint)typeof(VersionInfo);
					nint num5 = (nint)value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v6 (Il2CppClass<Coherence.VersionInfo>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v9 (Il2CppClass<Coherence.Common.IVersionInfo>)+130]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v6 (Il2CppClass<Coherence.VersionInfo>)+130]");
					if (num6 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v9 (Il2CppClass<Coherence.Common.IVersionInfo>)+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v17+FFFFFFF8+v166 @ rax_v16*8]");
						if (0 == (nint)typeof(VersionInfo))
						{
							return;
						}
					}
					throw new InvalidCastException();
				}
			}
			throw new InvalidCastException();
		}
	}

	public string OrganizationID
	{
		get
		{
			return organizationID;
		}
		internal set
		{
			organizationID = value;
		}
	}

	public string OrganizationName
	{
		get
		{
			return organizationName;
		}
		internal set
		{
			organizationName = value;
		}
	}

	public string ProjectID
	{
		get
		{
			return projectID;
		}
		internal set
		{
			projectID = value;
		}
	}

	public string ProjectName
	{
		get
		{
			return projectName;
		}
		internal set
		{
			projectName = value;
		}
	}

	public TransportType TransportType
	{
		get
		{
			return transportType;
		}
		internal set
		{
			transportType = value;
		}
	}

	public TransportConfiguration TransportConfiguration
	{
		get
		{
			return transportConfiguration;
		}
		internal set
		{
			transportConfiguration = value;
		}
	}

	public string ReplicationServerToken
	{
		get
		{
			return replicationServerToken;
		}
		internal set
		{
			replicationServerToken = value;
		}
	}

	public IReadOnlyCollection<SchemaAsset> DefaultSchemas => schemas;

	public string CombinedSchemaText
	{
		get
		{
			return _003CCombinedSchemaText_003Ek__BackingField;
		}
		private set
		{
			_003CCombinedSchemaText_003Ek__BackingField = value;
		}
	}

	public bool DisableKeepAlive
	{
		get
		{
			return disableKeepAlive;
		}
		set
		{
			disableKeepAlive = value;
		}
	}

	private void Reset()
	{
		localHost = Constants.localHost;
		localWorldUDPPort = Constants.localWorldUDPPort;
		localWorldWebPort = Constants.localWorldWebPort;
		localRoomsUDPPort = Constants.localRoomsUDPPort;
		localRoomsWebPort = Constants.localRoomsWebPort;
		apiPort = Constants.apiPort;
		remoteWebPort = Constants.remoteWebPort;
		playApiEndpoint = Constants.apiEndpoint;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if ((object)this != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.RuntimeSettings)+10]");
			if ((nint)0 != 0)
			{
				LoadCliOverrides();
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 130 Invalid \"Jump target not found in method: 0x181BEC5F0\"");
			}
		}
	}

	private void Init()
	{
		string text = playApiEndpoint;
		if (playApiEndpoint != null && text._stringLength > 0)
		{
			if (!playApiEndpoint.StartsWith("http://localhost:"))
			{
				string text2 = playApiEndpoint.Replace("http://", "https://");
				playApiEndpoint = text2;
			}
		}
		else
		{
			playApiEndpoint = Constants.apiEndpoint;
		}
		string text3 = playApiEndpoint.Replace("http://", "ws://");
		string text4 = text3.Replace("https://", "wss://");
		webSocketEndpoint = text4;
		string text5 = webSocketEndpoint;
		if ("/play/api/v1" != null)
		{
			if (text5._stringLength >= 0)
			{
				if (text5._stringLength >= 0 && text5._stringLength >= text5._stringLength)
				{
					int count = default(int);
					bool ignoreCase = default(bool);
					int num = CompareInfo.Invariant.IndexOfOrdinal(text5, "/play/api/v1", 0, count, ignoreCase);
					if (num <= -1)
					{
						string text6 = webSocketEndpoint + "/ws";
						webSocketEndpoint = text6;
					}
					else
					{
						string text7 = webSocketEndpoint.Replace("/play/api/v1", "/play/ws/v1");
						webSocketEndpoint = text7;
					}
					string text8;
					if (schemas == null)
					{
						text8 = "";
					}
					else
					{
						Func<SchemaAsset, string> selector = _003C_003Ec._003C_003E9__107_0;
						if (_003C_003Ec._003C_003E9__107_0 == null)
						{
							selector = (_003C_003Ec._003C_003E9__107_0 = (SchemaAsset s) => (string)(((object)s != null) ? ((object)s.raw) : ((object)new NullReferenceException())));
						}
						IEnumerable<string> values = Enumerable.Select(schemas, selector);
						text8 = string.Join("\n", values);
					}
					_003CCombinedSchemaText_003Ek__BackingField = text8;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("count", "Count must be positive and count must refer to a location within the string/array/collection.");
				ex._002Ector("count", "Count must be positive and count must refer to a location within the string/array/collection.");
				throw ex;
			}
			ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("startIndex", "Index was out of range. Must be non-negative and less than the size of the collection.");
			ex2._002Ector("startIndex", "Index was out of range. Must be non-negative and less than the size of the collection.");
			throw ex2;
		}
		ArgumentNullException ex3 = new ArgumentNullException("value");
		ex3._002Ector("value");
		throw ex3;
	}

	private unsafe static bool TryGetArg(string name, out string value)
	{
		//IL_00db: Expected O, but got I
		//IL_00eb: Expected O, but got I
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0146: Expected I4, but got O
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507B80");
			object obj = default(object);
			ref string reference;
			if ((nint)obj != -1)
			{
				object obj2 = obj + 1;
				if (commandLineArgs.Length > (nint)obj2)
				{
					object obj3 = obj + 1;
					if ((nint)obj3 < commandLineArgs.Length)
					{
						reference = ref *(string*)commandLineArgs[obj3];
						return true;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					return (byte)(int)ex != 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v13+B8]");
			object obj5 = 0;
			reference = ref *(string*)obj5;
			return false;
		}
		ArgumentNullException ex2 = new ArgumentNullException("array");
		throw ex2;
	}

	private unsafe void LoadCliOverrides()
	{
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected Ref, but got Unknown
		//IL_03cb: Expected O, but got I
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected Ref, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Ref, but got Unknown
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Expected Ref, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected Ref, but got Unknown
		//IL_0419: Expected O, but got I
		//IL_007c: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_0540: Expected O, but got I
		//IL_039c: Expected O, but got I
		//IL_03ac: Expected O, but got I
		//IL_0654: Expected O, but got I
		//IL_06ee: Expected O, but got I
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected Ref, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_0336: Expected O, but got I
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected Ref, but got Unknown
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected I, but got Unknown
		//IL_01a9: Expected O, but got I
		//IL_022a: Expected O, but got I4
		//IL_01d2: Expected O, but got I
		//IL_025e: Expected O, but got I4
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_0279: Expected I, but got O
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected I, but got Unknown
		//IL_02ac: Expected O, but got I
		//IL_02d5: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189979279]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = default(object);
		ref string value = ref *(string*)(obj + 64);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		string text;
		string text2;
		string text3;
		string text4;
		if (!TryGetArg("--coherence-play-api-endpoint", out value))
		{
			if (TryGetArg("--coherence-play-endpoint", out *(string*)(obj + 64)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
				text = (string)0;
				text2 = "/api/v1";
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
				if ((nint)0 != 0 && text._stringLength > 0)
				{
					if ("/api/v1" != null && text2._stringLength > 0)
					{
						int length = text2._stringLength + text._stringLength;
						text3 = string.FastAllocateString(length);
						if (text._stringLength <= text3._stringLength)
						{
							byte* ptr = (byte*)(nint)(text3 + 20);
							int num = text._stringLength + text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
							byte* ptr2 = (byte*)((nuint)0u + (nuint)20u);
							object obj2 = (object)(ptr - (nuint)ptr2);
							if ((nint)obj2 >= num)
							{
								obj2 = (object)(ptr2 - (nuint)ptr);
								if ((nint)obj2 >= num)
								{
									Buffer.Memcpy(ptr, ptr2, num);
									goto IL_0213;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
							goto IL_0213;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
					text4 = (string)0;
				}
				else if ("/api/v1" != null && text2._stringLength > 0)
				{
					text4 = "/api/v1";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rax_v54+B8]");
					object obj4 = 0;
					text4 = (string)obj4;
				}
				goto IL_05d1;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+40]");
			playApiEndpoint = (string)0;
		}
		goto IL_03d0;
		IL_05d1:
		playApiEndpoint = text4;
		goto IL_03d0;
		IL_03d0:
		if (TryGetArg("--coherence-http-server-port", out *(string*)(obj - 56)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
				object obj6 = (nint)0 + (nint)20;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rbx_v7+10]");
				_ = 0;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				ref int result = ref *(int*)(obj + 56);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-28]");
				_ = 0;
				ReadOnlySpan<char> value2 = (ReadOnlySpan<char>)(obj - 40);
				if (System.Number.TryParseInt32(value2, NumberStyles.Integer, currentInfo, out result))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+38]");
					localHttpServerPort = 0;
				}
			}
		}
		if (TryGetArg("--coherence-multi-room-sim-port", out *(string*)(obj - 56)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
				object obj8 = (nint)0 + (nint)20;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rbx_v5+10]");
				_ = 0;
				NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
				ref int result2 = ref *(int*)(obj + 56);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-28]");
				_ = 0;
				ReadOnlySpan<char> value3 = (ReadOnlySpan<char>)(obj - 40);
				if (System.Number.TryParseInt32(value3, NumberStyles.Integer, currentInfo2, out result2))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+38]");
					localHttpServerPort = 0;
				}
			}
			else
			{
				_ = 0;
			}
		}
		if (TryGetArg("--coherence-multi-room-sim-host", out *(string*)(obj - 48)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-30]");
			localHttpServerHost = (string)0;
		}
		return;
		IL_0213:
		object obj9 = text3._stringLength - text._stringLength;
		if (text2._stringLength <= (nint)obj9)
		{
			object obj10 = text._stringLength + 10;
			object obj11 = obj10 * 2;
			byte* ptr3 = (byte*)(nint)(text3 + obj11);
			int num2 = text2._stringLength + text2._stringLength;
			byte* ptr4 = (byte*)(nint)("/api/v1" + 20);
			object obj12 = (object)(ptr3 - (nuint)ptr4);
			if ((nint)obj12 >= num2)
			{
				obj12 = (object)(ptr4 - (nuint)ptr3);
				if ((nint)obj12 >= num2)
				{
					Buffer.Memcpy(ptr3, ptr4, num2);
					text4 = text3;
					goto IL_05d1;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			text4 = text3;
			goto IL_05d1;
		}
		IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
		throw ex2;
	}

	public void SetApiEndpoint(string endpoint)
	{
		if (endpoint != null && endpoint._stringLength > 0)
		{
			playApiEndpoint = endpoint;
			Init();
		}
		else
		{
			playApiEndpoint = Constants.apiEndpoint;
		}
	}

	public void SetRuntimeKey(string key)
	{
		if (key != null && key._stringLength > 0)
		{
			runtimeKey = key;
			Init();
		}
	}

	public void SetProjectID(string id)
	{
		if (id != null && id._stringLength > 0)
		{
			projectID = id;
			Init();
		}
	}

	public void SetSchemaID(string id)
	{
		if (id != null && id._stringLength > 0)
		{
			schemaID = id;
			Init();
		}
	}

	public void SetApiPort(int port)
	{
		if (port != 0)
		{
			apiPort = port;
			Init();
		}
		else
		{
			apiPort = Constants.apiPort;
		}
	}
}
