using UnityEngine;
using UnityEngine.UI;

public class ManualSectionSlot : MonoBehaviour
{
	[SerializeField]
	private GameObject toShowFolder;

	private Toggle toggle;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		toShowFolder.SetActive(toggle.isOn);
		toggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			toShowFolder.SetActive(isOn);
			if (isOn)
			{
				toShowFolder.GetComponentInChildren<Toggle>().isOn = true;
			}
		});
	}
}
