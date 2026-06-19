using UnityEngine;

public class RadicalPauseMenu_InvitePlayers : RadicalMainMenuOption
{
	private float _lastCheckTimeStamp;

	protected override void Awake()
	{
		UpdateState();
		base.Awake();
	}

	private void OnEnable()
	{
		if (Manager.networking.OfflineSession)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	protected override void Update()
	{
		base.Update();
		if (Time.realtimeSinceStartup - _lastCheckTimeStamp > 1f)
		{
			_lastCheckTimeStamp = Time.realtimeSinceStartup;
			UpdateState();
		}
	}

	public void UpdateState()
	{
		if (canBeActivated != Manager.networking.CanSendInvites)
		{
			Debug.Log("RadicalPauseMenu_InvitePlayers.UpdateState: " + (canBeActivated ? "can" : "can't") + " send invites.");
		}
		canBeActivated = (activeInSPStage = Manager.networking.CanSendInvites);
	}

	public override void OnActivated()
	{
		Debug.Log("RadicalPauseMenu_InvitePlayers.OnActivated");
		base.OnActivated();
		Manager.networking.StartSessionInvitationFlow();
	}

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		UpdateState();
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (Manager.networking.OfflineSession || !canBeActivated)
		{
			if (base.transform.parent.gameObject.activeSelf)
			{
				base.transform.parent.gameObject.SetActive(value: false);
			}
			return OptionActiveState.INACTIVE;
		}
		if (!base.transform.parent.gameObject.activeSelf)
		{
			base.transform.parent.gameObject.SetActive(value: true);
			GetComponentInParent<LinearLayoutUIComponent>().MarkUIComponentAsDirty();
		}
		return base.GetActiveStateInCurrentScene();
	}
}
