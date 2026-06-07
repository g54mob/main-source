using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

[AddComponentMenu("Flotsam/Visuals/Visual Prefab")]
[DisallowMultipleComponent]
public class VisualPrefab : MonoBehaviour
{
	internal class RendererMaterials
	{
		internal Renderer Renderer;

		private Material[] _sharedMaterials;

		private Material[] _replacementMaterials;

		private int _materialCount;

		private bool _disabled;

		public RendererMaterials(Renderer renderer)
		{
			Renderer = renderer;
			_disabled = false;
		}

		public void Enable()
		{
			if (_disabled)
			{
				Renderer.enabled = true;
			}
			_disabled = false;
		}

		public void Disable()
		{
			if ((bool)Renderer && Renderer.enabled)
			{
				Renderer.enabled = false;
				_disabled = true;
			}
		}

		public void SetReplacementSharedMaterial(Material replacementMaterial)
		{
			if (_sharedMaterials == null)
			{
				_sharedMaterials = Renderer.sharedMaterials;
				_materialCount = _sharedMaterials.Length;
				_replacementMaterials = new Material[_sharedMaterials.Length];
			}
			for (int i = 0; i < _materialCount; i++)
			{
				_replacementMaterials[i] = replacementMaterial;
			}
			Renderer.materials = _replacementMaterials;
		}

		public void SetColor(string name, Color color)
		{
			Material[] materials = Renderer.materials;
			for (int i = 0; i < materials.Length; i++)
			{
				materials[i].SetColor(name, color);
			}
		}

		public void RemoveReplacementMaterials()
		{
			Renderer.sharedMaterials = _sharedMaterials;
		}
	}

	public enum RotationAngles
	{
		None = 0,
		QuarterRotation = 1,
		HalfRotation = 2
	}

	[Tooltip("Length of this prefab. Used for walkway segments to determine the right size of prefab to use.")]
	public float WalkwayLength = 1f;

	[Tooltip("Gameobjects that form the visual prefab.")]
	[Obsolete]
	public List<GameObject> Visuals = new List<GameObject>();

	[Tooltip("Gameobjects that can be controlled by script.")]
	public List<GameObject> ScriptControlledVisuals = new List<GameObject>();

	[Tooltip("Visuals that are only shown whenever the visual prefab is at 100% progress.")]
	[SerializeField]
	private List<GameObject> _showOnCompleteVisuals = new List<GameObject>();

	[Space]
	[Tooltip("Straight angles that this prefab can randomly rotate in.")]
	public RotationAngles RotationLimits;

	[Tooltip("Range that the random rotation can divert from the straight angle.")]
	public Vector3 RandomRotationRange = Vector3.zero;

	[Tooltip("Ranges in which the visual prefab can be mirrored. Set to 1 to not mirror on an axis or to -1 to allow mirroring on that axis.")]
	public Vector2 MirrorRange = Vector2.one;

	[SerializeField]
	private SelectionLink _selectionLink;

	[Header("Visual States")]
	[Tooltip("The visual states that contain all the info about the build states of a construction.")]
	[SerializeField]
	private ThresholdedStates _buildStates;

	[SerializeField]
	[Tooltip("The SFX played when the build state changes. If this value is null the default SFx set in AudioSettings.PrefabChangeAudioSound is used.")]
	private AudioClipProperties _buildStatesSFX;

	[Header("Pathfinding")]
	[SerializeField]
	private GameObject _hierarchicalNodeParent;

	[Header("Frustum culling")]
	[SerializeField]
	private bool _frustumCulling;

	[SerializeField]
	[ConditionalHide("_frustumCulling", true)]
	private Bounds _bounds;

	[Header("World Map")]
	[SerializeField]
	private WorldMapReveal _worldMapReveal;

	private Vector3 _center = Vector3.zero;

	private List<RendererMaterials> _rendererMaterials;

	private AudioClipProperties _buildStateSFXOverride;

	public ThresholdedStates BuildStates => _buildStates;

	public GameObject HierarhicalNodeParent => _hierarchicalNodeParent;

	public float Progress { get; set; }

	public SelectionLink SelectionLink => _selectionLink;

	public bool FrustumCulling => _frustumCulling;

	public Bounds Bounds => _bounds;

	public WorldMapReveal WorldMapReveal => _worldMapReveal;

