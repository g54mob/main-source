using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Constants;
using UnityEngine;

namespace Motorways.Views
{
	[SelectionBase]
	public class RoadView : MonoBehaviour, IView, IReusable, ICreatedInScopeHandler
	{
		public enum LaneLineDebugMode
		{
			None = 0,
			Speed = 1,
			Hotswap = 2
		}

		[Dependency]
		private City _city;

		[Dependency]
		private RoadTileAtlas _roadTileAtlas;

		[Dependency]
		private PermanenceZoneTextureLibrary _permanenceZoneTextureLibrary;

		[Dependency]
		private VisualConstantsData _visualConstants;

		public Material activeMaterial;

		public Material mothballedMaterial;

		public Material outlineMaterial;

		public Material bridgeMaterial;

		public Material bridgeOutlineMaterial;

		public Material tunnelOutlineMaterial;

		public MeshFilter baseMesh;

		public MeshFilter outlineMesh;

		public MeshFilter dashedOutlineMesh;

		public MeshFilter dryingTunnelMesh;

		public MeshRenderer baseRenderer;

		public MeshRenderer outlineRenderer;

		public MeshRenderer dashedOutlineRenderer;

		public MeshRenderer dryingTunnelRenderer;

		public BridgeSpouts bridgeSpouts;

		[Serialize(false, null)]
		private TileView _tileView;

		private MaterialPropertyBlock _materialPropertyBlock;

		private MaterialPropertyBlock _dryingTunnelPropertyBlock;

		private PermanenceProgressRoadView _permanenceProgressRoadView;

		public const string DrawLaneLinesMode = "DrawLaneLinesMode";

		public const string ShouldDrawPathfindingLaneCosts = "ShouldDrawPathfindingLaneCosts";

		public const string ShouldDrawPathfindingNodeIds = "ShouldDrawPathfindingNodeIds";

		public const string ShouldDrawLinesFromVehiclesToAllChunksInTheirPath = "ShouldDrawLinesFromVehiclesToAllChunksInTheirPath";

		private const string RoadOutlineSortingLayerName = "RoadOutline";

		private int _roadOutlineSortingLayerId;

		private const string MotorwayRoadConnectionOutlineLayerName = "MotorwayRoadConnectionOutline";

		private int _motorwayRoadConnectionOutlineSortingLayerId;

		public TileView tileView
		{
			get
			{
				return _tileView;
			}
			set
			{
				_tileView = value;
				_permanenceProgressRoadView = ((_tileView == null) ? null : new PermanenceProgressRoadView(_materialPropertyBlock, baseRenderer, _tileView, _permanenceZoneTextureLibrary, _visualConstants, _city.Rules.RoadsBecomePermanentOverTime));
			}
		}

		public void Awake()
		{
			GetComponent<MeshRenderer>().sharedMaterial = activeMaterial;
			_roadOutlineSortingLayerId = SortingLayer.NameToID("RoadOutline");
			_motorwayRoadConnectionOutlineSortingLayerId = SortingLayer.NameToID("MotorwayRoadConnectionOutline");
			_materialPropertyBlock = new MaterialPropertyBlock();
		}

		public void OnCreatedInScope(IScope scope)
		{
			using RoadTileSignature roadTileSignature = scope.Get<RoadTileSignature>();
			roadTileSignature.AddConnection(new RoadTileConnection(new RoadTileNode(TileDirection.South), new RoadTileNode(TileDirection.South)));
			bridgeSpouts.SetDryingTunnelMesh(_roadTileAtlas.GetDefinitionForSignature(roadTileSignature));
		}

