using UnityEngine.UI;

public class UnreadController : ActiveComponent
{
	[SceneBind("UnreadCouActive")]
	private Image UnreadCouActive;

	[SceneBind("UnreadCou")]
	private Text UnreadCou;

	private int num;

	public int Num
	{
		get
		{
			return num;
		}
		set
		{
			num = value;
			UnreadCou.text = num.ToString();
			UnreadCouActive.gameObject.SetActive(num > 0);
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
	}
}
