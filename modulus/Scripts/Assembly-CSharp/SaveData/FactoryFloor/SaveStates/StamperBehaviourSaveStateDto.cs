using Data.FactoryFloor;

namespace SaveData.FactoryFloor.SaveStates
{
	public class StamperBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public bool HasStampShape;

		public string[] OutputHashes;

		public InputBufferSaveData InputBufferSaveData;
	}
}
