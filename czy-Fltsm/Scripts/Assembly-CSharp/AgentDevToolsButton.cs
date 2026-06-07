using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AgentDevToolsButton : MonoBehaviour
{
	[SerializeField]
	private Button _button;

	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private Image _image;

	[SerializeField]
	private Tooltip _tooltip;

	private ActorProfile _actorProfile;

	private void Awake()
	{
		if (_button == null)
		{
			_button = GetComponent<Button>();
		}
	}

	private void OnDestroy()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	public void Initialize(AgentProfile agentProfile)
	{
		_actorProfile = agentProfile;
		if ((bool)_label)
		{
			_label.text = agentProfile.Name;
		}
		if ((bool)_image)
		{
			_image.overrideSprite = agentProfile.BearingIcon;
		}
		if ((bool)_tooltip)
		{
			_tooltip.LocalizedText = agentProfile.PastBackground.Name;
		}
		_button.onClick.RemoveAllListeners();
		_button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		_actorProfile.GetActorDiscriptor().Spawn(Community.PlayerCommunity, CameraController.Instance.ReturnFocusPoint());
	}
}
