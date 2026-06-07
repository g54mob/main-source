using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop
{
	public class TabletopSaveManagerModifier : WorldManager, ISaveManagerModifier
	{
		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			if (worldEvent == EWorldEvent.WORLD_REGISTRATION)
			{
				SaveManager.Modifier = this;
			}
		}

		public Save CreateSave()
		{
			return new TabletopSave();
		}

		public Save ReadSaveFromFile(string content)
		{
			return JsonUtility.FromJson<TabletopSave>(content);
		}

		public string GetSaveContent()
		{
			return JsonUtility.ToJson(SaveManager.GetCurrentSaveAs<TabletopSave>());
		}
	}
}
