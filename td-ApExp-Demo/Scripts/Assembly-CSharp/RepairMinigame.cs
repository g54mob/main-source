using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class RepairMinigame : MonoBehaviour
{
	protected ContentSizeFitter fitter;

	private void Awake()
	{
		fitter = GetComponent<ContentSizeFitter>();
	}

	private void OnEnable()
	{
		Time.timeScale = GameManager.Instance.MinigameTimescale;
	}

	private void OnDisable()
	{
		Time.timeScale = 1f;
	}

	public virtual void ResetMinigame(Interactor interactor)
	{
		if ((bool)fitter)
		{
			fitter.enabled = true;
		}
		base.transform.position = interactor.ActiveInteractable.transform.position + new Vector3(0f, (interactor.playerController.PlayerIndex == 0) ? 0.5f : (-0.5f));
	}

	public virtual void InteractKey(Interactor interactor)
	{
	}

	public abstract void OnMinigameUpgrade();

	public virtual void Initialize()
	{
	}

	public virtual void SequencePress(Interactor interactor, InputActionReference inputActionRef)
	{
	}

	public virtual void SequenceRelease(Interactor interactor, InputActionReference inputActionRef)
	{
	}

	public virtual void MinigameComplete(Interactor interactor)
	{
		Health component = interactor.ActiveInteractable.GetComponent<Health>();
		HealthChangeInfo info = new HealthChangeInfo(this, component, 50f, isPercent: true, null, canRes: true, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		component.SetHealthWithInfo(info);
		interactor.repairMinigame.gameObject.SetActive(value: false);
	}
}
