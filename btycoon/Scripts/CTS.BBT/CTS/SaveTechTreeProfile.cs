using System.Collections.Generic;
using CTS.BBT.TechTree;
using CTS.Core;

namespace CTS
{
	public class SaveTechTreeProfile : SaveContainer
	{
		public override void Clear()
		{
			base.Clear();
			if (CTSSingleton<TechTreeManager>.TryGetInstance(out var outInstance))
			{
				outInstance.ResetTechTree();
			}
		}

		public override void Save(ES3Settings settings)
		{
			Dictionary<long, ETechTreeTechnologyLevel> dictionary = new Dictionary<long, ETechTreeTechnologyLevel>();
			foreach (var (obj, value) in TechTreeManager.ResearchStates)
			{
				dictionary.TryAdd(AssetReferences.GetOrCreateReferenceId(obj), value);
			}
			ES3.Save("ResearchStates", dictionary, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			if (!CTSSingleton<TechTreeManager>.TryGetInstance(out var outInstance))
			{
				return;
			}
			outInstance.ResetTechTree();
			Dictionary<long, ETechTreeTechnologyLevel> dictionary = ES3.Load("ResearchStates", (Dictionary<long, ETechTreeTechnologyLevel>)null, settings);
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<long, ETechTreeTechnologyLevel> item in dictionary)
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

		public override void LoadPost(ES3Settings settings)
		{
		}
	}
}
