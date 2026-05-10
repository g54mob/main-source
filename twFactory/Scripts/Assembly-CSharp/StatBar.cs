using System;
using TMPro;
using UnityEngine;

public class StatBar : FillBar
{
	[SerializeField]
	private TextMeshProUGUI barValueText;

	[SerializeField]
	private EStats statMain;

	[SerializeField]
	private EStats statMax;

	[SerializeField]
	private bool destroyIfStatNotFound = true;

	[SerializeField]
	private bool hideOnStatReachsZero = true;

	protected StatsComponent statsComponent;

	public virtual StatsComponent StatsComponent
	{
		get
		{
			return statsComponent;
		}
		set
		{
			statsComponent = value;
			if ((bool)statsComponent)
			{
				StatsComponent.onStatChanged += OnStatChanged;
				if (StatsComponent.GetStat(statMax) > 0f)
				{
					bool flag = base.BApplySmooth;
					base.BApplySmooth = false;
					SetBarValue(StatsComponent.GetStat(statMain) / StatsComponent.GetStat(statMax));
					UpdateBarValueText(StatsComponent.GetStat(statMain), StatsComponent.GetStat(statMax));
					OnStatChanged(statMain, StatsComponent.GetStat(statMain), 0f);
					base.BApplySmooth = flag;
				}
			}
		}
	}

	public event Action<bool> onVisibilityChange;

	public event Action onMaxStatChanged;

	protected override void Start()
	{
		base.Start();
		if (destroyIfStatNotFound && StatsComponent.GetStat(statMax) == 0f)
		{
			base.gameObject.SetActive(value: false);
			this.onVisibilityChange?.Invoke(obj: false);
		}
	}

	private void OnDestroy()
	{
		if ((bool)StatsComponent)
		{
			StatsComponent.onStatChanged -= OnStatChanged;
		}
	}

	private void UpdateBarValueText(float mainValue, float maxValue)
	{
		if ((bool)barValueText)
		{
			barValueText.text = Mathf.CeilToInt(mainValue) + "/" + Mathf.CeilToInt(maxValue);
		}
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == statMain)
		{
			float stat2 = StatsComponent.GetStat(statMax);
			SetBarValue(newValue / stat2);
			UpdateBarValueText(newValue, stat2);
			if (hideOnStatReachsZero)
			{
				if (newValue <= 0f)
				{
					base.gameObject.SetActive(value: false);
					this.onVisibilityChange?.Invoke(obj: false);
				}
				else if (!base.gameObject.activeSelf)
				{
					base.gameObject.SetActive(value: true);
					this.onVisibilityChange?.Invoke(obj: true);
				}
			}
		}
		else if (stat == statMax)
		{
			this.onMaxStatChanged?.Invoke();
		}
	}
}
