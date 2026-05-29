using AeLa.EasyFeedback.UI.Interfaces;
using TMPro;

namespace AeLa.EasyFeedback.UI.TMP
{
	internal class TMPDropdownWrapper : UIInteropWrapper<TMP_Dropdown>, IDropdown
	{
		public IText CaptionText { get; private set; }

		public int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TMPDropdownWrapper(TMP_Dropdown internalTarget)
			: base((TMP_Dropdown)default(_00210))
		{
		}

		public void ClearOptions()
		{
		}

		public void RefreshShownValue()
		{
		}

		public void AddOption(string text)
		{
		}
	}
}
