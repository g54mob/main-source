using System;
using Noesis;

namespace Loaf
{
	public class CodeTab
	{
		public string filePath;

		public bool main;

		public string Filename { get; set; }

		public Visibility CloseVisibilty { get; set; }

		public NoesisEventCommand CloseCommand { get; set; }

		public CodeTab(string fP, bool isMain, Action closeAction)
		{
		}
	}
}
