using System.Collections;
using Aggro.Core;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ReceiptUI : EntityBehaviourBase
{
	public float receiptStartTime = 0.5f;

	public float receiptShowInfoTime = 1f;

	public float receiptOnScreenTime = 4f;

	public float receiptHideInfoTime = 1f;

	public float receiptHideScaleTime = 0.5f;

	public AnimationCurve receiptStartScaleCurve;

	public AnimationCurve receiptShowInfoCurve;

	public AnimationCurve receiptHideInfoCurve;

	public AnimationCurve receiptHideScaleCurve;

	public Color green;

	public Color red;

	public TextMeshProUGUI moneyMadeText;

	public TextMeshProUGUI basePayText;

	public TextMeshProUGUI timerPayText;

	public TextMeshProUGUI damagePayText;

	public TextMeshProUGUI boxCountText;

	public TextMeshProUGUI wildCardCountText;

	public TextMeshProUGUI damageCountText;

	public VerticalLayoutGroup receiptGroup;

	public float receiptSpacing = 30f;

	public float hideOffset = -100f;

	public GameObject container;

	public GameObject jokerUI;

	public GameObject brokenUI;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<ShiftManager.EvTruckShipped>(StartReceiptSequence);
		container.SetActive(value: false);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<ShiftManager.EvTruckShipped>(StartReceiptSequence);
	}

	private void StartReceiptSequence(ShiftManager.EvTruckShipped ev)
	{
		moneyMadeText.text = "+$" + ev.moneyMade;
		basePayText.text = "+$" + ev.basePay;
		if (ev.timerPay >= 0)
		{
			timerPayText.color = green;
			timerPayText.text = "+$" + ev.timerPay;
		}
		else
		{
			timerPayText.color = red;
			timerPayText.text = "-$" + math.abs(ev.timerPay);
		}
		damagePayText.text = "-$" + math.abs(ev.damagePay);
		boxCountText.text = ev.boxCount.ToString();
		wildCardCountText.text = ev.wildCardCount.ToString();
		damageCountText.text = ev.damageCount.ToString();
		jokerUI.SetActive(ev.wildCardCount > 0);
		brokenUI.SetActive(ev.damageCount > 0);
		StopAllCoroutines();
		StartCoroutine(ReceiptStartCo());
	}

	public void Test()
	{
		StopAllCoroutines();
		StartCoroutine(ReceiptStartCo());
	}

	private IEnumerator ReceiptStartCo()
	{
		receiptGroup.spacing = hideOffset;
		receiptGroup.padding.top = (int)hideOffset;
		container.SetActive(value: true);
		base.transform.localScale = Vector3.zero;
		float time = 0f;
		while (time < receiptStartTime)
		{
			base.transform.localScale = Vector3.one * receiptStartScaleCurve.Evaluate(time / receiptStartTime);
			time += Time.deltaTime;
			yield return null;
		}
		base.transform.localScale = Vector3.one;
		yield return ReceiptShowInfoCo();
	}

	private IEnumerator ReceiptShowInfoCo()
	{
		float time = 0f;
		receiptGroup.spacing = hideOffset;
		receiptGroup.padding.top = (int)hideOffset;
		while (time < receiptShowInfoTime)
		{
			receiptGroup.padding.top = (int)Mathf.Lerp(hideOffset, 0f, receiptShowInfoCurve.Evaluate(time / receiptShowInfoTime));
			receiptGroup.spacing = Mathf.Lerp(hideOffset, receiptSpacing, receiptShowInfoCurve.Evaluate(time / receiptShowInfoTime));
			time += Time.deltaTime;
			yield return null;
		}
		receiptGroup.spacing = receiptSpacing;
		receiptGroup.padding.top = 0;
		yield return new WaitForSeconds(receiptOnScreenTime);
		yield return ReceiptHideInfoCo();
	}

	private IEnumerator ReceiptHideInfoCo()
	{
		float time = 0f;
		receiptGroup.spacing = receiptSpacing;
		receiptGroup.padding.top = 0;
		while (time < receiptHideInfoTime)
		{
			receiptGroup.padding.top = (int)Mathf.Lerp(hideOffset, 0f, receiptHideInfoCurve.Evaluate(time / receiptHideInfoTime));
			receiptGroup.spacing = Mathf.Lerp(hideOffset, receiptSpacing, receiptHideInfoCurve.Evaluate(time / receiptHideInfoTime));
			time += Time.deltaTime;
			yield return null;
		}
		receiptGroup.spacing = hideOffset;
		receiptGroup.padding.top = (int)hideOffset;
		yield return ReceiptLeaveCo();
	}

	private IEnumerator ReceiptLeaveCo()
	{
		base.transform.localScale = Vector3.one;
		float time = 0f;
		while (time < receiptHideScaleTime)
		{
			base.transform.localScale = Vector3.one * receiptHideScaleCurve.Evaluate(time / receiptHideScaleTime);
			time += Time.deltaTime;
			yield return null;
		}
		container.SetActive(value: false);
		base.transform.localScale = Vector3.zero;
	}
}
