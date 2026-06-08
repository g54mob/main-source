namespace Rewired
{
	public class CalibrationMapSaveData
	{
		private CalibrationMap RMiGlLhiyrjxSVHCwSWbjBQAeDCP;

		private ControllerType fkEwyowpQQKzBaGTBxLUNmLjHtN;

		private string EtZEzXBEhDpEDIEXlPJaGlvBfAuA;

		public CalibrationMap map => RMiGlLhiyrjxSVHCwSWbjBQAeDCP;

		public ControllerType controllerType => fkEwyowpQQKzBaGTBxLUNmLjHtN;

		public string hardwareIdentifier => EtZEzXBEhDpEDIEXlPJaGlvBfAuA;

		public CalibrationMapSaveData(CalibrationMap calibrationMap, ControllerType controllerType, string hardwareIdentifier)
		{
			while (true)
			{
				int num = 534988631;
				while (true)
				{
					switch (num ^ 0x1FE34756)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						RMiGlLhiyrjxSVHCwSWbjBQAeDCP = calibrationMap;
						fkEwyowpQQKzBaGTBxLUNmLjHtN = controllerType;
						num = 534988630;
						continue;
					case 0:
						EtZEzXBEhDpEDIEXlPJaGlvBfAuA = hardwareIdentifier;
						num = 534988629;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}
	}
}
