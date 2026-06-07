using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class CookeryLightVolumeRenderer : MonoBehaviour
{
	[Header("Components")]
	public Camera cam;

	public Material lightMaterial;

	public Mesh boxMesh;

	[Header("Parameters")]
	public Vector2 verticalPadding = Vector2.down;

	public float linearity = 1f;

	public float globalMultiplier = 1f;

	public float localMultiplier = 1f;

	public bool largeScale = true;

	private CommandBuffer buff;

	private Vector4 shaderParams = Vector4.zero;

	private bool firstUpdate = true;

	private static readonly int sp_InvBoxTransform = Shader.PropertyToID("_InvBoxTransform");

	private static readonly int sp_BoxTransform = Shader.PropertyToID("_BoxTransform");

	private static readonly int sp_LightVolumeParams = Shader.PropertyToID("_LightVolumeParams");

	public bool EffectEnabled { get; private set; }

	public Matrix4x4 InverseBoxTransform { get; private set; } = Matrix4x4.identity;

	public Matrix4x4 BoxRotationTransform { get; private set; } = Matrix4x4.identity;

	public Vector4 LightVolumeParameters { get; private set; } = Vector4.zero;

	private void OnEnable()
	{
		if (!(cam == null))
		{
			EnableEffect();
		}
	}

	private void ChangeCamera(Camera newCam)
	{
		bool effectEnabled = EffectEnabled;
		if (EffectEnabled)
		{
			DisableEffect();
		}
		cam = newCam;
		if (effectEnabled || firstUpdate)
		{
			EnableEffect();
		}
		firstUpdate = false;
	}

	private void EnableEffect()
	{
		if (buff == null)
		{
			buff = new CommandBuffer();
			buff.name = "Cookery volume renderer (" + base.transform.parent.name + ")";
		}
		if (cam.GetCommandBuffers(CameraEvent.AfterLighting).Contains(buff))
		{
			cam.RemoveCommandBuffer(CameraEvent.AfterLighting, buff);
		}
		cam.AddCommandBuffer(CameraEvent.AfterLighting, buff);
		CookeryVolumeTracker.RegisterVolume(this);
		EffectEnabled = true;
	}

	private void DisableEffect()
	{
		if (buff != null && (bool)cam)
		{
			cam.RemoveCommandBuffer(CameraEvent.AfterLighting, buff);
		}
		EffectEnabled = false;
		CookeryVolumeTracker.UnregisterVolume(this);
	}

	private void OnDisable()
	{
		DisableEffect();
	}

	private void LateUpdate()
	{
		if (Camera.main != null && Camera.main != cam)
		{
			ChangeCamera(Camera.main);
		}
		if (!(cam == null) && buff != null)
		{
			InverseBoxTransform = base.transform.worldToLocalMatrix;
			BoxRotationTransform = Matrix4x4.Rotate(base.transform.rotation);
			shaderParams.x = verticalPadding.x;
			shaderParams.y = verticalPadding.y;
			shaderParams.z = linearity;
			shaderParams.w = globalMultiplier * localMultiplier;
			LightVolumeParameters = shaderParams;
			buff.Clear();
			buff.SetGlobalMatrix(sp_InvBoxTransform, InverseBoxTransform);
			buff.SetGlobalMatrix(sp_BoxTransform, BoxRotationTransform);
			buff.SetGlobalVector(sp_LightVolumeParams, shaderParams);
			Matrix4x4 matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.localScale);
			buff.DrawMesh(boxMesh, matrix, lightMaterial, 0, (!cam.allowHDR) ? 1 : 0);
		}
	}
}
