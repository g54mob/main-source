using System;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class CrossBridgeConveyer : MechBase
	{
		[Flags]
		public enum Connect
		{
			None = 0,
			R = 1,
			U = 2,
			L = 4,
			D = 8
		}

		private const int iRL = 0;

		private const int iUD = 1;

		private Connect _connect;

		private Structure rStr;

		private Structure lStr;

		private Structure uStr;

		private Structure dStr;

		private double AllConnector_SpeedUp;

		public override bool HasRotateSwitch => false;

		public override bool HasMultiOutputProduct => false;

		private bool HasConnect(Connect flag)
		{
			return false;
		}

		public CrossBridgeConveyer(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateCircuitData()
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		public override void SwitchRotate(StructureAddr addr)
		{
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
