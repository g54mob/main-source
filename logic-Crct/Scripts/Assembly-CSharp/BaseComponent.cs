using System;
using System.Collections.Generic;
using Simulation;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
	public bool created;

	public string componentName;

	public bool interactable;

	public bool isBreadboard;

	public bool eeprom;

	public bool canScope;

	public bool canAnalyse;

	public bool Debug;

	public Guid identifier;

	public int toolID;

	public int editID;

	public string snapGuide;

	public int prefabID;

	public CircuitModel circElm;

	public byte[] eepromData;

	[Header("Outline")]
	public QuickOutline[] outlines;

	public TiePoint[] tiePoints;

	public TiePointID[] tiePointIDs;

	protected Collider[] colliders;

	public bool validPosition;

	protected bool canSnap;

	protected Transform snapTransform;

	protected Vector3 snapPosition;

	protected Node[] nodes;

	protected List<List<Material>> stdMaterials;

	protected bool isAnalysing;

	public List<BaseComponent> children;

	protected bool finished;

	public bool selected;

	public bool scoped;

	public bool failed;

	protected Renderer[] renderers { get; set; }

	public virtual void SimAnalyze()
	{
	}

	public virtual void TickUpdate()
	{
	}

	public virtual void Analyse(Material overrideMat, bool xray)
	{
	}

	public virtual void Awake()
	{
	}

	public virtual void Analysis()
	{
	}

	public virtual void EndAnalysis()
	{
	}

	public virtual void AddChild(BaseComponent child)
	{
	}

	public virtual void RemoveChild(BaseComponent child)
	{
	}

	public virtual void CallUpdateToChildren(params object[] args)
	{
	}

	public virtual void ParentCalledUpdate(params object[] args)
	{
	}

	public virtual TiePoint FindTiePoint(int i)
	{
		return null;
	}

	public virtual void OnTriggerStay(Collider other)
	{
	}

	public virtual void OnTriggerExit(Collider other)
	{
	}

	public virtual void SnapEnter(Collider other)
	{
	}

	public virtual void SnapEnter(Collider other, Vector3 parent)
	{
	}

	public virtual void SnapExit(Collider other)
	{
	}

	public virtual void Snap()
	{
	}

	public virtual bool PositionValid()
	{
		return false;
	}

	public virtual bool PositionValid(BaseComponent c)
	{
		return false;
	}

	public virtual void FinishPlacement()
	{
	}

	public virtual void CompleteCreate()
	{
	}

	public virtual void BeginPlacement()
	{
	}

	public virtual void BeginMove()
	{
	}

	public void CollidersOff()
	{
	}

	public void CollidersOn()
	{
	}

	public virtual void CompleteMove()
	{
	}

	public virtual object[] ReturnSaveData()
	{
		return null;
	}

	public virtual object[] ReturnXMLSaveData()
	{
		return null;
	}

	public virtual void ProcessSaveData(object[] data)
	{
	}

	public virtual object[] VarData()
	{
		return null;
	}

	public virtual bool ValuesChanged(object[] data)
	{
		return false;
	}

	public virtual void ProcessVarData(object[] data)
	{
	}

	public virtual void Clear()
	{
	}

	public virtual void AttachToSim()
	{
	}

	public virtual void DetachFromSim()
	{
	}

	public virtual void Highlight(InteractionMode mode = InteractionMode.Selection)
	{
	}

	public virtual void HighlightOff()
	{
	}

	public virtual void Deselect()
	{
	}

	public virtual void Select()
	{
	}

	public virtual void Scope()
	{
	}

	public virtual void DeScope()
	{
	}

	public virtual TiePoint RaycastTiePoints(Vector3 worldHit, bool display)
	{
		return null;
	}

	public virtual void EndRaycast()
	{
	}

	public virtual void Fail()
	{
	}

	public virtual void Pass()
	{
	}

	public virtual void InteractDown()
	{
	}

	public virtual void InteractUp()
	{
	}

	public virtual void InteractClick()
	{
	}

	public virtual void InteractClick(int id)
	{
	}

	public virtual void CallCurrentUpdate(float current)
	{
	}

	public virtual void ReattachToSim()
	{
	}
}
