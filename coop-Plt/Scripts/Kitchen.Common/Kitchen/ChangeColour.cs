using UnityEngine;

namespace Kitchen
{
	public class ChangeColour : InteractionSystem
	{
		private CPlayerColour Colour;

		protected override bool AllowActOrGrab => true;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!HasComponent<CColourSelector>(data.Target))
			{
				return false;
			}
			if (HasComponent<COwnedByPlayer>(data.Target) && GetComponent<COwnedByPlayer>(data.Target).Player != data.Interactor)
			{
				return false;
			}
			if (!Require<CPlayerColour>(data.Interactor, out Colour))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			int num = ((data.Attempt.Type == InteractionType.Act) ? 1 : (-1));
			Color.RGBToHSV(Colour.Color, out var H, out var S, out var V);
			Colour.Color = Color.HSVToRGB(H + 0.05f * (float)num, S, V);
			data.Context.Set(data.Interactor, Colour);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
