using UnityEngine;

public class MoveToHereOnStart : MonoBehaviour
{
	[SerializeField]
	private bool haikutherobot;

	[SerializeField]
	private bool slatethedigger;

	[SerializeField]
	private bool reapershop;

	private void Start()
	{
		if (haikutherobot)
		{
			GameManager.ins.haiku.transform.position = base.transform.position;
			GameManager.ins.haiku.gameObject.SetActive(value: true);
		}
		if (slatethedigger)
		{
			GameManager.ins.slate.transform.position = base.transform.position;
			GameManager.ins.slate.gameObject.SetActive(value: true);
		}
		_ = reapershop;
	}
}
