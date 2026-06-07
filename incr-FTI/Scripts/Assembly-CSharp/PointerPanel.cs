using System;
using DG.Tweening;
using UnityEngine;

public class PointerPanel : MonoBehaviour
{
	public RectTransform rootRectTransform;

	[NonSerialized]
	public RectTransform targetRectTransform;

	public RectTransform imageRect;

	public float animationProgress;

	private void Update()
	{
		UpdatePosition();
		animationProgress += TimeManager.MenuDelta;
		float lifetimePercentage = Mathf.Sin(animationProgress * 4f) * 0.5f + 1f;
		imageRect.rotation = Quaternion.Euler(0f, 0f, DOVirtual.EasedValue(0f, 5f, lifetimePercentage, Ease.InQuint));
	}

	public void AttachToTarget(RectTransform rt)
	{
		base.gameObject.SetActive(value: true);
		targetRectTransform = rt;
		UpdatePosition();
	}

	public void UpdatePosition()
	{
		if (null == targetRectTransform || !targetRectTransform.gameObject.activeInHierarchy)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		Rect screenSpaceRect = MenuManager.Instance.GetScreenSpaceRect(targetRectTransform);
		Vector3 position = new Vector3(screenSpaceRect.x + screenSpaceRect.width, screenSpaceRect.y + screenSpaceRect.height * 0.5f, 0f);
		Vector3 position2 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position);
		position2.z = rootRectTransform.position.z;
		rootRectTransform.position = position2;
	}
}
