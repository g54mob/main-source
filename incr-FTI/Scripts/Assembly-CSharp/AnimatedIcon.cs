using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedIcon : MonoBehaviour
{
	public delegate void OnIconAnimationCompleted(AnimatedIcon icon);

	public Image imageIcon;

	public EntityId displayedEntity;

	public TextMeshProUGUI label;

	public OnIconAnimationCompleted onCompleted;

	private Vector3 start;

	private Vector3 mid;

	private Vector3 end;

	private float speed;

	private float progress;

	public int animatedIconIndex;

	[NonSerialized]
	public double animatedValue;

	private void Update()
	{
		progress += TimeManager.MenuDelta * speed;
		float num = 0.4f;
		float num2 = 0.6f;
		if (progress < num)
		{
			float lifetimePercentage = progress / num;
			base.transform.position = DOVirtual.EasedValue(start, mid, lifetimePercentage, Ease.OutQuint);
		}
		else if (!(progress <= num2))
		{
			float lifetimePercentage2 = (progress - num2) / (1f - num2);
			base.transform.position = DOVirtual.EasedValue(mid, end, lifetimePercentage2, Ease.InQuad);
		}
		if (progress >= 1f)
		{
			onCompleted?.Invoke(this);
			MenuManager.Instance.ReturnToAnimatedIconPool(this);
		}
	}

	public void Animate(Vector3 from, Vector3 to, float duration, double value, float angleProgress = 0f)
	{
		if (GameUtility.IsNearlyZero(duration))
		{
			duration = 1f;
		}
		speed = 1f / duration;
		progress = 0f;
		start = from;
		float num = 0.35f;
		float x = Mathf.Sin(MathF.PI * 2f * angleProgress) * num;
		float y = Mathf.Cos(MathF.PI * 2f * angleProgress) * num;
		mid = start + new Vector3(x, y, 0f);
		end = to;
		animatedValue = value;
		base.transform.position = start;
	}
}
