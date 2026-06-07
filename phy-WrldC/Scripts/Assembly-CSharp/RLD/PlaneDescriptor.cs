namespace RLD
{
	public struct PlaneDescriptor
	{
		private PlaneId _id;

		private PlaneQuadrantId _quadrant;

		private AxisDescriptor _firstAxisDescriptor;

		private AxisDescriptor _secondAxisDescriptor;

		public PlaneId Id => _id;

		public PlaneQuadrantId Quadrant => _quadrant;

		public AxisSign FirstAxisSign => _firstAxisDescriptor.Sign;

		public AxisSign SecondAxisSign => _secondAxisDescriptor.Sign;

		public int FirstAxisIndex => _firstAxisDescriptor.Index;

		public int SecondAxisIndex => _secondAxisDescriptor.Index;

		public AxisDescriptor FirstAxisDescriptor => _firstAxisDescriptor;

		public AxisDescriptor SecondAxisDescriptor => _secondAxisDescriptor;

		public PlaneDescriptor(PlaneId planeId, PlaneQuadrantId planeQuadrant)
		{
			_id = planeId;
			_quadrant = planeQuadrant;
			_firstAxisDescriptor = PlaneIdHelper.GetFirstAxisDescriptor(planeId, planeQuadrant);
			_secondAxisDescriptor = PlaneIdHelper.GetSecondAxisDescriptor(planeId, planeQuadrant);
		}
	}
}
