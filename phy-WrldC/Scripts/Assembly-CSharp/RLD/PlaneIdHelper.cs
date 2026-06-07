using System.Collections.Generic;

namespace RLD
{
	public static class PlaneIdHelper
	{
		private struct PlaneQuadrantInfo
		{
			public PlaneQuadrantId Quadrant;

			public AxisSign FirstAxisSign;

			public AxisSign SecondAxisSign;
		}

		private struct PlaneInfo
		{
			public PlaneId PlaneId;

			public List<PlaneQuadrantInfo> QuadrantInfo;
		}

		private static List<PlaneInfo> _planeInfo;

		private static PlaneId[] _allPlaneIds;

		public static PlaneId[] AllPlaneIds => _allPlaneIds.Clone() as PlaneId[];

		static PlaneIdHelper()
		{
			_planeInfo = new List<PlaneInfo>(3)
			{
				default(PlaneInfo),
				default(PlaneInfo),
				default(PlaneInfo)
			};
			_allPlaneIds = new PlaneId[3]
			{
				PlaneId.XY,
				PlaneId.ZX,
				PlaneId.YZ
			};
			PlaneInfo value = new PlaneInfo
			{
				PlaneId = PlaneId.XY,
				QuadrantInfo = new List<PlaneQuadrantInfo>
				{
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.First,
						FirstAxisSign = AxisSign.Positive,
						SecondAxisSign = AxisSign.Positive
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Second,
						FirstAxisSign = AxisSign.Negative,
						SecondAxisSign = AxisSign.Positive
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Third,
						FirstAxisSign = AxisSign.Negative,
						SecondAxisSign = AxisSign.Negative
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Fourth,
						FirstAxisSign = AxisSign.Positive,
						SecondAxisSign = AxisSign.Negative
					}
				}
			};
			_planeInfo[0] = value;
			value = new PlaneInfo
			{
				PlaneId = PlaneId.YZ,
				QuadrantInfo = new List<PlaneQuadrantInfo>
				{
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.First,
						FirstAxisSign = AxisSign.Positive,
						SecondAxisSign = AxisSign.Negative
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Second,
						FirstAxisSign = AxisSign.Positive,
						SecondAxisSign = AxisSign.Positive
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Third,
						FirstAxisSign = AxisSign.Negative,
						SecondAxisSign = AxisSign.Positive
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Fourth,
						FirstAxisSign = AxisSign.Negative,
						SecondAxisSign = AxisSign.Negative
					}
				}
			};
			_planeInfo[1] = value;
			value = new PlaneInfo
			{
				PlaneId = PlaneId.ZX,
				QuadrantInfo = new List<PlaneQuadrantInfo>
				{
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.First,
						FirstAxisSign = AxisSign.Positive,
						SecondAxisSign = AxisSign.Positive
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Second,
						FirstAxisSign = AxisSign.Negative,
						SecondAxisSign = AxisSign.Positive
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Third,
						FirstAxisSign = AxisSign.Negative,
						SecondAxisSign = AxisSign.Negative
					},
					new PlaneQuadrantInfo
					{
						Quadrant = PlaneQuadrantId.Fourth,
						FirstAxisSign = AxisSign.Positive,
						SecondAxisSign = AxisSign.Negative
					}
				}
			};
			_planeInfo[2] = value;
		}

		public static AxisDescriptor GetFirstAxisDescriptor(PlaneId planeId, PlaneQuadrantId planeQuadrant)
		{
			return new AxisDescriptor(PlaneIdToFirstAxisIndex(planeId), GetFirstAxisSign(planeId, planeQuadrant));
		}

		public static AxisDescriptor GetSecondAxisDescriptor(PlaneId planeId, PlaneQuadrantId planeQuadrant)
		{
			return new AxisDescriptor(PlaneIdToSecondAxisIndex(planeId), GetSecondAxisSign(planeId, planeQuadrant));
		}

		public static AxisSign GetFirstAxisSign(PlaneId planeId, PlaneQuadrantId planeQuadrant)
		{
			return _planeInfo[(int)planeId].QuadrantInfo.FindAll((PlaneQuadrantInfo item) => item.Quadrant == planeQuadrant)[0].FirstAxisSign;
		}

		public static AxisSign GetSecondAxisSign(PlaneId planeId, PlaneQuadrantId planeQuadrant)
		{
			return _planeInfo[(int)planeId].QuadrantInfo.FindAll((PlaneQuadrantInfo item) => item.Quadrant == planeQuadrant)[0].SecondAxisSign;
		}

		public static PlaneQuadrantId GetQuadrantFromAxesSigns(PlaneId planeId, AxisSign firstAxisSign, AxisSign secondAxisSign)
		{
			return _planeInfo[(int)planeId].QuadrantInfo.FindAll((PlaneQuadrantInfo item) => item.FirstAxisSign == firstAxisSign && item.SecondAxisSign == secondAxisSign)[0].Quadrant;
		}

		public static int PlaneIdToFirstAxisIndex(PlaneId planeId)
		{
			switch (planeId)
			{
			case PlaneId.XY:
				return 0;
			case PlaneId.ZX:
				return 2;
			default:
				return 1;
			}
		}

		public static int PlaneIdToSecondAxisIndex(PlaneId planeId)
		{
			switch (planeId)
			{
			case PlaneId.XY:
				return 1;
			case PlaneId.ZX:
				return 0;
			default:
				return 2;
			}
		}

		public static PlaneId NormalAxisIndexToPlaneId(int axisIndex)
		{
			switch (axisIndex)
			{
			case 0:
				return PlaneId.YZ;
			case 1:
				return PlaneId.ZX;
			default:
				return PlaneId.XY;
			}
		}
	}
}
