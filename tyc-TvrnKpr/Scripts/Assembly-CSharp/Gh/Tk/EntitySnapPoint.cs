using UnityEngine;

namespace Gh.Tk
{
	[DisallowMultipleComponent]
	[PersistenceOptIn]
	public class EntitySnapPoint : MonoBehaviour, IPersistable
	{
		[HideInInspector]
		public string Id;

		private void Start()
		{
		}

		public void Init()
		{
		}
	}
}
