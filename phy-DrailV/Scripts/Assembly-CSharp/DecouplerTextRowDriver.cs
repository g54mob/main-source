using System.Collections;
using System.Text;
using UnityEngine;

public class DecouplerTextRowDriver : MonoBehaviour
{
	public DecouplerDeviceLogic device;

	private const float COUPLING_RANGE = 0.4f;

	private const string cantCouple = "              ";

	private const string canCouple = "  IN RANGE    ";

	private const string clockPrefix = "      ";

	private LCDDriver lcd;

	private StringBuilder sb;

	private bool blinkOn = true;

	private void Start()
	{
		lcd = base.transform.GetComponentInChildren<LCDDriver>();
		lcd.Clear();
		sb = new StringBuilder(lcd.numDigits, lcd.numDigits);
		StartCoroutine(UpdateDisplayCoro(0.2f));
	}

	private IEnumerator UpdateDisplayCoro(float waitSeconds)
	{
		WaitForSeconds wait = WaitFor.Seconds(waitSeconds);
		while (true)
		{
			yield return wait;
			blinkOn = (int)Time.timeSinceLevelLoad % 2 == 0;
			UpdateDisplay();
		}
	}

	private void UpdateDisplay()
	{
		float num = (device.frontCouplerInRange ? device.frontCouplerDistance : device.rearCouplerDistance);
		sb.Remove(0, sb.Length);
		if (!string.IsNullOrEmpty(device.notificationText))
		{
			sb.Append(device.notificationText.Substring(0, Mathf.Min(device.notificationText.Length, lcd.numDigits)));
		}
		else if (!(num >= 10f) && !(num < 0f))
		{
			int value = (int)num;
			int value2 = (int)(num * 10f % 10f);
			sb.Append((num <= 0.4f) ? "  IN RANGE    " : "              ");
			sb.Append(value);
			sb.Append('.');
			sb.Append(value2);
		}
		lcd.Display(sb.ToString());
	}
}
