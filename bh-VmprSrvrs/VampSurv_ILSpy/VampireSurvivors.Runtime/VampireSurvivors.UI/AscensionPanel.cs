using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class AscensionPanel : MonoBehaviour
{
	private TextMeshProUGUI _CompletionText;

	private TextMeshProUGUI _PortraitCompletionText;

	private AdjustValuePanel _LuckPanel;

	private AdjustValuePanel _GrowthPanel;

	private AdjustValuePanel _GreedPanel;

	private AdjustValuePanel _CursePanel;

	private List<AdjustValuePanel> _NavigationPanels;

	private Button _AscendAdventureButton;

	private UISpriteAnimation _Sheen;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private int _completionCount;

	private int _currentSpend;

	private bool _shouldGenerateNavigation;

	private PlayerOptionsData _adventurePod;

	private Selectable _selectableToReturnTo;

	private AdventureType _adventureType;

	private Transform _ascendSender;

	private void Construct(PlayerOptions player, AdventureManager adventureManager)
	{
		_playerOptions = player;
		_adventureManager = adventureManager;
	}

	private void Awake()
	{
		AdjustValuePanel.OnValueChange value = ValueChanged;
		_LuckPanel.ValueChanged += value;
		AdjustValuePanel.OnValueChange value2 = ValueChanged;
		_GreedPanel.ValueChanged += value2;
		AdjustValuePanel.OnValueChange value3 = ValueChanged;
		_GrowthPanel.ValueChanged += value3;
		AdjustValuePanel.OnValueChange value4 = ValueChanged;
		_CursePanel.ValueChanged += value4;
	}

	private void OnDestroy()
	{
		AdjustValuePanel.OnValueChange value = ValueChanged;
		_LuckPanel.ValueChanged -= value;
		AdjustValuePanel.OnValueChange value2 = ValueChanged;
		_GreedPanel.ValueChanged -= value2;
		AdjustValuePanel.OnValueChange value3 = ValueChanged;
		_GrowthPanel.ValueChanged -= value3;
		AdjustValuePanel.OnValueChange value4 = ValueChanged;
		_CursePanel.ValueChanged -= value4;
	}

	private void LateUpdate()
	{
		if (_shouldGenerateNavigation)
		{
			GenerateNavigation();
			_shouldGenerateNavigation = false;
		}
	}

	private void OnEnable()
	{
		//IL_0014: Expected I4, but got O
		AdventureManager adventureManager = _adventureManager;
		Action<bool> action = null;
		((AscensionPanel)(object)action).OnAdventureAscended((byte)(int)this != 0);
		Delegate obj = Delegate.Combine(adventureManager._003COnAdventureAscended_003Ek__BackingField, action);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureAscended_003Ek__BackingField = (Action<bool>)obj;
	}

	private void OnAdventureAscended(bool obj)
	{
		_Sheen.Play();
	}

	private void OnDisable()
	{
		//IL_0014: Expected I4, but got O
		AdventureManager adventureManager = _adventureManager;
		Action<bool> action = null;
		((AscensionPanel)(object)action).OnAdventureAscended((byte)(int)this != 0);
		Delegate obj = Delegate.Remove(adventureManager._003COnAdventureAscended_003Ek__BackingField, action);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureAscended_003Ek__BackingField = (Action<bool>)obj;
	}

	public void SetData(PlayerOptionsData adventurePod, AdventureType adventureType)
	{
		_adventurePod = adventurePod;
		_adventureType = adventureType;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 51 Invalid \"Jump target not found in method: 0x18699A8F0\"");
	}

	public void RefreshData()
	{
		//IL_0137: Expected O, but got I
		//IL_0153: Expected O, but got I4
		//IL_0624: Expected F4, but got I4
		//IL_01bf: Expected O, but got I
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected I4, but got Unknown
		//IL_0268: Expected O, but got I
		//IL_0284: Expected O, but got I4
		//IL_06d2: Expected F4, but got I4
		//IL_02f0: Expected O, but got I
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected I4, but got Unknown
		//IL_0399: Expected O, but got I
		//IL_03b5: Expected O, but got I4
		//IL_0780: Expected F4, but got I4
		//IL_0421: Expected O, but got I
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected I4, but got Unknown
		//IL_04ca: Expected O, but got I
		//IL_04e6: Expected O, but got I4
		//IL_0826: Expected F4, but got I4
		//IL_0552: Expected O, but got I
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Expected O, but got Unknown
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Expected I4, but got Unknown
		PlayerOptionsData adventurePod = _adventurePod;
		Button ascendAdventureButton = _AscendAdventureButton;
		_currentSpend = 0;
		_completionCount = adventurePod._003CAdventureCompletionCount_003Ek__BackingField;
		if ((object)_AscendAdventureButton != null && ((UnityEngine.Object)ascendAdventureButton).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _AscendAdventureButton.gameObject;
			bool active = _adventureManager.CanAscend(_adventureType);
			gameObject.SetActive(active);
		}
		PlayerOptionsData adventurePod2 = _adventurePod;
		Dictionary<PowerUpType, int> dictionary = adventurePod2._003CAscensionPointsAllocation_003Ek__BackingField;
		int num = adventurePod2._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.LUCK);
		if (num < 0)
		{
			AdjustValuePanel luckPanel = _LuckPanel;
			luckPanel._pointsAssigned = 0;
			luckPanel._displayValue = 0f;
			luckPanel.Refresh();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdi_v5 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, System.Int32>)+18]");
			object obj = 0;
			AdjustValuePanel luckPanel2 = _LuckPanel;
			object obj2 = num + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v46+2C+v135 @ rax_v82*8]");
			luckPanel2._pointsAssigned = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v46+2C+v135 @ rax_v82*8]");
			bool flag = (nint)0 >= (nint)1;
			int num2 = 25;
			if (!flag)
			{
				num2 = 0;
			}
			int num3 = num2 + 25;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v46+2C+v135 @ rax_v82*8]");
			if ((nint)0 < (nint)2)
			{
				num3 = num2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v46+2C+v135 @ rax_v82*8]");
			if ((nint)0 >= (nint)3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v46+2C+v135 @ rax_v82*8]");
				object obj3 = -2;
				object obj4 = obj3 * 25;
				num3 += obj4;
			}
			luckPanel2._displayValue = num3;
			luckPanel2.Refresh();
			int currentSpend = _currentSpend;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v46+2C+v135 @ rax_v82*8]");
			int currentSpend2 = (int)((nint)currentSpend + (nint)0);
			_currentSpend = currentSpend2;
		}
		PlayerOptionsData adventurePod3 = _adventurePod;
		Dictionary<PowerUpType, int> dictionary2 = adventurePod3._003CAscensionPointsAllocation_003Ek__BackingField;
		int num4 = adventurePod3._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.GROWTH);
		if (num4 < 0)
		{
			AdjustValuePanel growthPanel = _GrowthPanel;
			growthPanel._pointsAssigned = 0;
			growthPanel._displayValue = 0f;
			growthPanel.Refresh();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v7 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, System.Int32>)+18]");
			object obj5 = 0;
			AdjustValuePanel growthPanel2 = _GrowthPanel;
			object obj6 = num4 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v20+2C+v139 @ rax_v64*8]");
			growthPanel2._pointsAssigned = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v20+2C+v139 @ rax_v64*8]");
			bool flag2 = (nint)0 >= (nint)1;
			int num5 = 25;
			if (!flag2)
			{
				num5 = 0;
			}
			int num6 = num5 + 25;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v20+2C+v139 @ rax_v64*8]");
			if ((nint)0 < (nint)2)
			{
				num6 = num5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v20+2C+v139 @ rax_v64*8]");
			if ((nint)0 >= (nint)3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v20+2C+v139 @ rax_v64*8]");
				object obj7 = -2;
				object obj8 = obj7 * 25;
				num6 += obj8;
			}
			growthPanel2._displayValue = num6;
			growthPanel2.Refresh();
			int currentSpend3 = _currentSpend;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdi_v20+2C+v139 @ rax_v64*8]");
			int currentSpend4 = (int)((nint)currentSpend3 + (nint)0);
			_currentSpend = currentSpend4;
		}
		PlayerOptionsData adventurePod4 = _adventurePod;
		Dictionary<PowerUpType, int> dictionary3 = adventurePod4._003CAscensionPointsAllocation_003Ek__BackingField;
		int num7 = adventurePod4._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.GREED);
		if (num7 < 0)
		{
			AdjustValuePanel greedPanel = _GreedPanel;
			greedPanel._pointsAssigned = 0;
			greedPanel._displayValue = 0f;
			greedPanel.Refresh();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v9 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, System.Int32>)+18]");
			object obj9 = 0;
			AdjustValuePanel greedPanel2 = _GreedPanel;
			object obj10 = num7 + num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v17+2C+v143 @ rax_v46*8]");
			greedPanel2._pointsAssigned = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v17+2C+v143 @ rax_v46*8]");
			bool flag3 = (nint)0 >= (nint)1;
			int num8 = 25;
			if (!flag3)
			{
				num8 = 0;
			}
			int num9 = num8 + 25;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v17+2C+v143 @ rax_v46*8]");
			if ((nint)0 < (nint)2)
			{
				num9 = num8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v17+2C+v143 @ rax_v46*8]");
			if ((nint)0 >= (nint)3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v17+2C+v143 @ rax_v46*8]");
				object obj11 = -2;
				object obj12 = obj11 * 25;
				num9 += obj12;
			}
			greedPanel2._displayValue = num9;
			greedPanel2.Refresh();
			int currentSpend5 = _currentSpend;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v17+2C+v143 @ rax_v46*8]");
			int currentSpend6 = (int)((nint)currentSpend5 + (nint)0);
			_currentSpend = currentSpend6;
		}
		PlayerOptionsData adventurePod5 = _adventurePod;
		Dictionary<PowerUpType, int> dictionary4 = adventurePod5._003CAscensionPointsAllocation_003Ek__BackingField;
		int num10 = adventurePod5._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.CURSE);
		if (num10 < 0)
		{
			AdjustValuePanel cursePanel = _CursePanel;
			cursePanel._pointsAssigned = 0;
			cursePanel._displayValue = 0f;
			cursePanel.Refresh();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v11 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, System.Int32>)+18]");
			object obj13 = 0;
			AdjustValuePanel cursePanel2 = _CursePanel;
			object obj14 = num10 + num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdi_v14+2C+v147 @ rax_v31*8]");
			cursePanel2._pointsAssigned = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdi_v14+2C+v147 @ rax_v31*8]");
			bool flag4 = (nint)0 >= (nint)1;
			int num11 = 25;
			if (!flag4)
			{
				num11 = 0;
			}
			int num12 = num11 + 25;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdi_v14+2C+v147 @ rax_v31*8]");
			if ((nint)0 < (nint)2)
			{
				num12 = num11;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdi_v14+2C+v147 @ rax_v31*8]");
			if ((nint)0 >= (nint)3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdi_v14+2C+v147 @ rax_v31*8]");
				object obj15 = -2;
				object obj16 = obj15 * 25;
				num12 += obj16;
			}
			cursePanel2._displayValue = num12;
			cursePanel2.Refresh();
			int currentSpend7 = _currentSpend;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdi_v14+2C+v147 @ rax_v31*8]");
			int currentSpend8 = (int)((nint)currentSpend7 + (nint)0);
			_currentSpend = currentSpend8;
		}
		SetInteractionsFromSpend();
	}

	public void SetRegenerateNavigation()
	{
		_shouldGenerateNavigation = true;
	}

	public void SetSelected(Selectable selectedItem)
	{
		_selectableToReturnTo = selectedItem;
		_shouldGenerateNavigation = true;
	}

	public Selectable GetFirstSelectable()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		List<AdjustValuePanel> navigationPanels = _NavigationPanels;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj < navigationPanels._size)
			{
				if ((nint)obj2 >= navigationPanels._size)
				{
					break;
				}
				AdjustValuePanel[] items = navigationPanels._items;
				AdjustValuePanel adjustValuePanel = items[obj2];
				Selectable selectable = adjustValuePanel._UpButton;
				if (!selectable.m_Interactable)
				{
					selectable = adjustValuePanel._DownButton;
					if (!selectable.m_Interactable)
					{
						obj2++;
						obj = obj2;
						continue;
					}
				}
				return selectable;
			}
			Debug.LogError("No valid selectable found in ascension panel");
			return null;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Selectable result = default(Selectable);
		return result;
	}

	public Selectable GetLastSelectable()
	{
		//IL_0018: Expected O, but got I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		List<AdjustValuePanel> navigationPanels = _NavigationPanels;
		bool flag = (nint)_NavigationPanels < 0;
		object obj = navigationPanels._size - 1;
		if (!flag)
		{
			List<AdjustValuePanel> navigationPanels2 = _NavigationPanels;
			Selectable result = default(Selectable);
			while (true)
			{
				if ((nint)obj < navigationPanels2._size)
				{
					AdjustValuePanel[] items = navigationPanels2._items;
					AdjustValuePanel adjustValuePanel = items[obj];
					Selectable selectable = adjustValuePanel._UpButton;
					if (!selectable.m_Interactable)
					{
						selectable = adjustValuePanel._DownButton;
						if (!selectable.m_Interactable)
						{
							obj--;
							if ((selectable.m_Interactable ? 1 : 0) < (false ? 1 : 0))
							{
								break;
							}
							continue;
						}
					}
					return selectable;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		Debug.LogError("No valid selectable found in ascension panel");
		return null;
	}

	public unsafe void GenerateNavigation()
	{
		//IL_030c: Expected O, but got I4
		//IL_0315: Expected O, but got I4
		//IL_0096: Expected O, but got Ref
		//IL_00ba: Expected O, but got Ref
		//IL_0132: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_026d: Expected O, but got I
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0191: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_0215: Expected O, but got I
		//IL_022f: Expected O, but got I
		//IL_01b9: Expected O, but got I4
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02eb: Expected O, but got I4
		List<AdjustValuePanel> navigationPanels = _NavigationPanels;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while (true)
		{
			if ((nint)obj2 >= navigationPanels._size)
			{
				return;
			}
			List<AdjustValuePanel> navigationPanels2 = _NavigationPanels;
			if ((nint)obj >= navigationPanels2._size)
			{
				break;
			}
			AdjustValuePanel[] items = navigationPanels2._items;
			AdjustValuePanel adjustValuePanel = items[obj];
			adjustValuePanel._UpButton.navigation = (Navigation)(&obj3);
			Selectable downButton = adjustValuePanel._DownButton;
			adjustValuePanel._DownButton.navigation = (Navigation)(&obj3);
			Selectable upButton = adjustValuePanel._UpButton;
			Selectable origin = (upButton.m_Interactable ? upButton : adjustValuePanel._DownButton);
			Extensions.SetNavigationRight(origin, _selectableToReturnTo);
			Extensions.SetNavigationDown(adjustValuePanel._UpButton);
			Extensions.SetNavigationDown(adjustValuePanel._DownButton);
			List<AdjustValuePanel> navigationPanels3 = _NavigationPanels;
			object obj4 = navigationPanels3._size - 1;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
			object obj5 = 0;
			if (!flag)
			{
				object obj6 = obj + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Button downButton2 = adjustValuePanel._DownButton;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v41+38]");
				Extensions.SetNavigationDown(downButton2, (Selectable)0);
				Button upButton2 = adjustValuePanel._UpButton;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v41+30]");
				Extensions.SetNavigationDown(upButton2, (Selectable)0);
				obj5 = 0;
			}
			if ((nint)obj > 0)
			{
				object obj7 = obj - 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Button upButton3 = adjustValuePanel._UpButton;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v38+30]");
				Extensions.SetNavigationUp(upButton3, (Selectable)0);
				Button downButton3 = adjustValuePanel._DownButton;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v38+38]");
				Extensions.SetNavigationUp(downButton3, (Selectable)0);
			}
			Extensions.SetNavigationLeft(adjustValuePanel._UpButton, adjustValuePanel._DownButton);
			Button downButton4 = adjustValuePanel._DownButton;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v23 (UnityEngine.UI.Button)+48]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rax_v23 (UnityEngine.UI.Button)+48]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ xmm0_v10+10]");
				if ((nint)0 != 0)
				{
					goto IL_02c5;
				}
			}
			Extensions.SetNavigationRight(adjustValuePanel._DownButton, adjustValuePanel._UpButton);
			goto IL_02c5;
			IL_02c5:
			navigationPanels = _NavigationPanels;
			obj++;
			obj3 = 4;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Apply()
	{
		if (_adventurePod != null)
		{
			PlayerOptionsData adventurePod = _adventurePod;
			int num = adventurePod._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.LUCK);
			PlayerOptionsData adventurePod2 = _adventurePod;
			Dictionary<System.Int32Enum, int> dictionary;
			int pointsAssigned;
			System.Collections.Generic.InsertionBehavior behavior;
			if (num < 0)
			{
				AdjustValuePanel luckPanel = _LuckPanel;
				dictionary = (Dictionary<System.Int32Enum, int>)(object)adventurePod2._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned = luckPanel._pointsAssigned;
				behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			}
			else
			{
				AdjustValuePanel luckPanel2 = _LuckPanel;
				dictionary = (Dictionary<System.Int32Enum, int>)(object)adventurePod2._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned = luckPanel2._pointsAssigned;
				behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			}
			bool flag = dictionary.TryInsert((System.Int32Enum)11, pointsAssigned, behavior);
			PlayerOptionsData adventurePod3 = _adventurePod;
			int num2 = adventurePod3._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.GREED);
			PlayerOptionsData adventurePod4 = _adventurePod;
			Dictionary<System.Int32Enum, int> dictionary2;
			int pointsAssigned2;
			System.Collections.Generic.InsertionBehavior behavior2;
			if (num2 < 0)
			{
				AdjustValuePanel greedPanel = _GreedPanel;
				dictionary2 = (Dictionary<System.Int32Enum, int>)(object)adventurePod4._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned2 = greedPanel._pointsAssigned;
				behavior2 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			}
			else
			{
				AdjustValuePanel greedPanel2 = _GreedPanel;
				dictionary2 = (Dictionary<System.Int32Enum, int>)(object)adventurePod4._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned2 = greedPanel2._pointsAssigned;
				behavior2 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			}
			bool flag2 = dictionary2.TryInsert((System.Int32Enum)13, pointsAssigned2, behavior2);
			PlayerOptionsData adventurePod5 = _adventurePod;
			int num3 = adventurePod5._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.GROWTH);
			PlayerOptionsData adventurePod6 = _adventurePod;
			Dictionary<System.Int32Enum, int> dictionary3;
			int pointsAssigned3;
			System.Collections.Generic.InsertionBehavior behavior3;
			if (num3 < 0)
			{
				AdjustValuePanel growthPanel = _GrowthPanel;
				dictionary3 = (Dictionary<System.Int32Enum, int>)(object)adventurePod6._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned3 = growthPanel._pointsAssigned;
				behavior3 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			}
			else
			{
				AdjustValuePanel growthPanel2 = _GrowthPanel;
				dictionary3 = (Dictionary<System.Int32Enum, int>)(object)adventurePod6._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned3 = growthPanel2._pointsAssigned;
				behavior3 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			}
			bool flag3 = dictionary3.TryInsert((System.Int32Enum)12, pointsAssigned3, behavior3);
			PlayerOptionsData adventurePod7 = _adventurePod;
			int num4 = adventurePod7._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.CURSE);
			PlayerOptionsData adventurePod8 = _adventurePod;
			Dictionary<System.Int32Enum, int> dictionary4;
			int pointsAssigned4;
			System.Collections.Generic.InsertionBehavior behavior4;
			if (num4 < 0)
			{
				AdjustValuePanel cursePanel = _CursePanel;
				dictionary4 = (Dictionary<System.Int32Enum, int>)(object)adventurePod8._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned4 = cursePanel._pointsAssigned;
				behavior4 = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			}
			else
			{
				AdjustValuePanel cursePanel2 = _CursePanel;
				dictionary4 = (Dictionary<System.Int32Enum, int>)(object)adventurePod8._003CAscensionPointsAllocation_003Ek__BackingField;
				pointsAssigned4 = cursePanel2._pointsAssigned;
				behavior4 = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			}
			bool flag4 = dictionary4.TryInsert((System.Int32Enum)14, pointsAssigned4, behavior4);
			Debug.Log("Saving");
			_playerOptions.Save();
		}
	}

	private void ValueChanged(AdjustValuePanel panel, bool positive)
	{
		//IL_0096: Expected O, but got I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected I4, but got Unknown
		//IL_002a: Expected F4, but got I4
		//IL_0041: Expected F4, but got I4
		//IL_0066: Expected O, but got I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		object obj = (positive ? 1 : 0) * 2;
		object obj2 = obj - 1;
		int currentSpend = _currentSpend + obj2;
		_currentSpend = currentSpend;
		bool flag = panel._pointsAssigned >= 1;
		float num = 25f;
		if (!flag)
		{
			num = 0f;
		}
		float num2 = num + 25f;
		if (panel._pointsAssigned < 2)
		{
			num2 = num;
		}
		if (panel._pointsAssigned >= 3)
		{
			object obj3 = panel._pointsAssigned - 2;
			object obj4 = obj3 * 25;
			num2 += (float)obj4;
		}
		panel._displayValue = num2;
		panel.Refresh();
		Apply();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 116 Invalid \"Jump target not found in method: 0x18699BAC0\"");
		throw new NullReferenceException();
	}

	private unsafe void SetInteractionsFromSpend()
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected I4, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected I4, but got Unknown
		bool panelsInteractionUp = ((_currentSpend < AdventureManager.MAX_ASCENSION_POINTS && _currentSpend < _completionCount) ? true : false);
		SetPanelsInteractionUp(panelsInteractionUp);
		int num = this + 124;
		string text = ((int*)num)->ToString();
		int num2 = this + 120;
		string text2 = ((int*)num2)->ToString();
		string text3 = text + "/" + text2;
		_CompletionText.text = text3;
		TextMeshProUGUI portraitCompletionText = _PortraitCompletionText;
		if ((object)_PortraitCompletionText != null && ((UnityEngine.Object)portraitCompletionText).m_CachedPtr != (IntPtr)0)
		{
			string text4 = _CompletionText.text;
			_PortraitCompletionText.text = text4;
		}
	}

	private void SetPanelsInteractionUp(bool enabled)
	{
		//IL_0076: Expected O, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected I4, but got Unknown
		//IL_0143: Expected O, but got I4
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected I4, but got Unknown
		//IL_0210: Expected O, but got I4
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected I4, but got Unknown
		//IL_02dd: Expected O, but got I4
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected I4, but got Unknown
		PlayerOptionsData adventurePod = _adventurePod;
		int num = adventurePod._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.LUCK);
		bool flag = num < 0;
		bool flag2 = true;
		if (!flag)
		{
			PlayerOptionsData adventurePod2 = _adventurePod;
			int num2 = adventurePod2._003CAscensionPointsAllocation_003Ek__BackingField.get_Item(PowerUpType.LUCK);
			object obj = num2 - 20;
			int num3 = num2 ^ 0x14;
			int num4 = num2 ^ obj;
			int num5 = num3 & num4;
			bool flag3 = num5 < 0;
			bool flag4 = (nint)obj < 0;
			flag2 = flag4 != flag3;
		}
		PlayerOptionsData adventurePod3 = _adventurePod;
		int num6 = adventurePod3._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.GREED);
		bool flag5 = num6 < 0;
		bool flag6 = true;
		if (!flag5)
		{
			PlayerOptionsData adventurePod4 = _adventurePod;
			int num7 = adventurePod4._003CAscensionPointsAllocation_003Ek__BackingField.get_Item(PowerUpType.GREED);
			object obj2 = num7 - 20;
			int num8 = num7 ^ 0x14;
			int num9 = num7 ^ obj2;
			int num10 = num8 & num9;
			bool flag7 = num10 < 0;
			bool flag8 = (nint)obj2 < 0;
			flag6 = flag8 != flag7;
		}
		PlayerOptionsData adventurePod5 = _adventurePod;
		int num11 = adventurePod5._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.GROWTH);
		bool flag9 = num11 < 0;
		bool flag10 = true;
		if (!flag9)
		{
			PlayerOptionsData adventurePod6 = _adventurePod;
			int num12 = adventurePod6._003CAscensionPointsAllocation_003Ek__BackingField.get_Item(PowerUpType.GROWTH);
			object obj3 = num12 - 10;
			int num13 = num12 ^ 0xA;
			int num14 = num12 ^ obj3;
			int num15 = num13 & num14;
			bool flag11 = num15 < 0;
			bool flag12 = (nint)obj3 < 0;
			flag10 = flag12 != flag11;
		}
		PlayerOptionsData adventurePod7 = _adventurePod;
		int num16 = adventurePod7._003CAscensionPointsAllocation_003Ek__BackingField.FindEntry(PowerUpType.CURSE);
		bool flag13 = num16 < 0;
		bool flag14 = true;
		if (!flag13)
		{
			PlayerOptionsData adventurePod8 = _adventurePod;
			int num17 = adventurePod8._003CAscensionPointsAllocation_003Ek__BackingField.get_Item(PowerUpType.CURSE);
			object obj4 = num17 - 10;
			int num18 = num17 ^ 0xA;
			int num19 = num17 ^ obj4;
			int num20 = num18 & num19;
			bool flag15 = num20 < 0;
			bool flag16 = (nint)obj4 < 0;
			flag14 = flag16 != flag15;
		}
		AdjustValuePanel luckPanel = _LuckPanel;
		bool canGoUp = enabled & flag2;
		luckPanel._canGoUp = canGoUp;
		luckPanel.Refresh();
		bool canGoUp2 = flag10;
		if (!enabled)
		{
			canGoUp2 = false;
		}
		AdjustValuePanel growthPanel = _GrowthPanel;
		growthPanel._canGoUp = canGoUp2;
		growthPanel.Refresh();
		bool canGoUp3 = flag6;
		if (!enabled)
		{
			canGoUp3 = false;
		}
		AdjustValuePanel greedPanel = _GreedPanel;
		greedPanel._canGoUp = canGoUp3;
		greedPanel.Refresh();
		bool canGoUp4 = flag14;
		if (!enabled)
		{
			canGoUp4 = false;
		}
		AdjustValuePanel cursePanel = _CursePanel;
		cursePanel._canGoUp = canGoUp4;
		cursePanel.Refresh();
	}

	public AscensionPanel()
	{
		List<AdjustValuePanel> navigationPanels = new List<AdjustValuePanel>();
		_NavigationPanels = navigationPanels;
	}
}
