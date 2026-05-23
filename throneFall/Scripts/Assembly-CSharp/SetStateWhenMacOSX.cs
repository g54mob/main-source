using UnityEngine;

public class SetStateWhenMacOSX : MonoBehaviour
{
	public bool activeOnMacOSX;

	public bool activeElsewhere;

	private void Awake()
	{
		base.gameObject.SetActive(activeElsewhere);
	}
}
