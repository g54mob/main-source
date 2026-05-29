using System.Collections.Generic;
using Factory.FieldData;

namespace Factory.Mech
{
	public class RecycleBox : MechBase
	{
		private MechBase fromMech;

		private RecycleFacility toRecycleFacility;

		private double RecycleBoxEfficiency;

		private bool _includeParts;

		private Dictionary<eLuggage, int> sourceDB;

		private int recycleCounter;

		private eLuggage BlendId
		{
			get
			{
				return default(eLuggage);
			}
			set
			{
			}
		}

		public override List<MachineInformation.CollectItemInfo> GetCollectItemInfos => null;

		public override double Efficiency => 0.0;

		public RecycleBox(Structure[] structures)
			: base(null)
		{
		}

		public override void Vanish()
		{
		}

		public override string ToString()
		{
			return null;
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

		public override void Update(double deltaTime)
		{
		}

		private int GetCount(int i)
		{
			return 0;
		}

		private void AddCount(int i, int value)
		{
		}

		private void ClearCounter()
		{
		}

		public void CountRecycle(BlendState blendState)
		{
		}

		private void PlayAnimation(bool play)
		{
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
