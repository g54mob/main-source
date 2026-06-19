using InControl;
using UnityEngine;
using UnityEngine.UI;

public class BuildPrice : MonoBehaviour
{
	public Color positiveColor;

	public Color negativeColor;

	public Text textRef;

	private Camera uiCam;

	private string noCashString = "Not enough money!";

	private void Awake()
	{
		uiCam = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
	}

	private void Update()
	{
		FollowMouse();
	}

	public void SpawnPriceEffect(int price)
	{
		GameObject gameObject = Object.Instantiate(base.gameObject);
		BuildPriceApply buildPriceApply = gameObject.AddComponent<BuildPriceApply>();
		buildPriceApply.positiveColor = positiveColor;
		buildPriceApply.negativeColor = negativeColor;
		buildPriceApply.textRef = buildPriceApply.GetComponentInChildren<Text>();
		Object.Destroy(gameObject.GetComponent<BuildPrice>());
		gameObject.SetActive(value: true);
		buildPriceApply.RequestPriceApplication(price);
	}

	public void SpawnNoMoneyEffect()
	{
		GameObject gameObject = Object.Instantiate(base.gameObject);
		BuildPriceApply buildPriceApply = gameObject.AddComponent<BuildPriceApply>();
		buildPriceApply.positiveColor = positiveColor;
		buildPriceApply.negativeColor = negativeColor;
		buildPriceApply.textRef = buildPriceApply.GetComponentInChildren<Text>();
		Object.Destroy(gameObject.GetComponent<BuildPrice>());
		gameObject.SetActive(value: true);
		buildPriceApply.RequestTextApplication(noCashString);
	}

	public void SetPriceText(int price)
	{
		textRef.text = price.ToString();
		if (price >= 0)
		{
			textRef.color = positiveColor;
		}
		else
		{
			textRef.color = negativeColor;
		}
	}

	private void FollowMouse()
	{
		Vector3 vector = uiCam.ScreenToWorldPoint(InputManager.MouseProvider.GetPosition());
		base.transform.position = new Vector3(vector.x, vector.y, base.transform.position.z);
	}
}
