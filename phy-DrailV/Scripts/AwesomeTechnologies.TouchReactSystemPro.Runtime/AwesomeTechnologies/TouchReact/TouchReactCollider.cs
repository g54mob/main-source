using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.TouchReact
{
	[ExecuteInEditMode]
	public class TouchReactCollider : MonoBehaviour
	{
		public List<TouchColliderInfo> ColliderList = new List<TouchColliderInfo>();

		public bool AddChildColliders = true;

		public float ColliderScale = 1f;

		private void Awake()
		{
			ColliderList.Clear();
		}

		private void Start()
		{
			AddCollidersToManager();
		}

		private void OnEnable()
		{
			AddCollidersToManager();
		}

		private void OnDisable()
		{
			RemoveCollidersFromManager();
		}

		public void RefreshColliders()
		{
			RemoveCollidersFromManager();
			AddCollidersToManager();
		}

		private void AddCollidersToManager()
		{
			Collider[] array = (AddChildColliders ? base.gameObject.GetComponentsInChildren<Collider>() : base.gameObject.GetComponents<Collider>());
			foreach (Collider collider in array)
			{
				if (!(collider is TerrainCollider))
				{
					TouchColliderInfo touchColliderInfo = new TouchColliderInfo
					{
						Collider = collider,
						Scale = ColliderScale
					};
					ColliderList.Add(touchColliderInfo);
					TouchReactSystem.AddCollider(touchColliderInfo);
				}
			}
		}

		private void RemoveCollidersFromManager()
		{
			for (int i = 0; i <= ColliderList.Count - 1; i++)
			{
				TouchReactSystem.RemoveCollider(ColliderList[i]);
			}
			ColliderList.Clear();
		}
	}
}
