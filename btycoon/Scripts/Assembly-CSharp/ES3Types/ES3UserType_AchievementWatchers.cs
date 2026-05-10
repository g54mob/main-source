using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_AchievementWatchers : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_AchievementWatchers()
			: base(typeof(AchievementWatchers))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			_ = (AchievementWatchers)obj;
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			_ = (AchievementWatchers)obj;
			foreach (string property in reader.Properties)
			{
				_ = property;
				reader.Skip();
			}
		}
	}
}
