using UnityEngine.UI;

public class PhotoSelectButtonController : ButtonController
{
	public Human citizen;

	public Case.CaseElement element;

	public RawImage photo;

	public InfoWindow thisWindow;

	public void Setup(Human newCitizen, Case.CaseElement newCaseElement, InfoWindow newThisWindow)
	{
	}

	public override void UpdateButtonText()
	{
	}

	public override void OnLeftClick()
	{
	}

	private bool IsActiveKiller(Human person)
	{
		return false;
	}

	private void MergeTargetKeys(Evidence.DataKey key)
	{
	}
}
