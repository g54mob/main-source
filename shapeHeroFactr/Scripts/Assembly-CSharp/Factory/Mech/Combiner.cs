using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class Combiner : MechBase
	{
		public enum CombinerMode
		{
			Square11 = 0,
			Rectangle12 = 1,
			Error = 2
		}

		public CombinerMode _mode;

		private Structure[] _fromStrs;

		private StructureAddr[] _entranceAddrs;

		private int in1st;

		private int in2nd;

		private int in3rd;

		private double AllConnector_SpeedUp;

		private Structure Output => null;

		public override bool HasToggleSwitch => false;

		public override int InputPriorityCount => 0;

		public override StructureAddr? InputPriorityFromAddr => null;

		public override bool IsSerialize => false;

		public Combiner(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToMinimum()
		{
			return null;
		}

		public override string ToDump()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		public override void SwitchToggle()
		{
		}

		public override void SetIntArray(int[] array)
		{
		}

		public override int[] GetIntArray()
		{
			return null;
		}
	}
}
