using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using I2.Loc;
using Rewired;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors;

public class DraculaCutscene : GameMonoBehaviour
{
	protected enum CutsceneState
	{
		Inactive,
		EnteredPlatformingArea,
		DraculaAndRichterDialogue,
		CoffinSpawned,
		DeathDialogue,
		TransitionToDeathFight,
		CutsceneOver
	}

	public enum DialogueCharacter
	{
		None,
		Richter,
		Dracula,
		Death
	}

	[Serializable]
	public struct TPCutsceneDialogue
	{
		public DialogueCharacter Character;

		public LocalizedString DialogueLocKey;

		private float _003CEnglishShowTime_003Ek__BackingField;

		private int _003CEnglishCharacterCount_003Ek__BackingField;

		public float EnglishShowTime
		{
			get
			{
				return _003CEnglishShowTime_003Ek__BackingField;
			}
			private set
			{
				_003CEnglishShowTime_003Ek__BackingField = value;
			}
		}

		public int EnglishCharacterCount
		{
			get
			{
				return _003CEnglishCharacterCount_003Ek__BackingField;
			}
			private set
			{
				_003CEnglishCharacterCount_003Ek__BackingField = value;
			}
		}

		public void SetEnglishTextValues(float englishShowTime, int englishCharacterCount)
		{
			_003CEnglishShowTime_003Ek__BackingField = englishShowTime;
			_003CEnglishCharacterCount_003Ek__BackingField = englishCharacterCount;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__67_0;

		public static Func<SuperMap, bool> _003C_003E9__67_1;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__76_0;

		public static Func<KeyValuePair<CharacterType, List<CharacterData>>, bool> _003C_003E9__77_0;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__83_0;

		public static Action _003C_003E9__88_0;

		public static TweenCallback _003C_003E9__101_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CStart_003Eb__67_0(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)character != null)
			{
				object obj = character._characterType - 229;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CStart_003Eb__67_1(SuperMap map)
		{
			//IL_00ac: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A35E6]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)map != null)
			{
				GameObject gameObject = map.gameObject;
				if ((object)gameObject != null)
				{
					string name = ((UnityEngine.Object)gameObject).GetName();
					if (name != null)
					{
						return name.Contains("TP_CastleDracula");
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CBeginCutscene_003Eb__76_0(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			//IL_0043: Expected I4, but got O
			if ((object)character != null)
			{
				return (byte)(character._PlayerIndex >> 31) != 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CInitDracula_003Eb__77_0(KeyValuePair<CharacterType, List<CharacterData>> characterData)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			object obj = characterData - 209;
			return obj == null;
		}

		internal bool _003CTweenCharactersToWaitPosition_003Eb__83_0(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)character != null)
			{
				object obj = character._characterType - 229;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal void _003CPlayCutscene_003Eb__88_0()
		{
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		}

		internal void _003CDeathScreenShake_003Eb__101_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass77_0
	{
		public MeleeAttack idleAnim;

		public SpriteAnimation draculaSpriteAnimation;

		internal void _003CInitDracula_003Eb__1(bool _)
		{
			//IL_009c: Expected O, but got I4
			//IL_009c: Expected I4, but got O
			MeleeAttack meleeAttack = idleAnim;
			string animName = meleeAttack._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			MeleeAttack meleeAttack2 = idleAnim;
			Vector2 pivot = default(Vector2);
			string text = default(string);
			int num = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, meleeAttack2._003CframesNumber_003Ek__BackingField, pivot, text, num, flag);
			MeleeAttack meleeAttack3 = idleAnim;
			bool autoSetAnimation = default(bool);
			draculaSpriteAnimation.AddAnimation("idle", animationFrames, meleeAttack3._003CframeRate_003Ek__BackingField, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			draculaSpriteAnimation.SetAnimation("idle");
		}
	}

	private sealed class _003C_003Ec__DisplayClass79_0
	{
		public SpriteAnimation directerSpriteAnimation;

		public Action onSnap;

		internal void _003CPlayDirecterSnap_003Eb__0()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			directerSpriteAnimation.SetAnimation("snap");
			Action action = onSnap;
			if (onSnap != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v83.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass83_0
	{
		public int characterTweensCompleted;

		public int positionIndex;

		public TweenCallback _003C_003E9__3;

		internal void _003CTweenCharactersToWaitPosition_003Eb__1()
		{
			int num = characterTweensCompleted + 1;
			characterTweensCompleted = num;
		}

		internal void _003CTweenCharactersToWaitPosition_003Eb__3()
		{
			int num = characterTweensCompleted + 1;
			characterTweensCompleted = num;
		}

		internal bool _003CTweenCharactersToWaitPosition_003Eb__2()
		{
			//IL_0011: Expected O, but got I4
			object obj = characterTweensCompleted - positionIndex;
			return obj == null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass84_0
	{
		public VampireSurvivors.Objects.Characters.CharacterController character;

		internal void _003CAddMoveToPositionTween_003Eb__0()
		{
			ArcadeSprite arcadeSprite = character.setFlipX(flipX: true);
		}
	}

	private sealed class _003C_003Ec__DisplayClass88_0
	{
		public bool snapped;

		public DraculaCutscene _003C_003E4__this;

		internal void _003CPlayCutscene_003Eb__1()
		{
			snapped = true;
		}

		internal bool _003CPlayCutscene_003Eb__2()
		{
			return snapped;
		}

		internal void _003CPlayCutscene_003Eb__3()
		{
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			GameObject gameObject = draculaCutscene._DraculaSprite.gameObject;
			gameObject.SetActive(value: false);
		}

		internal bool _003CPlayCutscene_003Eb__4()
		{
			//IL_0041: Expected I4, but got O
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				return draculaCutscene._coffinSpawnTeleportComplete;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass98_0
	{
		public Enemy_TP_Death death;

		internal void _003CPlayDeathScream_003Eb__0()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A35EC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Enemy_TP_Death enemy_TP_Death = death;
			((EnemyController)enemy_TP_Death)._SpriteAnimation.SetAnimation("CloseMouth");
		}
	}

	private sealed class _003CCameraZoom_003Ed__80(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float startSize;

		public float endSize;

		public float duration;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0011: Expected F4, but got I4
			//IL_0047: Expected I4, but got I8
			//IL_00a8: Invalid comparison between I4 and F4
			//IL_00f3: Expected F4, but got I4
			//IL_0166: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003Ctimer_003E5__2 = _003C_003E1__state;
			}
			else if (_003C_003E1__state != 1)
			{
				goto IL_0152;
			}
			_003C_003E1__state = -1;
			if (duration > _003Ctimer_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num = (_003Ctimer_003E5__2 = deltaTime + _003Ctimer_003E5__2) / duration;
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				float num2 = endSize - startSize;
				float num3 = num2 * num;
				float newSize = num3 + startSize;
				ProCamera2D instance = ProCamera2D.Instance;
				if ((object)instance != null)
				{
					instance.UpdateScreenSize(newSize);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_0152;
			IL_0152:
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

	private sealed class _003CPlayCutscene_003Ed__88(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene _003C_003E4__this;

		private _003C_003Ec__DisplayClass88_0 _003C_003E8__1;

		private int _003Cindex_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0012: Expected O, but got I8
			//IL_002c: Expected O, but got I8
			while (true)
			{
				int num = _003C_003E1__state;
				if (_003C_003E1__state > 8)
				{
					break;
				}
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r15_v2+6DC0EE4+v38 @ rax_v2 (System.Int32)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ rcx_v3 (should have been resolved before IL gen)");
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

	private sealed class _003CPlayDeathDialogueCutscene_003Ed__90(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene _003C_003E4__this;

		private Enemy_TP_Death _003CdeathEnemy_003E5__2;

		private int _003Cindex_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_061a: Expected I4, but got I8
			//IL_0026: Expected O, but got I4
			//IL_0127: Expected I4, but got I8
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_00f4: Expected I4, but got I8
			//IL_0966: Expected O, but got Ref
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_0661: Expected O, but got Ref
			//IL_00c1: Expected I4, but got I8
			//IL_078f: Expected O, but got I
			//IL_082b: Expected F4, but got I4
			//IL_085d: Expected F4, but got I4
			//IL_00a4: Expected I4, but got I8
			//IL_07f8: Expected O, but got I8
			//IL_025b: Expected I, but got O
			//IL_0269: Expected I, but got O
			//IL_0279: Expected O, but got I
			//IL_02f9: Expected O, but got I4
			//IL_024e: Expected I, but got O
			//IL_0578: Expected O, but got I4
			//IL_0582: Unknown result type (might be due to invalid IL or missing references)
			//IL_0587: Expected O, but got Unknown
			//IL_02b5: Expected O, but got I
			//IL_05b7: Expected O, but got Ref
			//IL_02eb: Expected O, but got I4
			//IL_0426: Expected I, but got O
			//IL_0354: Expected I4, but got O
			//IL_04a4: Expected O, but got I4
			//IL_04b2: Expected O, but got I4
			//IL_04c0: Expected O, but got I4
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			BackgroundTP_Basic backgroundTP_Basic;
			Stage stage;
			BackgroundTP_Basic backgroundTP_Basic2;
			object obj4;
			bool result;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					if (draculaCutscene._mapToken != null)
					{
						GameManager core = GM.Core;
						bool flag2 = ((List<object>)(object)core._mapTokens).Remove((object)draculaCutscene._mapToken);
						draculaCutscene._mapToken = null;
						backgroundTP_Basic = null;
					}
					else
					{
						backgroundTP_Basic = null;
					}
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
					float2 float5 = _003C_003E4__this.ConvertLocalV3ToWorldFloat2((Vector3)(&enumerator));
					GameManager core2 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					Enemy_TP_Death enemy_TP_Death = default(Enemy_TP_Death);
					_003CdeathEnemy_003E5__2 = enemy_TP_Death;
					bool flag3 = _003CdeathEnemy_003E5__2 != null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					object message = default(object);
					Debug.Log(message);
					GameManager core3 = GM.Core;
					stage = core3._stage;
					BackgroundTP_Basic fancyBg = (BackgroundTP_Basic)stage._fancyBg;
					nint num;
					if ((object)stage._fancyBg == null)
					{
						backgroundTP_Basic2 = backgroundTP_Basic;
						num = unchecked((nint)null);
						goto IL_09a2;
					}
					num = (nint)fancyBg;
					nint num2 = (nint)typeof(BackgroundTP_Basic);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1802 @ r8_v43 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1802 @ r8_v43 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1858 @ rax_v123+FFFFFFF8+v1803 @ rax_v119*8]");
						if (0 == (nint)typeof(BackgroundTP_Basic))
						{
							obj4 = 1;
							goto IL_097d;
						}
					}
					obj4 = 0;
					goto IL_097d;
				}
				object obj5 = obj - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					int num4 = _003Cindex_003E5__3 + 1;
					_003Cindex_003E5__3 = num4;
					goto IL_0945;
				}
				object obj6 = obj5 - 1;
				if (!flag)
				{
					bool flag4 = (nint)obj6 != 1;
					result = false;
					if (!flag4)
					{
						_003C_003E1__state = -1;
						result = false;
					}
					goto IL_0905;
				}
				_003C_003E1__state = -1;
				_003CTransitionToDeathFight_003Ed__91 obj7 = null;
				obj7._003C_003E1__state = 0;
				obj7._003C_003E4__this = _003C_003E4__this;
				obj7.deathEnemy = _003CdeathEnemy_003E5__2;
				_003C_003E2__current = obj7;
				_003C_003E1__state = 4;
			}
			else
			{
				_003C_003E1__state = -1;
				_003C_003E4__this.DisableAllInput();
				draculaCutscene._currentCutsceneState = CutsceneState.DeathDialogue;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characterControllers = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)draculaCutscene._characterControllers;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator2.MoveNext())
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = null;
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator2);
					throw new NullReferenceException();
				}
				GameObject gameObject = draculaCutscene._cutsceneDialogueUI.gameObject;
				gameObject.SetActive(value: true);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				bool flag5 = (nint)0 != 0;
				GameObject gameObject2 = gameObject;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj8 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
					gameObject2 = (GameObject)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1719 @ rax_v35 (should have been resolved before IL gen)");
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 0f, 10, 0f, volume, rate, detune, loop, 1f);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 0f, 10, 0f, volume, rate, detune, loop, 1f);
				_003C_003E4__this.DeathScreenShake(draculaCutscene._ScreenShakeRepeats);
				IEnumerator enumerator4 = draculaCutscene._cutsceneDialogueUI.Show();
				_003C_003E2__current = enumerator4;
				_003C_003E1__state = 1;
			}
			goto IL_09de;
			IL_097d:
			bool flag6 = obj4 == null;
			backgroundTP_Basic2 = backgroundTP_Basic;
			if (!flag6)
			{
				backgroundTP_Basic2 = (BackgroundTP_Basic)stage._fancyBg;
			}
			goto IL_09a2;
			IL_09de:
			result = true;
			goto IL_0905;
			IL_09a2:
			if ((object)backgroundTP_Basic2 != null && ((UnityEngine.Object)backgroundTP_Basic2).m_CachedPtr != (IntPtr)0)
			{
				backgroundTP_Basic2.SpawnDeathFightTile();
			}
			_003Cindex_003E5__3 = (int)backgroundTP_Basic;
			goto IL_0945;
			IL_0905:
			return result;
			IL_0945:
			TPCutsceneDialogue[] afterCoffinCutsceneDialogue = draculaCutscene._AfterCoffinCutsceneDialogue;
			if (_003Cindex_003E5__3 < afterCoffinCutsceneDialogue.Length)
			{
				if (_003Cindex_003E5__3 == 3)
				{
					_003C_003E4__this.RemoveBackground();
					if (draculaCutscene._draculaCoffin != null)
					{
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if ((object)draculaCutscene._draculaCoffin != null)
						{
							nint num5 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj9 = default(object);
							if (obj9 == null)
							{
								ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
								throw ex2;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						tweenConfig.targets = array;
						Camera main = Camera.main;
						Transform transform = main.transform;
						Vector3 position = transform.position;
						tweenConfig.y = (float?)(object)1;
						tweenConfig.scale = (float?)(object)1;
						tweenConfig.angle = (float?)(object)1;
						tweenConfig.duration = 1000f;
						tweenConfig.delay = 500f;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
					}
					IEnumerator routine = _003C_003E4__this.RevealDeath();
					Coroutine cameraZoomCoroutine = _003C_003E4__this.StartCoroutine(routine);
					draculaCutscene._cameraZoomCoroutine = cameraZoomCoroutine;
				}
				TPCutsceneDialogue[] afterCoffinCutsceneDialogue2 = draculaCutscene._AfterCoffinCutsceneDialogue;
				if (_003Cindex_003E5__3 >= afterCoffinCutsceneDialogue2.Length)
				{
					throw new IndexOutOfRangeException();
				}
				object obj10 = afterCoffinCutsceneDialogue2.Length - 1;
				object obj11 = _003Cindex_003E5__3 - obj10;
				bool hidePortraitAtEnd = obj11 == null;
				TPCutsceneDialogue tPCutsceneDialogue = default(TPCutsceneDialogue);
				IEnumerator enumerator5 = draculaCutscene._cutsceneDialogueUI.PlayDialogue((TPCutsceneDialogue)(&tPCutsceneDialogue), hidePortraitAtEnd, SfxType.TP_sfx_Death);
				_003C_003E2__current = enumerator5;
				_003C_003E1__state = 2;
			}
			else
			{
				IEnumerator enumerator6 = draculaCutscene._cutsceneDialogueUI.HideDialoguePanelOnDialogueFinished();
				_003C_003E2__current = enumerator6;
				_003C_003E1__state = 3;
			}
			goto IL_09de;
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

	private sealed class _003CPlayDeathScream_003Ed__98(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Enemy_TP_Death death;

		public DraculaCutscene _003C_003E4__this;

		private _003C_003Ec__DisplayClass98_0 _003C_003E8__1;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_014d: Expected I4, but got I8
			//IL_0260: Expected I4, but got I8
			//IL_0264: Expected O, but got I4
			//IL_0074: Expected F4, but got I4
			//IL_01d3: Expected I4, but got I8
			//IL_01d7: Expected O, but got I4
			//IL_0205: Expected F4, but got I4
			//IL_00eb: Expected I4, but got F4
			//IL_00eb: Expected O, but got F4
			//IL_00eb: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003Ec__DisplayClass98_0 obj = new _003C_003Ec__DisplayClass98_0();
				_003C_003E8__1 = obj;
				_003C_003Ec__DisplayClass98_0 obj2 = _003C_003E8__1;
				obj2.death = death;
				object obj3 = UnityEngine.Random.RandomRangeInt(-200, 200);
				float? num = default(float?);
				float num2 = default(float);
				float num3 = default(float);
				bool flag = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Deathscream, 0f, 10, 0f, num, num2, num3, flag, 1f);
				object obj4 = UnityEngine.Random.RandomRangeInt(-200, 200);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.sfx_death_4, 0f, 10, 0f, num, num2, num3, flag, 1f);
				_003C_003Ec__DisplayClass98_0 obj5 = _003C_003E8__1;
				Enemy_TP_Death enemy_TP_Death = obj5.death;
				((EnemyController)enemy_TP_Death)._SpriteAnimation.SetAnimation("ScreamLoop");
				Action onComplete = delegate
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A35EC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Enemy_TP_Death enemy_TP_Death3 = _003C_003E8__1.death;
					((EnemyController)enemy_TP_Death3)._SpriteAnimation.SetAnimation("CloseMouth");
				};
				Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
				_003CWaitForSecondsPausable_003Ed__100 obj6 = null;
				obj6._003C_003E1__state = 0;
				obj6.seconds = 1.4f;
				_003C_003E2__current = obj6;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003Ec__DisplayClass98_0 obj7 = _003C_003E8__1;
				_003C_003E1__state = -1;
				Enemy_TP_Death enemy_TP_Death2 = obj7.death;
				((EnemyController)enemy_TP_Death2)._SpriteAnimation.SetAnimation("Idle");
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

	private sealed class _003CRevealDeath_003Ed__81(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0184: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_011e: Expected I4, but got I8
			//IL_01e1: Expected I4, but got O
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_008c: Expected I4, but got I8
			//IL_0077: Expected I4, but got I8
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			bool result;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						bool flag2 = (nint)obj2 != 1;
						result = false;
						if (!flag2)
						{
							_003C_003E1__state = -1;
							return false;
						}
						goto IL_020a;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.MakeAllBackgroundsInvisible();
						float cameraZoomScreenSize = _003C_003E4__this.CameraZoomScreenSize;
						IEnumerator enumerator = _003C_003E4__this.CameraZoom(cameraZoomScreenSize, draculaCutscene._preZoomCameraSize, draculaCutscene._CameraZoomOutDuration);
						_003C_003E2__current = enumerator;
						_003C_003E1__state = 3;
						return true;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						IEnumerator enumerator2 = _003C_003E4__this.WaitForSecondsPausable(draculaCutscene._BackgroundTileLerpOutDuration);
						_003C_003E2__current = enumerator2;
						_003C_003E1__state = 2;
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			_003C_003E1__state = -1;
			Func<bool> predicate = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180005010");
			WaitUntil waitUntil = new WaitUntil(predicate);
			_003C_003E2__current = waitUntil;
			_003C_003E1__state = 1;
			result = true;
			goto IL_020a;
			IL_020a:
			return result;
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

	private sealed class _003CScaleOutTile_003Ed__96(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene _003C_003E4__this;

		public Vector3Int cellPosition;

		public int relativeXCoordinate;

		public int relativeYCoordinate;

		public Vector3 cameraPosition;

		private Quaternion _003CendRotation_003E5__2;

		private float _003Ct_003E5__3;

		private Vector3 _003CtoCentrePosition_003E5__4;

		private Vector3 _003CstartOffset_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			//IL_028e: Expected I4, but got I8
			//IL_0065: Expected O, but got I4
			//IL_00d5: Expected I4, but got I8
			//IL_00a2: Expected I4, but got I8
			//IL_04e6: Expected O, but got I4
			//IL_04f7: Expected O, but got I4
			//IL_056a: Expected I, but got O
			//IL_0179: Invalid comparison between I4 and F4
			//IL_039f: Invalid comparison between I4 and F4
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Expected O, but got Unknown
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Expected O, but got Unknown
			//IL_03ec: Expected F4, but got Ref
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Expected O, but got Unknown
			//IL_0205: Expected O, but got I
			//IL_0466: Unknown result type (might be due to invalid IL or missing references)
			//IL_046b: Expected O, but got Unknown
			//IL_02ff->IL0557: Incompatible stack heights: 1 vs 0
			//IL_0597->IL0320: Incompatible stack heights: 1 vs 0
			//IL_0228->IL0557: Incompatible stack heights: 2 vs 0
			object obj2 = default(object);
			object obj = obj2 - 120;
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			Vector3 ret = default(Vector3);
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						goto IL_030b;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null)
					{
						goto IL_0320;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					_003Ct_003E5__3 = 0f;
					if ((object)_003C_003E4__this != null)
					{
						Tilemap backgroundTilemap = draculaCutscene._backgroundTilemap;
						if ((object)draculaCutscene._backgroundTilemap != null)
						{
							bool flag2 = ((UnityEngine.Object)backgroundTilemap).m_CachedPtr == (IntPtr)0;
							Vector3Int vector3Int = default(Vector3Int);
							GridLayout.CellToWorld_Injected(((UnityEngine.Object)backgroundTilemap).m_CachedPtr, ref vector3Int, out ret);
							Vector3 vector = default(Vector3);
							_003CtoCentrePosition_003E5__4 = vector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.DraculaCutscene+<ScaleOutTile>d__96)+44]");
							_ = 0;
							nint num = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ rax_v90 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num2 = 0;
							_003CstartOffset_003E5__5 = Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rcx_v74 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							_ = 0;
							goto IL_0320;
						}
					}
				}
				throw new NullReferenceException();
			}
			_003C_003E1__state = -1;
			Vector3Int position = default(Vector3Int);
			Quaternion ret2;
			if ((object)_003C_003E4__this != null)
			{
				DraculaCutscene backgroundTilemap2 = (DraculaCutscene)(object)draculaCutscene._backgroundTilemap;
				if ((object)draculaCutscene._backgroundTilemap != null)
				{
					bool flag3 = ((UnityEngine.Object)backgroundTilemap2).m_CachedPtr == (IntPtr)0;
					Tilemap.SetTileFlags_Injected(((UnityEngine.Object)backgroundTilemap2).m_CachedPtr, ref position, TileFlags.None);
					float num3 = UnityEngine.Random.Range(0f, 0.1f);
					object obj4 = relativeXCoordinate * relativeXCoordinate;
					object obj5 = relativeYCoordinate * relativeYCoordinate;
					object obj6 = obj4 + obj5;
					float num4 = (float)obj6 * 0.05f;
					float seconds = num3 + num4;
					float num5 = UnityEngine.Random.Range(-30f, 30f);
					Vector3 euler = default(Vector3);
					Quaternion.Internal_FromEulerRad_Injected(ref euler, out ret2);
					_003CendRotation_003E5__2 = ret2;
					_003CWaitForSecondsPausable_003Ed__100 obj7 = null;
					obj7.seconds = seconds;
					obj7._003C_003E1__state = 0;
					_003C_003E2__current = obj7;
					_003C_003E1__state = 1;
					return true;
				}
			}
			throw new NullReferenceException();
			IL_0320:
			if (draculaCutscene._BackgroundTileLerpOutDuration > _003Ct_003E5__3)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num6 = (_003Ct_003E5__3 = deltaTime + _003Ct_003E5__3) / draculaCutscene._BackgroundTileLerpOutDuration;
				if (0f > num6 || !(num6 > 1f))
				{
				}
				if (0f > num6 || !(num6 > 1f))
				{
				}
				_ = _003CendRotation_003E5__2;
				_ = Quaternion.identityQuaternion;
				object obj8 = obj - 96;
				object obj9 = obj - 80;
				Quaternion.Lerp_Injected(ref *(Quaternion*)obj9, ref *(Quaternion*)obj8, (float)(nint)(&ret), out ret2);
				_ = 0;
				_ = 0;
				object obj10 = obj - 64;
				Vector3 s = default(Vector3);
				Matrix4x4.TRS_Injected(ref ret, ref *(Quaternion*)obj10, ref s, out Matrix4x4 _);
				DraculaCutscene backgroundTilemap3 = (DraculaCutscene)(object)draculaCutscene._backgroundTilemap;
				bool flag4 = (object)draculaCutscene._backgroundTilemap == null;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-80]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbp_v1-70]");
				obj = 0;
				bool flag5 = ((UnityEngine.Object)backgroundTilemap3).m_CachedPtr == (IntPtr)0;
				object obj11 = obj - 48;
				Tilemap.SetTransformMatrix_Injected(((UnityEngine.Object)backgroundTilemap3).m_CachedPtr, ref position, ref *(Matrix4x4*)obj11);
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			if (relativeXCoordinate == 4 && relativeYCoordinate == 4)
			{
				draculaCutscene._backgroundRemoveComplete = true;
			}
			goto IL_030b;
			IL_030b:
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

	private sealed class _003CTransitionToDeathFight_003Ed__91(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene _003C_003E4__this;

		public Enemy_TP_Death deathEnemy;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00a7: Expected I4, but got I8
			//IL_059f: Expected I4, but got O
			//IL_01d7: Expected I, but got O
			//IL_01df: Expected I, but got O
			//IL_01ef: Expected O, but got I
			//IL_026f: Expected O, but got I4
			//IL_022b: Expected O, but got I
			//IL_0261: Expected O, but got I4
			//IL_0420: Expected O, but got I4
			//IL_067e: Expected O, but got I4
			//IL_068c: Expected O, but got I4
			//IL_069a: Expected O, but got I4
			//IL_06a8: Expected O, but got I4
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			Stage stage;
			BackgroundTP_Basic backgroundTP_Basic;
			object obj3;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					draculaCutscene._currentCutsceneState = CutsceneState.TransitionToDeathFight;
					IEnumerator enumerator = _003C_003E4__this.PlayDeathScream(deathEnemy);
					_003C_003E2__current = enumerator;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_05cb;
				}
				_003C_003E1__state = -1;
				ProCamera2D instance = ProCamera2D.Instance;
				if ((object)instance != null)
				{
					instance.RemoveAllCameraTargets(1f);
					if ((object)GM.Core != null)
					{
						GM.Core.AddAllPlayersAsCameraTargets(0.5f);
						if ((object)_003C_003E4__this != null)
						{
							_003C_003E4__this.RemoveWalls();
							GameManager core = GM.Core;
							if ((object)GM.Core != null)
							{
								stage = core._stage;
								if ((object)core._stage != null)
								{
									BackgroundTP_Basic fancyBg = (BackgroundTP_Basic)stage._fancyBg;
									if ((object)stage._fancyBg == null)
									{
										backgroundTP_Basic = null;
										goto IL_05fd;
									}
									nint num = (nint)typeof(BackgroundTP_Basic);
									nint num2 = (nint)fancyBg;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
									if (num3 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+C8]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v61+FFFFFFF8+v460 @ rax_v57*8]");
										if (0 == (nint)typeof(BackgroundTP_Basic))
										{
											obj3 = 1;
											goto IL_05d6;
										}
									}
									obj3 = 0;
									goto IL_05d6;
								}
							}
						}
					}
				}
			}
			goto IL_0591;
			IL_05fd:
			if ((object)backgroundTP_Basic == null || ((UnityEngine.Object)backgroundTP_Basic).m_CachedPtr == (IntPtr)0)
			{
				goto IL_03eb;
			}
			backgroundTP_Basic.ExitPlatformingZone();
			backgroundTP_Basic._polygonGroups = null;
			List<TPSoftBound> softBounds = backgroundTP_Basic._softBounds;
			if (backgroundTP_Basic._softBounds != null)
			{
				int version = softBounds._version + 1;
				softBounds._version = version;
				softBounds._size = 0;
				if (softBounds._size > 0)
				{
					Array.Clear(softBounds._items, 0, softBounds._size);
				}
				List<TPSoftBound> awakeSoftBounds = backgroundTP_Basic._awakeSoftBounds;
				if (backgroundTP_Basic._awakeSoftBounds != null)
				{
					int version2 = awakeSoftBounds._version + 1;
					awakeSoftBounds._version = version2;
					awakeSoftBounds._size = 0;
					if (awakeSoftBounds._size > 0)
					{
						Array.Clear(awakeSoftBounds._items, 0, awakeSoftBounds._size);
					}
					goto IL_03eb;
				}
			}
			goto IL_0591;
			IL_03eb:
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				core2._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
				_ = 0;
				_003C_003E4__this.EnableAllInput();
				_003C_003E4__this.EnableMovementAfterCutscene();
				if ((object)GM.Core != null)
				{
					GM.Core.SetAllPlayersWeaponsActive(active: true);
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null)
					{
						core3._003CCanPause_003Ek__BackingField = true;
						draculaCutscene._currentCutsceneState = CutsceneState.CutsceneOver;
						if ((object)deathEnemy != null)
						{
							deathEnemy.StartSequence();
							ThosePeopleLoader.UnloadCutsceneSfx();
							if ((object)draculaCutscene._cutsceneDialogueUI != null)
							{
								GameObject gameObject = draculaCutscene._cutsceneDialogueUI.gameObject;
								if ((object)gameObject != null)
								{
									gameObject.SetActive(value: false);
									PlatformZoneMovement platformZoneMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
									if ((object)PlatformZoneMovement._003CInstance_003Ek__BackingField != null)
									{
										if (platformZoneMovement._limitCameraPosition)
										{
											platformZoneMovement._blendAfterCameraLimitsDisabled = true;
										}
										platformZoneMovement.MinCameraX = (float?)(object)0;
										platformZoneMovement.MinCameraY = (float?)(object)0;
										platformZoneMovement.MaxCameraX = (float?)(object)0;
										platformZoneMovement.MaxCameraY = (float?)(object)0;
										platformZoneMovement._limitCameraPosition = false;
										PlatformZoneMovement platformZoneMovement2 = PlatformZoneMovement._003CInstance_003Ek__BackingField;
										if ((object)PlatformZoneMovement._003CInstance_003Ek__BackingField != null)
										{
											platformZoneMovement2._003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField = false;
											goto IL_05cb;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0591;
			IL_0591:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_05cb:
			return false;
			IL_05d6:
			bool flag = obj3 == null;
			backgroundTP_Basic = null;
			if (!flag)
			{
				backgroundTP_Basic = (BackgroundTP_Basic)stage._fancyBg;
			}
			goto IL_05fd;
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

	private sealed class _003CTweenCharactersToWaitPosition_003Ed__83(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0300: Expected I4, but got I8
			//IL_044b: Expected I4, but got O
			//IL_0142: Expected I4, but got O
			//IL_034f: Expected O, but got I4
			//IL_0357: Expected O, but got Ref
			//IL_04a1: Expected I, but got O
			//IL_04b7: Expected O, but got I
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00cb: Expected O, but got I8
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_05e4: Expected O, but got I4
			//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f9: Expected O, but got Unknown
			//IL_0184: Expected O, but got Ref
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003Ec__DisplayClass83_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass83_0();
				if (CS_0024_003C_003E8__locals8 != null)
				{
					CS_0024_003C_003E8__locals8.characterTweensCompleted = 0;
					if ((object)_003C_003E4__this != null)
					{
						float num = draculaCutscene._SpreadPerPlayerInCoOp * 0.5f;
						CS_0024_003C_003E8__locals8.positionIndex = 0;
						Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = _003C_003Ec._003C_003E9__83_0;
						if (_003C_003Ec._003C_003E9__83_0 == null)
						{
							Func<VampireSurvivors.Objects.Characters.CharacterController, bool> func = (_003C_003Ec._003C_003E9__83_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController characterController2)
							{
								//IL_0052: Expected I4, but got O
								//IL_0030: Expected O, but got I4
								if ((object)characterController2 == null)
								{
									NullReferenceException ex2 = new NullReferenceException();
									return (byte)(int)ex2 != 0;
								}
								object obj10 = characterController2._characterType - 229;
								return obj10 == null;
							});
							nint num2 = (nint)typeof(_003C_003Ec);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ rax_v78 (Il2CppClass<VampireSurvivors.DraculaCutscene+<>c>)+B8]");
							object obj = (nint)0 + (nint)40;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag = (nint)0 == 0;
							predicate = func;
							if (!flag)
							{
								object obj2 = obj >> 12;
								object obj3 = obj2 & 0x1FFFFF;
								object obj4 = obj3 >> 6;
								object obj5 = 6603577472L;
								object obj6 = obj3 & 0x3F;
								nint num4;
								do
								{
									object obj7 = 1 << (int)obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ r14_v12+462E0+v608 @ rdx_v37*8]");
									object obj8 = 0 | obj7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ r14_v12+462E0+v608 @ rdx_v37*8]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ r14_v12+462E0+v608 @ rdx_v37*8]");
									if (num3 == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ r14_v12+462E0+v608 @ rdx_v37*8]");
									num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ r14_v12+462E0+v608 @ rdx_v37*8]");
								}
								while (num4 != 0);
								predicate = func;
							}
						}
						object character = Enumerable.FirstOrDefault(draculaCutscene._characterControllers, (Func<object, bool>)predicate);
						TweenCallback tweenCallback = delegate
						{
							int characterTweensCompleted = CS_0024_003C_003E8__locals8.characterTweensCompleted + 1;
							CS_0024_003C_003E8__locals8.characterTweensCompleted = characterTweensCompleted;
						};
						TweenCallback onComplete = default(TweenCallback);
						_003C_003E4__this.AddMoveToPositionTween((VampireSurvivors.Objects.Characters.CharacterController)character, num, CS_0024_003C_003E8__locals8.positionIndex, onComplete);
						int positionIndex = CS_0024_003C_003E8__locals8.positionIndex + 1;
						CS_0024_003C_003E8__locals8.positionIndex = positionIndex;
						int num5 = (int)draculaCutscene._characterControllers;
						if (draculaCutscene._characterControllers != null)
						{
							float num6 = num;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController = null;
								List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							Func<bool> predicate2 = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180005010");
							WaitUntil waitUntil = null;
							waitUntil.m_MaxExecutionTime = -1.0;
							waitUntil.m_Predicate = predicate2;
							_003C_003E2__current = waitUntil;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
				goto IL_043d;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null || draculaCutscene._characterControllers == null)
				{
					goto IL_043d;
				}
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator3.MoveNext())
				{
					object obj9 = 0;
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator3);
					throw new NullReferenceException();
				}
			}
			return false;
			IL_043d:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	private sealed class _003CWaitForSecondsPausable_003Ed__100(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float seconds;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_002e: Expected F4, but got I4
			//IL_0064: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003Ctimer_003E5__2 = _003C_003E1__state;
			}
			else if (_003C_003E1__state != 1)
			{
				goto IL_00c8;
			}
			_003C_003E1__state = -1;
			if (seconds > _003Ctimer_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime + _003Ctimer_003E5__2;
				_003C_003E2__current = null;
				_003Ctimer_003E5__2 = num;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_00c8;
			IL_00c8:
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

	protected TPCutsceneDialogueUI _CutsceneDialogueUIPrefab;

	protected ArcadeSprite _DraculaSprite;

	private Vector2 _DebugTeleportPosition;

	private Vector2 _WaitPosition;

	private float _SpreadPerPlayerInCoOp;

	private int _CharacterWalkTimeInMilliseconds;

	protected Vector2 _DeathSpawnPosition;

	private Transform _CameraTargetTransform;

	private float _CameraTransitionDuration;

	private bool _DoCameraZoom;

	private float _CameraZoomScreenSize;

	private float _CameraZoomScreenSizePortrait;

	private float _CameraZoomInDuration;

	private float _CameraZoomOutDuration;

	protected TPCutsceneDialogue[] _CutsceneDialogue;

	protected TPCutsceneDialogue[] _AfterCoffinCutsceneDialogue;

	protected DraculaCutsceneWineGlass _WineGlass;

	private Vector2 _ThrowStartPosition;

	private Vector2 _ThrowEndPosition;

	private int _ThrowWineGlassDialogueIndex;

	private float _ThrowWineGlassDelay;

	private DraculaCutsceneTeleport _TeleportEffect;

	private ArcadeSprite _DirecterHand;

	private Vector2 _CoffinPosition;

	private float _DelayBeforePlayingDirecterSnap;

	private float _BackgroundTileLerpOutDuration;

	private float _ScreenShakeMagnitude;

	private float _ScreenShakeDuration;

	protected int _ScreenShakeRepeats;

	private bool _showLetterBox;

	protected Player _player;

	protected TPCutsceneDialogueUI _cutsceneDialogueUI;

	protected List<VampireSurvivors.Objects.Characters.CharacterController> _characterControllers;

	protected Tilemap _backgroundTilemap;

	private Coroutine _cutsceneCoroutine;

	protected Coroutine _cameraZoomCoroutine;

	private Rectangle _platformingArea;

	private Rectangle _cutsceneArea;

	private Rect? _originalHardBounds;

	private Rectangle _platformingHardBounds;

	private Rectangle _cutsceneHardBounds;

	private Rectangle _cutsceneCameraLimits;

	private float _preZoomCameraSize;

	protected bool _isAnyCharacterRichter;

	private bool _coffinSpawnTeleportComplete;

	private bool _backgroundRemoveComplete;

	protected CutsceneState _currentCutsceneState;

	protected MapToken _mapToken;

	private bool _deathCutsceneTriggered;

	protected PickupCoffin _draculaCoffin;

	private const string WalkAnimName = "walk";

	protected const string MeleeAnimName = "meleeA";

	protected CoherenceSync _sync;

	private bool _changingState;

	private const string PlatformingAreaBoundsName = "CutscenePlatformingZone";

	private const string CutsceneAreaBoundsName = "Cutscene";

	private const string CutsceneCameraLimitsName = "CutsceneCameraLimits";

	private const string DraculaIdleAnimationName = "idle";

	private const string EnemiesMTextureName = "enemiesM";

	private const string HandSnapAnimPrefix = "hand_snap_";

	private const string SnapDoAnimName = "snap";

	private const string SnapStartAnimName = "snap_start";

	private float CameraZoomScreenSize
	{
		get
		{
			if (UIHelper.IsPortrait)
			{
				return _CameraZoomScreenSizePortrait;
			}
			return _CameraZoomScreenSize;
		}
	}

	protected unsafe virtual void Start()
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Ref, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Ref, but got Unknown
		//IL_02c2: Expected F4, but got O
		CoherenceSync componentInParent = GetComponentInParent<CoherenceSync>();
		_sync = componentInParent;
		GameManager core = GM.Core;
		Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = _003C_003Ec._003C_003E9__67_0;
		if (_003C_003Ec._003C_003E9__67_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__67_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController character)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)character == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj = character._characterType - 229;
				return obj == null;
			});
		}
		if (Enumerable.Any(core._mainCharacters, predicate))
		{
			InitDracula();
			InitDirecterHand();
			_WineGlass.InitWineGlass();
			_isAnyCharacterRichter = true;
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(0);
			_player = player;
			GameManager core2 = GM.Core;
			Transform transform = core2._003CMainUI_003Ek__BackingField.transform;
			Transform parent = transform.parent;
			TPCutsceneDialogueUI cutsceneDialogueUI = UnityEngine.Object.Instantiate(_CutsceneDialogueUIPrefab, parent);
			_cutsceneDialogueUI = cutsceneDialogueUI;
			GameManager core3 = GM.Core;
			Transform transform2 = core3._003CMainUI_003Ek__BackingField.transform;
			int siblingIndex = transform2.GetSiblingIndex();
			Transform transform3 = _cutsceneDialogueUI.transform;
			int siblingIndex2 = siblingIndex + 1;
			transform3.SetSiblingIndex(siblingIndex2);
			GameObject gameObject = _cutsceneDialogueUI.gameObject;
			gameObject.SetActive(value: false);
			_cutsceneDialogueUI.InitDialogue(ref *(TPCutsceneDialogue[]*)(this + 120));
			_cutsceneDialogueUI.InitDialogue(ref *(TPCutsceneDialogue[]*)(this + 128));
			SetupCutsceneAreas();
			GameManager core4 = GM.Core;
			Stage stage = core4._stage;
			TilingTileset tilingTileset = stage._tilingTileset;
			Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__67_1;
			if (_003C_003Ec._003C_003E9__67_1 == null)
			{
				predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__67_1 = delegate(SuperMap superMap)
				{
					//IL_00ac: Expected I4, but got O
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A35E6]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ((object)superMap != null)
					{
						GameObject gameObject3 = superMap.gameObject;
						if ((object)gameObject3 != null)
						{
							string text = ((UnityEngine.Object)gameObject3).GetName();
							if (text != null)
							{
								return text.Contains("TP_CastleDracula");
							}
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				});
			}
			object map = Enumerable.FirstOrDefault(tilingTileset._maps, predicate2);
			GameManager core5 = GM.Core;
			Stage stage2 = core5._stage;
			SuperTileLayer superTileLayer = stage2._tilingTileset.GetSuperTileLayer((SuperMap)map, "FakeWalls");
			Tilemap component = superTileLayer.GetComponent<Tilemap>();
			_backgroundTilemap = component;
			MapToken mapToken = new MapToken();
			mapToken.texture = "TP_items";
			mapToken.frameName = "TP_BossToken";
			float2 position = _DraculaSprite.position;
			mapToken.x = (float)position;
			float2 position2 = _DraculaSprite.position;
			float y = default(float);
			mapToken.y = y;
			_mapToken = mapToken;
			GameManager core6 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
		}
		else
		{
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
		}
	}

	protected override void OnUpdate()
	{
		if (!_isAnyCharacterRichter || !_sync.HasStateAuthority)
		{
			return;
		}
		CoherenceSync sync;
		Action action2;
		if (_currentCutsceneState != CutsceneState.Inactive)
		{
			if (_currentCutsceneState != CutsceneState.EnteredPlatformingArea || _cutsceneArea == null || !CheckAllPlayersInRectangle(_cutsceneArea))
			{
				return;
			}
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				OnEnterCutsceneArea();
				return;
			}
			sync = _sync;
			_changingState = true;
			nint method = default(nint);
			Action action = new Action(this, method);
			action2 = action;
			method = 0;
		}
		else
		{
			if (_platformingArea == null || !CheckAllPlayersInRectangle(_platformingArea) || _changingState)
			{
				return;
			}
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				OnEnterPlatformingArea();
				return;
			}
			sync = _sync;
			_changingState = true;
			Action action = null;
			action2 = action;
			nint method = 0;
		}
		bool flag = sync.SendCommand(action2, MessageTarget.All);
	}

	protected override void OnDestroy()
	{
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v50 @ ZF_v5 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	private unsafe bool CheckAllPlayersInRectangle(Rectangle rectangle)
	{
		//IL_0018: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return true;
	}

	protected void SetupCutsceneAreas()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<Rectangle> scriptRectangularLocations = stage._tilingTileset.GetScriptRectangularLocations("CutscenePlatformingZone", autoScaleAndOffset: true);
		if (scriptRectangularLocations != null && scriptRectangularLocations._size >= 1)
		{
			if (scriptRectangularLocations._size <= 0)
			{
				goto IL_0267;
			}
			Rectangle[] items = scriptRectangularLocations._items;
			_platformingArea = items[0];
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		List<Rectangle> scriptRectangularLocations2 = stage2._tilingTileset.GetScriptRectangularLocations("Cutscene", autoScaleAndOffset: true);
		if (scriptRectangularLocations2 != null && scriptRectangularLocations2._size >= 1)
		{
			if (scriptRectangularLocations2._size <= 0)
			{
				goto IL_0267;
			}
			Rectangle[] items2 = scriptRectangularLocations2._items;
			_cutsceneArea = items2[0];
		}
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		List<Rectangle> scriptRectangularLocations3 = stage3._tilingTileset.GetScriptRectangularLocations("CutsceneCameraLimits", autoScaleAndOffset: true);
		if (scriptRectangularLocations3 != null && scriptRectangularLocations3._size >= 1)
		{
			if (scriptRectangularLocations3._size > 0)
			{
				Rectangle[] items3 = scriptRectangularLocations3._items;
				_cutsceneCameraLimits = items3[0];
				return;
			}
			goto IL_0267;
		}
		return;
		IL_0267:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void OnEnterPlatformingArea()
	{
		//IL_0168: Expected I4, but got F4
		//IL_0186: Expected O, but got I4
		//IL_019b: Expected O, but got I4
		//IL_01b5: Expected O, but got I4
		//IL_01ca: Expected O, but got I4
		_changingState = false;
		_currentCutsceneState = CutsceneState.EnteredPlatformingArea;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageEventManager stageEventManager = stage._stageEventManager;
		stageEventManager._stageEventsDisabled = true;
		DisableGameplayOnEnterPlatformingArea();
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		GM.Core.SetAllPlayersWeaponsActive(active: false);
		GM.Core.SetPlayerWorldBoundCollision(on: true);
		Rectangle platformingArea = _platformingArea;
		float num = platformingArea._width * 0.5f;
		float num2 = platformingArea._height * 0.5f;
		float num3 = num + platformingArea._x;
		float num4 = platformingArea._y - num2;
		float num5 = platformingArea._width * 0.5f;
		float num6 = platformingArea._height * 0.5f;
		float x = num3 - num5;
		float y = num6 + num4;
		float height = default(float);
		bool? checkLeft = default(bool?);
		bool checkRight = default(bool);
		bool checkUp = default(bool);
		World world = ArcadePhysics.s_world.setBounds(x, y, platformingArea._width, height, checkLeft, checkRight, checkUp, (byte)(int)platformingArea._height != 0);
		AudioLoader.LoadSFX(SfxType.TP_sfx_Coffin1, "TP_Cutscene_SFX", (DlcType?)(object)1);
		AudioLoader.LoadSFX(SfxType.TP_sfx_Coffin2, "TP_Cutscene_SFX", (DlcType?)(object)1);
		AudioLoader.LoadSFX(SfxType.TP_sfx_Death, "TP_Cutscene_SFX", (DlcType?)(object)1);
		AudioLoader.LoadSFX(SfxType.TP_sfx_ThroneRoom, "TP_Cutscene_SFX", (DlcType?)(object)1);
		if (_cutsceneCameraLimits != null)
		{
			PlatformZoneMovement platformZoneMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
			platformZoneMovement._limitCameraPosition = true;
			PlatformZoneMovement platformZoneMovement2 = PlatformZoneMovement._003CInstance_003Ek__BackingField;
			platformZoneMovement2._003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField = true;
			PlatformZoneMovement._003CInstance_003Ek__BackingField.SetCameraLimits(_cutsceneCameraLimits);
		}
	}

	public void OnEnterCutsceneArea()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		_changingState = false;
		_currentCutsceneState = CutsceneState.DraculaAndRichterDialogue;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		core._signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		BeginCutscene();
	}

	protected void DisableAllInput()
	{
		MultiplayerManager.s_instance.DisableAllUIInteraction();
		BackButtonController instance = BackButtonController.Instance;
		if ((object)BackButtonController.Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			BackButtonController instance2 = BackButtonController.Instance;
			instance2.ListenForControllerInput = false;
		}
		BackButtonController.BackButtonClosesPage = false;
	}

	protected void EnableAllInput()
	{
		MultiplayerManager.s_instance.EnableAllUIInteraction();
		BackButtonController instance = BackButtonController.Instance;
		if ((object)BackButtonController.Instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			BackButtonController instance2 = BackButtonController.Instance;
			instance2.ListenForControllerInput = true;
		}
		BackButtonController.BackButtonClosesPage = true;
	}

	private void BeginCutscene()
	{
		DisableAllInput();
		if (_cutsceneCoroutine != null)
		{
			StopCoroutine(_cutsceneCoroutine);
		}
		if (_cameraZoomCoroutine != null)
		{
			StopCoroutine(_cameraZoomCoroutine);
		}
		GameManager core = GM.Core;
		core._003CCanPause_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		Func<VampireSurvivors.Objects.Characters.CharacterController, bool> func = _003C_003Ec._003C_003E9__76_0;
		if (_003C_003Ec._003C_003E9__76_0 == null)
		{
			func = (_003C_003Ec._003C_003E9__76_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController character)
			{
				//IL_0043: Expected I4, but got O
				if ((object)character == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				return (byte)(character._PlayerIndex >> 31) != 0;
			});
		}
		IEnumerable<object> enumerable = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A8E590");
		if (enumerable != null)
		{
			List<object> characterControllers = new List<object>(enumerable);
			_characterControllers = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)characterControllers;
			ProCamera2D instance = ProCamera2D.Instance;
			instance.RemoveAllCameraTargets(1f);
			ProCamera2D instance2 = ProCamera2D.Instance;
			Transform targetTransform = _CameraTargetTransform.transform;
			float duration = default(float);
			Vector2 targetOffset = default(Vector2);
			Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance2.AddCameraTarget(targetTransform, 1f, 1f, duration, targetOffset);
			_cutsceneDialogueUI.Init();
			if (_DoCameraZoom)
			{
				ProCamera2D instance3 = ProCamera2D.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v63 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float startSize = (_preZoomCameraSize = 0f * 0.5f);
				float cameraZoomScreenSize = CameraZoomScreenSize;
				IEnumerator routine = CameraZoom(startSize, cameraZoomScreenSize, _CameraZoomInDuration);
				Coroutine cameraZoomCoroutine = StartCoroutine(routine);
				_cameraZoomCoroutine = cameraZoomCoroutine;
			}
			if (_showLetterBox)
			{
				TPCutsceneDialogueUI cutsceneDialogueUI = _cutsceneDialogueUI;
				IEnumerator routine2 = _cutsceneDialogueUI.LetterBoxFadeTransition(0f, 1f, cutsceneDialogueUI._LetterBoxTransitionInTime);
				Coroutine letterBoxTransitionCoroutine = _cutsceneDialogueUI.StartCoroutine(routine2);
				cutsceneDialogueUI._letterBoxTransitionCoroutine = letterBoxTransitionCoroutine;
				cutsceneDialogueUI._letterBoxShowing = true;
			}
			_003CPlayCutscene_003Ed__88 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine cutsceneCoroutine = StartCoroutine(obj);
			_cutsceneCoroutine = cutsceneCoroutine;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	protected void InitDracula()
	{
		//IL_00a1: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_00cb: Expected O, but got I
		//IL_0108: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_0132: Expected O, but got I
		//IL_014c: Expected O, but got I
		_003C_003Ec__DisplayClass77_0 obj = new _003C_003Ec__DisplayClass77_0();
		SpriteAnimation component = _DraculaSprite.GetComponent<SpriteAnimation>();
		obj.draculaSpriteAnimation = component;
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedDlcCharacterData = core._dataManager.GetConvertedDlcCharacterData(DlcType.ThosePeople);
		Func<KeyValuePair<CharacterType, List<CharacterData>>, bool> func = _003C_003Ec._003C_003E9__77_0;
		if (_003C_003Ec._003C_003E9__77_0 == null)
		{
			func = (_003C_003Ec._003C_003E9__77_0 = delegate(KeyValuePair<CharacterType, List<CharacterData>> characterData)
			{
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0013: Expected O, but got Unknown
				object obj8 = characterData - 209;
				return obj8 == null;
			});
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF4130");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ stack_-20+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ stack_-20+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v19+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v20+78]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v21+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v21+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v15+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v22+78]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v23+38]");
				obj.idleAnim = (MeleeAttack)0;
				MeleeAttack idleAnim = obj.idleAnim;
				Action<bool> action = null;
				KeyValuePair<CharacterType, List<CharacterData>> keyValuePair = Enumerable.FirstOrDefault((IEnumerable<KeyValuePair<CharacterType, List<CharacterData>>>)(object)action, (Func<KeyValuePair<CharacterType, List<CharacterData>>, bool>)(object)obj);
				GameManager core2 = GM.Core;
				string customCacheGroup = default(string);
				CharacterLoader.LoadCharacterTextureAsync(idleAnim._003CtextureName_003Ek__BackingField, CharacterType.TP_DRACULA, action, core2._dataManager, customCacheGroup);
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected void InitDirecterHand()
	{
		SpriteAnimation component = _DirecterHand.GetComponent<SpriteAnimation>();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("hand_snap_", 1, 3, "enemiesM", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("hand_snap_", 4, 5, "enemiesM", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		component.AddAnimation("snap_start", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		component.AddAnimation("snap", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		Action action = delegate
		{
			//IL_002c: Expected I, but got O
			//IL_0090: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_DirecterHand != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 1000f;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete2 = delegate
			{
				ArcadeSprite arcadeSprite3 = _DirecterHand.setVisible(visible: false);
			};
			tweenConfig.onComplete = onComplete2;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186DD0180");
		((BaseSpriteAnimation)component)._currentAnimation = null;
		ArcadeSprite arcadeSprite = _DirecterHand.setFlipX(flipX: true);
		ArcadeSprite arcadeSprite2 = _DirecterHand.setVisible(visible: false);
	}

	private void PlayDirecterSnap(Action onSnap = null)
	{
		_003C_003Ec__DisplayClass79_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass79_0();
		CS_0024_003C_003E8__locals6.onSnap = onSnap;
		ArcadeSprite arcadeSprite = _DirecterHand.setVisible(visible: true);
		SpriteAnimation component = _DirecterHand.GetComponent<SpriteAnimation>();
		CS_0024_003C_003E8__locals6.directerSpriteAnimation = component;
		CS_0024_003C_003E8__locals6.directerSpriteAnimation.SetAnimation("snap_start");
		Action onComplete = delegate
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Clap, 100f, 10, 0f, volume, rate, detune, loop, 1f);
			CS_0024_003C_003E8__locals6.directerSpriteAnimation.SetAnimation("snap");
			Action onSnap2 = CS_0024_003C_003E8__locals6.onSnap;
			if (CS_0024_003C_003E8__locals6.onSnap != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v83.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private IEnumerator CameraZoom(float startSize, float endSize, float duration)
	{
		_003CCameraZoom_003Ed__80 obj = null;
		obj.startSize = startSize;
		obj.endSize = endSize;
		obj.duration = duration;
		obj._003C_003E1__state = 0;
		return obj;
	}

	protected IEnumerator RevealDeath()
	{
		_003CRevealDeath_003Ed__81 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void DisableGameplayOnEnterPlatformingArea()
	{
		//IL_0088: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		GameManager core = GM.Core;
		core._003CCanInterrupt_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		core2._canRunTickerTimer = false;
		GameManager core3 = GM.Core;
		Stage stage = core3._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		if (flag)
		{
			goto IL_0139;
		}
		while (true)
		{
			GameManager core4 = GM.Core;
			Stage stage2 = core4._stage;
			List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
			if ((nint)obj >= spawnedEnemies2._size)
			{
				break;
			}
			EnemyController[] items = spawnedEnemies2._items;
			items[obj].Disappear();
			obj--;
			if ((nint)items[obj] >= 0)
			{
				continue;
			}
			goto IL_0139;
		}
		goto IL_046e;
		IL_046e:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_02b7:
		GameManager core5 = GM.Core;
		List<Pickup> stagePickups = core5._stagePickups;
		int version = stagePickups._version + 1;
		stagePickups._version = version;
		stagePickups._size = 0;
		if (stagePickups._size > 0)
		{
			Array.Clear(stagePickups._items, 0, stagePickups._size);
		}
		GameManager core6 = GM.Core;
		Stage stage3 = core6._stage;
		StageEventTrisectionManager trisection = stage3._trisection;
		if (stage3._trisection != null)
		{
			if (trisection._tweenCounter != null)
			{
				trisection._tweenCounter.Kill();
			}
			if (trisection._tweenRotateName != null)
			{
				trisection._tweenRotateName.Kill();
			}
			if (trisection._tweenHighlightName != null)
			{
				trisection._tweenHighlightName.Kill();
			}
			PhaserText phaserText = trisection._nextEventText.SetAlpha(0f);
			stage3._trisection.HideCircles();
		}
		return;
		IL_0139:
		GameManager core7 = GM.Core;
		Stage stage4 = core7._stage;
		if (stage4._spawnTimer != null)
		{
			stage4._spawnTimer.Cancel();
		}
		if (stage4._destructibleTimer != null)
		{
			stage4._destructibleTimer.Cancel();
		}
		GameManager core8 = GM.Core;
		List<Pickup> stagePickups2 = core8._stagePickups;
		bool flag2 = (nint)core8._stagePickups < 0;
		object obj2 = stagePickups2._size - 1;
		if (flag2)
		{
			goto IL_02b7;
		}
		while (true)
		{
			GameManager core9 = GM.Core;
			List<Pickup> stagePickups3 = core9._stagePickups;
			if ((nint)obj2 >= stagePickups3._size)
			{
				break;
			}
			Pickup[] items2 = stagePickups3._items;
			items2[obj2].Despawn();
			obj2--;
			if ((nint)items2[obj2] >= 0)
			{
				continue;
			}
			goto IL_02b7;
		}
		goto IL_046e;
	}

	private IEnumerator TweenCharactersToWaitPosition()
	{
		_003CTweenCharactersToWaitPosition_003Ed__83 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void AddMoveToPositionTween(VampireSurvivors.Objects.Characters.CharacterController character, float halfSpread, int positionIndex, TweenCallback onComplete)
	{
		//IL_0049: Expected O, but got I4
		//IL_0170: Expected O, but got Ref
		//IL_0135: Expected I, but got O
		//IL_01a9: Expected F4, but got I4
		//IL_01b7: Expected O, but got I4
		//IL_01c5: Expected O, but got I4
		_003C_003Ec__DisplayClass84_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass84_0();
		CS_0024_003C_003E8__locals9.character = character;
		VampireSurvivors.Objects.Characters.CharacterController character2 = CS_0024_003C_003E8__locals9.character;
		BaseBody body = character2.body;
		body._velocity = (float2)0;
		CS_0024_003C_003E8__locals9.character.enabled = false;
		VampireSurvivors.Objects.Characters.CharacterController character3 = CS_0024_003C_003E8__locals9.character;
		character3._isAnimForced = true;
		VampireSurvivors.Objects.Characters.CharacterController character4 = CS_0024_003C_003E8__locals9.character;
		SpriteAnimation spriteAnimation = character4._spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		VampireSurvivors.Objects.Characters.CharacterController character5 = CS_0024_003C_003E8__locals9.character;
		character5._spriteAnimation.SetAnimation("walk");
		VampireSurvivors.Objects.Characters.CharacterController character6 = CS_0024_003C_003E8__locals9.character;
		character6._canFlip = false;
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals9.character != null)
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
		object obj2 = default(object);
		float2 float5 = ConvertLocalV3ToWorldFloat2((Vector3)(&obj2));
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.targets = array;
		tweenConfig.duration = _CharacterWalkTimeInMilliseconds;
		tweenConfig.x = (float?)(object)1;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onUpdate = delegate
		{
			ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals9.character.setFlipX(flipX: true);
		};
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onComplete2 = default(TweenCallback);
		tweenConfig.onComplete = onComplete2;
		tweenConfig.ease = Ease.Linear;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	protected void EnableMovementAfterCutscene()
	{
		//IL_0084: Expected O, but got I
		//IL_002b->IL0089: Incompatible stack heights: 1 vs 0
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbx_v4 (System.Object)+10]");
			Behaviour.set_enabled_Injected((IntPtr)0, true);
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbx_v4 (System.Object)+D0]");
			object obj2 = 0;
			_ = 0;
			_ = 1;
		}
	}

	private void LockPlayerMovementToCameraBounds()
	{
		//IL_0167: Expected I4, but got F4
		//IL_020f->IL0171: Incompatible stack heights: 1 vs 0
		//IL_0133->IL0171: Incompatible stack heights: 1 vs 0
		//IL_022d->IL0171: Incompatible stack heights: 1 vs 0
		//IL_0170->IL0170: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			GM.Core.SetPlayerWorldBoundCollision(on: true);
			Camera main = Camera.main;
			if ((object)main == null || ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Bounds bounds = CameraExtensions.OrthographicBounds(main);
				object obj = default(object);
				float num = (float)obj * 2f;
				Bounds bounds2 = CameraExtensions.OrthographicBounds(main);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rax_v26 (UnityEngine.Bounds)+10]");
				float num2 = 0f * 2f;
				float num3 = num * 0.5f;
				float x = (float)ret - num3;
				float num4 = num2 * 0.5f;
				object obj2 = default(object);
				float y = (float)obj2 - num4;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null && ArcadePhysics.s_world != null)
				{
					float height = default(float);
					bool? checkLeft = default(bool?);
					bool checkRight = default(bool);
					bool checkUp = default(bool);
					World world = ArcadePhysics.s_world.setBounds(x, y, num, height, checkLeft, checkRight, checkUp, (byte)(int)num2 != 0);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LockPlayerMovementToPlatformingAreaBounds()
	{
		//IL_00fb: Expected I4, but got F4
		GM.Core.SetPlayerWorldBoundCollision(on: true);
		Rectangle platformingArea = _platformingArea;
		float num = platformingArea._width * 0.5f;
		float num2 = platformingArea._height * 0.5f;
		float num3 = num + platformingArea._x;
		float num4 = platformingArea._y - num2;
		float num5 = platformingArea._width * 0.5f;
		float num6 = platformingArea._height * 0.5f;
		float x = num3 - num5;
		float y = num6 + num4;
		float height = default(float);
		bool? checkLeft = default(bool?);
		bool checkRight = default(bool);
		bool checkUp = default(bool);
		World world = ArcadePhysics.s_world.setBounds(x, y, platformingArea._width, height, checkLeft, checkRight, checkUp, (byte)(int)platformingArea._height != 0);
	}

	private IEnumerator PlayCutscene()
	{
		_003CPlayCutscene_003Ed__88 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void OnTeleportFromThroneComplete()
	{
		Action onFadeToBlackComplete = SpawnDraculaCoffin;
		Action action = delegate
		{
			_coffinSpawnTeleportComplete = true;
		};
		action._002Ector(this, (nint)__ldftn(DraculaCutscene._003COnTeleportFromThroneComplete_003Eb__89_0));
		_TeleportEffect.PlayTeleportEffect(DraculaCutsceneTeleport.TeleportPosition.Foreground, onFadeToBlackComplete, action);
	}

	protected virtual IEnumerator PlayDeathDialogueCutscene()
	{
		_003CPlayDeathDialogueCutscene_003Ed__90 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator TransitionToDeathFight(Enemy_TP_Death deathEnemy)
	{
		_003CTransitionToDeathFight_003Ed__91 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.deathEnemy = deathEnemy;
		return obj;
	}

	private unsafe void SpawnDraculaCoffin()
	{
		//IL_028f: Expected O, but got Ref
		//IL_0079: Expected I, but got O
		//IL_0087: Expected I, but got O
		//IL_0097: Expected O, but got I
		//IL_0117: Expected O, but got I4
		//IL_00d3: Expected O, but got I
		//IL_0109: Expected O, but got I4
		//IL_01bf: Expected O, but got I4
		//IL_01bf: Expected O, but got I
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_030c: Expected O, but got I
		//IL_0271: Expected O, but got I4
		object obj = default(object);
		float2 float5 = ConvertLocalV3ToWorldFloat2((Vector3)(&obj));
		Pickup pickup;
		object obj4;
		if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.COFFIN))
		{
			Vector2 pos = default(Vector2);
			pickup = PickupManager.CreatePickup(pos, ItemType.COFFIN);
			if ((object)pickup != null)
			{
				nint num = (nint)pickup;
				nint num2 = (nint)typeof(PickupCoffin);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rax_v66+FFFFFFF8+v431 @ rax_v62*8]");
					if (0 == (nint)typeof(PickupCoffin))
					{
						obj4 = 1;
						goto IL_02c2;
					}
				}
				obj4 = 0;
				goto IL_02c2;
			}
		}
		PickupCoffin pickupCoffin = null;
		goto IL_02b4;
		IL_02c2:
		bool flag = obj4 == null;
		pickupCoffin = null;
		if (!flag)
		{
			pickupCoffin = (PickupCoffin)pickup;
		}
		goto IL_02b4;
		IL_02b4:
		GameManager core = GM.Core;
		Action action = OnCharacterFoundScreenClosed;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj5 = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.CharacterFoundPageClosedSignal>)obj5)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<UISignals.CharacterFoundPageClosedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj7 = default(object);
		object obj6 = obj7 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = core._signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v19 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
		if ((object)pickupCoffin != null && ((UnityEngine.Object)pickupCoffin).m_CachedPtr != (IntPtr)0)
		{
			((PickupGuarded)pickupCoffin)._enemyType = EnemyType.BAT1;
			((PickupGuarded)pickupCoffin)._hasAssignedSpawnData = true;
			((PickupGuarded)pickupCoffin)._003CIsAnyGuardAlive_003Ek__BackingField = false;
			pickupCoffin.SetChar(CharacterType.TP_DRACULA);
			BaseBody baseBody = pickupCoffin.body.setOffset(0f, (float?)(object)1);
			_draculaCoffin = pickupCoffin;
		}
	}

	private void OnCharacterFoundScreenClosed()
	{
		if (!_deathCutsceneTriggered)
		{
			_deathCutsceneTriggered = true;
			ThosePeopleLoader.UnloadGameplayAssets();
			Action onComplete = delegate
			{
				GameObject gameObject = _DraculaSprite.gameObject;
				gameObject.SetActive(value: false);
				DisableGameplayOnEnterPlatformingArea();
				IEnumerator routine = PlayDeathDialogueCutscene();
				Coroutine cutsceneCoroutine = StartCoroutine(routine);
				_cutsceneCoroutine = cutsceneCoroutine;
			};
			ThosePeopleLoader.LoadBossFightAssets(onComplete);
		}
	}

	private unsafe void MakeAllBackgroundsInvisible()
	{
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0143: Expected O, but got I4
		//IL_0080->IL00d6: Incompatible stack heights: 1 vs 0
		//IL_0149->IL0064: Incompatible stack heights: 3 vs 1
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		List<SuperMap>.Enumerator value = (List<SuperMap>.Enumerator)tilingTileset._maps;
		List<SuperMap>.Enumerator enumerator = default(List<SuperMap>.Enumerator);
		while (enumerator.MoveNext())
		{
			Tilemap[] componentsInChildren = ((Component)null).GetComponentsInChildren<Tilemap>();
			bool flag = componentsInChildren == null;
			Tilemap tilemap = null;
			while ((nint)tilemap < componentsInChildren.Length)
			{
				Tilemap tilemap2 = componentsInChildren[(object)tilemap];
				bool flag2 = (object)componentsInChildren[(object)tilemap] == null;
				bool flag3 = ((UnityEngine.Object)tilemap2).m_CachedPtr == (IntPtr)0;
				Tilemap.set_color_Injected(((UnityEngine.Object)tilemap2).m_CachedPtr, ref *(Color*)(&value));
				tilemap = (Tilemap)(tilemap + 1);
				value = (List<SuperMap>.Enumerator)0;
			}
		}
	}

	protected unsafe void RemoveBackground()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0170: Expected O, but got Ref
		//IL_01e3: Expected O, but got Ref
		//IL_01f1: Expected O, but got Ref
		//IL_0214: Expected I4, but got I8
		//IL_02e4: Expected O, but got I
		//IL_02f6: Expected O, but got I8
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0241: Expected O, but got Ref
		//IL_024f: Expected O, but got Ref
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_01a6->IL00ec: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.CameraSet cameras = s_scene.cameras;
				if (s_scene.cameras != null && (object)cameras.main != null)
				{
					Transform transform = cameras.main.transform;
					if ((object)transform != null)
					{
						_ = 0;
						_ = 0;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
						Transform backgroundTilemap = (Transform)(object)_backgroundTilemap;
						if ((object)_backgroundTilemap != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-1]");
							_ = 0;
							_ = 0;
							_ = 0;
							bool flag2 = ((UnityEngine.Object)backgroundTilemap).m_CachedPtr == (IntPtr)0;
							object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
							GridLayout.WorldToCell_Injected(((UnityEngine.Object)backgroundTilemap).m_CachedPtr, ref *(Vector3*)obj5, out *(Vector3Int*)obj4);
							int num = -5;
							int relativeYCoordinate = default(int);
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
								object obj6 = (nint)0 + (nint)num;
								object obj7 = 4294967291L;
								do
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B]");
									object obj8 = 0 + obj7;
									Vector3Int cellPosition = (Vector3Int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
									Vector3 cameraPosition = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+17]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
									_ = 0;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-1]");
									_ = 0;
									IEnumerator routine = ScaleOutTile(cameraPosition, cellPosition, num, relativeYCoordinate);
									Coroutine coroutine = StartCoroutine(routine);
									obj7++;
								}
								while ((nint)obj7 < 5);
								num++;
							}
							while (num < 5);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator ScaleOutTile(Vector3 cameraPosition, Vector3Int cellPosition, int relativeXCoordinate, int relativeYCoordinate)
	{
		//IL_0017: Expected O, but got F4
		//IL_0033: Expected O, but got I4
		_003CScaleOutTile_003Ed__96 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.cameraPosition = (Vector3)cameraPosition.x;
		_ = cameraPosition.z;
		obj.cellPosition = (Vector3Int)cellPosition.m_X;
		_ = cellPosition.m_Z;
		int relativeYCoordinate2 = default(int);
		obj.relativeYCoordinate = relativeYCoordinate2;
		obj.relativeXCoordinate = relativeXCoordinate;
		return obj;
	}

	protected void RemoveWalls()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					List<SuperMap>.Enumerator maps = (List<SuperMap>.Enumerator)tilingTileset._maps;
					if (tilingTileset._maps != null)
					{
						List<SuperMap>.Enumerator enumerator = default(List<SuperMap>.Enumerator);
						if (enumerator.MoveNext())
						{
							Component component = null;
							throw new NullReferenceException();
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core2._stage;
							if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
							{
								stage2._tilingTileset.SetTilemapCollisionsEnabled(isEnabled: false);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected IEnumerator PlayDeathScream(Enemy_TP_Death death)
	{
		_003CPlayDeathScream_003Ed__98 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.death = death;
		return obj;
	}

	private void PlayDeathScreamAudio()
	{
		//IL_009f: Expected I4, but got I8
		//IL_00a3: Expected O, but got I4
		//IL_0034: Expected F4, but got I4
		//IL_0055: Expected I4, but got I8
		//IL_0059: Expected O, but got I4
		//IL_0087: Expected F4, but got I4
		object obj = UnityEngine.Random.RandomRangeInt(-200, 200);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Deathscream, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		object obj2 = UnityEngine.Random.RandomRangeInt(-200, 200);
		PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.sfx_death_4, 0f, 10, 0f, volume, rate, detune, loop, 1f);
	}

	private IEnumerator WaitForSecondsPausable(float seconds)
	{
		_003CWaitForSecondsPausable_003Ed__100 obj = null;
		obj.seconds = seconds;
		obj._003C_003E1__state = 0;
		return obj;
	}

	protected void DeathScreenShake(int repeats)
	{
		//IL_00b3: Expected I, but got O
		//IL_0109: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
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
		tweenConfig.targets = array;
		tweenConfig.x = (float?)(object)1;
		tweenConfig.duration = _ScreenShakeDuration;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		TweenCallback onStart = delegate
		{
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected F4, but got Unknown
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras2 = s_scene2.cameras;
			PhaserCamera main2 = cameras2.main;
			PhaserScene.BoxedVector2 followOffset = main2.followOffset;
			float screenShakeMagnitude = _ScreenShakeMagnitude;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float x = screenShakeMagnitude ^ 0;
			followOffset.x = x;
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__101_1;
		if (_003C_003Ec._003C_003E9__101_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__101_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	protected unsafe float2 ConvertLocalV3ToWorldFloat2(Vector3 vector3)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float position = default(float);
		Transform.TransformPoint_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&position), out Vector3 _);
		float2 result = default(float2);
		return result;
	}

	public DraculaCutscene()
	{
		//IL_000b: Expected O, but got I4
		//IL_00b5: Expected I, but got O
		_DebugTeleportPosition = (Vector2)1130758144;
		_ = 1105933107;
		_SpreadPerPlayerInCoOp = 0.3f;
		_CharacterWalkTimeInMilliseconds = 2000;
		_CameraTransitionDuration = 0.75f;
		_DoCameraZoom = true;
		_CameraZoomScreenSize = 1f;
		_CameraZoomScreenSizePortrait = 2.5f;
		_CameraZoomInDuration = 0.75f;
		_CameraZoomOutDuration = 0.75f;
		_ThrowWineGlassDialogueIndex = 5;
		_ThrowWineGlassDelay = 1f;
		_DelayBeforePlayingDirecterSnap = 0.2f;
		_BackgroundTileLerpOutDuration = 1f;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CInitDirecterHand_003Eb__78_0()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_DirecterHand != null)
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
		tweenConfig.targets = array;
		tweenConfig.duration = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			ArcadeSprite arcadeSprite = _DirecterHand.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void _003CInitDirecterHand_003Eb__78_1()
	{
		ArcadeSprite arcadeSprite = _DirecterHand.setVisible(visible: false);
	}

	private bool _003CRevealDeath_003Eb__81_0()
	{
		return _backgroundRemoveComplete;
	}

	private void _003COnTeleportFromThroneComplete_003Eb__89_0()
	{
		_coffinSpawnTeleportComplete = true;
	}

	private void _003COnCharacterFoundScreenClosed_003Eb__93_0()
	{
		GameObject gameObject = _DraculaSprite.gameObject;
		gameObject.SetActive(value: false);
		DisableGameplayOnEnterPlatformingArea();
		IEnumerator routine = PlayDeathDialogueCutscene();
		Coroutine cutsceneCoroutine = StartCoroutine(routine);
		_cutsceneCoroutine = cutsceneCoroutine;
	}

	private void _003CDeathScreenShake_003Eb__101_0()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected F4, but got Unknown
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		PhaserScene.BoxedVector2 followOffset = main.followOffset;
		float screenShakeMagnitude = _ScreenShakeMagnitude;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float x = screenShakeMagnitude ^ 0;
		followOffset.x = x;
	}
}
