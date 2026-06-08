using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class ClosingQuestTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private QuestTile questTile;

	[SerializeField]
	private Transform flagVisual;

	[SerializeField]
	private AudioClipOptions hoverSound;

	private Tween wiggleTween;

	private void Awake()
	{
		questTile = GetComponentInParent<QuestTile>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		questTile.QuestWatcher.HighlightWatchTarget(newHighlight: true);
		Tween tween = wiggleTween;
		if (tween != null)
		{
			TweenExtensions.Kill(tween, complete: true);
		}
		wiggleTween = ShortcutExtensions.DOPunchRotation(flagVisual, Vector3.one * 2f, 0.75f, 8);
		AudioManager.Instance.PlaySoundAtPosition(hoverSound, base.transform.position);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		questTile.QuestWatcher.HighlightWatchTarget(newHighlight: false);
	}
}
