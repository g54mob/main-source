using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters;

public class TP_Blackmore_Character : TP_Character
{
	private SpriteRenderer _back2Sprite;

	private SpriteAnimation _back2Anim;

	private int _morphedTimes;

	private int _finalMorphedTimes;

	private int _finalThreshold = 17000;

	private int _enemiesTs;

	private bool _back2SpriteInitialized;

	private int[] _thresholds = new int[5] { 1000, 5000, 9000, 13000, 17000 };

	private void CalculateTreshold()
	{
		int[] thresholds = _thresholds;
		if (_morphedTimes < thresholds.Length)
		{
			int[] thresholds2 = _thresholds;
			int morphedTimes = _morphedTimes;
			_enemiesTs = thresholds2[morphedTimes];
		}
		else
		{
			int enemiesTs = _finalThreshold * _finalMorphedTimes;
			int finalMorphedTimes = _finalMorphedTimes + 1;
			_finalMorphedTimes = finalMorphedTimes;
			_enemiesTs = enemiesTs;
		}
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_004c: Expected O, but got I
		//IL_00a6: Expected O, but got I
		//IL_03ae: Expected I4, but got I8
		//IL_022d: Expected I4, but got O
		//IL_031c: Expected I4, but got O
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v9+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 5;
		}
		GameManager core2 = GM.Core;
		core2._arcanaManager.TriggerArcana(ArcanaType.T05_CRASH);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
		arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
		((CharacterController)this)._spriteTrail.Reset();
		SpriteTrail spriteTrail = ((CharacterController)this)._spriteTrail;
		spriteTrail._MaxHistory = 0;
		spriteTrail.InitialiseGhosts(expandExisting: true);
		base.SetBloodColor(0u);
		float2 float5 = base.cachedPosition;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		string text = default(string);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, vector, "character_tp_blackmore", text);
		((UnityEngine.Object)spriteRenderer).SetName("BlackmoreAnim");
		bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
		Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, -1);
		_back2Sprite = spriteRenderer;
		CheckRenderer();
		Transform parent = ((ArcadeSprite)this)._spriteRenderer.transform;
		Transform transform = _back2Sprite.transform;
		transform.SetParent(parent, worldPositionStays: true);
		Transform transform2 = _back2Sprite.transform;
		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector2 value = default(Vector2);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_back2Sprite, 0.85f);
		List<Sprite> animation = SpriteManager.GetAnimation("TP_Blackmore_Shadow_i0", 1, 5, "character_tp_blackmore", (byte)(int)text != 0);
		GameObject gameObject2 = _back2Sprite.gameObject;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rdi_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		bool flag3 = (object)gameObject2 == null;
		SpriteAnimation back2Anim = ((!gameObject2.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject2.AddComponent<SpriteAnimation>() : component);
		_back2Anim = back2Anim;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_back2Anim.AddAnimation("idle", animation, 12, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
		_back2Anim.SetAnimation("idle");
		_back2SpriteInitialized = true;
		CalculateTreshold();
	}

	protected override void OnUpdate()
	{
		//IL_006f: Expected O, but got I
		base.OnUpdate();
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v24 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v24 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v24 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		if (((CharacterController)this)._isDead || base.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CRunEnemies_003Ek__BackingField > _enemiesTs && _morphedTimes <= 4)
		{
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				EnterSkillSelection();
			}
			else
			{
				Action action = EnterSkillSelection;
				bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.All);
			}
			int morphedTimes = _morphedTimes;
			int[] thresholds = _thresholds;
			int enemiesTs;
			if (++_morphedTimes < thresholds.Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v15 (System.Int32[])+24+v77 @ rdx_v9 (System.Int32)*4]");
				enemiesTs = 0;
			}
			else
			{
				int finalMorphedTimes = _finalMorphedTimes + 1;
				_finalMorphedTimes = finalMorphedTimes;
				enemiesTs = _finalMorphedTimes * _finalThreshold;
			}
			_enemiesTs = enemiesTs;
		}
	}

	public void EnterSkillSelection()
	{
		GM.Core.QueueEnterSkillSelection(this);
	}

	private void LateUpdate()
	{
		if (_back2SpriteInitialized)
		{
			bool flag = base.flipX;
			_back2Sprite.flipX = flag;
		}
	}
}
