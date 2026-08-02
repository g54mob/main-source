using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "seed", "mainPlayer" })]
	public class ES3UserType_GameManager : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_GameManager()
			: base(typeof(TrainGameManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			TrainGameManager trainGameManager = (TrainGameManager)obj;
			writer.WriteProperty("seed", trainGameManager.seed, ES3Type_int.Instance);
			writer.WritePropertyByRef("mainPlayer", trainGameManager.mainPlayer);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			TrainGameManager trainGameManager = (TrainGameManager)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "seed"))
				{
					if (property == "mainPlayer")
					{
						trainGameManager.mainPlayer = reader.Read<GameObject>(ES3Type_GameObject.Instance);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					trainGameManager.Networkseed = reader.Read<int>(ES3Type_int.Instance);
				}
			}
		}
	}
}
