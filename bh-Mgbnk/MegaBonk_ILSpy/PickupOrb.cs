using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class PickupOrb : MonoBehaviour
{
	public GameObject hitEffect;

	public TrailRenderer trail;

	public ParticleSystem[] particleSystems;

	public Rigidbody rb;

	public EPickup ePickup;

	private float timeoutAtTime;

	private bool isDone;

	private void Awake()
	{
		float num = MyTime.time + 10f;
		timeoutAtTime = num;
	}

	private void Update()
	{
		//IL_0032: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		if (!(MyTime.time < timeoutAtTime))
		{
			isDone = true;
			trail.emitting = false;
			ParticleSystem[] array = particleSystems;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				array[obj].Clear();
				array[obj].Stop();
				obj++;
				obj2 = obj;
			}
			GameObject obj3 = base.gameObject;
			Object.Destroy(obj3, 0.1f);
		}
	}

	public void Set(EPickup ePickup)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_01be: Expected I, but got O
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		ParticleSystem[] array = particleSystems;
		this.ePickup = ePickup;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj2 < array.Length)
		{
			Color color = MyColorUtility.PickupToColor(ePickup);
			Color startColor = (Color)(obj3 - 48);
			_ = color.r;
			array[obj].startColor = startColor;
			obj++;
			obj2 = obj;
		}
		Color color2 = MyColorUtility.PickupToColor(ePickup);
		Color startColor2 = (Color)(obj3 - 48);
		_ = color2.r;
		trail.startColor = startColor2;
		Color startColor3 = trail.startColor;
		Color endColor = (Color)(obj3 - 48);
		_ = startColor3.r;
		trail.endColor = endColor;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_ = Vector3.upVector;
		Vector3 insideUnitSphere = Random.insideUnitSphere;
		Vector3 v = (Vector3)(obj3 - 80);
		_ = insideUnitSphere.x;
		_ = insideUnitSphere.z;
		Vector3 vector = VectorExtensions.XZVector(v);
		object obj4 = obj3 - 80;
		object obj5 = obj3 - 48;
		float num3 = vector.x * 0.2f;
		float num4 = vector.z * 0.2f;
		float num5 = num3 + (float)Vector3.upVector;
		float num6 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num7 = num6 + 0f;
		float num8 = vector.y * 0.2f;
		float num9 = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-3C]");
		float num10 = num9 + 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj6 = default(object);
		float num11 = (float)obj6 * 15f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v18+4]");
		float num12 = 0f * 15f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v18+8]");
		float num13 = 0f * 15f;
		Vector3 force = (Vector3)(obj3 - 80);
		rb.AddForce(force, ForceMode.Impulse);
	}

	private unsafe void OnCollisionEnter(Collision collision)
	{
		//IL_003d: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_00c7: Expected O, but got Ref
		if (!isDone)
		{
			isDone = true;
			trail.emitting = false;
			ParticleSystem[] array = particleSystems;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				array[obj].Clear();
				array[obj].Stop();
				obj++;
				obj2 = obj;
			}
			Transform transform = base.transform;
			Vector3 position = transform.position;
			object obj3 = default(object);
			bool useRandomOffsetPosition = default(bool);
			float pickupDelay = default(float);
			Pickup pickup = PickupManager.Instance.SpawnPickup(ePickup, (Vector3)(&obj3), 1, useRandomOffsetPosition, pickupDelay);
			GameObject obj4 = base.gameObject;
			Object.Destroy(obj4, 1f);
			hitEffect.SetActive(value: true);
		}
	}

	private void Timeout()
	{
		//IL_002d: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		isDone = true;
		trail.emitting = false;
		ParticleSystem[] array = particleSystems;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			array[obj].Clear();
			array[obj].Stop();
			obj++;
			obj2 = obj;
		}
		GameObject obj3 = base.gameObject;
		Object.Destroy(obj3, 0.1f);
	}
}
