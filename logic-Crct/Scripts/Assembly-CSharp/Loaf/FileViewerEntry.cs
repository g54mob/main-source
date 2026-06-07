using Noesis;

namespace Loaf
{
	public class FileViewerEntry : UserControl
	{
		public string filePath;

		public Noesis.Label FileLabel;

		public Button FileButton;

		public FileViewerEntry()
		{
		}

		private void FileButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs args)
		{
		}

		public FileViewerEntry(string path)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
