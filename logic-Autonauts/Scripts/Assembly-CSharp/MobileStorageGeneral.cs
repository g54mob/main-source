using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Rendering;

public class MobileStorageGeneral : MobileStorage
{
	private List<Holdable> m_Objects;

	private GameObject m_ContentsPoint;

	private int[][] m_Triangles;

	private int m_AddedAmount;

	private ObjectType m_LastObjectType;

	private bool m_ShowContents;

	public static bool GetIsTypeMobileStorageGeneral(ObjectType NewType)
	{
		if (NewType == ObjectType.Cart || NewType == ObjectType.WheelBarrow || Carriage.GetIsTypeCarriageGeneral(NewType) || NewType == ObjectType.TrojanRabbit)
		{
			return true;
		}
		return false;
	}

	public static bool GetIsTypeCartLiquid(ObjectType NewType)
	{
		if (NewType == ObjectType.CartLiquid || Carriage.GetIsTypeCarriageLiquid(NewType))
		{
			return true;
		}
		return false;
	}

	public override void Restart()
	{
		base.Restart();
		m_Objects = new List<Holdable>();
		if (GetIsLiquid())
		{
			m_Capacity = VariableManager.Instance.GetVariableAsInt(m_TypeIdentifier, "WeightCapacity");
		}
		m_ShowContents = true;
		UpdateStored();
	}

	public override void PostCreate()
	{
		base.PostCreate();
		if ((bool)m_ModelRoot.transform.Find("ContentsPoint"))
		{
			m_ContentsPoint = m_ModelRoot.transform.Find("ContentsPoint").gameObject;
			m_ContentsPoint.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}
	}

	public override void StopUsing(bool AndDestroy = true)
	{
		foreach (Holdable @object in m_Objects)
		{
			@object.SendAction(new ActionInfo(ActionType.Dropped, m_TileCoord, this));
		}
		base.StopUsing(AndDestroy);
	}

	public override void Save(JSONNode Node)
	{
		base.Save(Node);
		JSONArray jSONArray = (JSONArray)(Node["Objects"] = new JSONArray());
		int num = 0;
		foreach (Holdable @object in m_Objects)
		{
			JSONNode jSONNode2 = new JSONObject();
			string saveNameFromIdentifier = ObjectTypeList.Instance.GetSaveNameFromIdentifier(@object.m_TypeIdentifier);
			JSONUtils.Set(jSONNode2, "ID", saveNameFromIdentifier);
			@object.GetComponent<Savable>().Save(jSONNode2);
			jSONArray[num] = jSONNode2;
			num++;
		}
	}

