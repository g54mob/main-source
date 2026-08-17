using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundCarloCart : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SuperObject, bool> _003C_003E9__35_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CCreate_003Eb__35_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3B4A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "GoalPosition";
					if ((object)o.m_TiledName != "GoalPosition")
					{
						if ("GoalPosition" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("GoalPosition" + 20);
								ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public string texture;

		internal void _003CCustomPreload_003Eb__0(Action cb)
		{
			//IL_0029: Expected I4, but got O
			_003C_003Ec__DisplayClass42_1 obj = new _003C_003Ec__DisplayClass42_1();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_1)(object)action)._003CCustomPreload_003Eb__1((byte)(int)obj != 0);
			GameManager core = GM.Core;
			string customCacheGroup = default(string);
			CharacterLoader.LoadCharacterTextureAsync(texture, CharacterType.GYORUNTIN, action, core._dataManager, customCacheGroup);
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_1
	{
		public Action cb;

		internal void _003CCustomPreload_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass55_0
	{
		public VampireSurvivors.Objects.Characters.CharacterController player;

		internal unsafe void _003COnItemTriggered_003Eb__0()
		{
			//IL_00b0: Expected O, but got Ref
			//IL_00da: Expected O, but got I4
			//IL_0109: Expected F4, but got O
			VampireSurvivors.Objects.Characters.CharacterController characterController = player;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CGrowth_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 0.05f;
			playerStats._003CGrowth_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("Crown", "5", (Color?)(object)(&obj), characterController2, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 2400f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, (float)characterController2);
		}

		internal unsafe void _003COnItemTriggered_003Eb__1()
		{
			//IL_00b0: Expected O, but got Ref
			//IL_00da: Expected O, but got I4
			//IL_0109: Expected F4, but got O
			VampireSurvivors.Objects.Characters.CharacterController characterController = player;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CGreed_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 0.05f;
			playerStats._003CGreed_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("Mask", "5", (Color?)(object)(&obj), characterController2, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 2800f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, (float)characterController2);
		}

		internal unsafe void _003COnItemTriggered_003Eb__2()
		{
			//IL_00b0: Expected O, but got Ref
			//IL_00da: Expected O, but got I4
			//IL_0109: Expected F4, but got O
			VampireSurvivors.Objects.Characters.CharacterController characterController = player;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CCurse_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 0.05f;
			playerStats._003CCurse_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("Curse", "5", (Color?)(object)(&obj), characterController2, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 3200f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, (float)characterController2);
			GameManager core2 = GM.Core;
			core2._stage.RecalculateCurseAndCharm();
		}

		internal unsafe void _003COnItemTriggered_003Eb__3()
		{
			//IL_00b0: Expected O, but got Ref
			//IL_00da: Expected O, but got I4
			//IL_0109: Expected F4, but got O
			VampireSurvivors.Objects.Characters.CharacterController characterController = player;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 0.05f;
			playerStats._003CMoveSpeed_003Ek__BackingField = eggFloat2;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("Wing", "5", (Color?)(object)(&obj), characterController2, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 3600f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, (float)characterController2);
		}

		internal unsafe void _003COnItemTriggered_003Eb__4()
		{
			//IL_00cd: Expected O, but got Ref
			//IL_00f7: Expected O, but got I4
			//IL_0126: Expected F4, but got O
			VampireSurvivors.Objects.Characters.CharacterController characterController = player;
			MagnetZone magnet = characterController._magnet;
			EggFloat radius = magnet.Radius;
			float value = default(float);
			EggFloat radius2 = new EggFloat(value, radius._eggVal);
			value = radius._val + 5f;
			magnet.Radius = radius2;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = player;
			characterController2._magnet.RefreshSize();
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			core._gizmoManager.DisplayIconOverhead("OrbGlow", "5", (Color?)(object)(&obj), characterController3, displayTimeMultiplier, vOffset, textureName);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = 4000f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Groove, soundConfig, 150f, 3, (float)characterController3);
		}
	}

	protected float2 CartOffset;

	private Vector2 _initialOffset;

	private TileSprite fb_bg_hw_Back;

	private TileSprite fb_bg_hw_Front;

	private TileSprite rainbowRoad;

	private float _speedFactor;

	private float _accelerationMul;

	private bool isFirstUpdate;

	private List<PhaserSprite> _frontCartSprites;

	private List<PhaserSprite> _backCartSprites;

	private List<float2> _cartOffsets;

	private PickupCoffin secretCoffin;

	private bool canSpawnSecretCoffin;

	private bool _isAccelerated;

	private float _accelTime;

	private float _accelDuration;

	private float _distanceTravelled;

	private int _loopLength;

	private int _loopsDone;

	private float _nextLoopDist;

	private TilingTileset _tilingTileset;

	private List<Vector2> _accelLocations;

	private Timer _accelSpawnTimer;

	private float _accelSpawnFrequency;

	private float2 _GoalPosition;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _glitchEmitter;

	private ParticleSystem _glitchEmitter2;

	private float _savedTimeScale;

	private bool _wasPaused;

	private float _initialTimeScale;

	private float _inversionMul;

	private MapToken _mapToken;

	private float _playerStartX;

	private bool _canSpawnGoal;

	public unsafe override void Create()
	{
		//IL_0131: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_01ac: Expected O, but got I4
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected F4, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected F4, but got Unknown
		//IL_03e8: Expected O, but got F4
		//IL_04ae: Expected O, but got I
		//IL_0a50: Expected I4, but got O
		//IL_0a5c: Expected F4, but got I4
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected O, but got Unknown
		//IL_0ae2: Expected I4, but got I8
		base.Create();
		Delegate obj2;
		if (!GM.Core.IsStageHost)
		{
			Action<Pickup> b = OnRemoteItemInstantiated;
			Delegate obj = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b);
			if ((object)obj == null)
			{
				ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj;
				obj2 = obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<Pickup> action = default(Action<Pickup>);
				bool flag = action == null;
				obj2 = obj;
				if (flag)
				{
					throw new InvalidCastException();
				}
				ItemInstantiator.OnRemoteItemInstantiated = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				bool flag2 = obj3 == null;
				obj2 = obj;
				if (flag2)
				{
					goto IL_08ee;
				}
				obj2 = null;
			}
		}
		else
		{
			obj2 = null;
		}
		bool flag3 = GM.Core.IsStageVisuallyInverted();
		object obj4 = (flag3 ? 1 : 0) ^ 1;
		object obj5 = obj4 * 2;
		float inversionMul = (float)obj5 - 1f;
		_inversionMul = inversionMul;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BD8870");
		float initialTimeScale = default(float);
		_initialTimeScale = initialTimeScale;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BD8870");
		float savedTimeScale = default(float);
		_savedTimeScale = savedTimeScale;
		bool flag4 = GM.Core.IsStageVisuallyInverted();
		object obj6 = (flag4 ? 1 : 0) ^ 1;
		object obj7 = obj6 * 4;
		object obj8 = obj6 + obj7;
		object obj9 = obj8 << 4;
		float num = (_pickupLimitX = 40f - (float)obj9);
		_pickupRecycleOffset = 40f;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		_tilingTileset = stage._tilingTileset;
		RacingBoundsMinY = -20.8f;
		RacingBoundsMaxY = -18f;
		RacingBoundsFlyingEnemiesY = -16f;
		List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("Racing_Bounds_Min_Y");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v795 @ rax_v29 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		object obj10 = default(object);
		float num2;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			float racingBoundsMinY = obj10 ^ -0f;
			RacingBoundsMinY = racingBoundsMinY;
			num2 = -0f;
		}
		else
		{
			num2 = -0f;
			float racingBoundsMinY = num;
		}
		List<Vector2> specialLocations2 = _tilingTileset.GetSpecialLocations("Racing_Bounds_Max_Y");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v31 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			float racingBoundsMaxY = obj10 ^ num2;
			RacingBoundsMaxY = racingBoundsMaxY;
		}
		TilingTileset tilingTileset = _tilingTileset;
		Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__35_0;
		if (_003C_003Ec._003C_003E9__35_0 == null)
		{
			predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__35_0 = delegate(SuperObject o)
			{
				//IL_0144: Expected I4, but got O
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Expected Ref, but got Unknown
				//IL_00fd: Expected I8, but got I4
				//IL_010b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0110: Expected Ref, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3B4A]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if ((object)o != null)
				{
					string tiledName = o.m_TiledName;
					if (o.m_TiledName != null)
					{
						object obj15 = "GoalPosition";
						if ((object)o.m_TiledName != "GoalPosition")
						{
							if ("GoalPosition" != null)
							{
								int stringLength = tiledName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
								if ((nint)stringLength == 0)
								{
									ref byte second = ref *(byte*)("GoalPosition" + 20);
									ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
									return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
								}
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			});
		}
		object obj11 = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1389 @ rax_v37 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				Transform transform = ((Component)obj11).transform;
				Vector3 position = transform.position;
				Transform transform2 = ((Component)obj11).transform;
				Vector3 position2 = transform2.position;
				_GoalPosition = (float2)position.x;
				_ = position2.y;
			}
		}
		List<Vector2> accelLocations = _accelLocations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v33 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
		_ = (nint)0 + (nint)1;
		List<Vector2> specialLocations3 = _tilingTileset.GetSpecialLocations("AccelPosition");
		_accelLocations = specialLocations3;
		List<PhaserSprite> frontCartSprites = new List<PhaserSprite>();
		_frontCartSprites = frontCartSprites;
		List<PhaserSprite> backCartSprites = new List<PhaserSprite>();
		_backCartSprites = backCartSprites;
		List<float2> cartOffsets = new List<float2>();
		_cartOffsets = cartOffsets;
		VampireSurvivors.Objects.Characters.CharacterController characterController = null;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = enumerator2;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator3 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator4 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator3.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundCarloCart)+84]");
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)0;
			SpawnCartForCharacter(null, (float2)enumerator4);
			enumerator = enumerator4;
		}
		GameManager core2 = GM.Core;
		PlayerOptions playerOptions = core2._playerOptions;
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
						goto IL_09f3;
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
		goto IL_09f3;
		IL_0a2a:
		PlayerOptionsData playerOptionsData2;
		List<CharacterType> list = playerOptionsData2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rcx_v99 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 == 0)
		{
			goto IL_0714;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj13 = default(object);
		object obj12 = obj13 - -1;
		bool flag5 = obj12 == null;
		bool flag6 = flag5;
		goto IL_0a3c;
		IL_08ee:
		throw new InvalidCastException();
		IL_0714:
		flag6 = true;
		goto IL_0a3c;
		IL_09f3:
		List<CharacterType> list2 = playerOptionsData._003COpenedCoffins_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj14 = default(object);
			if ((nint)obj14 != -1)
			{
				GameManager core3 = GM.Core;
				PlayerOptions playerOptions2 = core3._playerOptions;
				if (playerOptions2._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions2._hostGameConfig == null)
					{
						if (playerOptions2._currentAdventureSaveData != null)
						{
							playerOptionsData2 = playerOptions2._currentAdventureSaveData;
							if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0a2a;
							}
						}
						playerOptionsData2 = playerOptions2._mainGameConfig;
					}
					else
					{
						playerOptionsData2 = playerOptions2._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
				}
				goto IL_0a2a;
			}
		}
		goto IL_0714;
		IL_0a3c:
		canSpawnSecretCoffin = flag6;
		_loopsDone = (int)obj2;
		_nextLoopDist = _loopLength;
		MakeEmitters();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		float num3 = renderer2.height * 0.85f;
		float y = num3 - 1f;
		float x = renderer.width * 0.5f;
		float height = default(float);
		string textureName = default(string);
		string spriteName = default(string);
		TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, renderer3.width, height, textureName, spriteName);
		TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
		object spriteRenderer = tileSprite._spriteRenderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdi_v12 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdi_v12 (System.Object)+10]");
			Renderer.set_sortingOrder_Injected((IntPtr)0, -1999);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(tileSprite._spriteRenderer, 0.15f);
			GameObject gameObject = tileSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName("rainbowRoad");
			rainbowRoad = tileSprite;
			TileSprite tileSprite2 = rainbowRoad.SetTileScale(32f, (float?)obj2);
			TileSprite tileSprite3 = rainbowRoad;
			Material material = MaterialManager.GetMaterial(MaterialType.ScrollableSpriteAdditive);
			((Renderer)tileSprite3._spriteRenderer).SetMaterial(material);
			TileSprite tileSprite4 = rainbowRoad;
			tileSprite4._spriteRenderer.enabled = false;
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(spriteRenderer);
		goto IL_08ee;
	}

	private void SpawnCartForCharacter(VampireSurvivors.Objects.Characters.CharacterController character, float2 offset)
	{
		//IL_01a3: Expected O, but got I4
		//IL_01f2: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		float2 item;
		List<float2> cartOffsets;
		if (!character.NeedsCart)
		{
			List<object> frontCartSprites = (List<object>)(object)_frontCartSprites;
			int version = frontCartSprites._version + 1;
			frontCartSprites._version = version;
			object[] items = frontCartSprites._items;
			if (frontCartSprites._size >= items.Length)
			{
				frontCartSprites.AddWithResize((object)null);
			}
			else
			{
				int size = frontCartSprites._size + 1;
				frontCartSprites._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<object> backCartSprites = (List<object>)(object)_backCartSprites;
			int version2 = backCartSprites._version + 1;
			backCartSprites._version = version2;
			object[] items2 = backCartSprites._items;
			if (backCartSprites._size >= items2.Length)
			{
				backCartSprites.AddWithResize((object)null);
			}
			else
			{
				int size2 = backCartSprites._size + 1;
				backCartSprites._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			item = (float2)0;
			cartOffsets = _cartOffsets;
		}
		else
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite = instance.AddPhaserSprite((Vector2)0, "enemies2023", "CarloCartFront");
			GameObject gameObject = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject).SetName("_frontCartSprite");
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite2 = instance2.AddPhaserSprite((Vector2)0, "enemies2023", "CarloCartBack");
			GameObject gameObject2 = phaserSprite2.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_backCartSprite");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA12D0");
			item = offset;
			cartOffsets = _cartOffsets;
		}
		cartOffsets.Add(item);
	}

	private void OnRemoteItemInstantiated(Pickup item)
	{
		//IL_0038: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_011a: Expected I4, but got I8
		//IL_00d0: Expected O, but got I4
		//IL_008c: Expected O, but got I
		//IL_00c2: Expected O, but got I4
		object obj3;
		if (item._003CPickupType_003Ek__BackingField == ItemType.COFFIN)
		{
			nint num = (nint)typeof(PickupCoffin);
			nint num2 = (nint)item;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v3 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v18+FFFFFFF8+v58 @ rax_v6*8]");
				if (0 == (nint)typeof(PickupCoffin))
				{
					obj3 = 1;
					goto IL_011f;
				}
			}
			obj3 = 0;
			goto IL_011f;
		}
		if (item._003CPickupType_003Ek__BackingField == ItemType.CART_GOAL)
		{
			ArcadeSprite arcadeSprite = item.setDepth(-1999);
		}
		return;
		IL_011f:
		bool flag = obj3 == null;
		Pickup pickup = null;
		if (!flag)
		{
			pickup = item;
		}
		secretCoffin = (PickupCoffin)pickup;
	}

	public override void OnInitCompleted()
	{
		//IL_00aa: Expected O, but got I4
		//IL_00aa: Expected I4, but got F4
		base.OnInitCompleted();
		float num = default(float);
		bool flag = default(bool);
		GM.Core.SetHardBoundsMinMax(-3.4028235E+38f, 1800f, 3.4028235E+38f, num, flag);
		if (_accelSpawnTimer != null)
		{
			_accelSpawnTimer.Cancel();
		}
		Action onComplete = TryToSpawnAccel;
		float duration = _accelSpawnFrequency * 0.001f;
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer accelSpawnTimer = Timers.Register(duration, onComplete, null, isLooped: true, (byte)(int)num != 0, (MonoBehaviour)flag, repeat, type, isOnlineTimer: false, canPause: false);
		_accelSpawnTimer = accelSpawnTimer;
		OnPlayerEnteringDifferentTilemap();
	}

	public void TryToSpawnAccel()
	{
		//IL_0182->IL0102: Incompatible stack heights: 1 vs 0
		//IL_00ac->IL0102: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL0102: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && (object)core2._stage != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA41C0");
						if ((object)GM.Core != null)
						{
							Vector2 pos = default(Vector2);
							float value = default(float);
							ItemType relicType = default(ItemType);
							bool validatePickups = default(bool);
							Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.CART_ACCEL, WeaponType.VOID, value, relicType, validatePickups);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		Action<Pickup> value = OnRemoteItemInstantiated;
		Delegate obj = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value);
		if ((object)obj == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<Pickup> action = default(Action<Pickup>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			ItemInstantiator.OnRemoteItemInstantiated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				throw new InvalidCastException();
			}
		}
		base.OnDestroy();
	}

	protected override void OnUpdate()
	{
		//IL_085b: Expected O, but got I4
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_012c: Expected O, but got I4
		//IL_0322: Invalid comparison between F4 and I4
		//IL_01e1: Expected O, but got I
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_0395: Invalid comparison between I4 and F4
		//IL_0780: Expected F4, but got O
		//IL_0373: Invalid comparison between F4 and O
		//IL_03e6: Invalid comparison between O and F4
		//IL_04eb: Expected O, but got I4
		//IL_0586: Expected I, but got O
		//IL_0594: Expected I, but got O
		//IL_05a4: Expected O, but got I
		//IL_0624: Expected O, but got I4
		//IL_05e0: Expected O, but got I
		//IL_0616: Expected O, but got I4
		base.OnUpdate();
		if (isFirstUpdate)
		{
			isFirstUpdate = false;
			ProCamera2D instance = ProCamera2D.Instance;
			instance.FollowVertical = false;
		}
		if (PauseSystem._paused)
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = _accelerationMul * _speedFactor;
		float num2 = num * _inversionMul;
		GameManager core = GM.Core;
		float num3 = deltaTime * num2;
		float num4 = num3 * 60f;
		Stage stage = core._stage;
		stage._tilingTileset.MoveTilesetForHorizontalRoad(num4);
		bool flag = PauseSystem._paused;
		float num5 = num4;
		object obj = 0;
		float2 float5 = default(float2);
		if (!flag)
		{
			TileSprite tileSprite = rainbowRoad;
			float num6 = num4 * 0.0064f;
			num5 = (tileSprite._xScrollOffset = num6 + tileSprite._xScrollOffset);
			tileSprite._spriteScroller.SetScrollOffsetX(num5);
			GM.Core.MovePickupsAndDestructibles(float5);
			obj = 0;
		}
		MoveCarts();
		float deltaTime2 = PauseSystem.DeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num4 & 0;
		float num7 = (float)obj2 * 6.4f;
		float num8 = deltaTime2 * 1000f;
		float distanceTravelled = num7 + _distanceTravelled;
		_distanceTravelled = distanceTravelled;
		if (_canSpawnGoal)
		{
			float distanceTravelled2 = GetDistanceTravelled();
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rcx_v82 (VampireSurvivors.Objects.Stage)+138]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rcx_v82 (VampireSurvivors.Objects.Stage)+138]");
			object obj3 = num9 + 0;
			object obj4 = obj3 & -2147483649L;
			num5 = (float)obj4 * 100f;
			float num10 = _nextLoopDist - num5;
			bool flag2 = !(distanceTravelled2 > num10);
			float num11 = distanceTravelled2;
			if (!flag2)
			{
				SpawnGoal();
				num11 = distanceTravelled2;
			}
		}
		if (_isAccelerated)
		{
			MoveEnemies();
			if (!((_accelTime = num8 + _accelTime) < _accelDuration))
			{
				Time.timeScale = (float)this;
				_isAccelerated = false;
				_accelerationMul = 1f;
				_glitchEmitter.Stop();
				_glitchEmitter2.Stop();
			}
		}
		if (!canSpawnSecretCoffin)
		{
			return;
		}
		float num12 = _inversionMul * -40.96f;
		float num13 = num12 + _playerStartX;
		if (_inversionMul > 0f)
		{
			GameManager core3 = GM.Core;
			GameSessionData gameSessionData = core3._gameSessionData;
			float2 position = gameSessionData._activeCharacter.position;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num13) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
			{
				goto IL_03fa;
			}
		}
		if (0f > _inversionMul)
		{
			GameManager core4 = GM.Core;
			GameSessionData gameSessionData2 = core4._gameSessionData;
			float2 position2 = gameSessionData2._activeCharacter.position;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num13))
			{
				goto IL_03fa;
			}
			return;
		}
		return;
		IL_07d0:
		object obj5;
		bool flag3 = obj5 == null;
		Pickup pickup = null;
		Pickup pickup2;
		if (!flag3)
		{
			pickup = pickup2;
		}
		goto IL_07b7;
		IL_07b7:
		secretCoffin = (PickupCoffin)pickup;
		PickupCoffin pickupCoffin = secretCoffin;
		if ((object)secretCoffin != null && ((UnityEngine.Object)pickupCoffin).m_CachedPtr != (IntPtr)0)
		{
			secretCoffin.SetChar(CharacterType.GYORUNTIN);
			PickupCoffin pickupCoffin2 = secretCoffin;
			((PickupGuarded)pickupCoffin2)._enemyType = EnemyType.BOSS_DRAGOGION;
			((PickupGuarded)pickupCoffin2)._spawnQuantity = 7;
			((PickupGuarded)pickupCoffin2)._hasAssignedSpawnData = true;
			((PickupGuarded)pickupCoffin2)._003CIsAnyGuardAlive_003Ek__BackingField = true;
			PickupCoffin pickupCoffin3 = secretCoffin;
			((PickupGuarded)pickupCoffin3)._003CSpawnAngle_003Ek__BackingField = (float)Math.PI * 2f;
			PickupCoffin pickupCoffin4 = secretCoffin;
			((Pickup)pickupCoffin4)._003CIgnoreForcedMovement_003Ek__BackingField = true;
			PickupCoffin pickupCoffin5 = secretCoffin;
			Action onGotTaken = delegate
			{
				GameManager core6 = GM.Core;
				PlayerOptions playerOptions = core6._playerOptions;
				bool flag6 = core6._playerOptions.UnlockSecret(SecretType.WinCarloCart, playerOptions._mainGameConfig);
				GameManager core7 = GM.Core;
				bool flag7 = ((List<object>)(object)core7._mapTokens).Remove((object)_mapToken);
			};
			pickupCoffin5.OnGotTaken = onGotTaken;
		}
		return;
		IL_03fa:
		if (_mapToken == null)
		{
			MapToken mapToken = new MapToken();
			_mapToken = mapToken;
			MapToken mapToken2 = _mapToken;
			float num14 = _inversionMul + _inversionMul;
			float x = num13 - num14;
			mapToken2.x = x;
			MapToken mapToken3 = _mapToken;
			mapToken3.y = -19.279999f;
			GameManager core5 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
		}
		canSpawnSecretCoffin = false;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Detune = -1000f;
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 0f, 10, time);
		if (!GM.Core.IsStageHost)
		{
			bool flag4 = NetworkItems.IsNetworkItem(ItemType.COFFIN);
			pickup = null;
			if (flag4)
			{
				goto IL_07b7;
			}
		}
		pickup2 = PickupManager.CreatePickup(float5, ItemType.COFFIN);
		bool flag5 = (object)pickup2 == null;
		pickup = null;
		if (flag5)
		{
			goto IL_07b7;
		}
		nint num15 = (nint)pickup2;
		nint num16 = (nint)typeof(PickupCoffin);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1235 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Items.PickupCoffin>)+130]");
		if (num17 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1236 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1294 @ rax_v56+FFFFFFF8+v1265 @ rax_v52*8]");
			if (0 == (nint)typeof(PickupCoffin))
			{
				obj5 = 1;
				goto IL_07d0;
			}
		}
		obj5 = 0;
		goto IL_07d0;
	}

	public override void CustomPreload(Action onComplete)
	{
		//IL_006f: Expected I, but got O
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.GYORUNTIN, core._playerOptions, core._dataManager);
			if (texturesForCharacterType != null)
			{
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass42_0();
					bool flag = CS_0024_003C_003E8__locals3 == null;
					nint num = (nint)typeof(_003C_003Ec__DisplayClass42_0);
					if (!flag)
					{
						CS_0024_003C_003E8__locals3.texture = null;
						Action<Action> loadCall = delegate(Action cb)
						{
							//IL_0029: Expected I4, but got O
							_003C_003Ec__DisplayClass42_1 obj = new _003C_003Ec__DisplayClass42_1();
							obj.cb = cb;
							Action<bool> action = null;
							((_003C_003Ec__DisplayClass42_1)(object)action)._003CCustomPreload_003Eb__1((byte)(int)obj != 0);
							GameManager core2 = GM.Core;
							string customCacheGroup = default(string);
							CharacterLoader.LoadCharacterTextureAsync(CS_0024_003C_003E8__locals3.texture, CharacterType.GYORUNTIN, action, core2._dataManager, customCacheGroup);
						};
						if (asyncLoader != null)
						{
							asyncLoader.Add(loadCall);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (asyncLoader != null)
				{
					asyncLoader.Load();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public float GetDistanceTravelled()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj = position - _playerStartX;
		object obj2 = obj & -2147483649L;
		float num = (float)obj2 * 100f;
		return num + _distanceTravelled;
	}

	private void CheckDistanceTravelled()
	{
		//IL_004c: Expected O, but got I
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		if (_canSpawnGoal)
		{
			float distanceTravelled = GetDistanceTravelled();
			GameManager core = GM.Core;
			Stage stage = core._stage;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v6 (VampireSurvivors.Objects.Stage)+138]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v6 (VampireSurvivors.Objects.Stage)+138]");
			object obj = num + 0;
			object obj2 = obj & -2147483649L;
			float num2 = (float)obj2 * 100f;
			float num3 = _nextLoopDist - num2;
			if (distanceTravelled > num3)
			{
				SpawnGoal();
			}
		}
	}

	private void OnPassGoal()
	{
		//IL_0076: Expected O, but got I4
		base.LoopPickupPositions();
		object obj = ++_loopsDone + 1;
		float nextLoopDist = (float)obj * (float)_loopLength;
		_nextLoopDist = nextLoopDist;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int num = config._003CTotalLapsCarlo_003Ek__BackingField + 1;
		config._003CTotalLapsCarlo_003Ek__BackingField = num;
		_canSpawnGoal = true;
	}

	private void SpawnGoal()
	{
		//IL_013f: Expected I4, but got I8
		//IL_01d4->IL0149: Incompatible stack heights: 1 vs 0
		//IL_00ac->IL0149: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL0149: Incompatible stack heights: 1 vs 0
		_canSpawnGoal = false;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && (object)core2._stage != null && (object)GM.Core != null)
					{
						Vector2 pos = default(Vector2);
						float value = default(float);
						ItemType relicType = default(ItemType);
						bool validatePickups = default(bool);
						Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.CART_GOAL, WeaponType.VOID, value, relicType, validatePickups);
						if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
						{
							ArcadeSprite arcadeSprite = pickup.setDepth(-1999);
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_0149->IL0149: Incompatible stack heights: 1 vs 0
		if (!PauseSystem._paused)
		{
			if (~(_isAccelerated ? 1u : 0u) == 0 && _wasPaused)
			{
				_wasPaused = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182BD8870");
				float num = default(float);
				_savedTimeScale = num;
				float timeScale = num + 0.35f;
				Time.timeScale = timeScale;
			}
		}
		else if (~(_isAccelerated ? 1u : 0u) == 0 && !_wasPaused)
		{
			_wasPaused = true;
			Time.timeScale = _savedTimeScale;
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v7 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v7 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			ContainWithinRacingBounds(target);
		}
	}

	private void MoveEnemies()
	{
		//IL_0095: Expected O, but got I
		//IL_016d: Expected I, but got O
		//IL_0176: Expected I, but got O
		//IL_0186: Expected O, but got I
		//IL_01be: Expected O, but got I
		//IL_0151->IL0261: Incompatible stack heights: 2 vs 1
		//IL_0205->IL0261: Incompatible stack heights: 4 vs 1
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		float num = _inversionMul * -1f;
		float num2 = num + (float)ret;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		object obj3 = default(object);
		float2 float5 = default(float2);
		while (enumerator.MoveNext())
		{
			Transform transform2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rbx_v8 (UnityEngine.Transform)+28]");
			if ((nint)0 == 0)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rbx_v8 (UnityEngine.Transform)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v582 @ rax_v25+40]");
			if ((nint)0 != 0)
			{
				Transform transform3 = ((Component)null).transform;
				bool flag2 = (object)transform3 == null;
				Vector3 position = transform3.position;
				object obj2 = obj3 - (object)float5;
				float num3 = num2 - position.x;
				object obj4 = obj2 * obj2;
				float num4 = num3 * num3;
				float num5 = num4 + (float)obj4;
				if (0.1f < num5)
				{
					float deltaTime = PauseSystem.DeltaTime;
					nint num6 = (nint)typeof(EnemyController);
					nint num7 = (nint)transform2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v8 (Il2CppClass<UnityEngine.Transform>)+130]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
					bool flag3 = num8 < 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ r8_v8 (Il2CppClass<UnityEngine.Transform>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rax_v29+FFFFFFF8+v692 @ rax_v28*8]");
					bool flag4 = 0 != (nint)typeof(EnemyController);
					float2 position2 = ((ArcadeSprite)null).position;
					((ArcadeSprite)null).position = float5;
				}
			}
		}
	}

	private void MoveVehiclesAndPickups(float movement)
	{
		if (!PauseSystem._paused)
		{
			TileSprite tileSprite = rainbowRoad;
			float num = movement * 0.0064f;
			float scrollOffsetX = (tileSprite._xScrollOffset = num + tileSprite._xScrollOffset);
			tileSprite._spriteScroller.SetScrollOffsetX(scrollOffsetX);
			float2 offset = default(float2);
			GM.Core.MovePickupsAndDestructibles(offset);
		}
	}

	public override void InitPickupForLoopingStage(Pickup pickup)
	{
		//IL_00c1: Expected O, but got I4
		if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0 && (object)pickup._003CLoopedSpawnX_003Ek__BackingField == null)
		{
			float2 position = pickup.position;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 position2 = gameSessionData._activeCharacter.position;
			float distanceTravelled = GetDistanceTravelled();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			pickup._003CLoopedSpawnX_003Ek__BackingField = (float?)(object)1;
		}
	}

	private void MoveCarts()
	{
		//IL_0490: Expected O, but got I4
		//IL_0499: Expected O, but got I4
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		//IL_04cd: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected I4, but got Unknown
		//IL_021a: Expected O, but got I4
		//IL_031d: Expected I, but got O
		//IL_0325: Expected I, but got O
		//IL_0335: Expected O, but got I
		//IL_0371: Expected O, but got I
		//IL_03ae: Expected O, but got I
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		PhaserSprite phaserSprite = default(PhaserSprite);
		float2 float6 = default(float2);
		object obj5 = default(object);
		object obj6 = default(object);
		float2 float8 = default(float2);
		PhaserSprite phaserSprite4 = default(PhaserSprite);
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			if ((nint)obj2 >= characters._size)
			{
				return;
			}
			GameManager core2 = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = core2._characters;
			if ((nint)obj >= characters2._size)
			{
				break;
			}
			VampireSurvivors.Objects.Characters.CharacterController[] items = characters2._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
			if (items[obj].NeedsCart)
			{
				float2 float5 = items[obj].ApplyRacingOffset(CharacterVehicleType.CART);
				bool flipX = items[obj].flipX;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				bool flag = (object)phaserSprite == null;
				object obj3 = 0;
				if (!flag)
				{
					bool flag2 = ((UnityEngine.Object)phaserSprite).m_CachedPtr == (IntPtr)0;
					obj3 = 0;
					if (!flag2)
					{
						float2 position = items[obj].position;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
						object obj4 = float6 + position;
						float2 float7 = (float2)(obj5 + obj6);
						object obj7 = obj5 + (object)float7;
						PhaserSprite phaserSprite2 = phaserSprite.setPosition(float8);
						int depth = items[obj].depth;
						int num = characterController._PlayerIndex >> 31;
						int num2 = num & 3;
						object obj8 = num2 + 1;
						int depth2 = obj8 + depth;
						PhaserSprite phaserSprite3 = phaserSprite.setDepth(depth2);
						obj3 = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if ((object)phaserSprite4 != null && ((UnityEngine.Object)phaserSprite4).m_CachedPtr != (IntPtr)0)
				{
					float2 position2 = items[obj].position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					object obj4 = obj5 + obj6;
					PhaserSprite phaserSprite5 = phaserSprite4.setPosition(float8);
					int depth3 = items[obj].depth;
					int depth4 = depth3 - 10;
					PhaserSprite phaserSprite6 = phaserSprite4.setDepth(depth4);
					float2 float7 = float8;
				}
				if (characterController._characterType == CharacterType.TP_SLOGRA_AND_GAIBON)
				{
					nint num3 = (nint)typeof(TP_SlograAndGaibon_Character);
					nint num4 = (nint)characterController;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_SlograAndGaibon_Character>)+130]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_SlograAndGaibon_Character>)+130]");
					if (num5 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32+FFFFFFF8+v176 @ rax_v31*8]");
						if (0 == (nint)typeof(TP_SlograAndGaibon_Character))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_SlograAndGaibon_Character>)+130]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32+FFFFFFF8+v837 @ rdx_v14*8]");
							object obj12 = 0 - typeof(TP_SlograAndGaibon_Character);
							bool flag3 = obj12 == null;
							bool flag4 = !flag3;
							VampireSurvivors.Objects.Characters.CharacterController characterController2 = null;
							if (!flag4)
							{
								characterController2 = items[obj];
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v16 (VampireSurvivors.Objects.Characters.CharacterController)+411]");
							PhaserSprite phaserSprite7 = phaserSprite.setVisible(visible: false);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v16 (VampireSurvivors.Objects.Characters.CharacterController)+411]");
							PhaserSprite phaserSprite8 = phaserSprite4.setVisible(visible: false);
							goto IL_0448;
						}
					}
					throw new NullReferenceException();
				}
			}
			goto IL_0448;
			IL_0448:
			obj++;
			core = GM.Core;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void Accelerate()
	{
		//IL_009f: Expected O, but got I4
		//IL_00bc: Expected O, but got F4
		//IL_00d6: Expected F4, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, time);
		_accelTime = 0f;
		if (!_isAccelerated)
		{
			_isAccelerated = true;
			_accelerationMul = 1.2f;
			object obj = Time.timeScale;
			_savedTimeScale = 0f;
			Time.timeScale = 110f;
			RenderingExtensions.Start(_glitchEmitter);
			RenderingExtensions.Start(_glitchEmitter2);
		}
	}

	public void StopAcceleration()
	{
		//IL_0027: Expected F4, but got O
		Time.timeScale = (float)this;
		_isAccelerated = false;
		_accelerationMul = 1f;
		_glitchEmitter.Stop();
		_glitchEmitter2.Stop();
	}

	public override void Cleanup()
	{
		//IL_00cd: Expected F4, but got I4
		//IL_009f: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int loopsDone = _loopsDone;
		if (config._003CTopLapsCarlo_003Ek__BackingField < _loopsDone)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			loopsDone = _loopsDone;
			config2._003CTopLapsCarlo_003Ek__BackingField = _loopsDone;
		}
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		Time.timeScale = loopsDone;
		GameManager core3 = GM.Core;
		core3._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	public unsafe override void OnItemTriggered(ItemType itemType, Pickup pickup, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0464: Expected O, but got I4
		//IL_04b0: Expected O, but got I4
		//IL_0168: Expected O, but got I4
		//IL_0472: Expected O, but got F4
		//IL_01a9: Expected O, but got I4
		//IL_04e3: Expected F4, but got I4
		//IL_0294: Expected O, but got F4
		//IL_0294: Expected O, but got Ref
		//IL_02b0: Expected O, but got I4
		//IL_0325: Expected I4, but got O
		//IL_0325: Expected O, but got F4
		//IL_0325: Expected I4, but got F4
		//IL_0367: Expected I4, but got O
		//IL_0367: Expected O, but got F4
		//IL_0367: Expected I4, but got F4
		//IL_03a4: Expected I4, but got O
		//IL_03a4: Expected O, but got F4
		//IL_03a4: Expected I4, but got F4
		//IL_03e6: Expected I4, but got O
		//IL_03e6: Expected O, but got F4
		//IL_03e6: Expected I4, but got F4
		//IL_0423: Expected I4, but got O
		//IL_0423: Expected O, but got F4
		//IL_0423: Expected I4, but got F4
		_003C_003Ec__DisplayClass55_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass55_0();
		CS_0024_003C_003E8__locals8.player = player;
		float num2 = default(float);
		switch (itemType)
		{
		case ItemType.CART_ACCEL:
		{
			SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
			soundConfig4.Rate = 2.5f;
			soundConfig4.Volume = (float?)(object)1;
			PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Morph, soundConfig4, 2000f, 1, num2);
			_accelTime = 0f;
			if (!_isAccelerated)
			{
				_isAccelerated = true;
				_accelerationMul = 1.2f;
				object obj3 = Time.timeScale;
				_savedTimeScale = 0f;
				Time.timeScale = 110f;
				RenderingExtensions.Start(_glitchEmitter);
				RenderingExtensions.Start(_glitchEmitter2);
			}
			break;
		}
		case ItemType.CART_GOAL:
		{
			base.LoopPickupPositions();
			object obj = ++_loopsDone + 1;
			float nextLoopDist = (float)obj * (float)_loopLength;
			_nextLoopDist = nextLoopDist;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			int num = config._003CTotalLapsCarlo_003Ek__BackingField + 1;
			config._003CTotalLapsCarlo_003Ek__BackingField = num;
			float speedFactor = _speedFactor + 0.05f;
			_canSpawnGoal = true;
			_speedFactor = speedFactor;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Cheers, soundConfig, 2000f, 1, num2);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 2.5f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Morph, soundConfig2, 2000f, 1, num2);
			VampireSurvivors.Objects.Characters.CharacterController player2 = CS_0024_003C_003E8__locals8.player;
			PlayerModifierStats playerStats = player2._playerStats;
			EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + 0.05f;
			playerStats._003CLuck_003Ek__BackingField = eggFloat2;
			GameManager core2 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj2 = default(object);
			float num3 = default(float);
			Vector2 vector = default(Vector2);
			string textureName = default(string);
			core2._gizmoManager.DisplayIconOverhead("Clover", "5", (Color?)(object)(&obj2), (VampireSurvivors.Objects.Characters.CharacterController)num2, num3, vector, textureName);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 1f;
			soundConfig3.Detune = 2000f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Groove, soundConfig3, 150f, 3, num2);
			Action onComplete = delegate
			{
				//IL_00b0: Expected O, but got Ref
				//IL_00da: Expected O, but got I4
				//IL_0109: Expected F4, but got O
				VampireSurvivors.Objects.Characters.CharacterController player3 = CS_0024_003C_003E8__locals8.player;
				PlayerModifierStats playerStats2 = player3._playerStats;
				EggFloat eggFloat3 = playerStats2._003CGrowth_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + 0.05f;
				playerStats2._003CGrowth_003Ek__BackingField = eggFloat4;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj4 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName2 = default(string);
				core3._gizmoManager.DisplayIconOverhead("Crown", "5", (Color?)(object)(&obj4), characterController, displayTimeMultiplier, vOffset, textureName2);
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Rate = 1f;
				soundConfig5.Volume = (float?)(object)1;
				soundConfig5.Detune = 2400f;
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Groove, soundConfig5, 150f, 3, (float)characterController);
			};
			Timer timer = TimerHelper.RegisterMillisUI(400f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)num3, (int)vector);
			Action onComplete2 = delegate
			{
				//IL_00b0: Expected O, but got Ref
				//IL_00da: Expected O, but got I4
				//IL_0109: Expected F4, but got O
				VampireSurvivors.Objects.Characters.CharacterController player3 = CS_0024_003C_003E8__locals8.player;
				PlayerModifierStats playerStats2 = player3._playerStats;
				EggFloat eggFloat3 = playerStats2._003CGreed_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + 0.05f;
				playerStats2._003CGreed_003Ek__BackingField = eggFloat4;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj4 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName2 = default(string);
				core3._gizmoManager.DisplayIconOverhead("Mask", "5", (Color?)(object)(&obj4), characterController, displayTimeMultiplier, vOffset, textureName2);
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Rate = 1f;
				soundConfig5.Volume = (float?)(object)1;
				soundConfig5.Detune = 2800f;
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Groove, soundConfig5, 150f, 3, (float)characterController);
			};
			Timer timer2 = TimerHelper.RegisterMillisUI(800f, onComplete2, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)num3, (int)vector);
			Action onComplete3 = delegate
			{
				//IL_00b0: Expected O, but got Ref
				//IL_00da: Expected O, but got I4
				//IL_0109: Expected F4, but got O
				VampireSurvivors.Objects.Characters.CharacterController player3 = CS_0024_003C_003E8__locals8.player;
				PlayerModifierStats playerStats2 = player3._playerStats;
				EggFloat eggFloat3 = playerStats2._003CCurse_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + 0.05f;
				playerStats2._003CCurse_003Ek__BackingField = eggFloat4;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj4 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName2 = default(string);
				core3._gizmoManager.DisplayIconOverhead("Curse", "5", (Color?)(object)(&obj4), characterController, displayTimeMultiplier, vOffset, textureName2);
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Rate = 1f;
				soundConfig5.Volume = (float?)(object)1;
				soundConfig5.Detune = 3200f;
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Groove, soundConfig5, 150f, 3, (float)characterController);
				GameManager core4 = GM.Core;
				core4._stage.RecalculateCurseAndCharm();
			};
			Timer timer3 = TimerHelper.RegisterMillisUI(1200f, onComplete3, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)num3, (int)vector);
			Action onComplete4 = delegate
			{
				//IL_00b0: Expected O, but got Ref
				//IL_00da: Expected O, but got I4
				//IL_0109: Expected F4, but got O
				VampireSurvivors.Objects.Characters.CharacterController player3 = CS_0024_003C_003E8__locals8.player;
				PlayerModifierStats playerStats2 = player3._playerStats;
				EggFloat eggFloat3 = playerStats2._003CMoveSpeed_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
				value2 = eggFloat3._val + 0.05f;
				playerStats2._003CMoveSpeed_003Ek__BackingField = eggFloat4;
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj4 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName2 = default(string);
				core3._gizmoManager.DisplayIconOverhead("Wing", "5", (Color?)(object)(&obj4), characterController, displayTimeMultiplier, vOffset, textureName2);
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Rate = 1f;
				soundConfig5.Volume = (float?)(object)1;
				soundConfig5.Detune = 3600f;
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Groove, soundConfig5, 150f, 3, (float)characterController);
			};
			Timer timer4 = TimerHelper.RegisterMillisUI(1600f, onComplete4, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)num3, (int)vector);
			Action onComplete5 = delegate
			{
				//IL_00cd: Expected O, but got Ref
				//IL_00f7: Expected O, but got I4
				//IL_0126: Expected F4, but got O
				VampireSurvivors.Objects.Characters.CharacterController player3 = CS_0024_003C_003E8__locals8.player;
				MagnetZone magnet = player3._magnet;
				EggFloat radius = magnet.Radius;
				float value2 = default(float);
				EggFloat radius2 = new EggFloat(value2, radius._eggVal);
				value2 = radius._val + 5f;
				magnet.Radius = radius2;
				VampireSurvivors.Objects.Characters.CharacterController player4 = CS_0024_003C_003E8__locals8.player;
				player4._magnet.RefreshSize();
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
				object obj4 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier = default(float);
				Vector2 vOffset = default(Vector2);
				string textureName2 = default(string);
				core3._gizmoManager.DisplayIconOverhead("OrbGlow", "5", (Color?)(object)(&obj4), characterController, displayTimeMultiplier, vOffset, textureName2);
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Rate = 1f;
				soundConfig5.Volume = (float?)(object)1;
				soundConfig5.Detune = 4000f;
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Groove, soundConfig5, 150f, 3, (float)characterController);
			};
			Timer timer5 = TimerHelper.RegisterMillisUI(2000f, onComplete5, null, isLooped: false, (byte)(int)num2 != 0, (MonoBehaviour)num3, (int)vector);
			break;
		}
		}
	}

	public override void OnPlayerEnteringDifferentTilemap()
	{
		TryToSpawnAccel();
	}

	private unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02c9: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		//IL_0328: Expected O, but got I4
		//IL_0341: Expected O, but got Ref
		//IL_0368: Expected O, but got I
		//IL_0382: Expected native int or pointer, but got O
		//IL_039c: Expected O, but got I
		//IL_03d5: Expected O, but got I
		//IL_0435: Expected O, but got Ref
		//IL_0458: Expected F4, but got I4
		//IL_0453: Expected native int or pointer, but got O
		//IL_0b6c: Expected O, but got I
		//IL_048b: Expected O, but got Ref
		//IL_04a5: Expected native int or pointer, but got O
		//IL_0ba6: Expected O, but got I
		//IL_04dd: Expected O, but got Ref
		//IL_04f7: Expected native int or pointer, but got O
		//IL_0be0: Expected O, but got I
		//IL_0577: Expected O, but got I
		//IL_05a6: Expected O, but got I
		//IL_06e5: Expected O, but got I4
		//IL_070c: Expected O, but got I4
		//IL_0744: Expected O, but got I4
		//IL_075d: Expected O, but got Ref
		//IL_0784: Expected O, but got I
		//IL_079e: Expected native int or pointer, but got O
		//IL_07b8: Expected O, but got I
		//IL_07f1: Expected O, but got I
		//IL_0830: Expected O, but got Ref
		//IL_0853: Expected F4, but got I4
		//IL_084e: Expected native int or pointer, but got O
		//IL_0869: Expected O, but got I
		//IL_0c3a: Expected O, but got I
		//IL_0889: Expected O, but got Ref
		//IL_08a3: Expected native int or pointer, but got O
		//IL_0c74: Expected O, but got I
		//IL_08db: Expected O, but got Ref
		//IL_08f5: Expected native int or pointer, but got O
		//IL_0cae: Expected O, but got I
		//IL_0975: Expected O, but got I
		//IL_0996: Expected O, but got I
		//IL_0d70: Expected O, but got I
		//IL_0de5: Expected O, but got Ref
		//IL_0daf: Expected O, but got I
		//IL_0e1c: Expected O, but got Ref
		//IL_0e09->IL0b05: Incompatible stack heights: 3 vs 0
		//IL_0acc->IL0dd7: Incompatible stack heights: 4 vs 3
		//IL_0b05->IL0e0e: Incompatible stack heights: 4 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			bool flag = GM.Core.IsStageVisuallyInverted();
			PhaserScene phaserScene = base.scene;
			if (phaserScene != null)
			{
				PhaserScene.Renderer renderer = phaserScene._renderer;
				if (phaserScene._renderer != null)
				{
					PhaserScene phaserScene2 = base.scene;
					if (phaserScene2 != null)
					{
						PhaserScene.Renderer renderer2 = phaserScene2._renderer;
						if (phaserScene2._renderer != null)
						{
							float num = renderer2.screenWidth * 0.5f;
							Rectangle rectangle = new Rectangle();
							float x = num ^ -0f;
							rectangle._x = x;
							rectangle._width = renderer.screenWidth;
							rectangle._y = 0f;
							rectangle._height = 0.64f;
							Rectangle rectangle2 = new Rectangle();
							float x2 = num ^ -0f;
							rectangle2._x = x2;
							rectangle2._width = renderer.screenWidth;
							rectangle2._y = 0.32f;
							rectangle2._height = 0.64f;
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
							List<string> list = new List<string>();
							if (list != null)
							{
								int version = list._version + 1;
								list._version = version;
								string[] items = list._items;
								if (list._items != null)
								{
									if (list._size >= items.Length)
									{
										((List<object>)(object)list).AddWithResize((object)"WhiteDot");
									}
									else
									{
										int size = list._size + 1;
										list._size = size;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									}
									if (particleSystemConfig != null)
									{
										particleSystemConfig._frame = list;
										ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
										particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
										_ = 0;
										minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
										particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
										_ = 0;
										float constant = _inversionMul * 5f;
										minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
										particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
										_ = 0;
										_ = 1;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
										particleSystemConfig._blendMode = (BlendMode?)(object)0;
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(200f, 250f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
										particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
										_ = 0;
										_ = 0;
										_ = 40;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
										particleSystemConfig._quantity = (int?)(object)0;
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer3 = s_scene._renderer;
												if (s_scene._renderer != null)
												{
													ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, renderer3.pixelWidth));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
													particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 2f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
													particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
													_ = 0;
													ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
													_ = 0;
													_ = 0;
													System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0.65f));
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
													_ = 0;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
													particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
													_ = 0;
													EmitZone emitZone = new EmitZone();
													emitZone._type = EmitZoneType.Random;
													emitZone._source = rectangle;
													particleSystemConfig._emitZone = emitZone;
													_ = 0;
													_ = 1120403456;
													_ = 1;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
													particleSystemConfig._frequency = (float?)(object)0;
													particleSystemConfig._on = true;
													_ = 6915750;
													_ = 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
													particleSystemConfig._tint = (uint?)(object)0;
													ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
													List<string> list2 = new List<string>();
													if (list2 != null)
													{
														int version2 = list2._version + 1;
														list2._version = version2;
														string[] items2 = list2._items;
														if (list2._items != null)
														{
															if (list2._size >= items2.Length)
															{
																((List<object>)(object)list2).AddWithResize((object)"WhiteDot");
															}
															else
															{
																int size2 = list2._size + 1;
																list2._size = size2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															if (particleSystemConfig2 != null)
															{
																particleSystemConfig2._frame = list2;
																minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
																_ = 0;
																minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
																particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
																_ = 0;
																float constant2 = _inversionMul * -5f;
																minMaxCurve = new ParticleSystem.MinMaxCurve(constant2);
																particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
																_ = 0;
																_ = 1;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._blendMode = (BlendMode?)(object)0;
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(200f, 250f));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
																particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
																_ = 0;
																_ = 0;
																_ = 40;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._quantity = (int?)(object)0;
																bool flag2 = (object)GM.Core == null;
																PhaserScene s_scene2 = ArcadePhysics.s_scene;
																PhaserScene.Renderer renderer4 = s_scene2._renderer;
																ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, renderer4.pixelWidth));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
																obj = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
																particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 304));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 2f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
																particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
																_ = 0;
																ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336));
																_ = 0;
																_ = 0;
																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 0.65f));
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
																particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
																_ = 0;
																particleSystemConfig2._emitZone = new EmitZone
																{
																	_type = EmitZoneType.Random,
																	_source = rectangle2
																};
																_ = 0;
																_ = 1120403456;
																_ = 1;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._frequency = (float?)(object)0;
																_ = 6915750;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
																particleSystemConfig2._tint = (uint?)(object)0;
																particleSystemConfig2._on = true;
																PhaserScene phaserScene3 = base.scene;
																Camera main = Camera.main;
																Transform parent = main.transform;
																ParticleSystem glitchEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "_glitchEmitter");
																_glitchEmitter = glitchEmitter;
																Transform transform = _glitchEmitter.transform;
																bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																Vector3 value = default(Vector3);
																Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
																RenderingExtensions.SetDepth(_glitchEmitter, 3000);
																Camera main2 = Camera.main;
																Transform parent2 = main2.transform;
																ParticleSystem glitchEmitter2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent2, "_glitchEmitter");
																_glitchEmitter2 = glitchEmitter2;
																Transform transform2 = _glitchEmitter2.transform;
																bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																Vector3 value2 = default(Vector3);
																Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
																RenderingExtensions.SetDepth(_glitchEmitter2, 3000);
																_ = _glitchEmitter;
																_ = _glitchEmitter;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																object obj3 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																if ((nint)0 == 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																	bool flag5 = obj3 == null;
																}
																object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 520));
																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3244 @ rax_v135 (should have been resolved before IL gen)");
																if ((object)_glitchEmitter2 != null)
																{
																	_ = _glitchEmitter2;
																	_ = _glitchEmitter2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																	object obj5 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																	if ((nint)0 == 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																		bool flag6 = obj5 == null;
																	}
																	object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 520));
																	Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3331 @ rax_v140 (should have been resolved before IL gen)");
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
		throw new NullReferenceException();
	}

	public override void OnFollowerAdded(VampireSurvivors.Objects.Characters.CharacterController character)
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
		//IL_017d: Expected O, but got I4
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		object obj = character + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		VampireSurvivors.Objects.Characters.CharacterController characterController = (VampireSurvivors.Objects.Characters.CharacterController)1;
		object obj4 = default(object);
		object obj5 = default(object);
		if (obj4 != obj5)
		{
			object obj6 = character + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj8 = default(object);
			object obj7 = obj8 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)1;
			object obj9 = default(object);
			object obj10 = default(object);
			if (obj9 != obj10)
			{
				object obj11 = character + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj14 = default(object);
				object obj13 = obj14 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				object obj15 = default(object);
				obj12 = obj15;
				object obj16 = default(object);
				if (obj16 != obj12)
				{
				}
			}
		}
		float2 offset = default(float2);
		SpawnCartForCharacter(character, offset);
	}

	public BackgroundCarloCart()
	{
		//IL_002d: Expected O, but got I4
		//IL_0042: Expected O, but got I8
		CartOffset = (float2)0;
		_ = 1034147594;
		_initialOffset = (Vector2)3204112712L;
		_ = 1085653647;
		_speedFactor = 1f;
		_accelerationMul = 1f;
		isFirstUpdate = true;
		_accelDuration = 6750f;
		_loopLength = 48000;
		List<Vector2> accelLocations = new List<Vector2>();
		_accelLocations = accelLocations;
		_accelSpawnFrequency = 10000f;
		_canSpawnGoal = true;
		base._002Ector();
	}

	private void _003COnUpdate_003Eb__41_0()
	{
		GameManager core = GM.Core;
		PlayerOptions playerOptions = core._playerOptions;
		bool flag = core._playerOptions.UnlockSecret(SecretType.WinCarloCart, playerOptions._mainGameConfig);
		GameManager core2 = GM.Core;
		bool flag2 = ((List<object>)(object)core2._mapTokens).Remove((object)_mapToken);
	}
}
