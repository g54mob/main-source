using UnityEngine.EventSystems;

public abstract class LandmarkActionUI : UIBehaviour
{
	protected ILandmarkAction _landmarkAction;

	public virtual void Initialize(ILandmarkAction action)
	{
		_landmarkAction = action;
		base.gameObject.SetActive(value: true);
	}

	public abstract bool IsLandmarkActionUI(LandmarkAction landmarkAction);
}
