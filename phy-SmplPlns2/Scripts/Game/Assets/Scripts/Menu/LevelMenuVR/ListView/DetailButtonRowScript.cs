using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class DetailButtonRowScript : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _buttonLabel;

		[SerializeField]
		private TextMeshProUGUI _label;

		public string ButtonLabelText
		{
			get
			{
				return _buttonLabel.text;
			}
			set
			{
				_buttonLabel.text = value;
			}
		}

		public Action<DetailButtonRowScript> Clicked { get; set; }

		public string LabelText
		{
			get
			{
				return _label.text;
			}
			set
			{
				_label.text = value;
			}
		}

		public void OnClicked()
		{
			Clicked?.Invoke(this);
		}
	}
}
