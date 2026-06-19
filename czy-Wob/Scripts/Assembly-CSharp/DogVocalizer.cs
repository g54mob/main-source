using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogVocalizer : MonoBehaviour
{
	public Transform scaler;

	private List<Image> allImages = new List<Image>();

	private bool locked;

	private DogLooks looksRef;

	private void Awake()
	{
		looksRef = base.transform.root.GetComponent<DogLooks>();
		allImages.AddRange(GetComponentsInChildren<Image>());
		UpdateEffect(0f, 0f);
	}

	public void UpdateEffect(float amplitude, float time)
	{
		if (!locked)
		{
			float num = Mathf.Clamp(amplitude * 3f, 0f, 1f);
			looksRef.RequestGhostlyColorShift(num * 2f);
			Color color = new Color(1f, 1f, 1f, num);
			for (int i = 0; i < allImages.Count; i++)
			{
				allImages[i].color = color;
			}
			float num2 = Mathf.Clamp(amplitude * 2f, 0.1f, 0.9f);
			float num3 = Mathf.Cos(time * 2f);
			num2 *= num3;
			scaler.localScale = new Vector3(1f + num2, 1f - num2, 0f);
		}
	}

	public void Lock()
	{
		locked = true;
		base.gameObject.SetActive(value: false);
	}
}
