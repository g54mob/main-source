using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class LaserBeamAttack : ConstantAttack
{
	public LineRenderer linerenderer;

	public GameObject laserStart;

	public GameObject laserEnd;

	private float radius = 0.5f;

	private Vector3 laserDir;

	private Enemy target;

	private float laserStopTime;

	private float laserStartedAtTime;

	private float laserReadyTime;

	private bool isShooting;

	private Vector3 prevStart;

	private Vector3 prevEnd;

	private Vector3 center;

	private Quaternion rotation;

	private Vector3 halfExtents;

	public AudioSource audioLoop;

	public GameObject explosionFx;

	private Dictionary<Collider, float> enemyHitCooldowns;

	private float hitCooldown;

	public int whipSegments;

	public float whipAmplitude;

	public float whipFrequency;

	public float animateWhipTime;

	private float whipAnimationTime;

	private static readonly Collider[] sphereHits;

	private static readonly Collider[] boxHits;

	private float laserRadius;

	private new void Awake()
	{
		//IL_00c4: Expected I, but got O
		//IL_009c: Expected I, but got O
		base.Awake();
		Action<WeaponBase> b = OnWeaponToggled;
		Delegate obj = Delegate.Combine(WeaponInventory.A_WeaponToggled, b);
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponToggled = (Action<WeaponBase>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<WeaponBase> action = default(Action<WeaponBase>);
		if (action != null)
		{
			WeaponInventory.A_WeaponToggled = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<WeaponBase>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<WeaponBase>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_00c4: Expected I, but got O
		//IL_009c: Expected I, but got O
		base.OnDestroy();
		Action<WeaponBase> value = OnWeaponToggled;
		Delegate obj = Delegate.Remove(WeaponInventory.A_WeaponToggled, value);
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponToggled = (Action<WeaponBase>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<WeaponBase> action = default(Action<WeaponBase>);
		if (action != null)
		{
			WeaponInventory.A_WeaponToggled = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<WeaponBase>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<WeaponBase>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnWeaponToggled(WeaponBase weaponBase)
	{
		StopLaser();
	}

	protected override void Init()
	{
		UpdateSize();
	}

	private void Update()
	{
		if (!isShooting && MyTime.time > laserReadyTime)
		{
			StartLaser();
		}
		RenderLaser();
	}

	private unsafe void StartLaser()
	{
		//IL_006c: Expected O, but got Ref
		//IL_00e3: Expected I4, but got O
		//IL_01f1: Expected O, but got F4
		//IL_0219: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		float num = default(float);
		GameObject gameObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, 0, weaponData.useVision, gameObject);
		target = enemy;
		if (target != null)
		{
			float duration = WeaponUtility.GetDuration(base.weaponBase);
			float duration2 = duration + duration;
			target.AddDebuff(EDebuff.Echo, null, duration2, (int)gameObject);
			isShooting = true;
			linerenderer.enabled = true;
			laserStart.SetActive(value: true);
			laserEnd.SetActive(value: true);
			linerenderer.startWidth = laserRadius;
			float duration3 = WeaponUtility.GetDuration(base.weaponBase);
			float num2 = (laserStopTime = duration3 + MyTime.time);
			float weaponCooldown = WeaponUtility.GetWeaponCooldown(base.weaponBase);
			float num3 = weaponCooldown + 1f;
			float num4 = num3 + num2;
			laserReadyTime = num4;
			laserStartedAtTime = MyTime.time;
			MyPlayer instance = MyPlayer.Instance;
			PlayerRenderer playerRenderer = instance.playerRenderer;
			Vector3 position2 = playerRenderer.hips.position;
			prevStart = (Vector3)position2.x;
			_ = position2.z;
			Vector3 beamEnd = GetBeamEnd();
			prevEnd = (Vector3)beamEnd.x;
			_ = beamEnd.z;
			whipAnimationTime = 0f;
			audioLoop.Play();
		}
		else
		{
			float num5 = laserReadyTime + 0.5f;
			laserReadyTime = num5;
		}
	}

	private unsafe void StopLaser()
	{
		//IL_00b0: Expected O, but got Ref
		//IL_0131: Expected O, but got Ref
		isShooting = false;
		linerenderer.enabled = false;
		laserStart.SetActive(value: false);
		laserEnd.SetActive(value: false);
		audioLoop.Stop();
		explosionFx.SetActive(value: true);
		Transform transform = explosionFx.transform;
		Transform transform2 = laserEnd.transform;
		Vector3 position = transform2.position;
		float num = default(float);
		transform.position = (Vector3)(&num);
		target.RemoveDebuff(EDebuff.Echo, fromDeath: false);
		Vector3 beamEnd = GetBeamEnd();
		MyPlayer instance = MyPlayer.Instance;
		PlayerRenderer playerRenderer = instance.playerRenderer;
		Vector3 position2 = playerRenderer.hips.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float forceDamage = default(float);
		DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, null, target, (Vector3)(&num), forceDamage);
		float duration = WeaponUtility.GetDuration(weaponBase);
		float num2 = duration * 3f;
		float damage = num2 * damageContainer.damage;
		damageContainer.damage = damage;
		target.DamageFromPlayerWeapon(damageContainer);
	}

	private unsafe void RenderLaser()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00c0: Expected O, but got Ref
		//IL_01a3: Expected O, but got Ref
		//IL_01c9: Expected O, but got Ref
		//IL_01e6: Expected O, but got Ref
		//IL_01fd: Expected O, but got Ref
		//IL_06b7: Invalid comparison between I4 and F4
		//IL_0292: Expected F4, but got I4
		//IL_0716: Invalid comparison between I4 and F4
		//IL_02ce: Expected F4, but got I4
		//IL_0733: Invalid comparison between I4 and F4
		//IL_030a: Expected F4, but got I4
		//IL_0826: Expected I, but got O
		//IL_0853: Expected O, but got I
		//IL_0870: Expected O, but got I
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Expected O, but got Unknown
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_089b: Expected O, but got Unknown
		//IL_08dc: Expected O, but got I
		//IL_0906: Expected O, but got I
		//IL_0929: Invalid comparison between F4 and O
		//IL_0942: Expected O, but got I
		//IL_095a: Expected O, but got I
		//IL_0338: Expected O, but got Ref
		//IL_0351: Expected O, but got Ref
		//IL_03ba: Expected O, but got I
		//IL_03ca: Expected O, but got I
		//IL_03ea: Invalid comparison between I4 and F4
		//IL_0409: Invalid comparison between F4 and I4
		//IL_045e: Expected O, but got I4
		//IL_047d: Expected O, but got I4
		//IL_099e: Expected I, but got O
		//IL_09cb: Expected O, but got I
		//IL_09e8: Expected O, but got I
		//IL_09f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Expected O, but got Unknown
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1f: Expected O, but got Unknown
		//IL_0a30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a35: Expected O, but got Unknown
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Expected O, but got Unknown
		//IL_0c0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c14: Expected I4, but got Unknown
		//IL_0c6e: Invalid comparison between I4 and F4
		//IL_04c3: Expected F4, but got I4
		//IL_05fc: Expected F4, but got I4
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aeb: Expected O, but got Unknown
		//IL_048b: Invalid comparison between I4 and F4
		//IL_0c9d: Invalid comparison between I4 and F4
		//IL_0509: Expected F4, but got I4
		//IL_0638: Expected F4, but got I4
		//IL_04a7: Expected F4, but got I4
		//IL_051e: Expected O, but got I
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_0539: Expected I, but got O
		//IL_0549: Expected O, but got I
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!isShooting)
		{
			return;
		}
		if (target == null)
		{
			StopLaser();
		}
		Vector3 beamEnd = GetBeamEnd();
		MyPlayer instance = MyPlayer.Instance;
		PlayerRenderer playerRenderer = instance.playerRenderer;
		Vector3 position = playerRenderer.hips.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Enemy enemy = target;
		Vector3 centerPosition = target.GetCenterPosition();
		float num = default(float);
		Vector3 vector = enemy.collider.ClosestPoint((Vector3)(&num));
		object obj3 = default(object);
		float num2 = (float)obj3 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+4]");
		float num3 = 0f * 0.5f;
		float num4 = num2 + vector.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+8]");
		float num5 = 0f * 0.5f;
		float num6 = num3 + vector.y;
		float num7 = num5 + vector.z;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerRenderer playerRenderer2 = instance2.playerRenderer;
		Vector3 position2 = playerRenderer2.hips.position;
		_ = position2.y;
		_ = position2.z;
		Transform transform = laserStart.transform;
		transform.position = (Vector3)(&num);
		Transform transform2 = laserEnd.transform;
		transform2.position = (Vector3)(&num);
		Transform transform3 = laserStart.transform;
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
		float num8 = default(float);
		transform3.rotation = (Quaternion)(&num8);
		float num9 = animateWhipTime;
		float deltaTime = Time.deltaTime;
		float num10 = deltaTime + whipAnimationTime;
		if (!(num10 > animateWhipTime))
		{
			num9 = num10;
		}
		whipAnimationTime = num9;
		float num11 = num9 / animateWhipTime;
		float num12 = ((0f > num11) ? 0f : ((num11 > 1f) ? 1f : num11));
		float num13 = 0f - whipAmplitude;
		float num14 = num13 * num12;
		float num15 = Easing.OutCubic(num11);
		float num16 = num15 + num15;
		if (!(0f > num16))
		{
			if (num16 > 1f)
			{
				num16 = 1f;
			}
		}
		else
		{
			num16 = 0f;
		}
		if (!(0f > num16))
		{
			if (num16 > 1f)
			{
				num16 = 1f;
			}
		}
		else
		{
			num16 = 0f;
		}
		float num17 = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
		float num18 = num17 - 0f;
		float num19 = num4 - position2.x;
		float num20 = num18 * num16;
		float num21 = num19 * num16;
		float num22 = num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
		float num23 = num22 + 0f;
		float num24 = num21 + position2.x;
		float num25 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
		float num26 = num25 - 0f;
		float num27 = num26 * num16;
		float num28 = num27;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
		float num29 = num28 + 0f;
		if (!(animateWhipTime > whipAnimationTime))
		{
			linerenderer.positionCount = 2;
			linerenderer.SetPosition(0, (Vector3)(&num));
			linerenderer.SetPosition(1, (Vector3)(&num));
		}
		else
		{
			int num30 = whipSegments + 1;
			Vector3[] positions = new Vector3[num30];
			nint num31 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rcx_v32 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rdx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			nint num33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+8]");
			object obj4 = num33 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rdx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			nint num34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+4]");
			object obj5 = num34 * 0;
			Vector3 upVector = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+8]");
			object obj6 = upVector * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ rdx_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			object obj7 = 0 * obj3;
			object obj8 = obj5 - obj4;
			object obj9 = obj6 - obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rax_v43+4]");
			nint num35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rax_v43+4]");
			object obj10 = num35 * 0;
			object obj12 = default(object);
			object obj11 = obj12 * obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rax_v43+8]");
			nint num36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rax_v43+8]");
			object obj13 = num36 * 0;
			object obj14 = obj10 + obj11;
			object obj15 = obj14 + obj13;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rax_v43+4]");
			object obj16 = 0;
			object obj17 = obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rax_v43+8]");
			object obj18 = 0;
			nint num37 = (nint)(&num8);
			if (!flag)
			{
				nint num38 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1155 @ rax_v51 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				num37 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
				nint num39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+4]");
				object obj19 = num39 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+40]");
				nint num40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+8]");
				object obj20 = num40 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
				object obj21 = 0 * obj3;
				object obj22 = obj19 - obj20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+40]");
				object obj23 = 0 * obj3;
				Vector3 rightVector = Vector3.rightVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+8]");
				object obj24 = rightVector * 0;
				Vector3 rightVector2 = Vector3.rightVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v18+4]");
				object obj25 = rightVector2 * 0;
				object obj26 = obj24 - obj21;
				object obj27 = obj23 - obj25;
				obj16 = obj26;
				obj17 = obj22;
				obj18 = obj27;
			}
			if (num30 > 0)
			{
				float num41 = num24 - position2.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
				float num42 = 0f + whipAmplitude;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
				object obj29 = 0;
				float num43 = num23;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
				float num44 = num43 - 0f;
				bool flag2 = 0f < num15;
				float num45 = 0f - num15;
				bool flag3 = num45 == 0f;
				float num46 = num15 * (float)Math.PI;
				float num47 = num29;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
				float num48 = num47 - 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				object obj30 = flag5 & flag4;
				float num49 = (float)Math.PI;
				float x = position2.x;
				object obj31 = 0;
				bool flag6;
				do
				{
					int num50 = obj31 / whipSegments;
					float num51 = ((0 > num50) ? 0f : (((float)num50 > 1f) ? 1f : ((float)num50)));
					float num52 = num41 * num51;
					float num53 = num44 * num51;
					float num54 = num51 * num48;
					float num55 = num52 + x;
					float num56 = num53 + (float)obj28;
					float num57 = num54 + (float)obj29;
					object obj32 = num50 * whipFrequency;
					float num58 = num46 + num46;
					float num59 = (float)obj32 * num49;
					float num60 = num59 + num59;
					float num61 = num60 - num58;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
					float num62 = ((obj30 != null) ? 0f : ((num15 > 1f) ? 1f : num15));
					float num63 = num61;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
					float num64 = num63 * 0f;
					float num65 = (float)num50 - 1f;
					float num66 = num65 * num62;
					float num67 = num66 + 1f;
					float num68 = num67 * num64;
					float num69 = num68 * (float)obj17;
					float num70 = num68 * (float)obj16;
					float num71 = num68 * (float)obj18;
					float num72 = num69 + num55;
					float num73 = num70 + num56;
					float num74 = num71 + num57;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
					obj28 = 0;
					object obj33 = obj31 * 2;
					num37 = (nint)(obj31 + obj33);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
					obj29 = 0;
					obj31++;
					flag6 = (nint)obj31 < num30;
					num49 = (float)Math.PI;
					x = position2.x;
				}
				while (flag6);
			}
			linerenderer.positionCount = num30;
			linerenderer.SetPositions(positions);
		}
		float num75 = laserStopTime - laserStartedAtTime;
		float num76 = MyTime.time - laserStartedAtTime;
		float num77 = num76 / num75;
		if (!(0f > num77))
		{
			if (num77 > 1f)
			{
				num77 = 1f;
			}
		}
		else
		{
			num77 = 0f;
		}
		float num78 = Easing.InPower(num77, 6);
		if (!(0f > num78))
		{
			if (num78 > 1f)
			{
				num78 = 1f;
			}
		}
		else
		{
			num78 = 0f;
		}
		float pitch = num78 + 1f;
		audioLoop.pitch = pitch;
	}

	private unsafe Vector3 GetBeamStart()
	{
		//IL_0075: Expected native int or pointer, but got O
		//IL_0087: Expected native int or pointer, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerRenderer playerRenderer = instance.playerRenderer;
			if ((object)instance.playerRenderer != null && (object)playerRenderer.hips != null)
			{
				Vector3 position = playerRenderer.hips.position;
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = position.x;
				((Vector3*)(nint)vector)->z = position.z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	private unsafe Vector3 GetBeamEnd()
	{
		//IL_00d0: Expected native int or pointer, but got O
		//IL_00e2: Expected native int or pointer, but got O
		Vector3 vector;
		if (!(target == null))
		{
			if ((object)target != null)
			{
				vector = target.GetCenterPosition();
				goto IL_00c3;
			}
		}
		else
		{
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerRenderer playerRenderer = instance.playerRenderer;
				if ((object)instance.playerRenderer != null && (object)playerRenderer.hips != null)
				{
					vector = playerRenderer.hips.position;
					goto IL_00c3;
				}
			}
		}
		return (Vector3)new NullReferenceException();
		IL_00c3:
		Vector3 vector2 = default(Vector3);
		((Vector3*)(nint)vector2)->x = vector.x;
		((Vector3*)(nint)vector2)->z = vector.z;
		return vector2;
	}

	private unsafe void FindTarget()
	{
		//IL_006c: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		float num = default(float);
		GameObject exceptObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, 0, weaponData.useVision, exceptObject);
		target = enemy;
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00be: Expected O, but got F4
		//IL_0307: Expected O, but got Ref
		//IL_0307: Expected O, but got Ref
		//IL_031a: Expected O, but got F4
		//IL_0232: Expected O, but got Ref
		//IL_01d1: Expected O, but got F4
		//IL_01ea: Expected O, but got F4
		//IL_0268: Expected O, but got I4
		//IL_014a: Expected O, but got Ref
		//IL_014a: Expected O, but got Ref
		//IL_014a: Expected O, but got Ref
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_0180: Expected O, but got I4
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!isShooting)
		{
			return;
		}
		if (!(MyTime.time > laserStopTime))
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerRenderer playerRenderer = instance.playerRenderer;
			Vector3 position = playerRenderer.hips.position;
			Vector3 beamEnd = GetBeamEnd();
			float num = beamEnd.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (LaserBeamAttack)+70]");
			float num2 = num - 0f;
			_ = beamEnd.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			float num8 = default(float);
			if (!(Mathf.Epsilon > beamEnd.z))
			{
				float num3 = beamEnd.z * 0.5f;
				halfExtents = (Vector3)laserRadius;
				_ = laserRadius;
				float num4 = num3 + laserRadius;
				float num5 = num2 * 0.5f;
				float num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (LaserBeamAttack)+70]");
				float num7 = num6 + 0f;
				Vector3 vector = default(Vector3);
				center = vector;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				float num9 = default(float);
				rotation = (Quaternion)Quaternion.LookRotation((Vector3)(&num8), (Vector3)(&num9)).x;
				GameManager instance2 = GameManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				Vector3 vector2 = default(Vector3);
				object obj3 = default(object);
				int mask = default(int);
				int num10 = Physics.OverlapBoxNonAlloc((Vector3)(&vector2), (Vector3)(&num8), boxHits, (Quaternion)(&obj3), mask);
				if (num10 > 0)
				{
					Collider[] array = boxHits;
					object obj4 = 0;
					do
					{
						HitEnemy(array[obj4]);
						obj4++;
					}
					while ((nint)obj4 < num10);
				}
			}
			else
			{
				GameManager instance3 = GameManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				int layerMask = default(int);
				int num11 = Physics.OverlapSphereNonAlloc((Vector3)(&num8), laserRadius, sphereHits, layerMask);
				if (num11 > 0)
				{
					Collider[] array2 = sphereHits;
					object obj5 = 0;
					do
					{
						HitEnemy(array2[obj5]);
						obj5++;
					}
					while ((nint)obj5 < num11);
				}
			}
			prevStart = (Vector3)position.x;
			_ = position.z;
			prevEnd = (Vector3)beamEnd.x;
			_ = beamEnd.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
			_ = 0;
		}
		else
		{
			StopLaser();
		}
	}

	private void ProcessHits(Collider[] colliders, int count)
	{
		//IL_0029: Expected O, but got I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		if (count > 0)
		{
			object obj = 0;
			do
			{
				HitEnemy(colliders[obj]);
				obj++;
			}
			while ((nint)obj < count);
		}
	}

	private unsafe void HitEnemy(Collider collider)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00cc: Expected O, but got I
		//IL_00ec: Expected O, but got Ref
		//IL_010b: Expected O, but got Ref
		//IL_0128: Expected O, but got I
		//IL_014a: Expected O, but got I
		//IL_0171: Expected O, but got Ref
		//IL_01a3: Expected O, but got I
		//IL_01c1: Expected O, but got I
		//IL_01d7: Expected O, but got I
		//IL_026f: Expected O, but got Ref
		//IL_031c: Expected O, but got I
		//IL_0333: Expected O, but got Ref
		//IL_0341: Expected O, but got Ref
		//IL_0391: Expected I4, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Enemy enemy = target;
		_ = 0;
		_ = 0;
		if (!(collider != enemy.collider))
		{
			return;
		}
		if (enemyHitCooldowns.TryGetValue(collider, out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
		{
			float num = MyTime.time;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
			float num2 = num - 0f;
			if (hitCooldown > num2)
			{
				return;
			}
		}
		if (EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
			if (!((Enemy)0).IsDead())
			{
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				object obj4 = prevEnd - prevStart;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (LaserBeamAttack)+78]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (LaserBeamAttack)+6C]");
				object obj6 = num3 - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (LaserBeamAttack)+7C]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (LaserBeamAttack)+70]");
				object obj7 = num4 - 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v15+8]");
				_ = 0;
				WeaponBase obj8 = weaponBase;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
				float num5 = default(float);
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj8, null, (Enemy)0, direction, num5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
				((Enemy)0).DamageFromPlayerWeapon(damageContainer);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
				Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
				object obj9 = default(object);
				float num6 = (float)obj9 * 5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v15+8]");
				float num7 = 0f * 5f;
				float num8 = centerPosition.x - num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v15+4]");
				float num9 = 0f * 5f;
				float num10 = centerPosition.y - num9;
				float num11 = centerPosition.z - num7;
				Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Vector3 vector = collider.ClosestPoint(position);
				float num12 = (float)obj9 * 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v15+4]");
				float num13 = 0f * 0.5f;
				float num14 = num12 + vector.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v15+8]");
				float num15 = 0f * 0.5f;
				float num16 = num13 + vector.y;
				float num17 = num15 + vector.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
				bool hitEnemy = (UnityEngine.Object)0;
				Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Vector3 hitPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v15+4]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v15+8]");
				_ = 0;
				GameObject weaponHitEffect = default(GameObject);
				bool useSfx = default(bool);
				EffectManager.Instance.EnemyHitEffect(hitPos, moveDir, hitEnemy, (EWeapon)num5, weaponHitEffect, useSfx);
				((Dictionary<object, float>)(object)enemyHitCooldowns).set_Item((object)collider, MyTime.time);
			}
		}
	}

	private void UpdateSize()
	{
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float startWidth = (laserRadius = attackSizeMultiplier * radius);
		linerenderer.startWidth = startWidth;
	}

	private float GetRadius()
	{
		return laserRadius;
	}

	public override float GetAuraRotationSpeed()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	private float GetDuration()
	{
		return WeaponUtility.GetDuration(weaponBase);
	}

	private float GetCooldown()
	{
		float weaponCooldown = WeaponUtility.GetWeaponCooldown(weaponBase);
		return weaponCooldown + 1f;
	}

	protected override void OnWeaponStatUpdate(EStat stat, EWeapon weapon)
	{
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		if (weapon == weaponData.eWeapon)
		{
			OnStatUpdate(stat);
		}
	}

	protected override void OnStatUpdate(EStat stat)
	{
		if (stat == EStat.SizeMultiplier)
		{
			UpdateSize();
		}
	}

	public LaserBeamAttack()
	{
		Dictionary<Collider, float> dictionary = new Dictionary<Collider, float>();
		enemyHitCooldowns = dictionary;
		hitCooldown = 0.5f;
		whipSegments = 20;
		whipAmplitude = 1f;
		whipFrequency = 2f;
		animateWhipTime = 1f;
		laserRadius = 0.5f;
		base._002Ector();
	}

	static LaserBeamAttack()
	{
		Collider[] array = new Collider[EnemyManager.maxNumEnemiesPooled];
		sphereHits = array;
		Collider[] array2 = new Collider[EnemyManager.maxNumEnemiesPooled];
		boxHits = array2;
	}
}
