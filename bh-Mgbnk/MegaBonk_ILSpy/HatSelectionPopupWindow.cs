using System;
using System.Collections.Generic;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;

public class HatSelectionPopupWindow : Window
{
	public HatSelection hatSelection;

	private List<MyButtonHat> hatButtons;

	public GameObject hatButtonPrefab;

	private HatData selectedHatBeforeOpenWindow;

	public MyButton b_hats;

	private HatData hatDataHover;

	public RectTransform windowRect;

	private new void Update()
	{
		base.Update();
		if (Input.GetKeyDownInt(KeyCode.Mouse0))
		{
			Vector3 mousePosition = Input.mousePosition;
			Vector2 screenPoint = default(Vector2);
			if (!RectTransformUtility.RectangleContainsScreenPoint(windowRect, screenPoint, null))
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			}
		}
	}

	public unsafe void FindStartButton(HatData hatData)
	{
		//IL_00df: Expected O, but got Ref
		//IL_006f: Expected O, but got I
		if (hatButtons == null)
		{
			return;
		}
		MyButtonHat myButtonHat = hatButtons.get_Item(0);
		startBtn = myButtonHat;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		MyButtonHat myButtonHat2 = default(MyButtonHat);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)myButtonHat2 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ stack_-38 (MyButtonHat)+98]");
				if (!((UnityEngine.Object)0 == hatData))
				{
					continue;
				}
				startBtn = myButtonHat2;
				((List<MyButtonHat>.Enumerator*)(&enumerator))->Dispose();
			}
			else
			{
				((List<MyButtonHat>.Enumerator*)(&enumerator))->Dispose();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			while (true)
			{
				if (enumerator.MoveNext())
				{
					bool flag = (object)myButtonHat2 == null;
					List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
					if (flag)
					{
						break;
					}
					if (!(myButtonHat2.hatData == hatData))
					{
						myButtonHat2.SetSelected(selected: false);
					}
					else
					{
						myButtonHat2.SetSelected(selected: true);
					}
					continue;
				}
				((List<MyButtonHat>.Enumerator*)(&enumerator))->Dispose();
				return;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public void RefreshHatButtons(List<HatData> availableHats, HatData selectedHat)
	{
		if (hatButtons == null)
		{
			List<MyButtonHat> list = new List<MyButtonHat>();
			hatButtons = list;
			MyButtonHat component = hatButtonPrefab.GetComponent<MyButtonHat>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180001FF0");
		}
		int num = 0;
		int num2 = 0;
		while (num2 < availableHats._size)
		{
			List<MyButtonHat> list2 = hatButtons;
			if (list2._size <= num)
			{
				Transform transform = hatButtonPrefab.transform;
				Transform parent = transform.parent;
				GameObject gameObject = UnityEngine.Object.Instantiate(hatButtonPrefab, parent);
				MyButtonHat component2 = gameObject.GetComponent<MyButtonHat>();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180001FF0");
			}
			MyButtonHat myButtonHat = hatButtons.get_Item(num);
			HatData hatData = availableHats.get_Item(num);
			myButtonHat.Set(hatData);
			HatData hatData2 = availableHats.get_Item(num);
			if (!(hatData2 == selectedHat))
			{
				MyButtonHat myButtonHat2 = hatButtons.get_Item(num);
				myButtonHat2.SetSelected(selected: false);
				num++;
				num2 = num;
			}
			else
			{
				MyButtonHat myButtonHat3 = hatButtons.get_Item(num);
				startBtn = myButtonHat3;
				MyButtonHat myButtonHat4 = hatButtons.get_Item(num);
				myButtonHat4.SetSelected(selected: true);
				num++;
				num2 = num;
			}
		}
		FindAllButtonsInWindow();
	}

	public void HoverButton(HatData hatData)
	{
		hatDataHover = hatData;
		Action<HatData> a_HatHover = HatSelection.A_HatHover;
		if (HatSelection.A_HatHover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v60 @ r9_v1 (System.Action`1<HatData>)+18] (should have been resolved before IL gen)");
		}
	}

	public void StopHoverButton(HatData hatData)
	{
		if (hatDataHover == hatData)
		{
			hatDataHover = null;
			hatSelection.HoverHat(selectedHatBeforeOpenWindow);
		}
	}

	public void ClickButton(HatData hatData)
	{
		selectedHatBeforeOpenWindow = hatData;
		HatSelection hatSelection = this.hatSelection;
		this.hatSelection.CheckInit(false);
		hatSelection.selectedHatData = hatData;
		EHat hat;
		if (hatSelection.selectedHatData != null)
		{
			HatData selectedHatData = hatSelection.selectedHatData;
			hat = selectedHatData.eHat;
		}
		else
		{
			hat = EHat.None;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		config.preferences.SetCharacterHat(hatSelection.character, hat);
		hatSelection.hatSelectionPopupWindow.FindStartButton(hatSelection.selectedHatData);
		this.hatSelection.UpdateHatText();
		Action a_HatChanged = HatSelection.A_HatChanged;
		if (HatSelection.A_HatChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v40.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void CloseWindow()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private new void OnDisable()
	{
		base.OnDisable();
		Action<HatData> a_HatHover = HatSelection.A_HatHover;
		if (HatSelection.A_HatHover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v77 @ r9_v1 (System.Action`1<HatData>)+18] (should have been resolved before IL gen)");
		}
		ButtonManager.ForceHoverButton(b_hats);
	}
}
