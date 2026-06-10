using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class NeonSignController : MonoBehaviour
{
	public List<MeshRenderer> meshRenderers;

	public Light lightComponent;

	[ReorderableList]
	public List<Material> materialAnimations;

	[ReorderableList]
	public List<bool> lightBools;

	public int frameCursor;

	public int frameDelay;

	private float frameCounter;

	[Header("Materials")]
	public bool useAddressColours;

	[EnableIf("useAddressColours")]
	public bool changeBaseColour;

	[EnableIf("useAddressColours")]
	public bool changeAltColour1;

	[EnableIf("useAddressColours")]
	public bool changeAltColour2;

	[EnableIf("useAddressColours")]
	public bool changeAltColour3;

	[Header("Audio")]
	public AudioEvent audioLoop;

	public Vector3 localSoundOffset;

	private AudioController.LoopingSoundInfo loop;

	private NewNode closestStreetNode;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}
}
