using Events.UI;
using UnityEngine;

namespace Presentation.UI
{
	public class AdvancedTextInfoPanelContent : InfoPanelContent
	{
		[SerializeField]
		private string _text1;

		[SerializeField]
		private string _text2;

		[SerializeField]
		private Color _text1Color;

		[SerializeField]
		private Color _text2Color;

		[SerializeField]
		private float _text1Size;

		[SerializeField]
		private float _text2Size;

		[SerializeField]
		private bool _enableWrapping = true;

		public void UpdateContent(string text1, string text2)
		{
			_text1 = text1;
			_text2 = text2;
		}

		public void UpdateText1(string text1)
		{
			_text1 = text1;
		}

		public void UpdateText2(string text2)
		{
			_text2 = text2;
		}

		public void UpdateColors(Color text1Color, Color text2Color)
		{
			_text1Color = text1Color;
			_text2Color = text2Color;
		}

		protected override InfoPanelDto GetInfoPanelDto()
		{
			return new AdvancedTextInfoPanelDto(_text1, _text2, _text1Color, _text2Color, _text1Size, _text2Size, _enableWrapping);
		}
	}
}
