using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Data.Objectives
{
	[CreateAssetMenu(menuName = "Objectives/BotCatogoryUILibrary")]
	public class BotCatogoryUILibrary : ScriptableObject
	{
		public SerializedDictionary<ObjectiveTargetCategorySO, CategoryUI> CategoryUIs;
	}
}
