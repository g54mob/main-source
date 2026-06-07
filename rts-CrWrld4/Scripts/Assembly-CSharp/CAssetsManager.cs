using UnityEngine;

public class CAssetsManager : MonoBehaviour
{
	public GameObject cPackMeshRowPrefab;

	public GameObject cPackTextureRowPrefab;

	public GameObject cPackScriptRowPrefab;

	public CPackManager cPackManager;

	public GameObject meshListContent;

	public PrimMeshDialog primMeshDialog;

	public StockMeshDialog stockMeshDialog;

	public ImportMeshDialog importMeshDialog;

	public GameObject textureListContent;

	public LoadTextureDialog loadTextureDialog;

	public EditMeshDialog editMeshDialog;

	public EditTextureDialog editTextureDialog;

	public GameObject scriptListContent;

	public NewScriptDialog newScriptDialog;

	public CompileResultDialog compileResultDialog;

	public void Refresh(CPack cpack = null)
	{
	}

	public void OnPrimClicked()
	{
	}

	public void OnStockClicked()
	{
	}

	public void OnImportMeshClicked()
	{
	}

	public void OnLoadTextureClicked()
	{
	}

	public void SyncScriptsToDisk(CPack cpack = null)
	{
	}

	public void OnNewScriptClicked()
	{
	}

	public void OnCompileAllScriptsClicked()
	{
	}

	public bool CompileAllScripts(out string compileResults)
	{
		compileResults = null;
		return false;
	}

	public static bool CompileAllScriptsInAllCPacks(out string compileResults)
	{
		compileResults = null;
		return false;
	}

	public bool CompileAllScripts(CPack cpack, out string compileResults)
	{
		compileResults = null;
		return false;
	}

	public static void DestroyChildren(Transform transform)
	{
	}
}
