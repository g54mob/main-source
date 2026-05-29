using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Eflatun.SceneReference
{
	[PublicAPI]
	public class SceneReferenceUnityEventAdapter : MonoBehaviour
	{
		[SerializeField]
		private SceneReference scene;

		[field: SerializeField]
		public UnityEvent<SceneReference> Raised { get; private set; }

		public void Raise()
		{
			Raised.Invoke(scene);
		}
	}
}
