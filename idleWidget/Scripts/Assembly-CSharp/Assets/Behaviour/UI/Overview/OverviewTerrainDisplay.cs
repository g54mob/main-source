using Assets.Source.World;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.Overview
{
	public class OverviewTerrainDisplay : MonoBehaviour
	{
		[SerializeField]
		private Image _sprite;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private Image _warning;

		private void Update()
		{
			if ((bool)WorldManager.Instance && OverviewUI.Instance.FullScreenActive)
			{
				byte terrain = WorldMap.Current.GetTerrain(WorldOverview.MousePosition, createNew: false);
				string text;
				bool flag;
				switch (terrain)
				{
				case 0:
					text = "Water";
					flag = false;
					break;
				case 1:
					text = "Mountain";
					flag = false;
					break;
				case 2:
					text = "Grass";
					flag = true;
					break;
				case 3:
					text = "Sand";
					flag = true;
					break;
				case 4:
					text = "Prairie";
					flag = true;
					break;
				case 5:
					text = "Swamp";
					flag = true;
					break;
				case 6:
					text = "Rocks";
					flag = true;
					break;
				case 7:
					text = "Forest";
					flag = true;
					break;
				case 8:
					text = "City";
					flag = true;
					break;
				case 9:
					text = "Ruins";
					flag = true;
					break;
				default:
					text = "???";
					flag = false;
					break;
				}
				_sprite.sprite = WorldOverview.Instance.Terrain.GetTile(WorldOverview.MousePosition);
				_sprite.color = ((terrain == byte.MaxValue) ? Color.black : Color.white);
				_name.text = text;
				_warning.gameObject.SetActive(!flag);
			}
		}
	}
}
