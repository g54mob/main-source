using System;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The water plane in the world.")]
	private GameObject _waterPlane;

	[HideInInspector]
	public Vector3 MovingWorldDirection = Vector3.forward;

	[HideInInspector]
	public Vector3 MovingFlotsamDirection = Vector3.forward;

	[HideInInspector]
	public float MovingWorldForce;

	[HideInInspector]
	public float MovingFlotsamForce = 500f;

	[HideInInspector]
	public float FixedDeltaTime;

	[HideInInspector]
	public Vector3 MainForce;

	private Material _waterMaterial;

	private Vector2 _surfacePanSpeed1;

	private Vector2 _surfacePanSpeed2;

	private Vector2 _surfacePanBlendSpeed2;

	private Vector2 _surfaceNormalPanSpeed1;

	private Vector2 _surfaceNormalPanSpeed2;

	private Vector2 _distortionPanSpeed;

	public void Initialize()
	{
		MovingWorldForce = 0f;
		_waterMaterial = null;
		UpdateWorldMovement();
	}

	private void FixedUpdate()
	{
		MainForce = MovingFlotsamDirection * MovingFlotsamForce * Time.fixedUnscaledDeltaTime;
	}

	public void UpdateWorldMovement()
	{
		Vector3 relativeFlotsamDirection = GameManager.Settings.GameplaySettings.WorldPhysics.RelativeFlotsamDirection;
		Vector3 vector = relativeFlotsamDirection.normalized * (MovingWorldForce + GameManager.Settings.GameplaySettings.WorldPhysics.RelativeFlotsamSpeed);
		MovingFlotsamForce = vector.magnitude;
		if (MovingFlotsamForce > GameManager.Settings.GameplaySettings.WorldPhysics.MaximumFlotsamForce)
		{
			MovingFlotsamForce = GameManager.Settings.GameplaySettings.WorldPhysics.MaximumFlotsamForce;
		}
		MovingFlotsamDirection = vector.normalized;
	}

	private void CacheShaderSpeed()
	{
		_surfacePanSpeed1.x = _waterMaterial.GetFloat("_SurfacePanSpeedX");
		_surfacePanSpeed1.y = _waterMaterial.GetFloat("_SurfacePanSpeedY");
		_surfacePanSpeed2.x = _waterMaterial.GetFloat("_Surface2PanSpeedX");
		_surfacePanSpeed2.y = _waterMaterial.GetFloat("_Surface2PanSpeedY");
		_surfacePanBlendSpeed2.x = _waterMaterial.GetFloat("_Surface2BlendPanSpeedX");
		_surfacePanBlendSpeed2.y = _waterMaterial.GetFloat("_Surface2BlendPanSpeedY");
		_surfaceNormalPanSpeed1.x = _waterMaterial.GetFloat("_SurfaceNormalPanSpeed1X");
		_surfaceNormalPanSpeed1.y = _waterMaterial.GetFloat("_SurfaceNormalPanSpeed1Y");
		_surfaceNormalPanSpeed2.x = _waterMaterial.GetFloat("_SurfaceNormalPanSpeed2X");
		_surfaceNormalPanSpeed2.y = _waterMaterial.GetFloat("_SurfaceNormalPanSpeed2Y");
		_distortionPanSpeed.x = _waterMaterial.GetFloat("_DistortionPanSpeedX");
		_distortionPanSpeed.y = _waterMaterial.GetFloat("_DistortionPanSpeedY");
	}

	private void SetShaderSpeed(float speed)
	{
		_waterMaterial.SetFloat("_SurfacePanSpeedX", RotateWithWorld(_surfacePanSpeed1).x * speed);
		_waterMaterial.SetFloat("_SurfacePanSpeedY", RotateWithWorld(_surfacePanSpeed1).y * speed);
		_waterMaterial.SetFloat("_Surface2PanSpeedX", RotateWithWorld(_surfacePanSpeed2).x * speed);
		_waterMaterial.SetFloat("_Surface2PanSpeedY", RotateWithWorld(_surfacePanSpeed2).y * speed);
		_waterMaterial.SetFloat("_Surface2BlendPanSpeedX", RotateWithWorld(_surfacePanBlendSpeed2).x * speed);
		_waterMaterial.SetFloat("_Surface2BlendPanSpeedY", RotateWithWorld(_surfacePanBlendSpeed2).y * speed);
		_waterMaterial.SetFloat("_SurfaceNormalPanSpeed1X", RotateWithWorld(_surfaceNormalPanSpeed1).x * speed);
		_waterMaterial.SetFloat("_SurfaceNormalPanSpeed1Y", RotateWithWorld(_surfaceNormalPanSpeed1).y * speed);
		_waterMaterial.SetFloat("_SurfaceNormalPanSpeed2X", RotateWithWorld(_surfaceNormalPanSpeed2).x * speed);
		_waterMaterial.SetFloat("_SurfaceNormalPanSpeed2Y", RotateWithWorld(_surfaceNormalPanSpeed2).y * speed);
		_waterMaterial.SetFloat("_DistortionPanSpeedX", RotateWithWorld(_distortionPanSpeed).x * speed);
		_waterMaterial.SetFloat("_DistortionPanSpeedY", RotateWithWorld(_distortionPanSpeed).y * speed);
	}

	private Vector2 RotateWithWorld(Vector2 direction)
	{
		float num = Vector2.SignedAngle(new Vector2(0f, 1f), new Vector2(MovingWorldDirection.x, MovingWorldDirection.z));
		float num2 = Mathf.Sin(num * (MathF.PI / 180f));
		float num3 = Mathf.Cos(num * (MathF.PI / 180f));
		float x = direction.x;
		float y = direction.y;
		direction.x = num3 * x - num2 * y;
		direction.y = num2 * x + num3 * y;
		return direction;
	}
}
