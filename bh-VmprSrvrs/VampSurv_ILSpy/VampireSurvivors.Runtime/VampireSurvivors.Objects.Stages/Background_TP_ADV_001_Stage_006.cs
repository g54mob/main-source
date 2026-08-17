using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages;

public class Background_TP_ADV_001_Stage_006 : BackgroundManager
{
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

	private TileSprite _bgTile;

	public override void Create()
	{
		//IL_00ce: Expected O, but got I4
		//IL_0184: Expected O, but got I4
		base.Create();
		CreateBossPizzas();
		if (_checkBossPizzasTimer != null)
		{
			_checkBossPizzasTimer.Cancel();
		}
		Action onComplete = CheckBossPizzas;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer checkBossPizzasTimer = Timers.Register(0.3f, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_checkBossPizzasTimer = checkBossPizzasTimer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background_TP_ADV_001_Stage_006)+3C]");
		float num = 0f * 2f;
		float num2 = num / 5.12f;
		GameObject go = base.gameObject;
		TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, 0f, 0f, "backgroundW", (string)flag);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				tileSpriteBuilder._tileWidth = renderer.width;
				tileSpriteBuilder._tileHeight = renderer2.height;
				TileSpriteBuilder tileSpriteBuilder2 = tileSpriteBuilder.SetScale(num2);
				tileSpriteBuilder2._spritePivot = (Vector2?)(object)1;
				_ = 0.5f;
				tileSpriteBuilder2._depth = -1990f;
				tileSpriteBuilder2._depthMul = 1f;
				tileSpriteBuilder2._blendMode = BlendMode.Add;
				tileSpriteBuilder2._alpha = 0.25f;
				TileSprite bgTile = tileSpriteBuilder2.Build();
				_bgTile = bgTile;
				Transform transform = _bgTile.transform;
				Transform parent = _mainCamera.transform;
				transform.SetParent(parent, worldPositionStays: true);
				Transform target = _bgTile.transform;
				float endValue = num2 * 1.25f;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, endValue, 5f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 2;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ rax_v32 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Transform target2 = _bgTile.transform;
				float endValue2 = num2 * 1.25f;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleY(target2, endValue2, 6.0000005f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 3;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v38 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				TileSprite bgTile2 = _bgTile;
				TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(bgTile2._spriteRenderer, 0.15f, 7.0000005f);
				if (tweenerCore3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rax_v43 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		//IL_011f: Expected F4, but got O
		//IL_0158: Expected F4, but got O
		//IL_0196: Expected F4, but got I
		//IL_01d2: Expected F4, but got I
		base.OnUpdate();
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					GameManager core = GM.Core;
					if ((object)GM.Core != null && core._playerOptions != null)
					{
						PlayerOptionsData config = core._playerOptions.Config;
						if (config != null && (object)_bgTile != null)
						{
							_bgTile.enabled = config._003CFlashingVFXEnabled_003Ek__BackingField;
							TileSprite bgTile = _bgTile;
							if ((object)_bgTile != null)
							{
								bgTile._xScrollOffset = (float)renderer.screenCenter;
								if ((object)bgTile._spriteScroller != null)
								{
									bgTile._spriteScroller.SetScrollOffsetX((float)renderer.screenCenter);
									TileSprite bgTile2 = _bgTile;
									if ((object)_bgTile != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (PhaserScene+Renderer)+38]");
										bgTile2._yScrollOffset = 0f;
										if ((object)bgTile2._spriteScroller != null)
										{
											SpriteScroller spriteScroller = bgTile2._spriteScroller;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (PhaserScene+Renderer)+38]");
											spriteScroller.SetScrollOffsetY(0f);
											if ((object)_bgTile != null)
											{
												Transform transform = _bgTile.transform;
												if ((object)transform != null)
												{
													bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
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
		throw new NullReferenceException();
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
	}

	public Background_TP_ADV_001_Stage_006()
	{
		List<PizzaCircle> bossPizzas = new List<PizzaCircle>();
		_bossPizzas = bossPizzas;
		base._002Ector();
	}
}
