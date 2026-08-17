using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using Zenject;

namespace VampireSurvivors.Framework.DLC;

public class ManifestLoader : IInitializable, IDisposable
{
	private DataManager _dataManager;

	private SpriteManager _spriteManager;

	private AdventureManager _adventureManager;

	private static ManifestLoader _sInstance;

	public void Initialize()
	{
		_sInstance = this;
	}

	public void Dispose()
	{
		_sInstance = null;
	}

	public static AssetBundle LoadAssetBundleFromPath(string bundlePath)
	{
		//IL_0013: Expected I8, but got I4
		return AssetBundle.LoadFromFile_Internal(bundlePath, 0u, 0uL);
	}

	public unsafe static void LoadManifest(BundleManifestData bundleManifestData, DlcType dlcType, Action<BundleManifestData> onComplete)
	{
		//IL_0042: Expected O, but got Ref
		//IL_008d: Expected I, but got O
		//IL_00b3: Expected I, but got O
		//IL_015c: Expected O, but got Ref
		//IL_00f9: Expected O, but got Ref
		nint num = default(nint);
		if ((object)bundleManifestData == null || ((UnityEngine.Object)bundleManifestData).m_CachedPtr == (IntPtr)0)
		{
			string text = ((Enum)(&num)).ToString();
			string message = "[ManifestLoader] - Manifest for " + text + " was null.";
			Debug.LogWarning(message);
			bool flag = onComplete == null;
			num = (nint)typeof(DlcType);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
				num = (nint)typeof(DlcType);
			}
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		if (loadedDlc.ContainsValue(bundleManifestData))
		{
			string text2 = ((Enum)(&num)).ToString();
			string message2 = "[ManifestLoader] - Manifest for " + text2 + " is already in the loaded dlc list.";
			Debug.LogWarning(message2);
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			string text3 = ((Enum)(&num)).ToString();
			string message3 = "[VERSION_INFO][DLC] :: " + text3 + " - " + bundleManifestData._Version;
			Debug.LogWarning(message3);
			ApplyBundleCore(dlcType, bundleManifestData, onComplete);
		}
	}

	private static void ApplyBundleCore(DlcType dlcType, BundleManifestData manifest, Action<BundleManifestData> onComplete)
	{
		//IL_018b: Expected O, but got I4
		//IL_0131: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_0151: Expected O, but got I
		//IL_005e: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		while (true)
		{
			ManifestLoader sInstance = _sInstance;
			sInstance._dataManager.MergeInJsonData(manifest._DataFiles, dlcType);
			DynamicSoundGroupCreator dynamicSoundGroup = manifest._DynamicSoundGroup;
			bool flag = (object)manifest._DynamicSoundGroup == null;
			object obj = 0;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)dynamicSoundGroup).m_CachedPtr == (IntPtr)0;
				obj = 0;
				if (!flag2)
				{
					MasterAudio instance = MasterAudio.Instance;
					GameObject gameObject = instance.gameObject;
					Transform transform = gameObject.transform;
					Transform parent = transform.parent;
					GameObject gameObject2 = manifest._DynamicSoundGroup.gameObject;
					GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2, parent);
					ManifestLoader sInstance2 = _sInstance;
					Transform transform2 = gameObject3.transform;
					sInstance2._dataManager.MergeInSFXTypes(dlcType, transform2);
					obj = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onComplete @ r8 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onComplete @ r8 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [onComplete @ r8 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v230 @ rax_v12 (should have been resolved before IL gen)");
		}
	}

	public static void DoRuntimeReload()
	{
		//IL_0263: Expected I, but got O
		//IL_008b: Expected I, but got O
		//IL_01c3: Expected I, but got O
		//IL_01f1: Expected O, but got I
		//IL_0233: Expected O, but got I
		nint num = (nint)typeof(ManifestLoader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.DLC.ManifestLoader>)+B8]");
		nint num2 = 0;
		ManifestLoader sInstance = _sInstance;
		if (_sInstance != null && sInstance._dataManager != null)
		{
			sInstance._dataManager.LoadBaseJObjects();
			sInstance._dataManager.LoadDataFromJson();
			sInstance._dataManager.ClearConvertedDlcData();
			sInstance._dataManager.BuildConvertedData();
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			bool flag = loadedDlc == null;
			num2 = unchecked((nint)null);
			if (!flag)
			{
				Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
				while (enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					DlcType dlcType = DlcType.Moonspell;
				}
				if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
				{
					return;
				}
				num2 = (nint)_sInstance;
				if (_sInstance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.ManifestLoader>)+20]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.ManifestLoader>)+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.ManifestLoader>)+20]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v14+28]");
						((AdventureManager)num3).InitDataManagerForAdventure(AdventureType.ADV_LMS_001);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
