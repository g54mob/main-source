using System;
using System.Collections.Generic;
using Coherence;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class TP_Nathan_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__6_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COpenArcana_003Eb__6_0()
		{
			GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
		}
	}

	private bool _ArcanaGiven5mins;

	private bool _ArcanaGiven10mins;

	public override void AfterFullInitialization()
	{
		//IL_004c: Expected O, but got I
		//IL_00a6: Expected O, but got I
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 4;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T04_AWAKE);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		_ArcanaGiven5mins = false;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		if (_ArcanaGiven5mins)
		{
			if (_ArcanaGiven10mins)
			{
				return;
			}
			if (_ArcanaGiven5mins)
			{
				goto IL_019f;
			}
		}
		GameManager core = GM.Core;
		float num = core._003CSurvivedSeconds_003Ek__BackingField / 60f;
		if (!(num < 7f))
		{
			if (GM.Core.ShouldShowArcanaPanel())
			{
				OpenArcana();
			}
			_ArcanaGiven5mins = true;
		}
		goto IL_019f;
		IL_019f:
		if (_ArcanaGiven10mins)
		{
			return;
		}
		GameManager core2 = GM.Core;
		float num2 = core2._003CSurvivedSeconds_003Ek__BackingField / 60f;
		if (!(num2 < 14f))
		{
			if (GM.Core.ShouldShowArcanaPanel())
			{
				OpenArcana();
			}
			_ArcanaGiven10mins = true;
		}
	}

	private void OpenArcana()
	{
		//IL_0045: Expected I8, but got O
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
			return;
		}
		Action<long> action = null;
		((TP_Nathan_Character)(object)action).OpenArcana((long)this);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	public void OpenArcana(long startingSimFrame)
	{
		Action onSyncedTimer = _003C_003Ec._003C_003E9__6_0;
		if (_003C_003Ec._003C_003E9__6_0 == null)
		{
			onSyncedTimer = (_003C_003Ec._003C_003E9__6_0 = delegate
			{
				GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
			});
		}
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}
}
