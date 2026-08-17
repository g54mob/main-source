using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class CharacterStageCompletionPanel : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<KeyValuePair<StageType, List<StageData>>, int> _003C_003E9__8_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CInitialize_003Eb__8_0(KeyValuePair<StageType, List<StageData>> x)
		{
			//IL_0074: Expected O, but got I
			//IL_003d: Expected O, but got I
			//IL_0052: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v6+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v9+10]");
				return 0;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			int result = default(int);
			return result;
		}
	}

	private GameObject _StagePrefab;

	private RectTransform _Container;

	private Dictionary<StageType, Image> _stageIcons;

	private DataManager _dataManager;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private bool _formatSize;

	private void Construct(DataManager data, SignalBus signal, PlayerOptions player)
	{
		_dataManager = data;
		_signalBus = signal;
		_playerOptions = player;
	}

	public unsafe void Initialize()
	{
		//IL_0989: Expected O, but got I4
		//IL_0992: Unknown result type (might be due to invalid IL or missing references)
		//IL_0997: Expected I4, but got Unknown
		//IL_01df: Expected O, but got I
		//IL_01ca: Expected O, but got I
		//IL_0a04: Expected I, but got O
		//IL_01f4: Expected O, but got I
		//IL_01b5: Expected O, but got I
		//IL_0229: Expected O, but got I
		//IL_017d: Expected O, but got I
		//IL_028c: Expected O, but got I
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_0479: Expected O, but got Ref
		//IL_0482: Expected O, but got I4
		//IL_0ad0: Expected I, but got O
		//IL_0ae6: Expected O, but got I
		//IL_04a5: Expected I, but got O
		//IL_0536: Expected O, but got I4
		//IL_04dc: Expected O, but got I
		//IL_088f: Expected O, but got I
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
		//IL_089d: Expected O, but got Unknown
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Expected O, but got Unknown
		//IL_055c: Expected I, but got O
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Expected O, but got Unknown
		//IL_0593: Expected O, but got I
		//IL_0498: Expected O, but got I4
		//IL_08d2: Expected O, but got I
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ed: Expected O, but got Unknown
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_0751: Expected I4, but got O
		//IL_07ac: Expected I, but got O
		//IL_085e: Expected I4, but got O
		//IL_00b4->IL0923: Incompatible stack heights: 1 vs 0
		//IL_0a23->IL0923: Incompatible stack heights: 1 vs 0
		//IL_00de->IL0923: Incompatible stack heights: 1 vs 0
		//IL_003a->IL0923: Incompatible stack heights: 1 vs 0
		//IL_0116->IL0923: Incompatible stack heights: 1 vs 0
		//IL_0a68->IL0923: Incompatible stack heights: 1 vs 0
		//IL_0214->IL0923: Incompatible stack heights: 1 vs 0
		//IL_0095->IL0a09: Incompatible stack heights: 2 vs 1
		//IL_009a->IL009a: Incompatible stack heights: 2 vs 1
		//IL_0462->IL0923: Incompatible stack heights: 4 vs 0
		//IL_0321->IL0a6d: Incompatible stack heights: 5 vs 1
		//IL_0407->IL0a6d: Incompatible stack heights: 9 vs 1
		//IL_049d->IL0af3: Incompatible stack heights: 6 vs 4
		//IL_0699->IL048f: Incompatible stack heights: 10 vs 6
		//IL_06d7->IL048f: Incompatible stack heights: 11 vs 6
		//IL_06f9->IL048f: Incompatible stack heights: 11 vs 6
		//IL_086c->IL048f: Incompatible stack heights: 16 vs 6
		TryShow();
		RectTransform container = _Container;
		bool flag4 = default(bool);
		if ((object)_Container != null)
		{
			bool flag = ((UnityEngine.Object)container).m_CachedPtr == (IntPtr)0;
			object obj = Transform.get_childCount_Injected(((UnityEngine.Object)container).m_CachedPtr);
			int num = obj - 1;
			if (num < 0)
			{
				goto IL_009a;
			}
			while ((object)_Container != null)
			{
				Transform child = _Container.GetChild(num);
				if ((object)child == null)
				{
					break;
				}
				bool flag2 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)child).m_CachedPtr);
				GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				nint num2 = (nint)typeof(UnityEngine.Object);
				UnityEngine.Object.Destroy(obj2, 0f);
				num--;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rcx_v48 (Il2CppClass<UnityEngine.Object>)+E4]");
				bool flag3 = (nint)0 >= (nint)0;
				flag4 = flag4;
				if (flag3)
				{
					continue;
				}
				goto IL_009a;
			}
		}
		goto IL_0923;
		IL_0a50:
		object obj3;
		Dictionary<StageType, List<StageData>> convertedStages;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v87+1A0]");
			Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v87+1A0]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v87+1A0]");
				Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)0;
				object obj4 = default(object);
				object obj5 = default(object);
				object obj7 = default(object);
				while (true)
				{
					bool flag5 = obj4 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-50_v30+1C]");
					if (obj5 == null)
					{
						object obj6 = obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-50_v30+18]");
						if ((nint)obj6 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-50_v30+10]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-50_v30+10]");
							bool flag6 = (nint)0 == 0;
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v76+18]");
							bool flag7 = (nint)obj9 >= 0;
							object obj10 = obj7 + 1;
							bool flag8 = convertedStages == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v76+20+v735 @ stack_-48_v28*4]");
							int num3 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).FindEntry((System.Int32Enum)0);
							obj7 = obj10;
							if (!flag8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v76+20+v1143 @ rcx_v114*4]");
								object obj11 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
								bool flag9 = obj11 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v76+20+v1143 @ rcx_v114*4]");
								List<StageData> list = ((Dictionary<StageType, List<StageData>>)obj11).get_Item(StageType.FOREST);
								bool flag10 = list == null;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v76+20+v1143 @ rcx_v114*4]");
								object obj12 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)0);
								bool flag11 = obj12 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rdx_v76+20+v1143 @ rcx_v114*4]");
								List<StageData> list2 = ((Dictionary<StageType, List<StageData>>)obj12).get_Item(StageType.FOREST);
								bool flag12 = list2 == null;
								_ = 0;
								obj7 = obj10;
							}
							continue;
						}
						break;
					}
					break;
				}
				bool flag13 = obj4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-50_v30+1C]");
				bool flag14 = obj5 != null;
				Func<KeyValuePair<StageType, List<StageData>>, int> keySelector = _003C_003Ec._003C_003E9__8_0;
				if (_003C_003Ec._003C_003E9__8_0 == null)
				{
					Func<KeyValuePair<StageType, List<StageData>>, int> func = (_003C_003Ec._003C_003E9__8_0 = delegate
					{
						//IL_0074: Expected O, but got I
						//IL_003d: Expected O, but got I
						//IL_0052: Expected O, but got I
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [x @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+8]");
						object obj38 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
							object obj39 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v6+20]");
							object obj40 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v9+10]");
							return 0;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						int result = default(int);
						return result;
					});
					nint num4 = (nint)typeof(_003C_003Ec);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ rax_v146 (Il2CppClass<VampireSurvivors.UI.CharacterStageCompletionPanel+<>c>)+B8]");
					dictionary = (Dictionary<System.Int32Enum, object>)((nint)0 + (nint)8);
					keySelector = func;
				}
				IOrderedEnumerable<KeyValuePair<StageType, List<StageData>>> orderedEnumerable = Enumerable.OrderBy(convertedStages, keySelector);
				if (orderedEnumerable != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					Dictionary<System.Int32Enum, object> dictionary3 = default(Dictionary<System.Int32Enum, object>);
					object obj13 = (object)(&dictionary3);
					object obj14 = 0;
					Dictionary<System.Int32Enum, object> dictionary4 = dictionary;
					object obj24 = default(object);
					object obj34 = default(object);
					object obj35 = default(object);
					object obj36 = default(object);
					StageData stageData = default(StageData);
					GameObject localParametersRoot = default(GameObject);
					string overrideLanguage = default(string);
					bool allowLocalizedParameters = default(bool);
					object obj37 = default(object);
					while (true)
					{
						bool flag15 = dictionary3 == null;
						nint num5 = (nint)dictionary3;
						object obj15 = obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r10_v15 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+12E]");
						if ((nint)obj15 >= 0)
						{
							goto IL_051b;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r10_v15 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+B0]");
						object obj16 = 0;
						object obj17 = obj14;
						while (true)
						{
							object obj18 = obj17 + obj17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2314 @ r8_v39+v2332 @ rax_v140*8]");
							if (0 == (nint)typeof(IEnumerator))
							{
								break;
							}
							obj17++;
							object obj19 = obj17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r10_v15 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+12E]");
							if ((nint)obj19 < 0)
							{
								continue;
							}
							goto IL_051b;
						}
						object obj20 = obj17 + obj17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2314 @ r8_v39+8+v2388 @ rcx_v102*8]");
						object obj21 = (nint)0 << 4;
						object obj22 = obj21 + 312;
						object obj23 = obj22 + num5;
						goto IL_0b7a;
						IL_0b7a:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2393 @ rdx_v48] (should have been resolved before IL gen)");
						if (obj24 == null)
						{
							break;
						}
						bool flag16 = dictionary3 == null;
						nint num6 = (nint)dictionary3;
						object obj25 = obj14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1501 @ r10_v16 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+12E]");
						if ((nint)obj25 >= 0)
						{
							goto IL_05d2;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1501 @ r10_v16 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+B0]");
						object obj26 = 0;
						object obj27 = obj14;
						while (true)
						{
							object obj28 = obj27 + obj27;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ r8_v58+v2437 @ rax_v135*8]");
							if (0 == (nint)typeof(IEnumerator<KeyValuePair<StageType, List<StageData>>>))
							{
								break;
							}
							obj27++;
							object obj29 = obj27;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1501 @ r10_v16 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>>)+12E]");
							if ((nint)obj29 < 0)
							{
								continue;
							}
							goto IL_05d2;
						}
						object obj30 = obj27 + obj27;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2434 @ r8_v58+8+v2493 @ rcx_v96*8]");
						object obj31 = (nint)0 << 4;
						object obj32 = obj31 + 312;
						object obj33 = obj32 + num6;
						goto IL_0ba1;
						IL_05d2:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj33 = obj34;
						goto IL_0ba1;
						IL_0ba1:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2499 @ r8_v42] (should have been resolved before IL gen)");
						dictionary4 = (Dictionary<System.Int32Enum, object>)obj35;
						if ((nint)obj35 != 30)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
							bool flag17 = obj35 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96630");
							bool flag18 = _playerOptions == null;
							PlayerOptionsData config = _playerOptions.Config;
							bool flag19 = config == null;
							bool flag20 = config._003CUnlockedStages_003Ek__BackingField == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
							if (obj36 != null)
							{
								bool flag21 = stageData == null;
								if (!stageData._003Chidden_003Ek__BackingField && stageData._003CvalidForCharcaterData_003Ek__BackingField)
								{
									GameObject gameObject = UnityEngine.Object.Instantiate(_StagePrefab, _Container);
									bool flag22 = (object)gameObject == null;
									GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, _Container);
									string localizedName = stageData.GetLocalizedName((StageType)obj35);
									string translation = LocalizationManager.GetTranslation(localizedName, FixForRTL: true, 0, ignoreRTLnumbers: true, flag4, localParametersRoot, overrideLanguage, allowLocalizedParameters);
									bool flag23 = (object)gameObject2 == null;
									nint num7 = (nint)gameObject2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2597 @ r8_v47 (Il2CppClass<System.Func`2<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>, System.Int32>>)+558] (should have been res…");
									((UnityEngine.Object)gameObject).SetName(stageData._003CstageName_003Ek__BackingField);
									Transform transform = gameObject.transform;
									bool flag24 = (object)transform == null;
									Transform child2 = transform.GetChild(1);
									bool flag25 = (object)child2 == null;
									Image component = child2.GetComponent<Image>();
									bool flag26 = _stageIcons == null;
									bool flag27 = ((Dictionary<System.Int32Enum, object>)(object)_stageIcons).TryInsert((System.Int32Enum)obj35, (object)component, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								}
							}
						}
						obj14 = 0;
						continue;
						IL_051b:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj23 = obj37;
						obj16 = 0;
						goto IL_0b7a;
					}
					if (obj13 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					_formatSize = true;
					return;
				}
			}
		}
		goto IL_0923;
		IL_009a:
		if (_stageIcons != null)
		{
			_stageIcons.Clear();
			if (_dataManager != null)
			{
				convertedStages = _dataManager.GetConvertedStages();
				object playerOptions = _playerOptions;
				if (_playerOptions != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v33 (System.Object)+68]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v33 (System.Object)+58]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v33 (System.Object)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v33 (System.Object)+78]");
								obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v87+2CC]");
								if ((nint)0 != 0)
								{
									goto IL_0a50;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v33 (System.Object)+50]");
							obj3 = 0;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v33 (System.Object)+58]");
							obj3 = 0;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v33 (System.Object)+68]");
						obj3 = 0;
					}
					goto IL_0a50;
				}
			}
		}
		goto IL_0923;
		IL_0923:
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_005d: Invalid comparison between O and F4
		if (_formatSize)
		{
			RectTransform component = GetComponent<RectTransform>();
			Vector2 sizeDelta = component.sizeDelta;
			Vector2 sizeDelta2 = _Container.sizeDelta;
			Vector2 sizeDelta3 = default(Vector2);
			component.sizeDelta = sizeDelta3;
			Vector2 sizeDelta4 = component.sizeDelta;
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)751f))
			{
				Vector2 sizeDelta5 = component.sizeDelta;
				component.sizeDelta = sizeDelta3;
			}
		}
	}

	public unsafe void TryShow()
	{
		//IL_0111: Expected O, but got Ref
		//IL_012d: Expected O, but got I4
		//IL_0135: Expected O, but got Ref
		GameObject gameObject;
		bool active;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CHideProgress_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
					bool flag = default(bool);
					if (!flag)
					{
						if (_playerOptions != null)
						{
							PlayerOptionsData config2 = _playerOptions.Config;
							if (config2 != null && config2._003CCharacterStageData_003Ek__BackingField != null)
							{
								bool flag2 = flag;
								bool flag3 = flag;
								Dictionary<CharacterType, List<VampireSurvivors.Data.Props.CharacterStageData>>.Enumerator enumerator = default(Dictionary<CharacterType, List<VampireSurvivors.Data.Props.CharacterStageData>>.Enumerator);
								List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator enumerator2 = default(List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator);
								List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator enumerator4 = default(List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator);
								while (enumerator.MoveNext())
								{
									bool flag4 = (object)enumerator2 == null;
									List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator enumerator3 = (List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator)(&enumerator);
									if (flag4)
									{
										throw new NullReferenceException();
									}
									if (enumerator4.MoveNext())
									{
										object obj = 0;
										enumerator3 = (List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator)(&enumerator4);
										throw new NullReferenceException();
									}
								}
								gameObject = base.gameObject;
								if ((object)gameObject != null)
								{
									active = flag3;
									goto IL_0296;
								}
							}
						}
						goto IL_01d2;
					}
				}
				Debug.Log("HIDE PROGRESS BABY");
				gameObject = base.gameObject;
				if ((object)gameObject != null)
				{
					active = false;
					goto IL_0296;
				}
			}
		}
		goto IL_01d2;
		IL_01d2:
		throw new NullReferenceException();
		IL_0296:
		gameObject.SetActive(active);
	}

	public void SetPanel(CharacterType cType)
	{
		//IL_023e: Expected O, but got I4
		//IL_02f0: Expected O, but got I
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_03bc->IL043b: Incompatible stack heights: 3 vs 0
		//IL_027e->IL0415: Incompatible stack heights: 1 vs 0
		//IL_037a->IL0415: Incompatible stack heights: 3 vs 0
		Dictionary<StageType, Image>.Enumerator enumerator = default(Dictionary<StageType, Image>.Enumerator);
		while (enumerator.MoveNext())
		{
			bool flag = _stageIcons == null;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)_stageIcons).get_Item((System.Int32Enum)0);
			bool flag2 = obj == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v64 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v64 (System.Object)+10]");
			Behaviour.set_enabled_Injected((IntPtr)0, false);
		}
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData playerOptionsData;
		if (playerOptions._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions._hostGameConfig == null)
			{
				if (playerOptions._currentAdventureSaveData != null)
				{
					playerOptionsData = playerOptions._currentAdventureSaveData;
					if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0115;
					}
				}
				playerOptionsData = playerOptions._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
		}
		goto IL_0115;
		IL_0215:
		PlayerOptionsData playerOptionsData2;
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)playerOptionsData2._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)cType);
		List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator enumerator2 = default(List<VampireSurvivors.Data.Props.CharacterStageData>.Enumerator);
		while (enumerator2.MoveNext())
		{
			object obj3 = 0;
			bool flag4 = _stageIcons == null;
			Dictionary<StageType, Image> stageIcons = _stageIcons;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rbx_v13+20]");
			int num = ((Dictionary<System.Int32Enum, object>)(object)stageIcons).FindEntry((System.Int32Enum)0);
			if (!flag4)
			{
				bool flag5 = _stageIcons == null;
				Dictionary<StageType, Image> stageIcons2 = _stageIcons;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rbx_v13+20]");
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)stageIcons2).get_Item((System.Int32Enum)0);
				bool flag6 = obj4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rbx_v13+10]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rbx_v13+10]");
				object obj5 = num2 ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rbx_v13+10]");
				object obj6 = 0 & obj5;
				bool flag7 = (nint)obj6 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rbx_v13+10]");
				bool flag8 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rbx_v13+10]");
				bool flag9 = (nint)0 == 0;
				bool flag10 = flag8 == flag7;
				bool flag11 = !flag9;
				bool flag12 = flag11 & flag10;
				((Behaviour)obj4).enabled = flag12;
			}
		}
		return;
		IL_0115:
		bool flag13 = playerOptionsData._003CCharacterStageData_003Ek__BackingField == null;
		int num3 = ((Dictionary<System.Int32Enum, object>)(object)playerOptionsData._003CCharacterStageData_003Ek__BackingField).FindEntry((System.Int32Enum)cType);
		if (flag13)
		{
			return;
		}
		PlayerOptions playerOptions2 = _playerOptions;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData2 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0215;
					}
				}
				playerOptionsData2 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_0215;
	}

	public CharacterStageCompletionPanel()
	{
		Dictionary<StageType, Image> stageIcons = new Dictionary<StageType, Image>();
		_stageIcons = stageIcons;
	}
}
