using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Text.SampleScene
{
	public class MText_SampleScene_FontTest : MonoBehaviour
	{
		[SerializeField]
		private Modular3DText modular3DText;

		[SerializeField]
		private Modular3DText fontText;

		[Space]
		[SerializeField]
		private List<Font> fonts;

		private int selectedFont;

		public void NextFont()
		{
		}

		public void PreviousFont()
		{
		}

		private void UpdateInfo()
		{
		}
	}
}
