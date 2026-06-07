using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class WarningBubble : SceneBehaviour
{
	[SerializeField]
	protected Transform _background;

	[SerializeField]
	protected Transform _counter;

	[SerializeField]
	protected TextMeshProUGUI _countText;

	protected ObjectOfInterestContainer _objectOfInterestContainer = new ObjectOfInterestContainer();

	protected HashSet<Transform> _lockedTransforms = new HashSet<Transform>();

	protected virtual void Start()
	{
		Subscribe();
		UpdateWarning();
	}

	private void OnDestroy()
	{
		Unsubscribe();
	}

	protected abstract void Subscribe();

	protected abstract void Unsubscribe();

	public void SelectObjectOfInterest()
	{
		_objectOfInterestContainer.SelectObjectOfInterest();
	}

	protected bool AddObjectOfInterest(INotificationObjectOfInterest objectOfInterest)
	{
		if (_objectOfInterestContainer.AddObjectOfInterest(objectOfInterest))
		{
			UpdateWarning();
			return true;
		}
		return false;
	}

	protected void RemoveObjectOfInterest(GameObject gameObject)
	{
		if (_objectOfInterestContainer == null)
		{
			Debug.LogWarning("Object of interest container is null!");
		}
		else if (_objectOfInterestContainer.RemoveObjectOfInterest(gameObject))
		{
			UpdateWarning();
		}
	}

	protected void RemoveObjectOfInterest(INotificationObjectOfInterest objectOfInterest)
	{
		if (_objectOfInterestContainer == null)
		{
			Debug.LogWarning("Object of interest container is null!");
		}
		else if (_objectOfInterestContainer.RemoveObjectOfInterest(objectOfInterest))
		{
			UpdateWarning();
		}
	}

	private void UpdateWarning()
	{
		if (_objectOfInterestContainer.ObjectsOfInterest.Count == 1)
		{
			base.gameObject.SetActive(value: true);
			_counter.gameObject.SetActive(value: false);
		}
		else if (_objectOfInterestContainer.ObjectsOfInterest.Count > 1)
		{
			base.gameObject.SetActive(value: true);
			_counter.gameObject.SetActive(value: true);
			_countText.text = _objectOfInterestContainer.ObjectsOfInterest.Count.ToString();
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	protected Coroutine StartAnimation(IEnumerator animation)
	{
		return StartCoroutine(animation);
	}

	protected void StopAnimation(Coroutine coroutine)
	{
		StopCoroutine(coroutine);
	}

	protected IEnumerator BounceOutTweenCoroutine(Transform animationTransform, float startScale = 1f, float endScale = 1.5f)
	{
		if (_lockedTransforms.Add(animationTransform))
		{
			animationTransform.localScale = Vector3.one * endScale;
			yield return Tweener.TweenRoutine(0.5f, EasingFunctions.BounceOut, true, new TransformScaleTweener(animationTransform, startScale));
			animationTransform.localScale = Vector3.one * startScale;
			_lockedTransforms.Remove(animationTransform);
		}
	}

	protected IEnumerator PulseTweenCoroutine(Transform animationTransform, float startScale = 1f, float endScale = 1.5f)
	{
		while (base.gameObject.activeInHierarchy)
		{
			yield return new WaitForSecondsRealtime(1f);
			yield return Tweener.TweenRoutine(0.25f, EasingFunctions.SineInOut, true, new TransformScaleTweener(animationTransform, endScale, is2D: true));
			yield return Tweener.TweenRoutine(0.25f, EasingFunctions.SineInOut, true, new TransformScaleTweener(animationTransform, startScale, is2D: true));
		}
		animationTransform.localScale = Vector3.one * startScale;
	}
}
