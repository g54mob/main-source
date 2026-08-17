using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI;

public class FastForwardButton : MonoBehaviour
{
	private GameObject _icon1;

	private GameObject _icon2;

	private GameObject _icon3;

	private float _tempTimeScale;

	private const float PaddingBelowTopMaskBar = 20f;

	private const float PaddingBelowKillCount = 80f;

	private void Start()
	{
		Button component = GetComponent<Button>();
		UnityAction call = FastForward;
		component.m_OnClick.AddListener(call);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (!stageData._003CisSpeedupBanned_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj = default(object);
			if (obj == null)
			{
				CheckTimescale();
				return;
			}
		}
		_icon1.SetActive(value: false);
		_icon2.SetActive(value: false);
		_icon3.SetActive(value: false);
	}

	private void OnEnable()
	{
		RepositionFastForwardButton();
	}

	private void Update()
	{
		//IL_015c: Invalid comparison between F4 and O
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (!stageData._003CisSpeedupBanned_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj = default(object);
			if (obj == null)
			{
				GameManager core3 = GM.Core;
				PlayerOptionsData config2 = core3._playerOptions.Config;
				if (!config2._003CHideGameUI_003Ek__BackingField)
				{
					GameManager core4 = GM.Core;
					if (!core4._multiplayer.IsOnlineMultiplayer)
					{
						SpeedupManager instance = SpeedupManager.Instance;
						if (!instance.m_isSpeedupBlocked)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BD8870");
							object obj2 = default(object);
							bool flag = (object)_tempTimeScale == obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186BF1BD5h\"");
							if (!flag)
							{
								CheckTimescale();
							}
							return;
						}
						bool flag2 = _tempTimeScale == -1f;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186BF1BF5h\"");
						if (flag2)
						{
							return;
						}
						_tempTimeScale = -1f;
					}
				}
			}
		}
		_icon1.SetActive(value: false);
		_icon2.SetActive(value: false);
		_icon3.SetActive(value: false);
	}

	private void CheckTimescale()
	{
		//IL_00c8: Expected O, but got F4
		object obj = Time.timeScale;
		float tempTimeScale = default(float);
		_tempTimeScale = tempTimeScale;
		_icon1.SetActive(value: false);
		_icon2.SetActive(value: false);
		_icon3.SetActive(value: false);
		GameObject gameObject = ((!(_tempTimeScale < 2f)) ? _icon3 : ((!(_tempTimeScale < 1.5f)) ? _icon2 : _icon1));
		gameObject.SetActive(value: true);
	}

	private void FastForward()
	{
		SpeedupManager instance = SpeedupManager.Instance;
		if (instance.m_CurrentSpeedMultiplier < 2f)
		{
			SpeedupManager instance2 = SpeedupManager.Instance;
			instance2.IncreaseSpeedup();
		}
		else
		{
			SpeedupManager instance3 = SpeedupManager.Instance;
			instance3.SetSpeedup(0f);
		}
	}

	private void RepositionFastForwardButton()
	{
		//IL_0044: Expected I, but got O
		AspectMask aspectMask = AspectMask._003CInstance_003Ek__BackingField;
		if ((object)AspectMask._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)aspectMask).m_CachedPtr != (IntPtr)0)
		{
			nint num = (nint)typeof(UIHelper);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v10 (Il2CppClass<VampireSurvivors.UI.UIHelper>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
	}

	private static bool IsKillsCountAboveTopAspectBarBottom(RectTransform topMask, RectTransform killCount)
	{
		//IL_0105: Expected I4, but got O
		//IL_00ad: Expected O, but got I
		Vector3[] array = new Vector3[4];
		killCount.GetWorldCorners(array);
		if (array.Length > 0)
		{
			Vector3[] array2 = new Vector3[4];
			topMask.GetWorldCorners(array2);
			if (array2.Length > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (UnityEngine.Vector3[])+24]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v9 (UnityEngine.Vector3[])+24]");
				bool flag = num < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (UnityEngine.Vector3[])+24]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v9 (UnityEngine.Vector3[])+24]");
				object obj = num2 - 0;
				bool flag2 = obj == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				return flag4 & flag3;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private static float GetBottomY(RectTransform rectTransform)
	{
		//IL_0024: Expected F4, but got I
		Vector3[] fourCornersArray = new Vector3[4];
		rectTransform.GetWorldCorners(fourCornersArray);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (UnityEngine.Vector3[])+24]");
		return 0f;
	}

	public FastForwardButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
