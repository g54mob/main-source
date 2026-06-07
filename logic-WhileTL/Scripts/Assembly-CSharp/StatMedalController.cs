using UnityEngine.UI;

public class StatMedalController : ActiveComponent
{
	[SceneBind("Locked")]
	private Image lockedImage;

	[SceneBind("Bronze")]
	private Image bronzeImage;

	[SceneBind("Silver")]
	private Image silverImage;

	[SceneBind("Gold")]
	private Image goldImage;

	private Image[] scores = new Image[4];

	private int activeMedal = -1;

	public int ActiveMedal
	{
		get
		{
			return activeMedal;
		}
		set
		{
			activeMedal = value;
			SetActiveMedal(value);
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		scores[0] = lockedImage;
		scores[1] = bronzeImage;
		scores[2] = silverImage;
		scores[3] = goldImage;
	}

	private void SetActiveMedal(int medalNumber)
	{
		for (int i = 0; i < scores.Length; i++)
		{
			scores[i].gameObject.SetActive(i == medalNumber + 1);
		}
	}

	public override void Init()
	{
		base.Init();
		Image[] array = scores;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
	}
}
