using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SimpleFillBar : MonoBehaviour
{
	public Image FillImage;

	public bool AnimationDurationProportional;

	public float AnimationDuration;

	public Ease AnimationEase;

	public Tween CurrentTween;

	public void ResetLevelTo(float level)
	{
	}

	public void SetLevel(float level)
	{
	}

	private void OnDestroy()
	{
	}
}
