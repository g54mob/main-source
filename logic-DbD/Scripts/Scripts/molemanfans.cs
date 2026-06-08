using UnityEngine;
using UnityEngine.UI;

public class molemanfans : Website
{
	[SerializeField]
	private Toggle q1Yes;

	[SerializeField]
	private Toggle q1No;

	[SerializeField]
	private Toggle q2Yes;

	[SerializeField]
	private Toggle q2No;

	[SerializeField]
	private Button submit;

	public static string[] MOLEMANS = new string[5] { "confused", "weak", "cool", "pathetic", "evil" };

	public void ChooseMoleman()
	{
		string text = "molemanfans.net/test";
		string text2 = (((q1Yes.isOn && q1No.isOn) || (q2Yes.isOn && q2No.isOn)) ? "confused" : ((q1Yes.isOn && q2Yes.isOn) ? "weak" : ((q1Yes.isOn && q2No.isOn) ? "cool" : ((!q1No.isOn || !q2Yes.isOn) ? "evil" : "pathetic"))));
		LaunchInnerSite(text + "/" + text2);
	}

	public void SetSensitivity()
	{
		submit.interactable = (q1Yes.isOn || q1No.isOn) && (q2Yes.isOn || q2No.isOn);
	}
}
