namespace DV.Customization.Gadgets.Implementations
{
	public class DuctTapeEmpty : MountHoleInteractor
	{
		private const string INTERACTION_TEXT_SPENT = "interaction/duct_tape_spent";

		protected override bool OnUpdateHoles(Drillable drillable, int holeIndex, bool use)
		{
			if (drillable.CheckIfCanChangeToState(holeIndex, MountPoint.States.Taped, out var failedDueToSurfaceConditions) || failedDueToSurfaceConditions)
			{
				GadgetInteractor.ShowInteractionText("interaction/duct_tape_spent", localize: true, string.Empty);
				return true;
			}
			return false;
		}
	}
}
