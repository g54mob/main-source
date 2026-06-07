using UnityEngine;
using UnityEngine.UI;

public class SecretPageDisplayManager : MonoBehaviour
{
	public static SecretPageDisplayManager Instance;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Animator animator;

	private const string startDisplayAnimationTrigger = "StartDisplay";

	private const string stopDisplayAnimationTrigger = "StopDisplay";

	private void Awake()
	{
		Instance = this;
	}

	public void StartDisplaySecretPage(Sprite sprite)
	{
		image.sprite = sprite;
		if (animator != null)
		{
			animator.SetTrigger("StartDisplay");
		}
	}

	public void StopDisplaySecretPage()
	{
		if (animator != null)
		{
			animator.SetTrigger("StopDisplay");
		}
	}
}
