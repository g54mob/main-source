using System.Collections.Generic;
using Factory.FieldData;

namespace Factory.Mech
{
	public class Mine : MechBase
	{
		private Extractor[] _aroundExtractors;

		private bool randomMode;

		private int AttachmentGetPlusCount;

		private Queue<int> shuffled;

		private int shuffleCycle;

		public override bool CheckRequirements(bool isUpgrade)
		{
			return false;
		}

		public Mine(Structure[] structures)
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

		public bool IsConnect(Extractor drawmotiefExtractor)
		{
			return false;
		}

		public eLuggage GetProduct()
		{
			return default(eLuggage);
		}

		public override string ToString()
		{
			return null;
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
