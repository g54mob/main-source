using UnityEngine;

public class CheckIfSaveFileExists : MonoBehaviour
{
	[SerializeField]
	private bool enableOnStart;

	private void Start()
	{
		if (!enableOnStart)
		{
			DisableOnStart();
		}
		else
		{
			EnableOnStart();
		}
	}

	private void DisableOnStart()
	{
		if (!SaveData.ins.checkIfSaveFileExists())
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void EnableOnStart()
	{
		if (SaveData.ins.checkIfSaveFileExists())
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
