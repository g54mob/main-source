using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.UI;

namespace VampireSurvivors.Framework.DLC;

public class DlcLoader
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<BundleManifestData> _003C_003E9__13_0;

		public static Action _003C_003E9__13_1;

		public static Action<BundleManifestData> _003C_003E9__18_0;

		public static Action<BundleManifestData> _003C_003E9__19_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CLoadDlc_003Eb__13_0(BundleManifestData bmd)
		{
			//IL_001e: Expected O, but got I4
			Debug.Log("<DLCLoader.LoadDlc> LoadManifest on complete");
			object obj = _manifestState - 2;
			bool flag = obj == null;
			DlcLoadState manifestState = (DlcLoadState)((flag ? 1 : 0) + 1);
			_manifestState = manifestState;
			_manifest = bmd;
			UpdateProgress();
		}

		internal void _003CLoadDlc_003Eb__13_1()
		{
			Debug.Log("<DLCLoader.LoadDlc> LoadSpriteLocations on complete");
			DlcLoadState spritesState;
			if (_spritesState != DlcLoadState.Error)
			{
				bool flag = _locationsState != DlcLoadState.Error;
				spritesState = DlcLoadState.Complete;
				if (flag)
				{
					goto IL_006a;
				}
			}
			spritesState = DlcLoadState.Error;
			goto IL_006a;
			IL_006a:
			_spritesState = spritesState;
			UpdateProgress();
		}

		internal void _003CLoadManifest_003Eb__18_0(BundleManifestData data)
		{
		}

		internal void _003CLoadBundleManifestData_003Eb__19_0(BundleManifestData data)
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public Action<BundleManifestData> onComplete;

		internal void _003CLoadManifest_003Eb__1(IList<BundleManifestData> result)
		{
			Debug.Log("<DLCLoader.LoadManifest> async load suceeded");
			if (result != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj = default(object);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99DF0");
					DlcType dlcType = DlcType;
					BundleManifestData bundleManifestData = default(BundleManifestData);
					ManifestLoader.LoadManifest(bundleManifestData, dlcType, onComplete);
					return;
				}
			}
			Action<BundleManifestData> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ rax_v5 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CLoadManifest_003Eb__2(IList<BundleManifestData> _)
		{
			Debug.Log("<DLCLoader.LoadManifest> async load failed");
			_manifestState = DlcLoadState.Error;
			Action<BundleManifestData> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v54 @ rax_v5 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public Action<BundleManifestData> onComplete;

		internal void _003CLoadBundleManifestData_003Eb__1(IList<BundleManifestData> result)
		{
			//IL_006f: Expected O, but got I
			//IL_007f: Expected O, but got I
			//IL_008f: Expected O, but got I
			if (result != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj = default(object);
				if (obj != null)
				{
					Action<BundleManifestData> action = onComplete;
					if (onComplete == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99DF0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+28]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+40]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v122 @ rax_v8 (should have been resolved before IL gen)");
				}
			}
			Action<BundleManifestData> action2 = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ rax_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
			}
		}

		internal void _003CLoadBundleManifestData_003Eb__2(IList<BundleManifestData> _)
		{
			_manifestState = DlcLoadState.Error;
			Action<BundleManifestData> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v32 @ rax_v3 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public Action onComplete;

		public AsyncOperationHandle<IList<IResourceLocation>> locationOp;

		internal void _003CLoadSpriteLocations_003Eb__0(IList<IResourceLocation> result)
		{
			//IL_00cf: Expected I, but got O
			nint num = (nint)typeof(DlcLoader);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v7 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
			nint num2 = 0;
			if ((object)_dlcType != null)
			{
				DlcUtils utils = DlcSystem._utils;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v2 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
				string persistentLabel = utils.GetPersistentLabel(DlcType.Moonspell);
				string message = "<DLCLoader.LoadSpriteLocations> Async load suceeded Path: " + persistentLabel;
				Debug.Log(message);
				_locationsState = DlcLoadState.Complete;
				if (result != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					int totalLocations = default(int);
					_totalLocations = totalLocations;
					LoadSprites(result, onComplete);
				}
				AsyncOperationHandle<object> asyncOperationHandle = default(AsyncOperationHandle<object>);
				asyncOperationHandle.Release();
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			throw new NullReferenceException();
		}

		internal void _003CLoadSpriteLocations_003Eb__1(IList<IResourceLocation> _)
		{
			Debug.Log("<DLCLoader.LoadSpriteLocations> failed to async load");
			_locationsState = DlcLoadState.Error;
			AsyncOperationHandle<object> asyncOperationHandle = default(AsyncOperationHandle<object>);
			asyncOperationHandle.Release();
			Action action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v105.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public Action onComplete;

		public Action<IList<Sprite>> _003C_003E9__0;

		public Action<IList<Sprite>> _003C_003E9__1;

		internal void _003CLoadSprites_003Eb__0(IList<Sprite> result)
		{
			//IL_0084: Expected O, but got I
			bool flag = result == null;
			IntPtr intPtr = default(IntPtr);
			IEnumerable<object> enumerable = (IEnumerable<object>)(nint)intPtr;
			if (!flag)
			{
				List<object> sprites = (List<object>)(object)_sprites;
				List<object> list = new List<object>(result);
				((List<object>)(object)_sprites).InsertRange(sprites._size, (IEnumerable<object>)list);
				enumerable = list;
			}
			Action action = onComplete;
			int completedLocations = _completedLocations + 1;
			_completedLocations = completedLocations;
			if (_completedLocations >= _totalLocations)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		internal void _003CLoadSprites_003Eb__1(IList<Sprite> _)
		{
			_spritesState = DlcLoadState.Error;
			Action action = onComplete;
			int completedLocations = _completedLocations + 1;
			_completedLocations = completedLocations;
			if (_completedLocations >= _totalLocations)
			{
				IntPtr method = ((Delegate)action).method;
				IntPtr method_code = ((Delegate)action).method_code;
				IntPtr invoke_impl = ((Delegate)action).invoke_impl;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ rax_v7 (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass23_0<T>
	{
		public AsyncOperationHandle<T> operationHandle;

		public string errorPrefix;

		public Action<T> onError;

		public Action<T> onComplete;

		internal unsafe void _003CWaitForAsyncLoad_003Eg__OnAsyncLoadComplete_007C0(AsyncOperationHandle<T> handle)
		{
			//IL_0031: Expected O, but got I
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_00ff: Expected O, but got I
			//IL_0095: Expected O, but got I
			//IL_0121: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v1 (Il2CppRgctx<VampireSurvivors.Framework.DLC.DlcLoader+<>c__DisplayClass23_0`1>)+10]");
			Action<AsyncOperationHandle<object>> value = new Action<AsyncOperationHandle<object>>(this, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v1 (Il2CppRgctx<VampireSurvivors.Framework.DLC.DlcLoader+<>c__DisplayClass23_0`1>)+20]");
			string text = (string)0;
			AsyncOperationHandle<object> asyncOperationHandle = (AsyncOperationHandle<object>)(this + 16);
			((AsyncOperationHandle<object>*)asyncOperationHandle)->Completed -= value;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
			object obj = default(object);
			object obj2;
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.DLC.DlcLoader+<>c__DisplayClass23_0`1<T>)+38]");
				obj2 = 0;
			}
			else
			{
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
				object obj4 = default(object);
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v174 @ rdx_v11+188] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.DLC.DlcLoader+<>c__DisplayClass23_0`1<T>)+28]");
				string text2 = default(string);
				string message = "[" + (string)0 + "] - " + text2;
				Debug.LogError(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.DLC.DlcLoader+<>c__DisplayClass23_0`1<T>)+30]");
				obj2 = 0;
				text = text2;
			}
			if (obj2 != null)
			{
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184132A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v106 @ rbx_v2+18] (should have been resolved before IL gen)");
			}
		}
	}

	private static Action<BundleManifestData> _onComplete;

	private static DlcType? _dlcType;

	private static int _initialProgress;

	private static int _totalLocations;

	private static int _completedLocations;

	private static List<Sprite> _sprites;

	private static BundleManifestData _manifest;

	private static DlcLoadState _spritesState;

	private static DlcLoadState _locationsState;

	private static DlcLoadState _manifestState;

	private static DlcType DlcType
	{
		get
		{
			//IL_002a: Expected I, but got O
			nint num = (nint)typeof(DlcLoader);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
			nint num2 = 0;
			if ((object)_dlcType != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v3 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
				return DlcType.Moonspell;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			DlcType result = default(DlcType);
			return result;
		}
	}

	public static void ResetLoader()
	{
		//IL_0014: Expected O, but got I4
		_totalLocations = 0;
		_completedLocations = 0;
		List<Sprite> sprites = new List<Sprite>();
		_sprites = sprites;
		int initialProgress = UnityEngine.Random.RandomRangeInt(10, 20);
		_initialProgress = initialProgress;
		_onComplete = null;
		_dlcType = (DlcType?)(object)0;
		_spritesState = DlcLoadState.Loading;
		_locationsState = DlcLoadState.Loading;
		_manifestState = DlcLoadState.Loading;
	}

	public unsafe static void LoadDlc(DlcType dlcType, Action<BundleManifestData> onComplete)
	{
		//IL_00b8: Expected O, but got Ref
		//IL_0022: Expected O, but got I4
		//IL_00e1: Expected I, but got O
		//IL_0059: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		string message = "<DLCLoader.LoadDlc> dlcType:" + text;
		Debug.Log(message);
		ResetLoader();
		_dlcType = (DlcType?)(object)1;
		_onComplete = onComplete;
		UpdateProgress();
		nint num = (nint)typeof(DlcLoader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v14 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
		nint num2 = 0;
		if ((object)_dlcType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v11 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
			AddressableLoader.PointAtDlc(DlcType.Moonspell);
			string text2 = ((Enum)(&intPtr)).ToString();
			string message2 = "<DLCLoader.LoadDlc> pointed At DLC " + text2;
			Debug.Log(message2);
			Action<BundleManifestData> onComplete2 = _003C_003Ec._003C_003E9__13_0;
			if (_003C_003Ec._003C_003E9__13_0 == null)
			{
				onComplete2 = (_003C_003Ec._003C_003E9__13_0 = delegate(BundleManifestData bmd)
				{
					//IL_001e: Expected O, but got I4
					Debug.Log("<DLCLoader.LoadDlc> LoadManifest on complete");
					object obj = _manifestState - 2;
					bool flag = obj == null;
					DlcLoadState manifestState = (DlcLoadState)((flag ? 1 : 0) + 1);
					_manifestState = manifestState;
					_manifest = bmd;
					UpdateProgress();
				});
			}
			LoadManifest(onComplete2);
			Action onComplete3 = _003C_003Ec._003C_003E9__13_1;
			if (_003C_003Ec._003C_003E9__13_1 == null)
			{
				onComplete3 = (_003C_003Ec._003C_003E9__13_1 = delegate
				{
					Debug.Log("<DLCLoader.LoadDlc> LoadSpriteLocations on complete");
					DlcLoadState spritesState;
					if (_spritesState != DlcLoadState.Error)
					{
						bool flag = _locationsState != DlcLoadState.Error;
						spritesState = DlcLoadState.Complete;
						if (flag)
						{
							goto IL_006a;
						}
					}
					spritesState = DlcLoadState.Error;
					goto IL_006a;
					IL_006a:
					_spritesState = spritesState;
					UpdateProgress();
				});
			}
			LoadSpriteLocations(onComplete3);
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	private static void LoadDlcComplete()
	{
		Debug.Log("<DLCLoader.LoadDlcComplete> called");
		if (_locationsState != DlcLoadState.Error && _spritesState != DlcLoadState.Error)
		{
			Sprite[] rawSprites = _sprites.ToArray();
			SpriteManager.RegisterSprites(rawSprites);
		}
		List<Sprite> sprites = _sprites;
		int version = sprites._version + 1;
		sprites._version = version;
		sprites._size = 0;
		if (sprites._size > 0)
		{
			Array.Clear(sprites._items, 0, sprites._size);
		}
		bool flag = _manifestState == DlcLoadState.Error;
		BundleManifestData bundleManifestData = null;
		if (!flag)
		{
			bool flag2 = _locationsState == DlcLoadState.Error;
			bundleManifestData = null;
			if (!flag2)
			{
				bool flag3 = _spritesState == DlcLoadState.Error;
				bundleManifestData = null;
				if (!flag3)
				{
					bundleManifestData = _manifest;
				}
			}
		}
		Action<BundleManifestData> onComplete = _onComplete;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v150 @ r9_v2 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
	}

	private unsafe static void UpdateProgress()
	{
		//IL_00c3: Expected I, but got O
		//IL_0086: Expected I, but got O
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected I4, but got Unknown
		//IL_0127: Expected I, but got O
		//IL_029a: Expected O, but got I
		//IL_02b9: Expected O, but got I
		//IL_020d: Expected O, but got Ref
		//IL_0230: Expected O, but got I
		Debug.Log("<DLCLoader.UpdateProgress> called");
		int num = _initialProgress;
		if (_manifestState == DlcLoadState.Complete || _manifestState == DlcLoadState.Error)
		{
			num = 50;
		}
		nint num2;
		if (_locationsState != DlcLoadState.Complete)
		{
			bool flag = _locationsState != DlcLoadState.Error;
			num2 = (nint)typeof(DlcLoader);
			if (flag)
			{
				goto IL_0451;
			}
		}
		num += 10;
		bool flag2 = _totalLocations <= 0;
		num2 = (nint)typeof(DlcLoader);
		if (!flag2)
		{
			float num3 = (float)_completedLocations * 100f;
			float num4 = num3 / (float)_totalLocations;
			float num5 = num4 * 0.4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			object obj = default(object);
			num += obj;
			num2 = (nint)typeof(DlcLoader);
		}
		goto IL_0451;
		IL_0451:
		if ((_manifestState != DlcLoadState.Complete && _manifestState != DlcLoadState.Error) || (_locationsState != DlcLoadState.Complete && _locationsState != DlcLoadState.Error) || (_spritesState != DlcLoadState.Complete && _spritesState != DlcLoadState.Error))
		{
			DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rdx_v12 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
			nint num6 = 0;
			if ((object)_dlcType == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			DlcDataDictionary dlcData = dlcCatalog._DlcData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v13 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dlcData).get_Item((System.Int32Enum)0);
			object obj3 = default(object);
			string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj3), null);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v20 (System.Object)+18]");
			string text2 = (string)0 + " (" + text + "%)";
			if (PreloaderEvents.UpdateExtraText == null)
			{
				return;
			}
			Action<string> updateExtraText = PreloaderEvents.UpdateExtraText;
			string text3 = text2;
		}
		else
		{
			Debug.Log("<DLCLoader.UpdateProgress> load has completed");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B58C00");
			DlcType dlcType = DlcType;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v42+18]");
			object obj4 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)dlcType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rax_v44 (System.Object)+18]");
			string text4 = (string)0 + " (100%)";
			PreloaderEvents.FireUpdateExtraText(text4);
			Debug.Log("<DLCLoader.LoadDlcComplete> called");
			if (_locationsState != DlcLoadState.Error && _spritesState != DlcLoadState.Error)
			{
				Sprite[] rawSprites = _sprites.ToArray();
				SpriteManager.RegisterSprites(rawSprites);
			}
			List<Sprite> sprites = _sprites;
			int version = sprites._version + 1;
			sprites._version = version;
			sprites._size = 0;
			if (sprites._size > 0)
			{
				Array.Clear(sprites._items, 0, sprites._size);
			}
			bool flag3 = _manifestState == DlcLoadState.Error;
			string text3 = null;
			if (!flag3)
			{
				bool flag4 = _locationsState == DlcLoadState.Error;
				text3 = null;
				if (!flag4)
				{
					bool flag5 = _spritesState == DlcLoadState.Error;
					text3 = null;
					if (!flag5)
					{
						text3 = (string)(object)_manifest;
					}
				}
			}
			bool flag6 = _onComplete != null;
			Action<string> updateExtraText = (Action<string>)_onComplete;
			if (!flag6)
			{
				throw new NullReferenceException();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ r9_v1 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
	}

	private static bool IsTaskDone(DlcLoadState task)
	{
		//IL_0033: Expected O, but got I4
		if (task == DlcLoadState.Complete)
		{
			return (byte)task != 0;
		}
		object obj = task - 2;
		return obj == null;
	}

	private static bool DidTaskError(DlcLoadState task)
	{
		//IL_000e: Expected O, but got I4
		object obj = task - 2;
		return obj == null;
	}

	private unsafe static void LoadManifest(Action<BundleManifestData> onComplete)
	{
		//IL_00fc: Expected I, but got O
		//IL_0099: Expected O, but got Ref
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass18_0();
		CS_0024_003C_003E8__locals6.onComplete = onComplete;
		Debug.Log("<DLCLoader.LoadManifest> called");
		nint num = (nint)typeof(DlcLoader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v15 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
		nint num2 = 0;
		if ((object)_dlcType != null)
		{
			DlcUtils utils = DlcSystem._utils;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v5 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
			string persistentLabel = utils.GetPersistentLabel(DlcType.Moonspell);
			Action<BundleManifestData> action = _003C_003Ec._003C_003E9__18_0;
			if (_003C_003Ec._003C_003E9__18_0 == null)
			{
				action = (_003C_003Ec._003C_003E9__18_0 = delegate
				{
				});
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99C10");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183C33A10");
			object obj = default(object);
			AddressableCache.PersistentOperationHandles.Add((AsyncOperationHandle)(&obj));
			Action<IList<BundleManifestData>> action2 = delegate(IList<BundleManifestData> result)
			{
				Debug.Log("<DLCLoader.LoadManifest> async load suceeded");
				if (result != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj2 = default(object);
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99DF0");
						DlcType dlcType = DlcType;
						BundleManifestData bundleManifestData = default(BundleManifestData);
						ManifestLoader.LoadManifest(bundleManifestData, dlcType, CS_0024_003C_003E8__locals6.onComplete);
						return;
					}
				}
				Action<BundleManifestData> onComplete2 = CS_0024_003C_003E8__locals6.onComplete;
				if (CS_0024_003C_003E8__locals6.onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ rax_v5 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
				}
			};
			Action<IList<BundleManifestData>> action3 = delegate
			{
				Debug.Log("<DLCLoader.LoadManifest> async load failed");
				_manifestState = DlcLoadState.Error;
				Action<BundleManifestData> onComplete2 = CS_0024_003C_003E8__locals6.onComplete;
				if (CS_0024_003C_003E8__locals6.onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v54 @ rax_v5 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD3980");
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	public unsafe static void LoadBundleManifestData(DlcType dlcType, Action<BundleManifestData> onComplete)
	{
		//IL_007d: Expected O, but got Ref
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals7.onComplete = onComplete;
		string persistentLabel = DlcSystem._utils.GetPersistentLabel(dlcType);
		Action<BundleManifestData> action = _003C_003Ec._003C_003E9__19_0;
		if (_003C_003Ec._003C_003E9__19_0 == null)
		{
			action = (_003C_003Ec._003C_003E9__19_0 = delegate
			{
			});
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99C10");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183C33A10");
		object obj = default(object);
		AddressableCache.PersistentOperationHandles.Add((AsyncOperationHandle)(&obj));
		Action<IList<BundleManifestData>> action2 = delegate(IList<BundleManifestData> result)
		{
			//IL_006f: Expected O, but got I
			//IL_007f: Expected O, but got I
			//IL_008f: Expected O, but got I
			if (result != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj2 = default(object);
				if (obj2 != null)
				{
					Action<BundleManifestData> onComplete2 = CS_0024_003C_003E8__locals7.onComplete;
					if (CS_0024_003C_003E8__locals7.onComplete == null)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99DF0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+28]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+40]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v122 @ rax_v8 (should have been resolved before IL gen)");
				}
			}
			Action<BundleManifestData> onComplete3 = CS_0024_003C_003E8__locals7.onComplete;
			if (CS_0024_003C_003E8__locals7.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v74 @ rax_v4 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
			}
		};
		Action<IList<BundleManifestData>> action3 = delegate
		{
			_manifestState = DlcLoadState.Error;
			Action<BundleManifestData> onComplete2 = CS_0024_003C_003E8__locals7.onComplete;
			if (CS_0024_003C_003E8__locals7.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v32 @ rax_v3 (System.Action`1<VampireSurvivors.Framework.DLC.BundleManifestData>)+18] (should have been resolved before IL gen)");
			}
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD3980");
	}

	private unsafe static void LoadSpriteLocations(Action onComplete)
	{
		//IL_0115: Expected I, but got O
		//IL_0156: Expected I, but got O
		//IL_0096: Expected O, but got Ref
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals5.onComplete = onComplete;
		nint num = (nint)typeof(DlcLoader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v13 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
		nint num2 = 0;
		if ((object)_dlcType != null)
		{
			DlcUtils utils = DlcSystem._utils;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v4 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
			string persistentLabel = utils.GetPersistentLabel(DlcType.Moonspell);
			string message = "<DLCLoader.LoadSpriteLocations> called   DlcSystem.Utils.GetPersistentLabel(DlcType): " + persistentLabel;
			Debug.Log(message);
			nint num3 = (nint)typeof(DlcLoader);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v23 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
			nint num4 = 0;
			if ((object)_dlcType != null)
			{
				DlcUtils utils2 = DlcSystem._utils;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v8 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
				string persistentLabel2 = utils2.GetPersistentLabel(DlcType.Moonspell);
				AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle2 = default(AsyncOperationHandle<IList<IResourceLocation>>);
				AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = (CS_0024_003C_003E8__locals5.locationOp = Addressables.LoadResourceLocationsAsync((object)(&asyncOperationHandle2), (Type)(object)persistentLabel2));
				_ = asyncOperationHandle.m_InternalOp;
				Action<IList<IResourceLocation>> action = delegate(IList<IResourceLocation> result)
				{
					//IL_00cf: Expected I, but got O
					nint num5 = (nint)typeof(DlcLoader);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v7 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcLoader>)+B8]");
					nint num6 = 0;
					if ((object)_dlcType != null)
					{
						DlcUtils utils3 = DlcSystem._utils;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v2 (Il2CppStaticFields<VampireSurvivors.Framework.DLC.DlcLoader>)+C]");
						string persistentLabel3 = utils3.GetPersistentLabel(DlcType.Moonspell);
						string message2 = "<DLCLoader.LoadSpriteLocations> Async load suceeded Path: " + persistentLabel3;
						Debug.Log(message2);
						_locationsState = DlcLoadState.Complete;
						if (result != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							int totalLocations = default(int);
							_totalLocations = totalLocations;
							LoadSprites(result, CS_0024_003C_003E8__locals5.onComplete);
						}
						AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
						asyncOperationHandle3.Release();
						return;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					throw new NullReferenceException();
				};
				Action<IList<IResourceLocation>> action2 = delegate
				{
					Debug.Log("<DLCLoader.LoadSpriteLocations> failed to async load");
					_locationsState = DlcLoadState.Error;
					AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
					asyncOperationHandle3.Release();
					Action onComplete2 = CS_0024_003C_003E8__locals5.onComplete;
					if (CS_0024_003C_003E8__locals5.onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v105.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD3980");
				return;
			}
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private static void IncrementAndCheckIfAllSpritesAreLoaded(Action onComplete)
	{
		int completedLocations = _completedLocations + 1;
		_completedLocations = completedLocations;
		if (_completedLocations >= _totalLocations)
		{
			IntPtr method = ((Delegate)onComplete).method;
			IntPtr method_code = ((Delegate)onComplete).method_code;
			IntPtr invoke_impl = ((Delegate)onComplete).invoke_impl;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ rax_v5 (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private unsafe static void LoadSprites(IList<IResourceLocation> locations, Action onComplete)
	{
		//IL_0029: Expected O, but got Ref
		//IL_0084: Expected I, but got O
		//IL_0117: Expected O, but got I4
		//IL_00bc: Expected O, but got I
		//IL_00c5: Expected O, but got I4
		//IL_01b7: Expected O, but got I4
		//IL_0210: Expected O, but got I
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_015c: Expected O, but got I
		//IL_0165: Expected O, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_0253: Expected O, but got I
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_02ab: Expected I, but got O
		//IL_02e6: Expected O, but got Ref
		//IL_03c3: Expected I, but got O
		//IL_03cb: Expected O, but got Ref
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals10.onComplete = onComplete;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Action action = default(Action);
		object obj = (object)(&action);
		Action action2 = null;
		object obj2 = default(object);
		object obj12 = default(object);
		object obj14 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		object obj18 = default(object);
		object obj19 = default(object);
		object obj21 = default(object);
		while (true)
		{
			object obj10;
			object obj3;
			if (action != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj2 != null)
				{
					bool flag = action == null;
					action2 = null;
					if (flag)
					{
						break;
					}
					nint num = (nint)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r10_v5 (Il2CppClass<System.Action>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_00fc;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r10_v5 (Il2CppClass<System.Action>)+B0]");
					obj3 = 0;
					object obj4 = 0;
					while (true)
					{
						object obj5 = obj4 + obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ r8_v10+v465 @ rax_v59*8]");
						if (0 == (nint)typeof(IEnumerator<IResourceLocation>))
						{
							break;
						}
						obj4++;
						object obj6 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r10_v5 (Il2CppClass<System.Action>)+12E]");
						if ((nint)obj6 < 0)
						{
							continue;
						}
						goto IL_00fc;
					}
					object obj7 = obj4 + obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ r8_v10+8+v527 @ rcx_v51*8]");
					object obj8 = (nint)0 << 4;
					object obj9 = obj8 + 312;
					obj10 = obj9 + num;
					goto IL_04c7;
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return;
			}
			throw new NullReferenceException();
			IL_019c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj11 = obj12;
			object obj13 = 8;
			goto IL_04d6;
			IL_00fc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj10 = obj14;
			obj3 = 0;
			goto IL_04c7;
			IL_04d6:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v630 @ rdx_v14] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj15 = obj16 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			nint num2;
			if (obj17 != obj18)
			{
				IncrementAndCheckIfAllSpritesAreLoaded(CS_0024_003C_003E8__locals10.onComplete);
				num2 = (nint)typeof(IResourceLocation);
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F971F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183C33A10");
			AddressableCache.SavePersistentHandle((AsyncOperationHandle)(&obj19));
			Action<IList<Sprite>> action3 = CS_0024_003C_003E8__locals10._003C_003E9__0;
			if (CS_0024_003C_003E8__locals10._003C_003E9__0 == null)
			{
				action3 = (CS_0024_003C_003E8__locals10._003C_003E9__0 = delegate(IList<Sprite> result)
				{
					//IL_0084: Expected O, but got I
					bool flag2 = result == null;
					IntPtr intPtr = default(IntPtr);
					IEnumerable<object> enumerable = (IEnumerable<object>)(nint)intPtr;
					if (!flag2)
					{
						List<object> sprites = (List<object>)(object)_sprites;
						List<object> list = new List<object>(result);
						((List<object>)(object)_sprites).InsertRange(sprites._size, (IEnumerable<object>)list);
						enumerable = list;
					}
					Action onComplete2 = CS_0024_003C_003E8__locals10.onComplete;
					int completedLocations = _completedLocations + 1;
					_completedLocations = completedLocations;
					if (_completedLocations >= _totalLocations)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v115.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			Action<IList<Sprite>> action4 = CS_0024_003C_003E8__locals10._003C_003E9__1;
			if (CS_0024_003C_003E8__locals10._003C_003E9__1 == null)
			{
				action4 = (CS_0024_003C_003E8__locals10._003C_003E9__1 = delegate
				{
					_spritesState = DlcLoadState.Error;
					Action onComplete2 = CS_0024_003C_003E8__locals10.onComplete;
					int completedLocations = _completedLocations + 1;
					_completedLocations = completedLocations;
					if (_completedLocations >= _totalLocations)
					{
						IntPtr method = ((Delegate)onComplete2).method;
						IntPtr method_code = ((Delegate)onComplete2).method_code;
						IntPtr invoke_impl = ((Delegate)onComplete2).invoke_impl;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ rax_v7 (System.IntPtr) (should have been resolved before IL gen)");
					}
				});
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FD3980");
			num2 = unchecked((nint)"LoadSpriteAsync");
			action2 = (Action)(&obj19);
			continue;
			IL_04c7:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v532 @ rdx_v11] (should have been resolved before IL gen)");
			object obj20 = obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ r10_v6+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_019c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ r10_v6+B0]");
			obj13 = 0;
			object obj22 = 0;
			while (true)
			{
				object obj23 = obj22 + obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ r8_v11+v567 @ rax_v54*8]");
				if (0 == (nint)typeof(IResourceLocation))
				{
					break;
				}
				obj22++;
				object obj24 = obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ r10_v6+12E]");
				if ((nint)obj24 < 0)
				{
					continue;
				}
				goto IL_019c;
			}
			object obj25 = obj22 + obj22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ r8_v11+8+v623 @ rcx_v43*8]");
			object obj26 = (nint)0 + (nint)8;
			object obj27 = obj26 << 4;
			object obj28 = obj27 + 312;
			obj11 = obj28 + obj20;
			goto IL_04d6;
		}
		throw new NullReferenceException();
	}

	private unsafe static void WaitForAsyncLoad<T>(AsyncOperationHandle<T> operationHandle, Action<T> onComplete, Action<T> onError, string errorPrefix = "WaitForAsyncLoad")
	{
		//IL_006f: Expected O, but got I
		//IL_0151: Expected O, but got I
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0119: Expected O, but got I
		//IL_00b1: Expected O, but got I
		//IL_00d0: Expected O, but got I
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
		object obj = 0;
		object obj2 = null;
		_ = operationHandle.m_InternalOp;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
		object obj3 = 0;
		if (!AddressableLoader.UseSyncLoad)
		{
			object obj4 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18330E270");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
			object obj6 = 0;
			object obj7 = obj2 + 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184131E30");
		}
		else
		{
			AsyncOperationHandle<object> asyncOperationHandle = (AsyncOperationHandle<object>)(obj2 + 16);
			object obj8 = ((AsyncOperationHandle<object>*)asyncOperationHandle)->WaitForCompletion();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_28+38]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832F6EA0");
		}
	}
}
