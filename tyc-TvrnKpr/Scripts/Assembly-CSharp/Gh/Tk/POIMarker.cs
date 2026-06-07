using System.Collections.Generic;

namespace Gh.Tk
{
	public class POIMarker : MapMarker
	{
		public string configId;

		public string defaultState;

		private Dictionary<string, POIState> _states;

		public string CurrentStateId { get; private set; }

		public string Name { get; set; }

		public string Description { get; set; }

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public override void OnLevelChanged()
		{
		}

		public override void CheckState()
		{
		}

		public void SetState(string stateId)
		{
		}

		public void AddState(POIState newState)
		{
		}
	}
}
