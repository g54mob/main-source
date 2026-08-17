using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class BlockingPopup : BasePopup
{
	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _Description;

	private UISpriteAnimation _AnimLeft;

	private UISpriteAnimation _AnimRight;

	private Action _onClose;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private void Construct(DataManager data, PlayerOptions player)
	{
		_data = data;
		_playerOptions = player;
	}

	public virtual void Initialize(string id, string title, string description, Action onClose = null)
	{
		_Title.text = title;
		_Description.text = description;
		_ID = id;
		Action onClose2 = default(Action);
		_onClose = onClose2;
		PopupManager.SetAllowInput(val: false);
	}

	public override void Hide()
	{
		base.Hide();
		Action onClose = _onClose;
		if (_onClose != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void UpdateDescriptionText(string newDescription)
	{
		TextMeshProUGUI description = _Description;
		if ((object)_Description != null && ((UnityEngine.Object)description).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		}
	}

	private void OnDestroy()
	{
		PopupManager.SetAllowInput(val: true);
	}

	private void SetAnimation()
	{
		//IL_020c: Expected O, but got I4
		//IL_0089: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_0129: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<CharacterType> list = config._003CBoughtCharacters_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		List<CharacterType> list2 = config2._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		object obj = UnityEngine.Random.RandomRangeInt(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdi_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		bool flag = (nint)obj >= 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdi_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj2 = 0;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v13+20+v122 @ rax_v16*4]");
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v19 (System.Object)+18]");
		bool flag2 = (nint)0 <= (nint)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v19 (System.Object)+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v20+20]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v7+48]");
		string animName = ((string)0).Replace("01.png", "");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v7+68]");
		Vector2 pivot = default(Vector2);
		string textureName = default(string);
		int zeroPad = default(int);
		bool respectOriginalXPivot = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 0, pivot, textureName, zeroPad, respectOriginalXPivot);
		if (animationFrames._size > 0)
		{
			UISpriteAnimation animLeft = _AnimLeft;
			animLeft.sprites = animationFrames;
			UISpriteAnimation animRight = _AnimRight;
			animRight.sprites = animationFrames;
			_AnimLeft.Play();
			_AnimRight.Play();
		}
	}
}
