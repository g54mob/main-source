using UnityEngine;

namespace Aggro.Core
{
	public abstract class SceneIdentifiableBase : EntityBehaviourBase, ISceneIdentifiable
	{
		[SerializeField]
		private SceneIdentifier _sceneIdentifier;

		public bool showSceneId
		{
			get
			{
				if (base.gameObject.scene.IsValid() && _sceneIdentifier.database != null)
				{
					return _sceneIdentifier.database.gameObject.scene.handle == base.gameObject.scene.handle;
				}
				return false;
			}
		}

		protected virtual void MonoBehaviourOnValidate()
		{
		}

		private void OnValidate()
		{
			MonoBehaviourOnValidate();
		}

		public string GetSceneId()
		{
			if (base.gameObject.scene.IsValid() && _sceneIdentifier.database != null)
			{
				return _sceneIdentifier.guid;
			}
			return "";
		}
	}
}
