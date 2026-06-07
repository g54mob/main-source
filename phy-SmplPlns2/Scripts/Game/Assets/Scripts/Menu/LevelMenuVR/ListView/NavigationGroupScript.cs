using System.Collections.Generic;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public class NavigationGroupScript : NavigationItemScript
	{
		public List<NavigationItemScript> NavigationItems { get; private set; }

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
				foreach (NavigationItemScript navigationItem in NavigationItems)
				{
					navigationItem.gameObject.SetActive(value);
				}
			}
		}

		public override void Initialize(string name, NavigationGroupScript navGroup, ListViewScript listView)
		{
			base.Initialize(name, navGroup, listView);
			NavigationItems = new List<NavigationItemScript>();
		}
	}
}
