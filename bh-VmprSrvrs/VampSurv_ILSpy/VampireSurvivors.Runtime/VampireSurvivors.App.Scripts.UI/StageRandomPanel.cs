using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI;

public class StageRandomPanel : MonoBehaviour
{
	private TickBoxUI _RandomEventsTickBox;

	private TickBoxUI _RandomLevelsTickBox;

	private PlayerOptions _playerOptions;

	private StageData _stageData;

	private StageType _stageType;

	private string _pointlessString;

	private bool _003CHasRandomEvents_003Ek__BackingField;

	private bool _003CHasRandomLevels_003Ek__BackingField;

	private bool _003CIsStageUnlocked_003Ek__BackingField;

	public TickBoxUI RandomEventsTickBox => _RandomEventsTickBox;

	public TickBoxUI RandomLevelUpsTickBox => _RandomLevelsTickBox;

	private bool HasRandomEvents
	{
		get
		{
			return _003CHasRandomEvents_003Ek__BackingField;
		}
		set
		{
			_003CHasRandomEvents_003Ek__BackingField = value;
		}
	}

	private bool HasRandomLevels
	{
		get
		{
			return _003CHasRandomLevels_003Ek__BackingField;
		}
		set
		{
			_003CHasRandomLevels_003Ek__BackingField = value;
		}
	}

	private bool IsStageUnlocked
	{
		get
		{
			return _003CIsStageUnlocked_003Ek__BackingField;
		}
		set
		{
			_003CIsStageUnlocked_003Ek__BackingField = value;
		}
	}

	private void Construct(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	public void SetStage(StageData stageData, StageType stageType)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		_stageData = stageData;
		StageType stageType2 = default(StageType);
		_stageType = stageType2;
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
		object obj = default(object);
		bool flag;
		if (obj != null)
		{
			flag = true;
		}
		else
		{
			StageData stageData2 = _stageData;
			flag = stageData2._003Cunlocked_003Ek__BackingField;
		}
		bool flag2 = !flag;
		bool flag3 = !flag2;
		_003CIsStageUnlocked_003Ek__BackingField = flag3;
		PlayerOptionsData config2 = _playerOptions.Config;
		List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag4;
		if ((nint)0 == 0)
		{
			flag4 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			object obj2 = obj3 - -1;
			bool flag5 = obj2 == null;
			flag4 = !flag5;
		}
		_003CHasRandomEvents_003Ek__BackingField = flag4;
		PlayerOptionsData config3 = _playerOptions.Config;
		List<ItemType> list2 = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag6;
		if ((nint)0 == 0)
		{
			flag6 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj5 = default(object);
			object obj4 = obj5 - -1;
			bool flag7 = obj4 == null;
			flag6 = !flag7;
		}
		_003CHasRandomLevels_003Ek__BackingField = flag6;
		PlayerOptionsData config4 = _playerOptions.Config;
		_RandomEventsTickBox.InitialSet(config4._003CSelectedRandomEvents_003Ek__BackingField);
		GameObject gameObject = _RandomEventsTickBox.gameObject;
		bool flag8 = !_003CHasRandomEvents_003Ek__BackingField;
		bool flag9 = false;
		if (!flag8)
		{
			flag9 = _003CIsStageUnlocked_003Ek__BackingField;
		}
		bool flag10 = !flag9;
		bool active = !flag10;
		gameObject.SetActive(active);
		TickBoxUI randomEventsTickBox;
		bool interactive;
		if (_003CHasRandomEvents_003Ek__BackingField && _003CIsStageUnlocked_003Ek__BackingField)
		{
			randomEventsTickBox = _RandomEventsTickBox;
			interactive = true;
		}
		else
		{
			randomEventsTickBox = _RandomEventsTickBox;
			interactive = false;
		}
		randomEventsTickBox.SetInteractive(interactive);
		PlayerOptionsData config5 = _playerOptions.Config;
		_RandomLevelsTickBox.InitialSet(config5._003CSelectedRandomLevels_003Ek__BackingField);
		GameObject gameObject2 = _RandomLevelsTickBox.gameObject;
		bool flag11 = !_003CHasRandomLevels_003Ek__BackingField;
		bool flag12 = false;
		if (!flag11)
		{
			flag12 = _003CIsStageUnlocked_003Ek__BackingField;
		}
		bool flag13 = !flag12;
		bool active2 = !flag13;
		gameObject2.SetActive(active2);
		TickBoxUI randomLevelsTickBox;
		bool interactive2;
		if (_003CHasRandomLevels_003Ek__BackingField && _003CIsStageUnlocked_003Ek__BackingField)
		{
			randomLevelsTickBox = _RandomLevelsTickBox;
			interactive2 = true;
		}
		else
		{
			randomLevelsTickBox = _RandomLevelsTickBox;
			interactive2 = false;
		}
		randomLevelsTickBox.SetInteractive(interactive2);
	}

