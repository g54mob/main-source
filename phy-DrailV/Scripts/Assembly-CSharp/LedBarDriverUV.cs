using UnityEngine;

public class LedBarDriverUV : LedBarDriverBase
{
	private static readonly int MainTexSt = Shader.PropertyToID("_MainTex_ST");

	public bool reverseTexture;

	public float length = 0.1f;

	private MeshRenderer renderer;

	private MaterialPropertyBlock materialPropertyBlock;

	private float baseLightScale;

	private float basePosition;

	public override void Initialize()
	{
		if (!initialized)
		{
			renderer = GetComponent<MeshRenderer>();
			materialPropertyBlock = new MaterialPropertyBlock();
			baseLightScale = base.transform.localScale.x;
			basePosition = base.transform.localPosition.x;
			base.Initialize();
		}
	}

	protected override void UpdateLeds(int amount)
	{
		if (mode == DisplayMode.OFF)
		{
			renderer.gameObject.SetActive(value: false);
			return;
		}
		renderer.gameObject.SetActive(value: true);
		float num = (float)amount / (float)ledsCount;
		materialPropertyBlock.SetVector(MainTexSt, new Vector4(1f, num, 0f, reverseTexture ? (1f - num) : 0f));
		renderer.SetPropertyBlock(materialPropertyBlock);
		Vector3 localScale = base.transform.localScale;
		base.transform.localScale = new Vector3(baseLightScale * num, localScale.y, localScale.z);
		float num2 = length / 2f * (1f - num);
		Vector3 localPosition = base.transform.localPosition;
		base.transform.localPosition = new Vector3(basePosition + num2, localPosition.y, localPosition.z);
	}
}
