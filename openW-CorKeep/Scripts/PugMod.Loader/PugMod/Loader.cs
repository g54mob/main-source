using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using RoslynCSharp;
using RoslynCSharp.Compiler;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace PugMod
{
	public class Loader : IIntegration
	{
		public struct Mod
		{
			public long ModId;

			public string Directory;

			public ModMetadata Metadata;

			public List<IMod> LoadedMods;

			public List<ScriptAssembly> LoadedAssemblies;

			public List<AssetBundle> LoadedBundles;

			public List<UnityEngine.Object> LoadedAssets;
		}

		public class DependencySorter
		{
			private enum State
			{
				Unvisited = 0,
				Visiting = 1,
				Visited = 2
			}

			private class Node
			{
				public Mod Mod;

				public State State;

				public List<Node> Dependencies = new List<Node>();
			}

			public List<Mod> SortMods(IList<Mod> mods)
			{
				Dictionary<string, Node> dictionary = new Dictionary<string, Node>();
				foreach (Mod mod2 in mods)
				{
					dictionary[mod2.Metadata.name] = new Node
					{
						Mod = mod2
					};
				}
				for (int num = mods.Count - 1; num >= 0; num--)
				{
					bool flag = false;
					Mod mod = mods[num];
					foreach (ModMetadata.Dependency dependency in mod.Metadata.dependencies)
					{
						if (!dictionary.ContainsKey(dependency.modName) && dependency.required)
						{
							Debug.LogWarning("skipping mod " + mod.Metadata.name + " because of missing dependency: " + dependency.modName);
							flag = true;
						}
					}
					if (flag)
					{
						dictionary.Remove(mod.Metadata.name);
						mods.RemoveAt(num);
						break;
					}
				}
				foreach (Mod mod3 in mods)
				{
					Node node = dictionary[mod3.Metadata.name];
					foreach (ModMetadata.Dependency dependency2 in mod3.Metadata.dependencies)
					{
						if (dictionary.TryGetValue(dependency2.modName, out var value))
						{
							node.Dependencies.Add(value);
						}
					}
				}
				List<Mod> list = new List<Mod>();
				foreach (Node value2 in dictionary.Values)
				{
					Visit(value2, list);
				}
				return list;
			}

			private void Visit(Node node, List<Mod> sortedMods)
			{
				if (node.State == State.Visited)
				{
					return;
				}
				if (node.State == State.Visiting)
				{
					Debug.LogError(node.Mod.Metadata.name + " has circular dependency");
					node.State = State.Visited;
					return;
				}
				node.State = State.Visiting;
				foreach (Node dependency in node.Dependencies)
				{
					Visit(dependency, sortedMods);
				}
				node.State = State.Visited;
				sortedMods.Add(node.Mod);
			}
		}

		private class SystemMethodWrapper
		{
			public SystemBaseRegistry.ForwardingFunc ForwardingFunc { get; }

			public SystemMethodWrapper(Type systemType, MethodInfo methodInfo)
			{
				DynamicMethod dynamicMethod = new DynamicMethod("_forwardingFunc_" + methodInfo.Name, null, new Type[2]
				{
					typeof(IntPtr),
					typeof(IntPtr)
				}, systemType.Module);
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				MethodInfo meth = typeof(IntPtr).GetMethods().FirstOrDefault((MethodInfo x) => x.Name == "ToPointer");
				iLGenerator.Emit(OpCodes.Ldarga, 0);
				iLGenerator.Emit(OpCodes.Call, meth);
				iLGenerator.Emit(OpCodes.Ldarga, 1);
				iLGenerator.Emit(OpCodes.Call, meth);
				iLGenerator.Emit(OpCodes.Call, methodInfo);
				iLGenerator.Emit(OpCodes.Ret);
				ForwardingFunc = (SystemBaseRegistry.ForwardingFunc)dynamicMethod.CreateDelegate(typeof(SystemBaseRegistry.ForwardingFunc));
			}
		}

		[Serializable]
		private class Config
		{
			public string version;

			public List<string> unsupportedModsToLoad = new List<string>();
		}

		private const string CONFIG_FILENAME = "config.json";

		public static Loader Instance;

		private static readonly string[] iSystemMethodNames = new string[6] { "OnCreate", "OnUpdate", "OnDestroy", "OnStartRunning", "OnStopRunning", "OnCreateForCompiler" };

		private readonly Config _config = new Config();

		private readonly LoadedMods _modHandlers = new LoadedMods();

		private readonly HashSet<string> _triedToLoadSet = new HashSet<string>();

		private readonly List<LoadedMod> _loadedMods = new List<LoadedMod>();

		private readonly List<NotLoadedMod> _notLoadedMods = new List<NotLoadedMod>();

		private readonly InvokeChecker _checker = new InvokeChecker();

		private readonly HarmonyBootstrap _harmony = new HarmonyBootstrap();

		private readonly DependencySorter _sorter = new DependencySorter();

		private IConfigFilesystem _configFilesystem;

		private List<Mod> _allMods = new List<Mod>();

		private List<Mod> _mods = new List<Mod>();

		private float _timeWaitingForReload = float.PositiveInfinity;

		private ScriptDomain _scriptDomain;

		private Assembly[] _assembliesLoadedAtStart;

		private bool _needsReload;

		private bool _hasSavesMod;

		private ModResourceProvider _modResourceProvider;

		public IEnumerable<LoadedMod> LoadedMods => _loadedMods;

		public IEnumerable<NotLoadedMod> FailedToLoadMods => _notLoadedMods;

		public IEnumerable<Mod> Mods => _allMods;

		public bool HasSavesMod => _hasSavesMod;

		public event Action<object> AssetProcessor;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Register()
		{
			Integration.Instance = (Instance = new Loader());
		}

		public void Init(IConfigFilesystem configFilesystem)
		{
			_configFilesystem = configFilesystem;
			_assembliesLoadedAtStart = AppDomain.CurrentDomain.GetAssemblies();
			_timeWaitingForReload = float.PositiveInfinity;
			_modResourceProvider = new ModResourceProvider();
			try
			{
				if (_configFilesystem.FileExists("config.json"))
				{
					byte[] bytes = _configFilesystem.Read("config.json");
					JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(bytes), _config);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			string version = ModVersion.GetVersion(Application.version);
			if (version != null && !string.Equals(_config.version, version))
			{
				Debug.Log("clear list of unsupported mods that is loaded anyway due to version change " + _config.version + " -> " + version);
				_config.unsupportedModsToLoad.Clear();
				_config.version = version;
				WriteConfig();
			}
		}

		public void Update()
		{
			_modHandlers.Call.Init();
			_modHandlers.Call.Update();
			if (_needsReload)
			{
				_timeWaitingForReload += Time.deltaTime;
				if (_timeWaitingForReload > 1f && Reload())
				{
					_timeWaitingForReload = 0f;
				}
			}
		}

		public bool AddMod(ModMetadata metadata, string modDirectory, long modId, bool supportsCurrentVersion)
		{
			if (!supportsCurrentVersion && !_config.unsupportedModsToLoad.Contains(metadata.guid))
			{
				Debug.Log("not loading incompatible mod " + metadata.name);
				_notLoadedMods.Add(new NotLoadedMod
				{
					ModId = modId,
					Metadata = metadata,
					Reason = "ModDoesNotSupportVersion",
					CanForceLoad = true
				});
				return false;
			}
			return Add(metadata, modDirectory, modId);
		}

		public void RemoveMod(long modId)
		{
			Remove(modId);
		}

		public void LoadUnsupportedMod(string guid)
		{
			_config.unsupportedModsToLoad.Add(guid);
			WriteConfig();
		}

		private void AssetLoaded(UnityEngine.Object obj)
		{
			this.AssetProcessor?.Invoke(obj);
		}

		public string GetDirectory(long modId)
		{
			foreach (Mod mod in _mods)
			{
				if (mod.ModId == modId)
				{
					return mod.Directory;
				}
			}
			return null;
		}

		private static bool LoadDll(Mod mod, ModFile file, ScriptDomain scriptDomain, string tempDirectoryPath, out ModLoadError modLoadError)
		{
			modLoadError = ModLoadError.None;
			if (!mod.Metadata.accessesExtraAssemblies)
			{
				Debug.LogWarning("Tried to load dll for " + mod.Metadata.name + ", but accessesExtraAssemblies not set");
				modLoadError = ModLoadError.InvalidAccess;
				return false;
			}
			string text = Path.Combine(mod.Directory, file.path);
			string text2 = Path.Combine(tempDirectoryPath, file.path);
			FileInfo fileInfo = new FileInfo(text2);
			try
			{
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				File.WriteAllBytes(text2, File.ReadAllBytes(text));
				text = text2;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			ScriptAssembly scriptAssembly;
			try
			{
				scriptAssembly = scriptDomain.LoadAssembly(text, mod.Metadata.skipSafetyChecks ? ScriptSecurityMode.EnsureLoad : ScriptSecurityMode.EnsureSecurity);
				if (scriptAssembly == null)
				{
					Debug.LogWarning("Failed to load assembly " + file.path + " for " + mod.Metadata.name);
					modLoadError = ModLoadError.CompileFailed;
					return false;
				}
			}
			catch (IOException exception2)
			{
				Debug.LogException(exception2);
				modLoadError = ModLoadError.FileAccess;
				return false;
			}
			catch (Exception exception3)
			{
				Debug.LogException(exception3);
				modLoadError = ModLoadError.InternalError;
				return false;
			}
			Debug.Log($"Successfully loaded {file.path} safetyCheck={!mod.Metadata.skipSafetyChecks}");
			mod.LoadedAssemblies.Add(scriptAssembly);
			return true;
		}

		private bool LoadScripts(Mod mod, List<ModFile> scriptFiles, ScriptDomain scriptDomain, string tempDirectoryPath, out ModLoadError error)
		{
			error = ModLoadError.None;
			List<IMetadataReferenceProvider> list = new List<IMetadataReferenceProvider>();
			foreach (Mod mod2 in _mods)
			{
				list.AddRange(mod2.LoadedAssemblies);
			}
			list.AddRange(mod.LoadedAssemblies);
			if (mod.Metadata.accessesExtraAssemblies)
			{
				Assembly[] assembliesLoadedAtStart = _assembliesLoadedAtStart;
				foreach (Assembly assembly in assembliesLoadedAtStart)
				{
					if (!assembly.IsDynamic && !string.IsNullOrEmpty(assembly.Location))
					{
						if (!File.Exists(assembly.Location))
						{
							Debug.LogError("doesn't exist: " + assembly.FullName + "@" + assembly.Location);
						}
						else
						{
							list.Add(new AssemblyReferenceFromFile(assembly.Location));
						}
					}
				}
			}
			List<string> list2 = new List<string>(scriptFiles.Count);
			foreach (ModFile scriptFile in scriptFiles)
			{
				try
				{
					list2.Add(File.ReadAllText(Path.Combine(mod.Directory, scriptFile.path)));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					SetError(mod, ref error, ModLoadError.FileAccess);
					return false;
				}
			}
			if (!SourceGenPatch.Patch(mod.Metadata.name, list2, !mod.Metadata.skipSafetyChecks))
			{
				Debug.LogWarning("Failed to do source gen patch for " + mod.Metadata.name);
				SetError(mod, ref error, ModLoadError.InternalError);
				return false;
			}
			scriptDomain.RoslynCompilerService.OutputName = mod.Metadata.name + ".dll";
			string[] array = new string[scriptFiles.Count];
			Debug.Log("Creating modified script files at " + tempDirectoryPath);
			for (int j = 0; j < scriptFiles.Count; j++)
			{
				FileInfo fileInfo = new FileInfo(Path.Combine(tempDirectoryPath, scriptFiles[j].path));
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				File.WriteAllText(fileInfo.FullName, list2[j], Encoding.UTF8);
				array[j] = fileInfo.FullName;
			}
			ScriptAssembly scriptAssembly = scriptDomain.CompileAndLoadFiles(array, mod.Metadata.skipSafetyChecks ? ScriptSecurityMode.EnsureLoad : ScriptSecurityMode.UseSettings, list.ToArray());
			if (scriptAssembly == null || scriptAssembly.CompileResult == null)
			{
				Debug.LogError("failed to compile mod, got null");
				SetError(mod, ref error, ModLoadError.CompileFailed);
				return false;
			}
			if (!scriptAssembly.CompileResult.Success)
			{
				scriptAssembly.CompileResult.Errors.ToList().ForEach(delegate(CompilationError e)
				{
					Debug.Log(e);
				});
				SetError(mod, ref error, ModLoadError.CompileFailed);
				return false;
			}
			Debug.Log($"Successfully compiled {mod.Metadata.name} safetyCheck={!mod.Metadata.skipSafetyChecks}");
			if (!JobsPatch.Patch(scriptAssembly.SystemAssembly))
			{
				Debug.Log("mod " + mod.Metadata.name + ": jobs patching failed");
			}
			if (!mod.Metadata.disableHarmonyPatching)
			{
				HarmonyPatchAssembly(mod, scriptAssembly, _harmony, _checker);
			}
			if (!AddEntitySystems(scriptAssembly))
			{
				SetError(mod, ref error, ModLoadError.InternalError);
				return false;
			}
			mod.LoadedAssemblies.Add(scriptAssembly);
			return true;
			static void SetError(Mod mod2, ref ModLoadError reference, ModLoadError setError)
			{
				Debug.Log($"mod {mod2.Metadata.name} load error: {setError}");
				reference = setError;
			}
		}

		private static bool AddEntitySystems(ScriptAssembly assembly)
		{
			try
			{
				foreach (ScriptType item in assembly.EnumerateAllTypes())
				{
					if (!item.IsSubTypeOf<ISystem>())
					{
						continue;
					}
					SystemBaseRegistry.ForwardingFunc[] array = new SystemBaseRegistry.ForwardingFunc[iSystemMethodNames.Length];
					MethodInfo[] methods = item.SystemType.GetMethods();
					foreach (MethodInfo methodInfo in methods)
					{
						for (int j = 0; j < array.Length; j++)
						{
							if (methodInfo.Name.Equals(iSystemMethodNames[j]) && !(methodInfo.ReturnType != typeof(void)))
							{
								ParameterInfo[] parameters = methodInfo.GetParameters();
								if (parameters.Length == 1 && !(parameters[0].ParameterType != typeof(SystemState).MakeByRefType()))
								{
									array[j] = new SystemMethodWrapper(item.SystemType, methodInfo).ForwardingFunc;
									Debug.Log("found ISystem function " + iSystemMethodNames[j] + " for " + item.FullName + ", creating wrapper");
								}
							}
						}
					}
					SystemBaseRegistry.AddUnmanagedSystemType(item.SystemType, BurstRuntime.GetHashCode64(item.SystemType), array[0], array[1], array[2], array[3], array[4], array[5], item.FullName, 0);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
			return true;
		}

		public void HarmonyPatch(Mod mod)
		{
			foreach (ScriptAssembly loadedAssembly in mod.LoadedAssemblies)
			{
				HarmonyPatchAssembly(mod, loadedAssembly, _harmony, _checker);
			}
		}

		private static void HarmonyPatchAssembly(Mod mod, ScriptAssembly assembly, HarmonyBootstrap harmony, InvokeChecker checker)
		{
			try
			{
				if (!harmony.Patch(mod.Metadata.name, assembly.SystemAssembly, !mod.Metadata.skipSafetyChecks, checker))
				{
					Debug.Log("mod " + mod.Metadata.name + ": patching failed");
				}
			}
			catch (Exception exception)
			{
				Debug.Log("failed to patch mod " + mod.Metadata.name + ", got exception");
				Debug.LogException(exception);
			}
		}

		public void HarmonyPatchType(Mod mod, Type type)
		{
			try
			{
				if (!_harmony.Patch(mod.Metadata.name, type, !mod.Metadata.skipSafetyChecks, _checker))
				{
					Debug.Log("mod " + mod.Metadata.name + ": patching failed");
				}
			}
			catch (Exception exception)
			{
				Debug.Log("failed to patch mod " + mod.Metadata.name + ", got exception");
				Debug.LogException(exception);
			}
		}

		public void UndoHarmonyPatch(Mod mod)
		{
			_harmony.Unload(mod.Metadata.name);
		}

		private static void FindAllModHandlers(Mod mod)
		{
			foreach (ScriptAssembly loadedAssembly in mod.LoadedAssemblies)
			{
				ScriptType[] array = loadedAssembly.FindAllSubTypesOf<IMod>(includeNonPublic: false);
				for (int i = 0; i < array.Length; i++)
				{
					IMod item = array[i].CreateInstanceRaw<IMod>();
					mod.LoadedMods.Add(item);
				}
			}
		}

		private bool LoadBundle(Mod mod, ModFile bundleFile, out ModLoadError modLoadError)
		{
			modLoadError = ModLoadError.None;
			Match match = new Regex("_(.+?)\\.assetbundle").Match(bundleFile.path);
			if (match.Success)
			{
				if (!match.Groups[1].Value.Equals("Windows"))
				{
					Debug.Log("Ignoring " + bundleFile.path + ": wrong platform");
					return true;
				}
			}
			else
			{
				Console.WriteLine("Pattern did not match.");
			}
			Debug.Log("loading " + bundleFile.path);
			string text = Path.Combine(mod.Directory, bundleFile.path);
			byte[] binary;
			try
			{
				binary = File.ReadAllBytes(text);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				modLoadError = ModLoadError.FileAccess;
				return false;
			}
			AssetBundle assetBundle = null;
			try
			{
				assetBundle = AssetBundle.LoadFromMemory(binary);
			}
			catch (Exception exception2)
			{
				modLoadError = ModLoadError.Unknown;
				Debug.LogException(exception2);
			}
			if (assetBundle == null)
			{
				Debug.LogError("failed to load assetbundle from mod " + mod.Metadata.name);
				modLoadError = ModLoadError.Unknown;
				return false;
			}
			ScriptableData.AddDataBlocksLoader(mod.Metadata.guid, new ScriptableDataLoader(assetBundle));
			Debug.Log("staged mod bundle: " + assetBundle.name);
			mod.LoadedBundles.Add(assetBundle);
			new List<UnityEngine.Object>();
			string text2 = text + ".manifest";
			if (File.Exists(text2))
			{
				foreach (KeyValuePair<string, string> item in GetAssetNameToGUIDMap(text2))
				{
					UnityEngine.Object obj = assetBundle.LoadAsset(item.Key);
					if (obj == null)
					{
						Debug.Log("couldn't load " + item.Key + " from asset bundle " + bundleFile.path);
						continue;
					}
					mod.LoadedAssets.Add(obj);
					_modResourceProvider.AddAsset(item.Value, obj);
				}
			}
			else
			{
				mod.LoadedAssets.AddRange(assetBundle.LoadAllAssets());
			}
			return true;
		}

		private static Dictionary<string, string> GetAssetNameToGUIDMap(string assetBundleManifestPath)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			AssetBundleManifest assetBundleManifest = new AssetBundleManifest
			{
				assets = new List<ModFile>()
			};
			if (!File.Exists(assetBundleManifestPath))
			{
				return dictionary;
			}
			JsonUtility.FromJsonOverwrite(File.ReadAllText(assetBundleManifestPath), assetBundleManifest);
			foreach (ModFile asset in assetBundleManifest.assets)
			{
				dictionary.Add(asset.path, asset.guid);
			}
			return dictionary;
		}

		public bool Add(ModMetadata metadata, string modDirectory, long modId)
		{
			Mod item = new Mod
			{
				ModId = modId,
				Directory = modDirectory,
				Metadata = metadata,
				LoadedMods = new List<IMod>(),
				LoadedAssemblies = new List<ScriptAssembly>(),
				LoadedBundles = new List<AssetBundle>(),
				LoadedAssets = new List<UnityEngine.Object>()
			};
			_mods.Add(item);
			_allMods.Add(item);
			_needsReload = true;
			return true;
		}

		public bool Reload()
		{
			foreach (Mod mod3 in _mods)
			{
				foreach (IMod loadedMod in mod3.LoadedMods)
				{
					if (!loadedMod.CanBeUnloaded())
					{
						Debug.Log($"Mod reload blocked by {loadedMod.GetType()}");
						return false;
					}
				}
			}
			_needsReload = false;
			foreach (Mod mod4 in _mods)
			{
				Reset(mod4);
			}
			_loadedMods.Clear();
			if (_scriptDomain != null)
			{
				_scriptDomain.Dispose();
			}
			_scriptDomain = ScriptDomain.CreateDomain("PugMod");
			string environmentVariable = Environment.GetEnvironmentVariable("PUG_MOD_CSHARP_DEFINES");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				string[] array = environmentVariable.Split(';');
				foreach (string text in array)
				{
					if (!string.IsNullOrEmpty(text))
					{
						_scriptDomain.RoslynCompilerService.DefineSymbols.Add(text);
					}
				}
			}
			_triedToLoadSet.Clear();
			bool flag = false;
			foreach (Mod mod5 in _mods)
			{
				_triedToLoadSet.Add(mod5.Metadata.guid);
			}
			for (int num = _config.unsupportedModsToLoad.Count - 1; num >= 0; num--)
			{
				string item = _config.unsupportedModsToLoad[num];
				if (!_triedToLoadSet.Contains(item))
				{
					_config.unsupportedModsToLoad.RemoveAt(num);
					flag = true;
				}
			}
			if (flag)
			{
				WriteConfig();
			}
			_mods = _sorter.SortMods(_mods);
			for (int j = 0; j < _mods.Count; j++)
			{
				Mod mod = _mods[j];
				_triedToLoadSet.Add(mod.Metadata.guid);
				if (!Load(mod, out var loadError))
				{
					_notLoadedMods.Add(new NotLoadedMod
					{
						ModId = mod.ModId,
						Metadata = mod.Metadata,
						CanForceLoad = false,
						Reason = loadError.ToString()
					});
					Reset(mod);
					_mods.RemoveAt(j);
					return false;
				}
				if (!_hasSavesMod)
				{
					try
					{
						if (Directory.Exists(Path.Combine(mod.Directory, "Saves")))
						{
							_hasSavesMod = true;
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				_loadedMods.Add(new LoadedMod
				{
					ModId = mod.ModId,
					Metadata = mod.Metadata,
					Handlers = mod.LoadedMods,
					Assets = mod.LoadedAssets,
					AssetBundles = mod.LoadedBundles
				});
			}
			for (int k = 0; k < _mods.Count; k++)
			{
				Mod mod2 = _mods[k];
				foreach (IMod loadedMod2 in mod2.LoadedMods)
				{
					_modHandlers.Add(loadedMod2);
					try
					{
						loadedMod2.EarlyInit();
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
					}
				}
				foreach (UnityEngine.Object loadedAsset in mod2.LoadedAssets)
				{
					ReplaceMaterials(loadedAsset);
					Instance.AssetLoaded(loadedAsset);
					foreach (IMod loadedMod3 in mod2.LoadedMods)
					{
						try
						{
							loadedMod3.ModObjectLoaded(loadedAsset);
						}
						catch (Exception exception3)
						{
							Debug.LogException(exception3);
						}
					}
				}
			}
			return true;
		}

		public void Remove(long modId)
		{
			for (int i = 0; i < _allMods.Count; i++)
			{
				if (_allMods[i].ModId == modId)
				{
					_allMods.RemoveAt(i);
					break;
				}
			}
			Mod mod = default(Mod);
			for (int j = 0; j < _mods.Count; j++)
			{
				if (_mods[j].ModId == modId)
				{
					mod = _mods[j];
					_mods.RemoveAt(j);
					break;
				}
			}
			if (mod.ModId == 0L)
			{
				Debug.LogError("Unload called on non-loaded modId");
				return;
			}
			Reset(mod);
			_needsReload = true;
		}

		private bool Load(Mod mod, out ModLoadError loadError)
		{
			loadError = ModLoadError.None;
			new List<string>();
			List<ModFile> list = mod.Metadata.files.FindAll((ModFile x) => x.path.EndsWith(".dll"));
			List<ModFile> list2 = mod.Metadata.files.FindAll((ModFile x) => x.path.EndsWith(".cs"));
			List<ModFile> list3 = mod.Metadata.files.FindAll((ModFile x) => x.path.EndsWith(".assetbundle"));
			if (!mod.Metadata.disableScripts)
			{
				string text = null;
				text = Path.Combine(Application.temporaryCachePath, "ModLoader", mod.Metadata.name);
				if (Directory.Exists(text))
				{
					Directory.Delete(text, recursive: true);
				}
				foreach (ModFile item in list)
				{
					if (!LoadDll(mod, item, _scriptDomain, text, out loadError))
					{
						return false;
					}
				}
				if (list2.Count != 0 && !LoadScripts(mod, list2, _scriptDomain, text, out loadError))
				{
					return false;
				}
				FindAllModHandlers(mod);
			}
			foreach (ModFile item2 in list3)
			{
				if (!LoadBundle(mod, item2, out loadError))
				{
					return false;
				}
			}
			return true;
		}

		private static void ReplaceMaterials(UnityEngine.Object asset)
		{
			if (!(asset is GameObject gameObject))
			{
				return;
			}
			MaterialSwapTable materialSwapTable = Resources.Load<MaterialSwapTable>("ModSDK/MaterialSwapTable");
			if (materialSwapTable == null)
			{
				return;
			}
			Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(Renderer), includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Renderer renderer = componentsInChildren[i] as Renderer;
				Material[] sharedMaterials = renderer.sharedMaterials;
				bool flag = false;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					if (sharedMaterials[j] == null)
					{
						continue;
					}
					string name = sharedMaterials[j].name;
					foreach (MaterialSwapTable.SwapEntry material in materialSwapTable.materials)
					{
						if (material.materialName.Equals(name, StringComparison.OrdinalIgnoreCase))
						{
							Debug.Log("material in " + renderer.name + " replaced with " + material.materialToSwapTo.name);
							sharedMaterials[j] = material.materialToSwapTo;
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					renderer.sharedMaterials = sharedMaterials;
				}
			}
			componentsInChildren = gameObject.GetComponentsInChildren(typeof(ParticleSystem), includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ParticleSystem particleSystem = componentsInChildren[i] as ParticleSystem;
				Renderer component = particleSystem.GetComponent<Renderer>();
				if (component == null)
				{
					continue;
				}
				Material[] sharedMaterials2 = component.sharedMaterials;
				bool flag2 = false;
				for (int k = 0; k < sharedMaterials2.Length; k++)
				{
					string name2 = sharedMaterials2[k].name;
					foreach (MaterialSwapTable.SwapEntry material2 in materialSwapTable.materials)
					{
						if (material2.materialName.Equals(name2, StringComparison.OrdinalIgnoreCase))
						{
							Debug.Log("material in " + particleSystem.name + " replaced with " + material2.materialToSwapTo.name);
							sharedMaterials2[k] = material2.materialToSwapTo;
							flag2 = true;
							break;
						}
					}
				}
				if (flag2)
				{
					component.sharedMaterials = sharedMaterials2;
				}
			}
		}

		private void Reset(Mod mod)
		{
			foreach (IMod loadedMod in mod.LoadedMods)
			{
				try
				{
					loadedMod.Shutdown();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				_modHandlers.Remove(loadedMod);
			}
			mod.LoadedMods.Clear();
			mod.LoadedAssemblies.Clear();
			foreach (AssetBundle loadedBundle in mod.LoadedBundles)
			{
				loadedBundle.Unload(unloadAllLoadedObjects: true);
			}
			mod.LoadedBundles.Clear();
			mod.LoadedAssets.Clear();
			if (!mod.Metadata.disableHarmonyPatching)
			{
				UndoHarmonyPatch(mod);
			}
		}

		private void WriteConfig()
		{
			byte[] bytes = Encoding.UTF8.GetBytes(JsonUtility.ToJson(_config));
			try
			{
				_configFilesystem.Write("config.json", bytes);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
