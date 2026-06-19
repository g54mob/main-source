using Pug.Properties;
using Unity.Entities;
using UnityEngine;

namespace PugMod
{
	public interface IAuthoring
	{
		public delegate void ObjectTypeAdded(Entity entity, GameObject authoringData, EntityManager entityManager);

		PropertyLookup.Enum<ObjectID> ObjectProperties { get; }

		event ObjectTypeAdded OnObjectTypeAdded;

		void RegisterAuthoringGameObject(GameObject authoringGameObject);

		void DeregisterAuthoringGameObject(GameObject authoringGameObject);

		ObjectID GetObjectID(string name);
	}
}
