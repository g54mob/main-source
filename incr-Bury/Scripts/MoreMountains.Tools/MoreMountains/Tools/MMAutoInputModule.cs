using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MoreMountains.Tools
{
	public class MMAutoInputModule : MonoBehaviour
	{
		protected GameObject _eventSystemGameObject;

		protected virtual void Awake()
		{
			StartCoroutine(InitializeInputModule());
		}

		protected virtual IEnumerator InitializeInputModule()
		{
			EventSystem eventSystem = Object.FindAnyObjectByType<EventSystem>();
			if (!(eventSystem == null))
			{
				eventSystem.gameObject.AddComponent<StandaloneInputModule>();
				yield return null;
			}
		}
	}
}
