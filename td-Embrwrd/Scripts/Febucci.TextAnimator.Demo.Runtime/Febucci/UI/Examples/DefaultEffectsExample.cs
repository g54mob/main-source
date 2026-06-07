using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI.Examples
{
	[AddComponentMenu(null)]
	public class DefaultEffectsExample : MonoBehaviour
	{
		public TypewriterCore typewriter;

		private TextAnimatorSettings settings;

		private void Awake()
		{
		}

		private string AddEffect<T>(TextAnimatorSettings.Category<T> category, string tag) where T : ScriptableObject
		{
			return null;
		}

		private void Start()
		{
		}
	}
}
