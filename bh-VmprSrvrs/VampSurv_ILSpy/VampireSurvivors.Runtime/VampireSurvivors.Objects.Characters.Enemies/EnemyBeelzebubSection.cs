using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyBeelzebubSection : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public PhaserSprite exp;

		internal void _003CSetupExplosions_003Eb__0()
		{
			PhaserSprite phaserSprite = exp.setVisible(visible: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public int localIndex;

		public float expAngle;

		public float radius;

		public float rnd;

		public EnemyBeelzebubSection _003C_003E4__this;

		internal void _003CPlayExplosions_003Eb__0()
		{
			//IL_0240: Expected F4, but got I4
			//IL_00c4->IL024a: Incompatible stack heights: 1 vs 0
			//IL_0121->IL024a: Incompatible stack heights: 1 vs 0
			//IL_015b->IL024a: Incompatible stack heights: 1 vs 0
			//IL_02ea->IL024a: Incompatible stack heights: 2 vs 0
			//IL_019f->IL024a: Incompatible stack heights: 2 vs 0
			//IL_036c->IL024a: Incompatible stack heights: 3 vs 0
			//IL_01f5->IL024a: Incompatible stack heights: 3 vs 0
			//IL_0249->IL0249: Incompatible stack heights: 3 vs 0
			EnemyBeelzebubSection enemyBeelzebubSection = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				List<PhaserSprite> explosionSprites = enemyBeelzebubSection.explosionSprites;
				if (enemyBeelzebubSection.explosionSprites != null)
				{
					if (explosionSprites._size < localIndex)
					{
						return;
					}
					EnemyBeelzebubSection enemyBeelzebubSection2 = _003C_003E4__this;
					List<PhaserSprite> explosionSprites2 = enemyBeelzebubSection2.explosionSprites;
					int num = localIndex;
					bool flag = localIndex >= explosionSprites2._size;
					PhaserSprite[] items = explosionSprites2._items;
					if (explosionSprites2._items != null)
					{
						if (localIndex >= items.Length)
						{
							throw new IndexOutOfRangeException();
						}
						ArcadeSprite arcadeSprite = _003C_003E4__this;
						PhaserSprite phaserSprite = items[num];
						if ((object)_003C_003E4__this != null)
						{
							_003C_003E4__this.CheckRenderer();
							object spriteRenderer = arcadeSprite._spriteRenderer;
							if ((object)arcadeSprite._spriteRenderer != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v11 (System.Object)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v11 (System.Object)+10]");
								Renderer.get_bounds_Injected((IntPtr)0, out Bounds _);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
								ArcadeSprite arcadeSprite2 = _003C_003E4__this;
								if ((object)_003C_003E4__this != null)
								{
									_003C_003E4__this.CheckRenderer();
									ArcadeSprite spriteRenderer2 = (ArcadeSprite)(object)arcadeSprite2._spriteRenderer;
									if ((object)arcadeSprite2._spriteRenderer != null)
									{
										bool flag3 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
										Renderer.get_bounds_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, out Bounds _);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
										float num2 = expAngle * radius;
										object obj = default(object);
										float num3 = num2 + (float)obj;
										if ((object)items[num] != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
											PhaserSprite phaserSprite2 = items[num].setVisible(visible: true);
											if ((object)phaserSprite._spriteAnimation != null)
											{
												phaserSprite._spriteAnimation.SetAnimation("bang");
												float? volume = default(float?);
												float rate = default(float);
												float detune = default(float);
												bool loop = default(bool);
												PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 10, 0f, volume, rate, detune, loop, 1f);
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
			throw new NullReferenceException();
		}
	}

	public PhaserSprite[] _chains;

	private bool _hasExplosions;

	private List<PhaserSprite> explosionSprites;

	private float offsetRadius;

	private List<Timer> explosionTimers;

	private int ExplosionsNumber;

	private bool _isFalling;

	private float _fallTimer;

	private List<PhaserSprite> _flies;

	private float _flyMovementPhaseOffset;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_004b: Expected O, but got I4
		base.InitEnemy(enemyType, asRemote);
		SetupFlies();
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		_treasure = null;
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		BaseBody baseBody = body;
		baseBody._immovable = true;
		BaseBody baseBody2 = body;
		baseBody2._pushable = false;
		_isFalling = false;
		_fallTimer = 0f;
		SetupExplosions();
	}

	public void OnlineSetupSection(CoherenceSync boss, bool hasChains, string spriteName, bool isHead)
	{
		EnemyBeelzebub component = boss.GetComponent<EnemyBeelzebub>();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 53 Invalid \"Jump target not found in method: 0x18769D1B0\"");
		throw new NullReferenceException();
	}

	public void SetupBeelzebubSection(EnemyBeelzebub parentBoss, bool hasChains, string spriteName, bool isHead)
	{
		//IL_0148: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		object obj = default(object);
		if (obj != null)
		{
			_SpriteAnimation.CleanAnimations();
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Beelzebub_Head", 1, 2, "Beelzebub", num);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_SpriteAnimation.AddAnimation("idle", animationFrames, 4, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			_SpriteAnimation.SetAnimation("idle");
		}
		if (hasChains)
		{
			PhaserSprite[] array = new PhaserSprite[1];
			PhaserWorld instance = PhaserWorld.Instance;
			float2 float5 = parentBoss.position;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "Beelzebub", "Beelzebub_Chain");
			if ((object)phaserSprite != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			_chains = array;
		}
		List<object> sections = (List<object>)(object)parentBoss._sections;
		int version = sections._version + 1;
		sections._version = version;
		object[] items = sections._items;
		if (sections._size >= items.Length)
		{
			sections.AddWithResize((object)this);
			return;
		}
		int num3 = sections._size + 1;
		sections._size = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	private unsafe void SetupFlies()
	{
		//IL_01b9: Expected O, but got I4
		//IL_04fb: Expected I, but got O
		//IL_02e7: Expected O, but got I
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_03aa: Expected O, but got I
		//IL_03b2: Expected I4, but got O
		//IL_0440: Expected O, but got I
		//IL_04a1: Expected O, but got I8
		//IL_0587->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_020a->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_0259->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_027b->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_02cc->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_030b->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_035a->IL04a6: Incompatible stack heights: 1 vs 0
		//IL_042b->IL051a: Incompatible stack heights: 1 vs 0
		List<PhaserSprite> flies = new List<PhaserSprite>();
		_flies = flies;
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
					((List<object>)(object)list).AddWithResize((object)"Beelzebub_Fly1");
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
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"Beelzebub_Fly2");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(list, "Beelzebub");
					object obj = 0;
					object obj2 = "Beelzebub_Fly2";
					List<string> list2 = null;
					Vector2 pos = default(Vector2);
					bool shouldLoop = default(bool);
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					while (true)
					{
						PhaserWorld instance = PhaserWorld.Instance;
						Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
						if ((object)cachedTrans == null)
						{
							break;
						}
						bool flag = ((List<string>)(object)cachedTrans)._items == null;
						float2 ret;
						Transform.get_position_Injected((IntPtr)((List<string>)(object)cachedTrans)._items, out *(Vector3*)(&ret));
						if (body != null)
						{
							BaseBody baseBody = body;
							ArcadeTransform arcadeTransform = baseBody._transform;
							if (baseBody._transform == null)
							{
								break;
							}
							arcadeTransform.position = ret;
						}
						if ((object)instance == null)
						{
							break;
						}
						PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "Beelzebub", "Beelzebub_Fly1");
						if ((object)phaserSprite == null || (object)phaserSprite._spriteAnimation == null)
						{
							break;
						}
						phaserSprite._spriteAnimation.AddAnimation("buzz", animationFrames, 16, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v31 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v31 (VampireSurvivors.Framework.Phaser.PhaserSprite)+30]");
						((BaseSpriteAnimation)0).SetAnimation("buzz");
						List<object> flies2 = (List<object>)(object)_flies;
						if (_flies == null)
						{
							break;
						}
						int version3 = flies2._version + 1;
						flies2._version = version3;
						obj2 = flies2._items;
						if (flies2._items == null)
						{
							break;
						}
						int num3 = flies2._size;
						int num4 = flies2._size;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r9_v8 (System.Object)+18]");
						if ((nint)num4 >= (nint)0)
						{
							((List<object>)(object)_flies).AddWithResize((object)phaserSprite);
							list2 = (List<string>)0;
							num3 = (int)phaserSprite;
							object flies3 = _flies;
						}
						else
						{
							int num5 = flies2._size + 1;
							flies2._size = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							list2 = (List<string>)(object)phaserSprite;
							object flies3 = flies2._items;
						}
						obj++;
						if ((nint)obj < 10)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj3 == null)
							{
								MissingMethodException ex = new MissingMethodException();
								throw ex;
							}
							object flies3 = 6573110936L;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v807 @ rax_v36 (should have been resolved before IL gen)");
						_flyMovementPhaseOffset = 0f;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0024: Expected O, but got I4
		//IL_076a: Expected O, but got F4
		//IL_02ac: Expected F4, but got I4
		//IL_00b1: Expected O, but got I
		//IL_051c: Expected O, but got F4
		//IL_052c: Expected O, but got I
		//IL_00e0: Expected F4, but got I4
		//IL_0909: Expected I, but got O
		//IL_0317: Expected O, but got I4
		//IL_0569: Expected O, but got F4
		//IL_0944: Expected F4, but got O
		//IL_0944: Expected F4, but got I
		//IL_0948: Expected O, but got F4
		//IL_057c: Expected F4, but got O
		//IL_057c: Expected F4, but got I
		//IL_0580: Expected O, but got F4
		//IL_095b: Expected F4, but got O
		//IL_095b: Expected F4, but got I
		//IL_095f: Expected O, but got F4
		//IL_0593: Expected F4, but got O
		//IL_0593: Expected F4, but got I
		//IL_0597: Expected O, but got F4
		//IL_03d5: Invalid comparison between F4 and I4
		//IL_079e: Invalid comparison between I4 and F4
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Expected O, but got Unknown
		//IL_044f: Expected O, but got Ref
		//IL_01a9: Expected O, but got I4
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_08e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Expected O, but got Unknown
		//IL_009c->IL04be: Incompatible stack heights: 1 vs 0
		//IL_05ca->IL04be: Incompatible stack heights: 1 vs 0
		//IL_0116->IL04be: Incompatible stack heights: 1 vs 0
		//IL_0149->IL04be: Incompatible stack heights: 1 vs 0
		//IL_022a->IL04be: Incompatible stack heights: 2 vs 0
		//IL_0246->IL06ba: Incompatible stack heights: 2 vs 0
		//IL_085c->IL04be: Incompatible stack heights: 1 vs 0
		//IL_08fb->IL0966: Incompatible stack heights: 4 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<PhaserSprite> flies = _flies;
		if (_flies != null)
		{
			Transform transform = null;
			float num = 2f;
			float? num2 = (float?)(object)0;
			float num6 = default(float);
			object obj11 = default(object);
			float2 float7 = default(float2);
			float x = default(float);
			float2 value = default(float2);
			while (true)
			{
				Vector3 ret;
				if ((nint)num2 < flies._size)
				{
					List<PhaserSprite> flies2 = _flies;
					if (_flies == null)
					{
						break;
					}
					bool flag = (nint)transform >= flies2._size;
					PhaserSprite[] items = flies2._items;
					if (flies2._items == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AC9A]");
					object obj3 = 0;
					float num3 = (float)transform * 3.14f;
					float num4 = num3 + _flyMovementPhaseOffset;
					float num5;
					if (PauseSystem._paused)
					{
						num5 = 0f;
					}
					else
					{
						object obj4 = Time.time;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AC9A]");
						obj3 = 0;
						num5 = num6;
					}
					nint num7 = (nint)typeof(PauseSystem);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1383 @ rax_v111 (Il2CppClass<PauseSystem>)+B8]");
					nint num8 = 0;
					if (!PauseSystem._paused)
					{
						object obj5 = Time.time;
					}
					float num9 = num5 * 0.125f;
					float num10 = num9 + num4;
					object obj6 = Mathf.PerlinNoise(num8, (float)obj3);
					object obj7 = Mathf.PerlinNoise(num8, (float)obj3);
					object obj8 = Mathf.PerlinNoise(num8, (float)obj3);
					object obj9 = Mathf.PerlinNoise(num8, (float)obj3);
					BaseBody baseBody = body;
					float num11 = num10 - num10;
					if (body == null || (object)items[(object)transform] == null)
					{
						break;
					}
					Transform transform2 = items[(object)transform].transform;
					if ((object)transform2 == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rax_v125 (BaseBody)+6C]");
					object obj10 = 0 - obj11;
					float num13;
					if (base._003CIsDead_003Ek__BackingField)
					{
						float num12 = _fallTimer * 0.1f;
						num13 = 0.1f - num12;
					}
					else
					{
						num13 = 0.2f;
					}
					float num14 = (float)obj10 * num13;
					float2 float5 = items[(object)transform].position;
					float num15 = num11 + num14;
					float num16 = num15 * 60f;
					float deltaTime = PauseSystem.DeltaTime;
					float num17 = num16 * deltaTime;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+74]");
					float num18 = 0f + num17;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
					PhaserSprite phaserSprite = items[(object)transform].setScale(2f, (float?)(object)0);
					num6 = _fallTimer * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
					float alpha = 1f - num6;
					PhaserSprite phaserSprite2 = items[(object)transform].setAlpha(alpha);
					flies = _flies;
					transform = (Transform)(transform + 1);
					if (_flies == null)
					{
						break;
					}
					num = 2f;
					num2 = (float?)transform;
					continue;
				}
				if (base._003CIsDead_003Ek__BackingField)
				{
					if (_isFalling)
					{
						goto IL_06fd;
					}
					PlayExplosions();
					_isFalling = true;
				}
				if (_isFalling)
				{
					goto IL_06fd;
				}
				return;
				IL_06fd:
				if (PauseSystem._paused)
				{
					num6 = 0f;
				}
				else
				{
					object obj12 = Time.deltaTime;
				}
				BaseBody baseBody2 = body;
				float fallTimer = num6 + _fallTimer;
				_fallTimer = fallTimer;
				if (body == null)
				{
					break;
				}
				baseBody2._enable = false;
				float2 float6 = base.position;
				base.position = float7;
				if (_chains != null)
				{
					PhaserSprite[] chains = _chains;
					float? num19 = (float?)(object)0;
					while ((nint)num19 < chains.Length)
					{
						if ((object)chains[(object)num19] == null)
						{
							goto end_IL_06ba;
						}
						Transform transform3 = chains[(object)num19].transform;
						if ((object)transform3 == null)
						{
							goto end_IL_06ba;
						}
						Vector3 localEulerAngles = transform3.localEulerAngles;
						Transform transform4 = chains[(object)num19].transform;
						if ((object)transform4 == null)
						{
							goto end_IL_06ba;
						}
						Vector3 localEulerAngles2 = transform4.localEulerAngles;
						if (localEulerAngles2.z > 0f)
						{
						}
						if (0f > localEulerAngles2.z)
						{
						}
						Transform transform5 = chains[(object)num19].transform;
						if ((object)transform5 == null)
						{
							goto end_IL_06ba;
						}
						Vector3 localEulerAngles3 = transform5.localEulerAngles;
						Transform transform6 = chains[(object)num19].transform;
						if ((object)transform6 == null)
						{
							goto end_IL_06ba;
						}
						transform6.localEulerAngles = (Vector3)(&x);
						Transform transform7 = chains[(object)num19].transform;
						if ((object)transform7 == null)
						{
							goto end_IL_06ba;
						}
						bool flag3 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out ret);
						Transform transform8 = chains[(object)num19].transform;
						Transform transform9 = chains[(object)num19].transform;
						if ((object)transform9 == null)
						{
							goto end_IL_06ba;
						}
						bool flag4 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
						float ret2;
						Transform.get_position_Injected(((UnityEngine.Object)transform9).m_CachedPtr, out *(Vector3*)(&ret2));
						bool flag5 = (object)transform8 == null;
						bool flag6 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Vector3*)(&value));
						num19 = (float?)(object)((_003F?)num19 + 1);
						x = localEulerAngles3.x;
					}
					num = 2f;
				}
				if (_fallTimer > num)
				{
					Despawn();
				}
				return;
				continue;
				end_IL_06ba:
				break;
			}
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb);
	}

	public override void Disappear()
	{
		base._003CIsDead_003Ek__BackingField = true;
	}

	protected override void Die()
	{
		base._003CIsDead_003Ek__BackingField = true;
	}

	public override void Despawn()
	{
		//IL_00d0: Expected O, but got I4
		//IL_00d9: Expected O, but got I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		List<PhaserSprite> flies = _flies;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < flies._size)
			{
				List<PhaserSprite> flies2 = _flies;
				if ((nint)obj >= flies2._size)
				{
					break;
				}
				PhaserSprite[] items = flies2._items;
				items[obj].destroy();
				flies = _flies;
				obj++;
				obj2 = obj;
				continue;
			}
			_flies = null;
			base.Despawn();
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void SetupExplosions()
	{
		//IL_007f: Expected O, but got I4
		//IL_009c: Expected O, but got I4
		//IL_014c: Expected I, but got O
		//IL_0162: Expected O, but got I
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01d9: Expected I, but got O
		//IL_049f: Expected O, but got I4
		//IL_04b6: Expected I, but got I8
		//IL_01c2: Expected I, but got I8
		//IL_050e: Expected I, but got O
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_052b->IL046d: Incompatible stack heights: 1 vs 0
		//IL_031c->IL046d: Incompatible stack heights: 1 vs 0
		//IL_034b->IL046d: Incompatible stack heights: 1 vs 0
		//IL_0382->IL046d: Incompatible stack heights: 1 vs 0
		//IL_03d1->IL046d: Incompatible stack heights: 1 vs 0
		//IL_0468->IL0530: Incompatible stack heights: 1 vs 0
		//IL_046d->IL055f: Incompatible stack heights: 1 vs 0
		if (_hasExplosions)
		{
			return;
		}
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("HitSmoke", 1, 2, "vfx", num);
		_hasExplosions = true;
		List<PhaserSprite> list = new List<PhaserSprite>();
		explosionSprites = list;
		if (ExplosionsNumber <= 0)
		{
			return;
		}
		object obj = 0;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		while (true)
		{
			_003C_003Ec__DisplayClass19_0 obj2 = new _003C_003Ec__DisplayClass19_0();
			PhaserWorld instance = PhaserWorld.Instance;
			if ((object)instance == null)
			{
				break;
			}
			PhaserSprite exp = instance.AddPhaserSprite((Vector2)0, "vfx", "HitSmoke1");
			if (obj2 == null)
			{
				break;
			}
			obj2.exp = exp;
			PhaserSprite exp2 = obj2.exp;
			if ((object)obj2.exp == null)
			{
				break;
			}
			Action action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ r10_v7 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass19_0._003CSetupExplosions_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ r10_v7 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num3;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ r10_v7 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_0496;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num3 = ((Delegate)action).method_ptr;
			goto IL_0496;
			IL_0496:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			if ((object)exp2._spriteAnimation == null)
			{
				break;
			}
			exp2._spriteAnimation.AddAnimation("bang", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			if ((object)obj2.exp == null)
			{
				break;
			}
			PhaserSprite phaserSprite = obj2.exp.setVisible(visible: false);
			if ((object)obj2.exp == null)
			{
				break;
			}
			Transform transform = obj2.exp.transform;
			if ((object)transform == null)
			{
				break;
			}
			bool flag = ((List<PhaserSprite>)(object)transform)._items == null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rcx_v30 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			Transform.SetParent_Injected((IntPtr)((List<PhaserSprite>)(object)transform)._items, (IntPtr)0, true);
			if ((object)obj2.exp == null)
			{
				break;
			}
			PhaserSprite phaserSprite2 = obj2.exp.setDepth(3000);
			if ((object)obj2.exp == null)
			{
				break;
			}
			GameObject gameObject = obj2.exp.gameObject;
			if ((object)gameObject == null)
			{
				break;
			}
			((UnityEngine.Object)gameObject).SetName("TP_Death_Bang");
			List<object> list2 = (List<object>)(object)explosionSprites;
			if (explosionSprites == null)
			{
				break;
			}
			int version = list2._version + 1;
			list2._version = version;
			object[] items = list2._items;
			if (list2._items == null)
			{
				break;
			}
			if (list2._size >= items.Length)
			{
				((List<object>)(object)explosionSprites).AddWithResize((object)obj2.exp);
			}
			else
			{
				int num5 = list2._size + 1;
				list2._size = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj++;
			if ((nint)obj >= ExplosionsNumber)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PlayExplosions()
	{
		//IL_03e0: Expected I, but got O
		//IL_040d: Expected O, but got F4
		//IL_041a: Expected I4, but got F4
		//IL_0526: Expected O, but got F4
		//IL_0544: Expected O, but got I4
		//IL_0572: Expected I4, but got F4
		//IL_0193: Expected I, but got O
		//IL_01a9: Expected O, but got I
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0220: Expected I, but got O
		//IL_043d: Expected O, but got I4
		//IL_0454: Expected I, but got I8
		//IL_0209: Expected I, but got I8
		//IL_0335->IL04ba: Incompatible stack heights: 11 vs 7
		List<Timer> list = explosionTimers;
		if (explosionTimers != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
				object[] array = null;
			}
		}
		List<Timer> list2 = new List<Timer>();
		explosionTimers = list2;
		CheckRenderer();
		bool flag = (object)((ArcadeSprite)this)._spriteRenderer == null;
		Sprite sprite = ((ArcadeSprite)this)._spriteRenderer.sprite;
		bool flag2 = (object)sprite == null;
		bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		CheckRenderer();
		bool flag4 = (object)((ArcadeSprite)this)._spriteRenderer == null;
		Sprite sprite2 = ((ArcadeSprite)this)._spriteRenderer.sprite;
		bool flag5 = (object)sprite2 == null;
		bool flag6 = ((List<Timer>)(object)sprite2)._items == null;
		Sprite.get_rect_Injected((IntPtr)((List<Timer>)(object)sprite2)._items, out Rect _);
		object obj = default(object);
		object obj2 = default(object);
		bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		object obj3 = obj;
		if (!flag7)
		{
			obj3 = obj2;
		}
		float num = (float)obj3 * 0.25f;
		List<PhaserSprite> list3 = explosionSprites;
		offsetRadius = num;
		bool flag8 = explosionSprites == null;
		bool flag9 = false;
		bool flag10 = false;
		bool flag11 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while ((flag11 ? 1 : 0) < list3._size)
		{
			_003C_003Ec__DisplayClass20_0 obj4 = new _003C_003Ec__DisplayClass20_0();
			bool flag12 = obj4 == null;
			obj4._003C_003E4__this = this;
			object obj5 = UnityEngine.Random.value;
			((List<Timer>)(object)obj4)._version = (int)num;
			float num2 = num * 360f;
			object obj6 = UnityEngine.Random.value;
			float num3 = num2 * offsetRadius;
			((List<Timer>)(object)obj4)._items = (Timer[])flag9;
			float num4 = num3 + offsetRadius;
			float num5 = num4 * 0.01f;
			((List<Timer>)(object)obj4)._size = (int)num5;
			Action action = null;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r10_v7 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass20_0._003CPlayExplosions_003Eb__0);
			((Delegate)action).m_target = obj4;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r10_v7 (Il2CppMethodInfo)+4C]");
			object obj7 = (nint)0 >> 4;
			object obj8 = obj7 & 1;
			nint num7;
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r10_v7 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num7 = unchecked((nint)6447293664L);
					goto IL_0434;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num7 = ((Delegate)action).method_ptr;
			goto IL_0434;
			IL_0434:
			object obj9 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			num = (float)(flag10 ? 1 : 0) * 0.001f;
			Timer item = Timers.Register(num, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			List<object> list4 = (List<object>)(object)explosionTimers;
			bool flag13 = explosionTimers == null;
			int version2 = list4._version + 1;
			list4._version = version2;
			object[] array = list4._items;
			bool flag14 = list4._items == null;
			if (list4._size >= array.Length)
			{
				((List<object>)(object)explosionTimers).AddWithResize((object)item);
			}
			else
			{
				int num8 = list4._size + 1;
				list4._size = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			list3 = explosionSprites;
			flag9 = (byte)((flag9 ? 1u : 0u) + 1u) != 0;
			flag10 = (byte)((flag10 ? 1u : 0u) + 30u) != 0;
			bool flag15 = explosionSprites == null;
			flag11 = flag9;
		}
	}

	public EnemyBeelzebubSection()
	{
		List<PhaserSprite> list = new List<PhaserSprite>();
		explosionSprites = list;
		ExplosionsNumber = 16;
		base._002Ector();
	}
}
