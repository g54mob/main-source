using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_OptionsParametersButtons : MonoBehaviour
	{
		private Button _thisbutton;

		[SerializeField]
		private CanvasGroupController _controller;

		private void Awake()
		{
			_thisbutton = GetComponent<Button>();
		}
	}
}
