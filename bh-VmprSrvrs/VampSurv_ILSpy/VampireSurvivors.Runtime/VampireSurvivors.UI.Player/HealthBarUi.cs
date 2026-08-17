using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI.Player;

public class HealthBarUi : MonoBehaviour
{
	private Image _HealthBar;

	private Image _HealthBarFill;

	private VampireSurvivors.Objects.Characters.CharacterController _character;

	private void Awake()
	{
		Sprite unpackedSprite = SpriteManager.GetUnpackedSprite("UISquare");
		_HealthBarFill.sprite = unpackedSprite;
		_HealthBar.sprite = unpackedSprite;
	}

	private unsafe void Update()
	{
		//IL_00b7: Expected O, but got Ref
		//IL_007f: Expected O, but got Ref
		VampireSurvivors.Objects.Characters.CharacterController character = _character;
		if ((object)_character != null && ((UnityEngine.Object)character).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController character2 = _character;
			object obj = default(object);
			if (character2._multiplayerRevivalUI.IsVisible())
			{
				_HealthBarFill.color = (Color)(&obj);
				VampireSurvivors.Objects.Characters.CharacterController character3 = _character;
				_HealthBarFill.fillAmount = character3._multiplayerRevivalProportion;
			}
			else
			{
				_HealthBarFill.color = (Color)(&obj);
				float normalizedHp = _character.NormalizedHp;
				_HealthBarFill.fillAmount = normalizedHp;
			}
		}
	}

	public void Initialize(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		_character = character;
	}

	public HealthBarUi()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
