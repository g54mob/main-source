using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BossOrbBleed : MonoBehaviour
{
	public Rigidbody rb;

	public SphereCollider collider;

	public GameObject explosion;

	public GameObject trail;

	public RandomSfx randomSfx;

	private Enemy boss;

	private float acceleration = 90f;

	private bool isFired;

	private float speed = 20f;

	private float moveAtTime;

	private float destroyAtTime;

	private Vector3 offset;

	private Vector3 velocity;

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
		//IL_00e2: Expected I, but got O
		//IL_016b: Expected I, but got O
		this.boss = boss;
		float num = (float)currentPhase * 300f;
		float num2 = num + 3000f;
		acceleration = num2;
		float num3 = MyTime.time + 8f;
		float num4 = num3 + (float)currentPhase;
		destroyAtTime = num4;
		nint num5 = (nint)typeof(MyTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v6 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
		nint num6 = 0;
		float num7 = MyTime.time + moveOverSeconds;
		float num8 = num7 + 1.5f;
		object obj = default(object);
		float num9 = (float)obj * 0.5f;
		float num10 = num8 + num9;
		moveAtTime = num10;
		if (numOrbs > 1)
		{
			float num11 = 360f / (float)numOrbs;
			float num12 = num11 * (float)obj;
			float num13 = num12 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
			Vector3 vector = default(Vector3);
			offset = vector;
			float num14 = num13 * 15f;
			nint num15 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num17 = 0f * 15f;
			float num18 = num17 + num14;
			offset = vector;
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_006a: Expected O, but got Ref
		if (isFired)
		{
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			float num = default(float);
			rb.AddForce((Vector3)(&num));
		}
		else
		{
			FloatMovement();
			if (MyTime.time > moveAtTime)
			{
				isFired = true;
				randomSfx.Play();
				rb.drag = 0.7f;
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
			Explode();
		}
	}

	private void ShootOrb()
	{
		isFired = true;
		randomSfx.Play();
		rb.drag = 0.7f;
	}

	private unsafe void Movement()
	{
		//IL_0065: Expected O, but got Ref
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num = default(float);
		rb.AddForce((Vector3)(&num));
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
		//IL_0105: Expected O, but got Ref
		//IL_0244: Expected O, but got Ref
		GameObject gameObject = collision.gameObject;
		int layer = gameObject.layer;
		int num = LayerMask.NameToLayer("Player");
		if (layer == num)
		{
			Explode();
			Transform transform = rb.transform;
			Vector3 position = transform.position;
			float radius = collider.radius;
			Transform transform2 = base.transform;
			Vector3 localScale = transform2.localScale;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			float num2 = localScale.x * radius;
			float radius2 = num2 * 1.2f;
			float num3 = default(float);
			int layerMask = default(int);
			Collider[] array = Physics.OverlapSphere((Vector3)(&num3), radius2, layerMask);
			GameObject gameObject2 = collision.gameObject;
			int layer2 = gameObject2.layer;
			int num4 = LayerMask.NameToLayer("Player");
			if (layer2 == num4 || array.Length != 0)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory = instance2.inventory;
				float damageMultiplierAddition = CombatScaling.GetDamageMultiplierAddition(out var _, out var _, out var _);
				float num5 = damageMultiplierAddition + 1f;
				float damage = num5 * 18f;
				Transform transform3 = MyPlayer.Instance.transform;
				Vector3 position2 = transform3.position;
				Transform transform4 = base.transform;
				Vector3 position3 = transform4.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				bool ignoreShield = default(bool);
				string damageSource = default(string);
				DcFlags flags = default(DcFlags);
				EDamageEffect damageEffect = default(EDamageEffect);
				inventory.playerHealth.DamagePlayerExternal(damage, 20f, (Vector3)(&num3), ignoreShield, damageSource, flags, damageEffect);
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance3.inventory;
				inventory2.statusEffects.BleedPlayer(5f);
			}
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
