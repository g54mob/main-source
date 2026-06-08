using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class allin_donate : WebsiteDownload
{
	[SerializeField]
	private TMP_InputField firstName;

	[SerializeField]
	private TMP_InputField lastName;

	[SerializeField]
	private TMP_InputField donationAmount;

	[SerializeField]
	private TMP_InputField ccInfo;

	[SerializeField]
	private Toggle sportsToggle;

	[SerializeField]
	private Toggle scratchToggle;

	public void SubmitDonation()
	{
		string message;
		if (firstName.text.Length != 0 && lastName.text.Length != 0)
		{
			message = ((donationAmount.text.Length == 0) ? "Please enter a valid donation amount." : ((ccInfo.text.Length != 0) ? "Please enter a valid credit card number." : "Please enter your credit card number."));
		}
		else
		{
			Debug.Log("firstName.text.Length=" + firstName.text + ", lastName.text.Length=" + lastName.text);
			message = "Please fill out your name.";
		}
		FailPopup(message);
	}
}
