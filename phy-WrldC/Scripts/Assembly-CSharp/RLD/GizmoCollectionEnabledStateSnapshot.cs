using System.Collections.Generic;

namespace RLD
{
	public class GizmoCollectionEnabledStateSnapshot
	{
		private Dictionary<Gizmo, bool> _gizmoToState = new Dictionary<Gizmo, bool>();

		public void Snapshot(IEnumerable<Gizmo> gizmos)
		{
			_gizmoToState.Clear();
			foreach (Gizmo gizmo in gizmos)
			{
				_gizmoToState.Add(gizmo, gizmo.IsEnabled);
			}
		}

		public void Apply()
		{
			foreach (KeyValuePair<Gizmo, bool> item in _gizmoToState)
			{
				item.Key.SetEnabled(item.Value);
			}
			_gizmoToState.Clear();
		}
	}
}
