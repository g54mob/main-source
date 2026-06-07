using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using DevConsole;
using DynamicCSharp;
using SINetworking;
using Tyd;
using UnityEngine;

public class ModController : MonoBehaviour
{
	public class DLLMod : IWorkshopItem
	{
		public ModMeta Meta;

		public string FileName;

		public string ModPath;

		public bool DLL;

		public Dictionary<string, string> Settings;

		public ModBehaviour[] Behaviors;

		private byte _networkID;

		private string _customTitle;

		public byte NetworkID
		{
			get
			{
				return _networkID;
			}
		}

		public bool Active
		{
			get
			{
				bool result = false;
				string value;
				if (Settings.TryGetValue("Active", out value))
				{
					result = value.ConvertToBoolDef(false);
				}
				return result;
			}
		}

		public void RegisterNetworkID(byte id)
		{
			if (_networkID > 0)
			{
				if (id != _networkID)
				{
					HandleException(base.ItemTitle, new Exception("Can't register mod network id " + id + " for " + base.ItemTitle + " as it is already registered as " + _networkID));
				}
			}
			else
			{
				NetworkMessaging.RegisterMod(id, this);
				_networkID = id;
			}
		}

		public IEnumerable<NetworkPlayer> GetCurrentPlayers()
		{
			foreach (NetworkPlayer player in NetworkManager.Instance.Players)
			{
				yield return player;
			}
		}

		public void ReceiveNetworkMessage(NetworkPlayer player, MemoryStream stream)
		{
			Meta.ReceiveNetworkMessage(player, stream);
		}

		public void SendNetworkMessage(byte[] data, ModBehaviour.MessageTarget target = ModBehaviour.MessageTarget.Everyone, byte targetID = 0)
		{
			if (!Thread.CurrentThread.Equals(_mainThread))
			{
				HandleException(base.ItemTitle, new Exception("Can't send network message for " + base.ItemTitle + " as it is not on the main thread"));
			}
			else if (_networkID > 0)
			{
				NetworkMessaging.SendModMessage(data, this, (NetworkMessaging.MessageTarget)target, targetID);
			}
			else
			{
				HandleException(base.ItemTitle, new Exception("Can't send network message for " + base.ItemTitle + " as it is not registered"));
			}
		}

		public void GenerateHash()
		{
			try
			{
				string path = Path.Combine(ModPath, FileName + "H.bin");
				if (!File.Exists(path))
				{
					byte[] array = null;
					array = (DLL ? UniqeHash(File.ReadAllBytes(Path.Combine(ModPath, FileName + ".dll"))) : ((!File.Exists(Path.Combine(ModPath, FileName + ".dcache"))) ? UniqeHash(GetScriptBytes(ModPath)) : UniqeHash(GetScriptBytes(ModPath)).ConcatArray(UniqeHash(File.ReadAllBytes(Path.Combine(ModPath, FileName + ".dcache"))))));
					File.WriteAllBytes(path, array);
				}
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
			}
		}

		public DLLMod(ModMeta meta, string filename, string path, bool dll, ModBehaviour[] behaviours, float loadTime)
		{
			Meta = meta;
			FileName = filename;
			Behaviors = behaviours;
			ModPath = path;
			DLL = dll;
			InitMod(path, loadTime);
			Settings = new Dictionary<string, string>();
			Settings["Active"] = "False";
			GenerateHash();
			try
			{
				string path2 = Path.Combine(ModFolder, FileName + "Setting.txt");
				if (!File.Exists(path2))
				{
					return;
				}
				foreach (KeyValuePair<string, List<string>> value in ConfigFile.Load(File.ReadAllLines(path2)).Values)
				{
					Settings[value.Key] = value.Value[0];
				}
			}
			catch (Exception)
			{
			}
		}

		public void SaveSetting(string name, string value)
		{
			if (!"Active".Equals(name))
			{
				Settings[name] = value;
				SaveSettings();
			}
		}

		public void DeleteSetting(string name)
		{
			if (!"Active".Equals(name))
			{
				Settings.Remove(name);
				SaveSettings();
			}
		}

		public void Activate(bool active)
		{
			if (active)
			{
				Debug.Log("Activated DLL mod: " + base.ItemTitle);
			}
			else
			{
				if (_networkID > 0)
				{
					NetworkMessaging.UnRegisterMod(_networkID, this);
					_networkID = 0;
				}
				Debug.Log("Deactivated DLL mod: " + base.ItemTitle);
			}
			ModBehaviour[] behaviors = Behaviors;
			foreach (ModBehaviour modBehaviour in behaviors)
			{
				if (active)
				{
					modBehaviour.OnActivate();
				}
				else
				{
					modBehaviour.OnDeactivate();
				}
				modBehaviour.enabled = active;
			}
			Settings["Active"] = active.ToString();
			SaveSettings();
			ErrorLogging.Modded = active || Instance.Mods.Any((DLLMod x) => x.Active);
		}

		private void SaveSettings()
		{
			try
			{
				ConfigFile configFile = ConfigFile.FromDictionary(Settings);
				if (!Directory.Exists(ModFolder))
				{
					Directory.CreateDirectory(ModFolder);
				}
				File.WriteAllText(Path.Combine(ModFolder, FileName + "Setting.txt"), configFile.Serialize());
			}
			catch (Exception)
			{
			}
		}

