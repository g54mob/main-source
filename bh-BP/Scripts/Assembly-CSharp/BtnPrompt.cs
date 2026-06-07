using I2.Loc;
using UnityEngine;

public class BtnPrompt : MonoBehaviour
{
	public GameObject Wrapper;

	public BtnPromptLocParams PromptParams;

	public Localize LocPrompt;

	public Localize LocLabel;

	public LocalizationParamsManager ParamsLabel;

	public bool DisableEventDemo;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnInputChanged()
	{
	}
}
