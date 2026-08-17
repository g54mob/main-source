using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_FullAutoProjectile : Projectile
{
	private static string[] s_frameNames;

	private float _MaxAlpha = 0.75f;

	private float _AlphaDiff = 0.25f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("BulletRed", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		float alphaDiff = 1f - _MaxAlpha;
		_AlphaDiff = alphaDiff;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0199: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_0172: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		float num = _weapon.PArea();
		float num2 = default(float);
		ArcadeSprite arcadeSprite2 = setScale(num2, (float?)(object)0);
		float alpha;
		if (!(num2 > 5f))
		{
			float num3 = num2 - 1f;
			float num4 = num3 / 5f;
			float num5 = 1f - num4;
			float num6 = num5 * _AlphaDiff;
			alpha = num6 + _MaxAlpha;
		}
		else
		{
			alpha = _MaxAlpha;
		}
		ArcadeSprite arcadeSprite3 = setAlpha(alpha);
		string[] array = s_frameNames;
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite4 = setFrame(sprite);
		float num7 = _weapon.PInterval();
		float num8 = 5f * 0.032f;
		if (1f > num8)
		{
		}
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_FullAutoShot, 2f, 200, 0f, volume, rate, detune, loop, 1f);
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		OnHasHitAnObjectLogic(target, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable target)
	{
		//IL_009c: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			int bounces = _bounces - 1;
			_bounces = bounces;
			BaseBody baseBody = body;
			float num = (float)baseBody._velocity * -1f;
			baseBody._velocity = (float2)num;
			BaseBody baseBody2 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v7 (BaseBody)+74]");
			float num2 = 0f * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
	{
		//IL_008b: Expected O, but got I4
		//IL_01b2: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		bool flag = !triggerHit;
		IDamageable damageable = target;
		Vector2 typeFromHandle = (Vector2)typeof(IDamageable);
		if (!flag)
		{
			bool flag2 = _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE);
			bool flag3 = !flag2;
			damageable = null;
			typeFromHandle = (Vector2)19;
			if (!flag3)
			{
				Weapon weapon = _weapon;
				GameManager gameMan = weapon._gameMan;
				float2 float5 = base.position;
				Vector2 vector = default(Vector2);
				gameMan._arcanaManager.TriggerFireExplosion(vector);
				damageable = null;
				typeFromHandle = vector;
			}
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				base.Despawn();
			}
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		BaseBody baseBody = body;
		float num = (float)baseBody._velocity * -1f;
		baseBody._velocity = (float2)num;
		BaseBody baseBody2 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v8 (BaseBody)+74]");
		float num2 = 0f * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	static FB_FullAutoProjectile()
	{
		string[] array = new string[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		s_frameNames = array;
	}
}
