using Rewired;
using UnityEngine;

public class VirtualKeyboardButtonOverride : MonoBehaviour
{
	public InteractablePreset.InteractionKey key;

	private ButtonController _buttonController;

	public bool performActionWithKey;

	private Rewired.Player _player;

	private string _originalText;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
