using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class DisplaySectorInfluence : MonoBehaviour
	{
		private TextMesh _label;

		public GalaxyMapSector StartSector;

		public GalaxyMapSector EndSector;

		public void Init(GalaxyMapSector start, GalaxyMapSector end)
		{
			_label = GetComponent<TextMesh>();
			GetComponent<MeshRenderer>().sortingOrder = 2;
			StartSector = start;
			EndSector = end;
			Vector2 position = start.Position;
			Vector2 position2 = end.Position;
			Vector2 vector = position2 - position;
			position += vector.normalized * (start.Radius + 10f);
			position2 -= vector.normalized * (end.Radius + 10f);
			Vector2 vector2 = position + (position2 - position) / 2f;
			base.transform.position = vector2;
			ChangeText(StartSector);
		}

		public void ChangeText(GalaxyMapSector sector)
		{
			_label.text = sector.Influence + " / " + sector.InfluenceToUnlock;
		}

		public bool BothExplored()
		{
			if (StartSector.Explored && EndSector.Explored)
			{
				return true;
			}
			return false;
		}
	}
}
