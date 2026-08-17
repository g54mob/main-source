using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Saves;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class PopupManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__58_0;

		public static Action _003C_003E9__60_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CTestBlockingPopup_003Eb__58_0()
		{
			Debug.Log("Popup closed");
		}

		internal void _003CTestAccountBlockingPopup_003Eb__60_0()
		{
			Debug.Log("Popup closed");
		}
	}

	private GameObject _Fader;

	private AutomationPopup _AutomationPopup;

	private LargeMultiOptionPopup _LargeMultiOption;

	private LargeMultiOptionSavePopup _LargeMultiOptionSaves;

	private LargeLoadableDLCSelectionPopup _LargeLoadableDLCSelectionPopup;

	private BlockingPopup _BlockingPopup;

	private OkCancelPopup _OkCancelPopup;

	private WarningPopup _WarningPopup;

	private ErrorPopup _ErrorPopup;

	private TwoButtonPopup _TwoButtonPopup;

	private TextInputPopup _TextInputPopup;

	private AdventureCompletedPopup _AdventureCompletedPopup;

	private TutorialPopup _TutorialPopup;

	private HelpPopup _HelpPopup;

	private AccountErrorPopup _AccountErrorPopup;

	private BlockingPopup _AccountBlockingPopup;

	private AdvancedMusicSelection _AdvancedMusicSelection;

	private EULAPopup _EULAPopup;

	private static PopupManager Instance;

	private GameObject _currentFader;

	private static DataManager _dataManager;

	private Dictionary<string, GameObject> _popups;

	private RewiredStandaloneInputModule _inputModule;

	public static bool IsShowingPopups
	{
		get
		{
			//IL_00cb: Expected I4, but got O
			//IL_004b: Expected O, but got I4
			PopupManager instance = Instance;
			if ((object)Instance != null)
			{
				Dictionary<string, GameObject> popups = instance._popups;
				if (instance._popups != null)
				{
					object obj = popups._count - popups._freeCount;
					object obj2 = obj ^ obj;
					object obj3 = obj & obj2;
					bool flag = (nint)obj3 < 0;
					bool flag2 = (nint)obj < 0;
					bool flag3 = obj == null;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private RewiredStandaloneInputModule InputModule
	{
		get
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_015f: Expected O, but got I4
			RewiredStandaloneInputModule inputModule = _inputModule;
			RewiredStandaloneInputModule rewiredStandaloneInputModule;
			if ((object)_inputModule == null || ((UnityEngine.Object)inputModule).m_CachedPtr == (IntPtr)0)
			{
				rewiredStandaloneInputModule = UnityEngine.Object.FindObjectOfType<RewiredStandaloneInputModule>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_inputModule = rewiredStandaloneInputModule;
				if (flag)
				{
					goto IL_012d;
				}
				object obj = this + 192;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			rewiredStandaloneInputModule = _inputModule;
			goto IL_012d;
			IL_012d:
			return rewiredStandaloneInputModule;
		}
	}

	private void Construct(DataManager dataManager)
	{
		_dataManager = dataManager;
	}

	private void Awake()
	{
		Instance = this;
	}

	public unsafe static LargeMultiOptionPopup CreateLargeMultiOption(string id, string title, string description, List<OptionDataSet> options, Action<int> callback, Action closedCallback = null, bool textIsLocalizationTerm = true, TextAlignmentOptions? textAlignment = null, bool centerTicks = false)
	{
		//IL_0278: Expected O, but got I4
		//IL_0127: Expected F4, but got I4
		//IL_012f: Expected O, but got Ref
		if ((object)Instance != null)
		{
			Instance.MakeFader();
			PopupManager instance = Instance;
			if ((object)Instance != null)
			{
				RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
				LargeMultiOptionPopup largeMultiOptionPopup = UnityEngine.Object.Instantiate(instance._LargeMultiOption, safeAreaObject);
				if ((object)largeMultiOptionPopup != null)
				{
					GameObject p = largeMultiOptionPopup.gameObject;
					ApplyCanvasSettings(p);
					object obj = default(object);
					bool flag = obj == null;
					string text = id;
					string title2 = title;
					string description2 = description;
					if (!flag)
					{
						string text2 = Translate(title);
						string text3 = Translate(description);
						if (options == null)
						{
							goto IL_022f;
						}
						List<OptionDataSet>.Enumerator enumerator = default(List<OptionDataSet>.Enumerator);
						if (enumerator.MoveNext())
						{
							float num = 0f;
							List<OptionDataSet>.Enumerator enumerator2 = (List<OptionDataSet>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						text = id;
						title2 = text2;
						description2 = text3;
					}
					largeMultiOptionPopup.Initialize(text, title2, description2, null, null, null, (TextAlignmentOptions?)(object)0);
					largeMultiOptionPopup.Show();
					PopupManager instance2 = Instance;
					if ((object)Instance != null)
					{
						GameObject value = largeMultiOptionPopup.gameObject;
						if (instance2._popups != null)
						{
							bool flag2 = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)text, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							return largeMultiOptionPopup;
						}
					}
				}
			}
		}
		goto IL_022f;
		IL_022f:
		throw new NullReferenceException();
	}

	public unsafe static void CreateLoadableDLCSelection(string id, Action callback, bool textisLocalizationTerm = true, bool runCallbackIfNoDLC = true, bool showBackButton = false)
	{
		//IL_0759: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_0115: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_06e7: Expected I, but got O
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_023f: Expected O, but got Ref
		//IL_0286: Expected I, but got O
		//IL_0336: Expected O, but got Ref
		//IL_0357: Expected O, but got I
		//IL_02e3: Expected O, but got I4
		//IL_02fa: Expected O, but got Ref
		//IL_0556: Expected F4, but got I4
		//IL_03a8: Expected O, but got Ref
		//IL_0328: Expected I, but got O
		//IL_03c6: Expected O, but got I
		List<DlcType> list = new List<DlcType>();
		List<DlcType> ownedDlc = DlcSystem.OwnedDlc;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
		((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)ownedDlc);
		List<DlcType> includedDlc = DlcSystem.IncludedDlc;
		List<System.Int32Enum> list2 = null;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-108_v22+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-108_v22+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-108_v22+10]");
						object obj5 = 0;
						obj4 = obj6 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rdx_v78+20+v463 @ stack_-100_v21*4]");
						bool flag = ((List<System.Int32Enum>)(object)list).Remove((System.Int32Enum)0);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		list2 = (List<System.Int32Enum>)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-108_v22+1C]");
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-108_v22+18]");
				List<System.Int32Enum> list3 = (List<System.Int32Enum>)((nint)0 + (nint)1);
				List<DlcType> includedDlc2 = DlcSystem.IncludedDlc;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				((List<System.Int32Enum>)(object)list).InsertRange(0, (IEnumerable<System.Int32Enum>)includedDlc2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				bool flag3 = (nint)0 > (nint)0;
				bool flag4 = false;
				if (!flag3)
				{
					flag4 = runCallbackIfNoDLC;
				}
				if (!flag4)
				{
					List<DLCOptionDataSet> list4 = new List<DLCOptionDataSet>();
					List<System.Int32Enum> list5 = list3;
					object obj7 = default(object);
					IntPtr intPtr = default(IntPtr);
					IntPtr intPtr2 = default(IntPtr);
					IntPtr intPtr3 = default(IntPtr);
					Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
					object obj10 = default(object);
					bool selected = default(bool);
					while (true)
					{
						if (obj7 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ stack_-108_v25+1C]");
							if (obj2 != null)
							{
								break;
							}
							List<System.Int32Enum> list6 = list5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ stack_-108_v25+18]");
							if ((nint)list6 >= 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ stack_-108_v25+10]");
							object obj8 = 0;
							List<System.Int32Enum> list7 = list5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rsi_v30+18]");
							if ((nint)list7 < 0)
							{
								List<System.Int32Enum> list8 = (List<System.Int32Enum>)(list5 + 1);
								string text = ((Enum)(&intPtr)).ToString();
								string message = "allOwnedDLC contains: " + text;
								Debug.Log(message);
								DLCSelection dlcSelection = DlcSystem._dlcSelection;
								bool flag5 = dlcSelection.SelectedDLCs == null;
								nint num = unchecked((nint)null);
								if (!flag5)
								{
									SelectedDLCDictionary selectedDlc = DlcSystem.SelectedDlc;
									bool flag6 = selectedDlc == null;
									if (flag6)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rsi_v30+20+v983 @ stack_-100_v24 (System.Collections.Generic.List`1<System.Int32Enum>)*4]");
									int num2 = ((Dictionary<DlcType, bool>)selectedDlc).FindEntry(DlcType.Moonspell);
									object obj9 = !flag6;
									if (obj9 == null)
									{
										string text2 = ((Enum)(&intPtr2)).ToString();
										string message2 = "Selected DLC dictionary does not contain " + text2;
										Debug.Log(message2);
										num = unchecked((nint)null);
									}
									else
									{
										SelectedDLCDictionary selectedDlc2 = DlcSystem.SelectedDlc;
										bool flag7 = selectedDlc2 == null;
										list2 = null;
										if (flag7)
										{
											throw new NullReferenceException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rsi_v30+20+v983 @ stack_-100_v24 (System.Collections.Generic.List`1<System.Int32Enum>)*4]");
										bool flag8 = ((Dictionary<System.Int32Enum, bool>)(object)selectedDlc2).get_Item((System.Int32Enum)0);
										num = 0;
									}
								}
								string text3 = ((Enum)(&intPtr3)).ToString();
								((List<DlcType>)(object)typeof(DlcSystem)).InsertRange(0, (IEnumerable<DlcType>)num);
								string text4 = text3;
								while (enumerator.MoveNext())
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rsi_v30+20+v983 @ stack_-100_v24 (System.Collections.Generic.List`1<System.Int32Enum>)*4]");
									if ((nint)0 == 0)
									{
										bool flag9 = obj10 == null;
										Dictionary<DlcType, DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
										if (flag9)
										{
											throw new NullReferenceException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2798 @ stack_-68+20]");
										text4 = (string)0;
									}
								}
								string title = text4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rsi_v30+20+v983 @ stack_-100_v24 (System.Collections.Generic.List`1<System.Int32Enum>)*4]");
								DLCOptionDataSet item = new DLCOptionDataSet(title, "", DlcType.Moonspell, selected);
								((List<object>)(object)list4).Add((object)item);
								list5 = list8;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
						throw new NullReferenceException();
					}
					bool flag10 = obj7 == null;
					nint num3 = 0;
					if (!flag10)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ stack_-108_v25+1C]");
						if (obj2 == null)
						{
							Instance.MakeFader();
							PopupManager instance = Instance;
							GameObject original = instance._LargeLoadableDLCSelectionPopup.gameObject;
							UIHelper instance2 = UIHelper.Instance;
							GameObject gameObject = UnityEngine.Object.Instantiate(original, instance2._SafeArea);
							LargeLoadableDLCSelectionPopup component = gameObject.GetComponent<LargeLoadableDLCSelectionPopup>();
							ApplyCanvasSettings(gameObject);
							bool flag11 = !textisLocalizationTerm;
							string description = "lang/options_dlcSelector_description";
							string title2 = "lang/options_dlcSelector_title";
							if (!flag11)
							{
								string text5 = Translate("lang/options_dlcSelector_title");
								string text6 = Translate("lang/options_dlcSelector_description");
								List<DLCOptionDataSet>.Enumerator enumerator3 = default(List<DLCOptionDataSet>.Enumerator);
								if (enumerator3.MoveNext())
								{
									float num4 = 0f;
									num3 = (nint)(&enumerator3);
									throw new NullReferenceException();
								}
								description = text6;
								title2 = text5;
							}
							component.Initialize(id, title2, description, null, null, showBackButton: false);
							component.Show();
							PopupManager instance3 = Instance;
							bool flag12 = ((Dictionary<object, object>)(object)instance3._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							return;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						num3 = unchecked((nint)null);
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: callback.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list2 = null;
		}
		throw new NullReferenceException();
	}

	public static TutorialPopup CreateTutorialPopup(string id, string titleTerm, string descriptionTerm, string buttonTerm)
	{
		if ((object)Instance != null)
		{
			Instance.MakeFader();
			PopupManager instance = Instance;
			if ((object)Instance != null && (object)instance._TutorialPopup != null)
			{
				GameObject original = instance._TutorialPopup.gameObject;
				RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
				GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
				if ((object)gameObject != null)
				{
					TutorialPopup component = gameObject.GetComponent<TutorialPopup>();
					if ((object)component != null)
					{
						string buttonTerm2 = default(string);
						component.Initialize(id, titleTerm, descriptionTerm, buttonTerm2);
						component.Show();
						PopupManager instance2 = Instance;
						if ((object)Instance != null && instance2._popups != null)
						{
							bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							ApplyCanvasSettings(gameObject);
							return component;
						}
					}
				}
			}
		}
		return (TutorialPopup)(object)new NullReferenceException();
	}

	private static void ApplyCanvasSettings(GameObject p, int sortingOrder = 11001)
	{
		Canvas canvas;
		if (p.TryGetComponent<Canvas>(out var component))
		{
			canvas = component;
		}
		else
		{
			Canvas canvas2 = p.AddComponent<Canvas>();
			canvas = canvas2;
		}
		canvas.overrideSorting = true;
		canvas.sortingLayerName = "UI";
		canvas.sortingOrder = sortingOrder;
		GraphicRaycaster component2 = p.GetComponent<GraphicRaycaster>();
		if ((object)component2 == null || ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0)
		{
			GraphicRaycaster graphicRaycaster = p.AddComponent<GraphicRaycaster>();
		}
	}

	public static void CreateBlockingPopup(string id, string title, string description, bool textisLocalizationTerm, Action onClose = null)
	{
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._BlockingPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		BlockingPopup component = gameObject.GetComponent<BlockingPopup>();
		ApplyCanvasSettings(gameObject);
		bool flag = !textisLocalizationTerm;
		string title2 = title;
		string description2 = description;
		if (!flag)
		{
			string text = Translate(title);
			string text2 = Translate(description);
			title2 = text;
			description2 = text2;
		}
		component.Initialize(id, title2, description2);
		component.Show();
		PopupManager instance2 = Instance;
		bool flag2 = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	public static void CreateAccountBlockingPopup(string id, string title, string description, bool textisLocalizationTerm, Action onClose = null)
	{
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._AccountBlockingPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		BlockingPopup component = gameObject.GetComponent<BlockingPopup>();
		ApplyCanvasSettings(gameObject);
		bool flag = !textisLocalizationTerm;
		string title2 = title;
		string description2 = description;
		if (!flag)
		{
			string text = Translate(title);
			string text2 = Translate(description);
			title2 = text;
			description2 = text2;
		}
		component.Initialize(id, title2, description2);
		component.Show();
		PopupManager instance2 = Instance;
		bool flag2 = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	public unsafe static void CreateSaveFileComparison(string id, string title, string description, List<SaveSummary> options, Action<int> callback, bool textIsLocalizationTerm = true, bool hasCancelButton = false, Action onCancel = null)
	{
		//IL_0037: Expected O, but got Ref
		//IL_041e: Expected I, but got O
		//IL_044f: Expected O, but got I
		//IL_046d: Expected O, but got I
		//IL_048c: Expected O, but got I
		//IL_07f0: Expected I, but got O
		//IL_04b7: Expected I, but got O
		//IL_04e8: Expected O, but got I
		//IL_058d: Expected O, but got I4
		//IL_058d: Expected I4, but got O
		//IL_058d: Expected O, but got I4
		//IL_05f7: Expected O, but got I
		//IL_0623: Expected O, but got I
		//IL_04f1->IL0628: Incompatible stack heights: 1 vs 0
		//IL_0531->IL0628: Incompatible stack heights: 1 vs 0
		//IL_0563->IL0628: Incompatible stack heights: 1 vs 0
		//IL_05cb->IL0628: Incompatible stack heights: 1 vs 0
		//IL_0600->IL0628: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F3F]");
		bool flag = (nint)0 != 0;
		List<SaveOptionDataSet> list = new List<SaveOptionDataSet>();
		bool flag2 = options == null;
		List<SaveOptionDataSet> list2 = list;
		if (!flag2)
		{
			List<SaveSummary>.Enumerator enumerator = default(List<SaveSummary>.Enumerator);
			if (enumerator.MoveNext())
			{
				List<SaveSummary> list3 = null;
				List<SaveSummary>.Enumerator enumerator2 = (List<SaveSummary>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			object obj = default(object);
			bool flag3 = obj == null;
			string text = default(string);
			string description2 = text;
			string title2 = title;
			bool flag4 = default(bool);
			GameObject gameObject = default(GameObject);
			string text2 = default(string);
			bool flag5 = default(bool);
			if (!flag3)
			{
				string translation = LocalizationManager.GetTranslation(title, FixForRTL: true, 0, ignoreRTLnumbers: true, flag4, gameObject, text2, flag5);
				string translation2 = LocalizationManager.GetTranslation(text, FixForRTL: true, 0, ignoreRTLnumbers: true, flag4, gameObject, text2, flag5);
				description2 = translation2;
				title2 = translation;
			}
			bool flag6 = (object)Instance == null;
			list2 = (List<SaveOptionDataSet>)(object)Instance;
			if (!flag6)
			{
				Instance.MakeFader();
				nint num = (nint)typeof(PopupManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v47 (Il2CppClass<VampireSurvivors.PopupManager>)+B8]");
				nint num2 = 0;
				List<SaveSummary> instance = (List<SaveSummary>)(object)Instance;
				bool flag7 = (object)Instance == null;
				list2 = (List<SaveOptionDataSet>)num2;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rbx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Saves.SaveSummary>)+38]");
					List<SaveSummary> list4 = (List<SaveSummary>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rbx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Framework.Saves.SaveSummary>)+38]");
					bool flag8 = (nint)0 == 0;
					list2 = (List<SaveOptionDataSet>)num2;
					if (!flag8)
					{
						bool flag9 = list4._items == null;
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)list4._items);
						GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						nint num3 = (nint)typeof(UIHelper);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1601 @ rax_v56 (Il2CppClass<VampireSurvivors.UI.UIHelper>)+B8]");
						nint num4 = 0;
						UIHelper instance2 = UIHelper.Instance;
						bool flag10 = (object)UIHelper.Instance == null;
						list2 = (List<SaveOptionDataSet>)num4;
						if (!flag10)
						{
							GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2, instance2._SafeArea);
							bool flag11 = (object)gameObject3 == null;
							list2 = (List<SaveOptionDataSet>)(object)gameObject2;
							if (!flag11)
							{
								LargeMultiOptionSavePopup component = gameObject3.GetComponent<LargeMultiOptionSavePopup>();
								bool flag12 = (object)component == null;
								list2 = (List<SaveOptionDataSet>)(object)gameObject3;
								if (!flag12)
								{
									component.Initialize(id, title2, description2, (List<SaveOptionDataSet>)flag4, (Action<int>)(object)gameObject, (byte)(int)text2 != 0, (Action)flag5);
									component.Show();
									ApplyCanvasSettings(gameObject3);
									list2 = (List<SaveOptionDataSet>)(object)Instance;
									if ((object)Instance != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.UI.SaveOptionDataSet>)+B8]");
										bool flag13 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.UI.SaveOptionDataSet>)+B8]");
										list2 = (List<SaveOptionDataSet>)0;
										if (!flag13)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.UI.SaveOptionDataSet>)+B8]");
											bool flag14 = ((Dictionary<object, object>)0).TryInsert((object)id, (object)gameObject3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static void CreateOKCancelPopup(string id, string text, string description, Action<bool> callback, bool textIsLocalizationTerm = true)
	{
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._OkCancelPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		OkCancelPopup component = gameObject.GetComponent<OkCancelPopup>();
		Action<bool> callback2 = default(Action<bool>);
		bool textIsLocalizationTerm2 = default(bool);
		component.Initialize(id, text, description, callback2, textIsLocalizationTerm2);
		component.Show();
		ApplyCanvasSettings(gameObject);
		PopupManager instance2 = Instance;
		bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	public static void CreateWarningPopup(string id, string text, string description, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true)
	{
		PopupManager instance = Instance;
		int num = instance._popups.FindEntry(id);
		if (num < 0)
		{
			Instance.MakeFader();
			PopupManager instance2 = Instance;
			GameObject original = instance2._WarningPopup.gameObject;
			RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
			GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
			WarningPopup component = gameObject.GetComponent<WarningPopup>();
			string description2 = default(string);
			Action callback2 = default(Action);
			bool titleIsLocalizationTerm2 = default(bool);
			bool descriptionIsLocalizationTerm2 = default(bool);
			component.Initialize(Instance, id, text, description2, callback2, titleIsLocalizationTerm2, descriptionIsLocalizationTerm2);
			component.Show();
			ApplyCanvasSettings(gameObject);
			PopupManager instance3 = Instance;
			bool flag = ((Dictionary<object, object>)(object)instance3._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		else
		{
			string message = "Popup already exists for id " + id;
			Debug.LogWarning(message);
		}
	}

	public static void CreateOnlineErrorPopup(string id, string text, string description, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true)
	{
		PopupManager instance = Instance;
		int num = instance._popups.FindEntry(id);
		if (num < 0)
		{
			Instance.MakeFader();
			PopupManager instance2 = Instance;
			GameObject original = instance2._WarningPopup.gameObject;
			RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
			GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
			WarningPopup component = gameObject.GetComponent<WarningPopup>();
			gameObject.layer = 5;
			string description2 = default(string);
			Action callback2 = default(Action);
			bool titleIsLocalizationTerm2 = default(bool);
			bool descriptionIsLocalizationTerm2 = default(bool);
			component.Initialize(Instance, id, text, description2, callback2, titleIsLocalizationTerm2, descriptionIsLocalizationTerm2);
			component.Show();
			ApplyCanvasSettings(gameObject);
			PopupManager instance3 = Instance;
			bool flag = ((Dictionary<object, object>)(object)instance3._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		else
		{
			string message = "Popup already exists for id " + id;
			Debug.LogWarning(message);
		}
	}

	public static void CreateHelpPopup(string id, string text, string description, string helpText, string helpUrl, string qrCodeName, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool helpTextIsLocalizationTerm = true)
	{
		//IL_00aa: Expected I4, but got O
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._HelpPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		HelpPopup component = gameObject.GetComponent<HelpPopup>();
		string description2 = default(string);
		string helpText2 = default(string);
		string helpUrl2 = default(string);
		string qrCodeName2 = default(string);
		IntPtr intPtr = default(IntPtr);
		component.Initialize(Instance, id, text, description2, helpText2, helpUrl2, qrCodeName2, (Action)(object)description, (byte)(int)helpText != 0, helpTextIsLocalizationTerm, (byte)(nint)intPtr != 0);
		component.Show();
		ApplyCanvasSettings(gameObject);
		PopupManager instance2 = Instance;
		bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	public static void CreateAccountErrorPopup(string id, string text, string description, string helpText, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool helpTextIsLocalizationTerm = true)
	{
		//IL_00a2: Expected I4, but got O
		//IL_00a2: Expected I4, but got O
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._AccountErrorPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		AccountErrorPopup component = gameObject.GetComponent<AccountErrorPopup>();
		string description2 = default(string);
		string helpText2 = default(string);
		Action callback2 = default(Action);
		bool titleIsLocalizationTerm2 = default(bool);
		component.Initialize(Instance, id, text, description2, helpText2, callback2, titleIsLocalizationTerm2, (byte)(int)description != 0, (byte)(int)helpText != 0);
		component.Show();
		ApplyCanvasSettings(gameObject);
		PopupManager instance2 = Instance;
		bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	public static void CreateErrorPopup(string id, string error, bool textIsLocalizationTerm = false)
	{
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._ErrorPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		ErrorPopup component = gameObject.GetComponent<ErrorPopup>();
		component._manager = Instance;
		((BasePopup)component)._ID = id;
		bool flag = !textIsLocalizationTerm;
		string text = error;
		if (!flag)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(error, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text = translation;
		}
		component._Description.text = text;
		component.Show();
		ApplyCanvasSettings(gameObject);
		PopupManager instance2 = Instance;
		bool flag2 = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	public static void CreateTwoButtonPopup(string id, string title, string description, string button1Text, string button2Text, Action button1Callback, Action button2Callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true, bool button2TextIsLocalizationTerm = true)
	{
		//IL_00ae: Expected I4, but got O
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._TwoButtonPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		TwoButtonPopup component = gameObject.GetComponent<TwoButtonPopup>();
		string description2 = default(string);
		string button1Text2 = default(string);
		string button2Text2 = default(string);
		Action button1Callback2 = default(Action);
		IntPtr intPtr = default(IntPtr);
		component.Initialize(Instance, id, title, description2, button1Text2, button2Text2, button1Callback2, (Action)(object)description, (byte)(int)button1Text != 0, button1TextIsLocalizationTerm, button2TextIsLocalizationTerm, (byte)(nint)intPtr != 0);
		component.Show();
		PopupManager instance2 = Instance;
		bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		ApplyCanvasSettings(gameObject);
	}

	public static void CreateEULAPopup(string id, string title, string button1Text, string button2Text, Action button1Callback, Action button2Callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true, bool button2TextIsLocalizationTerm = true)
	{
		//IL_00aa: Expected I4, but got O
		//IL_00aa: Expected I4, but got O
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._EULAPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		EULAPopup component = gameObject.GetComponent<EULAPopup>();
		string button1Text2 = default(string);
		string button2Text2 = default(string);
		Action button1Callback2 = default(Action);
		Action button2Callback2 = default(Action);
		IntPtr intPtr = default(IntPtr);
		component.Initialize(Instance, id, title, button1Text2, button2Text2, button1Callback2, button2Callback2, (byte)(int)button1Text != 0, (byte)(int)button2Text != 0, button2TextIsLocalizationTerm, (byte)(nint)intPtr != 0);
		component.Show();
		PopupManager instance2 = Instance;
		bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		ApplyCanvasSettings(gameObject);
	}

	public static void CreateTextInputPopup(string id, string title, string button1Text, Action<string> button1Callback, bool titleIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true)
	{
		Instance.MakeFader();
		PopupManager instance = Instance;
		GameObject original = instance._TextInputPopup.gameObject;
		RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
		TextInputPopup component = gameObject.GetComponent<TextInputPopup>();
		string button1Text2 = default(string);
		Action<string> button1Callback2 = default(Action<string>);
		bool titleIsLocalizationTerm2 = default(bool);
		bool button1TextIsLocalizationTerm2 = default(bool);
		component.Initialize(Instance, id, title, button1Text2, button1Callback2, titleIsLocalizationTerm2, button1TextIsLocalizationTerm2);
		component.Show();
		PopupManager instance2 = Instance;
		bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		ApplyCanvasSettings(gameObject);
	}

	public static AdventureCompletedPopup CreateAdventureCompletedPopup(string id)
	{
		if ((object)Instance != null)
		{
			Instance.MakeFader(0.35f, 0.25f);
			PopupManager instance = Instance;
			if ((object)Instance != null && (object)instance._AdventureCompletedPopup != null)
			{
				GameObject original = instance._AdventureCompletedPopup.gameObject;
				RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
				GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
				if ((object)gameObject != null)
				{
					AdventureCompletedPopup component = gameObject.GetComponent<AdventureCompletedPopup>();
					if ((object)component != null)
					{
						((BasePopup)component)._ID = id;
						component.Show();
						PopupManager instance2 = Instance;
						if ((object)Instance != null && instance2._popups != null)
						{
							bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							ApplyCanvasSettings(gameObject);
							return component;
						}
					}
				}
			}
		}
		return (AdventureCompletedPopup)(object)new NullReferenceException();
	}

	public static BasePopup CreateAdvancedMusicSelectionPopup(string id)
	{
		if ((object)Instance != null)
		{
			Instance.MakeFader(0.7f, 0.25f);
			PopupManager instance = Instance;
			if ((object)Instance != null && (object)instance._AdvancedMusicSelection != null)
			{
				GameObject original = instance._AdvancedMusicSelection.gameObject;
				RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
				GameObject gameObject = UnityEngine.Object.Instantiate(original, safeAreaObject);
				if ((object)gameObject != null)
				{
					AdvancedMusicSelection component = gameObject.GetComponent<AdvancedMusicSelection>();
					if ((object)component != null)
					{
						component.Show();
						((BasePopup)component)._ID = id;
						EventSystem current = EventSystem.current;
						if ((object)current != null)
						{
							((BasePopup)component)._previouslySelected = current.m_CurrentSelected;
							PopupManager instance2 = Instance;
							if ((object)Instance != null && instance2._popups != null)
							{
								bool flag = ((Dictionary<object, object>)(object)instance2._popups).TryInsert((object)id, (object)gameObject, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								ApplyCanvasSettings(gameObject);
								return component;
							}
						}
					}
				}
			}
		}
		return (BasePopup)(object)new NullReferenceException();
	}

	private void MakeFader(float targetAlpha = 0.5f, float duration = 0.1f)
	{
		PopupManager instance = Instance;
		GameObject currentFader = instance._currentFader;
		if ((object)instance._currentFader == null || ((UnityEngine.Object)currentFader).m_CachedPtr == (IntPtr)0)
		{
			PopupManager instance2 = Instance;
			RectTransform safeAreaObject = UIHelper.GetSafeAreaObject();
			GameObject gameObject = UnityEngine.Object.Instantiate(instance2._Fader, safeAreaObject);
			CanvasGroup component = gameObject.GetComponent<CanvasGroup>();
			component.alpha = 0f;
			CanvasGroup component2 = gameObject.GetComponent<CanvasGroup>();
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(component2, targetAlpha, duration);
			Canvas component3 = gameObject.GetComponent<Canvas>();
			component3.overrideSorting = true;
			component3.sortingLayerName = "UI";
			component3.sortingOrder = 11000;
			PopupManager instance3 = Instance;
			instance3._currentFader = gameObject;
		}
	}

	public static void ClosePopup(string id)
	{
		PopupManager instance = Instance;
		int num = instance._popups.FindEntry(id);
		if (num >= 0)
		{
			PopupManager instance2 = Instance;
			GameObject obj = instance2._popups.get_Item(id);
			UnityEngine.Object.Destroy(obj, 0f);
			PopupManager instance3 = Instance;
			bool flag = ((Dictionary<object, object>)(object)instance3._popups).Remove((object)id);
		}
		PopupManager instance4 = Instance;
		Dictionary<string, GameObject> popups = instance4._popups;
		if (popups._count == popups._freeCount)
		{
			PopupManager instance5 = Instance;
			GameObject currentFader = instance5._currentFader;
			if ((object)instance5._currentFader != null && ((UnityEngine.Object)currentFader).m_CachedPtr != (IntPtr)0)
			{
				PopupManager instance6 = Instance;
				CanvasGroup component = instance6._currentFader.GetComponent<CanvasGroup>();
				int num2 = ShortcutExtensions.DOKill(component);
			}
			PopupManager instance7 = Instance;
			UnityEngine.Object.Destroy(instance7._currentFader, 0f);
			PopupManager instance8 = Instance;
			instance8._currentFader = null;
		}
	}

	public static bool PopupExists(string id)
	{
		//IL_006c: Expected I4, but got O
		PopupManager instance = Instance;
		if ((object)Instance != null && instance._popups != null)
		{
			int num = instance._popups.FindEntry(id);
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static GameObject GetPopup(string id)
	{
		PopupManager instance = Instance;
		if ((object)Instance != null && instance._popups != null)
		{
			bool flag = ((Dictionary<object, object>)(object)instance._popups).TryGetValue((object)id, out object value);
			object result = value;
			if (!flag)
			{
				result = null;
			}
			return (GameObject)result;
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public static T GetPopup<T>(string id) where T : Component
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		PopupManager instance = Instance;
		if ((object)Instance != null && instance._popups != null)
		{
			bool flag = ((Dictionary<object, object>)(object)instance._popups).TryGetValue((object)id, out object value);
			object obj = value;
			if (!flag)
			{
				obj = null;
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rdi_v3 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					return ((GameObject)obj).GetComponent<T>();
				}
			}
			return null;
		}
		return (T)(object)new NullReferenceException();
	}

	public static void SetAllowInput(bool val)
	{
		PopupManager instance = Instance;
		RewiredStandaloneInputModule inputModule = instance._inputModule;
		if ((object)instance._inputModule == null || ((UnityEngine.Object)inputModule).m_CachedPtr == (IntPtr)0)
		{
			RewiredStandaloneInputModule inputModule2 = UnityEngine.Object.FindObjectOfType<RewiredStandaloneInputModule>();
			instance._inputModule = inputModule2;
		}
		Behaviour inputModule3 = instance._inputModule;
		if ((object)instance._inputModule != null && ((UnityEngine.Object)inputModule3).m_CachedPtr != (IntPtr)0)
		{
			instance._inputModule.enabled = val;
		}
	}

	private static string Translate(string text)
	{
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(text, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	private unsafe void TestLargeMultiOption()
	{
		//IL_0018: Expected O, but got Ref
		//IL_004b: Expected O, but got Ref
		//IL_017f: Expected I4, but got O
		List<OptionDataSet> list = new List<OptionDataSet>();
		int num = 0;
		object obj = default(object);
		do
		{
			string text = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
			string title = "Title " + text;
			string text2 = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
			string info = "Description " + text2;
			OptionDataSet item = new OptionDataSet(title, info);
			int version = list._version + 1;
			list._version = version;
			OptionDataSet[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)item);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 6);
		Action<int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800092F0");
		Action<int> callback = default(Action<int>);
		Action closedCallback = default(Action);
		bool textIsLocalizationTerm = default(bool);
		TextAlignmentOptions? textAlignment = default(TextAlignmentOptions?);
		LargeMultiOptionPopup largeMultiOptionPopup = CreateLargeMultiOption("large-multi-option", "Title", "Description", list, callback, closedCallback, textIsLocalizationTerm, textAlignment, (byte)(int)action != 0);
	}

	public static void MakeTESTLargeMultiOption()
	{
		Instance.TestLargeMultiOption();
	}

	private void TestTutorialPopup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F53]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TutorialPopup tutorialPopup = CreateTutorialPopup("tutorial", "title", "description", "okay");
	}

	public static void MakeTESTTutorialPopup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F53]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TutorialPopup tutorialPopup = CreateTutorialPopup("tutorial", "title", "description", "okay");
	}

	private void TestBlockingPopup()
	{
		if (_003C_003Ec._003C_003E9__58_0 == null)
		{
			Action action = delegate
			{
				Debug.Log("Popup closed");
			};
			_003C_003Ec._003C_003E9__58_0 = action;
		}
		Action onClose = default(Action);
		CreateBlockingPopup("blocking-dumdum", "Title", "Description", textisLocalizationTerm: false, onClose);
	}

	public static void MakeTESTBlockingPopup()
	{
		if (_003C_003Ec._003C_003E9__58_0 == null)
		{
			Action action = delegate
			{
				Debug.Log("Popup closed");
			};
			_003C_003Ec._003C_003E9__58_0 = action;
		}
		Action onClose = default(Action);
		CreateBlockingPopup("blocking-dumdum", "Title", "Description", textisLocalizationTerm: false, onClose);
	}

	private void TestAccountBlockingPopup()
	{
		if (_003C_003Ec._003C_003E9__60_0 == null)
		{
			Action action = delegate
			{
				Debug.Log("Popup closed");
			};
			_003C_003Ec._003C_003E9__60_0 = action;
		}
		Action onClose = default(Action);
		CreateAccountBlockingPopup("blocking-account-dumdum", "Title", "Description", textisLocalizationTerm: false, onClose);
	}

	public static void MakeTESTAccountBlockingPopup()
	{
		if (_003C_003Ec._003C_003E9__60_0 == null)
		{
			Action action = delegate
			{
				Debug.Log("Popup closed");
			};
			_003C_003Ec._003C_003E9__60_0 = action;
		}
		Action onClose = default(Action);
		CreateAccountBlockingPopup("blocking-account-dumdum", "Title", "Description", textisLocalizationTerm: false, onClose);
	}

	private void TestSaveFileComparison()
	{
		List<SaveSummary> list = new List<SaveSummary>();
		CharacterType characterType = CharacterType.VOID;
		do
		{
			SaveSummary saveSummary = new SaveSummary();
			saveSummary._003C_selectedCharacter_003Ek__BackingField = characterType;
			saveSummary._003C_selectedStage_003Ek__BackingField = (StageType)characterType;
			DateTime now = DateTime.Now;
			string timestamp = System.DateTimeFormat.Format(now, (string)null, (IFormatProvider)null);
			saveSummary.Timestamp = timestamp;
			int num = UnityEngine.Random.RandomRangeInt(0, 9999999);
			saveSummary._003C_totalGold_003Ek__BackingField = num;
			int num2 = UnityEngine.Random.RandomRangeInt(0, 150);
			saveSummary._003C_achievements_003Ek__BackingField = num2;
			int num3 = UnityEngine.Random.RandomRangeInt(0, 40);
			saveSummary._003C_unlockedCharacters_003Ek__BackingField = num3;
			int version = list._version + 1;
			list._version = version;
			SaveSummary[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)saveSummary);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			characterType++;
		}
		while (characterType < CharacterType.IMELDA);
		Action<int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800092F0");
		Action<int> callback = default(Action<int>);
		bool textIsLocalizationTerm = default(bool);
		bool hasCancelButton = default(bool);
		Action onCancel = default(Action);
		CreateSaveFileComparison("save-file-dummy", "Title", "Description", list, callback, textIsLocalizationTerm, hasCancelButton, onCancel);
	}

	public static void MakeTESTSaveFileComparison()
	{
		Instance.TestSaveFileComparison();
	}

	private void TestOKCancel()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F5B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool textIsLocalizationTerm = default(bool);
		CreateOKCancelPopup("ok-cancel-dummy", "Title?", "Description", null, textIsLocalizationTerm);
	}

	public static void MakeTESTOKCancel()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F5B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool textIsLocalizationTerm = default(bool);
		CreateOKCancelPopup("ok-cancel-dummy", "Title?", "Description", null, textIsLocalizationTerm);
	}

	private void TestWarning()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F5D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		CreateWarningPopup("warning-dummy", "Title", "Description", null, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
	}

	private void TestHelpError()
	{
		//IL_0066: Expected I4, but got O
		//IL_0066: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F5E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string helpUrl = default(string);
		string qrCodeName = default(string);
		Action callback = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		CreateHelpPopup("help-error-dummy", "Title", "Description", "help text", helpUrl, qrCodeName, callback, titleIsLocalizationTerm, (byte)(int)"https://dummy.com/help" != 0, (byte)(int)"dlc-help-qr" != 0);
	}

	public static void MakeTESTWarning()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F5D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		CreateWarningPopup("warning-dummy", "Title", "Description", null, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
	}

	private void TestAccountError()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F60]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action callback = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		bool helpTextIsLocalizationTerm = default(bool);
		CreateAccountErrorPopup("account-error-dummy", "Title", "Description", "help text", callback, titleIsLocalizationTerm, descriptionIsLocalizationTerm, helpTextIsLocalizationTerm);
	}

	public static void MakeTESTAccountError()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F60]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action callback = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		bool helpTextIsLocalizationTerm = default(bool);
		CreateAccountErrorPopup("account-error-dummy", "Title", "Description", "help text", callback, titleIsLocalizationTerm, descriptionIsLocalizationTerm, helpTextIsLocalizationTerm);
	}

	private void TestError()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CreateErrorPopup("error-dummy", "error words");
	}

	public static void MakeTESTError()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CreateErrorPopup("error-dummy", "error words");
	}

	private void TestTwoButton()
	{
		//IL_006b: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F64]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string button2Text = default(string);
		Action button1Callback = default(Action);
		Action button2Callback = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		CreateTwoButtonPopup("two-button-dummy", "title", "description", "button1text", button2Text, button1Callback, button2Callback, titleIsLocalizationTerm, (byte)(int)"button2text" != 0, button1TextIsLocalizationTerm: false, button2TextIsLocalizationTerm: false);
	}

	public static void MakeTESTTwoButton()
	{
		//IL_0070: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F64]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string button2Text = default(string);
		Action button1Callback = default(Action);
		Action button2Callback = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		CreateTwoButtonPopup("two-button-dummy", "title", "description", "button1text", button2Text, button1Callback, button2Callback, titleIsLocalizationTerm, (byte)(int)"button2text" != 0, button1TextIsLocalizationTerm: false, button2TextIsLocalizationTerm: false);
	}

	private void TestAdventureCompleted()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F66]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AdventureCompletedPopup adventureCompletedPopup = CreateAdventureCompletedPopup("adventure-completed-dummy");
	}

	public static void MakeTESTAdventureCompleted()
	{
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4F66]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			AdventureCompletedPopup adventureCompletedPopup = CreateAdventureCompletedPopup("adventure-completed-dummy");
		}
	}

	public PopupManager()
	{
		Dictionary<string, GameObject> popups = new Dictionary<string, GameObject>();
		_popups = popups;
	}

	internal static void _003CTestLargeMultiOption_003Eg__fakeAction_007C54_0(int a)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object message = default(object);
		Debug.Log(message);
	}

	internal static void _003CTestSaveFileComparison_003Eg__OnSelected_007C62_0(int i)
	{
		int num = default(int);
		string text = num.ToString();
		string message = "Fake save selected : " + text;
		Debug.Log(message);
	}
}
