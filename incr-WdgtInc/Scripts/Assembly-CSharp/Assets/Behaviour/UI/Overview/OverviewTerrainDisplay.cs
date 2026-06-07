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
				string s;
				bool flag;
				switch (terrain)
				{
				case 0:
					s = "@TerrainWater";
					flag = false;
					break;
				case 1:
					s = "@TerrainMountain";
					flag = false;
					break;
				case 2:
					s = "@TerrainGrass";
					flag = true;
					break;
				case 3:
					s = "@TerrainSand";
					flag = true;
					break;
				case 4:
					s = "@TerrainPrairie";
					flag = true;
					break;
				case 5:
					s = "@TerrainSwamp";
					flag = true;
					break;
				case 6:
					s = "@TerrainRocks";
					flag = true;
					break;
				case 7:
					s = "@TerrainForest";
					flag = true;
					break;
				case 8:
					s = "@TerrainCity";
					flag = true;
					break;
				case 9:
					s = "@TerrainRuins";
					flag = true;
					break;
				default:
					s = "@TerrainUnknown";
					flag = false;
					break;
				}
				_sprite.sprite = WorldOverview.Instance.Terrain.GetTile(WorldOverview.MousePosition);
				_sprite.color = ((terrain == byte.MaxValue) ? Color.black : Color.white);
				_name.TL(s);
				_warning.gameObject.SetActive(!flag);
			}
		}
	}
}
