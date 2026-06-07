using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Collections/Runtime GameObject Set", order = 1000, fileName = "New Runtime Gameobject Collection")]
	public class RuntimeGameObjects : RuntimeCollection<GameObject>
	{
		public GameObjectEvent OnItemAdded = new GameObjectEvent();

		public GameObjectEvent OnItemRemoved = new GameObjectEvent();

		public GameObject Item_GetClosest(GameObject origin)
		{
			GameObject result = null;
			items.RemoveAll((GameObject x) => x == null);
			float num = float.MaxValue;
			foreach (GameObject item in items)
			{
				float num2 = Vector3.Distance(item.transform.position, origin.transform.position);
				if (num2 < num)
				{
					result = item;
					num = num2;
				}
			}
			return result;
		}

		protected override void OnAddEvent(GameObject newItem)
		{
			OnItemAdded.Invoke(newItem);
		}

		protected override void OnRemoveEvent(GameObject newItem)
		{
			OnItemRemoved.Invoke(newItem);
		}

		public void Item_Add(Component newItem)
		{
			Item_Add(newItem.gameObject);
		}

		public void Item_Remove(Component newItem)
		{
			Item_Remove(newItem.gameObject);
		}

		public GameObject GetItem(RuntimeSetTypeGameObject type, int Index = 0, string m_name = "", GameObject origin = null)
		{
			if (base.IsEmpty)
			{
				return null;
			}
			return type switch
			{
				RuntimeSetTypeGameObject.First => Item_GetFirst(), 
				RuntimeSetTypeGameObject.Random => Item_GetRandom(), 
				RuntimeSetTypeGameObject.Index => Item_Get(Index), 
				RuntimeSetTypeGameObject.ByName => Item_Get(m_name), 
				RuntimeSetTypeGameObject.Closest => Item_GetClosest(origin), 
				_ => null, 
			};
		}
	}
}
