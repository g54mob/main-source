using RainbowArt.CleanFlatUI;
using UnityEngine;

public class BoilCoverage : MonoBehaviour
{
	public ProgressBarSpecialPattern progressBar;

	public ComputeShader coverageShader;

	public RenderTexture paintTex;

	public float successThreshold = 0.6f;

	public float checkInterval = 0.1f;

	private ComputeBuffer resultBuffer;

	private uint[] resultData = new uint[1];

	private int totalPixels;

	private void Start()
	{
		totalPixels = paintTex.width * paintTex.height;
		resultBuffer = new ComputeBuffer(1, 4);
		InvokeRepeating("CheckCoverage", 1f, checkInterval);
	}

	private void OnDestroy()
	{
		resultBuffer?.Release();
	}

	private void Update()
	{
		float num = (float)resultData[0] / (float)totalPixels;
		progressBar.CurrentValue = Mathf.Lerp(progressBar.CurrentValue, num * 100f, Time.deltaTime);
	}

	private void CheckCoverage()
	{
		int kernelIndex = coverageShader.FindKernel("CSMain");
		resultBuffer.SetData(new uint[1]);
		coverageShader.SetTexture(kernelIndex, "PaintTex", paintTex);
		coverageShader.SetBuffer(kernelIndex, "Result", resultBuffer);
		int threadGroupsX = Mathf.CeilToInt((float)paintTex.width / 8f);
		int threadGroupsY = Mathf.CeilToInt((float)paintTex.height / 8f);
		coverageShader.Dispatch(kernelIndex, threadGroupsX, threadGroupsY, 1);
		resultBuffer.GetData(resultData);
		float num = (float)resultData[0] / (float)totalPixels;
		Debug.Log($"Coverage: {num * 100f:F1}%");
		if (num >= successThreshold)
		{
			Debug.Log("70% 이상 칠해짐! 성공 처리");
			OnSuccess();
		}
	}

	private void OnSuccess()
	{
		GameManager.S.BoilCompleted();
	}
}
