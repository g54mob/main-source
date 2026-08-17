using Cpp2ILInjected;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KnifeProjectile_Kaleidoscope : EME_KnifeProjectile
{
	private float _saveVelX;

	private float _saveVelY;

	public override bool DoExplosions => true;

	public override float DurationMultiplier => 4f;

	protected override void Awake()
	{
		base.Awake();
		_speed = 2f;
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_007f: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
		BaseBody baseBody = base.body;
		baseBody._onWorldBounds = true;
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		EME_Knife1Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			float2 float5 = base.position;
			float2 pos = default(float2);
			Projectile projectile = trueWeapon._kaleidoscopePool.SpawnAt(pos, _trueWeapon);
		}
	}

	public override void InternalUpdate()
	{
		//IL_003c: Expected O, but got I4
		//IL_0084: Expected F4, but got O
		//IL_00d2: Expected F4, but got I
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num;
		object obj2 = obj >> 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187213B5Fh\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187213B80h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_004b: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00e2: Expected O, but got I8
		//IL_0253: Expected O, but got I4
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected O, but got Unknown
		//IL_00b1: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_0163: Expected O, but got I8
		//IL_0132: Expected O, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0148: Expected O, but got I4
		//IL_0189: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01ed;
			}
		}
		obj5 = 4294967295L;
		goto IL_01ed;
		IL_026e:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		EME_Knife1Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			float2 float5 = base.position;
			float2 pos = default(float2);
			Projectile projectile = trueWeapon._kaleidoscopePool.SpawnAt(pos, _trueWeapon);
		}
		return;
		IL_01ed:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_026e;
			}
		}
		obj6 = 4294967295L;
		goto IL_026e;
	}

	public override Color[][] GetTints()
	{
		return _tints3;
	}

	public override void FireSpecialBullets()
	{
		EME_Knife1Weapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			float2 float5 = base.position;
			float2 pos = default(float2);
			Projectile projectile = trueWeapon._kaleidoscopePool.SpawnAt(pos, _trueWeapon);
		}
	}
}
