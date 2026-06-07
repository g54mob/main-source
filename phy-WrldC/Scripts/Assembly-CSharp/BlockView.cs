using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour, IRecyclableObject
{
	public enum BlockRendererTypeEnum
	{
		None = 0,
		Placeholder = 1,
		Button3D = 2,
		Model = 3,
		Rigid = 4
	}

	private Schematic schematic;

	private float health;

	private readonly List<BlockBodyView> blockBodyViews = new List<BlockBodyView>();

	private readonly List<BlockView> interconnectedBlockViews = new List<BlockView>();

	public CreationView ParentCreationView { get; set; }

	public int Id { get; set; }

	public string ObjectTypeId { get; set; }

	public BlockRendererTypeEnum BlockRendererType { get; set; }

	public int ImpactAttack { get; private set; }

	public int ImpactResistence { get; private set; }

	public int PiercingAttack { get; private set; }

	public int PiercingResistence { get; private set; }

	public int LaserResistence { get; private set; }

	public BlockView GroupLeaderBlockView { get; set; }

	public bool IsDestroyed { get; private set; }

	public Schematic Schematic
	{
		get
		{
			return schematic;
		}
		set
		{
			schematic = value;
			Health = schematic.Health;
			ImpactAttack = schematic.ImpactAttack;
			ImpactResistence = schematic.ImpactResistence;
			PiercingAttack = schematic.PiercingAttack;
			PiercingResistence = schematic.PiercingResistence;
			LaserResistence = schematic.LaserResistence;
		}
	}

	public float Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
			if (!(health <= 0f) || IsDestroyed)
			{
				return;
			}
			IsDestroyed = true;
			foreach (BlockBodyView allBlockBodyView in GetAllBlockBodyViews())
			{
				allBlockBodyView.BeforeDestroyBlock();
				foreach (BaseComponentView allComponentView in allBlockBodyView.GetAllComponentViews())
				{
					allComponentView.SetBlockDestroyed();
				}
				allBlockBodyView.RemoveAllJoints(shouldKeepModelInfos: true);
			}
			ParentCreationView.OrderAnInterconnectionsUpdate();
			if (this.BlockDestroyedEvent != null)
			{
				this.BlockDestroyedEvent();
			}
		}
	}

	public event Action BlockDestroyedEvent;

	private void Awake()
	{
		ClearInterconnectedBlocks();
	}

	public void AddBlockBodyView(BlockBodyView blockBodyView)
	{
		blockBodyView.ParentBlockView = this;
		blockBodyView.Index = blockBodyViews.Count;
		blockBodyView.BodySchematic = schematic.GetBodySchematic(blockBodyView.Index);
		blockBodyView.MaterialSchematic = blockBodyView.BodySchematic.ParentSchematic.MaterialSchematic;
		blockBodyViews.Add(blockBodyView);
	}

	public BlockBodyView GetBlockBodyView(int index)
	{
		return blockBodyViews[index];
	}

	public ICollection<BlockBodyView> GetAllBlockBodyViews()
	{
		return blockBodyViews;
	}

	public int BlockBodyViewsCount()
	{
		return blockBodyViews.Count;
	}

	public TComponent GetComponentView<TComponent>() where TComponent : BaseComponentView
	{
		foreach (BlockBodyView blockBodyView in blockBodyViews)
		{
			TComponent componentView = blockBodyView.GetComponentView<TComponent>();
			if (componentView != null)
			{
				return componentView;
			}
		}
		return null;
	}

	public void AddInterconnectedBlock(BlockView blockView)
	{
		if (!interconnectedBlockViews.Contains(blockView))
		{
			blockView.GroupLeaderBlockView = this;
			interconnectedBlockViews.Add(blockView);
		}
	}

	public void AddInterconnectedBlockRange(ICollection<BlockView> blockViews)
	{
		foreach (BlockView blockView in blockViews)
		{
			AddInterconnectedBlock(blockView);
		}
	}

	public void ClearInterconnectedBlocks()
	{
		interconnectedBlockViews.Clear();
		interconnectedBlockViews.Add(this);
		GroupLeaderBlockView = this;
	}

	public ICollection<BlockView> GetAllInterconnectedBlocks()
	{
		if (GroupLeaderBlockView != this)
		{
			return GroupLeaderBlockView.GetAllInterconnectedBlocks();
		}
		return interconnectedBlockViews.ToArray();
	}

	public ICollection<BlockView> GetAllDirectConnectedBlocks()
	{
		List<BlockView> list = new List<BlockView>();
		foreach (BlockBodyView blockBodyView in blockBodyViews)
		{
			foreach (FixedJointView allFixedJointView in blockBodyView.GetAllFixedJointViews())
			{
				if (allFixedJointView.FixedJoint != null && allFixedJointView.FixedJoint.connectedBody != null)
				{
					list.Add(allFixedJointView.ConnectedBlockBodyView.ParentBlockView);
				}
			}
			foreach (HingeJointView allHingeJointView in blockBodyView.GetAllHingeJointViews())
			{
				if (allHingeJointView.HingeJoint != null && allHingeJointView.HingeJoint.connectedBody != null)
				{
					list.Add(allHingeJointView.ConnectedBlockBodyView.ParentBlockView);
				}
			}
		}
		return list;
	}

	public ICollection<BlockView> GetAllIndirectConnectedBlocks()
	{
		List<BlockView> list = new List<BlockView>();
		foreach (BlockBodyView blockBodyView in blockBodyViews)
		{
			foreach (FixedJointView allOutsideFixedJoint in blockBodyView.GetAllOutsideFixedJoints())
			{
				if (allOutsideFixedJoint.FixedJoint != null && allOutsideFixedJoint.FixedJoint.connectedBody != null)
				{
					list.Add(allOutsideFixedJoint.ParentBlockBodyView.ParentBlockView);
				}
			}
			foreach (HingeJointView allOutsideHingeJoint in blockBodyView.GetAllOutsideHingeJoints())
			{
				if (allOutsideHingeJoint.HingeJoint != null && allOutsideHingeJoint.HingeJoint.connectedBody != null)
				{
					list.Add(allOutsideHingeJoint.ParentBlockBodyView.ParentBlockView);
				}
			}
		}
		return list;
	}

	public void SetOutline(bool isEnabled, int colorLine = 0)
	{
		foreach (BlockBodyView blockBodyView in blockBodyViews)
		{
			blockBodyView.SetOutline(isEnabled, colorLine);
		}
	}

	public void SetVisibility(bool isVisible)
	{
		foreach (BlockBodyView blockBodyView in blockBodyViews)
		{
			blockBodyView.SetVisibility(isVisible);
		}
	}

	public void SetComponentsGizmosVisibility(bool isVisible)
	{
		foreach (BlockBodyView blockBodyView in blockBodyViews)
		{
			blockBodyView.SetComponentsGizmosVisibility(isVisible);
		}
	}

	public void SetIOKeysOverwritability(int bodyIndex, string[] ioKeysIds, bool shouldOverwrite)
	{
		ParentCreationView.SetIOKeysOverwritability(Id, bodyIndex, ioKeysIds, shouldOverwrite);
	}

	public void OnInstantiation()
	{
	}

	public void OnUnistantiation()
	{
		base.transform.localScale = Vector3.one;
		ParentCreationView = null;
		Health = schematic.Health;
		IsDestroyed = false;
		this.BlockDestroyedEvent = null;
		ClearInterconnectedBlocks();
		bool flag = false;
		foreach (BlockBodyView allBlockBodyView in GetAllBlockBodyViews())
		{
			if (allBlockBodyView.BlockRigidbody != null)
			{
				allBlockBodyView.BlockRigidbody.isKinematic = true;
			}
			allBlockBodyView.transform.localPosition = Vector3.zero;
			allBlockBodyView.transform.localRotation = Quaternion.identity;
			allBlockBodyView.transform.localScale = Vector3.one;
			allBlockBodyView.RemoveAllJoints(shouldKeepModelInfos: true);
			allBlockBodyView.RemoveAllLogicIOs();
			allBlockBodyView.OverridableProperties.RemoveAllProperties();
			foreach (BaseComponentView allComponentView in allBlockBodyView.GetAllComponentViews())
			{
				allComponentView.ResetComponent();
			}
			AudioEffectBase[] components = allBlockBodyView.transform.GetComponents<AudioEffectBase>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].ResetAudioEffect();
			}
			allBlockBodyView.SetVisibility(isVisible: true);
			allBlockBodyView.SetMaterial(allBlockBodyView.BodySchematic.MainMaterial);
			allBlockBodyView.SetOutline(isEnabled: false);
			allBlockBodyView.SetComponentsGizmosVisibility(isVisible: true);
			if (allBlockBodyView.BodySchematic.IsTwoPointBlock)
			{
				if (BlockRendererType != BlockRendererTypeEnum.Placeholder)
				{
					TwoPointBlock component = allBlockBodyView.GetComponent<TwoPointBlock>();
					if (component != null)
					{
						component.ResetMesh();
						UnityEngine.Object.Destroy(component);
					}
				}
				flag = true;
			}
			allBlockBodyView.ClearInterconnectedBlockBodies();
		}
		if (flag && BlockRendererType == BlockRendererTypeEnum.Placeholder)
		{
			TwoPointBlock[] componentsInChildren = base.transform.GetComponentsInChildren<TwoPointBlock>(includeInactive: true);
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].ResetMesh();
				UnityEngine.Object.Destroy(componentsInChildren[j]);
			}
		}
	}
}
