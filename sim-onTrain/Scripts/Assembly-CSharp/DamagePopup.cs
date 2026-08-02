using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
	[SerializeField]
	private TMP_Text damageText;

	[Header("Animation")]
	[SerializeField]
	private float floatDistance = 1.2f;

	[SerializeField]
	private float duration = 0.9f;

	[SerializeField]
	private float fadeDelay = 0.35f;

	[SerializeField]
	private float screenSizeMultiplier = 0.025f;

	[SerializeField]
	private Vector3 spawnOffset = new Vector3(0.3f, 0.5f, 0f);

	[Header("Colors")]
	[SerializeField]
	private Color normalColor = Color.white;

	[SerializeField]
	private Color headshotColor = Color.yellow;

	[SerializeField]
	private float normalFontSize = 4f;

	[SerializeField]
	private float headshotFontSize = 6f;

	private Camera _cam;

	public void Play(float damage, bool isHeadshot = false)
	{
		_cam = Camera.main;
		if (_cam != null)
		{
			Vector3 right = _cam.transform.right;
			Vector3 up = _cam.transform.up;
			base.transform.position += right * spawnOffset.x + up * spawnOffset.y + _cam.transform.forward * spawnOffset.z;
		}
		damageText.text = Mathf.RoundToInt(damage).ToString();
		damageText.color = (isHeadshot ? headshotColor : normalColor);
		damageText.fontSize = (isHeadshot ? headshotFontSize : normalFontSize);
		damageText.alpha = 1f;
		Vector3 vector = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
		Vector3 endValue = base.transform.position + Vector3.up * floatDistance + vector;
		if (isHeadshot)
		{
			base.transform.DOPunchScale(Vector3.one * 0.4f, 0.25f, 5, 0.5f);
		}
		base.transform.DOMove(endValue, duration).SetEase(Ease.OutCubic);
		DOTween.To(() => damageText.alpha, delegate(float x)
		{
			damageText.alpha = x;
		}, 0f, duration - fadeDelay).SetDelay(fadeDelay).OnComplete(delegate
		{
			Object.Destroy(base.gameObject);
		});
	}

	private void LateUpdate()
	{
		if (_cam != null)
		{
			base.transform.forward = _cam.transform.forward;
			float num = Vector3.Distance(_cam.transform.position, base.transform.position) * screenSizeMultiplier;
			base.transform.localScale = Vector3.one * num;
		}
	}
}
