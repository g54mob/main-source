using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using VampireSurvivors.Achievements;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.Framework.Cheats;

public class CheatCodeManager : IInitializable, IDisposable
{
	protected class CheatCodeCombo
	{
		public List<KeyCode> Combo;

		public List<string> ActionCombo;

		public Action OnComboComplete;

		private int _currentIndex;

		private bool _isComplete;

		public void CheckComboKeyboard(Keyboard keyboard)
		{
			//IL_00cb: Expected O, but got I
			//IL_0197: Expected I, but got O
			//IL_0107: Expected I, but got O
			if (_isComplete || Combo == null)
			{
				return;
			}
			List<KeyCode> combo = Combo;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v3 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			if ((nint)0 < (nint)0)
			{
				return;
			}
			if (keyboard.GetAnyButtonDown())
			{
				List<KeyCode> combo2 = Combo;
				int currentIndex = _currentIndex;
				int currentIndex2 = _currentIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v17 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
				if ((nint)currentIndex2 >= (nint)0)
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v17 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v9+20+v180 @ rcx_v10 (System.Int32)*4]");
				if (!keyboard.GetKeyDown(KeyCode.None))
				{
					_currentIndex = 0;
					nint num = unchecked((nint)null);
				}
				else
				{
					int currentIndex3 = _currentIndex + 1;
					_currentIndex = currentIndex3;
					nint num = unchecked((nint)null);
				}
			}
			List<KeyCode> combo3 = Combo;
			int currentIndex4 = _currentIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v13 (System.Collections.Generic.List`1<UnityEngine.KeyCode>)+18]");
			if ((nint)currentIndex4 == 0)
			{
				Action onComboComplete = OnComboComplete;
				_isComplete = true;
				if (OnComboComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v66.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
		}

		public void CheckComboController(Player player)
		{
			//IL_00d8: Expected I, but got O
			//IL_00b4: Expected I, but got O
			if (_isComplete || ActionCombo == null)
			{
				return;
			}
			List<string> actionCombo = ActionCombo;
			if (actionCombo._size < 0)
			{
				return;
			}
			if (player.GetAnyButtonDown())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				string actionName = default(string);
				if (!player.GetButtonDown(actionName))
				{
					_currentIndex = 0;
					nint num = unchecked((nint)null);
				}
				else
				{
					int currentIndex = _currentIndex + 1;
					_currentIndex = currentIndex;
					nint num = unchecked((nint)null);
				}
			}
			List<string> actionCombo2 = ActionCombo;
			if (_currentIndex == actionCombo2._size)
			{
				Action onComboComplete = OnComboComplete;
				_isComplete = true;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v161.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}

		private IGamepadTemplate GetGamepad(Player player)
		{
			if (player != null && player.controllers != null)
			{
				IGamepadTemplate firstControllerWithTemplate = (IGamepadTemplate)player.controllers.GetFirstControllerWithTemplate<IGamepadTemplate>();
				if (firstControllerWithTemplate != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809C7170");
					IGamepadTemplate result = default(IGamepadTemplate);
					return result;
				}
				return firstControllerWithTemplate;
			}
			return (IGamepadTemplate)new NullReferenceException();
		}
	}

	protected Player _player;

	protected PlayerOptions _playerOptions;

	protected AchievementManager _achievementManager;

	protected readonly List<CheatCodeCombo> _cheatCodeCombos;

	private void Construct(PlayerOptions playerOptions, AchievementManager achievementManager)
	{
		_playerOptions = playerOptions;
		_achievementManager = achievementManager;
	}

	public void Initialize()
	{
		ReInput.PlayerHelper players = ReInput.players;
		Player player = players.GetPlayer(0);
		_player = player;
		AddCheatCodeCombos();
	}

	public void Dispose()
	{
		List<CheatCodeCombo> cheatCodeCombos = _cheatCodeCombos;
		int version = cheatCodeCombos._version + 1;
		cheatCodeCombos._version = version;
		cheatCodeCombos._size = 0;
		if (cheatCodeCombos._size > 0)
		{
			Array.Clear(cheatCodeCombos._items, 0, cheatCodeCombos._size);
		}
	}

	public virtual void InternalUpdate()
	{
		CheckForCheatCodeComboActivation();
	}

	protected virtual void AddCheatCodeCombos()
	{
	}

	private unsafe void CheckForCheatCodeComboActivation()
	{
		//IL_002d: Expected O, but got Ref
		List<CheatCodeCombo>.Enumerator enumerator = default(List<CheatCodeCombo>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				Player player = _player;
				bool flag = _player == null;
				List<CheatCodeCombo>.Enumerator enumerator2 = (List<CheatCodeCombo>.Enumerator)(&enumerator);
				if (flag)
				{
					break;
				}
				if (player.controllers != null)
				{
					bool hasKeyboard = player.controllers.hasKeyboard;
					Player player2 = _player;
					if (hasKeyboard)
					{
						if (_player != null)
						{
							Keyboard keyboard = player2.controllers.Keyboard;
							((CheatCodeCombo)null).CheckComboKeyboard(keyboard);
							player2 = _player;
							((CheatCodeCombo)null).CheckComboController(player2);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			return;
		}
		throw new NullReferenceException();
	}

	public CheatCodeManager()
	{
		List<CheatCodeCombo> cheatCodeCombos = new List<CheatCodeCombo>();
		_cheatCodeCombos = cheatCodeCombos;
	}
}
