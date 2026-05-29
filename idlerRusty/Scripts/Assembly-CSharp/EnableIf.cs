using UnityEngine;

public class EnableIf : MonoBehaviour
{
	[SerializeField]
	private bool verticalMode;

	private void Start()
	{
		if (!verticalMode && SaveData.ins.verticalMode)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
