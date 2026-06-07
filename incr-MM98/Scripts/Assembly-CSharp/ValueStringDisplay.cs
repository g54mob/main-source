using LitMotion;
using LitMotion.Extensions;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class ValueStringDisplay : MonoBehaviour
{
	[SerializeField]
	protected TMP_Text field;

	[SerializeField]
	private ScrambleMode scramble = ScrambleMode.Uppercase;

	[SerializeField]
	private Vector3 direction = Vector3.up;

	[SerializeField]
	private Ease ease = Ease.InOutBounce;

	[SerializeField]
	private float punchDelay = 0.05f;

	protected string Text = "";

	private MotionHandle _handle;

	public virtual void Animate(string text, float duration)
	{
		if (_handle.IsValid())
		{
			_handle.TryCancel();
		}
		if (string.IsNullOrEmpty(text) || duration == 0f)
		{
			field.SetText(text);
			return;
		}
		if (string.IsNullOrEmpty(Text))
		{
			Text = "";
		}
		MotionSequenceBuilder motionSequenceBuilder = LSequence.Create();
		float num = Mathf.Min(punchDelay, duration / (float)text.Length);
		MotionHandle handle = LMotion.String.Create64Bytes((FixedString64Bytes)Text, (FixedString64Bytes)text, duration).WithScrambleChars(scramble).BindToText(field);
		motionSequenceBuilder.Append(handle);
		for (int i = 0; i < text.Length; i++)
		{
			MotionHandle handle2 = LMotion.Punch.Create(Vector3.zero, direction, duration).WithEase(ease).BindToTMPCharPosition(field, i);
			motionSequenceBuilder.Insert((float)i * num, handle2);
		}
		_handle = motionSequenceBuilder.Run().AddTo(this);
		Text = text;
	}

	public virtual void AnimateChangedCharacters(string text, float duration)
	{
		if (_handle.IsValid())
		{
			_handle.TryCancel();
		}
		if (string.IsNullOrEmpty(text))
		{
			field.SetText(text);
			return;
		}
		int num = FindFirstCharacterDifference(Text, text);
		if (num < text.Length)
		{
			MotionSequenceBuilder motionSequenceBuilder = LSequence.Create();
			float num2 = Mathf.Min(punchDelay, duration / (float)text.Length - (float)num);
			for (int i = num; i < text.Length; i++)
			{
				MotionHandle handle = LMotion.Punch.Create(Vector3.zero, direction, duration).WithEase(ease).WithDelay((float)(i - num) * num2)
					.BindToTMPCharPosition(field, i);
				motionSequenceBuilder.Append(handle);
			}
			_handle = motionSequenceBuilder.Run().AddTo(this);
		}
		field.text = text;
		Text = text;
	}

	private static int FindFirstCharacterDifference(string oldText, string newText)
	{
		int num = Mathf.Min(oldText.Length, newText.Length);
		for (int i = 0; i < num; i++)
		{
			if (oldText[i] != newText[i])
			{
				return i;
			}
		}
		return num;
	}
}
