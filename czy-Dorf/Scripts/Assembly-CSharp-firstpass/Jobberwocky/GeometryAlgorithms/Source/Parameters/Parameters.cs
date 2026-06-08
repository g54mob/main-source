using Jobberwocky.GeometryAlgorithms.Source.Core;

namespace Jobberwocky.GeometryAlgorithms.Source.Parameters
{
	public abstract class Parameters : IParameters
	{
		private CoordinateSystem _003CCoordinateSystem_003Ek__BackingField;

		public CoordinateSystem CoordinateSystem
		{
			get
			{
				return _003CCoordinateSystem_003Ek__BackingField;
			}
			set
			{
				_003CCoordinateSystem_003Ek__BackingField = value;
			}
		}

		public Parameters()
		{
			CoordinateSystem = CoordinateSystem.XYZ;
		}
	}
}
