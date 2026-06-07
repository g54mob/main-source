using UnityEngine;

namespace Assets.Scripts.Menu.ListView
{
	public abstract class DetailsWidgetBaseScript : MonoBehaviour, IDetailsWidget
	{
		public DetailsWidgetGroup Group { get; set; }

		public Transform Transform => base.transform;

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public void DestroyWidget()
		{
			Group?.RemoveWidget(this);
			Object.Destroy(base.gameObject);
		}

		public abstract void Initialize(ListViewDetailsScript details);
	}
}
