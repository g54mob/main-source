using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class AboutUIScript : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _aboutText;

		public event Action Closed;

		public void Close()
		{
			base.gameObject.SetActive(value: false);
			this.Closed?.Invoke();
		}

		protected virtual void Start()
		{
			_aboutText.text = $"Version: {Game.Version}\n\n" + _aboutText.text;
		}
	}
}
