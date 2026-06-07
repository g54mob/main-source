using System.Collections.Generic;
using LitJson;

namespace Gh.Tk.Story
{
	public class ActiveStory : IPersistable, IDataStore, IReferenceableObject
	{
		[JsonIgnore]
		private StoryNode _cachedNode;

		private DataStore _data;

		private List<string> _stickyDataKeys;

		[PersistenceObjectReference]
		public List<Actor> TargetActors { get; set; }

		[PersistenceObjectReference]
		public List<ActorData> TargetActorDataFallbacks { get; set; }

		[PersistenceObjectReference]
		public List<Prop> TargetProps { get; set; }

		public int Id { get; private set; }

		public string SourceNodeId { get; private set; }

		internal bool IsActive { get; set; }

		[JsonIgnore]
		public StoryNode StoryNode => null;

		[JsonIgnore]
		public DataStore ContextDataStore
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		static ActiveStory()
		{
		}

		private static void Actor_ActorSpawned(object sender, EventArgs<Actor> e)
		{
		}

		private void OnTargetActorSpawned(Actor actor)
		{
		}

		private static void Actor_ActorDespawned(object sender, EventArgs<Actor> e)
		{
		}

		protected ActiveStory()
		{
		}

		public ActiveStory(StoryNode node)
		{
		}

		public ActiveStory(StoryNode node, ActiveStory parentNode)
		{
		}

		public void SetTargetProp(Prop prop)
		{
		}

		public void SetTargetActor(Actor actor)
		{
		}

		private void TransferDataFromParentNode(ActiveStory parentNode)
		{
		}

		internal void Complete()
		{
		}

		public void AddStoryPermanentDataKey(string key)
		{
		}

		public void RemoveStoryPermanentDataKey(string key)
		{
		}

		public bool WasCreatedByChaosEvent()
		{
			return false;
		}

		public bool HasValue(string key)
		{
			return false;
		}

		public void SetValue(string key, object value)
		{
		}

		public T GetValue<T>(string key)
		{
			return default(T);
		}

		public T GetOrSetValue<T>(string key, T fallback)
		{
			return default(T);
		}

		public void RemoveValue(string key)
		{
		}

		public IDataStore CreateSubEntry(string key)
		{
			return null;
		}

		public void ResetTargetActors()
		{
		}
	}
}
