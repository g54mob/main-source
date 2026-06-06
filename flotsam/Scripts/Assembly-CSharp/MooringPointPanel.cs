using UnityEngine;

public class MooringPointPanel : SceneBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private GameObject _emptyBoat;

	[SerializeField]
	private BoatEntry _linkedBoat;

	private MooringPoint _mooringPoint;

	public BuildablePanelElementId Id => BuildablePanelElementId.MooringPoint;

	private void OnDisable()
	{
		_mooringPoint.OnBoatLinkUpdatedEvent.RemoveListener(UpdateLinkedBoat);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<MooringPoint>(out _mooringPoint))
		{
			base.gameObject.SetActive(value: true);
			UpdateLinkedBoat();
			_mooringPoint.OnBoatLinkUpdatedEvent.AddListener(UpdateLinkedBoat);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		if ((bool)_mooringPoint)
		{
			_mooringPoint.OnBoatLinkUpdatedEvent.RemoveListener(UpdateLinkedBoat);
		}
		base.gameObject.SetActive(value: false);
	}

	private void UpdateLinkedBoat()
	{
		bool flag = _mooringPoint.LinkedBoat != null;
		_emptyBoat.SetActive(!flag);
		_linkedBoat.gameObject.SetActive(flag);
		if (flag)
		{
			_linkedBoat.Initialize(_mooringPoint.LinkedBoat);
		}
	}
}
