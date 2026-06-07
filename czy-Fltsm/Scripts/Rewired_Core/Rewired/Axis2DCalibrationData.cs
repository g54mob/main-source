namespace Rewired
{
	public struct Axis2DCalibrationData
	{
		private DeadZone2DType FcDouApGUGHZHtuFOzBxEvVGpOld;

		private AxisSensitivity2DType fJcTXVyNbBofvUnlBsWUzrXCCQUN;

		private Axis2DClampType IUSsMUCDOMNtSZRgjTLhYYYyyjte;

		public DeadZone2DType deadZoneType
		{
			get
			{
				return FcDouApGUGHZHtuFOzBxEvVGpOld;
			}
			set
			{
				FcDouApGUGHZHtuFOzBxEvVGpOld = value;
			}
		}

		public AxisSensitivity2DType sensitivityType
		{
			get
			{
				return fJcTXVyNbBofvUnlBsWUzrXCCQUN;
			}
			set
			{
				fJcTXVyNbBofvUnlBsWUzrXCCQUN = value;
			}
		}

		public Axis2DClampType clampType
		{
			get
			{
				return IUSsMUCDOMNtSZRgjTLhYYYyyjte;
			}
			set
			{
				IUSsMUCDOMNtSZRgjTLhYYYyyjte = value;
			}
		}

		internal Axis2DCalibrationData(DeadZone2DType P_0, AxisSensitivity2DType P_1, Axis2DClampType P_2)
		{
			FcDouApGUGHZHtuFOzBxEvVGpOld = P_0;
			fJcTXVyNbBofvUnlBsWUzrXCCQUN = P_1;
			IUSsMUCDOMNtSZRgjTLhYYYyyjte = P_2;
		}
	}
}
