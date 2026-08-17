using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI;

public class PauseGameButton : MonoBehaviour
{
	private const float PaddingBelowTopMaskBar = 20f;

	private const float PaddingBelowKillCount = 80f;

	private void Start()
	{
		Button component = GetComponent<Button>();
		UnityAction call = PauseGame;
		component.m_OnClick.AddListener(call);
	}

	private void OnEnable()
	{
		RepositionPauseButton();
	}

	private void Update()
	{
	}

	private void PauseGame()
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core2 = GM.Core;
			VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B4A0");
		}
		else
		{
			PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
			VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
			OnlineStageManager._instance.SendPauseRequest(characterController);
		}
	}

	private void RepositionPauseButton()
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

	public PauseGameButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
