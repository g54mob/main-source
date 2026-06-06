using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;

public class RescueableDrifterInfo : UIBehaviour, IPointerDownHandler, IEventSystemHandler, ILocalizationGenderProvider, ILocalizationParamsManager
{
	[SerializeField]
	private OutlinedImage _portraitImage;

	[SerializeField]
	private DrifterAttributesEffectIcon _pastBackground;

	[SerializeField]
	private DrifterAttributesEffectIcon _presentBackground;

	private AgentDescriptor _agentDescriptor;

	Agent.EGender ILocalizationGenderProvider.LocalizationGender => _agentDescriptor.Gender;

	public void Initialize(AgentDescriptor agentDescriptor)
	{
		_agentDescriptor = agentDescriptor;
		_portraitImage.Initialize(PortraitGenerator.ReturnStaticPortrait(agentDescriptor));
		LocalizationManager.ParamManagers.AddUnique(this);
		_pastBackground.Initialize(agentDescriptor.PastBackground);
		_presentBackground.Initialize(agentDescriptor.PresentBackground);
		LocalizationManager.ParamManagers.Remove(this);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			Select();
		}
	}

	public void Select()
	{
		if ((bool)_agentDescriptor.Agent)
		{
			CameraController.Instance.Lock(_agentDescriptor.Agent.gameObject);
			GameManager.UIManager.DisplayPanel(_agentDescriptor.Agent);
		}
	}
}
