using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

namespace VampireSurvivors;

public class CheatsController : IInitializable, IDisposable
{
	private List<CheatData> _gameplayCheats;

	private List<CheatData> _menuCheats;

	private SignalBus _signalBus;

	private Player _player;

	public void Initialize()
	{
		//IL_0042: Expected I4, but got O
		UnityAction<Scene, LoadSceneMode> value = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B140");
		SceneManager.sceneLoaded += value;
		UnityAction<Scene> unityAction = null;
		((CheatsController)(object)unityAction).UnloadCheats((Scene)this);
		SceneManager.sceneUnloaded += unityAction;
		Scene activeScene = SceneManager.GetActiveScene();
		string nameInternal = Scene.GetNameInternal((int)activeScene);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48FA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	private unsafe void UnloadCheats(Scene arg0)
	{
		//IL_024e: Expected I4, but got O
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Ref, but got Unknown
		//IL_0091: Expected I8, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Ref, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Ref, but got Unknown
		//IL_0175: Expected I8, but got I4
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected Ref, but got Unknown
		string nameInternal = Scene.GetNameInternal((int)arg0);
		object obj = "MainMenu";
		List<CheatData> list;
		if ((object)nameInternal != "MainMenu")
		{
			if (nameInternal != null && "MainMenu" != null)
			{
				int stringLength = nameInternal._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(nameInternal + 20);
					ulong length = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("MainMenu" + 20), length))
					{
						goto IL_0236;
					}
				}
			}
			object obj2 = "Gameplay";
			if ((object)nameInternal != "Gameplay")
			{
				if (nameInternal == null || "Gameplay" == null)
				{
					return;
				}
				int stringLength2 = nameInternal._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v8+10]");
				if ((nint)stringLength2 != 0)
				{
					return;
				}
				ref byte first2 = ref *(byte*)(nameInternal + 20);
				ulong length2 = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Gameplay" + 20), length2))
				{
					return;
				}
			}
			list = _gameplayCheats;
			goto IL_01c1;
		}
		goto IL_0236;
		IL_01c1:
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
		return;
		IL_0236:
		list = _menuCheats;
		goto IL_01c1;
	}

	private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		//IL_0009: Expected I4, but got O
		string nameInternal = Scene.GetNameInternal((int)arg0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48FA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	private void LoadCheats(string sceneName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A48FA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public void Dispose()
	{
	}

	private void AddAllGameplayCheats()
	{
	}

	private void AddAllMenuCheats()
	{
	}

	private void AddGameplayCheat(string label, Action cb)
	{
		CheatData cheatData = new CheatData();
		cheatData.Label = label;
		Action action = ResumeGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC940");
	}

	private void AddMenuCheat(string label, Action cb)
	{
		CheatData cheatData = new CheatData();
		cheatData.Label = label;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F2220");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC940");
	}

	private void ResumeGame()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC9A0");
	}

	public unsafe List<CheatData> GetCheats()
	{
		//IL_0017: Expected I4, but got O
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Ref, but got Unknown
		//IL_00f2: Expected I8, but got I4
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Ref, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected Ref, but got Unknown
		//IL_01d6: Expected I8, but got I4
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected Ref, but got Unknown
		Scene activeScene = SceneManager.GetActiveScene();
		string nameInternal = Scene.GetNameInternal((int)activeScene);
		string message = "CheatsController - SceneName: " + nameInternal;
		Debug.LogWarning(message);
		object obj = "MainMenu";
		if ((object)nameInternal != "MainMenu")
		{
			if (nameInternal != null && "MainMenu" != null)
			{
				int stringLength = nameInternal._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v4+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(nameInternal + 20);
					ulong length = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("MainMenu" + 20), length))
					{
						goto IL_0223;
					}
				}
			}
			object obj2 = "Gameplay";
			if ((object)nameInternal != "Gameplay")
			{
				if (nameInternal != null && "Gameplay" != null)
				{
					int stringLength2 = nameInternal._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v7+10]");
					if ((nint)stringLength2 == 0)
					{
						ref byte first2 = ref *(byte*)(nameInternal + 20);
						ulong length2 = (ulong)(nameInternal._stringLength + nameInternal._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Gameplay" + 20), length2))
						{
							goto IL_021c;
						}
					}
				}
				return new List<CheatData>();
			}
			goto IL_021c;
		}
		goto IL_0223;
		IL_021c:
		return _gameplayCheats;
		IL_0223:
		return _menuCheats;
	}

	public CheatsController()
	{
		List<CheatData> gameplayCheats = new List<CheatData>();
		_gameplayCheats = gameplayCheats;
		List<CheatData> menuCheats = new List<CheatData>();
		_menuCheats = menuCheats;
	}
}
