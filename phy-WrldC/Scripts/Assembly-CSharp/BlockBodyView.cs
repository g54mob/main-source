using System;
using System.Collections.Generic;
using UltimateReplay;
using UnityEngine;
using cakeslice;

public class BlockBodyView : MonoBehaviour
{
	private class ChildMaterials
	{
		private Renderer childRenderer;

		private Material normalMaterial;

		private Material transparentMaterial;

		public ChildMaterials(Renderer childRenderer)
		{
			this.childRenderer = childRenderer;
			normalMaterial = childRenderer.material;
			transparentMaterial = new Material(normalMaterial);
			Util.TurnStandardMaterialToFade(transparentMaterial);
		}

		public void SetNormalMaterial()
		{
			childRenderer.material = normalMaterial;
		}

		public void SetTransparentMaterial()
		{
			childRenderer.material = transparentMaterial;
		}

		public void SetMaterialTransparency(float value)
		{
			childRenderer.material.color = childRenderer.material.color.WithChange(null, null, null, value);
		}

		public Renderer GetRenderer()
		{
			return childRenderer;
		}
	}

	public List<Material> NomalMaterials = new List<Material>();

	public List<Material> TransparentMaterials = new List<Material>();

	private readonly List<FixedJointView> fixedJointViews = new List<FixedJointView>();

	private readonly List<HingeJointView> hingeJointViews = new List<HingeJointView>();

	private readonly List<FixedJointView> outsideFixedJoints = new List<FixedJointView>();

	private readonly List<HingeJointView> outsideHingeJoints = new List<HingeJointView>();

	private Dictionary<string, LogicIO> logicIOs = new Dictionary<string, LogicIO>();

	private readonly List<BlockBodyView> interconnectedBlockBodyViews = new List<BlockBodyView>();

	private float collisionSpeedThreshold = 500f;

	private Renderer thisRenderer;

	private MeshRenderer thisMeshRenderer;

	private Collider[] thisAllColliders;

	private List<BaseComponentView> componentViews;

	private List<ChildMaterials> childrenMaterials;

	private List<Outline> childrenOutlines;

	private Outline outline;

	public BlockView ParentBlockView { get; set; }

	public int Index { get; set; }

	public BodySchematic BodySchematic { get; set; }

	public MaterialSchematic MaterialSchematic { get; set; }

	public Rigidbody BlockRigidbody { get; set; }

	public ReplayObject ReplayObject { get; set; }

	public Properties OverridableProperties { get; } = new Properties();

	public BlockBodyView GroupLeaderBlockBodyView { get; set; }

	public bool ShouldIncludeChildrenInAllHighlights { get; set; }

	public event Action OnSetUpToActionEvent;

	public event Action<bool> OnSetMaterialEvent;

	public event Action<float> OnSetMaterialTransparencyEvent;

	public event Action OnBeforeDestroyBlockEvent;

