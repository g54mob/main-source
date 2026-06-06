using System.Collections;
using UnityEngine;

public class LightManager : MonoBehaviour
{
	[SerializeField]
	private Color stage2Color;

	[SerializeField]
	private Color stage3Color;

	[SerializeField]
	private Color stage4Color;

	[SerializeField]
	private Color stage5Color;

	[SerializeField]
	private Light light;

	[SerializeField]
	private Renderer sun;

	private void Start()
	{
	}

	public void ChangeColor(int stage)
	{
		switch (stage)
		{
		case 2:
			StartCoroutine(ShiftLight(stage2Color, 180f));
			break;
		case 3:
			StartCoroutine(ShiftLight(stage3Color, 180f));
			break;
		case 4:
			StartCoroutine(ShiftLight(stage4Color, 180f));
			break;
		case 5:
			StartCoroutine(ShiftLight(stage5Color, 180f));
			break;
		}
	}

	private IEnumerator ShiftLight(Color newColor, float rotationInDeg)
	{
		Color startColor = light.color;
		Vector3 startEuler = light.transform.eulerAngles;
		Vector3 newEuler = startEuler + new Vector3(0f, rotationInDeg, 0f);
		float timer = 0f;
		float count = 0f;
		while (timer < 1f)
		{
			light.color = Color.Lerp(startColor, newColor, timer);
			light.transform.eulerAngles = Vector3.Lerp(startEuler, newEuler, timer);
			if (sun != null)
			{
				sun.material.color = light.color * 2.3784f;
			}
			count += Time.deltaTime;
			if (count > 60f)
			{
				Debug.LogError("Possible infinite loop");
				break;
			}
			timer += Time.deltaTime / 30f;
			yield return new WaitForEndOfFrame();
		}
		light.color = newColor;
		light.transform.eulerAngles = newEuler;
		yield return null;
	}
}
