namespace Kitchen
{
	public class OpenLetter : ApplianceInteractionSystem
	{
		private CLetterBlueprint Letter;

		private CPosition Position;

		protected override bool AllowActOrGrab => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CLetterBlueprint>(data.Target, out Letter))
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
			PostHelpers.OpenBlueprintLetter(data.Context, data.Target);
			data.Context.Destroy(data.Target);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
