using UnityEngine;

namespace Gh.Tk
{
	public interface ISelectable
	{
		bool SuppressInfoPanel { get; set; }

		bool IsSelected { get; set; }

		void AddHighlight(Color? color = null);

		void RemoveHighlight();

		bool CanSelect();
	}
}
