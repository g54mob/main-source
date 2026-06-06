using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

public class TooltipButtonTooltip : MonoBehaviour
{
	[SerializeField]
	private Canvas _root;

	[SerializeField]
	private TextMeshProUGUI _messageText;

	[SerializeField]
	private ChildBehaviourCache<IconWithLabel> _bullitPrefab;

	[SerializeField]
	private float _offsetY = 12f;

	[SerializeField]
	[Tooltip("Since the a tooltip cannor be 'closed' by moving the cursor we set a maximum duration for the tooltip.")]
	private float _joystickMaximumDuration = 5f;

	private object _owner;

	private float _duration = -1f;

	private void Awake()
	{
		if (_root == null)
		{
			_root = GetComponentInParent<Canvas>();
		}
	}

	private void LateUpdate()
	{
		if (0f < _duration)
		{
			_duration -= Time.deltaTime;
			if (_duration <= 0f || FlotsamInputManager.GetUICancel())
			{
				Close(_owner);
			}
		}
	}

	public void Display(string message, object owner, Vector2 position)
	{
		if ((bool)_root)
		{
			_messageText.text = message;
			_messageText.gameObject.SetActive(value: true);
			_bullitPrefab.Reset();
			_bullitPrefab.Trim();
			Display(owner, position);
		}
		else
		{
			TooltipPanel.DisplayErrorTooltip(owner, position, message);
		}
	}

	public void Display(List<LocalizedString> errors, object owner, Vector2 position)
	{
		if (_root == null)
		{
			throw new NotSupportedException("This method should never be called from a prefab!");
		}
		_messageText.gameObject.SetActive(value: false);
		_bullitPrefab.Reset();
		foreach (LocalizedString error in errors)
		{
			_bullitPrefab.Get(active: true).Initialize(null, error);
		}
		_bullitPrefab.Trim();
		Display(owner, position);
	}

	private void Display(object owner, Vector2 position)
	{
		_owner = owner;
		_duration = (FlotsamInputManager.HasActiveInput(InputFlags.Joystick) ? _joystickMaximumDuration : 0f);
		position.y += _offsetY * _root.scaleFactor;
		base.transform.SetParent(_root.transform, worldPositionStays: false);
		base.transform.position = position;
		base.gameObject.SetActive(value: true);
		StopAllCoroutines();
		StartCoroutine(DisplayCoroutine());
	}

	private IEnumerator DisplayCoroutine()
	{
		base.transform.localScale = Vector3.zero;
		yield return Tweener.TweenRoutine(0.5f, EasingFunctions.ElasticOut, true, new TransformScaleTweener(base.transform, 1f));
	}

	public void Close(object owner)
	{
		if (_root == null)
		{
			TooltipPanel.CloseErrorTooltip(owner);
		}
		else if (base.gameObject.activeSelf && _owner == owner)
		{
			StopAllCoroutines();
			StartCoroutine(CloseCoroutine());
			_owner = null;
			_duration = 0f;
		}
	}

	private IEnumerator CloseCoroutine()
	{
		yield return Tweener.TweenRoutine(0.15f, EasingFunctions.SineIn, true, new TransformScaleTweener(base.transform, 0f));
		base.gameObject.SetActive(value: false);
	}
}