	private void Awake()
	{
		VisualBoundary[] componentsInChildren = GetComponentsInChildren<VisualBoundary>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.SetActive(value: false);
		}
		if ((bool)_buildStatesSFX)
		{
			OverrideBuildStateChangeSFX(_buildStatesSFX);
		}
	}

	private void OnEnable()
	{
		ValidateBuildStates();
		_buildStates.Initialize();
		if (_rendererMaterials == null)
		{
			return;
		}
		foreach (RendererMaterials rendererMaterial in _rendererMaterials)
		{
			rendererMaterial.Enable();
		}
	}

	private void OnDisable()
	{
		if (_rendererMaterials == null)
		{
			InstanceRenderers();
		}
		foreach (RendererMaterials rendererMaterial in _rendererMaterials)
		{
			rendererMaterial.Disable();
		}
	}

	private void OnDestroy()
	{
		BuildStates.StateChangeSFX -= OnBuildStateChangeSFX;
	}

	public void InstanceRenderers()
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
		int num = componentsInChildren.Length;
		_rendererMaterials = new List<RendererMaterials>(num);
		for (int i = 0; i < num; i++)
		{
			Renderer renderer = componentsInChildren[i];
			_rendererMaterials.Add(new RendererMaterials(renderer));
		}
	}

	[ExecuteInEditMode]
	public void SetProgress(float progress)
	{
		_buildStates.UpdateState(progress);
		EnableShowOnCompleteVisuals(progress >= 1f);
	}

	[ExecuteInEditMode]
	public void ResetSettings()
	{
		base.transform.localPosition = Vector3.zero;
		base.transform.localScale = Vector3.one;
		base.transform.localRotation = Quaternion.identity;
	}

	[ExecuteInEditMode]
	public void SetCenter()
	{
		Vector3 position = base.transform.position;
		base.transform.position = Vector3.zero;
		List<float> list = new List<float>();
		List<float> list2 = new List<float>();
		List<float> list3 = new List<float>();
		List<float> list4 = new List<float>();
		for (int i = 0; i < _rendererMaterials.Count; i++)
		{
			Renderer renderer = _rendererMaterials[i].Renderer;
			list.Add(renderer.bounds.min.x);
			list2.Add(renderer.bounds.min.z);
			list3.Add(renderer.bounds.max.x);
			list4.Add(renderer.bounds.max.z);
		}
		Vector3 vector = new Vector3(Mathf.Min(list.ToArray()), 0f, Mathf.Min(list2.ToArray()));
		Vector3 vector2 = new Vector3(Mathf.Max(list3.ToArray()), 0f, Mathf.Max(list4.ToArray()));
		_center = new Vector3((vector.x + vector2.x) / 2f, 0f, (vector.z + vector2.z) / 2f);
		for (int j = 0; j < _rendererMaterials.Count; j++)
		{
			_rendererMaterials[j].Renderer.transform.parent.transform.localPosition -= _center;
		}
		base.transform.position = position;
	}

	[ExecuteInEditMode]
	public void Randomize()
	{
		ResetSettings();
		base.transform.localScale = Mirroring();
		base.transform.localRotation = ReturnRandomRotation();
	}

	public int StraightAngle()
	{
		return RotationLimits switch
		{
			RotationAngles.QuarterRotation => UnityEngine.Random.Range(0, 4) * 90, 
			RotationAngles.HalfRotation => UnityEngine.Random.Range(0, 2) * 180, 
			_ => 0, 
		};
	}

	public Vector3 Mirroring()
	{
		Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
		Vector3 one = Vector3.one;
		if (insideUnitCircle.x < 0f)
		{
			one.x = MirrorRange.x;
		}
		if (insideUnitCircle.y < 0f)
		{
			one.z = MirrorRange.y;
		}
		return one;
	}

	public void EnableShowOnCompleteVisuals(bool active)
	{
		for (int i = 0; i < _showOnCompleteVisuals.Count; i++)
		{
			_showOnCompleteVisuals[i].SetActive(active);
		}
	}

	public void SetReplacementMaterial(Material material)
	{
		for (int i = 0; i < _rendererMaterials.Count; i++)
		{
			_rendererMaterials[i].SetReplacementSharedMaterial(material);
		}
	}

	public void SetColor(Color color, string shaderParameter = "_BaseColor")
	{
		for (int i = 0; i < _rendererMaterials.Count; i++)
		{
			_rendererMaterials[i].SetColor(shaderParameter, color);
		}
	}

	public void OverrideBuildStateChangeSFX(AudioClipProperties audioClipProperties)
	{
		_buildStateSFXOverride = audioClipProperties;
		BuildStates.StateChangeSFX -= OnBuildStateChangeSFX;
		BuildStates.StateChangeSFX += OnBuildStateChangeSFX;
	}

	private bool ValidateBuildStates()
	{
		if (_buildStates != null && _buildStates.Validate())
		{
			return true;
		}
		if ((bool)this)
		{
			Debug.LogError($"Unable to validate build states for visual prefab '{Debugger.ReturnComponentPath(this)}'");
		}
		else
		{
			Debug.LogError("Unable to validate build states for visual prefab because the prefab has been destroyed (is NULL)");
		}
		return false;
	}

	private void OnBuildStateChangeSFX(ThresholdedState buildState, int currentStateIndex, int previousStateIndex)
	{
		if ((bool)_buildStateSFXOverride && (bool)buildState.State)
		{
			AudioManager.Play(_buildStateSFXOverride, buildState.State.transform);
		}
	}

	public Quaternion ReturnRandomRotation()
	{
		return Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0f, RandomRotationRange.x), UnityEngine.Random.Range(0f, RandomRotationRange.y), UnityEngine.Random.Range(0f, RandomRotationRange.z)));
	}

	public void AddFoamToCompletedVisuals()
	{
		FlotsamFoamTransformer[] componentsInChildren = GetComponentsInChildren<FlotsamFoamTransformer>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!_showOnCompleteVisuals.Contains(componentsInChildren[i].gameObject))
			{
				_showOnCompleteVisuals.Add(componentsInChildren[i].gameObject);
			}
		}
		PrefabHelper.SavePrefab();
	}
}
