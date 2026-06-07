using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
	[SerializeField]
	protected Image barImage;

	[SerializeField]
	[Tooltip("Pixeles de la fillbar por cada unidad (poner a 0 si no se quiere que se actualice)")]
	private float lifeBarSizePerUnit;

	[SerializeField]
	private float barUpdateSmooth = 0.2f;

	private bool bApplySmooth = true;

	private float value = 1f;

	private float maxValue = 1f;

	private Coroutine updateBarValueCoroutine_var;

	public bool BApplySmooth
	{
		get
		{
			return bApplySmooth;
		}
		set
		{
			bApplySmooth = value;
		}
	}

	protected float LifeBarSizePerUnit
	{
		get
		{
			return lifeBarSizePerUnit;
		}
		set
		{
			lifeBarSizePerUnit = value;
			UpdateBarSize();
		}
	}

	public float Value
	{
		get
		{
			return value;
		}
		private set
		{
			this.value = value;
		}
	}

	public float MaxValue
	{
		get
		{
			return maxValue;
		}
		private set
		{
			maxValue = value;
		}
	}

	public event Action<float, float> onValueChanged;

	protected virtual void Start()
	{
		UpdateBarValue();
	}

	protected virtual void OnDisable()
	{
		this.StopCoroutineCheckingVar(ref updateBarValueCoroutine_var);
	}

	public virtual void SetBarValue(float value)
	{
		float arg = Value;
		if (value > MaxValue)
		{
			Value = MaxValue;
		}
		else if (value < 0f)
		{
			Value = 0f;
		}
		else
		{
			Value = value;
		}
		UpdateBarValue();
		this.onValueChanged?.Invoke(Value, arg);
	}

	public void SetBarMaxValue(float value)
	{
		if (value < 0f)
		{
			MaxValue = 0f;
		}
		else
		{
			MaxValue = value;
		}
		UpdateBarValue();
		UpdateBarSize();
	}

	public void SetBarColor(Color color)
	{
		barImage.color = color;
	}

	private void UpdateBarValue()
	{
		if (BApplySmooth && base.gameObject.activeInHierarchy)
		{
			this.StartCoroutineCheckingVar(UpdateBarValueCoroutine(), ref updateBarValueCoroutine_var, stopCoroutineIfRunning: true);
			return;
		}
		float fillAmount = Value / MaxValue;
		barImage.fillAmount = fillAmount;
	}

	private IEnumerator UpdateBarValueCoroutine()
	{
		float percentage = Value / MaxValue;
		while (!Mathf.Approximately(barImage.fillAmount, percentage))
		{
			percentage = Value / MaxValue;
			barImage.fillAmount = Mathf.Lerp(barImage.fillAmount, percentage, 1f - barUpdateSmooth);
			yield return null;
		}
		updateBarValueCoroutine_var = null;
	}

	private void UpdateBarSize()
	{
		if (LifeBarSizePerUnit > 0f)
		{
			RectTransform component = GetComponent<RectTransform>();
			Vector2 sizeDelta = new Vector2(MaxValue * LifeBarSizePerUnit, component.sizeDelta.y);
			GetComponent<RectTransform>().sizeDelta = sizeDelta;
		}
	}
}
