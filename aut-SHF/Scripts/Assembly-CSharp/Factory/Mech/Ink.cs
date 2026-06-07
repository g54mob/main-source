using Factory.FieldData;

namespace Factory.Mech
{
	public class Ink : MechBase
	{
		private Extractor[] _aroundExtractors;

		private int AttachmentGetPlusCount;

		public override bool CheckRequirements(bool isUpgrade)
		{
			return false;
		}

		public Ink(Structure[] structures)
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

		public bool IsConnect(Extractor uptakeInkExtractor)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
