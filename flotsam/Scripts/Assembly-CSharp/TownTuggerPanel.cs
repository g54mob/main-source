using UnityEngine;

public class TownTuggerPanel : MonoBehaviour, IBuildablePanelElement
{
	public BuildablePanelElementId Id => BuildablePanelElementId.TownTugger;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (buildable.Properties.ReturnShowElement(this, finished))
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