		public void Serialize(WriteDictionary modData, GameReader.LoadMode mode)
		{
			if (Active)
			{
				WriteDictionary writeDictionary = Meta.Serialize(mode);
				if (writeDictionary != null)
				{
					modData[Meta.Name] = writeDictionary;
				}
			}
		}

		public void Deserialize(WriteDictionary modData, GameReader.LoadMode mode)
		{
			if (Active)
			{
				WriteDictionary writeDictionary = modData.Get<WriteDictionary>(Meta.Name, null);
				if (writeDictionary != null)
				{
					Meta.Deserialize(writeDictionary, mode);
				}
			}
		}

		public override string GetWorkshopType()
		{
			return "Code mod";
		}

		public override string[] GetValidExts()
		{
			return new string[12]
			{
				"cs", "jpg", "jpeg", "png", "txt", "tyd", "ogg", "mp3", "wav", "obj",
				"gltf", "glb"
			};
		}

		public override string[] ExtraTags()
		{
			return Array.Empty<string>();
		}

		public override bool PrepareForUpload(out bool hasShownError)
		{
			if (!base.PrepareForUpload(out hasShownError))
			{
				return false;
			}
			try
			{
				string path = Path.Combine(ModPath, FileName + ".dcache");
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				path = Path.Combine(ModPath, FileName + "H.bin");
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			catch
			{
				return false;
			}
			return true;
		}

		public override string GetActualString()
		{
			return base.ItemTitle;
		}

		public Texture2D LoadTexture(string relativePath)
		{
			string text = Path.Combine(base.Root, relativePath);
			if (text.Replace("\\", "/").Contains("/../"))
			{
				return null;
			}
			Texture2D texture2D = new Texture2D(4, 4);
			texture2D.LoadImage(File.ReadAllBytes(text));
			return texture2D;
		}

		public TydDocument LoadTydFile(string relativePath)
		{
			string text = Path.Combine(base.Root, relativePath);
			if (!text.Replace("\\", "/").Contains("/../"))
			{
				return TydFile.FromFile(text).DocumentNode;
			}
			return null;
		}

		public XMLParser.XMLNode LoadXMLFile(string relativePath)
		{
			string text = Path.Combine(base.Root, relativePath);
			if (!text.Replace("\\", "/").Contains("/../"))
			{
				return XMLParser.ParseXML(File.ReadAllText(text));
			}
			return null;
		}

		public List<XMLParser.XMLNode> LoadFullXMLFile(string relativePath)
		{
			string text = Path.Combine(base.Root, relativePath);
			if (!text.Replace("\\", "/").Contains("/../"))
			{
				return XMLParser.ParseXMLFull(File.ReadAllText(text));
			}
			return null;
		}

		public AudioClip LoadAudio(string relativePath)
		{
			string text = Path.Combine(base.Root, relativePath);
			if (text.Replace("\\", "/").Contains("/../"))
			{
				return null;
			}
			return new WWW("file://" + text).GetAudioClip();
		}

		public Mesh LoadGLTF(string relativePath)
		{
			string text = Path.Combine(base.Root, relativePath);
			if (text.Replace("\\", "/").Contains("/../"))
			{
				return null;
			}
			if (text.ToLower().EndsWith(".gltf"))
			{
				return SimpleGLTF.Parse(File.ReadAllText(text), Path.GetFileName(text));
			}
			if (text.ToLower().EndsWith(".glb"))
			{
				return SimpleGLTF.Parse(File.ReadAllBytes(text), Path.GetFileName(text));
			}
			return null;
		}

		public List<Mesh> LoadOBJ(string relativePath)
		{
			string text = Path.Combine(base.Root, relativePath);
			if (text.Replace("\\", "/").Contains("/../"))
			{
				return null;
			}
			return ObjImporter.ImportMeshes(File.ReadAllText(text));
		}

		public override void Enable(bool toggle)
		{
			Activate(toggle);
		}

		public override bool IsEnabled()
		{
			return Active;
		}
	}

	public enum VerificationType
	{
		New = 0,
		Changed = 1,
		AllAccess = 2
	}

	public struct DLLVerify
	{
		public string Path;

		public string Name;

		public bool DLL;

		public VerificationType VType;

		public DLLVerify(string path, string name, bool dLL, VerificationType vtype)
		{
			string dir = path;
			if (dLL)
			{
				dir = System.IO.Path.GetDirectoryName(path);
			}
			Path = path;
			Name = GetMetaName(dir) ?? name;
			DLL = dLL;
			VType = vtype;
		}
	}

