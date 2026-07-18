using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UI_ButtonPolishController : MonoBehaviour
{
	private void OnEnable()
	{
		base.transform.rotation = Quaternion.identity;
	}

	public void OnHover()
	{
		StartCoroutine(HoverEffect());
		UI_SoundManager.Instance.PlayHoverSound(hover: true);
	}

	public void OnLeaveHover()
	{
		base.transform.DORotate(new Vector3(0f, 0f, 0f), 0.5f).SetEase(Ease.OutBounce);
		UI_SoundManager.Instance.PlayHoverSound(hover: false);
	}

	private IEnumerator HoverEffect()
	{
		base.transform.DORotate(new Vector3(0f, 0f, 15f), 0.5f).SetEase(Ease.OutBounce);
		yield return new WaitForSeconds(0.5f);
	}
}
