using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Cutter Interval", fileName = "DetectCutterInterval", order = 17)]
	public class DetectCutterConfiguredIntervalSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private Vector3Int _position;

		[SerializeField]
		[Range(1f, 4f)]
		private int _requiredInterval;

		private CutterBehaviour _cutterBehaviour;

		public override bool IsValid()
		{
			if (_cutterBehaviour == null)
			{
				_cutterBehaviour = _factoryLayer.GetObjectAt(_position)?.GetFactoryObjectBehaviour<CutterBehaviour>();
			}
			if (_cutterBehaviour == null || !_cutterBehaviour.IsConfigured)
			{
				return false;
			}
			return _cutterBehaviour.CutInterval == _requiredInterval;
		}

		public override void Reset()
		{
			_cutterBehaviour = null;
		}
	}
}