	internal sealed class VersionConfigToNamespaceAssemblyObjectBinder : SerializationBinder
	{
		public override Type BindToType(string assemblyName, string typeName)
		{
			Type result = null;
			try
			{
				string text = assemblyName.Split(',')[0];
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					if (assembly.FullName.Split(',')[0] == text)
					{
						result = assembly.GetType(typeName);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
	}

	public const string DLLModBuildVersion = "24";

	public FileReaderWindow ReaderWindowPrefab;

	private static bool _initialized = false;

	public static ModController Instance;

	[NonSerialized]
	public List<DLLMod> Mods = new List<DLLMod>();

	[NonSerialized]
	private List<DLLVerify> _needsVerification = new List<DLLVerify>();

	[NonSerialized]
	private List<DLLVerify> _eulaPrevent = new List<DLLVerify>();

	private static uint _dllCounter = 0u;

	[NonSerialized]
	private ScriptDomain _modDomain;

	public static string ModEula = "The game has detected dll-based mods. You must agree to the following before any mods will be loaded:\r\n\r\nThe following agreement governs all download, installation or use of any assembly file (hereinafter \"mods\") that modifies the runtime behaviour of Software Inc. If you do not agree to this agreement, you may not install or use mods.\r\n\r\nYou acknowledge that downloading, installing or using mods may damage your computer and any data stored on it. Your installation or use of mods is at your own discretion and risk, you are solely responsible and Coredumping ApS is not liable for any loss of data or damage to your computer.";

	private static Thread _mainThread;

	private bool _pendingVerification;

	private static HashSet<DLLMod> _unload = new HashSet<DLLMod>();

	private static HashSet<string> _deactivating = new HashSet<string>();

	public static string ModFolder
	{
		get
		{
			return Path.Combine(Utilities.GetRoot(), "DLLMods");
		}
	}

	public static Thread MainThread
	{
		get
		{
			return _mainThread;
		}
	}

	public static string GetMetaName(string dir)
	{
		dir = Path.Combine(dir, "meta.tyd");
		if (File.Exists(dir))
		{
			try
			{
				TydDocument documentNode = TydFile.FromContent(Utilities.ReadOnlyReadAllText(dir), dir).DocumentNode;
				return (documentNode != null) ? documentNode.GetChildValue("Name", false) : null;
			}
			catch (Exception)
			{
			}
		}
		return null;
	}

	public static bool HasMods()
	{
		if (Directory.Exists(ModFolder))
		{
			if (Directory.GetFiles(ModFolder, "*.dll").Length == 0)
			{
				return Directory.GetDirectories(ModFolder).Length != 0;
			}
			return true;
		}
		return false;
	}

	private IWorkshopItem FinalizeAssembly(string fileName, Assembly assembly, string modPath, bool dll, float loadTime)
	{
		try
		{
			ModMeta modMeta = null;
			List<Type> list = new List<Type>();
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (modMeta == null && type.IsSubclassOf(typeof(ModMeta)))
				{
					ConstructorInfo constructor = type.GetConstructor(new Type[0]);
					if (constructor != null)
					{
						modMeta = (ModMeta)constructor.Invoke(null);
					}
				}
				else if (type.IsSubclassOf(typeof(ModBehaviour)))
				{
					list.Add(type);
				}
			}
			if (modMeta != null)
			{
				if (list.Count > 0)
				{
					GameObject gameObject = new GameObject(fileName);
					gameObject.SetActive(false);
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
					List<ModBehaviour> list2 = new List<ModBehaviour>();
					for (int j = 0; j < list.Count; j++)
					{
						Type componentType = list[j];
						ModBehaviour modBehaviour = gameObject.AddComponent(componentType) as ModBehaviour;
						modBehaviour.enabled = false;
						list2.Add(modBehaviour);
						modMeta.ModBehaviours.Add(modBehaviour);
					}
					DLLMod dLLMod = new DLLMod(modMeta, fileName, modPath, dll, list2.ToArray(), loadTime);
					for (int k = 0; k < list2.Count; k++)
					{
						list2[k].ParentMod = dLLMod;
					}
					gameObject.SetActive(true);
					modMeta.Initialize(dLLMod);
					if (dLLMod.Active)
					{
						dLLMod.Activate(true);
					}
					Mods.Add(dLLMod);
					return dLLMod;
				}
				throw new Exception("Error loading dll mod " + fileName + ": didn't have any behaviours and was not loaded");
			}
			throw new Exception("Error loading dll mod " + fileName + ": didn't have any meta and was not loaded");
		}
		catch (ReflectionTypeLoadException ex)
		{
			return HandleException(ex, fileName, modPath);
		}
		catch (Exception ex2)
		{
			return HandleException(ex2, fileName, modPath);
		}
	}

	private IWorkshopItem HandleException(Exception ex, string name, string path)
	{
		string text = ex.ToString();
		if (ex is SecurityException)
		{
			text = ex.Message;
		}
		else if (ex is ReflectionTypeLoadException)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Exception[] loaderExceptions = ((ReflectionTypeLoadException)ex).LoaderExceptions;
			foreach (Exception ex2 in loaderExceptions)
			{
				stringBuilder.AppendLine(ex2.ToString());
			}
			text = stringBuilder.ToString().TrimEnd();
		}
		LoadDebugger.AddError("Failed loading dll mod: " + name);
		text = "Error loading dll mod " + name + " with load errors:\n" + text;
		DevConsole.Console.LogError(text);
		Debug.Log(text);
		return new FailMod("Code mod", path, ex.ToString());
	}

	public void UnloadMod(string name, bool filename, bool terminal)
	{
		for (int i = 0; i < Mods.Count; i++)
		{
			DLLMod dLLMod = Mods[i];
			if ((filename && dLLMod.FileName.Equals(name)) || (!filename && dLLMod.ItemTitle.Equals(name)))
			{
				UnloadMod(dLLMod, terminal);
				break;
			}
		}
	}

