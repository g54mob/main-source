using UnityEngine;
using UnityEngine.UI;

public class StatHeaderItem : MonoBehaviour
{
	public Text headerLabel;

	public StatItem currentLabel;

	public StatItem currentBest;

	public StatItem currentTotal;

	public Image backgroundImage { get; private set; }

	private void Awake()
	{
		backgroundImage = GetComponent<Image>();
		backgroundImage.enabled = true;
	}
}
