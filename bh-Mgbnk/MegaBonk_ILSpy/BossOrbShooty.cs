using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using Utility;

public class BossOrbShooty : MonoBehaviour
{
	public Rigidbody rb;

	public SphereCollider collider;

	public GameObject explosion;

	public GameObject trail;

	public RandomSfx randomSfx;

	private Enemy boss;

	private bool isFired;

	private float speed = 20f;

	private float moveAtTime;

	private float destroyAtTime;

	private Vector3 offset;

	private float moveTimer;

	private float moveOverSeconds = 1.5f;

	public float spinSpeed = 90f;

	private float currentAngle;

	protected void Start()
	{
		Transform transform = trail.transform;
		transform.parentInternal = null;
	}

	public void Set(Enemy boss, int currentPhase, int numOrbs, int orbIndex)
	{
		//IL_012d: Expected I, but got O
		//IL_0186: Expected I, but got O
		this.boss = boss;
		float num = (float)currentPhase * 10f;
		float num2 = num + 75f;
		speed = num2;
		float num3 = MyTime.time + moveOverSeconds;
		float num4 = num3 + 1.5f;
		object obj = default(object);
		float num5 = (float)obj * 0.5f;
		float num6 = num4 + num5;
		moveAtTime = num6;
		nint num7 = (nint)typeof(MyTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v7 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
		nint num8 = 0;
		float num9 = MyTime.time + 10f;
		destroyAtTime = num9;
		if (numOrbs > 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebp\"");
			float num10 = 360f / 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,edx\"");
			float num11 = num10 * 0f;
			float num12 = num11 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
			float num13 = num12 * 15f;
			Vector3 vector = default(Vector3);
			offset = vector;
			nint num14 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num16 = 0f * 10f;
			float num17 = num16 + num13;
			offset = vector;
		}
	}

	private void FixedUpdate()
	{
		if (!isFired)
		{
			FloatMovement();
			if (MyTime.time > moveAtTime)
			{
				ShootOrb();
			}
		}
	}

	private unsafe void Update()
	{
		//IL_003a: Expected O, but got Ref
		Transform transform = trail.transform;
		Vector3 position = rb.position;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
		if (MyTime.time > destroyAtTime)
		{
			UnityEngine.Object.Destroy(trail);
			GameObject obj2 = base.gameObject;
			UnityEngine.Object.Destroy(obj2);
		}
	}

	private unsafe void ShootOrb()
	{
		//IL_01fc: Expected I, but got O
		//IL_00ed: Expected F8, but got I4
		//IL_01dd: Expected O, but got Ref
		isFired = true;
		randomSfx.Play();
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		nint num = (nint)typeof(Math);
		float num2 = position.x - position2.x;
		object obj = default(object);
		float num3 = (float)obj - position2.y;
		float num4 = position.z - position2.z;
		float num5 = num3 * num3;
		float num6 = num2 * num2;
		float num7 = num4 * num4;
		float num8 = num5 + num6;
		float num9 = num8 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rcx_v10 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			double num10 = 0.0;
		}
		else
		{
			double num10 = Math.Sqrt(num9);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
		float time = 0f / speed;
		double num11 = MyRandom.random.NextDouble();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm2,xmm0\"");
		bool flag = (nint)MyRandom.random <= 0;
		float x = position.x;
		float num12 = num9;
		if (!flag)
		{
			Vector3 vector = SpawnPositions.PredictPlayerPosition(time);
			num12 = vector.x;
			double num13 = default(double);
			double num10 = num13;
			x = vector.x;
		}
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		Transform transform3 = base.transform;
		Vector3 position3 = transform3.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		rb.velocity = (Vector3)(&x);
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

	private unsafe void OnCollisionEnter(Collision collision)
	{
		//IL_011b: Expected O, but got Ref
		//IL_025f: Expected O, but got Ref
		GameObject gameObject = explosion.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = explosion.transform;
		transform.parentInternal = null;
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
		UnityEngine.Object.Destroy(trail);
		Transform transform2 = rb.transform;
		Vector3 position = transform2.position;
		float radius = collider.radius;
		Transform transform3 = base.transform;
		Vector3 localScale = transform3.localScale;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num = localScale.x * radius;
		float radius2 = num * 1.2f;
		float num2 = default(float);
		int layerMask = default(int);
		Collider[] array = Physics.OverlapSphere((Vector3)(&num2), radius2, layerMask);
		GameObject gameObject2 = collision.gameObject;
		int layer = gameObject2.layer;
		int num3 = LayerMask.NameToLayer("Player");
		if (layer == num3 || array.Length != 0)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			float damageMultiplierAddition = CombatScaling.GetDamageMultiplierAddition(out var _, out var _, out var _);
			float num4 = damageMultiplierAddition + 1f;
			float damage = num4 * 18f;
			Transform transform4 = MyPlayer.Instance.transform;
			Vector3 position2 = transform4.position;
			Transform transform5 = base.transform;
			Vector3 position3 = transform5.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 20f, (Vector3)(&num2), ignoreShield, damageSource, flags, damageEffect);
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance3.inventory;
			inventory2.statusEffects.BossPoisonPlayer(8f);
		}
	}

	private float GetDamage()
	{
		float damageMultiplierAddition = CombatScaling.GetDamageMultiplierAddition(out var _, out var _, out var _);
		float num = damageMultiplierAddition + 1f;
		return num * 18f;
	}
}
