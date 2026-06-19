using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TextInputCopyOption : RadicalMenuOption
{
	public RadicalMenuOptionTextInput textInputField;

	public UnityEvent onSelectedEvent;

	public UnityEvent onDeselectedEvent;

	public GameObject selectedMarker;

	public SpriteRenderer background;

	public SpriteRenderer icon;

	public SpriteRenderer checkmarkIcon;

	public float checkmarkDuration = 1f;

	private Coroutine checkmarkCoroutine;

	protected override void Awake()
	{
		base.Awake();
		selectedMarker.SetActive(value: false);
		checkmarkIcon.enabled = false;
	}

	private void OnEnable()
	{
		icon.enabled = true;
		checkmarkIcon.enabled = false;
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
		onSelectedEvent?.Invoke();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
		onDeselectedEvent?.Invoke();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		GUIUtility.systemCopyBuffer = textInputField.GetInputText();
		if (checkmarkCoroutine != null)
		{
			StopCoroutine(checkmarkCoroutine);
		}
		checkmarkCoroutine = StartCoroutine(ShowCheckmark());
	}

	private IEnumerator ShowCheckmark()
	{
		icon.enabled = false;
		checkmarkIcon.enabled = true;
		yield return new WaitForSeconds(checkmarkDuration);
		checkmarkIcon.enabled = false;
		icon.enabled = true;
		checkmarkCoroutine = null;
	}
}
