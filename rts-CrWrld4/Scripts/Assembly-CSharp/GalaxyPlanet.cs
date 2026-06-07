using TMPro;
using UnityEngine;

public class GalaxyPlanet : MonoBehaviour
{
	public enum STATUS
	{
		NONE = 0,
		LOCKED = 1,
		UNLOCKED = 2,
		PARTIAL = 3,
		COMPLETE = 4
	}

	public Material galaxyPlanetOrangeMaterial;

	public Material galaxyPlanetBlueMaterial;

	public Material galaxyPlanetYellowMaterial;

	public Material galaxyPlanetGreenMaterial;

	public Material galaxyPlanetRedMaterial;

	public Material galaxyPlanetGrayMaterial;

	public GalaxyMissionData gmd;

	public TextMeshPro title;

	private int planetTexture;

	private STATUS _status;

	private string _planetName;

	private float _size;

	public STATUS status
	{
		get
		{
			return default(STATUS);
		}
		set
		{
		}
	}

	public string planetName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float size
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	public static float GetRadiusFromArea(int area)
	{
		return 0f;
	}

	private void Update()
	{
	}
}
