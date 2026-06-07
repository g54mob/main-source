using System;
using UnityEngine;

public class SecretPageObject : MonoBehaviour
{
	public SecretPageData data;

	private Sprite sprite;

	private Action OnStateChange;

	private bool isInteractible;

	private void Start()
	{
		sprite = data.localizedSprite.LoadAsset();
	}

	private void OnEnable()
	{
		OnStateChange = (Action)Delegate.Combine(OnStateChange, new Action(CanInteract));
		OnStateChange = (Action)Delegate.Combine(OnStateChange, new Action(CanNotInteract));
	}

	private void OnDisable()
	{
		OnStateChange = (Action)Delegate.Remove(OnStateChange, new Action(CanInteract));
		OnStateChange = (Action)Delegate.Remove(OnStateChange, new Action(CanNotInteract));
	}

	public void SetIsInteractible(bool state)
	{
		isInteractible = state;
		OnStateChange?.Invoke();
	}

	private void CanInteract()
	{
		if (isInteractible)
		{
			SecretPageDisplayManager.Instance.StartDisplaySecretPage(sprite);
		}
	}

	private void CanNotInteract()
	{
		if (!isInteractible)
		{
			SecretPageDisplayManager.Instance.StopDisplaySecretPage();
		}
	}
}
