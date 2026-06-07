using UnityEngine;
using UnityEngine.UI;

public class ManualPageSlot : MonoBehaviour
{
	[SerializeField]
	private GameObject toShowPage;

	private Toggle toggle;

	private ScrollRect pageParentScrollRect;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		toShowPage.SetActive(toggle.isOn);
		toggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			toShowPage.SetActive(isOn);
			if (isOn)
			{
				if (pageParentScrollRect == null)
				{
					pageParentScrollRect = toShowPage.GetComponentInParent<ScrollRect>();
				}
				if (pageParentScrollRect != null)
				{
					pageParentScrollRect.verticalNormalizedPosition = 1f;
				}
			}
		});
	}

	private void OnDisable()
	{
		if (toShowPage != null && toShowPage.activeInHierarchy)
		{
			toShowPage.SetActive(value: false);
		}
		if (toggle != null && toggle.isOn)
		{
			toggle.isOn = false;
		}
	}
}
