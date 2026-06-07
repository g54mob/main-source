using Bolt;
using DV.Utils;
using Ludiq;

[TypeIcon(typeof(TrainCar))]
[UnitCategory("World")]
[UnitSubtitle("Check if the railway hash matches the last saved hash")]
[UnitTitle("Railway Hash Check")]
public class RailwayHashCheckUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput hashMatch;

	[DoNotSerialize]
	public ControlOutput hashUnavailable;

	[DoNotSerialize]
	public ControlOutput hashMismatch;

	protected override void Definition()
	{
		hashMatch = ControlOutput("Match");
		hashUnavailable = ControlOutput("Missing");
		hashMismatch = ControlOutput("Mismatch");
		inputTrigger = ControlInput("Input", delegate
		{
			if (SingletonBehaviour<SaveGameManager>.Instance.data == null)
			{
				return hashUnavailable;
			}
			string text = SingletonBehaviour<SaveGameManager>.Instance.data.GetString("Last_Tracks_Hash");
			if (string.IsNullOrWhiteSpace(text))
			{
				return hashUnavailable;
			}
			return (!(text == SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash)) ? hashMismatch : hashMatch;
		});
	}
}
