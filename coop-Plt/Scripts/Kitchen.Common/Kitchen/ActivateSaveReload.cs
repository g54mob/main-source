using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup))]
	public class ActivateSaveReload : InteractionSystem
	{
		private Entity Entity;

		private CLocationChoice Choice;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CLocationChoice>(data.Target, out Choice))
			{
				return false;
			}
			Entity = data.Target;
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			switch (Choice.State)
			{
			case SaveState.Empty:
				Set(new SSelectedLocation
				{
					Valid = true,
					Selected = Choice
				});
				break;
			case SaveState.Failed:
			{
				Entity e = base.PopupUtilities.RequestManagedPopup(PopupType.AbandonSave);
				Set(e, new CLocationPopupRequest
				{
					Location = Choice
				});
				break;
			}
			case SaveState.Loaded:
			{
				Entity e = base.PopupUtilities.RequestManagedPopup(PopupType.LoadPreviousSave);
				Set(e, new CLocationPopupRequest
				{
					Location = Choice
				});
				break;
			}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
