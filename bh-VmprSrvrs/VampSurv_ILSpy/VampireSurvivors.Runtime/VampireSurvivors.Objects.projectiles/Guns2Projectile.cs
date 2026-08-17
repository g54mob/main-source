using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Guns2Projectile : GunsProjectile
{
	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		OnHasHitAnObjectLogic(target, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable target)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x18729A110\"");
	}

	private void OnHasHitAnObjectLogic(IDamageable target, bool triggerHit)
	{
		//IL_00f4: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			if (_bounces > 0)
			{
				int bounces = _bounces - 1;
				_bounces = bounces;
				BaseBody baseBody = body;
				float num = (float)baseBody._velocity * -1f;
				baseBody._velocity = (float2)num;
				BaseBody baseBody2 = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v15 (BaseBody)+74]");
				float num2 = 0f * -1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
				return;
			}
			if (!triggerHit)
			{
				return;
			}
			if (--_penetrating <= 0)
			{
				base.Despawn();
			}
		}
		else if (!triggerHit)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			bool flag = TryFreeze(target);
		}
	}
}