	public void UnloadMod(DLLMod mod, bool terminal)
	{
		if (OptionsWindow.Instance != null)
		{
			GameObject[] orNull = OptionsWindow.Instance.ModOptions.GetOrNull(mod);
			if (orNull != null)
			{
				for (int i = 0; i < orNull.Length; i++)
				{
					UnityEngine.Object.Destroy(orNull[i]);
				}
			}
		}
		ModBehaviour[] behaviors = mod.Behaviors;
		foreach (ModBehaviour modBehaviour in behaviors)
		{
			if (mod.Active)
			{
				try
				{
					modBehaviour.OnDeactivate();
				}
				catch (Exception ex)
				{
					Debug.Log(ex.ToString());
				}
			}
			UnityEngine.Object.Destroy(modBehaviour);
		}
		Mods.Remove(mod);
		ModWindow.RemoveMod(mod);
		if (terminal)
		{
			DevConsole.Console.Log("Successfully unloaded mod");
		}
	}

	public void UnloadAllMods()
	{
		if (OptionsWindow.Instance != null)
		{
			List<GameObject[]> list = OptionsWindow.Instance.ModOptions.Values.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				GameObject[] array = list[i];
				for (int j = 0; j < array.Length; j++)
				{
					UnityEngine.Object.Destroy(array[j]);
				}
			}
		}
		while (Mods.Count > 0)
		{
			DLLMod dLLMod = Mods[0];
			ModBehaviour[] behaviors = dLLMod.Behaviors;
			foreach (ModBehaviour modBehaviour in behaviors)
			{
				if (dLLMod.Active)
				{
					try
					{
						modBehaviour.OnDeactivate();
					}
					catch (Exception ex)
					{
						Debug.Log(ex.ToString());
					}
				}
				UnityEngine.Object.Destroy(modBehaviour);
			}
			ModWindow.RemoveMod(dLLMod);
			Mods.RemoveAt(0);
		}
	}

	public void ReloadMod(string name, bool terminal, bool recompile)
	{
		if (!PlayerPrefs.HasKey("MODEULA"))
		{
			DialogWindow dialog = WindowManager.SpawnDialog();
			dialog.Show(ModEula, false, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("I Agree", delegate
			{
				PlayerPrefs.SetInt("MODEULA", 1);
				PlayerPrefs.Save();
				ActuallyLoadMod(name, terminal, recompile);
				dialog.Window.Close();
			}), new KeyValuePair<string, Action>("Decline", delegate
			{
				dialog.Window.Close();
			}));
		}
		else
		{
			ActuallyLoadMod(name, terminal, recompile);
		}
	}

	private void ActuallyLoadMod(string name, bool terminal, bool recompile)
	{
		if (string.IsNullOrEmpty(name.Trim()))
		{
			DevConsole.Console.LogError("Please enter a mod name");
			return;
		}
		DLLMod dLLMod = Mods.FirstOrDefault((DLLMod x) => name.Equals(x.ItemTitle));
		if (dLLMod != null)
		{
			UnloadMod(dLLMod, terminal);
			ActuallyLoadMod(dLLMod, terminal, recompile);
			return;
		}
		bool initialized = OptionsWindow.Instance.Initialized;
		UnloadMod(name, true, terminal);
		string text = Path.Combine(ModFolder, name);
		bool flag = false;
		DLLMod dLLMod2 = null;
		if (Directory.Exists(text))
		{
			if (recompile)
			{
				try
				{
					string path = Path.Combine(text, Path.GetFileName(text) + "H.bin");
					if (File.Exists(path))
					{
						File.Delete(path);
					}
					string[] files = Directory.GetFiles(text, "*.dcache");
					for (int num = 0; num < files.Length; num++)
					{
						File.Delete(files[num]);
					}
				}
				catch (Exception)
				{
				}
			}
			string[] files2 = Directory.GetFiles(text, "*.dll");
			dLLMod2 = ((files2.Length == 0) ? (LoadMod(text, false, true, recompile) as DLLMod) : (LoadMod(files2[0], true, true, recompile) as DLLMod));
			flag = true;
		}
		if (dLLMod2 != null)
		{
			DevConsole.Console.Log("Successfully loaded mod");
			if (initialized)
			{
				OptionsWindow.Instance.AddModOption(dLLMod2);
			}
		}
		if (!flag)
		{
			DevConsole.Console.LogError("Mod not found");
		}
	}

	private void ActuallyLoadMod(DLLMod oldMod, bool terminal, bool recompile)
	{
		DLLMod dLLMod = null;
		bool flag = false;
		if (recompile)
		{
			try
			{
				string path = Path.Combine(oldMod.ModPath, Path.GetFileName(oldMod.FileName) + "H.bin");
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				string[] files = Directory.GetFiles(oldMod.ModPath, "*.dcache");
				for (int i = 0; i < files.Length; i++)
				{
					File.Delete(files[i]);
				}
			}
			catch (Exception)
			{
			}
		}
		if (oldMod.DLL)
		{
			string[] files2 = Directory.GetFiles(oldMod.ModPath, "*.dll");
			if (files2.Length != 0)
			{
				dLLMod = LoadMod(files2[0], true, true, recompile) as DLLMod;
			}
		}
		else if (!oldMod.DLL && Directory.Exists(oldMod.ModPath))
		{
			dLLMod = LoadMod(oldMod.ModPath, false, true, recompile) as DLLMod;
			flag = true;
		}
		if (dLLMod != null)
		{
			if (terminal)
			{
				DevConsole.Console.Log("Successfully loaded mod");
			}
			if (OptionsWindow.Instance.Initialized)
			{
				OptionsWindow.Instance.AddModOption(dLLMod);
			}
		}
		if (!flag && terminal)
		{
			DevConsole.Console.LogError("Mod not found");
		}
	}

