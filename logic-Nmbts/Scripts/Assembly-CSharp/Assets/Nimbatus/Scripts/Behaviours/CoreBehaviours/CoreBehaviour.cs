using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public abstract class CoreBehaviour
	{
		protected NimbatusBehaviour Behaviour;

		protected InteractiveWorldObject OwnWorldObject;

		public void Init(NimbatusBehaviour behaviour, InteractiveWorldObject worldObject)
		{
			Behaviour = behaviour;
			OwnWorldObject = worldObject;
			OnInit();
			OwnWorldObject.OnUpdate += OnUpdate;
			OwnWorldObject.OnFixedUpdate += OnFixedUpdate;
		}

		public void Release()
		{
			OwnWorldObject.OnUpdate -= OnUpdate;
			OwnWorldObject.OnFixedUpdate -= OnFixedUpdate;
			OnRelease();
		}

		protected virtual void OnUpdate()
		{
		}

		protected virtual void OnFixedUpdate()
		{
		}

		protected abstract void OnInit();

		protected abstract void OnRelease();
	}
}
