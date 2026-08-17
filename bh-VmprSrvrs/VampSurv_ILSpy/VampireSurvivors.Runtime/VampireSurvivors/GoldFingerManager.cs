using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors;

public class GoldFingerManager
{
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public GoldFingerManager _003C_003E4__this;

		public int award;

		internal void _003CDoExitAnimation_003Eb__0()
		{
			_003C_003E4__this.GiveAward(award);
		}

		internal void _003CDoExitAnimation_003Eb__1()
		{
			//IL_0063: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Cheers, soundConfig, 2000f, 1, time);
			GoldFingerManager goldFingerManager = _003C_003E4__this;
			PhaserSprite phaserSprite = goldFingerManager._clapSpriteL.setAlpha(1f);
		}

		internal void _003CDoExitAnimation_003Eb__2()
		{
			GoldFingerManager goldFingerManager = _003C_003E4__this;
			PhaserSprite phaserSprite = goldFingerManager._clapSpriteR.setAlpha(1f);
		}

		internal void _003CDoExitAnimation_003Eb__3()
		{
			//IL_009a: Expected I, but got O
			//IL_0104: Expected I, but got O
			//IL_0168: Expected O, but got I4
			GoldFingerManager goldFingerManager = _003C_003E4__this;
			if (goldFingerManager._clapAlphaTween != null)
			{
				goldFingerManager._clapAlphaTween.Kill();
			}
			GoldFingerManager goldFingerManager2 = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[2];
			GoldFingerManager goldFingerManager3 = _003C_003E4__this;
			if ((object)goldFingerManager3._clapSpriteL != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			GoldFingerManager goldFingerManager4 = _003C_003E4__this;
			if ((object)goldFingerManager4._clapSpriteR != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.alpha = (float?)(object)1;
			MultiTargetTween clapAlphaTween = Tweens.Add(tweenConfig);
			goldFingerManager2._clapAlphaTween = clapAlphaTween;
		}
	}

	private sealed class _003C_003Ec__DisplayClass38_0
	{
		public List<WeaponType> choices;

		public int i;

		public Predicate<Equipment> _003C_003E9__0;

		internal bool _003CGiveRandomWeapon_003Eb__0(Equipment equipment)
		{
			//IL_0057: Expected O, but got I
			//IL_0076: Expected O, but got I
			List<WeaponType> list = choices;
			int num = i;
			int num2 = i;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)num2 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj = 0;
				WeaponType equipmentType = equipment._equipmentType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v7+20+v45 @ rax_v8 (System.Int32)*4]");
				object obj2 = (nint)equipmentType - (nint)0;
				return obj2 == null;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
	}

	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public GoldFingerManager _003C_003E4__this;

		public int i;

		public Action<Pickup> _003C_003E9__0;

		public Action<Pickup> _003C_003E9__1;

		internal void _003CSendCoins_003Eb__0(Pickup coin)
		{
			if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
			{
				coin.GoToPlayer = true;
				GoldFingerManager goldFingerManager = _003C_003E4__this;
				coin._targetPlayer = goldFingerManager._player;
				coin.Time = 1f;
				float num = 250f - (float)i;
				coin._003CSpeed_003Ek__BackingField = num;
			}
		}

