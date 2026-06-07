using Factory.FieldData;

namespace Factory
{
	public class ErasingInfo
	{
		public bool JustMoved;

		private double startTime;

		public bool prevStructureIsStream;

		public eMachine prevStructureMachine;

		public bool prevStructureIsRelocatable;

		public bool prevStructureUnbreakable;

		public bool prevStructureOnCheerMinion;

		private StructureGroupID _prevStructureGroup;

		public StructureGroupID PrevStructureGroup
		{
			get
			{
				return default(StructureGroupID);
			}
			set
			{
			}
		}

		public bool ChangeStructureGroup { get; private set; }

		private static bool EnableRemoveTimer => false;

		public bool EraseOkInstant => false;

		public bool EraseOkTimerFinished => false;

		public double Timer => 0.0;

		public double TimerMax => 0.0;

		public void ResetTimer()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