	private void Awake()
	{
		thisRenderer = GetComponent<Renderer>();
		thisMeshRenderer = GetComponent<MeshRenderer>();
		thisAllColliders = GetComponents<Collider>();
		componentViews = new List<BaseComponentView>();
		childrenMaterials = new List<ChildMaterials>();
		childrenOutlines = new List<Outline>();
		Renderer[] componentsInChildren = base.transform.GetComponentsInChildren<Renderer>(includeInactive: true);
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer.transform == base.transform)
			{
				continue;
			}
			if (!(renderer is SkinnedMeshRenderer))
			{
				childrenMaterials.Add(new ChildMaterials(renderer));
			}
			if (renderer is MeshRenderer)
			{
				Outline outline = renderer.gameObject.GetComponent<Outline>();
				if (outline == null)
				{
					outline = renderer.gameObject.AddComponent<Outline>();
				}
				outline.enabled = false;
				childrenOutlines.Add(outline);
			}
		}
		ShouldIncludeChildrenInAllHighlights = false;
		ClearInterconnectedBlockBodies();
	}

	private void OnJointBreak(float breakForce)
	{
		ParentBlockView.ParentCreationView.OrderAnInterconnectionsUpdate();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (ParentBlockView.IsDestroyed)
		{
			return;
		}
		float magnitude = collision.relativeVelocity.magnitude;
		if (!(magnitude >= collisionSpeedThreshold))
		{
			return;
		}
		GameObject gameObject = collision.gameObject;
		bool flag = false;
		float num = 0f;
		float num2 = 0f;
		if (gameObject.CompareTag("Block"))
		{
			BlockView blockView = gameObject.GetBlockView();
			if (blockView == ParentBlockView)
			{
				return;
			}
			if (!blockView.IsDestroyed)
			{
				num = blockView.ImpactAttack;
				num2 = blockView.PiercingAttack;
			}
			else
			{
				num = (float)blockView.ImpactAttack * 0.4f;
				num2 = (float)blockView.PiercingAttack * 0.4f;
			}
			flag = true;
		}
		else if (gameObject.CompareTag("Level"))
		{
			num = 10f;
			num2 = 1f;
			flag = true;
		}
		if (flag)
		{
			float num3 = magnitude / collisionSpeedThreshold;
			float num4 = num * num3 - (float)ParentBlockView.ImpactResistence;
			float num5 = num2 * num3 - (float)ParentBlockView.PiercingResistence;
			float num6 = ((num4 > 0f) ? num4 : 0f) + ((num5 > 0f) ? num5 : 0f);
			ParentBlockView.Health -= num6;
			Debug.Log(ParentBlockView.Schematic.Id + "[" + ParentBlockView.Health + "] <<<< " + num6);
		}
	}

	public void SetUpToAction()
	{
		if (ReplayObject != null)
		{
			ReplayObject.RebuildComponentList();
		}
		BlockRigidbody.isKinematic = false;
		foreach (BaseComponentView componentView in componentViews)
		{
			componentView.SetUpToAction();
		}
		this.OnSetUpToActionEvent?.Invoke();
	}

	public void AddFixedJointView(FixedJointView fixedJointView)
	{
		fixedJointView.ParentBlockBodyView = this;
		fixedJointView.Index = fixedJointViews.Count;
		fixedJointViews.Add(fixedJointView);
		_ = fixedJointView.ConnectedBlockBodyView.ParentBlockView;
	}

	public FixedJointView GetFixedJointView(int index)
	{
		return fixedJointViews[index];
	}

	public ICollection<FixedJointView> GetAllFixedJointViews()
	{
		return fixedJointViews.ToArray();
	}

	public void RemoveFixedJointView(FixedJointView fixedJointView)
	{
		fixedJointViews.Remove(fixedJointView);
		if (fixedJointView.FixedJoint != null)
		{
			UnityEngine.Object.Destroy(fixedJointView.FixedJoint);
		}
		for (int i = 0; i < fixedJointViews.Count; i++)
		{
			fixedJointViews[i].Index = i;
		}
	}

	public void AddHingeJointView(HingeJointView newHingeJointView)
	{
		newHingeJointView.ParentBlockBodyView = this;
		newHingeJointView.Index = hingeJointViews.Count;
		hingeJointViews.Add(newHingeJointView);
		_ = newHingeJointView.ConnectedBlockBodyView.ParentBlockView;
	}

	public HingeJointView GetHingeJointView(int index)
	{
		return hingeJointViews[index];
	}

	public ICollection<HingeJointView> GetAllHingeJointViews()
	{
		return hingeJointViews.ToArray();
	}

	public void RemoveHingeJointView(HingeJointView hingeJointView, bool shouldKeepModelInfos = false)
	{
		if (!shouldKeepModelInfos)
		{
			hingeJointView.RemoveSpecializedJointViews();
		}
		if (hingeJointView.MotorBodyBlockView != null)
		{
			hingeJointView.MotorBodyBlockView.GetComponent<MotorView>().RemoveHingeJointView(hingeJointView);
		}
		hingeJointViews.Remove(hingeJointView);
		if (hingeJointView.HingeJoint != null)
		{
			UnityEngine.Object.Destroy(hingeJointView.HingeJoint);
		}
		for (int i = 0; i < hingeJointViews.Count; i++)
		{
			hingeJointViews[i].Index = i;
		}
	}

	public void AddOutsideFixedJoint(FixedJointView fixedJointView)
	{
		outsideFixedJoints.Add(fixedJointView);
	}

	public void RemoveOutsideFixedJoint(FixedJointView fixedJointView)
	{
		outsideFixedJoints.Remove(fixedJointView);
	}

	public ICollection<FixedJointView> GetAllOutsideFixedJoints()
	{
		return outsideFixedJoints.ToArray();
	}

	public void AddOutsideHingeJoint(HingeJointView hingeJointView)
	{
		outsideHingeJoints.Add(hingeJointView);
	}

	public void RemoveOutsideHingeJoint(HingeJointView hingeJointView)
	{
		outsideHingeJoints.Remove(hingeJointView);
	}

	public ICollection<HingeJointView> GetAllOutsideHingeJoints()
	{
		return outsideHingeJoints.ToArray();
	}

	public void RemoveAllJoints(bool shouldKeepModelInfos = false)
	{
		FixedJointView[] array = fixedJointViews.ToArray();
		foreach (FixedJointView fixedJointView in array)
		{
			if (fixedJointView.FixedJoint != null && fixedJointView.FixedJoint.connectedBody != null)
			{
				fixedJointView.ConnectedBlockBodyView.RemoveOutsideFixedJoint(fixedJointView);
			}
			RemoveFixedJointView(fixedJointView);
		}
		HingeJointView[] array2 = hingeJointViews.ToArray();
		foreach (HingeJointView hingeJointView in array2)
		{
			if (hingeJointView.HingeJoint != null && hingeJointView.HingeJoint.connectedBody != null)
			{
				hingeJointView.ConnectedBlockBodyView.RemoveOutsideHingeJoint(hingeJointView);
			}
			RemoveHingeJointView(hingeJointView, shouldKeepModelInfos);
		}
		array = outsideFixedJoints.ToArray();
		foreach (FixedJointView fixedJointView2 in array)
		{
			fixedJointView2.ParentBlockBodyView.RemoveFixedJointView(fixedJointView2);
		}
		array2 = outsideHingeJoints.ToArray();
		foreach (HingeJointView hingeJointView2 in array2)
		{
			hingeJointView2.ParentBlockBodyView.RemoveHingeJointView(hingeJointView2, shouldKeepModelInfos);
		}
		fixedJointViews.Clear();
		outsideFixedJoints.Clear();
		hingeJointViews.Clear();
		outsideHingeJoints.Clear();
	}

	public void AddInterconnectedBlockBodyView(BlockBodyView blockBodyView)
	{
		if (!interconnectedBlockBodyViews.Contains(blockBodyView))
		{
			blockBodyView.GroupLeaderBlockBodyView = this;
			interconnectedBlockBodyViews.Add(blockBodyView);
		}
	}

	public void AddInterconnectedBlockBodyViewRange(ICollection<BlockBodyView> blockBodyViews)
	{
		foreach (BlockBodyView blockBodyView in blockBodyViews)
		{
			AddInterconnectedBlockBodyView(blockBodyView);
		}
	}

	public void ClearInterconnectedBlockBodies()
	{
		interconnectedBlockBodyViews.Clear();
		interconnectedBlockBodyViews.Add(this);
		GroupLeaderBlockBodyView = this;
	}

	public ICollection<BlockBodyView> GetAllInterconnectedBlockBodies()
	{
		if (GroupLeaderBlockBodyView != this)
		{
			return GroupLeaderBlockBodyView.GetAllInterconnectedBlockBodies();
		}
		return interconnectedBlockBodyViews.ToArray();
	}

	public ICollection<BlockBodyView> GetAllDirectConnectedBlockBodies()
	{
		List<BlockBodyView> list = new List<BlockBodyView>();
		foreach (FixedJointView allFixedJointView in GetAllFixedJointViews())
		{
			if (allFixedJointView.FixedJoint != null && allFixedJointView.FixedJoint.connectedBody != null)
			{
				list.Add(allFixedJointView.ConnectedBlockBodyView);
			}
		}
		foreach (HingeJointView allHingeJointView in GetAllHingeJointViews())
		{
			if (allHingeJointView.HingeJoint != null && allHingeJointView.HingeJoint.connectedBody != null)
			{
				list.Add(allHingeJointView.ConnectedBlockBodyView);
			}
		}
		return list;
	}

	public ICollection<BlockBodyView> GetAllIndirectConnectedBlockBodies()
	{
		List<BlockBodyView> list = new List<BlockBodyView>();
		foreach (FixedJointView allOutsideFixedJoint in GetAllOutsideFixedJoints())
		{
			if (allOutsideFixedJoint.FixedJoint != null && allOutsideFixedJoint.FixedJoint.connectedBody != null)
			{
				list.Add(allOutsideFixedJoint.ParentBlockBodyView);
			}
		}
		foreach (HingeJointView allOutsideHingeJoint in GetAllOutsideHingeJoints())
		{
			if (allOutsideHingeJoint.HingeJoint != null && allOutsideHingeJoint.HingeJoint.connectedBody != null)
			{
				list.Add(allOutsideHingeJoint.ParentBlockBodyView);
			}
		}
		return list;
	}

	public ICollection<BlockBodyView> GetAllComponentConnectedBlockBodies()
	{
		List<BlockBodyView> list = new List<BlockBodyView>();
		bool flag = false;
		foreach (BlockBodyView allBlockBodyView in ParentBlockView.GetAllBlockBodyViews())
		{
			foreach (BaseComponentView allComponentView in allBlockBodyView.GetAllComponentViews())
			{
				if (allComponentView.IsBodiesSplited)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			foreach (BlockBodyView allBlockBodyView2 in ParentBlockView.GetAllBlockBodyViews())
			{
				if (!(allBlockBodyView2 == this))
				{
					list.Add(allBlockBodyView2);
				}
			}
		}
		return list;
	}

	public BaseComponentView GetComponentView(string name)
	{
		Type type = Type.GetType(name);
		if (type == null)
		{
			return null;
		}
		return GetComponent(type) as BaseComponentView;
	}

	public LogicIO AddLogicIO(LogicIO logicInput)
	{
		logicInput.ParentBlockBodyView = this;
		logicIOs.Add(logicInput.Name, logicInput);
		return logicInput;
	}

	public void RemoveLogicIO(LogicIO logicIO)
	{
		logicIO.DetachAllSocketIOs();
		logicIOs.Remove(logicIO.Name);
	}

	public void RemoveAllLogicIOs()
	{
		foreach (LogicIO value in logicIOs.Values)
		{
			foreach (SocketIO socketIO in value.SocketIOs)
			{
				socketIO.RemoveLogicIO();
			}
			value.SocketIOs.Clear();
		}
		logicIOs.Clear();
	}

	public LogicIO GetLogicIO(string name)
	{
		if (!logicIOs.ContainsKey(name))
		{
			return null;
		}
		return logicIOs[name];
	}

	public ICollection<LogicIO> GetAllLogicIOs()
	{
		return logicIOs.Values;
	}

	public void DetachAllLogicIOs()
	{
		foreach (LogicIO value in logicIOs.Values)
		{
			value.DetachAllSocketIOs();
		}
	}

	public void SetIOKeysOverwritability(string[] ioKeysIds, bool shouldOverwrite)
	{
		ParentBlockView.SetIOKeysOverwritability(Index, ioKeysIds, shouldOverwrite);
	}

	public void SetMaterial(Material material)
	{
		thisRenderer.material = material;
		if (material == BodySchematic.MainMaterial)
		{
			childrenMaterials.ForEach(delegate(ChildMaterials child)
			{
				child.SetNormalMaterial();
			});
		}
		else if (material == BodySchematic.TransparentMaterial)
		{
			childrenMaterials.ForEach(delegate(ChildMaterials child)
			{
				child.SetTransparentMaterial();
			});
		}
		this.OnSetMaterialEvent?.Invoke(material == BodySchematic.MainMaterial);
	}

	public void SetMaterialTransparency(float value)
	{
		thisRenderer.material.color = thisRenderer.material.color.WithChange(null, null, null, value);
		for (int i = 0; i < childrenMaterials.Count; i++)
		{
			childrenMaterials[i].SetMaterialTransparency(value);
		}
		this.OnSetMaterialTransparencyEvent?.Invoke(value);
	}

	public void SetOutline(bool isEnabled, int colorLine = 0, bool shouldIncludeChildren = false)
	{
		if (outline == null)
		{
			outline = GetComponent<Outline>();
		}
		if (!(outline == null))
		{
			outline.enabled = isEnabled;
			outline.color = colorLine;
			for (int i = 0; i < childrenOutlines.Count; i++)
			{
				childrenOutlines[i].enabled = isEnabled && (shouldIncludeChildren || ShouldIncludeChildrenInAllHighlights);
				childrenOutlines[i].color = colorLine;
			}
		}
	}

	public void SetVisibility(bool isVisible)
	{
		thisMeshRenderer.enabled = isVisible;
	}

	public void SetComponentsGizmosVisibility(bool isVisible)
	{
		foreach (BaseComponentView allComponentView in GetAllComponentViews())
		{
			allComponentView.SetGizmosVisibility(isVisible);
		}
	}

	public Bounds GetMeshRendererBounds()
	{
		return thisMeshRenderer.bounds;
	}

	public void BeforeDestroyBlock()
	{
		this.OnBeforeDestroyBlockEvent?.Invoke();
	}

	public Collider[] GetAllBodyColliders()
	{
		return thisAllColliders;
	}

	public void RefreshAllBodyColliders()
	{
		thisAllColliders = GetComponents<Collider>();
	}

	public void AddComponentView(BaseComponentView componentView)
	{
		componentViews.Add(componentView);
	}

	public ICollection<BaseComponentView> GetAllComponentViews()
	{
		return componentViews;
	}

	public TComponent GetComponentView<TComponent>() where TComponent : BaseComponentView
	{
		foreach (BaseComponentView componentView in componentViews)
		{
			if (componentView is TComponent)
			{
				return componentView as TComponent;
			}
		}
		return null;
	}

	public void AddChildObject(GameObject childObject)
	{
		Outline outline = childObject.GetComponent<Outline>();
		if (outline == null)
		{
			outline = childObject.AddComponent<Outline>();
		}
		outline.enabled = false;
		childrenOutlines.Add(outline);
		Renderer component = childObject.GetComponent<Renderer>();
		childrenMaterials.Add(new ChildMaterials(component));
	}

	public void RemoveChildObject(GameObject childObject)
	{
		Outline component = childObject.GetComponent<Outline>();
		if (childObject != null)
		{
			childrenOutlines.Remove(component);
		}
		Renderer component2 = childObject.GetComponent<Renderer>();
		ChildMaterials childMaterials = null;
		foreach (ChildMaterials childrenMaterial in childrenMaterials)
		{
			if (component2 == childrenMaterial.GetRenderer())
			{
				childMaterials = childrenMaterial;
				break;
			}
		}
		if (childMaterials != null)
		{
			childrenMaterials.Remove(childMaterials);
		}
	}
}
