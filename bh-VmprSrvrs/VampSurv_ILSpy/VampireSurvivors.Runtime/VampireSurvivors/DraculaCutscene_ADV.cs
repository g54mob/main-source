using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Rewired;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors;

public class DraculaCutscene_ADV : DraculaCutscene
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__0_0;

		public static Func<SuperMap, bool> _003C_003E9__0_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CStart_003Eb__0_0(VampireSurvivors.Objects.Characters.CharacterController character)
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

		internal bool _003CStart_003Eb__0_1(SuperMap map)
		{
			//IL_00ac: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3606]");
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
						return name.Contains("OTC_001_005_ThroneRooms_Death");
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CPlayDeathDialogueCutscene_003Ed__1(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene_ADV _003C_003E4__this;

		private Enemy_TP_Death _003CdeathEnemy_003E5__2;

		private int _003Cindex_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0602: Expected I4, but got I8
			//IL_0026: Expected O, but got I4
			//IL_0127: Expected I4, but got I8
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_00f4: Expected I4, but got I8
			//IL_0637: Expected O, but got Ref
			//IL_091c: Expected O, but got Ref
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_0745: Expected O, but got I
			//IL_00c1: Expected I4, but got I8
			//IL_07e1: Expected F4, but got I4
			//IL_0813: Expected F4, but got I4
			//IL_00a4: Expected I4, but got I8
			//IL_07ae: Expected O, but got I8
			//IL_023c: Expected I, but got O
			//IL_024a: Expected I, but got O
			//IL_025a: Expected O, but got I
			//IL_02da: Expected O, but got I4
			//IL_0222: Expected I, but got O
			//IL_022f: Expected I, but got O
			//IL_0950: Expected I, but got O
			//IL_0296: Expected O, but got I
			//IL_0560: Expected O, but got I4
			//IL_056a: Unknown result type (might be due to invalid IL or missing references)
			//IL_056f: Expected O, but got Unknown
			//IL_02ed: Expected I, but got O
			//IL_02cc: Expected O, but got I4
			//IL_033d: Expected I4, but got O
			//IL_059f: Expected O, but got Ref
			//IL_040e: Expected I, but got O
			//IL_048c: Expected O, but got I4
			//IL_049a: Expected O, but got I4
			//IL_04a8: Expected O, but got I4
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			UnityEngine.Object obj2;
			Stage stage;
			UnityEngine.Object obj3;
			object obj6;
			bool result;
			nint num;
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
						obj2 = null;
					}
					else
					{
						obj2 = null;
					}
					List<VampireSurvivors.Objects.Characters.CharacterController> list = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
					float2 float5 = _003C_003E4__this.ConvertLocalV3ToWorldFloat2((Vector3)(&list));
					GameManager core2 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					Enemy_TP_Death enemy_TP_Death = default(Enemy_TP_Death);
					_003CdeathEnemy_003E5__2 = enemy_TP_Death;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					object message = default(object);
					Debug.Log(message);
					GameManager core3 = GM.Core;
					stage = core3._stage;
					UnityEngine.Object fancyBg = stage._fancyBg;
					nint num2;
					if ((object)stage._fancyBg == null)
					{
						num = unchecked((nint)null);
						obj3 = obj2;
						num2 = unchecked((nint)null);
						goto IL_02ff;
					}
					num2 = (nint)fancyBg;
					nint num3 = (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1719 @ r8_v40 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+130]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r9_v12 (Il2CppClass<UnityEngine.Object>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1719 @ r8_v40 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r9_v12 (Il2CppClass<UnityEngine.Object>)+C8]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1792 @ rax_v114+FFFFFFF8+v1720 @ rax_v110*8]");
						if (0 == (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT))
						{
							obj6 = 1;
							goto IL_0933;
						}
					}
					obj6 = 0;
					goto IL_0933;
				}
				object obj7 = obj - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					int num5 = _003Cindex_003E5__3 + 1;
					_003Cindex_003E5__3 = num5;
					goto IL_08fb;
				}
				object obj8 = obj7 - 1;
				if (!flag)
				{
					bool flag3 = (nint)obj8 != 1;
					result = false;
					if (!flag3)
					{
						_003C_003E1__state = -1;
						result = false;
					}
					goto IL_08bb;
				}
				_003C_003E1__state = -1;
				_003CTransitionToDeathFight_003Ed__2 obj9 = null;
				obj9._003C_003E1__state = 0;
				obj9._003C_003E4__this = _003C_003E4__this;
				obj9.deathEnemy = _003CdeathEnemy_003E5__2;
				_003C_003E2__current = obj9;
				_003C_003E1__state = 4;
			}
			else
			{
				_003C_003E1__state = -1;
				_003C_003E4__this.DisableAllInput();
				draculaCutscene._currentCutsceneState = CutsceneState.DeathDialogue;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					Behaviour behaviour = null;
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				GameObject gameObject = draculaCutscene._cutsceneDialogueUI.gameObject;
				gameObject.SetActive(value: true);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				bool flag4 = (nint)0 != 0;
				GameObject gameObject2 = gameObject;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj10 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
					gameObject2 = (GameObject)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1662 @ rax_v35 (should have been resolved before IL gen)");
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 0f, 10, 0f, volume, rate, detune, loop, 1f);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 0f, 10, 0f, volume, rate, detune, loop, 1f);
				_003C_003E4__this.DeathScreenShake(draculaCutscene._ScreenShakeRepeats);
				IEnumerator enumerator3 = draculaCutscene._cutsceneDialogueUI.Show();
				_003C_003E2__current = enumerator3;
				_003C_003E1__state = 1;
			}
			goto IL_0985;
			IL_0933:
			bool flag5 = obj6 == null;
			num = (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT);
			obj3 = obj2;
			if (!flag5)
			{
				num = (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT);
				obj3 = stage._fancyBg;
			}
			goto IL_02ff;
			IL_0985:
			result = true;
			goto IL_08bb;
			IL_02ff:
			if ((bool)obj3)
			{
				((Background_TP_ADV_001_Stage_DEATHFIGHT)obj3).SpawnDeathFightTile();
			}
			_003Cindex_003E5__3 = (int)obj2;
			goto IL_08fb;
			IL_08bb:
			return result;
			IL_08fb:
			TPCutsceneDialogue[] afterCoffinCutsceneDialogue = draculaCutscene._AfterCoffinCutsceneDialogue;
			if (_003Cindex_003E5__3 < afterCoffinCutsceneDialogue.Length)
			{
				if (_003Cindex_003E5__3 == 3)
				{
					_003C_003E4__this.RemoveBackground();
					if ((bool)draculaCutscene._draculaCoffin)
					{
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if ((object)draculaCutscene._draculaCoffin != null)
						{
							nint num6 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj11 = default(object);
							if (obj11 == null)
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
				object obj12 = afterCoffinCutsceneDialogue2.Length - 1;
				object obj13 = _003Cindex_003E5__3 - obj12;
				bool hidePortraitAtEnd = obj13 == null;
				TPCutsceneDialogue tPCutsceneDialogue = default(TPCutsceneDialogue);
				IEnumerator enumerator4 = draculaCutscene._cutsceneDialogueUI.PlayDialogue((TPCutsceneDialogue)(&tPCutsceneDialogue), hidePortraitAtEnd, SfxType.TP_sfx_Death);
				_003C_003E2__current = enumerator4;
				_003C_003E1__state = 2;
			}
			else
			{
				IEnumerator enumerator5 = draculaCutscene._cutsceneDialogueUI.HideDialoguePanelOnDialogueFinished();
				_003C_003E2__current = enumerator5;
				_003C_003E1__state = 3;
			}
			goto IL_0985;
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

	private sealed class _003CTransitionToDeathFight_003Ed__2(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene_ADV _003C_003E4__this;

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
			//IL_0483: Expected I4, but got O
			//IL_01d7: Expected I, but got O
			//IL_01df: Expected I, but got O
			//IL_01ef: Expected O, but got I
			//IL_026f: Expected O, but got I4
			//IL_022b: Expected O, but got I
			//IL_0261: Expected O, but got I4
			//IL_0304: Expected O, but got I4
			//IL_0533: Expected O, but got I4
			//IL_0541: Expected O, but got I4
			//IL_054f: Expected O, but got I4
			//IL_055d: Expected O, but got I4
			DraculaCutscene draculaCutscene = _003C_003E4__this;
			Stage stage;
			Background_TP_ADV_001_Stage_DEATHFIGHT background_TP_ADV_001_Stage_DEATHFIGHT;
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
					goto IL_04af;
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
									Background_TP_ADV_001_Stage_DEATHFIGHT fancyBg = (Background_TP_ADV_001_Stage_DEATHFIGHT)stage._fancyBg;
									if ((object)stage._fancyBg == null)
									{
										background_TP_ADV_001_Stage_DEATHFIGHT = null;
										goto IL_04e1;
									}
									nint num = (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT);
									nint num2 = (nint)fancyBg;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+130]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+130]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+130]");
									if (num3 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+C8]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rax_v55+FFFFFFF8+v429 @ rax_v51*8]");
										if (0 == (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT))
										{
											obj3 = 1;
											goto IL_04ba;
										}
									}
									obj3 = 0;
									goto IL_04ba;
								}
							}
						}
					}
				}
			}
			goto IL_0475;
			IL_04ba:
			bool flag = obj3 == null;
			background_TP_ADV_001_Stage_DEATHFIGHT = null;
			if (!flag)
			{
				background_TP_ADV_001_Stage_DEATHFIGHT = (Background_TP_ADV_001_Stage_DEATHFIGHT)stage._fancyBg;
			}
			goto IL_04e1;
			IL_04e1:
			if ((object)background_TP_ADV_001_Stage_DEATHFIGHT != null && ((UnityEngine.Object)background_TP_ADV_001_Stage_DEATHFIGHT).m_CachedPtr != (IntPtr)0)
			{
				background_TP_ADV_001_Stage_DEATHFIGHT.ExitPlatformingZone();
				background_TP_ADV_001_Stage_DEATHFIGHT._polygonGroups = null;
			}
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
											goto IL_04af;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0475;
			IL_0475:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_04af:
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

	protected unsafe override void Start()
	{
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Ref, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Ref, but got Unknown
		//IL_02c2: Expected F4, but got O
		CoherenceSync componentInParent = GetComponentInParent<CoherenceSync>();
		_sync = componentInParent;
		GameManager core = GM.Core;
		Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = _003C_003Ec._003C_003E9__0_0;
		if (_003C_003Ec._003C_003E9__0_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__0_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController character)
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
			Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__0_1;
			if (_003C_003Ec._003C_003E9__0_1 == null)
			{
				predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__0_1 = delegate(SuperMap superMap)
				{
					//IL_00ac: Expected I4, but got O
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3606]");
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
								return text.Contains("OTC_001_005_ThroneRooms_Death");
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

	protected override IEnumerator PlayDeathDialogueCutscene()
	{
		_003CPlayDeathDialogueCutscene_003Ed__1 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator TransitionToDeathFight(Enemy_TP_Death deathEnemy)
	{
		_003CTransitionToDeathFight_003Ed__2 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.deathEnemy = deathEnemy;
		return obj;
	}

	public DraculaCutscene_ADV()
	{
		//IL_000b: Expected O, but got I4
		//IL_00b5: Expected I, but got O
		base._DebugTeleportPosition = (Vector2)1130758144;
		_ = 1105933107;
		base._SpreadPerPlayerInCoOp = 0.3f;
		base._CharacterWalkTimeInMilliseconds = 2000;
		base._CameraTransitionDuration = 0.75f;
		base._DoCameraZoom = true;
		base._CameraZoomScreenSize = 1f;
		base._CameraZoomScreenSizePortrait = 2.5f;
		base._CameraZoomInDuration = 0.75f;
		base._CameraZoomOutDuration = 0.75f;
		base._ThrowWineGlassDialogueIndex = 5;
		base._ThrowWineGlassDelay = 1f;
		base._DelayBeforePlayingDirecterSnap = 0.2f;
		base._BackgroundTileLerpOutDuration = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
