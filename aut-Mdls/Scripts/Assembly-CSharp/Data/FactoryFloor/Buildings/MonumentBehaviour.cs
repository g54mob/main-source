using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.Variables.Milestones;
using Events.UI.Overlays;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/MonumentBehaviour", fileName = "MonumentBehaviour", order = 0)]
	public class MonumentBehaviour : FactoryObjectBehaviour
	{
		[SerializeField]
		private MonumentBuiltVariableSO _monumentBuilt;

		[SerializeField]
		private MonumentBuiltEvent _monumentBuiltEvent;

		[SerializeField]
		private ReferenceObjectDatabase _referenceObjectDatabase;

		[Header("Notification details")]
		[SerializeField]
		private ShowIngameNotificationEvent _showIngameNotificationEvent;

		[SerializeField]
		private HideIngameNotificationEvent _hideIngameNotificationEvent;

		[SerializeField]
		[LocaKey]
		private string _notificationLocaKey;

		[SerializeField]
		[LocaKey]
		private string _buttonTextLocaKey;

		private bool _isActivated;

		private bool _hasShownNotification;

		private MonumentBuildingBehaviour _monumentBuildingBehaviour;

		public MainThreadEvent OnMonumentAllShapesReceived = new MainThreadEvent();

		public bool IsActivated => _isActivated;

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
		}

		public bool ReceivedAllShapes()
		{
			return _monumentBuildingBehaviour.AllRequirementsMet();
		}

		private void HandleMonumentAllShapesReceived()
		{
			throw new NotIncludedInDemoException();
		}

		private void OnNotificationButtonClicked()
		{
			if (_initialized)
			{
				ActivateMonument();
			}
		}

		private void HideNotification()
		{
			if (_hasShownNotification)
			{
				_hideIngameNotificationEvent.Fire(this);
				_hasShownNotification = false;
			}
		}

		public void ActivateMonument()
		{
			throw new NotIncludedInDemoException();
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			throw new NotIncludedInDemoException();
		}
	}
}
