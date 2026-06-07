using UnityEngine;
using UnityEngine.UI;

public class OzoneShieldPanel : SceneBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private Button _button;

	private OzoneShield _ozoneShield;

	public BuildablePanelElementId Id => BuildablePanelElementId.Radio;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryReturnBuildableExtendable<OzoneShield>(out _ozoneShield))
		{
			_button.interactable = _ozoneShield.IsInteractable();
			if (_button.interactable)
			{
				_button.onClick.AddListener(OnClick);
			}
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		_button.onClick.RemoveListener(OnClick);
		base.gameObject.SetActive(value: false);
	}

	private void OnClick()
	{
		_ozoneShield.Trigger();
	}
}
