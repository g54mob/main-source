using UnityEngine;
using UnityEngine.UI;

namespace FishNet.Example.ColliderRollbacks
{
	public class TextCanvas : MonoBehaviour
	{
		[SerializeField]
		private Text _text;

		private static TextCanvas _instance;

		private void Awake()
		{
		}

		public void SetText(string text)
		{
		}
	}
}
