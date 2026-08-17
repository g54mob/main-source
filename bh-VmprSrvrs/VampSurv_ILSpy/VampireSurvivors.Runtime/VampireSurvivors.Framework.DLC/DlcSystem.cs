using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.UI;

namespace VampireSurvivors.Framework.DLC;

public static class DlcSystem
{
	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public Action callback;

		internal unsafe void _003CLicenseCheckDlc_003Eb__0()
		{
			LicenseManager._003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals5 = new LicenseManager._003C_003Ec__DisplayClass14_0();
			CS_0024_003C_003E8__locals5._003C_003E4__this = _licenseManager;
			CS_0024_003C_003E8__locals5.callback = callback;
			SystemPlatform sInstance = SystemPlatform.sInstance;
			Action<List<DlcType>> onComplete = delegate
			{
				//IL_000f: Expected I, but got O
				//IL_0072: Expected O, but got I
				//IL_0226: Expected I, but got O
				//IL_0080: Unknown result type (might be due to invalid IL or missing references)
				//IL_0085: Expected O, but got Unknown
				//IL_008e: Expected O, but got Ref
				//IL_010a: Expected O, but got I4
				//IL_0113: Expected O, but got I4
				//IL_01b4: Expected I, but got O
				//IL_0131: Expected O, but got I
				//IL_016c: Expected O, but got I4
				//IL_0182: Expected O, but got I
				nint num = unchecked((nint)null);
				object obj = default(object);
				object obj2 = default(object);
				object obj4 = default(object);
				IntPtr intPtr = default(IntPtr);
				nint num3 = default(nint);
				object obj9 = default(object);
				while (true)
				{
					if (obj == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
					if (obj2 != null)
					{
						break;
					}
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+18]");
					if ((nint)obj3 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+10]");
					object obj5 = 0;
					object obj6 = obj4 + 1;
					string text = ((Enum)(&intPtr)).ToString();
					string text2 = "DLC: " + text + " is available to user.";
					string message = "[DlcSystem] - " + text2;
					Debug.Log(message);
					LicenseManager licenseManager = CS_0024_003C_003E8__locals5._003C_003E4__this;
					List<DlcType> list = licenseManager._003CAvailableDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					bool flag = (nint)0 == 0;
					nint num2 = num3;
					object obj7 = 0;
					object obj8 = 0;
					object obj10;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag2 = (nint)obj9 != -1;
						num2 = 0;
						obj8 = 0;
						num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj10 = 0;
						obj4 = obj6;
						if (flag2)
						{
							continue;
						}
					}
					LicenseManager licenseManager2 = CS_0024_003C_003E8__locals5._003C_003E4__this;
					num = (nint)licenseManager2._003CAvailableDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					num3 = num2;
					obj10 = obj7;
					obj4 = obj6;
				}
				bool flag3 = obj == null;
				num = 0;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
					if (obj2 == null)
					{
						Action action = CS_0024_003C_003E8__locals5.callback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v112.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						return;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num = unchecked((nint)null);
				}
				throw new NullReferenceException();
			};
			sInstance.m_CurrentSystem.GetAvailableDlc(onComplete);
		}
	}

	private sealed class _003C_003Ec__DisplayClass33_0
	{
		public Action callback;

		internal void _003CLoadDlc_003Eb__0()
		{
			//IL_0018: Expected I, but got O
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			//IL_0080: Expected O, but got I
			nint num = (nint)typeof(DlcType);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			if (num != 0)
			{
				object obj3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
				DlcType[] array = default(DlcType[]);
				if (array != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (array == null)
					{
						throw new InvalidCastException();
					}
				}
				_loadingManager.ValidateVersion(0, array, callback);
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("enumType");
			ex._002Ector("enumType");
			throw ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public Action onRetry;

		public Action onContinue;

		internal void _003CShowDlcDownloadError_003Eb__0()
		{
			Action action = onRetry;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}

		internal void _003CShowDlcDownloadError_003Eb__1()
		{
			Action action = onContinue;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static DlcCatalog _dlcCatalog;

	public static bool _initialised;

	private static LicenseManager _licenseManager;

	private static LoadingManager _loadingManager;

	private static UpdateManager _updateManager;

	private static DlcUtils _utils;

	private const string DlcDownloadPopupId = "download-dlc";

	private const string DlcErrorPopupId = "error-dlc";

	private const string SelectedDlcKey = "selecteddlc";

	private static DLCSelection _dlcSelection;

	public static List<DlcType> OnlineAvaliableDlcTypes;

	public const string PreviouslyExitedUnsafelyKey = "PREVIOUSLYEXITEDUNSAFELY";

	public const string PERSISTENT_TAG = "persistent";

	public const string DYNAMIC_TAG = "dynamic";

	public const string LOCAL_GROUP = "vs_local";

	public static DlcCatalog DlcCatalog => _dlcCatalog;

	public static DlcUtils Utils => _utils;

	public static List<DlcType> OwnedDlc
	{
		get
		{
			if (!_initialised)
			{
				return new List<DlcType>();
			}
			LicenseManager licenseManager = _licenseManager;
			if (_licenseManager != null)
			{
				return licenseManager._003COwnedDlc_003Ek__BackingField;
			}
			return (List<DlcType>)(object)new NullReferenceException();
		}
	}

	public static List<DlcType> IncludedDlc
	{
		get
		{
			if (!_initialised)
			{
				return new List<DlcType>();
			}
			LicenseManager licenseManager = _licenseManager;
			if (_licenseManager != null)
			{
				return licenseManager._003CIncludedDlc_003Ek__BackingField;
			}
			return (List<DlcType>)(object)new NullReferenceException();
		}
	}

	public static SelectedDLCDictionary SelectedDlc
	{
		get
		{
			DLCSelection dlcSelection = _dlcSelection;
			if (_dlcSelection != null)
			{
				return dlcSelection.SelectedDLCs;
			}
			return (SelectedDLCDictionary)(object)new NullReferenceException();
		}
	}

	public static Dictionary<DlcType, BundleManifestData> LoadedDlc
	{
		get
		{
			if (!_initialised)
			{
				return new Dictionary<DlcType, BundleManifestData>();
			}
			LoadingManager loadingManager = _loadingManager;
			if (_loadingManager != null)
			{
				return loadingManager._003CLoadedDlc_003Ek__BackingField;
			}
			return (Dictionary<DlcType, BundleManifestData>)(object)new NullReferenceException();
		}
	}

	public static Dictionary<DlcType, string> MountedPaths
	{
		get
		{
			if (!_initialised)
			{
				return new Dictionary<DlcType, string>();
			}
			LoadingManager loadingManager = _loadingManager;
			if (_loadingManager != null)
			{
				return loadingManager._003CMountedPaths_003Ek__BackingField;
			}
			return (Dictionary<DlcType, string>)(object)new NullReferenceException();
		}
	}

	public static void Init(DlcCatalog catalog)
	{
		//IL_0194: Expected O, but got I
		//IL_0669: Expected I, but got O
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_0277: Expected O, but got I
		//IL_01ef: Expected O, but got I4
		//IL_0967: Expected O, but got I
		//IL_028f: Expected I, but got O
		//IL_04c9: Expected O, but got I
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected O, but got Unknown
		//IL_0558: Expected O, but got I
		//IL_0570: Expected I, but got O
		//IL_02ff: Expected O, but got I
		//IL_06ca: Expected I, but got O
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_03e1: Expected O, but got I
		//IL_0359: Expected O, but got I4
		//IL_05e0: Expected O, but got I
		//IL_0760: Expected I, but got O
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Expected O, but got Unknown
		if (_initialised)
		{
			return;
		}
		Debug.Log("Initializing DLCSystem");
		_dlcCatalog = catalog;
		LicenseManager licenseManager = new LicenseManager();
		List<DlcType> list = new List<DlcType>();
		licenseManager._003COwnedDlc_003Ek__BackingField = list;
		List<DlcType> list2 = new List<DlcType>();
		licenseManager._003CIncludedDlc_003Ek__BackingField = list2;
		List<DlcType> list3 = new List<DlcType>();
		licenseManager._003CAvailableDlc_003Ek__BackingField = list3;
		_licenseManager = licenseManager;
		LoadingManager loadingManager = new LoadingManager();
		Dictionary<DlcType, string> dictionary = new Dictionary<DlcType, string>();
		loadingManager._003CMountedPaths_003Ek__BackingField = dictionary;
		Dictionary<DlcType, BundleManifestData> dictionary2 = new Dictionary<DlcType, BundleManifestData>();
		loadingManager._003CLoadedDlc_003Ek__BackingField = dictionary2;
		_loadingManager = loadingManager;
		UpdateManager updateManager = new UpdateManager();
		_updateManager = updateManager;
		DlcUtils utils = new DlcUtils();
		_utils = utils;
		_initialised = true;
		string text = PlayerPrefs.GetString("selecteddlc", "");
		object obj2 = default(object);
		object obj4 = default(object);
		if (text != null && text._stringLength > 0)
		{
			string message = "Selected DLC loaded from player prefs: " + text;
			Debug.Log(message);
			DLCSelection dlcSelection = JsonUtility.FromJson<DLCSelection>(text);
			_dlcSelection = dlcSelection;
			List<DlcType> ownedDlc = OwnedDlc;
			object obj = default(object);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ stack_-30_v24+1C]");
					if (obj2 == null)
					{
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ stack_-30_v24+18]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ stack_-30_v24+10]");
							object obj5 = 0;
							object obj6 = obj4 + 1;
							DLCSelection dlcSelection2 = _dlcSelection;
							bool flag = dlcSelection2.SelectedDLCs == null;
							SelectedDLCDictionary selectedDLCs = dlcSelection2.SelectedDLCs;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1878 @ rdx_v101+20+v2786 @ stack_-28_v5*4]");
							int num = ((Dictionary<DlcType, bool>)selectedDLCs).FindEntry(DlcType.Moonspell);
							object obj7 = !flag;
							obj4 = obj6;
							if (obj7 == null)
							{
								DLCSelection dlcSelection3 = _dlcSelection;
								SelectedDLCDictionary selectedDLCs2 = dlcSelection3.SelectedDLCs;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1878 @ rdx_v101+20+v2085 @ rcx_v176*4]");
								int num2 = ((Dictionary<DlcType, bool>)selectedDLCs2).FindEntry(DlcType.Moonspell);
								obj4 = obj6;
							}
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag2 = obj == null;
			nint num3 = 0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ stack_-30_v24+1C]");
				if (obj2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1471 @ stack_-30_v24+18]");
					object obj8 = (nint)0 + (nint)1;
					List<DlcType> includedDlc = IncludedDlc;
					nint num4 = unchecked((nint)null);
					object obj9 = obj8;
					object obj10 = default(object);
					while (true)
					{
						if (obj10 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1153 @ stack_-30_v35+1C]");
							if (obj2 == null)
							{
								object obj11 = obj9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1153 @ stack_-30_v35+18]");
								if ((nint)obj11 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1153 @ stack_-30_v35+10]");
									object obj12 = 0;
									object obj13 = obj9 + 1;
									DLCSelection dlcSelection4 = _dlcSelection;
									bool flag3 = dlcSelection4.SelectedDLCs == null;
									SelectedDLCDictionary selectedDLCs3 = dlcSelection4.SelectedDLCs;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1917 @ rdx_v95+20+v1904 @ stack_-28_v38*4]");
									int num5 = ((Dictionary<DlcType, bool>)selectedDLCs3).FindEntry(DlcType.Moonspell);
									object obj14 = !flag3;
									obj9 = obj13;
									if (obj14 == null)
									{
										DLCSelection dlcSelection5 = _dlcSelection;
										SelectedDLCDictionary selectedDLCs4 = dlcSelection5.SelectedDLCs;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1917 @ rdx_v95+20+v3176 @ rcx_v158*4]");
										int num6 = ((Dictionary<DlcType, bool>)selectedDLCs4).FindEntry(DlcType.Moonspell);
										obj9 = obj13;
									}
									continue;
								}
								break;
							}
							break;
						}
						throw new NullReferenceException();
					}
					bool flag4 = obj10 == null;
					num4 = 0;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1153 @ stack_-30_v35+1C]");
						if (obj2 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1153 @ stack_-30_v35+18]");
							object obj15 = (nint)0 + (nint)1;
							obj4 = obj15;
							goto IL_09f4;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						num4 = unchecked((nint)null);
					}
					throw new NullReferenceException();
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				num3 = unchecked((nint)null);
			}
			throw new NullReferenceException();
		}
		goto IL_09f4;
		IL_09f4:
		if (_dlcSelection != null)
		{
			return;
		}
		DLCSelection dlcSelection6 = new DLCSelection();
		_dlcSelection = dlcSelection6;
		DLCSelection dlcSelection7 = _dlcSelection;
		SelectedDLCDictionary selectedDLCDictionary = new SelectedDLCDictionary();
		List<DlcType> list4 = new List<DlcType>();
		List<bool> list5 = new List<bool>();
		selectedDLCDictionary._002Ector();
		dlcSelection7.SelectedDLCs = selectedDLCDictionary;
		List<DlcType> ownedDlc2 = OwnedDlc;
		Dictionary<System.Int32Enum, bool> dictionary3 = null;
		object obj16 = default(object);
		while (true)
		{
			if (obj16 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1472 @ stack_-30_v7+1C]");
				if (obj2 == null)
				{
					object obj17 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1472 @ stack_-30_v7+18]");
					if ((nint)obj17 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1472 @ stack_-30_v7+10]");
						object obj18 = 0;
						object obj19 = obj4 + 1;
						DLCSelection dlcSelection8 = _dlcSelection;
						SelectedDLCDictionary selectedDLCs5 = dlcSelection8.SelectedDLCs;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2881 @ rdx_v50+20+v2786 @ stack_-28_v5*4]");
						bool flag5 = ((Dictionary<System.Int32Enum, bool>)(object)selectedDLCs5).TryInsert((System.Int32Enum)0, true, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						obj4 = obj19;
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag6 = obj16 == null;
		dictionary3 = (Dictionary<System.Int32Enum, bool>)0;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1472 @ stack_-30_v7+1C]");
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1472 @ stack_-30_v7+18]");
				object obj20 = (nint)0 + (nint)1;
				List<DlcType> includedDlc2 = IncludedDlc;
				nint num7 = unchecked((nint)null);
				object obj21 = obj20;
				object obj22 = default(object);
				while (true)
				{
					if (obj22 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-30_v9+1C]");
						if (obj2 == null)
						{
							object obj23 = obj21;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-30_v9+18]");
							if ((nint)obj23 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-30_v9+10]");
								object obj24 = 0;
								object obj25 = obj21 + 1;
								DLCSelection dlcSelection9 = _dlcSelection;
								SelectedDLCDictionary selectedDLCs6 = dlcSelection9.SelectedDLCs;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3146 @ rdx_v46+20+v3131 @ stack_-28_v7*4]");
								bool flag7 = ((Dictionary<System.Int32Enum, bool>)(object)selectedDLCs6).TryInsert((System.Int32Enum)0, true, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								obj21 = obj25;
								continue;
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				bool flag8 = obj22 == null;
				num7 = 0;
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ stack_-30_v9+1C]");
					if (obj2 == null)
					{
						return;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num7 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			dictionary3 = null;
		}
		throw new NullReferenceException();
	}

	public static void SaveDlcSelection()
	{
		Debug.LogError("SaveDlcSelection will not be saved as the current platform is not IOS or Android");
	}

	public unsafe static void LicenseCheckDlc(Action callback)
	{
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals8.callback = callback;
		Log("Performing license check");
		Action callback2 = delegate
		{
			LicenseManager._003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals23 = new LicenseManager._003C_003Ec__DisplayClass14_0();
			CS_0024_003C_003E8__locals23._003C_003E4__this = _licenseManager;
			CS_0024_003C_003E8__locals23.callback = CS_0024_003C_003E8__locals8.callback;
			SystemPlatform sInstance2 = SystemPlatform.sInstance;
			Action<List<DlcType>> onComplete2 = delegate
			{
				//IL_000f: Expected I, but got O
				//IL_0072: Expected O, but got I
				//IL_0226: Expected I, but got O
				//IL_0080: Unknown result type (might be due to invalid IL or missing references)
				//IL_0085: Expected O, but got Unknown
				//IL_008e: Expected O, but got Ref
				//IL_010a: Expected O, but got I4
				//IL_0113: Expected O, but got I4
				//IL_01b4: Expected I, but got O
				//IL_0131: Expected O, but got I
				//IL_016c: Expected O, but got I4
				//IL_0182: Expected O, but got I
				nint num = unchecked((nint)null);
				object obj = default(object);
				object obj2 = default(object);
				object obj4 = default(object);
				IntPtr intPtr = default(IntPtr);
				nint num3 = default(nint);
				object obj9 = default(object);
				while (true)
				{
					if (obj == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
					if (obj2 != null)
					{
						break;
					}
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+18]");
					if ((nint)obj3 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+10]");
					object obj5 = 0;
					object obj6 = obj4 + 1;
					string text = ((Enum)(&intPtr)).ToString();
					string text2 = "DLC: " + text + " is available to user.";
					string message = "[DlcSystem] - " + text2;
					Debug.Log(message);
					LicenseManager licenseManager = CS_0024_003C_003E8__locals23._003C_003E4__this;
					List<DlcType> list = licenseManager._003CAvailableDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					bool flag = (nint)0 == 0;
					nint num2 = num3;
					object obj7 = 0;
					object obj8 = 0;
					object obj10;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag2 = (nint)obj9 != -1;
						num2 = 0;
						obj8 = 0;
						num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj10 = 0;
						obj4 = obj6;
						if (flag2)
						{
							continue;
						}
					}
					LicenseManager licenseManager2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
					num = (nint)licenseManager2._003CAvailableDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					num3 = num2;
					obj10 = obj7;
					obj4 = obj6;
				}
				bool flag3 = obj == null;
				num = 0;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
					if (obj2 == null)
					{
						Action callback3 = CS_0024_003C_003E8__locals23.callback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v112.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						return;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num = unchecked((nint)null);
				}
				throw new NullReferenceException();
			};
			sInstance2.m_CurrentSystem.GetAvailableDlc(onComplete2);
		};
		LicenseManager._003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals20 = new LicenseManager._003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals20._003C_003E4__this = _licenseManager;
		CS_0024_003C_003E8__locals20.callback = callback2;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		Action<List<DlcType>> onComplete = delegate
		{
			//IL_0626: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_0089: Expected O, but got Ref
			//IL_0217: Expected O, but got I
			//IL_0108: Expected O, but got I4
			//IL_0126: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_0161: Expected O, but got I4
			//IL_0171: Expected O, but got I
			//IL_029e: Expected O, but got I
			//IL_05bc: Expected O, but got I4
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Expected O, but got Unknown
			//IL_03ed: Expected O, but got I
			//IL_0307: Expected O, but got I
			//IL_033f: Expected O, but got Ref
			//IL_04a5: Expected O, but got I
			LicenseManager._003C_003Ec__DisplayClass10_0 obj = CS_0024_003C_003E8__locals20;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			IntPtr intPtr = default(IntPtr);
			object obj9 = default(object);
			nint num2 = default(nint);
			object obj11 = default(object);
			while (true)
			{
				if (obj2 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+1C]");
				if (obj3 != null)
				{
					break;
				}
				object obj4 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+10]");
				object obj6 = 0;
				object obj7 = obj5 + 1;
				string text = ((Enum)(&intPtr)).ToString();
				string text2 = "User owns license for DLC: " + text;
				string message = "[DlcSystem] - " + text2;
				Debug.Log(message);
				LicenseManager licenseManager = CS_0024_003C_003E8__locals20._003C_003E4__this;
				List<DlcType> list = licenseManager._003COwnedDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				bool flag = (nint)0 == 0;
				object obj8 = obj9;
				nint num = num2;
				object obj10 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
					obj = (LicenseManager._003C_003Ec__DisplayClass10_0)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj11 != -1;
					num = 0;
					obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					obj9 = 0;
					num2 = 0;
					obj5 = obj7;
					if (flag2)
					{
						continue;
					}
				}
				LicenseManager licenseManager2 = CS_0024_003C_003E8__locals20._003C_003E4__this;
				obj = (LicenseManager._003C_003Ec__DisplayClass10_0)(object)licenseManager2._003COwnedDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
				obj9 = obj8;
				num2 = num;
				obj5 = obj7;
			}
			bool flag3 = obj2 == null;
			obj = (LicenseManager._003C_003Ec__DisplayClass10_0)0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+1C]");
				if (obj3 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+18]");
					object obj12 = (nint)0 + (nint)1;
					LicenseManager licenseManager3 = CS_0024_003C_003E8__locals20._003C_003E4__this;
					List<DlcType> list2 = licenseManager3._003CIncludedDlc_003Ek__BackingField;
					object obj13 = obj12;
					object obj15 = default(object);
					object obj18 = default(object);
					object obj19 = default(object);
					object obj21 = default(object);
					IntPtr intPtr2 = default(IntPtr);
					while (true)
					{
						object obj14 = obj13;
						while (true)
						{
							if (obj15 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+1C]");
								if (obj3 == null)
								{
									object obj16 = obj14;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+18]");
									if ((nint)obj16 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+10]");
										object obj17 = 0;
										obj14++;
										LicenseManager licenseManager4 = CS_0024_003C_003E8__locals20._003C_003E4__this;
										List<DlcType> list3 = licenseManager4._003COwnedDlc_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
										if ((nint)0 != 0)
										{
											break;
										}
										continue;
									}
								}
								if (obj15 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+1C]");
									if (obj3 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
										bool flag4 = (nint)0 == 0;
										bool flag5 = false;
										if (!flag4)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
											list2 = (List<DlcType>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											bool flag6 = (nint)obj18 == -1;
											flag5 = false;
											if (!flag6)
											{
												bool flag7 = CS_0024_003C_003E8__locals20._003C_003E4__this.IsFreeDlcActivated(DlcType.Emeralds);
												flag5 = false;
												if (!flag7)
												{
													CS_0024_003C_003E8__locals20._003C_003E4__this.SetFreeDlcActivated(DlcType.Emeralds);
													list2 = null;
													flag5 = true;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
												list2 = (List<DlcType>)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
												bool flag8 = (nint)obj19 == -1;
												flag5 = false;
												if (!flag8)
												{
													bool flag9 = CS_0024_003C_003E8__locals20._003C_003E4__this.IsFreeDlcActivated(DlcType.Lemon);
													flag5 = false;
													if (!flag9)
													{
														CS_0024_003C_003E8__locals20._003C_003E4__this.SetFreeDlcActivated(DlcType.Lemon);
														list2 = null;
														flag5 = true;
													}
												}
											}
										}
										CS_0024_003C_003E8__locals20._003C_003E4__this.AddIncludedDlc();
										Action callback3 = CS_0024_003C_003E8__locals20.callback;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v162.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
										return;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									object obj20 = 0;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						list2 = (List<DlcType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag10 = (nint)obj21 == -1;
						obj13 = obj14;
						if (!flag10)
						{
							string text3 = ((Enum)(&intPtr2)).ToString();
							string message2 = "removing " + text3 + " from owned DLC list ";
							Debug.Log(message2);
							LicenseManager licenseManager5 = CS_0024_003C_003E8__locals20._003C_003E4__this;
							List<DlcType> list4 = licenseManager5._003COwnedDlc_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rax_v85+20+v758 @ rdx_v27*4]");
							bool flag11 = ((List<System.Int32Enum>)(object)list4).Remove((System.Int32Enum)0);
							list2 = null;
							obj13 = obj14;
						}
					}
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		};
		sInstance.m_CurrentSystem.GetLicensedDlc(onComplete);
	}

	public static void UpdateDlc(Action callback)
	{
		Log("Checking for DLC updates");
		SystemPlatform sInstance = SystemPlatform.sInstance;
		sInstance.m_CurrentSystem.UpdateInstalledDlc(callback);
	}

	public static void LoadDlc(Action callback)
	{
		_003C_003Ec__DisplayClass33_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass33_0();
		CS_0024_003C_003E8__locals2.callback = callback;
		Log("Mounting and loading DLCs");
		_licenseManager.SortDlcLists();
		Action callback2 = delegate
		{
			//IL_0018: Expected I, but got O
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			//IL_0080: Expected O, but got I
			nint num = (nint)typeof(DlcType);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			if (num != 0)
			{
				object obj3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ rdx_v7+8F8] (should have been resolved before IL gen)");
				DlcType[] array = default(DlcType[]);
				if (array != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (array == null)
					{
						throw new InvalidCastException();
					}
				}
				_loadingManager.ValidateVersion(0, array, CS_0024_003C_003E8__locals2.callback);
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("enumType");
			ex._002Ector("enumType");
			throw ex;
		};
		_loadingManager.LoadDlcs(callback2);
	}

	public unsafe static void MountDlc(DlcType dlcType, Action callback)
	{
		//IL_001d: Expected I4, but got O
		//IL_003d: Expected O, but got Ref
		object obj = default(object);
		object arg = (DlcType)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Mounting DLC: {0}", (System.ParamsArray)(&obj2));
		Log(message);
	}

	public static bool IsFreeDlcActivated(DlcType dlcType)
	{
		//IL_002a: Expected I4, but got O
		if (_licenseManager != null)
		{
			return _licenseManager.IsFreeDlcActivated(dlcType);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe static void SetFreeDlcActivated(DlcType dlcType, bool activated = true)
	{
		//IL_0014: Expected O, but got Ref
		DlcType dlcType2 = default(DlcType);
		object arg = dlcType2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg2 = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Activate Free DLC: {0}; Activate: {1}", (System.ParamsArray)(&obj));
		Log(message);
		_licenseManager.SetFreeDlcActivated(dlcType, activated);
	}

	public static List<DlcType> GetMissingDlc()
	{
		//IL_037c: Expected O, but got I
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00f5: Expected O, but got I
		//IL_0105: Expected O, but got I
		//IL_012c: Expected I, but got O
		//IL_015a: Expected O, but got I
		//IL_0199: Expected O, but got I
		//IL_01b2: Expected O, but got I
		//IL_01c8: Expected O, but got I
		List<DlcType> list = new List<DlcType>();
		LicenseManager licenseManager = _licenseManager;
		List<DlcType> list2 = licenseManager._003CAvailableDlc_003Ek__BackingField;
		ReleaseDateData releaseDateData = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		nint num2 = default(nint);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-28_v16+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-28_v16+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-28_v16+10]");
				System.Int32Enum int32Enum = (System.Int32Enum)0;
				object obj5 = obj4 + 1;
				List<DlcType> ownedDlc = OwnedDlc;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rax_v51 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				bool flag = (nint)0 == 0;
				nint num = num2;
				nint num3 = 0;
				List<DlcType> list3 = list2;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rax_v51 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					list3 = (List<DlcType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rax_v51 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
					releaseDateData = (ReleaseDateData)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj6 != -1;
					num = 0;
					num3 = unchecked((nint)null);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rdx_v22 (System.Int32Enum)+20+v122 @ stack_-20_v15*4]");
					int32Enum = (System.Int32Enum)0;
					num2 = 0;
					obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rax_v51 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					list2 = (List<DlcType>)0;
					if (flag2)
					{
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B58C00");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rax_v54+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rdx_v22 (System.Int32Enum)+20+v122 @ stack_-20_v15*4]");
				object obj7 = ((Dictionary<System.Int32Enum, object>)num4).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v55 (System.Object)+50]");
				releaseDateData = (ReleaseDateData)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v55 (System.Object)+50]");
				bool flag3 = ((ReleaseDateData)0).HasDatePassed();
				bool flag4 = !flag3;
				num2 = num;
				obj4 = obj5;
				list2 = list3;
				if (!flag4)
				{
					DlcData dlcData = ((Dictionary<DlcType, DlcData>)(object)typeof(DlcSystem)).get_Item(DlcType.Moonspell);
					string title = dlcData._Title;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rdx_v22 (System.Int32Enum)+20+v825 @ rcx_v26*4]");
					object obj8 = ((Dictionary<System.Int32Enum, object>)(object)title).get_Item((System.Int32Enum)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v59 (System.Object)+99]");
					bool flag5 = (nint)0 != 0;
					num2 = num;
					obj4 = obj5;
					list2 = list3;
					releaseDateData = (ReleaseDateData)(object)dlcData._Title;
					if (!flag5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v858 @ rdx_v22 (System.Int32Enum)+20+v825 @ rcx_v26*4]");
						DlcData dlcData2 = ((Dictionary<DlcType, DlcData>)(object)list).get_Item(DlcType.Moonspell);
						num2 = num;
						obj4 = obj5;
						list2 = list3;
						releaseDateData = (ReleaseDateData)(object)list;
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag6 = obj == null;
		releaseDateData = (ReleaseDateData)0;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ stack_-28_v16+1C]");
			if (obj2 == null)
			{
				return list;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			releaseDateData = null;
		}
		throw new NullReferenceException();
	}

	public unsafe static List<DlcType> GetDlcTypesToLoad()
	{
		//IL_028a: Expected O, but got I
		//IL_0080: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00ed: Expected O, but got I4
		//IL_0104: Expected O, but got Ref
		//IL_019f: Expected O, but got Ref
		List<DlcType> result = new List<DlcType>();
		List<DlcType> ownedDlc = OwnedDlc;
		Dictionary<System.Int32Enum, bool> dictionary = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		IntPtr intPtr = default(IntPtr);
		IntPtr intPtr2 = default(IntPtr);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-38_v12+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-38_v12+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-38_v12+10]");
				object obj5 = 0;
				object obj6 = obj4 + 1;
				DLCSelection dlcSelection = _dlcSelection;
				bool flag = dlcSelection.SelectedDLCs == null;
				SelectedDLCDictionary selectedDLCs = dlcSelection.SelectedDLCs;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbx_v13+20+v166 @ stack_-30_v11*4]");
				int num = ((Dictionary<DlcType, bool>)selectedDLCs).FindEntry(DlcType.Moonspell);
				object obj7 = !flag;
				if (obj7 == null)
				{
					string text = ((Enum)(&intPtr)).ToString();
					string message = "<DLCSYSTEM.GetDlcTypesToLoad> adding dlc to load as its not found in the selected DLC dictionary " + text;
					Debug.Log(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					obj4 = obj6;
					continue;
				}
				SelectedDLCDictionary selectedDlc = SelectedDlc;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbx_v13+20+v166 @ stack_-30_v11*4]");
				bool flag2 = ((Dictionary<System.Int32Enum, bool>)(object)selectedDlc).get_Item((System.Int32Enum)0);
				bool flag3 = !flag2;
				obj4 = obj6;
				if (!flag3)
				{
					string text2 = ((Enum)(&intPtr2)).ToString();
					string message2 = "<DLCSYSTEM.GetDlcTypesToLoad> adding dlc to load " + text2;
					Debug.Log(message2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					obj4 = obj6;
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag4 = obj == null;
		dictionary = (Dictionary<System.Int32Enum, bool>)0;
		if (!flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ stack_-38_v12+1C]");
			if (obj2 == null)
			{
				return result;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			dictionary = null;
		}
		throw new NullReferenceException();
	}

	public static void ReleaseGameplayDlc()
	{
		AddressableCache.ReleaseDynamicOperationHandles();
	}

	public static void Reset(Action callback)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: callback.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	public static void ShowDlcDownload(DlcType dlcType)
	{
		//IL_002e: Expected O, but got I
		//IL_00b5: Expected O, but got I
		//IL_00d4: Expected O, but got I4
		if (!PopupManager.PopupExists("download-dlc"))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B58C00");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v5+18]");
			object obj = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)dlcType);
			bool flag = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/dlc_download_title", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string translation2 = LocalizationManager.GetTranslation("lang/dlc_download_description", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v8 (System.Object)+18]");
			string description = translation2.Replace("%0", (string)0);
			PopupManager.CreateAccountBlockingPopup("download-dlc", translation, description, textisLocalizationTerm: false, (Action)flag);
		}
	}

	public static void UpdateDlcDownloadProgressText(DlcType dlcType, string progressPercentage)
	{
		//IL_02b8: Expected I4, but got O
		//IL_00fc: Expected I, but got O
		//IL_0169: Expected O, but got I
		//IL_011f: Expected O, but got I
		//IL_0187: Expected O, but got I
		//IL_0157: Expected I, but got O
		//IL_01e1: Expected O, but got I
		//IL_02d2: Expected O, but got I
		PopupManager instance = PopupManager.Instance;
		bool flag = ((Dictionary<object, object>)(object)instance._popups).TryGetValue((object)"download-dlc", out object value);
		object obj = value;
		if (!flag)
		{
			obj = null;
		}
		object obj2;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v4 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				BlockingPopup component = ((GameObject)obj).GetComponent<BlockingPopup>();
				obj2 = component;
				goto IL_0292;
			}
		}
		obj2 = null;
		goto IL_0292;
		IL_0292:
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v3 (System.Object)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		System.Int32Enum key = (System.Int32Enum)_dlcCatalog;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v6 (System.Int32Enum)+18]");
		bool flag2 = (nint)0 == 0;
		nint num = (nint)typeof(DlcSystem);
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdx_v6 (System.Int32Enum)+18]");
			int num2 = ((Dictionary<System.Int32Enum, object>)0).FindEntry((System.Int32Enum)dlcType);
			if (num2 < 0)
			{
				return;
			}
			key = (System.Int32Enum)dlcType;
			num = (nint)typeof(DlcSystem);
		}
		int num3 = ((Dictionary<DlcType, DlcData>)num).FindEntry((DlcType)key);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v25 (System.Int32)+18]");
		object obj3 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)dlcType);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/dlc_download_description", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v26 (System.Object)+18]");
		string text = translation.Replace("%0", (string)0);
		string text2 = text + "(" + progressPercentage + "%)";
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v3 (System.Object)+50]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v3 (System.Object)+50]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdi_v8+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			}
		}
	}

	public static void HideDlcDownload()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AF9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("download-dlc");
	}

	public static void ShowDlcDownloadError(DlcType dlcType, Action onRetry, Action onContinue, string info = "")
	{
		//IL_00c9: Expected O, but got I
		//IL_014f: Expected I4, but got O
		//IL_014f: Expected I4, but got O
		//IL_014f: Expected I4, but got O
		//IL_014f: Expected O, but got I4
		_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass44_0();
		CS_0024_003C_003E8__locals4.onRetry = onRetry;
		CS_0024_003C_003E8__locals4.onContinue = onContinue;
		DlcCatalog dlcCatalog = _dlcCatalog;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dlcCatalog._DlcData).get_Item((System.Int32Enum)dlcType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AF9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("download-dlc");
		bool flag = default(bool);
		GameObject gameObject = default(GameObject);
		string text = default(string);
		bool flag2 = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/dlc_download_error_description", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, gameObject, text, flag2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v13 (System.Object)+18]");
		string text2 = translation.Replace("%0", (string)0);
		string description = text2 + "/n" + info;
		Action action = delegate
		{
			Action onRetry2 = CS_0024_003C_003E8__locals4.onRetry;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		};
		Action action2 = delegate
		{
			Action onContinue2 = CS_0024_003C_003E8__locals4.onContinue;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		};
		PopupManager.CreateTwoButtonPopup("error-dlc", "lang/dlc_download_error_title", description, "lang/dlc_download_error_retry", (string)flag, (Action)(object)gameObject, (Action)(object)text, flag2, (byte)(int)"lang/dlc_download_error_continue" != 0, (byte)(int)action != 0, (byte)(int)action2 != 0);
	}

	public unsafe static void PrepareBgmLoad(BgmType bgmType)
	{
		//IL_0033: Expected O, but got Ref
		Dictionary<DlcType, BundleManifestData> loadedDlc = LoadedDlc;
		Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			DlcType dlcType = DlcType.Moonspell;
			Dictionary<DlcType, BundleManifestData>.Enumerator enumerator2 = (Dictionary<DlcType, BundleManifestData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public static void OpenDLCLink()
	{
		Application.OpenURL("https://store.steampowered.com/dlc/1794680/Vampire_Survivors/");
	}

	public static void Log(string message)
	{
		string message2 = "[DlcSystem] - " + message;
		Debug.Log(message2);
	}

	static DlcSystem()
	{
		List<DlcType> onlineAvaliableDlcTypes = new List<DlcType>();
		OnlineAvaliableDlcTypes = onlineAvaliableDlcTypes;
	}
}
