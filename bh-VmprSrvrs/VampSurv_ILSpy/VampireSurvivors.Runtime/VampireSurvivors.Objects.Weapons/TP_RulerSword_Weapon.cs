using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_RulerSword_Weapon : Weapon
{
	private Projectile _InvisibleProjectilePrefab;

	private GameObject _SwordsContainer;

	public BulletPool InvisibleProjectilesPool;

	private List<TP_RulerSword_Weapon_Sprite> _swords;

	private Vector3 innerRadius;

	private float momentum;

	private float lastVelX;

	private int _activeCount;

	private bool _isAttacking;

	public BulletPool SwordsPool => _projectilePool;

	protected override void OnStart()
	{
		base.OnStart();
	}

	private TP_RulerSword_Weapon_Sprite AddRulerSwordSprite(Vector2 pos, string textureName, string spriteName)
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PhaserSprite");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			if ((object)_SwordsContainer != null)
			{
				Transform parent = _SwordsContainer.transform;
				if ((object)transform != null)
				{
					transform.SetParent(parent, worldPositionStays: false);
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					TP_RulerSword_Weapon_Sprite tP_RulerSword_Weapon_Sprite = gameObject.AddComponent<TP_RulerSword_Weapon_Sprite>();
					bool flag3 = (object)tP_RulerSword_Weapon_Sprite == null;
					((PhaserSprite)tP_RulerSword_Weapon_Sprite).EnsureSpriteRenderer();
					Sprite sprite = SpriteManager.GetSprite(spriteName, textureName);
					PhaserSprite phaserSprite = tP_RulerSword_Weapon_Sprite.setFrame(sprite);
					return tP_RulerSword_Weapon_Sprite;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0032: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_00fc: Expected O, but got I
		//IL_0373: Expected O, but got I
		//IL_0389: Expected O, but got I4
		//IL_039e: Expected O, but got I
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_01da: Expected O, but got I
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_04b2->IL033f: Incompatible stack heights: 1 vs 0
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
		do
		{
			bool flag = AddNextSword();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5440]");
		}
		while ((nint)0 != 0);
		List<TP_RulerSword_Weapon_Sprite> swords = _swords;
		bool flag2 = _swords == null;
		bool flag3 = false;
		object obj = 0;
		object obj2 = 0;
		if (!flag2)
		{
			while (true)
			{
				if ((nint)obj < swords._size)
				{
					List<TP_RulerSword_Weapon_Sprite> swords2 = _swords;
					if (_swords == null)
					{
						break;
					}
					if ((nint)obj2 >= swords2._size)
					{
						goto IL_034b;
					}
					object items = swords2._items;
					if (swords2._items == null)
					{
						break;
					}
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rbx_v12 (System.Object)+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rbx_v12 (System.Object)+20+v118 @ rdi_v6*8]");
						PhaserSprite phaserSprite = (PhaserSprite)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rbx_v12 (System.Object)+20+v118 @ rdi_v6*8]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rbx_v12 (System.Object)+20+v118 @ rdi_v6*8]");
						PhaserSprite phaserSprite2 = ((PhaserSprite)0).setVisible(visible: false);
						flag3 = false;
						object obj4 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbx_v13 (VampireSurvivors.Framework.Phaser.PhaserSprite)+58]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbx_v13 (VampireSurvivors.Framework.Phaser.PhaserSprite)+58]");
							if ((nint)0 == 0)
							{
								break;
							}
							object obj6 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v34+18]");
							if ((nint)obj6 >= 0)
							{
								goto IL_023d;
							}
							object obj7 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v34+18]");
							if ((nint)obj7 >= 0)
							{
								goto IL_034b;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v34+10]");
							flag3 = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v34+10]");
							if ((uint)(~(nuint)0u) != 0)
							{
								break;
							}
							object obj8 = obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v10 (System.Boolean)+18]");
							if ((nint)obj8 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v10 (System.Boolean)+20+v91 @ rax_v38*8]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v10 (System.Boolean)+20+v91 @ rax_v38*8]");
								if ((nint)0 == 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v37+28]");
								if ((nint)0 == 0)
								{
									break;
								}
								_ = 0;
								obj4++;
								continue;
							}
							goto IL_0351;
						}
						break;
					}
					goto IL_0351;
				}
				object swordsContainer = _SwordsContainer;
				_activeCount = 0;
				if ((object)_SwordsContainer == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v9 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_SwordsContainer);
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rbx_v9 (System.Object)+10]");
				IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				object obj10 = ((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rbx_v10 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rbx_v10 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				if ((object)transform == null)
				{
					break;
				}
				transform.SetParent(parent, worldPositionStays: true);
				return;
				IL_023d:
				swords = _swords;
				obj2++;
				if (_swords == null)
				{
					break;
				}
				obj = obj2;
				continue;
				IL_034b:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				goto IL_0351;
				IL_0351:
				throw new IndexOutOfRangeException();
			}
		}
		throw new NullReferenceException();
	}

	public bool ShowNextSword()
	{
		List<TP_RulerSword_Weapon_Sprite> swords = _swords;
		if (_activeCount < swords._size)
		{
			List<TP_RulerSword_Weapon_Sprite> swords2 = _swords;
			int activeCount = _activeCount;
			if (_activeCount < swords2._size)
			{
				TP_RulerSword_Weapon_Sprite[] items = swords2._items;
				items[activeCount].Enable();
				int activeCount2 = _activeCount + 1;
				_activeCount = activeCount2;
				return true;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}
		return false;
	}

	private void AddSword(TP_RulerSword_Weapon_Sprite swordToAdd)
	{
		//IL_0375: Expected O, but got F4
		//IL_0387: Expected O, but got F4
		//IL_03b0->IL0247: Incompatible stack heights: 6 vs 0
		//IL_01db->IL0247: Incompatible stack heights: 6 vs 0
		if ((object)swordToAdd != null)
		{
			Transform transform = swordToAdd.transform;
			if ((object)_SwordsContainer != null)
			{
				Transform parent = _SwordsContainer.transform;
				if ((object)transform != null)
				{
					transform.SetParent(parent, worldPositionStays: true);
					Transform transform2 = swordToAdd.transform;
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					Transform transform3 = swordToAdd.transform;
					bool flag2 = (object)transform3 == null;
					bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Quaternion value2 = default(Quaternion);
					Transform.set_localRotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
					List<TP_RulerSword_Weapon_Sprite> swords = _swords;
					bool flag4 = _swords == null;
					float num = (float)swords._size * 30f;
					float num2 = num * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num3 = num2 * 0.125f;
					float num4 = num * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num5 = num4 * 0.125f;
					float num6 = num * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num7 = num6 * 1.65f;
					float num8 = num * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num9 = num8 * 1.65f;
					Transform transform4 = swordToAdd.transform;
					bool flag5 = (object)transform4 == null;
					bool flag6 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					Vector3 value3 = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value3);
					float angle = num + 90f;
					swordToAdd.angle = angle;
					swordToAdd.offset_Idle = (Vector2)num3;
					swordToAdd.offset_Attack = (Vector2)num7;
					List<object> swords2 = (List<object>)(object)_swords;
					if (_swords != null)
					{
						int version = swords2._version + 1;
						swords2._version = version;
						object[] items = swords2._items;
						if (swords2._items != null)
						{
							if (swords2._size >= items.Length)
							{
								((List<object>)(object)_swords).AddWithResize((object)swordToAdd);
								return;
							}
							int size = swords2._size + 1;
							swords2._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private TP_RulerSword_Weapon_Sprite MakeSword_Large()
	{
		Vector2 pos = default(Vector2);
		TP_RulerSword_Weapon_Sprite tP_RulerSword_Weapon_Sprite = AddRulerSwordSprite(pos, "character_tp_swordruler", "RulerSword_L");
		if ((object)tP_RulerSword_Weapon_Sprite != null)
		{
			tP_RulerSword_Weapon_Sprite.Initialize(this, 3);
			return tP_RulerSword_Weapon_Sprite;
		}
		return (TP_RulerSword_Weapon_Sprite)(object)new NullReferenceException();
	}

	private TP_RulerSword_Weapon_Sprite MakeSword_Small()
	{
		Vector2 pos = default(Vector2);
		TP_RulerSword_Weapon_Sprite tP_RulerSword_Weapon_Sprite = AddRulerSwordSprite(pos, "character_tp_swordruler", "RulerSword_S");
		if ((object)tP_RulerSword_Weapon_Sprite != null)
		{
			tP_RulerSword_Weapon_Sprite.Initialize(this, 2);
			return tP_RulerSword_Weapon_Sprite;
		}
		return (TP_RulerSword_Weapon_Sprite)(object)new NullReferenceException();
	}

	public bool AddNextSword()
	{
		//IL_009f: Expected I4, but got O
		//IL_0066: Expected O, but got I8
		//IL_0080: Expected O, but got I8
		List<TP_RulerSword_Weapon_Sprite> swords = _swords;
		if (_swords != null)
		{
			if (swords._size < 12)
			{
				int size = swords._size;
				if (swords._size <= 11)
				{
					object obj = 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v1+745DC30+v58 @ rcx_v3 (System.Int32)*4]");
					object obj2 = 0 + 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ rcx_v5 (should have been resolved before IL gen)");
				}
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void Fire()
	{
	}

	public void Attack()
	{
		//IL_00e2: Expected O, but got I4
		//IL_011f: Expected F4, but got I4
		//IL_013f: Expected O, but got I4
		//IL_0177: Expected F4, but got I4
		//IL_0197: Expected O, but got I4
		//IL_01cf: Expected F4, but got I4
		_isAttacking = true;
		Action onComplete = delegate
		{
			_isAttacking = false;
		};
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		List<TP_RulerSword_Weapon_Sprite> swords = _swords;
		bool flag2 = false;
		bool flag3 = false;
		while (true)
		{
			if ((flag3 ? 1 : 0) < swords._size)
			{
				List<TP_RulerSword_Weapon_Sprite> swords2 = _swords;
				if ((flag2 ? 1 : 0) >= swords2._size)
				{
					break;
				}
				TP_RulerSword_Weapon_Sprite[] items = swords2._items;
				items[flag2 ? 1u : 0u].Attack();
				swords = _swords;
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				flag3 = flag2;
				continue;
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = 1f;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig, 50f, 5, flag ? 1 : 0);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			soundConfig2.Detune = 1000f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig2, 50f, 5, flag ? 1 : 0);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 1f;
			soundConfig3.Detune = -1000f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig3, 50f, 5, flag ? 1 : 0);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected F4, but got Unknown
		//IL_0070: Invalid comparison between F4 and I4
		//IL_03c5: Expected O, but got F4
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected F4, but got Unknown
		//IL_0126: Invalid comparison between F4 and I4
		//IL_0263: Invalid comparison between F4 and I4
		//IL_032c: Expected O, but got F4
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected F4, but got Unknown
		//IL_037d: Expected F4, but got I4
		//IL_0455: Expected O, but got F4
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected F4, but got Unknown
		//IL_00a7: Invalid comparison between F4 and I4
		//IL_018a: Invalid comparison between F4 and I4
		//IL_04d2: Expected O, but got F4
		//IL_031d: Expected O, but got Ref
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PMoveSpeed();
		Vector2 velocity = ((Equipment)this)._003COwner_003Ek__BackingField.Velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018745E17Dh\"");
		float num3;
		object obj2 = default(object);
		float num12;
		if ((object)velocity == null)
		{
			Vector2 velocity2 = ((Equipment)this)._003COwner_003Ek__BackingField.Velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018745E0A1h\"");
			float num2 = default(float);
			if (num2 != 0f)
			{
				num3 = lastVelX;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018745E0D7h\"");
				float num4;
				if (lastVelX == 0f)
				{
					Vector2 velocity3 = ((Equipment)this)._003COwner_003Ek__BackingField.Velocity;
					num4 = num2;
				}
				else
				{
					num4 = lastVelX;
				}
				object obj = Time.deltaTime;
				float num5 = num4 * 18000f;
				float num6 = num3 * 100f;
				float num7 = num5 * (float)obj2;
				float num8 = num7 - momentum;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				float num9 = num8 & 0;
				if (num6 < num9)
				{
					float num10 = num7 - momentum;
					if (!(num10 < 0f))
					{
						float num11 = num6 * 1f;
						num12 = num11 + momentum;
						num3 = 1f;
					}
					else
					{
						float num13 = num6 * -1f;
						num12 = num13 + momentum;
						num3 = -1f;
					}
				}
				else
				{
					num12 = num7;
				}
			}
			else
			{
				object obj3 = Time.deltaTime;
				num3 = num2 * 80f;
				float num14 = 0f - momentum;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				float num15 = num14 & 0;
				bool flag = !(num3 < num15);
				num12 = 0f;
				if (!flag)
				{
					float num16 = 0f - momentum;
					if (!(num16 < 0f))
					{
						float num17 = 1f * num3;
						num12 = num17 + momentum;
					}
					else
					{
						float num18 = -1f * num3;
						num12 = num18 + momentum;
					}
				}
			}
		}
		else
		{
			Vector2 velocity4 = ((Equipment)this)._003COwner_003Ek__BackingField.Velocity;
			num3 = (lastVelX = velocity4 ^ -0f);
			Vector2 velocity5 = ((Equipment)this)._003COwner_003Ek__BackingField.Velocity;
			object obj4 = Time.deltaTime;
			float num19 = num3 * 100f;
			object obj5 = velocity5 ^ -0f;
			float num20 = (float)obj5 * 18000f;
			float num21 = num20 * (float)obj2;
			float num22 = num21 - momentum;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			float num23 = num22 & 0;
			if (num19 < num23)
			{
				float num24 = num21 - momentum;
				if (!(num24 < 0f))
				{
					float num25 = num19 * 1f;
					num12 = num25 + momentum;
					num3 = 1f;
				}
				else
				{
					float num26 = num19 * -1f;
					num12 = num26 + momentum;
					num3 = -1f;
				}
			}
			else
			{
				num12 = num21;
			}
		}
		momentum = num12;
		if (!_isAttacking)
		{
			Transform transform = _SwordsContainer.transform;
			object obj6 = Time.deltaTime;
			float angle = num3 * momentum;
			object obj7 = default(object);
			transform.Rotate((Vector3)(&obj7), angle, Space.Self);
		}
	}

	public override void SetVisible(bool visible)
	{
	}

	public TP_RulerSword_Weapon()
	{
		List<TP_RulerSword_Weapon_Sprite> swords = new List<TP_RulerSword_Weapon_Sprite>();
		_swords = swords;
		Vector3 vector = default(Vector3);
		innerRadius = vector;
		_ = 0;
		base._002Ector();
	}

	private void _003CAttack_003Eb__20_0()
	{
		_isAttacking = false;
	}
}
