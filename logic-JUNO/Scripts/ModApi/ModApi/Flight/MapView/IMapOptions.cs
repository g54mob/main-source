using System.Xml.Linq;

namespace ModApi.Flight.MapView
{
	public interface IMapOptions
	{
		GizmoAlignmentType BurnGizmoAlignment { get; set; }

		ICraftOptions Craft { get; }

		MapViewFontSize FontSize { get; set; }

		float FontSizeValue { get; }

		IManeuverNodeOptions ManeuverNodes { get; }

		AdjustmentSpaceType NodeAdjustmentSpace { get; set; }

		INodeNavOptions NodeNav { get; }

		OrbitUiVerbosity OrbitUiVerbosity { get; set; }

		ITargetingOptions Targeting { get; }

		XElement GenerateXml();

		void ResetDefaults();

		void RestoreFromXml(XElement mapOptionsContainerElement);
	}
}
