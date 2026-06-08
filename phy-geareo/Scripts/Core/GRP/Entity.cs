using Rhizomatic;
using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;

namespace GRP
{
	public class Entity : Thing, IExpositorUI
	{
		[JsonDataState(null)]
		public State<string> name;

		public EntityManager manager { get; private set; }

		public Id id { get; private set; }

		public new EntityConfig config => null;

		protected virtual void OnCreated()
		{
		}

		protected virtual void OnReady()
		{
		}

		protected virtual void OnDestroyed()
		{
		}

		public void _Created(EntityManager manager, Id id)
		{
		}

		public void _Ready()
		{
		}

		public void _Destroyed()
		{
		}

		public virtual void OnExpositorUI(ImUIBuilder ui)
		{
		}

		protected virtual void Save(JsonData data)
		{
		}

		protected virtual void Load(JsonData data)
		{
		}

		public EntityData Serialize()
		{
			return null;
		}

		public void Deserialize(EntityData data)
		{
		}
	}
	public class Entity<T> : Entity where T : EntityConfig
	{
		public new T config => null;
	}
}
