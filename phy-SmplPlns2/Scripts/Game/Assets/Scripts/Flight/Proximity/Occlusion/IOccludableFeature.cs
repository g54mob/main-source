using Jundroo.Common.Math;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public interface IOccludableFeature
	{
		string FeatureName { get; }

		float SizeScale { get; }

		OrientedBoundingBox WorldBounds { get; }

		void SetVisible(bool visible);
	}
}
