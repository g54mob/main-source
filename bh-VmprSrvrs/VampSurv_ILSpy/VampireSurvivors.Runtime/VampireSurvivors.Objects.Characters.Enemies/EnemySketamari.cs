using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySketamari : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public SpriteAnimation obj;

		internal void _003CMakeSpritesDisappear_003Eb__1()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6349]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			obj.SetAnimation("die");
		}
	}

	private GameObject _container;

	private List<SpriteRenderer> _containerChildren;

	private List<SpriteAnimation> _containerChildrenAnim;

	private float _radius;

	private EnemyType[] _enemiesArray;

	private PlaySoundResult _noise;

	private MultiTargetTween _onSineTween;

	private float _maxDistance;

	private MapToken _mapToken;

	private float _angle;

	private float _scale;

	private float _sineF;

	public unsafe Quaternion ContainerRotation
	{
		get
		{
			//IL_0113: Expected F4, but got O
			//IL_010e: Expected native int or pointer, but got O
			//IL_00f8->IL0106: Incompatible stack heights: 3 vs 0
			GameObject container = _container;
			Quaternion quaternion2;
			if ((object)_container != null && ((UnityEngine.Object)container).m_CachedPtr != (IntPtr)0)
			{
				bool flag = (object)_container == null;
				Transform transform = _container.transform;
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Quaternion ret);
				quaternion2 = ret;
			}
			else
			{
				quaternion2 = Quaternion.identityQuaternion;
			}
			Quaternion quaternion3 = default(Quaternion);
			((Quaternion*)(nint)quaternion3)->x = (float)quaternion2;
			return quaternion3;
		}
		set
		{
			//IL_00fb->IL00c5: Incompatible stack heights: 1 vs 0
			Transform container = (Transform)(object)_container;
			if ((object)_container == null || ((UnityEngine.Object)container).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if ((object)_container != null)
			{
				Transform transform = _container.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float value2 = default(float);
					Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)(&value2));
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_084b: Expected I, but got O
		//IL_000d: Expected I4, but got O
		//IL_001d: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_00d2: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0376: Expected I4, but got O
		//IL_04d4: Expected O, but got I4
		//IL_04dd: Expected O, but got I4
		//IL_09e1: Expected O, but got I4
		//IL_0a00: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_07f8: Expected O, but got I4
		//IL_052d: Expected I4, but got O
		//IL_065d: Expected O, but got I
		//IL_0680: Expected O, but got I
		//IL_0648: Expected O, but got I
		//IL_0996: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Expected O, but got Unknown
		//IL_0612: Expected O, but got I
		//IL_05da: Expected O, but got I
		//IL_0203->IL0203: Incompatible stack heights: 4 vs 2
		//IL_036c->IL036c: Incompatible stack heights: 5 vs 2
		//IL_093a->IL04a6: Incompatible stack heights: 7 vs 2
		//IL_09c0->IL0a09: Incompatible stack heights: 8 vs 3
		//IL_077b->IL077b: Incompatible stack heights: 8 vs 3
		//IL_0638->IL0962: Incompatible stack heights: 8 vs 7
		//IL_077a->IL0983: Incompatible stack heights: 12 vs 8
		base.InitEnemy(enemyType, asRemote);
		BaseBody baseBody = body;
		nint num = (nint)typeof(Body);
		bool flag = body == null;
		int num2 = (int)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v2 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r9_v10 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v2 (Il2CppClass<Body>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ r9_v10 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rax_v20+FFFFFFF8+v73 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				_ = 1;
				EnemyData currentEnemyData = _currentEnemyData;
				base._003CIsTeleportOnCull_003Ek__BackingField = false;
				base._003CIsCullable_003Ek__BackingField = false;
				bool flag2 = _currentEnemyData == null;
				_currentDirection = (Vector2)1065353216;
				_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
				float num4 = default(float);
				if (_noise == null)
				{
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Noise, new SoundManager.SoundConfig
					{
						Volume = (float?)(object)1,
						Rate = 1f,
						Loop = true
					}, 0f, 10, num4);
					_noise = playSoundResult;
					num2 = 10;
				}
				if (_mapToken == null)
				{
					MapToken mapToken = new MapToken();
					_mapToken = mapToken;
					GameManager core = GM.Core;
					bool flag3 = (object)GM.Core == null;
					bool flag4 = core._mapTokens == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
				}
				if (_onSineTween != null)
				{
					_onSineTween.Restart();
				}
				else
				{
					_sineF = 1f;
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					bool flag5 = array == null;
					object obj3 = array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					bool flag6 = tweenConfig == null;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					bool flag7 = dictionary == null;
					object value = default(object);
					bool flag8 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_SineF", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
					_ = 1184645120;
					_ = 4294967295L;
					_ = 1;
					_ = 4;
					MultiTargetTween onSineTween = Tweens.Add(tweenConfig);
					_onSineTween = onSineTween;
					num2 = 2;
				}
				EnemyType enemyType2 = (EnemyType)_container;
				_maxDistance = 42.426407f;
				if ((object)_container != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1018 @ rdi_v11 (VampireSurvivors.Data.EnemyType)+10]");
					if ((nint)0 != 0)
					{
						goto IL_04a6;
					}
				}
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "Sketamari_Container");
				_container = gameObject;
				bool flag9 = (object)_container == null;
				Transform transform = _container.transform;
				GameObject gameObject2 = base.gameObject;
				bool flag10 = (object)gameObject2 == null;
				Transform parent = gameObject2.transform;
				bool flag11 = (object)transform == null;
				transform.parent = parent;
				bool flag12 = (object)_container == null;
				Transform transform2 = _container.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1710 @ rax_v70 (UnityEngine.Transform)+10]");
				bool flag13 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1710 @ rax_v70 (UnityEngine.Transform)+10]");
				Vector3 value2 = default(Vector3);
				Transform.set_localPosition_Injected((IntPtr)0, ref value2);
				bool flag14 = default(bool);
				AddBones(250, 0.75f, 1f, num4, flag14);
				AddBones(150, 0.5f, 0.75f, num4, flag14);
				AddBones(100, 0f, 0.5f, num4, flag14);
				float num5 = 2f;
				goto IL_04a6;
			}
		}
		throw new InvalidCastException();
		IL_04a6:
		EnemyType[] enemiesArray = _enemiesArray;
		bool flag15 = _enemiesArray == null;
		float? num6 = (float?)(object)0;
		float? num7 = (float?)(object)0;
		while ((nint)num7 < enemiesArray.Length)
		{
			EnemyType[] enemiesArray2 = _enemiesArray;
			bool flag16 = _enemiesArray == null;
			bool flag17 = (nint)num6 >= enemiesArray2.Length;
			EnemyType enemyType3 = (EnemyType)GM.Core;
			bool flag18 = (object)GM.Core == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdi_v16 (VampireSurvivors.Data.EnemyType)+90]");
			EnemyType enemyType4 = EnemyType.BAT1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdi_v16 (VampireSurvivors.Data.EnemyType)+90]");
			bool flag19 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+68]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+58]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+78]");
					object obj5;
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+78]");
						obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v44+2CC]");
						if ((nint)0 != 0)
						{
							goto IL_0962;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+50]");
					obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+50]");
					bool flag20 = (nint)0 == 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+58]");
					object obj5 = 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v17 (VampireSurvivors.Data.EnemyType)+68]");
				object obj5 = 0;
			}
			goto IL_0962;
			IL_0962:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v44+1C8]");
			bool flag21 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v44+1C8]");
			int num8 = ((Dictionary<EnemyType, int>)0).FindEntry((EnemyType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref enemiesArray2[(object)num6]));
			if (num8 >= 0)
			{
				GameManager core2 = GM.Core;
				bool flag22 = (object)GM.Core == null;
				bool flag23 = core2._playerOptions == null;
				PlayerOptionsData config = core2._playerOptions.Config;
				bool flag24 = config == null;
				bool flag25 = config._003CKillCount_003Ek__BackingField == null;
				int num9 = config._003CKillCount_003Ek__BackingField.get_Item((EnemyType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref enemiesArray2[(object)num6]));
				float num10 = (float)num9 * 0.1f;
				float num5 = num10 + _maxHp;
				_maxHp = num5;
			}
			enemiesArray = _enemiesArray;
			num6 = (float?)(object)((_003F?)num6 + 1);
			bool flag26 = _enemiesArray != null;
			num7 = num6;
			if (!flag26)
			{
				break;
			}
		}
		if (_maxHp > 30000f)
		{
			_maxHp = 30000f;
		}
		_hp = _maxHp;
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		_scale = 0.25f;
		ArcadeSprite arcadeSprite2 = setScale(0.25f, (float?)(object)0);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_EnemyRenderer, 0f);
		bool flag27 = body == null;
		BaseBody baseBody2 = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		float radius = _scale * 200f;
		_radius = radius;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0139: Expected F4, but got I
		//IL_02b7: Expected F4, but got I4
		//IL_07e5: Expected O, but got I4
		//IL_0872: Expected O, but got I4
		//IL_088c: Expected O, but got I4
		//IL_0451: Expected O, but got I
		//IL_04a4: Invalid comparison between F4 and O
		//IL_050e: Expected I, but got O
		//IL_06dc->IL065f: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL065f: Incompatible stack heights: 1 vs 0
		//IL_0703->IL065f: Incompatible stack heights: 1 vs 0
		//IL_0751->IL065f: Incompatible stack heights: 2 vs 0
		//IL_0778->IL065f: Incompatible stack heights: 2 vs 0
		//IL_0124->IL065f: Incompatible stack heights: 2 vs 0
		//IL_079f->IL065f: Incompatible stack heights: 2 vs 0
		//IL_07ee->IL065e: Incompatible stack heights: 2 vs 0
		//IL_02e0->IL065f: Incompatible stack heights: 2 vs 0
		//IL_01dd->IL065f: Incompatible stack heights: 2 vs 0
		//IL_020c->IL065f: Incompatible stack heights: 2 vs 0
		//IL_022e->IL065f: Incompatible stack heights: 2 vs 0
		//IL_0840->IL065f: Incompatible stack heights: 3 vs 0
		//IL_0319->IL065f: Incompatible stack heights: 3 vs 0
		//IL_033b->IL065f: Incompatible stack heights: 3 vs 0
		//IL_065e->IL07d4: Incompatible stack heights: 3 vs 2
		//IL_08a3->IL08a8: Incompatible stack heights: 4 vs 3
		//IL_03cf->IL089a: Incompatible stack heights: 3 vs 4
		//IL_03b4->IL089a: Incompatible stack heights: 3 vs 4
		//IL_04b6->IL08a8: Incompatible stack heights: 7 vs 3
		//IL_0501->IL08a8: Incompatible stack heights: 8 vs 3
		//IL_0960->IL08a8: Incompatible stack heights: 8 vs 3
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		CheckDirection();
		float num = _sineF * _defaultSpeed;
		base._003CSpeed_003Ek__BackingField = num;
		Transform cachedTransform = _cachedTransform;
		float ret;
		float closestPlayerDistance;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			MapToken mapToken = _mapToken;
			if (_mapToken != null)
			{
				mapToken.x = ret;
				MapToken mapToken2 = _mapToken;
				if (_mapToken != null)
				{
					float y = default(float);
					mapToken2.y = y;
					closestPlayerDistance = GetClosestPlayerDistance();
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer = s_scene._renderer;
								if (s_scene._renderer != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rax_v54 (PhaserScene+Renderer)+38]");
									float num2 = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
									bool flag3 = _noise == null;
									float num4 = default(float);
									float num3 = num4;
									if (flag3)
									{
										goto IL_027e;
									}
									PlaySoundResult playSoundResult = _noise;
									float num5 = num4 / _maxDistance;
									if (num5 > 1f)
									{
										num5 = 1f;
									}
									GameManager core = GM.Core;
									if ((object)GM.Core != null)
									{
										PlayerOptions playerOptions = core._playerOptions;
										if (core._playerOptions != null)
										{
											PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
											if (playerOptions._mainGameConfig != null && (object)playSoundResult._003CActingVariation_003Ek__BackingField != null)
											{
												float num6 = 1f - num5;
												float num7 = num6 * mainGameConfig._003CSoundsVolume_003Ek__BackingField;
												num3 = num7 * 0.1f;
												playSoundResult._003CActingVariation_003Ek__BackingField.AdjustVolume(num3);
												goto IL_027e;
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
		goto IL_065f;
		IL_07d4:
		ArcadeSprite arcadeSprite = setScale(_scale, (float?)(object)0);
		return;
		IL_027e:
		float num8 = ((!(150f > _radius)) ? 0f : 0.9f);
		base._003CKnockBack_003Ek__BackingField = num8;
		MoveSketamari();
		if (600f > closestPlayerDistance)
		{
			Transform cachedTransform2 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Vector3*)(&ret));
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					PhysicsGroup enemies = core2.Enemies;
					if (core2.Enemies != null && ((Group)enemies).children != null)
					{
						HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
						object obj4 = default(object);
						while (enumerator.MoveNext())
						{
							EnemyController component = ((Component)null).GetComponent<EnemyController>();
							bool flag5 = (object)component == null;
							bool flag6 = (object)this == null;
							object obj = flag5 & flag6;
							bool flag7 = obj == null;
							object obj2 = !flag7;
							if (obj2 != null)
							{
								continue;
							}
							bool flag8;
							if ((object)this != null)
							{
								if ((object)component != null)
								{
									object obj3 = (object)component - (object)this;
									flag8 = obj3 == null;
								}
								else
								{
									flag8 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
								}
							}
							else
							{
								bool flag9 = (object)component == null;
								flag8 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
							}
							if (flag8)
							{
								continue;
							}
							bool flag10 = (object)component == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1654 @ rax_v72 (VampireSurvivors.Objects.Characters.EnemyController)+68]");
							bool flag11 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1654 @ rax_v72 (VampireSurvivors.Objects.Characters.EnemyController)+68]");
							Transform transform2 = ((Component)0).transform;
							bool flag12 = (object)transform2 == null;
							Vector3 vector = transform2.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
							float num9 = _radius * 0.01f;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
							{
								continue;
							}
							EnemyController component2 = component.GetComponent<EnemyController>();
							bool flag13 = (object)component2 == null;
							if (component2._003CIsDead_003Ek__BackingField)
							{
								continue;
							}
							nint num10 = (nint)component;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1844 @ rdx_v39 (Il2CppClass<UnityEngine.Transform>)+388] (should have been resolved before IL gen)");
							float num11;
							if (!(1f > _scale))
							{
								if (!(1.5f > _scale))
								{
									if (!(2f > _scale))
									{
										if (!(3f > _scale))
										{
											if (!(4f > _scale))
											{
												goto IL_08ce;
											}
											num11 = _scale + 0.00025f;
										}
										else
										{
											num11 = _scale + 0.0005f;
										}
										goto IL_0916;
									}
									float num12 = _scale + 0.00065f;
									_scale = num12;
								}
								else
								{
									float num13 = _scale + 0.00085f;
									_scale = num13;
								}
								goto IL_08ce;
							}
							num11 = _scale + 0.001f;
							goto IL_0916;
							IL_0916:
							_scale = num11;
							goto IL_08ce;
							IL_08ce:
							float radius = _scale * 200f;
							_radius = radius;
							float num2 = _scale;
							if (1f > _scale)
							{
								num2 = 1f;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1654 @ rax_v72 (VampireSurvivors.Objects.Characters.EnemyController)+1EC]");
							float num14 = 0f * 0.5f;
							float num15 = num14 / num2;
							if (num15 > 500f)
							{
								num15 = 500f;
							}
							float hp = num15 + _hp;
							_hp = hp;
							float maxHp = num15 + _maxHp;
							_maxHp = maxHp;
						}
						goto IL_07d4;
					}
				}
			}
			goto IL_065f;
		}
		goto IL_07d4;
		IL_065f:
		throw new NullReferenceException();
	}

	private void MoveSketamari()
	{
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_035c: Expected O, but got I4
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected F4, but got Unknown
		//IL_049f: Expected O, but got I4
		//IL_008c: Expected O, but got I
		//IL_00ff: Expected I, but got O
		//IL_0107: Expected I, but got O
		//IL_0117: Expected O, but got I
		//IL_0153: Expected O, but got I
		//IL_0190: Expected O, but got I
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_0246: Expected O, but got I4
		//IL_0261: Expected O, but got I8
		//IL_04df: Expected F4, but got O
		//IL_043c->IL043c: Incompatible stack heights: 1 vs 0
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null)
		{
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
				{
					goto IL_0291;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v36 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v36 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v36 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj = -3;
					bool flag2 = obj == null;
					flag = flag2;
				}
				if (!flag)
				{
					return;
				}
			}
			float num2;
			if (_receivingDamage)
			{
				float num = base._003CKnockBack_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				num2 = num ^ 0;
			}
			else
			{
				num2 = 1f;
			}
			bool flag3 = 0 < (nint)_currentDirection;
			object obj2 = 0 - _currentDirection;
			bool flag4 = obj2 == null;
			bool flag5 = !flag3;
			bool flag6 = !flag4;
			object obj3 = flag6 & flag5;
			_ = 0;
			float num3 = GameManager.EnemySpeed * base._003CSpeed_003Ek__BackingField;
			float num4 = num3 * num2;
			float num5 = num4 * base._003CSlow_003Ek__BackingField;
			float num6 = num5 * (float)_currentDirection;
			float xVel = num6 * 0.01f;
			setVelocity(xVel, (float?)(object)1);
			BaseBody baseBody = body;
			if (body != null)
			{
				nint num7 = (nint)typeof(Body);
				nint num8 = (nint)baseBody;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v10 (Il2CppClass<Body>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v8 (Il2CppClass<BaseBody>)+130]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v10 (Il2CppClass<Body>)+130]");
				if (num9 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v8 (Il2CppClass<BaseBody>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v23+FFFFFFF8+v121 @ rax_v22*8]");
					if (0 == (nint)typeof(Body))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v10 (Il2CppClass<Body>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v23+FFFFFFF8+v129 @ rcx_v18*8]");
						object obj7 = 0 - typeof(Body);
						bool flag7 = obj7 == null;
						bool flag8 = !flag7;
						CoherenceSync coherenceSync2 = null;
						if (flag8)
						{
							_ = baseBody._velocity;
							BaseBody baseBody2 = body;
							if (body == null)
							{
								goto IL_0291;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
						float deltaTime = PauseSystem.DeltaTime;
						object obj8 = default(object);
						float num10 = (float)obj8 * 100f;
						float num11 = _radius * 10f;
						float num12 = num10 / num11;
						float num13 = num12 * deltaTime;
						bool flag9 = obj3 != null;
						object obj9 = 1;
						if (!flag9)
						{
							obj9 = 4294967295L;
						}
						float num14 = num13 * 1000f;
						float num15 = num14 * (float)obj9;
						float num16 = num15 + _angle;
						_angle = num16;
						if ((object)_container != null)
						{
							Transform transform = _container.transform;
							Vector3 axis = default(Vector3);
							Quaternion.AngleAxis_Injected((float)typeof(Vector3), ref axis, out Quaternion _);
							bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Quaternion value = default(Quaternion);
							Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							float num17 = _radius * 0.01f;
							float num18 = GameManager.PlayerPxSpeed * 0.5f;
							float num19 = GameManager.PlayerPxSpeed - num17;
							if (num18 < num19)
							{
								num18 = num19;
							}
							base._003CSpeed_003Ek__BackingField = num18;
							return;
						}
					}
				}
			}
		}
		goto IL_0291;
		IL_0291:
		throw new NullReferenceException();
	}

	protected override void Die()
	{
		//IL_012b: Expected O, but got I4
		//IL_012b: Expected O, but got I
		//IL_0244: Expected I, but got O
		//IL_025e->IL01bc: Incompatible stack heights: 1 vs 0
		//IL_01b1->IL01b1: Incompatible stack heights: 1 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if (_noise != null)
		{
			SoundManager.StopSound(SfxType.Noise);
		}
		MakeSpritesDisappear();
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._mapTokens != null)
		{
			bool flag = ((List<object>)(object)core._mapTokens).Remove((object)_mapToken);
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
					if (config._003CCollectedItems_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+10]");
							bool flag2 = ((List<MapToken>)0).Remove((MapToken)37);
							if ((flag2 ? 1 : 0) != -1)
							{
								goto IL_01b1;
							}
						}
						PlayerOptionsData cachedTransform = (PlayerOptionsData)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							bool flag3 = cachedTransform._003CsaveDate_003Ek__BackingField == null;
							Transform.get_position_Injected((IntPtr)cachedTransform._003CsaveDate_003Ek__BackingField, out Vector3 _);
							if ((object)_gameManager != null)
							{
								Vector2 pos = default(Vector2);
								float value = default(float);
								ItemType relicType = default(ItemType);
								bool validatePickups = default(bool);
								Pickup pickup = _gameManager.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
								goto IL_01b1;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_01b1:
		base.Die();
	}

	public override void Disappear()
	{
		if (!base._003CIsDead_003Ek__BackingField)
		{
			if (_noise != null)
			{
				SoundManager.StopSound(SfxType.Noise);
			}
			MakeSpritesDisappear();
			GameManager core = GM.Core;
			bool flag = ((List<object>)(object)core._mapTokens).Remove((object)_mapToken);
			base.Disappear();
		}
	}

	private float GetClosestPlayerDistance()
	{
		//IL_0044: Expected F4, but got O
		//IL_02dd: Expected I, but got O
		//IL_00f8: Expected F4, but got I4
		//IL_029a->IL02e2: Incompatible stack heights: 8 vs 1
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		GameManager core = GM.Core;
		float num = 3.4028235E+38f;
		float num2 = (float)core._mainCharacters;
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		object obj3 = default(object);
		object obj4 = default(object);
		while (enumerator.MoveNext())
		{
			Transform transform2 = null;
			bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)transform2).m_CachedPtr);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag3 = (object)transform3 == null;
			bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret2);
			bool flag5 = (object)this == null;
			bool flag6 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
			Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			bool flag7 = (object)transform4 == null;
			bool flag8 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
			object obj = ret2 - ret;
			object obj2 = obj3 - obj4;
			nint num3 = (nint)typeof(Math);
			object obj5 = obj2 * obj2;
			object obj6 = obj * obj;
			double d = (double)obj5 + (double)obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rcx_v56 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
				num2 = 0f;
			}
			else
			{
				double num4 = Math.Sqrt(d);
				num2 = (float)num4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			if (num > num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private float GetDistanceToMyPlayer()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
		float result = default(float);
		return result;
	}

	private unsafe void MakeSpritesDisappear()
	{
		//IL_002e: Expected O, but got I4
		//IL_0131: Expected I, but got O
		//IL_0147: Expected O, but got I
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0196: Expected I, but got I8
		//IL_01f2: Expected O, but got F4
		//IL_01c3: Expected I, but got O
		//IL_0324: Expected I, but got I8
		//IL_0080: Expected I, but got O
		//IL_0096: Expected O, but got I
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_010d: Expected I, but got O
		//IL_024a: Expected I, but got I8
		//IL_02a4: Expected O, but got F4
		//IL_00f6: Expected I, but got I8
		//IL_01c8->IL030d: Incompatible stack heights: 1 vs 0
		//IL_01a4->IL01a4: Incompatible stack heights: 0 vs 1
		//IL_02a9->IL02a9: Incompatible stack heights: 1 vs 0
		object obj = 24;
		List<SpriteAnimation>.Enumerator enumerator2 = default(List<SpriteAnimation>.Enumerator);
		Action action;
		float num3;
		float num4;
		Timer timer;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		for (List<SpriteAnimation>.Enumerator enumerator = (List<SpriteAnimation>.Enumerator)_containerChildrenAnim; enumerator2.MoveNext(); ((Delegate)action).extra_arg = unchecked((nint)6447293568L), num3 = (float)enumerator * 1000f, num4 = num3 * 0.001f, timer = Timers.Register(num4, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false), enumerator = (List<SpriteAnimation>.Enumerator)num4)
		{
			_003C_003Ec__DisplayClass22_0 obj2 = new _003C_003Ec__DisplayClass22_0();
			bool flag = obj2 == null;
			obj2.obj = null;
			object obj3 = UnityEngine.Random.value;
			action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass22_0._003CMakeSpritesDisappear_003Eb__1);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num2;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r10_v6 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					continue;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
		}
		Action action2 = null;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r10_v5 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(EnemySketamari._003CMakeSpritesDisappear_003Eb__22_0);
		((Delegate)action2).m_target = this;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r10_v5 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num6;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ r10_v5 (Il2CppMethodInfo)+52]");
			bool flag2 = (nint)0 == 0;
			num6 = unchecked((nint)6447293664L);
			if (flag2)
			{
				goto IL_030d;
			}
		}
		else
		{
			bool flag3 = (object)this == null;
		}
		num6 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_030d;
		IL_030d:
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer timer2 = Timers.Register(1.5000001f, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void CheckDirection()
	{
		//IL_01e5: Invalid comparison between O and F4
		//IL_0125: Expected O, but got I8
		//IL_00a3: Invalid comparison between F4 and O
		//IL_0153: Expected O, but got I
		//IL_017c: Expected O, but got I4
		//IL_00c2: Expected O, but got I4
		//IL_00f0: Expected O, but got I
		//IL_0109: Expected O, but got I4
		//IL_00b2->IL01ab: Incompatible stack heights: 1 vs 0
		//IL_0233->IL01ab: Incompatible stack heights: 3 vs 0
		//IL_01a4->IL01a4: Incompatible stack heights: 4 vs 0
		if (base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if ((object)_coherenceSync != null)
		{
			if (!_coherenceSync.HasStateAuthority)
			{
				return;
			}
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				bool num;
				bool num2;
				object obj2 = default(object);
				object obj6 = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)102.399994f))
				{
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-102.399994f)) < System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret))
					{
						return;
					}
					_currentDirection = (Vector2)1065353216;
					Transform transform2 = base.transform;
					bool flag2 = (object)transform2 == null;
					num = flag2;
					IntPtr cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					num2 = flag3;
					object obj = 0;
					ret = (Vector3)obj2;
					object obj3 = obj2;
					object obj4 = 0;
					object obj5 = obj6;
				}
				else
				{
					_currentDirection = (Vector2)3212836864L;
					Transform transform3 = base.transform;
					bool flag4 = (object)transform3 == null;
					num = flag4;
					IntPtr cachedPtr = ((UnityEngine.Object)transform3).m_CachedPtr;
					bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					num2 = flag5;
					object obj = 0;
					bool flag6 = (nint)0 != 0;
					ret = (Vector3)obj2;
					object obj3 = obj2;
					object obj4 = 0;
					object obj5 = obj6;
					if (!flag6)
					{
						bool flag7 = (nint)0 == 0;
						goto IL_01a4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v766 @ rax_v31 (should have been resolved before IL gen)");
				return;
			}
		}
		goto IL_01a4;
		IL_01a4:
		throw new NullReferenceException();
	}

	private unsafe void AddBones(int amount, float radiusMin, float radiusMax, float scaleMax, bool flipY)
	{
		//IL_003e: Expected O, but got I4
		//IL_05d0: Expected O, but got I4
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_01c9: Expected O, but got I
		//IL_01f2: Expected O, but got I
		//IL_0254: Expected O, but got Ref
		//IL_02dc: Expected O, but got I
		//IL_0315: Expected O, but got I
		//IL_0345: Expected I4, but got O
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected I4, but got Unknown
		//IL_0428: Expected O, but got I
		//IL_0453: Expected I4, but got O
		//IL_04a0->IL0596: Incompatible stack heights: 1 vs 0
		//IL_03a9->IL0596: Incompatible stack heights: 1 vs 0
		//IL_04cc->IL0596: Incompatible stack heights: 1 vs 0
		//IL_03ce->IL0596: Incompatible stack heights: 1 vs 0
		//IL_04f8->IL0596: Incompatible stack heights: 1 vs 0
		//IL_0521->IL0596: Incompatible stack heights: 1 vs 0
		//IL_0404->IL0596: Incompatible stack heights: 1 vs 0
		//IL_0595->IL05d5: Incompatible stack heights: 1 vs 0
		if (_dataManager != null)
		{
			Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
			if (amount <= 0)
			{
				return;
			}
			object obj = 0;
			int num = amount;
			string text = default(string);
			Vector3 value3 = default(Vector3);
			object obj4 = default(object);
			object obj5 = default(object);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			object obj6 = default(object);
			object obj7 = default(object);
			string frameNames2 = default(string);
			object obj8 = default(object);
			while (true)
			{
				EnemyType[] enemiesArray = _enemiesArray;
				if (_enemiesArray == null)
				{
					break;
				}
				object obj2 = UnityEngine.Random.RandomRangeInt(0, enemiesArray.Length);
				if (convertedEnemyData == null)
				{
					break;
				}
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).get_Item((System.Int32Enum)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref enemiesArray[obj2]));
				if (obj3 != null)
				{
					List<EnemyData> list = ((Dictionary<EnemyType, List<EnemyData>>)obj3).get_Item(EnemyType.BAT1);
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm9,r13d\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,esi\"");
						float value = UnityEngine.Random.value;
						List<EnemyData> list2 = ((Dictionary<EnemyType, List<EnemyData>>)null).get_Item(EnemyType.BAT1);
						float value2 = UnityEngine.Random.value;
						List<EnemyData> list3 = ((Dictionary<EnemyType, List<EnemyData>>)null).get_Item(EnemyType.BAT1);
						List<EnemyData> list4 = ((Dictionary<EnemyType, List<EnemyData>>)obj3).get_Item(EnemyType.BAT1);
						if (list4 == null)
						{
							break;
						}
						List<EnemyData> list5 = ((Dictionary<EnemyType, List<EnemyData>>)obj3).get_Item(EnemyType.BAT1);
						if (list5 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.Enemies.EnemyData>)+D8]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.Enemies.EnemyData>)+D8]");
						List<EnemyData> list6 = ((Dictionary<EnemyType, List<EnemyData>>)0).get_Item(EnemyType.BAT1);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v28 (System.Collections.Generic.List`1<VampireSurvivors.Data.Enemies.EnemyData>)+C8]");
						SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(this, 0f, 0f, (string)0, text);
						if ((object)spriteRenderer == null)
						{
							break;
						}
						Transform transform = spriteRenderer.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1022 @ rax_v33 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1022 @ rax_v33 (UnityEngine.Transform)+10]");
						Transform.set_localPosition_Injected((IntPtr)0, ref value3);
						float value4 = UnityEngine.Random.value;
						bool flag2 = value4 < 0.5f;
						bool flag3 = !flag2;
						spriteRenderer.flipX = flag3;
						float value5 = UnityEngine.Random.value;
						Transform transform2 = spriteRenderer.transform;
						transform2.localEulerAngles = (Vector3)(&obj4);
						float value6 = UnityEngine.Random.value;
						float num2 = value6 * (float)obj5;
						float num3 = num2 + 1f;
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(spriteRenderer, num3);
						GameObject gameObject = spriteRenderer.gameObject;
						SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale((SpriteRenderer)obj3, num3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rax_v44 (UnityEngine.SpriteRenderer)+170]");
						SpriteRenderer frameNames = RenderingExtensions.SetScale((SpriteRenderer)0, num3);
						SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale((SpriteRenderer)obj3, num3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1026 @ rax_v46 (UnityEngine.SpriteRenderer)+C8]");
						List<Sprite> animationFramesFast = SpriteManager.GetAnimationFramesFast((List<string>)(object)frameNames, (string)0);
						spriteAnimation.AddAnimation("die", animationFramesFast, 24, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ rax_v50+BC]");
						bool flag4 = (nint)0 == 0;
						int num4 = 24;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (obj6 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v61+168]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (obj7 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v63+C8]");
							List<Sprite> animationFramesFast2 = SpriteManager.GetAnimationFramesFast((List<string>)(object)frameNames2, (string)0);
							spriteAnimation.AddAnimation("idle", animationFramesFast2, 8, (byte)(int)text != 0, startRandomFrame, onComplete, autoSetAnimation);
							spriteAnimation.SetAnimation("idle");
							num4 = 8;
						}
						Transform transform3 = spriteRenderer.transform;
						if ((object)_container == null)
						{
							break;
						}
						Transform parent = _container.transform;
						if ((object)transform3 == null)
						{
							break;
						}
						transform3.parent = parent;
						if (_containerChildren == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
						if (_containerChildrenAnim == null)
						{
							break;
						}
						((List<object>)(object)_containerChildrenAnim).Add((object)spriteAnimation);
						int maxExclusive = obj + 1;
						int sortingOrder = UnityEngine.Random.Range(0, maxExclusive);
						spriteRenderer.sortingOrder = sortingOrder;
						obj4 = obj8;
						value3 = (Vector3)obj8;
						text = text;
						num = amount;
					}
				}
				obj++;
				if ((nint)obj >= num)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public EnemySketamari()
	{
		List<SpriteRenderer> containerChildren = new List<SpriteRenderer>();
		_containerChildren = containerChildren;
		_containerChildrenAnim = new List<SpriteAnimation>();
		_radius = 200f;
		_enemiesArray = new EnemyType[10]
		{
			EnemyType.SKELETON,
			EnemyType.SKELETON2,
			EnemyType.SKELETON3,
			EnemyType.SKELETON4,
			EnemyType.SKULLINO,
			EnemyType.SKELEPANTHER,
			EnemyType.SKELETONE,
			EnemyType.SKELEWING_ZONE,
			EnemyType.SKULLNOAURA,
			EnemyType.SKULLNOAURA
		};
		_scale = 1f;
		base._002Ector();
	}

	private void _003CMakeSpritesDisappear_003Eb__22_0()
	{
		_container.SetActive(value: false);
	}
}
