using I2.Loc;

namespace TH20
{
	public class InspectorSubDataRoomResearch : InspectorSubDataRoom
	{
		private ResearchProjectComponent _projectComponent;

		public InspectorSubDataRoomResearch(Room room)
			: base(room)
		{
			RoomAlgorithms.IterateRoomItemsWithComponent(_room, delegate(ResearchProjectComponent component)
			{
				_projectComponent = component;
			});
		}

		public override string GetText()
		{
			if (_projectComponent == null)
			{
				return string.Empty;
			}
			if (_projectComponent.Project != null)
			{
				return ScriptLocalization.Inspector_Room_Research.CancelProject_CS;
			}
			return ScriptLocalization.Inspector_Room_Research.Research_CS;
		}

		public override string GetTooltip()
		{
			if (_projectComponent == null)
			{
				return string.Empty;
			}
			if (_projectComponent.Project != null)
			{
				return ScriptLocalization.Inspector_Room_Research.CancelProject_CS;
			}
			return ScriptLocalization.Inspector_Room_Research.StartProject_CS;
		}

		public override bool OnButtonPressed()
		{
			if (_projectComponent == null)
			{
				return false;
			}
			RoomItem roomItem = _projectComponent.GetOwner<RoomItem>();
			if (_projectComponent.Project != null)
			{
				base.Level.ResearchManager.RemoveResearchProject(_projectComponent.Project, roomItem);
				return false;
			}
			base.Level.HospitalHUDManager.TryOpenMenu(delegate
			{
				base.Level.HUD.CreateMenu<ResearchProjectMenu>().Setup(base.Level, roomItem);
			});
			return true;
		}

		public override bool ShouldShowButton()
		{
			if (_projectComponent != null)
			{
				return _room.HasValidRequiredItems();
			}
			return false;
		}
	}
}
