using System;
using Noesis;

namespace Loaf.Assets.NOESIS_UI
{
	public class CheckDialog : UserControl
	{
		private static CheckDialog inst;

		private Action confirmAction;

		private Action cancelAction;

		public Noesis.Label Heading;

		public Button ConfirmButton;

		public Button CancelButton;

		public TextBlock TextBody;

		public static void RegisterDialog(Action confirmAction, Action cancelAction, string heading, string body)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
