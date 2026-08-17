using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Curves;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Tongue2Projectile : TongueProjectile
{
	private bool _003CAssassinationTongue_003Ek__BackingField;

	public bool AssassinationTongue
	{
		get
		{
			return _003CAssassinationTongue_003Ek__BackingField;
		}
		set
		{
			_003CAssassinationTongue_003Ek__BackingField = value;
		}
	}

	protected override void InitTrailSprite()
	{
		Sprite sprite = SpriteManager.GetSprite("Tongue", "vfx");
		_trailSprite = sprite;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		_003CAssassinationTongue_003Ek__BackingField = false;
	}

	protected unsafe override Vector3[] GetCurve(float2 startPoint, float2 currentPoint)
	{
		//IL_010b: Expected O, but got F4
		object obj = currentPoint - startPoint;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		float num = (float)obj * 0.5f;
		float num2 = (float)obj2 * 0.5f;
		float num3 = (float)startPoint + num;
		float num4 = (float)obj4 + num2;
		QuadraticBezierCurve quadraticBezierCurve = null;
		quadraticBezierCurve._p0 = currentPoint;
		quadraticBezierCurve._p1 = (Vector2)num3;
		quadraticBezierCurve._p2 = startPoint;
		Vector3[] points = quadraticBezierCurve.GetPoints(5);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD370");
		IEnumerable<Vector3> enumerable = default(IEnumerable<Vector3>);
		if (enumerable != null)
		{
			System.Linq.Buffer<Vector3> buffer = new System.Linq.Buffer<Vector3>(enumerable);
			float2 float5 = default(float2);
			return ((System.Linq.Buffer<Vector3>*)(&float5))->ToArray();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_0042: Expected F4, but got I4
		if (_003CAssassinationTongue_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD810");
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_ImpostorKill, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		}
	}
}
