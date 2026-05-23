using System;
using RainbowArt.CleanFlatUI;
using UnityEngine;

public class HeatGun : MonoBehaviour
{
	public bool isHandled;

	public bool isOn;

	private bool done;

	private Vector3 genPos;

	public Transform heatPos;

	public Quaternion targetRot;

	public Quaternion startRot;

	public GameObject chip;

	public ProgressBarSpecialPattern gage;

	public LayerMask chipLayer;

	public float heatRadius = 0.1f;

	public float heatDistance = 1.5f;

	private float maxGage = 20f;

	public static event Action OnDesolderDone;

	private void Start()
	{
		isHandled = false;
		isOn = false;
		genPos = base.transform.position;
	}

	private void Update()
	{
		if (!isHandled)
		{
			if (Vector3.Magnitude(base.transform.position - genPos) > 0.01f)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, genPos, Time.deltaTime * 5f);
			}
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, startRot, Time.deltaTime * 4f);
		}
		else
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, startRot * targetRot, Time.deltaTime * 4f);
		}
		if (!isOn || done)
		{
			return;
		}
		Debug.Log("HeatGunOn");
		if (Physics.SphereCast(heatPos.position + base.transform.right, heatRadius, -base.transform.right, out var hitInfo, heatDistance, chipLayer) && hitInfo.collider.gameObject == chip)
		{
			gage.CurrentValue += 4f * Time.deltaTime;
			if (gage.CurrentValue >= 19f)
			{
				HeatGun.OnDesolderDone?.Invoke();
				done = true;
			}
		}
	}

	public void InitGage()
	{
		gage.MaxValue = maxGage;
		gage.CurrentValue = 0f;
	}
}
