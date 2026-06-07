using TMPro;
using UnityEngine;

public class Ruler : MonoBehaviour
{
	private SpriteRenderer[] rulerSprites;

	private GameObject lengthCanvasObject;

	private TextMeshProUGUI lengthText;

	private LookToObject lookToObject;

	private Color currentColor;

	private float currentDistance;

	public ScaleBetweenTwoPoints ScaleBetweenTwoPoints { get; private set; }

	private void Awake()
	{
		ScaleBetweenTwoPoints = base.transform.GetComponentInChildren<ScaleBetweenTwoPoints>(includeInactive: true);
		rulerSprites = base.transform.GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
		lengthCanvasObject = base.transform.Find("LengthCanvas").gameObject;
		lengthText = base.transform.FindComponent<TextMeshProUGUI>("LengthText", isRecursively: true);
		lookToObject = lengthCanvasObject.GetComponent<LookToObject>();
		currentDistance = 0f;
	}

	public void SetMainCamera(Transform mainCameraTransform)
	{
		lookToObject.objectToLook = mainCameraTransform;
	}

	public void SetColor(Color newColor)
	{
		if (!(currentColor == newColor))
		{
			SpriteRenderer[] array = rulerSprites;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = newColor;
			}
			lengthText.color = new Color(newColor.r, newColor.g, newColor.b);
			currentColor = newColor;
		}
	}

	private void Update()
	{
		lengthCanvasObject.transform.position = ScaleBetweenTwoPoints.gameObject.transform.position;
		lengthCanvasObject.transform.rotation = ScaleBetweenTwoPoints.gameObject.transform.rotation;
		if (currentDistance != ScaleBetweenTwoPoints.Distance)
		{
			currentDistance = ScaleBetweenTwoPoints.Distance;
			lengthText.text = currentDistance.ToString("0.00");
		}
		if (lookToObject.objectToLook != null)
		{
			float num = Vector3.Distance(lengthCanvasObject.transform.position, lookToObject.objectToLook.position);
			if (num > 3f)
			{
				float num2 = num / 4f;
				lengthCanvasObject.transform.localScale = Vector3.one * num2;
			}
		}
	}
}
