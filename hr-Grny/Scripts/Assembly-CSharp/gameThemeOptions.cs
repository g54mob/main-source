using UnityEngine;
using UnityEngine.UI;

public class gameThemeOptions : MonoBehaviour
{
	public Dropdown dropdownOptions;

	public GameObject MenuFloor;

	public GameObject PostProcessingCheck;

	public GameObject bearTrap;

	public GameObject bearTrapNightmare;

	public GameObject Pumpkin;

	public GameObject Santa;

	[Header("External Manager References")]
	[Tooltip("Drag the GameObject with the stopMusik script here to enable theme music switching.")]
	public stopMusik musicManager;

	public virtual void Start()
	{
	}

	public virtual void SetThemePlayerPrefs()
	{
	}
}
