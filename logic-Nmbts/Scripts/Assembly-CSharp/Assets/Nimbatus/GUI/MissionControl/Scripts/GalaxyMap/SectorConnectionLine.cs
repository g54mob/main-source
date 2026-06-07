using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class SectorConnectionLine : MonoBehaviour
	{
		public Color AvailableColor;

		public Color BlockedColor;

		public Color RevealedColor;

		public LineRenderer RevealLine;

		private LineRenderer _lineRenderer;

		public void Init(GalaxyMapSector startSector, GalaxyMapSector endSector)
		{
			Vector2 position = startSector.Position;
			Vector2 position2 = endSector.Position;
			_lineRenderer = GetComponent<LineRenderer>();
			if (startSector.Explored && endSector.Explored)
			{
				_lineRenderer.material.color = AvailableColor;
			}
			else if (startSector.Explored || endSector.Explored)
			{
				_lineRenderer.material.color = RevealedColor;
			}
			else
			{
				_lineRenderer.material.color = BlockedColor;
			}
			Vector2 vector = position2 - position;
			position += vector.normalized * (startSector.Radius + 10f);
			position2 -= vector.normalized * (endSector.Radius + 10f);
			_lineRenderer.SetPosition(0, position);
			_lineRenderer.SetPosition(1, position2);
			_lineRenderer.material.mainTextureScale = new Vector2((float)(int)Vector2.Distance(position, position2) / 4.25f, 1f);
			RevealLine.SetPosition(0, position);
			RevealLine.SetPosition(1, position2);
		}
	}
}
