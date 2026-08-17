using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class BloodMageAnimations : MonoBehaviour
{
	public AudioSource audioHoverLoop;

	private float defaultVolume;

	private float currentPitch;

	private void Awake()
	{
		float volume = audioHoverLoop.volume;
		defaultVolume = volume;
	}

	private void Update()
	{
		//IL_0052: Invalid comparison between I4 and F4
		//IL_009d: Expected F4, but got I4
		//IL_02c9: Invalid comparison between I4 and F4
		//IL_010d: Expected F4, but got I4
		//IL_0351: Invalid comparison between I4 and F4
		//IL_0149: Expected F4, but got I4
		//IL_016b: Expected I, but got O
		//IL_01d3: Invalid comparison between I4 and F4
		//IL_021e: Expected F4, but got I4
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		float speedHorizontal = instance.playerMovement.GetSpeedHorizontal();
		float num = speedHorizontal / 50f;
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
		float num3;
		if (!(0f > num))
		{
			if (!(num > 1f))
			{
				float num2 = num * 0.049999952f;
				num3 = num2 + 1f;
			}
			else
			{
				num3 = 1.05f;
				num = 1f;
			}
		}
		else
		{
			num3 = 1f;
			num = 0f;
		}
		float num4 = num * 0.7f;
		float num5 = MyTime.deltaTime + MyTime.deltaTime;
		if (!(0f > num5))
		{
			if (num5 > 1f)
			{
				num5 = 1f;
			}
		}
		else
		{
			num5 = 0f;
		}
		float num6 = num3 - currentPitch;
		float num7 = num6 * num5;
		float pitch = (currentPitch = num7 + currentPitch);
		audioHoverLoop.pitch = pitch;
		nint num8 = (nint)typeof(MyTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rax_v17 (Il2CppClass<Assets.Scripts.Utility.MyTime>)+B8]");
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
		float num14 = num4 + 0.3f;
		float num15 = num13 - 0.15f;
		float num16 = num14 * defaultVolume;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num15 & 0;
		float num17 = 0.15f - (float)obj;
		float num18 = num17 + 1f;
		float volume = num18 * num16;
		audioHoverLoop.volume = volume;
	}
}
