using UnityEngine;
using UnityEngine.UI;

public class ProgressButton : LabelButton
{
	public Slider slider;

	public Image progressFill;

	private float animationTimer;

	private float lerpStart;

	private float lerpEnd;

	private float currentLerpValue;

	private float lastUnitProgress;

	private bool hasInitializedLerp;

	public StateManager stateManager;

	public bool debug;

	public void UpdateDynamicDisplay()
	{
		if (stateManager is ConstructionState constructionState)
		{
			slider.value = constructionState.DisplayedDynamicProgress();
		}
		else
		{
			lerpStart = GameUtility.AsFloat(stateManager.cumulativeUnitProgressPrev);
			lerpEnd = GameUtility.AsFloat(stateManager.cumulativeUnitProgress);
			float progressToNextFixedUpdate = TimeManager.ProgressToNextFixedUpdate;
			currentLerpValue = Mathf.Lerp(lerpStart, lerpEnd, progressToNextFixedUpdate);
			if (stateManager is ConstructionState && stateManager.activePauseState)
			{
				slider.value = currentLerpValue;
			}
			else if (stateManager.numWorkersAssigned <= 0f || stateManager.activePauseState)
			{
				slider.value = 0f;
			}
			else if (stateManager.outputCapacityState == AffordabilityState.CanPartiallyProduce || stateManager.rateCapacityState == AffordabilityState.CanPartiallyProduce)
			{
				slider.value = 1f;
			}
			else if (stateManager.cumulativeUnitProgress > 1.0 && TimeManager.ProgressToNextFixedUpdate >= 1f && TimeManager.targetSpeedMultiplier >= 5)
			{
				slider.value = 1f;
			}
			else
			{
				_ = lerpEnd - lerpStart;
				_ = 1.4f;
				slider.value = currentLerpValue % 1f;
			}
		}
		animationTimer += TimeManager.MenuDelta;
		if (animationTimer > 1f)
		{
			animationTimer = 1f;
		}
	}
}
