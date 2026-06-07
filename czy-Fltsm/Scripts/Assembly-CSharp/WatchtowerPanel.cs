using UnityEngine;

public class WatchtowerPanel : MonoBehaviour, IBuildablePanelElement
{
	public BuildablePanelElementId Id => BuildablePanelElementId.Watchtower;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryReturnBuildableExtendable<WatchTower>(out var _))
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
}
