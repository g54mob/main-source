using System.Collections;
using Aggro.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TipTapNotificationUI : EntityBehaviourBase
{
	public Transform container;

	public TextMeshProUGUI notificationTextMesh;

	public Image thumbailImage;

	public float lifeTime = 4f;

	public float spawnAnimationTime;

	public EasingFunction.Ease spawnEase;

	public float destroyAnimationTime;

	public EasingFunction.Ease DestroyEase;

	public float destroySlideAwayDistance = -500f;

	protected override void OnEntityCreated()
	{
		container.localScale = Vector3.zero;
		container.localPosition = Vector3.zero;
		StopAllCoroutines();
		StartCoroutine(SpawnCo());
		StartCoroutine(WaitForDestroyCo());
	}

	public void SetUp(TipTapNotificationManager.NotificationData notificationData)
	{
		string text = "<color=#" + ColorUtility.ToHtmlStringRGB(notificationData.playerColor) + ">" + notificationData.username + "</color> has sent you a TipTap!";
		notificationTextMesh.text = text;
		thumbailImage.sprite = notificationData.tipTapObject.thumbnail;
	}

	private IEnumerator SpawnCo()
	{
		container.localScale = Vector3.zero;
		float time = 0f;
		while (time < spawnAnimationTime)
		{
			float value = time / spawnAnimationTime;
			container.localScale = Vector3.one * EasingFunction.Evaluate(spawnEase, value);
			time += Time.deltaTime;
			yield return null;
		}
		container.localScale = Vector3.one;
	}

	private IEnumerator WaitForDestroyCo()
	{
		yield return new WaitForSeconds(lifeTime);
		StartCoroutine(DestroyCo());
	}

	private IEnumerator DestroyCo()
	{
		container.localPosition = Vector3.zero;
		float time = 0f;
		while (time < destroyAnimationTime)
		{
			float value = time / destroyAnimationTime;
			container.localPosition = new Vector3(EasingFunction.Evaluate(DestroyEase, value) * destroySlideAwayDistance, 0f, 0f);
			time += Time.deltaTime;
			yield return null;
		}
		if (base.entity.TryGetStruct<PoolableEntityReference>(out var comp))
		{
			comp.Release();
			StopAllCoroutines();
		}
	}
}
