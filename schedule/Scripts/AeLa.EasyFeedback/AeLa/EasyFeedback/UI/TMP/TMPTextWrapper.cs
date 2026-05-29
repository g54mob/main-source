using AeLa.EasyFeedback.UI.Interfaces;
using TMPro;

namespace AeLa.EasyFeedback.UI.TMP
{
	internal class TMPTextWrapper : UIInteropWrapper<TMP_Text>, IText
	{
		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TMPTextWrapper(TMP_Text internalTarget)
			: base((TMP_Text)default(_00210))
		{
		}
	}
}
