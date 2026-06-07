using UnityEngine;

[RequireComponent(typeof(Camera))]
public sealed class SharpenEffect : MonoBehaviour
{
	public Material Effect;

	public SharpenEffect()
	{
		int num = 4;
		if (2 == 0)
		{
		}
		base._002Ector();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnRenderImage(RenderTexture _0023_003DqfH4kVs_0024e70wSQODVmo5ORQ_003D_003D, RenderTexture _0023_003Dqxtvv2qN5iv8A2_0024iIn2UuKQ_003D_003D)
	{
		int num = 6;
		if (2 == 0)
		{
		}
		int num2 = 1;
		if (5 == 0)
		{
		}
		int num3 = 1;
		if (7 == 0)
		{
		}
		Graphics.Blit(_0023_003DqfH4kVs_0024e70wSQODVmo5ORQ_003D_003D, _0023_003Dqxtvv2qN5iv8A2_0024iIn2UuKQ_003D_003D, Effect);
	}
}
