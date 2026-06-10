using System.Collections.Generic;
using UnityEngine;

public class SteamController : MonoBehaviour
{
	public NewRoom room;

	[Tooltip("The steam level previously existing in this room")]
	private float existingSteamLevel;

	[Tooltip("The steam level in this room.")]
	public float steamLevel;

	[Tooltip("The scale to blur glass panels.")]
	public Vector2 blurScale;

	[Tooltip("The time it takes to completely steam up a room")]
	public float steamTime;

	[Tooltip("The time it takes to completely de-steam a room")]
	public float desteamTime;

	public List<MeshRenderer> glassPanels;

	public Material glassMaterialOriginal;

	public Material glassMaterial;

	public void Setup(NewRoom newRoom)
	{
	}

	public void SteamStateChanged()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
