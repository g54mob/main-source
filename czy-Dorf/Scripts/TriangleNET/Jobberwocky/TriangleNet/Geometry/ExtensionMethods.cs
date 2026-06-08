using Jobberwocky.TriangleNet.Meshing;

namespace Jobberwocky.TriangleNet.Geometry
{
	public static class ExtensionMethods
	{
		public static IMesh Triangulate(IPolygon polygon, ConstraintOptions options)
		{
			return new GenericMesher().Triangulate(polygon, options, null);
		}
	}
}
