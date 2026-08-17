using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class EnemyControllerBoss_TerrainBreaker : EnemyControllerBoss
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public EnemyControllerBoss_TerrainBreaker _003C_003E4__this;

		public List<int2> posList;

		internal void _003CStartEatingTile_003Eb__0()
		{
			_003C_003E4__this.EatTile(posList);
		}
	}

	private static readonly List<string> TILE_LAYERS;

	private List<int2> _tilesToEat;

	private List<int2> _currentTilesBeingEaten;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		base.InitEnemy(enemyType, asRemote);
		CreateBlackEmitter();
	}

	protected override void OnUpdate()
	{
		OnUpdate();
		base.UpdateSpawnDamageZones();
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			base.UpdateDepth();
			if (!((EnemyController)this)._003CIsTimeStopped_003Ek__BackingField)
			{
				UpdateTileDestructionList();
			}
		}
	}

	protected virtual void UpdateTileDestructionList()
	{
		CheckTiles();
		List<int2> tilesToEat = _tilesToEat;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
		if ((nint)0 > (nint)0)
		{
			List<int2> currentTilesBeingEaten = _currentTilesBeingEaten;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v5 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			List<int2> currentTilesBeingEaten2 = _currentTilesBeingEaten;
			List<int2> currentTilesBeingEaten3 = _currentTilesBeingEaten;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v6 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			currentTilesBeingEaten3.InsertRange(0, _tilesToEat);
			_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass11_0();
			CS_0024_003C_003E8__locals4._003C_003E4__this = this;
			CS_0024_003C_003E8__locals4.posList = _currentTilesBeingEaten;
			Action onComplete = delegate
			{
				CS_0024_003C_003E8__locals4._003C_003E4__this.EatTile(CS_0024_003C_003E8__locals4.posList);
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			List<int2> tilesToEat2 = _tilesToEat;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v13 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
	}

	protected void CheckTiles()
	{
		//IL_0117: Expected O, but got I4
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (!stage._hasTileSet)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset = stage2._tilingTileset;
		List<PhaserTilemap> phaserTilemaps = tilingTileset._phaserTilemaps;
		if (tilingTileset._phaserTilemaps == null)
		{
			return;
		}
		int num = phaserTilemaps._size ^ phaserTilemaps._size;
		int num2 = phaserTilemaps._size & num;
		bool flag = num2 < 0;
		bool flag2 = phaserTilemaps._size < 0;
		bool flag3 = phaserTilemaps._size == 0;
		if (flag3)
		{
			return;
		}
		bool flag4 = flag2 == flag;
		object obj = !flag4;
		object obj2 = obj | flag3;
		if (obj2 == null)
		{
			PhaserTilemap[] items = phaserTilemaps._items;
			List<int2> list = (List<int2>)(items[0] + 192);
			int2 item = default(int2);
			list.Add(item);
			List<int2> list2 = (List<int2>)(items[0] + 192);
			list2.Add(item);
			object obj4 = default(object);
			int2 int5 = default(int2);
			object obj3 = obj4 - (object)int5;
			object obj5 = obj4 >> 32;
			object obj7 = default(object);
			object obj6 = obj5 - obj7;
			list2.Add(item);
			object obj9 = default(object);
			object obj8 = obj7 - obj9;
			int2 int6 = (int2)((object)int5 + obj3);
			bool flag5 = (byte)(int5 <= int6) != 0;
			int2 int7 = int5;
			if (!flag5)
			{
				int7 = int6;
			}
			int2 int8 = (int2)((object)int5 + obj3);
			bool flag6 = (byte)(int5 >= int8) != 0;
			int2 int9 = int5;
			if (!flag6)
			{
				int9 = int8;
			}
			while (int7 <= int9 != 0)
			{
				object obj10 = obj8 + obj6;
				bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10);
				object obj11 = obj8;
				if (!flag7)
				{
					obj11 = obj10;
				}
				object obj12 = obj8 + obj6;
				bool flag8 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12);
				object obj13 = obj8;
				if (!flag8)
				{
					obj13 = obj12;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
				{
					_tilesToEat.Add(int7);
					object obj14 = obj11 + 1;
					obj11 = obj14;
				}
				int7++;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	protected void StartEatingTile(List<int2> posList)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.posList = posList;
		Action onComplete = delegate
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.EatTile(CS_0024_003C_003E8__locals4.posList);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void EatTile(List<int2> posList)
	{
		//IL_00cc: Expected O, but got I4
		//IL_012e: Expected O, but got I4
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_017c: Expected I, but got O
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_01b9: Expected O, but got I4
		//IL_020c: Expected I, but got O
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if ((object)stage._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset2 = stage2._tilingTileset;
		List<SuperMap> maps = tilingTileset2._maps;
		if (maps._size <= 0)
		{
			return;
		}
		object obj = 0;
		float num = default(float);
		nint num2 = default(nint);
		int num4 = default(int);
		string text = default(string);
		float time = default(float);
		while ((nint)obj < maps._size)
		{
			SuperMap[] items = maps._items;
			List<string> tILE_LAYERS = TILE_LAYERS;
			bool flag = tILE_LAYERS._size <= 0;
			num = num;
			IntPtr intPtr = num2;
			int num3 = num4;
			object obj2 = 0;
			if (!flag)
			{
				bool flag4;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag2 = TilemapUtils.BatchRemoveTileAt(items[obj], posList, text);
					bool flag3 = !flag2;
					num2 = (nint)text;
					num4 = 0;
					if (!flag3)
					{
						BlackExplosionAt(posList);
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Rate = 1f;
						soundConfig.Detune = -1000f;
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 1000f, 1, time);
						num = 1000f;
						num2 = unchecked((nint)null);
						num4 = 1;
					}
					obj2++;
					flag4 = (nint)obj2 < tILE_LAYERS._size;
					intPtr = num2;
					num3 = num4;
				}
				while (flag4);
			}
			obj++;
			if ((nint)obj >= maps._size)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void BlackExplosionAt(List<int2> posList)
	{
		//IL_01aa->IL01aa: Incompatible stack heights: 1 vs 0
		int num = 0;
		int num2 = 0;
		Tilemap cellPosition = default(Tilemap);
		Vector2 pos = default(Vector2);
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				break;
			}
			GameManager core = GM.Core;
			Stage stage = core._stage;
			TilingTileset tilingTileset = stage._tilingTileset;
			List<Tilemap> allLayers = stage._tilingTileset.GetAllLayers();
			if (allLayers._size > 0)
			{
				SuperMap defaultMap = stage._tilingTileset.DefaultMap;
				if ((bool)defaultMap)
				{
					Tilemap tilemap = allLayers.get_Item(0);
					Tilemap tilemap2 = ((List<Tilemap>)(object)posList).get_Item(num);
					Tilemap tilemap3 = ((List<Tilemap>)(object)posList).get_Item(num);
					bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
					GridLayout.CellToWorld_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref *(Vector3Int*)(&cellPosition), out Vector3 _);
					if (tilingTileset._inverted)
					{
						GameManager core2 = GM.Core;
						PlayerOptionsData config = core2._playerOptions.Config;
						if (!config._003CVisuallyInvertStages_003Ek__BackingField)
						{
						}
					}
					SuperMap defaultMap2 = stage._tilingTileset.DefaultMap;
					SuperMap defaultMap3 = stage._tilingTileset.DefaultMap;
					_particlesManager.EmitParticleAt(pos, 5);
					cellPosition = tilemap2;
				}
			}
			num++;
			num2 = num;
		}
	}

	private unsafe void CreateBlackEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_026a: Expected F4, but got I
		//IL_027d: Expected O, but got I4
		//IL_02ac: Expected F4, but got I
		//IL_02bf: Expected O, but got I4
		//IL_02e6: Expected O, but got I4
		//IL_02ff: Expected O, but got Ref
		//IL_0319: Expected native int or pointer, but got O
		//IL_0333: Expected O, but got I
		//IL_0353: Expected O, but got Ref
		//IL_036d: Expected native int or pointer, but got O
		//IL_0387: Expected O, but got I
		//IL_03a7: Expected O, but got Ref
		//IL_03cf: Expected native int or pointer, but got O
		//IL_09e6: Expected O, but got I4
		//IL_03e7: Expected O, but got Ref
		//IL_040e: Expected O, but got I
		//IL_0428: Expected native int or pointer, but got O
		//IL_0a03: Expected O, but got I4
		//IL_045a: Expected O, but got Ref
		//IL_0481: Expected O, but got I
		//IL_049b: Expected native int or pointer, but got O
		//IL_0a3d: Expected O, but got I
		//IL_05fc: Expected F4, but got I
		//IL_060f: Expected O, but got I4
		//IL_063e: Expected F4, but got I
		//IL_0651: Expected O, but got I4
		//IL_0678: Expected O, but got I4
		//IL_0691: Expected O, but got Ref
		//IL_06ab: Expected native int or pointer, but got O
		//IL_06c5: Expected O, but got I
		//IL_06e5: Expected O, but got Ref
		//IL_06ff: Expected native int or pointer, but got O
		//IL_0719: Expected O, but got I
		//IL_0739: Expected O, but got Ref
		//IL_0761: Expected native int or pointer, but got O
		//IL_0a77: Expected O, but got I
		//IL_0799: Expected O, but got Ref
		//IL_07c0: Expected O, but got I
		//IL_07da: Expected native int or pointer, but got O
		//IL_0ab1: Expected O, but got I
		//IL_0812: Expected O, but got Ref
		//IL_0839: Expected O, but got I
		//IL_0853: Expected native int or pointer, but got O
		//IL_0ae3: Expected O, but got I
		//IL_0913: Expected O, but got I
		//IL_098a: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num = -renderer.pixelHeight;
			ParticleEmitterManager particleEmitterManager = _particlesManager.SetDepth(num);
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"Smoke1");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"Smoke2");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			float2 float5 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			float2 float6 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C4]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			particleSystemConfig._angleSteps = 16;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			_ = 0;
			_ = 4;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 1f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 1082130432;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 0.4f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
			_ = 0;
			particleSystemConfig._alphaEase = Easing.OutSine;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig);
			_pfxEmitter2 = pfxEmitter;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			List<string> list2 = new List<string>();
			int version3 = list2._version + 1;
			list2._version = version3;
			string[] items3 = list2._items;
			if (list2._size >= items3.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"blackDot");
			}
			else
			{
				int num4 = list2._size + 1;
				list2._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			float2 float7 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			float2 float8 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C4]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+100]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			particleSystemConfig2._angleSteps = 16;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+120]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
			_ = 0;
			_ = 4;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0f, 32f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+140]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+150]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
			_ = 0;
			_ = 1073741824;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig2._frequency = (float?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0f, 0.4f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+160]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig2._alphaEase = Easing.OutSine;
			particleSystemConfig2._on = false;
			ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2);
			_pfxEmitter = pfxEmitter2;
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			float2 float9 = base.position;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C8]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			gravityWellConfig._x = (float?)(object)0;
			float2 float10 = base.position;
			_ = 0;
			_ = 1;
			gravityWellConfig._power = 1f;
			gravityWellConfig._epsilon = 100f;
			gravityWellConfig._gravity = 40f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1CC]");
			float num5 = 0f + 0.19999999f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			gravityWellConfig._y = (float?)(object)0;
			GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
			_well = well;
			return;
		}
		throw new NullReferenceException();
	}

	public EnemyControllerBoss_TerrainBreaker()
	{
		List<int2> tilesToEat = new List<int2>();
		_tilesToEat = tilesToEat;
		_currentTilesBeingEaten = new List<int2>();
		base._002Ector();
	}

	static EnemyControllerBoss_TerrainBreaker()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"FloorOverlay");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"FakeWalls");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PlayerWall");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Obstacle");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Decals");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Walls");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Overlay1");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Structural");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"Shadows");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		TILE_LAYERS = list;
	}
}
