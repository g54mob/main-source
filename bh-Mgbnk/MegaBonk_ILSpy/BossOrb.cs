using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BossOrb : MonoBehaviour
{
	public Rigidbody rb;

	public SphereCollider collider;

	public GameObject explosion;

	public GameObject trail;

	public RandomSfx randomSfx;

	private Vector3 offset;

	private Enemy boss;

	private int iterationsBeforeExplode;

	private float overshootDistance = 1.5f;

	private float moveInterval = 1.5f;

	private float nextMoveTime;

	private float moveTimer = 1f;

	private float moveOverSeconds = 0.5f;

	private float maxMoveDistance = 30f;

	private Vector3 fromPosition;

	private Vector3 toPosition;

	private bool isFired;

	public float spinSpeed = 90f;

	private float currentAngle;

	private float moveDist;

	private Vector3 moveDirection;

	private float moveSpeed;

	private int numMoves;

	protected void Start()
	{
		Transform transform = trail.transform;
		transform.parentInternal = null;
	}

	public void Set(float startDelay, int currentPhase, Enemy ignoreCollisionEnemy, int numOrbs, int orbIndex)
	{
		//IL_0129: Expected O, but got I4
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0232: Expected I, but got O
		Enemy enemy = default(Enemy);
		boss = enemy;
		bool flag = enemy != null;
		bool flag2 = !flag;
		Collider collider = null;
		bool flag3 = false;
		if (!flag2)
		{
			Collider component = GetComponent<Collider>();
			Physics.IgnoreCollision(component, enemy.collider, ignore: true);
			enemy = null;
			collider = enemy.collider;
			flag3 = true;
		}
		object obj = currentPhase * 4;
		object obj2 = currentPhase + obj;
		float num = MyTime.time + moveOverSeconds;
		object obj3 = obj2 + obj2;
		float num2 = num + 1.5f;
		object obj4 = default(object);
		float num3 = (float)obj4 * 0.5f;
		float num4 = num2 + num3;
		nextMoveTime = num4;
		float num5 = (float)currentPhase + 0.5f;
		overshootDistance = num5;
		float num6 = (float)currentPhase * 0.1f;
		int num7 = currentPhase + 6;
		iterationsBeforeExplode = num7;
		float num8 = 1.5f - num6;
		float num9 = (float)obj3 + 30f;
		moveInterval = num8;
		maxMoveDistance = num9;
		object obj5 = default(object);
		if ((nint)obj5 > 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,eax\"");
			float num10 = 360f / 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,ecx\"");
			float num11 = num10 * 0f;
			float num12 = num11 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
			float num13 = num12 * 15f;
			Vector3 vector = default(Vector3);
			offset = vector;
			nint num14 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v10 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num16 = 0f * 20f;
			float num17 = num16 + num13;
			offset = vector;
		}
	}

	private void FixedUpdate()
	{
		if (isFired)
		{
			UpdateMoving();
			if (!(nextMoveTime > MyTime.time))
			{
				StartMoving();
			}
		}
		else
		{
			FloatMovement();
			if (MyTime.time > nextMoveTime)
			{
				isFired = true;
			}
		}
	}

	private unsafe void Update()
	{
		//IL_003d: Expected O, but got Ref
		Transform transform = trail.transform;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
	}

	private unsafe void FloatMovement()
	{
		//IL_012f: Expected O, but got Ref
		//IL_0140: Expected O, but got Ref
		//IL_0140: Expected O, but got Ref
		//IL_00d6: Invalid comparison between I4 and F4
		//IL_0050: Expected F4, but got I4
		//IL_0087: Expected O, but got Ref
		if (1f > moveTimer)
		{
			float num = MyTime.fixedDeltaTime / moveOverSeconds;
			float num2 = num + moveTimer;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			moveTimer = num2;
		}
		float num3 = Easing.InOutCirc(moveTimer);
		float num4 = spinSpeed * MyTime.fixedDeltaTime;
		float num5 = num4 + currentAngle;
		currentAngle = num5;
		float num6 = default(float);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num6));
		object obj = default(object);
		Vector3 vector = (Quaternion)(&obj) * (Vector3)(&num6);
		Vector3 centerPosition = boss.GetCenterPosition();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804AD730");
		rb.MovePosition((Vector3)(&num6));
	}

	private unsafe void UpdateMoving()
	{
		//IL_0008: Expected O, but got Ref
		//IL_034a: Invalid comparison between I4 and F4
		//IL_036b: Invalid comparison between I4 and F4
		//IL_0052: Expected O, but got Ref
		//IL_0071: Expected O, but got Ref
		//IL_008e: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_0121: Expected O, but got Ref
		//IL_012f: Expected O, but got Ref
		//IL_01c2: Expected O, but got Ref
		//IL_022a: Expected O, but got Ref
		//IL_0395: Expected I, but got O
		//IL_03be: Expected O, but got I
		//IL_0275: Expected I, but got O
		//IL_0283: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		if (!(moveTimer < 1f))
		{
			return;
		}
		float num = Easing.InOutQuad(moveTimer);
		float num2 = MyTime.fixedDeltaTime / moveOverSeconds;
		if (!(0f < (moveTimer = num2 + moveTimer)) || !(0f < MyTime.fixedDeltaTime))
		{
			return;
		}
		float num3 = Easing.InOutQuad(moveTimer);
		float num4 = num3 - num;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		object obj4 = toPosition - fromPosition;
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+8C]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+80]");
		object obj6 = num5 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+90]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+84]");
		object obj7 = num6 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj8 = default(object);
		Vector3 vector = (Vector3)obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v10+8]");
		object obj9 = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v10+8]");
		_ = 0;
		Vector3 position = rb.position;
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = position.x;
		_ = position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rax_v16+8]");
		_ = 0;
		float radius = collider.radius;
		GameManager instance = GameManager.Instance;
		float num7 = moveDist * num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		Ray ray = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
		_ = 0;
		int layerMask = default(int);
		if (Physics.SphereCast(ray, radius, out hitInfo, num7, layerMask))
		{
			nint num8 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v39 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num9 = 0;
			vector = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v27 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			obj9 = 0;
			_ = Vector3.upVector;
		}
		float num10 = num7 / MyTime.fixedDeltaTime;
		float num11 = num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-65]");
		float num12 = num11 * 0f;
		float num13 = num10 * (float)vector;
		float num14 = num10 * (float)obj9;
		Vector3 velocity = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		rb.velocity = velocity;
		if (!(moveTimer < 1f))
		{
			nint num15 = (nint)typeof(Vector3);
			Vector3 velocity2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rax_v29 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num16 = 0;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ rax_v30 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			rb.velocity = velocity2;
			if (numMoves >= iterationsBeforeExplode)
			{
				Explode();
			}
		}
	}

	private void StartMoving()
	{
		//IL_0023: Expected O, but got F4
		//IL_0061: Expected O, but got F4
		//IL_0218: Expected I, but got O
		//IL_0246: Expected O, but got I
		//IL_0263: Expected O, but got I
		//IL_00f5: Expected F8, but got I4
		//IL_015e: Expected O, but got I
		//IL_017b: Expected O, but got I
		moveTimer = 0f;
		float num = MyTime.time + moveInterval;
		float num2 = num + moveOverSeconds;
		nextMoveTime = num2;
		Vector3 position = rb.position;
		fromPosition = (Vector3)position.x;
		_ = position.z;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position2 = transform.position;
		toPosition = (Vector3)position2.x;
		_ = position2.z;
		nint num3 = (nint)typeof(Math);
		object obj = toPosition - fromPosition;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+8C]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+80]");
		object obj2 = num4 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+90]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+84]");
		object obj3 = num5 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj * obj;
		object obj6 = obj3 * obj3;
		object obj7 = obj4 + obj5;
		double d = (double)obj7 + (double)obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rcx_v11 (Il2CppClass<System.Math>)+E4]");
		double num6;
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			num6 = 0.0;
		}
		else
		{
			num6 = Math.Sqrt(d);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		moveDist = (float)num6;
		if (num6 > (double)maxMoveDistance)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+8C]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+80]");
			object obj8 = num7 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+90]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+84]");
			object obj9 = num8 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			float num9 = maxMoveDistance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v17+8]");
			float num10 = num9 * 0f;
			moveDist = maxMoveDistance;
			float num11 = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (BossOrb)+84]");
			float num12 = num11 + 0f;
			Vector3 vector = default(Vector3);
			toPosition = vector;
		}
		float num13 = moveDist + overshootDistance;
		moveDist = num13;
		randomSfx.Play();
		int num14 = numMoves + 1;
		numMoves = num14;
	}

	private unsafe void OnCollisionEnter(Collision collision)
	{
		//IL_0157: Expected O, but got Ref
		GameObject gameObject = collision.gameObject;
		int layer = gameObject.layer;
		int num = LayerMask.NameToLayer("Player");
		if (layer == num)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			inventory.statusEffects.FreezePlayer(1f);
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			float damageMultiplierAddition = CombatScaling.GetDamageMultiplierAddition(out var _, out var _, out var _);
			float num2 = damageMultiplierAddition + 1f;
			float damage = num2 * 18f;
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			float num3 = default(float);
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory2.playerHealth.DamagePlayerExternal(damage, 20f, (Vector3)(&num3), ignoreShield, damageSource, flags, damageEffect);
			Explode();
		}
	}

	private void Explode()
	{
		GameObject gameObject = explosion.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = explosion.transform;
		transform.parentInternal = null;
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
		UnityEngine.Object.Destroy(trail);
	}

	private float GetDamage()
	{
		float damageMultiplierAddition = CombatScaling.GetDamageMultiplierAddition(out var _, out var _, out var _);
		float num = damageMultiplierAddition + 1f;
		return num * 18f;
	}
}
