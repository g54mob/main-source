using InControl;
using UnityEngine;
using UnityEngine.UI;

public class BuildPriceApply : MonoBehaviour
{
	public Color positiveColor;

	public Color negativeColor;

	public Text textRef;

	private bool activated;

	private Vector3 moveRate = new Vector3(0f, 1f, 0f);

	private float totalEffectTime = 1f;

	private float currentEffectTime;

	private Camera uiCam;

	private void Awake()
	{
		uiCam = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
	}

	private void Update()
	{
		if (activated)
		{
			UpdateEffect();
		}
	}

	public void RequestPriceApplication(int price)
	{
		SetPriceText(price);
		MoveToMousePos();
		activated = true;
		textRef.material = new Material(textRef.material);
	}

	public void RequestTextApplication(string newText)
	{
		MoveToMousePos();
		textRef.color = negativeColor;
		textRef.text = newText;
		activated = true;
		textRef.material = new Material(textRef.material);
	}

	private void UpdateEffect()
	{
		currentEffectTime += Time.deltaTime;
		if (currentEffectTime > totalEffectTime)
		{
			currentEffectTime = totalEffectTime;
		}
		base.transform.localPosition += moveRate * Time.deltaTime;
		textRef.material.color = new Color(textRef.material.color.r, textRef.material.color.g, textRef.material.color.b, (totalEffectTime - currentEffectTime) / totalEffectTime);
		if (currentEffectTime >= totalEffectTime)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void SetPriceText(int price)
	{
		textRef.text = price.ToString();
		if (price >= 0)
		{
			textRef.text = "+" + textRef.text;
			textRef.color = positiveColor;
		}
		else
		{
			textRef.color = negativeColor;
		}
	}

	private void MoveToMousePos()
	{
		Vector3 vector = uiCam.ScreenToWorldPoint(InputManager.MouseProvider.GetPosition());
		base.transform.position = new Vector3(vector.x, vector.y, base.transform.position.z);
	}
}
