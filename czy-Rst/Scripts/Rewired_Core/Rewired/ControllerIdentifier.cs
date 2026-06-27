using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int cvkLHofBfggKOBLxrPggDDOPJNdM;

		private ControllerType vJWgjajoAnBxZhzHSDILbcOFoKIXB;

		private Guid ZMzQncxVIbmwphAOHywMRFsFSBPE;

		private string StQDbXDccLkfQvGsTeTwdYPlJvAGA;

		private Guid KGwVJfmhhtixxhQKpajOpRFbGLTDb;

		public int controllerId
		{
			get
			{
				return cvkLHofBfggKOBLxrPggDDOPJNdM;
			}
			set
			{
				cvkLHofBfggKOBLxrPggDDOPJNdM = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return vJWgjajoAnBxZhzHSDILbcOFoKIXB;
			}
			set
			{
				vJWgjajoAnBxZhzHSDILbcOFoKIXB = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return ZMzQncxVIbmwphAOHywMRFsFSBPE;
			}
			set
			{
				ZMzQncxVIbmwphAOHywMRFsFSBPE = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return StQDbXDccLkfQvGsTeTwdYPlJvAGA;
			}
			set
			{
				StQDbXDccLkfQvGsTeTwdYPlJvAGA = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return KGwVJfmhhtixxhQKpajOpRFbGLTDb;
			}
			set
			{
				KGwVJfmhhtixxhQKpajOpRFbGLTDb = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			cvkLHofBfggKOBLxrPggDDOPJNdM = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			cvkLHofBfggKOBLxrPggDDOPJNdM = P_0.id;
			vJWgjajoAnBxZhzHSDILbcOFoKIXB = P_0.type;
			ZMzQncxVIbmwphAOHywMRFsFSBPE = P_0.lcQyDEaPLwhlbiUKrOtQaptBTwRjc;
			StQDbXDccLkfQvGsTeTwdYPlJvAGA = P_0.hardwareIdentifier;
			KGwVJfmhhtixxhQKpajOpRFbGLTDb = P_0.deviceInstanceGuid;
		}
	}
}