	public void OnRandomEventsToggled()
	{
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		bool flag = !config2._003CSelectedRandomEvents_003Ek__BackingField;
		config._003CSelectedRandomEvents_003Ek__BackingField = flag;
	}

	public unsafe void MakeVisuallyDisabled()
	{
		//IL_000f: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0033: Expected O, but got Ref
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>();
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj < componentsInChildren.Length)
		{
			componentsInChildren[obj2].color = (Color)(&obj3);
			obj2++;
			obj = obj2;
		}
	}

	public unsafe void MakeVisuallyEnabled()
	{
		//IL_000f: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0033: Expected O, but got Ref
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		Graphic[] componentsInChildren = GetComponentsInChildren<Graphic>();
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj < componentsInChildren.Length)
		{
			componentsInChildren[obj2].color = (Color)(&obj3);
			obj2++;
			obj = obj2;
		}
	}

	public void OnRandomLevelsToggled()
	{
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		bool flag = !config2._003CSelectedRandomLevels_003Ek__BackingField;
		config._003CSelectedRandomLevels_003Ek__BackingField = flag;
	}

	private void SetupRandomEventsToggle()
	{
		PlayerOptionsData config = _playerOptions.Config;
		_RandomEventsTickBox.InitialSet(config._003CSelectedRandomEvents_003Ek__BackingField);
		GameObject gameObject = _RandomEventsTickBox.gameObject;
		bool flag = _003CHasRandomEvents_003Ek__BackingField && _003CIsStageUnlocked_003Ek__BackingField;
		bool flag2 = !flag;
		bool active = !flag2;
		gameObject.SetActive(active);
		if (_003CHasRandomEvents_003Ek__BackingField && _003CIsStageUnlocked_003Ek__BackingField)
		{
			_RandomEventsTickBox.SetInteractive(isInteractive: true);
		}
		else
		{
			_RandomEventsTickBox.SetInteractive(isInteractive: false);
		}
	}

	private void SetupRandomLevelsToggle()
	{
		PlayerOptionsData config = _playerOptions.Config;
		_RandomLevelsTickBox.InitialSet(config._003CSelectedRandomLevels_003Ek__BackingField);
		GameObject gameObject = _RandomLevelsTickBox.gameObject;
		bool flag = _003CHasRandomLevels_003Ek__BackingField && _003CIsStageUnlocked_003Ek__BackingField;
		bool flag2 = !flag;
		bool active = !flag2;
		gameObject.SetActive(active);
		if (_003CHasRandomLevels_003Ek__BackingField && _003CIsStageUnlocked_003Ek__BackingField)
		{
			_RandomLevelsTickBox.SetInteractive(isInteractive: true);
		}
		else
		{
			_RandomLevelsTickBox.SetInteractive(isInteractive: false);
		}
	}

	public StageRandomPanel()
	{
		//IL_0058: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E94]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_pointlessString = "Pointless String";
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
