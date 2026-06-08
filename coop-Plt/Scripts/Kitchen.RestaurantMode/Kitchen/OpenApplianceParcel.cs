using Unity.Entities;

namespace Kitchen
{
	public class OpenApplianceParcel : ApplianceInteractionSystem
	{
		private CLetterAppliance Letter;

		private CPosition Position;

		protected override bool AllowActOrGrab => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CLetterAppliance>(data.Target, out Letter))
			{
				return false;
			}
			if (!Require<CPosition>(data.Target, out Position))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Context.Destroy(data.Target);
			Entity entity = data.Context.CreateEntity();
			data.Context.Set(entity, new CCreateAppliance
			{
				ID = Letter.ApplianceID
			});
			data.Context.Set(entity, new CPosition(Position));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
