using System;
using UnityEngine;

namespace CTS
{
	public class UI_PrestigeCanvas : MonoBehaviour
	{
		[SerializeField]
		private GameObject _tocloseOnStart;

		public static event Action RadicalSolution;

		public void LaunchEvent()
		{
			UI_PrestigeCanvas.RadicalSolution?.Invoke();
		}

		private void Start()
		{
			_tocloseOnStart.SetActive(value: false);
		}
	}
}
