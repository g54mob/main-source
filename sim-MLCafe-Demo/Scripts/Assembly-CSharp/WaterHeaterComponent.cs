using System;
using MLCN_Localization;
using UnityEngine;

public class WaterHeaterComponent : MonoBehaviour
{
	[SerializeField]
	private AnomalyTag applyTag;

	[SerializeField]
	private float duration;

	[SerializeField]
	private ItemSocket socket;

	[SerializeField]
	private Vector2 colliderPositionOffOn;

	[SerializeField]
	private Vector2 colliderHeightOffOn;

	[Header("Sound")]
	[SerializeField]
	private string soundStartHeater;

	[SerializeField]
	private string soundHeaterFinished;

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyInvalidIsHeatingUp;

	[SerializeField]
	private string localizationKeyInvalidUse;

	[SerializeField]
	private string localizationKeyInvalidIsEmpty;

	[SerializeField]
	private string localizationKeyINvalidHoldingItem;

	private bool isHeatingUp;

	private BoxCollider collider;

	private void Start()
	{
		collider = GetComponent<BoxCollider>();
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		if (socket.IsHoldingItem())
		{
			if (isHeatingUp)
			{
				string localizedMessage = PopupMessageManager.GetHighlightBegin() + socket.GetItemComponent().GetInfo().GetLocalizedName() + PopupMessageManager.GetHighlightEnd() + LocalizationManager.GetLocalizedString(localizationKeyInvalidIsHeatingUp, LocalizationDataTable.Tables.UI);
				PopupMessageManager.GetInValidOrMissingPopUp().ShowPreLocalizedMessageForSeconds(localizedMessage);
			}
			else if (character.socket.IsHoldingItem())
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyINvalidHoldingItem);
			}
			else
			{
				character.socket.PushItem(socket.GetItemComponent());
				collider.center = new Vector3(collider.center.x, colliderPositionOffOn.x, collider.center.z);
				collider.size = new Vector3(collider.size.x, colliderHeightOffOn.x, collider.size.z);
			}
		}
		else if (character.socket.IsHoldingItem())
		{
			if (character.socket.GetItemComponent().GetComponent<KettleComponent>() == null)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidUse);
			}
			else if (character.socket.GetItemComponent().GetComponent<KettleComponent>() != null && character.socket.GetItemComponent().item.amount <= 0)
			{
				PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidIsEmpty, 1.5f, "", character.socket.GetItemComponent().GetInfo().GetLocalizedName());
			}
			else
			{
				HeatUp(character.socket.GetItemComponent());
			}
		}
	}

	public void HeatUp(ItemComponent item, bool clear = false)
	{
		if (item == null || socket == null)
		{
			socket.Clear();
			collider.center = new Vector3(collider.center.x, colliderPositionOffOn.x, collider.center.z);
			collider.size = new Vector3(collider.size.x, colliderHeightOffOn.x, collider.size.z);
			isHeatingUp = false;
			return;
		}
		if (clear)
		{
			socket.Clear();
		}
		socket.PushItem(item);
		if (collider == null)
		{
			collider = GetComponent<BoxCollider>();
		}
		collider.center = new Vector3(collider.center.x, colliderPositionOffOn.y, collider.center.z);
		collider.size = new Vector3(collider.size.x, colliderHeightOffOn.y, collider.size.z);
		Action action = delegate
		{
			isHeatingUp = false;
			socket.GetItemComponent().item.tag = applyTag;
			socket.GetItemComponent().GetComponent<KettleComponent>().FinishHeatUp();
			SoundManager.PlaySoundOnce(soundHeaterFinished);
		};
		isHeatingUp = true;
		TweenerManager.TweenTimeAction("HeatUp", duration, action);
		SoundManager.PlaySoundOnce(soundStartHeater);
		socket.GetItemComponent().GetComponent<KettleComponent>().HeatUp(duration);
	}
}
