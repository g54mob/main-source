using System.Collections.Generic;

namespace Assets.Scripts.Craft.Parts
{
	public class PartDuplication
	{
		private class PartMap
		{
			public PartData Duplicate { get; set; }

			public PartData Source { get; set; }
		}

		private List<PartMap> _mappings = new List<PartMap>();

		public List<PartData> DuplicateParts { get; private set; }

		public List<PartConnection> SourcePartConnections { get; private set; }

		public PartDuplication()
		{
			DuplicateParts = new List<PartData>();
			SourcePartConnections = new List<PartConnection>();
		}

		public void AddPart(PartData sourcePart, PartData duplicatePart)
		{
			DuplicateParts.Add(duplicatePart);
			PartMap item = new PartMap
			{
				Source = sourcePart,
				Duplicate = duplicatePart
			};
			foreach (PartConnection partConnection in sourcePart.PartConnections)
			{
				if (!SourcePartConnections.Contains(partConnection))
				{
					SourcePartConnections.Add(partConnection);
				}
			}
			_mappings.Add(item);
		}

		public PartData GetDuplicatePart(PartData sourcePart)
		{
			foreach (PartMap mapping in _mappings)
			{
				if (sourcePart == mapping.Source)
				{
					return mapping.Duplicate;
				}
			}
			return null;
		}

		public PartData GetSourcePart(PartData duplicatePart)
		{
			foreach (PartMap mapping in _mappings)
			{
				if (duplicatePart == mapping.Duplicate)
				{
					return mapping.Source;
				}
			}
			return null;
		}
	}
}
