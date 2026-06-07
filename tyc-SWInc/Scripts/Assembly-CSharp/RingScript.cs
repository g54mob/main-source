using UnityEngine;
using UnityEngine.UI;

public class RingScript : MonoBehaviour
{
	public int size;

	public float time;

	public RectTransform rect;

	public RawImage img;

	private void Update()
	{
		if (!(rect == null))
		{
			time += Time.deltaTime;
			rect.sizeDelta = new Vector2((float)size * time, (float)size * time);
			img.color = new Color(1f, 1f, 1f, 1f - time);
			if (time >= 1f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
