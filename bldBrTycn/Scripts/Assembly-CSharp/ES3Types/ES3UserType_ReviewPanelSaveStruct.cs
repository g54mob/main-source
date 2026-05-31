using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "GoodReviewService", "GoodReviewDrink", "GoodReviewFun", "GoodReviewToilet", "BadReviewService", "BadReviewDrink", "BadReviewFun", "BadReviewToilet" })]
	public class ES3UserType_ReviewPanelSaveStruct : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_ReviewPanelSaveStruct()
			: base(typeof(ReviewPanelSaveStruct))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ReviewPanelSaveStruct reviewPanelSaveStruct = (ReviewPanelSaveStruct)obj;
			writer.WriteProperty("GoodReviewService", reviewPanelSaveStruct.GoodReviewService, ES3Type_int.Instance);
			writer.WriteProperty("GoodReviewDrink", reviewPanelSaveStruct.GoodReviewDrink, ES3Type_int.Instance);
			writer.WriteProperty("GoodReviewFun", reviewPanelSaveStruct.GoodReviewFun, ES3Type_int.Instance);
			writer.WriteProperty("GoodReviewToilet", reviewPanelSaveStruct.GoodReviewToilet, ES3Type_int.Instance);
			writer.WriteProperty("BadReviewService", reviewPanelSaveStruct.BadReviewService, ES3Type_int.Instance);
			writer.WriteProperty("BadReviewDrink", reviewPanelSaveStruct.BadReviewDrink, ES3Type_int.Instance);
			writer.WriteProperty("BadReviewFun", reviewPanelSaveStruct.BadReviewFun, ES3Type_int.Instance);
			writer.WriteProperty("BadReviewToilet", reviewPanelSaveStruct.BadReviewToilet, ES3Type_int.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ReviewPanelSaveStruct reviewPanelSaveStruct = default(ReviewPanelSaveStruct);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				switch (text)
				{
				case "GoodReviewService":
					reviewPanelSaveStruct.GoodReviewService = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "GoodReviewDrink":
					reviewPanelSaveStruct.GoodReviewDrink = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "GoodReviewFun":
					reviewPanelSaveStruct.GoodReviewFun = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "GoodReviewToilet":
					reviewPanelSaveStruct.GoodReviewToilet = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "BadReviewService":
					reviewPanelSaveStruct.BadReviewService = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "BadReviewDrink":
					reviewPanelSaveStruct.BadReviewDrink = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "BadReviewFun":
					reviewPanelSaveStruct.BadReviewFun = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "BadReviewToilet":
					reviewPanelSaveStruct.BadReviewToilet = reader.Read<int>(ES3Type_int.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			return reviewPanelSaveStruct;
		}
	}
}
