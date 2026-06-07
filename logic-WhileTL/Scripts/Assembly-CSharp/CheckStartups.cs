using UnityEngine.UI;

public class CheckStartups : ActiveComponent
{
	[SceneBind("Text")]
	private Text text;

	private Image image;

	private void Start()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		image = base.transform.GetComponent<Image>();
		image.enabled = false;
		text.enabled = false;
	}

	private void Update()
	{
		if (ActiveComponent.Model != null && ActiveComponent.Model.P != null)
		{
			text.text = ActiveComponent.Model.P.startupQueue.Count.ToString();
			image.enabled = ActiveComponent.Model.P.startupQueue.Count != 0;
			text.enabled = ActiveComponent.Model.P.startupQueue.Count != 0;
		}
	}
}
