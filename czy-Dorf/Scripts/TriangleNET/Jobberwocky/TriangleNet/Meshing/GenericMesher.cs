using Jobberwocky.TriangleNet.Geometry;
using Jobberwocky.TriangleNet.Meshing.Algorithm;

namespace Jobberwocky.TriangleNet.Meshing
{
	public class GenericMesher
	{
		private Configuration config;

		private ITriangulator triangulator;

		public GenericMesher()
			: this(new Dwyer(), new Configuration())
		{
		}

		public GenericMesher(ITriangulator triangulator, Configuration config)
		{
			this.config = config;
			this.triangulator = triangulator;
		}

		public IMesh Triangulate(IPolygon polygon, ConstraintOptions options)
		{
			return Triangulate(polygon, options, null);
		}

		public IMesh Triangulate(IPolygon polygon, ConstraintOptions options, QualityOptions quality)
		{
			Mesh mesh = (Mesh)triangulator.Triangulate(polygon.Points, config);
			ConstraintMesher constraintMesher = new ConstraintMesher(mesh, config);
			QualityMesher qualityMesher = new QualityMesher(mesh, config);
			mesh.SetQualityMesher(qualityMesher);
			constraintMesher.Apply(polygon, options);
			qualityMesher.Apply(quality);
			return mesh;
		}
	}
}
