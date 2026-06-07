using System.Xml.Linq;
using Assets.Scripts.Craft.Wings.ControlSurfaces;

namespace Assets.Scripts.Craft.Wings
{
	public abstract class WingTipStyle
	{
		public struct InputData
		{
			public float CenterGradient;

			public uint ControlSurfaceMask;

			public float ScaleGradient;

			public readonly float LeadingEdgeGradient => CenterGradient + 0.5f * ScaleGradient;

			public readonly float TrailingEdgeGradient => CenterGradient - 0.5f * ScaleGradient;
		}

		public const string XmlTag = "Wingtip";

		public abstract void GeometryPass(in InputData input, CrossSection[] sections, MeshBuilder[] meshBuilders, ControlSurface[] controlSurfaces);

		public abstract uint GetControlSurfaceMask(uint lastSliceMask);

		public abstract void SaveToXML(XElement xml);
	}
}
