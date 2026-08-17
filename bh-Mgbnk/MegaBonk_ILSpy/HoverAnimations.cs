using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class HoverAnimations : MonoBehaviour
{
	public Transform player;

	public AudioSource audioHoverLoop;

	public AudioSource audioSpin;

	public Animator animator;

	private Vector3 defaultPos;

	private Vector3 defaultRotation;

	private float currentPitch;

	private float nextLandingReadyTime;

	private float landingInterval = 0.25f;

	private float minLandingSpeed = 4f;

	private float maxLandingSpeed = 20f;

	public float sinSpeed = 5f;

	public float height = 0.5f;

	private float currentLandingOffset;

	private float landingOffset;

	private float minLandingOffset = 1f;

	private float maxLandingOffset = 2.3f;

	public float landingResetSpeed = 5f;

	public float landingSpeed = 8f;

	private float lastVelY;

	private float currentLean;

	private float targetLean;

	public float maxLeanAngle = 25f;

	public float leanSpeed = 5f;

	public float maxSpeedForLean = 40f;

	private float newLean;

	private unsafe void Start()
	{
		//IL_001e: Expected O, but got F4
		//IL_0046: Expected O, but got Ref
		//IL_0058: Expected O, but got Ref
		//IL_006b: Expected O, but got F4
		Vector3 localPosition = player.localPosition;
		defaultPos = (Vector3)localPosition.x;
		_ = localPosition.z;
		Quaternion localRotation = player.localRotation;
		float num = default(float);
		Vector3 vector = Quaternion.Internal_ToEulerRad((Quaternion)(&num));
		Vector3 vector2 = Quaternion.Internal_MakePositive((Vector3)(&num));
		defaultRotation = (Vector3)vector2.x;
		_ = vector2.z;
	}

	private void Update()
	{
		//IL_0052: Invalid comparison between I4 and F4
		//IL_009d: Expected F4, but got I4
		//IL_031c: Invalid comparison between I4 and F4
		//IL_00d9: Expected F4, but got I4
		//IL_050e: Invalid comparison between I4 and F4
		//IL_0115: Expected F4, but got I4
		//IL_039e: Expected I, but got O
		//IL_0401: Invalid comparison between I4 and F4
		//IL_0151: Expected F4, but got I4
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0249: Expected O, but got I4
		//IL_043d: Invalid comparison between I4 and F4
		//IL_02aa: Expected F4, but got I4
		//IL_04a7: Invalid comparison between I4 and F4
		//IL_02fa: Expected F4, but got I4
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		float speedHorizontal = instance.playerMovement.GetSpeedHorizontal();
		float num = speedHorizontal / 60f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = num * 6f;
		float num3 = num2 + 1f;
		float num4 = MyTime.deltaTime + MyTime.deltaTime;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		float num5 = num3 - currentPitch;
		float num6 = num5 * num4;
		float num7 = (currentPitch = num6 + currentPitch);
		nint num8 = (nint)typeof(MyTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rax_v16 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
		nint num9 = 0;
		float num10 = MyTime.time * 0.6f;
		float num11 = num10 / 0.3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num12 = num11 * 0.3f;
		float num13 = num10 - num12;
		if (!(0f > num13))
		{
			if (num13 > 0.3f)
			{
				num13 = 0.3f;
			}
		}
		else
		{
			num13 = 0f;
		}
		float num14 = num13 - 0.15f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num14 & 0;
		float num15 = 0.15f - (float)obj;
		float pitch = num15 + num7;
		audioHoverLoop.pitch = pitch;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerMovement playerMovement = instance2.playerMovement;
		AudioSource audioSource;
		AudioSource audioSource2;
		float volume2;
		if (playerMovement.grounded)
		{
			audioSource = audioSpin;
			audioSource2 = audioSpin;
		}
		else
		{
			MyPlayer instance3 = MyPlayer.Instance;
			bool flag = (object)instance3.playerMovement == null;
			bool flag2 = instance3.playerMovement.IsCrouching();
			audioSource = audioSpin;
			object obj2 = !flag;
			audioSource2 = audioSpin;
			if (obj2 != null)
			{
				float volume = audioSpin.volume;
				float num16 = MyTime.deltaTime * 7f;
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
				float num17 = 0.09f - volume;
				float num18 = num17 * num16;
				volume2 = num18 + volume;
				goto IL_0522;
			}
		}
		float volume3 = audioSource2.volume;
		float num19 = MyTime.deltaTime * 7f;
		if (!(0f > num19))
		{
			if (num19 > 1f)
			{
				num19 = 1f;
			}
		}
		else
		{
			num19 = 0f;
		}
		float num20 = 0f - volume3;
		float num21 = num20 * num19;
		float num22 = num21 + volume3;
		volume2 = num22;
		goto IL_0522;
		IL_0522:
		audioSource.volume = volume2;
	}

	private void OnLanded(float speed)
	{
		//IL_0046: Invalid comparison between I4 and F4
		//IL_0091: Expected F4, but got I4
		//IL_0135: Invalid comparison between I4 and F4
		//IL_00d2: Expected F4, but got I4
		//IL_01a6: Invalid comparison between F4 and I
		//IL_00e7: Expected F4, but got I
		if (nextLandingReadyTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + landingInterval;
		nextLandingReadyTime = num;
		if (minLandingSpeed > speed)
		{
			return;
		}
		float num2 = speed - minLandingSpeed;
		float num3 = maxLandingSpeed - minLandingSpeed;
		float num4 = num2 / num3;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		float num5;
		if (!(0f > num4))
		{
			bool flag = num4 > 1f;
			num5 = 1f;
			if (!flag)
			{
				num5 = num4;
			}
		}
		else
		{
			num5 = 0f;
		}
		float num6 = maxLandingOffset - minLandingOffset;
		float num7 = num6 * num5;
		float num8 = num7 + minLandingOffset;
		landingOffset = num8;
		float num9 = num4 * 0.5f;
		float num10 = num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC40]");
		if (num10 < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC40]");
			num9 = 0f;
		}
		float num11 = currentPitch - num9;
		currentPitch = num11;
	}

	private unsafe void LateUpdate()
	{
		//IL_0027: Expected O, but got Ref
		//IL_0042: Invalid comparison between I4 and F4
		//IL_008d: Expected F4, but got I4
		//IL_0138: Invalid comparison between I4 and F4
		//IL_00c9: Expected F4, but got I4
		float num = MyTime.time * sinSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
		Transform transform = player.transform;
		float num2 = default(float);
		transform.localPosition = (Vector3)(&num2);
		float num3 = MyTime.deltaTime * landingResetSpeed;
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
		float num4 = 0f - landingOffset;
		float num5 = num4 * num3;
		float num6 = (landingOffset = num5 + landingOffset);
		float num7 = MyTime.deltaTime * landingSpeed;
		if (!(0f > num7))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		float num8 = num6 - currentLandingOffset;
		float num9 = num8 * num7;
		float num10 = num9 + currentLandingOffset;
		currentLandingOffset = num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 232 Invalid \"Jump target not found in method: 0x180355DE0\"");
		throw new NullReferenceException();
	}

	private unsafe void LeanRotation()
	{
		//IL_0121: Expected F4, but got I4
		//IL_0231: Invalid comparison between I4 and F4
		//IL_0088: Expected O, but got Ref
		//IL_00ab: Invalid comparison between I4 and F4
		//IL_015d: Expected F4, but got I4
		//IL_0113: Expected F4, but got I4
		//IL_0208: Expected O, but got Ref
		//IL_0171: Expected O, but got Ref
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		Vector3 velocity = instance.playerMovement.GetVelocity();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float num4;
		if (!(0.01f > velocity.x))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			float num = default(float);
			Vector3 vector = player.InverseTransformDirection((Vector3)(&num));
			float num2 = velocity.x / maxSpeedForLean;
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					float num3 = vector.x * maxLeanAngle;
					num4 = num3 * 1f;
					goto IL_01b4;
				}
			}
			else
			{
				num2 = 0f;
			}
			float num5 = vector.x * maxLeanAngle;
			num4 = num5 * num2;
		}
		else
		{
			num4 = 0f;
		}
		goto IL_01b4;
		IL_01b4:
		targetLean = num4;
		float num6 = MyTime.deltaTime * leanSpeed;
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		float num7 = num4 - currentLean;
		float num8 = num7 * num6;
		float num9 = num8 + currentLean;
		currentLean = num9;
		Vector3 vector2 = default(Vector3);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&vector2));
		object obj = default(object);
		player.localRotation = (Quaternion)(&obj);
	}

	private void FixedUpdate()
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008c: Invalid comparison between O and F4
		//IL_00e9: Invalid comparison between I4 and F4
		//IL_0134: Expected F4, but got I4
		//IL_0216: Invalid comparison between I4 and F4
		//IL_0175: Expected F4, but got I4
		//IL_0287: Invalid comparison between F4 and I
		//IL_018a: Expected F4, but got I
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		float num = instance.playerMovement.GetVelocity().y - lastVelY;
		if (!(num > minLandingSpeed))
		{
			float num2 = minLandingSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			object obj = num2 ^ 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
			{
				goto IL_02a3;
			}
		}
		if (!(nextLandingReadyTime > MyTime.time))
		{
			float num3 = MyTime.time + landingInterval;
			nextLandingReadyTime = num3;
			if (!(minLandingSpeed > num))
			{
				float num4 = num - minLandingSpeed;
				float num5 = maxLandingSpeed - minLandingSpeed;
				float num6 = num4 / num5;
				if (!(0f > num6))
				{
					if (num6 > 1f)
					{
						num6 = 1f;
					}
				}
				else
				{
					num6 = 0f;
				}
				float num7;
				if (!(0f > num6))
				{
					bool flag = num6 > 1f;
					num7 = 1f;
					if (!flag)
					{
						num7 = num6;
					}
				}
				else
				{
					num7 = 0f;
				}
				float num8 = maxLandingOffset - minLandingOffset;
				float num9 = num8 * num7;
				float num10 = num9 + minLandingOffset;
				landingOffset = num10;
				float num11 = num6 * 0.5f;
				float num12 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC40]");
				if (num12 < 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262EC40]");
					num11 = 0f;
				}
				float num13 = currentPitch - num11;
				currentPitch = num13;
			}
		}
		goto IL_02a3;
		IL_02a3:
		MyPlayer instance2 = MyPlayer.Instance;
		lastVelY = instance2.playerMovement.GetVelocity().y;
	}
}
