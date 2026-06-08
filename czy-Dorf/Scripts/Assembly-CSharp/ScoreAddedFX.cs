using DG.Tweening;
using Dorfromantik.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ScoreAddedFX : MonoBehaviour
{
	[FormerlySerializedAs("label")]
	[SerializeField]
	private TextMeshPro scoreLabel;

	[SerializeField]
	private float duration = 2f;

	[SerializeField]
	private float floatingHeight = 1f;

	[SerializeField]
	private AnimationCurve scaleCurve;

	[SerializeField]
	private AnimationCurve movementCurve;

	[SerializeField]
	private UnityEvent onSpawn;

	[SerializeField]
	private bool fadeOut;

	[SerializeField]
	private float fadeOutTime;

	[SerializeField]
	private UiScalingManager uiScalingManager;

	public void Appear(string text, float delay = 0f)
	{
		scoreLabel.text = text;
		TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(base.transform, Vector3.one * uiScalingManager.CurrentUiScalingLevel.scalingValue, duration), Vector3.zero), scaleCurve), delay);
		TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetEase(ShortcutExtensions.DOLocalMoveY(base.transform, base.transform.position.y + floatingHeight, duration), movementCurve), delay);
		if (fadeOut)
		{
			TweenSettingsExtensions.SetDelay(ShortcutExtensionsTMPText.DOFade(scoreLabel, 0f, duration - fadeOutTime), fadeOutTime + delay);
		}
		onSpawn?.Invoke();
		Object.Destroy(base.gameObject, duration + delay);
	}
}
