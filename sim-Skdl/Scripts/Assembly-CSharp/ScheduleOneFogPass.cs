using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScheduleOneFogPass : ScriptableRenderPass
{
	private Material _material;

	private RTHandle _cameraColorTarget;

	private RTHandle _tempTexture;

	private Color _color;

	private float _start;

	private float _end;

	private float _density;

	private float _blurStrength;

	private float _startHeightFade;

	private float _endHeightFade;

	public ScheduleOneFogPass(Material material)
	{
	}

	public void Setup(ScheduleOneFogFeature.Settings settings, RTHandle cameraColorTarget)
	{
	}

	public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
	{
	}

	public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
	{
	}

	public void Dispose()
	{
	}
}
