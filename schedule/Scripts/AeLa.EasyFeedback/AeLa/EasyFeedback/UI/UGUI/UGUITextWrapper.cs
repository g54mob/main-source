using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine.UI;

namespace AeLa.EasyFeedback.UI.UGUI
{
	internal class UGUITextWrapper : UIInteropWrapper<Text>, IText
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

		public UGUITextWrapper(Text internalTarget)
			: base((Text)default(_00210))
		{
		}
	}
}
