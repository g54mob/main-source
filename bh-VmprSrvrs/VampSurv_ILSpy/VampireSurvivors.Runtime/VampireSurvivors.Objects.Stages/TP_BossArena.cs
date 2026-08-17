using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages;

public class TP_BossArena : GameMonoBehaviour
{
	private enum ArenaState
	{
		Unactivated,
		Locked,
		Complete
	}

	private sealed class _003CWaitForAcksAndLoadBoss_003Ed__28(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TP_BossArena _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_009f: Expected I4, but got I8
			//IL_0183: Expected I4, but got O
			//IL_0069: Expected F4, but got I4
			TP_BossArena tP_BossArena = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_0175;
				}
				tP_BossArena._ackTimeout = _003C_003E1__state;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_016f;
				}
				_003C_003E1__state = -1;
			}
			if ((object)OnlineStageManager._instance != null)
			{
				int numberOfConnectedPlayers = OnlineStageManager._instance.NumberOfConnectedPlayers;
				if ((object)_003C_003E4__this != null)
				{
					if (numberOfConnectedPlayers > tP_BossArena._loadAcks && !(1.5f < tP_BossArena._ackTimeout))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
						object obj = default(object);
						float ackTimeout = (float)obj + tP_BossArena._ackTimeout;
						tP_BossArena._ackTimeout = ackTimeout;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003E4__this.SpawnBoss();
					goto IL_016f;
				}
			}
			goto IL_0175;
			IL_016f:
			return false;
			IL_0175:
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

	private sealed class _003C_CloseDoors_003Ed__32(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TP_BossArena _003C_003E4__this;

		private float _003CopenAmount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0020: Expected I4, but got I8
			//IL_0157: Expected I4, but got I8
			//IL_0160: Expected F4, but got I4
			//IL_016a: Expected F4, but got I4
			//IL_02ff: Expected I4, but got O
			//IL_029b: Expected F4, but got I4
			//IL_0361: Expected I4, but got F4
			//IL_00c9: Expected F4, but got I4
			//IL_0200: Invalid comparison between F4 and I
			//IL_0251: Expected O, but got F4
			//IL_0242: Expected F4, but got I4
			//IL_0339: Expected F4, but got I4
			//IL_0343: Expected F4, but got I4
			TP_BossArena tP_BossArena = _003C_003E4__this;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			float num;
			float num2;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_02f1;
				}
				if (tP_BossArena._doorLocations != null)
				{
					List<Vector2> doorLocations = tP_BossArena._doorLocations;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rax_v24 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)0 > (nint)0)
					{
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.LittleHit, 0f, 10, 0f, volume, rate, detune, loop, 1f);
						if (tP_BossArena._doorBlocks == null)
						{
							goto IL_02f1;
						}
						List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
						if (enumerator.MoveNext())
						{
							throw new NullReferenceException();
						}
						_003CopenAmount_003E5__2 = 1f;
						num = 0f;
						num2 = 0f;
						goto IL_037c;
					}
				}
				Debug.LogError("No door locations!");
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				num = 0f;
				num2 = 0f;
				goto IL_037c;
			}
			goto IL_02a4;
			IL_037c:
			if (_003CopenAmount_003E5__2 > num)
			{
				float deltaTime = PauseSystem.DeltaTime;
				if (num > (_003CopenAmount_003E5__2 -= deltaTime))
				{
					_003CopenAmount_003E5__2 = num2;
				}
				bool flag = (object)_003C_003E4__this == null;
				int num3 = (int)num2;
				float num4 = num2;
				if (!flag)
				{
					while (true)
					{
						List<Vector2> doorLocations2 = tP_BossArena._doorLocations;
						if (tP_BossArena._doorLocations == null)
						{
							break;
						}
						float num5 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v11 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if (num5 < 0f)
						{
							_003C_003E4__this.SetDoorOpenAmount(_003CopenAmount_003E5__2, num3);
							num3++;
							num4 = num3;
							continue;
						}
						_003C_003E2__current = num2;
						_003C_003E1__state = 1;
						return true;
					}
				}
				goto IL_02f1;
			}
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, num, 10, num, volume, rate, detune, loop, 1f);
			goto IL_02a4;
			IL_02f1:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_02a4:
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

	private sealed class _003C_OpenDoors_003Ed__33(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TP_BossArena _003C_003E4__this;

		private float _003CopenAmount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0186: Expected I4, but got I8
			//IL_022b: Expected O, but got I4
			TP_BossArena tP_BossArena = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_02c1;
				}
				if (tP_BossArena._doorLocations != null)
				{
					List<Vector2> doorLocations = tP_BossArena._doorLocations;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v32 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)0 > (nint)0)
					{
						if (tP_BossArena._mapToken != null)
						{
							GameManager core = GM.Core;
							if ((object)GM.Core == null || core._mapTokens == null)
							{
								goto IL_02c1;
							}
							bool flag = ((List<object>)(object)core._mapTokens).Remove((object)tP_BossArena._mapToken);
							tP_BossArena._mapToken = null;
						}
						_003CopenAmount_003E5__2 = 0f;
						goto IL_02fd;
					}
				}
				Debug.LogError("No door locations!");
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_02fd;
			}
			goto IL_0147;
			IL_0147:
			return false;
			IL_02c1:
			throw new NullReferenceException();
			IL_02fd:
			if (1f > _003CopenAmount_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				if ((_003CopenAmount_003E5__2 = deltaTime + _003CopenAmount_003E5__2) > 1f)
				{
					_003CopenAmount_003E5__2 = 1f;
				}
				bool flag2 = (object)_003C_003E4__this == null;
				_003C_OpenDoors_003Ed__33 obj = null;
				if (!flag2)
				{
					while (true)
					{
						List<Vector2> doorLocations2 = tP_BossArena._doorLocations;
						if (tP_BossArena._doorLocations == null)
						{
							break;
						}
						_003C_OpenDoors_003Ed__33 obj2 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v20 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if ((nint)obj2 < 0)
						{
							_003C_003E4__this.SetDoorOpenAmount(_003CopenAmount_003E5__2, 0);
							_003C_OpenDoors_003Ed__33 obj3 = (_003C_OpenDoors_003Ed__33)(0 + 1);
							obj = obj3;
							continue;
						}
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			else if ((object)_003C_003E4__this != null && tP_BossArena._doorBlocks != null)
			{
				List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
				if (enumerator.MoveNext())
				{
					PhaserSprite phaserSprite = null;
					throw new NullReferenceException();
				}
				goto IL_0147;
			}
			goto IL_02c1;
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

	private EnemyType _enemyType;

	private float2 _spawnPosition;

	private List<PhaserSprite> _doorBlocks;

	private List<Vector2> _doorLocations;

	private Rectangle _doorTriggerArea;

	private Rectangle _hardBoundsArea;

	private Rect? _originalHardBounds;

	private Rectangle _cameraLimitsRectangle;

	private ArenaState _state;

	private EnemyController _enemy;

	private CoherenceSync _sync;

	private int _loadAcks;

	private float _ackTimeout;

	private bool _isChangingState;

	private const float MaxAckTimeout = 1.5f;

	private MapToken _mapToken;

	[NonSerialized]
	public bool _fadeToSilenceInsteadOfMusic;

	private const string BOSS_CACHE_GROUP_NAME = "TP_BOSS";

	private void Awake()
	{
		CoherenceSync component = GetComponent<CoherenceSync>();
		_sync = component;
	}

	public void Setup(EnemyType enemyType, string bossName)
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			PerformSetup((int)enemyType, bossName);
			return;
		}
		Action<int, string> action = PerformSetup;
		object param = default(object);
		bool flag = _sync.SendCommand((Action<int, object>)action, MessageTarget.All, (int)enemyType, param);
	}

	public void PerformSetup(int enemy, string bossName)
	{
		//IL_0279: Expected O, but got I
		//IL_02da: Expected O, but got I4
		//IL_0312: Expected O, but got I4
		//IL_05a4: Expected O, but got I
		//IL_05bb: Expected O, but got I
		//IL_0687: Expected F4, but got O
		//IL_069c: Expected F4, but got I
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		_state = ArenaState.Unactivated;
		_enemyType = (EnemyType)enemy;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		string objectName = bossName + "SpawnRect";
		List<Rectangle> scriptRectangularLocations = stage._tilingTileset.GetScriptRectangularLocations(objectName);
		if (scriptRectangularLocations != null && scriptRectangularLocations._size >= 1)
		{
			if (scriptRectangularLocations._size <= 0)
			{
				goto IL_062b;
			}
			Rectangle[] items = scriptRectangularLocations._items;
			_hardBoundsArea = items[0];
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		string objectName2 = bossName + "SpawnRect";
		List<Rectangle> scriptRectangularLocations2 = stage2._tilingTileset.GetScriptRectangularLocations(objectName2, autoScaleAndOffset: true);
		if (scriptRectangularLocations2 != null && scriptRectangularLocations2._size >= 1)
		{
			if (scriptRectangularLocations2._size <= 0)
			{
				goto IL_062b;
			}
			Rectangle[] items2 = scriptRectangularLocations2._items;
			_doorTriggerArea = items2[0];
		}
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		string scriptName = bossName + "Door";
		List<Vector2> specialLocations = stage3._tilingTileset.GetSpecialLocations(scriptName);
		_doorLocations = specialLocations;
		if (_doorLocations != null)
		{
			List<Vector2> doorLocations = _doorLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ rax_v62 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 >= (nint)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ rax_v62 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj = (nint)0 << 2;
				int capacity = default(int);
				List<PhaserSprite> doorBlocks = new List<PhaserSprite>(capacity);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ rax_v62 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				capacity = (int)((nint)0 * (nint)4);
				_doorBlocks = doorBlocks;
				if ((nint)obj > 0)
				{
					float? num = (float?)(object)0;
					Vector2 pos = default(Vector2);
					do
					{
						List<object> doorBlocks2 = (List<object>)(object)_doorBlocks;
						PhaserWorld instance = PhaserWorld.Instance;
						PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "ThosePeople", "TP_DoorBlock");
						PhaserSprite phaserSprite2 = phaserSprite.setScale(1f, (float?)(object)0);
						phaserSprite2.EnsureSpriteRenderer();
						Material material = MaterialManager.GetMaterial(MaterialType.DefaultSpriteLit);
						((Renderer)phaserSprite2._spriteRenderer).SetMaterial(material);
						PhaserSprite item = phaserSprite2.setVisible(visible: false);
						int version = doorBlocks2._version + 1;
						doorBlocks2._version = version;
						object[] items3 = doorBlocks2._items;
						if (doorBlocks2._size >= items3.Length)
						{
							doorBlocks2.AddWithResize((object)item);
						}
						else
						{
							int size = doorBlocks2._size + 1;
							doorBlocks2._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						num = (float?)(object)((_003F?)num + 1);
					}
					while (System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj));
				}
			}
		}
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		string objectName3 = bossName + "CameraLimits";
		List<Rectangle> scriptRectangularLocations3 = stage4._tilingTileset.GetScriptRectangularLocations(objectName3, autoScaleAndOffset: true);
		if (scriptRectangularLocations3 != null && scriptRectangularLocations3._size > 0)
		{
			if (scriptRectangularLocations3._size <= 0)
			{
				goto IL_062b;
			}
			Rectangle[] items4 = scriptRectangularLocations3._items;
			_cameraLimitsRectangle = items4[0];
		}
		GameManager core5 = GM.Core;
		Stage stage5 = core5._stage;
		string scriptName2 = bossName + "Spawn";
		List<Vector2> specialLocations2 = stage5._tilingTileset.GetSpecialLocations(scriptName2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v32 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v32 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v32 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v32+20]");
				_spawnPosition = (float2)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v32+24]");
				_ = 0;
				MapToken mapToken = new MapToken();
				mapToken.texture = "TP_items";
				mapToken.frameName = "TP_BossToken";
				mapToken.x = (float)_spawnPosition;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.TP_BossArena)+30]");
				mapToken.y = 0f;
				_mapToken = mapToken;
				GameManager core6 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
				return;
			}
			goto IL_062b;
		}
		return;
		IL_062b:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_00eb: Expected O, but got Ref
		//IL_039b: Expected O, but got I4
		//IL_01ed: Expected O, but got I4
		if (_doorTriggerArea == null)
		{
			return;
		}
		CoherenceSync sync;
		Action action2;
		if ((object)_sync != null)
		{
			if (!_sync.HasStateAuthority || _isChangingState)
			{
				return;
			}
			if (_state == ArenaState.Unactivated)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._mainCharacters != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
					if (enumerator.MoveNext())
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = (VampireSurvivors.Objects.Characters.CharacterController)(&enumerator);
						throw new NullReferenceException();
					}
					_isChangingState = true;
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._multiplayer != null)
					{
						if (!core2._multiplayer.IsOnlineMultiplayer)
						{
							_state = ArenaState.Locked;
							CloseDoors();
							LoadBossTextureAndSpawn();
							return;
						}
						sync = _sync;
						Action action = null;
						action2 = action;
						nint num = 0;
						object obj = 0;
						goto IL_0470;
					}
				}
			}
			else
			{
				if (_state != ArenaState.Locked)
				{
					return;
				}
				EnemyController enemy = _enemy;
				if ((object)_enemy != null && ((UnityEngine.Object)enemy).m_CachedPtr != (IntPtr)0)
				{
					EnemyController enemy2 = _enemy;
					if ((object)_enemy == null)
					{
						goto IL_03a0;
					}
					if (!enemy2._003CIsDead_003Ek__BackingField || enemy2.body != null)
					{
						return;
					}
				}
				_isChangingState = true;
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null && core3._multiplayer != null)
				{
					bool isOnlineMultiplayer = core3._multiplayer.IsOnlineMultiplayer;
					if (!isOnlineMultiplayer)
					{
						_isChangingState = isOnlineMultiplayer;
						_state = ArenaState.Complete;
						OpenDoors();
						return;
					}
					sync = _sync;
					Action action = null;
					action2 = action;
					nint num = 0;
					object obj = 0;
					goto IL_0470;
				}
			}
		}
		goto IL_03a0;
		IL_03a0:
		throw new NullReferenceException();
		IL_0470:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C49640");
		if ((object)sync != null)
		{
			bool flag = sync.SendCommand(action2, MessageTarget.All);
			return;
		}
		goto IL_03a0;
	}

	public void SwitchToCompletedState()
	{
		_isChangingState = false;
		_state = ArenaState.Complete;
		OpenDoors();
	}

	public void SwitchToLockedState()
	{
		_state = ArenaState.Locked;
		CloseDoors();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 12 Invalid \"Jump target not found in method: 0x186FDAF40\"");
	}

	private void LoadBossTextureAndSpawn()
	{
		//IL_00df: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_013c: Expected I4, but got O
		//IL_0153: Expected O, but got I4
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer && GM.Core.IsStageHost)
		{
			_003CWaitForAcksAndLoadBoss_003Ed__28 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
		string textureName;
		if (_enemyType == EnemyType.TP_BOSS_LEGION)
		{
			textureName = "Legion";
		}
		else if (_enemyType == EnemyType.TP_BOSS_BEELZEBUB)
		{
			textureName = "Beelzebub";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v13+B8]");
			object obj3 = 0;
			textureName = (string)obj3;
		}
		Action<bool> action = null;
		((TP_BossArena)(object)action)._003CLoadBossTextureAndSpawn_003Eb__25_0((byte)(int)this != 0);
		bool flag = SpriteLoader.LoadTexture(textureName, "TP_BOSS", (DlcType?)(object)1, action);
	}

	private void SpawnBoss()
	{
		_isChangingState = false;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyController enemy = default(EnemyController);
		_enemy = enemy;
	}

	public void AckTake()
	{
		int loadAcks = _loadAcks + 1;
		_loadAcks = loadAcks;
	}

	private IEnumerator WaitForAcksAndLoadBoss()
	{
		_003CWaitForAcksAndLoadBoss_003Ed__28 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void CloseDoors()
	{
		//IL_002b: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_02a6: Expected F4, but got I4
		//IL_0376: Expected I4, but got O
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_02e2: Expected F4, but got I4
		bool flag = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		if (!_fadeToSilenceInsteadOfMusic)
		{
			SoundManager._003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals6 = new SoundManager._003C_003Ec__DisplayClass34_0();
			CS_0024_003C_003E8__locals6.newTrack = BgmType.BGM_TP_sotn_FestivalOfServants;
			CS_0024_003C_003E8__locals6.finalVolume = (float?)(object)0;
			CS_0024_003C_003E8__locals6.durationMillisIn = 1000f;
			SoundManager.FadeMusic(0f, 1000f);
			Action onComplete = delegate
			{
				//IL_0078: Expected O, but got I4
				//IL_004c: Expected F4, but got I
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				soundConfig.Loop = true;
				SoundManager.PlayMusic(CS_0024_003C_003E8__locals6.newTrack, soundConfig);
				bool flag4 = (object)CS_0024_003C_003E8__locals6.finalVolume == null;
				float volume = 0.3f;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.SoundManager+<>c__DisplayClass34_0)+18]");
					volume = 0f;
				}
				SoundManager.FadeMusic(volume, CS_0024_003C_003E8__locals6.durationMillisIn);
			};
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, flag, monoBehaviour, repeat, type, isOnlineTimer: false, canPause: false);
		}
		else
		{
			GM.Core.SetAllPlayersWeaponsActive(active: false);
			SoundManager.FadeMusic(0f, 2000f);
		}
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		GameManager core = GM.Core;
		core._canRunTickerTimer = false;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag2 = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		if (!flag2)
		{
			EnemyController[] items;
			do
			{
				GameManager core3 = GM.Core;
				Stage stage2 = core3._stage;
				List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
				if ((nint)obj < spawnedEnemies2._size)
				{
					items = spawnedEnemies2._items;
					items[obj].Disappear();
					obj--;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)items[obj] >= 0);
		}
		GameManager core4 = GM.Core;
		Stage stage3 = core4._stage;
		if (stage3._spawnTimer != null)
		{
			stage3._spawnTimer.Cancel();
		}
		if (stage3._destructibleTimer != null)
		{
			stage3._destructibleTimer.Cancel();
		}
		bool flag3 = _cameraLimitsRectangle == null;
		float yMax = (flag ? 1 : 0);
		if (!flag3)
		{
			PlatformZoneMovement platformZoneMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
			platformZoneMovement._003CMoveCameraInsideLimitsOnLimitsEnabled_003Ek__BackingField = true;
			PlatformZoneMovement platformZoneMovement2 = PlatformZoneMovement._003CInstance_003Ek__BackingField;
			platformZoneMovement2._limitCameraPosition = true;
			yMax = (flag ? 1 : 0);
			PlatformZoneMovement._003CInstance_003Ek__BackingField.SetCameraLimits(_cameraLimitsRectangle);
		}
		GameManager core5 = GM.Core;
		_originalHardBounds = core5._003CHardBounds_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v31 (VampireSurvivors.Framework.GameManager)+388]");
		_ = 0;
		Rectangle hardBoundsArea = _hardBoundsArea;
		float xMax = hardBoundsArea._width + hardBoundsArea._x;
		GM.Core.SetHardBoundsMinMax(hardBoundsArea._x, hardBoundsArea._y, xMax, yMax, (byte)(int)monoBehaviour != 0);
		_state = ArenaState.Locked;
		_003C_CloseDoors_003Ed__32 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
	}

	public void OpenDoors()
	{
		//IL_00bc: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0172: Expected O, but got I4
		//IL_0180: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		AddressableCache.RemoveTexturesFromCacheAndSpriteManager("TP_BOSS");
		AddressableCache.ReleaseCustomOperationHandleGroup("TP_BOSS");
		GM.Core.SetupMusicBanger();
		SoundManager.FadeMusic(0.3f, 2000f);
		GM.Core.SetAllPlayersWeaponsActive(active: true);
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: false);
		GameManager core = GM.Core;
		core._canRunTickerTimer = true;
		GameManager core2 = GM.Core;
		core2._stage.StartTimers();
		GameManager core3 = GM.Core;
		core3._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
		GameManager core4 = GM.Core;
		core4._003CHardBounds_003Ek__BackingField = _originalHardBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.TP_BossArena)+68]");
		_ = 0;
		PlatformZoneMovement platformZoneMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
		if (platformZoneMovement._limitCameraPosition)
		{
			platformZoneMovement._blendAfterCameraLimitsDisabled = true;
		}
		platformZoneMovement.MinCameraX = (float?)(object)0;
		platformZoneMovement.MinCameraY = (float?)(object)0;
		platformZoneMovement.MaxCameraX = (float?)(object)0;
		platformZoneMovement.MaxCameraY = (float?)(object)0;
		platformZoneMovement._limitCameraPosition = false;
		_003C_OpenDoors_003Ed__33 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	protected override void OnDestroy()
	{
		AddressableCache.RemoveTexturesFromCacheAndSpriteManager("TP_BOSS");
		AddressableCache.ReleaseCustomOperationHandleGroup("TP_BOSS");
	}

	private IEnumerator _CloseDoors()
	{
		_003C_CloseDoors_003Ed__32 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator _OpenDoors()
	{
		_003C_OpenDoors_003Ed__33 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SetDoorOpenAmount(float amount, int doorID)
	{
		//IL_005b: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0108: Expected I4, but got I8
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0048->IL020e: Incompatible stack heights: 1 vs 0
		//IL_031a->IL020e: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL020e: Incompatible stack heights: 2 vs 0
		//IL_00e8->IL020e: Incompatible stack heights: 2 vs 0
		//IL_0130->IL020e: Incompatible stack heights: 2 vs 0
		//IL_017f->IL020e: Incompatible stack heights: 3 vs 0
		//IL_01a6->IL020e: Incompatible stack heights: 3 vs 0
		//IL_01f4->IL020e: Incompatible stack heights: 3 vs 0
		//IL_02f1->IL02f6: Incompatible stack heights: 6 vs 1
		List<Vector2> doorLocations = _doorLocations;
		if (_doorLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag = (nint)doorID >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				object obj = doorID * 4;
				int num = -doorID;
				object obj2 = num * 4;
				Vector3 value = default(Vector3);
				while (true)
				{
					List<PhaserSprite> doorBlocks = _doorBlocks;
					if (_doorBlocks == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= doorBlocks._size;
					PhaserSprite[] items = doorBlocks._items;
					if (doorBlocks._items == null || (object)items[obj] == null)
					{
						break;
					}
					PhaserSprite phaserSprite = items[obj].setDepth(-1999);
					List<PhaserSprite> doorBlocks2 = _doorBlocks;
					if (_doorBlocks == null)
					{
						break;
					}
					bool flag3 = (nint)obj >= doorBlocks2._size;
					PhaserSprite[] items2 = doorBlocks2._items;
					if (doorBlocks2._items == null || (object)items2[obj] == null)
					{
						break;
					}
					Transform transform = items2[obj].transform;
					Transform transform2 = items2[obj].transform;
					if ((object)transform2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v29 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v29 (UnityEngine.Transform)+10]");
					float ret;
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
					bool flag5 = (object)transform == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					obj++;
					object obj3 = obj2 + obj;
					if ((nint)obj3 >= 4)
					{
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void StopRegularSpawning()
	{
		//IL_006c: Expected O, but got I4
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		GameManager core = GM.Core;
		core._canRunTickerTimer = false;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		if (!flag)
		{
			EnemyController[] items;
			do
			{
				GameManager core3 = GM.Core;
				Stage stage2 = core3._stage;
				List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
				if ((nint)obj < spawnedEnemies2._size)
				{
					items = spawnedEnemies2._items;
					items[obj].Disappear();
					obj--;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)items[obj] >= 0);
		}
		GameManager core4 = GM.Core;
		Stage stage3 = core4._stage;
		if (stage3._spawnTimer != null)
		{
			stage3._spawnTimer.Cancel();
		}
		if (stage3._destructibleTimer != null)
		{
			stage3._destructibleTimer.Cancel();
		}
	}

	private void ResumeRegularSpawning()
	{
		GameManager core = GM.Core;
		core._canRunTickerTimer = true;
		GameManager core2 = GM.Core;
		core2._stage.StartTimers();
	}

	public TP_BossArena()
	{
		//IL_002b: Expected I, but got O
		_fadeToSilenceInsteadOfMusic = true;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CLoadBossTextureAndSpawn_003Eb__25_0(bool success)
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			SpawnBoss();
			return;
		}
		Action action = AckTake;
		bool flag = _sync.SendCommand(action, MessageTarget.AuthorityOnly);
	}
}
