using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveRow : MonoBehaviour
{
	public TextMeshProUGUI text;

	public TextMeshProUGUI text2;

	public Image image;

	private int _objective;

	public int objective
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void SetState(bool complete, bool failed)
	{
	}

	public void LateUpdate()
	{
	}

	private void HandleNullify()
	{
	}

	private void HandleTotem()
	{
	}

	private void HandleCollect()
	{
	}

	private void HandleReclaim()
	{
	}

	public static string GetReclaimStatusString()
	{
		return null;
	}

	private void HandleSurvive()
	{
	}

	public static float GetInhibitorLevel()
	{
		return 0f;
	}
}
