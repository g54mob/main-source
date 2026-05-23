using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class UnderwaterCamera : MonoBehaviour
{
	private float waterPosy = -5.3f;

	[SerializeField]
	private Volume postProcessingVolume;

	[SerializeField]
	private Volume rocketCameraPostProcessingVolume;

	[SerializeField]
	private GameObject waterSurface;

	private CinemachineCamera cam;

	private Transform currentRocket;

	private bool _isUnderwater;

	private bool isCalculation;

	private void Start()
	{
		waterPosy = waterSurface.transform.position.y;
		cam = GetComponent<CinemachineCamera>();
		GameManager.S.OnRocketLaunch += S_OnRocketLaunch;
		GameManager.S.OnRocketLanded += S_OnRocketLanded;
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
	}

	private void PauseUI_OnSaveAndQuit()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void S_OnRocketLanded(object sender, EventArgs e)
	{
		isCalculation = false;
		EnableEffect(active: false);
	}

	private void OnDestroy()
	{
		GameManager.S.OnRocketLaunch -= S_OnRocketLaunch;
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
		GameManager.S.OnRocketLanded -= S_OnRocketLanded;
	}

	private void S_OnRocketLaunch(int obj)
	{
		currentRocket = GameManager.S.rocketCamera.Follow;
		isCalculation = true;
	}

	private void Update()
	{
		if (!isCalculation)
		{
			return;
		}
		if (cam.State.GetFinalPosition().y < waterPosy)
		{
			EnableEffect(active: true);
		}
		else
		{
			EnableEffect(active: false);
		}
		if (currentRocket != null)
		{
			if (currentRocket.position.y < waterPosy)
			{
				EnbaleEffectRocketCamera(active: true);
			}
			else
			{
				EnbaleEffectRocketCamera(active: false);
			}
		}
	}

	private void EnableEffect(bool active)
	{
		float num = (active ? 1f : 0f);
		if (postProcessingVolume.weight != num)
		{
			postProcessingVolume.weight = num;
		}
	}

	private void EnbaleEffectRocketCamera(bool active)
	{
		float num = (active ? 1f : 0f);
		if (rocketCameraPostProcessingVolume.weight != num)
		{
			rocketCameraPostProcessingVolume.weight = num;
		}
	}
}
