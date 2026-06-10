using System.Collections.Generic;
using NSMedieval.Enums;

namespace NSMedieval.Tutorial
{
	public class TutorialInputManager
	{
		private readonly List<KeyInputEvent> blockedKeyInputEvents = new List<KeyInputEvent>
		{
			KeyInputEvent.LayerUp,
			KeyInputEvent.LayerDown,
			KeyInputEvent.ShowHideRooms,
			KeyInputEvent.GameSpeedNormal,
			KeyInputEvent.GameSpeedFast,
			KeyInputEvent.GameSpeedFaster,
			KeyInputEvent.GamePause,
			KeyInputEvent.GameSpeedDev,
			KeyInputEvent.CameraReset,
			KeyInputEvent.ShowHideTrees,
			KeyInputEvent.ShowHideItemIndicators,
			KeyInputEvent.ShowHideResourceGroups,
			KeyInputEvent.LockCameraToLayer,
			KeyInputEvent.LockCameraToLayerUp,
			KeyInputEvent.LockCameraToLayerDown,
			KeyInputEvent.ShowHideRoofs,
			KeyInputEvent.Jobs,
			KeyInputEvent.Schedule,
			KeyInputEvent.Research,
			KeyInputEvent.Manage,
			KeyInputEvent.Animals,
			KeyInputEvent.Chopping,
			KeyInputEvent.CutAllVegetation,
			KeyInputEvent.Deconstructing,
			KeyInputEvent.Cancel,
			KeyInputEvent.Harvesting,
			KeyInputEvent.Digging,
			KeyInputEvent.Hunting,
			KeyInputEvent.Allow,
			KeyInputEvent.Draft,
			KeyInputEvent.UrgentHaul,
			KeyInputEvent.Fishing,
			KeyInputEvent.Base,
			KeyInputEvent.Production,
			KeyInputEvent.Furniture,
			KeyInputEvent.Leisure,
			KeyInputEvent.Decoration,
			KeyInputEvent.Defense,
			KeyInputEvent.Zone,
			KeyInputEvent.SelectNextWorker,
			KeyInputEvent.Multiselect,
			KeyInputEvent.Report,
			KeyInputEvent.ShowHideAlmanac,
			KeyInputEvent.DevTools,
			KeyInputEvent.ShowHideZoneGrid,
			KeyInputEvent.TameAnimal,
			KeyInputEvent.TrainAnimal,
			KeyInputEvent.SlaughterAnimal,
			KeyInputEvent.ReleaseAnimal
		};

		private readonly List<KeyInputEvent> timeControls = new List<KeyInputEvent>
		{
			KeyInputEvent.GameSpeedNormal,
			KeyInputEvent.GameSpeedFast,
			KeyInputEvent.GameSpeedFaster,
			KeyInputEvent.GamePause
		};

		public bool IsInputEventBlocked(KeyInputEvent keyInputEvent)
		{
			return blockedKeyInputEvents.Contains(keyInputEvent);
		}

		public void AllowKeyInputEvents(List<KeyInputEvent> keyInputEvents)
		{
			foreach (KeyInputEvent keyInputEvent in keyInputEvents)
			{
				if (blockedKeyInputEvents.Contains(keyInputEvent))
				{
					AllowKeyInputEvent(keyInputEvent);
				}
			}
		}

		private void AllowKeyInputEvent(KeyInputEvent keyInputEvent)
		{
			blockedKeyInputEvents.Remove(keyInputEvent);
		}

		public void BlockKeyInputEvents(List<KeyInputEvent> keyInputEvents)
		{
			foreach (KeyInputEvent keyInputEvent in keyInputEvents)
			{
				if (!blockedKeyInputEvents.Contains(keyInputEvent))
				{
					BlockKeyInputEvent(keyInputEvent);
				}
			}
		}

		private void BlockKeyInputEvent(KeyInputEvent keyInputEvent)
		{
			blockedKeyInputEvents.Add(keyInputEvent);
		}

		public void AllowTimeControls(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvents(timeControls);
			}
			else
			{
				BlockKeyInputEvents(timeControls);
			}
		}

		public void AllowConstructZone(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Zone);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Zone);
			}
		}

		public void AllowConstructFurniture(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Furniture);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Furniture);
			}
		}

		public void AllowConstructBase(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Base);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Base);
			}
		}

		public void AllowConstructDefense(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Defense);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Defense);
			}
		}

		public void AllowConstructProduction(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Production);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Production);
			}
		}

		public void AllowAllowOrder(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Allow);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Allow);
			}
		}

		public void AllowHarvestOrder(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Harvesting);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Harvesting);
			}
		}

		public void AllowDigOrder(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Digging);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Digging);
			}
		}

		public void AllowLayerControls(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.LayerUp);
				AllowKeyInputEvent(KeyInputEvent.LayerDown);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.LayerUp);
				BlockKeyInputEvent(KeyInputEvent.LayerDown);
			}
		}

		public void AllowRoofsControls(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.ShowHideRoofs);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.ShowHideRoofs);
			}
		}

		public void AllowJobsControls(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Jobs);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Jobs);
			}
		}

		public void AllowResearchControls(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Research);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Research);
			}
		}

		public void AllowDraftControls(bool allow)
		{
			if (allow)
			{
				AllowKeyInputEvent(KeyInputEvent.Draft);
			}
			else
			{
				BlockKeyInputEvent(KeyInputEvent.Draft);
			}
		}
	}
}