	private static byte[] GetScriptBytes(string modPath)
	{
		List<byte[]> list = new List<byte[]>();
		string[] files = Directory.GetFiles(modPath, "*.cs", SearchOption.AllDirectories);
		foreach (string path in files)
		{
			list.Add(File.ReadAllBytes(path));
		}
		byte[] array = new byte[list.SumSafe((byte[] x) => x.Length)];
		int num = 0;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			byte[] array2 = list[num2];
			for (int num3 = 0; num3 < array2.Length; num3++)
			{
				array[num] = array2[num3];
				num++;
			}
		}
		return array;
	}

	private static byte[] UniqeHash(byte[] input)
	{
		byte[] buffer = input.ConcatArray(Encoding.UTF8.GetBytes(SystemInfo.deviceUniqueIdentifier + "24"));
		return MD5.Create().ComputeHash(buffer);
	}

	private static int VerifyMod(string path, string hashFile, bool scripts, bool cached = false)
	{
		if (!File.Exists(hashFile))
		{
			return 0;
		}
		byte[] array = File.ReadAllBytes(hashFile);
		if (scripts)
		{
			byte[] second = UniqeHash(GetScriptBytes(path));
			if (array.Take(16).SequenceEqual(second))
			{
				return 1;
			}
			Debug.Log("Failed verifying script mod: " + Path.GetFileName(path));
			File.Delete(hashFile);
			return -1;
		}
		byte[] second2 = UniqeHash(File.ReadAllBytes(path));
		if (cached)
		{
			if (array.Length < 32)
			{
				Debug.Log("Hash too short to verify cached mod: " + Path.GetFileName(path));
				File.Delete(hashFile);
				return -1;
			}
			if (array.Skip(16).SequenceEqual(second2))
			{
				return 1;
			}
			Debug.Log("Failed verifying cached mod: " + Path.GetFileName(path));
			File.Delete(hashFile);
			return -1;
		}
		if (array.SequenceEqual(second2))
		{
			return 1;
		}
		Debug.Log("Failed verifying DLL mod: " + Path.GetFileName(path));
		File.Delete(hashFile);
		return -1;
	}

