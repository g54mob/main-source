using UnityEngine.Rendering.PostProcessing;

public sealed class ZoneDetectorRender : PostProcessEffectRenderer<ZoneDetector>
{
	public override bool HasRendering()
	{
		return false;
	}

	public override void Render(PostProcessRenderContext context)
	{
		ZoneDetector.SetValue(base.settings.underwater.value, ZoneDetector.ZoneType.Underwater);
		ZoneDetector.SetValue(base.settings.tunnel.value, ZoneDetector.ZoneType.Tunnel);
		ZoneDetector.SetValue(base.settings.indoors.value, ZoneDetector.ZoneType.Indoors);
		ZoneDetector.SetValue(base.settings.depot.value, ZoneDetector.ZoneType.Depot);
	}
}
