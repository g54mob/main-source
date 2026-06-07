using System;
using ModApi.Craft.Parts;

namespace ModApi.Flight.UI
{
	public class FlightLogEntry
	{
		private WeakReference<IPartScript> _associatedPart;

		public IPartScript AssociatedPart
		{
			get
			{
				if (_associatedPart == null)
				{
					return null;
				}
				if (!_associatedPart.TryGetTarget(out var target))
				{
					return null;
				}
				return target;
			}
		}

		public FlightLogEntryCategory Category { get; }

		public int Id { get; }

		public bool IsDynamic { get; }

		public string Text { get; set; }

		public FlightLogEntry(int id, string text, FlightLogEntryCategory category, bool isDynamic, IPartScript associatedPart)
		{
			Id = id;
			Text = text;
			Category = category;
			IsDynamic = isDynamic;
			if (associatedPart != null)
			{
				_associatedPart = new WeakReference<IPartScript>(associatedPart);
			}
		}
	}
}
