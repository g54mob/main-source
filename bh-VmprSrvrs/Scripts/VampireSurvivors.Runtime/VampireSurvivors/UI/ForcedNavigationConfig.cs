using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class ForcedNavigationConfig : MonoBehaviour
	{
		[SerializeField]
		private Selectable _Target;

		[SerializeField]
		private Selectable _OnDown;

		[SerializeField]
		private Selectable _OnUp;

		[SerializeField]
		private Selectable _OnLeft;

		[SerializeField]
		private Selectable _OnRight;

		[SerializeField]
		private List<Selectable> _FallbackUpSelections;

		private Navigation.Mode _cachedMode;

		private Selectable _cachedLeft;

		private Selectable _cachedRight;

		private Selectable _cachedUp;

		private Selectable _cachedDown;

		public bool isLive;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
