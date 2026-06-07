using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int hvKCFMzvCzWDGRowpBUVDwCadGpe;

		private ControllerType krchgDbbQmodDxrAEVQfGwyDJgGPA;

		private Guid IPBFsHnNHocYrnVNRiciLfdyjeDs;

		private string JWcMQkNsbGlnWlfvXRiOSjEYJnSD;

		private Guid JeWTIYyHdanvbMIJzdriTxpQpfVT;

		public int controllerId
		{
			get
			{
				return hvKCFMzvCzWDGRowpBUVDwCadGpe;
			}
			set
			{
				hvKCFMzvCzWDGRowpBUVDwCadGpe = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return krchgDbbQmodDxrAEVQfGwyDJgGPA;
			}
			set
			{
				krchgDbbQmodDxrAEVQfGwyDJgGPA = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return IPBFsHnNHocYrnVNRiciLfdyjeDs;
			}
			set
			{
				IPBFsHnNHocYrnVNRiciLfdyjeDs = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return JWcMQkNsbGlnWlfvXRiOSjEYJnSD;
			}
			set
			{
				JWcMQkNsbGlnWlfvXRiOSjEYJnSD = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return JeWTIYyHdanvbMIJzdriTxpQpfVT;
			}
			set
			{
				JeWTIYyHdanvbMIJzdriTxpQpfVT = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			hvKCFMzvCzWDGRowpBUVDwCadGpe = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			hvKCFMzvCzWDGRowpBUVDwCadGpe = P_0.id;
			krchgDbbQmodDxrAEVQfGwyDJgGPA = P_0.type;
			IPBFsHnNHocYrnVNRiciLfdyjeDs = P_0.sfymSjcVHxtWxMcRdJtqvPLgjYLfA;
			JWcMQkNsbGlnWlfvXRiOSjEYJnSD = P_0.hardwareIdentifier;
			JeWTIYyHdanvbMIJzdriTxpQpfVT = P_0.deviceInstanceGuid;
		}
	}
}
