using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class MultiplayerCharacterDisplay : MonoBehaviour
{
	protected DataManager Data;

	protected PlayerOptions PlayerOptions;

	protected Sprite CharacterSprite;

	protected Coroutine ShowRoutine;

	private CanvasGroup _cg;

	private void Construct(DataManager data, PlayerOptions playerOptions)
	{
		Data = data;
		PlayerOptions = playerOptions;
	}

	private void Awake()
	{
		GameObject gameObject = base.gameObject;
		CanvasGroup cg = gameObject.AddComponent<CanvasGroup>();
		_cg = cg;
	}

	protected virtual void OnEnable()
	{
		GameManager core = GM.Core;
		if (core._mainCharacters != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			if (mainCharacters._size > 1)
			{
				Show();
				_cg.alpha = 1f;
				return;
			}
		}
		_cg.alpha = 0f;
	}

	private void OnDestroy()
	{
		//IL_0071: Expected I4, but got O
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool complete = (byte)(int)gameObject != 0;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			complete = !flag2;
		}
		int num = DOTween.KillAll(complete);
	}

	public virtual void Show()
	{
		VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
		CharacterData currentSkinData = interactingPlayer._currentSkinData;
		VampireSurvivors.Objects.Characters.CharacterController interactingPlayer2 = GM.Core.InteractingPlayer;
		CharacterData currentSkinData2 = interactingPlayer2._currentSkinData;
		Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData2._003CtextureName_003Ek__BackingField);
		CharacterSprite = sprite;
	}

	public MultiplayerCharacterDisplay()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
