using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;
using mattmc3.dotmore.Collections.Generic;

public class CPack
{
	public class CPackMesh
	{
		public string meshName;

		public Mesh mesh;

		public CPackMesh()
		{
		}

		public CPackMesh(string meshName, Mesh m)
		{
		}

		public void Destroy()
		{
		}

		public void ReadData(Tag data)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}

		private Vector4[] ConvertColorsToVectors(Color[] colors)
		{
			return null;
		}

		private Color[] ConvertVectorsToColors(Vector4[] vectors)
		{
			return null;
		}
	}

	public class CPackTexture
	{
		public string textureName;

		public Texture2D texture;

		public Material baseMaterial;

		public Material buildGhostMaterial;

		public Material buildingMaterial;

		public Material disabledMaterial;

		public bool builtIn;

		public CPackTexture()
		{
		}

		public CPackTexture(string textureName, Texture2D t, bool builtIn)
		{
		}

		private void GenerateMaterials()
		{
		}

		public void Destroy()
		{
		}

		public Texture2D GetBuiltInTexture(string tname)
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

	public class CPackScript
	{
		public string scriptName;

		public string scriptData;

		public CPackScript()
		{
		}

		public CPackScript(string scriptName, string scriptData)
		{
		}

		public void Destroy()
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

	public class GlobalScript
	{
		public string scriptName;

		public OrderedDictionary2<string, RplCore.Data> scriptSettings;

		public bool executeWhenPaused;

		public CPack cpack;

		public CModRplCore core;

		public GlobalScript()
		{
		}

		public GlobalScript(string scriptName, CPack cpack)
		{
		}

		public bool CreateRunningScript()
		{
			return false;
		}

		public void ResetCore()
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

	public string cpackName;

	public string notes;

	public string attributions;

	private List<CPackMesh> meshes;

	private List<CPackTexture> textures;

	private List<CMod> mods;

	private List<CPackScript> scripts;

	public List<GlobalScript> preGlobalScripts;

	public List<GlobalScript> postGlobalScripts;

	public string GUID;

	public Dictionary<string, RplCompiler.CachedCompile> compileCache;

	private CPackTexture defaultTexture;

	public int globalScriptDirtyCounter;

	public void CPackLoaded()
	{
	}

	public void ResetAllGlobalScripts()
	{
	}

	public void PreGameUpdate()
	{
	}

	public void PostGameUpdate()
	{
	}

	public void RemovePreGlobalScript(GlobalScript gs)
	{
	}

	public void RemovePostGlobalScript(GlobalScript gs)
	{
	}

	public int GetGlobalScriptIndex(GlobalScript gs, bool pre)
	{
		return 0;
	}

	public void MoveGlobalScriptUp(GlobalScript gs, bool pre)
	{
	}

	public void MoveGlobalScriptDown(GlobalScript gs, bool pre)
	{
	}

	public string GetCPackEditorDir()
	{
		return null;
	}

	public static string GetCPackEditorDir(string GUID, string cpackName)
	{
		return null;
	}

	public void DestroyCPack()
	{
	}

	private int GetCPackIndex()
	{
		return 0;
	}

	public void CleanupReferences()
	{
	}

	public List<CPackMesh> GetMeshes()
	{
		return null;
	}

	public bool AddMesh(string meshName, Mesh m, out string result)
	{
		result = null;
		return false;
	}

	public int RemoveMesh(string meshName, bool cleanReferences = true)
	{
		return 0;
	}

	public int GetMeshIndex(string meshName)
	{
		return 0;
	}

	public CPackMesh GetMesh(string meshName)
	{
		return null;
	}

	public void MoveMeshUp(string meshName)
	{
	}

	public void MoveMeshDown(string meshName)
	{
	}

	public List<CPackTexture> GetTextures()
	{
		return null;
	}

	public bool AddTexture(string textureName, Texture2D t, bool builtIn, out string result)
	{
		result = null;
		return false;
	}

	public int RemoveTexture(string textureName, bool cleanReferences = true)
	{
		return 0;
	}

	public int GetTextureIndex(string textureName)
	{
		return 0;
	}

	public CPackTexture GetTexture(string textureName)
	{
		return null;
	}

	public void MoveTextureUp(string textureName)
	{
	}

	public void MoveTextureDown(string textureName)
	{
	}

	public List<CMod> GetMods()
	{
		return null;
	}

	public bool AddMod(CMod m, out string result)
	{
		result = null;
		return false;
	}

	public int RemoveMod(CMod mod)
	{
		return 0;
	}

	public int GetModIndex(CMod mod)
	{
		return 0;
	}

	public void MoveModUp(CMod mod)
	{
	}

	public void MoveModDown(CMod mod)
	{
	}

	public List<CPackScript> GetScripts()
	{
		return null;
	}

	public bool AddScript(string scriptName, string scriptData, out string result)
	{
		result = null;
		return false;
	}

	public int RemoveScript(string scriptName)
	{
		return 0;
	}

	public int GetScriptIndex(string scriptName)
	{
		return 0;
	}

	public CPackScript GetScript(string scriptName)
	{
		return null;
	}

	public void MoveScriptUp(string scriptName)
	{
	}

	public void MoveScriptDown(string scriptName)
	{
	}

	private static void RecreateCModUnit(CModUnitManager cmum)
	{
	}

	public static void RecreateAllCModUnits()
	{
	}

	public void ReadData(Tag data, bool overwriteOldScripts = false)
	{
	}

	public TagCompound WriteData(bool branch)
	{
		return null;
	}
}
