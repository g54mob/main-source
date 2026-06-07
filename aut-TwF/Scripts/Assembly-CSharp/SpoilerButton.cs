using TMPro;
using UnityEngine;

public class SpoilerButton : MonoBehaviour
{
	[SerializeField]
	private GameObject[] objectsToShow;

	[SerializeField]
	private string showText;

	[SerializeField]
	private string hideText;

	[SerializeField]
	private TextMeshProUGUI buttonText;

	[SerializeField]
	private AutoTransformRebuild autoTransformRebuild;

	private bool visible;

	private void Awake()
	{
		GameObject[] array = objectsToShow;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		visible = false;
		buttonText.text = showText;
	}

	public void ShowObjects()
	{
		visible = !visible;
		GameObject[] array = objectsToShow;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(visible);
		}
		buttonText.text = (visible ? hideText : showText);
		if ((bool)autoTransformRebuild)
		{
			autoTransformRebuild.RebuildTransform();
		}
	}
}
