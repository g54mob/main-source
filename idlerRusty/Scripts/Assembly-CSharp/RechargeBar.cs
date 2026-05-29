using UnityEngine;

public class RechargeBar : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private Animator barAnim;

	[SerializeField]
	private GameObject noBiofuelSign;

	private const string play = "PLAY";

	private const string charged = "CHARGED";

	private const string empty = "EMPTY";

	private void Start()
	{
		noBiofuelSign.SetActive(value: false);
		ResetRechargeBar();
	}

	public void RechargeFor(int timeInSeconds)
	{
		barAnim.Play("PLAY");
	}

	public void ResetRechargeBar()
	{
		barAnim.Play("EMPTY");
	}

	public void PlayNoBiofuelWarning()
	{
		if (!noBiofuelSign.activeInHierarchy)
		{
			noBiofuelSign.SetActive(value: true);
		}
	}

	public void StopNoBiofuelWarning()
	{
		if (noBiofuelSign.activeInHierarchy)
		{
			noBiofuelSign.SetActive(value: false);
		}
	}
}
