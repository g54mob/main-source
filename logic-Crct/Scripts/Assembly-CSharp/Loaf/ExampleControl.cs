using Noesis;
using UnityEngine;

namespace Loaf
{
	public class ExampleControl : UserControl
	{
		private TextAsset data;

		public ImageBrush PreviewImage;

		public TextBlock Description;

		public Noesis.Label DesignName;

		public Button ExampleButton;

		public ExampleControl()
		{
		}

		private void ExampleButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public ExampleControl(TextAsset textAsset, string desc)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
