using UnityEngine;

public class Tooltip : MonoBehaviour
{
	public string tip;

	private void Start()
	{
		if (tip == "")
		{
			tip = base.transform.name;
		}
	}
}
