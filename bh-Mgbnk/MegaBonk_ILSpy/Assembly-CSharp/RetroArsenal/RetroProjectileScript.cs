using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

public class RetroProjectileScript : MonoBehaviour
{
	public GameObject impactParticle;

	public GameObject projectileParticle;

	public GameObject muzzleParticle;

	public GameObject[] trailParticles;

	public float colliderRadius = 1f;

	public float collideOffset = 0.15f;

	private Rigidbody rb;

	private Transform myTransform;

	private SphereCollider sphereCollider;

	private float destroyTimer;

	private bool destroyed;

	private unsafe void Start()
	{
		//IL_006a: Expected O, but got Ref
		//IL_006a: Expected O, but got Ref
		//IL_0108: Expected O, but got Ref
		//IL_0108: Expected O, but got Ref
		Rigidbody component = GetComponent<Rigidbody>();
		rb = component;
		Transform transform = base.transform;
		myTransform = transform;
		SphereCollider component2 = GetComponent<SphereCollider>();
		sphereCollider = component2;
		Vector3 position = myTransform.position;
		Quaternion rotation = myTransform.rotation;
		float num = default(float);
		float num2 = default(float);
		GameObject gameObject = Object.Instantiate(projectileParticle, (Vector3)(&num), (Quaternion)(&num2));
		projectileParticle = gameObject;
		Transform transform2 = projectileParticle.transform;
		transform2.parent = myTransform;
		if ((bool)muzzleParticle)
		{
			Vector3 position2 = myTransform.position;
			Quaternion rotation2 = myTransform.rotation;
			GameObject gameObject2 = Object.Instantiate(muzzleParticle, (Vector3)(&num), (Quaternion)(&num2));
			muzzleParticle = gameObject2;
			Object.Destroy(muzzleParticle, 1.5f);
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0069: Expected O, but got I4
		//IL_0051: Expected O, but got F4
		//IL_016b: Expected O, but got Ref
		//IL_016b: Expected O, but got Ref
		//IL_01f2: Expected O, but got Ref
		//IL_0422: Expected O, but got Ref
		//IL_0422: Expected O, but got Ref
		//IL_021e: Expected O, but got Ref
		//IL_021e: Expected O, but got Ref
		//IL_02e2: Expected O, but got I4
		//IL_02eb: Expected O, but got I4
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		if (destroyed)
		{
			return;
		}
		float radius2;
		if ((bool)sphereCollider)
		{
			float radius = sphereCollider.radius;
			radius2 = radius;
			RaycastHit raycastHit = (RaycastHit)radius;
		}
		else
		{
			radius2 = colliderRadius;
			RaycastHit raycastHit = (RaycastHit)0;
		}
		Vector3 velocity = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float deltaTime = Time.deltaTime;
		float num3;
		if (rb.useGravity)
		{
			Vector3 gravity = Physics.gravity;
			float deltaTime2 = Time.deltaTime;
			float num = gravity.x * deltaTime2;
			float num2 = num + velocity.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			float deltaTime3 = Time.deltaTime;
			num3 = num2;
		}
		else
		{
			num3 = velocity.x;
		}
		Vector3 position = myTransform.position;
		float num4 = default(float);
		float maxDistance = default(float);
		if (!Physics.SphereCast((Vector3)(&num4), radius2, (Vector3)(&num3), out var hitInfo, maxDistance))
		{
			float deltaTime4 = Time.deltaTime;
			if ((destroyTimer = deltaTime4 + destroyTimer) < 5f)
			{
				goto IL_03dc;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			myTransform.position = (Vector3)(&num3);
			Vector3 position2 = myTransform.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			Quaternion quaternion = Quaternion.FromToRotation((Vector3)(&num3), (Vector3)(&num4));
			Vector3 vector = default(Vector3);
			GameObject obj = Object.Instantiate(impactParticle, (Vector3)(&num4), (Quaternion)(&vector));
			Transform transform = hitInfo.transform;
			string text = transform.tag;
			if (text == "Target")
			{
				Transform transform2 = hitInfo.transform;
				RetroTarget component = transform2.GetComponent<RetroTarget>();
				if (component != null)
				{
					component.OnHit();
				}
			}
			GameObject[] array = trailParticles;
			object obj2 = 0;
			object obj3 = 0;
			while ((nint)obj3 < array.Length)
			{
				string text2 = projectileParticle.name;
				string text3 = array[obj2].name;
				string n = text2 + "/" + text3;
				Transform transform3 = myTransform.Find(n);
				GameObject gameObject = transform3.gameObject;
				Transform transform4 = gameObject.transform;
				transform4.parent = null;
				Object.Destroy(gameObject, 3f);
				obj2++;
				obj3 = obj2;
			}
			Object.Destroy(projectileParticle, 3f);
			Object.Destroy(obj, 5f);
		}
		DestroyMissile();
		goto IL_03dc;
		IL_03dc:
		RotateTowardsDirection();
	}

	private void DestroyMissile()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		GameObject[] array = trailParticles;
		destroyed = true;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			string text = projectileParticle.name;
			string text2 = array[obj].name;
			string n = text + "/" + text2;
			Transform transform = myTransform.Find(n);
			GameObject gameObject = transform.gameObject;
			Transform transform2 = gameObject.transform;
			transform2.parent = null;
			Object.Destroy(gameObject, 3f);
			obj++;
			obj2 = obj;
		}
		Object.Destroy(projectileParticle, 3f);
		GameObject obj3 = base.gameObject;
		Object.Destroy(obj3);
		ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
		object obj4 = 1;
		while ((nint)obj4 < componentsInChildren.Length)
		{
			GameObject gameObject2 = componentsInChildren[obj4].gameObject;
			string text3 = gameObject2.name;
			if (text3.Contains("Trail"))
			{
				Transform transform3 = componentsInChildren[obj4].transform;
				transform3.parentInternal = null;
				GameObject obj5 = componentsInChildren[obj4].gameObject;
				Object.Destroy(obj5, 2f);
			}
			obj4++;
		}
	}

