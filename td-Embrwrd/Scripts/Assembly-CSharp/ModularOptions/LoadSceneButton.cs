using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Button/Load Scene")]
	[RequireComponent(typeof(Button))]
	public class LoadSceneButton : MonoBehaviour
	{
		[SceneRef]
		public string scene;

		private void Awake()
		{
		}
	}
}
