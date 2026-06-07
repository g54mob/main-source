using SimulationScripts.BibiteScripts;

namespace ScriptHelpers
{
	public class ConnectionSortHelper
	{
		public NEATBrain.Synaps connection;

		public NodeSortHelper nodeIn;

		public NodeSortHelper nodeOut;

		public int indexIn => connection.NodeIn;

		public int indexOut => connection.NodeOut;

		public float value => connection.Weight;

		public bool enabled => connection.En;

		public ConnectionSortHelper(NEATBrain.Synaps conn, NodeSortHelper from, NodeSortHelper to)
		{
			connection = conn;
			nodeIn = from;
			nodeOut = to;
		}
	}
}
