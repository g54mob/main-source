using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "HumanReview", "VampireReview" })]
	public class ES3UserType_ReviewMounthSaveStruct : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_ReviewMounthSaveStruct()
			: base(typeof(ReviewMounthSaveStruct))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			ReviewMounthSaveStruct reviewMounthSaveStruct = (ReviewMounthSaveStruct)obj;
			writer.WriteProperty("HumanReview", reviewMounthSaveStruct.HumanReview, ES3UserType_ReviewPanelSaveStruct.Instance);
			writer.WriteProperty("VampireReview", reviewMounthSaveStruct.VampireReview, ES3UserType_ReviewPanelSaveStruct.Instance);
		}

		public override object Read<T>(ES3Reader reader)
		{
			ReviewMounthSaveStruct reviewMounthSaveStruct = default(ReviewMounthSaveStruct);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				if (!(text == "HumanReview"))
				{
					if (text == "VampireReview")
					{
						reviewMounthSaveStruct.VampireReview = reader.Read<ReviewPanelSaveStruct>(ES3UserType_ReviewPanelSaveStruct.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					reviewMounthSaveStruct.HumanReview = reader.Read<ReviewPanelSaveStruct>(ES3UserType_ReviewPanelSaveStruct.Instance);
				}
			}
			return reviewMounthSaveStruct;
		}
	}
}
