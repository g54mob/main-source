using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectCentricSwatch : ImageEffectBase
{
	public Texture SwatchTexture;

	public bool InvertYAxis;

	public float StartDistance = 0.1f;

	public bool UseNearColorBeforeStart;

	public float MaxDistance = 2f;

	private List<Drone> droneList = new List<Drone>();

	protected override void Start()
	{
		Drone[] array = Object.FindObjectsOfType(typeof(Drone)) as Drone[];
		if (array.Length > 0)
		{
			Drone[] array2 = array;
			foreach (Drone drone in array2)
			{
				if (drone.IsVisible)
				{
					droneList.Add(drone);
				}
			}
		}
		base.Start();
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		GameObject gameObject = null;
		foreach (Drone drone in droneList)
		{
			if (drone != null && drone.isCurrentDrone())
			{
				gameObject = drone.gameObject;
				break;
			}
		}
		if (gameObject != null && (bool)gameObject.transform)
		{
			GameObject gameObject2 = GameObject.FindGameObjectWithTag("DroneMainCamera");
			Transform transform = gameObject2.transform;
			Vector3 vector = transform.InverseTransformPoint(gameObject.transform.position);
			Vector4 vector2 = new Vector4(vector.x, vector.y, vector.z, 1f);
			vector2.x += 0.5f;
			vector2.y += 0.5f;
			base.material.SetTexture("_SwatchTex", SwatchTexture);
			base.material.SetVector("_ObjectPos", vector2);
			base.material.SetFloat("_StartDistance", Mathf.Clamp(StartDistance, 0f, MaxDistance));
			base.material.SetFloat("_UseNearColor", (!UseNearColorBeforeStart) ? 0f : 1f);
			base.material.SetFloat("_MaxDistance", MaxDistance);
			base.material.SetFloat("_InvertY", (!InvertYAxis) ? 0f : 1f);
			Graphics.Blit(src, dest, base.material);
		}
	}
}
