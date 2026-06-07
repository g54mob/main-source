using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_ScrapTankEnhanceHint : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Image image_Background;

	[SerializeField]
	private Image image_WhiteArrow;

	[SerializeField]
	private Image image_Bar;

	[SerializeField]
	private Image image_Bar_AfterEnhance;

	[SerializeField]
	private Color color_FullBar;

	[SerializeField]
	private TMP_Text text_UpgradeEffect;

	[SerializeField]
	private TMP_Text text_UpgradeLimit;

	private Transform trackTarget;

	private Vector3 offset;

	private Tower_ScrapTank tower_ScrapTank;

	private bool isAnimatorOn;

	public bool IsAnimatorOn => false;

	public static UI_Obj_ScrapTankEnhanceHint Create(Transform trackTarget, Vector3 offset, Tower_ScrapTank tower_ScrapTank)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	private void Setup(Tower_ScrapTank tower_ScrapTank)
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	internal void SetTrackingTarget(Transform target, Vector3 offset)
	{
	}

	private void OnScrapTankUpgraded()
	{
	}

	private void ForceUpdateContent()
	{
	}

	public void SetContent(int curValue, int maxValue, int enhanceValue, string upgradeEffectText, eDamageType targetDamageType)
	{
	}

	public void Toggle(bool isOn)
	{
	}
}
