using DG.Tweening;
using UnityEngine;

public class CameraStarter : MonoBehaviour
{
	public KeyCode startKey;

	public KeyCode stopKey;

	private Vector3 startPos;

	public float startingDelay = 3f;

	private void Start()
	{
		startPos = base.transform.position;
		GetComponent<Animator>().speed = 0f;
	}

	private void Update()
	{
		if (Input.GetKeyDown(startKey))
		{
			DOVirtual.DelayedCall(startingDelay, delegate
			{
				GetComponent<Animator>().speed = 1f;
				GetComponent<Animator>().SetTrigger("Record");
			});
		}
		if (Input.GetKeyDown(stopKey))
		{
			base.transform.position = startPos;
			GetComponent<Animator>().speed = 0f;
			GetComponent<Animator>().ResetTrigger("Record");
			base.gameObject.SetActive(value: false);
			base.gameObject.SetActive(value: true);
		}
	}
}
