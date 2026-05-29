namespace CTS
{
	public class SaveCamera : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			ES3.Save("Camera", MainCamera.CameraReference.transform, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
		}

		public override void LoadPost(ES3Settings settings)
		{
			if (ES3.KeyExists("Camera", settings))
			{
				ES3.LoadInto("Camera", MainCamera.CameraReference.transform, settings);
			}
		}
	}
}
