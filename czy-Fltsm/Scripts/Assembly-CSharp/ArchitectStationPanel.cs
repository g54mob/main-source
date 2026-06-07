using UnityEngine;
using UnityEngine.UI;

public class ArchitectStationPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private Button _button;

	public BuildablePanelElementId Id => BuildablePanelElementId.ArchitectStation;

	private void OnEnable()
	{
		OnUIBlockersUpdated();
		GameEventDispatcher.AddListener(GameEventType.UIBlockersUpdated, OnUIBlockersUpdated);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.UIBlockersUpdated, OnUIBlockersUpdated);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.Properties.ReturnShowElement(this, finished))
		{
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}

	public void EnterArchitectMode()
	{
		GameManager.UIManager.DisplayPanel(PanelID.ArchitectBottomBar);
	}

	private void OnUIBlockersUpdated(GameEvent gameEvent = null)
	{
		_button.interactable = UIManager.AllowArchitectMode;
	}
}
