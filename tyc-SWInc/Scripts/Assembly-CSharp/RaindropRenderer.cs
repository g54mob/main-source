using UnityEngine;

public class RaindropRenderer : MonoBehaviour
{
	public RenderTexture MainTex;

	public Material RainSim;

	public Material NormalMapping;

	private RenderTexture _workTex;

	private RenderTexture _workTex2;

	private void Awake()
	{
		Shader.SetGlobalTexture("_RainDrops", MainTex);
		RainSim = new Material(RainSim);
		_workTex = new RenderTexture(MainTex.width, MainTex.height, 16);
		_workTex2 = new RenderTexture(MainTex.width, MainTex.height, 16);
	}

	private void FixedUpdate()
	{
		if (!GameSettings.Instance.IsReferenceNull() && GameSettings.GameSpeed > 0f && TimeOfDay.Instance.RainFactor > 0f)
		{
			RainSim.SetVector("_Offset", new Vector4(Random.value, Random.value));
			Graphics.Blit(_workTex, _workTex2, RainSim);
			Graphics.Blit(_workTex2, MainTex, NormalMapping);
			RenderTexture workTex = _workTex;
			_workTex = _workTex2;
			_workTex2 = workTex;
		}
	}
}
