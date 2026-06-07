using UnityEngine;

namespace ModApi.Craft.Parts
{
	public interface IPartHighlighter
	{
		Color HighlightColor { get; set; }

		Color OutlineColor { get; set; }

		void AddPartHighlight(IPartScript part);

		void AddPartOutline(IPartScript part);

		void RemovePartHighlight(IPartScript part);

		void RemovePartOutline(IPartScript part);
	}
}
