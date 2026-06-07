using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.ThingTypes
{
	public abstract class Thing_v2 : ScriptableObject
	{
		public delegate void ErrorPopulator(string errorMessage, Object context = null);

		public string id;

		public List<(string errorMessage, Object context)> Validate()
		{
			List<(string, Object)> errors = new List<(string, Object)>();
			PopulateErrors(ErrorPopulator);
			return errors;
			void ErrorPopulator(string message, Object context)
			{
				if (context == null)
				{
					context = this;
				}
				errors.Add((base.name + ": " + message, context));
			}
		}

		internal static bool ListContainsDuplicates<T>(List<T> list)
		{
			return false;
		}

		protected abstract void PopulateErrors(ErrorPopulator AddError);

		public static void ValidateList<T>(List<T> list, string listName, ErrorPopulator AddError) where T : Thing_v2
		{
			if (list == null || list.Count() == 0)
			{
				AddError("'" + listName + "' list is empty");
				return;
			}
			List<T> list2 = list.Where((T el) => el != null).ToList();
			if (list2.Count != list.Count)
			{
				AddError($"'{listName}' list contains {list.Count - list2.Count} null items");
			}
			int num = list2.Distinct().Count();
			if (num != list2.Count)
			{
				AddError($"'{listName}' list contains {list2.Count - num} duplicate items");
			}
			list2.Where((T el) => string.IsNullOrWhiteSpace(el.id)).ToList().ForEach(delegate(T el)
			{
				AddError("'" + listName + "' list item '" + el.name + "' has null id");
			});
			List<T> list3 = list2.Where((T el) => !string.IsNullOrWhiteSpace(el.id)).ToList();
			List<string> list4 = list3.Select((T el) => el.id).Distinct().ToList();
			if (list4.Count != list3.Count)
			{
				AddError($"'{listName}' list contains {list3.Count - list4.Count} items with non-unique ids");
			}
		}
	}
}
