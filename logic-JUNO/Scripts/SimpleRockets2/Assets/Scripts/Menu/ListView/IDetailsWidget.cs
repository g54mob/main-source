using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public interface IDetailsWidget
	{
		DetailsWidgetGroup Group { get; set; }

		Transform Transform { get; }

		bool Visible { get; set; }

		void DestroyWidget();

		void Initialize(ListViewDetailsScript details);
	}
}
