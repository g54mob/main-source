using UnityEngine.UI;

public class MedalSystem : ActiveComponent
{
	[SceneBind("Locked")]
	private Image Locked;

	[SceneBind("Chosen")]
	private Image Chosen;

	[SceneBind("Icon")]
	private Image Icon;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Locked.gameObject.SetActive(value: false);
		Chosen.gameObject.SetActive(value: false);
	}

	public void SetState(bool chosen, bool locked)
	{
		SetLocked(locked);
		SetChosen(chosen);
	}

	public void SetLocked(bool locked)
	{
		Locked.gameObject.SetActive(locked);
		Icon.gameObject.SetActive(!locked);
	}

	public void SetChosen(bool chosen)
	{
		Chosen.gameObject.SetActive(chosen);
	}
}
