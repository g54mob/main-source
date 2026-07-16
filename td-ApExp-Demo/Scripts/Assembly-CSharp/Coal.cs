using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Coal : MonoBehaviour
{
	[SerializeField]
	private float top;

	[SerializeField]
	private float bottom;

	[SerializeField]
	private RectTransform missingFillRt;

	[SerializeField]
	private Image OverfillFire;

	[SerializeField]
	private Image coalImage;

	[SerializeField]
	private Sprite coalRegular;

	[SerializeField]
	private Sprite coalOverfill;

	[SerializeField]
	private GameObject overfillMarker;

	private RectTransform overfillRectTransform;

	[SerializeField]
	private float overfillTop;

	[SerializeField]
	private float overfillbottom;

	[SerializeField]
	private float overfillfireBottomPercent;

	[SerializeField]
	private float overfillfireTopPercent;

	[SerializeField]
	private RectTransform OverfillCoalBG;

	[SerializeField]
	private float coalFillOffset = -28.36666f;

	[SerializeField]
	private GameObject OverfillFlash;

	[SerializeField]
	private Animator OverdriveFlashAnim;

	[SerializeField]
	private GameObject OverdriveWarningStatic;

	private bool IsInOverfillUI;

	[SerializeField]
	private GameObject OverfillBorder;

	[SerializeField]
	private GameObject OverdriveBorder;

	private void Awake()
	{
		overfillRectTransform = overfillMarker.GetComponent<RectTransform>();
	}

	private void Update()
	{
		if (HUD.Instance.IsScrambled)
		{
			return;
		}
		float t = Train.Instance.CoalSeconds / Train.Instance.CoalSecondsCapacity;
		float y = Mathf.Lerp(bottom, top, t);
		missingFillRt.anchoredPosition = new Vector2(0f, y);
		float y2 = Mathf.Lerp(top, bottom, t) + coalFillOffset;
		OverfillCoalBG.anchoredPosition = new Vector2(0f, y2);
		if (Train.Instance.IsOverfillEnabled)
		{
			float overfillPercent = Train.Instance.GetOverfillPercent();
			OverfillFire.fillAmount = Mathf.Lerp(overfillfireBottomPercent, overfillfireTopPercent, overfillPercent);
			float y3 = Mathf.Lerp(overfillbottom, overfillTop, overfillPercent);
			overfillRectTransform.anchoredPosition = new Vector2(overfillRectTransform.anchoredPosition.x, y3);
			if (overfillPercent > 0.01f && !Train.Instance.IsInOverfill)
			{
				Train.Instance.furnace.chargingOverfill = true;
				overfillMarker.gameObject.SetActive(value: true);
				OverfillFlash.gameObject.SetActive(value: true);
				OverfillBorder.gameObject.SetActive(value: true);
			}
			else
			{
				Train.Instance.furnace.chargingOverfill = false;
				overfillMarker.gameObject.SetActive(value: false);
				OverfillFlash.gameObject.SetActive(value: false);
				OverfillBorder.gameObject.SetActive(value: false);
			}
		}
		if (Train.Instance.IsOverfillEnabled && Train.Instance.IsInOverfill && !IsInOverfillUI)
		{
			ChangeOverfillUIState(state: true);
		}
		else if ((!Train.Instance.IsOverfillEnabled || !Train.Instance.IsInOverfill) && IsInOverfillUI)
		{
			ChangeOverfillUIState(state: false);
		}
	}

	public void Scramble()
	{
		missingFillRt.anchoredPosition = new Vector2(0f, Random.Range(bottom, top));
		if (Train.Instance.IsOverfillEnabled)
		{
			OverfillCoalBG.anchoredPosition = new Vector2(0f, Random.Range(bottom, top));
			OverfillFire.fillAmount = Random.Range(overfillfireBottomPercent, overfillfireTopPercent);
			overfillRectTransform.anchoredPosition = new Vector2(overfillRectTransform.anchoredPosition.x, Random.Range(overfillbottom, overfillTop));
		}
	}

	private void ChangeOverfillUIState(bool state)
	{
		if (state)
		{
			coalImage.sprite = coalOverfill;
		}
		else
		{
			coalImage.sprite = coalRegular;
		}
		OverfillCoalBG.gameObject.SetActive(state);
		OverdriveWarningStatic.SetActive(state);
		OverdriveBorder.SetActive(state);
		StartCoroutine(OverdtiveWhiteFlash());
		IsInOverfillUI = state;
	}

	private IEnumerator OverdtiveWhiteFlash()
	{
		OverdriveFlashAnim.SetBool("playAnim", value: true);
		yield return new WaitForSeconds(0.2f);
		OverdriveFlashAnim.SetBool("playAnim", value: false);
	}
}
