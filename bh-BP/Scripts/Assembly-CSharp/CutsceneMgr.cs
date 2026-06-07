using UnityEngine;

public class CutsceneMgr : MonoBehaviour
{
	public static CutsceneMgr I;

	public static CutsceneType sTgtCutscene;

	[NamedArray(typeof(CutsceneType))]
	public CutsceneObj[] Cutscenes;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public static void LoadCutscene(CutsceneType ct)
	{
	}
}
