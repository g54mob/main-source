using TMPro;
using UnityEngine;

namespace TH20
{
	public class Tooltip : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private bool _raycastTarget = true;

		public string Text
		{
			get
			{
				if (_text == null)
				{
					return string.Empty;
				}
				return _text.text;
			}
			set
			{
				if (_text != null)
				{
					_text.text = value;
					_text.raycastTarget = _raycastTarget;
				}
			}
		}

		public void Close()
		{
			Object.Destroy(base.gameObject);
		}
	}
}
