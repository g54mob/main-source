namespace CTS
{
	public class SaveConstruction : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("MapEditor", MapEditor.GetAllGridData(), settings);
		}

		public override void Clear()
		{
			MapEditor.Clear();
		}

		public override void LoadInit(ES3Settings settings)
		{
			MapEditor.LoadAllGridData(ES3.Load("MapEditor", (GridSaveData[])null, settings));
		}

		public override void LoadPost(ES3Settings settings)
		{
		}
	}
}
