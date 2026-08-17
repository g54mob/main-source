using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroArsenal;

public class RetroSceneSelect : MonoBehaviour
{
	private bool GUIHide01;

	private bool GUIHide02;

	private bool GUIHide03;

	public void CBLoadSceneBeams()
	{
		SceneManager.LoadScene("R_Beams");
	}

	public void CBLoadSceneEmojis()
	{
		SceneManager.LoadScene("R_Emojis");
	}

	public void CBLoadSceneExplosions()
	{
		SceneManager.LoadScene("R_Explosions");
	}

	public void CBLoadSceneLibrary()
	{
		SceneManager.LoadScene("R_Library");
	}

	public void CBLoadSceneLoot()
	{
		SceneManager.LoadScene("R_Loot");
	}

	public void CBLoadSceneMissiles()
	{
		SceneManager.LoadScene("R_Missiles");
	}

	public void CBLoadScenePowerups()
	{
		SceneManager.LoadScene("R_Powerups");
	}

	private void Update()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BD4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	private void CheckKeyCode(KeyCode keyCode, ref bool guiHide, string canvasName)
	{
	}
}
