using UnityEngine;
using UnityEngine.UI;

public class SandboxObjController : ActiveComponent
{
	[SceneBind("Hover")]
	private Image Hover;

	[SceneBind("Active")]
	private Image Active;

	[SceneBind("Normal")]
	private Image Normal;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
	}

	public void Redraw(bool active, bool chosen)
	{
		Hover.gameObject.SetActive(!active && !chosen);
		Normal.gameObject.SetActive(active);
		Active.gameObject.SetActive(chosen);
		GetComponent<Button>().enabled = active && !chosen;
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		if (!active && !chosen)
		{
			base.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
		}
	}
}
