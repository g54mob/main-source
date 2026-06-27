using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.ObjectPools
{
	public class PoolableEntity : MonoBehaviour
	{
		private static class OdinStyle
		{
			public const string OBJECTS_TO_DESTROY = "Objects to destroy";
		}

		[SerializeField]
		private bool cleanEventHandlers = true;

		[SerializeField]
		private UnityEvent onDisposed = new UnityEvent();

		[SerializeField]
		private PoolableEntity[] childPoolableEntities = new PoolableEntity[0];

		[SerializeField]
		private GameObject[] gameObjectToDestroy = new GameObject[0];

		[SerializeField]
		private Component[] componentsToDestroy = new Component[0];

		private readonly List<ICleanableComponent> cleanablesBuffer = new List<ICleanableComponent>(10);

		public GameObject SourcePrefab { get; set; }

		public void Clean()
		{
			CleanComponents();
			DestroyGameObject();
			DestroyComponents();
			onDisposed.Invoke();
			if (cleanEventHandlers)
			{
				onDisposed.RemoveAllListeners();
			}
		}

		private void CleanComponents()
		{
			cleanablesBuffer.Clear();
			GetComponents(cleanablesBuffer);
			foreach (ICleanableComponent item in cleanablesBuffer)
			{
				item.Clean();
			}
			PoolableEntity[] array = childPoolableEntities;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clean();
			}
		}

		private void DestroyGameObject()
		{
			GameObject[] array = gameObjectToDestroy;
			foreach (GameObject gameObject in array)
			{
				if (gameObject != null)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			gameObjectToDestroy = Array.Empty<GameObject>();
		}

		private void DestroyComponents()
		{
			Component[] array = componentsToDestroy;
			foreach (Component component in array)
			{
				if (component != null)
				{
					UnityEngine.Object.Destroy(component);
				}
			}
			componentsToDestroy = Array.Empty<Component>();
		}
	}
}
