using UnityEngine;

namespace HumanAPI
{
	public abstract class LevelObject : MonoBehaviour
	{
		protected Level level;

		protected bool active
		{
			get
			{
				if (level == null)
				{
					level = GetComponentInParent<Level>();
				}
				return base.enabled && level.active && base.gameObject.activeInHierarchy;
			}
		}

		protected virtual void OnEnable()
		{
			level = GetComponentInParent<Level>();
			if (level == null)
			{
				Debug.LogError("LevelObject must be placed in a level");
			}
		}
	}
}
