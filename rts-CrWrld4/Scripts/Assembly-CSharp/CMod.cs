using System;
using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using VLB;
using mattmc3.dotmore.Collections.Generic;

public class CMod
{
	public class CModUISlot
	{
		public enum CModUISlotType
		{
			NONE = 0,
			LABEL = 1,
			BUTTON = 2,
			FLIP = 3,
			CHOICE = 4
		}

		public CModUISlotType slotType;

		public string slotName;

		public List<string> slotOptions;

		public string[] GetSlotOptions()
		{
			return null;
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public class CModScript
	{
		public string scriptName;

		public OrderedDictionary2<string, RplCore.Data> scriptSettings;

		public CModScript()
		{
		}

		public CModScript(string scriptName)
		{
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public class CModObj
	{
		public CModObj parent;

		public List<CModObj> children;

		public string objName;

		public bool meshInternal;

		public string mesh;

		public bool textureInternal;

		public string texture;

		public Vector3 position;

		public Vector3 rotation;

		public Color color;

		public float colorBrightness;

		public Vector3 scale;

		public int tmpDepth;

		public CMod cmod;

		public CModObj(CMod cmod)
		{
		}

		public GameObject CreateObjInstance(Transform parent)
		{
			return null;
		}

		public void CleanupReferences()
		{
		}

		public void Clone(CModObj other)
		{
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public class CModObjInstance : MonoBehaviour
	{
		[NonSerialized]
		public CPack.CPackTexture cpackTexture;

		private MeshRenderer meshRenderer;

		private bool colorSet;

		private Color color;

		private float colorBrightness;

		private int materialType;

		private Material myMaterial;

		private VolumetricLightBeam lightCone;

		private ParticleTrailManager trail;

		private CModUnitText cmuText;

		public void Destroy()
		{
		}

		public Material GetBaseMaterial()
		{
			return null;
		}

		public void SetMaterial(int materialType)
		{
		}

		public void SetColor(Color color)
		{
		}

		public Color GetColor()
		{
			return default(Color);
		}

		public void SetColorBrightness(float colorBrightness)
		{
		}

		public float GetColorBrightness()
		{
			return 0f;
		}

		public void SetLightConeVisible(bool vis)
		{
		}

		public void CreateTrail(ParticleTrailManager.TRAIL_TYPE trailType, float lifeTime)
		{
		}

		public void DestroyTrail(bool immediate)
		{
		}

		private void ManageText(bool create)
		{
		}

		public void SetText(string text)
		{
		}

		public void SetTextColor(Color color)
		{
		}

		public void SetTextFontSize(float fontSize)
		{
		}

		public void SetTextBillboard(bool billboard)
		{
		}

		public void ReadData(Tag data, bool skipPRS = false)
		{
		}

		public TagCompound WriteData(bool skipPRS = false)
		{
			return null;
		}
	}

	public string GUID;

	public string modName;

	public CPack cpack;

	private CModObj rootObj;

	private List<CModScript> scripts;

	public string editMenuUnitName;

	public string playerMenuUnitName;

	public UnitBuildPane.UNITBUILDPANETYPE playerBuildMenu;

	public Vector3 colliderSize;

	public Vector3 colliderCenter;

	public bool autoCollider;

	public UnitData.UnitConstants unitConstants;

	public static int CMOD_UI_SLOT_COUNT;

	public CModUISlot[] uiSlots;

	public CMod(CPack cpack)
	{
	}

	public void DestroyCMod()
	{
	}

	private void SetDefaultUnitConstants()
	{
	}

	public static void AddCModImageToRecorder(CMod mod)
	{
	}

	public static void SetCModInstanceMaterial(GameObject go, int materialType)
	{
	}

	public CModUnitManager CreateCModUnit(Vector3 pos)
	{
		return null;
	}

	public CModUnitManager CreateCModUnit(Vector3 pos, List<OrderedDictionary2<string, RplCore.Data>> setInputVarsList, OrderedDictionary2<string, RplCore.Data> initParams, bool deferAwakeScripts = false)
	{
		return null;
	}

	public CModUnitBuildGhost CreateCModUnitBuildGhost()
	{
		return null;
	}

	public GameObject CreateCModInstance()
	{
		return null;
	}

	private GameObject CreateObjInstance(CModObj cmo, GameObject parent)
	{
		return null;
	}

	public static void SetLayer(GameObject parent, int layer, bool includeChildren = true)
	{
	}

	public void ResolveCollider(GameObject go)
	{
	}

	public void AutoCollider(GameObject go)
	{
	}

	private void RemoveAnyColliders(GameObject go)
	{
	}

	public void CleanupReferences()
	{
	}

	public List<CModObj> GetObjs()
	{
		return null;
	}

	private void AddObjNode(List<CModObj> result, CModObj cmo, int depth)
	{
	}

	public CModObj AddObj()
	{
		return null;
	}

	public void RemoveObj(CModObj cmo)
	{
	}

	public bool IsRootObj(CModObj cmo)
	{
		return false;
	}

	private bool RemoveObj(CModObj parent, CModObj cmo)
	{
		return false;
	}

	public bool CanMoveUp(CModObj cmo)
	{
		return false;
	}

	public bool CanMoveDown(CModObj cmo)
	{
		return false;
	}

	public bool CanMoveRight(CModObj cmo)
	{
		return false;
	}

	public bool CanMoveLeft(CModObj cmo)
	{
		return false;
	}

	public void MoveObjUp(CModObj cmo)
	{
	}

	public void MoveObjDown(CModObj cmo)
	{
	}

	public void MoveObjRight(CModObj cmo)
	{
	}

	public void MoveObjLeft(CModObj cmo)
	{
	}

	public List<CModScript> GetScripts()
	{
		return null;
	}

	public CModScript GetScript(int pos)
	{
		return null;
	}

	public CModScript GetScript(string scriptName)
	{
		return null;
	}

	public void AddScript(string s)
	{
	}

	public void RemoveScript(int pos)
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData(bool branch)
	{
		return null;
	}
}
