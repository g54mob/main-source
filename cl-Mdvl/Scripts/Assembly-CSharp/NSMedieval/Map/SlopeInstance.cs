using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Manager;
using NSMedieval.Model.MapNew;
using NSMedieval.Resources;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Terrain;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View.Slope;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Map
{
	[Serializable]
	[FVSerializableKey("SlopeInstance", "")]
	public class SlopeInstance : WorldObject
	{
		private static readonly Vec3Int SlopeSize = new Vec3Int(3, 3, 1);

		private Slope blueprint;

		[SerializeField]
		private List<Vec3Int> positions = new List<Vec3Int>();

		[SerializeField]
		private bool markedForDig;

		[SerializeField]
		private bool hoverSelecting;

		[SerializeField]
		private bool selected;

		[SerializeField]
		private string digVoxelTypeName;

		[SerializeField]
		private float health;

		[SerializeField]
		private int healthMax;

		[SerializeField]
		private int digAmount;

		[SerializeField]
		private int digAmountMax;

		[SerializeField]
		private string name;

		private bool digMarkerAfterLoadFix;

		public override bool BlueprintExists => Blueprint != null;

		internal override ThermalModel ThermalModel => GetNode().VoxelType?.ThermalModel;

		public string Name => name;

		public bool MarkedForDig => markedForDig;

		public bool HoverSelecting => hoverSelecting;

		public override List<Vec3Int> Positions => positions;

		public Slope Blueprint => blueprint ?? (blueprint = Repository<SlopeRepository, Slope>.Instance.GetByID(blueprintId));

		public float Health => health;

		public int HealthMax => healthMax;

		public int DigAmount => digAmount;

		public int DigAmountMax => digAmountMax;

		public bool Selected
		{
			get
			{
				return selected;
			}
			set
			{
				selected = value;
				SlopeView view = MonoSingleton<SlopeManager>.Instance.GetView(this);
				if (view != null)
				{
					view.RefreshSelectionOutline();
				}
			}
		}

		public SlopeInstance(Slope blueprint, Vector3 worldPosition, PooledList<Vec3Int> gridPositions, float angle, string name)
			: base(WorldObjectType.Slope, worldPosition, SlopeSize)
		{
			this.name = name;
			this.blueprint = blueprint;
			blueprintId = this.blueprint.GetID();
			positions.AddRange(gridPositions);
			base.Angle = angle;
			VoxelType closestVoxelType = GetClosestVoxelType();
			digVoxelTypeName = closestVoxelType.GetID();
			health = closestVoxelType.Health;
			healthMax = closestVoxelType.Health;
			digAmount = (digAmountMax = closestVoxelType.DigAmount);
		}

		public SlopeInstance(Slope blueprint, Vector3 worldPosition, List<Vec3Int> gridPositions, float angle, string name, VoxelType voxelType)
			: base(WorldObjectType.Slope, worldPosition, SlopeSize)
		{
			this.name = name;
			this.blueprint = blueprint;
			blueprintId = this.blueprint.GetID();
			positions.AddRange(gridPositions);
			base.Angle = angle;
			digVoxelTypeName = voxelType.GetID();
			health = voxelType.Health;
			healthMax = voxelType.Health;
			digAmount = (digAmountMax = voxelType.DigAmount);
		}

		public SlopeInstance()
		{
		}

		public void SetHovering(bool isHovering)
		{
			hoverSelecting = isHovering;
			SlopeView view = MonoSingleton<SlopeManager>.Instance.GetView(this);
			if (view != null)
			{
				view.SetSelectedObjectHoveringVisuals(hoverSelecting);
			}
		}

		public DigMarkerResourceInstance GetDigMarker()
		{
			Vec3Int gridPosition = CalculateDigMarkerPosition();
			MapNode node = base.Map.GetNode(gridPosition);
			if (node == null)
			{
				return null;
			}
			if ((node.DataType & GridDataType.DigMarkerResourceToMine) == 0)
			{
				return null;
			}
			return (DigMarkerResourceInstance)node.GetWorldObject(GridDataType.DigMarkerResourceToMine);
		}

		public void OnMarkedForDig()
		{
			if (!markedForDig)
			{
				markedForDig = true;
				PlaceDigMarker();
			}
		}

		public void PlaceDigMarker(bool afterLoad = false)
		{
			digMarkerAfterLoadFix = afterLoad;
			MonoSingleton<ResourceCommonController>.Instance.AddMiningMarkerEvent += OnDigMarkerAdded;
			Vec3Int gridPos = CalculateDigMarkerPosition();
			MapPropType byID = Repository<MapPropTypeRepository, MapPropType>.Instance.GetByID(GetVoxelType().DigMarker);
			MonoSingleton<ResourceSpawner>.Instance.PlaceProp3d(byID, gridPos, 0, "marker_dig_slopes");
		}

		public void OnDigCanceled()
		{
			markedForDig = false;
			SlopeView view = MonoSingleton<SlopeManager>.Instance.GetView(this);
			if (view != null)
			{
				view.CancelDigging();
			}
		}

		public bool OnDigActionCompleted()
		{
			digAmount--;
			health -= (float)healthMax / (float)digAmountMax;
			if (digAmount > 0)
			{
				return health <= 0f;
			}
			return true;
		}

		public void UpdateDigPercentInEffectMask()
		{
			foreach (Vec3Int position in positions)
			{
				MonoSingleton<GroundManager>.Instance.MapGenerationTextures.WriteVoxelHealthToEffectMap(position);
			}
		}

		public VoxelType GetVoxelType()
		{
			return VoxelTypeRepository.FastInstance.GetByID(digVoxelTypeName);
		}

		public bool IsForbiddenEdge()
		{
			foreach (Vec3Int position in positions)
			{
				if (GridDataIndexTools.IsForbiddenEdge(position.x, position.z))
				{
					return true;
				}
			}
			return false;
		}

		public override void ReInstantiate()
		{
			if (Positions.Count > 3)
			{
				Vec3Int gridPosition = Positions[0];
				Positions.RemoveAt(0);
				base.Map.GetNode(gridPosition).RemoveObject(this);
				SetObjectSize(SlopeSize);
			}
			base.ReInstantiate();
		}

		public override float GetBeautyInput()
		{
			return 0f;
		}

		private Vec3Int CalculateDigMarkerPosition()
		{
			Vec3Int a = Vec3Int.zero;
			foreach (Vec3Int position in Positions)
			{
				a += position;
			}
			int count = Positions.Count;
			return new Vec3Int(a.x / count, a.y / count, a.z / count) + Vec3Int.up;
		}

		private void OnDigMarkerAdded(DigMarkerResourceInstance instance)
		{
			Vec3Int b = CalculateDigMarkerPosition();
			if (Vec3Int.Distance(instance.GridDataPosition, in b) >= 1f)
			{
				return;
			}
			instance.SetPositions(Positions);
			MonoSingleton<ResourceCommonController>.Instance.AddMiningMarkerEvent -= OnDigMarkerAdded;
			if (digMarkerAfterLoadFix)
			{
				MonoSingleton<World>.Instance.MapLoadedEvent += delegate(bool fromSave)
				{
					instance.OnMapLoaded(fromSave);
				};
			}
		}

		private VoxelType GetClosestVoxelType()
		{
			foreach (Vec3Int position in positions)
			{
				if (GridDataIndexTools.InRange(position))
				{
					VoxelType voxelType = base.Map.GetNode(position.x, position.y, position.z).VoxelType;
					if (voxelType != null)
					{
						return voxelType;
					}
				}
			}
			foreach (Vec3Int position2 in positions)
			{
				Vec3Int a = position2;
				Vec3Int[] neighbors3DNonDiagonal = MapNodeUtils.Neighbors3DNonDiagonal;
				for (int i = 0; i < neighbors3DNonDiagonal.Length; i++)
				{
					Vec3Int b = neighbors3DNonDiagonal[i];
					Vec3Int vec3Int = a + b;
					if (GridDataIndexTools.InRange(vec3Int))
					{
						VoxelType voxelType2 = base.Map.GetNode(vec3Int).VoxelType;
						if (voxelType2 != null)
						{
							return voxelType2;
						}
					}
				}
			}
			return null;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("positions", positions);
			serializer.Write("markedForDig", markedForDig);
			serializer.Write("hoverSelecting", hoverSelecting);
			serializer.Write("selected", selected);
			serializer.Write("digVoxelTypeName", digVoxelTypeName);
			serializer.Write("health", health);
			serializer.Write("healthMax", healthMax);
			serializer.Write("digAmount", digAmount);
			serializer.Write("digAmountMax", digAmountMax);
			serializer.Write("name", name);
		}

		public SlopeInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			positions = deserializer.ReadObjectList<Vec3Int>("positions");
			markedForDig = deserializer.ReadBool("markedForDig");
			hoverSelecting = deserializer.ReadBool("hoverSelecting");
			selected = deserializer.ReadBool("selected");
			digVoxelTypeName = deserializer.ReadString("digVoxelTypeName");
			health = deserializer.ReadFloat("health");
			healthMax = deserializer.ReadInt("healthMax");
			digAmount = deserializer.ReadInt("digAmount");
			digAmountMax = deserializer.ReadInt("digAmountMax");
			name = deserializer.ReadString("name");
		}
	}
}
