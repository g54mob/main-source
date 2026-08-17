using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class MegaSealPanel : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ContentGroupType, int> _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CStart_003Eb__7_0(ContentGroupType v)
		{
			//IL_005b: Expected I4, but got O
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected I4, but got Unknown
			DlcType? dlcTypeContentGroup = ContentGroupMethods.GetDlcTypeContentGroup(v);
			if ((object)dlcTypeContentGroup == null)
			{
				return (int)v;
			}
			List<DlcType> sortedDlcTypes = DlcSorting.SortedDlcTypes;
			if (sortedDlcTypes != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj = default(object);
				return obj + 10;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private GameObject _DLCSealPrefab;

	private PlayerOptions _playerOptions;

	private CollectionsPage _page;

	private List<DLCSealItem> _dlcSealItems;

	public bool IsAvailable
	{
		get
		{
			//IL_01ba: Expected I4, but got O
			//IL_00e5: Expected O, but got I4
			//IL_012d: Expected O, but got I
			//IL_019a: Expected O, but got I4
			//IL_01a7: Expected I4, but got O
			if (_playerOptions != null)
			{
				int maxSeals = _playerOptions.GetMaxSeals();
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						int num = config._003CSeals_003Ek__BackingField ^ config._003CSeals_003Ek__BackingField;
						int num2 = config._003CSeals_003Ek__BackingField & num;
						bool flag = num2 < 0;
						bool flag2 = config._003CSeals_003Ek__BackingField < 0;
						bool flag3 = config._003CSeals_003Ek__BackingField == 0;
						bool flag4 = flag2 == flag;
						bool flag5 = !flag3;
						object obj = flag5 & flag4;
						Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
						if (loadedDlc != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v7 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.DlcType, VampireSurvivors.Framework.DLC.BundleManifestData>)+20]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v7 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.DlcType, VampireSurvivors.Framework.DLC.BundleManifestData>)+28]");
							object obj2 = num3 - 0;
							object obj3 = obj2 ^ obj2;
							object obj4 = obj2 & obj3;
							bool flag6 = (nint)obj4 < 0;
							bool flag7 = (nint)obj2 < 0;
							bool flag8 = obj2 == null;
							bool flag9 = flag7 == flag6;
							bool flag10 = !flag8;
							object obj5 = flag10 & flag9;
							return (byte)(obj5 & obj) != 0;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void Construct(PlayerOptions player)
	{
		_playerOptions = player;
	}

	private unsafe void Start()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003f: Expected O, but got I4
		//IL_018e: Expected O, but got Ref
		//IL_0193: Expected I, but got O
		//IL_027f: Expected O, but got I4
		//IL_022d: Expected O, but got I
		//IL_02d8: Expected I, but got O
		//IL_02b2: Expected I, but got O
		//IL_0300: Expected O, but got I
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = 0;
		object obj5 = default(object);
		object obj4 = obj5;
		if (obj4 != null)
		{
			object obj6 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v162 @ rdx_v5+8F8] (should have been resolved before IL gen)");
			Func<ContentGroupType, int> func = _003C_003Ec._003C_003E9__7_0;
			ContentGroupType contentGroupType = default(ContentGroupType);
			if (_003C_003Ec._003C_003E9__7_0 != null)
			{
				if (contentGroupType == ContentGroupType.BASE)
				{
					object obj7 = obj3;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj8 = default(object);
					if (obj8 == null)
					{
						throw new InvalidCastException();
					}
					object obj7 = obj8;
				}
			}
			else
			{
				if (contentGroupType == ContentGroupType.BASE)
				{
					object obj7 = obj3;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj9 = default(object);
					if (obj9 == null)
					{
						throw new InvalidCastException();
					}
					object obj7 = obj9;
				}
				func = (_003C_003Ec._003C_003E9__7_0 = delegate(ContentGroupType v)
				{
					//IL_005b: Expected I4, but got O
					//IL_0043: Unknown result type (might be due to invalid IL or missing references)
					//IL_0048: Expected I4, but got Unknown
					DlcType? dlcTypeContentGroup = ContentGroupMethods.GetDlcTypeContentGroup(v);
					if ((object)dlcTypeContentGroup == null)
					{
						return (int)v;
					}
					List<DlcType> sortedDlcTypes = DlcSorting.SortedDlcTypes;
					if (sortedDlcTypes == null)
					{
						NullReferenceException ex2 = new NullReferenceException();
						return (int)ex2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj24 = default(object);
					return obj24 + 10;
				});
			}
			object obj10 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A8DE30");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj12 = default(object);
			object obj11 = (object)(&obj12);
			nint num = unchecked((nint)null);
			ContentGroupType contentGroupType2 = ContentGroupType.BASE;
			object obj13 = default(object);
			object obj23 = default(object);
			ContentGroupType contentGroupType3 = default(ContentGroupType);
			while (true)
			{
				object obj15;
				object obj22;
				if (obj12 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj13 != null)
					{
						bool flag = obj12 == null;
						contentGroupType2 = ContentGroupType.BASE;
						if (flag)
						{
							break;
						}
						object obj14 = obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ r10_v7+12E]");
						if ((nint)obj3 >= 0)
						{
							goto IL_026c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ r10_v7+B0]");
						obj15 = 0;
						object obj16 = obj3;
						while (true)
						{
							object obj17 = obj16 + obj16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ r8_v14+v747 @ rax_v48*8]");
							if (0 == (nint)typeof(IEnumerator<ContentGroupType>))
							{
								break;
							}
							obj16++;
							object obj18 = obj16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ r10_v7+12E]");
							if ((nint)obj18 < 0)
							{
								continue;
							}
							goto IL_026c;
						}
						object obj19 = obj16 + obj16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ r8_v14+8+v803 @ rcx_v42*8]");
						object obj20 = (nint)0 << 4;
						object obj21 = obj20 + 312;
						obj22 = obj21 + obj14;
						goto IL_044c;
					}
					if (obj11 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					return;
				}
				throw new NullReferenceException();
				IL_026c:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj15 = 0;
				obj22 = obj23;
				goto IL_044c;
				IL_044c:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v808 @ rdx_v20] (should have been resolved before IL gen)");
				if (contentGroupType3 > ContentGroupType.EXTRA)
				{
					bool flag2 = ContentGroupMethods.IsDlcLoadedForContentGroup(contentGroupType3);
					bool flag3 = !flag2;
					num = (nint)typeof(IEnumerator<ContentGroupType>);
					if (flag3)
					{
						continue;
					}
				}
				SpawnDLC(contentGroupType3);
				num = (nint)typeof(IEnumerator<ContentGroupType>);
			}
			throw new NullReferenceException();
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		ex._002Ector("enumType");
		throw ex;
	}

	public void TryShow()
	{
		if (IsAvailable)
		{
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				if (_dlcSealItems != null)
				{
					List<DLCSealItem>.Enumerator enumerator = default(List<DLCSealItem>.Enumerator);
					if (enumerator.MoveNext())
					{
						ContentGroupType contentGroupType = ContentGroupType.BASE;
						ContentGroupType contentGroupType2 = ContentGroupType.BASE;
						throw new NullReferenceException();
					}
					return;
				}
			}
		}
		else
		{
			GameObject gameObject2 = base.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void Initialize(CollectionsPage page)
	{
		_page = page;
	}

	private void SpawnDLC(ContentGroupType group)
	{
		//IL_00a1: Expected O, but got I
		Transform parent = base.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(_DLCSealPrefab, parent);
		DLCSealItem component = gameObject.GetComponent<DLCSealItem>();
		List<object> dlcSealItems = (List<object>)(object)_dlcSealItems;
		int version = dlcSealItems._version + 1;
		dlcSealItems._version = version;
		object[] items = dlcSealItems._items;
		if (dlcSealItems._size >= items.Length)
		{
			dlcSealItems.AddWithResize((object)component);
			DLCSealItem dLCSealItem = (DLCSealItem)0;
		}
		else
		{
			int size = dlcSealItems._size + 1;
			dlcSealItems._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			DLCSealItem dLCSealItem = component;
		}
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FEF0");
		bool isBanished = default(bool);
		component._isBanished = isBanished;
		component._megaSealPanel = this;
		component._type = group;
		string localizedName = ContentGroupMethods.GetLocalizedName(group);
		component._Name.text = localizedName;
		component.ApplySetting();
		Button component2 = component.GetComponent<Button>();
		UnityAction call = component.Toggle;
		component2.m_OnClick.AddListener(call);
	}

	public unsafe void SetBanished(ContentGroupType t, bool isBanished, bool playSound, bool updatePage = true)
	{
		//IL_01e2: Expected O, but got Ref
		//IL_0131: Expected O, but got I
		//IL_018a: Expected O, but got I
		SfxType sfxType;
		if (!isBanished)
		{
			PlayerOptionsData config = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FEF0");
			object obj = default(object);
			if (obj != null)
			{
				PlayerOptionsData config2 = _playerOptions.Config;
				bool flag = ((List<System.Int32Enum>)(object)config2.BanishedContentGroups).Remove((System.Int32Enum)t);
				_page.UnBanishGroup(t);
				if (playSound)
				{
					sfxType = SfxType.ClickIn;
					goto IL_0244;
				}
			}
		}
		else
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FEF0");
			object obj2 = default(object);
			if (obj2 == null)
			{
				PlayerOptionsData config4 = _playerOptions.Config;
				List<System.Int32Enum> banishedContentGroups = (List<System.Int32Enum>)(object)config4.BanishedContentGroups;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r8_v8+18]");
				if (num >= 0)
				{
					banishedContentGroups.AddWithResize((System.Int32Enum)t);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					object obj4 = (nint)0 + (nint)1;
				}
				_page.BanishGroup(t);
				if (playSound)
				{
					sfxType = SfxType.Banish;
					goto IL_0244;
				}
			}
		}
		goto IL_01d9;
		IL_01d9:
		object obj5 = default(object);
		string text = ((Enum)(&obj5)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag2 = !isBanished;
		string text2 = "False";
		if (!flag2)
		{
			text2 = "True";
		}
		string message = text + "Is banished ? " + text2;
		Debug.Log(message);
		return;
		IL_0244:
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, null, 0f, 10, time);
		goto IL_01d9;
	}

	public void UnsealAll(bool playSound = true)
	{
		//IL_04b3: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_04d4: Expected O, but got I4
		//IL_04dd: Expected O, but got I4
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0440: Expected F4, but got I4
		PlayerOptionsData config = _playerOptions.Config;
		List<ContentGroupType> list = (List<ContentGroupType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)config.BanishedContentGroups);
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		bool flag = default(bool);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-48_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-48_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-48_v3+10]");
						object obj5 = 0;
						obj4 = obj6 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rdx_v20+20+v464 @ stack_-40_v2*4]");
						SetBanished(ContentGroupType.BASE, isBanished: false, playSound: false, flag);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)0;
		PlayerOptionsData playerOptionsData;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ stack_-48_v3+1C]");
			if (obj2 == null)
			{
				DLCSealItem[] componentsInChildren = GetComponentsInChildren<DLCSealItem>();
				object obj7 = 0;
				object obj8 = 0;
				while ((nint)obj8 < componentsInChildren.Length)
				{
					DLCSealItem dLCSealItem = componentsInChildren[obj7];
					dLCSealItem._isBanished = false;
					dLCSealItem.ApplySetting();
					obj7++;
					obj8 = obj7;
				}
				PlayerOptions playerOptions = _playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0513;
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
				goto IL_0513;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			list2 = null;
		}
		throw new NullReferenceException();
		IL_054a:
		PlayerOptionsData playerOptionsData2;
		List<WeaponType> list3 = playerOptionsData2._003CContentGroupSealedWeapons_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData playerOptionsData3;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData3 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0581;
					}
				}
				playerOptionsData3 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_0581;
		IL_0513:
		List<ItemType> list4 = playerOptionsData._003CContentGroupSealedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		PlayerOptions playerOptions3 = _playerOptions;
		if (playerOptions3._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions3._hostGameConfig == null)
			{
				if (playerOptions3._currentAdventureSaveData != null)
				{
					playerOptionsData2 = playerOptions3._currentAdventureSaveData;
					if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_054a;
					}
				}
				playerOptionsData2 = playerOptions3._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions3._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions3._onlineClientWithRunDataConfig;
		}
		goto IL_054a;
		IL_0581:
		List<ContentGroupType> banishedContentGroups = playerOptionsData3.BanishedContentGroups;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.ContentGroupType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		if (playSound)
		{
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, flag ? 1 : 0);
		}
	}

	private bool IsBanished(ContentGroupType group)
	{
		//IL_0070: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config.BanishedContentGroups != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FEF0");
				bool result = default(bool);
				return result;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public MegaSealPanel()
	{
		List<DLCSealItem> dlcSealItems = new List<DLCSealItem>();
		_dlcSealItems = dlcSealItems;
	}
}
