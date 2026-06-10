using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BreakableWindowController : MonoBehaviour
{
	[Serializable]
	public class WindowBreakSetting
	{
		public MeshFilter filter;

		public MeshRenderer renderer;

		[Space(5f)]
		public Material defaultMat;

		public Material brokenMat;

		public Material boardedMat;

		[Space(5f)]
		public Mesh defaultMesh;

		public Mesh brokenMesh;

		public Mesh boardedMesh;

		[Space(5f)]
		public Collider collider;

		public bool removeColliderWhenBroken;

		[Space(5f)]
		public bool removeWhenBoarded;

		public bool shatter;

		[EnableIf("shatter")]
		public Vector3 shardSize;

		[EnableIf("shatter")]
		public int shardEveryXPixels;

		[EnableIf("shatter")]
		public float shatterForceMultiplier;
	}

	public bool isBroken;

	public bool isBoarded;

	[ReadOnly]
	public float brokenAt;

	public float breakForce;

	public AudioEvent breakAudioEvent;

	public List<Interactable> bulletHoles;

	public List<WindowBreakSetting> panes;

	public void InteractableCollision(Collision collision, float damage, Actor brokenBy, Interactable itemThrown)
	{
	}

	public Vector3 GetAveragePosition()
	{
		return default(Vector3);
	}

	public void BreakWindow(Vector3 contactPosition, Vector3 relativeVelocity, Actor brokenBy, bool noDebris = false)
	{
	}

	public void AddBulletHole(MurderWeaponPreset weapon, Vector3 contactPosition, Vector3 relativeVelocity, Actor brokenBy, bool noDebris, Vector3 normal)
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void SpawnStateCheck()
	{
	}

	public void SetBroken(bool val)
	{
	}

	private Vector3 GetRoughPosition()
	{
		return default(Vector3);
	}

	public NewAddress GetAddress()
	{
		return null;
	}

	public NewWall GetWall()
	{
		return null;
	}

	public void UpdateBrokenState()
	{
	}

	public void Shatter(Vector3 contact, Vector3 velocity)
	{
	}

	private Vector3 UvTo3D(Vector2 uv, Mesh mesh)
	{
		return default(Vector3);
	}

	private float Area(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		return 0f;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AddRandomBulletHole()
	{
	}
}
