using TMPro;
using UnityEngine;

namespace Rhizomatic.UI
{
	public class TMP_TextAdapter : TextAdapter
	{
		public TMP_Text component;

		public override Color color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		protected override void UpdateView()
		{
		}

		private void Reset()
		{
		}
	}
}
