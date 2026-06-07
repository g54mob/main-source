using System.Collections.Generic;
using System.Text;
using CLanguage.Syntax;
using CLanguage.Tests;
using Noesis;
using UnityEngine;

namespace Loaf
{
	public class CodeEditorWindow : UserControl
	{
		private string defaultCode;

		public static CodeEditorWindow inst;

		private MicroController microController;

		private TranslateTransform translate;

		private Vector2 dragStart;

		private Vector2 startPos;

		private Vector2 delta;

		private static string MainCode;

		private List<CodeTab> codeTabs;

		private Brush[] colors;

		private string rawCode;

		private ArduinoMachine machine;

		private bool locked;

		private ColorSpan[] spans;

		private int prevLines;

		private StringBuilder sb;

		private CompilePrinter printer;

		public Button DragHandle;

		public ScrollViewer scrollview;

		public Grid EntryContainer;

		public Grid TextGrid;

		public Button CloseButton;

		public Button NewButton;

		public Button SaveButton;

		public Button OpenButton;

		public Button ApplyButton;

		public TreeViewItem RootTreeItem;

		public TextBlock RenderText;

		public TextBlock Numbers;

		public ScrollViewer NumberScroll;

		public ScrollViewer TextScroll;

		public TextBox EntryText;

		public StackPanel FileStack;

		public TabControl CodeTabs;

		public Button RootButton;

		public static Border Container;

		public Border CompileStatus;

		public TextBlock OutcomeText;

		public Image OutcomeImage;

		public Button CompileOkButton;

		public Button CompileCloseButton;

		public TextBox CompileErrors;

		public CodeEditorWindow()
		{
		}

		private void SaveButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void SaveSourceFile()
		{
		}

		private void OpenButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void NewButton_Click(object sender, RoutedEventArgs args)
		{
		}

		private void NewMainCode()
		{
		}

		private void OpenMainCode()
		{
		}

		public CodeEditorWindow(MicroController mc)
		{
		}

		private void DragHandle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs args)
		{
		}

		public void Update()
		{
		}

		private void RootButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs args)
		{
		}

		private void CodeTabs_SelectionChanged(object sender, SelectionChangedEventArgs args)
		{
		}

		private void PopulateFileList()
		{
		}

		private void OpenMainTab()
		{
		}

		public static void OpenFile(FileViewerEntry entry)
		{
		}

		public static void CloseTab(CodeTab tab)
		{
		}

		private void _CloseTab(CodeTab tab)
		{
		}

		private void _OpenFile(FileViewerEntry entry)
		{
		}

		private static string[] GetFiles(string path)
		{
			return null;
		}

		private void CodeEditorWindow_Loaded(object sender, RoutedEventArgs args)
		{
		}

		private void TextScroll_ScrollChanged(object sender, ScrollChangedEventArgs args)
		{
		}

		private void CreateColors()
		{
		}

		private void EntryText_TextChanged(object sender, RoutedEventArgs args)
		{
		}

		private void UpdateRenderText()
		{
		}

		private void UpdateNumbers()
		{
		}

		private void ApplyButton_Click(object sender, RoutedEventArgs e)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}
