using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModuleIconLoading : MonoBehaviour
{
	[SerializeField]
	private RawImage _icon;

	[SerializeField]
	private TextMeshProUGUI _amtNeededText;

	[SerializeField]
	private Image _amtBar;

	[SerializeField]
	private Image _timerBar;

	[SerializeField]
	private float _totalBarLerpTime = 0.5f;

	private int _maxAmt;

	private float _targetAmountNeeded = 1f;

	private Coroutine _totalTargetAmountAnim;

	private void Awake()
	{
		_amtBar.fillAmount = 0f;
		_timerBar.fillAmount = 0f;
	}

	public void SetIcon(Texture2D icon)
	{
		_icon.texture = icon;
		_amtNeededText.SetText("1");
	}

	public void SetMaxAmt(int amt)
	{
		_maxAmt = amt;
	}

	public void SetTimer(float amt)
	{
		_timerBar.fillAmount = 1f - amt;
	}

	private IEnumerator LerpAmountNeededBarAnim()
	{
		float timer = 0f;
		float originalFill = _amtBar.fillAmount;
		while (_amtBar.fillAmount < _targetAmountNeeded)
		{
			timer += Time.deltaTime;
			_amtBar.fillAmount = Mathf.Lerp(originalFill, _targetAmountNeeded, timer / _totalBarLerpTime);
			yield return null;
		}
		_totalTargetAmountAnim = null;
	}

	public void SetAmtNeeded(int amt)
	{
		_amtNeededText.SetText(amt.ToString());
		if (_totalTargetAmountAnim != null)
		{
			StopCoroutine(_totalTargetAmountAnim);
			_totalTargetAmountAnim = null;
		}
		_targetAmountNeeded = 1f - (float)amt / (float)_maxAmt;
		StartCoroutine(LerpAmountNeededBarAnim());
		_amtNeededText.gameObject.SetActive(amt != 0);
	}

	public void ResetBar()
	{
		StopAllCoroutines();
		_amtBar.fillAmount = 0f;
	}
}
