using System;
using Noesis;

namespace Loaf.Assets.NOESIS_UI
{
	public class RecentFileControl : UserControl
	{
		private string fileName;

		public Noesis.Label DesignName;

		public Noesis.Label Modified;

		public ImageBrush PreviewImage;

		public Button DesignButton;

		private void DesignButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public void LoadInfo(string f, DateTime dt)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
