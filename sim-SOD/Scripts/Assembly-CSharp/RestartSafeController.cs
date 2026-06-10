using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RestartSafeController : MonoBehaviour
{
	public bool loadFromDirty;

	[Header("New Game")]
	public bool generateNew;

	public bool newGameLoadCity;

	public FileInfo loadCityFileInfo;

	public string cityName;

	public int cityX;

	public int cityY;

	public string seed;

	public bool sandbox;

	[Header("New Character")]
	public string newGamePlayerFirstName;

	public string newGamePlayerSurname;

	public Human.Gender newGamePlayerGender;

	public Human.Gender newGamePartnerGender;

	public Color newGamePlayerSkinTone;

	[Header("Load Save")]
	public bool loadSaveGame;

	public FileInfo saveStateFileInfo;

	[Header("Floor Edit New")]
	public bool newFloor;

	public string newFloorName;

	public Vector2 newFloorSize;

	public int newFloorFloorHeight;

	public int newFloorCeilingHeight;

	[Header("Floor Edit Load")]
	public bool loadFloor;

	public string loadFloorString;

	[Header("Floor Edit Recalculate All")]
	public bool recalculateAll;

	public List<string> floorList;

	private static RestartSafeController _instance;

	public static RestartSafeController Instance => null;

	private void Awake()
	{
	}
}
