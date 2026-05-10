using CTS;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "toiledAdd", "loanTake", "numberOfCustomerInToilet", "observedSpecies" })]
	public class ES3UserType_ProgressSaveSucess : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_ProgressSaveSucess()
			: base(typeof(AchievementWatchers.ProgressSaveSucess))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			AchievementWatchers.ProgressSaveSucess progressSaveSucess = (AchievementWatchers.ProgressSaveSucess)obj;
			writer.WriteProperty("toiledAdd", progressSaveSucess.toiledAdd, ES3Type_bool.Instance);
			writer.WriteProperty("loanTake", progressSaveSucess.loanTake, ES3Type_bool.Instance);
			writer.WriteProperty("numberOfCustomerInToilet", progressSaveSucess.numberOfCustomerInToilet, ES3Type_int.Instance);
			writer.WriteProperty("observedSpecies", progressSaveSucess.observedSpecies, ES3TypeMgr.GetOrCreateES3Type(typeof(ESubSpecies)));
		}

		public override object Read<T>(ES3Reader reader)
		{
			AchievementWatchers.ProgressSaveSucess progressSaveSucess = default(AchievementWatchers.ProgressSaveSucess);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "toiledAdd":
					progressSaveSucess.toiledAdd = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "loanTake":
					progressSaveSucess.loanTake = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "numberOfCustomerInToilet":
					progressSaveSucess.numberOfCustomerInToilet = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "observedSpecies":
					progressSaveSucess.observedSpecies = reader.Read<ESubSpecies>(ES3Type_enum.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			return progressSaveSucess;
		}
	}
}
