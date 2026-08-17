using System;
using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;

public class ResolutionWindow : Window
{
	public GameObject resolutionButtonPrefab;

	private List<MyButtonResolution> resolutionButtons;

	private new void OnEnable()
	{
		Refresh();
		MyButtonResolution myButtonResolution = resolutionButtons.get_Item(0);
		savedBtn = myButtonResolution;
		WindowManager.WindowOpened(this);
	}

	private unsafe void Refresh()
	{
		//IL_0204: Expected O, but got I4
		//IL_0228: Expected O, but got Ref
		Resolution[] myResolutions = ConfigSettingsUtility.GetMyResolutions();
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVideoSettings cfVideoSettings = config.cfVideoSettings;
		List<MyButtonResolution> list = resolutionButtons;
		if (list._size <= 0)
		{
			MyButtonResolution component = resolutionButtonPrefab.GetComponent<MyButtonResolution>();
			list.Add(component);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Component component2 = default(Component);
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component2 == null)
				{
					break;
				}
				GameObject gameObject = component2.gameObject;
				gameObject.SetActive(value: false);
				continue;
			}
			((List<MyButtonResolution>.Enumerator*)(&enumerator))->Dispose();
			int num = 0;
			for (int num2 = 0; num2 < myResolutions.Length; num2 = num)
			{
				List<MyButtonResolution> list2 = resolutionButtons;
				if (num >= list2._size)
				{
					Transform transform = resolutionButtonPrefab.transform;
					Transform parent = transform.parent;
					GameObject gameObject2 = UnityEngine.Object.Instantiate(resolutionButtonPrefab, parent);
					MyButtonResolution component3 = gameObject2.GetComponent<MyButtonResolution>();
					resolutionButtons.Add(component3);
				}
				MyButtonResolution myButtonResolution = resolutionButtons.get_Item(num);
				GameObject gameObject3 = myButtonResolution.gameObject;
				gameObject3.SetActive(value: true);
				MyButtonResolution myButtonResolution2 = resolutionButtons.get_Item(num);
				object obj = num - cfVideoSettings.resolution;
				bool isSelected = obj == null;
				myButtonResolution2.SetResolution((Resolution)(&enumerator2), isSelected, num);
				MyButtonResolution myButtonResolution3 = resolutionButtons.get_Item(num);
				savedBtn = myButtonResolution3;
				num++;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public ResolutionWindow()
	{
		List<MyButtonResolution> list = new List<MyButtonResolution>();
		resolutionButtons = list;
		base._002Ector();
	}
}
