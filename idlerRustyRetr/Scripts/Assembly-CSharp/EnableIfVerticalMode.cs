using UnityEngine;

public class EnableIfVerticalMode : MonoBehaviour
{
	[SerializeField]
	private bool enable;

	private void Start()
	{
		bool flag = SaveData.ins.verticalMode;
		if (!enable)
		{
			flag = !flag;
		}
		base.gameObject.SetActive(flag);
	}
}
