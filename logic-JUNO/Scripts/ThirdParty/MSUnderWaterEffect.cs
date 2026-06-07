using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MSUnderWaterEffect : MonoBehaviour
{
	public enum StartMode
	{
		inTheWater = 0,
		outOfTtheWater = 1
	}

	public enum WaterDetectionMode
	{
		Tag = 0,
		Name = 1
	}

	public delegate void UnderWaterStateChangedHandler(bool underWater);

	private static class ShaderPropertyIds
	{
		public static readonly int IsUnderWater = Shader.PropertyToID("_IsUnderWater");
	}

	[Header("Start Mode")]
	[Tooltip("Here you can define whether the player will start in or out of the water. If it starts in water, the effect already starts active ... otherwise, the effect starts inactive.")]
	public StartMode _start = StartMode.outOfTtheWater;

	[Tooltip("If 'start' is set to 'inTheWater', here you can define which water will be selected as the effect to be activated.")]
	public int startWaterID;

	[Header("Waters")]
	[Tooltip("Here you can decide how the water will be detected, whether by tag or name.")]
	public WaterDetectionMode detectionMode;

	[Tooltip("Here you must configure all the types of water you have in your game, according to the tag of each object.")]
	public MSWaterClass[] waters;

	[Space(5f)]
	[Header("Water Drops")]
	[Tooltip("If this variable is true, the water droplets on the screen will not appear.")]
	public bool disableDropsOnScreen;

	[Tooltip("The texture that will give the effect of drops on the screen")]
	public Texture waterDropsTexture;

	[Space(5f)]
	[Header("Sounds")]
	[Tooltip("The sound that will be played when the player enters the water")]
	public AudioClip soundToEnter;

	[Tooltip("The sound that will be played when the player exits the water")]
	public AudioClip soundToExit;

	[Tooltip("The sound that will be played while the player is underwater")]
	public AudioClip underWaterSound;

	[Space(5f)]
	[Header("Resources")]
	[Tooltip("Shader 'SrBlur' must be associated with this variable")]
	public Shader SrBlur;

	[Tooltip("Shader 'SrEdge' must be associated with this variable")]
	public Shader SrEdge;

	[Tooltip("Shader 'SrFisheye' must be associated with this variable")]
	public Shader SrFisheye;

	[Tooltip("Shader 'SrVortex' must be associated with this variable")]
	public Shader SrVortex;

	[Tooltip("Shader 'SrQuad' must be associated with this variable")]
	public Shader SrQuad;

	private bool underWater;

	private bool cameOutOfTheWater;

	private bool enableQuadDrops;

	private float timerDrops;

	public GameObject quadDrops;

	public Renderer quadDropsRenderer;

	private int waterIndex;

	private int interactions = 3;

	private float strengthX;

	private float strengthY;

	private float blurSpread = 0.6f;

	private float angleVortex;

	private float edgesOnly;

	private Color edgesOnlyBgColor = Color.white;

	private Vector2 centerVortex = new Vector2(0.5f, 0.5f);

	private Material materialBlur;

	private Material fisheyeMaterial;

	private Material materialVortex;

	public AudioSource audioSourceCamera;

	private GameObject audioSourceUnderWater;

	private Camera cameraComponent;

	private bool error;

	[Header("Disable Effects - Jundroo Tweaks")]
	public bool DisableDistortion;

	public bool DisableBlur;

	public bool DisableWaterExitDrops;

	public AudioSource AudioSourceUnderwater => audioSourceUnderWater?.GetComponent<AudioSource>();

	public AudioSource AudioSourceCamera => audioSourceCamera;

	public bool UnderWater
	{
		get
		{
			return underWater;
		}
		set
		{
			underWater = value;
			Shader.SetGlobalFloat(ShaderPropertyIds.IsUnderWater, value ? 1f : 0f);
			this.UnderWaterStateChanged?.Invoke(value);
		}
	}

	public event UnderWaterStateChangedHandler UnderWaterStateChanged;

	private void OnValidate()
	{
		if (waters == null || waters.Length == 0)
		{
			return;
		}
		Color color = new Color(0f, 0f, 0f, 0f);
		for (int i = 0; i < waters.Length; i++)
		{
			waters[i].automaticWaterID = i;
			if (string.IsNullOrEmpty(waters[i].waterTag))
			{
				waters[i].waterTag = "Respawn";
			}
			if (string.IsNullOrEmpty(waters[i].waterName))
			{
				waters[i].waterName = "WaterName";
			}
			if (waters[i].waterColor == color)
			{
				waters[i].waterColor = new Color(0.05f, 0.5f, 0.5f, 0f);
			}
			if (waters[i].vortexDistortion == 0f)
			{
				waters[i].vortexDistortion = 0.45f;
			}
			if (waters[i].fisheyeDistortion == 0f)
			{
				waters[i].fisheyeDistortion = 0.3f;
			}
			if (waters[i].distortionSpeed == 0f)
			{
				waters[i].distortionSpeed = 0.2f;
			}
			if (waters[i].colorIntensity == 0f)
			{
				waters[i].colorIntensity = 0.4f;
			}
			if (waters[i].visibility == 0f)
			{
				waters[i].visibility = 7f;
			}
		}
		startWaterID = Mathf.Clamp(startWaterID, 0, waters.Length - 1);
	}

	private void Awake()
	{
		error = false;
		materialVortex = new Material(SrVortex);
		materialVortex.hideFlags = HideFlags.HideAndDontSave;
		materialBlur = new Material(SrBlur);
		materialBlur.hideFlags = HideFlags.DontSave;
		cameraComponent = GetComponent<Camera>();
		if (!cameraComponent)
		{
			error = true;
			Debug.LogError("For the code to function properly, it must be associated with an object that has the camera component.");
			base.enabled = false;
			return;
		}
		for (int i = 0; i < waters.Length; i++)
		{
			waters[i].automaticWaterID = i;
		}
		if (!SrQuad.isSupported || disableDropsOnScreen)
		{
			enableQuadDrops = false;
		}
		else
		{
			enableQuadDrops = true;
			quadDrops = GameObject.CreatePrimitive(PrimitiveType.Quad);
			UnityEngine.Object.Destroy(quadDrops.GetComponent<MeshCollider>());
			quadDrops.transform.parent = base.transform;
			quadDrops.name = "UnderwaterDroplets";
			UpdateWaterDropsSize();
			quadDrops.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			quadDropsRenderer = quadDrops.GetComponent<Renderer>();
			quadDropsRenderer.material.shader = SrQuad;
			quadDropsRenderer.material.SetTexture("_BumpMap", waterDropsTexture);
			quadDropsRenderer.material.SetFloat("_BumpAmt", 0f);
			quadDropsRenderer.enabled = false;
		}
		if ((bool)underWaterSound)
		{
			audioSourceUnderWater = new GameObject("UnderWaterSound");
			audioSourceUnderWater.AddComponent(typeof(AudioSource));
			audioSourceUnderWater.GetComponent<AudioSource>().loop = true;
			audioSourceUnderWater.transform.parent = base.transform;
			audioSourceUnderWater.transform.localPosition = new Vector3(0f, 0f, 0f);
			audioSourceUnderWater.GetComponent<AudioSource>().clip = underWaterSound;
			audioSourceUnderWater.SetActive(value: false);
		}
		audioSourceCamera = GetComponent<AudioSource>();
		audioSourceCamera.playOnAwake = false;
		CheckSupport();
		if (_start == StartMode.inTheWater)
		{
			Shader.SetGlobalFloat(ShaderPropertyIds.IsUnderWater, 1f);
			EnableWater(_enable: true, startWaterID);
		}
		if (_start == StartMode.outOfTtheWater)
		{
			Shader.SetGlobalFloat(ShaderPropertyIds.IsUnderWater, 0f);
		}
	}

	public void UpdateWaterDropsSize()
	{
		float num = 1f + cameraComponent.nearClipPlane * 25f;
		float num2 = 1f + cameraComponent.nearClipPlane * 20f;
		quadDrops.transform.localScale = new Vector3(0.16f * num2, 0.16f * num2, 1f);
		quadDrops.transform.localPosition = new Vector3(0f, 0f, 0.05f * num);
	}

	private void CheckSupport()
	{
		if (!SrBlur.isSupported)
		{
			Debug.LogError("Shader 'SrBlur' not supported");
		}
		if (!SrEdge.isSupported)
		{
			Debug.LogError("Shader 'SrEdge' not supported");
		}
		if (!SrFisheye.isSupported)
		{
			Debug.LogError("Shader 'SrFisheye' not supported");
		}
		if (!SrVortex.isSupported)
		{
			Debug.LogError("Shader 'SrVortex' not supported");
		}
		if (!SrQuad.isSupported)
		{
			Debug.LogError("Shader 'SrQuad' not supported");
		}
	}

	private void OnDisable()
	{
		if (!error)
		{
			if ((bool)underWaterSound)
			{
				audioSourceUnderWater.SetActive(value: false);
			}
			if (enableQuadDrops)
			{
				timerDrops = 0f;
				cameOutOfTheWater = false;
				quadDropsRenderer.material.SetFloat("_BumpAmt", 0f);
				quadDropsRenderer.enabled = false;
			}
		}
	}

	private void Update()
	{
		if (error)
		{
			return;
		}
		float unscaledDeltaTime = Time.unscaledDeltaTime;
		float t = unscaledDeltaTime * 0.5f;
		if (enableQuadDrops)
		{
			if (cameraComponent.enabled && !DisableWaterExitDrops)
			{
				quadDrops.SetActive(value: true);
			}
			else
			{
				quadDrops.SetActive(value: false);
			}
			if (cameOutOfTheWater)
			{
				timerDrops -= unscaledDeltaTime * 20f;
				quadDropsRenderer.material.SetTextureOffset("_BumpMap", new Vector2(0f, (0f - timerDrops) * 0.01f));
				if (timerDrops < 0f)
				{
					timerDrops = 0f;
					cameOutOfTheWater = false;
					quadDropsRenderer.material.SetFloat("_BumpAmt", 0f);
					quadDropsRenderer.enabled = false;
				}
				else
				{
					quadDropsRenderer.material.SetFloat("_BumpAmt", timerDrops);
					quadDropsRenderer.enabled = true;
				}
			}
		}
		if (underWater)
		{
			interactions = (int)(7f - waters[waterIndex].visibility * 0.38f);
			blurSpread = 1f - waters[waterIndex].visibility * 0.1f;
			edgesOnly = waters[waterIndex].colorIntensity;
			edgesOnlyBgColor = waters[waterIndex].waterColor;
			float num = waters[waterIndex].distortionSpeed * Time.unscaledTime * 2f;
			float num2 = Mathf.Sin(num * 0.75f) * 10f;
			float num3 = Mathf.Sin(num) * 1.3f;
			float num4 = Mathf.Sin(num * 0.66f) * 0.45f;
			float num5 = (1f + Mathf.Sin(num)) * 0.25f;
			float num6 = (1f + Mathf.Sin(num * 0.618f)) * 0.25f;
			angleVortex = Mathf.Lerp(angleVortex, waters[waterIndex].vortexDistortion * num2, t);
			centerVortex = Vector2.Lerp(centerVortex, new Vector2(0.5f + num3, 0.5f + num4), t);
			strengthX = Mathf.Lerp(strengthX, 2f * num5 * waters[waterIndex].fisheyeDistortion, t);
			strengthY = Mathf.Lerp(strengthY, 2f * num6 * waters[waterIndex].fisheyeDistortion, t);
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (underWater && !error)
		{
			RenderTexture renderTexture = null;
			if (!DisableDistortion)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(source.width / 2, source.height / 2);
				fisheyeMaterial = CheckShaderAndCreateMaterial(SrFisheye, fisheyeMaterial);
				float num = source.width / source.height;
				fisheyeMaterial.SetVector("intensity", new Vector4(strengthX * num * (5f / 32f), strengthY * (5f / 32f), strengthX * num * (5f / 32f), strengthY * (5f / 32f)));
				Graphics.Blit(source, temporary, fisheyeMaterial);
				RenderTexture renderTexture2 = temporary;
				RenderTexture temporary2 = RenderTexture.GetTemporary(renderTexture2.width, renderTexture2.height);
				RenderTexture.ReleaseTemporary(renderTexture2);
				RenderDistortion(materialVortex, renderTexture2, temporary2, angleVortex, centerVortex, new Vector2(1f, 1f));
				renderTexture = temporary2;
			}
			RenderTexture renderTexture3 = renderTexture ?? source;
			if (!DisableBlur)
			{
				RenderTexture renderTexture4 = RenderTexture.GetTemporary(renderTexture3.width, renderTexture3.height, 0);
				DownSample4x(renderTexture3, renderTexture4);
				for (int i = 0; i < interactions; i++)
				{
					RenderTexture temporary3 = RenderTexture.GetTemporary(renderTexture3.width, renderTexture3.height, 0);
					FourTapCone(renderTexture4, temporary3, i);
					RenderTexture.ReleaseTemporary(renderTexture4);
					renderTexture4 = temporary3;
				}
				Graphics.Blit(renderTexture4, destination);
				RenderTexture.ReleaseTemporary(renderTexture4);
			}
			else
			{
				Graphics.Blit(renderTexture3, destination);
			}
			if (renderTexture != null)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
			}
		}
		else
		{
			Graphics.Blit(source, destination);
		}
	}

	private void FourTapCone(RenderTexture source, RenderTexture dest, int iteration)
	{
		float num = 0.5f + (float)iteration * blurSpread;
		Graphics.BlitMultiTap(source, dest, materialBlur, new Vector2(0f - num, 0f - num), new Vector2(0f - num, num), new Vector2(num, num), new Vector2(num, 0f - num));
	}

	private void DownSample4x(RenderTexture source, RenderTexture dest)
	{
		float num = 1f;
		Graphics.BlitMultiTap(source, dest, materialBlur, new Vector2(0f - num, 0f - num), new Vector2(0f - num, num), new Vector2(num, num), new Vector2(num, 0f - num));
	}

	private void RenderDistortion(Material material, RenderTexture source, RenderTexture destination, float angle, Vector2 center, Vector2 radius)
	{
		if (source.texelSize.y < 0f)
		{
			center.y = 1f - center.y;
			angle = 0f - angle;
		}
		Matrix4x4 value = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, angle), Vector3.one);
		material.SetMatrix("_RotationMatrix", value);
		material.SetVector("_CenterRadius", new Vector4(center.x, center.y, radius.x, radius.y));
		material.SetFloat("_Angle", angle * (MathF.PI / 180f));
		Graphics.Blit(source, destination, material);
	}

	private Material CheckShaderAndCreateMaterial(Shader s, Material m2Create)
	{
		if (s.isSupported && (bool)m2Create && m2Create.shader == s)
		{
			return m2Create;
		}
		m2Create = new Material(s);
		m2Create.hideFlags = HideFlags.DontSave;
		return m2Create;
	}

	public void EnableWater(bool _enable, int index)
	{
		if (waters.Length == 0)
		{
			return;
		}
		UnderWater = _enable;
		waterIndex = Mathf.Clamp(index, 0, waters.Length);
		if (enableQuadDrops)
		{
			cameOutOfTheWater = !_enable;
			if (_enable)
			{
				quadDropsRenderer.material.SetFloat("_BumpAmt", 0f);
				quadDropsRenderer.enabled = false;
			}
			else
			{
				timerDrops = 40f;
			}
		}
		if (_enable)
		{
			if ((bool)soundToEnter)
			{
				audioSourceCamera.Stop();
				audioSourceCamera.clip = soundToEnter;
				audioSourceCamera.PlayOneShot(audioSourceCamera.clip);
			}
			if ((bool)underWaterSound)
			{
				audioSourceUnderWater.SetActive(value: true);
			}
		}
		else
		{
			if ((bool)soundToExit)
			{
				audioSourceCamera.Stop();
				audioSourceCamera.clip = soundToExit;
				audioSourceCamera.PlayOneShot(audioSourceCamera.clip);
			}
			if ((bool)underWaterSound)
			{
				audioSourceUnderWater.SetActive(value: false);
			}
		}
		if (_enable)
		{
			angleVortex = (strengthX = (strengthY = 0f));
			centerVortex = new Vector2(0.5f, 0.5f);
		}
	}

	public void SetAudioMixerGroup(AudioMixerGroup mixer)
	{
		audioSourceCamera.outputAudioMixerGroup = mixer;
	}

	private void OnTriggerEnter(Collider colisor)
	{
		if (!base.enabled || error)
		{
			return;
		}
		for (int i = 0; i < waters.Length; i++)
		{
			if (detectionMode == WaterDetectionMode.Tag && !string.IsNullOrEmpty(waters[i].waterTag) && colisor.gameObject.CompareTag(waters[i].waterTag))
			{
				EnableWater(_enable: true, i);
				break;
			}
			if (detectionMode == WaterDetectionMode.Name && !string.IsNullOrEmpty(waters[i].waterName) && colisor.gameObject.name == waters[i].waterName)
			{
				EnableWater(_enable: true, i);
				break;
			}
		}
	}

	private void OnTriggerExit(Collider colisor)
	{
		if (!base.enabled || error)
		{
			return;
		}
		for (int i = 0; i < waters.Length; i++)
		{
			if (detectionMode == WaterDetectionMode.Tag && !string.IsNullOrEmpty(waters[i].waterTag) && colisor.gameObject.CompareTag(waters[i].waterTag))
			{
				EnableWater(_enable: false, 0);
				break;
			}
			if (detectionMode == WaterDetectionMode.Name && !string.IsNullOrEmpty(waters[i].waterName) && colisor.gameObject.name == waters[i].waterName)
			{
				EnableWater(_enable: false, 0);
				break;
			}
		}
	}
}
