using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Movement;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class PlayerSfxs : MonoBehaviour
{
	public static PlayerSfxs Instance;

	public RandomSfx sourceEvade;

	public RandomSfx sourceFlex;

	public RandomSfx slideStart;

	public AudioSource slideLoop;

	public AudioClip evade;

	public AudioClip evadePhantom;

	public AudioSource windAudio;

	private float maxVolume = 0.32f;

	private float maxPitch = 1.8f;

	private float minSpeed = 7f;

	private float maxSpeed = 55f;

	public GameObject grindFx;

	public RandomSfx sourceGrindAction;

	public RandomSfx sourceGrindLoop;

	public AudioClip grindStart;

	public AudioClip grindStop;

	private float avgSpeed;

	private bool wasPlayingGrind;

	private void Start()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> b = OnPause;
		Delegate obj = Delegate.Combine(MyTime.A_Pause, b);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<bool> value = OnPause;
		Delegate obj = Delegate.Remove(MyTime.A_Pause, value);
		if ((object)obj == null)
		{
			MyTime.A_Pause = (Action<bool>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action = default(Action<bool>);
		if (action != null)
		{
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<bool>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<bool>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Update()
	{
		if (!MyTime.paused)
		{
			MyPlayer instance = MyPlayer.Instance;
			UnityEngine.Object obj;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerMovement playerMovement = instance.playerMovement;
				obj = playerMovement.rb;
			}
			else
			{
				obj = null;
			}
			if (obj != null)
			{
				UpdateSliding();
				UpdateWind();
			}
		}
	}

	public void Evade(bool phantom)
	{
		//IL_002c: Expected O, but got I4
		RandomSfx randomSfx = sourceEvade;
		AudioClip[] array = new AudioClip[1];
		AudioClip audioClip = ((!phantom) ? evade : evadePhantom);
		array[0] = audioClip;
		object obj = 32;
		sourceEvade.Play();
	}

	public void Flex()
	{
		sourceFlex.Play();
	}

	public void StartGrind()
	{
		RandomSfx randomSfx = sourceGrindAction;
		randomSfx.sounds = new AudioClip[1] { grindStart };
		sourceGrindAction.Play();
		sourceGrindLoop.Play();
		grindFx.SetActive(value: true);
	}

	public void StopGrind()
	{
		RandomSfx randomSfx = sourceGrindAction;
		randomSfx.sounds = new AudioClip[1] { grindStop };
		sourceGrindAction.Play();
		sourceGrindLoop.Stop();
		grindFx.SetActive(value: false);
	}

	private void UpdateSliding()
	{
		//IL_0094: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0122: Expected F4, but got I4
		//IL_015d: Invalid comparison between I4 and F4
		//IL_01a8: Expected F4, but got I4
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance == null || instance.inventory == null)
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if (instance2.character == ECharacter.TonyMcZoom)
		{
			return;
		}
		if (!MyPlayer.Instance.IsDead())
		{
			MyPlayer instance3 = MyPlayer.Instance;
			EMovementState movementState = instance3.playerMovement.GetMovementState();
			object obj = movementState & EMovementState.Sliding;
			bool flag = obj == null;
			object obj2 = !flag;
			object obj3;
			if (obj2 == null)
			{
				obj3 = 0;
			}
			else
			{
				MyPlayer instance4 = MyPlayer.Instance;
				EMovementState movementState2 = instance4.playerMovement.GetMovementState();
				object obj4 = (int)movementState2 >> 4;
				object obj5 = ~obj4;
				obj3 = obj5 & 1;
			}
			float num = ((obj3 == null) ? 0f : 0.35f);
			float volume = slideLoop.volume;
			float deltaTime = Time.deltaTime;
			float num2 = deltaTime * 12f;
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
			float num3 = num - volume;
			float num4 = num3 * num2;
			float volume2 = num4 + volume;
			slideLoop.volume = volume2;
			if (obj3 != null)
			{
				if (!slideLoop.isPlaying)
				{
					slideStart.Play();
					slideLoop.Play();
				}
				return;
			}
			float volume3 = slideLoop.volume;
			if (0.05f < volume3)
			{
				return;
			}
			slideLoop.volume = 0f;
		}
		else if (!slideLoop.isPlaying)
		{
			return;
		}
		slideLoop.Stop();
	}

	private void UpdateWind()
	{
		//IL_0226: Expected I, but got O
		//IL_011c: Invalid comparison between I4 and F4
		//IL_0169: Expected F4, but got I4
		//IL_024d: Invalid comparison between I4 and F4
		//IL_01a5: Expected F4, but got I4
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		Vector3 velocity = instance.playerMovement.GetVelocity();
		nint num = (nint)typeof(Math);
		float num2 = velocity.y * velocity.y;
		float num3 = velocity.x * velocity.x;
		float num4 = velocity.z * velocity.z;
		float num5 = num2 + num3;
		float num6 = num5 + num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v11 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num7 = Math.Sqrt(num6);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
		float num8 = 0f - minSpeed;
		if (!(0f > num8))
		{
			if (num8 > maxSpeed)
			{
				num8 = maxSpeed;
			}
		}
		else
		{
			num8 = 0f;
		}
		float deltaTime = Time.deltaTime;
		float num9 = deltaTime * 4f;
		if (!(0f > num9))
		{
			if (num9 > 1f)
			{
				num9 = 1f;
			}
		}
		else
		{
			num9 = 0f;
		}
		float num10 = num8 - avgSpeed;
		float num11 = num10 * num9;
		float num12 = (avgSpeed = num11 + avgSpeed) / maxSpeed;
		float volume = num12 * maxVolume;
		windAudio.volume = volume;
		float num13 = num12 * maxPitch;
		float pitch = num13 + 1f;
		windAudio.pitch = pitch;
	}

	private void OnPause(bool pause)
	{
		RandomSfx randomSfx = sourceGrindLoop;
		if (!pause)
		{
			randomSfx.s.UnPause();
			windAudio.UnPause();
		}
		else
		{
			randomSfx.s.Pause();
			windAudio.Pause();
		}
	}
}
