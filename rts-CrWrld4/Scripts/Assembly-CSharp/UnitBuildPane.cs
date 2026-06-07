using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitBuildPane : MonoBehaviour
{
	public enum UNITBUILDPANETYPE
	{
		STRUCT = 0,
		WEAPON = 1,
		AIR = 2,
		SPECIAL = 3,
		CUSTOM = 4
	}

	public class CModUnitBuildPaneButton
	{
		public string buttonName;

		public string unitToBuild;
	}

	public UNITBUILDPANETYPE unitBuildPaneType;

	public GameObject buttonContainer;

	public Button upButton;

	public Button downButton;

	private int _startIndex;

	private const int MAX_BUTTONS = 6;

	private int startIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public BuildButton[] GetBuildButtons()
	{
		return null;
	}

	public void OnEnable()
	{
	}

	public void Show(bool val)
	{
	}

	public void Start()
	{
	}

	public void Refresh()
	{
	}

	public void MoveDown()
	{
	}

	public void MoveUp()
	{
	}

	private void SetEnabledButtons()
	{
	}

	private void OnBuildCModUnit(string cmodUnit)
	{
	}

	private void AddCModUnitBuildButton(CMod cmod)
	{
	}

	private List<GameObject> GetCModButtons()
	{
		return null;
	}

	private Bounds GetGameObjectBounds(Renderer renderer)
	{
		return default(Bounds);
	}

	private Bounds GetGameObjectMeshBounds(GameObject go)
	{
		return default(Bounds);
	}

	public static Bounds CalculateBoundingBox(GameObject aObj)
	{
		return default(Bounds);
	}
}
