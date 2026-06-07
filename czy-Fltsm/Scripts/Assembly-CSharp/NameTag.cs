using UnityEngine;
using UnityEngine.UI;

public class NameTag : WorldInteractable
{
	private Image _image;

	private Text _text;

	private Canvas _canvas;

	private ActorBehaviour _actor;

	protected override void Awake()
	{
		base.Awake();
		_image = GetComponent<Image>();
		_text = GetComponentInChildren<Text>();
		_canvas = GetComponent<Canvas>();
		_actor = GetComponentInParent<ActorBehaviour>();
	}

	private void Update()
	{
		ShowNameTag(FlotsamInputManager.RewiredPlayer.GetButton("Show Drifter Names"));
		if (_canvas.enabled)
		{
			FaceCamera();
			ScaleToCamera();
		}
	}

	private void UpdateName()
	{
		if (_actor != null && _text.text != _actor.Name)
		{
			_text.text = _actor.Name;
		}
	}

	private void ShowNameTag(bool show)
	{
		if (_canvas.enabled != show)
		{
			UpdateName();
			_canvas.enabled = show;
			_image.enabled = show;
			_text.enabled = show;
		}
	}
}
