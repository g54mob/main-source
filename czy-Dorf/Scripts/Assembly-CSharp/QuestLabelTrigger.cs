using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class QuestLabelTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private QuestWatcher questWatcher;

	[SerializeField]
	private Wiggler wiggler;

	[SerializeField]
	private bool highlightQuestGroups = true;

	[SerializeField]
	private AudioClipOptions hoverSound;

	private void Start()
	{
		questWatcher = GetComponentInParent<QuestWatcher>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (highlightQuestGroups)
		{
			if (!questWatcher)
			{
				Debug.LogError($"{base.name} has no QuestWatcher {questWatcher} " + $"| {GetComponentInParent<QuestGiver>()} | {GetComponentInParent<QuestTile>()}", questWatcher);
			}
			else
			{
				questWatcher.HighlightWatchTarget(newHighlight: true);
			}
		}
		wiggler.Wiggle(1f, 1.5f);
		AudioManager.Instance.PlaySoundAtPosition(hoverSound, base.transform.position);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (highlightQuestGroups)
		{
			questWatcher.HighlightWatchTarget(newHighlight: false);
		}
		wiggler.Wiggle(-0.5f, 1.5f, killWiggle: false);
	}
}
