using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "vidIndex", "vidScore", "vidUrl", "thumbnailUrl" })]
	public class ES3UserType_MyTubeVideo : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_MyTubeVideo()
			: base(typeof(MyTubeVideo))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			MyTubeVideo myTubeVideo = (MyTubeVideo)obj;
			writer.WriteProperty("vidIndex", myTubeVideo.vidIndex, ES3Type_int.Instance);
			writer.WriteProperty("vidScore", myTubeVideo.vidScore, ES3Type_float.Instance);
			writer.WriteProperty("vidUrl", myTubeVideo.vidUrl, ES3Type_string.Instance);
			writer.WriteProperty("thumbnailUrl", myTubeVideo.thumbnailUrl, ES3Type_string.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			MyTubeVideo myTubeVideo = (MyTubeVideo)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "vidIndex":
					myTubeVideo.vidIndex = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "vidScore":
					myTubeVideo.vidScore = reader.Read<float>(ES3Type_float.Instance);
					break;
				case "vidUrl":
					myTubeVideo.vidUrl = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "thumbnailUrl":
					myTubeVideo.thumbnailUrl = reader.Read<string>(ES3Type_string.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
