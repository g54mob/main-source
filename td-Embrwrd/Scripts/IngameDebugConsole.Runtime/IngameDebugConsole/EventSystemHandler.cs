using UnityEngine;
using UnityEngine.SceneManagement;

namespace IngameDebugConsole
{
	[DefaultExecutionOrder(1000)]
	public class EventSystemHandler : MonoBehaviour
	{
		[SerializeField]
		private GameObject embeddedEventSystem;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void OnSceneUnloaded(Scene current)
		{
		}

		private void ActivateEventSystemIfNeeded()
		{
		}

		private void DeactivateEventSystem()
		{
		}
	}
}
