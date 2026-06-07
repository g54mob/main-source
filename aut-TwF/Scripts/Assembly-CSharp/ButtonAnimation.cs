using System.Collections;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
{
	[Header("Sound")]
	[SerializeField]
	private AudioClip onOverSound;

	[SerializeField]
	private AudioClip onClickSound;

	[SerializeField]
	private float overSoundPitchVariation = 0.1f;

	[Header("Animation")]
	[SerializeField]
	private float baseScale = 1f;

	[SerializeField]
	private float onOverScale = 1.1f;

	[SerializeField]
	private float onClickScale = 1.2f;

	[SerializeField]
	private float onOverScaleTime = 0.05f;

	[SerializeField]
	private float onClickScaleTime = 0.05f;

	[SerializeField]
	private GameObject overrideTargetGraphic;

	[Header("Other")]
	[SerializeField]
	[Tooltip("Objects to activate on over")]
	private GameObject[] onOverObjects;

	private bool keepOnOverObjectsActive;

	private GameObject targetGraphic;

	private Coroutine currentCoroutine;

	private GameObject TargetGraphic
	{
		get
		{
			if (!targetGraphic)
			{
				targetGraphic = (overrideTargetGraphic ? overrideTargetGraphic : base.gameObject);
			}
			return targetGraphic;
		}
		set
		{
			targetGraphic = value;
		}
	}

	public AudioClip OnClickSound
	{
		get
		{
			return onClickSound;
		}
		set
		{
			onClickSound = value;
		}
	}

	private void OnDisable()
	{
		this.StopCoroutineCheckingVar(ref currentCoroutine);
		ActivateOnOverObjects(active: false);
		TargetGraphic.transform.localScale = Vector3.one;
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
		SubmitAnimation();
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		EventSystem.current.SetSelectedGameObject(base.gameObject);
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
		if (EventSystem.current?.currentSelectedGameObject == base.gameObject)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public virtual void OnSelect(BaseEventData eventData)
	{
		SelectAnimation();
	}

	public virtual void OnDeselect(BaseEventData eventData)
	{
		DeselectAnimation();
	}

	public virtual void OnSubmit(BaseEventData eventData)
	{
		SubmitAnimation();
	}

	private void SelectAnimation()
	{
		if (Application.isFocused)
		{
			if ((bool)onOverSound)
			{
				AudioSystem.Instance.PlaySound2D(onOverSound, AudioSystem.EAudioMixerGroup.UI, 0.65f, Random.Range(1f - overSoundPitchVariation, 1f + overSoundPitchVariation));
			}
			ActivateOnOverObjects(active: true);
			this.StartCoroutineCheckingVar(ChangeScaleCoroutine(baseScale, onOverScale), ref currentCoroutine, stopCoroutineIfRunning: true);
		}
	}

	private void DeselectAnimation()
	{
		if (Application.isFocused)
		{
			ActivateOnOverObjects(active: false);
			this.StartCoroutineCheckingVar(ChangeScaleCoroutine(onOverScale, baseScale), ref currentCoroutine, stopCoroutineIfRunning: true);
		}
	}

	private void SubmitAnimation()
	{
		if ((bool)OnClickSound)
		{
			AudioSystem.Instance.PlaySound2D(OnClickSound, AudioSystem.EAudioMixerGroup.UI, 0.6f);
		}
		if (base.gameObject.activeInHierarchy)
		{
			this.StartCoroutineCheckingVar(OnClickCoroutine(), ref currentCoroutine, stopCoroutineIfRunning: true);
		}
	}

	private void ActivateOnOverObjects(bool active)
	{
		if (onOverObjects != null)
		{
			onOverObjects.ForEach(delegate(GameObject x)
			{
				x.SetActive(keepOnOverObjectsActive || active);
			});
		}
	}

	public void MarkSelected(bool active)
	{
		keepOnOverObjectsActive = active;
		ActivateOnOverObjects(active);
	}

	private IEnumerator ChangeScaleCoroutine(float startScale, float targetScale)
	{
		float time = 0f;
		while (time <= onOverScaleTime)
		{
			time += Time.unscaledDeltaTime;
			float num = Mathf.Lerp(startScale, targetScale, time / onOverScaleTime);
			TargetGraphic.transform.localScale = Vector3.one * num;
			yield return null;
		}
		currentCoroutine = null;
	}

	private IEnumerator OnClickCoroutine()
	{
		float time = 0f;
		_ = onOverScale;
		while (time <= onClickScaleTime * 0.5f)
		{
			time += Time.unscaledDeltaTime;
			float num = Mathf.Lerp(onOverScale, onClickScale, time / (onClickScaleTime * 0.5f));
			TargetGraphic.transform.localScale = Vector3.one * num;
			yield return null;
		}
		time = 0f;
		while (time <= onClickScaleTime * 0.5f)
		{
			time += Time.unscaledDeltaTime;
			float num = Mathf.Lerp(onClickScale, onOverScale, time / (onClickScaleTime * 0.5f));
			TargetGraphic.transform.localScale = Vector3.one * num;
			yield return null;
		}
		currentCoroutine = null;
	}
}
