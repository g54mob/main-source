using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class Background1 : BackgroundManager
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public Transform floorChickenTrans;

		public Background1 _003C_003E4__this;

		public Pickup floorChicken;

		public Vector2 pos;

		public TweenCallback _003C_003E9__2;

		public TweenCallback _003C_003E9__3;

		internal unsafe void _003CSpawnFreeChicken_003Eb__0()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0147: Expected O, but got I
			//IL_022a->IL01c0: Incompatible stack heights: 1 vs 0
			//IL_0034->IL01c0: Incompatible stack heights: 1 vs 0
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Transform transform = floorChickenTrans;
			if ((object)floorChickenTrans != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Background1 background = _003C_003E4__this;
				if ((object)_003C_003E4__this != null && (object)background._chickenSprite != null)
				{
					Transform transform2 = background._chickenSprite.transform;
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
					Transform transform3 = floorChickenTrans;
					bool flag4 = (object)floorChickenTrans == null;
					bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
					bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
					Background1 background2 = _003C_003E4__this;
					bool flag7 = (object)_003C_003E4__this == null;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(background2._chickenSprite, 1f);
					Background1 background3 = _003C_003E4__this;
					bool flag8 = (object)_003C_003E4__this == null;
					bool flag9 = (object)floorChicken == null;
					int depth = floorChicken.Depth;
					bool flag10 = (object)background3._chickenSprite == null;
					int sortingOrder = depth + 100;
					background3._chickenSprite.sortingOrder = sortingOrder;
					object obj3 = _003C_003E4__this;
					bool flag11 = (object)_003C_003E4__this == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdi_v17 (System.Object)+90]");
					object obj4 = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdi_v17 (System.Object)+90]");
					bool flag12 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rdi_v18 (System.Object)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rdi_v18 (System.Object)+10]");
					ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
					ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, 1);
					return;
				}
			}
			throw new NullReferenceException();
		}

		internal unsafe void _003CSpawnFreeChicken_003Eb__1()
		{
			//IL_0241: Expected O, but got Ref
			Sequence sequence = DOTween.Sequence();
			Background1 background = _003C_003E4__this;
			Transform transform = background._chickenSprite.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(transform, (Vector3)(&obj), 0.3f);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
			{
				Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
			}
			Background1 background2 = _003C_003E4__this;
			TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(background2._chickenSprite, 1f, 0.3f);
			if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
			{
				Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			sequence.stringId = "DefaultGameTweenId";
			TweenCallback onStart = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onStart = (_003C_003E9__2 = delegate
				{
					Background1 background3 = _003C_003E4__this;
					Background1 pfxEmitterPickups = (Background1)(object)background3._pfxEmitterPickups;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
					_ = 0;
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
					ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
					ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
				});
			}
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				((ABSSequentiable)sequence).onStart = onStart;
			}
			TweenCallback onComplete = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				onComplete = (_003C_003E9__3 = delegate
				{
					Background1 background3 = _003C_003E4__this;
					Background1 pfxEmitterPickups = (Background1)(object)background3._pfxEmitterPickups;
					_ = 0;
					_ = 0;
					_ = 0;
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
					_ = 0;
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
					ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
					ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
				});
			}
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				sequence.onComplete = onComplete;
			}
		}

		internal void _003CSpawnFreeChicken_003Eb__2()
		{
			Background1 background = _003C_003E4__this;
			Background1 pfxEmitterPickups = (Background1)(object)background._pfxEmitterPickups;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
			_ = 0;
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
			ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
			ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
		}

		internal void _003CSpawnFreeChicken_003Eb__3()
		{
			Background1 background = _003C_003E4__this;
			Background1 pfxEmitterPickups = (Background1)(object)background._pfxEmitterPickups;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
			_ = 0;
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
			ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
			ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
		}
	}

	private bool _hadEnoughChicken;

	private bool _chickenTrailSpawned;

	private int _chickenTimerLoopCount;

	private SpriteRenderer _chickenSprite;

	private ParticleSystem _pfxEmitterPickups;

	private Timer _chickenTimer;

	private EnemyStalkerNoob _boon;

	private bool _awarded;

	public override void Awake()
	{
		base.Awake();
		GenerateParticleSystems();
		GenerateChickenSprite();
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		SpriteRenderer chickenSprite = _chickenSprite;
		if ((object)_chickenSprite != null && ((UnityEngine.Object)chickenSprite).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj = _chickenSprite.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		}
		ParticleSystem pfxEmitterPickups = _pfxEmitterPickups;
		if ((object)_pfxEmitterPickups != null && ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr != (IntPtr)0)
		{
			GameObject obj2 = _pfxEmitterPickups.gameObject;
			UnityEngine.Object.Destroy(obj2, 0f);
		}
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (_hadEnoughChicken && !PickupManager.IsWeaponPickupItemInWorld(WeaponType.REGEN))
		{
			bool flag = PickupManager.IsWeaponPickupItemInWorld(WeaponType.CURSE);
			if (!flag && _chickenTrailSpawned == flag)
			{
				StartChickenTrail();
			}
		}
	}

	public override void Create()
	{
		base.Create();
		_chickenTimerLoopCount = 0;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				_hadEnoughChicken = true;
			}
		}
	}

	private bool Siffregatoipummarola()
	{
		if (!PickupManager.IsWeaponPickupItemInWorld(WeaponType.REGEN))
		{
			bool flag = PickupManager.IsWeaponPickupItemInWorld(WeaponType.CURSE);
			return !flag;
		}
		return false;
	}

	private void StartChickenTrail()
	{
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		_chickenTrailSpawned = true;
		GameManager core = GM.Core;
		Vector2 spawnPos = default(Vector2);
		bool flag = default(bool);
		GameObject gameObject = core._stage.SpawnEnemy(EnemyType.BOSS_NOOB, spawnPos, asRemote: false, flag);
		EnemyStalkerNoob component = gameObject.GetComponent<EnemyStalkerNoob>();
		_boon = component;
		EnemyStalkerNoob boon = _boon;
		Action onDefeat = OnDefeated;
		boon.OnDefeat = onDefeat;
		Action onComplete = delegate
		{
			SpawnFreeChicken();
			if (++_chickenTimerLoopCount >= 100 && _chickenTimer != null)
			{
				_chickenTimer.Cancel();
			}
		};
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer chickenTimer = Timers.Register(2f, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_chickenTimer = chickenTimer;
	}

	private void OnDefeated()
	{
		//IL_00a1: Expected I8, but got O
		//IL_00b9: Expected I8, but got O
		//IL_0071: Expected O, but got I
		if (!_awarded)
		{
			_awarded = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				AwardNeoUnlock();
				return;
			}
			long num = (long)OnlineStageManager._instance;
			Action<long> action = null;
			((OnlineStageManager)(object)action).SendBackground1NeoUnlock((long)OnlineStageManager._instance);
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rbx_v4 (System.Int64)+78]");
			bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	public void AwardNeoUnlock()
	{
		//IL_00c8: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_01fa: Expected O, but got I
		//IL_0254: Expected O, but got I
		//IL_032c: Expected O, but got I
		//IL_0386: Expected O, but got I
		//IL_03cf: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptions playerOptions = core._playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		List<CharacterType> list = mainGameConfig._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r10_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_0137;
			}
		}
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)mainGameConfig._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v18+18]");
		if (num >= 0)
		{
			list2.AddWithResize((System.Int32Enum)54);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = 54;
		}
		goto IL_0137;
		IL_0137:
		GameManager core2 = GM.Core;
		PlayerOptions playerOptions2 = core2._playerOptions;
		PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
		List<CharacterType> list3 = mainGameConfig2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r10_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				goto IL_0269;
			}
		}
		List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)mainGameConfig2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r8_v13+18]");
		if (num2 >= 0)
		{
			list4.AddWithResize((System.Int32Enum)54);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 54;
		}
		goto IL_0269;
		IL_0269:
		GameManager core3 = GM.Core;
		PlayerOptions playerOptions3 = core3._playerOptions;
		PlayerOptionsData mainGameConfig3 = playerOptions3._mainGameConfig;
		List<CharacterType> list5 = mainGameConfig3._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj7 = default(object);
			if ((nint)obj7 != -1)
			{
				goto IL_0411;
			}
		}
		List<System.Int32Enum> list6 = (List<System.Int32Enum>)(object)mainGameConfig3._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r9_v9+18]");
		if (num3 >= 0)
		{
			list6.AddWithResize((System.Int32Enum)54);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = 54;
		}
		goto IL_0411;
		IL_0411:
		GameManager core4 = GM.Core;
		core4._playerOptions.Save();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -1000f;
		soundConfig.Rate = 0.5f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
	}

	private unsafe void SpawnFreeChicken()
	{
		//IL_0012: Expected O, but got I8
		//IL_02c9: Expected O, but got F4
		//IL_080c: Expected O, but got Ref
		//IL_0851: Expected O, but got Ref
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_08c1: Expected O, but got I4
		//IL_08d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Expected O, but got Unknown
		//IL_0721->IL0658: Incompatible stack heights: 1 vs 0
		//IL_00e3->IL0658: Incompatible stack heights: 1 vs 0
		//IL_0105->IL0658: Incompatible stack heights: 1 vs 0
		//IL_0134->IL0658: Incompatible stack heights: 1 vs 0
		//IL_0643->IL0628: Incompatible stack heights: 2 vs 0
		//IL_018d->IL0658: Incompatible stack heights: 2 vs 0
		//IL_0658->IL0628: Incompatible stack heights: 2 vs 0
		//IL_01bc->IL0658: Incompatible stack heights: 2 vs 0
		//IL_01de->IL0658: Incompatible stack heights: 2 vs 0
		//IL_0245->IL0658: Incompatible stack heights: 2 vs 0
		//IL_0274->IL0658: Incompatible stack heights: 2 vs 0
		//IL_0296->IL0658: Incompatible stack heights: 2 vs 0
		//IL_0306->IL0658: Incompatible stack heights: 2 vs 0
		//IL_0396->IL0658: Incompatible stack heights: 2 vs 0
		//IL_03cb->IL0658: Incompatible stack heights: 2 vs 0
		//IL_041f->IL0658: Incompatible stack heights: 2 vs 0
		//IL_0470->IL0658: Incompatible stack heights: 2 vs 0
		//IL_05ef->IL0628: Incompatible stack heights: 2 vs 0
		//IL_0611->IL0628: Incompatible stack heights: 2 vs 0
		//IL_0628->IL0628: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals45 = new _003C_003Ec__DisplayClass16_0();
		Sequence sequence;
		TweenCallback onComplete;
		if (CS_0024_003C_003E8__locals45 != null)
		{
			object obj = 6603577472L;
			CS_0024_003C_003E8__locals45._003C_003E4__this = this;
			object boon = _boon;
			if ((object)_boon == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (System.Object)+10]");
			if ((nint)0 == 0)
			{
				return;
			}
			if ((object)_boon != null)
			{
				Transform transform = _boon.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v22 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v22 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
					float num = (float)ret * 100f;
					object obj2 = default(object);
					float num2 = (float)obj2 * 100f;
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						GameSessionData gameSessionData = core._gameSessionData;
						if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
						{
							Transform transform2 = gameSessionData._activeCharacter.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
								float num3 = (float)ret * 100f;
								float num4 = (float)obj2 * 100f;
								float num5 = num2 - num4;
								float num6 = num - num3;
								float num7 = num5 * num5;
								float num8 = num6 * num6;
								float num9 = num8 + num7;
								if (80000f > num9)
								{
									if (_chickenTimer != null)
									{
										_chickenTimer.Cancel();
									}
									return;
								}
								float num10 = num2 - num4;
								float num11 = num - num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
								GameManager core2 = GM.Core;
								if ((object)GM.Core != null)
								{
									GameSessionData gameSessionData2 = core2._gameSessionData;
									if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
									{
										float2 position = gameSessionData2._activeCharacter.position;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
										float num12 = num10 * 1.8f;
										float num13 = num12 + (float)position;
										GameManager core3 = GM.Core;
										if ((object)GM.Core != null)
										{
											GameSessionData gameSessionData3 = core3._gameSessionData;
											if (core3._gameSessionData != null && (object)gameSessionData3._activeCharacter != null)
											{
												float2 position2 = gameSessionData3._activeCharacter.position;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
												CS_0024_003C_003E8__locals45.pos = (Vector2)num13;
												float num14 = num10 * 1.8f;
												object obj3 = default(object);
												float num15 = num14 + (float)obj3;
												if ((object)GM.Core != null)
												{
													Vector2 pos = default(Vector2);
													Pickup floorChicken = ((GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.ROAST)) ? PickupManager.CreatePickup(pos, ItemType.ROAST) : null);
													CS_0024_003C_003E8__locals45.floorChicken = floorChicken;
													if ((object)CS_0024_003C_003E8__locals45.floorChicken != null)
													{
														CS_0024_003C_003E8__locals45.floorChicken.SetFrame("pie");
														if ((object)CS_0024_003C_003E8__locals45.floorChicken != null)
														{
															Transform floorChickenTrans = CS_0024_003C_003E8__locals45.floorChicken.transform;
															CS_0024_003C_003E8__locals45.floorChickenTrans = floorChickenTrans;
															sequence = DOTween.Sequence();
															if ((object)CS_0024_003C_003E8__locals45.floorChicken != null)
															{
																Transform target = CS_0024_003C_003E8__locals45.floorChicken.transform;
																TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, (Vector3)(&ret), 0.3f);
																if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
																{
																	Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
																}
																if ((object)_chickenSprite != null)
																{
																	Transform target2 = _chickenSprite.transform;
																	TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target2, (Vector3)(&ret), 0.3f);
																	if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
																	{
																		Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
																	}
																	Sequence sequence4 = VampireSurvivors.Tools.TweenExtensions.SetGameId(sequence);
																	TweenCallback onStart = delegate
																	{
																		//IL_0008: Expected O, but got Ref
																		//IL_0147: Expected O, but got I
																		//IL_022a->IL01c0: Incompatible stack heights: 1 vs 0
																		//IL_0034->IL01c0: Incompatible stack heights: 1 vs 0
																		object obj12 = default(object);
																		object obj11 = (object)(&obj12);
																		Transform floorChickenTrans2 = CS_0024_003C_003E8__locals45.floorChickenTrans;
																		if ((object)CS_0024_003C_003E8__locals45.floorChickenTrans != null)
																		{
																			bool flag5 = ((UnityEngine.Object)floorChickenTrans2).m_CachedPtr == (IntPtr)0;
																			Vector3 value = default(Vector3);
																			Transform.set_localScale_Injected(((UnityEngine.Object)floorChickenTrans2).m_CachedPtr, ref value);
																			Background1 background = CS_0024_003C_003E8__locals45._003C_003E4__this;
																			if ((object)CS_0024_003C_003E8__locals45._003C_003E4__this != null && (object)background._chickenSprite != null)
																			{
																				Transform transform3 = background._chickenSprite.transform;
																				bool flag6 = (object)transform3 == null;
																				bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																				Vector3 value2 = default(Vector3);
																				Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
																				Transform floorChickenTrans3 = CS_0024_003C_003E8__locals45.floorChickenTrans;
																				bool flag8 = (object)CS_0024_003C_003E8__locals45.floorChickenTrans == null;
																				bool flag9 = ((UnityEngine.Object)floorChickenTrans3).m_CachedPtr == (IntPtr)0;
																				Transform.get_position_Injected(((UnityEngine.Object)floorChickenTrans3).m_CachedPtr, out Vector3 _);
																				bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																				Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
																				Background1 background2 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																				bool flag11 = (object)CS_0024_003C_003E8__locals45._003C_003E4__this == null;
																				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(background2._chickenSprite, 1f);
																				Background1 background3 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																				bool flag12 = (object)CS_0024_003C_003E8__locals45._003C_003E4__this == null;
																				bool flag13 = (object)CS_0024_003C_003E8__locals45.floorChicken == null;
																				int depth = CS_0024_003C_003E8__locals45.floorChicken.Depth;
																				bool flag14 = (object)background3._chickenSprite == null;
																				int sortingOrder = depth + 100;
																				background3._chickenSprite.sortingOrder = sortingOrder;
																				object obj13 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																				bool flag15 = (object)CS_0024_003C_003E8__locals45._003C_003E4__this == null;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdi_v17 (System.Object)+90]");
																				object obj14 = 0;
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				_ = 1;
																				_ = 1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1042 @ rdi_v17 (System.Object)+90]");
																				bool flag16 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rdi_v18 (System.Object)+10]");
																				bool flag17 = (nint)0 == 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rdi_v18 (System.Object)+10]");
																				ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
																				ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, 1);
																				return;
																			}
																		}
																		throw new NullReferenceException();
																	};
																	if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																		bool flag3 = (nint)0 == 0;
																		((ABSSequentiable)sequence).onStart = onStart;
																		if (!flag3)
																		{
																			object obj4 = sequence + 32;
																			object obj5 = obj4 >> 12;
																			object obj6 = obj5 & 0x1FFFFF;
																			object obj7 = obj6 >> 6;
																			object obj8 = obj6 & 0x3F;
																			nint num17;
																			do
																			{
																				object obj9 = 1 << (int)obj8;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r14_v6+462E0+v1460 @ rdx_v38*8]");
																				object obj10 = 0 | obj9;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r14_v6+462E0+v1460 @ rdx_v38*8]");
																				nint num16 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r14_v6+462E0+v1460 @ rdx_v38*8]");
																				if (num16 == 0)
																				{
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r14_v6+462E0+v1460 @ rdx_v38*8]");
																				num17 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ r14_v6+462E0+v1460 @ rdx_v38*8]");
																			}
																			while (num17 != 0);
																			TweenCallback tweenCallback = delegate
																			{
																				//IL_0241: Expected O, but got Ref
																				Sequence sequence5 = DOTween.Sequence();
																				Background1 background = CS_0024_003C_003E8__locals45._003C_003E4__this;
																				Transform target3 = background._chickenSprite.transform;
																				object obj11 = default(object);
																				TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScale(target3, (Vector3)(&obj11), 0.3f);
																				if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t3, false))
																				{
																					Sequence sequence6 = Sequence.DoInsert(sequence5, (Tween)t3, 0f);
																				}
																				Background1 background2 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																				TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleSprite.DOFade(background2._chickenSprite, 1f, 0.3f);
																				if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t4, false))
																				{
																					Sequence sequence7 = Sequence.DoInsert(sequence5, (Tween)t4, 0f);
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
																				if ((nint)0 == 0)
																				{
																					_ = 1;
																				}
																				sequence5.stringId = "DefaultGameTweenId";
																				TweenCallback onStart2 = CS_0024_003C_003E8__locals45._003C_003E9__2;
																				if (CS_0024_003C_003E8__locals45._003C_003E9__2 == null)
																				{
																					onStart2 = (CS_0024_003C_003E8__locals45._003C_003E9__2 = delegate
																					{
																						Background1 background3 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																						Background1 pfxEmitterPickups = (Background1)(object)background3._pfxEmitterPickups;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 1;
																						_ = 1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						bool flag5 = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
																						ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
																						ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
																					});
																				}
																				if (((Tween)sequence5)._003Cactive_003Ek__BackingField)
																				{
																					((ABSSequentiable)sequence5).onStart = onStart2;
																				}
																				TweenCallback onComplete2 = CS_0024_003C_003E8__locals45._003C_003E9__3;
																				if (CS_0024_003C_003E8__locals45._003C_003E9__3 == null)
																				{
																					onComplete2 = (CS_0024_003C_003E8__locals45._003C_003E9__3 = delegate
																					{
																						Background1 background3 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																						Background1 pfxEmitterPickups = (Background1)(object)background3._pfxEmitterPickups;
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						_ = 1;
																						_ = 1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
																						_ = 0;
																						_ = 0;
																						_ = 0;
																						bool flag5 = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
																						ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
																						ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
																					});
																				}
																				if (((Tween)sequence5)._003Cactive_003Ek__BackingField)
																				{
																					sequence5.onComplete = onComplete2;
																				}
																			};
																			onComplete = tweenCallback;
																			goto IL_05f4;
																		}
																	}
																	TweenCallback tweenCallback2 = delegate
																	{
																		//IL_0241: Expected O, but got Ref
																		Sequence sequence5 = DOTween.Sequence();
																		Background1 background = CS_0024_003C_003E8__locals45._003C_003E4__this;
																		Transform target3 = background._chickenSprite.transform;
																		object obj11 = default(object);
																		TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScale(target3, (Vector3)(&obj11), 0.3f);
																		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t3, false))
																		{
																			Sequence sequence6 = Sequence.DoInsert(sequence5, (Tween)t3, 0f);
																		}
																		Background1 background2 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																		TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleSprite.DOFade(background2._chickenSprite, 1f, 0.3f);
																		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t4, false))
																		{
																			Sequence sequence7 = Sequence.DoInsert(sequence5, (Tween)t4, 0f);
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
																		if ((nint)0 == 0)
																		{
																			_ = 1;
																		}
																		sequence5.stringId = "DefaultGameTweenId";
																		TweenCallback onStart2 = CS_0024_003C_003E8__locals45._003C_003E9__2;
																		if (CS_0024_003C_003E8__locals45._003C_003E9__2 == null)
																		{
																			onStart2 = (CS_0024_003C_003E8__locals45._003C_003E9__2 = delegate
																			{
																				Background1 background3 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																				Background1 pfxEmitterPickups = (Background1)(object)background3._pfxEmitterPickups;
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				_ = 1;
																				_ = 1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				bool flag5 = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
																				ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
																				ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
																			});
																		}
																		if (((Tween)sequence5)._003Cactive_003Ek__BackingField)
																		{
																			((ABSSequentiable)sequence5).onStart = onStart2;
																		}
																		TweenCallback onComplete2 = CS_0024_003C_003E8__locals45._003C_003E9__3;
																		if (CS_0024_003C_003E8__locals45._003C_003E9__3 == null)
																		{
																			onComplete2 = (CS_0024_003C_003E8__locals45._003C_003E9__3 = delegate
																			{
																				Background1 background3 = CS_0024_003C_003E8__locals45._003C_003E4__this;
																				Background1 pfxEmitterPickups = (Background1)(object)background3._pfxEmitterPickups;
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				_ = 1;
																				_ = 1;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-18]");
																				_ = 0;
																				_ = 0;
																				_ = 0;
																				bool flag5 = ((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr == (IntPtr)0;
																				ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
																				ParticleSystem.Emit_Injected(((UnityEngine.Object)pfxEmitterPickups).m_CachedPtr, ref emitParams, 1);
																			});
																		}
																		if (((Tween)sequence5)._003Cactive_003Ek__BackingField)
																		{
																			sequence5.onComplete = onComplete2;
																		}
																	};
																	bool flag4 = sequence == null;
																	onComplete = tweenCallback2;
																	if (!flag4)
																	{
																		goto IL_05f4;
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
		throw new NullReferenceException();
		IL_05f4:
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = onComplete;
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0169: Expected O, but got Ref
		//IL_0183: Expected native int or pointer, but got O
		//IL_019d: Expected O, but got I
		//IL_01bd: Expected O, but got Ref
		//IL_01d7: Expected native int or pointer, but got O
		//IL_03c3: Expected O, but got I4
		//IL_01ef: Expected O, but got Ref
		//IL_0216: Expected O, but got I
		//IL_0230: Expected native int or pointer, but got O
		//IL_024a: Expected O, but got I
		//IL_026a: Expected O, but got Ref
		//IL_0284: Expected native int or pointer, but got O
		//IL_03e0: Expected O, but got I4
		//IL_029c: Expected O, but got Ref
		//IL_02b6: Expected native int or pointer, but got O
		//IL_040a: Expected O, but got I
		//IL_02ee: Expected O, but got Ref
		//IL_0303: Expected native int or pointer, but got O
		//IL_031d: Expected O, but got I
		//IL_0350: Expected O, but got I
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
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(25f, 50f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 30;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 400f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-1000f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = false;
		Transform parent = base.transform;
		ParticleSystem pfxEmitterPickups = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "PfxEmitterPickups - Background1");
		_pfxEmitterPickups = pfxEmitterPickups;
	}

	private void GenerateChickenSprite()
	{
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			string spriteName = default(string);
			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, 0f, 0f, "items", spriteName);
			if ((object)spriteRenderer != null)
			{
				GameObject gameObject2 = spriteRenderer.gameObject;
				if ((object)gameObject2 != null)
				{
					((UnityEngine.Object)gameObject2).SetName("ChickenSprite");
					Material material = MaterialManager.GetMaterial(MaterialType.Character);
					((Renderer)spriteRenderer).SetMaterial(material);
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					int stringLength = (int)(nint)MaterialPropertyBlock.CreateImpl();
					((string)(object)materialPropertyBlock)._stringLength = stringLength;
					((Renderer)spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock);
					RenderingExtensions.SetTintEnabled(materialPropertyBlock, isEnabled: true);
					bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, (IntPtr)((string)(object)materialPropertyBlock)._stringLength);
					MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
					int stringLength2 = (int)(nint)MaterialPropertyBlock.CreateImpl();
					((string)(object)materialPropertyBlock2)._stringLength = stringLength2;
					((Renderer)spriteRenderer).Internal_GetPropertyBlock(materialPropertyBlock2);
					bool flag2 = ((string)(object)materialPropertyBlock2)._stringLength == 0;
					Color value = default(Color);
					MaterialPropertyBlock.SetColorImpl_Injected((IntPtr)((string)(object)materialPropertyBlock2)._stringLength, RenderingExtensions.TintColor, ref value);
					bool flag3 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, (IntPtr)((string)(object)materialPropertyBlock2)._stringLength);
					_chickenSprite = spriteRenderer;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CStartChickenTrail_003Eb__13_0()
	{
		SpawnFreeChicken();
		if (++_chickenTimerLoopCount >= 100 && _chickenTimer != null)
		{
			_chickenTimer.Cancel();
		}
	}
}
