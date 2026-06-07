using System;
using System.IO;
using Assets.Scripts.Menu.ListView;
using ModApi;
using ModApi.Math;

namespace Assets.Scripts.Vizzy.UI
{
	public class LoadProgramDetails
	{
		private DetailsPropertyScript _createdDate;

		private DetailsPropertyScript _size;

		public LoadProgramDetails(ListViewDetailsScript listViewDetails)
		{
			_createdDate = listViewDetails.Widgets.AddProperty("Created");
			_size = listViewDetails.Widgets.AddProperty("Size");
		}

		public void UpdateDetails(FileInfo file)
		{
			_createdDate.ValueText = RelativeDate(file.LastWriteTime);
			_size.ValueText = Units.GetMemoryString(file.Length);
		}

		private static string RelativeDate(DateTime d)
		{
			return Utilities.RelativeDate(DateTime.Now, d);
		}
	}
}
