using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
	public static readonly Color32 BLUE = new Color32(76, 165, 248, byte.MaxValue);

	public static readonly Color32 GREEN = new Color32(121, byte.MaxValue, 112, byte.MaxValue);

	public static readonly Color32 YELLOW = new Color32(245, byte.MaxValue, 126, byte.MaxValue);

	public static readonly Color32 RED = new Color32(byte.MaxValue, 83, 107, byte.MaxValue);

	private void Start()
	{
		Object.Destroy(base.gameObject, 3f);
	}

	public void SetColor(Color32 color)
	{
		GetComponent<Image>().color = color;
	}
}
