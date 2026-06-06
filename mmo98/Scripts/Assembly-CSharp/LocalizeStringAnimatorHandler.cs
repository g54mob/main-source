using Febucci.TextAnimatorForUnity.TextMeshPro;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text), typeof(TextAnimator_TMP))]
public class LocalizeStringAnimatorHandler : LocalizeStringHandler
{
	private TextAnimator_TMP _animator;

	public TextAnimator_TMP Animator => _animator;

	protected override void Awake()
	{
		base.Awake();
		_animator = GetComponent<TextAnimator_TMP>();
	}

	protected override void ApplyProperty(string value)
	{
		_animator.SetText(value);
	}
}
