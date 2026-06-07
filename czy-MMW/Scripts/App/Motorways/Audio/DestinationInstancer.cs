namespace Motorways.Audio
{
	public class DestinationInstancer : ImmediateAudioModule
	{
		public DestinationInstancer(AudioEventFilter filter)
			: base(filter, "")
		{
		}

		protected override void OnAudioEvent(AudioEvent e)
		{
			CreateDestinationGroup(e);
		}

		private void CreateDestinationGroup(AudioEvent e)
		{
			Dbug.Log.Info("DestinationInstancer.CreateDestinationGroup(): DestGroups.Count is {0}. e.GroupIndex is {1}.", Get.Loadout.DestinationGroups.Count, e.GroupIndex);
			if (Get.Loadout.DestinationGroups.Count <= e.GroupIndex)
			{
				Get.Loadout.GetDestinationGroup(e.GroupIndex).OnEvents(e);
			}
		}
	}
}
