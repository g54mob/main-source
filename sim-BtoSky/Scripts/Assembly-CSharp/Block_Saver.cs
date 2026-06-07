using System.Collections;
using System.IO;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Serializer;
using UnityEngine;

public class Block_Saver : MonoBehaviour
{
	[SerializeField]
	private GameObject programmingEnvGO;

	private I_BE2_ProgrammingEnv _targetEnv;

	private void Awake()
	{
		if (programmingEnvGO != null)
		{
			_targetEnv = programmingEnvGO.GetComponent<I_BE2_ProgrammingEnv>();
		}
	}

	private void Start()
	{
		ES3AutoSaveMgr.OnPauseSaveDone += ES3AutoSaveMgr_OnPauseSaveDone;
		LoadFromFile();
	}

	private void OnDestroy()
	{
		ES3AutoSaveMgr.OnPauseSaveDone -= ES3AutoSaveMgr_OnPauseSaveDone;
	}

	private void ES3AutoSaveMgr_OnPauseSaveDone()
	{
		SaveToFile();
	}

	public void SaveToFile()
	{
		string text = "BlockSave";
		BE2_BlocksSerializer.SaveCode(Path.Combine(Application.persistentDataPath, text + ".BE2"), _targetEnv);
	}

	public void LoadFromFile()
	{
		string text = Path.Combine(Application.persistentDataPath, "BlockSave.BE2");
		if (File.Exists(text))
		{
			StartCoroutine(DelayedLoadBlock(text));
		}
		else
		{
			Debug.LogWarning("[BE2] 파일을 찾을 수 없습니다: " + text);
		}
	}

	private IEnumerator DelayedLoadBlock(string fullPath)
	{
		yield return null;
		_targetEnv.ClearBlocks();
		if (BE2_BlocksSerializer.LoadCode(fullPath, _targetEnv))
		{
			Debug.Log("[BE2] 로드 성공: " + fullPath);
		}
	}
}
