using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Obsolete]
	public class ChangingScene : MonoBehaviour
	{
		[SerializeField]
		private MenuScreen _currentScreen;

		[SerializeField]
		private MenuScreen _loadingScreen;

		[SerializeField]
		private float _transitionDuration = 0.5f;

		[field: SerializeField]
		[field: Scene]
		public int GameSceneToUnload { get; private set; }
	}
}
