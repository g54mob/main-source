using System.Collections.Generic;
using Noesis;

namespace Loaf.Assets.NOESIS_UI
{
	public class OpenDesignWindow : UserControl
	{
		private static OpenDesignWindow inst;

		private List<string> recentFiles;

		public Button CloseButton;

		public Button BrowseButton;

		public Button NewButton;

		public Noesis.Label NoRecentLabel;

		public StackPanel RecentFilesStack;

		public Button BrowseExamplesButton;

		public Button BackButton;

		public Button QuickStartButton;

		public Button GuideBackButton;

		public Grid WelcomeGrid;

		public Grid ExamplesGrid;

		public Grid GuideGrid;

		public StackPanel ExampleStack;

		private void QuickStartButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void GuideBackButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void LoadExamples()
		{
		}

		public static void Home()
		{
		}

		private void BackButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void BrowseExamplesButton_Click(object sender, RoutedEventArgs args)
		{
		}

		public static void LoadRecentFiles()
		{
		}

		private void loadRecentFiles()
		{
		}

		public static void UpdateRecentFiles(string f)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
