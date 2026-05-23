using Data.FactoryFloor;

namespace SaveData.FactoryFloor.SaveStates
{
	public class StamperMK2BehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public bool HasStampShape;

		public string[] OutputHashes;

		public InputBufferSaveData InputBufferSaveData;
	}
}
