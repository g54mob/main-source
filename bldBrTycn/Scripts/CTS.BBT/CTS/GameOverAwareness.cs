using CTS.Core;

namespace CTS
{
	public class GameOverAwareness : GameOverListener
	{
		protected override void OnEnabled()
		{
			base.OnEnabled();
			VigilanceHandlers.VigilanceChanged += OnVigilanceChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			VigilanceHandlers.VigilanceChanged -= OnVigilanceChanged;
		}

		private void OnVigilanceChanged(int obj)
		{
			if (IsGameOverValid())
			{
				StartGameOver();
			}
		}

		public override bool IsGameOverValid()
		{
			if (!MonoSingleton<VigilanceHandlers>.InstanceExists())
			{
				return false;
			}
			return MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance >= VigilanceHandlers.MaxVigilance;
		}
	}
}
