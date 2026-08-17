using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json.Linq;
using QFSW.MOP2;
using Rewired;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Scripts.Framework;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.Objects.VFX;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using VampireSurvivors.Spells;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.Framework;

public class GameManager : GameMonoBehaviour
{
	public class ZoomSize
	{
		public float _currentSize;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ArcanaType, bool> _003C_003E9__425_0;

		public static Predicate<VampireSurvivors.Objects.Characters.CharacterController> _003C_003E9__518_0;

		public static Func<KeyValuePair<WeaponType, List<WeaponData>>, bool> _003C_003E9__565_0;

		public static Func<KeyValuePair<WeaponType, List<WeaponData>>, bool> _003C_003E9__565_1;

		public static Comparison<VampireSurvivors.Objects.Characters.CharacterController> _003C_003E9__565_2;

		public static Func<Equipment, WeaponType> _003C_003E9__675_0;

		public static Func<Equipment, WeaponType> _003C_003E9__675_1;

		public static Func<Equipment, WeaponType> _003C_003E9__676_0;

		public static Func<Equipment, WeaponType> _003C_003E9__676_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CShouldShowArcanaPanel_003Eb__425_0(ArcanaType arcana)
		{
			//IL_00a3: Expected I4, but got O
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected I4, but got Unknown
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				if (config != null && config._003CUnlockedArcanas_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
					object obj = default(object);
					return (byte)(obj ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CPullRandomChestWinner_003Eb__518_0(VampireSurvivors.Objects.Characters.CharacterController c)
		{
			//IL_0073: Expected I4, but got O
			if ((object)c != null)
			{
				if (c._isDead)
				{
					return false;
				}
				bool isDisconnectedFromOnlinePlay = c.IsDisconnectedFromOnlinePlay;
				return (byte)((isDisconnectedFromOnlinePlay ? 1u : 0u) ^ 1u) != 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CDebugCoopShowcase_003Eb__565_0(KeyValuePair<WeaponType, List<WeaponData>> w)
		{
			//IL_0219: Expected O, but got I
			//IL_003d: Expected O, but got I
			//IL_0052: Expected O, but got I
			//IL_008f: Expected O, but got I
			//IL_009f: Expected O, but got I
			//IL_00af: Expected O, but got I
			//IL_00e7: Expected O, but got I
			//IL_0124: Expected O, but got I
			//IL_0139: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v9+101]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v12+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v13+20]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8+60]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v14+18]");
						if ((nint)0 <= (nint)0)
						{
							goto IL_021e;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v14+10]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v9+20]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v15+61]");
						if ((nint)0 == 0 && (nint)w != 88 && (nint)w != 100 && (nint)w != 158)
						{
							bool flag = (nint)w < 0;
							bool flag2 = (object)w == null;
							bool flag3 = !flag;
							bool flag4 = !flag2;
							return flag4 & flag3;
						}
					}
				}
				return false;
			}
			goto IL_021e;
			IL_021e:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}

		internal bool _003CDebugCoopShowcase_003Eb__565_1(KeyValuePair<WeaponType, List<WeaponData>> w)
		{
			//IL_0074: Expected O, but got I
			//IL_003d: Expected O, but got I
			//IL_0052: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v6+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v9+101]");
				return false;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}

		internal int _003CDebugCoopShowcase_003Eb__565_2(VampireSurvivors.Objects.Characters.CharacterController a, VampireSurvivors.Objects.Characters.CharacterController b)
		{
			//IL_004e: Expected I4, but got O
			if ((object)OnlineStageManager._instance != null)
			{
				int seatNumberForCharacter = OnlineStageManager._instance.GetSeatNumberForCharacter(a);
				if ((object)OnlineStageManager._instance != null)
				{
					int seatNumberForCharacter2 = OnlineStageManager._instance.GetSeatNumberForCharacter(b);
					return seatNumberForCharacter - seatNumberForCharacter2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal WeaponType _003CPreManipulateLevelUpOptionsForSpecialWeapons_003Eb__675_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CPreManipulateLevelUpOptionsForSpecialWeapons_003Eb__675_1(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CPostManipulateLevelUpOptionsForSpecialWeapons_003Eb__676_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CPostManipulateLevelUpOptionsForSpecialWeapons_003Eb__676_1(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass496_0
	{
		public float startSize;

		public ZoomSize zoomSizeObject;

		internal void _003CZoomOnPlayer_003Eb__0()
		{
			ProCamera2D instance = ProCamera2D.Instance;
			ZoomSize zoomSize = zoomSizeObject;
			float num = zoomSize._currentSize * -0.1f;
			float newSize = num + startSize;
			instance.UpdateScreenSize(newSize);
		}
	}

	private sealed class _003C_003Ec__DisplayClass497_0
	{
		public float startSize;

		public ZoomSize zoomSizeObject;

		internal void _003CZoomZoomOnPlayer_003Eb__0()
		{
			ProCamera2D instance = ProCamera2D.Instance;
			ZoomSize zoomSize = zoomSizeObject;
			float num = zoomSize._currentSize * -0.5f;
			float newSize = num + startSize;
			instance.UpdateScreenSize(newSize);
		}
	}

	private sealed class _003C_003Ec__DisplayClass542_0
	{
		public WeaponType weaponToGive;

		internal bool _003CTryGiveWeaponToPlayer_003Eb__0(Equipment equipment)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)equipment != null)
			{
				object obj = equipment._equipmentType - weaponToGive;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass543_0
	{
		public Pickup pickupItem;

		internal float _003CDoPraise_003Eb__0()
		{
			Pickup pickup = pickupItem;
			return pickup.Time;
		}

		internal void _003CDoPraise_003Eb__1(float x)
		{
			Pickup pickup = pickupItem;
			pickup.Time = x;
		}
	}

	private sealed class _003C_003Ec__DisplayClass547_0
	{
		public bool pauseTweens;

		public GameManager _003C_003E4__this;

		public Action onComplete;

		internal void _003CFrameFreeze_003Eb__0()
		{
			PauseSystem._paused = false;
			if (pauseTweens && "DefaultGameTweenId" != null)
			{
				float optionalFloat = default(float);
				object optionalObj = default(object);
				object[] optionalArray = default(object[]);
				int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Play, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)"DefaultGameTweenId", false, optionalFloat, optionalObj, optionalArray);
			}
			GameManager gameManager = _003C_003E4__this;
			gameManager._003CFreezingFrame_003Ek__BackingField = false;
			Action action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v153.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass565_0
	{
		public WeaponType type;

		internal bool _003CDebugCoopShowcase_003Eb__3(KeyValuePair<WeaponType, List<WeaponData>> x)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Expected O, but got Unknown
			object obj = x - type;
			return obj == null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass619_0
	{
		public VampireSurvivors.Objects.Characters.CharacterController character;

		internal void _003CSetPlayersInvulForMillisecondsAndRestoreTints_003Eb__0()
		{
			character.RestoreTint();
		}
	}

	private sealed class _003C_003Ec__DisplayClass644_0
	{
		public Light2D l2d;

		internal float _003CAddLightsToPool_003Eb__0()
		{
			Light2D light2D = l2d;
			return light2D.m_PointLightOuterRadius;
		}

		internal void _003CAddLightsToPool_003Eb__1(float x)
		{
			Light2D light2D = l2d;
			light2D.m_PointLightOuterRadius = x;
		}

		internal float _003CAddLightsToPool_003Eb__2()
		{
			Light2D light2D = l2d;
			return light2D.m_Intensity;
		}

		internal void _003CAddLightsToPool_003Eb__3(float x)
		{
			Light2D light2D = l2d;
			light2D.m_Intensity = x;
		}
	}

	private sealed class _003C_003Ec__DisplayClass712_0
	{
		public float scale;
	}

	private sealed class _003C_003Ec__DisplayClass712_1
	{
		public SpriteRenderer s;

		public int index;

		public _003C_003Ec__DisplayClass712_0 CS_0024_003C_003E8__locals1;

		public TweenCallback _003C_003E9__2;

		internal void _003CDoRemovePowersEffect_003Eb__0()
		{
			s.enabled = true;
		}

		internal unsafe void _003CDoRemovePowersEffect_003Eb__1()
		{
			//IL_002b: Expected O, but got Ref
			Transform transform = s.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, (Vector3)(&obj), 0.5f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			float num = (float)index + 1100f;
			float delay = num * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					s.enabled = false;
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CDoRemovePowersEffect_003Eb__2()
		{
			s.enabled = false;
		}
	}

	private sealed class _003CFirePlayerXpUpdatedFromOnlineRoutine_003Ed__608(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00f1: Expected I4, but got O
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				OnlineStageManager instance = OnlineStageManager._instance;
				if ((object)OnlineStageManager._instance != null)
				{
					PlayerInfo playerInfo = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
					if ((object)playerInfo != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
						if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
						{
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
						if ((object)_003C_003E4__this != null)
						{
							_003C_003E4__this.FirePlayerXpUpdated();
							return false;
						}
					}
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

	private sealed class _003CInitRemoteCharacterWhenGameplayLoaded_003Ed__574(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		public GameObject characterInstance;

		public CharacterType characterType;

		private PlayerInfo _003CmyPlayerInfo_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_001c: Expected I4, but got I8
			//IL_006f: Expected I4, but got I8
			//IL_0662: Expected I4, but got O
			//IL_01e2: Expected O, but got I4
			//IL_03ab: Expected O, but got I4
			//IL_03ed: Expected O, but got Ref
			//IL_02a4: Expected O, but got I
			//IL_02d3: Expected F4, but got I4
			//IL_02e9: Expected O, but got I4
			//IL_043e: Expected O, but got Ref
			//IL_0460: Expected O, but got Ref
			//IL_0478: Expected native int or pointer, but got O
			//IL_0490: Expected O, but got Ref
			//IL_04cb: Expected O, but got Ref
			//IL_04de: Expected I4, but got O
			//IL_04f5: Expected O, but got Ref
			//IL_0525: Expected O, but got Ref
			//IL_053d: Expected native int or pointer, but got O
			//IL_0555: Expected O, but got Ref
			//IL_05f1: Expected O, but got I4
			object obj2 = default(object);
			object obj = (object)(&obj2);
			GameManager gameManager = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)OnlineStageManager._instance == null)
				{
					goto IL_0654;
				}
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				_003CmyPlayerInfo_003E5__2 = myPlayerInfo;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0646;
				}
				_003C_003E1__state = -1;
			}
			PlayerInfo playerInfo = _003CmyPlayerInfo_003E5__2;
			VampireSurvivors.Objects.Characters.CharacterController component;
			if ((object)_003CmyPlayerInfo_003E5__2 != null)
			{
				if (!playerInfo._gameplayLoaded)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				if ((object)_003C_003E4__this != null)
				{
					ArcadeSprite arcadeSprite = _003C_003E4__this.InitPlayerPhysics(characterInstance);
					if ((object)characterInstance != null)
					{
						component = characterInstance.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
						if ((object)component != null)
						{
							int num = component._PlayerIndex >> 31;
							int num2 = num & -2;
							int playerIndex = num2 + 1;
							bool flag = default(bool);
							component.InitCharacter(characterType, playerIndex, asRemote: true, flag);
							_003C_003E4__this.ApplyPurchasedPowerUpData(component);
							_003C_003E4__this.ApplyAscensionPoints(component);
							component.ApplySkinModifiers();
							bool flag2 = component._PlayerIndex >= 0;
							int num3 = 1;
							object obj3 = 0;
							if (flag2)
							{
								goto IL_02ee;
							}
							GameSessionData gameSessionData = gameManager._gameSessionData;
							if (gameManager._gameSessionData != null)
							{
								VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
								if ((object)gameSessionData._activeCharacter != null)
								{
									component._level = activeCharacter._level;
									_003C_003E4__this.InitFollower(component);
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									_ = 0;
									_ = 1065353216;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
									soundConfig.Volume = (float?)(object)0;
									soundConfig.Rate = 0.5f;
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, flag ? 1 : 0);
									num3 = 1;
									obj3 = 0;
									goto IL_02ee;
								}
							}
						}
					}
				}
			}
			goto IL_0654;
			IL_0654:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_02ee:
			if (gameManager._characters != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
				if (component._PlayerIndex < 0)
				{
					CharacterADControl deficiencyControl = component._deficiencyControl;
					if (component._deficiencyControl == null)
					{
						goto IL_0654;
					}
					if (deficiencyControl._003CLevelupType_003Ek__BackingField != LevelupType.ManualSelection)
					{
						goto IL_03b0;
					}
				}
				_003C_003E4__this.AddMainCharacter(component);
				object obj3 = 0;
				goto IL_03b0;
			}
			goto IL_0654;
			IL_03b0:
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = gameManager._characters;
			if (gameManager._characters != null)
			{
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				_ = characters._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = gameManager._mainCharacters;
				if (gameManager._mainCharacters != null)
				{
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					_ = mainCharacters._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					_ = 0;
					_ = 0;
					object arg = default(object);
					object arg2 = default(object);
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg, arg2));
					System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
					_ = 0;
					string text = string.FormatHelper((IFormatProvider)null, "Adding Remote Char: All Count:{0}. Main Chars Count: {1}", args);
					object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					_ = component._characterType;
					object arg3 = (CharacterType)obj6;
					object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					int num4 = component._PlayerIndex >> 31;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					_ = 0;
					_ = 0;
					object arg4 = default(object);
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg3, arg4));
					System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
					_ = 0;
					string text2 = string.FormatHelper((IFormatProvider)null, " Type: {0}. Follower: {1}", args2);
					string message = text + text2;
					Debug.Log(message);
					MainGamePage mainGamePage = gameManager._003CMainUI_003Ek__BackingField;
					if ((object)gameManager._003CMainUI_003Ek__BackingField != null)
					{
						Dictionary<VampireSurvivors.Objects.Characters.CharacterController, GameObject> uiPanels = mainGamePage._uiPanels;
						if (mainGamePage._uiPanels != null)
						{
							object obj8 = uiPanels._count - uiPanels._freeCount;
							if ((nint)obj8 > 0)
							{
								if ((object)gameManager._003CMainUI_003Ek__BackingField == null)
								{
									goto IL_0654;
								}
								gameManager._003CMainUI_003Ek__BackingField.ReinitializeEquipment();
							}
							goto IL_0646;
						}
					}
				}
			}
			goto IL_0654;
			IL_0646:
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

	private sealed class _003CReenableBrokenShadowCasterGroup2DsBecauseUnity_003Ed__642(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00c8: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.SetSpecialStageLightingEnabled((byte)_003C_003E1__state != 0);
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

	private sealed class _003CRemoveManualCameraControl_003Ed__455(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		private VampireSurvivors.Objects.Characters.CharacterController _003CmyPlayer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00e7: Expected I4, but got I8
			//IL_017c: Expected I4, but got O
			GameManager gameManager = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)OnlineStageManager._instance != null)
				{
					PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
					if ((object)myPlayerInfo != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
						_003CmyPlayer_003E5__2 = characterController;
						if ((object)_003CmyPlayer_003E5__2 != null)
						{
							_003CmyPlayer_003E5__2.UpdateBoxCollider();
							goto IL_019a;
						}
					}
				}
				goto IL_016e;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0168;
			}
			_003C_003E1__state = -1;
			goto IL_019a;
			IL_019a:
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = _003CmyPlayer_003E5__2;
			if ((object)_003CmyPlayer_003E5__2 != null && (object)_003C_003E4__this != null)
			{
				if (_003C_003E4__this.IsAnyPlayerOutsideBounds(characterController2._worldBoxCollider))
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				gameManager._003CManualCameraTargetControl_003Ek__BackingField = null;
				goto IL_0168;
			}
			goto IL_016e;
			IL_016e:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0168:
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

	private sealed class _003CSignalGameplayLoaded_003Ed__584(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_00f7: Expected I4, but got O
			GameManager gameManager = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 1f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					gameManager._signalGameplayLoadedRoutine = null;
					if ((object)OnlineStageManager._instance != null)
					{
						PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
						if ((object)myPlayerInfo != null)
						{
							myPlayerInfo._gameplayLoaded = true;
							goto IL_0123;
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_0123;
			IL_0123:
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

	private sealed class _003CSnapshotRecap_003Ed__449(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		public Action onComplete;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_00fa: Expected O, but got I4
			GameManager gameManager = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				object obj = Application.isBatchMode;
				if (obj == null)
				{
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_011a;
				}
				_003C_003E1__state = -1;
				IntPtr gcHandlePtr = ScreenCapture.CaptureScreenshotAsTexture_Injected(1, ScreenCapture.StereoScreenCaptureMode.LeftEye);
				Texture2D recapTex = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Texture2D>(gcHandlePtr);
				gameManager._recapTex = recapTex;
				((UnityEngine.Object)gameManager._recapTex).SetName("RecapPageRenderTexture");
			}
			Action action = onComplete;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v269.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			goto IL_011a;
			IL_011a:
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

	private sealed class _003CWaitForAllCharactersToBeLoaded_003Ed__578(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GameManager _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_002e: Expected I4, but got I8
			//IL_011b: Expected I4, but got O
			if (_003C_003E1__state <= 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					int nonFollowerMainCharacterCount = _003C_003E4__this.GetNonFollowerMainCharacterCount();
					if ((object)OnlineStageManager._instance != null)
					{
						int numberOfConnectedPlayers = OnlineStageManager._instance.NumberOfConnectedPlayers;
						if (nonFollowerMainCharacterCount != numberOfConnectedPlayers)
						{
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
						_003C_003E4__this.UpdateMainPlayersEligibleForLevelUp();
						_003C_003E4__this.PostStageInit();
						if ((object)OnlineStageManager._instance != null)
						{
							PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
							if ((object)myPlayerInfo != null)
							{
								myPlayerInfo._stageInitialized = true;
								return false;
							}
						}
					}
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

	private sealed class _003CWaitForEveryoneToResetGameSession_003Ed__446(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		private bool _003CeveryoneResetSession_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0064: Expected I4, but got I8
			//IL_009e: Expected O, but got Ref
			//IL_00a3: Expected I, but got O
			//IL_00e3: Expected I, but got O
			//IL_0113: Expected I, but got O
			//IL_013f: Expected I, but got O
			//IL_01b5: Expected I, but got O
			//IL_01e8: Expected I, but got O
			//IL_024e: Expected I, but got O
			//IL_02b4: Expected I, but got O
			//IL_036c: Expected O, but got Ref
			//IL_031a: Expected I, but got O
			//IL_03c7: Expected I, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003CeveryoneResetSession_003E5__2 = false;
				Debug.Log("<color=green>Starting To Wait For Everyone To Reset Session</color>");
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_046c;
				}
				_003C_003E1__state = -1;
			}
			if (!_003CeveryoneResetSession_003E5__2)
			{
				_003CeveryoneResetSession_003E5__2 = true;
				IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj2 = default(object);
				object obj = (object)(&obj2);
				nint num = unchecked((nint)null);
				object obj3 = default(object);
				PlayerInfo playerInfo = default(PlayerInfo);
				CharacterType characterType = default(CharacterType);
				object obj5 = default(object);
				object obj6 = default(object);
				object obj7 = default(object);
				object obj8 = default(object);
				object obj9 = default(object);
				object obj10 = default(object);
				object obj11 = default(object);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				while (true)
				{
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj3 == null)
						{
							break;
						}
						bool flag = obj2 == null;
						num = unchecked((nint)null);
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99E70");
							num = (nint)typeof(UnityEngine.Object);
							if ((object)playerInfo == null)
							{
								continue;
							}
							bool flag2 = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
							num = (nint)typeof(UnityEngine.Object);
							if (flag2)
							{
								continue;
							}
							object[] array = new object[4];
							VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
							if ((object)characterController != null)
							{
								object obj4 = characterType;
								bool flag3 = array == null;
								num = (nint)typeof(CharacterType);
								if (!flag3)
								{
									if (obj4 != null)
									{
										nint num2 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										if (obj5 == null)
										{
											ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
											throw ex;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									if (obj6 != null)
									{
										nint num3 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										if (obj7 == null)
										{
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									if (obj8 != null)
									{
										nint num4 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										if (obj9 == null)
										{
											ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
											throw ex3;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									if (obj10 != null)
									{
										nint num5 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										if (obj11 == null)
										{
											ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
											throw ex4;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									System.ParamsArray paramsArray = new System.ParamsArray(array);
									string message = string.FormatHelper((IFormatProvider)null, "<color=green>Player {0}. SceneLoaded: {1}. GameplayLoaded: {2}. StageInit: {3}</color>", (System.ParamsArray)(&paramsArray2));
									Debug.Log(message);
									bool flag4 = !playerInfo._sceneLoaded;
									nint num6 = ((flag4 & _003CeveryoneResetSession_003E5__2) ? 1 : 0);
									_003CeveryoneResetSession_003E5__2 = (byte)num6 != 0;
									bool flag5 = playerInfo._gameplayLoaded;
									nint num7 = unchecked((nint)null);
									if (!flag5)
									{
										num7 = num6;
									}
									_003CeveryoneResetSession_003E5__2 = (byte)num7 != 0;
									bool flag6 = !playerInfo._stageInitialized;
									bool flag7 = (byte)((flag6 ? 1 : 0) & num7) != 0;
									_003CeveryoneResetSession_003E5__2 = flag7;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (!_003CeveryoneResetSession_003E5__2)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			Debug.Log("<color=green>Sending Reloading Gameplay Scene</color>");
			OnlineStageManager instance = OnlineStageManager._instance;
			Action action = OnlineStageManager._instance.ReloadCurrentScene;
			bool flag8 = instance._sync.SendCommand(action, MessageTarget.All);
			goto IL_046c;
			IL_046c:
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

	public const float BASE_PLAYER_PX_SPEED = 0.82500005f;

	public const float BASE_ENEMY_SPEED = 0.231f;

	public const float BASE_PROJECTILE_SPEED = 1.6500001f;

	public const int BASE_GOLD_MULTIPLIER = 1;

	public const float BASE_ENEMY_HEALTH_MULTIPLIER = 1f;

	public const float BASE_EXPERIENCE_MULTIPLIER = 1f;

	public const float BASE_MARKUP = 0.1f;

	public const float PPU = 100f;

	public const float UNITY_SCALE = 0.01f;

	public const double INVERSE_UNITY_SCALE = 100.0;

	public const float PIXEL_SCALE = 1f;

	public const float R_PIXEL_SCALE = 1f;

	public const float PPU_MUL = 0.01f;

	public const float MS_PER_SEC = 1000f;

	public const float MS_PER_SEC_MUL = 0.001f;

	public const int MAX_GEMS = 400;

	public const int MAX_COINS = 200;

	public const int MAX_REDCOINBAGS = 200;

	public const int MAX_FROZENSOULS = 200;

	public const int FIRST_ASCENSION_POINT_BONUS = 25;

	public const int SECOND_ASCENSION_POINT_BONUS = 25;

	public const int THIRD_ASCENSION_POINT_BONUS = 25;

	public const int MIN_SORTING_ORDER = -32768;

	public const int MAX_SORTING_ORDER = 32767;

	public const int Z_DAMAGE_NUMBER = 22767;

	public const int Z_IN_GAME_UI = 31767;

	public const string DEFAULT_GAME_TWEEN_ID = "DefaultGameTweenId";

	public const string PAUSED_GAME_TWEEN_ID = "PausedGameTweenId";

	public static float PlayerPxSpeed = 0.82500005f;

	public static float EnemySpeed = 0.231f;

	public static float ProjectileSpeed = 1.6500001f;

	public static float GoldMultiplier = 1f;

	public static float EnemyHealthMultiplier = 1f;

	public static float ExperienceMultiplier = 1f;

	public static float BaseMarkup = 0.1f;

	public static float SfxVolumeFactor = 1f;

	public static float DifficultyAdjustmentEnemyHPMultiplier = 1f;

	public static float DifficultyAdjustmentEnemyDamageMultiplier = 1f;

	public static uint Tflag = 0u;

	public static DamageNumberManager DamageNumberManager;

	private GameObject _Preloader;

	private MagnetZone _MagnetZonePrefab;

	private TouchControlCustomiser _TouchJoystick;

	private WhiteHandManager _WhiteHandManager;

	private Light2D _GlobalLight;

	private Light2D _BackgroundLight;

	private Light2D _Spotlight2D;

	private Light2D _Light2DPrefab;

	private Light2D _Light2DForTilemapPrefab;

	private Renderer2DData _Renderer2DData;

	private Canvas _GameCanvas;

	private SignalBus _signalBus;

	private DiContainer _diContainer;

	private PlayerOptions _playerOptions;

	private AssetReferenceLibrary _assetReferenceLibrary;

	private LootManager _lootManager;

	private WeaponsFacade _weaponsFacade;

	private AccessoriesFacade _accessoriesFacade;

	private Stage _stage;

	private AdventureManager _adventureManager;

	private GameplayLoader _gameplayLoader;

	private ShopFactory _shopFactory;

	private ParticleManager _particleManager;

	private GameSessionData _gameSessionData;

	private LevelUpFactory _levelUpFactory;

	private CharacterFactory _characterFactory;

	private TreasureFactory _treasureFactory;

	private LimitBreakManager _limitBreakManager;

	private DataManager _dataManager;

	private PlayerStats _playerStats;

	private ArcanaManager _arcanaManager;

	private PhysicsManager _physicsManager;

	private ExplosionManager _explosionManager;

	private EggManager _eggManager;

	private ProjectileFactory _projectileFactory;

	private GameplayCheatCodeManager _gameplayCheatCodeManager;

	private GizmoManager _gizmoManager;

	private CanvasGroup _touchJoystickCanvasGroup;

	private SpellsManager _spellsManager;

	private AchievementManager _achievementManager;

	private MultiplayerManager _multiplayer;

	private FontFactory _fontFactory;

	private int _defangIndex;

	private List<float> _defangChancesArray;

	private CommonVfxManager _commonVfxManager;

	private ParticleSystem _pickupVfx;

	private ParticleSystem _jewelPickupVfx;

	private Transform _blittersParent;

	private bool _canRunTickerTimer = true;

	private float _secondsTickerTimer;

	private int _updateTicks;

	private const int UpdateFreq = 4;

	private float _targetTick = 1f;

	private float? _preZoomOrthoSize;

	private Timer _stopTimeTimer;

	public List<PickupToSpawn> _gemsToSpawn;

	public List<PickupToSpawn> _coinsToSpawn;

	public List<PickupToSpawn> _redCoinBagsToSpawn;

	public List<PickupToSpawn> _frozenSoulsToSpawn;

	private bool _isPaused;

	private bool _isGameRunning;

	private readonly List<UiTransition> _queuedUiTransitions;

	private List<Pickup> _stagePickups;

	private List<MapToken> _mapTokens;

	private Transform _candleLightsParent;

	private Queue<Light2D> _candleLights;

	private Dictionary<Destructible, Light2D> _candleLightsMapping;

	private ObjectPool _gemPool;

	private HashSet<Pickup> _gems;

	private ObjectPool _coinPool;

	private HashSet<Coin> _coins;

	private float _defaultCoinValue;

	private ObjectPool _redCoinBagPool;

	private HashSet<CoinBag1> _redCoinBags;

	private float _defaultRedCoinBagValue;

	private ObjectPool _frozenSoulPool;

	private HashSet<Pickup_Bonus_FrozenSoul> _frozenSouls;

	private float _defaultFrozenSoulValue;

	private TilingBackground _bgMan;

	private Timer _safetyPause;

	private bool _restartingGameScene;

	private bool _inGameOverState;

	private bool _inOnlineErrorState;

	private bool _hideLoadingVisuals;

	private Texture2D _recapTex;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _characters;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _mainCharacters;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _charactersLevelingUp;

	private Coroutine _signalGameplayLoadedRoutine;

	private bool _waitingForLevelUp;

	private List<int> _coopChestRandomness;

	private int _coopChestRandomnessIndex;

	private Transform _coopCameraTarget;

	private Action _003CManualCameraTargetControl_003Ek__BackingField;

	private GoldFingerManager _003CGoldFingerManager_003Ek__BackingField;

	private bool _003CHasGfBonus_003Ek__BackingField;

	private Coherence.Log.Logger _logger;

	private EnemyType _latestKilledEnemyThatCanBeFollowerType;

	private EnemyData _latestKilledEnemyThatCanBeFollowerData;

	private bool _latestKilledEnemyWasCartRider;

	private int _nextLevelUpAtLevel;

	private int _batchedOnlineLevelUpSkips;

	private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<FollowerEnemy_CharacterController>> m_EnemyFollowerPools;

	private Dictionary<VampireSurvivors.Objects.Characters.CharacterController, int> m_NumAliveEnemyFollowers;

	private OpenTreasurePage _003COpenTreasurePage_003Ek__BackingField;

	private ConnectionException _003CConnectionException_003Ek__BackingField;

	private bool _003CIsInPauseGameState_003Ek__BackingField;

	private bool _003CCanInterrupt_003Ek__BackingField;

	private bool _003CCanPause_003Ek__BackingField;

	private bool _003CFreezingFrame_003Ek__BackingField;

	private VampireSurvivors.Objects.Characters.CharacterController _003CPausingPlayer_003Ek__BackingField;

	[NonSerialized]
	public bool BlockConnectionErrorPopups;

	private bool _003CStartedAsOnlineMultiplayerRun_003Ek__BackingField;

	private VampireSurvivors.Objects.Characters.CharacterController _003CChestWinnerPlayer_003Ek__BackingField;

	private int _003CSurvarotsCardsToShow_003Ek__BackingField;

	private bool _003CCanShowGameOverRewardAd_003Ek__BackingField;

	private bool _003CCanShowArcadeReviveButton_003Ek__BackingField;

	private string _003CWeaponSelectionType_003Ek__BackingField;

	private ArcanaUiType _003CArcanaUiType_003Ek__BackingField;

	private Transform _003CWorldSpritesTransform_003Ek__BackingField;

	private Rect? _003CHardBounds_003Ek__BackingField;

	private MerchantInventoryType _003CMerchantInventory_003Ek__BackingField;

	private PickupCustomMerchant _003CCurrentCustomMerchant_003Ek__BackingField;

	private bool _003CIsTimeStopped_003Ek__BackingField;

	private bool _003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField;

	private bool _003CIsAllDefanged_003Ek__BackingField;

	private VampireSurvivors.Objects.Characters.CharacterController _003CEnterWeaponSelectionPlayer_003Ek__BackingField;

	private VampireSurvivors.Objects.Characters.CharacterController _003CEnterBonusSelectionPlayer_003Ek__BackingField;

	private ItemType _003CCurrentFoundRelic_003Ek__BackingField;

	private bool _003CIsHalloween_003Ek__BackingField;

	public CoopConfig CoopConfig;

	public PhysicsGroup Enemies;

	public PhysicsGroup EnemiesThatIgnoreProjectiles;

	private GameEquipmentPanel _003CGameEquipmentPanel_003Ek__BackingField;

	private MainGamePage _003CMainUI_003Ek__BackingField;

	private float _003CSurvivedSeconds_003Ek__BackingField;

	private List<Action<float>> _003COnCoinPickup_003Ek__BackingField;

	private UiTransition _latestUITransition;

	private List<bool> _cachedCharacterValidity;

	private int _003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _followerCache;

	private float _bossHealthMultiplier;

	private float _bossAttacksTriggerChance;

	public float? PreZoomOrthoSize => _preZoomOrthoSize;

	public Transform CoopCameraTarget => _coopCameraTarget;

	public Action ManualCameraTargetControl
	{
		get
		{
			return _003CManualCameraTargetControl_003Ek__BackingField;
		}
		set
		{
			_003CManualCameraTargetControl_003Ek__BackingField = value;
		}
	}

	public GoldFingerManager GoldFingerManager
	{
		get
		{
			return _003CGoldFingerManager_003Ek__BackingField;
		}
		set
		{
			_003CGoldFingerManager_003Ek__BackingField = value;
		}
	}

	public bool HasGfBonus
	{
		get
		{
			return _003CHasGfBonus_003Ek__BackingField;
		}
		set
		{
			_003CHasGfBonus_003Ek__BackingField = value;
		}
	}

	public Stage Stage => _stage;

	public ArcanaManager ArcanaManager => _arcanaManager;

	public PhysicsManager PhysicsManager => _physicsManager;

	public Renderer2DData Renderer2DData => _Renderer2DData;

	public DataManager DataManager => _dataManager;

	public GameSessionData GameSessionData => _gameSessionData;

	public LevelUpFactory LevelUpFactory => _levelUpFactory;

	public PlayerOptions PlayerOptions => _playerOptions;

	public AssetReferenceLibrary AssetReferenceLibrary => _assetReferenceLibrary;

	public EggManager EggManager => _eggManager;

	public TreasureFactory TreasureFactory => _treasureFactory;

	public SignalBus SignalBus => _signalBus;

	public DiContainer DiContainer => _diContainer;

	public TilingBackground BGMan => _bgMan;

	public ProjectileFactory ProjectileFactory => _projectileFactory;

	public SpellsManager SpellsManager => _spellsManager;

	public GizmoManager GizmoManager => _gizmoManager;

	public AchievementManager AchievementManager => _achievementManager;

	public WeaponsFacade WeaponsFacade => _weaponsFacade;

	public AccessoriesFacade AccessoriesFacade => _accessoriesFacade;

	public AdventureManager AdventureManager => _adventureManager;

	public ShopFactory ShopFactory => _shopFactory;

	public FontFactory FontFactory => _fontFactory;

	public CharacterFactory CharacterFactory => _characterFactory;

	public OpenTreasurePage OpenTreasurePage
	{
		get
		{
			return _003COpenTreasurePage_003Ek__BackingField;
		}
		set
		{
			_003COpenTreasurePage_003Ek__BackingField = value;
		}
	}

	public ConnectionException ConnectionException
	{
		get
		{
			return _003CConnectionException_003Ek__BackingField;
		}
		private set
		{
			_003CConnectionException_003Ek__BackingField = value;
		}
	}

	public ParticleManager ParticleManager => _particleManager;

	public Light2D Spotlight2D => _Spotlight2D;

	public bool IsPaused => _isPaused;

	public bool IsInPauseGameState
	{
		get
		{
			return _003CIsInPauseGameState_003Ek__BackingField;
		}
		set
		{
			_003CIsInPauseGameState_003Ek__BackingField = value;
		}
	}

	public bool RestartingGameScene
	{
		get
		{
			return _restartingGameScene;
		}
		set
		{
			_restartingGameScene = value;
		}
	}

	public bool InGameOverState
	{
		get
		{
			return _inGameOverState;
		}
		set
		{
			_inGameOverState = value;
		}
	}

	public bool InOnlineErrorState
	{
		get
		{
			return _inOnlineErrorState;
		}
		set
		{
			_inOnlineErrorState = value;
		}
	}

	public bool HideLoadingVisuals
	{
		get
		{
			return _hideLoadingVisuals;
		}
		set
		{
			_hideLoadingVisuals = value;
		}
	}

	public Texture2D RecapTex
	{
		get
		{
			return _recapTex;
		}
		set
		{
			_recapTex = value;
		}
	}

	public bool CanInterrupt
	{
		get
		{
			return _003CCanInterrupt_003Ek__BackingField;
		}
		set
		{
			_003CCanInterrupt_003Ek__BackingField = value;
		}
	}

	public bool CanPause
	{
		get
		{
			return _003CCanPause_003Ek__BackingField;
		}
		set
		{
			_003CCanPause_003Ek__BackingField = value;
		}
	}

	public bool FreezingFrame
	{
		get
		{
			return _003CFreezingFrame_003Ek__BackingField;
		}
		set
		{
			_003CFreezingFrame_003Ek__BackingField = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController PausingPlayer
	{
		get
		{
			return _003CPausingPlayer_003Ek__BackingField;
		}
		set
		{
			_003CPausingPlayer_003Ek__BackingField = value;
		}
	}

	public float BossAttacksTriggerChance
	{
		get
		{
			return _bossAttacksTriggerChance;
		}
		set
		{
			if (_bossAttacksTriggerChance > value)
			{
				_bossAttacksTriggerChance = value;
			}
		}
	}

	public float BossHealthMultiplier
	{
		get
		{
			return _bossHealthMultiplier;
		}
		set
		{
			if (_bossHealthMultiplier > value)
			{
				_bossHealthMultiplier = value;
			}
		}
	}

	public bool StartedAsOnlineMultiplayerRun
	{
		get
		{
			return _003CStartedAsOnlineMultiplayerRun_003Ek__BackingField;
		}
		set
		{
			_003CStartedAsOnlineMultiplayerRun_003Ek__BackingField = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController ChestWinnerPlayer
	{
		get
		{
			return _003CChestWinnerPlayer_003Ek__BackingField;
		}
		set
		{
			_003CChestWinnerPlayer_003Ek__BackingField = value;
		}
	}

	public int SurvarotsCardsToShow
	{
		get
		{
			return _003CSurvarotsCardsToShow_003Ek__BackingField;
		}
		set
		{
			_003CSurvarotsCardsToShow_003Ek__BackingField = value;
		}
	}

	public bool CanShowGameOverRewardAd
	{
		get
		{
			return _003CCanShowGameOverRewardAd_003Ek__BackingField;
		}
		set
		{
			_003CCanShowGameOverRewardAd_003Ek__BackingField = value;
		}
	}

	public bool CanShowArcadeReviveButton
	{
		get
		{
			return _003CCanShowArcadeReviveButton_003Ek__BackingField;
		}
		set
		{
			_003CCanShowArcadeReviveButton_003Ek__BackingField = value;
		}
	}

	public string WeaponSelectionType
	{
		get
		{
			return _003CWeaponSelectionType_003Ek__BackingField;
		}
		set
		{
			_003CWeaponSelectionType_003Ek__BackingField = value;
		}
	}

	public ArcanaUiType ArcanaUiType
	{
		get
		{
			return _003CArcanaUiType_003Ek__BackingField;
		}
		set
		{
			_003CArcanaUiType_003Ek__BackingField = value;
		}
	}

	public Transform WorldSpritesTransform
	{
		get
		{
			return _003CWorldSpritesTransform_003Ek__BackingField;
		}
		private set
		{
			_003CWorldSpritesTransform_003Ek__BackingField = value;
		}
	}

	public Rect? HardBounds
	{
		get
		{
			//IL_0010: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+378]");
			GameManager gameManager = (GameManager)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+388]");
			((UnityEngine.Object)this).m_CachedPtr = (IntPtr)0;
			return (Rect?)this;
		}
		set
		{
			_003CHardBounds_003Ek__BackingField = value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ rdx (System.Nullable`1<UnityEngine.Rect>)+10]");
			_ = 0;
		}
	}

	public List<Pickup> StagePickups => _stagePickups;

	public List<MapToken> MapTokens => _mapTokens;

	public LootManager LootManager => _lootManager;

	public HashSet<Pickup> Gems => _gems;

	public HashSet<Coin> Coins => _coins;

	public HashSet<CoinBag1> RedCoinBags => _redCoinBags;

	public HashSet<Pickup_Bonus_FrozenSoul> FrozenSouls => _frozenSouls;

	public ParticleSystem PickupVfx => _pickupVfx;

	public ParticleSystem JewelPickupVfx => _jewelPickupVfx;

	public MerchantInventoryType MerchantInventory
	{
		get
		{
			return _003CMerchantInventory_003Ek__BackingField;
		}
		set
		{
			_003CMerchantInventory_003Ek__BackingField = value;
		}
	}

	public PickupCustomMerchant CurrentCustomMerchant
	{
		get
		{
			return _003CCurrentCustomMerchant_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentCustomMerchant_003Ek__BackingField = value;
		}
	}

	public bool IsTimeStopped
	{
		get
		{
			return _003CIsTimeStopped_003Ek__BackingField;
		}
		set
		{
			_003CIsTimeStopped_003Ek__BackingField = value;
		}
	}

	public bool IgnoreMovementFreezeFromTimeStop
	{
		get
		{
			return _003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField;
		}
		set
		{
			_003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField = value;
		}
	}

	public bool IsAllDefanged
	{
		get
		{
			return _003CIsAllDefanged_003Ek__BackingField;
		}
		set
		{
			_003CIsAllDefanged_003Ek__BackingField = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController EnterWeaponSelectionPlayer
	{
		get
		{
			return _003CEnterWeaponSelectionPlayer_003Ek__BackingField;
		}
		set
		{
			_003CEnterWeaponSelectionPlayer_003Ek__BackingField = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController EnterBonusSelectionPlayer
	{
		get
		{
			return _003CEnterBonusSelectionPlayer_003Ek__BackingField;
		}
		private set
		{
			_003CEnterBonusSelectionPlayer_003Ek__BackingField = value;
		}
	}

	public ItemType CurrentFoundRelic
	{
		get
		{
			return _003CCurrentFoundRelic_003Ek__BackingField;
		}
		set
		{
			_003CCurrentFoundRelic_003Ek__BackingField = value;
		}
	}

	public bool IsHalloween
	{
		get
		{
			return _003CIsHalloween_003Ek__BackingField;
		}
		set
		{
			_003CIsHalloween_003Ek__BackingField = value;
		}
	}

	public bool IsLocalMultiplayer
	{
		get
		{
			//IL_00ca: Expected I4, but got O
			//IL_003c: Expected O, but got I4
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected I4, but got Unknown
			if (_multiplayer != null)
			{
				int localPlayerCount = _multiplayer.GetLocalPlayerCount();
				object obj = localPlayerCount - 1;
				int num = localPlayerCount ^ 1;
				int num2 = localPlayerCount ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				bool flag3 = obj == null;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool IsOnlineMultiplayer
	{
		get
		{
			//IL_0041: Expected I4, but got O
			if (_multiplayer != null)
			{
				return _multiplayer.IsOnlineMultiplayer;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool IsMultiplayer
	{
		get
		{
			//IL_0076: Expected I4, but got O
			if (_multiplayer != null)
			{
				int playerCount = _multiplayer.GetPlayerCount();
				if (playerCount > 1)
				{
					return true;
				}
				return _multiplayer.IsOnlineMultiplayer;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool IsStageHost
	{
		get
		{
			//IL_0062: Expected I4, but got O
			OnlineStageManager instance = OnlineStageManager._instance;
			if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				if ((object)OnlineStageManager._instance != null)
				{
					return OnlineStageManager._instance.IsHost;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return true;
		}
	}

	public bool HasMultipleMainCharacters
	{
		get
		{
			//IL_0028: Expected O, but got I4
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected I4, but got Unknown
			if (_mainCharacters == null)
			{
				return false;
			}
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
			object obj = mainCharacters._size - 1;
			int num = mainCharacters._size ^ 1;
			int num2 = mainCharacters._size ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	public List<VampireSurvivors.Objects.Characters.CharacterController> AllPlayers => _characters;

	public List<VampireSurvivors.Objects.Characters.CharacterController> MainPlayers => _mainCharacters;

	public VampireSurvivors.Objects.Characters.CharacterController Player
	{
		get
		{
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null)
			{
				return gameSessionData._activeCharacter;
			}
			return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController PlayerOne
	{
		get
		{
			if (!_multiplayer.IsOnlineMultiplayer)
			{
				if (_characters != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
					if (characters._size > 0)
					{
						if (characters._size > 0)
						{
							VampireSurvivors.Objects.Characters.CharacterController[] items = characters._items;
							return items[0];
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						VampireSurvivors.Objects.Characters.CharacterController result = default(VampireSurvivors.Objects.Characters.CharacterController);
						return result;
					}
				}
			}
			else
			{
				OnlineStageManager instance = OnlineStageManager._instance;
				PlayerInfo playerInfo = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
				if ((object)playerInfo != null && ((UnityEngine.Object)playerInfo).m_CachedPtr != (IntPtr)0)
				{
					return playerInfo.CharacterController;
				}
			}
			return null;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController MyOnlinePlayer
	{
		get
		{
			if (_multiplayer != null)
			{
				if (_multiplayer.IsOnlineMultiplayer)
				{
					if ((object)OnlineStageManager._instance == null)
					{
						goto IL_008a;
					}
					PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
					if ((object)myPlayerInfo != null && ((UnityEngine.Object)myPlayerInfo).m_CachedPtr != (IntPtr)0)
					{
						return myPlayerInfo.CharacterController;
					}
				}
				return null;
			}
			goto IL_008a;
			IL_008a:
			return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
		}
	}

	public PhaserScene scene => ArcadePhysics.s_scene;

	public PhysicsGroup EnemyGroup
	{
		get
		{
			PhysicsManager physicsManager = _physicsManager;
			if (_physicsManager != null)
			{
				return physicsManager._enemyGroup;
			}
			return (PhysicsGroup)(object)new NullReferenceException();
		}
	}

	public PhysicsGroup PlayerGroup
	{
		get
		{
			PhysicsManager physicsManager = _physicsManager;
			if (_physicsManager != null)
			{
				return physicsManager._playerGroup;
			}
			return (PhysicsGroup)(object)new NullReferenceException();
		}
	}

	public PhysicsGroup Destructibles
	{
		get
		{
			PhysicsManager physicsManager = _physicsManager;
			if (_physicsManager != null)
			{
				return physicsManager._destructiblesGroup;
			}
			return (PhysicsGroup)(object)new NullReferenceException();
		}
	}

	public PhysicsGroup PickupGroup
	{
		get
		{
			PhysicsManager physicsManager = _physicsManager;
			if (_physicsManager != null)
			{
				return physicsManager._pickupGroup;
			}
			return (PhysicsGroup)(object)new NullReferenceException();
		}
	}

	public GameEquipmentPanel GameEquipmentPanel
	{
		get
		{
			return _003CGameEquipmentPanel_003Ek__BackingField;
		}
		private set
		{
			_003CGameEquipmentPanel_003Ek__BackingField = value;
		}
	}

	public MainGamePage MainUI
	{
		get
		{
			return _003CMainUI_003Ek__BackingField;
		}
		private set
		{
			_003CMainUI_003Ek__BackingField = value;
		}
	}

	public float SurvivedSeconds
	{
		get
		{
			return _003CSurvivedSeconds_003Ek__BackingField;
		}
		set
		{
			_003CSurvivedSeconds_003Ek__BackingField = value;
		}
	}

	public List<Action<float>> OnCoinPickup
	{
		get
		{
			return _003COnCoinPickup_003Ek__BackingField;
		}
		set
		{
			_003COnCoinPickup_003Ek__BackingField = value;
		}
	}

	public bool IsGameRunning => _isGameRunning;

	public CommonVfxManager CommonVfxManager => _commonVfxManager;

	private ObjectPool GemPool
	{
		get
		{
			ObjectPool gemPool = _gemPool;
			if ((object)_gemPool == null || ((UnityEngine.Object)gemPool).m_CachedPtr == (IntPtr)0)
			{
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField == null)
				{
					return (ObjectPool)(object)new NullReferenceException();
				}
				ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("Gems");
				_gemPool = pool;
			}
			return _gemPool;
		}
	}

	private ObjectPool CoinPool
	{
		get
		{
			ObjectPool coinPool = _coinPool;
			if ((object)_coinPool == null || ((UnityEngine.Object)coinPool).m_CachedPtr == (IntPtr)0)
			{
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField == null)
				{
					return (ObjectPool)(object)new NullReferenceException();
				}
				ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("Coins");
				_coinPool = pool;
			}
			return _coinPool;
		}
	}

	private ObjectPool RedCoinBagPool
	{
		get
		{
			ObjectPool redCoinBagPool = _redCoinBagPool;
			if ((object)_redCoinBagPool == null || ((UnityEngine.Object)redCoinBagPool).m_CachedPtr == (IntPtr)0)
			{
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField == null)
				{
					return (ObjectPool)(object)new NullReferenceException();
				}
				ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("RedCoinBags");
				_redCoinBagPool = pool;
			}
			return _redCoinBagPool;
		}
	}

	private ObjectPool FrozenSoulPool
	{
		get
		{
			ObjectPool frozenSoulPool = _frozenSoulPool;
			if ((object)_frozenSoulPool == null || ((UnityEngine.Object)frozenSoulPool).m_CachedPtr == (IntPtr)0)
			{
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField == null)
				{
					return (ObjectPool)(object)new NullReferenceException();
				}
				ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("FrozenSouls");
				_frozenSoulPool = pool;
			}
			return _frozenSoulPool;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController InteractingPlayer
	{
		get
		{
			//IL_0097: Expected O, but got I
			//IL_0046: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.GameManager)+3F8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.GameManager)+3F8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.GameManager)+3F8]");
					return (VampireSurvivors.Objects.Characters.CharacterController)0;
				}
			}
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null)
			{
				return gameSessionData._activeCharacter;
			}
			return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
		}
	}

	public int FreeRoamCameraTargetWhenDead
	{
		get
		{
			return _003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
		}
		set
		{
			_003CFreeRoamCameraTargetWhenDead_003Ek__BackingField = value;
		}
	}

	public bool IsStageVisuallyInverted()
	{
		//IL_00be: Expected I4, but got O
		Stage stage = _stage;
		if ((object)_stage != null)
		{
			TilingTileset tilingTileset = stage._tilingTileset;
			if ((object)stage._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
			{
				return false;
			}
			Stage stage2 = _stage;
			if ((object)_stage != null)
			{
				TilingTileset tilingTileset2 = stage2._tilingTileset;
				if ((object)stage2._tilingTileset != null)
				{
					return tilingTileset2._visuallyInverted;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void Construct(SignalBus signalBus, DiContainer diContainer, PlayerOptions playerOptions, LootManager lootManager, WeaponsFacade weaponsFacade, Stage stage, GameSessionData gameSessionData, LevelUpFactory levelUpFactory, CharacterFactory characterFactory, AccessoriesFacade accessoriesFacade, DataManager dataManager, PlayerStats playerStats, ArcanaManager arcanaManager, PhysicsManager physicsManager, EggManager egg, LimitBreakManager limitBreakManager, GizmoManager gizmoManager, TreasureFactory treasureFactory, ProjectileFactory projectileFactory, SpellsManager spellsManager, AchievementManager achievementManager, MainGamePage mainGamePage, MultiplayerManager multiplayer, AdventureManager adventureManager, FontFactory fontFactory, AssetReferenceLibrary assetReferenceLibrary, ParticleManager particleManager, ShopFactory shopFactory)
	{
		//IL_0109: Expected O, but got I
		//IL_01c7: Expected O, but got I
		//IL_01eb: Expected O, but got I
		//IL_0304: Expected O, but got I
		//IL_0328: Expected O, but got I
		//IL_041c: Expected O, but got I
		//IL_0440: Expected O, but got I
		//IL_0534: Expected O, but got I
		//IL_0558: Expected O, but got I
		//IL_064c: Expected O, but got I
		//IL_0670: Expected O, but got I
		//IL_0773: Expected O, but got I4
		//IL_0773: Expected O, but got I
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0781: Expected O, but got Unknown
		//IL_0f0d: Expected O, but got I
		//IL_0889: Expected O, but got I4
		//IL_0889: Expected O, but got I
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_0897: Expected O, but got Unknown
		//IL_0f46: Expected O, but got I
		//IL_099f: Expected O, but got I4
		//IL_099f: Expected O, but got I
		//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Expected O, but got Unknown
		//IL_0f7f: Expected O, but got I
		//IL_0ab5: Expected O, but got I4
		//IL_0ab5: Expected O, but got I
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac3: Expected O, but got Unknown
		//IL_0fb8: Expected O, but got I
		//IL_0bcb: Expected O, but got I4
		//IL_0bcb: Expected O, but got I
		//IL_0bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Expected O, but got Unknown
		//IL_0ff1: Expected O, but got I
		//IL_0c55: Expected O, but got I
		//IL_0cb8: Expected O, but got I
		//IL_0d05: Expected O, but got I4
		//IL_0d05: Expected O, but got I
		//IL_0d0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Expected O, but got Unknown
		//IL_102a: Expected O, but got I
		//IL_0e83: Expected O, but got I4
		//IL_0e83: Expected O, but got I
		//IL_0e8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e91: Expected O, but got Unknown
		//IL_1065: Expected O, but got I
		_signalBus = signalBus;
		_diContainer = diContainer;
		_playerOptions = playerOptions;
		_lootManager = (LootManager)(object)characterFactory;
		_weaponsFacade = (WeaponsFacade)(object)accessoriesFacade;
		_accessoriesFacade = (AccessoriesFacade)(object)egg;
		_stage = (Stage)(object)dataManager;
		_gameSessionData = (GameSessionData)(object)playerStats;
		_levelUpFactory = (LevelUpFactory)(object)arcanaManager;
		_characterFactory = (CharacterFactory)(object)physicsManager;
		_dataManager = (DataManager)(object)limitBreakManager;
		_playerStats = (PlayerStats)(object)gizmoManager;
		_arcanaManager = (ArcanaManager)(object)treasureFactory;
		_physicsManager = (PhysicsManager)(object)projectileFactory;
		_eggManager = (EggManager)(object)spellsManager;
		_limitBreakManager = (LimitBreakManager)(object)achievementManager;
		_gizmoManager = (GizmoManager)(object)mainGamePage;
		_treasureFactory = (TreasureFactory)(object)multiplayer;
		_projectileFactory = (ProjectileFactory)(object)adventureManager;
		_spellsManager = (SpellsManager)(object)fontFactory;
		_achievementManager = (AchievementManager)(object)assetReferenceLibrary;
		_003CMainUI_003Ek__BackingField = (MainGamePage)(object)particleManager;
		_multiplayer = (MultiplayerManager)(object)shopFactory;
		IntPtr intPtr = default(IntPtr);
		_adventureManager = (AdventureManager)(nint)intPtr;
		FontFactory fontFactory2 = default(FontFactory);
		_fontFactory = fontFactory2;
		AssetReferenceLibrary assetReferenceLibrary2 = default(AssetReferenceLibrary);
		_assetReferenceLibrary = assetReferenceLibrary2;
		ShopFactory shopFactory2 = default(ShopFactory);
		_shopFactory = shopFactory2;
		ParticleManager particleManager2 = default(ParticleManager);
		_particleManager = particleManager2;
		Action action = InitializeGame;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v556 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.InitializeGameSessionSignal>)obj)._003CSubscribeId_003Eb__0;
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rax_v40 (System.Object)+10]");
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(typeFromHandle, (object)null, (object)0, callback);
		Action action3 = ResetGameSessionCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4420");
		Action<GameplaySignals.AddWeaponToCharacterSignal> action4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB36D0");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rbx_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rbx_v9 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj2 = null;
		Action<object> action5 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.AddWeaponToCharacterSignal>)obj2)._003CSubscribeId_003Eb__0;
		Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v58 (System.Object)+10]");
		signalBus3.SubscribeInternal(typeFromHandle2, (object)null, (object)0, callback);
		Action<GameplaySignals.AddAccessoryToCharacterSignal> action6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB37B0");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1171 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rbx_v13 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rbx_v13 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj3 = null;
		Action<object> action7 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.AddAccessoryToCharacterSignal>)obj3)._003CSubscribeId_003Eb__0;
		Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus4 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v73 (System.Object)+10]");
		signalBus4.SubscribeInternal(typeFromHandle3, (object)null, (object)0, callback);
		Action<GameplaySignals.RemoveWeaponFromCharacterSignal> action8 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3890");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1274 @ rbx_v16 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v17 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v562 @ rbx_v17 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj4 = null;
		Action<object> action9 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.RemoveWeaponFromCharacterSignal>)obj4)._003CSubscribeId_003Eb__0;
		Type typeFromHandle4 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus5 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rax_v88 (System.Object)+10]");
		signalBus5.SubscribeInternal(typeFromHandle4, (object)null, (object)0, callback);
		Action<GameplaySignals.AddHiddenWeaponToCharacterSignal> action10 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3970");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1377 @ rbx_v20 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rbx_v21 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rbx_v21 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj5 = null;
		Action<object> action11 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.AddHiddenWeaponToCharacterSignal>)obj5)._003CSubscribeId_003Eb__0;
		Type typeFromHandle5 = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		SignalBus signalBus6 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v103 (System.Object)+10]");
		signalBus6.SubscribeInternal(typeFromHandle5, (object)null, (object)0, callback);
		Action<GameplaySignals.RemoveHiddenWeaponFromCharacterSignal> action12 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3A50");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1480 @ rbx_v24 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ rbx_v25 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ rbx_v25 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj6 = null;
		Action<object> action13 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.RemoveHiddenWeaponFromCharacterSignal>)obj6)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.RemoveHiddenWeaponFromCharacterSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus7 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v118 (System.Object)+10]");
		Type signalType = default(Type);
		signalBus7.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<GameplaySignals.SetCharacterInvincibilityForMillisSignal> action14 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3B30");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1689 @ rbx_v28 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rbx_v29 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rbx_v29 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj9 = null;
		Action<object> action15 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.SetCharacterInvincibilityForMillisSignal>)obj9)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.SetCharacterInvincibilityForMillisSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj11 = default(object);
		object obj10 = obj11 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus8 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v133 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus8.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action<GameplaySignals.SetCharacterInvincibilityForMillisNonCumulativeSignal> action16 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3C10");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1898 @ rbx_v32 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rbx_v33 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rbx_v33 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj12 = null;
		Action<object> action17 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.SetCharacterInvincibilityForMillisNonCumulativeSignal>)obj12)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.SetCharacterInvincibilityForMillisNonCumulativeSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj14 = default(object);
		object obj13 = obj14 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus9 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v148 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus9.SubscribeInternal(signalType3, (object)null, (object)0, callback);
		Action<GameplaySignals.TimeStopSignal> action18 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3CF0");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2107 @ rbx_v36 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rbx_v37 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rbx_v37 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj15 = null;
		Action<object> action19 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.TimeStopSignal>)obj15)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.TimeStopSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj17 = default(object);
		object obj16 = obj17 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus10 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v163 (System.Object)+10]");
		Type signalType4 = default(Type);
		signalBus10.SubscribeInternal(signalType4, (object)null, (object)0, callback);
		Action<GameplaySignals.ReviveCharacterSignal> action20 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3DD0");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2316 @ rbx_v40 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rbx_v41 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rbx_v41 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj18 = null;
		Action<object> action21 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.ReviveCharacterSignal>)obj18)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.ReviveCharacterSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj20 = default(object);
		object obj19 = obj20 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus11 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rax_v178 (System.Object)+10]");
		Type signalType5 = default(Type);
		signalBus11.SubscribeInternal(signalType5, (object)null, (object)0, callback);
		Action<UISignals.SetVisibleJoysticksSignal> action22 = null;
		((GameManager)(object)action22).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
		((GameManager)(object)_signalBus).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)action22);
		Action<GameplaySignals.SkipLevelUpSignal> action23 = null;
		((GameManager)(object)action23).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2531 @ rbx_v45 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((GameManager)0).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
		}
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rbx_v46 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rbx_v46 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				((GameManager)0).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
			}
		}
		object obj21 = null;
		Action<object> action24 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.SkipLevelUpSignal>)obj21)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.SkipLevelUpSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj23 = default(object);
		object obj22 = obj23 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus12 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rax_v196 (System.Object)+10]");
		Type signalType6 = default(Type);
		signalBus12.SubscribeInternal(signalType6, (object)null, (object)0, callback);
		Action action25 = OnLevelUpCompleted;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8F70");
		Action action26 = OnLevelUpCompleted;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AACCE0");
		Action action27 = OnLevelUpCompleted;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA90F0");
		Action<GameplaySignals.FireEnemyBulletSignal> action28 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3F90");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2757 @ rbx_v52 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rbx_v53 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rbx_v53 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		object obj24 = null;
		Action<object> action29 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.FireEnemyBulletSignal>)obj24)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.FireEnemyBulletSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj26 = default(object);
		object obj25 = obj26 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus13 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v220 (System.Object)+10]");
		Type signalType7 = default(Type);
		signalBus13.SubscribeInternal(signalType7, (object)null, (object)0, callback);
		List<Action<float>> list = new List<Action<float>>();
		_003COnCoinPickup_003Ek__BackingField = list;
		GM.Core = this;
	}

	private void Awake()
	{
		//IL_00c3: Expected O, but got I
		Coherence.Log.Logger logger = Log.GetLogger<GameManager>();
		_logger = logger;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "WorldSpritesContainer");
		Transform transform = gameObject.transform;
		_003CWorldSpritesTransform_003Ek__BackingField = transform;
		_Spotlight2D.enabled = false;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionException> onConnectionError = masterBridge.onConnectionError;
		UnityAction<CoherenceBridge, ConnectionException> action = OnConnectionError;
		UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<CoherenceBridge, ConnectionException>.GetDelegate(action);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rdi_v3 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
		_ = 1;
	}

	private void InitializeGame()
	{
		GameplayLoader gameplayLoader = _diContainer.Instantiate<GameplayLoader>();
		_gameplayLoader = gameplayLoader;
		Debug.Log("Initiating gameplay preload...");
		Action onComplete = delegate
		{
			//IL_002a: Expected O, but got I4
			//IL_0033: Expected O, but got I4
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			Debug.Log("Gameplay preload completed. Initiating gameplay load...");
			MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
			ObjectPool[] pools = masterObjectPooler._pools;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < pools.Length)
			{
				ObjectPool objectPool = pools[obj];
				objectPool._003CInitialized_003Ek__BackingField = true;
				objectPool.AutoFillName();
				objectPool.Populate(objectPool._defaultSize);
				obj++;
				obj2 = obj;
			}
			GeneratePickupVfx();
			InitializeGameSession();
			Action onComplete2 = delegate
			{
				Debug.Log("Gameplay load completed. Initializing game session...");
				InitializeGameSessionPostLoad();
				AspectMask aspectMask = AspectMask._003CInstance_003Ek__BackingField;
				if ((object)AspectMask._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)aspectMask).m_CachedPtr != (IntPtr)0)
				{
					AspectMask aspectMask2 = AspectMask._003CInstance_003Ek__BackingField;
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Top, true);
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Bottom, true);
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Left, true);
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Right, true);
				}
				if (!_multiplayer.IsOnlineMultiplayer)
				{
					_Preloader.SetActive(value: false);
				}
			};
			_gameplayLoader.Load(onComplete2);
		};
		_gameplayLoader.Preload(onComplete);
	}

	private void InitiateGameplayPreload()
	{
		Debug.Log("Initiating gameplay preload...");
		Action onComplete = delegate
		{
			//IL_002a: Expected O, but got I4
			//IL_0033: Expected O, but got I4
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			Debug.Log("Gameplay preload completed. Initiating gameplay load...");
			MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
			ObjectPool[] pools = masterObjectPooler._pools;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < pools.Length)
			{
				ObjectPool objectPool = pools[obj];
				objectPool._003CInitialized_003Ek__BackingField = true;
				objectPool.AutoFillName();
				objectPool.Populate(objectPool._defaultSize);
				obj++;
				obj2 = obj;
			}
			GeneratePickupVfx();
			InitializeGameSession();
			Action onComplete2 = delegate
			{
				Debug.Log("Gameplay load completed. Initializing game session...");
				InitializeGameSessionPostLoad();
				AspectMask aspectMask = AspectMask._003CInstance_003Ek__BackingField;
				if ((object)AspectMask._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)aspectMask).m_CachedPtr != (IntPtr)0)
				{
					AspectMask aspectMask2 = AspectMask._003CInstance_003Ek__BackingField;
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Top, true);
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Bottom, true);
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Left, true);
					AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Right, true);
				}
				if (!_multiplayer.IsOnlineMultiplayer)
				{
					_Preloader.SetActive(value: false);
				}
			};
			_gameplayLoader.Load(onComplete2);
		};
		_gameplayLoader.Preload(onComplete);
	}

	protected override void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_0326: Expected O, but got I
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Expected O, but got Unknown
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected O, but got Unknown
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected O, but got Unknown
		//IL_075b: Expected O, but got I
		//IL_0796: Expected O, but got I
		//IL_07b1: Expected O, but got I4
		//IL_07b1: Expected O, but got I
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected O, but got Unknown
		//IL_0874: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected O, but got Unknown
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0933: Expected O, but got Unknown
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ed: Expected O, but got Unknown
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa7: Expected O, but got Unknown
		Action token = InitializeGame;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action action = ResetGameSessionCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA45A0");
		Action<GameplaySignals.AddWeaponToCharacterSignal> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB36D0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v608 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action<GameplaySignals.AddAccessoryToCharacterSignal> token3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB37B0");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v731 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
		Action<GameplaySignals.RemoveWeaponFromCharacterSignal> token4 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3890");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ rbx_v15 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rbx_v16 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType4 = default(Type);
		_signalBus.UnsubscribeInternal(signalType4, (object)null, (object)token4, throwIfMissing);
		Action<GameplaySignals.AddHiddenWeaponToCharacterSignal> token5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3970");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rbx_v19 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v995 @ rbx_v20 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)0);
		_signalBus.UnsubscribeInternal(typeFromHandle, (object)null, (object)token5, throwIfMissing);
		Action<GameplaySignals.RemoveHiddenWeaponFromCharacterSignal> token6 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3A50");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1032 @ rbx_v23 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rbx_v24 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj10 = default(object);
		object obj9 = obj10 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType5 = default(Type);
		_signalBus.UnsubscribeInternal(signalType5, (object)null, (object)token6, throwIfMissing);
		Action<GameplaySignals.SetCharacterInvincibilityForMillisSignal> token7 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3B30");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1128 @ rbx_v27 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1145 @ rbx_v28 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj12 = default(object);
		object obj11 = obj12 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType6 = default(Type);
		_signalBus.UnsubscribeInternal(signalType6, (object)null, (object)token7, throwIfMissing);
		Action<GameplaySignals.SetCharacterInvincibilityForMillisNonCumulativeSignal> token8 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3C10");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1224 @ rbx_v31 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1241 @ rbx_v32 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj14 = default(object);
		object obj13 = obj14 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType7 = default(Type);
		_signalBus.UnsubscribeInternal(signalType7, (object)null, (object)token8, throwIfMissing);
		Action<GameplaySignals.TimeStopSignal> token9 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3CF0");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1320 @ rbx_v35 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1337 @ rbx_v36 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj16 = default(object);
		object obj15 = obj16 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType8 = default(Type);
		_signalBus.UnsubscribeInternal(signalType8, (object)null, (object)token9, throwIfMissing);
		Action<GameplaySignals.ReviveCharacterSignal> token10 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3DD0");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1416 @ rbx_v39 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1433 @ rbx_v40 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj18 = default(object);
		object obj17 = obj18 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType9 = default(Type);
		_signalBus.UnsubscribeInternal(signalType9, (object)null, (object)token10, throwIfMissing);
		Action<UISignals.SetVisibleJoysticksSignal> action2 = null;
		((GameManager)(object)action2).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
		((GameManager)(object)_signalBus).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)action2);
		Action<GameplaySignals.SkipLevelUpSignal> action3 = null;
		((GameManager)(object)action3).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1519 @ rbx_v44 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((GameManager)0).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
		}
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1536 @ rbx_v45 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			((GameManager)0).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)this);
		}
		((GameManager)0).OnJoystickOptionsChanged((UISignals.SetVisibleJoysticksSignal)1);
		object obj20 = default(object);
		object obj19 = obj20 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType10 = default(Type);
		_signalBus.UnsubscribeInternal(signalType10, (object)null, (object)action3, throwIfMissing);
		Action token11 = OnLevelUpCompleted;
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1617 @ rbx_v48 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1634 @ rbx_v49 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj22 = default(object);
		object obj21 = obj22 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType11 = default(Type);
		_signalBus.UnsubscribeInternal(signalType11, (object)null, (object)token11, throwIfMissing);
		Action token12 = OnLevelUpCompleted;
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1715 @ rbx_v52 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1732 @ rbx_v53 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj24 = default(object);
		object obj23 = obj24 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType12 = default(Type);
		_signalBus.UnsubscribeInternal(signalType12, (object)null, (object)token12, throwIfMissing);
		Action token13 = OnLevelUpCompleted;
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1813 @ rbx_v56 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1830 @ rbx_v57 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj26 = default(object);
		object obj25 = obj26 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType13 = default(Type);
		_signalBus.UnsubscribeInternal(signalType13, (object)null, (object)token13, throwIfMissing);
		Action<GameplaySignals.FireEnemyBulletSignal> token14 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3F90");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1909 @ rbx_v60 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1926 @ rbx_v61 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj28 = default(object);
		object obj27 = obj28 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType14 = default(Type);
		_signalBus.UnsubscribeInternal(signalType14, (object)null, (object)token14, throwIfMissing);
		Texture2D recapTex = _recapTex;
		if ((object)_recapTex != null && ((UnityEngine.Object)recapTex).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.DestroyImmediate(_recapTex, allowDestroyingAssets: false);
			_recapTex = null;
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0030: Expected F4, but got I4
		//IL_09d2: Expected O, but got F4
		//IL_0342: Expected O, but got I4
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected I4, but got Unknown
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac6: Expected O, but got Unknown
		//IL_0ace: Expected I4, but got O
		//IL_042b: Expected I4, but got I8
		//IL_0455: Expected O, but got I4
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected I4, but got Unknown
		//IL_0121: Invalid comparison between F4 and I4
		//IL_01a3: Invalid comparison between F4 and I4
		//IL_0643: Expected O, but got I
		//IL_0c9a->IL0ad3: Incompatible stack heights: 3 vs 0
		if (!_isGameRunning)
		{
			return;
		}
		bool flag = !_canRunTickerTimer;
		float num = 0f;
		if (!flag)
		{
			object obj = Time.deltaTime;
			_secondsTickerTimer = _secondsTickerTimer;
			bool flag2 = !(_secondsTickerTimer > _targetTick);
			float secondsTickerTimer = _secondsTickerTimer;
			num = _secondsTickerTimer;
			float secondsTickerTimer2 = _secondsTickerTimer;
			if (!flag2)
			{
				secondsTickerTimer2 = _targetTick;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				_secondsTickerTimer = _secondsTickerTimer;
				num = _003CSurvivedSeconds_003Ek__BackingField + 1f;
				_003CSurvivedSeconds_003Ek__BackingField = num;
				Transform stage = (Transform)(object)_stage;
				bool flag3 = (object)_stage == null;
				secondsTickerTimer = _secondsTickerTimer;
				if (!flag3)
				{
					bool flag4 = ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0;
					secondsTickerTimer = _secondsTickerTimer;
					if (!flag4)
					{
						Stage stage2 = _stage;
						if ((object)_stage == null)
						{
							goto IL_09a3;
						}
						bool flag5 = !stage2._003CHasInitialized_003Ek__BackingField;
						secondsTickerTimer = _secondsTickerTimer;
						if (!flag5)
						{
							num = _003CSurvivedSeconds_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187792410h\"");
							if (_003CSurvivedSeconds_003Ek__BackingField == 0f)
							{
								if ((object)_stage == null)
								{
									goto IL_09a3;
								}
								_stage.CheckMinute();
								secondsTickerTimer = _secondsTickerTimer;
								secondsTickerTimer2 = 60f;
							}
							else
							{
								num = _003CSurvivedSeconds_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018779243Ah\"");
								bool flag6 = _003CSurvivedSeconds_003Ek__BackingField != 0f;
								secondsTickerTimer = _secondsTickerTimer;
								secondsTickerTimer2 = 30f;
								if (!flag6)
								{
									_stage.CheckHalfMinute();
									secondsTickerTimer = _secondsTickerTimer;
									secondsTickerTimer2 = 30f;
								}
							}
						}
					}
				}
			}
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		bool flag7 = _characters == null;
		Transform transform = null;
		int num2 = 0;
		int num3 = 0;
		if (!flag7)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			object obj7 = default(object);
			HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
			while (true)
			{
				if (num3 < characters._size)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if ((object)characterController == null)
					{
						break;
					}
					if (!characterController.IsDisconnectedFromOnlinePlay)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if ((object)characterController2 == null)
						{
							break;
						}
						if (!characterController2._isDead && !characterController2.IsDisconnectedFromOnlinePlay)
						{
							num2++;
						}
					}
					transform = (Transform)(transform + 1);
					num3 = (int)transform;
					continue;
				}
				if (num2 == 0)
				{
					return;
				}
				if (_gameplayCheatCodeManager != null)
				{
					_gameplayCheatCodeManager.InternalUpdate();
				}
				if (_explosionManager != null)
				{
					_explosionManager.InternalUpdate();
				}
				object obj2 = _003CHasGfBonus_003Ek__BackingField ^ _003CHasGfBonus_003Ek__BackingField;
				int num4 = ((_003CHasGfBonus_003Ek__BackingField & obj2) ? 1 : 0);
				bool flag8 = num4 < 0;
				bool flag9 = (_003CHasGfBonus_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
				if (_003CHasGfBonus_003Ek__BackingField)
				{
					object obj3 = (object)_003CGoldFingerManager_003Ek__BackingField ^ (object)_003CGoldFingerManager_003Ek__BackingField;
					object obj4 = (object)_003CGoldFingerManager_003Ek__BackingField & obj3;
					flag8 = (nint)obj4 < 0;
					flag9 = (nint)_003CGoldFingerManager_003Ek__BackingField < 0;
					if (_003CGoldFingerManager_003Ek__BackingField == null)
					{
						break;
					}
					_003CGoldFingerManager_003Ek__BackingField.GoldenFingerUpdate();
				}
				int num5 = (int)(++_updateTicks & 0x80000003L);
				if (flag9 != flag8)
				{
					object obj5 = num5 - 1;
					object obj6 = obj5 | -4;
					num5 = obj6 + 1;
				}
				if (num5 != 0)
				{
					return;
				}
				_updateTicks = 0;
				if (_003CCanInterrupt_003Ek__BackingField && !_003CFreezingFrame_003Ek__BackingField)
				{
					HandleIngamePopup();
				}
				Stage stage3 = _stage;
				if ((object)_stage == null)
				{
					break;
				}
				StageData stageData = stage3._stageData;
				if (stage3._stageData == null)
				{
					break;
				}
				if (stageData._003CdayNight_003Ek__BackingField)
				{
					Transform bgMan = (Transform)(object)_bgMan;
					if ((object)_bgMan != null && ((UnityEngine.Object)bgMan).m_CachedPtr != (IntPtr)0)
					{
						if ((object)_bgMan == null)
						{
							break;
						}
						_bgMan.DayNightHue();
					}
				}
				SpawnGems();
				ObjectPool coinPool = CoinPool;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183040080");
				ObjectPool redCoinBagPool = RedCoinBagPool;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183040080");
				ObjectPool frozenSoulPool = FrozenSoulPool;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183040080");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
				if (obj7 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rax_v49+30]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rax_v49+30]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ r9_v14+18]");
				if ((nint)0 == 0)
				{
					break;
				}
				while (enumerator.MoveNext())
				{
					Pickup component = ((Component)null).GetComponent<Pickup>();
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						component.InternalUpdate();
					}
				}
				PhysicsManager sInstance = PhysicsManager._sInstance;
				if (PhysicsManager._sInstance == null)
				{
					break;
				}
				PhysicsGroup goToPlayerPickupGroup = sInstance._goToPlayerPickupGroup;
				if (sInstance._goToPlayerPickupGroup == null || ((Group)goToPlayerPickupGroup).children == null)
				{
					break;
				}
				HashSet<object>.Enumerator value = (HashSet<object>.Enumerator)((Group)goToPlayerPickupGroup).children;
				while (enumerator.MoveNext())
				{
					Pickup component2 = ((Component)null).GetComponent<Pickup>();
					if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0)
					{
						component2.InternalUpdate();
					}
				}
				Stage stage4 = _stage;
				if ((object)_stage == null)
				{
					break;
				}
				StageData stageData2 = stage4._stageData;
				if (stage4._stageData == null)
				{
					break;
				}
				if (!stageData2._003ChasLights_003Ek__BackingField)
				{
					return;
				}
				GameManager core = GM.Core;
				if ((object)GM.Core == null)
				{
					break;
				}
				Stage stage5 = core._stage;
				if ((object)core._stage == null)
				{
					break;
				}
				StageData baseStageData = stage5._baseStageData;
				if (stage5._baseStageData == null)
				{
					break;
				}
				if (baseStageData._003ChasCharacterSpotlight_003Ek__BackingField)
				{
					return;
				}
				GameManager core2 = GM.Core;
				Transform bgMan2 = (Transform)(object)core2._bgMan;
				if ((object)core2._bgMan == null || ((UnityEngine.Object)bgMan2).m_CachedPtr == (IntPtr)0)
				{
					if ((object)_Spotlight2D == null)
					{
						break;
					}
					Transform transform2 = _Spotlight2D.transform;
					GameSessionData gameSessionData = _gameSessionData;
					if (_gameSessionData == null || (object)gameSessionData._activeCharacter == null)
					{
						break;
					}
					Transform transform3 = gameSessionData._activeCharacter.transform;
					if ((object)transform3 == null)
					{
						break;
					}
					bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
					bool flag11 = (object)transform2 == null;
					bool flag12 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
				}
				return;
			}
		}
		goto IL_09a3;
		IL_09a3:
		throw new NullReferenceException();
	}

	public void OverrideLatestUIPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
	{
	}

	private unsafe void HandleIngamePopup()
	{
		//IL_007d: Expected I, but got O
		//IL_00ac: Expected I, but got O
		//IL_00d4: Expected I, but got O
		//IL_0199: Expected O, but got Ref
		//IL_01a2: Expected F4, but got I4
		//IL_0bb1: Expected O, but got Ref
		//IL_0556: Expected I4, but got O
		//IL_01bc: Expected I4, but got O
		//IL_0572: Expected O, but got Ref
		//IL_0481: Expected I, but got O
		//IL_0491: Expected I4, but got O
		//IL_059c: Expected O, but got I4
		//IL_020f: Expected O, but got I
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_066d: Expected O, but got Unknown
		//IL_0612: Expected O, but got I4
		//IL_029a: Expected I4, but got O
		//IL_029a: Expected O, but got I
		//IL_02a3: Expected I, but got O
		//IL_0250: Expected O, but got I4
		//IL_05e8: Expected O, but got I4
		//IL_062d: Expected O, but got Ref
		//IL_0434: Expected O, but got I
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_06ea: Expected O, but got I
		//IL_0775: Expected I4, but got O
		//IL_0775: Expected O, but got I
		//IL_077e: Expected I, but got O
		//IL_072b: Expected O, but got I4
		//IL_0f37: Expected O, but got Ref
		//IL_0f4a: Expected I4, but got O
		//IL_0f60: Expected O, but got Ref
		//IL_0f68: Expected O, but got I4
		//IL_0945: Expected O, but got I
		//IL_094e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0953: Expected O, but got Unknown
		//IL_0960: Expected I4, but got O
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_073e: Expected O, but got Unknown
		//IL_07bc: Expected I4, but got O
		//IL_07bc: Expected O, but got I4
		//IL_07c0: Expected I, but got O
		//IL_07ce: Expected I, but got O
		//IL_07fc: Expected O, but got I
		//IL_0a34: Expected O, but got I
		//IL_0ab3: Expected O, but got Ref
		//IL_0af6: Expected O, but got Ref
		//IL_0afb: Expected I, but got O
		//IL_0ae3: Expected O, but got I4
		LevelUpFactory levelUpFactory = _levelUpFactory;
		float xp;
		if (_multiplayer.IsOnlineMultiplayer)
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			if ((object)OnlineStageManager._instance == null)
			{
				PlayerInfo playerInfo = (PlayerInfo)(object)instance;
				throw new NullReferenceException();
			}
			PlayerInfo playerInfo2 = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
			bool flag = (object)playerInfo2 == null;
			nint num = unchecked((nint)null);
			if (flag)
			{
				throw new NullReferenceException();
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo2.CharacterController;
			bool flag2 = (object)characterController == null;
			num = unchecked((nint)null);
			instance = (OnlineStageManager)(object)playerInfo2;
			if (flag2)
			{
				throw new NullReferenceException();
			}
			xp = characterController._xp;
			num = unchecked((nint)null);
		}
		else
		{
			GameSessionData gameSessionData = _gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			xp = activeCharacter._xp;
		}
		if (_multiplayer.IsOnlineMultiplayer && IsStageHost)
		{
			if ((object)OnlineStageManager._instance == null)
			{
				throw new NullReferenceException();
			}
			IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
			if (enumerable == null)
			{
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			IntPtr intPtr = default(IntPtr);
			object obj = (object)(&intPtr);
			float num2 = 0f;
			PlayerInfo playerInfo = null;
			PlayerInfo playerInfo3 = default(PlayerInfo);
			nint num;
			while (true)
			{
				bool flag3 = intPtr == (IntPtr)0;
				num = intPtr;
				List<UiTransition> list2;
				if (!flag3)
				{
					List<UiTransition> list = ((Dictionary<UITransitionType, List<UiTransition>>)null).get_Item((UITransitionType)typeof(IEnumerator));
					if (list == null)
					{
						break;
					}
					bool flag4 = intPtr == (IntPtr)0;
					num = intPtr;
					playerInfo = null;
					if (!flag4)
					{
						object obj2 = (nint)intPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ r10_v45+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0287;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ r10_v45+B0]");
						num = 0;
						object obj3 = 0;
						while (true)
						{
							object obj4 = obj3 + obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1165 @ r8_v47 (Il2CppMethodInfo)+v2571 @ rax_v208*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							obj3++;
							object obj5 = obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ r10_v45+12E]");
							if ((nint)obj5 < 0)
							{
								continue;
							}
							goto IL_0287;
						}
						object obj6 = obj3 + obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1165 @ r8_v47 (Il2CppMethodInfo)+8+v2800 @ rcx_v143*8]");
						object obj7 = (nint)0 << 4;
						object obj8 = obj7 + 312;
						list2 = (List<UiTransition>)(object)(obj8 + obj2);
						goto IL_0e59;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0287:
				List<UiTransition> list3 = ((Dictionary<UITransitionType, List<UiTransition>>)(nint)intPtr).get_Item((UITransitionType)typeof(IEnumerator<PlayerInfo>));
				num = unchecked((nint)null);
				list2 = list3;
				goto IL_0e59;
				IL_0e59:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2805 @ rdx_v106 (System.Collections.Generic.List`1<VampireSurvivors.Data.UiTransition>)] (should have been resolved before IL gen)");
				playerInfo = (PlayerInfo)(object)typeof(UnityEngine.Object);
				if ((object)playerInfo3 == null)
				{
					continue;
				}
				bool flag5 = ((UnityEngine.Object)playerInfo3).m_CachedPtr == (IntPtr)0;
				playerInfo = (PlayerInfo)(object)typeof(UnityEngine.Object);
				if (flag5)
				{
					continue;
				}
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = playerInfo3.CharacterController;
				if ((object)characterController2 != null)
				{
					CharacterData currentCharacterData = characterController2._currentCharacterData;
					if (characterController2._currentCharacterData != null)
					{
						if (currentCharacterData._003CexLevels_003Ek__BackingField == 0)
						{
							continue;
						}
						VampireSurvivors.Objects.Characters.CharacterController characterController3 = playerInfo3.CharacterController;
						if ((object)characterController3 != null)
						{
							num2 = characterController3._xp;
							if (!(characterController3._xp < levelUpFactory._currentXpFactor))
							{
								VampireSurvivors.Objects.Characters.CharacterController characterController4 = playerInfo3.CharacterController;
								if ((object)characterController4 == null)
								{
									throw new NullReferenceException();
								}
								xp = characterController4._xp;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			bool flag6 = obj == null;
			num = intPtr;
			if (!flag6)
			{
				num = (nint)obj;
				List<UiTransition> list4 = ((Dictionary<UITransitionType, List<UiTransition>>)null).get_Item((UITransitionType)typeof(IDisposable));
			}
		}
		List<UiTransition> queuedUiTransitions = _queuedUiTransitions;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v918 @ rax_v97 (System.Collections.Generic.List`1<VampireSurvivors.Data.UiTransition>)+18]");
		if ((nint)0 > (nint)0)
		{
			List<UiTransition> queuedUiTransitions2 = default(List<UiTransition>);
			if (!_multiplayer.IsOnlineMultiplayer)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config._003CPopupsShouldFollowPriority_003Ek__BackingField)
				{
					Dictionary<UITransitionType, List<UiTransition>> dictionary = new Dictionary<UITransitionType, List<UiTransition>>();
					queuedUiTransitions2 = _queuedUiTransitions;
					List<UiTransition>.Enumerator queuedUiTransitions3 = (List<UiTransition>.Enumerator)_queuedUiTransitions;
					System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)_queuedUiTransitions;
					List<UiTransition>.Enumerator enumerator = default(List<UiTransition>.Enumerator);
					System.Int32Enum key = default(System.Int32Enum);
					List<UiTransition>.Enumerator enumerator2 = default(List<UiTransition>.Enumerator);
					object obj13 = default(object);
					Array array = default(Array);
					IntPtr intPtr2 = default(IntPtr);
					object obj22 = default(object);
					while (true)
					{
						if (enumerator.MoveNext())
						{
							bool flag7 = dictionary == null;
							Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)(&enumerator);
							if (!flag7)
							{
								int num3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry(key);
								object obj9 = !flag7;
								System.Int32Enum key2;
								if (obj9 == null)
								{
									List<UiTransition> value = new List<UiTransition>();
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
									bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									queuedUiTransitions3 = (List<UiTransition>.Enumerator)0;
									insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
									key2 = (System.Int32Enum)0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
									queuedUiTransitions3 = (List<UiTransition>.Enumerator)0;
									key2 = (System.Int32Enum)0;
								}
								object obj10 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item(key2);
								bool flag9 = obj10 == null;
								nint num = 0;
								if (flag9)
								{
									break;
								}
								((List<UiTransition>)obj10).Add((UiTransition)(&enumerator2));
								num = 0;
								continue;
							}
							throw new NullReferenceException();
						}
						List<UiTransition> list5 = ((Dictionary<UITransitionType, List<UiTransition>>)(object)typeof(UITransitionType)).get_Item(UITransitionType.WeaponSelector);
						object obj11 = list5 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
						object obj12 = obj13;
						if (obj12 != null)
						{
							object obj14 = obj12;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3158 @ rdx_v60+8F8] (should have been resolved before IL gen)");
							IEnumerator enumerator3 = array.GetEnumerator();
							while (true)
							{
								int num5;
								nint num4;
								if (intPtr2 != (IntPtr)0)
								{
									object obj15 = (nint)intPtr2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1327 @ r10_v42+12E]");
									if ((nint)0 >= (nint)0)
									{
										goto IL_0762;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1327 @ r10_v42+B0]");
									num4 = 0;
									object obj16 = 0;
									while (true)
									{
										object obj17 = obj16 + obj16;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3296 @ r8_v50 (Il2CppMethodInfo)+v3232 @ rax_v155*8]");
										if (0 == (nint)typeof(IEnumerator))
										{
											break;
										}
										obj16++;
										object obj18 = obj16;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1327 @ r10_v42+12E]");
										if ((nint)obj18 < 0)
										{
											continue;
										}
										goto IL_0762;
									}
									object obj19 = obj16 + obj16;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3296 @ r8_v50 (Il2CppMethodInfo)+8+v3264 @ rcx_v100*8]");
									object obj20 = (nint)0 << 4;
									object obj21 = obj20 + 312;
									num5 = (int)(obj21 + obj15);
									goto IL_0fa7;
								}
								throw new NullReferenceException();
								IL_0762:
								int num6 = ((Dictionary<UITransitionType, List<UiTransition>>)(nint)intPtr2).FindEntry((UITransitionType)typeof(IEnumerator));
								num4 = unchecked((nint)null);
								num5 = num6;
								goto IL_0fa7;
								IL_0fa7:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3270.m_value (System.Int32) (should have been resolved before IL gen)");
								if (obj22 != null)
								{
									if (intPtr2 == (IntPtr)0)
									{
										throw new NullReferenceException();
									}
									nint num7 = (nint)((Dictionary<UITransitionType, List<UiTransition>>)1).get_Item((UITransitionType)typeof(IEnumerator));
									nint num8 = (nint)typeof(UITransitionType);
									bool flag10 = num7 == 0;
									nint num9 = 1;
									if (flag10)
									{
										throw new NullReferenceException();
									}
									object obj23 = num7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2651 @ rcx_v83+40]");
									nint num10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2646 @ rdx_v72 (Il2CppClass<VampireSurvivors.Framework.UITransitionType>)+40]");
									if (num10 != 0)
									{
										throw new InvalidCastException();
									}
									bool flag11 = dictionary == null;
									if (flag11)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2902 @ rax_v134 (Il2CppMethodInfo)+10]");
									int num11 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
									if (flag11)
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2902 @ rax_v134 (Il2CppMethodInfo)+10]");
									if ((nint)0 != 9 || xp < levelUpFactory._currentXpFactor || !IsStageHost || _waitingForLevelUp)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2902 @ rax_v134 (Il2CppMethodInfo)+10]");
										object obj24 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
										if (obj24 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2542 @ rax_v141 (System.Object)+18]");
											if ((nint)0 <= (nint)0)
											{
												continue;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2902 @ rax_v134 (Il2CppMethodInfo)+10]");
											object obj25 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
											if (obj25 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v142 (System.Object)+18]");
												if ((nint)0 > (nint)0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v142 (System.Object)+10]");
													object obj26 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2023 @ rax_v142 (System.Object)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1994 @ rdx_v77+18]");
														if ((nint)0 <= (nint)0)
														{
															break;
														}
														if (_queuedUiTransitions != null)
														{
															int num12 = _queuedUiTransitions.IndexOf((UiTransition)(&queuedUiTransitions2));
															if (num12 >= 0)
															{
																int num13 = _queuedUiTransitions.IndexOf((UiTransition)num12);
															}
															ProcessUITransition((UiTransition)(&queuedUiTransitions2));
															num4 = unchecked((nint)null);
															goto IL_0f2f;
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
											}
										}
										throw new NullReferenceException();
									}
									RunLocalOrOnlineLevelUp();
									num4 = 0;
								}
								goto IL_0f2f;
								IL_0f2f:
								object obj27 = (object)(&intPtr2);
								int num14 = ((Dictionary<UITransitionType, List<UiTransition>>)obj27).FindEntry((UITransitionType)typeof(IDisposable));
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm8,8\"");
								object obj28 = (object)(&intPtr2);
								obj28 = num14;
								if (num14 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
								return;
							}
							throw new IndexOutOfRangeException();
						}
						ArgumentNullException ex = new ArgumentNullException("enumType");
						throw ex;
					}
					throw new NullReferenceException();
				}
			}
			List<UiTransition> queuedUiTransitions4 = _queuedUiTransitions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v103 (System.Collections.Generic.List`1<VampireSurvivors.Data.UiTransition>)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			List<UiTransition> list6 = ((Dictionary<UITransitionType, List<UiTransition>>)(object)_queuedUiTransitions).get_Item((UITransitionType)0);
			ProcessUITransition((UiTransition)(&queuedUiTransitions2));
		}
		else if (!(xp < levelUpFactory._currentXpFactor) && IsStageHost && !_waitingForLevelUp)
		{
			RunLocalOrOnlineLevelUp();
		}
	}

	private void ProcessUITransition(UiTransition uiTransition)
	{
		VampireSurvivors.Objects.Characters.CharacterController triggeredByPlayer = uiTransition.TriggeredByPlayer;
		if ((object)uiTransition.TriggeredByPlayer == null || ((UnityEngine.Object)triggeredByPlayer).m_CachedPtr == (IntPtr)0)
		{
			MethodInfo methodImpl = ((MulticastDelegate)uiTransition.TransitionPredicate).GetMethodImpl();
			string text = methodImpl.Name;
			string message = "Shouldn't have a UI transition with a null 'TriggeredByPlayer' value.  Predicate name = " + text;
			Debug.LogError(message);
		}
		_latestUITransition = (UiTransition)uiTransition.TransitionPredicate;
		_ = uiTransition.Arguments;
		(string, object)[] args = new(string, object)[3];
		MethodInfo methodImpl2 = ((MulticastDelegate)uiTransition.TransitionPredicate).GetMethodImpl();
		object item = methodImpl2.Name;
		(string, object) tuple = ("Transition Predicate", item);
		_ = 0;
		VampireSurvivors.Objects.Characters.CharacterController triggeredByPlayer2 = uiTransition.TriggeredByPlayer;
		object item2;
		string log;
		string item3;
		if ((object)uiTransition.TriggeredByPlayer != null && ((UnityEngine.Object)triggeredByPlayer2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController triggeredByPlayer3 = uiTransition.TriggeredByPlayer;
			CharacterType characterType = default(CharacterType);
			item2 = characterType;
			characterType = triggeredByPlayer3._characterType;
			log = "Performing Ui Transition";
			item3 = "Triggering Player";
		}
		else
		{
			log = "Performing Ui Transition";
			item3 = "Triggering Player";
			item2 = "VOID";
		}
		(string, object) tuple2 = (item3, item2);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item4 = default(object);
		(string, object) tuple3 = ("Transitions In Queue", item4);
		_ = 0;
		_logger.Info(log, args);
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> transitionPredicate = uiTransition.TransitionPredicate;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v568 @ rax_v37 (System.Action`2<VampireSurvivors.Objects.Characters.CharacterController, System.Collections.Generic.Dictionary`2<System.String, System.Object>>)+18] (should have been resolved before IL gen)");
	}

	public bool ShouldShowArcanaPanel()
	{
		//IL_01f1: Expected I4, but got O
		//IL_013f: Expected O, but got I
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
				if (config._003CUnlockedArcanas_003Ek__BackingField != null)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						ArcanaManager arcanaManager = core2._arcanaManager;
						if (core2._arcanaManager != null)
						{
							IEnumerable<System.Int32Enum> enumerable = (IEnumerable<System.Int32Enum>)arcanaManager._003CActiveArcanas_003Ek__BackingField;
							Func<System.Int32Enum, bool> predicate = (Func<System.Int32Enum, bool>)(object)_003C_003Ec._003C_003E9__425_0;
							if (_003C_003Ec._003C_003E9__425_0 == null)
							{
								predicate = (Func<System.Int32Enum, bool>)(object)(_003C_003Ec._003C_003E9__425_0 = delegate
								{
									//IL_00a3: Expected I4, but got O
									//IL_008b: Unknown result type (might be due to invalid IL or missing references)
									//IL_0090: Expected I4, but got Unknown
									GameManager core3 = GM.Core;
									if ((object)GM.Core != null && core3._playerOptions != null)
									{
										PlayerOptionsData config2 = core3._playerOptions.Config;
										if (config2 != null && config2._003CUnlockedArcanas_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
											object obj6 = default(object);
											return (byte)(obj6 ^ 1) != 0;
										}
									}
									NullReferenceException ex2 = new NullReferenceException();
									return (byte)(int)ex2 != 0;
								});
							}
							int num = Enumerable.Count((IEnumerable<System.Int32Enum>)arcanaManager._003CActiveArcanas_003Ek__BackingField, predicate);
							if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rsi_v2 (System.Collections.Generic.IEnumerable`1<System.Int32Enum>)+18]");
								object obj = -num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
								object obj2 = 0 - obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
								object obj3 = 0 ^ obj;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
								object obj4 = 0 ^ obj2;
								object obj5 = obj3 & obj4;
								bool flag = (nint)obj5 < 0;
								bool flag2 = (nint)obj2 < 0;
								bool flag3 = obj2 == null;
								bool flag4 = flag2 == flag;
								bool flag5 = !flag3;
								return flag5 & flag4;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void MovePickupsAndDestructibles(float2 offset)
	{
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
	}

	private unsafe void RunLocalOrOnlineLevelUp()
	{
		//IL_01b7: Expected O, but got I4
		//IL_04d1: Expected I8, but got O
		//IL_0260: Expected I, but got O
		//IL_0275: Expected O, but got I
		//IL_02d2: Expected I, but got O
		//IL_0353: Expected I, but got O
		//IL_040a: Expected O, but got Ref
		//IL_03b8: Expected I, but got O
		if (_waitingForLevelUp)
		{
			return;
		}
		if (_multiplayer.IsOnlineMultiplayer)
		{
			if (!IsStageHost)
			{
				return;
			}
			_waitingForLevelUp = true;
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				object arg3 = default(object);
				string message = $"Running Level Up. Character Level: {arg}. Next Level Up At: {arg2}. Pending Level Ups: {arg3}";
				Debug.Log(message);
				GameSessionData gameSessionData = _gameSessionData;
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				if (activeCharacter._level != _nextLevelUpAtLevel)
				{
					Debug.Log("Send Level Up Without Screen");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
					OnlineStageManager onlineStageManager = default(OnlineStageManager);
					long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
					Action<long> action = null;
					((OnlineStageManager)(object)action).LevelUpWithoutScreen((long)onlineStageManager);
					bool flag = onlineStageManager._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
					return;
				}
				GameSessionData gameSessionData2 = _gameSessionData;
				List<VampireSurvivors.Objects.Characters.CharacterController> charactersLevelingUp = _charactersLevelingUp;
				object obj = charactersLevelingUp._size - 1;
				bool adjustXpFactors = obj == null;
				SwapToLevelUpScreen(adjustXpFactors);
				bool flag2 = ((List<object>)(object)_charactersLevelingUp).Remove((object)gameSessionData2._activeCharacter);
				if (charactersLevelingUp._size != 1)
				{
					return;
				}
				AdjustNextLevelUpAtLevel();
				object[] array = new object[4];
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				List<VampireSurvivors.Objects.Characters.CharacterController> list = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
				if (list != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v894 @ rcx_v66 (Il2CppClass<System.Object[]>)+40]");
					if (!list.Remove((VampireSurvivors.Objects.Characters.CharacterController)0))
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj2 = default(object);
				if (obj2 != null)
				{
					nint num2 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				OnlineStageManager onlineStageManager2 = default(OnlineStageManager);
				int numberOfConnectedPlayers = onlineStageManager2.NumberOfConnectedPlayers;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj4 = default(object);
				if (obj4 != null)
				{
					nint num3 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj6 = default(object);
				if (obj6 != null)
				{
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj7 = default(object);
					if (obj7 == null)
					{
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				System.ParamsArray paramsArray = new System.ParamsArray(array);
				object obj8 = default(object);
				string message2 = string.FormatHelper((IFormatProvider)null, "Resetting Level Up Values: Next Level Up At: {0}. Pending Level Ups: {1}. Connected Players: {2}. MainPlayers Count: {3}.", (System.ParamsArray)(&obj8));
				Debug.Log(message2);
			}
			else
			{
				SwapToLevelUpScreen(adjustXpFactors: true);
			}
		}
		else
		{
			GameSessionData gameSessionData3 = _gameSessionData;
			_ = gameSessionData3._activeCharacter;
			HandleLevelUp();
			PreManipulateLevelUpOptionsForSpecialWeapons();
			SwapToLevelUpScreen(adjustXpFactors: true);
			_lootManager.RecalculateLoot();
			_levelUpFactory.CalculateXpFactor();
		}
	}

	private void AdjustNextLevelUpAtLevel()
	{
		UpdateMainPlayersEligibleForLevelUp();
		List<VampireSurvivors.Objects.Characters.CharacterController> charactersLevelingUp = _charactersLevelingUp;
		int nextLevelUpAtLevel = _nextLevelUpAtLevel + charactersLevelingUp._size;
		_nextLevelUpAtLevel = nextLevelUpAtLevel;
	}

	private unsafe void OnlineLevelUp(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_0092: Expected O, but got Ref
		//IL_00e6: Expected I, but got O
		//IL_010b: Expected I, but got O
		//IL_0154: Expected O, but got I
		//IL_02e9: Expected O, but got I
		//IL_0327: Expected O, but got I
		//IL_030d: Expected O, but got I
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge != null && masterBridge._003CClient_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C1F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "RUNNING LEVEL UP AT FRAME {0}", (System.ParamsArray)(&obj2));
				Debug.Log(message);
				if (args != null)
				{
					object obj3 = args.get_Item("levelUpData");
					nint num = (nint)typeof(OnlineLevelUpData);
					if (obj3 != null)
					{
						nint num2 = (nint)obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v10 (Il2CppClass<System.Object>)+40]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r8_v8 (Il2CppClass<VampireSurvivors.OnlineLevelUpData>)+40]");
						if (num3 != 0)
						{
							goto IL_029c;
						}
						OnlineStageManager instance = OnlineStageManager._instance;
						if ((object)OnlineStageManager._instance != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (System.Object)+10]");
							instance._003CChosenLevelUpWeapons_003Ek__BackingField = (List<WeaponType>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (System.Object)+10]");
							instance._003CChosenLevelUpItems_003Ek__BackingField = (List<ItemType>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (System.Object)+20]");
							instance._003CChosenAmuletTargets_003Ek__BackingField = (List<VampireSurvivors.Objects.Characters.CharacterController>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (System.Object)+20]");
							instance._003CChosenLimitBreaks_003Ek__BackingField = (List<WeightedLimitBreak>)0;
							if (_gameSessionData != null)
							{
								_gameSessionData.ActiveCharacter = player;
								_waitingForLevelUp = false;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (System.Object)+40]");
								if ((nint)0 != 0)
								{
									HandleLevelUp();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (System.Object)+30]");
								SwapToLevelUpScreenOnline(shouldSwapToLevelUpUi: false, player);
								if (_lootManager != null)
								{
									_lootManager.RecalculateLoot();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v18 (System.Object)+40]");
									if ((nint)0 == 0)
									{
										return;
									}
									if (_levelUpFactory != null)
									{
										_levelUpFactory.CalculateXpFactor();
										GrantSkipsExperience(player);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_029c;
		IL_029c:
		throw new InvalidCastException();
	}

	private void RunOnlineLevelUpLogic(bool shouldSwapToLevelUpUi, bool adjustXpFactors, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		_waitingForLevelUp = false;
		if (adjustXpFactors)
		{
			HandleLevelUp();
		}
		SwapToLevelUpScreenOnline(shouldSwapToLevelUpUi, characterController);
		_lootManager.RecalculateLoot();
		if (adjustXpFactors)
		{
			_levelUpFactory.CalculateXpFactor();
			GrantSkipsExperience(characterController);
		}
	}

	private unsafe void GrantSkipsExperience(VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0070: Expected I4, but got F4
		//IL_00a7: Expected O, but got Ref
		//IL_00d8: Expected O, but got I4
		//IL_00e1: Expected O, but got I4
		if (_batchedOnlineLevelUpSkips > 0)
		{
			float num2 = default(float);
			object arg2 = default(object);
			object arg3 = default(object);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			bool flag;
			do
			{
				LevelUpFactory levelUpFactory = _levelUpFactory;
				float num = levelUpFactory._currentXpFactor - characterController._xp;
				float xp = num * 0.2f;
				AddPlayerXp(xp);
				int batchedOnlineLevelUpSkips = _batchedOnlineLevelUpSkips - 1;
				_batchedOnlineLevelUpSkips = batchedOnlineLevelUpSkips;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = (CharacterType)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				System.ParamsArray paramsArray = new System.ParamsArray(arg2, arg, arg3);
				string message = string.FormatHelper((IFormatProvider)null, "Granting {0} XP to {1} for level up skip. Remaining skips: {2}", (System.ParamsArray)(&paramsArray2));
				Debug.Log(message);
				flag = _batchedOnlineLevelUpSkips > 0;
				paramsArray2 = (System.ParamsArray)0;
				paramsArray = (System.ParamsArray)0;
				int batchedOnlineLevelUpSkips2 = _batchedOnlineLevelUpSkips;
			}
			while (flag);
		}
	}

	private void RunLocalLevelUpLogic()
	{
		HandleLevelUp();
		PreManipulateLevelUpOptionsForSpecialWeapons();
		SwapToLevelUpScreen(adjustXpFactors: true);
		_lootManager.RecalculateLoot();
		_levelUpFactory.CalculateXpFactor();
	}

	private void SwapToLevelUpScreenOnline(bool shouldSwapToLevelUpUi, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0015: Expected O, but got I
		//IL_02c3: Expected I, but got O
		//IL_0272: Expected O, but got I
		//IL_0308: Expected I, but got O
		//IL_00ac: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_0176: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_0118: Expected O, but got I
		//IL_01b3: Expected O, but got I
		if (!shouldSwapToLevelUpUi)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE1F]");
			object obj = 0;
			OnlineStageManager instance = OnlineStageManager._instance;
			List<WeaponType> list = instance._003CChosenLevelUpWeapons_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			VampireSurvivors.Objects.Characters.CharacterController player = default(VampireSurvivors.Objects.Characters.CharacterController);
			if ((nint)0 > (nint)0)
			{
				OnlineStageManager instance2 = OnlineStageManager._instance;
				List<WeaponType> list2 = instance2._003CChosenLevelUpWeapons_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v6+20]");
					ApplyRandomLevelUpWeapon(WeaponType.VOID, player);
					return;
				}
			}
			else
			{
				nint num = (nint)typeof(OnlineStageManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v20 (Il2CppClass<VampireSurvivors.OnlineStageManager>)+B8]");
				nint num2 = 0;
				OnlineStageManager instance3 = OnlineStageManager._instance;
				List<WeightedLimitBreak> list3 = instance3._003CChosenLimitBreaks_003Ek__BackingField;
				if (list3._size > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v35+38]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v36+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_02e6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v36+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v13+20]");
					bool flag = ApplyRandomLevelUpLimitBreak((WeightedLimitBreak)0, player);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE1F]");
					obj = 0;
				}
				nint num3 = (nint)typeof(OnlineStageManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ rax_v25 (Il2CppClass<VampireSurvivors.OnlineStageManager>)+B8]");
				nint num4 = 0;
				OnlineStageManager instance4 = OnlineStageManager._instance;
				List<ItemType> list4 = instance4._003CChosenLevelUpItems_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v27 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				if ((nint)0 <= (nint)0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v29+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v30+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v30+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v19+20]");
					if ((nint)0 == 4)
					{
						ApplyCoinBagLevelUp(player);
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v19+20]");
					if ((nint)0 == 12)
					{
						ApplyRoastLevelUp(player);
					}
					return;
				}
			}
			goto IL_02e6;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4070");
		return;
		IL_02e6:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void HandleLevelUp()
	{
		//IL_0013: Expected O, but got I4
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private unsafe void OnDrawGizmos()
	{
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0245: Expected I, but got O
		//IL_00ee: Expected I, but got O
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected I, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03be: Expected F4, but got I
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_03ec->IL03a2: Incompatible stack heights: 2 vs 0
		//IL_024e->IL01ad: Incompatible stack heights: 1 vs 0
		//IL_00f7->IL01ad: Incompatible stack heights: 1 vs 0
		//IL_031c->IL01ad: Incompatible stack heights: 3 vs 0
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null)
		{
			gameSessionData = (GameSessionData)(object)gameSessionData._activeCharacter;
		}
		object obj2 = default(object);
		if (gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			GameSessionData gameSessionData2 = _gameSessionData;
			Transform transform = gameSessionData2._activeCharacter.transform;
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj = obj2 - 64;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
			Vector3 vector = (Vector3)(obj2 - 48);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
			_ = 0;
			EnemyController enemyController = _stage.FindClosestEnemy(vector);
			bool flag2 = (object)enemyController == null;
			nint num = (nint)vector;
			if (!flag2)
			{
				bool flag3 = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
				num = (nint)vector;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
					_ = 0;
					object obj3 = obj2 - 48;
					Gizmos.set_color_Injected(ref *(Color*)obj3);
					Transform transform2 = enemyController.transform;
					bool flag4 = (object)transform2 == null;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v943 @ rax_v75 (UnityEngine.Transform)+10]");
					bool flag5 = (nint)0 == 0;
					num = (nint)(obj2 - 64);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v943 @ rax_v75 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)num);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
					_ = 0;
					object obj4 = obj2 - 48;
					Gizmos.DrawWireSphere_Injected(ref *(Vector3*)obj4, (float)num);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
					_ = 0;
					object obj5 = obj2 - 64;
					Gizmos.set_color_Injected(ref *(Color*)obj5);
				}
			}
		}
		bool flag6 = (object)_003CHardBounds_003Ek__BackingField == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.GameManager)+388]");
		_ = 0;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
			_ = 0;
			object obj6 = obj2 - 16;
			Gizmos.set_color_Injected(ref *(Color*)obj6);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.GameManager)+388]");
			_ = 0;
			_ = _003CHardBounds_003Ek__BackingField;
			bool flag7 = (object)_003CHardBounds_003Ek__BackingField == null;
			bool flag8 = (object)_003CHardBounds_003Ek__BackingField == null;
			_ = 0;
			_ = 0;
			object obj7 = obj2 - 48;
			object obj8 = obj2 - 64;
			Gizmos.DrawWireCube_Injected(ref *(Vector3*)obj8, ref *(Vector3*)obj7);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			object obj9 = obj2 - 16;
			Gizmos.set_color_Injected(ref *(Color*)obj9);
		}
	}

	public void DeactivatePreloader()
	{
		_Preloader.SetActive(value: false);
	}

	public void PauseGame()
	{
		//IL_0109: Expected I4, but got O
		//IL_0109: Expected I4, but got F4
		Debug.Log("Pausing game");
		_isPaused = true;
		float num2 = default(float);
		object obj = default(object);
		object[] array = default(object[]);
		if ("DefaultGameTweenId" != null)
		{
			int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Pause, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)"DefaultGameTweenId", false, num2, obj, array);
		}
		Physics2D.simulationMode = SimulationMode2D.Script;
		if ((object)ArcadePhysics.s_instance != null)
		{
			_ = 1;
			ArcadePhysics.s_world.emit(WorldEvents.PauseEvent);
			PauseSystem._paused = true;
			GraphicRaycaster component = _GameCanvas.GetComponent<GraphicRaycaster>();
			component.enabled = false;
			if (_safetyPause == null)
			{
				Action onComplete = PauseGame;
				TimerType type = default(TimerType);
				Timer safetyPause = Timers.Register(0.1f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)obj, (int)array, type, isOnlineTimer: false, canPause: false);
				_safetyPause = safetyPause;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void ResumeGame()
	{
		if (_safetyPause != null)
		{
			_safetyPause.Cancel();
		}
		_safetyPause = null;
		_isPaused = false;
		if ("DefaultGameTweenId" != null)
		{
			float optionalFloat = default(float);
			object optionalObj = default(object);
			object[] optionalArray = default(object[]);
			int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Play, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)"DefaultGameTweenId", false, optionalFloat, optionalObj, optionalArray);
		}
		Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
		MasterAudio.UnpauseMixer();
		bool flag = (object)ArcadePhysics.s_instance == null;
		_ = 0;
		ArcadePhysics.s_world.emit(WorldEvents.ResumeEvent);
		PauseSystem._paused = false;
		GraphicRaycaster component = _GameCanvas.GetComponent<GraphicRaycaster>();
		component.enabled = true;
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CShowPlayerIndicators_003Ek__BackingField)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			if (!((VampireSurvivors.Objects.Characters.CharacterController)null).IsDisconnectedFromOnlinePlay)
			{
				((VampireSurvivors.Objects.Characters.CharacterController)null).ShowMultiplayerIndicator();
			}
		}
	}

	public void RemoveTickerTimer()
	{
		_canRunTickerTimer = false;
	}

	public void ResumeTickerTimer()
	{
		_canRunTickerTimer = true;
	}

	public void SummonWhiteHand(bool forceStageTimerEnd = false)
	{
		_WhiteHandManager.SummonWhiteHand(forceStageTimerEnd);
	}

	public void ForceStageTimerEnd()
	{
		//IL_0080: Expected O, but got I
		//IL_0095: Expected O, but got I
		//IL_00aa: Expected O, but got I
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		PlayerOptionsData config = _playerOptions.Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v12 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v12 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v17+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v16+98]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rax_v26+10]");
			bool flag = (nint)0 == 0;
			float num = 1800f;
			if (!flag)
			{
				float num2 = default(float);
				num = num2;
			}
			GameManager core = GM.Core;
			float num3 = num + 60f;
			if (num3 > core._003CSurvivedSeconds_003Ek__BackingField)
			{
				float num4 = num + 60f;
				core._003CSurvivedSeconds_003Ek__BackingField = num4;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public void TransitionToFoscari2()
	{
		GameManager core = GM.Core;
		PlayerOptions playerOptions = core._playerOptions;
		playerOptions._onlineClientWithRunDataConfig = null;
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.FOSCARI2;
		GameManager core3 = GM.Core;
		PlayerOptionsData config2 = core3._playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Foscari2;
		GameManager core4 = GM.Core;
		PlayerOptionsData config3 = core4._playerOptions.Config;
		config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GM.Core.TogglePlayerHealthBar(visible: false);
		GameManager core5 = GM.Core;
		core5._restartingGameScene = true;
		core5.ResetGameSession(disconnectFromCoherence: false);
		core5.GoToPreloadScene();
	}

	public void TransitionToTP_ADV_001_Stage_DEATHFIGHT()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB3060");
		GameManager core = GM.Core;
		PlayerOptions playerOptions = core._playerOptions;
		playerOptions._onlineClientWithRunDataConfig = null;
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.ADV_OTC_001_009_DeathFight;
		GameManager core3 = GM.Core;
		core3._restartingGameScene = true;
		core3.ResetGameSession(disconnectFromCoherence: false);
		core3.GoToPreloadScene();
	}

	public void RestartGameScene(bool shouldShowTransition = false)
	{
		_restartingGameScene = true;
		ResetGameSession(disconnectFromCoherence: false);
		if (shouldShowTransition)
		{
			GameManager core = GM.Core;
			Action onCompleteCallback = delegate
			{
				GoToPreloadScene();
			};
			core._003CMainUI_003Ek__BackingField.PerformSceneTransition(onCompleteCallback);
		}
		else
		{
			GoToPreloadScene();
		}
	}

	private static IEnumerator WaitForEveryoneToResetGameSession()
	{
		_003CWaitForEveryoneToResetGameSession_003Ed__446 obj = null;
		obj._003C_003E1__state = 0;
		return obj;
	}

	public void ResetGameToMenu()
	{
		//IL_0029: Expected O, but got I4
		ResetGameSession();
		_playerOptions.DestroyOnlineConfigs();
		Scene scene = SceneManager.LoadScene("ScenePreloader", (LoadSceneParameters)1);
	}

	private void GoToPreloadScene()
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			SceneManager.LoadScene("ScenePreloader", LoadSceneMode.Additive);
			return;
		}
		Debug.Log("<color=green>WaitingForSessionReset</color>");
		OnlineStageManager instance = OnlineStageManager._instance;
		(string, object)[] args = Array.Empty<(string, object)>();
		instance._logger.Info("Resetting Game Session Variables", args);
		instance._signalledGameStart = false;
		instance._signalledInitStage = false;
		PlayerInfo myPlayerInfo = instance.GetMyPlayerInfo();
		if ((object)myPlayerInfo != null && ((UnityEngine.Object)myPlayerInfo).m_CachedPtr != (IntPtr)0)
		{
			Debug.Log("Resetting Player Info Session Variables");
			myPlayerInfo._sceneLoaded = false;
			myPlayerInfo._stageInitialized = false;
		}
		if (GM.Core.IsStageHost)
		{
			_003CWaitForEveryoneToResetGameSession_003Ed__446 obj = null;
			obj._003C_003E1__state = 0;
			Coroutine coroutine = OnlineStageManager._instance.StartCoroutine(obj);
		}
	}

	public IEnumerator SnapshotRecap(Action onComplete)
	{
		_003CSnapshotRecap_003Ed__449 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.onComplete = onComplete;
		return obj;
	}

	public void ClearRecapScreenshot()
	{
		Texture2D recapTex = _recapTex;
		if ((object)_recapTex != null && ((UnityEngine.Object)recapTex).m_CachedPtr != (IntPtr)0)
		{
			UnityEngine.Object.DestroyImmediate(_recapTex, allowDestroyingAssets: false);
			_recapTex = null;
		}
	}

	public void EnterCreditEndingScene()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void EnterGameEndScene()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public bool TeleportMyPlayerToRemotePlayer(VampireSurvivors.Objects.Characters.CharacterController remotePlayer, Action onYoyo)
	{
		//IL_00d3: Expected O, but got I
		//IL_02c1->IL0217: Incompatible stack heights: 1 vs 0
		//IL_01a6->IL0217: Incompatible stack heights: 1 vs 0
		//IL_03b1->IL0217: Incompatible stack heights: 6 vs 0
		//IL_01eb->IL03c4: Incompatible stack heights: 6 vs 0
		if ((object)remotePlayer != null)
		{
			CoherenceSync coherenceSync = remotePlayer._coherenceSync;
			if ((object)remotePlayer._coherenceSync != null)
			{
				NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
				if (coherenceSync._003CEntityState_003Ek__BackingField == null)
				{
					goto IL_01eb;
				}
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v28 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					bool flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v28 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v28 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						bool flag2 = obj == null;
						flag = flag2;
					}
					if (flag)
					{
						goto IL_01eb;
					}
					if ((object)OnlineStageManager._instance != null)
					{
						PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
						if ((object)myPlayerInfo != null)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
							Transform transform = remotePlayer.transform;
							if ((object)transform != null)
							{
								bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
								if ((object)characterController != null)
								{
									float2 position = default(float2);
									characterController.position = position;
									CoherenceSync coopCameraTarget = (CoherenceSync)(object)_coopCameraTarget;
									Transform transform2 = characterController.transform;
									if ((object)transform2 != null)
									{
										bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
										bool flag5 = (object)_coopCameraTarget == null;
										bool flag6 = ((UnityEngine.Object)coopCameraTarget).m_CachedPtr == (IntPtr)0;
										Vector3 value = default(Vector3);
										Transform.set_position_Injected(((UnityEngine.Object)coopCameraTarget).m_CachedPtr, ref value);
										Transform transform3 = characterController.transform;
										bool flag7 = (object)transform3 == null;
										bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
										if ((object)_stage != null)
										{
											_stage.DoTeleportVfx(position, null, onYoyo);
											return true;
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
		IL_01eb:
		if (onYoyo != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onYoyo.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		return false;
	}

	public void TeleportPlayers(float2 position, float2 offsetForEachPlayer, bool centered = false, bool focusCameraOnPlayer = true)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_003c: Expected O, but got I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected F4, but got Unknown
		//IL_046f: Expected O, but got I4
		//IL_0478: Expected O, but got I4
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0217: Expected O, but got I
		//IL_0493: Expected O, but got I
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_0231: Expected O, but got I
		//IL_0289: Expected O, but got I
		object obj3 = default(object);
		float num4;
		float num5 = default(float);
		if (centered)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = offsetForEachPlayer ^ 0;
			object obj2 = characters._size - 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float num = obj3 ^ 0;
			float num2 = (float)obj2 * num;
			float num3 = num2 * 0.5f;
			num4 = num5 + num3;
		}
		else
		{
			num4 = num5;
		}
		GameManager core = GM.Core;
		bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
		object obj5 = default(object);
		object obj4 = obj5 & isOnlineMultiplayer;
		if (obj4 != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (!config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				Action manualCameraTargetControl = OnlineFocusCameraOnMyPlayer;
				ManualCameraTargetControl = manualCameraTargetControl;
			}
		}
		int num6;
		if (_multiplayer.IsOnlineMultiplayer)
		{
			int mySeatNumber = OnlineStageManager._instance.GetMySeatNumber();
			num6 = mySeatNumber;
		}
		else
		{
			num6 = 0;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
		object obj6 = 0;
		object obj7 = 0;
		float2 position2 = default(float2);
		while (true)
		{
			if ((nint)obj6 < characters2._size)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = _characters;
				if ((nint)obj7 >= characters3._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters3._items;
				ArcadeSprite arcadeSprite = items[obj7];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rbp_v5 (ArcadeSprite)+A8]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rsi_v5+160]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rsi_v5+160]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v39+20]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v31+10]");
					bool flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v31+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v31+10]");
						object obj11 = -3;
						bool flag2 = obj11 == null;
						flag = flag2;
					}
					if (!flag)
					{
						goto IL_02e0;
					}
				}
				object obj12 = num6 + obj7;
				object obj = obj3 * obj12;
				float num = num4 + (float)obj;
				arcadeSprite.position = position2;
				goto IL_02e0;
			}
			GameManager core2 = GM.Core;
			bool isOnlineMultiplayer2 = core2._multiplayer.IsOnlineMultiplayer;
			object obj13 = obj5 & isOnlineMultiplayer2;
			if (obj13 == null)
			{
				return;
			}
			PlayerOptions playerOptions = _playerOptions;
			PlayerOptionsData playerOptionsData;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_04f6;
						}
					}
					playerOptionsData = playerOptions._mainGameConfig;
				}
				else
				{
					playerOptionsData = playerOptions._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
			}
			goto IL_04f6;
			IL_02e0:
			characters2 = _characters;
			obj7++;
			obj6 = obj7;
			continue;
			IL_04f6:
			if (!playerOptionsData._003CSelectedOnlineFreeRoam_003Ek__BackingField)
			{
				_003CRemoveManualCameraControl_003Ed__455 obj14 = null;
				obj14._003C_003E1__state = 0;
				obj14._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(obj14);
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private IEnumerator RemoveManualCameraControl()
	{
		_003CRemoveManualCameraControl_003Ed__455 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private bool IsAnyPlayerOutsideBounds(ArcadeBodyBounds bounds)
	{
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite = null;
			throw new NullReferenceException();
		}
		return false;
	}

	private void OnlineFocusCameraOnMyPlayer()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				Debug.LogError("This method is meant to be called in an online multiplayer context.");
				return;
			}
			if ((object)OnlineStageManager._instance != null)
			{
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				if ((object)myPlayerInfo != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
					GameManager coopCameraTarget = (GameManager)(object)_coopCameraTarget;
					if ((object)characterController != null)
					{
						Transform cameraTarget = characterController.CameraTarget;
						if ((object)cameraTarget != null)
						{
							bool flag = ((UnityEngine.Object)cameraTarget).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)cameraTarget).m_CachedPtr, out Vector3 _);
							bool flag2 = (object)_coopCameraTarget == null;
							bool flag3 = ((UnityEngine.Object)coopCameraTarget).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)coopCameraTarget).m_CachedPtr, ref value);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public VampireSurvivors.Objects.Characters.CharacterController GetClosestPlayer(float2 position, PlayerInclusionMode inclusionMode = PlayerInclusionMode.AliveOrDead, float maxRangeSqrd = 3.4028235E+38f, bool includeFollowers = true)
	{
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Expected O, but got Unknown
		//IL_04d0: Expected O, but got I4
		//IL_0692: Expected O, but got I
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_026f: Expected O, but got I
		//IL_0285: Expected O, but got I
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		if (characters._size != 1)
		{
			float num = maxRangeSqrd;
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
			List<VampireSurvivors.Objects.Characters.CharacterController> list = characters;
			VampireSurvivors.Objects.Characters.CharacterController characterController4 = default(VampireSurvivors.Objects.Characters.CharacterController);
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = default(VampireSurvivors.Objects.Characters.CharacterController);
			Component component = default(Component);
			object obj5 = default(object);
			ArcadeSprite arcadeSprite = default(ArcadeSprite);
			object obj8 = default(object);
			object obj9 = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController6 = default(VampireSurvivors.Objects.Characters.CharacterController);
			for (VampireSurvivors.Objects.Characters.CharacterController characterController3 = null; (nint)characterController3 < list._size; list = _characters, characterController = (VampireSurvivors.Objects.Characters.CharacterController)(characterController + 1), characterController3 = characterController)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
				if ((nint)characterController >= characters2._size)
				{
					goto IL_062b;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
				if ((nint)characterController < items.Length)
				{
					if (items[(object)characterController].IsDisconnectedFromOnlinePlay)
					{
						continue;
					}
					if (inclusionMode == PlayerInclusionMode.OnlyAlive || inclusionMode == PlayerInclusionMode.AlivePreferred)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if (characterController4._isDead || characterController4.IsDisconnectedFromOnlinePlay)
						{
							continue;
						}
					}
					if (inclusionMode == PlayerInclusionMode.OnlyDead)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if (!characterController5._isDead && !characterController5.IsDisconnectedFromOnlinePlay)
						{
							continue;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					GameObject gameObject = component.gameObject;
					if (!gameObject.activeInHierarchy)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v49+340]");
					bool flag = (nint)0 == 0;
					bool flag2 = true;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v49+340]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1114 @ rcx_v43+28]");
						object obj2 = -3;
						bool flag3 = obj2 == null;
						flag2 = !flag3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v49+64]");
					object obj3 = (nint)0 >> 31;
					object obj4 = flag2 & obj3;
					if (obj4 == null || obj5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						float2 position2 = arcadeSprite.position;
						object obj6 = position - position2;
						object obj7 = obj8 - obj9;
						object obj10 = obj6 * obj6;
						object obj11 = obj7 * obj7;
						float num2 = (float)obj11 + (float)obj10;
						if (num > num2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							num = num2;
							characterController2 = characterController6;
						}
					}
					continue;
				}
				goto IL_0651;
			}
			if (inclusionMode == PlayerInclusionMode.AlivePreferred && ((object)characterController2 == null || ((UnityEngine.Object)characterController2).m_CachedPtr == (IntPtr)0))
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = _characters;
				VampireSurvivors.Objects.Characters.CharacterController characterController7 = null;
				VampireSurvivors.Objects.Characters.CharacterController characterController8 = null;
				float num3 = maxRangeSqrd;
				ArcadeSprite arcadeSprite2 = default(ArcadeSprite);
				VampireSurvivors.Objects.Characters.CharacterController characterController10 = default(VampireSurvivors.Objects.Characters.CharacterController);
				while ((nint)characterController8 < characters3._size)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> characters4 = _characters;
					if ((nint)characterController7 >= characters4._size)
					{
						goto IL_062b;
					}
					VampireSurvivors.Objects.Characters.CharacterController[] items2 = characters4._items;
					if ((nint)characterController7 < items2.Length)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController9 = items2[(object)characterController7];
						bool flag4 = characterController9._deficiencyControl == null;
						bool flag5 = true;
						if (!flag4)
						{
							CharacterADControl deficiencyControl = characterController9._deficiencyControl;
							object obj12 = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
							bool flag6 = obj12 == null;
							flag5 = !flag6;
						}
						int num4 = characterController9._PlayerIndex >> 31;
						if (((flag5 ? 1u : 0u) & (uint)num4) == 0 || obj5 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							float2 position3 = arcadeSprite2.position;
							object obj13 = position - position3;
							object obj14 = obj8 - obj9;
							object obj10 = obj13 * obj13;
							object obj15 = obj14 * obj14;
							float num2 = (float)obj15 + (float)obj10;
							if (num3 > num2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								characterController2 = characterController10;
								num3 = num2;
							}
						}
						characters3 = _characters;
						characterController7 = (VampireSurvivors.Objects.Characters.CharacterController)(characterController7 + 1);
						bool flag7 = _characters != null;
						characterController8 = characterController7;
						if (flag7)
						{
							continue;
						}
						goto IL_0645;
					}
					goto IL_0651;
				}
			}
			return characterController2;
		}
		if (characters._size <= 0)
		{
			goto IL_062b;
		}
		VampireSurvivors.Objects.Characters.CharacterController[] items3 = characters._items;
		if (items3.Length > 0)
		{
			return items3[0];
		}
		goto IL_0651;
		IL_0651:
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new IndexOutOfRangeException();
		IL_062b:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0645;
		IL_0645:
		throw new NullReferenceException();
	}

	public int GetAlivePlayerCount(bool countRevivingPlayerAsAlive = false, bool includeOnlyMainCharacters = false)
	{
		//IL_028c: Expected I4, but got O
		//IL_022b: Expected F8, but got I
		List<VampireSurvivors.Objects.Characters.CharacterController> list = _characters;
		if (includeOnlyMainCharacters)
		{
			list = _mainCharacters;
		}
		if (list != null)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			double num5 = default(double);
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			while (true)
			{
				double num4;
				if (num2 < list._size)
				{
					if (includeOnlyMainCharacters)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						if (obj == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v20+3AC]");
						if ((nint)0 == 0)
						{
							goto IL_02af;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if ((object)characterController == null)
					{
						break;
					}
					if (characterController.IsDisconnectedFromOnlinePlay)
					{
						goto IL_02af;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if ((object)characterController2 == null)
					{
						break;
					}
					if (!characterController2._isDead)
					{
						bool isDisconnectedFromOnlinePlay = characterController2.IsDisconnectedFromOnlinePlay;
						bool flag = !isDisconnectedFromOnlinePlay;
						num4 = num5;
						if (flag)
						{
							goto IL_025e;
						}
					}
					if (!countRevivingPlayerAsAlive)
					{
						goto IL_02af;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (obj2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v15+330]");
					if ((nint)0 == 0)
					{
						goto IL_02af;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					if (obj3 == null)
					{
						break;
					}
					object obj4 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v366 @ rdx_v12+5A8] (should have been resolved before IL gen)");
					if (obj5 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+10h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v18+18]");
					num4 = EggDouble.Cap(0.0);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm6\"");
					bool flag2 = (nint)obj5 < 0;
					num5 = num4;
					if (flag2)
					{
						goto IL_02af;
					}
					goto IL_025e;
				}
				return num;
				IL_02af:
				num3++;
				num2 = num3;
				continue;
				IL_025e:
				num++;
				num5 = num4;
				goto IL_02af;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public unsafe void UpdateMainPlayersEligibleForLevelUp()
	{
		//IL_0086: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController> charactersLevelingUp = _charactersLevelingUp;
		int version = charactersLevelingUp._version + 1;
		charactersLevelingUp._version = version;
		charactersLevelingUp._size = 0;
		if (charactersLevelingUp._size > 0)
		{
			Array.Clear(charactersLevelingUp._items, 0, charactersLevelingUp._size);
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public unsafe int GetNonFollowerMainCharacterCount()
	{
		//IL_0025: Expected O, but got Ref
		int result = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public unsafe int GetNonFollowerMainCharacterInCoffinCount()
	{
		//IL_0025: Expected O, but got Ref
		int result = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public void ClearAllPlayerRevives()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < characters._size)
			{
				if ((nint)obj >= characters._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
				PlayerModifierStats playerStats = characterController._playerStats;
				EggDouble eggDouble = playerStats._003CRevivals_003Ek__BackingField;
				if (0L <= 9218868437227405312L)
				{
					obj++;
					eggDouble._val = 0.0;
					obj2 = obj;
				}
				else
				{
					obj++;
					eggDouble._val = 1.7976931348623157E+308;
					obj2 = obj;
				}
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void RosaryDamage(bool showVfx = true, float volume = 1.8f, WeaponType damageType = WeaponType.ROSARY, bool setDark = false)
	{
		//IL_0093: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		//IL_0129: Expected O, but got Ref
		//IL_02a1: Expected O, but got I
		//IL_0361: Expected O, but got I
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Expected O, but got Unknown
		//IL_0676: Expected O, but got I4
		//IL_03b1: Invalid comparison between F4 and I4
		//IL_03c9: Invalid comparison between F4 and O
		//IL_042b: Invalid comparison between F4 and I4
		//IL_043e: Invalid comparison between O and F4
		//IL_0484: Invalid comparison between F4 and I4
		//IL_0492: Invalid comparison between F4 and O
		//IL_04d5: Invalid comparison between O and F4
		//IL_04f3: Invalid comparison between F4 and I4
		//IL_051c: Expected O, but got I4
		//IL_056a: Expected F4, but got I
		//IL_058b: Invalid comparison between F4 and I4
		//IL_05a2: Invalid comparison between F4 and I
		//IL_0658->IL05c7: Incompatible stack heights: 1 vs 0
		//IL_0145->IL05c7: Incompatible stack heights: 1 vs 0
		//IL_028c->IL05c7: Incompatible stack heights: 1 vs 0
		//IL_0186->IL0186: Incompatible stack heights: 1 vs 0
		//IL_02c1->IL05c7: Incompatible stack heights: 1 vs 0
		//IL_034b->IL05c7: Incompatible stack heights: 1 vs 0
		//IL_037d->IL05c7: Incompatible stack heights: 1 vs 0
		//IL_0687->IL06a7: Incompatible stack heights: 1 vs 0
		//IL_068c->IL0601: Incompatible stack heights: 1 vs 0
		Stage stage = _stage;
		if ((object)_stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				object obj = config._003CFlashingVFXEnabled_003Ek__BackingField & showVfx;
				bool flag = obj == null;
				WeaponType weaponType = damageType;
				Transform transform = null;
				if (flag)
				{
					goto IL_0186;
				}
				Camera main = Camera.main;
				if ((object)main != null)
				{
					Transform transform2 = main.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						float ret;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
						ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.RosaryVfx);
						if ((object)pool != null)
						{
							RosaryVfx objectComponent = pool.GetObjectComponent<RosaryVfx>((Vector3)(&ret));
							if ((object)objectComponent != null)
							{
								objectComponent.SetParent(transform2);
								bool setDark2 = default(bool);
								objectComponent.Play(volume, setDark2);
								float num = volume;
								weaponType = WeaponType.VOID;
								transform = transform2;
								goto IL_0186;
							}
						}
					}
				}
			}
		}
		goto IL_05c7;
		IL_05c7:
		throw new NullReferenceException();
		IL_0186:
		Stage stage2 = _stage;
		if ((object)_stage != null)
		{
			List<EnemyController> spawnedEnemies = stage2._spawnedEnemies;
			bool flag3 = (nint)stage2._spawnedEnemies < 0;
			if (stage2._spawnedEnemies != null)
			{
				object obj2 = spawnedEnemies._size - 1;
				if (flag3)
				{
					return;
				}
				Rect rect = default(Rect);
				Rect rect2 = default(Rect);
				Rect rect4 = default(Rect);
				float num5 = default(float);
				while (true)
				{
					Stage stage3 = _stage;
					if ((object)_stage == null)
					{
						break;
					}
					List<EnemyController> spawnedEnemies2 = stage3._spawnedEnemies;
					if (stage3._spawnedEnemies == null)
					{
						break;
					}
					bool flag4 = (nint)obj2 >= spawnedEnemies2._size;
					Stage items = (Stage)(object)spawnedEnemies2._items;
					if (spawnedEnemies2._items == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v12 (VampireSurvivors.Objects.Stage)+20+v434 @ rdi_v14*8]");
					Component component = (Component)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v12 (VampireSurvivors.Objects.Stage)+20+v434 @ rdi_v14*8]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v13 (UnityEngine.Component)+20C]");
					bool flag5;
					Rect rect3;
					if ((nint)0 != 0)
					{
						flag5 = (nint)rect < 0;
						bool flag6 = (nint)rect > 0;
						rect2 = rect;
						rect3 = rect;
						if (flag6)
						{
							goto IL_065d;
						}
					}
					Stage stage4 = _stage;
					if ((object)_stage == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rbx_v12 (VampireSurvivors.Objects.Stage)+20+v434 @ rdi_v14*8]");
					Transform transform3 = ((Component)0).transform;
					if ((object)transform3 == null)
					{
						break;
					}
					Vector3 position = transform3.position;
					float num2 = position.x - (float)stage4._containmentScreenRect;
					flag5 = num2 < 0f;
					float x = position.x;
					Rect containmentScreenRect = stage4._containmentScreenRect;
					bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect);
					rect3 = rect2;
					float num = position.x;
					Transform transform = transform3;
					if (!flag7)
					{
						rect3 = (Rect)((object)rect4 + (object)stage4._containmentScreenRect);
						float num3 = (float)rect3 - position.x;
						flag5 = num3 < 0f;
						bool flag8 = System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect3) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)position.x);
						num = position.x;
						transform = transform3;
						if (!flag8)
						{
							float num4 = num5 - (float)rect4;
							flag5 = num4 < 0f;
							bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect4);
							rect3 = rect4;
							num = num5;
							transform = transform3;
							if (!flag9)
							{
								rect3 = (Rect)((object)rect4 + (object)rect4);
								bool flag10 = System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5);
								float num6 = (float)rect3 - num5;
								bool flag11 = num6 == 0f;
								bool flag12 = !flag10;
								bool flag13 = !flag11;
								object obj3 = flag13 & flag12;
								flag5 = (nint)obj3 < 0;
								bool flag14 = obj3 == null;
								num = num5;
								transform = transform3;
								if (!flag14)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v13 (UnityEngine.Component)+1EC]");
									num = 0f;
									float num7 = 66f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v13 (UnityEngine.Component)+1EC]");
									float num8 = num7 - 0f;
									flag5 = num8 < 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v13 (UnityEngine.Component)+1EC]");
									if (66f > 0f)
									{
										num = 66f;
									}
									transform = (Transform)component;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v720 @ rdx_v13 (UnityEngine.Transform)+3E8] (should have been resolved before IL gen)");
								}
							}
						}
					}
					goto IL_065d;
					IL_065d:
					obj2--;
					object obj4 = !flag5;
					rect2 = rect3;
					if (obj4 == null)
					{
						return;
					}
				}
			}
		}
		goto IL_05c7;
	}

	private unsafe void StopTime(GameplaySignals.TimeStopSignal signal)
	{
		//IL_0061: Expected I4, but got O
		//IL_05dc: Expected I4, but got F4
		//IL_02b4: Expected I4, but got O
		//IL_02e9: Expected O, but got I
		//IL_0415: Expected I, but got O
		//IL_042b: Expected O, but got I
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_03d3: Expected I4, but got F4
		//IL_04af: Expected I, but got O
		//IL_015a: Expected O, but got Ref
		//IL_064e: Expected O, but got I4
		//IL_0665: Expected I, but got I8
		//IL_03f5: Expected O, but got I4
		//IL_0403: Expected O, but got I4
		//IL_048b: Expected I, but got I8
		//IL_021c: Expected O, but got I4
		//IL_0545->IL04b5: Incompatible stack heights: 1 vs 0
		//IL_032a->IL0593: Incompatible stack heights: 2 vs 0
		//IL_0176->IL04b5: Incompatible stack heights: 1 vs 0
		//IL_0351->IL0593: Incompatible stack heights: 2 vs 0
		//IL_01a0->IL04b5: Incompatible stack heights: 1 vs 0
		//IL_03c6->IL0593: Incompatible stack heights: 4 vs 0
		//IL_01e9->IL04b5: Incompatible stack heights: 1 vs 0
		//IL_025d->IL056a: Incompatible stack heights: 1 vs 0
		Stage stage = _stage;
		if ((object)_stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		_003CIsTimeStopped_003Ek__BackingField = true;
		_003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField = (byte)(int)signal != 0;
		bool canPause;
		float num = default(float);
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				object obj = default(object);
				if (!config._003CFlashingVFXEnabled_003Ek__BackingField || obj != null)
				{
					canPause = false;
					goto IL_056a;
				}
				Camera main = Camera.main;
				if ((object)main != null)
				{
					Transform transform = main.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.OrologionVfx);
						if ((object)pool != null)
						{
							OrologionVfx objectComponent = pool.GetObjectComponent<OrologionVfx>((Vector3)(&ret));
							if ((object)objectComponent != null)
							{
								Transform transform2 = objectComponent.transform;
								if ((object)transform2 != null)
								{
									Transform parent = transform2.parent;
									objectComponent._originalParent = parent;
									Transform transform3 = objectComponent.transform;
									if ((object)transform3 != null)
									{
										transform3.SetParent(transform, worldPositionStays: true);
										objectComponent.Init();
										objectComponent.PerformScreenFill();
										objectComponent.PerformShockwave();
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Orologion, new SoundManager.SoundConfig
										{
											Volume = (float?)(object)1,
											Rate = 2f
										}, 500f, 5, num);
										canPause = false;
										goto IL_056a;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04b5;
		IL_04b5:
		throw new NullReferenceException();
		IL_0645:
		object obj2 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool useRealTime;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer stopTimeTimer = Timers.Register(10f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
		_stopTimeTimer = stopTimeTimer;
		return;
		IL_056a:
		Stage stage2 = _stage;
		if ((object)_stage == null || stage2._spawnedEnemies == null)
		{
			goto IL_04b5;
		}
		EnemyController enemyController = null;
		List<EnemyController>.Enumerator spawnedEnemies = (List<EnemyController>.Enumerator)stage2._spawnedEnemies;
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		object obj3 = default(object);
		List<EnemyController>.Enumerator enumerator2 = default(List<EnemyController>.Enumerator);
		while (enumerator.MoveNext())
		{
			((EnemyController)null).TimeStop((byte)(int)signal != 0);
			Component arcanaManager = (Component)(object)_arcanaManager;
			bool flag2 = _arcanaManager == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1200 @ rcx_v43 (UnityEngine.Component)+B0]");
			Component component = (Component)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1200 @ rcx_v43 (UnityEngine.Component)+B0]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ rcx_v44 (UnityEngine.Component)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				if ((nint)obj3 != -1)
				{
					Transform transform4 = ((Component)null).transform;
					bool flag4 = (object)transform4 == null;
					Vector3 position = transform4.position;
					bool flag5 = _arcanaManager == null;
					_arcanaManager.TriggerColdExplosion((Vector2)enumerator2);
					enemyController = (EnemyController)enumerator2;
					spawnedEnemies = enumerator2;
				}
			}
		}
		Timer stopTimeTimer2 = _stopTimeTimer;
		bool flag6 = _stopTimeTimer == null;
		useRealTime = (byte)(int)num != 0;
		if (!flag6)
		{
			useRealTime = (byte)(int)num != 0;
			if (!_stopTimeTimer.IsDone)
			{
				float timeElapsed = _stopTimeTimer.GetTimeElapsed();
				stopTimeTimer2._timeElapsedBeforeCancel = (float?)(object)1;
				stopTimeTimer2._timeElapsedBeforePause = (float?)(object)0;
			}
		}
		action = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(GameManager.ClearTimeStop);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj4 = (nint)0 >> 4;
		object obj5 = obj4 & 1;
		nint num3;
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num3 = unchecked((nint)6447293664L);
				goto IL_0645;
			}
		}
		num3 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0645;
	}

	private unsafe void StopTimeForMilliseconds(float milliseconds)
	{
		//IL_0093: Expected I, but got O
		//IL_00a9: Expected O, but got I
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_012d: Expected I, but got O
		//IL_0219: Expected O, but got I4
		//IL_0230: Expected I, but got I8
		//IL_0073: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_0109: Expected I, but got I8
		if (_003CIsTimeStopped_003Ek__BackingField)
		{
			return;
		}
		_003CIsTimeStopped_003Ek__BackingField = true;
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		if (enumerator.MoveNext())
		{
			EnemyController enemyController = null;
			throw new NullReferenceException();
		}
		Timer stopTimeTimer = _stopTimeTimer;
		if (_stopTimeTimer != null && !_stopTimeTimer.IsDone)
		{
			float timeElapsed = _stopTimeTimer.GetTimeElapsed();
			stopTimeTimer._timeElapsedBeforeCancel = (float?)(object)1;
			stopTimeTimer._timeElapsedBeforePause = (float?)(object)0;
		}
		Action action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(GameManager.ClearTimeStop);
		((Delegate)action).m_target = this;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		nint num2;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num2 = unchecked((nint)6447293664L);
				goto IL_0210;
			}
		}
		num2 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0210;
		IL_0210:
		object obj3 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		float duration = milliseconds * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer stopTimeTimer2 = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_stopTimeTimer = stopTimeTimer2;
	}

	public void SpawnPickupEffectsParticles(Vector2 pos)
	{
		ParticleSystem pickupVfx = _pickupVfx;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag = ((UnityEngine.Object)pickupVfx).m_CachedPtr == (IntPtr)0;
		ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
		ParticleSystem.Emit_Injected(((UnityEngine.Object)pickupVfx).m_CachedPtr, ref emitParams, 10);
	}

	public void ShowHitVfxAt(Vector2 pos, HitVfxType showHitVfx)
	{
		VFXManager.SpawnImpactVFX(showHitVfx, pos);
	}

	public void ShowDamageAt(Vector2 pos, float value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2990");
	}

	public void ShowRecoveryAt(Vector2 pos, float value)
	{
		if (!(value < 1f))
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CDamageNumbersEnabled_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2990");
			}
		}
	}

	public unsafe Transform FindClosestEnemyToPlayer(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_003a: Expected O, but got Ref
		Transform transform = character.transform;
		if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
		{
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			object obj = default(object);
			EnemyController enemyController = _stage.FindClosestEnemy((Vector3)(&obj));
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				return enemyController._EnemyRenderer.transform;
			}
			return null;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		throw new NullReferenceException();
	}

	public unsafe void AddOnlineLevelUpToQueue(OnlineLevelUpData levelUpData)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0030: Expected O, but got Ref
		//IL_009d: Expected O, but got Ref
		//IL_010a: Expected O, but got Ref
		//IL_012c: Expected O, but got Ref
		//IL_0140: Expected native int or pointer, but got O
		//IL_0153: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = OnlineLevelUp;
		_ = levelUpData._003CTargetCharacter_003Ek__BackingField;
		_ = 9;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = levelUpData._003CChosenLevelUpWeapons_003Ek__BackingField;
		_ = levelUpData._003CChosenAmuletTargets_003Ek__BackingField;
		_ = levelUpData._003CShouldSwapToLevelUpUi_003Ek__BackingField;
		_ = levelUpData._003CAdjustXpFactors_003Ek__BackingField;
		object value = (OnlineLevelUpData)obj3;
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"levelUpData", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		UiTransition item = (UiTransition)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
		_ = 0;
		_queuedUiTransitions.Add(item);
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C1F0");
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 0;
		object arg = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
		System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-9]");
		_ = 0;
		string message = string.FormatHelper((IFormatProvider)null, "QUEUING LEVEL UP AT FRAME {0}", args);
		Debug.Log(message);
	}

	public unsafe void AddTreasureToQueue(Treasure treasure)
	{
		//IL_0048: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = SwapToTreasureScreen;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"treasure", (object)treasure, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	public unsafe void AddCharacterTypeToQueue(CharacterType characterType, VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
	{
		//IL_001d: Expected I4, but got O
		//IL_0055: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = SwapToCharFoundScreen;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj = default(object);
		object value = (CharacterType)obj;
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"characterType", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj2 = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj2));
	}

	public unsafe void AddRelicToQueue(ItemType itemType, VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
	{
		//IL_001d: Expected I4, but got O
		//IL_0055: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = SwapToRelicFoundScreen;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj = default(object);
		object value = (ItemType)obj;
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"itemType", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj2 = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj2));
	}

	public unsafe void AddFoundWeaponToQueue(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController targetPlayer)
	{
		//IL_001d: Expected I4, but got O
		//IL_0055: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = SwapToItemFoundScreen;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj = default(object);
		object value = (WeaponType)obj;
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"weaponType", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj2 = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj2));
	}

	public void MakeExplosion(Vector2 spawnPos, int moreX, int moreY)
	{
		//IL_0017: Expected F4, but got I4
		//IL_0017: Expected F4, but got I4
		_explosionManager.SpawnExplosion(spawnPos, moreX, moreY);
	}

	public Pickup MakeStagePickup(Vector2 pos, ItemType itemType = ItemType.COIN, WeaponType weaponType = WeaponType.VOID, float value = 0f, ItemType relicType = ItemType.VOID, bool validatePickups = true)
	{
		Pickup pickup;
		if (!IsStageHost && NetworkItems.IsNetworkItem(itemType))
		{
			pickup = null;
		}
		else
		{
			float value2 = default(float);
			ItemType relicType2 = default(ItemType);
			bool shouldCallValidatePickups = default(bool);
			bool isRemote = default(bool);
			bool onlineSynchronization = default(bool);
			pickup = MakePickup(pos, itemType, weaponType, value2, relicType2, shouldCallValidatePickups, isRemote, onlineSynchronization);
			if ((object)pickup == null)
			{
				goto IL_00e9;
			}
			pickup._003CIsStagePickup_003Ek__BackingField = true;
			RegisterStagePickup(pickup);
			object obj = default(object);
			if (obj != null)
			{
				if (_signalBus == null)
				{
					goto IL_00e9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4120");
			}
		}
		return pickup;
		IL_00e9:
		return (Pickup)(object)new NullReferenceException();
	}

	public void RegisterStagePickup(Pickup pickup)
	{
		Action<Pickup> action = OnStagePickupCallback;
		pickup._003CPickupCallback_003Ek__BackingField = action;
		((GameManager)(object)_stagePickups).OnStagePickupCallback(pickup);
	}

	public unsafe void MakeGem(Vector2 pos, float xp, Action<Pickup> callback = null)
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		_gemsToSpawn.Add((PickupToSpawn)(&obj));
	}

	public unsafe void MakeCoin(Vector2 pos, float value = 0f, Action<Pickup> callback = null)
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		_coinsToSpawn.Add((PickupToSpawn)(&obj));
	}

	public unsafe void MakeRedCoinBag(Vector2 pos, float value = 0f, Action<Pickup> callback = null)
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		_redCoinBagsToSpawn.Add((PickupToSpawn)(&obj));
	}

	public unsafe void MakeFrozenSoul(Vector2 pos, float value = 0f, Action<Pickup> callback = null)
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		_frozenSoulsToSpawn.Add((PickupToSpawn)(&obj));
	}

	public unsafe Gem MakeGemIgnoreAllTheLimits(Vector2 pos, float xp)
	{
		//IL_0017: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_0067: Expected I, but got O
		//IL_0077: Expected O, but got I
		//IL_00b3: Expected O, but got I
		ObjectPool gemPool = GemPool;
		if ((object)gemPool != null)
		{
			Vector2 vector = default(Vector2);
			Pickup objectComponent = gemPool.GetObjectComponent<Pickup>((Vector3)(&vector));
			if ((object)objectComponent != null && ((UnityEngine.Object)objectComponent).m_CachedPtr != (IntPtr)0)
			{
				nint num = (nint)typeof(Gem);
				nint num2 = (nint)objectComponent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v18+FFFFFFF8+v313 @ rax_v17*8]");
					if (0 == (nint)typeof(Gem))
					{
						objectComponent.SetData(ItemType.GEM);
						objectComponent.Time = 1f;
						((Gem)objectComponent).SetValue(xp);
						if (_gems != null)
						{
							bool flag = ((HashSet<object>)(object)_gems).AddIfNotPresent((object)objectComponent);
							return (Gem)objectComponent;
						}
						goto IL_015b;
					}
				}
			}
			else
			{
				Debug.LogError("Well, it appears limits were not ignored...");
			}
			return null;
		}
		goto IL_015b;
		IL_015b:
		return (Gem)(object)new NullReferenceException();
	}

	public TreasureChest MakeTreasure(Vector2 pos, Treasure treasure, bool isRemote = false)
	{
		//IL_00f3: Expected I, but got O
		//IL_0101: Expected I, but got O
		//IL_0111: Expected O, but got I
		//IL_0191: Expected O, but got I4
		//IL_014d: Expected O, but got I
		//IL_0183: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_02ed: Expected O, but got I4
		Pickup pickup;
		object obj3;
		TreasureChest treasureChest;
		if (isRemote || IsStageHost)
		{
			if (treasure == null)
			{
				goto IL_039e;
			}
			if (treasure._003CprizeTypes_003Ek__BackingField != null)
			{
				if (isRemote || IsStageHost || !NetworkItems.IsNetworkItem(ItemType.TREASURE))
				{
					pickup = PickupManager.CreatePickup(pos, ItemType.TREASURE);
					if ((object)pickup != null)
					{
						nint num = (nint)pickup;
						nint num2 = (nint)typeof(TreasureChest);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Items.TreasureChest>)+130]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Items.TreasureChest>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v49+FFFFFFF8+v452 @ rax_v45*8]");
							if (0 == (nint)typeof(TreasureChest))
							{
								obj3 = 1;
								goto IL_03cd;
							}
						}
						obj3 = 0;
						goto IL_03cd;
					}
				}
				treasureChest = null;
				goto IL_03f4;
			}
			Debug.LogError("Null treasure prize types :(");
		}
		goto IL_0394;
		IL_039e:
		return (TreasureChest)(object)new NullReferenceException();
		IL_03f4:
		if ((object)treasureChest == null || ((UnityEngine.Object)treasureChest).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0394;
		}
		treasureChest.SetData(ItemType.TREASURE, treasure);
		if (treasure._003CprizeTypes_003Ek__BackingField != null)
		{
			int num4 = ((List<System.Int32Enum?>)(object)treasure._003CprizeTypes_003Ek__BackingField).IndexOf((System.Int32Enum?)(object)1);
			if (num4 > -1)
			{
				treasureChest.SetWithEvo();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5000]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (~(treasure._003ChasArcana_003Ek__BackingField ? 1u : 0u) == 0)
			{
				treasureChest._hasArcana = true;
				treasureChest.SetFrame("BoxArcana");
				treasureChest.RemoveCursor();
				treasureChest.AddArcanaCursor();
			}
			if (treasure._003CprizeTypes_003Ek__BackingField != null)
			{
				int num5 = ((List<System.Int32Enum?>)(object)treasure._003CprizeTypes_003Ek__BackingField).IndexOf((System.Int32Enum?)(object)1);
				if (num5 > -1)
				{
					treasureChest.SetSpecial();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5002]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (~(treasure._003ChasRandoms_003Ek__BackingField ? 1u : 0u) == 0)
				{
					treasureChest._hasRandoms = true;
					treasureChest.SetFrame("BoxOpen4");
				}
				return treasureChest;
			}
		}
		goto IL_039e;
		IL_03cd:
		bool flag = obj3 == null;
		treasureChest = null;
		if (!flag)
		{
			treasureChest = (TreasureChest)pickup;
		}
		goto IL_03f4;
		IL_0394:
		return null;
	}

	public void MakeAndActivatePickup(ItemType itemType, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
	{
		if ((object)receivingCharacter != null)
		{
			Transform transform = receivingCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool shouldCallValidatePickups = default(bool);
				bool isRemote = default(bool);
				Pickup pickup = MakePickup(pos, itemType, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
				if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
				{
					PhysicsManager.TakePickup(pickup, receivingCharacter);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public Pickup MakePickup(Vector2 pos, ItemType itemType = ItemType.COIN, WeaponType weaponType = WeaponType.VOID, float value = 0f, ItemType relicType = ItemType.VOID, bool shouldCallValidatePickups = true, bool isRemote = false, bool onlineSynchronization = true)
	{
		//IL_0181: Expected I, but got O
		//IL_018f: Expected I, but got O
		//IL_019f: Expected O, but got I
		//IL_0388: Expected I, but got O
		//IL_0396: Expected I, but got O
		//IL_03a6: Expected O, but got I
		//IL_021f: Expected O, but got I4
		//IL_0426: Expected O, but got I4
		//IL_060b: Expected I4, but got O
		//IL_01db: Expected O, but got I
		//IL_03e2: Expected O, but got I
		//IL_0538: Expected F4, but got I
		//IL_023a: Expected I4, but got O
		//IL_0211: Expected O, but got I4
		//IL_0418: Expected O, but got I4
		bool flag = default(bool);
		object obj = default(object);
		if (flag && obj == null && !IsStageHost && NetworkItems.IsNetworkItem(itemType))
		{
			return null;
		}
		Pickup pickup;
		ItemType itemType2;
		PickupWeapon pickupWeapon;
		nint num;
		object obj4;
		System.Int32Enum int32Enum = default(System.Int32Enum);
		Pickup pickup2;
		PickupRelic pickupRelic;
		object obj7;
		Pickup pickup3;
		object message;
		bool flag2;
		if (itemType != ItemType.GEM)
		{
			if (itemType != ItemType.COIN)
			{
				if (itemType != ItemType.BONUS_FROZENSOUL)
				{
					if (itemType != ItemType.COINBAG1)
					{
						if (itemType == ItemType.WEAPON)
						{
							if (weaponType != WeaponType.VOID)
							{
								pickup = PickupManager.CreatePickup(pos, ItemType.WEAPON, flag);
								if ((object)pickup == null)
								{
									flag2 = flag;
									itemType2 = ItemType.WEAPON;
									pickupWeapon = null;
									goto IL_0623;
								}
								num = (nint)pickup;
								nint num2 = (nint)typeof(PickupWeapon);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rax_v69+FFFFFFF8+v645 @ rax_v65*8]");
									if (0 == (nint)typeof(PickupWeapon))
									{
										obj4 = 1;
										goto IL_05e6;
									}
								}
								obj4 = 0;
								goto IL_05e6;
							}
						}
						else if (itemType == ItemType.RELIC)
						{
							if (int32Enum != 0)
							{
								pickup2 = PickupManager.CreatePickup(pos, ItemType.RELIC, flag);
								if ((object)pickup2 == null)
								{
									pickupRelic = null;
									goto IL_0681;
								}
								nint num4 = (nint)pickup2;
								nint num5 = (nint)typeof(PickupRelic);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v743 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v743 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rax_v46+FFFFFFF8+v745 @ rax_v42*8]");
									if (0 == (nint)typeof(PickupRelic))
									{
										obj7 = 1;
										goto IL_065a;
									}
								}
								obj7 = 0;
								goto IL_065a;
							}
							goto IL_0547;
						}
						if (int32Enum != 0)
						{
							DataManager dataManager = _dataManager;
							if (_dataManager == null || dataManager._003CAllItems_003Ek__BackingField == null)
							{
								goto IL_05b5;
							}
							int num7 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).FindEntry(int32Enum);
							if (num7 < 0)
							{
								IntPtr intPtr = default(IntPtr);
								MakeCoin(pos, (nint)intPtr);
								pickup3 = null;
								goto IL_06a6;
							}
						}
						goto IL_0547;
					}
					message = "Please use 'GM.Core.MakeRedCoinBag' to spawn Red Coin Bags.";
				}
				else
				{
					message = "Please use 'GM.Core.MakeFrozenSoul' to spawn Frozen Souls.";
				}
			}
			else
			{
				message = "Please use 'GM.Core.MakeCoin' to spawn Coins.";
			}
		}
		else
		{
			message = "Please use 'GM.Core.MakeGem' to spawn Gems.";
		}
		Debug.LogError(message);
		pickup3 = null;
		goto IL_06a6;
		IL_0681:
		bool flag3 = (object)pickupRelic == null;
		Pickup result = pickup2;
		if (!flag3)
		{
			bool flag4 = ((UnityEngine.Object)pickupRelic).m_CachedPtr == (IntPtr)0;
			result = pickup2;
			if (!flag4)
			{
				pickupRelic.SetItemType((ItemType)int32Enum);
				result = pickup2;
			}
		}
		goto IL_0648;
		IL_05e6:
		bool flag5 = obj4 == null;
		flag2 = (byte)num != 0;
		itemType2 = (ItemType)typeof(PickupWeapon);
		pickupWeapon = null;
		if (!flag5)
		{
			flag2 = (byte)num != 0;
			itemType2 = (ItemType)typeof(PickupWeapon);
			pickupWeapon = (PickupWeapon)pickup;
		}
		goto IL_0623;
		IL_065a:
		bool flag6 = obj7 == null;
		pickupRelic = null;
		if (!flag6)
		{
			pickupRelic = (PickupRelic)pickup2;
		}
		goto IL_0681;
		IL_06a6:
		result = pickup3;
		goto IL_0648;
		IL_0648:
		return result;
		IL_05b5:
		return (Pickup)(object)new NullReferenceException();
		IL_0623:
		bool flag7 = (object)pickupWeapon == null;
		WeaponType weaponType2 = (WeaponType)itemType2;
		if (!flag7)
		{
			bool flag8 = ((UnityEngine.Object)pickupWeapon).m_CachedPtr == (IntPtr)0;
			weaponType2 = (WeaponType)itemType2;
			if (!flag8)
			{
				pickupWeapon.SetWeaponType(weaponType);
				flag2 = false;
				weaponType2 = weaponType;
			}
		}
		object obj8 = default(object);
		bool flag9 = obj8 == null;
		result = pickup;
		if (!flag9)
		{
			if (_signalBus == null)
			{
				goto IL_05b5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4120");
			result = pickup;
		}
		goto IL_0648;
		IL_0547:
		Pickup pickup4 = PickupManager.CreatePickup(pos, itemType, flag);
		result = pickup4;
		goto IL_0648;
	}

	public void ReturnGem(Gem gem)
	{
		ObjectPool gemPool = GemPool;
		GameObject obj = gem.gameObject;
		gemPool.Release(obj);
		bool flag = ((HashSet<object>)(object)_gems).Remove((object)gem);
	}

	public void ReturnCoin(Coin coin)
	{
		ObjectPool coinPool = CoinPool;
		GameObject obj = coin.gameObject;
		coinPool.Release(obj);
		bool flag = ((HashSet<object>)(object)_coins).Remove((object)coin);
	}

	public void ReturnRedCoinBag(CoinBag1 coinBag)
	{
		ObjectPool redCoinBagPool = RedCoinBagPool;
		GameObject obj = coinBag.gameObject;
		redCoinBagPool.Release(obj);
		bool flag = ((HashSet<object>)(object)_redCoinBags).Remove((object)coinBag);
	}

	public void ReturnFrozenSoul(Pickup_Bonus_FrozenSoul soul)
	{
		ObjectPool frozenSoulPool = FrozenSoulPool;
		GameObject obj = soul.gameObject;
		frozenSoulPool.Release(obj);
		bool flag = ((HashSet<object>)(object)_frozenSouls).Remove((object)soul);
	}

	public void StopTrackingFrozenSoul(Pickup_Bonus_FrozenSoul soul)
	{
		bool flag = ((HashSet<object>)(object)_frozenSouls).Remove((object)soul);
	}

	public void TurnOnVacuum(VampireSurvivors.Objects.Characters.CharacterController target = null)
	{
		//IL_0019: Expected I, but got O
		//IL_0071: Expected I, but got O
		//IL_018e: Expected I, but got O
		//IL_0202: Expected I, but got O
		//IL_0152: Expected I, but got O
		//IL_00e3: Expected I, but got O
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		OnlineStageManager onlineStageManager = default(OnlineStageManager);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v10 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			GameManager core = GM.Core;
			VampireSurvivors.Objects.Characters.CharacterController targetPlayer;
			if ((object)GM.Core != null)
			{
				bool flag = core._multiplayer == null;
				num2 = (nint)core._multiplayer;
				if (!flag)
				{
					if (!core._multiplayer.IsOnlineMultiplayer)
					{
						num2 = (nint)core._multiplayer;
						throw new NullReferenceException();
					}
					bool flag2 = (object)target == null;
					nint num3 = (nint)typeof(UnityEngine.Object);
					if (!flag2)
					{
						bool flag3 = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
						num3 = (nint)typeof(UnityEngine.Object);
						if (!flag3)
						{
							targetPlayer = target;
							goto IL_0172;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
					bool flag4 = (object)onlineStageManager == null;
					num2 = num3;
					if (!flag4)
					{
						PlayerInfo myPlayerInfo = onlineStageManager.GetMyPlayerInfo();
						bool flag5 = (object)myPlayerInfo == null;
						num2 = (nint)onlineStageManager;
						if (flag5)
						{
							break;
						}
						targetPlayer = myPlayerInfo.CharacterController;
						goto IL_0172;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_0172:
			((Pickup)null).TargetPlayer = targetPlayer;
			((Pickup)null).GoToPlayer = true;
		}
		throw new NullReferenceException();
	}

	public void TurnOnVacuumForGold()
	{
		List<Pickup> allPickupsOfTypes = PickupManager.GetAllPickupsOfTypes(new ItemType[4]
		{
			ItemType.COIN,
			ItemType.COINBAG1,
			ItemType.COINBAGMAX,
			ItemType.STATIC_GOLDPILE
		});
		((List<object>)(object)allPickupsOfTypes).InsertRange(allPickupsOfTypes._size, (IEnumerable<object>)_coins);
		((List<object>)(object)allPickupsOfTypes).InsertRange(allPickupsOfTypes._size, (IEnumerable<object>)_redCoinBags);
		List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
		if (enumerator.MoveNext())
		{
			Pickup pickup = null;
			throw new NullReferenceException();
		}
	}

	public void ZoomOnPlayer()
	{
		//IL_0043: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0121: Expected I, but got O
		//IL_02e7->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0093->IL023a: Incompatible stack heights: 1 vs 0
		//IL_00f2->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0166->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0144->IL0144: Incompatible stack heights: 2 vs 1
		//IL_01ae->IL023a: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass496_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass496_0();
		if ((object)_preZoomOrthoSize == null)
		{
			Camera main = Camera.main;
			if ((object)main == null)
			{
				goto IL_023a;
			}
			float orthographicSize = main.orthographicSize;
			_preZoomOrthoSize = (float?)(object)1;
			float? num = (float?)(object)1;
		}
		GameManager gameCanvas = (GameManager)(object)_GameCanvas;
		if ((object)_GameCanvas != null)
		{
			bool flag = ((UnityEngine.Object)gameCanvas).m_CachedPtr == (IntPtr)0;
			Canvas.set_renderMode_Injected(((UnityEngine.Object)gameCanvas).m_CachedPtr, RenderMode.WorldSpace);
			ZoomSize zoomSizeObject = new ZoomSize();
			if (CS_0024_003C_003E8__locals6 != null)
			{
				CS_0024_003C_003E8__locals6.zoomSizeObject = zoomSizeObject;
				ProCamera2D instance = ProCamera2D.Instance;
				if ((object)instance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v19 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					float startSize = 0f * 0.5f;
					CS_0024_003C_003E8__locals6.startSize = startSize;
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						if (CS_0024_003C_003E8__locals6.zoomSizeObject != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag2 = obj == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							Dictionary<string, object> dictionary = new Dictionary<string, object>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							if (dictionary != null)
							{
								object value = default(object);
								bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_currentSize", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								tweenConfig.custom = dictionary;
								TweenCallback onUpdate = delegate
								{
									ProCamera2D instance2 = ProCamera2D.Instance;
									ZoomSize zoomSizeObject2 = CS_0024_003C_003E8__locals6.zoomSizeObject;
									float num3 = zoomSizeObject2._currentSize * -0.1f;
									float newSize = num3 + CS_0024_003C_003E8__locals6.startSize;
									instance2.UpdateScreenSize(newSize);
								};
								tweenConfig.onUpdate = onUpdate;
								tweenConfig.duration = 900f;
								tweenConfig.ease = Ease.InOutCubic;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_023a;
		IL_023a:
		throw new NullReferenceException();
	}

	public void ZoomZoomOnPlayer()
	{
		//IL_0043: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0121: Expected I, but got O
		//IL_02e7->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0093->IL023a: Incompatible stack heights: 1 vs 0
		//IL_00f2->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0166->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0144->IL0144: Incompatible stack heights: 2 vs 1
		//IL_01ae->IL023a: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass497_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass497_0();
		if ((object)_preZoomOrthoSize == null)
		{
			Camera main = Camera.main;
			if ((object)main == null)
			{
				goto IL_023a;
			}
			float orthographicSize = main.orthographicSize;
			_preZoomOrthoSize = (float?)(object)1;
			float? num = (float?)(object)1;
		}
		GameManager gameCanvas = (GameManager)(object)_GameCanvas;
		if ((object)_GameCanvas != null)
		{
			bool flag = ((UnityEngine.Object)gameCanvas).m_CachedPtr == (IntPtr)0;
			Canvas.set_renderMode_Injected(((UnityEngine.Object)gameCanvas).m_CachedPtr, RenderMode.WorldSpace);
			ZoomSize zoomSizeObject = new ZoomSize();
			if (CS_0024_003C_003E8__locals6 != null)
			{
				CS_0024_003C_003E8__locals6.zoomSizeObject = zoomSizeObject;
				ProCamera2D instance = ProCamera2D.Instance;
				if ((object)instance != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v19 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
					float startSize = 0f * 0.5f;
					CS_0024_003C_003E8__locals6.startSize = startSize;
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if (array != null)
					{
						if (CS_0024_003C_003E8__locals6.zoomSizeObject != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj = default(object);
							bool flag2 = obj == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig != null)
						{
							tweenConfig.targets = array;
							Dictionary<string, object> dictionary = new Dictionary<string, object>();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							if (dictionary != null)
							{
								object value = default(object);
								bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_currentSize", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								tweenConfig.custom = dictionary;
								TweenCallback onUpdate = delegate
								{
									ProCamera2D instance2 = ProCamera2D.Instance;
									ZoomSize zoomSizeObject2 = CS_0024_003C_003E8__locals6.zoomSizeObject;
									float num3 = zoomSizeObject2._currentSize * -0.5f;
									float newSize = num3 + CS_0024_003C_003E8__locals6.startSize;
									instance2.UpdateScreenSize(newSize);
								};
								tweenConfig.onUpdate = onUpdate;
								tweenConfig.duration = 9000f;
								tweenConfig.ease = Ease.Linear;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_023a;
		IL_023a:
		throw new NullReferenceException();
	}

	public void ZoomCamera(float zoomAmount, float duration, EaseType easeType = EaseType.Linear)
	{
		ProCamera2D instance = ProCamera2D.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
		float num = 0f * 0.5f;
		float newSize = num + zoomAmount;
		instance.UpdateScreenSize(newSize, duration, easeType);
	}

	public void SetCanvasRenderMode(RenderMode renderMode)
	{
		_GameCanvas.renderMode = renderMode;
	}

	public void RemoveAllPlayersAsCameraTargets(float removePlayerTargetDuration)
	{
		ProCamera2D instance = ProCamera2D.Instance;
		instance.RemoveCameraTarget(_coopCameraTarget, removePlayerTargetDuration);
	}

	public void AddAllPlayersAsCameraTargets(float transitionDuration = 0f)
	{
		ProCamera2D instance = ProCamera2D.Instance;
		float duration = default(float);
		Vector2 targetOffset = default(Vector2);
		Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.AddCameraTarget(_coopCameraTarget, 1f, 1f, duration, targetOffset);
	}

	public unsafe void SetPlayerWorldBoundCollision(bool on)
	{
		//IL_0012: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public void StopCamera(Vector2 center, float removePlayerTargetDuration = 1f)
	{
		//IL_016e: Expected I4, but got F4
		ProCamera2D instance = ProCamera2D.Instance;
		instance.RemoveCameraTarget(_coopCameraTarget, removePlayerTargetDuration);
		Stage stage = _stage;
		TilingBackground tilingBackground = stage._tilingBackground;
		if ((object)stage._tilingBackground != null && ((UnityEngine.Object)tilingBackground).m_CachedPtr != (IntPtr)0)
		{
			Stage stage2 = _stage;
			TilingBackground tilingBackground2 = stage2._tilingBackground;
			tilingBackground2._canScroll = false;
		}
		SetPlayerWorldBoundCollision(on: true);
		Camera main = Camera.main;
		Bounds bounds = VampireSurvivors.Tools.CameraExtensions.OrthographicBounds(main);
		object obj = default(object);
		float num = (float)obj * 2f;
		Camera main2 = Camera.main;
		Bounds bounds2 = VampireSurvivors.Tools.CameraExtensions.OrthographicBounds(main2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rax_v18 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		float num3 = num * 0.5f;
		float x = (float)center - num3;
		float num4 = num2 * 0.5f;
		object obj2 = default(object);
		float y = (float)obj2 - num4;
		float height = default(float);
		bool? checkLeft = default(bool?);
		bool checkRight = default(bool);
		bool checkUp = default(bool);
		World world = ArcadePhysics.s_world.setBounds(x, y, num, height, checkLeft, checkRight, checkUp, (byte)(int)num2 != 0);
	}

	public void ResumeCamera()
	{
		AddAllPlayersAsCameraTargets();
		Stage stage = _stage;
		TilingBackground tilingBackground = stage._tilingBackground;
		if ((object)stage._tilingBackground != null && ((UnityEngine.Object)tilingBackground).m_CachedPtr != (IntPtr)0)
		{
			Stage stage2 = _stage;
			TilingBackground tilingBackground2 = stage2._tilingBackground;
			tilingBackground2._canScroll = true;
		}
		SetPlayerWorldBoundCollision(on: false);
	}

	public void SetHardBoundsMinMax(float xMin, float yMin, float xMax, float yMax, bool skipInverseCalculation = false)
	{
		object obj = default(object);
		float num = (float)obj * -0.01f;
		float num2 = yMin * -0.01f;
		float num3 = num2 - num;
		Rect? rect = default(Rect?);
		_003CHardBounds_003Ek__BackingField = rect;
		object obj2 = default(object);
		if (obj2 != null)
		{
			return;
		}
		Stage stage = _stage;
		StageData stageData = stage._stageData;
		if (stageData._003CisRacingStage_003Ek__BackingField)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CSelectedInverse_003Ek__BackingField)
		{
			return;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		if (config2._003CVisuallyInvertStages_003Ek__BackingField)
		{
			Stage stage2 = _stage;
			StageData stageData2 = stage2._stageData;
			if (stageData2._003CallowVisualInversion_003Ek__BackingField)
			{
				float num4 = num2 - num;
				_003CHardBounds_003Ek__BackingField = rect;
			}
		}
	}

	public void RemoveHardBounds()
	{
		//IL_000b: Expected O, but got I4
		_003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	public void CoinPickedup(Pickup pickup)
	{
		//IL_0033: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		List<Action<float>> list = _003COnCoinPickup_003Ek__BackingField;
		if (list._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		List<Action<float>> list2 = list;
		while (true)
		{
			if ((nint)obj < list2._size)
			{
				if ((nint)obj2 >= list._size)
				{
					break;
				}
				Action<float>[] items = list._items;
				Action<float> action = items[obj2];
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v70 @ rdx_v7 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
				list = _003COnCoinPickup_003Ek__BackingField;
				obj2++;
				obj = obj2;
				list2 = _003COnCoinPickup_003Ek__BackingField;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public Blitter CreateBlitter(Vector2 pos, string blitterName = null)
	{
		Transform blittersParent = _blittersParent;
		if ((object)_blittersParent == null || ((UnityEngine.Object)blittersParent).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, "Blitters");
			if ((object)gameObject == null)
			{
				goto IL_01c7;
			}
			Transform blittersParent2 = gameObject.transform;
			_blittersParent = blittersParent2;
		}
		string text;
		if (blitterName != null)
		{
			bool flag = blitterName._stringLength > 0;
			text = blitterName;
			if (flag)
			{
				goto IL_0206;
			}
		}
		text = "Blitter";
		goto IL_0206;
		IL_01c7:
		throw new NullReferenceException();
		IL_0206:
		GameObject gameObject2 = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject2, text);
		if ((object)gameObject2 != null)
		{
			Transform transform = gameObject2.transform;
			bool flag2 = (object)transform == null;
			bool flag3 = ((string)(object)transform)._stringLength == 0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected((IntPtr)((string)(object)transform)._stringLength, ref value);
			Transform transform2 = gameObject2.transform;
			bool flag4 = (object)transform2 == null;
			transform2.SetParent(_blittersParent, worldPositionStays: false);
			Blitter blitter = gameObject2.AddComponent<Blitter>();
			bool flag5 = (object)blitter == null;
			Renderer component = blitter.GetComponent<Renderer>();
			Material material = MaterialManager.GetMaterial(MaterialType.Blitter);
			bool flag6 = (object)component == null;
			component.SetMaterial(material);
			return blitter;
		}
		goto IL_01c7;
	}

	public void SetLatestKilledEnemy(EnemyController _enemyController)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Expected O, but got I4
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00c4: Expected O, but got I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_03c0: Expected O, but got I4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0131: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		object obj = _enemyController + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		EnemyController enemyController = (EnemyController)1;
		object obj4 = default(object);
		object obj5 = default(object);
		if (obj4 != obj5)
		{
			object obj6 = _enemyController + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj8 = default(object);
			object obj7 = obj8 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			enemyController = (EnemyController)1;
			object obj9 = default(object);
			object obj10 = default(object);
			if (obj9 != obj10)
			{
				object obj11 = _enemyController + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj14 = default(object);
				object obj13 = obj14 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj15 = default(object);
				obj12 = obj15;
				enemyController = (EnemyController)1;
				object obj16 = default(object);
				if (obj16 != obj12)
				{
					object obj17 = _enemyController + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Enemy_SpawnHigh));
					object obj18 = default(object);
					if (obj18 != typeFromHandle)
					{
						object obj19 = _enemyController + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
						Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EnemySkullino));
						object obj20 = default(object);
						if (obj20 != typeFromHandle2)
						{
							return;
						}
					}
				}
			}
		}
		if (_enemyController._003CIsBoss_003Ek__BackingField)
		{
			return;
		}
		EnemyData currentEnemyData = _enemyController._currentEnemyData;
		if (currentEnemyData._003CCannotBeFollower_003Ek__BackingField || !CheckIfFrameListIsValid(currentEnemyData._003CframeNames_003Ek__BackingField))
		{
			return;
		}
		EnemyData currentEnemyData2 = _enemyController._currentEnemyData;
		if (currentEnemyData2.Internal_IdleAnimFrameNames == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
		List<string> frameList = default(List<string>);
		if (CheckIfFrameListIsValid(frameList))
		{
			EnemyData currentEnemyData3 = _enemyController._currentEnemyData;
			if (currentEnemyData3._003CtextureName_003Ek__BackingField != null)
			{
				_latestKilledEnemyThatCanBeFollowerType = _enemyController._enemyType;
				_latestKilledEnemyThatCanBeFollowerData = _enemyController._currentEnemyData;
				object obj21 = _enemyController + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Enemy_RightFacing_CartRider));
				object obj23 = default(object);
				object obj22 = obj23 - (object)typeFromHandle3;
				bool latestKilledEnemyWasCartRider = obj22 == null;
				_latestKilledEnemyWasCartRider = latestKilledEnemyWasCartRider;
			}
		}
	}

	private bool CheckIfFrameListIsValid(List<string> frameList)
	{
		if (frameList != null && frameList._size > 0)
		{
			if (frameList._size > 0)
			{
				string[] items = frameList._items;
				bool flag = (nint)items[0] < 0;
				bool flag2 = items[0] == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				return flag4 & flag3;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
		return false;
	}

	public EnemyData GetLatestKilledEnemyThatCanBeFollower()
	{
		return _latestKilledEnemyThatCanBeFollowerData;
	}

	public EnemyType GetLatestKilledEnemyThatCanBeFollowerType()
	{
		return _latestKilledEnemyThatCanBeFollowerType;
	}

	public bool GetLatestKilledEnemyWasCartRider()
	{
		return _latestKilledEnemyWasCartRider;
	}

	public unsafe void EraseEnemies(bool showVfx = true)
	{
		//IL_0043: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_0412: Expected O, but got I
		//IL_00d5: Expected O, but got Ref
		//IL_0216: Expected I4, but got O
		//IL_0224: Expected I4, but got O
		//IL_00f4: Expected I4, but got O
		//IL_02ec: Expected O, but got I
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected O, but got Unknown
		//IL_04b0: Expected O, but got I4
		//IL_0372: Expected O, but got I
		//IL_046e->IL03dc: Incompatible stack heights: 1 vs 0
		//IL_022d->IL03dc: Incompatible stack heights: 1 vs 0
		//IL_00fd->IL03dc: Incompatible stack heights: 1 vs 0
		//IL_012d->IL012d: Incompatible stack heights: 1 vs 0
		//IL_0492->IL03db: Incompatible stack heights: 1 vs 0
		//IL_0276->IL03db: Incompatible stack heights: 1 vs 0
		//IL_04c1->IL0507: Incompatible stack heights: 1 vs 0
		//IL_04c6->IL03db: Incompatible stack heights: 1 vs 0
		//IL_035c->IL03dc: Incompatible stack heights: 1 vs 0
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				object obj = config._003CFlashingVFXEnabled_003Ek__BackingField & showVfx;
				bool flag = obj == null;
				IntPtr intPtr = default(IntPtr);
				bool flag2 = (byte)(nint)intPtr != 0;
				if (flag)
				{
					goto IL_012d;
				}
				Camera main = Camera.main;
				if ((object)main != null)
				{
					Transform transform = main.transform;
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v48 (UnityEngine.Transform)+10]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v48 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v48 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
						ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.RosaryVfx);
						if ((object)pool != null)
						{
							RosaryVfx objectComponent = pool.GetObjectComponent<RosaryVfx>((Vector3)(&ret));
							Transform transform2 = main.transform;
							if ((int)(~objectComponent) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186EB3350");
								objectComponent.Play();
								flag2 = false;
								goto IL_012d;
							}
						}
					}
				}
			}
		}
		goto IL_03dc;
		IL_03dc:
		throw new NullReferenceException();
		IL_012d:
		Stage stage = _stage;
		if ((object)_stage != null)
		{
			List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
			bool flag4 = (nint)stage._spawnedEnemies < 0;
			if (stage._spawnedEnemies != null)
			{
				object obj3 = spawnedEnemies._size - 1;
				if (flag4)
				{
					return;
				}
				object obj4 = default(object);
				object obj5 = default(object);
				while (true)
				{
					Stage stage2 = _stage;
					if ((object)_stage == null)
					{
						break;
					}
					List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
					if (stage2._spawnedEnemies == null)
					{
						break;
					}
					bool flag5 = (nint)obj3 >= spawnedEnemies2._size;
					bool flag6 = (byte)(int)spawnedEnemies2._items != 0;
					if ((int)(~spawnedEnemies2._items) != 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v9 (System.Boolean)+20+v96 @ rdi_v10*8]");
					bool flag7 = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v9 (System.Boolean)+20+v96 @ rdi_v10*8]");
					if ((uint)(~(nuint)0u) != 0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.Boolean)+10]");
					if ((nint)0 == 0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.Boolean)+20C]");
					bool flag8;
					object obj6;
					if ((nint)0 != 0)
					{
						flag8 = (nint)obj4 < 0;
						bool flag9 = (nint)obj4 > 0;
						obj5 = obj4;
						obj6 = obj4;
						if (flag9)
						{
							goto IL_0497;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.Boolean)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.Boolean)+C8]");
					bool flag10 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.Boolean)+C8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rsi_v8+10]");
						flag10 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rsi_v8+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.Boolean)+C8]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rbx_v10 (System.Boolean)+C8]");
							bool hasStateAuthority = ((CoherenceSync)0).HasStateAuthority;
							flag10 = (hasStateAuthority ? 1 : 0) < (false ? 1 : 0);
							bool flag11 = !hasStateAuthority;
							obj6 = obj5;
							flag8 = flag10;
							if (flag11)
							{
								goto IL_0497;
							}
						}
					}
					bool value = ((bool*)(flag7 ? 1 : 0))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v850 @ rax_v32 (System.Boolean)+388] (should have been resolved before IL gen)");
					obj6 = obj5;
					flag8 = flag10;
					goto IL_0497;
					IL_0497:
					obj3--;
					object obj7 = !flag8;
					obj5 = obj6;
					if (obj7 == null)
					{
						return;
					}
				}
			}
		}
		goto IL_03dc;
	}

	public void EnterTheBossi()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void SetupMusicBanger(bool loop = true)
	{
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2CC0");
		SoundManager.SoundConfig config2 = BuildSoundConfigWithModifiers(loop);
		SoundManager.PlayMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, config2);
	}

	public SoundManager.SoundConfig BuildSoundConfigWithModifiers(bool loop = true)
	{
		//IL_0365: Expected O, but got I4
		//IL_03d2: Expected O, but got I4
		//IL_0598: Expected O, but got I4
		//IL_026a: Expected O, but got I
		//IL_0461: Expected O, but got I
		//IL_0476: Expected F4, but got I
		//IL_02a4: Expected F4, but got I
		//IL_04a3: Expected O, but got I
		//IL_02d1: Expected O, but got I
		//IL_04bd: Expected F4, but got I
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = null;
		DataManager dataManager = _dataManager;
		bool flag3;
		bool flag4;
		if (_dataManager != null && dataManager._003CAllMusicData_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)SoundManager._003CCurrentBgm_003Ek__BackingField);
			if (num >= 0)
			{
				DataManager dataManager2 = _dataManager;
				if (_dataManager == null || dataManager2._003CAllMusicData_003Ek__BackingField == null)
				{
					goto IL_04c2;
				}
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)SoundManager._003CCurrentBgm_003Ek__BackingField);
				obj = obj2;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						PlayerOptions playerOptions;
						if ((nint)0 == 0)
						{
							playerOptions = _playerOptions;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							playerOptions = _playerOptions;
							object obj3 = default(object);
							if ((nint)obj3 != -1)
							{
								if (_playerOptions != null)
								{
									PlayerOptionsData config2 = _playerOptions.Config;
									if (config2 != null)
									{
										object obj4 = config2._003CSelectedBGMMod_003Ek__BackingField - 1;
										bool flag = obj4 == null;
										if (_playerOptions != null)
										{
											PlayerOptionsData config3 = _playerOptions.Config;
											if (config3 != null)
											{
												object obj5 = config3._003CSelectedBGMMod_003Ek__BackingField - 2;
												bool flag2 = obj5 == null;
												flag3 = flag;
												flag4 = flag2;
												goto IL_0564;
											}
										}
									}
								}
								goto IL_04c2;
							}
						}
						if (playerOptions != null)
						{
							PlayerOptionsData config4 = playerOptions.Config;
							if (config4 != null)
							{
								flag3 = config4._003CSelectedHyper_003Ek__BackingField;
								if (_playerOptions != null)
								{
									PlayerOptionsData config5 = _playerOptions.Config;
									if (config5 != null)
									{
										flag4 = config5._003CSelectedInverse_003Ek__BackingField;
										goto IL_0564;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04c2;
		IL_057d:
		soundConfig.Loop = loop;
		soundConfig.Volume = (float?)(object)1;
		return soundConfig;
		IL_04c2:
		return (SoundManager.SoundConfig)(object)new NullReferenceException();
		IL_0564:
		object obj7;
		if (flag3 && obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_20_v4 (System.Object)+50]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_20_v4 (System.Object)+50]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_20_v4 (System.Object)+50]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v27+10]");
					soundConfig.Rate = 0f;
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_20_v4 (System.Object)+50]");
						obj7 = 0;
						goto IL_052a;
					}
				}
				goto IL_04c2;
			}
		}
		if (flag4 && obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_20_v4 (System.Object)+58]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_20_v4 (System.Object)+58]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v744 @ rax_v24+10]");
				soundConfig.Rate = 0f;
				if (obj == null)
				{
					goto IL_04c2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ stack_20_v4 (System.Object)+58]");
				obj7 = 0;
				goto IL_052a;
			}
		}
		goto IL_057d;
		IL_052a:
		if (obj7 == null)
		{
			goto IL_04c2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v23+14]");
		soundConfig.Detune = 0f;
		goto IL_057d;
	}

	public VampireSurvivors.Objects.Characters.CharacterController PullRandomChestWinner()
	{
		VampireSurvivors.Objects.Characters.CharacterController result;
		if (_mainCharacters != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
			if (mainCharacters._size > 1)
			{
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						bool saveChances = !config._003CSequentialChestMode_003Ek__BackingField;
						CoopConfig coopConfig = CoopConfig;
						if ((object)CoopConfig != null)
						{
							if (coopConfig._chestRandomPrioritiseEvolvablePlayers)
							{
								Predicate<VampireSurvivors.Objects.Characters.CharacterController> isValid = delegate(VampireSurvivors.Objects.Characters.CharacterController c)
								{
									//IL_0090: Expected I4, but got O
									if (_levelUpFactory != null)
									{
										bool flag3 = _levelUpFactory.HasPotentialEvolution(c);
										if (!flag3)
										{
											return flag3;
										}
										if ((object)c != null)
										{
											bool isDisconnectedFromOnlinePlay = c.IsDisconnectedFromOnlinePlay;
											return (byte)((isDisconnectedFromOnlinePlay ? 1u : 0u) ^ 1u) != 0;
										}
									}
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								};
								VampireSurvivors.Objects.Characters.CharacterController characterController = FindNextValidWinner(isValid, saveChances);
								if ((object)characterController != null)
								{
									bool flag = ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0;
									result = characterController;
									if (flag)
									{
										goto IL_01a1;
									}
								}
							}
							Predicate<VampireSurvivors.Objects.Characters.CharacterController> isValid2 = _003C_003Ec._003C_003E9__518_0;
							if (_003C_003Ec._003C_003E9__518_0 == null)
							{
								isValid2 = (_003C_003Ec._003C_003E9__518_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController c)
								{
									//IL_0073: Expected I4, but got O
									if ((object)c == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									if (c._isDead)
									{
										return false;
									}
									bool isDisconnectedFromOnlinePlay = c.IsDisconnectedFromOnlinePlay;
									return (byte)((isDisconnectedFromOnlinePlay ? 1u : 0u) ^ 1u) != 0;
								});
							}
							VampireSurvivors.Objects.Characters.CharacterController characterController2 = FindNextValidWinner(isValid2, saveChances);
							if ((object)characterController2 != null)
							{
								bool flag2 = ((UnityEngine.Object)characterController2).m_CachedPtr == (IntPtr)0;
								result = characterController2;
								if (!flag2)
								{
									goto IL_01a1;
								}
							}
							goto IL_01a6;
						}
					}
				}
				goto IL_01d9;
			}
		}
		goto IL_01a6;
		IL_01a1:
		return result;
		IL_01d9:
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
		IL_01a6:
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null)
		{
			return gameSessionData._activeCharacter;
		}
		goto IL_01d9;
	}

	public void OnCharacterDestroyed(VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0063: Expected O, but got I4
		//IL_0216: Expected O, but got I4
		//IL_0216: Expected O, but got I
		//IL_0228: Expected O, but got I4
		//IL_054c: Expected I, but got O
		//IL_0568: Expected O, but got I
		//IL_04f4: Expected O, but got I4
		//IL_050e: Expected O, but got I4
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v11+C0]");
		if ((nint)0 == 0 || !((List<VampireSurvivors.Objects.Characters.CharacterController>)41).Remove((VampireSurvivors.Objects.Characters.CharacterController)(object)typeof(IClient)) || _restartingGameScene || _inGameOverState || _003CConnectionException_003Ek__BackingField != null)
		{
			return;
		}
		if (_charactersLevelingUp.Remove(characterController))
		{
			bool flag = ((List<object>)(object)_charactersLevelingUp).Remove((object)characterController);
		}
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		if (activeCharacter._level == _nextLevelUpAtLevel)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> charactersLevelingUp = _charactersLevelingUp;
			if (charactersLevelingUp._size == 0)
			{
				AdjustNextLevelUpAtLevel();
				HandleLevelUp();
				_levelUpFactory.CalculateXpFactor();
				GrantSkipsExperience(characterController);
			}
		}
		else
		{
			int nextLevelUpAtLevel = _nextLevelUpAtLevel - 1;
			_nextLevelUpAtLevel = nextLevelUpAtLevel;
		}
		nint num = 0;
		bool flag2 = ((List<VampireSurvivors.Objects.Characters.CharacterController>)0).Remove((VampireSurvivors.Objects.Characters.CharacterController)1);
		object obj = (flag2 ? 1 : 0) + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj2 = default(object);
		object signal = (IntPtr)obj2;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		GameSessionData gameSessionData2 = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
		bool flag3 = (object)gameSessionData2._activeCharacter == null;
		bool flag4 = (object)characterController == null;
		object obj3 = flag4 & flag3;
		bool flag5 = obj3 == null;
		object obj4 = !flag5;
		if (obj4 == null)
		{
			bool flag6;
			if ((object)characterController != null)
			{
				if ((object)gameSessionData2._activeCharacter != null)
				{
					object obj5 = (object)gameSessionData2._activeCharacter - (object)characterController;
					flag6 = obj5 == null;
				}
				else
				{
					flag6 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag6 = ((UnityEngine.Object)activeCharacter2).m_CachedPtr == (IntPtr)0;
			}
			if (!flag6)
			{
				goto IL_030c;
			}
		}
		CycleActivePlayer();
		goto IL_030c;
		IL_030c:
		RedistributeEquipment(characterController);
		_003CMainUI_003Ek__BackingField.ReinitializeEquipment();
		PhysicsManager physicsManager = _physicsManager;
		physicsManager._playerGroup.remove(characterController);
		PhysicsManager physicsManager2 = _physicsManager;
		Group playersWithWallCollisionGroup = physicsManager2._playersWithWallCollisionGroup;
		physicsManager2._playersWithWallCollisionGroup.remove(characterController);
		bool flag7 = characterController.body == null;
		PhaserGameObject phaserGameObject = characterController;
		if (!flag7)
		{
			characterController.body.destroy();
			playersWithWallCollisionGroup = (Group)(characterController + 40);
			characterController.body = null;
			phaserGameObject = null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
		OnlineStageManager onlineStageManager = default(OnlineStageManager);
		PlayerInfo myPlayerInfo = onlineStageManager.GetMyPlayerInfo();
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = myPlayerInfo.CharacterController;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
		OnlineStageManager onlineStageManager2 = default(OnlineStageManager);
		int numberOfConnectedPlayers = onlineStageManager2.NumberOfConnectedPlayers;
		int nonFollowerMainCharacterInCoffinCount = GetNonFollowerMainCharacterInCoffinCount();
		if (numberOfConnectedPlayers == nonFollowerMainCharacterInCoffinCount)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1B20");
		}
	}

	private unsafe void RedistributeEquipment(VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_07b4: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_0099: Expected O, but got Ref
		//IL_009e: Expected I, but got O
		//IL_00de: Expected I, but got O
		//IL_00f4: Expected I, but got O
		//IL_017f: Expected O, but got I4
		//IL_012c: Expected O, but got I
		//IL_07cf: Expected O, but got I4
		//IL_0249: Expected O, but got I4
		//IL_025f: Expected O, but got I
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_02d2: Expected O, but got I4
		//IL_02e9: Expected O, but got Ref
		//IL_019f: Expected I, but got O
		//IL_081b: Expected I, but got O
		//IL_06df: Expected O, but got I4
		//IL_01cb: Expected I, but got O
		//IL_01d9: Expected I, but got O
		//IL_0450: Expected O, but got I4
		//IL_0467: Expected O, but got Ref
		//IL_05ba: Expected O, but got I4
		//IL_05c2: Expected O, but got Ref
		//IL_0723: Expected O, but got I4
		//IL_0237: Expected I, but got O
		List<VampireSurvivors.Objects.Characters.CharacterController> list = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		bool flag = characterController._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = characterController._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = characterController._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 != null)
		{
			return;
		}
		IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj4 = default(object);
		object obj3 = (object)(&obj4);
		nint num3 = unchecked((nint)null);
		object obj5 = default(object);
		int num7;
		object obj12 = default(object);
		PlayerInfo playerInfo = default(PlayerInfo);
		while (true)
		{
			object obj6;
			object obj11;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj5 != null)
				{
					bool flag5 = obj4 == null;
					num3 = unchecked((nint)null);
					if (!flag5)
					{
						nint num4 = (nint)obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ r10_v22 (Il2CppClass<System.Object>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_016c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ r10_v22 (Il2CppClass<System.Object>)+B0]");
						obj6 = 0;
						int num5 = 0;
						while (true)
						{
							object obj7 = num5 + num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ r8_v51+v791 @ rax_v140*8]");
							if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
							{
								break;
							}
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ r10_v22 (Il2CppClass<System.Object>)+12E]");
							if ((nint)num6 < (nint)0)
							{
								continue;
							}
							goto IL_016c;
						}
						object obj8 = num5 + num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ r8_v51+8+v941 @ rcx_v90*8]");
						object obj9 = (nint)0 << 4;
						object obj10 = obj9 + 312;
						obj11 = obj10 + num4;
						goto IL_0851;
					}
					throw new NullReferenceException();
				}
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				num7 = 0;
				break;
			}
			throw new NullReferenceException();
			IL_016c:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj6 = 0;
			obj11 = obj12;
			goto IL_0851;
			IL_0851:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v946 @ rdx_v55] (should have been resolved before IL gen)");
			num3 = (nint)typeof(UnityEngine.Object);
			bool flag6 = (object)playerInfo == null;
			nint num8 = (nint)typeof(IEnumerator<PlayerInfo>);
			if (flag6)
			{
				continue;
			}
			bool flag7 = ((UnityEngine.Object)playerInfo).m_CachedPtr == (IntPtr)0;
			num8 = (nint)typeof(IEnumerator<PlayerInfo>);
			num3 = (nint)typeof(UnityEngine.Object);
			if (!flag7)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = playerInfo.CharacterController;
				if (list == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
				characterController2.UpdateMaxWeaponCount();
				num8 = (nint)typeof(IEnumerator<PlayerInfo>);
			}
		}
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		WeaponType weaponType = default(WeaponType);
		CharacterType characterType = default(CharacterType);
		List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
		WeaponType weaponType2 = default(WeaponType);
		CharacterType characterType2 = default(CharacterType);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator5 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				object obj13 = 0;
				bool flag8 = list == null;
				List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
				if (flag8)
				{
					break;
				}
				if (num7 < list._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items = list._items;
					VampireSurvivors.Objects.Characters.CharacterController player = items[num7];
					int num9 = 0;
					while (true)
					{
						int num10 = num9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rsi_v25+4C]");
						if ((nint)num10 >= (nint)0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v663 @ rsi_v25+48]");
						LevelWeaponUp(WeaponType.VOID, removeFromStore: false, player);
						num9++;
					}
					object arg = weaponType;
					object arg2 = characterType;
					string message = $"Giving {arg} to {arg2}";
					Debug.Log(message);
					num7++;
					if (num7 >= list._size)
					{
						num7 = 0;
					}
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				enumerator2 = (List<Equipment>.Enumerator)0;
				break;
			}
			int num11 = 0;
			while (enumerator3.MoveNext())
			{
				object obj14 = 0;
				bool flag9 = list == null;
				List<Equipment>.Enumerator enumerator4 = (List<Equipment>.Enumerator)(&enumerator3);
				if (!flag9)
				{
					if (num11 < list._size)
					{
						VampireSurvivors.Objects.Characters.CharacterController[] items2 = list._items;
						VampireSurvivors.Objects.Characters.CharacterController player2 = items2[num11];
						int num12 = 0;
						while (true)
						{
							int num13 = num12;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1247 @ rsi_v24+4C]");
							if ((nint)num13 >= (nint)0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1247 @ rsi_v24+48]");
							LevelWeaponUp(WeaponType.VOID, removeFromStore: false, player2);
							num12++;
						}
						object arg3 = weaponType2;
						object arg4 = characterType2;
						string message2 = $"Giving {arg3} to {arg4}";
						Debug.Log(message2);
						num11++;
						if (num11 >= list._size)
						{
							num11 = 0;
						}
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					enumerator4 = (List<Equipment>.Enumerator)0;
				}
				throw new NullReferenceException();
			}
			if (enumerator5.MoveNext())
			{
				object obj15 = 0;
				CharacterWeaponsManager characterWeaponsManager = (CharacterWeaponsManager)(&enumerator5);
				throw new NullReferenceException();
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void InitializeCharacterSpawnedRemotely(GameObject characterInstance, CharacterType characterType)
	{
		_003CInitRemoteCharacterWhenGameplayLoaded_003Ed__574 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.characterInstance = characterInstance;
		obj.characterType = characterType;
		Coroutine coroutine = StartCoroutine(obj);
	}

	public unsafe void AddPlayerXp(float xp, XPMultiplierMode multiplierMode = XPMultiplierMode.Normal)
	{
		//IL_0124: Expected O, but got I4
		//IL_012d: Expected O, but got I4
		//IL_0045: Expected O, but got Ref
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (!_multiplayer.IsOnlineMultiplayer)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
			object obj = 0;
			object obj2 = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = _mainCharacters;
			while ((nint)obj2 < mainCharacters._size)
			{
				if ((nint)obj < mainCharacters2._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters2._items;
					items[obj].AddXp(xp, multiplierMode);
					obj++;
					mainCharacters2 = _mainCharacters;
					obj2 = obj;
					mainCharacters = _mainCharacters;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
		}
		else if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		FirePlayerXpUpdated();
	}

	public void UpdatePlayerUI()
	{
		FirePlayerXpUpdated();
	}

	public void TogglePlayerHealthBar(bool visible)
	{
		//IL_00e6: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < characters._size)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
				if ((nint)obj >= characters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
				GameObject gameObject = characterController._healthBar.gameObject;
				gameObject.SetActive(visible);
				characters = _characters;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe List<Weapon> RemoveAllWeaponsFromPlayer(VampireSurvivors.Objects.Characters.CharacterController owner)
	{
		//IL_0050: Expected O, but got I4
		//IL_006c: Expected I, but got O
		//IL_01fe: Expected O, but got I4
		//IL_0206: Expected O, but got Ref
		//IL_00d0: Expected I, but got O
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0290: Expected O, but got I4
		//IL_0116: Expected O, but got I
		//IL_0126: Expected O, but got I
		//IL_01a0: Expected O, but got I4
		//IL_02b2: Expected I, but got O
		//IL_0162: Expected O, but got I
		//IL_01b6: Expected I, but got O
		//IL_0192: Expected O, but got I4
		//IL_01e6: Expected I, but got O
		List<Weapon> list = new List<Weapon>();
		CharacterWeaponsManager weaponsManager = owner._weaponsManager;
		List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		bool flag = (nint)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField < 0;
		object obj = list2._size - 1;
		if (!flag)
		{
			nint num = (nint)typeof(Weapon);
			nint num2 = 0;
			object obj6;
			do
			{
				CharacterWeaponsManager weaponsManager2 = owner._weaponsManager;
				List<Equipment> list3 = ((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField;
				Equipment[] items;
				bool flag2;
				object obj5;
				if ((nint)obj < list3._size)
				{
					items = list3._items;
					nint num3 = (nint)items[obj];
					flag2 = (nint)items[obj] < 0;
					if ((object)items[obj] == null)
					{
						goto IL_0277;
					}
					object obj2 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rdx_v15+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rdx_v15+C8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v43+FFFFFFF8+v559 @ rax_v38*8]");
						if (0 == num)
						{
							obj5 = 1;
							goto IL_029e;
						}
					}
					obj5 = 0;
					goto IL_029e;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
				IL_0277:
				obj--;
				obj6 = !flag2;
				continue;
				IL_029e:
				bool flag3 = obj5 == null;
				num2 = unchecked((nint)null);
				if (!flag3)
				{
					num2 = (nint)items[obj];
				}
				flag2 = num2 < 0;
				if (num2 != 0)
				{
					flag2 = (nint)list < 0;
					list._002Ector();
					num = (nint)typeof(Weapon);
				}
				goto IL_0277;
			}
			while (obj6 != null);
		}
		List<Weapon>.Enumerator enumerator = default(List<Weapon>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj7 = 0;
			List<Weapon>.Enumerator enumerator2 = (List<Weapon>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return list;
	}

	public unsafe void SetAllPlayersWeaponsActive(bool active)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public unsafe void SetOnlySomePlayersWeaponsActive(int maxActive)
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public List<EquipmentInfo> RemoveAllEquipmentFromPlayers(bool addToRemovedList = false)
	{
		//IL_0cc3: Expected O, but got I4
		//IL_0ccc: Expected O, but got I4
		//IL_0cd5: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_03a6: Expected O, but got I4
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		//IL_0325: Expected O, but got I4
		//IL_0128: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0140: Expected O, but got I
		//IL_06a6: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_061a: Expected O, but got Unknown
		//IL_0625: Expected O, but got I4
		//IL_017c: Expected O, but got I
		//IL_0428: Expected I, but got O
		//IL_0430: Expected I, but got O
		//IL_0440: Expected O, but got I
		//IL_0e31: Expected I, but got O
		//IL_09a6: Expected O, but got I4
		//IL_04c0: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		//IL_0c5b: Expected O, but got I
		//IL_0c64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c69: Expected O, but got Unknown
		//IL_0915: Unknown result type (might be due to invalid IL or missing references)
		//IL_091a: Expected O, but got Unknown
		//IL_0925: Expected O, but got I4
		//IL_047c: Expected O, but got I
		//IL_0728: Expected I, but got O
		//IL_0730: Expected I, but got O
		//IL_0740: Expected O, but got I
		//IL_0e6b: Expected I, but got O
		//IL_0202: Expected I, but got O
		//IL_07c0: Expected O, but got I4
		//IL_04b2: Expected O, but got I4
		//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Expected O, but got Unknown
		//IL_0c1d: Expected O, but got I4
		//IL_077c: Expected O, but got I
		//IL_0a20: Expected I, but got O
		//IL_0a28: Expected I, but got O
		//IL_0a38: Expected O, but got I
		//IL_0ea5: Expected I, but got O
		//IL_0502: Expected I, but got O
		//IL_0237: Expected O, but got I
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0255: Expected O, but got I
		//IL_02a3: Expected I, but got I8
		//IL_0ab8: Expected O, but got I4
		//IL_07b2: Expected O, but got I4
		//IL_0a74: Expected O, but got I
		//IL_0edf: Expected I, but got O
		//IL_0802: Expected I, but got O
		//IL_0537: Expected O, but got I
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Expected O, but got Unknown
		//IL_0555: Expected O, but got I
		//IL_05a3: Expected I, but got I8
		//IL_0aaa: Expected O, but got I4
		//IL_0301: Expected I, but got I8
		//IL_0afa: Expected I, but got O
		//IL_0837: Expected O, but got I
		//IL_0840: Unknown result type (might be due to invalid IL or missing references)
		//IL_0845: Expected O, but got Unknown
		//IL_0855: Expected O, but got I
		//IL_08a3: Expected I, but got I8
		//IL_0601: Expected I, but got I8
		//IL_0b2f: Expected O, but got I
		//IL_0b38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3d: Expected O, but got Unknown
		//IL_0b4d: Expected O, but got I
		//IL_0b9b: Expected I, but got I8
		//IL_0901: Expected I, but got I8
		//IL_0bf9: Expected I, but got I8
		_ = 0;
		_ = 0;
		List<EquipmentInfo> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		GameManager gameManager = this;
		object obj6 = default(object);
		nint num2 = default(nint);
		nint num4 = default(nint);
		object obj8 = default(object);
		object obj13 = default(object);
		object obj17 = default(object);
		object obj25 = default(object);
		object obj33 = default(object);
		while (true)
		{
			if ((nint)obj3 < characters._size)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = gameManager._characters;
				if ((nint)obj2 >= characters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj2];
				CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
				List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
				bool flag = (nint)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField < 0;
				object obj4 = list2._size - 1;
				object obj5 = obj6;
				object obj7 = obj;
				nint num = num2;
				nint num3 = num4;
				GameManager gameManager2 = gameManager;
				if (!flag)
				{
					object obj12;
					do
					{
						CharacterWeaponsManager weaponsManager2 = characterController._weaponsManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag2 = (nint)obj8 < 0;
						if (obj8 == null)
						{
							goto IL_030c;
						}
						nint num5 = (nint)typeof(Weapon);
						num = (nint)obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ r9_v3 (Il2CppClass<System.Object>)+130]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj11;
						if (num6 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ r9_v3 (Il2CppClass<System.Object>)+C8]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1000 @ rcx_v26+FFFFFFF8+v957 @ rcx_v11*8]");
							if (0 == (nint)typeof(Weapon))
							{
								obj11 = 1;
								goto IL_0ce9;
							}
						}
						obj11 = 0;
						goto IL_0ce9;
						IL_030c:
						obj4--;
						obj12 = !flag2;
						obj6 = obj5;
						obj = obj7;
						num2 = num;
						num4 = num3;
						gameManager = gameManager2;
						continue;
						IL_0ce9:
						bool flag3 = obj11 == null;
						gameManager2 = null;
						if (!flag3)
						{
							gameManager2 = (GameManager)obj8;
						}
						flag2 = (nint)gameManager2 < 0;
						bool flag4 = (object)gameManager2 == null;
						num3 = (nint)typeof(Weapon);
						if (!flag4)
						{
							CharacterWeaponsManager weaponsManager3 = characterController._weaponsManager;
							bool flag5 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove(obj8);
							nint num7 = (nint)gameManager2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1317 @ rax_v17 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+1F8] (should have been resolved before IL gen)");
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							obj7 = 0;
							EquipmentInfo item = (EquipmentInfo)(obj13 - 48);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							_ = 0;
							list.Add(item);
							flag2 = (addToRemovedList ? 1 : 0) < (false ? 1 : 0);
							bool flag6 = !addToRemovedList;
							num = unchecked((nint)6603577472L);
							num3 = 0;
							if (!flag6)
							{
								CharacterWeaponsManager weaponsManager4 = characterController._weaponsManager;
								flag2 = (nint)((EquipmentManager)weaponsManager4)._003CRemovedEquipment_003Ek__BackingField < 0;
								((List<EquipmentInfo>)(object)((EquipmentManager)weaponsManager4)._003CRemovedEquipment_003Ek__BackingField).Add((EquipmentInfo)obj8);
								num = unchecked((nint)6603577472L);
								num3 = 0;
							}
						}
						goto IL_030c;
					}
					while (obj12 != null);
				}
				CharacterWeaponsManager weaponsManager5 = characterController._weaponsManager;
				List<Equipment> list3 = ((EquipmentManager)weaponsManager5)._003CHiddenEquipment_003Ek__BackingField;
				bool flag7 = (nint)((EquipmentManager)weaponsManager5)._003CHiddenEquipment_003Ek__BackingField < 0;
				object obj14 = list3._size - 1;
				nint num8 = num2;
				object obj15 = obj6;
				object obj16 = obj;
				nint num9 = num2;
				nint num10 = num4;
				GameManager gameManager3 = gameManager;
				if (!flag7)
				{
					object obj21;
					do
					{
						CharacterWeaponsManager weaponsManager6 = characterController._weaponsManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag8 = (nint)obj17 < 0;
						if (obj17 == null)
						{
							goto IL_060c;
						}
						nint num11 = (nint)typeof(Weapon);
						num9 = (nint)obj17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ r9_v8 (Il2CppClass<System.Object>)+130]");
						nint num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						object obj20;
						if (num12 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v907 @ r9_v8 (Il2CppClass<System.Object>)+C8]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ rcx_v46+FFFFFFF8+v1100 @ rcx_v32*8]");
							if (0 == (nint)typeof(Weapon))
							{
								obj20 = 1;
								goto IL_0d27;
							}
						}
						obj20 = 0;
						goto IL_0d27;
						IL_060c:
						obj14--;
						obj21 = !flag8;
						obj6 = obj15;
						obj = obj16;
						num8 = num9;
						num4 = num10;
						gameManager = gameManager3;
						continue;
						IL_0d27:
						bool flag9 = obj20 == null;
						gameManager3 = null;
						if (!flag9)
						{
							gameManager3 = (GameManager)obj17;
						}
						flag8 = (nint)gameManager3 < 0;
						bool flag10 = (object)gameManager3 == null;
						num10 = (nint)typeof(Weapon);
						if (!flag10)
						{
							CharacterWeaponsManager weaponsManager7 = characterController._weaponsManager;
							bool flag11 = ((List<object>)(object)((EquipmentManager)weaponsManager7)._003CHiddenEquipment_003Ek__BackingField).Remove(obj17);
							nint num13 = (nint)gameManager3;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1530 @ rax_v49 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+1F8] (should have been resolved before IL gen)");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							obj16 = 0;
							EquipmentInfo item2 = (EquipmentInfo)(obj13 - 48);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							_ = 0;
							list.Add(item2);
							flag8 = (addToRemovedList ? 1 : 0) < (false ? 1 : 0);
							bool flag12 = !addToRemovedList;
							num9 = unchecked((nint)6603577472L);
							num10 = 0;
							if (!flag12)
							{
								CharacterWeaponsManager weaponsManager8 = characterController._weaponsManager;
								flag8 = (nint)((EquipmentManager)weaponsManager8)._003CRemovedEquipment_003Ek__BackingField < 0;
								((List<EquipmentInfo>)(object)((EquipmentManager)weaponsManager8)._003CRemovedEquipment_003Ek__BackingField).Add((EquipmentInfo)obj17);
								num9 = unchecked((nint)6603577472L);
								num10 = 0;
							}
						}
						goto IL_060c;
					}
					while (obj21 != null);
				}
				CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
				List<Equipment> list4 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
				bool flag13 = (nint)((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField < 0;
				object obj22 = list4._size - 1;
				nint num14 = num8;
				object obj23 = obj6;
				object obj24 = obj;
				nint num15 = num8;
				nint num16 = num4;
				GameManager gameManager4 = gameManager;
				if (!flag13)
				{
					object obj29;
					do
					{
						CharacterAccessoriesManager accessoriesManager2 = characterController._accessoriesManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag14 = (nint)obj25 < 0;
						if (obj25 == null)
						{
							goto IL_090c;
						}
						nint num17 = (nint)typeof(Accessory);
						num15 = (nint)obj25;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r8_v36 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+130]");
						object obj26 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ r9_v13 (Il2CppClass<System.Object>)+130]");
						nint num18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r8_v36 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+130]");
						object obj28;
						if (num18 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ r9_v13 (Il2CppClass<System.Object>)+C8]");
							object obj27 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1291 @ rcx_v67+FFFFFFF8+v1246 @ rcx_v52*8]");
							if (0 == (nint)typeof(Accessory))
							{
								obj28 = 1;
								goto IL_0d65;
							}
						}
						obj28 = 0;
						goto IL_0d65;
						IL_090c:
						obj22--;
						obj29 = !flag14;
						obj6 = obj23;
						obj = obj24;
						num14 = num15;
						num4 = num16;
						gameManager = gameManager4;
						continue;
						IL_0d65:
						bool flag15 = obj28 == null;
						gameManager4 = null;
						if (!flag15)
						{
							gameManager4 = (GameManager)obj25;
						}
						flag14 = (nint)gameManager4 < 0;
						bool flag16 = (object)gameManager4 == null;
						num16 = (nint)typeof(Accessory);
						if (!flag16)
						{
							CharacterAccessoriesManager accessoriesManager3 = characterController._accessoriesManager;
							bool flag17 = ((List<object>)(object)((EquipmentManager)accessoriesManager3)._003CActiveEquipment_003Ek__BackingField).Remove(obj25);
							nint num19 = (nint)gameManager4;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1687 @ rax_v79 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+1F8] (should have been resolved before IL gen)");
							_ = 0;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							obj24 = 0;
							EquipmentInfo item3 = (EquipmentInfo)(obj13 - 48);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							obj23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							_ = 0;
							list.Add(item3);
							flag14 = (addToRemovedList ? 1 : 0) < (false ? 1 : 0);
							bool flag18 = !addToRemovedList;
							num15 = unchecked((nint)6603577472L);
							num16 = 0;
							if (!flag18)
							{
								CharacterWeaponsManager weaponsManager9 = characterController._weaponsManager;
								flag14 = (nint)((EquipmentManager)weaponsManager9)._003CRemovedEquipment_003Ek__BackingField < 0;
								((List<EquipmentInfo>)(object)((EquipmentManager)weaponsManager9)._003CRemovedEquipment_003Ek__BackingField).Add((EquipmentInfo)obj25);
								num15 = unchecked((nint)6603577472L);
								num16 = 0;
							}
						}
						goto IL_090c;
					}
					while (obj29 != null);
				}
				CharacterAccessoriesManager accessoriesManager4 = characterController._accessoriesManager;
				List<Equipment> list5 = ((EquipmentManager)accessoriesManager4)._003CHiddenEquipment_003Ek__BackingField;
				bool flag19 = (nint)((EquipmentManager)accessoriesManager4)._003CHiddenEquipment_003Ek__BackingField < 0;
				object obj30 = list5._size - 1;
				nint num20 = num14;
				object obj31 = obj6;
				object obj32 = obj;
				nint num21 = num14;
				nint num22 = num4;
				if (!flag19)
				{
					object obj37;
					do
					{
						CharacterAccessoriesManager accessoriesManager5 = characterController._accessoriesManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag20 = (nint)obj33 < 0;
						if (obj33 == null)
						{
							goto IL_0c04;
						}
						nint num23 = (nint)typeof(Accessory);
						num21 = (nint)obj33;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r8_v52 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+130]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1172 @ r9_v18 (Il2CppClass<System.Object>)+130]");
						nint num24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r8_v52 (Il2CppClass<VampireSurvivors.Objects.Accessory>)+130]");
						object obj36;
						if (num24 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1172 @ r9_v18 (Il2CppClass<System.Object>)+C8]");
							object obj35 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1504 @ rcx_v88+FFFFFFF8+v1410 @ rcx_v73*8]");
							if (0 == (nint)typeof(Accessory))
							{
								obj36 = 1;
								goto IL_0da3;
							}
						}
						obj36 = 0;
						goto IL_0da3;
						IL_0c04:
						obj30--;
						obj37 = !flag20;
						obj6 = obj31;
						obj = obj32;
						num20 = num21;
						num4 = num22;
						continue;
						IL_0da3:
						bool flag21 = obj36 == null;
						gameManager = null;
						if (!flag21)
						{
							gameManager = (GameManager)obj33;
						}
						flag20 = (nint)gameManager < 0;
						bool flag22 = (object)gameManager == null;
						num22 = (nint)typeof(Accessory);
						if (!flag22)
						{
							CharacterAccessoriesManager accessoriesManager6 = characterController._accessoriesManager;
							bool flag23 = ((List<object>)(object)((EquipmentManager)accessoriesManager6)._003CHiddenEquipment_003Ek__BackingField).Remove(obj33);
							nint num25 = (nint)gameManager;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1823 @ rax_v111 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+1F8] (should have been resolved before IL gen)");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							obj32 = 0;
							EquipmentInfo item4 = (EquipmentInfo)(obj13 - 48);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							obj31 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							_ = 0;
							list.Add(item4);
							flag20 = (addToRemovedList ? 1 : 0) < (false ? 1 : 0);
							bool flag24 = !addToRemovedList;
							num21 = unchecked((nint)6603577472L);
							num22 = 0;
							if (!flag24)
							{
								CharacterWeaponsManager weaponsManager10 = characterController._weaponsManager;
								flag20 = (nint)((EquipmentManager)weaponsManager10)._003CRemovedEquipment_003Ek__BackingField < 0;
								((List<EquipmentInfo>)(object)((EquipmentManager)weaponsManager10)._003CRemovedEquipment_003Ek__BackingField).Add((EquipmentInfo)obj33);
								num21 = unchecked((nint)6603577472L);
								num22 = 0;
							}
						}
						goto IL_0c04;
					}
					while (obj37 != null);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
				gameManager = (GameManager)0;
				obj2++;
				characters = gameManager._characters;
				num2 = num20;
				obj3 = obj2;
				continue;
			}
			return list;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<EquipmentInfo> result = default(List<EquipmentInfo>);
		return result;
	}

	public unsafe void GiveBackAllEquipmentToPlayers(List<EquipmentInfo> playerEquipment)
	{
		//IL_0021: Expected O, but got Ref
		//IL_0247: Expected O, but got I4
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_0081: Expected I, but got O
		//IL_0089: Expected O, but got Ref
		//IL_00a7: Expected O, but got I
		//IL_00d4: Expected I, but got O
		//IL_00e4: Expected O, but got I
		//IL_010f: Expected I, but got O
		//IL_011f: Expected O, but got I
		//IL_0136: Expected O, but got I4
		//IL_014b: Expected O, but got I
		List<EquipmentInfo>.Enumerator enumerator = default(List<EquipmentInfo>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		object obj = default(object);
		bool flag = obj == null;
		List<EquipmentInfo>.Enumerator enumerator2 = (List<EquipmentInfo>.Enumerator)(&enumerator);
		if (!flag)
		{
			object obj2 = obj;
			nint num = (nint)typeof(Weapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			List<EquipmentInfo>.Enumerator enumerator3 = (List<EquipmentInfo>.Enumerator)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r9_v9+130]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			bool flag2 = num2 < 0;
			nint num3 = (nint)typeof(Weapon);
			enumerator2 = (List<EquipmentInfo>.Enumerator)(&enumerator);
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r9_v9+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v28+FFFFFFF8+v328 @ rax_v27 (System.Collections.Generic.List`1<VampireSurvivors.Framework.EquipmentInfo>+Enumerator<VampireSurvivors.Framework.EquipmentInfo>)*8]");
				bool flag3 = 0 != (nint)typeof(Weapon);
				num3 = (nint)typeof(Weapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				enumerator2 = (List<EquipmentInfo>.Enumerator)0;
				if (!flag3)
				{
					bool flag4 = obj == null;
					num3 = (nint)typeof(Weapon);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
					enumerator2 = (List<EquipmentInfo>.Enumerator)0;
					if (!flag4)
					{
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						enumerator2 = (List<EquipmentInfo>.Enumerator)0;
						throw new NullReferenceException();
					}
				}
			}
		}
		object obj5 = 0;
		throw new NullReferenceException();
	}

	public Weapon RemoveWeaponFromPlayer(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController owner)
	{
		if (_weaponsFacade != null)
		{
			return _weaponsFacade.RemoveWeapon(weaponType, owner);
		}
		return (Weapon)(object)new NullReferenceException();
	}

	public void RemoveHiddenWeaponFromPlayer(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController owner)
	{
		_weaponsFacade.RemoveHiddenWeapon(weaponType, owner);
	}

	public void FinishLevelUp(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		if (!_multiplayer.IsOnlineMultiplayer)
		{
			FinishLevelUpActions(weaponType, setInvincibility: true);
			return;
		}
		OnlineStageManager instance = OnlineStageManager._instance;
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Action<long, int, CoherenceSync> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5950");
		int param = default(int);
		object param2 = default(object);
		bool flag = instance._sync.SendCommand((Action<long, int, object>)action, MessageTarget.All, startingOnlineClientFrame, param, param2);
	}

	public unsafe void OnlineFinishLevelUp(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
	{
		//IL_0061: Expected O, but got Ref
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C1F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "FINISH LEVEL UP AT FRAME {0}", (System.ParamsArray)(&obj));
		Debug.Log(message);
		FinishLevelUpActions(weaponType, setInvincibility: true, receivingCharacter);
	}

	public void LevelWeaponUp(WeaponType weaponType, bool removeFromStore = true, VampireSurvivors.Objects.Characters.CharacterController player = null)
	{
		//IL_00fc: Expected O, but got I
		//IL_0111: Expected O, but got I
		DataManager dataManager = _dataManager;
		int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllWeaponData_003Ek__BackingField).FindEntry((System.Int32Enum)weaponType);
		if (num < 0)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)player != null)
		{
			bool flag = ((UnityEngine.Object)player).m_CachedPtr != (IntPtr)0;
			characterController = player;
			if (flag)
			{
				goto IL_009a;
			}
		}
		GameSessionData gameSessionData = _gameSessionData;
		characterController = gameSessionData._activeCharacter;
		goto IL_009a;
		IL_009a:
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)weaponType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v19 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v19 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v20+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v15+101]");
			if ((nint)0 != 0)
			{
				_accessoriesFacade.AddAccessory(weaponType, characterController, removeFromStore);
			}
			else
			{
				Weapon weapon = _weaponsFacade.AddWeapon(weaponType, characterController, removeFromStore);
			}
			SetSeenWeapon(weaponType);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void OnReRollLevelUp()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_01eb: Expected O, but got F4
		//IL_01f9: Invalid comparison between I4 and F4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_00ec: Invalid comparison between F4 and I4
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		PlayerModifierStats playerStats = activeCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CReRolls_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				bool flag = num == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877A3347h\"");
				if (flag || !(num > 0f))
				{
					return;
				}
			}
		}
		object obj3 = UnityEngine.Random.value;
		if (0f < playerStats._003CRecycle_003Ek__BackingField)
		{
			return;
		}
		EggFloat eggFloat2 = playerStats._003CReRolls_003Ek__BackingField;
		float num2 = eggFloat2._val - 1f;
		object obj4 = num2 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = num2 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877A33EBh\"");
				if (num2 == -1f / 0f)
				{
					eggFloat2._val = -3.4028235E+38f;
					playerStats.ReRolls = eggFloat2;
					return;
				}
				goto IL_020d;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_020d;
		IL_020d:
		eggFloat2._val = num2;
		playerStats.ReRolls = eggFloat2;
	}

	public void OnLevelUpBanish()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_01eb: Expected O, but got F4
		//IL_01f9: Invalid comparison between I4 and F4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_00ec: Invalid comparison between F4 and I4
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		PlayerModifierStats playerStats = activeCharacter._playerStats;
		EggFloat eggFloat = playerStats._003CBanish_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				bool flag = num == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877A349Ah\"");
				if (flag || !(num > 0f))
				{
					return;
				}
			}
		}
		object obj3 = UnityEngine.Random.value;
		if (0f < playerStats._003CRecycle_003Ek__BackingField)
		{
			return;
		}
		EggFloat eggFloat2 = playerStats._003CBanish_003Ek__BackingField;
		float num2 = eggFloat2._val - 1f;
		object obj4 = num2 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = num2 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877A3541h\"");
				if (num2 == -1f / 0f)
				{
					eggFloat2._val = -3.4028235E+38f;
					playerStats.Banish = eggFloat2;
					return;
				}
				goto IL_020d;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_020d;
		IL_020d:
		eggFloat2._val = num2;
		playerStats.Banish = eggFloat2;
	}

	public int GetWeaponLevel(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0096: Expected I4, but got O
		if ((object)character != null && (object)character._weaponsManager != null)
		{
			Weapon weaponByType = character._weaponsManager.GetWeaponByType(weaponType);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				return ((Equipment)weaponByType)._003CLevel_003Ek__BackingField;
			}
			return 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public Weapon GetWeapon(WeaponType weaponType, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		if ((object)character != null && (object)character._weaponsManager != null)
		{
			return character._weaponsManager.GetWeaponByType(weaponType);
		}
		return (Weapon)(object)new NullReferenceException();
	}

	public int GetAccessoryLevel(WeaponType accessoryType, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0096: Expected I4, but got O
		if ((object)character != null && (object)character._accessoriesManager != null)
		{
			Accessory accessoryByType = character._accessoriesManager.GetAccessoryByType(accessoryType);
			if ((object)accessoryByType != null && ((UnityEngine.Object)accessoryByType).m_CachedPtr != (IntPtr)0)
			{
				return ((Equipment)accessoryByType)._003CLevel_003Ek__BackingField;
			}
			return 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public bool HasCharacterInPlay(CharacterType characterType)
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = _mainCharacters;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < mainCharacters._size)
			{
				if ((nint)obj >= mainCharacters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
				if (characterController._characterType != characterType)
				{
					obj++;
					obj2 = obj;
					continue;
				}
				return true;
			}
			return false;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	public unsafe bool HasWeaponInPlay(WeaponType weaponType)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public PickupWeapon TryGiveWeaponToPlayer(WeaponType weaponToGive, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_01c3: Expected I, but got O
		//IL_01cb: Expected I, but got O
		//IL_01db: Expected O, but got I
		//IL_025b: Expected O, but got I4
		//IL_0217: Expected O, but got I
		//IL_042b: Expected I, but got O
		//IL_03c0: Expected I, but got O
		//IL_03d0: Expected O, but got I
		//IL_024d: Expected O, but got I4
		//IL_0292: Expected I, but got O
		//IL_02c9: Expected O, but got I
		//IL_02b4: Expected I, but got O
		_003C_003Ec__DisplayClass542_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass542_0();
		CS_0024_003C_003E8__locals4.weaponToGive = weaponToGive;
		CharacterWeaponsManager weaponsManager = character._weaponsManager;
		Pickup pickup;
		PickupWeapon result;
		object obj3;
		if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
		{
			List<object> list = new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
			CharacterAccessoriesManager accessoriesManager = character._accessoriesManager;
			if (((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField != null)
			{
				List<object> collection = new List<object>(((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField);
				list.InsertRange(list._size, collection);
				Predicate<Equipment> match = delegate(Equipment equipment2)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if ((object)equipment2 == null)
					{
						NullReferenceException ex3 = new NullReferenceException();
						return (byte)(int)ex3 != 0;
					}
					object obj6 = equipment2._equipmentType - CS_0024_003C_003E8__locals4.weaponToGive;
					return obj6 == null;
				};
				Equipment equipment = ((List<Equipment>)(object)list).Find(match);
				if ((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0)
				{
					return null;
				}
				float2 position = character.position;
				float2 position2 = character.position;
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, CS_0024_003C_003E8__locals4.weaponToGive, value, relicType, validatePickups);
				bool flag = (object)pickup == null;
				result = null;
				if (flag)
				{
					goto IL_0389;
				}
				nint num = (nint)typeof(PickupWeapon);
				nint num2 = (nint)pickup;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v43 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rax_v43 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v42+FFFFFFF8+v619 @ rcx_v36*8]");
					if (0 == (nint)typeof(PickupWeapon))
					{
						obj3 = 1;
						goto IL_0396;
					}
				}
				obj3 = 0;
				goto IL_0396;
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
		IL_0389:
		return result;
		IL_0396:
		bool flag2 = obj3 == null;
		Pickup pickup2 = null;
		if (!flag2)
		{
			pickup2 = pickup;
		}
		bool flag3 = (object)pickup2 == null;
		nint num4 = (nint)typeof(PickupWeapon);
		if (!flag3)
		{
			bool flag4 = CS_0024_003C_003E8__locals4.weaponToGive != WeaponType.CANDYBOX;
			num4 = (nint)typeof(PickupWeapon);
			if (!flag4)
			{
				_ = 0;
				num4 = (nint)typeof(PickupWeapon);
			}
		}
		nint num5 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ rax_v49+FFFFFFF8+v734 @ rax_v46*8]");
			if (0 == num4)
			{
				Pickup pickup3 = null;
				return (PickupWeapon)pickup;
			}
		}
		result = null;
		goto IL_0389;
	}

	public void DoPraise(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_003c: Expected O, but got I4
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_0178: Expected O, but got I4
		//IL_0181: Expected O, but got I4
		//IL_0220: Expected O, but got I
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_02a2: Expected O, but got I
		//IL_0460: Expected O, but got I4
		//IL_02c2: Expected O, but got I
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_0344: Expected O, but got I
		//IL_0280: Expected O, but got I8
		//IL_049d: Expected O, but got I4
		//IL_0322: Expected O, but got I8
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		Camera main = Camera.main;
		Bounds bounds = VampireSurvivors.Tools.CameraExtensions.OrthographicBounds(main);
		float2 position = player.position;
		List<Pickup> list = new List<Pickup>();
		object obj = 0;
		List<Pickup> list2 = list;
		Vector2 pos = default(Vector2);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			list2._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			list2._002Ector();
			if (!IsStageHost && NetworkItems.IsNetworkItem(ItemType.LITTLEHEART))
			{
				break;
			}
			Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
			bool flag = pickup.Vacuum(player);
			int version = list._version + 1;
			list._version = version;
			list2 = (List<Pickup>)(object)list._items;
			if (list._size >= list2._size)
			{
				((List<object>)(object)list).AddWithResize((object)pickup);
				list2 = list;
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				list2._002Ector();
			}
			obj++;
			if ((nint)obj < 108)
			{
				continue;
			}
			object obj2 = 0;
			object obj3 = 0;
			while (true)
			{
				if ((nint)obj2 >= list._size)
				{
					return;
				}
				_003C_003Ec__DisplayClass543_0 obj4 = new _003C_003Ec__DisplayClass543_0();
				if ((nint)obj3 >= list._size)
				{
					break;
				}
				Pickup[] items = list._items;
				obj4.pickupItem = items[obj3];
				DOGetter<float> getter = null;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ r9_v6 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ r9_v6 (Il2CppMethodInfo)+4C]");
				object obj5 = (nint)0 >> 4;
				object obj6 = obj5 & 1;
				object obj7;
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ r9_v6 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						obj7 = 6447965120L;
						goto IL_0457;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v28 (DG.Tweening.Core.DOGetter`1<System.Single>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v28 (DG.Tweening.Core.DOGetter`1<System.Single>)+10]");
				obj7 = 0;
				goto IL_0457;
				IL_0457:
				object obj8 = 24;
				_ = 6447969936L;
				DOSetter<float> setter = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppMethodInfo)+4C]");
				object obj9 = (nint)0 >> 4;
				object obj10 = obj9 & 1;
				object obj11;
				if (obj10 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r9_v7 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 1)
					{
						obj11 = 6447299152L;
						goto IL_0494;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v827 @ rax_v34 (DG.Tweening.Core.DOSetter`1<System.Single>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v827 @ rax_v34 (DG.Tweening.Core.DOSetter`1<System.Single>)+10]");
				obj11 = 0;
				goto IL_0494;
				IL_0494:
				object obj12 = 24;
				_ = 6449796912L;
				TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, setter, 1f, 0.016f);
				float num3 = (float)obj3 * 8f;
				float delay = num3 * 0.001f;
				TweenerCore<float, float, FloatOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				obj3++;
				obj2 = obj3;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			break;
		}
		throw new NullReferenceException();
	}

	public Light2D GetLight(Destructible destructible)
	{
		if (_candleLightsMapping != null)
		{
			int num = _candleLightsMapping.FindEntry(destructible);
			if (num < 0)
			{
				Queue<Light2D> candleLights = _candleLights;
				if (_candleLights != null)
				{
					if (candleLights._size <= 0)
					{
						Stage stage = _stage;
						if ((object)_stage == null)
						{
							goto IL_0173;
						}
						int count = stage._003CMaxDestructibles_003Ek__BackingField + 1;
						AddLightsToPool(count);
					}
					if (_candleLights != null)
					{
						object obj = ((Queue<object>)(object)_candleLights).Dequeue();
						if (_candleLightsMapping != null)
						{
							bool flag = ((Dictionary<object, object>)(object)_candleLightsMapping).TryInsert((object)destructible, obj, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							return (Light2D)obj;
						}
					}
				}
			}
			else if (_candleLightsMapping != null)
			{
				return _candleLightsMapping.get_Item(destructible);
			}
		}
		goto IL_0173;
		IL_0173:
		return (Light2D)(object)new NullReferenceException();
	}

	public void ReturnLight(Destructible destructible)
	{
		int num = _candleLightsMapping.FindEntry(destructible);
		if (num >= 0)
		{
			Light2D item = _candleLightsMapping.get_Item(destructible);
			((Queue<object>)(object)_candleLights).Enqueue((object)item);
			bool flag = ((Dictionary<object, object>)(object)_candleLightsMapping).Remove((object)destructible);
		}
	}

	public unsafe bool LimitBreakWeaponUp(WeightedLimitBreak limitBreakData, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter)
	{
		//IL_022d: Expected I4, but got O
		//IL_01de: Expected I4, but got O
		//IL_0203: Expected O, but got Ref
		//IL_01b0: Expected I4, but got O
		//IL_0147: Expected I4, but got O
		object message2;
		if (limitBreakData != null)
		{
			DataManager dataManager = _dataManager;
			if (_dataManager == null || dataManager._003CAllWeaponData_003Ek__BackingField == null)
			{
				goto IL_021f;
			}
			int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllWeaponData_003Ek__BackingField).FindEntry((System.Int32Enum)limitBreakData.WeaponType);
			object obj2 = default(object);
			string text = default(string);
			if (num >= 0)
			{
				if ((object)receivingCharacter == null || (object)receivingCharacter._weaponsManager == null)
				{
					goto IL_021f;
				}
				Weapon weaponByType = receivingCharacter._weaponsManager.GetWeaponByType(limitBreakData.WeaponType);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					if (!weaponByType.ApplyLimitBreak(limitBreakData))
					{
						object obj = (WeaponType)obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
						object message = default(object);
						Debug.Log(message);
						if (_playerOptions == null)
						{
							goto IL_021f;
						}
						float num2 = _playerOptions.AddCoins(10f);
					}
					return true;
				}
				object obj3 = (WeaponType)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
			}
			else
			{
				object arg = (WeaponType)obj2;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj4 = default(object);
				text = string.FormatHelper((IFormatProvider)null, "Limit Break Data Weapon Not Found {0}", (System.ParamsArray)(&obj4));
			}
			message2 = text;
		}
		else
		{
			message2 = "Limit Break Data is Null";
		}
		Debug.Log(message2);
		return false;
		IL_021f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void FrameFreeze(Action onComplete = null, float milliseconds = 120f, bool pauseTweens = false)
	{
		//IL_0065: Expected O, but got I4
		//IL_0065: Expected F4, but got I4
		_003C_003Ec__DisplayClass547_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass547_0();
		CS_0024_003C_003E8__locals8.pauseTweens = pauseTweens;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.onComplete = onComplete;
		_003CFreezingFrame_003Ek__BackingField = true;
		PauseSystem._paused = true;
		bool flag2 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num2 = default(int);
		if (CS_0024_003C_003E8__locals8.pauseTweens)
		{
			bool flag = "DefaultGameTweenId" == null;
			flag2 = flag2;
			if (!flag)
			{
				int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Pause, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)"DefaultGameTweenId", false, (float)(flag2 ? 1 : 0), (object)monoBehaviour, (object[])num2);
				flag2 = flag2;
			}
		}
		Action onComplete2 = delegate
		{
			PauseSystem._paused = false;
			if (CS_0024_003C_003E8__locals8.pauseTweens && "DefaultGameTweenId" != null)
			{
				float optionalFloat = default(float);
				object optionalObj = default(object);
				object[] optionalArray = default(object[]);
				int num3 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Play, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)"DefaultGameTweenId", false, optionalFloat, optionalObj, optionalArray);
			}
			GameManager gameManager = CS_0024_003C_003E8__locals8._003C_003E4__this;
			gameManager._003CFreezingFrame_003Ek__BackingField = false;
			Action onComplete3 = CS_0024_003C_003E8__locals8.onComplete;
			if (CS_0024_003C_003E8__locals8.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v153.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		Timer timer = TimerHelper.RegisterMillisUI(milliseconds, onComplete2, null, isLooped: false, flag2, monoBehaviour, num2);
	}

	public void TriggerGoldFever(float durationMillis)
	{
		float num = durationMillis * 0.001f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A971C0");
	}

	public void TriggerFakeGoldFever(float durationMillis)
	{
		float num = durationMillis * 1000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A971C0");
	}

	public unsafe void QueueEnterPianoScene(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_002f: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = EnterPianoScene;
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	public void EnterPianoScene(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void ExitPianoScene()
	{
	}

	public bool CheckValidToastieInputs()
	{
		//IL_019f: Expected I4, but got O
		//IL_003d: Expected I4, but got O
		//IL_008c: Expected O, but got I
		//IL_01b2: Expected O, but got I4
		//IL_0176: Expected O, but got I4
		//IL_00e8: Expected O, but got I
		ReInput.PlayerHelper players = ReInput.players;
		bool flag;
		bool flag3;
		if (players != null)
		{
			flag = (byte)(int)players.GetPlayer(0) != 0;
			if (!flag)
			{
				return flag;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v6 (System.Boolean)+50]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v6 (System.Boolean)+50]");
				bool hasKeyboard = ((Player.ControllerHelper)0).hasKeyboard;
				bool flag2 = !hasKeyboard;
				flag3 = false;
				if (flag2)
				{
					goto IL_01a4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v6 (System.Boolean)+50]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v6 (System.Boolean)+50]");
					Keyboard keyboard = ((Player.ControllerHelper)0).Keyboard;
					if (keyboard != null)
					{
						if (!keyboard.GetKey(KeyCode.Return))
						{
							flag3 = false;
						}
						else
						{
							bool key = keyboard.GetKey(KeyCode.DownArrow);
							flag3 = key;
						}
						goto IL_01a4;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01a4:
		bool button = ((Player)flag).GetButton(11);
		if (!button)
		{
			return button | flag3;
		}
		bool button2 = ((Player)flag).GetButton(15);
		return button2 | flag3;
	}

	public bool HasAnimaWeapon(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_042c: Expected I4, but got O
		//IL_0419: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_044f: Expected O, but got I
		//IL_01aa: Expected O, but got I
		//IL_0477: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_0282: Expected I, but got O
		//IL_02e5: Expected O, but got I
		//IL_03c1: Expected I, but got O
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_0338: Expected I, but got O
		//IL_036c: Expected I, but got O
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v14+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)128);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v14+18]");
			if (num2 >= 0)
			{
				goto IL_041e;
			}
			_ = 128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v16+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)148);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v16+18]");
			if (num4 >= 0)
			{
				goto IL_041e;
			}
			_ = 148;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v18+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)155);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v18+18]");
			if (num6 >= 0)
			{
				goto IL_041e;
			}
			_ = 155;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v20+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)154);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v20+18]");
			if (num8 >= 0)
			{
				goto IL_041e;
			}
			_ = 154;
		}
		nint num9 = unchecked((nint)null);
		object obj9 = default(object);
		object obj10 = default(object);
		object obj12 = default(object);
		while (true)
		{
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ stack_-28_v10+1C]");
				if (obj10 != null)
				{
					break;
				}
				object obj11 = obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ stack_-28_v10+18]");
				if ((nint)obj11 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ stack_-28_v10+10]");
				object obj13 = 0;
				object obj14 = obj12 + 1;
				CharacterWeaponsManager weaponsManager = player._weaponsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v24+20+v151 @ stack_-20_v9*4]");
				Weapon weaponByType = weaponsManager.GetWeaponByType(WeaponType.VOID);
				num9 = (nint)typeof(UnityEngine.Object);
				bool flag = (object)weaponByType == null;
				obj12 = obj14;
				if (!flag)
				{
					bool flag2 = ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0;
					obj12 = obj14;
					num9 = (nint)typeof(UnityEngine.Object);
					if (!flag2)
					{
						return true;
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag3 = obj9 == null;
		num9 = 0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ stack_-28_v10+1C]");
			if (obj10 == null)
			{
				return false;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num9 = unchecked((nint)null);
		}
		throw new NullReferenceException();
		IL_041e:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public unsafe void CheckAllWeaponsForTeleport(float2 destinationPos)
	{
		//IL_0037: Expected O, but got I4
		//IL_003f: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6505]");
		bool flag = (nint)0 != 0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public FollowerEnemy_CharacterController AddLastEnemyFollower(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
	{
		//IL_00bb: Expected O, but got I
		if ((object)followedCharacter != null)
		{
			CoherenceSync coherenceSync = followedCharacter._coherenceSync;
			if ((object)followedCharacter._coherenceSync != null)
			{
				NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
				if (coherenceSync._003CEntityState_003Ek__BackingField != null)
				{
					ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
					if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
					{
						goto IL_018d;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v10 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					bool flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v10 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v10 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						bool flag2 = obj == null;
						flag = flag2;
					}
					if (!flag)
					{
						goto IL_00d7;
					}
				}
				if (m_NumAliveEnemyFollowers != null)
				{
					int num = m_NumAliveEnemyFollowers.FindEntry(followedCharacter);
					if (num >= 0)
					{
						if (m_NumAliveEnemyFollowers == null)
						{
							goto IL_018d;
						}
						int num2 = m_NumAliveEnemyFollowers.get_Item(followedCharacter);
						if (num2 >= 4)
						{
							goto IL_00d7;
						}
					}
					return AddNewEnemyFollower(followedCharacter);
				}
			}
		}
		goto IL_018d;
		IL_018d:
		return (FollowerEnemy_CharacterController)(object)new NullReferenceException();
		IL_00d7:
		return null;
	}

	public int GetNumAliveEnemyFollowers(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
	{
		//IL_0083: Expected I4, but got O
		if (m_NumAliveEnemyFollowers != null)
		{
			int num = m_NumAliveEnemyFollowers.FindEntry(followedCharacter);
			if (num < 0)
			{
				return 0;
			}
			if (m_NumAliveEnemyFollowers != null)
			{
				return m_NumAliveEnemyFollowers.get_Item(followedCharacter);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public void RefreshEnemyFollowersList(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
	{
		bool flag = m_EnemyFollowerPools == null;
		int value;
		if (!flag)
		{
			int num = m_EnemyFollowerPools.FindEntry(followedCharacter);
			value = 0;
			if (flag)
			{
				goto IL_01af;
			}
			if (m_EnemyFollowerPools != null)
			{
				List<FollowerEnemy_CharacterController> list = m_EnemyFollowerPools.get_Item(followedCharacter);
				if (list != null)
				{
					value = 0;
					List<FollowerEnemy_CharacterController>.Enumerator enumerator = default(List<FollowerEnemy_CharacterController>.Enumerator);
					if (enumerator.MoveNext())
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = null;
						VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
						throw new NullReferenceException();
					}
					goto IL_01af;
				}
			}
		}
		goto IL_0183;
		IL_01af:
		if (m_NumAliveEnemyFollowers != null)
		{
			int num2 = m_NumAliveEnemyFollowers.FindEntry(followedCharacter);
			System.Collections.Generic.InsertionBehavior behavior;
			if (num2 < 0)
			{
				if (m_NumAliveEnemyFollowers == null)
				{
					goto IL_0183;
				}
				behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			}
			else
			{
				if (m_NumAliveEnemyFollowers == null)
				{
					goto IL_0183;
				}
				behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			}
			bool flag2 = ((Dictionary<object, int>)(object)m_NumAliveEnemyFollowers).TryInsert((object)followedCharacter, value, behavior);
			return;
		}
		goto IL_0183;
		IL_0183:
		throw new NullReferenceException();
	}

	public void FromOnlineSetEnemyFollowerDataOnly(short enemyType, bool wasCartRider)
	{
		//IL_0067: Expected O, but got I
		//IL_007e: Expected O, but got I
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).get_Item((System.Int32Enum)enemyType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v9 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v9 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v10+20]");
			_latestKilledEnemyThatCanBeFollowerData = (EnemyData)0;
			_latestKilledEnemyWasCartRider = wasCartRider;
			_latestKilledEnemyThatCanBeFollowerType = (EnemyType)enemyType;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void FromOnlineSetRecycledEnemyFollowerData(short enemyType, bool wasCartRider, CoherenceSync newFollowerSync)
	{
		//IL_0067: Expected O, but got I
		//IL_007e: Expected O, but got I
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).get_Item((System.Int32Enum)enemyType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v9 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v9 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v10+20]");
			_latestKilledEnemyThatCanBeFollowerData = (EnemyData)0;
			_latestKilledEnemyThatCanBeFollowerType = (EnemyType)enemyType;
			_latestKilledEnemyWasCartRider = wasCartRider;
			if ((object)newFollowerSync != null && ((UnityEngine.Object)newFollowerSync).m_CachedPtr != (IntPtr)0)
			{
				FollowerEnemy_CharacterController component = newFollowerSync.GetComponent<FollowerEnemy_CharacterController>();
				component.Activate();
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe FollowerEnemy_CharacterController AddNewEnemyFollower(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
	{
		//IL_07b2: Expected O, but got I4
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected O, but got Unknown
		//IL_07cd: Expected O, but got I8
		//IL_004d: Expected O, but got I8
		//IL_0176: Expected I, but got O
		//IL_0852: Expected I, but got O
		//IL_01e8: Expected I, but got O
		//IL_0599: Expected I, but got O
		//IL_05a7: Expected I, but got O
		//IL_05b7: Expected O, but got I
		//IL_0637: Expected O, but got I4
		//IL_05f3: Expected O, but got I
		//IL_0469: Expected O, but got I
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_0629: Expected O, but got I4
		//IL_04f7: Expected O, but got I
		//IL_0975: Expected O, but got I4
		//IL_052d: Expected O, but got I
		//IL_04c9: Expected O, but got I8
		//IL_0303: Expected O, but got I
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_0391: Expected O, but got I
		//IL_093c: Expected O, but got I4
		//IL_0363: Expected O, but got I8
		//IL_0057->IL0057: Incompatible stack heights: 0 vs 1
		//IL_00d7->IL00d7: Incompatible stack heights: 2 vs 1
		//IL_01f1->IL03c2: Incompatible stack heights: 4 vs 3
		//IL_04b7->IL04e7: Incompatible stack heights: 4 vs 5
		//IL_0536->IL0536: Incompatible stack heights: 6 vs 3
		//IL_04ce->IL096c: Incompatible stack heights: 4 vs 5
		//IL_0790->IL09c7: Incompatible stack heights: 9 vs 0
		//IL_0351->IL0381: Incompatible stack heights: 10 vs 11
		//IL_03c2->IL0779: Incompatible stack heights: 12 vs 9
		//IL_0368->IL0933: Incompatible stack heights: 10 vs 11
		Debug.Log("<AddNewEnemyFollower>");
		if (_latestKilledEnemyThatCanBeFollowerData == null)
		{
			return null;
		}
		object obj = UnityEngine.Random.RandomRangeInt(1, 7);
		object obj2 = obj - 1;
		object obj3 = 6442450944L;
		if ((nint)obj2 <= 6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rbx_v12+77A71C8+v125 @ rax_v32*4]");
			object obj4 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v262 @ rax_v141 (should have been resolved before IL gen)");
		}
		else
		{
			bool flag = m_EnemyFollowerPools == null;
		}
		int num = m_EnemyFollowerPools.FindEntry(followedCharacter);
		if (m_EnemyFollowerPools == null)
		{
			List<FollowerEnemy_CharacterController> value = new List<FollowerEnemy_CharacterController>();
			bool flag2 = m_EnemyFollowerPools == null;
			bool flag3 = ((Dictionary<object, object>)(object)m_EnemyFollowerPools).TryInsert((object)followedCharacter, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		bool flag4 = m_EnemyFollowerPools == null;
		List<FollowerEnemy_CharacterController> list = m_EnemyFollowerPools.get_Item(followedCharacter);
		bool flag5 = list == null;
		List<FollowerEnemy_CharacterController> value2 = list;
		List<FollowerEnemy_CharacterController>.Enumerator enumerator = default(List<FollowerEnemy_CharacterController>.Enumerator);
		Component component;
		while (true)
		{
			if (enumerator.MoveNext())
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = null;
				bool flag6 = characterController._isDead;
				nint num2 = 0;
				if (!flag6)
				{
					bool isDisconnectedFromOnlinePlay = ((VampireSurvivors.Objects.Characters.CharacterController)null).IsDisconnectedFromOnlinePlay;
					bool flag7 = !isDisconnectedFromOnlinePlay;
					num2 = unchecked((nint)null);
					if (flag7)
					{
						continue;
					}
				}
				component = null;
			}
			else
			{
				component = null;
				nint num2 = 0;
			}
			break;
		}
		bool flag8 = (object)component == null;
		nint num3 = (nint)typeof(UnityEngine.Object);
		bool num4;
		bool num5;
		bool num6;
		bool num7;
		bool num9;
		bool num10;
		VampireSurvivors.Objects.Characters.CharacterController characterController2;
		VampireSurvivors.Objects.Characters.CharacterController followedCharacter2;
		if (!flag8)
		{
			bool flag9 = (object)component == null;
			num4 = flag9;
			bool flag10 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			num3 = (nint)typeof(UnityEngine.Object);
			if (!flag10)
			{
				Transform transform = component.transform;
				bool flag11 = (object)followedCharacter == null;
				num5 = flag11;
				Transform transform2 = followedCharacter.transform;
				bool flag12 = (object)transform2 == null;
				num6 = flag12;
				bool flag13 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				num7 = flag13;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				float num8 = (float)ret + 1f;
				bool flag14 = (object)transform == null;
				num9 = flag14;
				bool flag15 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				num10 = flag15;
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value2));
				_ = 0;
				((VampireSurvivors.Objects.Characters.CharacterController)component).SetMovementAI(AIType.Defensive, followedCharacter);
				_ = 3;
				_ = followedCharacter._level;
				_ = followedCharacter._xp;
				((FollowerEnemy_CharacterController)component).Activate();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				UnityEngine.Object obj5 = default(UnityEngine.Object);
				bool flag16 = obj5;
				bool flag17 = !flag16;
				characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)component;
				followedCharacter2 = followedCharacter;
				if (flag17)
				{
					goto IL_0779;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				object obj6 = default(object);
				bool flag18 = obj6 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				Action<short, bool, CoherenceSync> action = null;
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ r10_v11 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ r10_v11 (Il2CppMethodInfo)+4C]");
				object obj7 = (nint)0 >> 4;
				object obj8 = obj7 & 1;
				object obj9;
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ r10_v11 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 3)
					{
						obj9 = 6447777712L;
						goto IL_0933;
					}
				}
				else
				{
					object obj10 = default(object);
					bool flag19 = obj10 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1823 @ rax_v104 (System.Action`3<System.Int16, System.Boolean, Coherence.Toolkit.CoherenceSync>)+10]");
				obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1823 @ rax_v104 (System.Action`3<System.Int16, System.Boolean, Coherence.Toolkit.CoherenceSync>)+20]");
				_ = 0;
				goto IL_0933;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
		UnityEngine.Object obj11 = default(UnityEngine.Object);
		if (!obj11)
		{
			goto IL_0536;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
		object obj12 = default(object);
		bool flag20 = obj12 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
		Action<short, bool> action2 = null;
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ r10_v10 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ r10_v10 (Il2CppMethodInfo)+4C]");
		object obj13 = (nint)0 >> 4;
		object obj14 = obj13 & 1;
		object obj15;
		if (obj14 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ r10_v10 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 2)
			{
				obj15 = 6447764320L;
				goto IL_096c;
			}
		}
		else
		{
			object obj16 = default(object);
			bool flag21 = obj16 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1507 @ rax_v67 (System.Action`2<System.Int16, System.Boolean>)+10]");
		obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1507 @ rax_v67 (System.Action`2<System.Int16, System.Boolean>)+20]");
		_ = 0;
		goto IL_096c;
		IL_0933:
		object obj17 = 24;
		_ = 6447777568L;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v102+78]");
		bool flag22 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F62000");
		characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)component;
		followedCharacter2 = followedCharacter;
		goto IL_0779;
		IL_0536:
		bool flag23 = (object)GM.Core == null;
		num4 = flag23;
		bool flag24 = default(bool);
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = GM.Core.AddFollower(CharacterType.FOLLOWER_ENEMY, followedCharacter, AIType.Defensive, flag24, everyXLevels, spawnWithoutAuthority);
		bool flag25 = (object)characterController3 == null;
		num5 = flag25;
		nint num13 = (nint)characterController3;
		nint num14 = (nint)typeof(FollowerEnemy_CharacterController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Characters.FollowerEnemy_CharacterController>)+130]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Characters.FollowerEnemy_CharacterController>)+130]");
		object obj20;
		if (num15 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ rcx_v52+FFFFFFF8+v1508 @ rcx_v45*8]");
			if (0 == (nint)typeof(FollowerEnemy_CharacterController))
			{
				obj20 = 1;
				goto IL_09a5;
			}
		}
		obj20 = 0;
		goto IL_09a5;
		IL_0779:
		RefreshEnemyFollowersList(followedCharacter2);
		return (FollowerEnemy_CharacterController)characterController2;
		IL_09a5:
		bool flag26 = obj20 == null;
		characterController2 = null;
		if (!flag26)
		{
			characterController2 = characterController3;
		}
		bool flag27 = (object)characterController2 == null;
		num6 = flag27;
		characterController2._003CTrackedByCamera_003Ek__BackingField = false;
		characterController2.IsFollowerSharingPassives = false;
		characterController2._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
		bool flag28 = m_EnemyFollowerPools == null;
		num7 = flag28;
		List<FollowerEnemy_CharacterController> list2 = m_EnemyFollowerPools.get_Item(followedCharacter);
		bool flag29 = list2 == null;
		num9 = flag29;
		int version = list2._version + 1;
		list2._version = version;
		FollowerEnemy_CharacterController[] items = list2._items;
		bool flag30 = list2._items == null;
		num10 = flag30;
		if (list2._size >= items.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)characterController2);
			followedCharacter2 = followedCharacter;
		}
		else
		{
			int size = list2._size + 1;
			list2._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			followedCharacter2 = followedCharacter;
		}
		goto IL_0779;
		IL_096c:
		object obj21 = 24;
		_ = 6447764192L;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rax_v65+78]");
		bool flag31 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rax_v65+78]");
		bool flag32 = ((CoherenceSync)0).SendCommand(action2, MessageTarget.Other, (short)_latestKilledEnemyThatCanBeFollowerType, flag24);
		goto IL_0536;
	}

	public unsafe void KillAllFollowers(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
	{
		//IL_0050: Expected O, but got Ref
		bool flag = m_EnemyFollowerPools == null;
		int num = m_EnemyFollowerPools.FindEntry(followedCharacter);
		if (!flag)
		{
			List<FollowerEnemy_CharacterController> list = m_EnemyFollowerPools.get_Item(followedCharacter);
			List<FollowerEnemy_CharacterController>.Enumerator enumerator = default(List<FollowerEnemy_CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = null;
				List<FollowerEnemy_CharacterController>.Enumerator enumerator2 = (List<FollowerEnemy_CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	public bool IsWeaponTypeAvailable(WeaponType element)
	{
		//IL_0333: Expected I4, but got O
		//IL_006b: Expected O, but got I4
		//IL_0137: Expected O, but got I4
		//IL_0203: Expected O, but got I4
		//IL_02ab: Expected O, but got I4
		//IL_02d9: Expected O, but got I4
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		if (loadedDlc != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)0);
			if (num < 0)
			{
				object obj = element - 101;
				if ((nint)obj <= 20)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt ecx,eax\"");
					if ((nint)obj < 20)
					{
						goto IL_0319;
					}
				}
				if (element == WeaponType.BUBBLES2)
				{
					goto IL_0319;
				}
			}
			Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
			if (loadedDlc2 != null)
			{
				int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)1);
				if (num2 < 0)
				{
					object obj2 = element - 127;
					if ((nint)obj2 <= 12)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt ecx,eax\"");
						if ((nint)obj2 < 12)
						{
							goto IL_0319;
						}
					}
					if (element == WeaponType.SHADOWSERVANT2)
					{
						goto IL_0319;
					}
				}
				Dictionary<DlcType, BundleManifestData> loadedDlc3 = DlcSystem.LoadedDlc;
				if (loadedDlc3 != null)
				{
					int num3 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc3).FindEntry((System.Int32Enum)2);
					if (num3 < 0)
					{
						object obj3 = element - 166;
						if ((nint)obj3 <= 14 || element == WeaponType.C1_HATCOLLECTION_EXPLO)
						{
							goto IL_0319;
						}
					}
					Dictionary<DlcType, BundleManifestData> loadedDlc4 = DlcSystem.LoadedDlc;
					if (loadedDlc4 != null)
					{
						int num4 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc4).FindEntry((System.Int32Enum)3);
						if (num4 < 0)
						{
							object obj4 = element - 300;
							if ((nint)obj4 > 22)
							{
								object obj5 = element - 333;
								if ((nint)obj5 > 9 && element != WeaponType.FB_EXPLOBARRELHAZARD)
								{
									goto IL_031f;
								}
							}
							goto IL_0319;
						}
						goto IL_031f;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0319:
		return false;
		IL_031f:
		return true;
	}

	public void DebugCharShowcase()
	{
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		Dictionary<WeaponType, List<WeaponData>> dictionary = convertedWeapons;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			if (_dataManager != null)
			{
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
	}

	public void DebugCoopShowcase(bool prioritiseEvolvablePairings, long seed = -1L, int minusMaxLevel = 0)
	{
		//IL_0901: Expected I8, but got F4
		//IL_091b: Invalid comparison between I4 and F4
		//IL_09d0: Expected I, but got O
		//IL_09e6: Expected O, but got I
		//IL_0128: Expected O, but got I8
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c0: Expected O, but got I8
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_0ca5: Expected O, but got I4
		//IL_0cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Expected O, but got Unknown
		//IL_0186: Expected O, but got I8
		//IL_0197: Expected O, but got I
		//IL_08a2: Expected O, but got I
		//IL_08b7: Expected O, but got I
		//IL_08d2: Expected O, but got I
		//IL_027e: Expected O, but got I4
		//IL_0636: Expected O, but got I
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Expected O, but got Unknown
		//IL_0673: Expected I4, but got O
		//IL_0bf3: Expected O, but got I4
		//IL_0c78: Expected O, but got I4
		//IL_03c5: Expected I4, but got O
		//IL_03e1: Expected O, but got I4
		//IL_0400: Expected O, but got I
		//IL_05c2: Expected O, but got I
		//IL_081d: Expected O, but got I
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Expected O, but got Unknown
		//IL_0452: Expected I4, but got O
		//IL_082b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Expected O, but got Unknown
		//IL_085a: Expected I4, but got O
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected O, but got Unknown
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected O, but got Unknown
		//IL_07a9: Expected O, but got I
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected O, but got Unknown
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected O, but got Unknown
		//IL_02de->IL0b59: Incompatible stack heights: 5 vs 4
		//IL_030b->IL0b59: Incompatible stack heights: 5 vs 4
		//IL_0338->IL0b59: Incompatible stack heights: 5 vs 4
		//IL_0365->IL0b59: Incompatible stack heights: 5 vs 4
		//IL_0580->IL0b80: Incompatible stack heights: 5 vs 4
		//IL_0221->IL0b33: Incompatible stack heights: 7 vs 2
		//IL_03ae->IL0b59: Incompatible stack heights: 6 vs 4
		//IL_088d->IL0214: Incompatible stack heights: 8 vs 7
		//IL_0bb0->IL0b80: Incompatible stack heights: 5 vs 4
		//IL_04c6->IL0b59: Incompatible stack heights: 7 vs 4
		//IL_0626->IL0ba3: Incompatible stack heights: 6 vs 5
		//IL_048a->IL03eb: Incompatible stack heights: 9 vs 7
		//IL_0888->IL0c61: Incompatible stack heights: 9 vs 7
		//IL_0619->IL0bb0: Incompatible stack heights: 6 vs 5
		//IL_080d->IL0c12: Incompatible stack heights: 9 vs 8
		//IL_0800->IL0c35: Incompatible stack heights: 9 vs 8
		long num;
		long num2;
		if (seed >= 0)
		{
			num = seed << 13;
			num2 = seed;
		}
		else
		{
			num = (long)UnityEngine.Random.value;
			float num3 = 0f * 4.2949673E+09f;
			if (0f > num3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				num2 = num << 13;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
				num2 = num << 13;
			}
		}
		long num4 = num2 ^ num;
		long num5 = num4 >> 17;
		long num6 = num4 ^ num5;
		long num7 = num6 << 5;
		long num8 = num6 ^ num7;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		Func<KeyValuePair<WeaponType, List<WeaponData>>, bool> predicate = _003C_003Ec._003C_003E9__565_0;
		if (_003C_003Ec._003C_003E9__565_0 == null)
		{
			Func<KeyValuePair<WeaponType, List<WeaponData>>, bool> func = (_003C_003Ec._003C_003E9__565_0 = delegate(KeyValuePair<WeaponType, List<WeaponData>> w)
			{
				//IL_0219: Expected O, but got I
				//IL_003d: Expected O, but got I
				//IL_0052: Expected O, but got I
				//IL_008f: Expected O, but got I
				//IL_009f: Expected O, but got I
				//IL_00af: Expected O, but got I
				//IL_00e7: Expected O, but got I
				//IL_0124: Expected O, but got I
				//IL_0139: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
				object obj30 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
					object obj31 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v6+20]");
					object obj32 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v9+101]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v12+10]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v13+20]");
						object obj35 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v8+60]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
							object obj36 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v14+18]");
							if ((nint)0 <= (nint)0)
							{
								goto IL_021e;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v14+10]");
							object obj37 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v9+20]");
							object obj38 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v15+61]");
							if ((nint)0 == 0 && (nint)w != 88 && (nint)w != 100 && (nint)w != 158)
							{
								bool flag26 = (nint)w < 0;
								bool flag27 = (object)w == null;
								bool flag28 = !flag26;
								bool flag29 = !flag27;
								return flag29 & flag28;
							}
						}
					}
					return false;
				}
				goto IL_021e;
				IL_021e:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			});
			nint num9 = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v164 (Il2CppClass<VampireSurvivors.Framework.GameManager+<>c>)+B8]");
			object obj = (nint)0 + (nint)24;
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
				nint num11;
				do
				{
					object obj7 = 1 << (int)obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ r12_v10+462E0+v618 @ rdx_v58*8]");
					object obj8 = 0 | obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ r12_v10+462E0+v618 @ rdx_v58*8]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ r12_v10+462E0+v618 @ rdx_v58*8]");
					if (num10 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ r12_v10+462E0+v618 @ rdx_v58*8]");
					num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ r12_v10+462E0+v618 @ rdx_v58*8]");
				}
				while (num11 != 0);
				predicate = func;
			}
		}
		IEnumerable<KeyValuePair<WeaponType, List<WeaponData>>> enumerable = Enumerable.Where(convertedWeapons, predicate);
		bool flag2 = enumerable == null;
		List<KeyValuePair<System.Int32Enum, object>> list = new List<KeyValuePair<System.Int32Enum, object>>((IEnumerable<KeyValuePair<System.Int32Enum, object>>)enumerable);
		VampireSurvivors.App.Tools.Extensions.Shuffle((IList<KeyValuePair<WeaponType, List<WeaponData>>>)list, (Unity.Mathematics.Random)num8);
		Func<KeyValuePair<WeaponType, List<WeaponData>>, bool> predicate2 = _003C_003Ec._003C_003E9__565_1;
		if (_003C_003Ec._003C_003E9__565_1 == null)
		{
			predicate2 = (_003C_003Ec._003C_003E9__565_1 = delegate
			{
				//IL_0074: Expected O, but got I
				//IL_003d: Expected O, but got I
				//IL_0052: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [w @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.WeaponType, System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>>)+8]");
				object obj30 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
					object obj31 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v6+20]");
					object obj32 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v9+101]");
					return false;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			});
		}
		IEnumerable<KeyValuePair<WeaponType, List<WeaponData>>> enumerable2 = Enumerable.Where(convertedWeapons, predicate2);
		bool flag3 = enumerable2 == null;
		List<KeyValuePair<System.Int32Enum, object>> list2 = new List<KeyValuePair<System.Int32Enum, object>>((IEnumerable<KeyValuePair<System.Int32Enum, object>>)enumerable2);
		VampireSurvivors.App.Tools.Extensions.Shuffle((IList<KeyValuePair<WeaponType, List<WeaponData>>>)list2, (Unity.Mathematics.Random)num8);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ stack_8+2A8]");
		List<VampireSurvivors.Objects.Characters.CharacterController> list3 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)new List<object>((IEnumerable<object>)0);
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__565_2;
			if (_003C_003Ec._003C_003E9__565_2 == null)
			{
				comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__565_2 = delegate(VampireSurvivors.Objects.Characters.CharacterController a, VampireSurvivors.Objects.Characters.CharacterController b)
				{
					//IL_004e: Expected I4, but got O
					if ((object)OnlineStageManager._instance != null)
					{
						int seatNumberForCharacter = OnlineStageManager._instance.GetSeatNumberForCharacter(a);
						if ((object)OnlineStageManager._instance != null)
						{
							int seatNumberForCharacter2 = OnlineStageManager._instance.GetSeatNumberForCharacter(b);
							return seatNumberForCharacter - seatNumberForCharacter2;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				});
			}
			((List<object>)(object)list3).Sort(comparison);
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> list4 = list3;
		Dictionary<WeaponType, List<WeaponData>> dictionary = convertedWeapons;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<Equipment>.Enumerator enumerator2 = default(List<Equipment>.Enumerator);
		int num13 = default(int);
		int num14 = default(int);
		object obj16 = default(object);
		object obj20 = default(object);
		while (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
			bool flag4 = (object)characterController._weaponsManager == null;
			bool flag5 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField == null;
			while (enumerator2.MoveNext())
			{
				object obj9 = 0;
				_003C_003Ec__DisplayClass565_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass565_0();
				bool flag6 = CS_0024_003C_003E8__locals11 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rbx_v33+48]");
				CS_0024_003C_003E8__locals11.type = WeaponType.VOID;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rbx_v33+48]");
				bool flag7 = (nint)0 == 88;
				list4 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11;
				if (flag7)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rbx_v33+48]");
				bool flag8 = (nint)0 == 100;
				list4 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11;
				if (flag8)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rbx_v33+48]");
				bool flag9 = (nint)0 == 158;
				list4 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11;
				if (flag9)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rbx_v33+48]");
				bool flag10 = (nint)0 == 0;
				list4 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11;
				if (flag10)
				{
					continue;
				}
				bool flag11 = dictionary == null;
				Dictionary<WeaponType, List<WeaponData>> dictionary2 = dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rbx_v33+48]");
				int num12 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).FindEntry((System.Int32Enum)0);
				list4 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11;
				if (flag11)
				{
					continue;
				}
				object obj10 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)((List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11)._items);
				bool flag12 = obj10 == null;
				object obj11 = 1;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rax_v101 (System.Object)+18]");
					object obj12 = -num13;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
					{
						break;
					}
					bool flag13 = (object)GM.Core == null;
					GM.Core.LevelWeaponUp((WeaponType)((List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11)._items);
					bool flag14 = (object)GM.Core == null;
					GM.Core.HandleLevelUp();
					obj11++;
				}
				Func<KeyValuePair<WeaponType, List<WeaponData>>, bool> condition = delegate(KeyValuePair<WeaponType, List<WeaponData>> x)
				{
					//IL_000f: Unknown result type (might be due to invalid IL or missing references)
					//IL_0014: Expected O, but got Unknown
					object obj30 = x - CS_0024_003C_003E8__locals11.type;
					return obj30 == null;
				};
				VampireSurvivors.App.Tools.Extensions.RemoveWhere((ICollection<KeyValuePair<WeaponType, List<WeaponData>>>)list, condition);
				list4 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(object)CS_0024_003C_003E8__locals11;
				dictionary = convertedWeapons;
			}
			while (true)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> list5 = list4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rax_v31 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
				bool flag15 = (nint)list5 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rax_v31 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+10]");
				object obj13 = 0;
				object obj14 = list4 + 2;
				object obj15 = obj14 + obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1195 @ rcx_v68+v3451 @ rax_v87*8]");
				WeaponType weaponType = WeaponType.VOID;
				((List<KeyValuePair<WeaponType, List<WeaponData>>>)(object)list).RemoveAt((int)list4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1195 @ rcx_v68+v3451 @ rax_v87*8]");
				((VampireSurvivors.Objects.Characters.CharacterController)null).GiveMaxedWeaponToPlayer(WeaponType.VOID, num13);
				num14++;
				List<Equipment>.Enumerator enumerator3 = (List<Equipment>.Enumerator)(characterController._maxWeaponCount + characterController._maxWeaponBonus);
				if (num14 >= (nint)enumerator3)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rax_v31 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
				if ((nint)0 <= (nint)0)
				{
					break;
				}
				bool flag16 = obj16 == null;
				list4 = null;
				if (flag16)
				{
					continue;
				}
				List<VampireSurvivors.Objects.Characters.CharacterController> list6 = null;
				while (true)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> list7 = list6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rax_v31 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
					bool flag17 = (nint)list7 >= 0;
					list4 = null;
					if (flag17)
					{
						break;
					}
					List<VampireSurvivors.Objects.Characters.CharacterController> list8 = list6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rax_v31 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
					bool flag18 = (nint)list8 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rax_v31 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+10]");
					object obj17 = 0;
					object obj18 = list6 + 2;
					object obj19 = obj18 + obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1125 @ rcx_v73+v3501 @ rax_v94*8]");
					if (!((VampireSurvivors.Objects.Characters.CharacterController)null).WouldWeaponSynergise(WeaponType.VOID))
					{
						list6 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(list6 + 1);
						continue;
					}
					list4 = list6;
					break;
				}
				obj16 = obj20;
			}
			CharacterAccessoriesManager accessoriesManager = characterController._accessoriesManager;
			bool flag19 = (object)characterController._accessoriesManager == null;
			List<Equipment> list9 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField;
			bool flag20 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField == null;
			int num15 = list9._size;
			while (true)
			{
				List<Equipment>.Enumerator enumerator4 = (List<Equipment>.Enumerator)(characterController._maxAccessoryCount + characterController._maxAccessoryBonus);
				if (num15 >= (nint)enumerator4)
				{
					break;
				}
				bool flag21 = list2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ rax_v41 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
				if ((nint)0 <= (nint)0)
				{
					break;
				}
				bool flag22 = obj20 == null;
				list4 = null;
				if (!flag22)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> list10 = null;
					while (true)
					{
						List<VampireSurvivors.Objects.Characters.CharacterController> list11 = list10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ rax_v41 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
						bool flag23 = (nint)list11 >= 0;
						list4 = null;
						if (flag23)
						{
							break;
						}
						List<VampireSurvivors.Objects.Characters.CharacterController> list12 = list10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ rax_v41 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
						bool flag24 = (nint)list12 >= 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ rax_v41 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+10]");
						object obj21 = 0;
						object obj22 = list10 + 2;
						object obj23 = obj22 + obj22;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1829 @ rcx_v65+v3521 @ rax_v82*8]");
						if (!((VampireSurvivors.Objects.Characters.CharacterController)null).WouldWeaponSynergise(WeaponType.VOID))
						{
							list10 = (List<VampireSurvivors.Objects.Characters.CharacterController>)(list10 + 1);
							continue;
						}
						list4 = list10;
						break;
					}
				}
				List<VampireSurvivors.Objects.Characters.CharacterController> list13 = list4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ rax_v41 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+18]");
				bool flag25 = (nint)list13 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ rax_v41 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<System.Int32Enum, System.Object>>)+10]");
				object obj24 = 0;
				object obj25 = list4 + 2;
				object obj26 = obj25 + obj25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1908 @ rcx_v61+v3516 @ rax_v76*8]");
				WeaponType weaponType = WeaponType.VOID;
				((List<KeyValuePair<WeaponType, List<WeaponData>>>)(object)list2).RemoveAt((int)list4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1908 @ rcx_v61+v3516 @ rax_v76*8]");
				((VampireSurvivors.Objects.Characters.CharacterController)null).GiveMaxedWeaponToPlayer(WeaponType.VOID, num13);
				num15++;
			}
			dictionary = convertedWeapons;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ stack_8+E0]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v59+10]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v60+22C]");
		object obj29 = (nint)0 + (nint)1;
	}

	public unsafe void DebugGiveAllWeapons(bool includeSealedWeapons = true)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_00c5: Expected I, but got O
		//IL_00d2: Expected I, but got O
		//IL_043a: Expected I, but got O
		//IL_0447: Expected I, but got O
		//IL_0186: Expected O, but got I
		//IL_04fb: Expected O, but got I
		//IL_0299: Expected O, but got I
		//IL_060e: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		int num2 = default(int);
		int num = num2;
		if (num != 0)
		{
			int value = ((int*)num)->m_value;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v161 @ rax_v18 (System.Int32)+8F8] (should have been resolved before IL gen)");
			int num3 = 0;
			int num4 = 0;
			Array array = default(Array);
			while (true)
			{
				int length = array.Length;
				if (num4 < length)
				{
					object value2 = array.GetValue(num3);
					nint num5 = (nint)typeof(WeaponType);
					nint num6 = (nint)value2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v29 (Il2CppClass<System.Object>)+40]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r8_v15 (Il2CppClass<VampireSurvivors.Data.WeaponType>)+40]");
					if (num7 == 0)
					{
						DataManager dataManager = _dataManager;
						Dictionary<WeaponType, JArray> dictionary = dataManager._003CAllWeaponData_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
						int num8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
						if (num8 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
							if ((nint)0 != 24)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
								object obj3 = -88;
								if ((nint)obj3 <= 17)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt r12d,eax\"");
									if ((nint)obj3 < 17)
									{
										goto IL_081c;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
								if ((nint)0 != 158)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
									if ((nint)0 != 341)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
										if ((nint)0 != 1598)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
											if ((nint)0 != 1589)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
												if ((nint)0 != 1507)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
													object obj4 = -1407;
													if ((nint)obj4 > 3)
													{
														if (!includeSealedWeapons)
														{
															PlayerOptionsData config = _playerOptions.Config;
															List<WeaponType> list = config._003CSealedWeapons_003Ek__BackingField;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
															if (((Dictionary<WeaponType, JArray>)(object)list).FindEntry(WeaponType.VOID) != 0)
															{
																goto IL_081c;
															}
														}
														Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
														object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
														List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj5).get_Item(WeaponType.VOID);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v57 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+101]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v57 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+60]");
															if ((nint)0 != 0)
															{
																GameManager core = GM.Core;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v46 (System.Object)+10]");
																core.LevelWeaponUp(WeaponType.VOID);
																GameManager core2 = GM.Core;
																GameSessionData gameSessionData = core2._gameSessionData;
																gameSessionData._activeCharacter.LevelUp();
																VampireSurvivors.Objects.Characters.CharacterController characterController = null;
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
						goto IL_081c;
					}
					InvalidCastException ex = new InvalidCastException();
					break;
				}
				int num9 = 0;
				int num10 = 0;
				while (true)
				{
					int length2 = array.Length;
					if (num10 < length2)
					{
						object value3 = array.GetValue(num9);
						nint num11 = (nint)typeof(WeaponType);
						nint num12 = (nint)value3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v16 (Il2CppClass<System.Object>)+40]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ r8_v9 (Il2CppClass<VampireSurvivors.Data.WeaponType>)+40]");
						if (num13 != 0)
						{
							break;
						}
						DataManager dataManager2 = _dataManager;
						Dictionary<WeaponType, JArray> dictionary2 = dataManager2._003CAllWeaponData_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
						int num14 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).FindEntry((System.Int32Enum)0);
						if (num14 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
							if ((nint)0 != 24)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
								object obj6 = -88;
								if ((nint)obj6 <= 17)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt r12d,eax\"");
									if ((nint)obj6 < 17)
									{
										goto IL_0843;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
								if ((nint)0 != 158)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
									if ((nint)0 != 341)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
										if ((nint)0 != 1598)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
											if ((nint)0 != 1589)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
												if ((nint)0 != 1507)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
													object obj7 = -1407;
													if ((nint)obj7 > 3)
													{
														if (!includeSealedWeapons)
														{
															PlayerOptionsData config2 = _playerOptions.Config;
															List<WeaponType> list3 = config2._003CSealedWeapons_003Ek__BackingField;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
															if (((Dictionary<WeaponType, JArray>)(object)list3).FindEntry(WeaponType.VOID) != 0)
															{
																goto IL_0843;
															}
														}
														Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
														object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)0);
														List<WeaponData> list4 = ((Dictionary<WeaponType, List<WeaponData>>)obj8).get_Item(WeaponType.VOID);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v38 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+101]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v38 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+60]");
															if ((nint)0 != 0)
															{
																goto IL_0843;
															}
														}
														GameManager core3 = GM.Core;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v27 (System.Object)+10]");
														core3.LevelWeaponUp(WeaponType.VOID);
														GameManager core4 = GM.Core;
														GameSessionData gameSessionData2 = core4._gameSessionData;
														gameSessionData2._activeCharacter.LevelUp();
														VampireSurvivors.Objects.Characters.CharacterController characterController = null;
													}
												}
											}
										}
									}
								}
							}
						}
						goto IL_0843;
					}
					GameManager core5 = GM.Core;
					GameSessionData gameSessionData3 = core5._gameSessionData;
					LevelUpFactory levelUpFactory = core5._levelUpFactory;
					VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData3._activeCharacter;
					activeCharacter._xp = levelUpFactory._previousXpFactor;
					return;
					IL_0843:
					num9++;
					num10 = num9;
				}
				break;
				IL_081c:
				num3++;
				num4 = num3;
			}
			throw new InvalidCastException();
		}
		ArgumentNullException ex2 = new ArgumentNullException("enumType");
		throw ex2;
	}

	public void DestroyOnlineConfigs()
	{
		_playerOptions.DestroyOnlineConfigs();
	}

	public void InitializeStageLogicOnline()
	{
		PlayerOptionsData config = _playerOptions.Config;
		StageInit(config._003CSelectedStage_003Ek__BackingField);
		Stage stage = _stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			Stage stage2 = _stage;
			string text = ((UnityEngine.Object)stage2._fancyBg).GetName();
			string message = "Preloading fancy bg for online stage: " + text;
			Debug.Log(message);
			Stage stage3 = _stage;
			Action onComplete = LoadRestOfStageOnline;
			stage3._fancyBg.CustomPreload(onComplete);
		}
		else
		{
			SetupLighting();
			_stage.InitStagePostLoad();
			Stage stage4 = _stage;
			_bgMan = stage4._tilingBackground;
			_003CWaitForAllCharactersToBeLoaded_003Ed__578 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	private void LoadRestOfStageOnline()
	{
		SetupLighting();
		_stage.InitStagePostLoad();
		Stage stage = _stage;
		_bgMan = stage._tilingBackground;
		_003CWaitForAllCharactersToBeLoaded_003Ed__578 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	public unsafe void StartOnlineGame()
	{
		//IL_00e9: Expected O, but got Ref
		PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
		myPlayerInfo._003CUpdateAverageLatency_003Ek__BackingField = true;
		GameManager core = GM.Core;
		core._003CStartedAsOnlineMultiplayerRun_003Ek__BackingField = true;
		InitCoopChestRandomness();
		UpdateCameraTarget();
		ResumeGame();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB41D0");
		_Preloader.SetActive(value: false);
		_isGameRunning = true;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C1F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "STARTING GAME AT FRAME {0}.", (System.ParamsArray)(&obj));
		Debug.Log(message);
	}

	public void LevelUpWithoutScreen()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		_waitingForLevelUp = false;
		HandleLevelUp();
		_levelUpFactory.CalculateXpFactor();
		FinishLevelUpActions(WeaponType.VOID, setInvincibility: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public static bool IsOnMobile()
	{
		return false;
	}

	public static int GetAscensionBonusPercentage(int assignedPoints)
	{
		//IL_0052: Expected O, but got I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected I4, but got Unknown
		bool flag = assignedPoints >= 1;
		int num = 25;
		if (!flag)
		{
			num = 0;
		}
		int num2 = num + 25;
		if (assignedPoints < 2)
		{
			num2 = num;
		}
		if (assignedPoints >= 3)
		{
			object obj = assignedPoints - 2;
			object obj2 = obj * 25;
			return obj2 + num2;
		}
		return num2;
	}

	private IEnumerator InitRemoteCharacterWhenGameplayLoaded(GameObject characterInstance, CharacterType characterType)
	{
		_003CInitRemoteCharacterWhenGameplayLoaded_003Ed__574 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.characterInstance = characterInstance;
		obj.characterType = characterType;
		return obj;
	}

	private unsafe void GeneratePickupVfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0169: Expected O, but got Ref
		//IL_0183: Expected native int or pointer, but got O
		//IL_019d: Expected O, but got I
		//IL_01bd: Expected O, but got Ref
		//IL_01d7: Expected native int or pointer, but got O
		//IL_06b5: Expected O, but got I4
		//IL_01ef: Expected O, but got Ref
		//IL_0216: Expected O, but got I
		//IL_0230: Expected native int or pointer, but got O
		//IL_024a: Expected O, but got I
		//IL_026a: Expected O, but got Ref
		//IL_0284: Expected native int or pointer, but got O
		//IL_06d2: Expected O, but got I4
		//IL_02b6: Expected O, but got Ref
		//IL_02d0: Expected native int or pointer, but got O
		//IL_070c: Expected O, but got I
		//IL_0316: Expected O, but got I4
		//IL_03a2: Expected O, but got I
		//IL_03be: Expected O, but got I4
		//IL_048f: Expected O, but got Ref
		//IL_04a9: Expected native int or pointer, but got O
		//IL_0746: Expected O, but got I
		//IL_04e1: Expected O, but got Ref
		//IL_04fb: Expected native int or pointer, but got O
		//IL_0515: Expected O, but got I
		//IL_0535: Expected O, but got Ref
		//IL_054f: Expected native int or pointer, but got O
		//IL_0780: Expected O, but got I
		//IL_0587: Expected O, but got Ref
		//IL_05a1: Expected native int or pointer, but got O
		//IL_07b2: Expected O, but got I
		//IL_05e7: Expected O, but got I4
		//IL_07ec: Expected O, but got I
		//IL_0632: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxColor1");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxColor2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(25f, 50f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 10;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1D0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 400f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A8]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D8]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+E8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = new ParticleSystem.MinMaxCurve(-1000f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		particleSystemConfig._on = false;
		Transform parent = base.transform;
		ParticleSystem pickupVfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "PickupVfx");
		_pickupVfx = pickupVfx;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("items");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1D0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		minMaxCurve6 = new ParticleSystem.MinMaxCurve(2000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"CoinGold");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 264));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+108]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+118]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+128]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+138]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(225f, 275f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+148]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+158]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 360));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+168]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+178]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		minMaxCurve6 = new ParticleSystem.MinMaxCurve(800f);
		particleSystemConfig2._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve6 = new ParticleSystem.MinMaxCurve(0.2f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		particleSystemConfig2._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		_ = 257;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1D0]");
		particleSystemConfig2._collideBottom = (bool?)(object)0;
		particleSystemConfig2._on = false;
		Transform parent2 = base.transform;
		ParticleSystem jewelPickupVfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent2, "JewelPickupVfx");
		_jewelPickupVfx = jewelPickupVfx;
		RenderingExtensions.Start(_jewelPickupVfx);
	}

	private void InitializeGameSession()
	{
		//IL_00ed: Expected F4, but got I
		//IL_012a: Expected F4, but got I
		//IL_0167: Expected F4, but got I
		//IL_032b: Expected O, but got I4
		//IL_0337: Expected O, but got I4
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		//IL_06f7: Expected O, but got I
		//IL_0709: Expected O, but got I4
		//IL_0719: Expected O, but got I
		//IL_06e2: Expected O, but got I4
		PauseSystem._paused = true;
		Cleanup();
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedReapers_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			config2._003CHasUsedTrumpet_003Ek__BackingField = true;
		}
		PlayerOptionsData config3 = _playerOptions.Config;
		if (config3._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			config4._003CHasUsedMirror_003Ek__BackingField = true;
		}
		DataManager dataManager = _dataManager;
		_003CCanInterrupt_003Ek__BackingField = true;
		_003CCanShowGameOverRewardAd_003Ek__BackingField = true;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v14 (System.Object)+4C]");
		_defaultCoinValue = 0f;
		DataManager dataManager2 = _dataManager;
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)204);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v17 (System.Object)+4C]");
		_defaultFrozenSoulValue = 0f;
		DataManager dataManager3 = _dataManager;
		object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v20 (System.Object)+4C]");
		_defaultRedCoinBagValue = 0f;
		_physicsManager.InitPhysicsGroups(this);
		PlayerOptionsData config5 = _playerOptions.Config;
		int playerCount = _multiplayer.GetPlayerCount();
		bool flag;
		if (playerCount <= 1 && !_multiplayer.IsOnlineMultiplayer)
		{
			PlayerOptionsData config6 = _playerOptions.Config;
			flag = config6._003CSelectedGoldenEggs_003Ek__BackingField;
		}
		else
		{
			flag = false;
		}
		bool flag2 = !flag;
		bool flag3 = !flag2;
		config5._003CSelectedGoldenEggs_003Ek__BackingField = flag3;
		List<int> coopChestRandomness = new List<int>();
		_coopChestRandomness = coopChestRandomness;
		CommonVfxManager commonVfxManager = new CommonVfxManager();
		_commonVfxManager = commonVfxManager;
		_secondsTickerTimer = 0f;
		_canRunTickerTimer = true;
		PlayerOptionsData config7 = _playerOptions.Config;
		VampireSurvivors.Objects.Characters.CharacterController newCharacter = GeneratePlayerCharacter(config7._selectedChar, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
		AddMainCharacter(newCharacter);
		int localPlayerCount = _multiplayer.GetLocalPlayerCount();
		if (localPlayerCount <= 1)
		{
			goto IL_0487;
		}
		MultiplayerManager multiplayer = _multiplayer;
		List<CoopSlotData> slotsSelections = multiplayer._slotsSelections;
		object obj4 = 1;
		object obj5 = 1;
		goto IL_0d62;
		IL_0fd8:
		PlayerOptionsData playerOptionsData;
		List<ItemType> list = playerOptionsData._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r10_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		PlayerOptionsData playerOptionsData2;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				PlayerOptions playerOptions = _playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData2 = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0ef2;
							}
						}
						playerOptionsData2 = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData2 = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData2 = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0ef2;
			}
		}
		goto IL_0e94;
		IL_0e94:
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData playerOptionsData3;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData3 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0f61;
					}
				}
				playerOptionsData3 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_0f61;
		IL_0ef2:
		List<ArcanaType> list2 = playerOptionsData2._003CUnlockedArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		PlayerOptionsData playerOptionsData4;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj7 = default(object);
			if ((nint)obj7 != -1)
			{
				PlayerOptions playerOptions3 = _playerOptions;
				if (playerOptions3._onlineClientWithRunDataConfig != null)
				{
					playerOptionsData4 = playerOptions3._onlineClientWithRunDataConfig;
					goto IL_0f29;
				}
				if (playerOptions3._hostGameConfig == null)
				{
					if (playerOptions3._currentAdventureSaveData != null)
					{
						playerOptionsData4 = playerOptions3._currentAdventureSaveData;
						if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_0f29;
						}
					}
					PlayerOptionsData mainGameConfig = playerOptions3._mainGameConfig;
					mainGameConfig._003CHasKilledTheFinalBoss_003Ek__BackingField = true;
				}
				else
				{
					PlayerOptionsData hostGameConfig = playerOptions3._hostGameConfig;
					hostGameConfig._003CHasKilledTheFinalBoss_003Ek__BackingField = true;
				}
			}
		}
		goto IL_0e94;
		IL_0d5c:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0d62;
		IL_05cf:
		_physicsManager.InitPhysicsColliders();
		PlayerOptions playerOptions4 = _playerOptions;
		PlayerOptionsData playerOptionsData5;
		if (playerOptions4._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions4._hostGameConfig == null)
			{
				if (playerOptions4._currentAdventureSaveData != null)
				{
					playerOptionsData5 = playerOptions4._currentAdventureSaveData;
					if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0e29;
					}
				}
				playerOptionsData5 = playerOptions4._mainGameConfig;
			}
			else
			{
				playerOptionsData5 = playerOptions4._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData5 = playerOptions4._onlineClientWithRunDataConfig;
		}
		goto IL_0e29;
		IL_0e29:
		Dictionary<EnemyType, int> dictionary = playerOptionsData5._003CKillCount_003Ek__BackingField;
		int num = playerOptionsData5._003CKillCount_003Ek__BackingField.FindEntry(EnemyType.BOSS_ENDER);
		object obj8;
		if (num < 0)
		{
			obj8 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v13 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.EnemyType, System.Int32>)+18]");
			object obj9 = 0;
			object obj10 = num + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v117+2C+v2093 @ rax_v165*8]");
			obj8 = 0;
		}
		PlayerOptions playerOptions5 = _playerOptions;
		PlayerOptionsData playerOptionsData6;
		if (playerOptions5._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions5._hostGameConfig == null)
			{
				if (playerOptions5._currentAdventureSaveData != null)
				{
					playerOptionsData6 = playerOptions5._currentAdventureSaveData;
					if ((object)playerOptionsData6._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0e6f;
					}
				}
				playerOptionsData6 = playerOptions5._mainGameConfig;
			}
			else
			{
				playerOptionsData6 = playerOptions5._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData6 = playerOptions5._onlineClientWithRunDataConfig;
		}
		goto IL_0e6f;
		IL_0ce3:
		LootManager lootManager;
		lootManager.CheckForAddedLoot();
		if (!_multiplayer.IsOnlineMultiplayer)
		{
			StageInit(playerOptionsData3._003CSelectedStage_003Ek__BackingField);
		}
		return;
		IL_0e6f:
		if (playerOptionsData6._003CHasKilledTheFinalBoss_003Ek__BackingField || (nint)obj8 <= 0)
		{
			goto IL_0e94;
		}
		PlayerOptions playerOptions6 = _playerOptions;
		if (playerOptions6._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions6._hostGameConfig == null)
			{
				if (playerOptions6._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = playerOptions6._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData = currentAdventureSaveData;
						goto IL_0fd8;
					}
				}
				playerOptionsData = playerOptions6._mainGameConfig;
			}
			else
			{
				playerOptionsData = playerOptions6._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData = playerOptions6._onlineClientWithRunDataConfig;
		}
		goto IL_0fd8;
		IL_0f29:
		playerOptionsData4._003CHasKilledTheFinalBoss_003Ek__BackingField = true;
		goto IL_0e94;
		IL_0d62:
		while ((nint)obj5 < slotsSelections._size)
		{
			if ((nint)obj4 < slotsSelections._size)
			{
				CoopSlotData[] items = slotsSelections._items;
				CoopSlotData coopSlotData = items[obj4];
				if (coopSlotData.SelectedCharacter != CharacterType.VOID && coopSlotData.AIType == AIType.None && coopSlotData.RewiredPlayer != null)
				{
					string text = coopSlotData.RewiredPlayer.ToString();
					string message = "GeneratingPlayerCharacter for player " + text + " at slot index : {index}";
					Debug.Log(message);
					int id = coopSlotData.RewiredPlayer.id;
					VampireSurvivors.Objects.Characters.CharacterController playerOne = GeneratePlayerCharacter(coopSlotData.SelectedCharacter, id);
					AddLocalCharacter(playerOne);
				}
				obj4++;
				obj5 = obj4;
				continue;
			}
			goto IL_0d5c;
		}
		goto IL_0487;
		IL_0487:
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PlayerCameraTarget");
		if (((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform coopCameraTarget = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			_coopCameraTarget = coopCameraTarget;
			_003CManualCameraTargetControl_003Ek__BackingField = null;
			if (!_multiplayer.IsOnlineMultiplayer)
			{
				UpdateCameraTarget();
			}
			ProCamera2D instance = ProCamera2D.Instance;
			float duration = default(float);
			Vector2 targetOffset = default(Vector2);
			Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.AddCameraTarget(_coopCameraTarget, 1f, 1f, duration, targetOffset);
			LevelUpFactory levelUpFactory = _levelUpFactory;
			_levelUpFactory.CalculateXpFactor();
			GameSessionData gameSessionData = levelUpFactory._gameSessionData;
			_levelUpFactory.CalculateWeights(gameSessionData._activeCharacter);
			int playerCount2 = MultiplayerManager.s_instance.GetPlayerCount();
			if (playerCount2 <= 1 && !MultiplayerManager.s_instance.IsOnlineMultiplayer)
			{
				GameManager core = GM.Core;
				if (!core._multiplayer.IsOnlineMultiplayer)
				{
					goto IL_05cf;
				}
			}
			_levelUpFactory.InitAmuletBag();
			goto IL_05cf;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(gameObject);
		goto IL_0d5c;
		IL_0f61:
		if (playerOptionsData3._003CSelectedStage_003Ek__BackingField == StageType.WAREHOUSE)
		{
			PlayerOptions playerOptions7 = _playerOptions;
			PlayerOptionsData mainGameConfig2 = playerOptions7._mainGameConfig;
			mainGameConfig2._003CHasPlayedStage3_003Ek__BackingField = true;
		}
		_defangIndex = 0;
		List<float> defangChancesArray = Weapon.MakeChanceArray(1000);
		_defangChancesArray = defangChancesArray;
		LootManager lootManager2 = _lootManager;
		List<ItemType> addedLoot = new List<ItemType>();
		lootManager2._addedLoot = addedLoot;
		lootManager2._forcedLootTable = null;
		lootManager2.MakeDefaultLootTable();
		lootManager = _lootManager;
		List<ItemType> items2;
		if (lootManager._forcedLootTable == null)
		{
			Stage stage = lootManager._stage;
			StageData stageData = stage._stageData;
			if (stageData._003CLootTable_003Ek__BackingField == null)
			{
				lootManager.MakeDefaultLootTable();
				goto IL_0ce3;
			}
			items2 = stageData._003CLootTable_003Ek__BackingField;
		}
		else
		{
			items2 = lootManager._forcedLootTable;
		}
		lootManager.MakeCustomLootTable(items2);
		goto IL_0ce3;
	}

	private unsafe void InitializeGameSessionPostLoad()
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I8
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_09db: Expected O, but got I4
		//IL_09eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Expected O, but got Unknown
		//IL_0249: Expected O, but got I
		//IL_0258: Expected O, but got I4
		//IL_08ce: Expected O, but got I
		//IL_03d2: Expected F4, but got I4
		//IL_06f3: Expected O, but got I4
		//IL_06fb: Expected O, but got Ref
		if (_multiplayer != null)
		{
			if (_multiplayer.IsOnlineMultiplayer)
			{
				goto IL_084c;
			}
			if ((object)_stage != null)
			{
				_stage.InitStagePostLoad();
				Stage stage = _stage;
				if ((object)_stage != null)
				{
					_bgMan = stage._tilingBackground;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					if ((nint)0 != 0)
					{
						object obj = this + 632;
						object obj2 = obj >> 12;
						object obj3 = obj2 & 0x1FFFFF;
						object obj4 = obj3 >> 6;
						object obj5 = 6603577472L;
						object obj6 = obj3 & 0x3F;
						nint num2;
						do
						{
							object obj7 = 1 << (int)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rsi_v7+462E0+v684 @ rdx_v70*8]");
							object obj8 = 0 | obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rsi_v7+462E0+v684 @ rdx_v70*8]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rsi_v7+462E0+v684 @ rdx_v70*8]");
							if (num == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rsi_v7+462E0+v684 @ rdx_v70*8]");
							num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rsi_v7+462E0+v684 @ rdx_v70*8]");
						}
						while (num2 != 0);
					}
					goto IL_084c;
				}
			}
		}
		goto IL_07f1;
		IL_07f1:
		throw new NullReferenceException();
		IL_084c:
		System.Int32Enum key;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				float targetTick = ((!config._003CSelectedHurry_003Ek__BackingField) ? 1f : 0.5f);
				_targetTick = targetTick;
				ProCamera2D instance = ProCamera2D.Instance;
				if ((object)instance != null)
				{
					instance.CenterOnTargets();
					GoldFingerManager goldFingerManager = new GoldFingerManager(ArcadePhysics.s_scene);
					_003CGoldFingerManager_003Ek__BackingField = goldFingerManager;
					Component touchJoystick = _TouchJoystick;
					if ((object)_TouchJoystick != null && _playerOptions != null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						if (config2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v5 (UnityEngine.Component)+20]");
							bool flag = (nint)0 == 0;
							if (!flag)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v5 (UnityEngine.Component)+20]");
								int num3 = ((Dictionary<System.Int32Enum, object>)0).FindEntry((System.Int32Enum)config2._003CSelectedJoystickType_003Ek__BackingField);
								object obj9 = !flag;
								if (obj9 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v5 (UnityEngine.Component)+20]");
									if ((nint)0 != 0)
									{
										key = (System.Int32Enum)1;
										goto IL_08b9;
									}
								}
								else
								{
									PlayerOptionsData config3 = _playerOptions.Config;
									if (config3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v5 (UnityEngine.Component)+20]");
										if ((nint)0 != 0)
										{
											key = (System.Int32Enum)config3._003CSelectedJoystickType_003Ek__BackingField;
											goto IL_08b9;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07f1;
		IL_08b9:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v5 (UnityEngine.Component)+20]");
		object original = ((Dictionary<System.Int32Enum, object>)0).get_Item(key);
		Transform parent = _TouchJoystick.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)original, parent);
		if ((object)_TouchJoystick != null)
		{
			CanvasGroup componentInChildren = _TouchJoystick.GetComponentInChildren<CanvasGroup>();
			_touchJoystickCanvasGroup = componentInChildren;
			if (_playerOptions != null)
			{
				PlayerOptionsData config4 = _playerOptions.Config;
				if (config4 != null)
				{
					bool flag2 = config4._003CJoystickVisible_003Ek__BackingField;
					float alpha = 1f;
					if (!flag2)
					{
						alpha = 0f;
					}
					if ((object)_touchJoystickCanvasGroup != null)
					{
						_touchJoystickCanvasGroup.alpha = alpha;
						if (_arcanaManager != null)
						{
							_arcanaManager.InitializeSupportObjects();
							if (_multiplayer != null)
							{
								if (!_multiplayer.IsOnlineMultiplayer)
								{
									SetupLighting();
								}
								SoundManager._003CAllowUIFades_003Ek__BackingField = true;
								if (_multiplayer != null)
								{
									if (!_multiplayer.IsOnlineMultiplayer)
									{
										PostStageInit();
									}
									if (_diContainer != null)
									{
										GameplayCheatCodeManager gameplayCheatCodeManager = _diContainer.Instantiate<GameplayCheatCodeManager>();
										_gameplayCheatCodeManager = gameplayCheatCodeManager;
										if (_gameplayCheatCodeManager != null)
										{
											_gameplayCheatCodeManager.Initialize();
											if (_diContainer != null)
											{
												ExplosionManager explosionManager = _diContainer.Instantiate<ExplosionManager>();
												_explosionManager = explosionManager;
												ExplosionManager explosionManager2 = _explosionManager;
												if (_explosionManager != null && (object)HeroVfxManager._factory != null)
												{
													ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.Explosions);
													explosionManager2._explosionPool = pool;
													if (_multiplayer != null)
													{
														if (!_multiplayer.IsOnlineMultiplayer)
														{
															ResumeGame();
														}
														if (_spellsManager != null)
														{
															_spellsManager.ActivateSpells();
															if (_multiplayer != null)
															{
																if (!_multiplayer.IsOnlineMultiplayer)
																{
																	if (_signalBus == null)
																	{
																		goto IL_07f1;
																	}
																	ObjectPool pool2 = ((GenericPoolFactory<HeroVfxType>)(object)_signalBus).GetPool(HeroVfxType.CrabRedWarning);
																}
																if (_multiplayer != null)
																{
																	bool isOnlineMultiplayer = _multiplayer.IsOnlineMultiplayer;
																	bool isGameRunning = (byte)((isOnlineMultiplayer ? 1u : 0u) ^ 1u) != 0;
																	_isGameRunning = isGameRunning;
																	if (_characters != null)
																	{
																		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
																		if (enumerator.MoveNext())
																		{
																			object obj10 = 0;
																			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
																			throw new NullReferenceException();
																		}
																		if (_playerOptions != null)
																		{
																			_playerOptions.Save();
																			if (_multiplayer != null)
																			{
																				if (_multiplayer.IsOnlineMultiplayer)
																				{
																					_003CSignalGameplayLoaded_003Ed__584 obj11 = null;
																					obj11._003C_003E1__state = 0;
																					obj11._003C_003E4__this = this;
																					Coroutine signalGameplayLoadedRoutine = StartCoroutine(obj11);
																					_signalGameplayLoadedRoutine = signalGameplayLoadedRoutine;
																				}
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
		goto IL_07f1;
	}

	private IEnumerator WaitForAllCharactersToBeLoaded()
	{
		_003CWaitForAllCharactersToBeLoaded_003Ed__578 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void AddStartingWeaponsForAllCharacters()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController> charactersToAddStartingWeapon = GetCharactersToAddStartingWeapon();
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			AddStartingWeapon(null);
			throw new NullReferenceException();
		}
	}

	private unsafe List<VampireSurvivors.Objects.Characters.CharacterController> GetCharactersToAddStartingWeapon()
	{
		//IL_0015: Expected O, but got I
		//IL_004b: Expected O, but got I
		//IL_0151: Expected O, but got Ref
		//IL_008a: Expected O, but got I4
		//IL_0092: Expected O, but got Ref
		//IL_0237: Expected O, but got I4
		//IL_01e4: Expected O, but got I
		//IL_01ed: Expected O, but got I4
		//IL_0309: Expected O, but got I
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_047c: Expected I, but got O
		//IL_0283: Expected I, but got O
		//IL_02e1: Expected I, but got O
		List<VampireSurvivors.Objects.Characters.CharacterController> list = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		MultiplayerManager core = (MultiplayerManager)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v11 (VampireSurvivors.Framework.MultiplayerManager)+168]");
			core = (MultiplayerManager)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v11 (VampireSurvivors.Framework.MultiplayerManager)+168]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v11 (VampireSurvivors.Framework.MultiplayerManager)+168]");
				if (!((MultiplayerManager)0).IsOnlineMultiplayer)
				{
					if (_characters != null)
					{
						List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
						if (enumerator.MoveNext())
						{
							object obj = 0;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						goto IL_03f7;
					}
				}
				else
				{
					bool flag = (object)OnlineStageManager._instance == null;
					core = (MultiplayerManager)(object)OnlineStageManager._instance;
					if (!flag)
					{
						IEnumerable<PlayerInfo> enumerable = OnlineStageManager._instance.IterateSeats();
						bool flag2 = enumerable == null;
						core = (MultiplayerManager)(object)OnlineStageManager._instance;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							object obj3 = default(object);
							object obj2 = (object)(&obj3);
							PlayerInfo playerInfo = null;
							object obj4 = default(object);
							PlayerInfo playerInfo2 = default(PlayerInfo);
							object obj14 = default(object);
							while (true)
							{
								object obj6;
								object obj13;
								if (obj3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									if (obj4 == null)
									{
										break;
									}
									bool flag3 = obj3 == null;
									playerInfo = null;
									if (!flag3)
									{
										object obj5 = obj3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ r10_v6+12E]");
										if ((nint)0 >= (nint)0)
										{
											goto IL_0224;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ r10_v6+B0]");
										obj6 = 0;
										object obj7 = 0;
										while (true)
										{
											object obj8 = obj7 + obj7;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ r8_v12+v713 @ rax_v50*8]");
											if (0 == (nint)typeof(IEnumerator<PlayerInfo>))
											{
												break;
											}
											obj7++;
											object obj9 = obj7;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ r10_v6+12E]");
											if ((nint)obj9 < 0)
											{
												continue;
											}
											goto IL_0224;
										}
										object obj10 = obj7 + obj7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ r8_v12+8+v769 @ rcx_v38*8]");
										object obj11 = (nint)0 << 4;
										object obj12 = obj11 + 312;
										obj13 = obj12 + obj5;
										goto IL_04b2;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
								IL_04b2:
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v774 @ rdx_v17] (should have been resolved before IL gen)");
								playerInfo = (PlayerInfo)(object)typeof(UnityEngine.Object);
								bool flag4 = (object)playerInfo2 == null;
								nint num = (nint)typeof(IEnumerator<PlayerInfo>);
								if (flag4)
								{
									continue;
								}
								bool flag5 = ((UnityEngine.Object)playerInfo2).m_CachedPtr == (IntPtr)0;
								num = (nint)typeof(IEnumerator<PlayerInfo>);
								playerInfo = (PlayerInfo)(object)typeof(UnityEngine.Object);
								if (!flag5)
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo2.CharacterController;
									if (list == null)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
									num = (nint)typeof(IEnumerator<PlayerInfo>);
								}
								continue;
								IL_0224:
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
								obj6 = 0;
								obj13 = obj14;
								goto IL_04b2;
							}
							if (obj2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							goto IL_03f7;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03f7:
		return list;
	}

	private void StageInit(StageType stageType)
	{
		_stage.InitStage(stageType);
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedStage_003Ek__BackingField == StageType.SINKING)
		{
			goto IL_00b4;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_00b4;
			}
		}
		goto IL_0139;
		IL_0139:
		PlayerOptionsData config3 = _playerOptions.Config;
		List<ItemType> list2 = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				SetupMusicBanger();
				goto IL_01b9;
			}
		}
		SetupMusicNormal();
		goto IL_01b9;
		IL_01b9:
		_levelUpFactory.ExcludeNonOwnedLockedWeapons(_characters);
		return;
		IL_00b4:
		_stage.SpawnMerchant();
		Stage stage = _stage;
		PickupMerchant trouserMerchant = stage.TrouserMerchant;
		if ((object)stage.TrouserMerchant != null && ((UnityEngine.Object)trouserMerchant).m_CachedPtr != (IntPtr)0)
		{
			List<CharacterType> customMerchantCharacters = _playerOptions.GetCustomMerchantCharacters();
			_stage.SpawnCustomMerchants(customMerchantCharacters);
		}
		goto IL_0139;
	}

	private void PostStageInit()
	{
		//IL_0179: Expected I, but got O
		//IL_0181: Expected I4, but got O
		//IL_0191: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_03cd: Expected I, but got O
		//IL_03d5: Expected I, but got O
		//IL_03e5: Expected O, but got I
		//IL_046b: Expected I, but got O
		//IL_0488: Expected O, but got I
		//IL_0490: Expected I, but got O
		//IL_0421: Expected O, but got I
		//IL_04cc: Expected O, but got I
		Stage stage = _stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			Stage stage2 = _stage;
			if (!stage2._fancyBg.ShouldPlayNormalMusic())
			{
				goto IL_0651;
			}
		}
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				SetupMusicBanger();
				goto IL_0672;
			}
		}
		SetupMusicNormal();
		goto IL_0672;
		IL_0517:
		AddStartingWeaponsForAllCharacters();
		Stage stage3 = _stage;
		StageData stageData = stage3._stageData;
		float num = default(float);
		if (stage3._stageData != null)
		{
			Tileset tileset = stageData._003Ctileset_003Ek__BackingField;
			if (stageData._003Ctileset_003Ek__BackingField != null && tileset._003ChardBounds_003Ek__BackingField != null)
			{
				Stage stage4 = _stage;
				StageData stageData2 = stage4._stageData;
				Tileset tileset2 = stageData2._003Ctileset_003Ek__BackingField;
				HardBounds hardBounds = tileset2._003ChardBounds_003Ek__BackingField;
				bool skipInverseCalculation = default(bool);
				SetHardBoundsMinMax(hardBounds._003Cx_003Ek__BackingField, hardBounds._003Cy_003Ek__BackingField, hardBounds._003Cwidth_003Ek__BackingField, num, skipInverseCalculation);
				Debug.Log("[GameManager] Set hard bounds dynamically from StageData");
			}
		}
		return;
		IL_0672:
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		Weapon weaponByType = activeCharacter._weaponsManager.GetWeaponByType(WeaponType.GATTI);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			nint num2 = (nint)typeof(GattiWeapon);
			bool flag = (byte)(int)weaponByType != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ r8_v14 (System.Boolean)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ r8_v14 (System.Boolean)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rax_v76+FFFFFFF8+v569 @ rax_v75*8]");
				if (0 == (nint)typeof(GattiWeapon))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v560 @ r8_v14 (System.Boolean)+5B8] (should have been resolved before IL gen)");
				}
			}
		}
		goto IL_0651;
		IL_0381:
		Stage stage5 = _stage;
		BackgroundManager fancyBg2 = stage5._fancyBg;
		float num7;
		if ((object)stage5._fancyBg != null)
		{
			nint num4 = (nint)typeof(BackgroundDevilRoom);
			nint num5 = (nint)fancyBg2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v881 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundDevilRoom>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v881 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ rax_v39+FFFFFFF8+v1144 @ rax_v34*8]");
				bool flag2 = 0 == (nint)typeof(BackgroundDevilRoom);
				num = num7;
				if (flag2)
				{
					goto IL_0517;
				}
			}
			Stage stage6 = _stage;
			nint num8 = (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT);
			BackgroundManager fancyBg3 = stage6._fancyBg;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+130]");
			object obj6 = 0;
			nint num9 = (nint)fancyBg3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_DEATHFIGHT>)+130]");
			if (num10 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v882 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ rax_v38+FFFFFFF8+v1159 @ rax_v37*8]");
				bool flag3 = 0 == (nint)typeof(Background_TP_ADV_001_Stage_DEATHFIGHT);
				num = num7;
				if (flag3)
				{
					goto IL_0517;
				}
			}
		}
		QueueOpenArcana(ArcanaUiType.MAIN);
		num = num7;
		goto IL_0517;
		IL_0651:
		Stage stage7 = _stage;
		BackgroundManager fancyBg4 = stage7._fancyBg;
		if ((object)stage7._fancyBg != null && ((UnityEngine.Object)fancyBg4).m_CachedPtr != (IntPtr)0)
		{
			Stage stage8 = _stage;
			stage8._fancyBg.OnInitCompleted();
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		if (config2._003CSelectedMazzo_003Ek__BackingField)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			List<ItemType> list2 = config3._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj8 = default(object);
				bool flag4 = (nint)obj8 != -1;
				num7 = num;
				if (flag4)
				{
					goto IL_0381;
				}
			}
			PlayerOptionsData config4 = _playerOptions.Config;
			List<ItemType> list3 = config4._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v37 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj9 = default(object);
				bool flag5 = (nint)obj9 == -1;
				num7 = num;
				if (!flag5)
				{
					goto IL_0381;
				}
			}
		}
		goto IL_0517;
	}

	private void InitCoopChestRandomness()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		List<int> coopChestRandomness = new List<int>();
		_coopChestRandomness = coopChestRandomness;
		CoopConfig coopConfig = CoopConfig;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < coopConfig._chestRandomnessSetSize)
		{
			int num = 0;
			while (true)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
				if (num >= mainCharacters._size)
				{
					break;
				}
				_coopChestRandomness.Add(num);
				num++;
			}
			coopConfig = CoopConfig;
			obj++;
			obj2 = obj;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 175 Invalid \"Jump target not found in method: 0x1877AD930\"");
		throw new NullReferenceException();
	}

	private IEnumerator SignalGameplayLoaded()
	{
		_003CSignalGameplayLoaded_003Ed__584 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void AddLocalCharacter(VampireSurvivors.Objects.Characters.CharacterController playerOne)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
		AddMainCharacter(playerOne);
	}

	private void RefreshCoopChestRandomisation()
	{
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CSequentialChestMode_003Ek__BackingField)
		{
			VampireSurvivors.App.Tools.Extensions.Shuffle(_coopChestRandomness);
		}
		_coopChestRandomnessIndex = 0;
	}

	private VampireSurvivors.Objects.Characters.CharacterController FindNextValidWinner(Predicate<VampireSurvivors.Objects.Characters.CharacterController> isValid, bool saveChances)
	{
		//IL_0036: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_0144: Expected O, but got I4
		//IL_014d: Expected O, but got I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00c6: Expected O, but got I4
		//IL_0198: Expected O, but got I
		//IL_01ad: Expected O, but got I
		//IL_0248: Expected O, but got I
		//IL_028d: Expected O, but got I4
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected I4, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		List<bool> cachedCharacterValidity = _cachedCharacterValidity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v2 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
		object obj = 0;
		bool flag = saveChances;
		object obj2 = 0;
		object obj3 = 0;
		bool flag2 = default(bool);
		while (true)
		{
			if ((nint)obj3 < mainCharacters._size)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = _mainCharacters;
				if ((nint)obj2 >= mainCharacters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters2._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [isValid @ rdx (System.Predicate`1<VampireSurvivors.Objects.Characters.CharacterController>)+18] (should have been resolved before IL gen)");
				if (flag2)
				{
					obj = 1;
				}
				_cachedCharacterValidity.Add(flag2);
				mainCharacters = _mainCharacters;
				obj2++;
				flag = false;
				obj3 = obj2;
				continue;
			}
			if (obj != null)
			{
				List<int> coopChestRandomness = _coopChestRandomness;
				int num = _coopChestRandomnessIndex;
				object obj4 = 0;
				object obj5 = 0;
				while (true)
				{
					object obj6 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v14 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)obj6 >= 0)
					{
						break;
					}
					List<int> coopChestRandomness2 = _coopChestRandomness;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)num2 >= (nint)0)
					{
						goto end_IL_0439;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdi_v10+20+v157 @ rsi_v9 (System.Int32)*4]");
					object obj8 = 0;
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters3 = _mainCharacters;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdi_v10+20+v157 @ rsi_v9 (System.Int32)*4]");
					if ((nint)0 >= (nint)mainCharacters3._size)
					{
						goto end_IL_0439;
					}
					VampireSurvivors.Objects.Characters.CharacterController[] items2 = mainCharacters3._items;
					List<bool> cachedCharacterValidity2 = _cachedCharacterValidity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdi_v10+20+v157 @ rsi_v9 (System.Int32)*4]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+18]");
					if (num3 >= 0)
					{
						goto end_IL_0439;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v14 (System.Collections.Generic.List`1<System.Boolean>)+10]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v11+20+v136 @ rcx_v15]");
					if ((nint)0 == 0)
					{
						List<int> coopChestRandomness3 = _coopChestRandomness;
						object obj10 = num + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v645 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32>)+18]");
						int num4 = obj10 % 0;
						if (num4 == 0 && !saveChances)
						{
							RefreshCoopChestRandomisation();
						}
						coopChestRandomness = _coopChestRandomness;
						obj4++;
						bool flag3 = _coopChestRandomness != null;
						obj5 = obj4;
						num = num4;
						if (!flag3)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					if (num != _coopChestRandomnessIndex)
					{
						if (!saveChances)
						{
							_coopChestRandomnessIndex = num;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805E9A20");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805E9A20");
						}
					}
					List<int> coopChestRandomness4 = _coopChestRandomness;
					int num5 = ++_coopChestRandomnessIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v9 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)num5 == 0)
					{
						RefreshCoopChestRandomisation();
					}
					return items2[obj8];
				}
			}
			return null;
			continue;
			end_IL_0439:
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		VampireSurvivors.Objects.Characters.CharacterController result = default(VampireSurvivors.Objects.Characters.CharacterController);
		return result;
	}

	private void SetupGattiCustomBgmRate()
	{
		//IL_0077: Expected I, but got O
		//IL_007f: Expected I, but got O
		//IL_008f: Expected O, but got I
		//IL_00cb: Expected O, but got I
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		Weapon weaponByType = activeCharacter._weaponsManager.GetWeaponByType(WeaponType.GATTI);
		if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		nint num = (nint)typeof(GattiWeapon);
		nint num2 = (nint)weaponByType;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v12+FFFFFFF8+v220 @ rax_v11*8]");
			if (0 == (nint)typeof(GattiWeapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v218 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+5B8] (should have been resolved before IL gen)");
			}
		}
	}

	private void Cleanup()
	{
		//IL_0180: Expected O, but got I
		CommonVfxManager commonVfxManager = _commonVfxManager;
		if (_commonVfxManager != null)
		{
			ParticleEmitterManager smallParticlesManager = commonVfxManager._smallParticlesManager;
			if ((object)commonVfxManager._smallParticlesManager != null && ((UnityEngine.Object)smallParticlesManager).m_CachedPtr != (IntPtr)0)
			{
				GameObject obj = commonVfxManager._smallParticlesManager.gameObject;
				UnityEngine.Object.Destroy(obj, 0f);
			}
		}
		_commonVfxManager = null;
		List<Pickup> stagePickups = _stagePickups;
		int version = stagePickups._version + 1;
		stagePickups._version = version;
		stagePickups._size = 0;
		if (stagePickups._size > 0)
		{
			Array.Clear(stagePickups._items, 0, stagePickups._size);
		}
		SfxVolumeFactor = 1f;
		SoundManager.Cleanup();
		List<UiTransition> queuedUiTransitions = _queuedUiTransitions;
		_003CSurvivedSeconds_003Ek__BackingField = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.UiTransition>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.UiTransition>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.UiTransition>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.UiTransition>)+18]");
			Array.Clear((Array)num, 0, 0);
		}
		DifficultyAdjustmentEnemyHPMultiplier = 1f;
		DifficultyAdjustmentEnemyDamageMultiplier = 1f;
	}

	public void FastForwardOneDay()
	{
		//IL_0009: Expected O, but got I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		object obj = 0;
		do
		{
			float num = _003CSurvivedSeconds_003Ek__BackingField + 60f;
			_003CSurvivedSeconds_003Ek__BackingField = num;
			_stage.CheckMinute();
			obj++;
		}
		while ((nint)obj < 1440);
	}

	private void OnTickerCallback()
	{
		//IL_0086: Invalid comparison between F4 and I4
		//IL_00cc: Invalid comparison between F4 and I4
		float num = _003CSurvivedSeconds_003Ek__BackingField + 1f;
		Stage stage = _stage;
		_003CSurvivedSeconds_003Ek__BackingField = num;
		if ((object)_stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Stage stage2 = _stage;
		if (!stage2._003CHasInitialized_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877AE30Ah\"");
		if (_003CSurvivedSeconds_003Ek__BackingField == 0f)
		{
			_stage.CheckMinute();
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877AE2FAh\"");
		if (_003CSurvivedSeconds_003Ek__BackingField == 0f)
		{
			_stage.CheckHalfMinute();
		}
	}

	private void ResetGameSessionCallback()
	{
		ResetGameSession();
	}

	private unsafe void ResetGameSession(bool disconnectFromCoherence = true)
	{
		//IL_00ea: Expected I4, but got O
		//IL_00ea: Expected O, but got I
		//IL_0223: Expected O, but got I4
		//IL_022c: Expected F4, but got I4
		//IL_0278: Expected F4, but got I4
		//IL_0280: Expected O, but got Ref
		//IL_032e: Expected I4, but got I8
		//IL_040e: Expected I4, but got I8
		//IL_04ee: Expected I4, but got I8
		//IL_05f3: Expected O, but got I
		//IL_05f3: Expected O, but got I
		//IL_0640: Expected O, but got I4
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Expected O, but got Unknown
		Debug.Log("<color=green>Resetting Game Session</color>");
		_isGameRunning = false;
		Timers.CancelAllRegisteredTimers();
		_canRunTickerTimer = false;
		Stage stage = _stage;
		if ((object)_stage != null)
		{
			_stage.Cleanup();
			stage = (Stage)(object)_stagePickups;
			if (_stagePickups != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rcx_v9 (VampireSurvivors.Objects.Stage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)stage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)stage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)stage).m_CachedPtr, 0, (int)((MonoBehaviour)stage).m_CancellationTokenSource);
				}
				ProCamera2D instance = ProCamera2D.Instance;
				bool flag = (object)instance == null;
				stage = null;
				if (!flag)
				{
					instance.RemoveAllCameraTargets();
					PickupManager.Cleanup();
					SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
					MasterAudio.StopMixer();
					if (_playerOptions != null)
					{
						_playerOptions.Save(commitImmediately: false);
						PauseSystem._paused = true;
						bool flag2 = (object)ArcadePhysics.s_instance == null;
						stage = (Stage)(object)typeof(ArcadePhysics);
						if (!flag2)
						{
							EventEmitter s_world = ArcadePhysics.s_world;
							if (ArcadePhysics.s_world != null)
							{
								_ = 1;
								ArcadePhysics.s_world.emit(WorldEvents.PauseEvent);
								bool flag3 = (object)ArcadePhysics.s_instance == null;
								stage = (Stage)(object)typeof(ArcadePhysics);
								if (!flag3 && ArcadePhysics.s_world != null)
								{
									ArcadePhysics.s_world.destroy();
									int num = DG.Tweening.Core.TweenManager.DespawnAll();
									if (_gameplayCheatCodeManager != null)
									{
										_gameplayCheatCodeManager.Dispose();
									}
									_003CIsHalloween_003Ek__BackingField = false;
									bool flag4 = _characters == null;
									List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
									float num2 = 0f;
									if (!flag4)
									{
										List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
										if (enumerator2.MoveNext())
										{
											Stage stage2 = null;
											stage = null;
											throw new NullReferenceException();
										}
										enumerator = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)_characters;
										num2 = 0f;
										stage = (Stage)(&enumerator2);
									}
									HashSet<Pickup> gems = _gems;
									if (_gems != null)
									{
										if (gems._lastIndex > 0)
										{
											Array.Clear(gems._slots, 0, gems._lastIndex);
											int[] buckets = gems._buckets;
											if (gems._buckets == null)
											{
												goto IL_06b1;
											}
											Array.Clear(gems._buckets, 0, buckets.Length);
											gems._count = 0;
											gems._freeList = -1;
										}
										int version = gems._version + 1;
										gems._version = version;
										ObjectPool gemPool = GemPool;
										if ((object)gemPool != null)
										{
											gemPool.ReleaseAll();
											HashSet<Coin> coins = _coins;
											if (_coins != null)
											{
												if (coins._lastIndex > 0)
												{
													Array.Clear(coins._slots, 0, coins._lastIndex);
													int[] buckets2 = coins._buckets;
													if (coins._buckets == null)
													{
														goto IL_06b1;
													}
													Array.Clear(coins._buckets, 0, buckets2.Length);
													coins._count = 0;
													coins._freeList = -1;
												}
												int version2 = coins._version + 1;
												coins._version = version2;
												ObjectPool coinPool = CoinPool;
												if ((object)coinPool != null)
												{
													coinPool.ReleaseAll();
													HashSet<Pickup_Bonus_FrozenSoul> frozenSouls = _frozenSouls;
													if (_frozenSouls != null)
													{
														if (frozenSouls._lastIndex > 0)
														{
															Array.Clear(frozenSouls._slots, 0, frozenSouls._lastIndex);
															int[] buckets3 = frozenSouls._buckets;
															if (frozenSouls._buckets == null)
															{
																goto IL_06b1;
															}
															Array.Clear(frozenSouls._buckets, 0, buckets3.Length);
															frozenSouls._count = 0;
															frozenSouls._freeList = -1;
														}
														int version3 = frozenSouls._version + 1;
														frozenSouls._version = version3;
														ObjectPool frozenSoulPool = FrozenSoulPool;
														if ((object)frozenSoulPool != null)
														{
															frozenSoulPool.ReleaseAll();
															if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
															{
																MasterObjectPooler._003CInstance_003Ek__BackingField.DestroyAllPoolsAndRuntimeInstances();
																CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
																if ((object)CoherenceBridgeStore.masterBridge != null)
																{
																	UnityEvent<CoherenceBridge, ConnectionException> onConnectionError = masterBridge.onConnectionError;
																	UnityAction<CoherenceBridge, ConnectionException> unityAction = OnConnectionError;
																	if (masterBridge.onConnectionError != null && unityAction != null)
																	{
																		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rsi_v5 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+10]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rsi_v5 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+10]");
																			nint num3 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1244 @ rax_v65 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+20]");
																			((UnityEngine.Events.InvokableCallList)num3).RemoveListener(0, methodImpl);
																			CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
																			if ((object)CoherenceBridgeStore.masterBridge != null)
																			{
																				object obj = default(object);
																				if (masterBridge2._003CClient_003Ek__BackingField != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																				}
																				else
																				{
																					obj = 0;
																				}
																				object obj2 = disconnectFromCoherence & obj;
																				if (obj2 == null)
																				{
																					goto IL_06a7;
																				}
																				CoherenceBridge masterBridge3 = CoherenceBridgeStore.masterBridge;
																				bool flag5 = (object)CoherenceBridgeStore.masterBridge == null;
																				stage = (Stage)(object)typeof(CoherenceBridgeStore);
																				if (!flag5)
																				{
																					stage = (Stage)(object)typeof(CoherenceBridgeStore);
																					if (masterBridge3._003CClient_003Ek__BackingField != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
																						goto IL_06a7;
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
		goto IL_06b1;
		IL_06b1:
		throw new NullReferenceException();
		IL_06a7:
		SpeedupManager.ClearSpeedupManager();
		Time.timeScale = 0f;
	}

	public void ReleaseGameplayLoader()
	{
		GameplayLoader gameplayLoader = _gameplayLoader;
		if (_gameplayLoader != null)
		{
			CharacterLoader.ClearCharacterTextures();
			AddressableCache.RemoveTexturesFromCacheAndSpriteManager("Gameplay");
			AddressableCache.ReleaseCustomOperationHandleGroup("Gameplay");
			TilesetFactory tilesetFactory = gameplayLoader._tilesetFactory;
			tilesetFactory._mapInstances.Clear();
		}
		_gameplayLoader = null;
	}

	private void FinishLevelUpActions(WeaponType weaponType, bool setInvincibility, VampireSurvivors.Objects.Characters.CharacterController receivingCharacter = null)
	{
		LevelWeaponUp(weaponType, removeFromStore: true, receivingCharacter);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F4B0");
		if (setInvincibility)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F560");
		}
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
	}

	private ArcadeSprite InitPlayerPhysics(GameObject characterInstance)
	{
		//IL_00a4: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController component = characterInstance.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
		GenerateMagnetZone(component);
		ArcadeSprite component2 = characterInstance.GetComponent<ArcadeSprite>();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Factory add = s_scene.add;
		PhaserGameObject phaserGameObject = add._world.enableBody(component2);
		BaseBody body = component2.body;
		float2 origin = default(float2);
		body._transform.setOrigin(origin);
		BaseBody baseBody = component2.body.setCircle(9f, (float?)(object)0, (float?)(object)0);
		BaseBody baseBody2 = component2.body.setOffset(6f, (float?)(object)1);
		BaseBody body2 = component2.body;
		body2._immovable = true;
		PhysicsManager physicsManager = _physicsManager;
		Group obj = physicsManager._playerGroup.add(component2);
		return component2;
	}

	private unsafe VampireSurvivors.Objects.Characters.CharacterController GeneratePlayerCharacter(CharacterType characterType, int playerIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_05e6: Expected O, but got Ref
		//IL_05f4: Expected I4, but got O
		//IL_0606: Expected O, but got Ref
		//IL_061a: Expected native int or pointer, but got O
		//IL_0632: Expected O, but got Ref
		//IL_0064: Expected O, but got Ref
		//IL_0072: Expected I4, but got O
		//IL_0084: Expected O, but got Ref
		//IL_00a6: Expected O, but got Ref
		//IL_00be: Expected native int or pointer, but got O
		//IL_00d3: Expected O, but got I
		//IL_00e1: Expected O, but got Ref
		//IL_00f1: Expected O, but got I
		//IL_06cd: Expected I, but got O
		//IL_0182: Expected O, but got Ref
		//IL_0196: Expected O, but got Ref
		//IL_0419: Expected I, but got O
		//IL_02e8: Expected O, but got I
		//IL_04d0: Expected O, but got I
		//IL_0748: Expected O, but got Ref
		//IL_0768: Expected O, but got I4
		//IL_0776: Expected O, but got I4
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
		//IL_078b: Expected O, but got Unknown
		//IL_07d0: Expected O, but got Ref
		//IL_020c->IL0677: Incompatible stack heights: 1 vs 0
		//IL_01c7->IL01f2: Incompatible stack heights: 0 vs 1
		//IL_0392->IL0677: Incompatible stack heights: 1 vs 0
		//IL_0319->IL0677: Incompatible stack heights: 1 vs 0
		//IL_0287->IL0677: Incompatible stack heights: 1 vs 0
		//IL_03be->IL0677: Incompatible stack heights: 1 vs 0
		//IL_02b1->IL0677: Incompatible stack heights: 1 vs 0
		//IL_03ea->IL0677: Incompatible stack heights: 1 vs 0
		//IL_0355->IL0677: Incompatible stack heights: 1 vs 0
		//IL_02ce->IL0677: Incompatible stack heights: 1 vs 0
		//IL_04f0->IL0677: Incompatible stack heights: 1 vs 0
		//IL_0464->IL0677: Incompatible stack heights: 1 vs 0
		//IL_0809->IL0677: Incompatible stack heights: 1 vs 0
		//IL_0486->IL0677: Incompatible stack heights: 1 vs 0
		//IL_054f->IL0677: Incompatible stack heights: 1 vs 0
		//IL_07ef->IL03c3: Incompatible stack heights: 4 vs 1
		//IL_05d8->IL080e: Incompatible stack heights: 1 vs 0
		//IL_0590->IL0677: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Component component;
		bool flag3;
		if ((object)_characterFactory != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterPrefab = _characterFactory.GetCharacterPrefab(characterType);
			if ((object)characterPrefab == null || ((UnityEngine.Object)characterPrefab).m_CachedPtr == (IntPtr)0)
			{
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				object arg = (CharacterType)obj3;
				System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
				System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
				_ = 0;
				string message = string.FormatHelper((IFormatProvider)null, "Character prefab is NULL for type {0}. Adam has likely not generated this character variant yet... Come on Adam...", args);
				Debug.LogError(message);
				return null;
			}
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			object arg2 = (CharacterType)obj4;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = 0;
			_ = 0;
			object arg3 = default(object);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg2, arg3));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
			object obj6 = 0;
			System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
			_ = 0;
			string message2 = string.FormatHelper((IFormatProvider)null, "Generating Player Character: {0} for player index: {1}", args2);
			Debug.Log(message2);
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rax_v40 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rbx_v14 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			_ = Quaternion.identityQuaternion;
			Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = Vector3.zeroVector;
			Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ rcx_v36 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			UnityEngine.Object obj8 = UnityEngine.Object.Instantiate((UnityEngine.Object)characterPrefab, position, rotation);
			if ((object)obj8 == null)
			{
				component = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Component component2 = default(Component);
				bool flag = (object)component2 == null;
				component = component2;
			}
			if (_multiplayer != null)
			{
				if (!_multiplayer.IsOnlineMultiplayer)
				{
					goto IL_02ed;
				}
				bool flag2 = playerIndex < 0;
				flag3 = playerIndex == 0;
				if (flag2)
				{
					goto IL_0702;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				OnlineStageManager onlineStageManager = default(OnlineStageManager);
				if ((object)onlineStageManager != null)
				{
					PlayerInfo myPlayerInfo = onlineStageManager.GetMyPlayerInfo();
					if ((object)component != null && (object)myPlayerInfo != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v15 (UnityEngine.Component)+A8]");
						myPlayerInfo.CharacterEntity = (CoherenceSync)0;
						goto IL_02ed;
					}
				}
			}
		}
		goto IL_0677;
		IL_03c3:
		GameObject characterInstance = component.gameObject;
		if (_diContainer != null)
		{
			_diContainer.InjectGameObject(characterInstance);
			ArcadeSprite child = InitPlayerPhysics(characterInstance);
			nint num4 = (nint)component;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1240 @ rdx_v33 (Il2CppClass<UnityEngine.Component>)+758] (should have been resolved before IL gen)");
			object obj9 = default(object);
			if (obj9 != null)
			{
				PhysicsManager physicsManager = _physicsManager;
				if (_physicsManager == null || physicsManager._playersWithWallCollisionGroup == null)
				{
					goto IL_0677;
				}
				Group obj10 = physicsManager._playersWithWallCollisionGroup.add(child);
			}
			bool dontGetCharacterDataForCurrentLevel = default(bool);
			((VampireSurvivors.Objects.Characters.CharacterController)component).InitCharacter(characterType, playerIndex, false, dontGetCharacterDataForCurrentLevel);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v15 (UnityEngine.Component)+110]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v15 (UnityEngine.Component)+110]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v58+154]");
				if ((nint)0 > (nint)0)
				{
					_ = 1084227584;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						if (config._003CSelectedGoldenEggs_003Ek__BackingField)
						{
							if (_eggManager == null)
							{
								goto IL_0677;
							}
							_eggManager.ApplyBonuses((VampireSurvivors.Objects.Characters.CharacterController)component);
						}
						ApplyPurchasedPowerUpData((VampireSurvivors.Objects.Characters.CharacterController)component);
						ApplyAscensionPoints((VampireSurvivors.Objects.Characters.CharacterController)component);
						((VampireSurvivors.Objects.Characters.CharacterController)component).ApplySkinModifiers();
						return (VampireSurvivors.Objects.Characters.CharacterController)component;
					}
				}
			}
		}
		goto IL_0677;
		IL_02ed:
		flag3 = playerIndex == 0;
		goto IL_0702;
		IL_0702:
		if (!flag3)
		{
			if ((object)component != null)
			{
				Transform transform = component.transform;
				Transform transform2 = component.transform;
				if ((object)transform2 != null)
				{
					_ = 0;
					_ = 0;
					bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj12);
					object obj13 = playerIndex * 0;
					object obj7 = playerIndex * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-31]");
					object obj14 = 0 + obj7;
					bool flag5 = (object)transform == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj15);
					object obj16 = default(object);
					object obj6 = obj16;
					goto IL_03c3;
				}
			}
		}
		else if (_gameSessionData != null)
		{
			_gameSessionData.ActiveCharacter = (VampireSurvivors.Objects.Characters.CharacterController)component;
			if ((object)component != null)
			{
				goto IL_03c3;
			}
		}
		goto IL_0677;
		IL_0677:
		throw new NullReferenceException();
	}

	public void RemoveWallCollisionFromCharacter(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		GameObject gameObject = character.gameObject;
		ArcadeSprite component = gameObject.GetComponent<ArcadeSprite>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			PhysicsManager physicsManager = _physicsManager;
			physicsManager._playersWithWallCollisionGroup.remove(component);
		}
	}

	private void ApplyStatModifiers(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
	{
		ApplyPurchasedPowerUpData(newCharacter);
		ApplyAscensionPoints(newCharacter);
		newCharacter.ApplySkinModifiers();
	}

	public VampireSurvivors.Objects.Characters.CharacterController AddFollower(CharacterType characterType, VampireSurvivors.Objects.Characters.CharacterController followedCharacter, AIType aiType, bool manualLevelups = false, int EveryXLevels = 1, bool spawnWithoutAuthority = false)
	{
		//IL_0113: Expected I4, but got I8
		//IL_00bb: Expected O, but got I
		//IL_033f: Expected O, but got I
		//IL_0407: Invalid comparison between I4 and F4
		//IL_01b9: Expected I4, but got I8
		//IL_01be->IL03f3: Incompatible stack heights: 4 vs 3
		//IL_03ee->IL03ee: Incompatible stack heights: 4 vs 0
		//IL_0237->IL024f: Incompatible stack heights: 4 vs 0
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)followedCharacter != null)
		{
			CoherenceSync coherenceSync = followedCharacter._coherenceSync;
			if ((object)followedCharacter._coherenceSync != null)
			{
				NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
				if (coherenceSync._003CEntityState_003Ek__BackingField != null)
				{
					ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
					if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
					{
						goto IL_024f;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v40 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					bool flag = false;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v40 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					if ((nint)0 != 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v40 (Coherence.Toolkit.ObservableAuthorityType)+10]");
						object obj = -3;
						bool flag2 = obj == null;
						flag = flag2;
					}
					object obj2 = default(object);
					if (!flag && (nint)obj2 == (flag ? 1 : 0))
					{
						characterController = null;
						goto IL_03ee;
					}
				}
				characterController = GeneratePlayerCharacter(characterType, -1);
				if ((object)characterController != null)
				{
					Transform transform = characterController.transform;
					Transform transform2 = followedCharacter.transform;
					if ((object)transform2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v25 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v25 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						bool flag4 = (object)transform == null;
						bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						bool flag6 = (nint)0 != 0;
						CharacterType characterType2 = (CharacterType)(nint)((UnityEngine.Object)transform).m_CachedPtr;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag7 = obj3 == null;
							characterType2 = (CharacterType)(-2016823656);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v789 @ rax_v36 (should have been resolved before IL gen)");
						if (0f > 1f)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
						}
						uint num = default(uint);
						characterController._003CFollowerLevelUpShuffleSeed_003Ek__BackingField = num;
						characterController.SetMovementAI(aiType, followedCharacter);
						characterController._pickupMode = PickupMode.GemsCoinsRoastsSouls;
						characterController._level = followedCharacter._level;
						characterController._xp = followedCharacter._xp;
						bool flag8 = _characters == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
						object obj4 = default(object);
						if (obj4 != null)
						{
							AddMainCharacter(characterController);
							CharacterADControl deficiencyControl = characterController._deficiencyControl;
							if (characterController._deficiencyControl == null)
							{
								goto IL_024f;
							}
							deficiencyControl._003CLevelupType_003Ek__BackingField = LevelupType.ManualSelection;
						}
						InitFollower(characterController);
						goto IL_03ee;
					}
				}
			}
		}
		goto IL_024f;
		IL_024f:
		throw new NullReferenceException();
		IL_03ee:
		return characterController;
	}

	private void InitFollower(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
	{
		//IL_007f: Expected O, but got I4
		CharacterADControl deficiencyControl = newCharacter._deficiencyControl;
		int num = (int)(newCharacter._003CFollowerLevelUpShuffleSeed_003Ek__BackingField << 13);
		int num2 = num ^ (int)newCharacter._003CFollowerLevelUpShuffleSeed_003Ek__BackingField;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num5 ^ num4;
		deficiencyControl._loadoutShuffler = (Unity.Mathematics.Random)num6;
		AddStartingWeapon(newCharacter);
		AddInitialPresetLoadout(newCharacter);
		newCharacter.AfterFullInitialization();
		Stage stage = _stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0)
		{
			Stage stage2 = _stage;
			stage2._fancyBg.OnFollowerAdded(newCharacter);
		}
	}

	private void AddMainCharacter(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
		InitCoopChestRandomness();
	}

	private void AddInitialPresetLoadout(VampireSurvivors.Objects.Characters.CharacterController newCharacter)
	{
		//IL_0231: Expected O, but got I
		//IL_013e: Expected O, but got I
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		CharacterData currentCharacterData = newCharacter._currentCharacterData;
		List<Loadout> list = currentCharacterData._003ClevelUpPresets_003Ek__BackingField;
		if (currentCharacterData._003ClevelUpPresets_003Ek__BackingField == null || list._size <= 0)
		{
			return;
		}
		if (list._size > 0)
		{
			Loadout[] items = list._items;
			WeaponsFacade weaponsFacade = (WeaponsFacade)(object)items[0];
			if ((object)weaponsFacade._weaponFactory == null)
			{
				return;
			}
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ stack_-28_v6+1C]");
					if (obj2 == null)
					{
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ stack_-28_v6+18]");
						if ((nint)obj3 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ stack_-28_v6+10]");
							object obj5 = 0;
							obj4++;
							WeaponsFacade weaponsFacade2 = _weaponsFacade;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rdx_v14+20+v639 @ rcx_v20*4]");
							Weapon weapon = weaponsFacade2.AddWeapon(WeaponType.VOID, newCharacter, removeFromStore: false);
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag = obj == null;
			WeaponsFacade weaponsFacade3 = (WeaponsFacade)0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ stack_-28_v6+1C]");
				if (obj2 == null)
				{
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				weaponsFacade3 = null;
			}
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void AddStartingWeapon(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0202: Expected O, but got I
		//IL_0354: Expected I, but got O
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		bool removeFromStore;
		if ((object)character != null)
		{
			bool flag = character._deficiencyControl == null;
			removeFromStore = true;
			if (!flag)
			{
				CharacterADControl deficiencyControl = character._deficiencyControl;
				bool flag2 = deficiencyControl._003CLevelupType_003Ek__BackingField == LevelupType.ManualSelection;
				removeFromStore = true;
				if (!flag2)
				{
					removeFromStore = false;
				}
			}
			if (_weaponsFacade != null)
			{
				Weapon weapon = _weaponsFacade.AddWeapon(character._startingWeaponType, character, removeFromStore);
				CharacterData currentCharacterData = character._currentCharacterData;
				if (character._currentCharacterData != null)
				{
					List<string> list = currentCharacterData._003CexWeapons_003Ek__BackingField;
					if (currentCharacterData._003CexWeapons_003Ek__BackingField != null && list._size > 0)
					{
						List<string>.Enumerator enumerator = default(List<string>.Enumerator);
						while (enumerator.MoveNext())
						{
							WeaponType weaponType = Enum.Parse<WeaponType>(null);
							bool flag3 = _weaponsFacade == null;
							string text = null;
							if (!flag3)
							{
								Weapon weapon2 = _weaponsFacade.AddWeapon(weaponType, character, removeFromStore);
								continue;
							}
							throw new NullReferenceException();
						}
					}
					List<WeaponType> weaponSelection = character._weaponSelection;
					if (character._weaponSelection != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v560 @ r9_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						if ((nint)0 > (nint)0)
						{
							object obj = default(object);
							object obj2 = default(object);
							object obj4 = default(object);
							while (true)
							{
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ stack_-90_v13+1C]");
									if (obj2 == null)
									{
										object obj3 = obj4;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ stack_-90_v13+18]");
										if ((nint)obj3 < 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ stack_-90_v13+10]");
											object obj5 = 0;
											obj4++;
											WeaponsFacade weaponsFacade = _weaponsFacade;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v28+20+v1286 @ rcx_v32*4]");
											Weapon weapon3 = weaponsFacade.AddWeapon(WeaponType.VOID, character, removeFromStore);
											continue;
										}
										break;
									}
									break;
								}
								throw new NullReferenceException();
							}
							bool flag4 = obj == null;
							nint num = 0;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ stack_-90_v13+1C]");
								if (obj2 == null)
								{
									goto IL_0416;
								}
								System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
								num = unchecked((nint)null);
							}
							throw new NullReferenceException();
						}
					}
					goto IL_0416;
				}
			}
		}
		goto IL_0329;
		IL_0416:
		CharacterData currentCharacterData2 = character._currentCharacterData;
		if (character._currentCharacterData != null)
		{
			List<string> list2 = currentCharacterData2._003ChiddenWeapons_003Ek__BackingField;
			if (currentCharacterData2._003ChiddenWeapons_003Ek__BackingField != null && list2._size > 0)
			{
				List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
				bool allowDuplicates = default(bool);
				while (enumerator2.MoveNext())
				{
					WeaponType weaponType2 = Enum.Parse<WeaponType>(null);
					bool flag5 = _weaponsFacade == null;
					string text2 = null;
					if (!flag5)
					{
						Weapon weapon4 = _weaponsFacade.AddHiddenWeapon(weaponType2, character, removeFromStore, allowDuplicates);
						continue;
					}
					throw new NullReferenceException();
				}
			}
			character.AddSkinWeapons();
			SetSeenWeapon(character._startingWeaponType);
			return;
		}
		goto IL_0329;
		IL_0329:
		throw new NullReferenceException();
	}

	private void GenerateMagnetZone(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		Transform parentTransform = character.transform;
		GameObject gameObject = _diContainer.InstantiatePrefab(_MagnetZonePrefab, parentTransform);
		MagnetZone component = gameObject.GetComponent<MagnetZone>();
		component.Init(character);
		character._magnet = component;
		Transform transform = component.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		PhysicsManager physicsManager = _physicsManager;
		Group obj = physicsManager._magnetGroup.add(component);
	}

	public void FirePlayerXpUpdatedFromOnline()
	{
		_003CFirePlayerXpUpdatedFromOnlineRoutine_003Ed__608 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator FirePlayerXpUpdatedFromOnlineRoutine()
	{
		_003CFirePlayerXpUpdatedFromOnlineRoutine_003Ed__608 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void FirePlayerXpUpdated()
	{
		if (_multiplayer.IsOnlineMultiplayer)
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			PlayerInfo playerInfo = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
			VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
		}
		LevelUpFactory levelUpFactory = _levelUpFactory;
		float num = levelUpFactory._currentXpFactor - levelUpFactory._previousXpFactor;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAEAB0");
	}

	private void AddWeaponToPlayer(GameplaySignals.AddWeaponToCharacterSignal signal)
	{
		//IL_006c: Expected O, but got I
		//IL_0081: Expected O, but got I
		LevelWeaponUp(signal.Weapon, removeFromStore: true, signal.Character);
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)signal.Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v10 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v10 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v9+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v7+60]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v10 (System.Object)+18]");
				if ((nint)0 > (nint)1)
				{
					_levelUpFactory.RemoveFromExcluded(signal.Weapon);
				}
			}
			_levelUpFactory.RemoveFromSpecialWeapons(signal.Weapon);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void AddAccessoryToPlayer(GameplaySignals.AddAccessoryToCharacterSignal signal)
	{
		_accessoriesFacade.AddAccessory(signal.Accessory, signal.Character);
		_levelUpFactory.RemoveFromSpecialWeapons(signal.Accessory);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 45 Invalid \"Jump target not found in method: 0x1877B0F00\"");
		throw new NullReferenceException();
	}

	public void SetSeenWeapon(WeaponType weaponType)
	{
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj = default(object);
		if (obj == null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
		}
		PlayerOptionsData config3 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
		}
	}

	public Weapon AddWeapon(WeaponType weapon, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		if (_weaponsFacade != null)
		{
			Weapon result = _weaponsFacade.AddWeapon(weapon, character);
			SetSeenWeapon(weapon);
			return result;
		}
		return (Weapon)(object)new NullReferenceException();
	}

	private void RemoveWeaponFromPlayer(GameplaySignals.RemoveWeaponFromCharacterSignal signal)
	{
		//IL_0216: Expected O, but got I4
		//IL_0229: Expected O, but got I4
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected I4, but got Unknown
		//IL_0451: Expected O, but got I4
		//IL_046b: Expected O, but got I4
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController character = signal.Character;
		Equipment equipment = _weaponsFacade.RemoveEquipment(signal.Weapon, signal.Character);
		if (((object)equipment != null && ((UnityEngine.Object)equipment).m_CachedPtr != (IntPtr)0) || !signal.RemoveFromAnotherCharacterIfNotFound)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
		VampireSurvivors.Objects.Characters.CharacterController character2 = signal.Character;
		WeaponsFacade weaponsFacade = null;
		WeaponsFacade weaponsFacade2 = null;
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = default(VampireSurvivors.Objects.Characters.CharacterController);
		while (true)
		{
			bool flag = (nint)weaponsFacade2 >= mainCharacters._size;
			WeaponsFacade weaponsFacade3 = null;
			if (!flag)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
				if ((nint)weaponsFacade >= characters._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[(object)weaponsFacade];
				bool flag2 = (object)signal.Character == null;
				bool flag3 = (object)items[(object)weaponsFacade] == null;
				object obj = flag3 & flag2;
				bool flag4 = obj == null;
				object obj2 = !flag4;
				if (obj2 == null)
				{
					bool flag5;
					if ((object)signal.Character != null)
					{
						if ((object)items[(object)weaponsFacade] != null)
						{
							object obj3 = (object)items[(object)weaponsFacade] - (object)signal.Character;
							flag5 = obj3 == null;
						}
						else
						{
							flag5 = ((UnityEngine.Object)character2).m_CachedPtr == (IntPtr)0;
						}
					}
					else
					{
						flag5 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
					}
					if (!flag5)
					{
						mainCharacters = _mainCharacters;
						weaponsFacade = (WeaponsFacade)(weaponsFacade + 1);
						weaponsFacade2 = weaponsFacade;
						continue;
					}
				}
				weaponsFacade3 = weaponsFacade;
			}
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = _mainCharacters;
			object obj4 = 1;
			bool flag6 = true;
			object obj5 = 1;
			while (true)
			{
				if ((nint)obj5 >= mainCharacters2._size)
				{
					return;
				}
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
				object obj6 = obj4 + (object)weaponsFacade3;
				int num = obj6 % characters2._size;
				if (num >= characters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items2 = characters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = items2[num];
				if (characterController2._PlayerIndex < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v37+39F]");
					if ((nint)0 == 0)
					{
						goto IL_037c;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Equipment equipment2 = _weaponsFacade.RemoveEquipment(signal.Weapon, characterController3);
				bool flag7 = (object)equipment2 == null;
				flag6 = true;
				character = characterController3;
				if (!flag7)
				{
					bool flag8 = ((UnityEngine.Object)equipment2).m_CachedPtr != (IntPtr)0;
					flag6 = true;
					character = characterController3;
					if (flag8)
					{
						return;
					}
				}
				goto IL_037c;
				IL_037c:
				mainCharacters2 = _mainCharacters;
				obj4++;
				bool flag9 = _mainCharacters != null;
				obj5 = obj4;
				if (!flag9)
				{
					throw new NullReferenceException();
				}
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public Weapon AddHiddenWeapon(WeaponType weapon, VampireSurvivors.Objects.Characters.CharacterController character, bool allowDuplicates = false)
	{
		bool allowDuplicates2 = default(bool);
		if (_weaponsFacade != null)
		{
			return _weaponsFacade.AddHiddenWeapon(weapon, character, removeFromStore: true, allowDuplicates2);
		}
		return (Weapon)(object)new NullReferenceException();
	}

	private void AddHiddenWeaponToPlayer(GameplaySignals.AddHiddenWeaponToCharacterSignal signal)
	{
		bool allowDuplicates = default(bool);
		Weapon weapon = _weaponsFacade.AddHiddenWeapon(signal.Weapon, signal.Character, removeFromStore: true, allowDuplicates);
	}

	private void RemoveHiddenWeaponFromPlayer(GameplaySignals.RemoveHiddenWeaponFromCharacterSignal signal)
	{
		_weaponsFacade.RemoveHiddenWeapon(signal.Weapon, signal.Character);
	}

	public void SetPlayersVisible(bool visible)
	{
		//IL_00fa: Expected O, but got I4
		//IL_0103: Expected O, but got I4
		//IL_00b8: Expected O, but got I
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < characters._size)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
				if ((nint)obj >= characters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
				ArcadeSprite arcadeSprite = items[obj];
				ArcadeSprite arcadeSprite2 = items[obj].setVisible(visible);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdi_v6 (ArcadeSprite)+E0]");
				SpriteTrail spriteTrail = ((SpriteTrail)0).setVisible(visible);
				characters = _characters;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe void SetPlayersInvulForMillisecondsAndRestoreTints(float milliseconds)
	{
		//IL_013c: Expected I, but got O
		//IL_0152: Expected O, but got I
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_01c9: Expected I, but got O
		//IL_0207: Expected O, but got I4
		//IL_021e: Expected I, but got I8
		//IL_01b2: Expected I, but got I8
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		bool flag = false;
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			if ((flag2 ? 1 : 0) >= characters._size)
			{
				return;
			}
			_003C_003Ec__DisplayClass619_0 obj = new _003C_003Ec__DisplayClass619_0();
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
			if ((flag ? 1 : 0) >= characters2._size)
			{
				break;
			}
			VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
			obj.character = items[flag ? 1u : 0u];
			VampireSurvivors.Objects.Characters.CharacterController character = obj.character;
			obj.character.IsInvul = true;
			float num = milliseconds * 0.001f;
			float invincibilityTimer = num + character._invincibilityTimer;
			character._invincibilityTimer = invincibilityTimer;
			obj.character.RestoreTint();
			Action action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass619_0._003CSetPlayersInvulForMillisecondsAndRestoreTints_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num3;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_01fe;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num3 = ((Delegate)action).method_ptr;
			goto IL_01fe;
			IL_01fe:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			Timer timer = Timers.Register(0.1f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			characters = _characters;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag2 = flag;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SetPlayersInvulForMilliSecondsNonCumulative(float milliseconds)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < characters._size)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
				if ((nint)obj >= characters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
				items[obj].IsInvul = true;
				float num = milliseconds * 0.001f;
				if (num > characterController._invincibilityTimer)
				{
					characterController._invincibilityTimer = num;
				}
				characters = _characters;
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void SetPlayerInvincibility(GameplaySignals.SetCharacterInvincibilityForMillisSignal signal)
	{
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount > 1 || _multiplayer.IsOnlineMultiplayer)
		{
			StopTimeForMilliseconds(1000f);
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			throw new NullReferenceException();
		}
	}

	private void SetPlayerInvincibilityNonCumulative(GameplaySignals.SetCharacterInvincibilityForMillisNonCumulativeSignal signal)
	{
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount > 1 || _multiplayer.IsOnlineMultiplayer)
		{
			StopTimeForMilliseconds(1000f);
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			throw new NullReferenceException();
		}
	}

	private void LetPlayersGetTheirBearings()
	{
		int playerCount = _multiplayer.GetPlayerCount();
		if (playerCount > 1 || _multiplayer.IsOnlineMultiplayer)
		{
			StopTimeForMilliseconds(1000f);
		}
	}

	private void OnReviveCharacter(GameplaySignals.ReviveCharacterSignal signal)
	{
		//IL_0033: Expected O, but got I4
		//IL_0177: Expected I, but got O
		//IL_00a0: Expected O, but got I
		//IL_00cd: Expected I, but got O
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
		bool flag = _mainCharacters == null;
		GameManager gameManager = this;
		if (!flag)
		{
			if (mainCharacters._size > 1)
			{
				object obj = 0;
				gameManager = this;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				while (true)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = _mainCharacters;
					if (_mainCharacters == null)
					{
						break;
					}
					if ((nint)obj < mainCharacters2._size)
					{
						gameManager = (GameManager)(object)mainCharacters2._items;
						if (mainCharacters2._items == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v5 (VampireSurvivors.Framework.GameManager)+20+v87 @ rdi_v7*8]");
						gameManager = (GameManager)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v5 (VampireSurvivors.Framework.GameManager)+20+v87 @ rdi_v7*8]");
						if ((nint)0 == 0)
						{
							break;
						}
						nint num = (nint)gameManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v379 @ r9_v8 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+468] (should have been resolved before IL gen)");
						obj++;
						if ((nint)obj >= mainCharacters._size)
						{
							if (_mainCharacters == null)
							{
								break;
							}
							while (enumerator.MoveNext())
							{
								RunAllPostRevivialActions(null, instantRevival: true);
							}
							return;
						}
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
			}
			else
			{
				GameSessionData gameSessionData = _gameSessionData;
				bool flag2 = _gameSessionData == null;
				gameManager = this;
				if (!flag2)
				{
					gameManager = (GameManager)(object)gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						nint num2 = (nint)gameManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v231 @ rax_v12 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+468] (should have been resolved before IL gen)");
						GameSessionData gameSessionData2 = _gameSessionData;
						if (_gameSessionData != null)
						{
							RunAllPostRevivialActions(gameSessionData2._activeCharacter, instantRevival: true);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void RunAllPostRevivialActions(VampireSurvivors.Objects.Characters.CharacterController revived, bool instantRevival = false)
	{
		//IL_0013: Expected O, but got I4
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private void ApplyAscensionPoints(VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_003f: Expected O, but got I4
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_0056: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_0077: Expected O, but got I4
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00e3: Expected I4, but got O
		PlayerOptionsData config = _playerOptions.Config;
		Dictionary<PowerUpType, int>.Enumerator enumerator = default(Dictionary<PowerUpType, int>.Enumerator);
		object obj8 = default(object);
		object message = default(object);
		while (enumerator.MoveNext())
		{
			bool flag = 0 >= 1;
			object obj = 25;
			if (!flag)
			{
				obj = 0;
			}
			object obj2 = obj + 25;
			if (0 < 2)
			{
				obj2 = obj;
			}
			if (0 >= 3)
			{
				object obj3 = -2;
				object obj4 = obj3 * 25;
				obj2 += obj4;
			}
			float num = (float)obj2 * 0.01f;
			object obj5 = -11;
			obj5--;
			object obj6 = obj5 - 1;
			if ((nint)obj6 != 1)
			{
				object obj7 = (PowerUpType)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
				Debug.Log(message);
			}
			else
			{
				PlayerModifierStats playerStats = characterController._playerStats;
				EggFloat curse = playerStats._003CCurse_003Ek__BackingField + num;
				playerStats.Curse = curse;
			}
		}
	}

	private unsafe void ApplyPurchasedPowerUpData(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0041: Expected O, but got Ref
		//IL_0057: Expected O, but got Ref
		Dictionary<PowerUpType, PlayerStat> ownedPowerUps = _playerStats.GetOwnedPowerUps();
		Dictionary<PowerUpType, PlayerStat>.Enumerator enumerator = default(Dictionary<PowerUpType, PlayerStat>.Enumerator);
		nint num2 = default(nint);
		object obj = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			PlayerOptions playerOptions = _playerOptions;
			bool flag = _playerOptions == null;
			Dictionary<PowerUpType, PlayerStat>.Enumerator enumerator2 = (Dictionary<PowerUpType, PlayerStat>.Enumerator)(&enumerator);
			PlayerOptionsData playerOptionsData;
			if (!flag)
			{
				enumerator2 = (Dictionary<PowerUpType, PlayerStat>.Enumerator)(&enumerator);
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_01ea;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_01ea;
			}
			throw new NullReferenceException();
			IL_01ea:
			if (playerOptionsData == null)
			{
				break;
			}
			Dictionary<PowerUpType, PlayerStat>.Enumerator enumerator3 = (Dictionary<PowerUpType, PlayerStat>.Enumerator)playerOptionsData._003CDisabledPowerups_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v10 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.PowerUpType, VampireSurvivors.PlayerStat>+Enumerator<VampireSurvivors.Data.PowerUpType, VampireSurvivors.PlayerStat>)+18]");
			bool flag2 = (nint)0 == 0;
			nint num = num2;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				bool flag3 = (nint)obj != -1;
				num = 0;
				num2 = 0;
				if (flag3)
				{
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
			ApplyPlayerStat(null, character);
			num2 = num;
		}
		throw new NullReferenceException();
	}

	private void ApplyPlayerStat(PlayerStat playerStat, VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		//IL_0050: Expected O, but got I4
		//IL_008c: Expected I, but got O
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		DataManager dataManager = _dataManager;
		bool flag = dataManager._003CAllPowerUps_003Ek__BackingField == null;
		int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllPowerUps_003Ek__BackingField).FindEntry((System.Int32Enum)playerStat._Type);
		if (flag)
		{
			return;
		}
		object obj = 0;
		JToken jToken = default(JToken);
		float health = default(float);
		while ((nint)obj < playerStat._Level)
		{
			DataManager dataManager2 = _dataManager;
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllPowerUps_003Ek__BackingField).get_Item((System.Int32Enum)playerStat._Type);
			nint num2 = (nint)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v282 @ r8_v11 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
			object obj3 = jToken.ToObject<object>();
			if (obj3 != null)
			{
				characterController.PlayerStatsUpgrade((ModifierStats)obj3, multiplicativeMaxHp: true);
				float num3 = characterController.MaxHp();
				characterController.SetHealth(health);
			}
			obj++;
		}
	}

	private unsafe void OnLevelUpSkipped(GameplaySignals.SkipLevelUpSignal signal)
	{
		//IL_0015: Expected O, but got I
		//IL_002a: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_03ae: Expected O, but got F4
		//IL_03be: Expected O, but got I
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00b3: Invalid comparison between O and F4
		//IL_012a: Expected O, but got I
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_02b2: Expected O, but got Ref
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_02fc: Invalid comparison between I4 and F4
		//IL_0382: Invalid comparison between F4 and I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+SkipLevelUpSignal)+218]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v4+78]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5+14]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5+10]");
		object obj3 = num + 0;
		object obj4 = obj3 & -2147483649L;
		if ((nint)obj4 != 2139095040)
		{
			object obj5 = obj3 & -2147483649L;
			if ((nint)obj5 <= 2139095040)
			{
				bool flag = obj3 == (object)(-1f / 0f);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877B2C28h\"");
				if (flag || 0 >= (nint)obj3)
				{
					return;
				}
			}
		}
		object obj6 = UnityEngine.Random.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+SkipLevelUpSignal)+218]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v13+C8]");
		if ((nint)obj3 < 0)
		{
			goto IL_01eb;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v13+78]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v18+10]");
		float num2 = 0f - 1f;
		object obj9 = num2 & -2147483649L;
		if ((nint)obj9 != 2139095040)
		{
			object obj10 = num2 & -2147483649L;
			if ((nint)obj10 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877B2CC8h\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_03c3;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_03c3;
		IL_01eb:
		if (!_multiplayer.IsOnlineMultiplayer)
		{
			GameplaySignals.SkipLevelUpSignal skipLevelUpSignal = signal;
		}
		else
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			PlayerInfo playerInfo = OnlineStageManager._instance.ReturnPlayerInfoForSeat(instance._firstSeat);
			VampireSurvivors.Objects.Characters.CharacterController characterController = playerInfo.CharacterController;
			GameplaySignals.SkipLevelUpSignal skipLevelUpSignal = (GameplaySignals.SkipLevelUpSignal)characterController;
		}
		LevelUpFactory levelUpFactory = _levelUpFactory;
		float num3 = levelUpFactory._currentXpFactor;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v16 (VampireSurvivors.Signals.GameplaySignals+SkipLevelUpSignal)+23C]");
		float num4 = num3 - 0f;
		float num5 = num4 * 0.2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj11 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Granting {0} XP for level up skip", (System.ParamsArray)(&obj11));
		Debug.Log(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj12 = default(object);
		if (obj12 != null || 0f > num5)
		{
			Debug.Log("Batching Level Up Skip");
			int batchedOnlineLevelUpSkips = _batchedOnlineLevelUpSkips + 1;
			_batchedOnlineLevelUpSkips = batchedOnlineLevelUpSkips;
		}
		AddPlayerXp(num5);
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		((VampireSurvivors.Objects.Characters.CharacterController)signal).IsInvul = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+SkipLevelUpSignal)+15C]");
		if (0.5f > 0f)
		{
			_ = 1056964608;
		}
		CycleActivePlayer();
		VampireSurvivors.Objects.Characters.CharacterController player = signal.Player;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v681 @ rax_v29 (VampireSurvivors.Objects.Characters.CharacterController)+458] (should have been resolved before IL gen)");
		return;
		IL_03c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B8FFE0");
		goto IL_01eb;
	}

	private float GetLevelUpSkipXpToGrant(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		LevelUpFactory levelUpFactory = _levelUpFactory;
		float num = levelUpFactory._currentXpFactor - player._xp;
		return num * 0.2f;
	}

	private void OnLevelUpCompleted()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				PostManipulateLevelUpOptionsForSpecialWeapons();
			}
			if (_characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					MultiplayerManager multiplayerManager = null;
					MultiplayerManager multiplayerManager2 = null;
					throw new NullReferenceException();
				}
				CycleActivePlayer();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void CycleActivePlayer()
	{
		//IL_00b9: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected I4, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		if (_mainCharacters == null)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
		if (mainCharacters._size <= 1 || !IsStageHost)
		{
			return;
		}
		GameSessionData gameSessionData = _gameSessionData;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = _mainCharacters;
		int num = Array.IndexOf((object[])mainCharacters2._items, (object)gameSessionData._activeCharacter, 0, mainCharacters2._size);
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters3 = _mainCharacters;
		int num2 = num;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= mainCharacters3._size)
			{
				return;
			}
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters4 = _mainCharacters;
			object obj3 = num2 + 1;
			int num3 = obj3 % mainCharacters4._size;
			if (num3 >= mainCharacters4._size)
			{
				break;
			}
			VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters4._items;
			_gameSessionData.ActiveCharacter = items[num3];
			GameSessionData gameSessionData2 = _gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData2._activeCharacter;
			if (!activeCharacter._isDead && !activeCharacter.IsDisconnectedFromOnlinePlay)
			{
				GameSessionData gameSessionData3 = _gameSessionData;
				if (!gameSessionData3._activeCharacter.IsDisconnectedFromOnlinePlay)
				{
					return;
				}
			}
			mainCharacters3 = _mainCharacters;
			obj++;
			num2 = num3;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void UpdateTouchControls(bool isOn)
	{
		//IL_0030: Expected F4, but got I4
		float alpha = ((!isOn) ? 0f : 1f);
		_touchJoystickCanvasGroup.alpha = alpha;
	}

	private void OnJoystickOptionsChanged(UISignals.SetVisibleJoysticksSignal signal)
	{
		//IL_0034: Expected F4, but got I4
		float alpha = (((object)signal == null) ? 0f : 1f);
		_touchJoystickCanvasGroup.alpha = alpha;
	}

	private void SetupMusicNormal()
	{
		if (!SetupCharacterMusic())
		{
			Stage stage = _stage;
			StageData stageData = stage._stageData;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2CC0");
			SoundManager.SoundConfig config = BuildSoundConfigWithModifiers();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.PlayMusic(bgmType, config);
		}
	}

	private bool SetupCharacterMusic()
	{
		//IL_02a4: Expected I4, but got O
		//IL_01e2: Expected O, but got I
		//IL_0242: Expected O, but got I
		//IL_0256: Expected O, but got I4
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			goto IL_0290;
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				DataManager dataManager = _dataManager;
				if (_dataManager != null && dataManager._003CAllCharacters_003Ek__BackingField != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).FindEntry((System.Int32Enum)config._selectedChar);
					if (num < 0)
					{
						goto IL_0290;
					}
					if (_dataManager != null)
					{
						Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
						if (convertedCharacterData != null)
						{
							object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)config._selectedChar);
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v13 (System.Object)+18]");
								if ((nint)0 > (nint)0)
								{
									List<CharacterData> list = ((Dictionary<CharacterType, List<CharacterData>>)obj).get_Item(config._selectedChar);
									if (list == null)
									{
										goto IL_0296;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+100]");
									string text = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+100]");
									if ((nint)0 != 0 && text._stringLength > 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>)+100]");
										BgmType bgmType = Enum.Parse<BgmType>((string)0);
										List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)bgmType).get_Item(CharacterType.VOID);
										SoundManager.SoundConfig config2 = BuildSoundConfigWithModifiers();
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
										BgmType bgmType2 = default(BgmType);
										SoundManager.PlayMusic(bgmType2, config2);
										return true;
									}
								}
							}
							goto IL_0290;
						}
					}
				}
			}
		}
		goto IL_0296;
		IL_0296:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0290:
		return false;
	}

	private unsafe bool GetMusicData(BgmType bgmType, out MusicData musicData)
	{
		//IL_011b: Expected I4, but got O
		ref MusicData reference = ref *(MusicData*)null;
		DataManager dataManager = _dataManager;
		if (_dataManager != null && dataManager._003CAllMusicData_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)bgmType);
			if (num < 0)
			{
				return false;
			}
			DataManager dataManager2 = _dataManager;
			if (_dataManager != null && dataManager2._003CAllMusicData_003Ek__BackingField != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)bgmType);
				reference = ref *(MusicData*)obj;
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void DisableBuiltInLighting()
	{
		Light2D globalLight = _GlobalLight;
		if ((object)_GlobalLight != null && ((UnityEngine.Object)globalLight).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _GlobalLight.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		}
		_GlobalLight = null;
	}

	public bool HasSpecialStageLighting()
	{
		Light2D globalLight = _GlobalLight;
		if ((object)_GlobalLight != null)
		{
			return ((UnityEngine.Object)globalLight).m_CachedPtr == (IntPtr)0;
		}
		return true;
	}

	public Light2D GetGlobalLight()
	{
		return _GlobalLight;
	}

	public void SetSpecialStageLightingEnabled(bool enabled)
	{
		//IL_001c: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bc->IL002a: Incompatible stack heights: 1 vs 0
		ShadowCasterGroup2D[] array = UnityEngine.Object.FindObjectsByType<ShadowCasterGroup2D>(FindObjectsSortMode.None);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			ShadowCasterGroup2D shadowCasterGroup2D = array[obj];
			bool flag = ((UnityEngine.Object)shadowCasterGroup2D).m_CachedPtr == (IntPtr)0;
			Behaviour.set_enabled_Injected(((UnityEngine.Object)shadowCasterGroup2D).m_CachedPtr, enabled);
			obj++;
			obj2 = obj;
		}
	}

	private IEnumerator ReenableBrokenShadowCasterGroup2DsBecauseUnity()
	{
		_003CReenableBrokenShadowCasterGroup2DsBecauseUnity_003Ed__642 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void SetupLighting()
	{
		//IL_00ad: Expected O, but got F4
		//IL_0220: Expected O, but got I
		//IL_0247: Expected O, but got I
		Light2D globalLight = _GlobalLight;
		if ((object)_GlobalLight != null && ((UnityEngine.Object)globalLight).m_CachedPtr != (IntPtr)0)
		{
			Stage stage = _stage;
			StageData stageData = stage._stageData;
			bool flag = !stageData._003ChasLights_003Ek__BackingField;
			GameManager gameManager = this;
			if (!flag)
			{
				Light2D backgroundLight = _BackgroundLight;
				backgroundLight.m_Color = (Color)ColourHelper.HexToColor("0x302020").r;
				GameManager core = GM.Core;
				Stage stage2 = core._stage;
				StageData baseStageData = stage2._baseStageData;
				if (baseStageData._003ChasCharacterSpotlight_003Ek__BackingField)
				{
					_Spotlight2D.enabled = false;
				}
				else
				{
					_Spotlight2D.enabled = true;
					Light2D spotlight2D = _Spotlight2D;
					spotlight2D.m_Intensity = 0.65f;
					Light2D spotlight2D2 = _Spotlight2D;
					spotlight2D2.m_PointLightOuterRadius = 2.8f;
				}
				GameObject gameObject = new GameObject("CandleLightsRoot");
				Transform candleLightsParent = gameObject.transform;
				_candleLightsParent = candleLightsParent;
				Queue<Light2D> candleLights = new Queue<Light2D>();
				_candleLights = candleLights;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 445 Invalid \"Jump target not found in method: 0x1877B40E0\"");
				GameManager gameManager2 = default(GameManager);
				gameManager = gameManager2;
			}
			gameManager._Spotlight2D.enabled = false;
			gameManager._GlobalLight.enabled = true;
			gameManager._BackgroundLight.enabled = true;
			Light2D globalLight2 = gameManager._GlobalLight;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			globalLight2.m_Color = (Color)0;
			Light2D backgroundLight2 = gameManager._BackgroundLight;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			backgroundLight2.m_Color = (Color)0;
		}
		else
		{
			_003CReenableBrokenShadowCasterGroup2DsBecauseUnity_003Ed__642 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	private void AddLightsToPool(int count)
	{
		//IL_0037: Expected O, but got I4
		//IL_0720: Expected O, but got I8
		//IL_0094: Expected O, but got F4
		//IL_0537: Expected I4, but got I8
		//IL_00cb: Expected O, but got I
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_014d: Expected O, but got I
		//IL_0620: Expected O, but got I4
		//IL_016d: Expected O, but got I
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_01ef: Expected O, but got I
		//IL_012b: Expected O, but got I8
		//IL_065d: Expected O, but got I4
		//IL_01cd: Expected O, but got I8
		//IL_02ec: Expected O, but got I
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_036e: Expected O, but got I
		//IL_067a: Expected O, but got I4
		//IL_038e: Expected O, but got I
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_0410: Expected O, but got I
		//IL_034c: Expected O, but got I8
		//IL_06b7: Expected O, but got I4
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected O, but got Unknown
		//IL_03ee: Expected O, but got I8
		Sequence sequence = DOTween.Sequence();
		if (count > 0)
		{
			object obj = 0;
			do
			{
				_003C_003Ec__DisplayClass644_0 obj2 = new _003C_003Ec__DisplayClass644_0();
				Light2D l2d = AddLight((Vector2)3313106944L, 0.79999995f, 0.9f);
				obj2.l2d = l2d;
				((Queue<object>)(object)_candleLights).Enqueue((object)obj2.l2d);
				Light2D l2d2 = obj2.l2d;
				l2d2.m_Color = (Color)ColourHelper.HexToColor("0xdd8800").r;
				object l2d3 = obj2.l2d;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rbx_v7 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(l2d3);
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rbx_v7 (System.Object)+10]");
				Behaviour.set_enabled_Injected((IntPtr)0, false);
				DOGetter<float> getter = null;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ r9_v5 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ r9_v5 (Il2CppMethodInfo)+4C]");
				object obj3 = (nint)0 >> 4;
				object obj4 = obj3 & 1;
				object obj5;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ r9_v5 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						obj5 = 6447965120L;
						goto IL_0617;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v29 (DG.Tweening.Core.DOGetter`1<System.Single>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v29 (DG.Tweening.Core.DOGetter`1<System.Single>)+10]");
				obj5 = 0;
				goto IL_0617;
				IL_0617:
				object obj6 = 24;
				_ = 6447969936L;
				DOSetter<float> setter = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ r9_v6 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ r9_v6 (Il2CppMethodInfo)+4C]");
				object obj7 = (nint)0 >> 4;
				object obj8 = obj7 & 1;
				object obj9;
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ r9_v6 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 1)
					{
						obj9 = 6447299152L;
						goto IL_0654;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rax_v36 (DG.Tweening.Core.DOSetter`1<System.Single>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ rax_v36 (DG.Tweening.Core.DOSetter`1<System.Single>)+10]");
				obj9 = 0;
				goto IL_0654;
				IL_06ae:
				object obj10 = 24;
				_ = 6449796912L;
				DOGetter<float> getter2;
				DOSetter<float> setter2;
				TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter2, setter2, 1.1f, 0.5f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1284 @ rax_v62 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
				{
					Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
				}
				obj++;
				continue;
				IL_0654:
				object obj11 = 24;
				_ = 6449796912L;
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, setter, 0.9f, 0.5f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v932 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false))
				{
					Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, 0f);
				}
				getter2 = null;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ r9_v9 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ r9_v9 (Il2CppMethodInfo)+4C]");
				object obj12 = (nint)0 >> 4;
				object obj13 = obj12 & 1;
				object obj14;
				if (obj13 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ r9_v9 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						obj14 = 6447965120L;
						goto IL_0671;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v48 (DG.Tweening.Core.DOGetter`1<System.Single>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1024 @ rax_v48 (DG.Tweening.Core.DOGetter`1<System.Single>)+10]");
				obj14 = 0;
				goto IL_0671;
				IL_0671:
				object obj15 = 24;
				_ = 6447969936L;
				setter2 = null;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r10_v5 (Il2CppMethodInfo)+8]");
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r10_v5 (Il2CppMethodInfo)+4C]");
				object obj16 = (nint)0 >> 4;
				object obj17 = obj16 & 1;
				object obj18;
				if (obj17 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r10_v5 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 1)
					{
						obj18 = 6447299152L;
						goto IL_06ae;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v55 (DG.Tweening.Core.DOSetter`1<System.Single>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1164 @ rax_v55 (DG.Tweening.Core.DOSetter`1<System.Single>)+10]");
				obj18 = 0;
				goto IL_06ae;
			}
			while ((nint)obj < count);
		}
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField && !((Tween)sequence).creationLocked)
		{
			((Tween)sequence).loops = -1;
			((Tween)sequence).loopType = LoopType.Yoyo;
			if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
			{
				((Tween)sequence).fullDuration = 1f / 0f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence.stringId = "DefaultGameTweenId";
	}

	private Light2D AddLight(Vector2 pos, float radius, float intensity)
	{
		Stage stage = _stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		DiContainer diContainer;
		UnityEngine.Object prefab;
		if ((object)stage._tilingTileset != null)
		{
			bool flag = ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0;
			diContainer = _diContainer;
			if (!flag)
			{
				prefab = _Light2DForTilemapPrefab;
				goto IL_0190;
			}
		}
		else
		{
			diContainer = _diContainer;
		}
		prefab = _Light2DPrefab;
		goto IL_0190;
		IL_0190:
		GameSessionData gameSessionData = _gameSessionData;
		Transform parentTransform = gameSessionData._activeCharacter.transform;
		GameObject gameObject = diContainer.InstantiatePrefab(prefab, parentTransform);
		((UnityEngine.Object)gameObject).SetName("Light2D - Candlelight");
		Transform transform = gameObject.transform;
		bool flag2 = (object)transform == null;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = gameObject.transform;
		bool flag4 = (object)transform2 == null;
		transform2.parent = _candleLightsParent;
		Light2D component = gameObject.GetComponent<Light2D>();
		bool flag5 = (object)component == null;
		component.lightType = Light2D.LightType.Point;
		component.m_PointLightOuterRadius = radius;
		component.m_Intensity = intensity;
		return component;
	}

	private void OnFireEnemyBullet(GameplaySignals.FireEnemyBulletSignal signal)
	{
		//IL_0031: Expected O, but got I4
		Stage stage = _stage;
		int permanentEnemiesNumber = _stage.PermanentEnemiesNumber;
		object obj = stage._maximum + 50;
		if (permanentEnemiesNumber < (nint)obj)
		{
			bool forceSpawn = default(bool);
			GameObject gameObject = _stage.SpawnEnemy(signal.BulletType, signal.SpawnPos, asRemote: false, forceSpawn);
		}
	}

	public void OnStagePickupCallback(Pickup pickup)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)_stagePickups).Remove((object)pickup);
		}
	}

	private unsafe void SpawnGems()
	{
		//IL_008e: Expected O, but got I
		//IL_0616: Expected I, but got O
		//IL_01d8: Expected I, but got O
		//IL_015d: Expected I, but got O
		//IL_016d: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_03f3: Expected O, but got I4
		//IL_0495: Expected O, but got I4
		//IL_058f: Expected O, but got I
		//IL_0422: Expected I, but got O
		//IL_0285: Expected O, but got Ref
		//IL_0297: Expected I, but got O
		//IL_04b1: Expected I, but got O
		//IL_04c1: Expected O, but got I
		//IL_02b8: Expected I, but got O
		//IL_02c8: Expected O, but got I
		//IL_04f9: Expected O, but got I
		//IL_0300: Expected O, but got I
		//IL_0365: Expected I, but got O
		//IL_037c: Expected F4, but got O
		//IL_03b8: Expected O, but got I4
		//IL_01f2->IL0595: Incompatible stack heights: 1 vs 0
		//IL_01ce->IL01ce: Incompatible stack heights: 3 vs 1
		//IL_067d->IL0595: Incompatible stack heights: 1 vs 0
		//IL_0568->IL0594: Incompatible stack heights: 1 vs 0
		//IL_049a->IL0633: Incompatible stack heights: 2 vs 1
		//IL_0594->IL0594: Incompatible stack heights: 1 vs 0
		//IL_046b->IL046b: Incompatible stack heights: 3 vs 2
		//IL_0527->IL0442: Incompatible stack heights: 4 vs 2
		//IL_03c3->IL0633: Incompatible stack heights: 8 vs 1
		List<PickupToSpawn> gemsToSpawn = _gemsToSpawn;
		if (_gemsToSpawn != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ r8_v1 (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
			if ((nint)0 == 0)
			{
				return;
			}
			HashSet<Pickup> gems = _gems;
			if (_gems != null)
			{
				int count = gems._count;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ r8_v1 (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
				object obj = (nint)count + (nint)0;
				if ((nint)obj >= 400)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ r8_v1 (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
					int maxGems = (int)((nint)400 - (nint)0);
					CondenseGems(maxGems);
				}
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Vector2 vector = default(Vector2);
						Pickup pickup = MathTools.FurthestObject(vector, _gems);
						nint num = (nint)typeof(Gem);
						if ((object)pickup != null)
						{
							nint num2 = (nint)pickup;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1151 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
							bool flag2 = num3 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1151 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1187 @ rax_v76+FFFFFFF8+v1152 @ rax_v75*8]");
							bool flag3 = 0 != (nint)typeof(Gem);
						}
						nint num4 = (nint)_gemsToSpawn;
						if (_gemsToSpawn != null)
						{
							Pickup pickup2 = pickup;
							List<PickupToSpawn>.Enumerator enumerator = default(List<PickupToSpawn>.Enumerator);
							Vector2 vector2 = default(Vector2);
							while (enumerator.MoveNext())
							{
								HashSet<Pickup> gems2 = _gems;
								bool flag4 = _gems == null;
								if (gems2._count <= 400)
								{
									ObjectPool gemPool = GemPool;
									bool flag5 = (object)gemPool == null;
									Pickup objectComponent = gemPool.GetObjectComponent<Pickup>((Vector3)(&vector2));
									nint num5 = (nint)typeof(Gem);
									bool flag6 = (object)objectComponent == null;
									nint num6 = (nint)objectComponent;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rdx_v31 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
									bool flag7 = num7 < 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v778 @ rax_v61+FFFFFFF8+v777 @ rax_v60*8]");
									bool flag8 = 0 != (nint)typeof(Gem);
									GameObject gameObject = objectComponent.gameObject;
									bool flag9 = (object)gameObject == null;
									gameObject.SetActive(value: true);
									nint num8 = (nint)objectComponent;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1418 @ r8_v31 (Il2CppClass<UnityEngine.Transform>)+328] (should have been resolved before IL gen)");
									((Gem)objectComponent).SetValue((float)vector);
									bool flag10 = _gems == null;
									bool flag11 = ((HashSet<object>)(object)_gems).AddIfNotPresent((object)objectComponent);
									Vector2 vector3 = (Vector2)0;
									num4 = 0;
									continue;
								}
								bool flag12 = (object)pickup2 != null;
								Vector2 vector4 = (Vector2)0;
								if (!flag12)
								{
									Pickup pickup3 = MathTools.FurthestObject(vector, _gems);
									nint num9 = (nint)typeof(Gem);
									if ((object)pickup3 != null)
									{
										nint num10 = (nint)pickup3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
										Vector2 vector5 = (Vector2)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
										nint num11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
										bool flag13 = num11 < 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
										object obj6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v996 @ rax_v56+FFFFFFF8+v995 @ rax_v55 (UnityEngine.Vector2)*8]");
										bool flag14 = 0 != (nint)typeof(Gem);
									}
									bool flag15 = (object)pickup3 == null;
									vector4 = vector;
									pickup2 = pickup3;
								}
								float value = (float)vector + pickup2._003CValue_003Ek__BackingField;
								((Gem)pickup2).SetValue(value);
								Vector2 vector6 = (Vector2)0;
							}
							List<PickupToSpawn> gemsToSpawn2 = _gemsToSpawn;
							if (_gemsToSpawn != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+1C]");
								_ = (nint)0 + (nint)1;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+10]");
									nint num12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
									Array.Clear((Array)num12, 0, 0);
								}
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void CondenseGems(int maxGems = 400)
	{
		//IL_00bd: Expected O, but got I4
		//IL_00dd: Expected O, but got I4
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Expected O, but got Unknown
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_03af: Expected I, but got O
		//IL_03b7: Expected I, but got O
		//IL_03c7: Expected O, but got I
		//IL_0403: Expected O, but got I
		//IL_01a9: Invalid comparison between F4 and O
		//IL_02c5: Expected I, but got O
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_01e9: Invalid comparison between O and F4
		//IL_0215: Invalid comparison between F4 and O
		//IL_024e: Invalid comparison between O and F4
		//IL_026c: Invalid comparison between F4 and I4
		//IL_0295: Expected O, but got I4
		//IL_0370->IL052c: Incompatible stack heights: 1 vs 0
		int num;
		Transform transform;
		while (true)
		{
			GameSessionData gameSessionData = _gameSessionData;
			bool flag = maxGems >= 1;
			num = maxGems;
			if (!flag)
			{
				num = 1;
			}
			transform = gameSessionData._activeCharacter.transform;
			if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		}
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		HashSet<Pickup> gems = _gems;
		if (gems._count <= num)
		{
			return;
		}
		Vector2 vector = default(Vector2);
		List<Pickup> list = MathTools.ListNearestToFarthest(vector, gems);
		HashSet<Pickup> gems2 = _gems;
		HashSet<Pickup> hashSet = (HashSet<Pickup>)(list._size - 1);
		Gem gem = null;
		Vector2 vector2 = vector;
		float num3 = default(float);
		float num2 = num3;
		object obj = 0;
		List<Pickup> list2 = list;
		while (gems2._count > num)
		{
			Component component;
			if (list._size > 0)
			{
				list2 = MathTools.ListNearestToFarthest((Vector2)list, hashSet);
				component = (Component)(object)list2;
			}
			else
			{
				component = null;
			}
			hashSet = (HashSet<Pickup>)(hashSet - 1);
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				Stage stage = _stage;
				Transform transform2 = component.transform;
				Vector3 position = transform2.position;
				float x = position.x;
				Rect containmentScreenRect = stage._containmentScreenRect;
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect);
				num2 = position.x;
				if (!flag2)
				{
					vector2 = (Vector2)((object)vector + (object)stage._containmentScreenRect);
					bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)position.x);
					num2 = position.x;
					if (!flag3)
					{
						bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector);
						vector2 = vector;
						num2 = num3;
						if (!flag4)
						{
							vector2 = vector + vector;
							bool flag5 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3);
							float num4 = (float)vector2 - num3;
							bool flag6 = num4 == 0f;
							bool flag7 = !flag5;
							bool flag8 = !flag6;
							object obj2 = flag8 & flag7;
							bool flag9 = obj2 != null;
							num2 = num3;
							if (flag9)
							{
								break;
							}
						}
					}
				}
				nint num5 = (nint)component;
				object obj3 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v9 (UnityEngine.Component)+FC]");
				obj = obj3 + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1021 @ rax_v52 (Il2CppClass<UnityEngine.Component>)+368] (should have been resolved before IL gen)");
			}
			gem = (Gem)(gem + 1);
			if ((nint)gem > num)
			{
				break;
			}
			gems2 = _gems;
		}
		bool flag10 = list._size <= 0;
		Gem gem2 = null;
		if (!flag10)
		{
			bool flag11 = (nint)hashSet >= list._size;
			Pickup[] items = list._items;
			gem2 = (Gem)items[(object)hashSet];
		}
		if ((object)gem2 == null || ((UnityEngine.Object)gem2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		nint num6 = (nint)typeof(Gem);
		nint num7 = (nint)gem2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ rcx_v26 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ rcx_v26 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+130]");
		if (num8 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Items.Gem>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rax_v32+FFFFFFF8+v593 @ rax_v31*8]");
			if (0 == (nint)typeof(Gem))
			{
				float value = (float)obj + ((Pickup)gem2)._003CValue_003Ek__BackingField;
				gem2.SetValue(value);
			}
		}
	}

	private void SpawnPickups<T>(List<PickupToSpawn> toSpawn, HashSet<T> pickupSet, int MAX_COUNT, float defaultValue, ObjectPool pool, ItemType itemType) where T : Pickup, ICountedPickup
	{
		//IL_015f: Expected O, but got I
		//IL_019b: Expected O, but got I
		//IL_01b0: Expected O, but got I
		//IL_04c3: Expected O, but got I
		//IL_0284: Expected F4, but got O
		//IL_0476: Expected O, but got I
		//IL_0400: Expected F4, but got I
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected I4, but got Unknown
		//IL_0439: Expected O, but got I4
		//IL_03bf: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_0337: Expected I, but got O
		//IL_036a: Expected O, but got I4
		//IL_0556->IL047b: Incompatible stack heights: 1 vs 0
		//IL_047b->IL047b: Incompatible stack heights: 1 vs 0
		//IL_03eb->IL03eb: Incompatible stack heights: 2 vs 1
		//IL_0377->IL04f4: Incompatible stack heights: 4 vs 1
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ stack_40+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ stack_40+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		if ((object)GM.Core != null)
		{
			ItemType type = default(ItemType);
			if (!GM.Core.IsStageHost && NetworkItems.IsNetworkItem(type))
			{
				return;
			}
			if (toSpawn != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toSpawn @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
				if ((nint)0 == 0)
				{
					return;
				}
				if (pickupSet != null)
				{
					int count = pickupSet._count;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toSpawn @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
					object obj = (nint)count + (nint)0;
					bool flag = (nint)obj < MAX_COUNT;
					int num = MAX_COUNT;
					HashSet<T> hashSet = pickupSet;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ stack_40+38]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toSpawn @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
						hashSet = (HashSet<T>)((nint)MAX_COUNT - (nint)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ rax_v66+10]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18303FC20");
					}
					GameSessionData gameSessionData = _gameSessionData;
					if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
					{
						Transform transform = gameSessionData._activeCharacter.transform;
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ stack_40+38]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183096380");
							object obj5 = default(object);
							object obj4 = obj5;
							List<PickupToSpawn>.Enumerator enumerator = default(List<PickupToSpawn>.Enumerator);
							Component component = default(Component);
							float num2 = default(float);
							GameManager gameManager = default(GameManager);
							GameManager gameManager2 = default(GameManager);
							object obj9 = default(object);
							object obj10 = default(object);
							while (enumerator.MoveNext())
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001830403F7h\"");
								bool flag3 = (object)component != null;
								float valueToAdd = (float)component;
								if (!flag3)
								{
									valueToAdd = num2;
								}
								if (pickupSet._count <= MAX_COUNT)
								{
									bool flag4 = (object)gameManager == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ stack_40+38]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1095 @ rax_v49+38]");
									num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B8220");
									bool flag5 = (object)gameManager2 == null;
									GameObject gameObject = gameManager2.gameObject;
									bool flag6 = (object)gameObject == null;
									gameObject.SetActive(value: true);
									nint num3 = (nint)gameManager2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1127 @ r8_v22 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+328] (should have been resolved before IL gen)");
									bool flag7 = ((HashSet<object>)(object)pickupSet).AddIfNotPresent((object)gameManager2);
									object obj7 = 0;
									Component component2 = component;
								}
								else
								{
									if (obj4 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ stack_40+38]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183096380");
										bool flag8 = obj9 == null;
										obj4 = obj9;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1005 @ rdi_v13+FC]");
									float num4 = MathUtils.AddValueCapped(0f, valueToAdd);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									num = obj10 + 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
									object obj11 = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toSpawn @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+1C]");
							_ = (nint)0 + (nint)1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toSpawn @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toSpawn @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+10]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [toSpawn @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Framework.PickupToSpawn>)+18]");
								Array.Clear((Array)num5, 0, 0);
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void CondensePickups<T>(HashSet<T> pickupSet, int maxPickups) where T : Pickup, ICountedPickup
	{
		//IL_054d: Expected O, but got F4
		//IL_0551: Expected I4, but got O
		//IL_00c7: Expected O, but got I
		//IL_0124: Expected F4, but got I4
		//IL_041b: Invalid comparison between F4 and I4
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_04d4: Expected F4, but got I
		//IL_021f: Invalid comparison between F4 and O
		//IL_0342: Expected F4, but got I
		//IL_0357: Expected F4, but got I
		//IL_037f: Expected I, but got O
		//IL_02c4: Invalid comparison between F4 and I4
		//IL_02ed: Expected O, but got I4
		//IL_0314: Expected I, but got O
		//IL_0565->IL0509: Incompatible stack heights: 1 vs 0
		//IL_00df->IL0509: Incompatible stack heights: 1 vs 0
		//IL_01d0->IL0509: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL0509: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		GameSessionData gameSessionData = _gameSessionData;
		if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
		{
			Transform transform = gameSessionData._activeCharacter.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				float num = default(float);
				if ((int)MathTools.ListNearestToFarthest((Vector2)num, pickupSet) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v17 (System.Boolean)+18]");
					HashSet<T> hashSet = (HashSet<T>)(-1);
					if (pickupSet != null)
					{
						bool flag2 = pickupSet._count <= maxPickups;
						float num2 = num;
						float num4 = default(float);
						float num3 = num4;
						nint num5 = 0;
						GameManager gameManager = null;
						GameManager gameManager2 = null;
						float num6 = 0f;
						if (flag2)
						{
							return;
						}
						float num8 = default(float);
						GameManager gameManager5 = default(GameManager);
						object obj2 = default(object);
						GameManager gameManager8 = default(GameManager);
						object obj4 = default(object);
						while (true)
						{
							bool flag3 = pickupSet._count <= maxPickups;
							float num7 = num8;
							float num9 = num2;
							float num10 = num3;
							nint num11 = num5;
							HashSet<T> hashSet2 = hashSet;
							GameManager gameManager3 = gameManager;
							float num12 = num6;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v17 (System.Boolean)+18]");
								GameManager gameManager4;
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									gameManager4 = gameManager5;
								}
								else
								{
									gameManager4 = null;
								}
								hashSet2 = (HashSet<T>)(hashSet - 1);
								if ((object)gameManager4 != null && ((UnityEngine.Object)gameManager4).m_CachedPtr != (IntPtr)0)
								{
									Stage stage = _stage;
									if ((object)_stage == null)
									{
										break;
									}
									Transform transform2 = gameManager4.transform;
									if ((object)transform2 == null)
									{
										break;
									}
									Vector3 position = transform2.position;
									float x = position.x;
									Rect containmentScreenRect = stage._containmentScreenRect;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect))
									{
										num9 = num + (float)stage._containmentScreenRect;
										if (num9 > position.x)
										{
											bool flag4 = num4 < num;
											num8 = num4;
											if (!flag4)
											{
												num10 = num + num;
												bool flag5 = num10 < num4;
												float num13 = num10 - num4;
												bool flag6 = num13 == 0f;
												bool flag7 = !flag5;
												bool flag8 = !flag6;
												object obj = flag8 & flag7;
												bool flag9 = obj != null;
												num8 = num4;
												num7 = num4;
												num11 = unchecked((nint)null);
												gameManager3 = gameManager;
												num12 = num6;
												if (flag9)
												{
													goto IL_0412;
												}
											}
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rbx_v8 (VampireSurvivors.Framework.GameManager)+FC]");
									num3 = 0f;
									float baseValue = num6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rbx_v8 (VampireSurvivors.Framework.GameManager)+FC]");
									num2 = MathUtils.AddValueCapped(baseValue, 0f);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									gameManager = (GameManager)(object)((object)gameManager + obj2);
									nint num14 = (nint)gameManager4;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v994 @ rax_v48 (Il2CppClass<VampireSurvivors.Framework.GameManager>)+368] (should have been resolved before IL gen)");
									bool flag10 = ((HashSet<object>)(object)pickupSet).Remove((object)gameManager4);
									num5 = 0;
									num6 = num2;
								}
								gameManager2 = (GameManager)(gameManager2 + 1);
								bool flag11 = (nint)gameManager2 <= maxPickups;
								num7 = num8;
								num9 = num2;
								num10 = num3;
								num11 = num5;
								gameManager3 = gameManager;
								num12 = num6;
								hashSet = hashSet2;
								if (flag11)
								{
									continue;
								}
							}
							goto IL_0412;
							IL_0412:
							if (!(num12 > 0f))
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v17 (System.Boolean)+18]");
							bool flag12 = (nint)0 <= (nint)0;
							GameManager gameManager6 = null;
							if (!flag12)
							{
								bool flag13 = (nint)hashSet2 == -1;
								GameManager gameManager7 = null;
								if (!flag13)
								{
									gameManager7 = (GameManager)(object)hashSet2;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								gameManager6 = gameManager8;
							}
							if ((object)gameManager6 != null && ((UnityEngine.Object)gameManager6).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rdi_v2 (VampireSurvivors.Framework.GameManager)+FC]");
								float num15 = MathUtils.AddValueCapped(0f, num12);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								object obj3 = (object)gameManager3 + obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006320");
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void QueueGenericResume(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer)
	{
		//IL_0014: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = PerformGenericResume;
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void PerformGenericResume(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer, Dictionary<string, object> args)
	{
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAC9A0");
	}

	public unsafe void QueueGenericPause(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer)
	{
		//IL_0014: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = GenericOnlinePause;
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void GenericOnlinePause(VampireSurvivors.Objects.Characters.CharacterController pausingPlayer, Dictionary<string, object> args)
	{
		//IL_009c: Expected I, but got O
		//IL_004e: Expected I4, but got O
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args2 = new(string, object)[1];
		VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = InteractingPlayer;
		object item;
		string log;
		string item2;
		if ((object)interactingPlayer != null && ((UnityEngine.Object)interactingPlayer).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController interactingPlayer2 = InteractingPlayer;
			object obj = default(object);
			item = (CharacterType)obj;
			log = "Game has been paused";
			item2 = "Pausing Player";
		}
		else
		{
			log = "Game has been paused";
			item2 = "Pausing Player";
			item = "null";
		}
		(string, object) tuple = (item2, item);
		_ = 0;
		nint num = (nint)logger;
		logger.Info(log, args2);
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B4A0");
	}

	public unsafe void QueueOpenWeaponSelection(VampireSurvivors.Objects.Characters.CharacterController player, string weaponSelectionType)
	{
		//IL_0043: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = OpenWeaponSelection;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"weaponSelectionType", (object)weaponSelectionType, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void OpenWeaponSelection(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_0171: Expected O, but got I4
		//IL_0132: Expected O, but got I4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_01c3: Expected I, but got O
		//IL_01df: Expected O, but got I
		_003CEnterWeaponSelectionPlayer_003Ek__BackingField = player;
		object obj = args.get_Item("weaponSelectionType");
		bool flag = obj == null;
		object obj2 = null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			bool flag2 = obj != null;
			obj2 = null;
			if (!flag2)
			{
				obj2 = obj;
			}
		}
		_003CWeaponSelectionType_003Ek__BackingField = (string)obj2;
		GameManager core = GM.Core;
		if (!core._003CWeaponSelectionType_003Ek__BackingField.Contains("tp_"))
		{
			GameManager core2 = GM.Core;
			if (!core2._003CWeaponSelectionType_003Ek__BackingField.Contains("eme_"))
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj4 = default(object);
				object obj3 = obj4 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				IntPtr intPtr = default(IntPtr);
				num = intPtr;
				object obj5 = default(object);
				object signal = (IntPtr)obj5;
				bool requireDeclaration = default(bool);
				_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
				return;
			}
			string text = "eme_";
			object obj6 = 0;
			SignalBus signalBus = _signalBus;
		}
		else
		{
			SignalBus signalBus = _signalBus;
			bool flag3 = _signalBus != null;
			string text = "tp_";
			object obj6 = 0;
			if (!flag3)
			{
				throw new NullReferenceException();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4280");
	}

	public unsafe void QueueEnterSkillSelection(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0014: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = EnterSkillSelection;
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void EnterSkillSelection(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0070: Expected I, but got O
		//IL_008c: Expected O, but got I
		_003CEnterBonusSelectionPlayer_003Ek__BackingField = player;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	public unsafe void QueueEnterShop(VampireSurvivors.Objects.Characters.CharacterController player, MerchantInventoryType inventoryType, PickupCustomMerchant customMerchant)
	{
		//IL_001d: Expected I4, but got O
		//IL_0075: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = EnterShop;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj = default(object);
		object value = (MerchantInventoryType)obj;
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"inventoryType", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"customMerchant", (object)customMerchant, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj2 = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj2));
	}

	private void EnterShop(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_0025: Expected I, but got O
		//IL_004a: Expected I, but got O
		//IL_00cb: Expected I, but got O
		//IL_00d9: Expected I, but got O
		//IL_00e9: Expected O, but got I
		//IL_0169: Expected O, but got I4
		//IL_0125: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_01e1: Expected O, but got I4
		//IL_01e1: Expected O, but got I
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		object obj2;
		object obj3;
		object obj6;
		if (args != null)
		{
			object obj = args.get_Item("inventoryType");
			nint num = (nint)typeof(MerchantInventoryType);
			if (obj != null)
			{
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v4 (Il2CppClass<VampireSurvivors.Data.MerchantInventoryType>)+40]");
				if (num3 != 0)
				{
					goto IL_023d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v6 (System.Object)+10]");
				_003CMerchantInventory_003Ek__BackingField = MerchantInventoryType.DEFAULT;
				obj2 = args.get_Item("customMerchant");
				bool flag = obj2 == null;
				obj3 = obj2;
				if (flag)
				{
					goto IL_0244;
				}
				nint num4 = (nint)obj2;
				nint num5 = (nint)typeof(PickupCustomMerchant);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v18 (Il2CppClass<System.Object>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCustomMerchant>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ r8_v18 (Il2CppClass<System.Object>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v43+FFFFFFF8+v223 @ rax_v38*8]");
					if (0 == (nint)typeof(PickupCustomMerchant))
					{
						obj6 = 1;
						goto IL_0253;
					}
				}
				obj6 = 0;
				goto IL_0253;
			}
		}
		goto IL_0211;
		IL_0244:
		_003CCurrentCustomMerchant_003Ek__BackingField = (PickupCustomMerchant)obj3;
		VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = InteractingPlayer;
		UISignals.OpenMerchantSignal openMerchantSignal = null;
		openMerchantSignal._003CCharacter_003Ek__BackingField = interactingPlayer;
		if (_signalBus != null)
		{
			object obj7 = ((Dictionary<string, object>)0).get_Item((string)1);
			object obj8 = obj7 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)openMerchantSignal, (object)null, requireDeclaration);
			return;
		}
		goto IL_0211;
		IL_023d:
		throw new InvalidCastException();
		IL_0211:
		NullReferenceException ex = new NullReferenceException();
		goto IL_023d;
		IL_0253:
		bool flag2 = obj6 == null;
		obj3 = null;
		if (!flag2)
		{
			obj3 = obj2;
		}
		goto IL_0244;
	}

	public unsafe void QueueEnterHealer(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0014: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = EnterHealer;
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void EnterHealer(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public unsafe void QueueEnterDirecter(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0014: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = EnterDirecter;
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void EnterDirecter(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public unsafe void QueueOpenArcana(ArcanaUiType type, VampireSurvivors.Objects.Characters.CharacterController chestWinner = null)
	{
		//IL_0008: Expected O, but got Ref
		//IL_01af: Expected O, but got Ref
		//IL_01c9: Expected I4, but got O
		//IL_01db: Expected O, but got Ref
		//IL_01ef: Expected native int or pointer, but got O
		//IL_0202: Expected O, but got Ref
		//IL_0128: Expected O, but got Ref
		//IL_0136: Expected I4, but got O
		//IL_0172: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		_ = 0;
		_ = 0;
		object arg = (ArcanaUiType)obj3;
		System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
		System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-1]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F]");
		_ = 0;
		string message = string.FormatHelper((IFormatProvider)null, "Queueing arcana opening {0}", args);
		Debug.Log(message);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager = core2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if (num <= 0)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController;
		if ((object)chestWinner != null)
		{
			bool flag = ((UnityEngine.Object)chestWinner).m_CachedPtr != (IntPtr)0;
			characterController = chestWinner;
			if (flag)
			{
				goto IL_0256;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController playerOne = PlayerOne;
		characterController = playerOne;
		goto IL_0256;
		IL_0256:
		_ = 0;
		_ = 0;
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = OpenMainArcana;
		_ = 6;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		object value = (ArcanaUiType)obj4;
		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"type", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		UiTransition item = (UiTransition)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-21]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-11]");
		_ = 0;
		_queuedUiTransitions.Add(item);
	}

	private void OpenMainArcana(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_0176: Expected I, but got O
		//IL_019b: Expected I, but got O
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_02a4: Expected I, but got O
		//IL_02c0: Expected O, but got I
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
				if (config._003CUnlockedArcanas_003Ek__BackingField != null)
				{
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						ArcanaManager arcanaManager = core2._arcanaManager;
						if (core2._arcanaManager != null)
						{
							List<ArcanaType> list2 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
							if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
								if (num <= 0)
								{
									return;
								}
								if (args != null)
								{
									object obj = args.get_Item("type");
									nint num2 = (nint)typeof(ArcanaUiType);
									if (obj != null)
									{
										nint num3 = (nint)obj;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v8 (Il2CppClass<System.Object>)+40]");
										nint num4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r8_v5 (Il2CppClass<VampireSurvivors.Data.ArcanaUiType>)+40]");
										if (num4 != 0)
										{
											goto IL_0289;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v15 (System.Object)+10]");
										_003CArcanaUiType_003Ek__BackingField = ArcanaUiType.MAIN;
										_003CChestWinnerPlayer_003Ek__BackingField = player;
										if (_signalBus != null)
										{
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
											object obj3 = default(object);
											object obj2 = obj3 + 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
											IntPtr intPtr = default(IntPtr);
											num5 = intPtr;
											object obj4 = default(object);
											object signal = (IntPtr)obj4;
											bool requireDeclaration = default(bool);
											_signalBus.InternalFire((Type)num5, signal, (object)null, requireDeclaration);
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
		NullReferenceException ex = new NullReferenceException();
		goto IL_0289;
		IL_0289:
		throw new InvalidCastException();
	}

	public unsafe void QueueOpenSurvarots(int cardsToShow, VampireSurvivors.Objects.Characters.CharacterController chestWinner)
	{
		//IL_0077: Expected O, but got Ref
		Debug.Log("Queueing Survarrochi opening");
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = OpenSurvarots;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"cardsToShow", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void OpenSurvarots(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_0044: Expected O, but got I
		//IL_0069: Expected I, but got O
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_019a: Expected I, but got O
		//IL_01b6: Expected O, but got I
		float num = (DifficultyAdjustmentEnemyHPMultiplier = CharacterSkillCardsManager.GetSurvarotDifficultyMultiplier()) - 1f;
		float num2 = num * 0.5f;
		float difficultyAdjustmentEnemyDamageMultiplier = num2 + 1f;
		DifficultyAdjustmentEnemyDamageMultiplier = difficultyAdjustmentEnemyDamageMultiplier;
		_003CChestWinnerPlayer_003Ek__BackingField = player;
		if (args != null)
		{
			object obj = args.get_Item("cardsToShow");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
			object obj2 = 0;
			if (obj != null)
			{
				nint num3 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v6 (Il2CppClass<System.Object>)+40]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r8_v5+40]");
				if (num4 != 0)
				{
					goto IL_017f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v11 (System.Object)+10]");
				_003CSurvarotsCardsToShow_003Ek__BackingField = 0;
				if (_signalBus != null)
				{
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj4 = default(object);
					object obj3 = obj4 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					IntPtr intPtr = default(IntPtr);
					num5 = intPtr;
					object obj5 = default(object);
					object signal = (IntPtr)obj5;
					bool requireDeclaration = default(bool);
					_signalBus.InternalFire((Type)num5, signal, (object)null, requireDeclaration);
					return;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_017f;
		IL_017f:
		throw new InvalidCastException();
	}

	public unsafe void QueueReportBody(VampireSurvivors.Objects.Characters.CharacterController reporter, VampireSurvivors.Objects.Characters.CharacterController reportedPlayer)
	{
		//IL_0043: Expected O, but got Ref
		Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = TransitionToReportBody;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"reportedPlayer", (object)reportedPlayer, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj = default(object);
		_queuedUiTransitions.Add((UiTransition)(&obj));
	}

	private void TransitionToReportBody(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_004e: Expected I, but got O
		//IL_005c: Expected I, but got O
		//IL_006c: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_00a8: Expected O, but got I
		//IL_00de: Expected O, but got I4
		//IL_0149: Expected I, but got O
		//IL_0157: Expected I, but got O
		//IL_0167: Expected O, but got I
		//IL_01e7: Expected O, but got I4
		//IL_01a3: Expected O, but got I
		//IL_01d9: Expected O, but got I4
		object obj = args.get_Item("reportedPlayer");
		VampireSurvivors.Objects.Characters.CharacterController character;
		ReportWeapon reportWeapon;
		if (obj == null)
		{
			character = null;
			reportWeapon = null;
			goto IL_0108;
		}
		nint num = (nint)obj;
		nint num2 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v9 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v9 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v33+FFFFFFF8+v122 @ rax_v29*8]");
			if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
			{
				obj4 = 1;
				goto IL_023d;
			}
		}
		obj4 = 0;
		goto IL_023d;
		IL_0269:
		object obj5;
		Weapon weaponByType;
		if (obj5 != null)
		{
			reportWeapon = (ReportWeapon)weaponByType;
		}
		goto IL_028b;
		IL_0108:
		weaponByType = player._weaponsManager.GetWeaponByType(WeaponType.C1_REPORT1);
		if ((object)weaponByType != null)
		{
			nint num4 = (nint)weaponByType;
			nint num5 = (nint)typeof(ReportWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.ReportWeapon>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.ReportWeapon>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v25+FFFFFFF8+v272 @ rax_v21*8]");
				if (0 == (nint)typeof(ReportWeapon))
				{
					obj5 = 1;
					goto IL_0269;
				}
			}
			obj5 = 0;
			goto IL_0269;
		}
		goto IL_028b;
		IL_023d:
		bool flag = obj4 == null;
		character = null;
		reportWeapon = null;
		if (!flag)
		{
			character = (VampireSurvivors.Objects.Characters.CharacterController)obj;
			reportWeapon = null;
		}
		goto IL_0108;
		IL_028b:
		if ((object)reportWeapon != null && ((UnityEngine.Object)reportWeapon).m_CachedPtr != (IntPtr)0)
		{
			reportWeapon.ReportBody(character);
		}
	}

	private void SwapToRelicFoundScreen(VampireSurvivors.Objects.Characters.CharacterController targetPlayer, Dictionary<string, object> args)
	{
		//IL_0025: Expected I, but got O
		//IL_004a: Expected I, but got O
		if (args != null)
		{
			object obj = args.get_Item("itemType");
			nint num = (nint)typeof(ItemType);
			if (obj != null)
			{
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v4 (Il2CppClass<VampireSurvivors.Data.ItemType>)+40]");
				if (num3 != 0)
				{
					goto IL_00d4;
				}
				if (_signalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E180");
					return;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_00d4;
		IL_00d4:
		throw new InvalidCastException();
	}

	private void SwapToItemFoundScreen(VampireSurvivors.Objects.Characters.CharacterController targetPlayer, Dictionary<string, object> args)
	{
		//IL_0025: Expected I, but got O
		//IL_0032: Expected I, but got O
		//IL_00cb: Expected O, but got I
		//IL_00e0: Expected O, but got I
		//IL_0165: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		object obj = args.get_Item("weaponType");
		nint num = (nint)typeof(WeaponType);
		nint num2 = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v7 (Il2CppClass<System.Object>)+40]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r8_v6 (Il2CppClass<VampireSurvivors.Data.WeaponType>)+40]");
		if (num3 == 0)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v10 (System.Object)+10]");
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v12 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v12 (System.Object)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v12+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v5+101]");
				int num4;
				if ((nint)0 != 0)
				{
					GameManager core = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v10 (System.Object)+10]");
					num4 = core.GetAccessoryLevel(WeaponType.VOID, targetPlayer);
					object obj5 = 0;
					VampireSurvivors.Objects.Characters.CharacterController characterController = targetPlayer;
				}
				else
				{
					GameManager core2 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v10 (System.Object)+10]");
					num4 = core2.GetWeaponLevel(WeaponType.VOID, targetPlayer);
					object obj5 = 0;
					VampireSurvivors.Objects.Characters.CharacterController characterController = targetPlayer;
				}
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v12 (System.Object)+18]");
				if ((nint)num5 >= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v5+19D]");
					if ((nint)0 == 0)
					{
						Debug.LogWarning("We cannot show this weapon page as we are already maxed out for this weapon");
						return;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E180");
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		throw new InvalidCastException();
	}

	private void SwapToCharFoundScreen(VampireSurvivors.Objects.Characters.CharacterController targetPlayer, Dictionary<string, object> args)
	{
		//IL_0025: Expected I, but got O
		//IL_004a: Expected I, but got O
		if (args != null)
		{
			object obj = args.get_Item("characterType");
			nint num = (nint)typeof(CharacterType);
			if (obj != null)
			{
				nint num2 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v5 (Il2CppClass<System.Object>)+40]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v4 (Il2CppClass<VampireSurvivors.Data.CharacterType>)+40]");
				if (num3 != 0)
				{
					goto IL_00d4;
				}
				if (_signalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD730");
					return;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_00d4;
		IL_00d4:
		throw new InvalidCastException();
	}

	public void PreManipulateLevelUpOptionsForSpecialWeapons()
	{
		//IL_0426: Expected I, but got O
		//IL_043c: Expected O, but got I
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_05ed: Expected O, but got I4
		//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Expected O, but got Unknown
		//IL_0184: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_02a2: Expected O, but got I
		//IL_02c7: Expected I, but got O
		//IL_02e5: Expected O, but got I
		//IL_030a: Expected I, but got O
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		CharacterWeaponsManager weaponsManager = activeCharacter._weaponsManager;
		CharacterAccessoriesManager accessoriesManager = activeCharacter._accessoriesManager;
		Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__675_0;
		if (_003C_003Ec._003C_003E9__675_0 == null)
		{
			Func<Equipment, WeaponType> func = (_003C_003Ec._003C_003E9__675_0 = delegate(Equipment x)
			{
				//IL_0035: Expected I4, but got O
				if ((object)x == null)
				{
					NullReferenceException ex3 = new NullReferenceException();
					return (WeaponType)ex3;
				}
				return x._equipmentType;
			});
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v102 (Il2CppClass<VampireSurvivors.Framework.GameManager+<>c>)+B8]");
			object obj = (nint)0 + (nint)48;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			selector = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj4 * 8;
				object obj6 = 6603577472L + obj5;
				object obj7 = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj8 = 1 << (int)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v30+462E0]");
					object obj9 = 0 | obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v30+462E0]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v30+462E0]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v30+462E0]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v30+462E0]");
				}
				while (num3 != 0);
				selector = func;
			}
		}
		IEnumerable<WeaponType> enumerable = Enumerable.Select(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, selector);
		if (enumerable != null)
		{
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			Func<Equipment, WeaponType> selector2 = _003C_003Ec._003C_003E9__675_1;
			if (_003C_003Ec._003C_003E9__675_1 == null)
			{
				selector2 = (_003C_003Ec._003C_003E9__675_1 = delegate(Equipment x)
				{
					//IL_0035: Expected I4, but got O
					if ((object)x == null)
					{
						NullReferenceException ex3 = new NullReferenceException();
						return (WeaponType)ex3;
					}
					return x._equipmentType;
				});
			}
			IEnumerable<WeaponType> enumerable2 = Enumerable.Select(((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField, selector2);
			if (enumerable2 != null)
			{
				List<System.Int32Enum> list2 = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				list.InsertRange(0, list2);
				List<Equipment>.Enumerator enumerator = (List<Equipment>.Enumerator)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
				IEnumerable<System.Int32Enum> enumerable3 = list2;
				List<Equipment>.Enumerator enumerator2 = default(List<Equipment>.Enumerator);
				List<WeaponType>.Enumerator enumerator3 = default(List<WeaponType>.Enumerator);
				object obj13 = default(object);
				while (true)
				{
					if (!enumerator2.MoveNext())
					{
						return;
					}
					object obj10 = 0;
					object obj11 = 0;
					if (obj11 == null)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rbx_v11+10]");
					if ((nint)0 == 0)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rbx_v11+88]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rbx_v11+88]");
					bool flag2 = (nint)0 == 0;
					nint num4 = (nint)typeof(UnityEngine.Object);
					if (flag2)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1168 @ r9_v12+110]");
					enumerator = (List<Equipment>.Enumerator)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1168 @ r9_v12+110]");
					bool flag3 = (nint)0 == 0;
					num4 = (nint)typeof(UnityEngine.Object);
					if (flag3)
					{
						throw new NullReferenceException();
					}
					while (enumerator3.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
						if (obj13 == null)
						{
							if (_signalBus != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2130");
								return;
							}
							throw new NullReferenceException();
						}
					}
				}
				throw new NullReferenceException();
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}
		Exception ex2 = System.Linq.Error.ArgumentNull("source");
		throw ex2;
	}

	public unsafe void PostManipulateLevelUpOptionsForSpecialWeapons()
	{
		//IL_0014: Expected O, but got I4
		//IL_002a: Expected O, but got Ref
		List<WeaponType>.Enumerator enumerator = (List<WeaponType>.Enumerator)0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator2.MoveNext())
		{
			WeaponType weaponType = WeaponType.VOID;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator2);
			throw new NullReferenceException();
		}
	}

	private void SwapToLevelUpScreen(bool adjustXpFactors)
	{
		//IL_02f5: Expected O, but got I4
		//IL_02fe: Expected O, but got I4
		//IL_0310: Expected O, but got I4
		//IL_04e2: Expected O, but got I4
		//IL_02c7: Expected O, but got I4
		//IL_02d0: Expected O, but got I4
		//IL_02e2: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_017b: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_00c9: Invalid comparison between O and F4
		//IL_03a4: Expected O, but got I4
		//IL_021c: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		//IL_0237: Expected O, but got I4
		//IL_0373: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		//IL_010e: Expected O, but got I4
		//IL_03d2: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = CanLimitBreak();
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		WeightedLimitBreak weightedLimitBreak;
		WeaponType? weaponType;
		object obj2;
		bool flag2;
		WeaponType? randomWeapon;
		object obj3;
		WeaponType weaponType2 = default(WeaponType);
		if (!_levelUpFactory.HasPowerupsInStore(gameSessionData._activeCharacter))
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController;
			if (!flag)
			{
				if (~(config._003CSelectedRandomLevels_003Ek__BackingField ? 1u : 0u) == 0)
				{
					activeCharacter._003CAlwaysRoast_003Ek__BackingField = true;
				}
				if (activeCharacter._003CAlwaysRoast_003Ek__BackingField)
				{
					float num = gameSessionData._activeCharacter.MaxHp();
					object obj = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)activeCharacter._currentHp))
					{
						characterController = null;
						weightedLimitBreak = null;
						weaponType = (WeaponType?)(object)0;
						obj2 = 1;
						flag2 = false;
						randomWeapon = (WeaponType?)(object)0;
						goto IL_04d9;
					}
				}
				if (!activeCharacter._003CAlwaysCoinBag_003Ek__BackingField)
				{
					bool flag3 = !activeCharacter._003CAlwaysRoast_003Ek__BackingField;
					characterController = null;
					if (flag3)
					{
						goto IL_02e7;
					}
				}
				characterController = null;
				weightedLimitBreak = null;
				weaponType = (WeaponType?)(object)0;
				obj2 = 0;
				flag2 = false;
				randomWeapon = (WeaponType?)(object)0;
				obj3 = 1;
				goto IL_0315;
			}
			if (~(config._003CSelectedRandomLevels_003Ek__BackingField ? 1u : 0u) == 0)
			{
				activeCharacter._003CAlwaysRandomLimitBreak_003Ek__BackingField = true;
			}
			bool flag4 = !activeCharacter._003CAlwaysRandomLimitBreak_003Ek__BackingField;
			characterController = null;
			if (!flag4)
			{
				bool flag5 = _limitBreakManager.HasLimitBreaks();
				bool flag6 = !flag5;
				characterController = null;
				if (!flag6)
				{
					WeightedLimitBreak randomWeightedWeapon = _limitBreakManager.GetRandomWeightedWeapon();
					characterController = null;
					weightedLimitBreak = randomWeightedWeapon;
					weaponType = (WeaponType?)(object)0;
					obj2 = 0;
					flag2 = false;
					randomWeapon = (WeaponType?)(object)0;
					goto IL_04d9;
				}
			}
		}
		else
		{
			bool flag7 = (byte)(~(config._003CSelectedRandomLevels_003Ek__BackingField ? 1u : 0u)) != 0;
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			if (!flag7)
			{
				List<WeaponType> levelUpPowerups = _levelUpFactory.GetLevelUpPowerups(gameSessionData._activeCharacter);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				bool flag8 = (nint)0 <= (nint)0;
				characterController = null;
				if (!flag8)
				{
					weaponType2 = VampireSurvivors.App.Tools.Extensions.PickRnd(levelUpPowerups);
					characterController = null;
					weightedLimitBreak = null;
					weaponType = (WeaponType?)(object)1;
					obj2 = 0;
					flag2 = false;
					randomWeapon = (WeaponType?)(object)1;
					goto IL_04d9;
				}
			}
		}
		goto IL_02e7;
		IL_02e7:
		weightedLimitBreak = null;
		weaponType = (WeaponType?)(object)0;
		obj2 = 0;
		flag2 = true;
		randomWeapon = (WeaponType?)(object)0;
		goto IL_04d9;
		IL_04d9:
		obj3 = 0;
		goto IL_0315;
		IL_0315:
		bool isOnlineMultiplayer = _multiplayer.IsOnlineMultiplayer;
		if (!isOnlineMultiplayer)
		{
			bool flag9 = (nint)weaponType == (isOnlineMultiplayer ? 1 : 0);
			WeaponType weaponType3 = WeaponType.VOID;
			if (!flag9)
			{
				ApplyRandomLevelUpWeapon(weaponType2, gameSessionData._activeCharacter);
				object obj4 = 0;
				VampireSurvivors.Objects.Characters.CharacterController characterController = gameSessionData._activeCharacter;
				weaponType3 = weaponType2;
			}
			bool flag10 = weightedLimitBreak == null;
			WeightedLimitBreak weightedLimitBreak2 = (WeightedLimitBreak)weaponType3;
			if (!flag10)
			{
				bool flag11 = ApplyRandomLevelUpLimitBreak(weightedLimitBreak, gameSessionData._activeCharacter);
				object obj4 = 0;
				VampireSurvivors.Objects.Characters.CharacterController characterController = gameSessionData._activeCharacter;
				flag2 = flag11;
				weightedLimitBreak2 = weightedLimitBreak;
			}
			bool flag12 = obj2 == null;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = (VampireSurvivors.Objects.Characters.CharacterController)(object)weightedLimitBreak2;
			if (!flag12)
			{
				ApplyRoastLevelUp(gameSessionData._activeCharacter);
				VampireSurvivors.Objects.Characters.CharacterController characterController = null;
				characterController2 = gameSessionData._activeCharacter;
			}
			if (obj3 != null)
			{
				ApplyCoinBagLevelUp(gameSessionData._activeCharacter);
				VampireSurvivors.Objects.Characters.CharacterController characterController = null;
				characterController2 = gameSessionData._activeCharacter;
			}
			if (flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4070");
			}
		}
		else
		{
			WeightedLimitBreak randomLimitBreak = default(WeightedLimitBreak);
			bool roastLevelUp = default(bool);
			bool coinBagLevelUp = default(bool);
			StartOnlineLevelUpFromHost(flag2, adjustXpFactors, randomWeapon, randomLimitBreak, roastLevelUp, coinBagLevelUp);
		}
	}

	private unsafe void StartOnlineLevelUpFromHost(bool shouldSendLevelUpSignal, bool adjustXpFactors, WeaponType? randomWeapon, WeightedLimitBreak randomLimitBreak, bool roastLevelUp, bool coinBagLevelUp)
	{
		//IL_0031: Expected O, but got Ref
		//IL_01fb: Expected O, but got Ref
		//IL_00c9: Expected O, but got I
		//IL_016a: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_01c4: Expected O, but got I
		bool flag = !shouldSendLevelUpSignal;
		List<WeaponType> chosenWeapons = null;
		bool flag2 = adjustXpFactors;
		WeaponType? weaponType = randomWeapon;
		ref List<ItemType> reference = default(ref List<ItemType>);
		if (!flag)
		{
			PreManipulateLevelUpOptionsForSpecialWeapons();
			GetLevelUpChoices(out chosenWeapons, out var amuletTargets, out var limitBreaks, out reference);
			flag2 = (byte)(&amuletTargets) != 0;
			weaponType = (WeaponType?)(object)(&limitBreaks);
		}
		if ((object)randomWeapon != null)
		{
			List<WeaponType> list = new List<WeaponType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
			chosenWeapons = list;
		}
		object obj = default(object);
		if (obj != null)
		{
			List<WeightedLimitBreak> list2 = new List<WeightedLimitBreak>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A70");
		}
		object obj2 = default(object);
		if (obj2 != null)
		{
			List<ItemType> list3 = new List<ItemType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdx_v14+18]");
			if (num >= 0)
			{
				((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)12);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v24 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj4 = (nint)0 + (nint)1;
				_ = 12;
			}
		}
		object obj5 = default(object);
		if (obj5 != null)
		{
			List<ItemType> list4 = new List<ItemType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rdx_v10+18]");
			if (num2 >= 0)
			{
				((List<System.Int32Enum>)(object)list4).AddWithResize((System.Int32Enum)4);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj7 = (nint)0 + (nint)1;
				_ = 4;
			}
		}
		PostManipulateLevelUpOptionsForSpecialWeapons();
		List<VampireSurvivors.Objects.Characters.CharacterController> amuletTargets2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>);
		List<WeightedLimitBreak> limitBreaks2 = default(List<WeightedLimitBreak>);
		OnlineStageManager._instance.SendOnlineLevelUpCommand(shouldSendLevelUpSignal, adjustXpFactors, chosenWeapons, (List<ItemType>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference), amuletTargets2, limitBreaks2);
	}

	private bool CanLimitBreak()
	{
		//IL_0150: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
				if (config._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							if (_playerOptions != null)
							{
								PlayerOptionsData config2 = _playerOptions.Config;
								if (config2 != null)
								{
									if (!config2._003CSelectedLimitBreak_003Ek__BackingField)
									{
										goto IL_013c;
									}
									if (_limitBreakManager != null)
									{
										return _limitBreakManager.HasLimitBreaks();
									}
								}
							}
							goto IL_0142;
						}
					}
					goto IL_013c;
				}
			}
		}
		goto IL_0142;
		IL_0142:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_013c:
		return false;
	}

	private unsafe void GetLevelUpChoices(out List<WeaponType> chosenWeapons, out List<VampireSurvivors.Objects.Characters.CharacterController> amuletTargets, out List<WeightedLimitBreak> limitBreaks, out List<ItemType> chosenItems)
	{
		//IL_01c0: Expected O, but got I4
		//IL_018c: Expected O, but got I
		ref List<WeaponType> reference = ref *(List<WeaponType>*)null;
		object obj = 0;
		ref List<VampireSurvivors.Objects.Characters.CharacterController> reference2 = ref *(List<VampireSurvivors.Objects.Characters.CharacterController>*)null;
		ref List<WeightedLimitBreak> reference3 = ref *(List<WeightedLimitBreak>*)null;
		GameSessionData gameSessionData = _gameSessionData;
		if (!_levelUpFactory.HasPowerupsInStore(gameSessionData._activeCharacter))
		{
			if (CanLimitBreak() && _limitBreakManager.HasLimitBreaks())
			{
				List<WeightedLimitBreak> limitBreakBonuses = _limitBreakManager.GetLimitBreakBonuses();
				reference3 = ref *(List<WeightedLimitBreak>*)limitBreakBonuses;
			}
			else
			{
				List<ItemType> levelUpItems = _levelUpFactory.GetLevelUpItems();
				obj = levelUpItems;
			}
			return;
		}
		GameSessionData gameSessionData2 = _gameSessionData;
		List<WeaponType> levelUpPowerups = _levelUpFactory.GetLevelUpPowerups(gameSessionData2._activeCharacter);
		reference = ref *(List<WeaponType>*)levelUpPowerups;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F650");
		List<VampireSurvivors.Objects.Characters.CharacterController> list = _levelUpFactory.FindFriendshipAmuletTargets(checkAmuletBag: true);
		reference2 = ref *(List<VampireSurvivors.Objects.Characters.CharacterController>*)list;
		if (amuletTargets != null)
		{
			List<WeaponType> list2 = chosenWeapons;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 == 4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				object obj2 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047F780");
			}
		}
	}

	private bool ApplyOfflineLevelUp(WeaponType? randomWeapon, VampireSurvivors.Objects.Characters.CharacterController player, WeightedLimitBreak randomLimitBreak, bool shouldSendLevelUpSignal, bool roastLevelUp, bool coinBagLevelUp)
	{
		//IL_019c: Expected I4, but got O
		//IL_01d2: Expected O, but got I4
		//IL_00b4: Expected I4, but got O
		if (_multiplayer != null)
		{
			if (!_multiplayer.IsOnlineMultiplayer)
			{
				bool flag = (object)randomWeapon == null;
				WeightedLimitBreak weightedLimitBreak = randomLimitBreak;
				WeaponType weaponType = WeaponType.VOID;
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				if (!flag)
				{
					WeaponType weaponType2 = default(WeaponType);
					ApplyRandomLevelUpWeapon(weaponType2, characterController);
					weightedLimitBreak = null;
					weaponType = weaponType2;
				}
				bool flag3;
				if (randomLimitBreak != null)
				{
					bool flag2 = ApplyRandomLevelUpLimitBreak(randomLimitBreak, characterController);
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = characterController;
					weightedLimitBreak = null;
					weaponType = (WeaponType)randomLimitBreak;
					flag3 = flag2;
				}
				else
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = characterController;
					bool flag4 = default(bool);
					flag3 = flag4;
				}
				object obj = default(object);
				bool flag5 = obj == null;
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = (VampireSurvivors.Objects.Characters.CharacterController)weaponType;
				if (!flag5)
				{
					ApplyRoastLevelUp(characterController);
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
					characterController3 = characterController;
				}
				object obj2 = default(object);
				if (obj2 != null)
				{
					ApplyCoinBagLevelUp(characterController);
					VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
					characterController3 = characterController;
				}
				if (flag3)
				{
					if (_signalBus == null)
					{
						goto IL_018e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4070");
				}
				return true;
			}
			return false;
		}
		goto IL_018e;
		IL_018e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void ApplyCoinBagLevelUp(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0164: Expected O, but got Ref
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		float num = GoldMultiplier * 25f;
		if ((object)player == null || ((UnityEngine.Object)player).m_CachedPtr == (IntPtr)0)
		{
			goto IL_01af;
		}
		PlayerModifierStats playerStats = player._playerStats;
		EggFloat eggFloat = playerStats._003CGreed_003Ek__BackingField;
		float num2 = eggFloat._eggVal + eggFloat._val;
		object obj = num2 & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877BA7EAh\"");
				if (num2 == -1f / 0f)
				{
					num2 = -3.4028235E+38f;
				}
				goto IL_01cd;
			}
		}
		num2 = 3.4028235E+38f;
		goto IL_01cd;
		IL_01af:
		MakeAndActivatePickup(ItemType.COINBAG2, player);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string value = System.Number.FormatSingle(num, "F0", currentInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		object obj3 = default(object);
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		string textureName = default(string);
		_gizmoManager.DisplayIconOverhead("CoinGold", value, (Color?)(object)(&obj3), character, displayTimeMultiplier, vOffset, textureName);
		_gizmoManager.DisplayLevelUp(player);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4330");
		return;
		IL_01cd:
		num *= num2;
		goto IL_01af;
	}

	private unsafe void ApplyRoastLevelUp(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_002e: Expected O, but got Ref
		MakeAndActivatePickup(ItemType.ROAST, player);
		object obj = default(object);
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		float displayTimeMultiplier = default(float);
		Vector2 vOffset = default(Vector2);
		string textureName = default(string);
		_gizmoManager.DisplayIconOverhead("Roast", "", (Color?)(object)(&obj), character, displayTimeMultiplier, vOffset, textureName);
		_gizmoManager.DisplayLevelUp(player);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4330");
	}

	private unsafe bool ApplyRandomLevelUpLimitBreak(WeightedLimitBreak lBreakData, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0272: Expected I4, but got O
		//IL_013a: Expected O, but got I
		//IL_016f: Expected O, but got I
		//IL_01e2: Expected O, but got Ref
		//IL_01e2: Expected O, but got I
		//IL_0200: Expected F4, but got O
		if (LimitBreakWeaponUp(lBreakData, player))
		{
			if (lBreakData != null && lBreakData.KeyValues != null)
			{
				string localizedDescription = lBreakData.KeyValues.GetLocalizedDescription();
				if (_gizmoManager != null)
				{
					_gizmoManager.DisplayLimitBreakLevelUp(player);
					if (_dataManager != null)
					{
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
						if (convertedWeapons != null)
						{
							object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)lBreakData.WeaponType);
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v9 (System.Object)+18]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v9 (System.Object)+10]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v9 (System.Object)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v12+20]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v12+20]");
										if ((nint)0 != 0 && _gizmoManager != null)
										{
											GizmoManager gizmoManager = _gizmoManager;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v7+40]");
											object obj4 = default(object);
											VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
											float displayTimeMultiplier = default(float);
											Vector2 vOffset = default(Vector2);
											string textureName = default(string);
											gizmoManager.DisplayIconOverhead((string)0, localizedDescription, (Color?)(object)(&obj4), characterController, displayTimeMultiplier, vOffset, textureName);
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, (float)characterController);
											if (_signalBus != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4330");
												return false;
											}
										}
									}
								}
								else
								{
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return true;
	}

	private unsafe void ApplyRandomLevelUpWeapon(WeaponType choice, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_00e7: Expected O, but got I
		//IL_00fc: Expected O, but got I
		//IL_0119: Expected O, but got Ref
		//IL_0151: Expected O, but got Ref
		//IL_0151: Expected O, but got I
		//IL_016f: Expected F4, but got O
		LevelWeaponUp(choice, removeFromStore: true, player);
		Weapon weaponByType = player._weaponsManager.GetWeaponByType(choice);
		bool flag = (object)weaponByType == null;
		int value = 1;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0;
			value = 1;
			if (!flag2)
			{
				value = ((Equipment)weaponByType)._003CLevel_003Ek__BackingField;
			}
		}
		_gizmoManager.DisplayLimitBreakLevelUp(player);
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)choice);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v17 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v17 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v18+20]");
			object obj3 = 0;
			object obj4 = default(object);
			string value2 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj4), null);
			GizmoManager gizmoManager = _gizmoManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v16+40]");
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			gizmoManager.DisplayIconOverhead((string)0, value2, (Color?)(object)(&obj4), characterController, displayTimeMultiplier, vOffset, textureName);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, (float)characterController);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB4330");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void SwapToTreasureScreen(VampireSurvivors.Objects.Characters.CharacterController player, Dictionary<string, object> args)
	{
		//IL_0049: Expected I, but got O
		//IL_0057: Expected I, but got O
		//IL_0067: Expected O, but got I
		//IL_00e7: Expected O, but got I4
		//IL_00a3: Expected O, but got I
		//IL_00d9: Expected O, but got I4
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_033b: Expected I, but got O
		//IL_0357: Expected O, but got I
		object obj = args.get_Item("treasure");
		Treasure treasure;
		if (obj == null)
		{
			treasure = null;
			goto IL_0101;
		}
		nint num = (nint)obj;
		nint num2 = (nint)typeof(Treasure);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rdx_v27 (Il2CppClass<VampireSurvivors.Data.Stage.Treasure>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r9_v6 (Il2CppClass<System.Object>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rdx_v27 (Il2CppClass<VampireSurvivors.Data.Stage.Treasure>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ r9_v6 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v66+FFFFFFF8+v219 @ rax_v62*8]");
			if (0 == (nint)typeof(Treasure))
			{
				obj4 = 1;
				goto IL_02de;
			}
		}
		obj4 = 0;
		goto IL_02de;
		IL_01c9:
		_003CChestWinnerPlayer_003Ek__BackingField = treasure.winningPlayer;
		object obj5;
		if (!_multiplayer.IsOnlineMultiplayer || !treasure.QuickTreasureAnim)
		{
			if (!_multiplayer.IsOnlineMultiplayer)
			{
				bool flag = CanPlayQuickTreasureAnim(treasure.prizes);
				bool flag2 = !flag;
				obj5 = null;
				if (!flag2)
				{
					goto IL_0278;
				}
			}
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj7 = default(object);
			object obj6 = obj7 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num4 = intPtr;
			object obj8 = default(object);
			object signal = (IntPtr)obj8;
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire((Type)num4, signal, (object)null, requireDeclaration);
			return;
		}
		goto IL_0278;
		IL_0278:
		PlayQuickTreasureAnim(treasure, treasure.winningPlayer);
		return;
		IL_0101:
		VampireSurvivors.Objects.Characters.CharacterController winningPlayer;
		if (!_multiplayer.IsOnlineMultiplayer)
		{
			if (_mainCharacters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
				if (mainCharacters._size > 1)
				{
					winningPlayer = PullRandomChestWinner();
					goto IL_0182;
				}
			}
			GameSessionData gameSessionData = _gameSessionData;
			winningPlayer = gameSessionData._activeCharacter;
			goto IL_0182;
		}
		obj5 = obj;
		goto IL_01c9;
		IL_0182:
		treasure.winningPlayer = winningPlayer;
		PostManipulateLevelUpOptionsForSpecialWeapons();
		List<TreasurePrizeTypePair> list = _treasureFactory.GenerateNewPrizes(treasure);
		obj5 = null;
		goto IL_01c9;
		IL_02de:
		bool flag3 = obj4 == null;
		IntPtr intPtr2 = num;
		treasure = null;
		if (!flag3)
		{
			intPtr2 = num;
			treasure = (Treasure)obj;
		}
		goto IL_0101;
	}

	public bool CanPlayQuickTreasureAnim(List<TreasurePrizeTypePair> prizes)
	{
		//IL_00bf: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			bool flag;
			if (CanSkipTreasureLevel3(config))
			{
				flag = true;
			}
			else
			{
				PlayerOptions playerOptions = _playerOptions;
				if (_playerOptions == null)
				{
					goto IL_00b1;
				}
				bool flag2 = CanSkipTreasureLevel3(playerOptions._mainGameConfig);
				flag = flag2;
			}
			bool flag3 = AllPrizesAreFillerOrArcana(prizes);
			return flag3 & flag;
		}
		goto IL_00b1;
		IL_00b1:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void PlayQuickTreasureAnim(Treasure treasure, VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0226: Expected I4, but got O
		//IL_002a: Expected I4, but got O
		//IL_0060: Expected O, but got Ref
		//IL_00c9: Expected O, but got Ref
		//IL_00c9: Expected O, but got I
		//IL_00d2: Expected I4, but got O
		//IL_013a: Expected O, but got I
		//IL_017a: Expected O, but got I4
		//IL_0188: Expected O, but got I4
		//IL_0190: Expected O, but got Ref
		bool flag = treasure == null;
		int num = (int)this;
		if (!flag)
		{
			treasure.ClaimPrizes(character);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			num = (int)GM.Core;
			if ((object)GM.Core != null)
			{
				int num2 = default(int);
				object obj = default(object);
				string value = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&obj), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v3 (System.Int32)+148]");
				bool flag2 = (nint)0 == 0;
				num = num2;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v8 (System.Int32)+148]");
					VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
					float displayTimeMultiplier = default(float);
					Vector2 vOffset = default(Vector2);
					string textureName = default(string);
					((GizmoManager)0).DisplayIconOverhead("MoneyBagGreen", value, (Color?)(object)(&obj), character2, displayTimeMultiplier, vOffset, textureName);
					num = (int)GM.Core;
					if ((object)GM.Core != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v3 (System.Int32)+148]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v3 (System.Int32)+148]");
						num = 0;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v3 (System.Int32)+148]");
							((GizmoManager)0).DisplayQuickTreasureChestAnimation(character);
							bool flag4 = treasure.prizes == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v3 (System.Int32)+148]");
							num = 0;
							if (!flag4)
							{
								object obj2 = 0;
								List<TreasurePrizeTypePair>.Enumerator enumerator = default(List<TreasurePrizeTypePair>.Enumerator);
								if (enumerator.MoveNext())
								{
									object obj3 = 0;
									List<TreasurePrizeTypePair>.Enumerator enumerator2 = (List<TreasurePrizeTypePair>.Enumerator)(&enumerator);
									throw new NullReferenceException();
								}
								if (_signalBus != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0620");
									if ((nint)obj2 > 0)
									{
										do
										{
											QueueOpenArcana(ArcanaUiType.DRAFT, character);
										}
										while (obj2 != null);
									}
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool CanSkipTreasureLevel3(PlayerOptionsData config)
	{
		//IL_01ca: Expected I4, but got O
		//IL_00a2: Expected O, but got I4
		//IL_019d: Expected O, but got I4
		if (config != null && config._003CPickupCount_003Ek__BackingField != null)
		{
			int num = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.STATS_TREASURE_3);
			if (num >= 0)
			{
				if (config._003CPickupCount_003Ek__BackingField == null)
				{
					goto IL_01bc;
				}
				int num2 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.STATS_TREASURE_3);
				object obj = num2 - 50;
				bool flag = obj == null;
				if (num2 >= 50)
				{
					return !flag;
				}
			}
			if (config._003CPickupCount_003Ek__BackingField != null)
			{
				int num3 = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.TREASURE);
				bool flag2 = num3 == 0;
				if (num3 < 0)
				{
					return !flag2;
				}
				if (config._003CPickupCount_003Ek__BackingField != null)
				{
					int num4 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.TREASURE);
					object obj2 = num4 - 200;
					bool flag3 = obj2 == null;
					return !flag3;
				}
			}
		}
		goto IL_01bc;
		IL_01bc:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool AllPrizesAreFillerOrArcana(List<TreasurePrizeTypePair> prizes)
	{
		//IL_0021: Expected O, but got I4
		//IL_0029: Expected O, but got Ref
		bool result = true;
		List<TreasurePrizeTypePair>.Enumerator enumerator = default(List<TreasurePrizeTypePair>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<TreasurePrizeTypePair>.Enumerator enumerator2 = (List<TreasurePrizeTypePair>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	private void GenerateCheatCodeManager()
	{
		GameplayCheatCodeManager gameplayCheatCodeManager = _diContainer.Instantiate<GameplayCheatCodeManager>();
		_gameplayCheatCodeManager = gameplayCheatCodeManager;
		_gameplayCheatCodeManager.Initialize();
	}

	private unsafe void ClearTimeStop()
	{
		//IL_001d: Expected O, but got Ref
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		if (enumerator.MoveNext())
		{
			EnemyController enemyController = null;
			List<EnemyController>.Enumerator enumerator2 = (List<EnemyController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		_003CIsTimeStopped_003Ek__BackingField = false;
	}

	public void OnConnectionError(CoherenceBridge _, ConnectionException connectionException)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0158: Expected I, but got O
		//IL_0174: Expected O, but got I
		if (_signalGameplayLoadedRoutine != null)
		{
			StopCoroutine(_signalGameplayLoadedRoutine);
			_signalGameplayLoadedRoutine = null;
		}
		_003CConnectionException_003Ek__BackingField = connectionException;
		if (!_inGameOverState && !BlockConnectionErrorPopups)
		{
			OnlinePlatformSupport.OnConnectionError();
			string message = connectionException.Message;
			OnlineErrorManager.ShowError(OnlineErrorType.InGame, message);
			string message2 = connectionException.Message;
			string message3 = "Firing connection error signal: " + message2;
			Debug.Log(message3);
			_inOnlineErrorState = true;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	public void HandleCameraUpdate()
	{
		//IL_0089: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		//IL_01bf: Expected O, but got F4
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		if (_characters == null)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		if (characters._size == 0)
		{
			return;
		}
		Transform coopCameraTarget = _coopCameraTarget;
		if ((object)_coopCameraTarget == null || ((UnityEngine.Object)coopCameraTarget).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
		object obj = 0;
		object obj2 = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = _characters;
		while ((nint)obj < characters2._size)
		{
			if ((nint)obj2 < characters3._size)
			{
				VampireSurvivors.Objects.Characters.CharacterController[] items = characters3._items;
				items[obj2].HandleLateUpdate();
				characters3 = _characters;
				obj2++;
				obj = obj2;
				characters2 = _characters;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		UpdateCameraTarget();
		ProCamera2D instance = ProCamera2D.Instance;
		object obj3 = Time.deltaTime;
		float deltaTime = default(float);
		instance.Move(deltaTime);
	}

	public bool IsNormalCameraTarget()
	{
		//IL_01d7: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		ProCamera2D instance = ProCamera2D.Instance;
		List<Com.LuisPedroFonseca.ProCamera2D.CameraTarget> cameraTargets = instance.CameraTargets;
		if (cameraTargets._size != 1)
		{
			return false;
		}
		ProCamera2D instance2 = ProCamera2D.Instance;
		List<Com.LuisPedroFonseca.ProCamera2D.CameraTarget> cameraTargets2 = instance2.CameraTargets;
		if (cameraTargets2._size > 0)
		{
			Com.LuisPedroFonseca.ProCamera2D.CameraTarget[] items = cameraTargets2._items;
			Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = items[0];
			Transform targetTransform = cameraTarget.TargetTransform;
			Transform coopCameraTarget = _coopCameraTarget;
			bool flag = (object)_coopCameraTarget == null;
			bool flag2 = (object)cameraTarget.TargetTransform == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				if ((object)_coopCameraTarget != null)
				{
					if ((object)cameraTarget.TargetTransform != null)
					{
						object obj3 = (object)cameraTarget.TargetTransform - (object)_coopCameraTarget;
						return obj3 == null;
					}
					return ((UnityEngine.Object)coopCameraTarget).m_CachedPtr == (IntPtr)0;
				}
				return ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			}
			return true;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result = default(bool);
		return result;
	}

	private Transform GetFreeRoamCameraTarget()
	{
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			if ((object)OnlineStageManager._instance != null)
			{
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				if ((object)myPlayerInfo == null || ((UnityEngine.Object)myPlayerInfo).m_CachedPtr == (IntPtr)0)
				{
					goto IL_01f6;
				}
				if ((object)OnlineStageManager._instance != null)
				{
					PlayerInfo myPlayerInfo2 = OnlineStageManager._instance.GetMyPlayerInfo();
					if ((object)myPlayerInfo2 != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo2.CharacterController;
						if ((object)characterController != null && (object)characterController._multiplayerRevivalUI != null)
						{
							if (!characterController._multiplayerRevivalUI.IsVisible())
							{
								return characterController.transform;
							}
							List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = _mainCharacters;
							int num = _003CFreeRoamCameraTargetWhenDead_003Ek__BackingField;
							if (_mainCharacters != null)
							{
								if (_003CFreeRoamCameraTargetWhenDead_003Ek__BackingField < mainCharacters._size)
								{
									VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
									if (mainCharacters._items != null && (object)items[num] != null)
									{
										return items[num].transform;
									}
								}
								else
								{
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								}
							}
						}
					}
				}
			}
			return (Transform)(object)new NullReferenceException();
		}
		goto IL_01f6;
		IL_01f6:
		return _coopCameraTarget;
	}

	private unsafe void UpdateCameraTarget()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1078: Expected I, but got O
		//IL_10ab: Expected F4, but got I
		//IL_10cc: Expected F4, but got I
		//IL_01d4: Expected O, but got I4
		//IL_115c: Expected O, but got I
		//IL_0e98: Expected I, but got O
		//IL_0f19: Expected F4, but got O
		//IL_0f22: Expected O, but got I4
		//IL_0f2b: Expected O, but got I4
		//IL_0f34: Expected O, but got I4
		//IL_0bba: Expected O, but got I
		//IL_0260: Expected O, but got I
		//IL_0281: Expected F4, but got I
		//IL_02bc: Expected O, but got I4
		//IL_02c5: Expected O, but got I4
		//IL_02ce: Expected O, but got I4
		//IL_012b: Expected O, but got I
		//IL_11d5: Expected O, but got I
		//IL_0e7d: Expected O, but got Ref
		//IL_0dff: Expected O, but got Ref
		//IL_0e14: Expected O, but got I
		//IL_0cfa: Expected O, but got I
		//IL_10f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fd: Expected O, but got Unknown
		//IL_1049: Expected O, but got I
		//IL_0552: Expected O, but got I
		//IL_08cb: Expected O, but got I
		//IL_0e4e: Expected O, but got I
		//IL_0577: Expected O, but got I
		//IL_0f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f56: Expected O, but got Unknown
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1b: Expected O, but got Unknown
		//IL_0b3c: Expected O, but got I4
		//IL_07ec: Expected O, but got I
		//IL_0480: Expected O, but got Ref
		//IL_048e: Expected O, but got Ref
		//IL_04ab: Expected F4, but got I
		//IL_04d8: Expected O, but got I4
		//IL_0fe8: Expected O, but got I
		//IL_0848: Expected O, but got I
		//IL_12f7: Expected F4, but got O
		//IL_1308: Expected O, but got I4
		//IL_00d9->IL0130: Incompatible stack heights: 4 vs 2
		//IL_01fd->IL0e19: Incompatible stack heights: 4 vs 1
		//IL_0e19->IL11f3: Incompatible stack heights: 8 vs 7
		//IL_0d1b->IL0e6f: Incompatible stack heights: 12 vs 7
		//IL_1202->IL0e19: Incompatible stack heights: 7 vs 1
		//IL_0bf8->IL0bf8: Incompatible stack heights: 8 vs 3
		//IL_1122->IL0906: Incompatible stack heights: 10 vs 5
		//IL_0d32->IL0d32: Incompatible stack heights: 13 vs 0
		//IL_08e4->IL0e6f: Incompatible stack heights: 10 vs 7
		//IL_0b4a->IL0b4a: Incompatible stack heights: 10 vs 5
		//IL_0a48->IL10e5: Incompatible stack heights: 11 vs 10
		//IL_057c->IL0e6f: Incompatible stack heights: 9 vs 7
		//IL_0901->IL0901: Incompatible stack heights: 11 vs 4
		//IL_0f83->IL1202: Incompatible stack heights: 13 vs 8
		//IL_0b49->IL10e5: Incompatible stack heights: 14 vs 10
		//IL_0891->IL0891: Incompatible stack heights: 13 vs 8
		//IL_073a->IL0f3e: Incompatible stack heights: 14 vs 13
		//IL_051d->IL0e1a: Incompatible stack heights: 13 vs 7
		//IL_03f6->IL04dd: Incompatible stack heights: 13 vs 12
		//IL_04dd->IL04dd: Incompatible stack heights: 16 vs 12
		//IL_1315->IL0f3e: Incompatible stack heights: 17 vs 13
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_003CManualCameraTargetControl_003Ek__BackingField != null)
		{
			goto IL_0d32;
		}
		bool flag = _playerOptions == null;
		PlayerOptionsData config = _playerOptions.Config;
		bool flag2 = config == null;
		Vector3 ret;
		object obj4;
		Transform transform;
		object obj3;
		Vector3 vector;
		if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			bool flag3 = (object)GM.Core == null;
			bool flag4 = core._multiplayer == null;
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				Transform freeRoamCameraTarget = GetFreeRoamCameraTarget();
				GameManager coopCameraTarget = (GameManager)(object)_coopCameraTarget;
				bool flag5 = (object)freeRoamCameraTarget == null;
				bool flag6 = ((UnityEngine.Object)freeRoamCameraTarget).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)freeRoamCameraTarget).m_CachedPtr, out ret);
				bool flag7 = (object)_coopCameraTarget == null;
				_ = 0;
				bool flag8 = ((UnityEngine.Object)coopCameraTarget).m_CachedPtr == (IntPtr)0;
				obj3 = 0;
				obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				vector = ret;
				transform = (Transform)(nint)((UnityEngine.Object)coopCameraTarget).m_CachedPtr;
				goto IL_11f3;
			}
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
		bool flag9 = _characters == null;
		if (characters._size <= 1)
		{
			goto IL_0bf8;
		}
		CoopConfig coopConfig = CoopConfig;
		bool flag10 = (object)CoopConfig == null;
		bool flag11 = coopConfig._cameraMode == CoopConfig.CameraMode.AveragePosition;
		GameManager gameManager;
		Transform transform4 = default(Transform);
		object obj9 = default(object);
		if (!flag11)
		{
			object obj5 = coopConfig._cameraMode - 1;
			if (!flag11)
			{
				if ((nint)obj5 != 1)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				ArcadeSprite arcadeSprite = default(ArcadeSprite);
				bool flag12 = (object)arcadeSprite == null;
				arcadeSprite.CheckRenderer();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v103 (ArcadeSprite)+48]");
				bool flag13 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v103 (ArcadeSprite)+48]");
				Bounds bounds = ((Renderer)0).bounds;
				Vector3 center = bounds.m_Center;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1847 @ rax_v105 (UnityEngine.Bounds)+10]");
				float num = 0f;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _characters;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1847 @ rax_v105 (UnityEngine.Bounds)+10]");
				_ = 0;
				_ = bounds.m_Center;
				bool flag14 = _characters == null;
				object obj6 = 0;
				Transform transform2 = (Transform)1;
				Transform transform3 = (Transform)1;
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				ArcadeSprite arcadeSprite2 = default(ArcadeSprite);
				while ((nint)transform3 < characters2._size)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> characters3 = _characters;
					bool flag15 = _characters == null;
					bool flag16 = (nint)transform2 >= characters3._size;
					VampireSurvivors.Objects.Characters.CharacterController[] items = characters3._items;
					bool flag17 = characters3._items == null;
					bool flag18 = (nint)transform2 >= items.Length;
					Renderer renderer = (Renderer)(object)items[(object)transform2];
					bool flag19 = (object)items[(object)transform2] == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v61 (UnityEngine.Renderer)+34E]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag20 = (object)characterController == null;
						if (!characterController.IsDisconnectedFromOnlinePlay)
						{
							bool flag21 = _characters == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							bool flag22 = (object)arcadeSprite2 == null;
							arcadeSprite2.CheckRenderer();
							bool flag23 = (object)arcadeSprite2._spriteRenderer == null;
							Bounds bounds2 = arcadeSprite2._spriteRenderer.bounds;
							Bounds bounds3 = (Bounds)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							Bounds bounds4 = (Bounds)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
							center = bounds2.m_Center;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2671 @ rax_v121 (UnityEngine.Bounds)+10]");
							num = 0f;
							_ = bounds2.m_Center;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2671 @ rax_v121 (UnityEngine.Bounds)+10]");
							_ = 0;
							((Bounds*)bounds4)->Encapsulate(bounds3);
							obj6 = 0;
						}
					}
					characters2 = _characters;
					transform2 = (Transform)(transform2 + 1);
					bool flag24 = _characters == null;
					transform3 = transform2;
				}
				object coopCameraTarget2 = _coopCameraTarget;
				bool flag25 = (object)_coopCameraTarget == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
				vector = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-51]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v933 @ rbx_v35 (System.Object)+10]");
				gameManager = (GameManager)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v933 @ rbx_v35 (System.Object)+10]");
				bool flag26 = (nint)0 == 0;
				obj3 = 0;
			}
			else
			{
				bool flag27 = _characters == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
				bool flag28 = (object)characterController2 == null;
				Transform cameraTarget = characterController2.CameraTarget;
				bool flag29 = (object)cameraTarget == null;
				Vector3 position = cameraTarget.position;
				float x = position.x;
				float num2 = position.z;
				nint num3 = (nint)typeof(Vector3);
				_ = position.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2184 @ rax_v86 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num4 = 0;
				vector = Vector3.zeroVector;
				float num5 = (float)transform4 * 0.5f;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2185 @ rcx_v76 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				float num = 0f * 0.5f;
				List<VampireSurvivors.Objects.Characters.CharacterController> characters4 = _characters;
				bool flag30 = _characters == null;
				float num6 = num;
				float num7 = (float)transform4;
				object obj6 = 0;
				Transform transform5 = (Transform)1;
				Transform transform6 = (Transform)1;
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = default(VampireSurvivors.Objects.Characters.CharacterController);
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = default(VampireSurvivors.Objects.Characters.CharacterController);
				while ((nint)transform6 < characters4._size)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> characters5 = _characters;
					bool flag31 = _characters == null;
					bool flag32 = (nint)transform5 >= characters5._size;
					VampireSurvivors.Objects.Characters.CharacterController[] items2 = characters5._items;
					bool flag33 = characters5._items == null;
					bool flag34 = (nint)transform5 >= items2.Length;
					Transform transform7 = (Transform)(object)items2[(object)transform5];
					bool flag35 = (object)items2[(object)transform5] == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v50 (UnityEngine.Transform)+34E]");
					bool flag36 = (nint)0 == 0;
					float num8 = num6;
					if (!flag36)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag37 = (object)characterController3 == null;
						bool isDisconnectedFromOnlinePlay = characterController3.IsDisconnectedFromOnlinePlay;
						num8 = num6;
						if (!isDisconnectedFromOnlinePlay)
						{
							bool flag38 = _characters == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							bool flag39 = (object)characterController4 == null;
							Transform cameraTarget2 = characterController4.CameraTarget;
							bool flag40 = (object)cameraTarget2 == null;
							Vector3 position2 = cameraTarget2.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
							float num9 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-4D]");
							float num10 = num9 - 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
							object obj7 = num11 - 0;
							float num12 = num2 - num6;
							_ = position2.x;
							if (!(position2.x > num10))
							{
								num10 = position2.x;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
							if (0 <= (nint)obj7)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
								obj7 = 0;
							}
							if (!(position2.z > num12))
							{
								num12 = position2.z;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-4D]");
							float num13 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
							float num14 = num13 + 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
							nint num15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
							object obj8 = num15 + 0;
							float num16 = num2 + num6;
							if (!(num14 > position2.x))
							{
								num14 = position2.x;
							}
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9))
							{
								obj8 = obj9;
							}
							if (!(num16 > position2.z))
							{
								num16 = position2.z;
							}
							float num17 = num14 - num10;
							object obj10 = obj8 - obj7;
							float num18 = num16 - num12;
							float num19 = num17 * 0.5f;
							num5 = (float)obj10 * 0.5f;
							num = num18 * 0.5f;
							num7 = num19 + num10;
							float num20 = num12 + num;
							num8 = num;
							x = (float)transform4;
							num2 = num20;
							obj6 = 0;
							vector = (Vector3)transform4;
						}
					}
					characters4 = _characters;
					transform5 = (Transform)(transform5 + 1);
					bool flag41 = _characters != null;
					num6 = num8;
					transform6 = transform5;
					if (!flag41)
					{
						break;
					}
				}
				object coopCameraTarget3 = _coopCameraTarget;
				bool flag42 = (object)_coopCameraTarget == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1463 @ rbx_v30 (System.Object)+10]");
				gameManager = (GameManager)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1463 @ rbx_v30 (System.Object)+10]");
				bool flag43 = (nint)0 == 0;
				obj3 = 0;
				if ((nint)0 == 0)
				{
					bool flag44 = (nint)0 == 0;
					goto IL_106a;
				}
			}
			goto IL_0e6f;
		}
		goto IL_106a;
		IL_0d32:
		Action action = _003CManualCameraTargetControl_003Ek__BackingField;
		bool flag45 = _003CManualCameraTargetControl_003Ek__BackingField == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v77.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		return;
		IL_11f3:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2447 @ rax_v45 (should have been resolved before IL gen)");
		return;
		IL_0bf8:
		Transform coopCameraTarget4 = _coopCameraTarget;
		bool flag46 = _characters == null;
		bool flag47 = characters._size <= 0;
		VampireSurvivors.Objects.Characters.CharacterController[] items3 = characters._items;
		bool flag48 = characters._items == null;
		bool flag49 = items3.Length <= 0;
		bool flag50 = (object)items3[0] == null;
		Transform cameraTarget3 = items3[0].CameraTarget;
		bool flag51 = (object)cameraTarget3 == null;
		bool flag52 = ((UnityEngine.Object)cameraTarget3).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cameraTarget3).m_CachedPtr, out ret);
		bool flag53 = (object)_coopCameraTarget == null;
		_ = 0;
		gameManager = (GameManager)(nint)((UnityEngine.Object)coopCameraTarget4).m_CachedPtr;
		bool flag54 = ((UnityEngine.Object)coopCameraTarget4).m_CachedPtr == (IntPtr)0;
		obj3 = 0;
		bool flag55 = (nint)0 != 0;
		vector = ret;
		if (!flag55)
		{
			bool flag56 = (nint)0 == 0;
			goto IL_0d32;
		}
		goto IL_0e6f;
		IL_0e6f:
		obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		transform = (Transform)(object)gameManager;
		goto IL_11f3;
		IL_106a:
		nint num21 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1290 @ rax_v65 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num22 = 0;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters6 = _characters;
		Vector3 zeroVector = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1291 @ rcx_v56 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num23 = 0f;
		bool flag57 = _characters == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1291 @ rcx_v56 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num24 = 0f;
		Transform transform8 = null;
		Transform transform9 = null;
		Transform transform10 = null;
		VampireSurvivors.Objects.Characters.CharacterController characterController5 = default(VampireSurvivors.Objects.Characters.CharacterController);
		VampireSurvivors.Objects.Characters.CharacterController characterController6 = default(VampireSurvivors.Objects.Characters.CharacterController);
		Transform transform12 = default(Transform);
		while ((nint)transform10 < characters6._size)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters7 = _characters;
			bool flag58 = _characters == null;
			bool flag59 = (nint)transform9 >= characters7._size;
			VampireSurvivors.Objects.Characters.CharacterController[] items4 = characters7._items;
			bool flag60 = characters7._items == null;
			bool flag61 = (nint)transform9 >= items4.Length;
			Transform transform11 = (Transform)(object)items4[(object)transform9];
			bool flag62 = (object)items4[(object)transform9] == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v39 (UnityEngine.Transform)+34E]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag63 = (object)characterController5 == null;
				if (!characterController5.IsDisconnectedFromOnlinePlay)
				{
					bool flag64 = _characters == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag65 = (object)characterController6 == null;
					Transform cameraTarget4 = characterController6.CameraTarget;
					bool flag66 = (object)cameraTarget4 == null;
					Vector3 position3 = cameraTarget4.position;
					float num = position3.x;
					float num5 = num24 + position3.z;
					_ = position3.x;
					float num20 = (float)Vector3.zeroVector + position3.x;
					float num7 = (float)obj9 + (float)transform4;
					transform8 = (Transform)(transform8 + 1);
					num24 = num5;
					num23 = num5;
					zeroVector = (Vector3)transform4;
					object obj6 = 0;
					transform12 = transform4;
				}
			}
			characters6 = _characters;
			transform9 = (Transform)(transform9 + 1);
			bool flag67 = _characters != null;
			transform10 = transform9;
			if (!flag67)
			{
				break;
			}
		}
		if ((nint)transform8 > 0)
		{
			float num = (float)obj9 / (float)transform8;
			float num5 = num24 / (float)transform8;
			num23 = num5;
			zeroVector = (Vector3)transform4;
			transform12 = transform8;
		}
		object coopCameraTarget5 = _coopCameraTarget;
		bool flag68 = (object)_coopCameraTarget == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1594 @ rbx_v26 (System.Object)+10]");
		gameManager = (GameManager)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1594 @ rbx_v26 (System.Object)+10]");
		bool flag69 = (nint)0 == 0;
		obj3 = 0;
		bool flag70 = (nint)0 != 0;
		vector = (Vector3)transform12;
		if (!flag70)
		{
			bool flag71 = (nint)0 == 0;
			goto IL_0bf8;
		}
		goto IL_0e6f;
	}

	public unsafe float AveragePlayerCurse()
	{
		//IL_0108: Expected F4, but got I4
		//IL_01fb: Expected F4, but got O
		//IL_0203: Expected O, but got Ref
		//IL_011c: Expected F4, but got O
		//IL_00cc: Expected I, but got O
		bool flag = _multiplayer == null;
		MultiplayerManager multiplayerManager = (MultiplayerManager)(object)this;
		if (!flag)
		{
			int playerCount = _multiplayer.GetPlayerCount();
			bool flag2 = playerCount > 1;
			multiplayerManager = _multiplayer;
			if (!flag2)
			{
				bool isOnlineMultiplayer = _multiplayer.IsOnlineMultiplayer;
				multiplayerManager = _multiplayer;
				if (!isOnlineMultiplayer)
				{
					GameSessionData gameSessionData = _gameSessionData;
					bool flag3 = _gameSessionData == null;
					multiplayerManager = _multiplayer;
					if (!flag3)
					{
						multiplayerManager = (MultiplayerManager)(object)gameSessionData._activeCharacter;
						if ((object)gameSessionData._activeCharacter != null)
						{
							nint num = (nint)multiplayerManager;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v368 @ rdx_v13 (Il2CppClass<VampireSurvivors.Framework.MultiplayerManager>)+4C8] (should have been resolved before IL gen)");
							float result = default(float);
							return result;
						}
					}
					goto IL_016c;
				}
			}
			if (_characters != null)
			{
				float num2 = 0f;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				float result;
				if (enumerator.MoveNext())
				{
					MultiplayerManager multiplayerManager2 = null;
					result = (float)_characters;
					multiplayerManager = null;
					throw new NullReferenceException();
				}
				List<VampireSurvivors.Objects.Characters.CharacterController> characters = _characters;
				bool flag4 = _characters == null;
				result = (float)_characters;
				multiplayerManager = (MultiplayerManager)(&enumerator);
				if (!flag4)
				{
					return num2 / (float)characters._size;
				}
			}
		}
		goto IL_016c;
		IL_016c:
		throw new NullReferenceException();
	}

	public bool HasAPlayerGotRevivals()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator mainCharacters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)_mainCharacters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			GameManager gameManager = null;
			GameManager gameManager2 = null;
			throw new NullReferenceException();
		}
		return false;
	}

	public unsafe double GetMaxReviveCount()
	{
		//IL_0031: Expected F8, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0051: Expected F8, but got O
		//IL_0059: Expected O, but got Ref
		double result = 0.0;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)_characters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)0;
			double num = (double)characters;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return result;
	}

	public float GetDefangChanceFromArray()
	{
		//IL_0053: Expected O, but got I
		//IL_0065: Expected F4, but got I
		List<float> defangChancesArray = _defangChancesArray;
		int defangIndex = _defangIndex + 1;
		_defangIndex = defangIndex;
		int defangIndex2 = _defangIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)defangIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v50 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public bool HasRandomazzoEnabled()
	{
		//IL_01d2: Expected I4, but got O
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CSelectedMazzo_003Ek__BackingField)
				{
					goto IL_0070;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null)
					{
						List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
						if (config2._003CCollectedItems_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								object obj = default(object);
								if ((nint)obj != -1)
								{
									return true;
								}
							}
							if (_playerOptions != null)
							{
								PlayerOptionsData config3 = _playerOptions.Config;
								if (config3 != null)
								{
									List<ItemType> list2 = config3._003CCollectedItems_003Ek__BackingField;
									if (config3._003CCollectedItems_003Ek__BackingField != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											object obj3 = default(object);
											object obj2 = obj3 - -1;
											bool flag = obj2 == null;
											return !flag;
										}
										goto IL_0070;
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0070:
		return false;
	}

	public float GetKillRatio()
	{
		//IL_000b: Invalid comparison between F4 and I4
		//IL_0024: Expected F4, but got I4
		bool flag = _003CSurvivedSeconds_003Ek__BackingField == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001877BDDCBh\"");
		float result = 0f;
		if (!flag)
		{
			PlayerOptionsData config = _playerOptions.Config;
			result = (float)config._003CRunEnemies_003Ek__BackingField / _003CSurvivedSeconds_003Ek__BackingField;
		}
		return result;
	}

	public unsafe List<VampireSurvivors.Objects.Characters.CharacterController> GetFollowers(VampireSurvivors.Objects.Characters.CharacterController followedCharacter)
	{
		//IL_0293: Expected I, but got O
		//IL_0056: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_00aa: Expected O, but got I4
		Array followerCache = (Array)(object)_followerCache;
		bool flag = _followerCache == null;
		nint num = (nint)_followerCache;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v7 (System.Array)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v7 (System.Array)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v7 (System.Array)+10]");
				followerCache = (Array)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v7 (System.Array)+10]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v7 (System.Array)+18]");
				Array.Clear((Array)num2, 0, 0);
			}
			if (_characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					num = (nint)(&enumerator);
					throw new NullReferenceException();
				}
				return _followerCache;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void DoRemovePowersEffect(List<string> frames, List<string> textureNames = null, float scale = 1f, float2? center = null)
	{
		//IL_005d: Expected F4, but got O
		//IL_006d: Expected F4, but got I
		//IL_009a: Expected F4, but got I
		//IL_00aa: Expected F4, but got I
		//IL_0297: Expected O, but got Ref
		//IL_035e: Expected I4, but got O
		//IL_0364: Expected O, but got I
		//IL_036c: Expected I4, but got O
		_003C_003Ec__DisplayClass712_0 obj = new _003C_003Ec__DisplayClass712_0();
		obj.scale = scale;
		int size = frames._size;
		float num = (float)Math.PI * 2f / (float)frames._size;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float x = (float)renderer.screenCenter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v8 (PhaserScene+Renderer)+38]");
		float y = 0f;
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ stack_28+4]");
			x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ stack_28+8]");
			y = 0f;
		}
		int num2 = 0;
		List<string> list = textureNames;
		Vector2 vector = default(Vector2);
		string textureName = default(string);
		string spriteName = default(string);
		int num8 = default(int);
		TweenerCore<Vector3, Vector3, VectorOptions> t = default(TweenerCore<Vector3, Vector3, VectorOptions>);
		Tween gameId = default(Tween);
		for (int num3 = 0; num3 < frames._size; num3 = num2)
		{
			_003C_003Ec__DisplayClass712_1 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass712_1();
			CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals1 = obj;
			if (textureNames != null && textureNames._size > num2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			SpriteRenderer s = RenderingExtensions.AddSprite(this, x, y, vector, textureName, spriteName);
			CS_0024_003C_003E8__locals17.s = s;
			_003C_003Ec__DisplayClass712_0 obj3 = CS_0024_003C_003E8__locals17.CS_0024_003C_003E8__locals1;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(CS_0024_003C_003E8__locals17.s, obj3.scale);
			CS_0024_003C_003E8__locals17.s.enabled = false;
			CS_0024_003C_003E8__locals17.s.sortingOrder = 5000;
			Transform transform = CS_0024_003C_003E8__locals17.s.transform;
			transform.SetParent(null, worldPositionStays: true);
			Transform transform2 = CS_0024_003C_003E8__locals17.s.transform;
			Vector3 localPosition = transform2.localPosition;
			float num4 = (float)num2 * num;
			float num5 = num4 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num6 = (float)num2 * num;
			float num7 = num6 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			CS_0024_003C_003E8__locals17.index = num2;
			Transform target = CS_0024_003C_003E8__locals17.s.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMove(target, (Vector3)(&num8), 0.5f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			float num9 = (float)num2 * 100f;
			float num10 = num9 + 800f;
			float delay = num10 * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, delay);
			TweenCallback tweenCallback = delegate
			{
				CS_0024_003C_003E8__locals17.s.enabled = true;
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5360");
			TweenCallback tweenCallback2 = delegate
			{
				//IL_002b: Expected O, but got Ref
				Transform target2 = CS_0024_003C_003E8__locals17.s.transform;
				object obj4 = default(object);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target2, (Vector3)(&obj4), 0.5f);
				if (tweenerCore3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
				float num11 = (float)CS_0024_003C_003E8__locals17.index + 1100f;
				float delay2 = num11 * 0.001f;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(tweenerCore3, delay2);
				TweenCallback tweenCallback3 = CS_0024_003C_003E8__locals17._003C_003E9__2;
				if (CS_0024_003C_003E8__locals17._003C_003E9__2 == null)
				{
					tweenCallback3 = (CS_0024_003C_003E8__locals17._003C_003E9__2 = delegate
					{
						CS_0024_003C_003E8__locals17.s.enabled = false;
					});
				}
				if (tweenerCore4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
			Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
			num2++;
			num8 = (int)vector;
			list = (List<string>)0;
			size = (int)vector;
		}
	}

	public void ClearCurrentCustomMerchant()
	{
		_003CCurrentCustomMerchant_003Ek__BackingField = null;
	}

	public unsafe VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllerFromType(CharacterType type)
	{
		//IL_0017: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe VampireSurvivors.Objects.Characters.CharacterController GetCharacterFromRewiredPlayer(Player player)
	{
		//IL_0017: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public GameManager()
	{
		List<PickupToSpawn> gemsToSpawn = new List<PickupToSpawn>();
		_gemsToSpawn = gemsToSpawn;
		List<PickupToSpawn> coinsToSpawn = new List<PickupToSpawn>();
		_coinsToSpawn = coinsToSpawn;
		List<PickupToSpawn> redCoinBagsToSpawn = new List<PickupToSpawn>();
		_redCoinBagsToSpawn = redCoinBagsToSpawn;
		List<PickupToSpawn> frozenSoulsToSpawn = new List<PickupToSpawn>();
		_frozenSoulsToSpawn = frozenSoulsToSpawn;
		List<UiTransition> queuedUiTransitions = new List<UiTransition>();
		_queuedUiTransitions = queuedUiTransitions;
		List<Pickup> stagePickups = new List<Pickup>();
		_stagePickups = stagePickups;
		List<MapToken> mapTokens = new List<MapToken>();
		_mapTokens = mapTokens;
		Queue<Light2D> candleLights = new Queue<Light2D>();
		_candleLights = candleLights;
		Dictionary<Destructible, Light2D> candleLightsMapping = new Dictionary<Destructible, Light2D>();
		_candleLightsMapping = candleLightsMapping;
		HashSet<Pickup> gems = (HashSet<Pickup>)(object)new HashSet<object>();
		_gems = gems;
		HashSet<Coin> coins = (HashSet<Coin>)(object)new HashSet<object>();
		_coins = coins;
		HashSet<CoinBag1> redCoinBags = (HashSet<CoinBag1>)(object)new HashSet<object>();
		_redCoinBags = redCoinBags;
		HashSet<Pickup_Bonus_FrozenSoul> frozenSouls = (HashSet<Pickup_Bonus_FrozenSoul>)(object)new HashSet<object>();
		_frozenSouls = frozenSouls;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_characters = characters;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_mainCharacters = mainCharacters;
		List<VampireSurvivors.Objects.Characters.CharacterController> charactersLevelingUp = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_charactersLevelingUp = charactersLevelingUp;
		_nextLevelUpAtLevel = 1;
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<FollowerEnemy_CharacterController>> enemyFollowerPools = new Dictionary<VampireSurvivors.Objects.Characters.CharacterController, List<FollowerEnemy_CharacterController>>();
		m_EnemyFollowerPools = enemyFollowerPools;
		Dictionary<VampireSurvivors.Objects.Characters.CharacterController, int> numAliveEnemyFollowers = new Dictionary<VampireSurvivors.Objects.Characters.CharacterController, int>();
		m_NumAliveEnemyFollowers = numAliveEnemyFollowers;
		_003CCanInterrupt_003Ek__BackingField = true;
		_003CSurvarotsCardsToShow_003Ek__BackingField = 4;
		_003CCanShowGameOverRewardAd_003Ek__BackingField = true;
		_003CWeaponSelectionType_003Ek__BackingField = "normal";
		List<bool> cachedCharacterValidity = new List<bool>();
		_cachedCharacterValidity = cachedCharacterValidity;
		List<VampireSurvivors.Objects.Characters.CharacterController> followerCache = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_followerCache = followerCache;
		_bossHealthMultiplier = 1f;
		_bossAttacksTriggerChance = 1f;
		base._onResumeSent = true;
	}

	private void _003CInitiateGameplayPreload_003Eb__416_0()
	{
		//IL_002a: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		Debug.Log("Gameplay preload completed. Initiating gameplay load...");
		MasterObjectPooler masterObjectPooler = MasterObjectPooler._003CInstance_003Ek__BackingField;
		ObjectPool[] pools = masterObjectPooler._pools;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < pools.Length)
		{
			ObjectPool objectPool = pools[obj];
			objectPool._003CInitialized_003Ek__BackingField = true;
			objectPool.AutoFillName();
			objectPool.Populate(objectPool._defaultSize);
			obj++;
			obj2 = obj;
		}
		GeneratePickupVfx();
		InitializeGameSession();
		Action onComplete = delegate
		{
			Debug.Log("Gameplay load completed. Initializing game session...");
			InitializeGameSessionPostLoad();
			AspectMask aspectMask = AspectMask._003CInstance_003Ek__BackingField;
			if ((object)AspectMask._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)aspectMask).m_CachedPtr != (IntPtr)0)
			{
				AspectMask aspectMask2 = AspectMask._003CInstance_003Ek__BackingField;
				AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Top, true);
				AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Bottom, true);
				AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Left, true);
				AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Right, true);
			}
			if (!_multiplayer.IsOnlineMultiplayer)
			{
				_Preloader.SetActive(value: false);
			}
		};
		_gameplayLoader.Load(onComplete);
	}

	private void _003CInitiateGameplayPreload_003Eb__416_1()
	{
		Debug.Log("Gameplay load completed. Initializing game session...");
		InitializeGameSessionPostLoad();
		AspectMask aspectMask = AspectMask._003CInstance_003Ek__BackingField;
		if ((object)AspectMask._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)aspectMask).m_CachedPtr != (IntPtr)0)
		{
			AspectMask aspectMask2 = AspectMask._003CInstance_003Ek__BackingField;
			AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Top, true);
			AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Bottom, true);
			AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Left, true);
			AspectMask._003CInstance_003Ek__BackingField.SetImageEnabled(aspectMask2._Right, true);
		}
		if (!_multiplayer.IsOnlineMultiplayer)
		{
			_Preloader.SetActive(value: false);
		}
	}

	private void _003CRestartGameScene_003Eb__445_0()
	{
		GoToPreloadScene();
	}

	private bool _003CPullRandomChestWinner_003Eb__518_1(VampireSurvivors.Objects.Characters.CharacterController c)
	{
		//IL_0090: Expected I4, but got O
		if (_levelUpFactory != null)
		{
			bool flag = _levelUpFactory.HasPotentialEvolution(c);
			if (!flag)
			{
				return flag;
			}
			if ((object)c != null)
			{
				bool isDisconnectedFromOnlinePlay = c.IsDisconnectedFromOnlinePlay;
				return (byte)((isDisconnectedFromOnlinePlay ? 1u : 0u) ^ 1u) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