	public override void Load(JSONNode Node)
	{
		JSONArray asArray = Node["Objects"].AsArray;
		if (asArray != null && !asArray.IsNull)
		{
			for (int i = 0; i < asArray.Count; i++)
			{
				JSONNode asObject = asArray[i].AsObject;
				BaseClass baseClass = ObjectTypeList.Instance.CreateObjectFromSaveName(asObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				if ((bool)baseClass)
				{
					baseClass.GetComponent<Savable>().Load(asObject);
					AddObject(baseClass.GetComponent<Holdable>());
				}
			}
		}
		base.Load(Node);
	}

	protected void DontShowContents()
	{
		m_ShowContents = false;
		UpdateStored();
	}

	protected override void UpdateStored()
	{
		base.UpdateStored();
		UpdateStoredModel();
	}

	protected override void SetObjectType(ObjectType NewType)
	{
		m_ObjectType = NewType;
		if (!GetIsLiquid())
		{
			m_Capacity = 0;
			if (NewType != ObjectTypeList.m_Total)
			{
				m_Capacity = m_WeightCapacity / Holdable.GetWeight(NewType);
			}
		}
		if (m_Stored > m_Capacity)
		{
			m_Stored = m_Capacity;
		}
		SetSign(NewType);
		SetupObjectMesh();
		UpdateStoredModel();
	}

	private void AddObject(Holdable NewObject)
	{
		m_Objects.Add(NewObject);
		NewObject.SendAction(new ActionInfo(ActionType.BeingHeld, default(TileCoord), this));
	}

	private Holdable ReleaseObject()
	{
		Holdable holdable = m_Objects[m_Objects.Count - 1];
		m_Objects.Remove(holdable);
		holdable.SendAction(new ActionInfo(ActionType.Dropped, m_TileCoord));
		return holdable;
	}

	private bool GetIsLiquid()
	{
		return GetIsTypeCartLiquid(m_TypeIdentifier);
	}

	private void StartAdd(AFO Info)
	{
		Actionable actionable = Info.m_Object;
		actionable.transform.position = m_ModelRoot.transform.position;
		if (m_ObjectType == ObjectTypeList.m_Total)
		{
			SetObjectType(actionable.m_TypeIdentifier);
			if (actionable.m_TypeIdentifier == ObjectType.Folk)
			{
				AddObject(actionable.GetComponent<Holdable>());
			}
		}
		AudioManager.Instance.StartEvent("BuildingStorageAdd", this);
		AddToStored(actionable.m_TypeIdentifier, 1, Info.m_Actioner);
	}

	private void EndAdd(AFO Info)
	{
		Actionable actionable = Info.m_Object;
		if (actionable.m_TypeIdentifier != ObjectType.Folk)
		{
			actionable.StopUsing();
		}
		UpdateStored();
	}

	private void AbortAdd(AFO Info)
	{
		Actionable actionable = Info.m_Object;
		ReleaseStored(actionable.m_TypeIdentifier, Info.m_Actioner);
		if (actionable.m_TypeIdentifier == ObjectType.Folk)
		{
			m_Objects.Remove(actionable.GetComponent<Holdable>());
		}
	}

	private ActionType GetSecondaryActionFromObject(AFO Info)
	{
		Info.m_StartAction = StartAdd;
		Info.m_EndAction = EndAdd;
		Info.m_AbortAction = AbortAdd;
		Info.m_FarmerState = Farmer.State.Adding;
		if (m_State != State.None)
		{
			return ActionType.Fail;
		}
		if (!CanAcceptObject(Info.m_Object, Info.m_ObjectType))
		{
			return ActionType.Fail;
		}
		return ActionType.AddResource;
	}

	private void StartRelease(AFO Info)
	{
		if (m_ObjectType != ObjectTypeList.m_Total && GetStored() > 0)
		{
			if (m_ObjectType == ObjectType.Folk)
			{
				Holdable component = m_Objects[m_Objects.Count - 1].GetComponent<Holdable>();
				m_Objects.Remove(component);
				Info.m_Actioner.GetComponent<Farmer>().m_FarmerCarry.AddTempCarry(component);
			}
			else
			{
				Info.m_Actioner.GetComponent<Farmer>().m_FarmerCarry.AddTempCarry(m_ObjectType);
			}
			ReleaseStored(m_ObjectType, Info.m_Actioner);
			AddAnimationManager.Instance.Add(this, false);
			AudioManager.Instance.StartEvent("BuildingStorageTake", this);
			UpdateStored();
		}
	}

	private void AbortRelease(AFO Info)
	{
		if (m_ObjectType == ObjectType.Folk)
		{
			AddObject(Info.m_Actioner.GetComponent<Farmer>().m_FarmerCarry.GetTempObject());
		}
		else
		{
			Info.m_Actioner.GetComponent<Farmer>().m_FarmerCarry.RemoveTempCarry();
		}
		AddToStored(m_ObjectType, 1, Info.m_Actioner);
	}

	public bool CanReleaseObject()
	{
		if (m_State != State.None)
		{
			return false;
		}
		if (m_ObjectType == ObjectTypeList.m_Total)
		{
			return false;
		}
		return GetStored() > 0;
	}

	private ActionType GetPrimaryActionFromObject(AFO Info)
	{
		Info.m_StartAction = StartRelease;
		Info.m_AbortAction = AbortRelease;
		Info.m_FarmerState = Farmer.State.Taking;
		if (m_State != State.None)
		{
			return ActionType.Fail;
		}
		if (!CanReleaseObject())
		{
			return ActionType.Fail;
		}
		if ((bool)Info.m_Actioner && Info.m_Actioner.m_TypeIdentifier == ObjectType.Worker)
		{
			Worker component = Info.m_Actioner.GetComponent<Worker>();
			if (component.m_FarmerCarry.GetTopObjectType() != ObjectTypeList.m_Total)
			{
				if (component.m_FarmerCarry.GetTopObjectType() != m_ObjectType)
				{
					return ActionType.Total;
				}
				if (!Info.m_Actioner.GetComponent<Worker>().m_FarmerCarry.CanAddCarry(m_ObjectType))
				{
					return ActionType.Fail;
				}
			}
		}
		return ActionType.TakeResource;
	}

	private void StartRemoveFillable(AFO Info)
	{
		ToolFillable component = Info.m_Object.GetComponent<ToolFillable>();
		m_AddedAmount = component.GetSpace();
		if (m_AddedAmount > m_Stored)
		{
			m_AddedAmount = m_Stored;
		}
		m_LastObjectType = m_ObjectType;
		ReleaseStored(m_ObjectType, Info.m_Actioner, m_AddedAmount);
		AddAnimationManager.Instance.Add(this, false);
		AudioManager.Instance.StartEvent("BuildingStorageTake", this);
		UpdateStored();
	}

	private void EndRemoveFillable(AFO Info)
	{
		Info.m_Object.GetComponent<ToolFillable>().Fill(m_LastObjectType, m_AddedAmount);
	}

	private void AbortRemoveFillable(AFO Info)
	{
		AddToStored(m_ObjectType, m_AddedAmount, Info.m_Actioner);
		Info.m_Object.GetComponent<ToolFillable>().Empty(m_AddedAmount);
	}

	private ActionType GetPrimaryActionFromFillable(AFO Info)
	{
		Info.m_StartAction = StartRemoveFillable;
		Info.m_EndAction = EndRemoveFillable;
		Info.m_AbortAction = AbortRemoveFillable;
		Info.m_FarmerState = Farmer.State.Taking;
		if (m_State != State.None)
		{
			return ActionType.Fail;
		}
		if (GetStored() == 0)
		{
			return ActionType.Fail;
		}
		if (Info.m_Object == null)
		{
			return ActionType.Fail;
		}
		ToolFillable component = Info.m_Object.GetComponent<ToolFillable>();
		if (component == null)
		{
			return ActionType.Fail;
		}
		if (!component.CanAcceptObjectType(m_ObjectType))
		{
			return ActionType.Fail;
		}
		return ActionType.TakeResource;
	}

	private void StartAddFillable(AFO Info)
	{
		if (!(Info.m_Object == null))
		{
			ToolFillable component = Info.m_Object.GetComponent<ToolFillable>();
			ObjectType heldType = component.m_HeldType;
			if (m_ObjectType == ObjectTypeList.m_Total)
			{
				SetObjectType(heldType);
			}
			int num = component.m_Stored;
			if (m_Stored + num > GetCapacity())
			{
				num = GetCapacity() - m_Stored;
			}
			component.Empty(num);
			AddToStored(heldType, num, Info.m_Actioner);
			m_AddedAmount = num;
			AddAnimationManager.Instance.Add(this, true);
			AudioManager.Instance.StartEvent("BuildingStorageAdd", this);
		}
	}

	private void EndAddFillable(AFO Info)
	{
		UpdateStored();
	}

	private void AbortAddFillable(AFO Info)
	{
		ReleaseStored(m_ObjectType, Info.m_Actioner, m_AddedAmount);
	}

	private ActionType GetSecondaryActionFromFillable(AFO Info)
	{
		Info.m_StartAction = StartAddFillable;
		Info.m_EndAction = EndAddFillable;
		Info.m_AbortAction = AbortAddFillable;
		Info.m_FarmerState = Farmer.State.Adding;
		if (Info.m_Object == null)
		{
			return ActionType.Fail;
		}
		ToolFillable component = Info.m_Object.GetComponent<ToolFillable>();
		if (component == null)
		{
			return ActionType.Fail;
		}
		if (component.m_HeldType == ObjectTypeList.m_Total)
		{
			return ActionType.Fail;
		}
		if (!CanAcceptObject(component, component.m_HeldType))
		{
			return ActionType.Total;
		}
		if (m_ObjectType != ObjectTypeList.m_Total && component.m_HeldType != m_ObjectType)
		{
			return ActionType.Fail;
		}
		if (GetIsLiquid())
		{
			int stored = GetStored();
			int capacity = GetCapacity();
			if (stored >= capacity)
			{
				return ActionType.Fail;
			}
		}
		return ActionType.AddResource;
	}

	public override ActionType GetActionFromObject(AFO Info)
	{
		if (GetBusy())
		{
			return ActionType.Fail;
		}
		if (Info.m_ActionType == AFO.AT.Primary)
		{
			if (GetIsLiquid())
			{
				if (ToolFillable.GetIsTypeFillable(Info.m_ObjectType))
				{
					return GetPrimaryActionFromFillable(Info);
				}
			}
			else
			{
				if (Info.m_Object != null && ToolFillable.GetIsTypeFillable(Info.m_ObjectType))
				{
					return GetPrimaryActionFromFillable(Info);
				}
				if (Info.m_Actioner.GetComponent<Crane>() == null)
				{
					return GetPrimaryActionFromObject(Info);
				}
			}
		}
		else if (Info.m_ActionType == AFO.AT.Secondary)
		{
			if (!GetIsLiquid())
			{
				if (ToolFillable.GetIsTypeFillable(Info.m_ObjectType) && (bool)Info.m_Object && Info.m_Object.GetComponent<ToolFillable>().m_HeldType != ObjectTypeList.m_Total && CanAcceptObject(Info.m_Object, Info.m_Object.GetComponent<ToolFillable>().m_HeldType))
				{
					return GetSecondaryActionFromFillable(Info);
				}
				return GetSecondaryActionFromObject(Info);
			}
			if (ToolFillable.GetIsTypeFillable(Info.m_ObjectType))
			{
				return GetSecondaryActionFromFillable(Info);
			}
		}
		return base.GetActionFromObject(Info);
	}

	private bool GetBusy()
	{
		if (m_State != State.None)
		{
			return true;
		}
		if (Carriage.GetIsTypeCarriage(m_TypeIdentifier))
		{
			Minecart minecart = GetComponent<Carriage>().m_Minecart;
			if ((bool)minecart && minecart.m_State != State.None)
			{
				return true;
			}
		}
		return false;
	}

	public override bool CanAcceptObject(BaseClass NewObject, ObjectType NewType)
	{
		if (GetIsLiquid() && !StorageLiquid.IsObjectTypeAcceptibleStatic(NewType))
		{
			return false;
		}
		if (!GetIsLiquid() && StorageLiquid.IsObjectTypeAcceptibleStatic(NewType))
		{
			return false;
		}
		return base.CanAcceptObject(NewObject, NewType);
	}

	private void HideChild(GameObject NewObject, string ChildName)
	{
		GameObject gameObject = ObjectUtils.FindDeepChild(NewObject.transform, ChildName).gameObject;
		if ((bool)gameObject)
		{
			gameObject.SetActive(false);
		}
	}

	private bool GetUsesMesh()
	{
		if (GetIsLiquid())
		{
			return false;
		}
		if (m_ObjectType == ObjectTypeList.m_Total)
		{
			return false;
		}
		if (m_ObjectType == ObjectType.Folk)
		{
			return false;
		}
		if (m_ContentsPoint == null)
		{
			return false;
		}
		if (!m_ShowContents)
		{
			return false;
		}
		if (StorageSand.IsObjectTypeAcceptibleStatic(m_ObjectType))
		{
			return false;
		}
		return true;
	}

	private void SetupObjectMesh()
	{
		if (!GetUsesMesh())
		{
			return;
		}
		string modelNameFromIdentifier = ObjectTypeList.Instance.GetModelNameFromIdentifier(m_ObjectType);
		GameObject gameObject = ModelManager.Instance.Instantiate(m_ObjectType, modelNameFromIdentifier, null, false);
		if (m_ObjectType == ObjectType.ToolPitchfork)
		{
			HideChild(gameObject, "Hay");
		}
		if (ToolBucket.GetIsTypeBucket(m_ObjectType))
		{
			HideChild(gameObject, "Liquid");
		}
		if (Sign.GetIsTypeSign(m_ObjectType))
		{
			HideChild(gameObject, "Text");
		}
		Bounds bounds = ObjectUtils.ObjectBounds(gameObject);
		float num = bounds.size.x / bounds.size.y;
		float num8 = bounds.size.z / bounds.size.y;
		float num2 = 0.25f;
		float height = ObjectTypeList.Instance.GetHeight(m_ObjectType);
		float num3 = height;
		if (num < num2)
		{
			num3 = bounds.size.x;
		}
		MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
		List<Material> list = new List<Material>();
		MeshRenderer[] array = componentsInChildren;
		foreach (MeshRenderer meshRenderer in array)
		{
			for (int j = 0; j < meshRenderer.sharedMaterials.Length; j++)
			{
				if (!list.Contains(meshRenderer.sharedMaterials[j]))
				{
					list.Add(meshRenderer.sharedMaterials[j]);
				}
			}
		}
		int count = list.Count;
		List<CombineInstance>[] array2 = new List<CombineInstance>[count];
		for (int k = 0; k < count; k++)
		{
			array2[k] = new List<CombineInstance>();
		}
		for (int l = 0; l < m_Capacity; l++)
		{
			gameObject.transform.position = default(Vector3);
			float y = UnityEngine.Random.Range(0, 360);
			gameObject.transform.localRotation = Quaternion.Euler(0f, y, 0f);
			if (num < num2)
			{
				gameObject.transform.localRotation *= Quaternion.Euler(90f, 0f, 0f);
				gameObject.transform.position -= gameObject.transform.TransformPoint(new Vector3(0f, height / 2f, 0f));
			}
			float y2 = (float)l * num3;
			Vector3 vector = new Vector3(0f, y2, 0f);
			gameObject.transform.position += vector;
			MeshFilter[] componentsInChildren2 = gameObject.GetComponentsInChildren<MeshFilter>();
			gameObject.GetComponentsInChildren<MeshRenderer>();
			MeshFilter[] array3 = componentsInChildren2;
			foreach (MeshFilter meshFilter in array3)
			{
				Mesh mesh = meshFilter.mesh;
				MeshRenderer component = meshFilter.GetComponent<MeshRenderer>();
				for (int m = 0; m < mesh.subMeshCount; m++)
				{
					CombineInstance item = new CombineInstance
					{
						mesh = mesh,
						subMeshIndex = m,
						transform = meshFilter.transform.localToWorldMatrix
					};
					int num4 = list.IndexOf(component.sharedMaterials[m]);
					array2[num4].Add(item);
				}
			}
		}
		MeshFilter meshFilter2 = m_ContentsPoint.GetComponent<MeshFilter>();
		if (meshFilter2 == null)
		{
			meshFilter2 = m_ContentsPoint.AddComponent<MeshFilter>();
			meshFilter2.mesh = new Mesh();
		}
		CombineInstance[] array4 = new CombineInstance[count];
		Mesh[] array5 = new Mesh[count];
		for (int n = 0; n < count; n++)
		{
			array5[n] = new Mesh();
			array5[n].indexFormat = IndexFormat.UInt16;
			array5[n].CombineMeshes(array2[n].ToArray());
			array4[n].mesh = array5[n];
			array4[n].subMeshIndex = 0;
			array4[n].transform = Matrix4x4.identity;
		}
		meshFilter2.mesh.CombineMeshes(array4, false);
		m_Triangles = new int[meshFilter2.mesh.subMeshCount][];
		for (int num5 = 0; num5 < meshFilter2.mesh.subMeshCount; num5++)
		{
			int[] triangles = meshFilter2.mesh.GetTriangles(num5);
			m_Triangles[num5] = new int[triangles.Length];
			for (int num6 = 0; num6 < triangles.Length; num6++)
			{
				m_Triangles[num5][num6] = triangles[num6];
			}
		}
		MeshRenderer meshRenderer2 = m_ContentsPoint.GetComponent<MeshRenderer>();
		if (meshRenderer2 == null)
		{
			meshRenderer2 = m_ContentsPoint.AddComponent<MeshRenderer>();
		}
		meshRenderer2.sharedMaterials = list.ToArray();
		float num7 = 1f;
		int tierFromType = BaseClass.GetTierFromType(m_ObjectType);
		if (tierFromType != 0)
		{
			num7 = BaseClass.GetTierScale(tierFromType);
		}
		m_ContentsPoint.transform.localScale = new Vector3(num7, num7, num7);
		UnityEngine.Object.Destroy(gameObject);
	}

	private void ClearMesh()
	{
		if ((bool)m_ContentsPoint)
		{
			MeshFilter component = m_ContentsPoint.GetComponent<MeshFilter>();
			if ((bool)component)
			{
				component.mesh.Clear();
			}
		}
	}

	private void UpdateStoredModel()
	{
		if (m_ObjectType == ObjectTypeList.m_Total)
		{
			ClearMesh();
		}
		if (!GetUsesMesh())
		{
			return;
		}
		m_ContentsPoint.gameObject.SetActive(true);
		if (m_ObjectType == ObjectType.Folk)
		{
			ClearMesh();
			return;
		}
		MeshFilter component = m_ContentsPoint.GetComponent<MeshFilter>();
		for (int i = 0; i < component.mesh.subMeshCount; i++)
		{
			int[] array = m_Triangles[i];
			int num = array.Length / m_Capacity * m_Stored;
			int[] array2 = new int[num];
			if (array.Length < num || array2.Length < num)
			{
				Debug.Log("Copy " + i + " " + num);
			}
			Array.Copy(array, array2, num);
			component.mesh.SetTriangles(array2, i);
		}
	}

	protected new void Update()
	{
		base.Update();
		if (GetIsLiquid())
		{
			return;
		}
		foreach (Holdable @object in m_Objects)
		{
			@object.transform.position = m_ContentsPoint.transform.position;
			@object.transform.rotation = m_ContentsPoint.transform.rotation;
		}
	}
}
