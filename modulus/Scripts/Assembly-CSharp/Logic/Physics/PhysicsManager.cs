using Data.FactoryFloor;
using Events;
using Events.FactoryFloor;
using UnityEngine;

namespace Logic.Physics
{
	public class PhysicsManager : MonoBehaviour
	{
		[SerializeField]
		private BaseEvent _updatePhysics;

		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private FactoryObjectDeletedEvent _factoryObjectDeletedEvent;

		[SerializeField]
		private FactoryStepEvent _factoryStepEvent;

		private bool _physicsRequiresUpdate;

		private void Start()
		{
			_updatePhysics.Register(TriggerPhysicsUpdate);
			_createFactoryObjectEvent.Register(OnFactoryObjectCreated);
			_factoryObjectDeletedEvent.Register(OnFactoryObjectDeleted);
			_factoryStepEvent.RegisterMainThread(SyncPhysicsTransforms);
		}

		private void OnDestroy()
		{
			_updatePhysics.UnRegister(TriggerPhysicsUpdate);
			_createFactoryObjectEvent.UnRegister(OnFactoryObjectCreated);
			_factoryObjectDeletedEvent.UnRegister(OnFactoryObjectDeleted);
			_factoryStepEvent.UnRegisterMainThread(SyncPhysicsTransforms);
		}

		private void SyncPhysicsTransforms(int _)
		{
			UnityEngine.Physics.SyncTransforms();
		}

		private void FixedUpdate()
		{
			if (_physicsRequiresUpdate)
			{
				UnityEngine.Physics.Simulate(float.Epsilon);
				_physicsRequiresUpdate = false;
			}
		}

		private void TriggerPhysicsUpdate()
		{
			_physicsRequiresUpdate = true;
		}

		private void OnFactoryObjectCreated(CreateFactoryObjectDto _)
		{
			_physicsRequiresUpdate = true;
		}

		private void OnFactoryObjectDeleted((FactoryObject factoryObject, FactoryLayer factoryLayer) _)
		{
			_physicsRequiresUpdate = true;
		}
	}
}
