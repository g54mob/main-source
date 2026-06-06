using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class OperationProgressBar : MonoBehaviour, ITooltip, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private LocalizedString idleTitle;

	[SerializeField]
	private LocalizedString idleDescription;

	[SerializeField]
	private LocalizeStringHandler labelHandler;

	[SerializeField]
	private SegmentedLoadingBar loadingBar;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private float idleAlpha = 0.7f;

	[SerializeField]
	private AudioDataType completionSfx;

	private bool _idle = true;

	private FloatVariable _timeVariable;

	private FloatVariable _durationVariable;

	[field: SerializeField]
	public Tooltip Tooltip { get; private set; }

	private void Awake()
	{
		_timeVariable = Tooltip.description["operation_time"] as FloatVariable;
		_durationVariable = Tooltip.description["operation_duration"] as FloatVariable;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		MonoSingleton<TooltipVisualizer>.Instance.Show(Tooltip.title, _idle ? idleDescription : Tooltip.description);
	}

	public void AssignProgress(OperationInstance instance)
	{
		SetOperationTitle(instance.Operation.Data().TitleLocalized);
		_timeVariable.Value = RoundValue(instance.Time);
		_durationVariable.Value = RoundValue(instance.Duration);
		_idle = false;
		canvasGroup.alpha = 1f;
	}

	public void UpdateProgress(OperationInstance instance)
	{
		_timeVariable.Value = RoundValue(instance.Time);
		loadingBar.SetNormalizedValue(instance.NormalizedTime);
	}

	public void ClearProgress()
	{
		SetOperationTitle(idleTitle);
		loadingBar.SetNormalizedValue(0f);
		_idle = true;
		Audio.PlaySfx(completionSfx);
		canvasGroup.alpha = idleAlpha;
	}

	private void SetOperationTitle(LocalizedString title)
	{
		labelHandler.SetLocalizedString(title);
		Tooltip.title["operation_title"] = title;
	}

	private float RoundValue(float value)
	{
		return Mathf.Round(value * 10f) / 10f;
	}
}