		internal void _003CSendCoins_003Eb__1(Pickup coin)
		{
			if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
			{
				coin.GoToPlayer = true;
				GoldFingerManager goldFingerManager = _003C_003E4__this;
				coin._targetPlayer = goldFingerManager._player;
				coin.Time = 1f;
				float num = 250f - (float)i;
				coin._003CSpeed_003Ek__BackingField = num;
			}
		}
	}

	private PhaserScene _scene;

	private VampireSurvivors.Objects.Characters.CharacterController _player;

	private PhaserSprite _fogRays;

	private PhaserSprite _logoSprite;

	private PhaserSprite _logoSpriteShadow;

	private PhaserSprite _clapSpriteL;

	private PhaserSprite _clapSpriteR;

	private BitmapText _totalText;

	private float _targetScale;

	private int _awardReached;

	private float _elapsedGfBonusTime;

	private float _gFCooldownBonus;

	private float _startingEnemiesCounter;

	private int _shadowBumps;

	private int _previousAwardReached;

	private float _gfEndInvulBonusTime;

	private MultiTargetTween _logoTween1;

	private MultiTargetTween _logoTween2;

	private MultiTargetTween _logoTween3;

	private MultiTargetTween _exitTween;

	private MultiTargetTween _clapTweenL;

	private MultiTargetTween _clapTweenR;

	private MultiTargetTween _clapAlphaTween;

	private MultiTargetTween _shadowTween;

	private List<float> _fontScales;

	private List<uint> _fontTints;

	private List<int> _thresholds;

	private List<string> _frames;

	private const float GfDuration = 10000f;

	private unsafe float GFDurationWithBonus
	{
		get
		{
			//IL_02c4: Expected I, but got O
			//IL_0181: Expected I, but got O
			//IL_0084: Expected I, but got O
			//IL_01fc: Expected F4, but got O
			//IL_0205: Expected F4, but got I4
			//IL_0107: Expected I, but got O
			//IL_0213: Expected O, but got I4
			//IL_021b: Expected O, but got Ref
			//IL_0139: Expected O, but got I
			//IL_016e: Expected F4, but got I
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			GameManager core = GM.Core;
			float num5;
			if ((object)GM.Core != null && core._multiplayer != null)
			{
				int playerCount = core._multiplayer.GetPlayerCount();
				if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
				{
					nint num3 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rax_v27 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num4 = 0;
					GameManager core2 = GM.Core;
					bool flag = (object)GM.Core == null;
					num2 = num4;
					if (!flag)
					{
						GameSessionData gameSessionData = core2._gameSessionData;
						bool flag2 = core2._gameSessionData == null;
						num2 = num4;
						if (!flag2)
						{
							num2 = (nint)gameSessionData._activeCharacter;
							if ((object)gameSessionData._activeCharacter != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v3 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+218]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v3 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+218]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v30+C4]");
									num5 = 0f;
									goto IL_02fb;
								}
							}
						}
					}
				}
				else
				{
					nint num6 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v13 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num7 = 0;
					GameManager core3 = GM.Core;
					bool flag3 = (object)GM.Core == null;
					num2 = num7;
					if (!flag3)
					{
						bool flag4 = core3._mainCharacters == null;
						num2 = num7;
						if (!flag4)
						{
							float num8 = (float)core3._mainCharacters;
							num5 = 0f;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj2 = 0;
								List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							goto IL_02fb;
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_02fb:
			float num9 = num5 + 1f;
			return num9 * 10000f;
		}
	}

	public GoldFingerManager(PhaserScene scene)
	{
		//IL_0028: Expected O, but got I
		//IL_008b: Expected O, but got I
		//IL_0a68: Expected O, but got I
		//IL_00fe: Expected O, but got I
		//IL_0a90: Expected O, but got I
		//IL_0171: Expected O, but got I
		//IL_0ab8: Expected O, but got I
		//IL_01e4: Expected O, but got I
		//IL_0ae0: Expected O, but got I
		//IL_0257: Expected O, but got I
		//IL_029e: Expected O, but got I
		//IL_02f8: Expected O, but got I
		//IL_0b17: Expected O, but got I
		//IL_0362: Expected O, but got I
		//IL_0b3f: Expected O, but got I
		//IL_03cc: Expected O, but got I
		//IL_0b67: Expected O, but got I
		//IL_0436: Expected O, but got I
		//IL_0b8f: Expected O, but got I
		//IL_04a0: Expected O, but got I
		//IL_04e7: Expected O, but got I
		//IL_0541: Expected O, but got I
		//IL_0bc6: Expected O, but got I
		//IL_05ab: Expected O, but got I
		//IL_0bee: Expected O, but got I
		//IL_0615: Expected O, but got I
		//IL_0c16: Expected O, but got I
		//IL_067f: Expected O, but got I
		//IL_0c3e: Expected O, but got I
		//IL_06e9: Expected O, but got I
		_targetScale = 1f;
		_gFCooldownBonus = -1f;
		_gfEndInvulBonusTime = 4000f;
		List<float> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(1f);
			float num2 = 1f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v5+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(1.25f);
			float num2 = 1.25f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1067450368;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rdx_v6+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(1.5f);
			float num2 = 1.5f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1069547520;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v7+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(1.75f);
			float num2 = 1.75f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1071644672;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v8+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(2f);
			float num2 = 2f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1073741824;
		}
		_fontScales = list;
		List<uint> list2 = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v11+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize(11891247u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 11891247;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v13+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize(15856113u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 15856113;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v15+18]");
		if (num9 >= 0)
		{
			list2.AddWithResize(16579683u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 16579683;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v17+18]");
		if (num10 >= 0)
		{
			list2.AddWithResize(14101051u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 14101051;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rdx_v19+18]");
		if (num11 >= 0)
		{
			list2.AddWithResize(12517375u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ rax_v15 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 12517375;
		}
		_fontTints = list2;
		List<int> list3 = new List<int>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v23+18]");
		if (num12 >= 0)
		{
			list3.AddWithResize(0);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdx_v25+18]");
		if (num13 >= 0)
		{
			list3.AddWithResize(500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 500;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v27+18]");
		if (num14 >= 0)
		{
			list3.AddWithResize(1000);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1000;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v29+18]");
		if (num15 >= 0)
		{
			list3.AddWithResize(1500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1500;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v31+18]");
		if (num16 >= 0)
		{
			list3.AddWithResize(2500);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 2500;
		}
		_thresholds = list3;
		List<string> list4 = new List<string>();
		int version = list4._version + 1;
		list4._version = version;
		string[] items = list4._items;
		if (list4._size >= items.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"BronzeFinger.png");
		}
		else
		{
			int size = list4._size + 1;
			list4._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list4._version + 1;
		list4._version = version2;
		string[] items2 = list4._items;
		if (list4._size >= items2.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"SilverFinger.png");
		}
		else
		{
			int size2 = list4._size + 1;
			list4._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list4._version + 1;
		list4._version = version3;
		string[] items3 = list4._items;
		if (list4._size >= items3.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"GoldenFinger.png");
		}
		else
		{
			int size3 = list4._size + 1;
			list4._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list4._version + 1;
		list4._version = version4;
		string[] items4 = list4._items;
		if (list4._size >= items4.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"DemonFinger.png");
		}
		else
		{
			int size4 = list4._size + 1;
			list4._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list4._version + 1;
		list4._version = version5;
		string[] items5 = list4._items;
		if (list4._size >= items5.Length)
		{
			((List<object>)(object)list4).AddWithResize((object)"CosmicFinger.png");
		}
		else
		{
			int size5 = list4._size + 1;
			list4._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frames = list4;
		_scene = scene;
	}

	public unsafe void ActivateGoldFinger(VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
	{
		//IL_0046: Expected O, but got I4
		//IL_01a7: Expected F4, but got I4
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0246: Expected O, but got Ref
		//IL_02f2: Expected F4, but got I4
		//IL_07b6: Expected O, but got I
		//IL_1ad5: Expected O, but got I4
		//IL_1d0a: Expected O, but got I4
		//IL_036e: Expected O, but got F4
		//IL_03a2: Expected O, but got I4
		//IL_1b37: Expected O, but got Ref
		//IL_08c4: Expected O, but got F4
		//IL_04cd: Expected O, but got I4
		//IL_08f8: Expected O, but got I4
		//IL_0b44: Expected O, but got Ref
		//IL_0d45: Expected F4, but got O
		//IL_0b88: Expected O, but got F4
		//IL_0bbc: Expected O, but got I4
		//IL_0e19: Expected O, but got Ref
		//IL_114b: Expected O, but got F4
		//IL_0638: Expected I4, but got F4
		//IL_0a36: Expected F4, but got I4
		//IL_0a3e: Expected O, but got F4
		//IL_0e8b: Expected I4, but got F4
		//IL_0e8b: Expected O, but got Ref
		//IL_0e8b: Expected O, but got F4
		//IL_11ff: Expected O, but got F4
		//IL_06b3: Expected I4, but got F4
		//IL_1233: Expected O, but got I4
		//IL_0cfa: Expected F4, but got I4
		//IL_0d02: Expected O, but got F4
		//IL_1267: Expected O, but got I4
		//IL_0f33: Expected O, but got Ref
		//IL_15cc: Expected I, but got O
		//IL_1620: Expected I, but got O
		//IL_168a: Expected O, but got I4
		//IL_1698: Expected O, but got I4
		//IL_16b4: Expected O, but got I4
		//IL_1368: Expected O, but got F4
		//IL_139c: Expected O, but got I4
		//IL_13d0: Expected O, but got I4
		//IL_1490: Expected F4, but got I4
		//IL_1498: Expected O, but got F4
		//IL_1884: Expected O, but got I
		//IL_1938: Expected I4, but got O
		//IL_1b79->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_08e0->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_0914->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_0943->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_0972->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_09b2->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_09ec->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_0a16->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_0a44->IL0a44: Incompatible stack heights: 1 vs 0
		//IL_15ef->IL15ef: Incompatible stack heights: 1 vs 0
		//IL_1643->IL1643: Incompatible stack heights: 1 vs 0
		//IL_1c65->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_0fd5->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_1017->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_1041->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_17fc->IL1cb5: Incompatible stack heights: 1 vs 0
		//IL_107d->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_1814->IL1cb5: Incompatible stack heights: 1 vs 0
		//IL_10b7->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_10e1->IL1a8f: Incompatible stack heights: 1 vs 0
		//IL_110e->IL110e: Incompatible stack heights: 1 vs 0
		//IL_1976->IL1cb5: Incompatible stack heights: 3 vs 0
		//IL_18d8->IL1cdb: Incompatible stack heights: 4 vs 3
		//IL_1971->IL1cdb: Incompatible stack heights: 7 vs 3
		_player = targetPlayer;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		_shadowBumps = 0;
		float gFDurationWithBonus = GFDurationWithBonus;
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		float num3 = default(float);
		if ((object)GM.Core != null)
		{
			float playersInvulForMilliSecondsNonCumulative = _gfEndInvulBonusTime + gFDurationWithBonus;
			GM.Core.SetPlayersInvulForMilliSecondsNonCumulative(playersInvulForMilliSecondsNonCumulative);
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				_elapsedGfBonusTime = 0f;
				if (core._003CHasGfBonus_003Ek__BackingField)
				{
					return;
				}
				_awardReached = 0;
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._playerOptions != null)
				{
					PlayerOptionsData config = core2._playerOptions.Config;
					if (config != null)
					{
						_startingEnemiesCounter = config._003CRunEnemies_003Ek__BackingField;
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null && core3._playerOptions != null)
						{
							PlayerOptionsData config2 = core3._playerOptions.Config;
							if (config2 != null)
							{
								object obj = config2._003CRunEnemies_003Ek__BackingField - _startingEnemiesCounter;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								object arg = default(object);
								System.ParamsArray paramsArray = new System.ParamsArray(arg);
								string message = string.FormatHelper((IFormatProvider)null, "Starting Enemies Count: {0}", (System.ParamsArray)(&paramsArray2));
								Debug.Log(message);
								GameManager core4 = GM.Core;
								if ((object)GM.Core != null && core4._playerOptions != null)
								{
									PlayerOptionsData config3 = core4._playerOptions.Config;
									if (config3 != null)
									{
										bool flag = !config3._003CFlashingVFXEnabled_003Ek__BackingField;
										float num2 = 0f;
										if (flag)
										{
											goto IL_078b;
										}
										if ((bool)_fogRays)
										{
											goto IL_0717;
										}
										PhaserScene scene = _scene;
										if (_scene != null)
										{
											PhaserSprite phaserSprite = RenderingExtensions.sprite(scene.add, (Vector2)num3, "vfx", "fogRays1");
											if ((object)phaserSprite != null)
											{
												PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)0);
												if ((object)GM.Core != null)
												{
													PhaserScene scene2 = GM.Core.scene;
													if (scene2 != null)
													{
														PhaserScene.Renderer renderer = scene2._renderer;
														if (scene2._renderer != null && (object)GM.Core != null)
														{
															PhaserScene scene3 = GM.Core.scene;
															if (scene3 != null && scene3._renderer != null && (object)phaserSprite2 != null)
															{
																float xScale = renderer.width / 1.5999999f;
																PhaserSprite phaserSprite3 = phaserSprite2.setScale(xScale, (float?)(object)1);
																if ((object)phaserSprite3 != null)
																{
																	PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Screen);
																	if ((object)phaserSprite4 != null)
																	{
																		PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0f);
																		if ((object)phaserSprite5 != null)
																		{
																			PhaserSprite component = phaserSprite5.setVisible(visible: false);
																			PhaserSprite phaserSprite6 = RenderingExtensions.SetScrollFactor(component, 0f);
																			if ((object)phaserSprite6 != null)
																			{
																				PhaserSprite phaserSprite7 = phaserSprite6.setDepth(31763);
																				if ((object)phaserSprite7 != null)
																				{
																					PhaserSprite phaserSprite8 = phaserSprite7.setTint(16776960u);
																					if ((object)phaserSprite8 != null)
																					{
																						PhaserSprite fogRays = phaserSprite8.setName("FogRays");
																						_fogRays = fogRays;
																						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("fogRays", 1, 2, "vfx", (int)num);
																						PhaserSprite fogRays2 = _fogRays;
																						if ((object)_fogRays != null && (object)fogRays2._spriteAnimation != null)
																						{
																							bool startRandomFrame = default(bool);
																							Action onComplete = default(Action);
																							bool autoSetAnimation = default(bool);
																							fogRays2._spriteAnimation.AddAnimation("loop", animationFrames, 24, (byte)(int)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																							PhaserSprite fogRays3 = _fogRays;
																							if ((object)_fogRays != null && (object)fogRays3._spriteAnimation != null)
																							{
																								fogRays3._spriteAnimation.SetAnimation("loop");
																								goto IL_0717;
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1a8f;
		IL_149d:
		if ((object)_logoSprite != null)
		{
			PhaserSprite phaserSprite9 = _logoSprite.setFrame("BronzeFinger", "UI");
			if ((object)_logoSpriteShadow != null)
			{
				PhaserSprite phaserSprite10 = _logoSpriteShadow.setFrame("BronzeFinger", "UI");
				if (_logoTween1 != null)
				{
					_logoTween1.Kill();
				}
				if (_logoTween2 != null)
				{
					_logoTween2.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[2];
				if (array != null)
				{
					if ((object)_logoSprite != null)
					{
						nint num4 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						bool flag2 = obj2 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)_totalText != null)
					{
						nint num5 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj3 = default(object);
						bool flag3 = obj3 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						tweenConfig.alpha = (float?)(object)1;
						tweenConfig.angle = (float?)(object)1;
						tweenConfig.duration = 300f;
						tweenConfig.scale = (float?)(object)1;
						TweenCallback onComplete2 = delegate
						{
							//IL_0026: Expected O, but got Ref
							//IL_006f: Expected I, but got O
							//IL_00d3: Expected O, but got I4
							//IL_00f3: Expected I4, but got I8
							//IL_0101: Expected O, but got I4
							Transform transform10 = _totalText.transform;
							object obj8 = default(object);
							transform10.localEulerAngles = (Vector3)(&obj8);
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							if ((object)_logoSprite != null)
							{
								nint num10 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj9 = default(object);
								if (obj9 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							tweenConfig2.targets = array2;
							tweenConfig2.duration = 1000f;
							tweenConfig2.angle = (float?)(object)1;
							tweenConfig2.yoyo = true;
							tweenConfig2.repeat = -1;
							tweenConfig2.scale = (float?)(object)1;
							TweenCallback onStart = delegate
							{
								//IL_0026: Expected O, but got Ref
								Transform transform11 = _logoSprite.transform;
								object obj10 = default(object);
								transform11.localEulerAngles = (Vector3)(&obj10);
								PhaserSprite phaserSprite31 = RenderingExtensions.SetScale(_logoSprite, 1f);
							};
							tweenConfig2.onStart = onStart;
							MultiTargetTween logoTween2 = Tweens.Add(tweenConfig2);
							_logoTween2 = logoTween2;
						};
						tweenConfig.onComplete = onComplete2;
						MultiTargetTween logoTween = Tweens.Add(tweenConfig);
						_logoTween1 = logoTween;
						GameManager core5 = GM.Core;
						if ((object)GM.Core != null)
						{
							core5._003CHasGfBonus_003Ek__BackingField = true;
							_gFCooldownBonus = -1f;
							GameManager core6 = GM.Core;
							if ((object)GM.Core != null)
							{
								List<VampireSurvivors.Objects.Characters.CharacterController> characters = core6._characters;
								if (core6._characters != null)
								{
									List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core6._characters;
									List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
									object obj4 = default(object);
									List<Equipment>.Enumerator enumerator2 = default(List<Equipment>.Enumerator);
									object obj5 = default(object);
									while (enumerator.MoveNext())
									{
										VampireSurvivors.Objects.Characters.CharacterController characterController = null;
										GameManager playerStats = (GameManager)(object)characterController._playerStats;
										bool flag4 = characterController._playerStats == null;
										EggFloat eggFloat = (EggFloat)(object)playerStats._GlobalLight + _gFCooldownBonus;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A333C0");
										if (characterController._isDead || ((VampireSurvivors.Objects.Characters.CharacterController)null).IsDisconnectedFromOnlinePlay)
										{
											continue;
										}
										CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
										bool flag5 = (object)characterController._weaponsManager == null;
										bool flag6 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
										characters2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)obj4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4943 @ rax_v143+10]");
										GameManager gameManager = (GameManager)0;
										bool flag7 = false;
										while (enumerator2.MoveNext())
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4943 @ rax_v143+10]");
											bool flag8 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002AF0");
											if (obj5 == null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4943 @ rax_v143+10]");
												bool flag9 = (nint)0 == 0;
												bool flag10 = (object)characterController._weaponsManager == null;
												Weapon weaponByType = characterController._weaponsManager.GetWeaponByType((WeaponType)gameManager._GlobalLight);
												bool flag11 = (object)weaponByType == null;
												weaponByType.Fire();
												characters = null;
												flag7 = false;
											}
										}
									}
									GameManager core7 = GM.Core;
									if ((object)GM.Core != null)
									{
										Stage stage = core7._stage;
										if ((object)core7._stage != null)
										{
											StageData stageData = stage._stageData;
											GameManager core8 = GM.Core;
											Stage stage2 = core8._stage;
											stage2._maximum = 500;
											if (stage._stageData != null)
											{
												stageData._003Cminimum_003Ek__BackingField = 500;
												GameManager core9 = GM.Core;
												if ((object)GM.Core != null && (object)core9._stage != null)
												{
													core9._stage.SwarmCheck();
													return;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1a8f;
		IL_078b:
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3120 @ rax_v76 (UnityEngine.Bounds)+10]");
		Vector2 vector = (Vector2)0;
		object obj6 = Screen.height;
		object obj7 = Screen.width;
		GameManager logoSprite = (GameManager)(object)_logoSprite;
		if ((object)_logoSprite != null && ((UnityEngine.Object)logoSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0a44;
		}
		GameManager core10 = GM.Core;
		float num6 = default(float);
		if ((object)GM.Core != null)
		{
			MainGamePage mainGamePage = core10._003CMainUI_003Ek__BackingField;
			if ((object)core10._003CMainUI_003Ek__BackingField != null && (object)mainGamePage._EnemiesText != null)
			{
				Transform transform = mainGamePage._EnemiesText.transform;
				if ((object)transform != null)
				{
					bool flag12 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Vector3 vector2 = UICamera.UIToGame((Vector3)(&num6));
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
					{
					}
					PhaserScene scene4 = _scene;
					if (_scene != null)
					{
						PhaserSprite phaserSprite11 = RenderingExtensions.sprite(scene4.add, (Vector2)num3, "UI", "BronzeFinger");
						if ((object)phaserSprite11 != null)
						{
							PhaserSprite phaserSprite12 = phaserSprite11.setScale(0f, (float?)(object)0);
							if ((object)phaserSprite12 != null)
							{
								PhaserSprite phaserSprite13 = phaserSprite12.setAlpha(0f);
								if ((object)phaserSprite13 != null)
								{
									PhaserSprite phaserSprite14 = phaserSprite13.setDepth(31763);
									if ((object)phaserSprite14 != null)
									{
										PhaserSprite logoSprite2 = phaserSprite14.setName("LogoSprite");
										_logoSprite = logoSprite2;
										if ((object)_logoSprite != null)
										{
											Transform transform2 = _logoSprite.transform;
											Camera main2 = Camera.main;
											if ((object)main2 != null)
											{
												Transform transform3 = main2.transform;
												if ((object)transform2 != null)
												{
													transform2.SetParent(transform3, worldPositionStays: true);
													float num2 = 0f;
													vector = (Vector2)num3;
													goto IL_0a44;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1a8f;
		IL_1a8f:
		throw new NullReferenceException();
		IL_0a44:
		GameManager logoSpriteShadow = (GameManager)(object)_logoSpriteShadow;
		if ((object)_logoSpriteShadow != null && ((UnityEngine.Object)logoSpriteShadow).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0d08;
		}
		GameManager core11 = GM.Core;
		if ((object)GM.Core != null)
		{
			MainGamePage mainGamePage2 = core11._003CMainUI_003Ek__BackingField;
			if ((object)core11._003CMainUI_003Ek__BackingField != null && (object)mainGamePage2._EnemiesText != null)
			{
				Transform transform4 = mainGamePage2._EnemiesText.transform;
				if ((object)transform4 != null)
				{
					Vector3 position = transform4.position;
					Vector3 vector3 = UICamera.UIToGame((Vector3)(&num6));
					PhaserScene scene5 = default(PhaserScene);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
					{
						scene5 = _scene;
						if (_scene == null)
						{
							goto IL_1a8f;
						}
					}
					PhaserSprite phaserSprite15 = RenderingExtensions.sprite(scene5.add, (Vector2)num3, "UI", "BronzeFinger");
					if ((object)phaserSprite15 != null)
					{
						PhaserSprite phaserSprite16 = phaserSprite15.setScale(0f, (float?)(object)0);
						if ((object)phaserSprite16 != null)
						{
							PhaserSprite phaserSprite17 = phaserSprite16.setAlpha(0f);
							if ((object)phaserSprite17 != null)
							{
								PhaserSprite phaserSprite18 = phaserSprite17.setDepth(31762);
								if ((object)phaserSprite18 != null)
								{
									PhaserSprite logoSpriteShadow2 = phaserSprite18.setName("LogoSpriteShadow");
									_logoSpriteShadow = logoSpriteShadow2;
									if ((object)_logoSpriteShadow != null)
									{
										Transform transform5 = _logoSpriteShadow.transform;
										Camera main3 = Camera.main;
										if ((object)main3 != null)
										{
											Transform transform6 = main3.transform;
											if ((object)transform5 != null)
											{
												transform5.SetParent(transform6, worldPositionStays: true);
												float num2 = 0f;
												vector = (Vector2)num3;
												goto IL_0d08;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1a8f;
		IL_110e:
		GameManager clapSpriteL = (GameManager)(object)_clapSpriteL;
		float num7;
		if ((object)_clapSpriteL != null)
		{
			bool flag13 = ((UnityEngine.Object)clapSpriteL).m_CachedPtr != (IntPtr)0;
			Vector2 vector4 = (Vector2)num7;
			if (flag13)
			{
				goto IL_149d;
			}
		}
		if ((object)_logoSprite != null)
		{
			float2 position2 = _logoSprite.position;
			if ((object)_logoSprite != null)
			{
				float2 position3 = _logoSprite.position;
				PhaserScene scene6 = _scene;
				if (_scene != null)
				{
					PhaserSprite phaserSprite19 = RenderingExtensions.sprite(scene6.add, (Vector2)num3, "enemiesM", "hand_clap_L");
					if ((object)phaserSprite19 != null)
					{
						PhaserSprite phaserSprite20 = phaserSprite19.setOrigin(1f, (float?)(object)1);
						if ((object)phaserSprite20 != null)
						{
							PhaserSprite phaserSprite21 = phaserSprite20.setScale(1f, (float?)(object)0);
							if ((object)phaserSprite21 != null)
							{
								PhaserSprite component2 = phaserSprite21.setAlpha(0f);
								PhaserSprite phaserSprite22 = RenderingExtensions.SetScrollFactor(component2, 0f);
								if ((object)phaserSprite22 != null)
								{
									PhaserSprite phaserSprite23 = phaserSprite22.setDepth(31771);
									if ((object)phaserSprite23 != null)
									{
										PhaserSprite clapSpriteL2 = phaserSprite23.setName("ClapSpriteL");
										_clapSpriteL = clapSpriteL2;
										PhaserScene scene7 = _scene;
										if (_scene != null)
										{
											PhaserSprite phaserSprite24 = RenderingExtensions.sprite(scene7.add, (Vector2)num3, "enemiesM", "hand_clap_R");
											if ((object)phaserSprite24 != null)
											{
												PhaserSprite phaserSprite25 = phaserSprite24.setOrigin(0f, (float?)(object)1);
												if ((object)phaserSprite25 != null)
												{
													PhaserSprite phaserSprite26 = phaserSprite25.setScale(1f, (float?)(object)0);
													if ((object)phaserSprite26 != null)
													{
														PhaserSprite component3 = phaserSprite26.setAlpha(0f);
														PhaserSprite phaserSprite27 = RenderingExtensions.SetScrollFactor(component3, 0f);
														if ((object)phaserSprite27 != null)
														{
															PhaserSprite phaserSprite28 = phaserSprite27.setDepth(31772);
															if ((object)phaserSprite28 != null)
															{
																PhaserSprite clapSpriteR = phaserSprite28.setName("ClapSpriteR");
																_clapSpriteR = clapSpriteR;
																float num2 = 0f;
																Vector2 vector4 = (Vector2)num3;
																goto IL_149d;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1a8f;
		IL_0717:
		if ((object)_fogRays != null)
		{
			PhaserSprite phaserSprite29 = _fogRays.setVisible(visible: true);
			if ((object)_fogRays != null)
			{
				PhaserSprite phaserSprite30 = _fogRays.setAlpha(1f);
				float num2 = 1f;
				goto IL_078b;
			}
		}
		goto IL_1a8f;
		IL_0d08:
		GameManager totalText = (GameManager)(object)_totalText;
		if ((object)_totalText != null)
		{
			bool flag14 = ((UnityEngine.Object)totalText).m_CachedPtr != (IntPtr)0;
			num7 = (float)vector;
			float num8 = 2000f;
			if (flag14)
			{
				goto IL_110e;
			}
		}
		GameManager core12 = GM.Core;
		if ((object)GM.Core != null)
		{
			MainGamePage mainGamePage3 = core12._003CMainUI_003Ek__BackingField;
			if ((object)core12._003CMainUI_003Ek__BackingField != null && (object)mainGamePage3._EnemiesText != null)
			{
				Transform transform7 = mainGamePage3._EnemiesText.transform;
				if ((object)transform7 != null)
				{
					Vector3 position4 = transform7.position;
					Vector3 vector5 = UICamera.UIToGame((Vector3)(&num6));
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) || (object)GM.Core != null)
					{
						PhaserScene scene8 = GM.Core.scene;
						if (scene8 != null)
						{
							BitmapText bitmapText = RenderingExtensions.bitmapText(scene8.add, (Vector2)num3, "0", (Color)(&paramsArray2), (int)num);
							if ((object)bitmapText != null)
							{
								BitmapText bitmapText2 = bitmapText.SetFont("GoldenFinger_Numbers-export");
								if ((object)bitmapText2 != null && (object)((GameManager)(object)bitmapText2)._Preloader != null)
								{
									num7 = ((TextMesh)(object)((GameManager)(object)bitmapText2)._Preloader).color.r;
									float num9 = default(float);
									((TextMesh)(object)((GameManager)(object)bitmapText2)._Preloader).color = (Color)(&num9);
									if ((object)((GameManager)(object)bitmapText2)._Preloader != null)
									{
										((TextMesh)(object)((GameManager)(object)bitmapText2)._Preloader).alignment = TextAlignment.Center;
										TextMesh preloader = (TextMesh)(object)((GameManager)(object)bitmapText2)._Preloader;
										if ((object)((GameManager)(object)bitmapText2)._Preloader != null)
										{
											bool flag15 = ((UnityEngine.Object)preloader).m_CachedPtr == (IntPtr)0;
											TextMesh.set_anchor_Injected(((UnityEngine.Object)preloader).m_CachedPtr, TextAnchor.UpperCenter);
											if ((object)((GameManager)(object)bitmapText2)._Preloader != null)
											{
												Renderer component4 = ((Component)(object)((GameManager)(object)bitmapText2)._Preloader).GetComponent<Renderer>();
												if ((object)component4 != null)
												{
													component4.sortingOrder = 31767;
													BitmapText bitmapText3 = bitmapText2.SetTint(11891247u);
													if ((object)bitmapText3 != null)
													{
														GameObject gameObject = bitmapText3.gameObject;
														if ((object)gameObject != null)
														{
															((UnityEngine.Object)gameObject).SetName("TotalText");
															_totalText = bitmapText3;
															if ((object)_totalText != null)
															{
																Transform transform8 = _totalText.transform;
																Camera main4 = Camera.main;
																if ((object)main4 != null)
																{
																	Transform transform9 = main4.transform;
																	if ((object)transform8 != null)
																	{
																		transform8.SetParent(transform9, worldPositionStays: true);
																		float num2 = num3;
																		float num8 = num3;
																		goto IL_110e;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_1a8f;
	}

	public unsafe void GoldenFingerUpdate()
	{
		//IL_04c9: Expected O, but got I
		//IL_0288: Expected F4, but got I4
		//IL_0789: Expected O, but got I
		//IL_0296: Expected F4, but got I4
		//IL_029e: Expected O, but got Ref
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Expected O, but got Unknown
		//IL_1240: Unknown result type (might be due to invalid IL or missing references)
		//IL_1245: Expected O, but got Unknown
		//IL_1374: Invalid comparison between F4 and O
		//IL_0870: Expected O, but got F4
		//IL_087f: Expected O, but got F4
		//IL_08a4: Invalid comparison between F4 and I4
		//IL_08b3: Invalid comparison between F4 and I4
		//IL_13a1: Expected O, but got I4
		//IL_13a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ae: Expected O, but got Unknown
		//IL_07f5: Expected O, but got F4
		//IL_0802: Expected O, but got F4
		//IL_0827: Invalid comparison between F4 and I4
		//IL_0836: Invalid comparison between F4 and I4
		//IL_06e9: Expected I4, but got O
		//IL_0990: Expected O, but got Ref
		//IL_09cd: Invalid comparison between F4 and I4
		//IL_0dba: Expected I, but got O
		//IL_0e24: Expected O, but got I4
		//IL_0e40: Expected O, but got I4
		//IL_0e4e: Expected O, but got I4
		//IL_0a8e: Expected I, but got O
		//IL_13c9: Expected I, but got O
		//IL_13df: Expected O, but got I
		//IL_13e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ed: Expected O, but got Unknown
		//IL_0ef4: Expected I, but got O
		//IL_0af8: Expected O, but got I4
		//IL_0b14: Expected O, but got I4
		//IL_0b22: Expected O, but got I4
		//IL_1413: Expected O, but got I4
		//IL_142a: Expected I, but got I8
		//IL_0edd: Expected I, but got I8
		//IL_0fb7: Expected I, but got O
		//IL_0c17: Expected I, but got O
		//IL_1021: Expected O, but got I4
		//IL_0c81: Expected O, but got I4
		//IL_1449: Expected I, but got O
		//IL_145f: Expected O, but got I
		//IL_1468: Unknown result type (might be due to invalid IL or missing references)
		//IL_146d: Expected O, but got Unknown
		//IL_10da: Expected I, but got O
		//IL_14a1: Expected I, but got I8
		//IL_10ad: Expected I, but got I8
		//IL_08fa->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0926->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0952->IL114d: Incompatible stack heights: 1 vs 0
		//IL_097e->IL114d: Incompatible stack heights: 1 vs 0
		//IL_09df->IL0cf4: Incompatible stack heights: 1 vs 0
		//IL_0d8e->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0a62->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0dff->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0ddd->IL0ddd: Incompatible stack heights: 2 vs 1
		//IL_0ad3->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0ab1->IL0ab1: Incompatible stack heights: 2 vs 1
		//IL_0f8b->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0beb->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0ffc->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0c5c->IL114d: Incompatible stack heights: 1 vs 0
		//IL_0fda->IL0fda: Incompatible stack heights: 2 vs 1
		//IL_0c3a->IL0c3a: Incompatible stack heights: 2 vs 1
		//IL_0cf4->IL0cf4: Incompatible stack heights: 1 vs 0
		//IL_1100->IL0cf4: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		UnityEngine.Object obj;
		if ((object)GM.Core != null)
		{
			if (!core._003CHasGfBonus_003Ek__BackingField)
			{
				return;
			}
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			float elapsedGfBonusTime = _elapsedGfBonusTime + num;
			_elapsedGfBonusTime = elapsedGfBonusTime;
			float gFDurationWithBonus = GFDurationWithBonus;
			float elapsedGfBonusTime2 = _elapsedGfBonusTime;
			float num2 = gFDurationWithBonus - 2000f;
			if (!(_elapsedGfBonusTime < num2) && (bool)_fogRays)
			{
				if ((object)_fogRays == null)
				{
					goto IL_114d;
				}
				float num3 = gFDurationWithBonus - 2000f;
				float num4 = _elapsedGfBonusTime - num3;
				elapsedGfBonusTime2 = num4 / 1000f;
				num2 = 1f - elapsedGfBonusTime2;
				PhaserSprite phaserSprite = _fogRays.setAlpha(num2);
				Stage stage = null;
			}
			if (_elapsedGfBonusTime < gFDurationWithBonus)
			{
				obj = null;
				goto IL_11d6;
			}
			if ((bool)_fogRays)
			{
				if ((object)_fogRays == null)
				{
					goto IL_114d;
				}
				PhaserSprite phaserSprite2 = _fogRays.setVisible(visible: false);
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				core2._003CHasGfBonus_003Ek__BackingField = false;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> characters = core3._characters;
					if (core3._characters != null)
					{
						num2 = 0f;
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator.MoveNext())
						{
							float num5 = 0f;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core4._stage;
							if ((object)core4._stage != null)
							{
								StageData stageData = stage2._stageData;
								GameManager core5 = GM.Core;
								Stage stage3 = core5._stage;
								if (stage2._stageData != null)
								{
									stageData._003Cminimum_003Ek__BackingField = stage3._lastMinimum;
									GameManager core6 = GM.Core;
									if ((object)GM.Core != null)
									{
										Stage stage = core6._stage;
										if ((object)core6._stage != null)
										{
											stage._maximum = stage._lastMaximum;
											DoExitAnimation();
											obj = null;
											goto IL_11d6;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_114d;
		IL_114d:
		throw new NullReferenceException();
		IL_11d6:
		_previousAwardReached = _awardReached;
		float num6 = CurrentEnemiesCounter();
		List<int> thresholds = _thresholds;
		bool flag = _thresholds == null;
		UnityEngine.Object obj2 = obj;
		UnityEngine.Object obj3 = obj;
		if (!flag)
		{
			string spriteName = default(string);
			string spriteName2 = default(string);
			uint tint = default(uint);
			object obj18 = default(object);
			object obj19 = default(object);
			object obj20 = default(object);
			object obj24 = default(object);
			while (true)
			{
				UnityEngine.Object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1368 @ rax_v39 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)obj4 < 0)
				{
					List<int> thresholds2 = _thresholds;
					if (_thresholds == null)
					{
						break;
					}
					UnityEngine.Object obj5 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v221 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)obj5 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v221 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v221 (System.Collections.Generic.List`1<System.Int32>)+10]");
						if ((nint)0 == 0)
						{
							break;
						}
						UnityEngine.Object obj7 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v106+18]");
						if ((nint)obj7 < 0)
						{
							VampireSurvivors.Objects.Characters.CharacterController player = _player;
							if ((object)_player == null)
							{
								break;
							}
							object obj8 = obj2 + 1;
							object obj9 = obj8 * player._level;
							float num7 = (float)obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v106+20+v214 @ rbx_v17 (UnityEngine.Object)*4]");
							float num8 = num7 + 0f;
							if (!(num6 < num8))
							{
								if (_frames == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								if ((object)_logoSprite == null)
								{
									break;
								}
								PhaserSprite phaserSprite3 = _logoSprite.setFrame(spriteName, "UI");
								if (_frames == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								if ((object)_logoSpriteShadow == null)
								{
									break;
								}
								PhaserSprite phaserSprite4 = _logoSpriteShadow.setFrame(spriteName2, "UI");
								if (_fontTints == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
								if ((object)_totalText == null)
								{
									break;
								}
								BitmapText bitmapText = _totalText.SetTint(tint);
								if (_fontScales == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
								_targetScale = num8;
								_awardReached = (int)obj2;
								List<VampireSurvivors.Objects.Characters.CharacterController> characters = null;
								Stage stage = null;
							}
							obj2 = (UnityEngine.Object)(obj2 + 1);
							thresholds = _thresholds;
							if (_thresholds == null)
							{
								break;
							}
							obj3 = obj2;
							continue;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				UnityEngine.Object totalText = _totalText;
				NumberFormatInfo instance = NumberFormatInfo.GetInstance(CultureInfo.invariant_culture_info);
				string text = System.Number.FormatSingle(num6, null, instance);
				if ((object)_totalText == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rbx_v18 (UnityEngine.Object)+28]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rbx_v18 (UnityEngine.Object)+28]");
				((TextMesh)0).text = text;
				object totalText2 = _totalText;
				if ((object)_totalText == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r15_v14 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_totalText);
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r15_v14 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if ((object)transform == null)
				{
					break;
				}
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float deltaTime2 = PauseSystem.DeltaTime;
				float num9 = deltaTime2 * 0.001f;
				float num10 = num9 * 1000f;
				float targetScale = _targetScale;
				float num11;
				bool flag3;
				bool flag4;
				bool flag5;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)targetScale) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
				{
					num11 = (float)ret - num10;
					float num12 = num11 - _targetScale;
					object obj10 = num11 ^ _targetScale;
					object obj11 = num11 ^ num12;
					object obj12 = obj10 & obj11;
					flag3 = (nint)obj12 < 0;
					flag4 = num12 < 0f;
					flag5 = num12 == 0f;
				}
				else
				{
					num11 = (float)ret + num10;
					float num13 = _targetScale - num11;
					object obj13 = _targetScale ^ num11;
					object obj14 = _targetScale ^ num13;
					object obj15 = obj13 & obj14;
					flag3 = (nint)obj15 < 0;
					flag4 = num13 < 0f;
					flag5 = num13 == 0f;
				}
				bool flag6 = flag4 == flag3;
				object obj16 = !flag5;
				object obj17 = flag6 & obj16;
				if (obj17 == null)
				{
					num11 = _targetScale;
				}
				BitmapText bitmapText2 = RenderingExtensions.SetScale(_totalText, num11);
				if ((object)_logoSprite == null)
				{
					break;
				}
				Transform transform2 = _logoSprite.transform;
				if ((object)transform2 == null)
				{
					break;
				}
				Vector3 localEulerAngles = transform2.localEulerAngles;
				if ((object)_logoSpriteShadow == null)
				{
					break;
				}
				Transform transform3 = _logoSpriteShadow.transform;
				if ((object)transform3 == null)
				{
					break;
				}
				transform3.localEulerAngles = (Vector3)(&ret);
				if (_previousAwardReached == _awardReached)
				{
					float num14 = num6 / 100f;
					if (num14 > (float)_shadowBumps)
					{
						int shadowBumps = _shadowBumps + 1;
						_shadowBumps = shadowBumps;
						if (_shadowTween != null)
						{
							_shadowTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array == null)
						{
							break;
						}
						if ((object)_logoSpriteShadow != null)
						{
							nint num15 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							bool flag7 = obj18 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig == null)
						{
							break;
						}
						tweenConfig.targets = array;
						tweenConfig.alpha = (float?)(object)1;
						tweenConfig.duration = 150f;
						tweenConfig.scaleX = (float?)(object)1;
						tweenConfig.scaleY = (float?)(object)1;
						tweenConfig.yoyo = true;
						tweenConfig.ease = Ease.InOutBounce;
						TweenCallback onStart = delegate
						{
							//IL_002e: Expected O, but got I4
							PhaserSprite phaserSprite5 = _logoSpriteShadow.setAlpha(0.65f);
							PhaserSprite phaserSprite6 = _logoSpriteShadow.setScale(0f, (float?)(object)0);
						};
						tweenConfig.onStart = onStart;
						MultiTargetTween shadowTween = Tweens.Add(tweenConfig);
						_shadowTween = shadowTween;
						if (_logoTween3 != null)
						{
							_logoTween3.Kill();
						}
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if (array2 == null)
						{
							break;
						}
						if ((object)_logoSprite != null)
						{
							nint num16 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							bool flag8 = obj19 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 == null)
						{
							break;
						}
						tweenConfig2.targets = array2;
						tweenConfig2.scale = (float?)(object)1;
						tweenConfig2.duration = 150f;
						tweenConfig2.yoyo = true;
						tweenConfig2.ease = Ease.InOutBounce;
						TweenCallback onStart2 = delegate
						{
							//IL_0015: Expected O, but got I4
							PhaserSprite phaserSprite5 = _logoSprite.setScale(1f, (float?)(object)0);
						};
						tweenConfig2.onStart = onStart2;
						MultiTargetTween logoTween = Tweens.Add(tweenConfig2);
						_logoTween3 = logoTween;
					}
					return;
				}
				Debug.Log("New award reached");
				_previousAwardReached = _awardReached;
				int shadowBumps2 = _shadowBumps + 1;
				_shadowBumps = shadowBumps2;
				if (_shadowTween != null)
				{
					_shadowTween.Kill();
				}
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				if (array3 == null)
				{
					break;
				}
				if ((object)_logoSpriteShadow != null)
				{
					nint num17 = (nint)array3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag9 = obj20 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig3 == null)
				{
					break;
				}
				tweenConfig3.targets = array3;
				tweenConfig3.alpha = (float?)(object)1;
				tweenConfig3.duration = 150f;
				tweenConfig3.scaleX = (float?)(object)1;
				tweenConfig3.scaleY = (float?)(object)1;
				tweenConfig3.yoyo = true;
				tweenConfig3.ease = Ease.InOutBounce;
				TweenCallback tweenCallback = null;
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r10_v12 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(GoldFingerManager._003CGoldenFingerUpdate_003Eb__33_0);
				((Delegate)tweenCallback).m_target = this;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r10_v12 (Il2CppMethodInfo)+4C]");
				object obj21 = (nint)0 >> 4;
				object obj22 = obj21 & 1;
				nint num19;
				if (obj22 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r10_v12 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num19 = unchecked((nint)6447293664L);
						goto IL_140a;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num19 = ((Delegate)tweenCallback).method_ptr;
				goto IL_140a;
				IL_140a:
				object obj23 = 24;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				tweenConfig3.onStart = tweenCallback;
				MultiTargetTween shadowTween2 = Tweens.Add(tweenConfig3);
				_shadowTween = shadowTween2;
				if (_logoTween3 != null)
				{
					_logoTween3.Kill();
				}
				TweenConfig tweenConfig4 = new TweenConfig();
				object[] array4 = new object[1];
				if (array4 == null)
				{
					break;
				}
				if ((object)_logoSprite != null)
				{
					nint num20 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag10 = obj24 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig4 == null)
				{
					break;
				}
				tweenConfig4.targets = array4;
				tweenConfig4.scale = (float?)(object)1;
				tweenConfig4.duration = 150f;
				tweenConfig4.yoyo = true;
				tweenConfig4.ease = Ease.InOutBounce;
				TweenCallback tweenCallback2 = null;
				nint num21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r10_v13 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback2).method = (nint)__ldftn(GoldFingerManager._003CGoldenFingerUpdate_003Eb__33_1);
				((Delegate)tweenCallback2).m_target = this;
				((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r10_v13 (Il2CppMethodInfo)+4C]");
				object obj25 = (nint)0 >> 4;
				object obj26 = obj25 & 1;
				nint num22;
				if (obj26 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r10_v13 (Il2CppMethodInfo)+52]");
					bool flag11 = (nint)0 == 0;
					num22 = unchecked((nint)6447293664L);
					if (flag11)
					{
						goto IL_148a;
					}
				}
				num22 = ((Delegate)tweenCallback2).method_ptr;
				((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
				goto IL_148a;
				IL_148a:
				((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
				tweenConfig4.onStart = tweenCallback2;
				MultiTargetTween logoTween2 = Tweens.Add(tweenConfig4);
				_logoTween3 = logoTween2;
				return;
			}
		}
		goto IL_114d;
	}

	private void GiveAward(int award = 0)
	{
		//IL_08f2: Invalid comparison between O and F4
		//IL_0054: Expected O, but got I4
		//IL_0969: Expected O, but got I4
		//IL_0976: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Expected O, but got Unknown
		//IL_07f1: Invalid comparison between O and F4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0942: Expected I, but got O
		//IL_05b0: Invalid comparison between O and F4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0841: Expected I, but got O
		//IL_07ae: Expected F4, but got O
		//IL_0576: Expected F4, but got O
		//IL_026d: Expected F4, but got O
		//IL_02ca: Expected O, but got I4
		//IL_031f: Expected O, but got I4
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController player = _player;
		CharacterWeaponsManager weaponsManager = player._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		bool flag = award == 0;
		object obj8 = default(object);
		if (!flag)
		{
			object obj = award - 1;
			int totalCoins;
			bool isRandomType;
			if (!flag)
			{
				object obj2 = obj - 1;
				object obj4 = default(object);
				Vector2 pos = default(Vector2);
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 != 1)
						{
							return;
						}
						float2 position = _player.position;
						float2 position2 = _player.position;
						PhaserScene scene = GM.Core.scene;
						PhaserScene.Renderer renderer = scene._renderer;
						float num = renderer.height * 0.4f;
						float y = (float)obj4 - num;
						List<float> list2 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
						list2.Add(3f);
						list2.Add(33f);
						list2.Add(100f);
						List<PrizeType?> list3 = new List<PrizeType?>();
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						((List<float>)(object)list3).Add(100f);
						Treasure treasure = new Treasure();
						treasure.chances = list2;
						treasure.prizeTypes = list3;
						GameManager core = GM.Core;
						int num2 = core._stage.SetTreasureLevelFromChance(treasure);
						TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
						GameManager core2 = GM.Core;
						core2._gizmoManager.ShowHighlightAt((float)position, y);
						List<WeaponType> choices = new List<WeaponType>();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						VampireSurvivors.Objects.Characters.CharacterController player2 = _player;
						object obj5 = player2._maxWeaponBonus + player2._maxWeaponCount;
						if (list._size < (nint)obj5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						}
						VampireSurvivors.Objects.Characters.CharacterController player3 = _player;
						object obj6 = player3._maxWeaponBonus + 1;
						object obj7 = obj6 + player3._maxWeaponCount;
						if (list._size < (nint)obj7 && !GM.Core.HasAnimaWeapon(_player))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						}
						GiveRandomWeapon(choices);
						totalCoins = 64;
					}
					else
					{
						float2 position3 = _player.position;
						float2 position4 = _player.position;
						PhaserScene scene2 = GM.Core.scene;
						PhaserScene.Renderer renderer2 = scene2._renderer;
						float num3 = renderer2.height * 0.4f;
						float y2 = (float)obj4 - num3;
						List<float> list4 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
						list4.Add(3f);
						list4.Add(33f);
						list4.Add(100f);
						List<PrizeType?> list5 = new List<PrizeType?>();
						((List<float>)(object)list5).Add(100f);
						((List<float>)(object)list5).Add(100f);
						((List<float>)(object)list5).Add(100f);
						((List<float>)(object)list5).Add(100f);
						((List<float>)(object)list5).Add(100f);
						Treasure treasure2 = new Treasure();
						treasure2.chances = list4;
						treasure2.prizeTypes = list5;
						GameManager core3 = GM.Core;
						int num4 = core3._stage.SetTreasureLevelFromChance(treasure2);
						TreasureChest treasureChest2 = GM.Core.MakeTreasure(pos, treasure2);
						GameManager core4 = GM.Core;
						core4._gizmoManager.ShowHighlightAt((float)position3, y2);
						totalCoins = 32;
					}
					isRandomType = true;
				}
				else
				{
					VampireSurvivors.Objects.Characters.CharacterController player4 = _player;
					float num5 = player4.MaxHp();
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)player4._currentHp))
					{
						GameManager core5 = GM.Core;
						Stage stage = core5._stage;
						stage._stageEventManager.fnChicken();
					}
					float2 position5 = _player.position;
					float2 position6 = _player.position;
					PhaserScene scene3 = GM.Core.scene;
					PhaserScene.Renderer renderer3 = scene3._renderer;
					float num6 = renderer3.height * 0.4f;
					float y3 = (float)obj4 - num6;
					List<float> list6 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
					list6.Add(3f);
					list6.Add(33f);
					list6.Add(100f);
					List<PrizeType?> list7 = new List<PrizeType?>();
					((List<float>)(object)list7).Add(100f);
					((List<float>)(object)list7).Add(100f);
					((List<float>)(object)list7).Add(100f);
					((List<float>)(object)list7).Add(100f);
					((List<float>)(object)list7).Add(100f);
					Treasure treasure3 = new Treasure();
					treasure3.chances = list6;
					treasure3.prizeTypes = list7;
					GameManager core6 = GM.Core;
					int num7 = core6._stage.SetTreasureLevelFromChance(treasure3);
					TreasureChest treasureChest3 = GM.Core.MakeTreasure(pos, treasure3);
					GameManager core7 = GM.Core;
					core7._gizmoManager.ShowHighlightAt((float)position5, y3);
					totalCoins = 64;
					isRandomType = false;
				}
			}
			else
			{
				VampireSurvivors.Objects.Characters.CharacterController player5 = _player;
				float num8 = _player.MaxHp();
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)player5._currentHp))
				{
					GameManager core8 = GM.Core;
					Stage stage2 = core8._stage;
					stage2._stageEventManager.fnPetPlayer(_player);
					nint num9 = unchecked((nint)null);
				}
				List<ItemType> choices2 = new List<ItemType>();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				MakeItem(choices2);
				List<ItemType> choices3 = new List<ItemType>();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
				MakeItem(choices3);
				totalCoins = 32;
				isRandomType = false;
			}
			SendCoins(isRandomType, totalCoins);
		}
		else
		{
			VampireSurvivors.Objects.Characters.CharacterController player6 = _player;
			float num10 = _player.MaxHp();
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)player6._currentHp))
			{
				GameManager core9 = GM.Core;
				Stage stage3 = core9._stage;
				stage3._stageEventManager.fnPetPlayer(_player);
				nint num9 = unchecked((nint)null);
			}
			VampireSurvivors.Objects.Characters.CharacterController player7 = _player;
			object obj9 = player7._maxWeaponBonus + 1;
			object obj10 = obj9 + player7._maxWeaponCount;
			if (list._size < (nint)obj10)
			{
				List<WeaponType> choices4 = new List<WeaponType>();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
				GiveRandomWeapon(choices4);
			}
		}
	}

	private unsafe void DoExitAnimation()
	{
		//IL_00de: Expected O, but got Ref
		//IL_016e: Expected I, but got O
		//IL_01c6: Expected I, but got O
		//IL_0250: Expected O, but got I4
		//IL_0405: Expected O, but got Ref
		//IL_045d: Expected O, but got Ref
		//IL_04ed: Expected I, but got O
		//IL_0838: Expected O, but got I4
		//IL_0846: Expected O, but got I4
		//IL_0653: Expected I, but got O
		//IL_08d4: Expected O, but got I4
		//IL_08e2: Expected O, but got I4
		//IL_0627->IL0751: Incompatible stack heights: 1 vs 0
		//IL_0698->IL0751: Incompatible stack heights: 1 vs 0
		//IL_0676->IL0676: Incompatible stack heights: 2 vs 1
		//IL_06c9->IL0751: Incompatible stack heights: 1 vs 0
		//IL_06f5->IL0751: Incompatible stack heights: 1 vs 0
		//IL_0750->IL0750: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass35_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass35_0();
		if (CS_0024_003C_003E8__locals12 != null)
		{
			CS_0024_003C_003E8__locals12._003C_003E4__this = this;
			CS_0024_003C_003E8__locals12.award = _awardReached;
			if (_logoTween1 != null)
			{
				_logoTween1.Kill();
			}
			if (_logoTween2 != null)
			{
				_logoTween2.Kill();
			}
			if ((object)_logoSprite != null)
			{
				Transform transform = _logoSprite.transform;
				if ((object)transform != null)
				{
					Vector3 ret = default(Vector3);
					transform.localEulerAngles = (Vector3)(&ret);
					if (_exitTween != null)
					{
						_exitTween.Kill();
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[2];
					if (array != null)
					{
						if ((object)_logoSprite != null)
						{
							nint num = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							if (obj == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if ((object)_totalText != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj2 = default(object);
							if (obj2 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							tweenConfig.duration = 500f;
							tweenConfig.delay = 2000f;
							tweenConfig.scale = (float?)(object)1;
							TweenCallback onComplete = delegate
							{
								CS_0024_003C_003E8__locals12._003C_003E4__this.GiveAward(CS_0024_003C_003E8__locals12.award);
							};
							tweenConfig.onComplete = onComplete;
							MultiTargetTween exitTween = Tweens.Add(tweenConfig);
							_exitTween = exitTween;
							if (CS_0024_003C_003E8__locals12.award < 2)
							{
								return;
							}
							if ((object)_logoSprite != null)
							{
								float2 position = _logoSprite.position;
								if ((object)_logoSprite != null)
								{
									float2 position2 = _logoSprite.position;
									if ((object)_clapSpriteL != null)
									{
										float x = (float)position + 0.08f;
										PhaserSprite phaserSprite = _clapSpriteL.setPosition(x, 0f);
										if ((object)_clapSpriteR != null)
										{
											float x2 = (float)position - 0.08f;
											PhaserSprite phaserSprite2 = _clapSpriteR.setPosition(x2, 0f);
											if ((object)_clapSpriteL != null)
											{
												Transform transform2 = _clapSpriteL.transform;
												if ((object)transform2 != null)
												{
													transform2.localEulerAngles = (Vector3)(&ret);
													if ((object)_clapSpriteR != null)
													{
														Transform transform3 = _clapSpriteR.transform;
														if ((object)transform3 != null)
														{
															transform3.localEulerAngles = (Vector3)(&ret);
															if (_clapTweenL != null)
															{
																_clapTweenL.Kill();
															}
															TweenConfig tweenConfig2 = new TweenConfig();
															object[] array2 = new object[1];
															if (array2 != null)
															{
																if ((object)_clapSpriteL != null)
																{
																	nint num3 = (nint)array2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj3 = default(object);
																	if (obj3 == null)
																	{
																		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
																		throw ex3;
																	}
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig2 != null)
																{
																	tweenConfig2.targets = array2;
																	if ((object)_clapSpriteL != null)
																	{
																		Transform transform4 = _clapSpriteL.transform;
																		if ((object)transform4 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v67 (UnityEngine.Transform)+10]");
																			bool flag = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v67 (UnityEngine.Transform)+10]");
																			Transform.get_localPosition_Injected((IntPtr)0, out ret);
																			float num4 = (float)ret - 0.06f;
																			tweenConfig2.duration = 200f;
																			tweenConfig2.delay = 1500f;
																			tweenConfig2.repeat = 8;
																			tweenConfig2.localX = (float?)(object)1;
																			tweenConfig2.angle = (float?)(object)1;
																			TweenCallback onStart = delegate
																			{
																				//IL_0063: Expected O, but got I4
																				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																				soundConfig.Volume = (float?)(object)1;
																				soundConfig.Rate = 1f;
																				float time = default(float);
																				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Cheers, soundConfig, 2000f, 1, time);
																				GoldFingerManager goldFingerManager = CS_0024_003C_003E8__locals12._003C_003E4__this;
																				PhaserSprite phaserSprite3 = goldFingerManager._clapSpriteL.setAlpha(1f);
																			};
																			tweenConfig2.onStart = onStart;
																			MultiTargetTween clapTweenL = Tweens.Add(tweenConfig2);
																			_clapTweenL = clapTweenL;
																			if (_clapTweenR != null)
																			{
																				_clapTweenR.Kill();
																			}
																			TweenConfig tweenConfig3 = new TweenConfig();
																			object[] array3 = new object[1];
																			if (array3 != null)
																			{
																				if ((object)_clapSpriteR != null)
																				{
																					nint num5 = (nint)array3;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																					object obj4 = default(object);
																					bool flag2 = obj4 == null;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				if (tweenConfig3 != null)
																				{
																					tweenConfig3.targets = array3;
																					if ((object)_clapSpriteR != null)
																					{
																						Transform transform5 = _clapSpriteR.transform;
																						if ((object)transform5 != null)
																						{
																							bool flag3 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
																							Transform.get_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret);
																							tweenConfig3.duration = 200f;
																							tweenConfig3.delay = 1500f;
																							tweenConfig3.repeat = 8;
																							tweenConfig3.localX = (float?)(object)1;
																							tweenConfig3.angle = (float?)(object)1;
																							TweenCallback onStart2 = delegate
																							{
																								GoldFingerManager goldFingerManager = CS_0024_003C_003E8__locals12._003C_003E4__this;
																								PhaserSprite phaserSprite3 = goldFingerManager._clapSpriteR.setAlpha(1f);
																							};
																							tweenConfig3.onStart = onStart2;
																							TweenCallback onComplete2 = delegate
																							{
																								//IL_009a: Expected I, but got O
																								//IL_0104: Expected I, but got O
																								//IL_0168: Expected O, but got I4
																								GoldFingerManager goldFingerManager = CS_0024_003C_003E8__locals12._003C_003E4__this;
																								if (goldFingerManager._clapAlphaTween != null)
																								{
																									goldFingerManager._clapAlphaTween.Kill();
																								}
																								GoldFingerManager goldFingerManager2 = CS_0024_003C_003E8__locals12._003C_003E4__this;
																								TweenConfig tweenConfig4 = new TweenConfig();
																								object[] array4 = new object[2];
																								GoldFingerManager goldFingerManager3 = CS_0024_003C_003E8__locals12._003C_003E4__this;
																								if ((object)goldFingerManager3._clapSpriteL != null)
																								{
																									nint num6 = (nint)array4;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																									object obj5 = default(object);
																									if (obj5 == null)
																									{
																										ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
																										throw ex4;
																									}
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								GoldFingerManager goldFingerManager4 = CS_0024_003C_003E8__locals12._003C_003E4__this;
																								if ((object)goldFingerManager4._clapSpriteR != null)
																								{
																									nint num7 = (nint)array4;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																									object obj6 = default(object);
																									if (obj6 == null)
																									{
																										ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
																										throw ex5;
																									}
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								tweenConfig4.targets = array4;
																								tweenConfig4.duration = 200f;
																								tweenConfig4.alpha = (float?)(object)1;
																								MultiTargetTween clapAlphaTween = Tweens.Add(tweenConfig4);
																								goldFingerManager2._clapAlphaTween = clapAlphaTween;
																							};
																							tweenConfig3.onComplete = onComplete2;
																							MultiTargetTween clapTweenR = Tweens.Add(tweenConfig3);
																							_clapTweenR = clapTweenR;
																							return;
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private float CurrentEnemiesCounter()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		float result = (float)config._003CRunEnemies_003Ek__BackingField - _startingEnemiesCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		return result;
	}

	private void MakeItem(List<ItemType> choices)
	{
		//IL_00b8: Expected F4, but got O
		ItemType itemType = Extensions.PickRnd(choices);
		float2 position = _player.position;
		float2 position2 = _player.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.height * 0.45f;
		object obj = default(object);
		float y = (float)obj - num;
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = GM.Core.MakeStagePickup(pos, itemType, WeaponType.VOID, value, relicType, validatePickups);
		GameManager core = GM.Core;
		core._gizmoManager.ShowHighlightAt((float)position, y);
	}

	private void GiveRandomWeapon(List<WeaponType> choices)
	{
		//IL_01f4: Expected O, but got I4
		//IL_02ec: Expected I, but got O
		//IL_02f4: Expected I, but got O
		//IL_0304: Expected O, but got I
		//IL_0384: Expected O, but got I4
		//IL_0340: Expected O, but got I
		//IL_0376: Expected O, but got I4
		_003C_003Ec__DisplayClass38_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass38_0();
		CS_0024_003C_003E8__locals14.choices = choices;
		VampireSurvivors.Objects.Characters.CharacterController player = _player;
		CharacterWeaponsManager weaponsManager = player._weaponsManager;
		WeaponType weaponType;
		Pickup pickup;
		object obj3;
		if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
		{
			List<object> list = new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
			VampireSurvivors.Objects.Characters.CharacterController player2 = _player;
			CharacterAccessoriesManager accessoriesManager = player2._accessoriesManager;
			if (((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField != null)
			{
				List<object> collection = new List<object>(((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField);
				list.InsertRange(list._size, collection);
				List<WeaponType> list2 = new List<WeaponType>();
				CS_0024_003C_003E8__locals14.i = 0;
				while (true)
				{
					List<WeaponType> choices2 = CS_0024_003C_003E8__locals14.choices;
					int i = CS_0024_003C_003E8__locals14.i;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)i >= (nint)0)
					{
						break;
					}
					Predicate<Equipment> match = CS_0024_003C_003E8__locals14._003C_003E9__0;
					if (CS_0024_003C_003E8__locals14._003C_003E9__0 == null)
					{
						match = (CS_0024_003C_003E8__locals14._003C_003E9__0 = delegate(Equipment equipment3)
						{
							//IL_0057: Expected O, but got I
							//IL_0076: Expected O, but got I
							List<WeaponType> choices3 = CS_0024_003C_003E8__locals14.choices;
							int i3 = CS_0024_003C_003E8__locals14.i;
							int i4 = CS_0024_003C_003E8__locals14.i;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							if ((nint)i4 < (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								object obj4 = 0;
								WeaponType equipmentType = equipment3._equipmentType;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v7+20+v45 @ rax_v8 (System.Int32)*4]");
								object obj5 = (nint)equipmentType - (nint)0;
								return obj5 == null;
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							bool result = default(bool);
							return result;
						});
					}
					Equipment equipment = ((List<Equipment>)(object)list).Find(match);
					if (!equipment)
					{
						Equipment match2 = ((List<Equipment>)(object)CS_0024_003C_003E8__locals14.choices).Find((Predicate<Equipment>)CS_0024_003C_003E8__locals14.i);
						Equipment equipment2 = ((List<Equipment>)(object)list2).Find((Predicate<Equipment>)(object)match2);
					}
					int i2 = CS_0024_003C_003E8__locals14.i + 1;
					CS_0024_003C_003E8__locals14.i = i2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 <= (nint)0)
				{
					return;
				}
				weaponType = Extensions.PickRnd(list2);
				float2 position = _player.position;
				float2 position2 = _player.position;
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
				if ((object)pickup == null)
				{
					return;
				}
				nint num = (nint)typeof(PickupWeapon);
				nint num2 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v704 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v704 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rcx_v38+FFFFFFF8+v782 @ rcx_v35*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj3 = 1;
						goto IL_0419;
					}
				}
				obj3 = 0;
				goto IL_0419;
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
		IL_0419:
		bool flag = obj3 == null;
		Pickup pickup2 = null;
		if (!flag)
		{
			pickup2 = pickup;
		}
		if ((object)pickup2 != null && weaponType == WeaponType.CANDYBOX)
		{
			_ = 0;
		}
	}

	private unsafe void SendCoins(bool isRandomType = false, int totalCoins = 32)
	{
		//IL_0173: Expected I4, but got I8
		//IL_01d2: Expected O, but got I
		//IL_01a1: Expected O, but got I4
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected I4, but got Unknown
		//IL_0d37: Expected I4, but got I8
		//IL_02e9: Expected O, but got I
		//IL_02b8: Expected O, but got I4
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected I4, but got Unknown
		//IL_0343: Expected O, but got I
		//IL_039d: Expected O, but got I
		//IL_0bc4: Expected O, but got I
		//IL_042d: Expected O, but got I
		//IL_0bec: Expected O, but got I
		//IL_04bd: Expected O, but got I
		//IL_0c14: Expected O, but got I
		//IL_054d: Expected O, but got I
		//IL_0c3c: Expected O, but got I
		//IL_05dd: Expected O, but got I
		//IL_0c64: Expected O, but got I
		//IL_066d: Expected O, but got I
		//IL_0c8c: Expected O, but got I
		//IL_06fd: Expected O, but got I
		//IL_0cb4: Expected O, but got I
		//IL_078e: Expected O, but got I
		//IL_08c2: Expected O, but got I4
		//IL_08cf: Expected F4, but got O
		//IL_0387->IL0ba1: Incompatible stack heights: 8 vs 9
		//IL_0417->IL0bc9: Incompatible stack heights: 9 vs 10
		//IL_04a7->IL0bf1: Incompatible stack heights: 10 vs 11
		//IL_0537->IL0c19: Incompatible stack heights: 11 vs 12
		//IL_05c7->IL0c41: Incompatible stack heights: 12 vs 13
		//IL_0657->IL0c69: Incompatible stack heights: 13 vs 14
		//IL_06e7->IL0c91: Incompatible stack heights: 14 vs 15
		//IL_0778->IL0cb9: Incompatible stack heights: 15 vs 16
		//IL_0a4e->IL0cfc: Incompatible stack heights: 16 vs 2
		//IL_09a2->IL0cfc: Incompatible stack heights: 16 vs 2
		//IL_08fc->IL0cfc: Incompatible stack heights: 16 vs 2
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals22._003C_003E4__this = this;
		PhaserScene scene = _scene;
		PhaserScene.Renderer renderer = scene._renderer;
		Ellipse ellipse = new Ellipse();
		float width = renderer.width * 1.4f;
		float height = renderer.height * 1.4f;
		ellipse._x = 0f;
		ellipse._width = width;
		ellipse._height = height;
		List<Vector2> points = ellipse.GetPoints(32);
		bool flag = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag2 = s_scene._renderer == null;
		CS_0024_003C_003E8__locals22.i = 0;
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool shouldCallValidatePickups = default(bool);
		bool isRemote = default(bool);
		while (CS_0024_003C_003E8__locals22.i < totalCoins)
		{
			ArcadeSprite player = _player;
			Transform cachedTrans = ((ArcadeSprite)_player).CachedTrans;
			bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (player.body != null)
			{
				BaseBody body = player.body;
				ArcadeTransform transform = body._transform;
				transform.position = ret;
			}
			int num = (int)(CS_0024_003C_003E8__locals22.i & 0x8000001FL);
			if ((nint)points < 0)
			{
				object obj = num - 1;
				object obj2 = obj | -32;
				num = obj2 + 1;
			}
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag4 = (nint)num2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj3 = 0;
			int num3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v27+18]");
			bool flag5 = (nint)num3 >= (nint)0;
			ArcadeSprite player2 = _player;
			Transform cachedTrans2 = ((ArcadeSprite)_player).CachedTrans;
			bool flag6 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
			Vector2 ret2;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
			object obj4 = (object)player2.body ^ (object)player2.body;
			object obj5 = (object)player2.body & obj4;
			bool flag7 = (nint)obj5 < 0;
			bool flag8 = (nint)player2.body < 0;
			if (player2.body != null)
			{
				BaseBody body2 = player2.body;
				ArcadeTransform transform2 = body2._transform;
				object obj6 = (object)body2._transform ^ (object)body2._transform;
				object obj7 = (object)body2._transform & obj6;
				flag7 = (nint)obj7 < 0;
				flag8 = (nint)body2._transform < 0;
				transform2.position = ret2;
			}
			int num4 = (int)(CS_0024_003C_003E8__locals22.i & 0x8000001FL);
			if (flag8 != flag7)
			{
				object obj8 = num4 - 1;
				object obj9 = obj8 | -32;
				num4 = obj9 + 1;
			}
			int num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag9 = (nint)num5 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj10 = 0;
			int num6 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rcx_v33+18]");
			bool flag10 = (nint)num6 >= (nint)0;
			List<ItemType> list = new List<ItemType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v19+18]");
			if (num7 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj12 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v19+18]");
				bool flag11 = num8 >= 0;
				_ = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v21+18]");
			if (num9 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj14 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdx_v21+18]");
				bool flag12 = num10 >= 0;
				_ = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v23+18]");
			if (num11 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj16 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v23+18]");
				bool flag13 = num12 >= 0;
				_ = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v25+18]");
			if (num13 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj18 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v25+18]");
				bool flag14 = num14 >= 0;
				_ = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v27+18]");
			if (num15 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj20 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v27+18]");
				bool flag15 = num16 >= 0;
				_ = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v29+18]");
			if (num17 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj22 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdx_v29+18]");
				bool flag16 = num18 >= 0;
				_ = 3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v31+18]");
			if (num19 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj24 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rdx_v31+18]");
				bool flag17 = num20 >= 0;
				_ = 4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v33+18]");
			if (num21 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)5);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj26 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v33+18]");
				bool flag18 = num22 >= 0;
				_ = 5;
			}
			if (isRandomType)
			{
				ItemType itemType = Extensions.PickRnd(list);
				if (itemType != ItemType.COIN)
				{
					if (itemType != ItemType.COINBAG1)
					{
						Pickup pickup = GM.Core.MakePickup(pos, itemType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
						if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
						{
							pickup.GoToPlayer = true;
							pickup.TargetPlayer = _player;
							pickup.Time = 1f;
							Vector2 vector = (Vector2)(250 - CS_0024_003C_003E8__locals22.i);
							pickup._003CSpeed_003Ek__BackingField = (float)vector;
							int i = CS_0024_003C_003E8__locals22.i + 1;
							CS_0024_003C_003E8__locals22.i = i;
							continue;
						}
						goto IL_0a28;
					}
					Action<Pickup> callback = CS_0024_003C_003E8__locals22._003C_003E9__1;
					if (CS_0024_003C_003E8__locals22._003C_003E9__1 == null)
					{
						callback = (CS_0024_003C_003E8__locals22._003C_003E9__1 = delegate(Pickup coin)
						{
							if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
							{
								coin.GoToPlayer = true;
								GoldFingerManager goldFingerManager = CS_0024_003C_003E8__locals22._003C_003E4__this;
								coin._targetPlayer = goldFingerManager._player;
								coin.Time = 1f;
								float num23 = 250f - (float)CS_0024_003C_003E8__locals22.i;
								coin._003CSpeed_003Ek__BackingField = num23;
							}
						});
					}
					GM.Core.MakeRedCoinBag(pos, 0f, callback);
					int i2 = CS_0024_003C_003E8__locals22.i + 1;
					CS_0024_003C_003E8__locals22.i = i2;
					continue;
				}
			}
			Action<Pickup> callback2 = CS_0024_003C_003E8__locals22._003C_003E9__0;
			if (CS_0024_003C_003E8__locals22._003C_003E9__0 == null)
			{
				callback2 = (CS_0024_003C_003E8__locals22._003C_003E9__0 = delegate(Pickup coin)
				{
					if ((object)coin != null && ((UnityEngine.Object)coin).m_CachedPtr != (IntPtr)0)
					{
						coin.GoToPlayer = true;
						GoldFingerManager goldFingerManager = CS_0024_003C_003E8__locals22._003C_003E4__this;
						coin._targetPlayer = goldFingerManager._player;
						coin.Time = 1f;
						float num23 = 250f - (float)CS_0024_003C_003E8__locals22.i;
						coin._003CSpeed_003Ek__BackingField = num23;
					}
				});
			}
			GM.Core.MakeCoin(pos, 0f, callback2);
			goto IL_0a28;
			IL_0a28:
			int i3 = CS_0024_003C_003E8__locals22.i + 1;
			CS_0024_003C_003E8__locals22.i = i3;
		}
	}

	private static float Approach(float start, float end, float shift)
	{
		if (!(end > start))
		{
			float num = start - shift;
			if (num < end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start + shift;
		if (num2 > end)
		{
			num2 = end;
		}
		return num2;
	}

	private unsafe void _003CActivateGoldFinger_003Eb__32_0()
	{
		//IL_0026: Expected O, but got Ref
		//IL_006f: Expected I, but got O
		//IL_00d3: Expected O, but got I4
		//IL_00f3: Expected I4, but got I8
		//IL_0101: Expected O, but got I4
		Transform transform = _totalText.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_logoSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 1000f;
		tweenConfig.angle = (float?)(object)1;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0026: Expected O, but got Ref
			Transform transform2 = _logoSprite.transform;
			object obj3 = default(object);
			transform2.localEulerAngles = (Vector3)(&obj3);
			PhaserSprite phaserSprite = RenderingExtensions.SetScale(_logoSprite, 1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween logoTween = Tweens.Add(tweenConfig);
		_logoTween2 = logoTween;
	}

	private unsafe void _003CActivateGoldFinger_003Eb__32_1()
	{
		//IL_0026: Expected O, but got Ref
		Transform transform = _logoSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_logoSprite, 1f);
	}

	private void _003CGoldenFingerUpdate_003Eb__33_0()
	{
		//IL_002e: Expected O, but got I4
		PhaserSprite phaserSprite = _logoSpriteShadow.setAlpha(0.65f);
		PhaserSprite phaserSprite2 = _logoSpriteShadow.setScale(0f, (float?)(object)0);
	}

	private void _003CGoldenFingerUpdate_003Eb__33_1()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _logoSprite.setScale(1f, (float?)(object)0);
	}

	private void _003CGoldenFingerUpdate_003Eb__33_2()
	{
		//IL_002e: Expected O, but got I4
		PhaserSprite phaserSprite = _logoSpriteShadow.setAlpha(0.65f);
		PhaserSprite phaserSprite2 = _logoSpriteShadow.setScale(0f, (float?)(object)0);
	}

	private void _003CGoldenFingerUpdate_003Eb__33_3()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _logoSprite.setScale(1f, (float?)(object)0);
	}
}
