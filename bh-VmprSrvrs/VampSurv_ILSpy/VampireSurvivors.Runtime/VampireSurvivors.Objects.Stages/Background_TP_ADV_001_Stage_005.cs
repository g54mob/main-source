using System;
using System.Collections.Generic;
using System.Linq;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages;

public class Background_TP_ADV_001_Stage_005 : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__5_0;

		public static Func<Equipment, bool> _003C_003E9__5_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CCheckMinute_003Eb__5_0(VampireSurvivors.Objects.Characters.CharacterController player)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)player != null)
			{
				object obj = player._characterType - 229;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CCheckMinute_003Eb__5_1(Equipment e)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)e != null)
			{
				object obj = e._equipmentType - 1406;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public PizzaCircle triggered;

		public Action _003C_003E9__0;

		internal void _003CCheckBossPizzas_003Eb__0()
		{
			PizzaCircle pizzaCircle = triggered;
			if ((object)triggered == null || ((UnityEngine.Object)pizzaCircle).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			GameObject gameObject = triggered.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject obj;
				if ((object)triggered != null)
				{
					GameObject gameObject2 = triggered.gameObject;
					obj = gameObject2;
				}
				else
				{
					obj = null;
				}
				ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
				pool.Release(obj);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public VampireSurvivors.Objects.Characters.CharacterController player;

		public Func<PizzaCircle, bool> _003C_003E9__1;

		internal bool _003CCheckBossPizzas_003Eb__1(PizzaCircle pizza)
		{
			//IL_0096: Expected I4, but got O
			if ((object)player != null)
			{
				float2 position = player.position;
				Vector2 point = default(Vector2);
				if ((object)pizza != null && pizza._circle != null)
				{
					return pizza._circle.Contains(point);
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private const string PizzasPoolName = "PizzaCircles";

	private List<PizzaCircle> _bossPizzas;

	private Timer _checkBossPizzasTimer;

	private TileSprite _adventureBackground;

	public override void Create()
	{
		base.Create();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
		CreateBossPizzas();
		if (_checkBossPizzasTimer != null)
		{
			_checkBossPizzasTimer.Cancel();
		}
		Action onComplete = CheckBossPizzas;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer checkBossPizzasTimer = Timers.Register(0.3f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_checkBossPizzasTimer = checkBossPizzasTimer;
	}

	public override void CheckMinute(int minute)
	{
		//IL_007c: Expected O, but got I
		//IL_00a0: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_015e: Expected I8, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0193: Expected O, but got I
		if (minute != 25)
		{
			return;
		}
		GameManager core = GM.Core;
		Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__5_0;
		if (_003C_003Ec._003C_003E9__5_0 == null)
		{
			predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__5_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController player)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)player == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = player._characterType - 229;
				return obj5 == null;
			});
		}
		object obj = Enumerable.FirstOrDefault(core._mainCharacters, predicate);
		if (obj == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v10 (System.Object)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v10 (System.Object)+C0]");
		object obj2 = 0;
		Func<Equipment, bool> predicate2 = _003C_003Ec._003C_003E9__5_1;
		if (_003C_003Ec._003C_003E9__5_1 == null)
		{
			predicate2 = (_003C_003Ec._003C_003E9__5_1 = delegate(Equipment e)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)e == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = e._equipmentType - 1406;
				return obj5 == null;
			});
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v17+28]");
		if (Enumerable.Any((IEnumerable<Equipment>)0, predicate2))
		{
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				GM.Core.TransitionToTP_ADV_001_Stage_DEATHFIGHT();
			}
			else if (GM.Core.IsStageHost)
			{
				bool flag = Enumerable.Any((IEnumerable<Equipment>)GM.Core, null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v27 (System.Boolean)+88]");
				object obj3 = 0;
				(string, object)[] array = Array.Empty<(string, object)>();
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v126 @ r10_v2+1E8] (should have been resolved before IL gen)");
				Action<long> action = null;
				((OnlineStageManager)(object)action).TransitionTP_ADV_001_Stage_DEATHFIGHT((long)(flag ? 1 : 0));
				long startingOnlineClientFrame = ((OnlineStageManager)flag).GetStartingOnlineClientFrame();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v27 (System.Boolean)+78]");
				bool flag2 = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
			}
		}
	}

	private unsafe void CreateBossPizzas()
	{
		//IL_007e: Expected O, but got I4
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0180: Expected O, but got I4
		//IL_019f: Expected O, but got Ref
		//IL_019f: Expected O, but got Ref
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("BossSpawn");
		if (scriptsFromName == null || scriptsFromName._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = default(object);
		Quaternion identityQuaternion = default(Quaternion);
		object obj3 = default(object);
		while ((nint)obj < scriptsFromName._size)
		{
			SuperObject[] items = scriptsFromName._items;
			SuperCustomProperties component = items[obj].GetComponent<SuperCustomProperties>();
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			Vector2 spawnPosFromSuperObject = stage2._tilingTileset.GetSpawnPosFromSuperObject(items[obj], component);
			if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "enemyType", out var property))
			{
				EnemyType enemyType = Enum.Parse<EnemyType>(property.m_Value);
				if (enemyType != EnemyType.BAT1)
				{
					EnemyType enemyType2 = Enum.Parse<EnemyType>(property.m_Value);
					ObjectPool pool = ((MasterObjectPooler)enemyType2).GetPool("PizzaCircles");
					GameObject gameObject = pool.GetObject((Vector3)(&obj2), (Quaternion)(&identityQuaternion));
					PizzaCircle component2 = gameObject.GetComponent<PizzaCircle>();
					component2.Init(24f);
					component2.SetAlpha(1f);
					component2.EnemyTag = enemyType;
					component2.SetSprite("TP_items", "TP_BOSSPIZZA");
					component2.SetMapToken("TP_items", "TP_BossToken");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4300");
					identityQuaternion = Quaternion.identityQuaternion;
					obj2 = obj3;
				}
			}
			obj++;
			if ((nint)obj >= scriptsFromName._size)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void CheckBossPizzas()
	{
		//IL_0051: Expected I, but got O
		//IL_012b: Expected O, but got I4
		//IL_0397: Expected O, but got I4
		//IL_04fc: Expected I4, but got F4
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals30 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals30.triggered = null;
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj = default(object);
		object obj3 = default(object);
		PizzaCircle triggered = default(PizzaCircle);
		UnityEngine.Object obj4 = default(UnityEngine.Object);
		SoundManager.SoundConfig triggered5;
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			_003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass7_1();
			bool flag = CS_0024_003C_003E8__locals25 == null;
			nint num = (nint)typeof(_003C_003Ec__DisplayClass7_1);
			if (!flag)
			{
				CS_0024_003C_003E8__locals25.player = null;
				Func<PizzaCircle, bool> predicate = CS_0024_003C_003E8__locals25._003C_003E9__1;
				if (CS_0024_003C_003E8__locals25._003C_003E9__1 == null)
				{
					predicate = (CS_0024_003C_003E8__locals25._003C_003E9__1 = delegate(PizzaCircle pizza)
					{
						//IL_0096: Expected I4, but got O
						if ((object)CS_0024_003C_003E8__locals25.player != null)
						{
							float2 position2 = CS_0024_003C_003E8__locals25.player.position;
							Vector2 point = default(Vector2);
							if ((object)pizza != null && pizza._circle != null)
							{
								return pizza._circle.Contains(point);
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					});
					mainCharacters = null;
				}
				IEnumerable<PizzaCircle> enumerable = Enumerable.Where(_bossPizzas, predicate);
				if (enumerable != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					bool flag2 = obj == null;
					object obj2 = 0;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6860");
							CS_0024_003C_003E8__locals30.triggered = triggered;
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
						}
						else if (obj != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						PizzaCircle triggered2 = CS_0024_003C_003E8__locals30.triggered;
						if ((object)CS_0024_003C_003E8__locals30.triggered == null || ((UnityEngine.Object)triggered2).m_CachedPtr == (IntPtr)0)
						{
							continue;
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							PizzaCircle triggered3 = CS_0024_003C_003E8__locals30.triggered;
							if ((object)CS_0024_003C_003E8__locals30.triggered != null)
							{
								bool flag3 = !((SoundManager.SoundConfig)(object)triggered3).Mute;
								object triggered4 = CS_0024_003C_003E8__locals30.triggered;
								if (!flag3)
								{
									IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)(((SoundManager.SoundConfig)(object)triggered3).Mute ? 1 : 0));
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									bool flag4 = (object)transform == null;
									triggered5 = (SoundManager.SoundConfig)(object)CS_0024_003C_003E8__locals30.triggered;
									if (!flag4)
									{
										Vector3 position = transform.position;
										bool flag5 = (object)core2._stage == null;
										triggered5 = (SoundManager.SoundConfig)(object)CS_0024_003C_003E8__locals30.triggered;
										if (!flag5)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
											if (!obj4)
											{
												break;
											}
											bool flag6 = (object)obj4 == null;
											triggered5 = (SoundManager.SoundConfig)(object)obj4;
											if (!flag6)
											{
												_ = 257;
												_ = 1;
												break;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									triggered4 = triggered5;
									throw new NullReferenceException();
								}
								UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(triggered4);
							}
							throw new NullReferenceException();
						}
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		bool flag7 = (object)CS_0024_003C_003E8__locals30.triggered == null;
		triggered5 = (SoundManager.SoundConfig)(object)obj4;
		if (!flag7)
		{
			CS_0024_003C_003E8__locals30.triggered.ShowFinalWarning();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float value = UnityEngine.Random.value;
			float detune = value * 500f;
			soundConfig.Detune = detune;
			soundConfig.Rate = 1f;
			float num2 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, num2);
			bool flag8 = (object)CS_0024_003C_003E8__locals30.triggered == null;
			triggered5 = soundConfig;
			if (!flag8)
			{
				CS_0024_003C_003E8__locals30.triggered.CleanUp();
				bool flag9 = _bossPizzas == null;
				triggered5 = soundConfig;
				if (!flag9)
				{
					bool flag10 = ((List<object>)(object)_bossPizzas).Remove((object)CS_0024_003C_003E8__locals30.triggered);
					Action onComplete = CS_0024_003C_003E8__locals30._003C_003E9__0;
					if (CS_0024_003C_003E8__locals30._003C_003E9__0 == null)
					{
						onComplete = (CS_0024_003C_003E8__locals30._003C_003E9__0 = delegate
						{
							PizzaCircle triggered6 = CS_0024_003C_003E8__locals30.triggered;
							if ((object)CS_0024_003C_003E8__locals30.triggered != null && ((UnityEngine.Object)triggered6).m_CachedPtr != (IntPtr)0)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals30.triggered.gameObject;
								if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
								{
									GameObject obj5;
									if ((object)CS_0024_003C_003E8__locals30.triggered != null)
									{
										GameObject gameObject2 = CS_0024_003C_003E8__locals30.triggered.gameObject;
										obj5 = gameObject2;
									}
									else
									{
										obj5 = null;
									}
									ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
									pool.Release(obj5);
								}
							}
						});
					}
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					return;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		if (_checkBossPizzasTimer != null)
		{
			_checkBossPizzasTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
		TileSprite adventureBackground = _adventureBackground;
		if ((object)_adventureBackground != null && ((UnityEngine.Object)adventureBackground).m_CachedPtr != (IntPtr)0)
		{
			_adventureBackground.destroy();
			_adventureBackground = null;
		}
	}

	private void SpawnBackground()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
	}

	private void RemoveBackground()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA61F0");
		TileSprite adventureBackground = _adventureBackground;
		if ((object)_adventureBackground != null && ((UnityEngine.Object)adventureBackground).m_CachedPtr != (IntPtr)0)
		{
			_adventureBackground.destroy();
			_adventureBackground = null;
		}
	}

	public Background_TP_ADV_001_Stage_005()
	{
		List<PizzaCircle> bossPizzas = new List<PizzaCircle>();
		_bossPizzas = bossPizzas;
		base._002Ector();
	}
}
