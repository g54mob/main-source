using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP.Net
{
	public class NetProjectView : View<NetProjectViewable>
	{
		public Transform head;

		public WorldPointablePort port;

		public ProjectView projectView;

		public ListLoader players;

		public HighlightConfig selectionHighlight;

		private Dictionary<NetPresenceHandle, PartTransformData> dragHandles;

		private Dictionary<NetPresenceHandle, PartTransformData[]> startHandles;

		private Dictionary<NetPresenceHandle, EntityData> handleHandles;

		private Dictionary<NetPresenceHandle, Part> handlePartHandles;

		private Dictionary<NetPresenceHandle, Part> buildHandles;

		private Hertz presence;

		private NetGame netGame;

		private List<NetPresenceHandle> toRemoveHandles;

		private Highlight createHighlight;

		private List<Highlightable> currentHighlightables;

		private Dictionary<ulong, Highlight> highlights;

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		protected override void OnRender()
		{
		}

		private Highlight GetHighlight(ulong id)
		{
			return null;
		}

		private void OnHandleStart(NetPresenceHandle handle)
		{
		}

		private void OnHandleEnd(NetPresenceHandle handle)
		{
		}

		private void OnHandleUpdate(NetPresenceHandle handle)
		{
		}

		protected override void Update()
		{
		}
	}
}
