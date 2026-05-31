using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class StorePointSlider : MonoBehaviour
{
	private const float m_FillSpeed = 1f;

	[SerializeField]
	private Slider m_StorePointSlider;

	[SerializeField]
	private LocalizeStringEvent m_StoreLevelText;

	[SerializeField]
	private InGameTextIndicator m_StorePointIndicator;

	[SerializeField]
	private Transform m_IndicatorPosition;

	private StoreLevelManager m_StoreLevelManager;

	private bool m_ChangingBarForNewLevel;

	private bool m_FillingBar;

	private Tween m_FillingTween;

	private void Start()
	{
	}

	private void LoadStoreLevelInfo()
	{
	}

	private void StorePointChanged(int amount, bool increased)
	{
	}

	private void StoreLevelChanged(bool levelUp)
	{
	}

	private void UpdateLevel()
	{
	}

	private void UpdateBar()
	{
	}

	private float GetDuration()
	{
		return 0f;
	}
}
