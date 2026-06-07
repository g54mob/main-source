using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Assets.Scripts.Mods.Events;
using Assets.Scripts.Mods.Exceptions;
using Jundroo.Common;
using Jundroo.Common.Extensions;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Mods
{
	public abstract class ModManagerBase : IModManagerBase
	{
		protected class LoadedModAssembly
		{
			private string _assemblyHashCode;

			public Assembly Assembly { get; private set; }

			public byte[] AssemblyBytes { get; private set; }

			public string AssemblyHashCode
			{
				get
				{
					if (_assemblyHashCode == null)
					{
						_assemblyHashCode = GenerateAssemblyHashCode();
					}
					return _assemblyHashCode;
				}
			}

			public string Name { get; private set; }

			public LoadedModAssembly(Assembly assembly, byte[] bytes)
			{
				Name = assembly.FullName;
				Assembly = assembly;
				AssemblyBytes = bytes;
			}

			private string GenerateAssemblyHashCode()
			{
				if (AssemblyBytes == null)
				{
					return null;
				}
				using SHA256 sHA = SHA256.Create();
				return Encoding.UTF8.GetString(sHA.ComputeHash(AssemblyBytes));
			}
		}

		private readonly List<ModLoadMessage> _allModLoadMessages;

		private readonly List<ModInfo> _knownMods;

		private readonly List<ILoadedMod> _loadedMods;

		private readonly Dictionary<string, LoadedModAssembly> _modAssemblies;

		private readonly Dictionary<string, ModInfo> _scanResults;

		public ReadOnlyCollection<ModInfo> KnownMods { get; private set; }

		public ReadOnlyCollection<ILoadedMod> LoadedMods { get; private set; }

		public ICollection<ModLoadMessage> ModLoadErrors { get; private set; }

		public ICollection<ModLoadMessage> ModLoadMessages { get; private set; }

		public ICollection<ModLoadMessage> ModLoadWarnings { get; private set; }

		public bool SupportsCodeExecution => true;

		protected IReadOnlyCollection<LoadedModAssembly> Assemblies => _modAssemblies.Values;

		public static event EventHandler<PreProcessAssemblyEventArgs> PreProcessAssembly;

		public event EventHandler<ApiVersionMismatchEventArgs> ApiVersionMismatch;

		public ModManagerBase()
		{
			_knownMods = new List<ModInfo>();
			_loadedMods = new List<ILoadedMod>();
			_modAssemblies = new Dictionary<string, LoadedModAssembly>();
			_scanResults = new Dictionary<string, ModInfo>();
			KnownMods = new ReadOnlyCollection<ModInfo>(_knownMods);
			LoadedMods = new ReadOnlyCollection<ILoadedMod>(_loadedMods);
			ModLoadMessages = new List<ModLoadMessage>();
			ModLoadErrors = new List<ModLoadMessage>();
			ModLoadWarnings = new List<ModLoadMessage>();
			_allModLoadMessages = new List<ModLoadMessage>();
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
			AppDomain.CurrentDomain.TypeResolve += TypeResolve;
		}

		public void DeleteMod(ModInfo mod)
		{
			if (mod.Enabled || mod.PendingDisable)
			{
				throw new InvalidOperationException("Unable to delete mod '" + mod.Name + "'. The mod must not be enabled or pending disable.");
			}
			File.Delete(mod.Path);
			if (!_knownMods.Remove(mod))
			{
				LogLoadError(mod, "An error occurred deleting mod '" + mod.Name + "'. Unable to remove mod from the mod list.");
			}
			string key = FileIOUtility.NormalizePath(mod.Path, preserveCasing: false);
			if (!_scanResults.Remove(key))
			{
				LogLoadError(mod, "An error occurred deleting mod '" + mod.Name + "'. Unable to remove mod from the scan results.");
			}
		}

		public List<Assembly> GetModAssemblies()
		{
			return _modAssemblies.Select((KeyValuePair<string, LoadedModAssembly> x) => x.Value.Assembly).ToList();
		}

		public void LoadEnabledMods(bool allowApiVersionMismatch)
		{
			foreach (ModInfo item in from x in _knownMods
				where x.Enabled
				orderby x.LoadPriority, x.Name
				select x)
			{
				LoadMod(item, allowApiVersionMismatch);
			}
		}

		public void LoadMod(ModInfo mod, bool allowApiVersionMismatch)
		{
			if (!mod.Enabled)
			{
				LogLoadError(mod, "Could not load mod '{0} - {1}'. The mod is currently disabled.", mod.Name, mod.Version);
				return;
			}
			if (!_knownMods.Contains(mod))
			{
				LogLoadError(mod, "Could not load mod '{0} - {1}'. The mod is not in the list of discovered mods.", mod.Name, mod.Version);
				return;
			}
			if (_loadedMods.Any((ILoadedMod x) => x.ModInfo == mod))
			{
				LogLoadError(mod, "Could not load mod '{0} - {1}'. Mod already loaded.", mod.Name, mod.Version);
				return;
			}
			if (_loadedMods.Any((ILoadedMod x) => x.ModInfo.Name == mod.Name && x.ModInfo.Author == mod.Author))
			{
				LogLoadError(mod, "Could not load mod '{0} - {1}'. A mod with that name and author has already been loaded.", mod.Name, mod.Version);
				return;
			}
			try
			{
				ModHeader header;
				AssetBundle assetBundle = LoadAssetBundleFromMod(mod, mod.Path, out header);
				if (assetBundle == null)
				{
					return;
				}
				ModManifest modManifest = GetModManifest(mod.Name, assetBundle);
				bool flag = VerifyApiVersions(mod, modManifest);
				if (flag || allowApiVersionMismatch)
				{
					if (!flag)
					{
						LogLoadMessage(mod, "Attempting to load mod '{0}' despite API version mismatch", mod.Name);
					}
					LoadedMod loadedMod = new LoadedMod(mod, assetBundle, modManifest);
					LoadModAssemblies(loadedMod, modManifest);
					_loadedMods.Add(loadedMod);
					OnModLoaded(loadedMod, modManifest);
					LogLoadMessage(mod, "Mod Loaded: {0}, Version {1} - {2}", mod.Name, mod.Version, mod.LastUpdated);
				}
				else
				{
					LogLoadError(mod, "Mod '{0}' will not be loaded due to an API version mismatch.", mod.Name);
					assetBundle.Unload(unloadAllLoadedObjects: true);
				}
			}
			catch (Exception ex)
			{
				LogLoadError(mod, "An error occurred attempting load mod '{0} - {1}' located at '{2}'. {3}", mod.Name, mod.Version, mod.Path, ex);
			}
		}

		public void LoadMods(List<ModInfo> mods, bool allowApiVersionMismatch)
		{
			foreach (ModInfo item in from x in mods
				orderby x.LoadPriority, x.Name
				select x)
			{
				LoadMod(item, allowApiVersionMismatch);
			}
		}

		public void SaveModLoadLog(string filePath)
		{
			if (_allModLoadMessages.Count == 0)
			{
				return;
			}
			try
			{
				using FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
				using StreamWriter streamWriter = new StreamWriter(stream);
				foreach (ModLoadMessage allModLoadMessage in _allModLoadMessages)
				{
					if (allModLoadMessage.Mod != null)
					{
						string value = $"Mod: {allModLoadMessage.Mod.Name}, Author: {allModLoadMessage.Mod.Author}, Version: {allModLoadMessage.Mod.Version}, Created: {allModLoadMessage.Mod.LastUpdated}, Path: {allModLoadMessage.Mod.Path}";
						streamWriter.WriteLine(value);
					}
					streamWriter.WriteLine(allModLoadMessage.Message);
					streamWriter.WriteLine();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public List<ModInfo> ScanForMods(string directory, bool recursive, bool createIfNotFound)
		{
			if (!Directory.Exists(directory))
			{
				if (createIfNotFound)
				{
					Directory.CreateDirectory(directory);
				}
				else
				{
					LogLoadMessage(null, "The directory to scan for mods could not be found: " + directory);
				}
				return new List<ModInfo>();
			}
			List<ModInfo> list = new List<ModInfo>();
			foreach (string item in from x in GetModFilePaths(directory, recursive)
				select FileIOUtility.NormalizePath(x, preserveCasing: false))
			{
				if (!_scanResults.TryGetValue(item, out var mod))
				{
					mod = ReadModFileInfo(item);
					if (mod != null)
					{
						if (!_knownMods.Any((ModInfo x) => x.Name == mod.Name && x.Author == mod.Author))
						{
							_knownMods.Add(mod);
						}
						_scanResults.Add(item, mod);
					}
				}
				if (mod != null)
				{
					list.Add(mod);
				}
			}
			return list;
		}

		protected virtual Assembly AssemblyResolve(object sender, ResolveEventArgs args)
		{
			return _modAssemblies.GetValueOrDefault(args.Name)?.Assembly;
		}

		protected virtual Type GetGameModObjectType()
		{
			return typeof(GameModBase);
		}

		protected abstract string[] GetModFilePaths(string directory, bool recursive);

		protected void LogLoadError(ModInfo mod, string message, params object[] args)
		{
			message = ((args == null || args.Length == 0) ? message : string.Format(message, args));
			ModLoadMessage item = new ModLoadMessage(mod, message);
			ModLoadErrors.Add(item);
			_allModLoadMessages.Add(item);
			Debug.LogError(message);
		}

		protected void LogLoadMessage(ModInfo mod, string message, params object[] args)
		{
			message = ((args == null || args.Length == 0) ? message : string.Format(message, args));
			ModLoadMessage item = new ModLoadMessage(mod, message);
			ModLoadMessages.Add(item);
			_allModLoadMessages.Add(item);
			Debug.Log(message);
		}

		protected void LogLoadWarning(ModInfo mod, string message, params object[] args)
		{
			message = ((args == null || args.Length == 0) ? message : string.Format(message, args));
			ModLoadMessage item = new ModLoadMessage(mod, message);
			ModLoadWarnings.Add(item);
			_allModLoadMessages.Add(item);
			Debug.LogWarning(message);
		}

		protected virtual void OnGameModObjectInitialized(GameModBase mod)
		{
		}

		protected virtual void OnModLoaded(LoadedMod mod, ModManifest manifest)
		{
		}

		protected void RaiseApiVersionMismatch(ModInfo mod, Version currentApiVersion, Version modApiVersion, string apiName)
		{
			this.ApiVersionMismatch?.Invoke(this, new ApiVersionMismatchEventArgs(mod, currentApiVersion, modApiVersion, apiName));
		}

		protected virtual void ScanLoadedAssembly(LoadedMod mod, Assembly assembly, IReadOnlyList<Type> types)
		{
		}

		protected virtual bool VerifyApiVersions(ModInfo mod, ModManifest modManifest)
		{
			Version version = typeof(Project).Assembly.GetName().Version;
			Version apiVersion = modManifest.GetApiVersion();
			if (version != apiVersion)
			{
				RaiseApiVersionMismatch(mod, version, apiVersion, "Common");
				return false;
			}
			return true;
		}

		private ModManifest GetModManifest(string modNameOrPath, AssetBundle assetBundle)
		{
			TextAsset textAsset = assetBundle.LoadAsset<TextAsset>(AssetPaths.ModManifestFile);
			if (textAsset == null)
			{
				throw new ModManifestNotFoundException($"Could not find mod manifest for mod '{modNameOrPath}'.");
			}
			XDocument xml;
			try
			{
				xml = AssetHeaders.LoadManifest(textAsset.bytes);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				throw new ModManifestNotFoundException("An error occurred loading the mod manifest for mod '" + modNameOrPath + "'. " + ex.Message, ex);
			}
			return new ModManifest(xml);
		}

		private void InitializeGameModObjects(LoadedMod mod, IReadOnlyList<Type> types)
		{
			Type baseType = GetGameModObjectType();
			foreach (Type item in types.Where((Type x) => baseType.IsAssignableFrom(x)).ToList())
			{
				try
				{
					RuntimeHelpers.RunClassConstructor(item.TypeHandle);
					GameModBase modInstance = GameModBase.GetModInstance(item);
					modInstance.Initialize(mod);
					mod.GameMods.Add(modInstance);
					OnGameModObjectInitialized(modInstance);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					LogLoadError(mod.ModInfo, "An error occurred initializing mod type '" + item.FullName + "' in mod '" + mod.ModInfo.Name + "'.");
				}
			}
		}

		private AssetBundle LoadAssetBundleFromMod(ModInfo modInfo, string modFilePath, out ModHeader header)
		{
			if (modInfo != null && modInfo.IsBundledMod)
			{
				TextAsset textAsset = Resources.Load<TextAsset>("BundledMods/" + modFilePath);
				if (textAsset == null)
				{
					LogLoadError(modInfo, "Prepackaged bundle not found for mod: " + modInfo.Name);
					header = null;
					return null;
				}
				header = new ModHeader(0L, 0L, 0L, 0L, 0L);
				return AssetBundle.LoadFromMemory(textAsset.bytes);
			}
			header = ModHeader.Read(modFilePath);
			if (header == null)
			{
				LogLoadMessage(null, "Attempting to load a mod file without header information: " + modFilePath);
				if (modInfo != null)
				{
					LogLoadWarning(modInfo, "Mod '" + modInfo.Name + "' was built with an old version of the mod tools and may not work correctly.");
				}
				header = ModHeader.Default;
			}
			long? num = null;
			long? num2 = null;
			if (Device.IsWindowsBuild)
			{
				num = header.AssetBundleOffsetWindows;
				num2 = num ?? header.AssetBundleOffsetLinux ?? header.AssetBundleOffsetMacOS;
			}
			else if (Device.IsOsxBuild)
			{
				num = header.AssetBundleOffsetMacOS;
				num2 = num ?? header.AssetBundleOffsetLinux ?? header.AssetBundleOffsetWindows;
			}
			else if (Device.IsLinuxBuild)
			{
				num = header.AssetBundleOffsetLinux;
				num2 = num ?? header.AssetBundleOffsetWindows ?? header.AssetBundleOffsetMacOS;
			}
			else if (Device.IsAndroidBuild)
			{
				num = header.AssetBundleOffsetAndroid;
				num2 = num;
			}
			else if (Device.IsIosBuild)
			{
				num = header.AssetBundleOffsetIOS;
				num2 = num;
			}
			if (modInfo != null)
			{
				if (!num2.HasValue)
				{
					LogLoadError(modInfo, $"Unable to load mod '{modInfo.Name}' because the mod file does not support this platform ({Application.platform}).");
				}
				else if (!num.HasValue)
				{
					LogLoadWarning(modInfo, $"Mod '{modInfo.Name}' does not support this platform ({Application.platform}) and may not work correctly.");
				}
			}
			if (!num2.HasValue)
			{
				return null;
			}
			return AssetBundle.LoadFromFile(modFilePath, 0u, (ulong)num2.Value);
		}

		private void LoadModAssemblies(LoadedMod mod, ModManifest manifest)
		{
			if (mod.ModInfo.IsBundledMod)
			{
				throw new Exception("Bundled mods not currently supported");
			}
			List<string> list = manifest.AssemblyPaths.ToList();
			if (!SupportsCodeExecution && list.Count > 0)
			{
				LogLoadWarning(mod.ModInfo, $"Could not load '{list.Count}' assemblies from mod '{mod.ModInfo.Name}' " + "because mod code execution is not supported in this version of the game.");
				return;
			}
			List<Assembly> list2 = new List<Assembly>();
			foreach (string item in list)
			{
				TextAsset textAsset = mod.ResourceLoader.LoadAsset<TextAsset>(item);
				if (textAsset == null)
				{
					LogLoadError(mod.ModInfo, "Unable to find assembly asset '{0}' in mod '{1}'", item, mod.ModInfo.Name);
					continue;
				}
				byte[] bytes = textAsset.bytes;
				byte[] assemblyBytes;
				try
				{
					assemblyBytes = AssetHeaders.ExtractAsset(bytes, AssetHeaders.AssemblyHeader);
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
					LogLoadError(mod.ModInfo, "Unable to load assembly '" + item + "' from mod '" + mod.ModInfo.Name + "'. " + ex.Message);
					continue;
				}
				assemblyBytes = PreprocessAssembly(assemblyBytes, mod, manifest, item);
				Assembly assembly = Assembly.Load(assemblyBytes);
				LoadedModAssembly loadedModAssembly = new LoadedModAssembly(assembly, assemblyBytes);
				if (_modAssemblies.ContainsKey(loadedModAssembly.Name))
				{
					if (_modAssemblies[loadedModAssembly.Name].AssemblyHashCode != loadedModAssembly.AssemblyHashCode)
					{
						LogLoadWarning(mod.ModInfo, "Mod '{0}' attempted to load assembly '{1}' but a different version of assembly '{2}' was already loaded by another mod", mod.ModInfo.Name, item, assembly.FullName);
					}
				}
				else
				{
					_modAssemblies.Add(assembly.FullName, loadedModAssembly);
					list2.Add(assembly);
				}
			}
			foreach (Assembly item2 in list2)
			{
				ScanLoadedAssembly(mod, item2);
			}
		}

		private byte[] PreprocessAssembly(byte[] assemblyBytes, LoadedMod mod, ModManifest manifest, string assemblyPath)
		{
			EventHandler<PreProcessAssemblyEventArgs> preProcessAssembly = ModManagerBase.PreProcessAssembly;
			if (preProcessAssembly != null)
			{
				PreProcessAssemblyEventArgs e = new PreProcessAssemblyEventArgs(mod.ModInfo, assemblyPath, assemblyBytes);
				preProcessAssembly(this, e);
				assemblyBytes = e.AssemblyBytes;
			}
			return assemblyBytes;
		}

		private ModInfo ReadModFileInfo(string modFile)
		{
			ModInfo result = null;
			AssetBundle assetBundle = null;
			try
			{
				assetBundle = LoadAssetBundleFromMod(null, modFile, out var _);
				if (assetBundle != null)
				{
					ModManifest modManifest = GetModManifest(modFile, assetBundle);
					result = new ModInfo(new ModBuildInfo(modManifest.BuildID.Value, modManifest.BuildGameVersion, modManifest.BuildUnityVersion, modManifest.BuildOperatingSystem), modManifest.Name, modManifest.Description, modManifest.Author, modManifest.Version, modManifest.LastUpdated, modManifest.LoadPriority, modFile, enabled: false);
				}
				else
				{
					LogLoadError(null, "An error occurred attempting to read mod file '{0}'.", modFile);
				}
			}
			catch (Exception ex)
			{
				LogLoadError(null, "An error occurred attempting to read mod file '{0}'. {1}", modFile, ex);
			}
			finally
			{
				if (assetBundle != null)
				{
					assetBundle.Unload(unloadAllLoadedObjects: true);
				}
			}
			return result;
		}

		private void ScanLoadedAssembly(LoadedMod mod, Assembly assembly)
		{
			List<Type> list = null;
			try
			{
				list = assembly.GetTypes().ToList();
			}
			catch (ReflectionTypeLoadException ex)
			{
				Debug.LogException(ex);
				ex.LoaderExceptions.ToList().ForEach(delegate(Exception x)
				{
					Debug.LogException(x);
				});
				LogLoadError(mod.ModInfo, "An error occurred getting types for assembly '" + assembly.FullName + "' in mod '" + mod.ModInfo.Name + "'.");
				return;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				LogLoadError(mod.ModInfo, "An error occurred getting types for assembly '" + assembly.FullName + "' in mod '" + mod.ModInfo.Name + "'.");
				return;
			}
			try
			{
				ScanLoadedAssembly(mod, assembly, list);
				InitializeGameModObjects(mod, list);
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
				LogLoadError(mod.ModInfo, "An error occurred scanning assembly types '" + assembly.FullName + "' in mod '" + mod.ModInfo.Name + "'.");
			}
		}

		private Assembly TypeResolve(object sender, ResolveEventArgs args)
		{
			foreach (LoadedModAssembly value in _modAssemblies.Values)
			{
				if (value.Assembly.GetType(args.Name, throwOnError: false) != null)
				{
					return value.Assembly;
				}
			}
			return null;
		}
	}
}
