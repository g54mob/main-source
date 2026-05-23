using Data.Buildings;
using Data.FactoryFloor;
using Data.FactoryFloor.Buildings;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementAnyMonumentBuiltSO", menuName = "Story/StoryElementAnyMonumentBuiltSO")]
	public class StoryElementAnyMonumentBuiltSO : StoryElementSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private int _monumentsCountRequired;

		[SerializeField]
		private MonumentFinishedActivationAnimEvent _monumentFinishedActivationAnimEventSO;

		public override void Initialize()
		{
			_monumentFinishedActivationAnimEventSO.Register(OnMonumentFinishedActivationAnim);
		}

		public override void Destroy()
		{
			_monumentFinishedActivationAnimEventSO.UnRegister(OnMonumentFinishedActivationAnim);
		}

		private void OnMonumentFinishedActivationAnim(MonumentBehaviour monumentBehaviour)
		{
			CheckForExistingMonuments();
		}

		private void CheckForExistingMonuments()
		{
			int num = 0;
			foreach (FactoryObject allDistinctObjectList in _factoryLayer.GetAllDistinctObjectLists())
			{
				if (allDistinctObjectList.HasFactoryObjectBehaviour(out BuildingBehaviour behaviour) && behaviour is MonumentBuildingBehaviour)
				{
					num++;
					if (num >= _monumentsCountRequired)
					{
						TryExecute();
					}
				}
			}
		}
	}
}
