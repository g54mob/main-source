using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Runtime Vars/Get Runtime GameObjects")]
	public class GetRuntimeGameObjects : MonoBehaviour
	{
		[RequiredField]
		public RuntimeGameObjects Collection;

		public FloatReference delay = new FloatReference();

		public RuntimeSetTypeGameObject type = RuntimeSetTypeGameObject.Random;

		[Hide("showIndex", false)]
		public int Index;

		[Hide("showName", false)]
		public string m_name;

		public GameObjectEvent Raise = new GameObjectEvent();

		public GameObjectEvent OnItemAdded = new GameObjectEvent();

		public GameObjectEvent OnItemRemoved = new GameObjectEvent();

		[HideInInspector]
		public bool showIndex;

		[HideInInspector]
		public bool showName;

		public void SetCollection(RuntimeGameObjects col)
		{
			Collection = col;
		}

		private void OnEnable()
		{
			if ((float)delay > 0f)
			{
				Invoke("GetSet", delay);
			}
			else
			{
				this.Delay_Action(delegate
				{
					GetSet();
				});
			}
			if (Collection != null)
			{
				Collection.OnItemAdded.AddListener(ItemAdded);
				Collection.OnItemRemoved.AddListener(ItemRemoved);
			}
		}

		private void OnDisable()
		{
			if (Collection != null)
			{
				Collection.OnItemAdded.RemoveListener(ItemAdded);
				Collection.OnItemRemoved.RemoveListener(ItemRemoved);
			}
		}

		private void ItemAdded(GameObject item)
		{
			OnItemAdded.Invoke(item);
		}

		private void ItemRemoved(GameObject item)
		{
			OnItemRemoved.Invoke(item);
		}

		private void GetSet()
		{
			if (Collection != null)
			{
				Raise.Invoke(Collection.GetItem(type, Index, base.name, base.gameObject));
			}
		}

		private void OnValidate()
		{
			showIndex = type == RuntimeSetTypeGameObject.Index;
			showName = type == RuntimeSetTypeGameObject.ByName;
		}
	}
}
