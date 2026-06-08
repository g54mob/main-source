using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TileStackCounter : MonoBehaviour
{
	[SerializeField]
	private Vector3 countReducedScalePunch = Vector3.one * -0.1f;

	[SerializeField]
	private float countReducedPunchDuration = 0.4f;

	[SerializeField]
	private int countReducedPunchVibrato = 9;

	[SerializeField]
	private Vector3 countAddedTargetScale = Vector3.one;

	[SerializeField]
	private float countAddedGrowDuration = 0.1f;

	[SerializeField]
	private float countAddedShrinkDuration = 0.2f;

	[SerializeField]
	private float addedFxInterval = 0.2f;

	[SerializeField]
	private Vector3 addedFxSpawnOffset = new Vector3(0f, 0.5f, 0f);

	[SerializeField]
	private Color normalBackgroundColor = Color.white;

	[SerializeField]
	private Color emergencyBackgroundColor;

	[SerializeField]
	private Color normalTextColor;

	[SerializeField]
	private Color emergencyTextColor;

	[SerializeField]
	private int emergencyStackHeight = 9;

	[SerializeField]
	private float emergencyTransitionDuration;

	[SerializeField]
	private TileStack stack;

	[SerializeField]
	private TextMeshPro label;

	[SerializeField]
	private SpriteRenderer backgroundSolid;

	[SerializeField]
	private SpriteRenderer backgroundOutline;

	[SerializeField]
	private ScoreAddedFX tileAddedFxPrefab;

	private List<int> pendingAddedCounts = new List<int>();

	private float lastSpawnedFxTime = -500f;

	private Vector3 originalScale;

	private bool currentEmergencyState;

	private Sequence scaleTween;

	private void Awake()
	{
		originalScale = base.transform.localScale;
		stack.OnInitialized += Initialize;
	}

	private void Initialize()
	{
		UpdateLabel();
		stack.OnAdvanced += ReduceCount;
		stack.OnSingleTileAdded += TileGainedAnimation;
		stack.OnTilesAdded += SpawnTileAddedFx;
	}

	private void SpawnTileAddedFx(int addedTiles)
	{
		pendingAddedCounts.Add(addedTiles);
	}

	private void ReduceCount()
	{
		Sequence sequence = scaleTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence, complete: true);
		}
		scaleTween = DOTween.Sequence();
		TweenSettingsExtensions.Append(scaleTween, ShortcutExtensions.DOPunchScale(base.transform, countReducedScalePunch, countReducedPunchDuration, countReducedPunchVibrato));
		UpdateLabel();
	}

	private void TileGainedAnimation()
	{
		Sequence sequence = scaleTween;
		if (sequence != null)
		{
			TweenExtensions.Kill(sequence, complete: true);
		}
		scaleTween = DOTween.Sequence();
		TweenSettingsExtensions.Append(scaleTween, ShortcutExtensions.DOScale(base.transform, countAddedTargetScale, countAddedGrowDuration));
		TweenSettingsExtensions.Append(scaleTween, ShortcutExtensions.DOScale(base.transform, originalScale, countAddedShrinkDuration));
		UpdateLabel();
	}

	private void Update()
	{
		if (pendingAddedCounts.Count > 0 && Time.time - lastSpawnedFxTime > addedFxInterval)
		{
			lastSpawnedFxTime = Time.time;
			Object.Instantiate(tileAddedFxPrefab, base.transform.position + addedFxSpawnOffset, Quaternion.identity, null).Appear("+" + pendingAddedCounts[0]);
			pendingAddedCounts.RemoveAt(0);
		}
	}

	private void UpdateLabel()
	{
		if (stack.IsInfinite)
		{
			label.enableAutoSizing = false;
			label.fontSize = 4f;
			label.text = "∞";
		}
		else
		{
			label.text = stack.Height.ToString();
			SetEmergencyState(stack.Height <= emergencyStackHeight);
		}
	}

	private void SetEmergencyState(bool newEmergencyState)
	{
		if (currentEmergencyState != newEmergencyState)
		{
			currentEmergencyState = newEmergencyState;
			DOTweenModuleSprite.DOColor(backgroundSolid, currentEmergencyState ? emergencyBackgroundColor : normalBackgroundColor, emergencyTransitionDuration);
			ShortcutExtensionsTMPText.DOColor(label, currentEmergencyState ? emergencyTextColor : normalTextColor, emergencyTransitionDuration);
			DOTweenModuleSprite.DOFade(backgroundOutline, currentEmergencyState ? 1 : 0, emergencyTransitionDuration);
		}
	}
}
