using TMPro;
using UnityEngine;

public class ObjectiveContentListEntry : ButtonController
{
	[Header("References")]
	public TextMeshProUGUI objectiveText;

	public Case.ResolveQuestion question;

	public ObjectivesContentController objectivesController;

	public void Setup(ObjectivesContentController newController, Case.ResolveQuestion newStarting)
	{
	}

	public override void VisualUpdate()
	{
	}
}
