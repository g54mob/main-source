using DV.DopplerEffects;

public struct DopplerRequest
{
	public static readonly DopplerRequest DEFAULT = new DopplerRequest
	{
		useSpatialBlend = false,
		updateMode = Doppler.UpdateMode.LateUpdate
	};

	public bool? useSpatialBlend;

	public Doppler.UpdateMode? updateMode;
}
