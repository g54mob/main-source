using Factory.UI;

namespace UI
{
	public class CollectionArtifactDescriptionCtrl : ArtifactDescriptionCtrl
	{
		public override void ShowMachineDescription(eMachine machineId)
		{
		}

		protected override bool IsActiveUsableMachine(eMachine machine)
		{
			return false;
		}
	}
}
