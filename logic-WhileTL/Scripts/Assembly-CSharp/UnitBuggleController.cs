using App.Data;
using Localization;
using UnityEngine.UI;

public class UnitBuggleController : ActiveComponent
{
	[SceneBind("Score")]
	private Text Score;

	[SceneBind("Name")]
	private Text Name;

	[SceneBind("Top")]
	private Text Top;

	private void Awake()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
	}

	public void Clear()
	{
		Top.text = "";
		Name.text = "";
		Score.text = "";
	}

	public void Redraw(Unit u, int id)
	{
		base.gameObject.SetActive(value: false);
		Name.text = u.name.ToUpper();
		Score.text = TextResources.GetString("SCORE") + " " + Logic.ColorTransform("GOOD", u.score.ToString());
		Top.text = Logic.ColorTransform("WARNING", "#" + id);
	}
}
