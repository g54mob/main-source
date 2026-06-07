using UnityEngine;

namespace Motorways
{
	public class BridgeSpouts : MonoBehaviour
	{
		public PassageSpout N;

		public PassageSpout NE;

		public PassageSpout E;

		public PassageSpout SE;

		public PassageSpout S;

		public PassageSpout SW;

		public PassageSpout W;

		public PassageSpout NW;

		private TileDirectionBitfield _visibleSpouts;

		public void SetDryingTunnelMesh(RoadTileDefinition deadEndMesh)
		{
			TileDirection[] directions = TileUtilities.Directions;
			foreach (TileDirection direction in directions)
			{
				MeshFilter dryingTunnelMesh = GetSpoutInDirection(direction).dryingTunnelMesh;
				dryingTunnelMesh.mesh = deadEndMesh.mesh.roadMesh;
				dryingTunnelMesh.transform.localRotation = Quaternion.Euler(0f, 0f, (float)(-TileUtilities.GetRotationAngle(deadEndMesh.rotation)));
			}
		}

		public void DisableAllSpouts()
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				base.transform.GetChild(i).gameObject.SetActive(value: false);
			}
			_visibleSpouts.Clear();
		}

		public void SetSpoutActiveInDirection(TileDirection direction, UpgradeType upgradeType)
		{
			PassageSpout spoutInDirection = GetSpoutInDirection(direction);
			if (Diagnostics.Verify(spoutInDirection != null))
			{
				_visibleSpouts[direction] = true;
				spoutInDirection.gameObject.SetActive(value: true);
				switch (upgradeType)
				{
				case UpgradeType.Bridge:
					spoutInDirection.ShowBridge();
					break;
				case UpgradeType.Tunnel:
					spoutInDirection.ShowTunnel();
					break;
				}
			}
		}

		public void ShowDryingTunnel(MaterialPropertyBlock propertyBlock)
		{
			TileDirectionBitfield.Enumerator enumerator = _visibleSpouts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				GetSpoutInDirection(current).ShowDryingTunnel(propertyBlock);
			}
		}

		public void HideDryingTunnel()
		{
			TileDirectionBitfield.Enumerator enumerator = _visibleSpouts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				GetSpoutInDirection(current).HideDryingTunnel();
			}
		}

		private PassageSpout GetSpoutInDirection(TileDirection direction)
		{
			switch (direction)
			{
			case TileDirection.North:
				return N;
			case TileDirection.NorthEast:
				return NE;
			case TileDirection.East:
				return E;
			case TileDirection.SouthEast:
				return SE;
			case TileDirection.South:
				return S;
			case TileDirection.SouthWest:
				return SW;
			case TileDirection.West:
				return W;
			case TileDirection.NorthWest:
				return NW;
			default:
				Diagnostics.FailAssert("Failed to find the {0} spout.", direction);
				return null;
			}
		}
	}
}
