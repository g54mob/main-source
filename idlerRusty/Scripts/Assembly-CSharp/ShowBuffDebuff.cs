using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShowBuffDebuff : MonoBehaviour
{
	private Image image;

	[SerializeField]
	private Sprite neutral;

	[SerializeField]
	private Sprite buffed;

	[SerializeField]
	private Sprite debuff;

	public void Neutral()
	{
		image = GetComponent<Image>();
		image.sprite = neutral;
	}

	public void Buff()
	{
		image = GetComponent<Image>();
		image.sprite = buffed;
	}

	public void Debuff()
	{
		image = GetComponent<Image>();
		image.sprite = debuff;
	}
}
