using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonSetting : MyButton
{
	public BetterSetting betterSetting;

	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	public Action A_StartHover;

	public Action A_StopHover;

	private float nextUpdateTime;

	private int holdingDir;

	private float cooldownTimer;

	private float multiplier;

	private float canUseHorizontalTime;

	public unsafe override void StartHover()
	{
		//IL_0017: Expected I, but got O
		//IL_0024: Expected O, but got Ref
		MaskableGraphic maskableGraphic = background;
		nint num = (nint)maskableGraphic;
		object obj = default(object);
		maskableGraphic.color = (Color)(&obj);
		isHovering = true;
		multiplier = 1f;
		cooldownTimer = 0.3f;
		float time = Time.time;
		nextUpdateTime = time;
		float time2 = Time.time;
		float num2 = time2 + 0.2f;
		Action a_StartHover = A_StartHover;
		canUseHorizontalTime = num2;
		if (A_StartHover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v35.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void ResetCanUseHorizontalTime()
	{
		float time = Time.time;
		float num = time + 0.2f;
		canUseHorizontalTime = num;
	}

	public unsafe override void StopHover()
	{
		//IL_0017: Expected I, but got O
		//IL_0024: Expected O, but got Ref
		MaskableGraphic maskableGraphic = background;
		nint num = (nint)maskableGraphic;
		object obj = default(object);
		maskableGraphic.color = (Color)(&obj);
		Action a_StopHover = A_StopHover;
		isHovering = false;
		if (A_StopHover != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v26.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	protected override void OnClick()
	{
	}

	private new void Update()
	{
		//IL_0314: Expected I4, but got I8
		base.Update();
		bool flag = betterSetting.IsDisabled();
		if (!flag)
		{
			if (isHovering == flag)
			{
				return;
			}
			float time = Time.time;
			if (canUseHorizontalTime > time)
			{
				return;
			}
			if (isHovering)
			{
				float axis = MyInputManager.GetAxis(MyInputManager.UIHorizontal);
				if (axis > 0.5f)
				{
					if (holdingDir != 1)
					{
						multiplier = 1f;
						cooldownTimer = 0.3f;
						float time2 = Time.time;
						nextUpdateTime = time2;
					}
					holdingDir = 1;
				}
				else
				{
					float axis2 = MyInputManager.GetAxis(MyInputManager.UIHorizontal);
					if (!(-0.5f > axis2))
					{
						if (holdingDir != 0)
						{
							multiplier = 1f;
							cooldownTimer = 0.3f;
							float time3 = Time.time;
							nextUpdateTime = time3;
						}
						holdingDir = 0;
					}
					else
					{
						if (holdingDir != -1)
						{
							multiplier = 1f;
							cooldownTimer = 0.3f;
							float time4 = Time.time;
							nextUpdateTime = time4;
						}
						holdingDir = -1;
					}
				}
			}
			float time5 = Time.time;
			if (nextUpdateTime > time5)
			{
				return;
			}
			float time6 = Time.time;
			float num = time6 + cooldownTimer;
			float num2 = cooldownTimer * 0.6f;
			float num3 = multiplier * 1.015f;
			nextUpdateTime = num;
			multiplier = num3;
			bool flag2 = 0.01f > num2;
			float num4 = 0.01f;
			if (!flag2)
			{
				bool flag3 = num2 > 0.35f;
				num4 = 0.35f;
				if (!flag3)
				{
					num4 = num2;
				}
			}
			bool flag4 = holdingDir == 0;
			cooldownTimer = num4;
			if (!flag4)
			{
				betterSetting.ControllerInputDir(holdingDir, num3);
				if ((object)AudioManager.Instance != null)
				{
					AudioManager.Instance.PlayButtonSelect();
				}
			}
		}
		else
		{
			holdingDir = 0;
		}
	}

	private void ResetCooldown()
	{
		multiplier = 1f;
		cooldownTimer = 0.3f;
		float time = Time.time;
		nextUpdateTime = time;
	}

	public MyButtonSetting()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
