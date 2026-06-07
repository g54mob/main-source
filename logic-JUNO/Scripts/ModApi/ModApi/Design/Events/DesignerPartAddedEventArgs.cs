using System;
using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Craft.Parts;

namespace ModApi.Design.Events
{
	public class DesignerPartAddedEventArgs : EventArgs
	{
		public Assembly Assembly { get; }

		public DesignerPart DesignerPart { get; }

		public IReadOnlyList<IPartScript> PartScripts { get; }

		public DesignerPartAddedEventArgs(DesignerPart designerPart, Assembly assembly, IReadOnlyList<IPartScript> partScripts)
		{
			DesignerPart = designerPart;
			Assembly = assembly;
			PartScripts = partScripts;
		}
	}
}
