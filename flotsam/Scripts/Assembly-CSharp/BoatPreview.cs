public class BoatPreview : BuildablePreview
{
	public MooringPoint ClosestMooringPoint;

	public BoatPreview(Buildable buildable, VisualPrefabPreviewSettings previewSettings, int visualIndex)
		: base(buildable, previewSettings, visualIndex)
	{
		ClosestMooringPoint = null;
	}
}
