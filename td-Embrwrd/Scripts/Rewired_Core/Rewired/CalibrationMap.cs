using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class CalibrationMap
	{
		public struct InitOptions
		{
			[CompilerGenerated]
			private IList<AxisCalibration> LxCGkccBkYlisbTPsRFInoEOirUUA;

			[CompilerGenerated]
			private IList<Axis2DCalibration> WWQOWnVcapqxHYHGvhFiXatefqXE;

			public IList<AxisCalibration> axisCalibrations
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				internal set
				{
				}
			}

			public IList<Axis2DCalibration> axis2DCalibrations
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				internal set
				{
				}
			}
		}

		private AxisCalibration[] YbNIqmifqBxhSqpqziuRpCxbdFwlA;

		private MappedArray<AxisCalibration> qpMNiDdFdQyAWzPLslMGyHPqMRDy;

		private Axis2DCalibration[] EjGdDmcFGozIyvSETgSPcdkjVOGEB;

		private IList<AxisCalibration> mndVZtUANZuPrcQiwbZOfpqldULg;

		private IList<Axis2DCalibration> bXlGIEIkEIRVTwnwYDCYapHdEDFsA;

		private readonly int DuQgJNziTeTggpFYtuqjbTtKQrFT;

		public IList<AxisCalibration> Axes => null;

		public int axisCount => 0;

		public IList<Axis2DCalibration> Axes2D => null;

		public int axis2DCount => 0;

		private CalibrationMap()
		{
		}

		internal CalibrationMap(AxisCalibrationData[] P_0, Axis2DCalibrationData[] P_1, Func<int, int> P_2)
		{
		}

		[Obsolete("Use CalibrationMap(InitOptions) overload instead.", false)]
		public CalibrationMap(AxisCalibration[] P_0)
		{
		}

		public CalibrationMap(InitOptions P_0)
		{
		}

		public void Reset()
		{
		}

		public AxisCalibration GetAxis(int index)
		{
			return null;
		}

		public Axis2DCalibration GetAxis2D(int index)
		{
			return null;
		}

		public float GetCalibratedValue(int axisIndex, float value)
		{
			return 0f;
		}

		public Vector2 GetCalibratedValue2D(int axis2DIndex, int xAxisIndex, int yAxisIndex, Vector2 value)
		{
			return default(Vector2);
		}

		public bool SetAxisData(int index, AxisCalibrationData data)
		{
			return false;
		}

		public bool SetAxis2DData(int index, Axis2DCalibrationData data)
		{
			return false;
		}

		public AxisCalibrationData GetAxisData(int index)
		{
			return default(AxisCalibrationData);
		}

		public Axis2DCalibrationData GetAxis2DData(int index)
		{
			return default(Axis2DCalibrationData);
		}

		internal void CopyFrom(CalibrationMap map, bool copyHardwareDeadzone)
		{
		}

		public string ToXmlString()
		{
			return null;
		}

		public string ToJsonString()
		{
			return null;
		}

		public bool ImportXmlString(string xmlString)
		{
			return false;
		}

		public bool ImportJsonString(string jsonString)
		{
			return false;
		}

		private SerializedObject VeXHJhoKwadmQUwnEuvqUHAVNVMm()
		{
			return null;
		}

		private void FmZevLdfKRiZhmOOoDXZxxoRsmaQ(SerializedObject P_0)
		{
		}
	}
}
