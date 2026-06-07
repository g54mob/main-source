using System.Collections.Generic;
using UnityEngine;

namespace Helios.GUI
{
	public class GameManager : SingletonPersistent<GameManager>
	{
		[SerializeField]
		private GameObject _goRoot;

		[SerializeField]
		private Transform _tfParent;

		private Stack<GameObject> _stScenes;

		private void Start()
		{
		}

		public void LoadGameObject(GameObject go)
		{
		}

		public void LoadPopup(GameObject go)
		{
		}

		public void Back()
		{
		}

		private void TweenFading(GameObject obj)
		{
		}

		public void BackHome()
		{
		}
	}
}
