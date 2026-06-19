using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LobbyReadyUpUI : EntityBehaviourBase, ISelectHandler, IEventSystemHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
	private static readonly int Punch = Animator.StringToHash("punch");

	public bool _selected;

	public bool _hover;

	public float hideSpeed = 1f;

	private bool _requested;

	public GameObject readyUpCheck;

	public float highPos;

	public float lowPos;

	public Animator readyUpAnimator;

	public Image fill;

	public StudioEventEmitter showSFX;

	public StudioEventEmitter hideSFX;

	public StudioEventEmitter failToReadySFX;

	public StudioEventEmitter checkReadyUpSFX;

	public StudioEventEmitter uncheckReadyUpSFX;

	public StudioEventEmitter proceedFillSFX;

	public bool wasUp;

	public GameObject lockParent;

	private bool previouslyProceeding;

	public ContractSelectionUI contractSelectionUI;

	protected override void OnEntityCreated()
	{
	}

	protected override void OnUpdatePresentation()
	{
		contractSelectionUI.selected = _selected;
		lockParent.SetActive(!NetworkAggroManagerBase<LobbyManager>.instance.IsCurrentContractUnlocked());
		if (AggroInputManager.input.Lobby.BackOut.WasPressedThisFrame() && _requested)
		{
			NetworkAggroManagerBase<PlayersManager>.instance.RequestCancel();
			_requested = false;
		}
		if (NetworkAggroManagerBase<PlayersManager>.instance.proceededLastTimer)
		{
			readyUpCheck.SetActive(value: true);
			fill.fillAmount = 1f;
		}
		else
		{
			readyUpCheck.SetActive(NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding());
			fill.fillAmount = NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue();
		}
		if (!NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding() & previouslyProceeding)
		{
			uncheckReadyUpSFX.Play();
		}
		previouslyProceeding = NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding();
	}

	public void ToggleProceed()
	{
		if (!NetworkAggroManagerBase<LobbyManager>.instance.IsCurrentContractUnlocked())
		{
			failToReadySFX.Play();
			return;
		}
		if (_requested)
		{
			NetworkAggroManagerBase<PlayersManager>.instance.RequestCancel();
			_requested = false;
			uncheckReadyUpSFX.Play();
		}
		else
		{
			NetworkAggroManagerBase<PlayersManager>.instance.RequestProceed();
			_requested = true;
			checkReadyUpSFX.Play();
		}
		readyUpAnimator.SetTrigger(Punch);
	}

	protected override void OnUpdatePresentationLate()
	{
		if (NetworkAggroManagerBase<LobbyManager>.instance.state == LobbyManager.LobbyState.Waiting)
		{
			Vector2 vector = new Vector2(base.transform.localPosition.x, (_selected || ((contractSelectionUI.hover || _hover) && AggroInputManager.mode == InputMode.KBM) || NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue() > 0f) ? highPos : lowPos);
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, vector, hideSpeed * Time.deltaTime);
			float num = (highPos + lowPos) / 2f;
			if (base.transform.localPosition.y < num && wasUp)
			{
				hideSFX.Play();
			}
			if (base.transform.localPosition.y > num && !wasUp)
			{
				showSFX.Play();
			}
			wasUp = base.transform.localPosition.y > num;
			proceedFillSFX.SetParameter("confirm-hold", NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedProceedValue());
		}
		else
		{
			proceedFillSFX.SetParameter("confirm-hold", 0f);
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		_selected = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		_selected = false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_hover = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_hover = false;
	}
}