		public void Reset()
		{
			_tileView = null;
			Transform obj = base.transform;
			obj.localPosition = default(Vector3);
			obj.localRotation = default(Quaternion);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_city.Rules.RoadsBecomePermanentOverTime && _tileView != null)
			{
				_permanenceProgressRoadView.UpdatePermanenceValues();
				return TickResult.ContinueTicking;
			}
			return TickResult.StopTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void SetSignature(RoadTileSignature newSignature)
		{
			RoadTileDefinition definitionForSignature = _roadTileAtlas.GetDefinitionForSignature(newSignature);
			if (!Diagnostics.Verify(definitionForSignature != null, "Tile at {0} has invalid visual signature {1}.", (_tileView != null) ? _tileView.Coordinates : default(Vector2Int), newSignature))
			{
				return;
			}
			baseMesh.mesh = definitionForSignature.mesh.roadMesh;
			outlineMesh.mesh = definitionForSignature.mesh.outlineMesh;
			bridgeSpouts.DisableAllSpouts();
			baseRenderer.enabled = true;
			dashedOutlineRenderer.enabled = false;
			dryingTunnelRenderer.enabled = false;
			bool flag = false;
			foreach (RoadTileConnection connection in newSignature.Connections)
			{
				flag = connection.input.type == RoadType.Motorway || connection.output.type == RoadType.Motorway;
				if (flag)
				{
					break;
				}
			}
			outlineRenderer.sortingLayerID = (flag ? _motorwayRoadConnectionOutlineSortingLayerId : _roadOutlineSortingLayerId);
			if (_tileView != null && _city.Definition.TileIsOverWater(_tileView.Coordinates))
			{
				baseRenderer.material = bridgeMaterial;
				outlineRenderer.material = bridgeOutlineMaterial;
				foreach (RoadTileConnection connection2 in newSignature.Connections)
				{
					TileDirection direction = connection2.input.direction;
					TileDirection direction2 = connection2.output.direction;
					if (!_city.Definition.TileIsOverWater(TileUtilities.GetAdjacentCoordinates(_tileView.Coordinates, direction)))
					{
						bridgeSpouts.SetSpoutActiveInDirection(direction, UpgradeType.Bridge);
					}
					if (!_city.Definition.TileIsOverWater(TileUtilities.GetAdjacentCoordinates(_tileView.Coordinates, direction2)))
					{
						bridgeSpouts.SetSpoutActiveInDirection(direction2, UpgradeType.Bridge);
					}
				}
			}
			else if (_tileView != null && _city.Definition.TileIsUnderAMountain(_tileView.Coordinates))
			{
				outlineRenderer.material = outlineMaterial;
				dashedOutlineRenderer.material = tunnelOutlineMaterial;
				dashedOutlineMesh.mesh = ((definitionForSignature.mesh.dashedOutlineMesh != null) ? definitionForSignature.mesh.dashedOutlineMesh : definitionForSignature.mesh.outlineMesh);
				dashedOutlineRenderer.enabled = true;
				float num = 0f;
				if (_city.Rules.RoadsBecomePermanentOverTime)
				{
					TileDirectionBitfield twoLaneRoads = tileView.Tile.GetTwoLaneRoads(RoadState.Live | RoadState.Pending);
					if (twoLaneRoads.Count > 0)
					{
						Fix64 nodePermanenceProgress = tileView.Tile.GetNodePermanenceProgress(twoLaneRoads[0]);
						if (nodePermanenceProgress < Fix64.One)
						{
							num = (1f - _visualConstants.DryingTunnelFalloff.Evaluate((float)nodePermanenceProgress)) * _visualConstants.MaxDryingTunnelOpacity;
						}
					}
				}
				foreach (RoadTileConnection connection3 in newSignature.Connections)
				{
					TileDirection direction3 = connection3.input.direction;
					TileDirection direction4 = connection3.output.direction;
					if (!_city.Definition.TileIsUnderAMountain(TileUtilities.GetAdjacentCoordinates(_tileView.Coordinates, direction3)))
					{
						bridgeSpouts.SetSpoutActiveInDirection(direction3, UpgradeType.Tunnel);
					}
					if (!_city.Definition.TileIsUnderAMountain(TileUtilities.GetAdjacentCoordinates(_tileView.Coordinates, direction4)))
					{
						bridgeSpouts.SetSpoutActiveInDirection(direction4, UpgradeType.Tunnel);
					}
				}
				if (num > 0f)
				{
					dryingTunnelMesh.mesh = definitionForSignature.mesh.roadMesh;
					dryingTunnelRenderer.enabled = true;
					if (_dryingTunnelPropertyBlock == null)
					{
						_dryingTunnelPropertyBlock = new MaterialPropertyBlock();
					}
					_dryingTunnelPropertyBlock.SetFloat(ShaderConstants.Alpha, num);
					dryingTunnelRenderer.SetPropertyBlock(_dryingTunnelPropertyBlock);
					bridgeSpouts.ShowDryingTunnel(_dryingTunnelPropertyBlock);
				}
			}
			else
			{
				baseRenderer.material = activeMaterial;
				outlineRenderer.material = outlineMaterial;
			}
			base.transform.localRotation = Quaternion.Euler(0f, 0f, (float)(-TileUtilities.GetRotationAngle(definitionForSignature.rotation)));
			bridgeSpouts.transform.localRotation = Quaternion.Euler(0f, 0f, (float)TileUtilities.GetRotationAngle(definitionForSignature.rotation));
		}

		public void ReconfigurePermanenceVisibility()
		{
			bool roadsBecomePermanentOverTime = _city.Rules.RoadsBecomePermanentOverTime;
			_permanenceProgressRoadView?.SetPermanenceVisibility(roadsBecomePermanentOverTime);
			if (!roadsBecomePermanentOverTime)
			{
				dryingTunnelRenderer.enabled = false;
				bridgeSpouts.HideDryingTunnel();
			}
		}
	}
}
