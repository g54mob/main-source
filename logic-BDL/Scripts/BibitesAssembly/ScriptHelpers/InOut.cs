using SimulationScripts.BibiteScripts;

namespace ScriptHelpers
{
	public struct InOut
	{
		public int iIn;

		public int iOut;

		public InOut(NEATBrain.Synaps synaps)
		{
			iIn = synaps.NodeIn;
			iOut = synaps.NodeOut;
		}
	}
}
