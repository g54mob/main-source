using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractableCat : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Transform heartTemplate;

	[SerializeField]
	private float heartMoveOffsetY;

	[SerializeField]
	private float heartMoveDuration;

	[SerializeField]
	private Ease easing;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private bool isDog;

	private const string IS_INTERACTED = "IsInteracted";

	public event EventHandler OnCatInteracted;

	public event EventHandler OnDogInteracted;

	private void Awake()
	{
		heartTemplate.gameObject.SetActive(value: false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!isDog)
		{
			this.OnCatInteracted?.Invoke(this, EventArgs.Empty);
		}
		else
		{
			this.OnDogInteracted?.Invoke(this, EventArgs.Empty);
		}
		animator.SetTrigger("IsInteracted");
		Transform heart = UnityEngine.Object.Instantiate(heartTemplate, heartTemplate.parent);
		heart.gameObject.SetActive(value: true);
		StartCoroutine(Fade(heart));
		heart.DOMoveY(heart.position.y + heartMoveOffsetY, heartMoveDuration).SetEase(easing).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(heart.gameObject, heartMoveDuration + 1f);
		});
	}

	private IEnumerator Fade(Transform transform)
	{
		yield return new WaitForSeconds(heartMoveDuration / 2f);
		transform.GetComponent<CanvasGroup>().DOFade(0f, heartMoveDuration / 2f);
	}
}
