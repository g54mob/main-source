using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardwareDesignRenderer : MonoBehaviour
{
	public struct RenderJob
	{
		public IDisplayable Target;

		public HardwareDesign TargetDesign;

		public HardwareDesign.MeshObject TargetObject;

		public RenderTexture Texture;

		public bool Stay;

		public RenderJob(IDisplayable target, RenderTexture texture, bool stay)
		{
			Target = target;
			Texture = texture;
			Stay = stay;
			TargetDesign = null;
			TargetObject = null;
		}

		public RenderJob(HardwareDesign targetDesign, HardwareDesign.MeshObject targetObject, RenderTexture texture, bool stay)
		{
			Target = null;
			Texture = texture;
			Stay = stay;
			TargetDesign = targetDesign;
			TargetObject = targetObject;
		}
	}

	public static HardwareDesignRenderer Instance;

	public Camera Cam;

	public RenderTexture MainTex;

	public bool Maintain;

	private HardwareDesignInstance _active;

	private HardwareDesignInstance _temp;

	private GameObject _tempGO;

	private bool _renderInitiated;

	public Transform Root;

	public Transform CamOrigin;

	public GameObject Floppy;

	public GameObject CDRom;

	public Image[] FloppyImages;

	public Image FloppyLabel;

	public Image CDRomLabel;

	public Image CDRomBack;

	public Color Dark;

	public Color AmbientColor;

	public Text FloppyName;

	public Text FloppyCompany;

	public Text CDName;

	public Text CDCompany;

	[NonSerialized]
	public List<RenderJob> _renderQueue = new List<RenderJob>();

	private Quaternion _floppyDefaultRot;

	private Quaternion _CDDefaultRot;

	[NonSerialized]
	public Transform StickJob;

	private Color _prevAmb;

	public static void Release(Texture t)
	{
		if (Instance != null && Instance.Cam != null && Instance.Cam.targetTexture == t)
		{
			Instance.Cam.targetTexture = null;
			Instance.Cam.enabled = false;
		}
	}

	public RenderTexture RenderProduct(IDisplayable p, int size, bool stay)
	{
		RenderTexture renderTexture = new RenderTexture(size, size, 0);
		if (_renderQueue.Count == 0 && !_renderInitiated)
		{
			_renderInitiated = true;
			Transform stickJob = InitJob(p, renderTexture);
			if (stay)
			{
				StickJob = stickJob;
			}
		}
		else
		{
			_renderQueue.Add(new RenderJob(p, renderTexture, stay));
			Cam.enabled = true;
		}
		return renderTexture;
	}

	public void RenderProduct(IDisplayable p, RenderTexture rend, bool stay)
	{
		if (_renderQueue.Count == 0 && !_renderInitiated)
		{
			_renderInitiated = true;
			Transform stickJob = InitJob(p, rend);
			if (stay)
			{
				StickJob = stickJob;
			}
		}
		else
		{
			_renderQueue.Add(new RenderJob(p, rend, stay));
			Cam.enabled = true;
		}
	}

	public void RenderPart(HardwareDesign d, HardwareDesign.MeshObject o, RenderTexture rend)
	{
		if (_renderQueue.Count == 0 && !_renderInitiated)
		{
			_renderInitiated = true;
			InitJob(d, o, rend);
		}
		else
		{
			_renderQueue.Add(new RenderJob(d, o, rend, false));
			Cam.enabled = true;
		}
	}

	private Transform InitJob(IDisplayable p, RenderTexture r)
	{
		Reset();
		Transform result = null;
		if (p.Manufacturing.IsHardware())
		{
			if (p.HardwareDesign != null)
			{
				_temp = HardwareDesignInstance.Deserialize(p.HardwareDesign, 9);
				if (_temp != null)
				{
					_temp.transform.SetParent(Root, false);
					_temp.transform.rotation = Quaternion.Euler(_temp.Design.RotOffset + 10f, _temp.Design.RotOffsetX - 60f, 0f);
					LoadCamPos(_temp.Design);
					result = _temp.transform;
				}
			}
		}
		else
		{
			if (p.ReleaseYear >= 1995)
			{
				CDRom.SetActive(true);
				CDName.text = p.GetName();
				CDCompany.text = p.GetCompanyName();
				System.Random random = new System.Random(p.GetName().GetHashCode());
				CDRomBack.color = Utilities.HSVToRGBA((float)random.NextDouble(), 0.8f, 1f);
				if (random.Next(2) == 0)
				{
					CDRomLabel.color = Color.white;
					Text cDCompany = CDCompany;
					Color color = (CDName.color = Dark);
					cDCompany.color = color;
				}
				else
				{
					CDRomLabel.color = Dark;
					Text cDCompany2 = CDCompany;
					Color color = (CDName.color = Color.white);
					cDCompany2.color = color;
				}
				result = CDRom.transform;
			}
			else
			{
				Floppy.SetActive(true);
				FloppyName.text = p.GetName();
				FloppyCompany.text = p.GetCompanyName();
				System.Random random2 = new System.Random(p.GetName().GetHashCode());
				Color color2 = Utilities.HSVToRGBA((float)random2.NextDouble(), 0.8f, 1f);
				for (int i = 0; i < FloppyImages.Length; i++)
				{
					FloppyImages[i].color = color2;
				}
				if (random2.Next(2) == 0)
				{
					FloppyLabel.color = Color.white;
					Text floppyCompany = FloppyCompany;
					Color color = (FloppyName.color = Dark);
					floppyCompany.color = color;
				}
				else
				{
					FloppyLabel.color = Dark;
					Text floppyCompany2 = FloppyCompany;
					Color color = (FloppyName.color = Color.white);
					floppyCompany2.color = color;
				}
				result = Floppy.transform;
			}
			ResetCamPos();
		}
		Cam.targetTexture = r;
		Cam.enabled = true;
		return result;
	}

	private Transform InitJob(HardwareDesign d, HardwareDesign.MeshObject o, RenderTexture r)
	{
		Reset();
		bool skinned;
		_tempGO = d.SpawnObject(o, out skinned);
		Renderer component = _tempGO.GetComponent<Renderer>();
		Material material = new Material(d.Mat);
		if (d.ColorSets.Count > 0)
		{
			if (d.ColorPrimary && d.ColorSets[0].Primaries.Count > 0)
			{
				material.SetColor("_Color1", d.ColorSets[0].Primaries[0]);
			}
			if (d.ColorSecondary && d.ColorSets[0].Secondaries.Count > 0)
			{
				material.SetColor("_Color2", d.ColorSets[0].Secondaries[0]);
			}
			if (d.ColorTertiary && d.ColorSets[0].Tertieries.Count > 0)
			{
				material.SetColor("_Color3", d.ColorSets[0].Tertieries[0]);
			}
		}
		component.sharedMaterial = material;
		_tempGO.layer = 9;
		Bounds bounds = o.Mesh.bounds;
		_tempGO.transform.SetParent(Root, false);
		float num = 4f / (bounds.min - bounds.max).magnitude;
		_tempGO.transform.localScale = new Vector3(num, num, num);
		_tempGO.transform.localPosition = -bounds.center;
		ResetCamPos();
		Transform result = _tempGO.transform;
		Cam.targetTexture = r;
		Cam.enabled = true;
		return result;
	}

	public HardwareDesignInstance BeginRend(HardwareDesignInstance instance)
	{
		if (_active != null && _active != instance)
		{
			UnityEngine.Object.Destroy(_active.gameObject);
		}
		Reset();
		_active = instance;
		_active.transform.SetParent(Root, false);
		LoadCamPos(instance.Design);
		Maintain = true;
		Cam.targetTexture = MainTex;
		Cam.enabled = true;
		return _active;
	}

	private void Update()
	{
		if (StickJob != null)
		{
			StickJob.transform.Rotate(Vector3.up, Time.deltaTime * 45f, Space.World);
		}
	}

	private void Reset()
	{
		StickJob = null;
		Floppy.SetActive(false);
		CDRom.SetActive(false);
		Floppy.transform.rotation = _floppyDefaultRot;
		CDRom.transform.rotation = _CDDefaultRot;
		if (_temp != null)
		{
			UnityEngine.Object.Destroy(_temp.gameObject);
		}
		if (_tempGO != null)
		{
			UnityEngine.Object.Destroy(_tempGO);
		}
		if (_active != null)
		{
			_active.gameObject.SetActive(false);
		}
	}

	public void ResetCamPos()
	{
		Cam.transform.localPosition = new Vector3(0f, 0f, -3f);
		CamOrigin.transform.localPosition = Vector3.zero;
	}

	public void LoadCamPos(HardwareDesign d)
	{
		Cam.transform.localPosition = new Vector3(0f, 0f, -3f + d.ZoomOffset);
		CamOrigin.transform.localPosition = d.ThumbnailOffset;
	}

	public void StopRend()
	{
		Cam.enabled = false;
		Maintain = false;
		if (_active != null)
		{
			UnityEngine.Object.Destroy(_active.gameObject);
		}
	}

	private void Awake()
	{
		MainTex = new RenderTexture(512, 512, 0);
		Instance = this;
		Cam.enabled = false;
		_floppyDefaultRot = Floppy.transform.rotation;
		_CDDefaultRot = CDRom.transform.rotation;
	}

	private void OnDestroy()
	{
		Release(MainTex);
		UnityEngine.Object.Destroy(MainTex);
	}

	private void OnPreRender()
	{
		_prevAmb = RenderSettings.ambientLight;
		RenderSettings.ambientLight = AmbientColor;
	}

	private void OnPostRender()
	{
		RenderSettings.ambientLight = _prevAmb;
	}

	public bool IsActive()
	{
		if (!_renderInitiated)
		{
			return _renderQueue.Count > 0;
		}
		return true;
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		Graphics.Blit(src, dst);
		if (StickJob != null)
		{
			if (_renderQueue.Count <= 0)
			{
				_renderInitiated = false;
				return;
			}
			StickJob = null;
		}
		if (_renderQueue.Count > 0)
		{
			Transform stickJob = ((_renderQueue[0].TargetDesign != null) ? InitJob(_renderQueue[0].TargetDesign, _renderQueue[0].TargetObject, _renderQueue[0].Texture) : InitJob(_renderQueue[0].Target, _renderQueue[0].Texture));
			if (_renderQueue[0].Stay && _renderQueue.Count == 1)
			{
				StickJob = stickJob;
			}
			_renderQueue.RemoveAt(0);
		}
		else if (Maintain)
		{
			_renderInitiated = false;
			Reset();
			LoadCamPos(_active.Design);
			Cam.targetTexture = MainTex;
			if (!_active.gameObject.activeSelf)
			{
				_active.gameObject.SetActive(true);
			}
		}
		else
		{
			_renderInitiated = false;
			Cam.enabled = false;
		}
	}
}
