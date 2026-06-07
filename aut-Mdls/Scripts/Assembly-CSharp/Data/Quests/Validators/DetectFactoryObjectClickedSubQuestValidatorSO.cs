using Data.FactoryFloor;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect FactoryObject Clicked", fileName = "DetectFactoryObjectClicked", order = 6)]
	public class DetectFactoryObjectClickedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private Vector3Int _position;

		[SerializeField]
		private OpenOperatorToolUsedOnPositionEvent _openOperatorToolUsedOnPositionEvent;

		private bool _objectClicked;

		private bool _initialized;

		public override bool IsValid()
		{
			if (_objectClicked)
			{
				return true;
			}
			if (!_initialized)
			{
				_initialized = true;
				_openOperatorToolUsedOnPositionEvent.Register(HandleOperatorOpened);
			}
			return false;
		}

		private void HandleOperatorOpened(Vector3Int clickedPosition)
		{
			FactoryObject objectAt = _factoryLayer.GetObjectAt(_position);
			FactoryObject objectAt2 = _factoryLayer.GetObjectAt(clickedPosition);
			_objectClicked = objectAt != null && objectAt2 != null && objectAt == objectAt2;
			if (_objectClicked)
			{
				_openOperatorToolUsedOnPositionEvent.UnRegister(HandleOperatorOpened);
			}
		}

		public override void Reset()
		{
			_openOperatorToolUsedOnPositionEvent.UnRegister(HandleOperatorOpened);
			_objectClicked = false;
			_initialized = false;
		}
	}
}
