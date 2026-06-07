using UnityEngine;
using UnityEngine.UI;

public class AnimatedImage : MonoBehaviour
{
	public int Cells;

	public int Frames;

	public int Frame;

	public float Speed;

	public float LastFrameWait;

	private float NextFrame;

	private RawImage img;

	private void Start()
	{
		img = GetComponent<RawImage>();
	}

	private void Update()
	{
		NextFrame -= Time.deltaTime;
		if (NextFrame <= 0f)
		{
			Frame = (Frame + 1) % Frames;
			if (Frame == Frames - 1)
			{
				NextFrame += Speed + LastFrameWait;
			}
			else
			{
				NextFrame += Speed;
			}
		}
		float num = 1f / (float)Cells;
		img.uvRect = new Rect((float)(Frame % Cells) * num, 1f - (float)(Frame / Cells) * num - num, num, num);
	}
}
