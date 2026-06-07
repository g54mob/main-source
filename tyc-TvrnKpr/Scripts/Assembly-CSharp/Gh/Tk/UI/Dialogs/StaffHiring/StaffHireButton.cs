using System;
using System.Runtime.CompilerServices;
using I18n;

namespace Gh.Tk.UI.Dialogs.StaffHiring
{
	public class StaffHireButton : Button3DUIView
	{
		public Action Callback;

		public TextMeshProI18n Text;

		private Staff _staff;

		private string _textTemplate;

		public Staff Staff
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event EventHandler Clicked
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
