using UnityEngine;

public class LocReview : MonoBehaviour
{
	public delegate string Func();

	public delegate string GenderedFunc(Manifest.Gender gender);

	public static bool active;

	public GameObject localGo;

	public Dialog dialog;

	public DialogLib dialogLib;

	[Space]
	public string langId;

	public string nextLangIds;

	public string allLangIds = "en fr de es pt it ru ja zh-s pl zh-t";

	[Space]
	public bool publish;

	public bool exitWhenDone;

	[Space]
	public bool strings;

	public bool fates;

	public bool title;

	public bool credits;

	public bool intro;

	public bool dialogs;

	public bool book;

	public bool tally;

	public bool office;
}
