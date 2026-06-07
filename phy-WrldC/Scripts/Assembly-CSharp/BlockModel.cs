using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockModel
{
	private readonly List<BlockBodyModel> blockBodyModels;

	private readonly List<BlockModel> interconnectedBlockModels;

	public CreationModel ParentCreationModel { get; set; }

	public int Id { get; set; }

	public Schematic Schematic { get; private set; }

	public Vector3 Position { get; set; }

	public Quaternion Rotation { get; set; }

	public BlockModel GroupLeaderBlockModel { get; set; }

	public BlockModel(Schematic schematic)
	{
		Id = 0;
		Schematic = schematic;
		Position = Vector3.zero;
		Rotation = Quaternion.Euler(Vector3.zero);
		blockBodyModels = new List<BlockBodyModel>();
		interconnectedBlockModels = new List<BlockModel>();
	}

	public void AddBlockBodyModel(BlockBodyModel blockBodyModel)
	{
		blockBodyModel.ParentBlockModel = this;
		blockBodyModel.Index = blockBodyModels.Count;
		blockBodyModel.BodySchematic = Schematic.GetBodySchematic(blockBodyModel.Index);
		blockBodyModels.Add(blockBodyModel);
	}

	public BlockBodyModel GetBlockBodyModel(int index)
	{
		return blockBodyModels[index];
	}

	public ICollection<BlockBodyModel> GetAllBlockBodyModels()
	{
		return blockBodyModels;
	}

	public void AddInterconnectedBlock(BlockModel blockModel)
	{
		if (!interconnectedBlockModels.Contains(blockModel))
		{
			blockModel.GroupLeaderBlockModel = this;
			interconnectedBlockModels.Add(blockModel);
		}
	}

	public void AddInterconnectedBlockRange(ICollection<BlockModel> blockModels)
	{
		foreach (BlockModel blockModel in blockModels)
		{
			AddInterconnectedBlock(blockModel);
		}
	}

	public void ClearInterconnectedBlocks()
	{
		interconnectedBlockModels.Clear();
		interconnectedBlockModels.Add(this);
		GroupLeaderBlockModel = this;
	}

	public ICollection<BlockModel> GetAllInterconnectedBlocks()
	{
		if (GroupLeaderBlockModel != this)
		{
			return GroupLeaderBlockModel.GetAllInterconnectedBlocks();
		}
		return interconnectedBlockModels.ToArray();
	}

	public ICollection<BlockModel> GetAllDirectConnectedBlocks()
	{
		List<BlockModel> list = new List<BlockModel>();
		foreach (BlockBodyModel blockBodyModel in blockBodyModels)
		{
			foreach (FixedJointModel item in blockBodyModel.GetAllFixedJointModel())
			{
				list.Add(item.ConnectedBlockBodyModel.ParentBlockModel);
			}
			foreach (HingeJointModel item2 in blockBodyModel.GetAllHingeJointModel())
			{
				list.Add(item2.ConnectedBlockBodyModel.ParentBlockModel);
			}
		}
		return list;
	}

	public ICollection<BlockModel> GetAllIndirectConnectedBlocks()
	{
		List<BlockModel> list = new List<BlockModel>();
		foreach (BlockBodyModel blockBodyModel in blockBodyModels)
		{
			foreach (FixedJointModel item in blockBodyModel.GetAllOutsideFixedJointModel())
			{
				list.Add(item.ParentBlockBodyModel.ParentBlockModel);
			}
			foreach (HingeJointModel item2 in blockBodyModel.GetAllOutsideHingeJointModel())
			{
				list.Add(item2.ParentBlockBodyModel.ParentBlockModel);
			}
		}
		return list;
	}

	public bool HasAnyComponentModels()
	{
		return blockBodyModels.Any((BlockBodyModel blockBodyModel) => blockBodyModel.HasComponentModel());
	}

	public bool HasAnyDefaultKeyIO()
	{
		return blockBodyModels.Any((BlockBodyModel blockBodyModel) => blockBodyModel.HasDefaultKeyIO());
	}

	public bool HasOnlyOutputDefaultKeyIOs()
	{
		return blockBodyModels.All((BlockBodyModel blockBodyModel) => blockBodyModel.HasOnlyOutputDefaultKeyIOs());
	}

	public bool HasOnlyHiddenDefaultKeyIOs()
	{
		return blockBodyModels.All((BlockBodyModel blockBodyModel) => blockBodyModel.HasOnlyHiddenDefaultKeyIOs());
	}

	public bool HasOnlyHingeJointIOs()
	{
		return blockBodyModels.All((BlockBodyModel blockBodyModel) => blockBodyModel.HasOnlyHingeJointIOs());
	}

	public bool HasAnyOverridableProperties()
	{
		return blockBodyModels.Any((BlockBodyModel blockBodyModel) => blockBodyModel.HasOverridableProperty());
	}

	public bool HasUserEditableProperties(bool shouldIncludeOnlyOutputKeys = false)
	{
		if (!HasAnyDefaultKeyIO() || HasOnlyHingeJointIOs() || !(!HasOnlyOutputDefaultKeyIOs() || shouldIncludeOnlyOutputKeys))
		{
			return HasAnyOverridableProperties();
		}
		return true;
	}

	public bool HasUserLogicEditableProperties()
	{
		if (HasAnyDefaultKeyIO() && !HasOnlyHiddenDefaultKeyIOs())
		{
			return !HasOnlyHingeJointIOs();
		}
		return false;
	}

	public bool HasAnyMotorComponent()
	{
		return blockBodyModels.Any((BlockBodyModel blockBodyModel) => blockBodyModel.HasMotorComponent());
	}
}