	public IWorkshopItem LoadMod(string path, bool dll, bool force, bool uniqueName, string overrideName = null)
	{
		if (!PlayerPrefs.HasKey("MODEULA"))
		{
			string text = (dll ? Path.GetFileNameWithoutExtension(path) : Path.GetFileName(path));
			_eulaPrevent.Add(new DLLVerify(path, overrideName ?? text, dll, VerificationType.New));
			return null;
		}
		if (dll)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			int num = VerifyMod(path, Path.Combine(Path.GetDirectoryName(path), fileNameWithoutExtension + "H.bin"), false);
			if (!force && num < 1)
			{
				try
				{
					_modDomain.SecurityCheckAssembly(path, ScriptDomain.HackLevel.WARN, true);
				}
				catch (WarningException)
				{
					_needsVerification.Add(new DLLVerify(path, overrideName ?? fileNameWithoutExtension, true, VerificationType.AllAccess));
					return null;
				}
				catch (Exception)
				{
				}
			}
			if (!force && num < 1)
			{
				_needsVerification.Add(new DLLVerify(path, overrideName ?? fileNameWithoutExtension, true, (num != 0) ? VerificationType.Changed : VerificationType.New));
				return null;
			}
			try
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				ScriptAssembly scriptAssembly = _modDomain.LoadAssembly(path, force || num == 1);
				return FinalizeAssembly(fileNameWithoutExtension, scriptAssembly.RawAssembly, Path.GetDirectoryName(path), true, Time.realtimeSinceStartup - realtimeSinceStartup);
			}
			catch (WarningException)
			{
				_needsVerification.Add(new DLLVerify(path, overrideName ?? fileNameWithoutExtension, true, VerificationType.AllAccess));
			}
			catch (Exception ex4)
			{
				return HandleException(ex4, fileNameWithoutExtension, path);
			}
		}
		else
		{
			string fileName = Path.GetFileName(path);
			string path2 = Path.Combine(path, fileName + ".dcache");
			if (File.Exists(path2) && VerifyMod(path, Path.Combine(path, fileName + "H.bin"), true) < 1)
			{
				File.Delete(path2);
				if (!force)
				{
					_needsVerification.Add(new DLLVerify(path, overrideName ?? fileName, false, VerificationType.Changed));
					return null;
				}
			}
			if (File.Exists(path2))
			{
				if (!force)
				{
					int num2 = VerifyMod(path2, Path.Combine(path, fileName + "H.bin"), false, true);
					if (num2 < 1)
					{
						_needsVerification.Add(new DLLVerify(path, overrideName ?? fileName, false, (num2 != 0) ? VerificationType.Changed : VerificationType.New));
						return null;
					}
				}
				try
				{
					float realtimeSinceStartup2 = Time.realtimeSinceStartup;
					byte[] data = File.ReadAllBytes(path2);
					Assembly rawAssembly = _modDomain.LoadAssembly(data, null, ScriptDomain.HackLevel.DENY).RawAssembly;
					return FinalizeAssembly(fileName, rawAssembly, path, false, Time.realtimeSinceStartup - realtimeSinceStartup2);
				}
				catch (Exception ex5)
				{
					return HandleException(ex5, fileName, path);
				}
			}
			string[] files = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories);
			if (files.Length != 0)
			{
				if (!force)
				{
					int num3 = VerifyMod(path, Path.Combine(path, fileName + "H.bin"), true);
					if (num3 < 1)
					{
						_needsVerification.Add(new DLLVerify(path, overrideName ?? fileName, false, (num3 != 0) ? VerificationType.Changed : VerificationType.New));
						return null;
					}
				}
				try
				{
					float realtimeSinceStartup3 = Time.realtimeSinceStartup;
					string n = Path.GetFileName(path).ToLower();
					string text2 = fileName;
					if (uniqueName)
					{
						text2 += _dllCounter;
						_dllCounter++;
					}
					try
					{
						ScriptAssembly scriptAssembly2 = _modDomain.CompileAndLoadScriptSources(text2, files.SelectInPlace(Path.GetFileName), files.SelectInPlace((string x) => InjectTryBlocks(File.ReadAllText(x), n)), ScriptDomain.HackLevel.DENY);
						if (scriptAssembly2 != null)
						{
							File.WriteAllBytes(path2, _modDomain.CompilerService.AssemblyData);
							return FinalizeAssembly(fileName, scriptAssembly2.RawAssembly, path, false, Time.realtimeSinceStartup - realtimeSinceStartup3);
						}
						if (_modDomain.CompilerService.HasErrors)
						{
							return HandleException(new Exception(_modDomain.CompilerService.Errors[0]), fileName, path);
						}
					}
					catch (Exception ex6)
					{
						return HandleException(ex6, fileName, path);
					}
				}
				catch (Exception ex7)
				{
					return HandleException(ex7, fileName, path);
				}
			}
		}
		return null;
	}

	private void LoadMods()
	{
		string[] directories = Directory.GetDirectories(ModFolder);
		foreach (string path in directories)
		{
			string[] files = Directory.GetFiles(path, "*.dll");
			if (files.Length != 0)
			{
				LoadMod(files[0], true, false, false);
			}
			else
			{
				LoadMod(path, false, false, false);
			}
		}
		LoadDebugger.AddInfo("Finished loading DLL mods");
	}

	private void QueryNextVerification(bool any)
	{
		if (!PlayerPrefs.HasKey("MODEULA"))
		{
			DialogWindow dialog = WindowManager.SpawnDialog();
			dialog.Show(ModEula, false, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("I Agree", delegate
			{
				PlayerPrefs.SetInt("MODEULA", 1);
				PlayerPrefs.Save();
				_pendingVerification = false;
				dialog.Window.Close();
			}), new KeyValuePair<string, Action>("Decline", delegate
			{
				_eulaPrevent.Clear();
				_needsVerification.Clear();
				_pendingVerification = false;
				dialog.Window.Close();
			}));
			return;
		}
		if (_eulaPrevent.Count > 0)
		{
			for (int num = 0; num < _eulaPrevent.Count; num++)
			{
				LoadMod(_eulaPrevent[num].Path, _eulaPrevent[num].DLL, false, false, _eulaPrevent[num].Name);
			}
			_eulaPrevent.Clear();
		}
		if (_needsVerification.Count > 0)
		{
			DLLVerify verify = _needsVerification[0];
			_needsVerification.RemoveAt(0);
			DialogWindow msg = WindowManager.SpawnDialog();
			List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("Yes", delegate
				{
					LoadMod(verify.Path, verify.DLL, true, false);
					QueryNextVerification(true);
					msg.Window.Close();
				}),
				new KeyValuePair<string, Action>("No", delegate
				{
					QueryNextVerification(any);
					msg.Window.Close();
				})
			};
			if (!verify.DLL)
			{
				list.Insert(1, new KeyValuePair<string, Action>("ReadDLLCodeSource", delegate
				{
					FileReaderWindow fileReaderWindow = UnityEngine.Object.Instantiate(ReaderWindowPrefab);
					fileReaderWindow.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
					fileReaderWindow.Show(Directory.GetFiles(verify.Path, "*.cs", SearchOption.AllDirectories));
				}));
			}
			string input = "";
			DialogWindow.DialogType type = DialogWindow.DialogType.Warning;
			switch (verify.VType)
			{
			case VerificationType.New:
				input = "NewDLLModVerify";
				break;
			case VerificationType.Changed:
				input = "ChangedDLLModVerify";
				break;
			case VerificationType.AllAccess:
				input = "AllAccessDLLModVerify";
				type = DialogWindow.DialogType.Error;
				break;
			}
			msg.Show(input.Loc(verify.Name), false, type, list.ToArray());
		}
		else
		{
			_pendingVerification = false;
			if (any && SteamManager.Initialized)
			{
				SteamWorkshop.RecheckItems(Mods.OfType<IWorkshopItem>());
			}
		}
	}

	public static void Initialize(bool canAskEULA)
	{
		if (_initialized || Instance == null)
		{
			return;
		}
		bool flag = HasMods();
		bool flag2 = PlayerPrefs.HasKey("MODEULA");
		if (!canAskEULA && !flag2)
		{
			return;
		}
		if (!_initialized)
		{
			_initialized = true;
		}
		if (!flag)
		{
			return;
		}
		if (!flag2)
		{
			Instance._pendingVerification = true;
			DialogWindow dialog = WindowManager.SpawnDialog();
			dialog.Show(ModEula, false, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("I Agree", delegate
			{
				Instance._pendingVerification = false;
				PlayerPrefs.SetInt("MODEULA", 1);
				PlayerPrefs.Save();
				Instance.LoadMods();
				dialog.Window.Close();
			}), new KeyValuePair<string, Action>("Decline", delegate
			{
				Instance._eulaPrevent.Clear();
				Instance._needsVerification.Clear();
				Instance._pendingVerification = false;
				dialog.Window.Close();
			}));
		}
		else
		{
			Instance.LoadMods();
		}
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		_modDomain = ScriptDomain.CreateDomain("ModDomain", true);
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		_mainThread = Thread.CurrentThread;
		Application.quitting += delegate
		{
			GameSettings.IsQuitting = true;
		};
	}

	private void Update()
	{
		if ((_needsVerification.Count > 0 || _eulaPrevent.Count > 0) && !_pendingVerification && WindowManager.Instance != null)
		{
			_pendingVerification = true;
			QueryNextVerification(false);
		}
		ModErrorWindow.UpdateMe();
		foreach (DLLMod item in _unload)
		{
			UnloadAndDeactivateMod(item);
		}
		_unload.Clear();
	}

	private static void UnloadAndDeactivateMod(DLLMod m)
	{
		if (_deactivating.Add(m.ItemTitle))
		{
			try
			{
				m.Activate(false);
			}
			catch (Exception)
			{
			}
			try
			{
				Instance.UnloadMod(m, false);
			}
			catch (Exception)
			{
			}
			_deactivating.Remove(m.ItemTitle);
		}
	}

	public static void HandleException(string mod, Exception e)
	{
		if (!(Instance != null))
		{
			return;
		}
		DLLMod dLLMod = ((mod != null) ? Instance.GetMod(mod) : null);
		ModErrorWindow.Show(dLLMod, e);
		if (dLLMod != null)
		{
			if (Thread.CurrentThread.Equals(_mainThread))
			{
				UnloadAndDeactivateMod(dLLMod);
			}
			else
			{
				_unload.Add(dLLMod);
			}
		}
	}

	private DLLMod GetMod(string path)
	{
		for (int i = 0; i < Mods.Count; i++)
		{
			DLLMod dLLMod = Mods[i];
			if (dLLMod.ModPath.ToLower().EndsWith(path))
			{
				return dLLMod;
			}
		}
		return null;
	}

	public static string InjectTryBlocks(string input, string modName)
	{
		input = "#define SWINC" + Versioning.AlmostExtremelySimpleVersionString.ToUpper() + "\n#define SWINC" + Versioning.ExtremelySimpleVersionString.ToUpper() + "\n#define SWINC" + Versioning.TypeVersionString.ToUpper() + "\n" + input;
		if (!Options.InjectMods)
		{
			return input;
		}
		input = StripComments(input);
		StringBuilder stringBuilder = new StringBuilder();
		int i = 0;
		int j = 0;
		while (i < input.Length)
		{
			if (FindNextClassOrStruct(input, ref i) && SkipTo(input, ref i, '{'))
			{
				HandleObjectParsing(input, ref i, ref j, stringBuilder, modName);
			}
		}
		stringBuilder.Append(input.Substring(j, i - j));
		return stringBuilder.ToString();
	}

	private static string StripComments(string input)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		for (int i = 0; i < input.Length; i++)
		{
			char c = input[i];
			if (flag)
			{
				if (c == '*' && i + 1 < input.Length && input[i + 1] == '/')
				{
					flag = false;
					i++;
				}
				continue;
			}
			if (flag2)
			{
				if (c == '\n')
				{
					flag2 = false;
					i--;
				}
				continue;
			}
			if ((c == '"' || c == '\'') && i > 1 && input[i - 1] != '\\')
			{
				flag3 = !flag3;
			}
			else if (!flag3 && c == '/' && i + 1 < input.Length)
			{
				switch (input[i + 1])
				{
				case '/':
					flag2 = true;
					i++;
					break;
				case '*':
					flag = true;
					break;
				}
			}
			if (!flag2 && !flag)
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static void HandleObjectParsing(string input, ref int i, ref int j, StringBuilder sb, string modName)
	{
		int num = 0;
		bool flag = false;
		while (i < input.Length && num >= 0)
		{
			if (flag)
			{
				if (input[i] == '"')
				{
					flag = false;
				}
			}
			else if (input[i] == '"')
			{
				flag = true;
			}
			else if (input[i] == '{')
			{
				num++;
			}
			else if (input[i] == '}')
			{
				num--;
			}
			else if (num == 0 && input[i] == '(')
			{
				switch (SkipToAvoid(input, ref i, '{', "=>"))
				{
				case 1:
					sb.Append(input.Substring(j, i - j));
					j = i;
					if (input[i] == '}')
					{
						sb.Append(input[i]);
						i++;
						j = i;
					}
					else if (!MatchBrace(input, ref i, ref j, sb, modName, HasYield(input, i)))
					{
						return;
					}
					break;
				case 2:
					if (!SkipTo(input, ref i, ';'))
					{
						return;
					}
					break;
				default:
					return;
				}
			}
			i++;
		}
	}

	private static bool HasYield(string input, int i)
	{
		bool flag = false;
		int num = 0;
		for (int j = i; j < input.Length; j++)
		{
			if (flag)
			{
				if (input[j] == '"')
				{
					flag = false;
				}
				continue;
			}
			if (input[j] == '"')
			{
				flag = true;
				continue;
			}
			if (CheckForName(input, j, "yield", true))
			{
				return true;
			}
			if (input[j] == '{')
			{
				num++;
			}
			else if (input[j] == '}')
			{
				num--;
				if (num < 0)
				{
					return false;
				}
			}
		}
		return false;
	}

	private static bool MatchBrace(string input, ref int i, ref int j, StringBuilder sb, string modName, bool hasYield)
	{
		bool flag = false;
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		bool flag2 = true;
		for (; i < input.Length; i++)
		{
			if (flag)
			{
				if (input[i] == '"')
				{
					flag = false;
				}
				continue;
			}
			if (input[i] == '\n')
			{
				stringBuilder.Clear();
				flag2 = true;
			}
			else if (flag2)
			{
				if (char.IsWhiteSpace(input[i]))
				{
					stringBuilder.Append(input[i]);
				}
				else
				{
					flag2 = false;
				}
			}
			if (hasYield)
			{
				if (CheckForName(input, i, "yield", true))
				{
					i--;
					string value = input.Substring(j, i - j);
					if (!string.IsNullOrWhiteSpace(value))
					{
						string text = stringBuilder.ToString();
						sb.Append("\n" + text + "try {\n");
						sb.Append(value);
						AppendCatch(sb, modName, text);
					}
					else
					{
						sb.Append(value);
					}
					j = i;
					if (!SkipTo(input, ref i, ';'))
					{
						return false;
					}
					sb.Append(input.Substring(j, i - j));
					j = i;
				}
				else if (CheckForName(input, i, "while", true) || CheckForName(input, i, "if", true) || CheckForName(input, i, "for", true) || CheckForName(input, i, "foreach", true) || CheckForName(input, i, "do", true) || CheckForName(input, i, "else", true))
				{
					i--;
					string value2 = input.Substring(j, i - j);
					sb.Append(value2);
					j = i;
					if (SkipTo(input, ref i, '{'))
					{
						sb.Append(input.Substring(j, i - j));
						j = i;
						if (MatchBrace(input, ref i, ref j, sb, modName, true))
						{
							if (SkipTo(input, ref i, '}'))
							{
								sb.Append(input.Substring(j, i - j));
								j = i;
								continue;
							}
							return false;
						}
						return false;
					}
					return false;
				}
			}
			if (input[i] == '"')
			{
				flag = true;
			}
			else if (input[i] == '{')
			{
				num++;
			}
			else
			{
				if (input[i] != '}')
				{
					continue;
				}
				num--;
				if (num < 0)
				{
					i--;
					string value3 = input.Substring(j, i - j);
					if (!string.IsNullOrWhiteSpace(value3))
					{
						string lead = stringBuilder.ToString();
						sb.Append(string.Concat("\n", stringBuilder, "try {\n"));
						sb.Append(value3);
						AppendCatch(sb, modName, lead);
					}
					else
					{
						sb.Append(value3);
					}
					i++;
					j = i;
					return true;
				}
			}
		}
		return false;
	}

	private static void AppendCatch(StringBuilder sb, string modName, string lead)
	{
		sb.Append("\n" + lead + "\t}\n" + lead + "catch(ModException) {throw;}\n" + lead + "catch(System.Exception ex)\n" + lead + "\t{\n" + lead + "\tModController.HandleException(\"" + modName + "\", ex);\n" + lead + "\tthrow new ModException();\n" + lead + "\t}\n" + lead);
	}

	private static bool FindNextClassOrStruct(string input, ref int i)
	{
		bool flag = false;
		while (i < input.Length)
		{
			if (flag)
			{
				if (input[i] == '"')
				{
					flag = false;
				}
			}
			else
			{
				if (input[i] == '"')
				{
					flag = true;
				}
				else if (CheckForName(input, i, "class", true))
				{
					i += 5;
					return true;
				}
				if (CheckForName(input, i, "struct", true))
				{
					i += 6;
					return true;
				}
			}
			i++;
		}
		return false;
	}

	private static bool SkipTo(string input, ref int i, char c)
	{
		bool flag = false;
		while (i < input.Length)
		{
			if (flag)
			{
				if (input[i] == '"')
				{
					flag = false;
				}
			}
			else if (input[i] == '"')
			{
				flag = true;
			}
			else if (input[i] == c)
			{
				i++;
				return true;
			}
			i++;
		}
		return false;
	}

	private static int SkipToAvoid(string input, ref int i, char c, string avoid)
	{
		bool flag = false;
		while (i < input.Length)
		{
			if (flag)
			{
				if (input[i] == '"')
				{
					flag = false;
				}
			}
			else if (input[i] == '"')
			{
				flag = true;
			}
			else
			{
				if (input[i] == c)
				{
					i++;
					return 1;
				}
				if (CheckForName(input, i, avoid))
				{
					return 2;
				}
			}
			i++;
		}
		return 0;
	}

	private static bool CheckForName(string input, int i, string name, bool withEnd = false)
	{
		if (withEnd && i - 1 >= 0 && !char.IsWhiteSpace(input[i - 1]))
		{
			return false;
		}
		for (int j = 0; j < name.Length; j++)
		{
			int num = i + j;
			if (num < input.Length)
			{
				if (input[num] != name[j])
				{
					return false;
				}
				continue;
			}
			return false;
		}
		if (withEnd && i + name.Length < input.Length)
		{
			char c = input[i + name.Length];
			if (!char.IsWhiteSpace(c) && c != '(')
			{
				return false;
			}
		}
		return true;
	}
}
