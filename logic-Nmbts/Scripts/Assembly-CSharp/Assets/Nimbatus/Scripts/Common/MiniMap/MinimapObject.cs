using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.MiniMap
{
	public class MinimapObject : SerializedMonoBehaviour
	{
		public Texture2D Icon;

		public void Start()
		{
			if (BaseSingleton<Minimap>.Instance != null)
			{
				BaseSingleton<Minimap>.Instance.Register(this);
			}
		}

		public void OnDestroy()
		{
			if (BaseSingleton<Minimap>.Instance != null)
			{
				BaseSingleton<Minimap>.Instance.Unregister(this);
			}
		}
	}
}
