using System;
using Assets.Scripts.Craft.Parts;

namespace Assets.Scripts.Craft.Events
{
	public class MainCockpitChangedEventArgs : EventArgs
	{
		public PartScript NewCockpit { get; }

		public PartScript PreviousCockpit { get; }

		public MainCockpitChangedEventArgs(PartScript previousCockpit, PartScript newCockpit)
		{
			PreviousCockpit = previousCockpit;
			NewCockpit = newCockpit;
		}
	}
}
