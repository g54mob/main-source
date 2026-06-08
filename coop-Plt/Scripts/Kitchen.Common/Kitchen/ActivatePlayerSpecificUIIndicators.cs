namespace Kitchen
{
	public class ActivatePlayerSpecificUIIndicators : InteractionSystem
	{
		private CTriggerPlayerSpecificUI Editor;

		private COwnedByPlayer OwnedByPlayer;

		protected override bool AllowActOrGrab => true;

		protected override bool ShouldAct(ref InteractionData data)
		{
			if (!Require<CTriggerPlayerSpecificUI>(data.Target, out Editor))
			{
				return false;
			}
			bool flag = data.Attempt.Type == InteractionType.Grab;
			bool flag2 = base.ShouldAct(ref data);
			return Editor.UseGrab == flag && flag2;
		}

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CTriggerPlayerSpecificUI>(data.Target, out Editor))
			{
				return false;
			}
			if (Require<COwnedByPlayer>(data.Target, out OwnedByPlayer) && OwnedByPlayer.Player != data.Interactor)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			Editor.IsTriggered = true;
			Editor.TriggerEntity = data.Interactor;
			SetComponent(data.Target, Editor);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
