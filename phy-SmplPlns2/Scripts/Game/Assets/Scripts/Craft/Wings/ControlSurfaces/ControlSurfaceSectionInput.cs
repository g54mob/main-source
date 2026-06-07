using System;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	public readonly ref struct ControlSurfaceSectionInput
	{
		public readonly NativeAirfoil Airfoil;

		public readonly MeshBuilder[] Meshes;

		public readonly int RegionIndex;

		public readonly int SliceIndex;

		public readonly Span<CrossSection> SurfaceSections;

		public readonly CrossSection Wing;

		public ControlSurfaceSectionInput(CrossSection wing, Span<CrossSection> surfaceSections, NativeAirfoil airfoil, MeshBuilder[] meshes, int sliceIndex, int regionIndex)
		{
			Wing = wing;
			SurfaceSections = surfaceSections;
			Airfoil = airfoil;
			Meshes = meshes;
			SliceIndex = sliceIndex;
			RegionIndex = regionIndex;
		}
	}
}
