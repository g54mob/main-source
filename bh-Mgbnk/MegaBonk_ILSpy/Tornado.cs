using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class Tornado : MonoBehaviour
{
	public float force = 0.85f;

	public Rigidbody rb;

	private Vector3 desiredVelocity;

	private float speed = 5f;

	private float actualSpeed = 5f;

	private Vector3 lastPos;

	public AudioSource audio;

	private float defaultVolume;

	private float startTime;

	private float stopTime;

	private Vector3 defaultScale;

	private float scaleMultiplier;

	private float fadeTime = 2f;

	private unsafe void Start()
	{
		//IL_008c: Expected O, but got F4
		//IL_00b7: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B04]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		rb.isKinematic = true;
		float volume = audio.volume;
		defaultVolume = volume;
		Transform transform = base.transform;
		Vector3 localScale = transform.localScale;
		defaultScale = (Vector3)localScale.x;
		_ = localScale.z;
		Transform transform2 = base.transform;
		object obj = default(object);
		transform2.localScale = (Vector3)(&obj);
		Invoke("Spawn", 1f);
		float num = (scaleMultiplier = Random.Range(0.5f, 4f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Tornado)+6C]");
		float num2 = num * 0f;
		Vector3 vector = default(Vector3);
		defaultScale = vector;
	}

	private unsafe void Spawn()
	{
		//IL_003d: Expected O, but got Ref
		//IL_0083: Expected O, but got Ref
		Vector3 randomSpawnPositionOnMap = SpawnPositions.GetRandomSpawnPositionOnMap(999f);
		rb.isKinematic = false;
		float num = default(float);
		rb.MovePosition((Vector3)(&num));
		audio.volume = 0f;
		audio.Play();
		Transform transform = base.transform;
		transform.localScale = (Vector3)(&num);
		float num2 = Random.Range(4f, 10f);
		speed = num2;
		FindNewDir();
		startTime = MyTime.time;
		float num3 = Random.Range(30f, 45f);
		float num4 = num3 + MyTime.time;
		stopTime = num4;
	}

	private unsafe void FindNewDir()
	{
		//IL_0013: Expected O, but got Ref
		Vector3 insideUnitSphere = Random.insideUnitSphere;
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num2 = speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v5+8]");
		float num3 = num2 * 0f;
		actualSpeed = 5f;
		Vector3 vector2 = default(Vector3);
		desiredVelocity = vector2;
	}

	private unsafe void Update()
	{
		//IL_0297: Invalid comparison between I4 and F4
		//IL_0304: Invalid comparison between I4 and F4
		//IL_0046: Expected O, but got Ref
		//IL_004f: Invalid comparison between I4 and F4
		//IL_009a: Expected F4, but got I4
		//IL_0105: Expected O, but got Ref
		//IL_010e: Invalid comparison between I4 and F4
		//IL_01df: Expected O, but got Ref
		//IL_0159: Expected F4, but got I4
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0225: Expected O, but got Ref
		float num = fadeTime + startTime;
		float num4 = default(float);
		if (num > MyTime.time)
		{
			float num2 = MyTime.time - startTime;
			float num3 = num2 / fadeTime;
			Transform transform = base.transform;
			if (0f > num3 || !(num3 > 1f))
			{
			}
			transform.localScale = (Vector3)(&num4);
			if (!(0f > num3))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			float volume = defaultVolume * num3;
			audio.volume = volume;
		}
		float num5 = stopTime - fadeTime;
		if (MyTime.time > num5)
		{
			float num6 = stopTime - fadeTime;
			float num7 = MyTime.time - num6;
			float num8 = num7 / fadeTime;
			Transform transform2 = base.transform;
			if (0f > num8 || !(num8 > 1f))
			{
			}
			transform2.localScale = (Vector3)(&num4);
			if (!(0f > num8))
			{
				if (num8 > 1f)
				{
					num8 = 1f;
				}
			}
			else
			{
				num8 = 0f;
			}
			object obj = 0 - defaultVolume;
			float num9 = (float)obj * num8;
			float volume2 = num9 + defaultVolume;
			audio.volume = volume2;
		}
		if (!(MyTime.time < stopTime))
		{
			Vector3 randomSpawnPositionOnMap = SpawnPositions.GetRandomSpawnPositionOnMap(999f);
			rb.isKinematic = false;
			rb.MovePosition((Vector3)(&num4));
			audio.volume = 0f;
			audio.Play();
			Transform transform3 = base.transform;
			transform3.localScale = (Vector3)(&num4);
			float num10 = Random.Range(4f, 10f);
			speed = num10;
			FindNewDir();
			startTime = MyTime.time;
			float num11 = Random.Range(30f, 45f);
			float num12 = num11 + MyTime.time;
			stopTime = num12;
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_031c: Invalid comparison between I4 and F4
		//IL_0341: Expected I, but got O
		//IL_00a0: Expected O, but got Ref
		//IL_00ae: Expected O, but got Ref
		//IL_01ff: Expected O, but got Ref
		//IL_0247: Expected O, but got Ref
		//IL_02e1: Expected O, but got F4
		//IL_03f8: Expected I, but got O
		//IL_0195: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!rb.isKinematic && !MyTime.paused && 0f < MyTime.fixedDeltaTime)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rax_v15 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num3 = 0f * 10f;
			float num4 = (float)Vector3.upVector * 10f;
			float num5 = num3 + position2.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num6 = 0f * 10f;
			float num7 = num4 + position2.x;
			float num8 = num6 + position2.z;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			float radius = scaleMultiplier * 4f;
			Vector3 end = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Vector3 start = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = position.x;
			_ = position.z;
			int num9 = default(int);
			bool flag = Physics.CheckCapsule(start, end, radius, num9);
			bool flag2 = !flag;
			int num10 = num9;
			if (!flag2)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerMovement playerMovement = instance2.playerMovement;
				nint num11 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rax_v37 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num12 = 0;
				_ = Vector3.upVector;
				float num13 = (float)Vector3.upVector * force;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-15]");
				float num14 = 0f * force;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num15 = 0f * force;
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerMovement playerMovement2 = instance3.playerMovement;
				float mass = playerMovement2.rb.mass;
				float num16 = num13 * mass;
				float num17 = num14 * mass;
				float num18 = num15 * mass;
				Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				playerMovement.rb.AddForce(vector, ForceMode.Acceleration);
				MyPlayer instance4 = MyPlayer.Instance;
				instance4.playerMovement.TouchingTornado();
				num10 = 0;
			}
			Vector3 velocity = rb.velocity;
			_ = desiredVelocity;
			Vector3 velocity2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = velocity.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Tornado)+38]");
			_ = 0;
			rb.velocity = velocity2;
			Vector3 position3 = rb.position;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			float num19 = position3.x - (float)lastPos;
			float num20 = position3.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Tornado)+48]");
			float num21 = num20 - 0f;
			float num22 = position3.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Tornado)+4C]");
			float num23 = num22 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			float num24 = num23 / MyTime.fixedDeltaTime;
			float num25 = num24 - actualSpeed;
			float num26 = num25 * 0.1f;
			if (2.5f > (actualSpeed = num26 + actualSpeed))
			{
				FindNewDir();
			}
			Vector3 position4 = rb.position;
			lastPos = (Vector3)position4.x;
			_ = position4.z;
		}
	}

	private void OnDrawGizmosSelected()
	{
	}
}
