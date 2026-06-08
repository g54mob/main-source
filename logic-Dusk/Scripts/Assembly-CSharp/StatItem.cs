using UnityEngine;
using UnityEngine.UI;

public class StatItem : MonoBehaviour
{
	public Text label;

	public Image backgroundImage { get; private set; }

	private void Awake()
	{
		backgroundImage = GetComponent<Image>();
		backgroundImage.enabled = true;
	}
}
