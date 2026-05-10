using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine.UI;

namespace AeLa.EasyFeedback.UI.UGUI
{
	internal class UGUIDropdownWrapper : UIInteropWrapper<Dropdown>, IDropdown
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

		public UGUIDropdownWrapper(Dropdown internalTarget)
			: base((Dropdown)default(_00210))
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
