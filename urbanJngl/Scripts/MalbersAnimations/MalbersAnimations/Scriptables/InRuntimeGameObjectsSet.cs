using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Runtime Vars/In Runtime GameObjects Set")]
	public class InRuntimeGameObjectsSet : MonoBehaviour
	{
		[RequiredField]
		public RuntimeGameObjects Collection;

		public UnityEvent AddedToSet = new UnityEvent();

		public UnityEvent RemovedFromSet = new UnityEvent();

		private void OnEnable()
		{
			if (Collection != null)
			{
				Collection.OnItemRemoved.AddListener(OnItemAdded);
				Collection.OnItemRemoved.AddListener(OnItemRemoved);
			}
		}

		private void OnDisable()
		{
			if (Collection != null)
			{
				Collection.OnItemRemoved.RemoveListener(OnItemAdded);
				Collection.OnItemRemoved.RemoveListener(OnItemRemoved);
			}
		}

		private void OnItemRemoved(GameObject arg0)
		{
			if (arg0 == base.gameObject)
			{
				RemovedFromSet.Invoke();
			}
		}

		private void OnItemAdded(GameObject arg0)
		{
			if (arg0 == base.gameObject)
			{
				AddedToSet.Invoke();
			}
		}
	}
}
