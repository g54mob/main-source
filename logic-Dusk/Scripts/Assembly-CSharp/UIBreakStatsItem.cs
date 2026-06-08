using UnityEngine;
using UnityEngine.UI;

public class UIBreakStatsItem : MonoBehaviour
{
	public Image Border;

	public Text DescriptionLabel;

	public Text MissionCountLabel;

	public Text BreakProbabilityLabel;

	public void Awake()
	{
		if (DescriptionLabel == null)
		{
			DescriptionLabel = base.gameObject.GetComponent<Text>();
		}
	}

	private void OnDestroy()
	{
		Border = null;
		DescriptionLabel = null;
		MissionCountLabel = null;
		BreakProbabilityLabel = null;
	}
}