	private void RotateTowardsDirection()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_01fc: Expected I, but got O
		//IL_0244: Expected O, but got I
		//IL_02d1: Invalid comparison between F4 and I4
		//IL_02fa: Expected O, but got I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0328: Expected I, but got O
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		Vector3 velocity = rb.velocity;
		_ = velocity.x;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_ = Vector3.zeroVector;
		float num3 = velocity.x - (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-5]");
		object obj3 = num4 - 0;
		float num5 = velocity.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num6 = num5 - 0f;
		object obj4 = obj3 * obj3;
		float num7 = num3 * num3;
		float num8 = num6 * num6;
		float num9 = (float)obj4 + num7;
		float num10 = num9 + num8;
		bool flag = 9.9999994E-11f < num10;
		float num11 = 9.9999994E-11f - num10;
		bool flag2 = num11 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj5 = flag4 & flag3;
		if (obj5 == null)
		{
			Vector3 velocity2 = rb.velocity;
			object obj6 = obj - 25;
			object obj7 = obj + 7;
			_ = velocity2.x;
			_ = velocity2.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			nint num12 = (nint)typeof(Vector3);
			Vector3 upwards = (Vector3)(obj - 9);
			Vector3 forward = (Vector3)(obj + 7);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v13+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v15 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num13 = 0;
			_ = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			_ = 0;
			Quaternion quaternion = Quaternion.LookRotation(forward, upwards);
			Vector3 forward2 = myTransform.forward;
			Vector3 velocity3 = rb.velocity;
			object obj8 = obj - 25;
			object obj9 = obj - 9;
			_ = velocity3.x;
			_ = velocity3.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj10 = obj + 7;
			object obj11 = obj - 9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v22+8]");
			_ = 0;
			_ = forward2.x;
			_ = forward2.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			float deltaTime = Time.deltaTime;
			_ = quaternion.x;
			Quaternion rotation = myTransform.rotation;
			object obj12 = default(object);
			float t = deltaTime * (float)obj12;
			Quaternion b = (Quaternion)(obj + 7);
			Quaternion a = (Quaternion)(obj - 9);
			_ = rotation.x;
			Quaternion quaternion2 = Quaternion.Slerp(a, b, t);
			Quaternion rotation2 = (Quaternion)(obj + 7);
			_ = quaternion2.x;
			myTransform.rotation = rotation2;
		}
	}
}
