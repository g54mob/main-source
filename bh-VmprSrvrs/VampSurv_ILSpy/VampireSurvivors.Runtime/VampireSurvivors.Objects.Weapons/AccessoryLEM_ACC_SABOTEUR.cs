using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class AccessoryLEM_ACC_SABOTEUR : AccessoryTP_FREESLOT_FOLLOWER
{
	private sealed class _003C_UpdateFace_003Ed__7(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public AccessoryLEM_ACC_SABOTEUR _003C_003E4__this;

		public PhaserSprite saboteurFace;

		public VampireSurvivors.Objects.Characters.CharacterController owner;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_002e: Expected I4, but got I8
			//IL_0095: Expected I4, but got O
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					_003C_003E4__this.UpdateFace(saboteurFace, owner);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public List<CharacterType> excludedCharacters;

	private PhaserSprite saboteurFace;

	public override bool LevelUp(bool skipFire = false)
	{
		//IL_0010: Expected O, but got I4
		object obj = ((Equipment)this)._003CLevel_003Ek__BackingField + 1;
		float value = (float)obj * 100f;
		GiveCoins(value);
		return base.LevelUp(skipFire);
	}

	protected override void MakeLevelOne()
	{
		//IL_00b5: Expected O, but got I4
		//IL_000a: Expected I, but got O
		bool flag = SpriteLoader.LoadTexture("lem_character_head", "Gameplay", (DlcType?)(object)1);
		MakeLevelOne();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryLEM_ACC_SABOTEUR>)+290]");
		Action action = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.AccessoryLEM_ACC_SABOTEUR>)+290]");
		action._002Ector(this, (IntPtr)0);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete = delegate
		{
			GiveCoins(100f);
		};
		Timer timer2 = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected unsafe void GiveCoins(float value)
	{
		//IL_00e7: Expected I, but got O
		//IL_0064: Expected O, but got Ref
		//IL_008e: Expected O, but got I4
		//IL_00af: Expected F4, but got O
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string value2 = System.Number.FormatSingle(value, "F0", currentInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj = default(object);
		VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		string textureName = default(string);
		core._gizmoManager.DisplayIconOverhead("CoinGold", value2, (Color?)(object)(&obj), characterController, displayTimeMultiplier, vOffset, textureName);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Coin, soundConfig, 0f, 10, (float)characterController);
		GameManager core2 = GM.Core;
		float num3 = core2._playerOptions.AddCoins(value);
	}

	public void AddAnimation_Saboteur()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
		object obj = default(object);
		if (obj == null)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "lem_character_head", "LEM_jimboHead_i01.png");
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(2);
			GameObject gameObject = phaserSprite2.gameObject;
			((UnityEngine.Object)gameObject).SetName("Saboteur");
			saboteurFace = phaserSprite2;
			Transform transform = saboteurFace.transform;
			Transform parent = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			transform.parent = parent;
			UpdateFace(saboteurFace, ((Equipment)this)._003COwner_003Ek__BackingField);
			string animName = "LEM_jimboHead_i01.png".Replace("01.png", "");
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 4, "lem_character_head", num);
			PhaserSprite phaserSprite3 = saboteurFace;
			phaserSprite3._spriteAnimation.CleanAnimations();
			PhaserSprite phaserSprite4 = saboteurFace;
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			phaserSprite4._spriteAnimation.AddAnimation("walk", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			PhaserSprite phaserSprite5 = saboteurFace;
			phaserSprite5._spriteAnimation.SetAnimation("walk");
			_003C_UpdateFace_003Ed__7 obj2 = null;
			obj2._003C_003E1__state = 0;
			obj2._003C_003E4__this = this;
			obj2.saboteurFace = saboteurFace;
			obj2.owner = ((Equipment)this)._003COwner_003Ek__BackingField;
			Coroutine coroutine = saboteurFace.StartCoroutine(obj2);
		}
	}

	private void UpdateFace(PhaserSprite saboteurFace, VampireSurvivors.Objects.Characters.CharacterController owner)
	{
		bool flipX = owner.flipX;
		PhaserSprite phaserSprite = saboteurFace.setFlipX(flipX);
		List<Vector2> headOffsets = owner.GetHeadOffsets();
		if (headOffsets != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v10 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_017b;
			}
		}
		if (owner.flipX)
		{
			goto IL_017b;
		}
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite2 = saboteurFace.setLocalPosition(localPosition);
		int depth;
		if (owner._characterType > CharacterType.TP_DRACULA)
		{
			if (owner._characterType == CharacterType.TP_DEATH_MEGA)
			{
				goto IL_00f9;
			}
			if (owner._characterType != CharacterType.TP_DRACULA_MEGA)
			{
				goto IL_013a;
			}
			depth = 11;
		}
		else
		{
			if (owner._characterType == CharacterType.TP_DEATH)
			{
				goto IL_00f9;
			}
			if (owner._characterType != CharacterType.TP_DRACULA)
			{
				goto IL_013a;
			}
			depth = 11;
		}
		goto IL_01b7;
		IL_017b:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_01b7:
		PhaserSprite phaserSprite3 = saboteurFace.setDepth(depth);
		return;
		IL_00f9:
		depth = 401;
		goto IL_01b7;
		IL_013a:
		int depth2 = owner.depth;
		depth = depth2 + 1;
		goto IL_01b7;
	}

	private IEnumerator _UpdateFace(PhaserSprite saboteurFace, VampireSurvivors.Objects.Characters.CharacterController owner)
	{
		_003C_UpdateFace_003Ed__7 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.saboteurFace = saboteurFace;
		obj.owner = owner;
		return obj;
	}

	public AccessoryLEM_ACC_SABOTEUR()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_02e2: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_030a: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0332: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_035a: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0382: Expected O, but got I
		//IL_0294: Expected O, but got I
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)402);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 402;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)401);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 401;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)403);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 403;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)404);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 404;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)167);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 167;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)169);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 169;
		}
		excludedCharacters = list;
		((Accessory)this)._002Ector();
	}

	private void _003CMakeLevelOne_003Eb__3_0()
	{
		GiveCoins(100f);
	}
}
