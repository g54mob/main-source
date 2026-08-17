using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class CreditsWindow : MonoBehaviour
{
	private float nextUpdateTime;

	private int holdingDir;

	private float cooldownTimer;

	public ScrollRect scrollRect;

	private float multiplier;

	private void Update()
	{
		//IL_0294: Expected I4, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317309A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float axisRaw = Input.GetAxisRaw("Vertical");
		if (!(axisRaw > 0.2f))
		{
			float axisRaw2 = Input.GetAxisRaw("Vertical");
			if (!(-0.2f > axisRaw2))
			{
				if (holdingDir != 0)
				{
					multiplier = 1f;
					cooldownTimer = 0.3f;
					float time = Time.time;
					nextUpdateTime = time;
				}
				holdingDir = 0;
			}
			else
			{
				if (holdingDir != -1)
				{
					multiplier = 1f;
					cooldownTimer = 0.3f;
					float time2 = Time.time;
					nextUpdateTime = time2;
				}
				holdingDir = -1;
			}
		}
		else
		{
			if (holdingDir != 1)
			{
				multiplier = 1f;
				cooldownTimer = 0.3f;
				float time3 = Time.time;
				nextUpdateTime = time3;
			}
			holdingDir = 1;
		}
		float time4 = Time.time;
		if (nextUpdateTime > time4)
		{
			return;
		}
		float time5 = Time.time;
		float num = time5 + cooldownTimer;
		float num2 = cooldownTimer * 0.6f;
		nextUpdateTime = num;
		float num3 = multiplier * 1.015f;
		multiplier = num3;
		float num4;
		if (!(0.01f > num2))
		{
			bool flag = num2 > 0.35f;
			num4 = 0.35f;
			if (!flag)
			{
				num4 = num2;
			}
		}
		else
		{
			num4 = 0.01f;
		}
		bool flag2 = holdingDir == 0;
		cooldownTimer = num4;
		if (!flag2)
		{
			float verticalNormalizedPosition = scrollRect.verticalNormalizedPosition;
			float num5 = (float)holdingDir * 0.01f;
			float num6 = num5 * multiplier;
			float verticalNormalizedPosition2 = num6 + verticalNormalizedPosition;
			scrollRect.verticalNormalizedPosition = verticalNormalizedPosition2;
		}
	}

	private void ResetCooldown()
	{
		multiplier = 1f;
		cooldownTimer = 0.3f;
		float time = Time.time;
		nextUpdateTime = time;
	}
}
