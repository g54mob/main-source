using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerHalloween : CharacterController
{
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public SkinType skinType;

		internal bool _003CMakeLevelOne_003Eb__0(Skin x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (x != null)
			{
				object obj = x.skinType - skinType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0237: Expected O, but got I4
		//IL_0237: Expected I4, but got O
		//IL_01fc: Expected I4, but got O
		base.MakeLevelOne();
		GameManager core = GM.Core;
		if (!core._003CIsHalloween_003Ek__BackingField)
		{
			return;
		}
		CharacterData currentCharacterData = _currentCharacterData;
		List<Skin> list = currentCharacterData._003Cskins_003Ek__BackingField;
		CharacterData characterData2;
		if (currentCharacterData._003Cskins_003Ek__BackingField != null && list._size > 0)
		{
			_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass0_0();
			SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(_characterType);
			CS_0024_003C_003E8__locals2.skinType = skinTypeForCharacter;
			CharacterData currentCharacterData2 = _currentCharacterData;
			Func<Skin, bool> predicate = delegate(Skin x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if (x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = x.skinType - CS_0024_003C_003E8__locals2.skinType;
				return obj == null;
			};
			Skin value = Enumerable.First(currentCharacterData2._003Cskins_003Ek__BackingField, predicate);
			string value2 = JsonConvert.SerializeObject(value);
			CharacterData characterData = JsonConvert.DeserializeObject<CharacterData>(value2);
			bool flag = characterData != null;
			characterData2 = characterData;
			if (!flag)
			{
				Debug.LogError("Uh oh, skin data is invalid");
				return;
			}
		}
		else
		{
			characterData2 = currentCharacterData;
		}
		if (characterData2._003CwalkingFrames_003Ek__BackingField > 0)
		{
			_hasWalkingAnimation = true;
			string animName = characterData2._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			Vector2 pivot = default(Vector2);
			string text = default(string);
			int num = default(int);
			bool flag2 = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, characterData2._003CwalkingFrames_003Ek__BackingField, pivot, text, num, flag2);
			int fps = (((object)characterData2._003CwalkFrameRate_003Ek__BackingField == null) ? 8 : ((object?)characterData2._003CwalkFrameRate_003Ek__BackingField >> 32));
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)(int)text != 0, (byte)num != 0, (Action)flag2, autoSetAnimation);
			_spriteAnimation.SetAnimation("walk");
		}
	}
}
