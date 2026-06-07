using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class GoxInfoElement : MonoBehaviour, IGoxInfoElement
	{
		public GameObjectX Gox { get; private set; }

		private void Start()
		{
		}

		public void Refresh()
		{
		}

		protected virtual void OnRefresh()
		{
		}

		public void SetGox(GameObjectX gox)
		{
		}

		protected virtual void OnGoxPreSet()
		{
		}

		protected virtual void OnGoxPostSet()
		{
		}
	}
}
