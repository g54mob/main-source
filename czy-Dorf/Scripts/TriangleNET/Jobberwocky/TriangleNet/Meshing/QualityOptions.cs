using System;
using Jobberwocky.TriangleNet.Geometry;

namespace Jobberwocky.TriangleNet.Meshing
{
	public class QualityOptions
	{
		private double _003CMaximumAngle_003Ek__BackingField;

		private double _003CMinimumAngle_003Ek__BackingField;

		private double _003CMaximumArea_003Ek__BackingField;

		private Func<ITriangle, double, bool> _003CUserTest_003Ek__BackingField;

		private bool _003CVariableArea_003Ek__BackingField;

		private int _003CSteinerPoints_003Ek__BackingField;

		public double MaximumAngle => _003CMaximumAngle_003Ek__BackingField;

		public double MinimumAngle => _003CMinimumAngle_003Ek__BackingField;

		public double MaximumArea => _003CMaximumArea_003Ek__BackingField;

		public Func<ITriangle, double, bool> UserTest => _003CUserTest_003Ek__BackingField;

		public bool VariableArea => _003CVariableArea_003Ek__BackingField;

		public int SteinerPoints => _003CSteinerPoints_003Ek__BackingField;
	}
}
