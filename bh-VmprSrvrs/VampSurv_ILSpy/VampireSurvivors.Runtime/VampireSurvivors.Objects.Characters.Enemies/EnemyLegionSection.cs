using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyLegionSection : EnemyController
{
	private EnemyLegion _parentBoss;

	private int2 _direction;

	private bool _isFalling;

	private float _fallTimer;

	public void OnlineSetupSection(CoherenceSync boss, Vector2 direction)
	{
		EnemyLegion component = boss.GetComponent<EnemyLegion>();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rsp+20h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rsp+24h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 49 Invalid \"Jump target not found in method: 0x1876AB460\"");
		throw new NullReferenceException();
	}

	public void SetupLegionSection(EnemyLegion parentBoss, int2 direction)
	{
		//IL_0058: Expected O, but got I4
		//IL_020a: Expected I4, but got O
		_parentBoss = parentBoss;
		GameObject owner = parentBoss.gameObject;
		base.SetOwner(owner);
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		_treasure = null;
		_direction = direction;
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setFlipX(flipX: false);
		if ((object)direction != null)
		{
			goto IL_0168;
		}
		object obj = default(object);
		Sprite sprite2;
		if (obj != null)
		{
			if ((nint)obj != 1)
			{
				if ((nint)obj != -1)
				{
					goto IL_0168;
				}
				Sprite sprite = SpriteManager.GetSprite("Legion_S", "Legion");
				sprite2 = sprite;
			}
			else
			{
				Sprite sprite3 = SpriteManager.GetSprite("Legion_N", "Legion");
				sprite2 = sprite3;
			}
		}
		else
		{
			Sprite sprite4 = SpriteManager.GetSprite("Legion_Middle", "Legion");
			sprite2 = sprite4;
		}
		goto IL_03c7;
		IL_03c7:
		if ((object)sprite2 != null && ((UnityEngine.Object)sprite2).m_CachedPtr != (IntPtr)0)
		{
			ArcadeSprite arcadeSprite3 = setFrame(sprite2);
		}
		BaseBody baseBody = body;
		baseBody._immovable = true;
		BaseBody baseBody2 = body;
		baseBody2._pushable = false;
		BaseBody baseBody3 = body;
		baseBody3._enable = false;
		_isFalling = false;
		_fallTimer = 0f;
		UpdateSection();
		List<object> sections = (List<object>)(object)parentBoss._sections;
		int version = sections._version + 1;
		sections._version = version;
		object[] items = sections._items;
		if (sections._size >= items.Length)
		{
			sections.AddWithResize((object)this);
			return;
		}
		int num = sections._size + 1;
		sections._size = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		return;
		IL_0168:
		string spriteName;
		if ((nint)obj != 1)
		{
			if ((nint)obj != -1)
			{
				bool flag = obj != null;
				sprite2 = null;
				if (flag)
				{
					goto IL_03c7;
				}
				spriteName = "Legion_W";
			}
			else
			{
				spriteName = "Legion_SW";
			}
		}
		else
		{
			spriteName = "Legion_NW";
		}
		Sprite sprite5 = SpriteManager.GetSprite(spriteName, "Legion");
		bool flag2 = (nint)direction != 1;
		sprite2 = sprite5;
		if (!flag2)
		{
			ArcadeSprite arcadeSprite4 = setFlipX((byte)(int)direction != 0);
			sprite2 = sprite5;
		}
		goto IL_03c7;
	}

	public unsafe void SetOutlineColour(Color c)
	{
		//IL_0059: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6077]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		CheckRenderer();
		Material material = ((Renderer)((ArcadeSprite)this)._spriteRenderer).GetMaterial();
		object obj = default(object);
		material.SetColor("_ReplacementColour", (Color)(&obj));
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0062: Expected O, but got I4
		//IL_01d4: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		if ((object)_direction == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rcx_v1 (VampireSurvivors.Objects.Characters.Enemies.EnemyLegionSection)+27C]");
			if ((nint)0 == 0)
			{
				List<EnemyLegionSection>.Enumerator enumerator = default(List<EnemyLegionSection>.Enumerator);
				while (true)
				{
					if (!enumerator.MoveNext())
					{
						return;
					}
					object obj = 0;
					bool flag = (object)this == null;
					bool flag2 = !flag;
					object obj2 = !flag2;
					if (obj2 == null)
					{
						if ((object)this == null)
						{
							nint num = (nint)typeof(UnityEngine.Object);
							throw new NullReferenceException();
						}
						if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
						{
							break;
						}
					}
				}
			}
		}
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
	}

	public bool IsMiddleSection()
	{
		if ((object)_direction != null)
		{
			return false;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyLegionSection)+27C]");
		return (nint)0 == 0;
	}

	public override void Disappear()
	{
		//IL_0053: Invalid comparison between I4 and F4
		EnemyLegion parentBoss = _parentBoss;
		if ((object)_parentBoss != null && ((UnityEngine.Object)parentBoss).m_CachedPtr != (IntPtr)0)
		{
			EnemyLegion parentBoss2 = _parentBoss;
			if (!(0f < parentBoss2._timeUntilSectionsVulnerable))
			{
				base._003CIsDead_003Ek__BackingField = true;
				parentBoss2._timeUntilSectionsVulnerable = 5f;
			}
		}
	}

	protected override void Die()
	{
		//IL_0053: Invalid comparison between I4 and F4
		EnemyLegion parentBoss = _parentBoss;
		if ((object)_parentBoss != null && ((UnityEngine.Object)parentBoss).m_CachedPtr != (IntPtr)0)
		{
			EnemyLegion parentBoss2 = _parentBoss;
			if (!(0f < parentBoss2._timeUntilSectionsVulnerable))
			{
				base._003CIsDead_003Ek__BackingField = true;
				parentBoss2._timeUntilSectionsVulnerable = 5f;
			}
		}
	}

	protected override void OnUpdate()
	{
		//IL_0065: Expected F4, but got I4
		if (base._003CIsDead_003Ek__BackingField)
		{
			if (_isFalling)
			{
				goto IL_008d;
			}
			_isFalling = true;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Scream, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
		}
		if (_isFalling)
		{
			goto IL_008d;
		}
		return;
		IL_008d:
		float deltaTime = PauseSystem.DeltaTime;
		BaseBody baseBody = body;
		float fallTimer = deltaTime + _fallTimer;
		_fallTimer = fallTimer;
		baseBody._enable = false;
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num = deltaTime2 * (float)_direction;
		float num2 = num * -40f;
		float num3 = num2 + localEulerAngles.z;
		base.angle = num3;
		if (_fallTimer > 2f)
		{
			base.Despawn();
		}
	}

	public void UpdateSection()
	{
		//IL_0283: Unsupported input type for neg.
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected I4, but got Unknown
		//IL_0190: Expected O, but got I4
		//IL_0199: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		//IL_011e: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_0167: Expected O, but got I4
		//IL_02be->IL01c7: Incompatible stack heights: 1 vs 0
		//IL_00b3->IL02c3: Incompatible stack heights: 1 vs 0
		//IL_01a2->IL01c7: Incompatible stack heights: 1 vs 0
		//IL_01c7->IL02c3: Incompatible stack heights: 1 vs 0
		if (_isFalling)
		{
			return;
		}
		BaseBody baseBody;
		float? offsetY;
		float? offsetX;
		if ((object)_owner != null)
		{
			Transform transform = _owner.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				object obj = default(object);
				float num = (float)obj - 0.25f;
				float num2 = (float)_direction * 1.1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyLegionSection)+27C]");
				float num3 = 0f * 1.1f;
				float num4 = num + num3;
				float2 float5 = default(float2);
				base.position = float5;
				EnemyLegion parentBoss = _parentBoss;
				object obj2 = 0 - _direction;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb eax,eax\"");
				int num5 = (int)(obj2 + 4294967107L);
				if ((object)_parentBoss != null)
				{
					if (parentBoss._phase >= EnemyLegion.LegionBossPhase.Normal)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
					}
					ArcadeSprite arcadeSprite = setDepth(num5);
					if (body == null)
					{
						return;
					}
					if ((object)_direction != null)
					{
						goto IL_016c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyLegionSection)+27C]");
					if ((nint)0 == 0)
					{
						baseBody = body;
						offsetY = (float?)(object)1;
						offsetX = (float?)(object)1;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyLegionSection)+27C]");
						if ((nint)0 != 1)
						{
							goto IL_016c;
						}
						baseBody = body;
						offsetY = (float?)(object)1;
						offsetX = (float?)(object)1;
					}
					goto IL_01a7;
				}
			}
		}
		goto IL_01c7;
		IL_016c:
		baseBody = body;
		bool flag2 = body == null;
		offsetY = (float?)(object)1;
		offsetX = (float?)(object)1;
		if (!flag2)
		{
			goto IL_01a7;
		}
		goto IL_01c7;
		IL_01a7:
		BaseBody baseBody2 = baseBody.setCircle(32f, offsetX, offsetY);
		return;
		IL_01c7:
		throw new NullReferenceException();
	}
}
