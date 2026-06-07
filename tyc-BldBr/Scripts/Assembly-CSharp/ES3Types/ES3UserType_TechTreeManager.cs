using System.Collections.Generic;
using CTS;
using CTS.BBT.TechTree;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_TechTreeManager : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_TechTreeManager()
			: base(typeof(TechTreeManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			_ = (TechTreeManager)obj;
			Dictionary<long, ETechTreeTechnologyLevel> dictionary = new Dictionary<long, ETechTreeTechnologyLevel>();
			foreach (var (obj2, value) in TechTreeManager.ResearchStates)
			{
				dictionary.TryAdd(AssetReferences.GetOrCreateReferenceId(obj2), value);
			}
			writer.WriteProperty("ResearchStates", dictionary);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			((TechTreeManager)obj).ResetTechTree();
			foreach (string property in reader.Properties)
			{
				if (property == "ResearchStates")
				{
					foreach (KeyValuePair<long, ETechTreeTechnologyLevel> item in reader.Read<Dictionary<long, ETechTreeTechnologyLevel>>())
					{
						item.Deconstruct(out var key, out var value);
						long id = key;
						ETechTreeTechnologyLevel level = value;
						TechTreeTechnologySO reference = AssetReferences.GetReference<TechTreeTechnologySO>(id);
						if ((bool)reference)
						{
							TechTreeManager.ResearchATechnology(reference, level);
						}
					}
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
