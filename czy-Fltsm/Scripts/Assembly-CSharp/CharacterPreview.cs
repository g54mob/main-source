using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using UnityEngine.UI.PajamaLlama;

public class CharacterPreview : MonoBehaviour, ILocalizationGenderProvider, ILocalizationParamsManager
{
	[Header("Portrait")]
	[SerializeField]
	private RawImage _portrait;

	[SerializeField]
	private Camera _cameraPrefab;

	[SerializeField]
	private Vector3 _cameraOffset;

	[Header("Information")]
	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private TextMeshProUGUI _pastBackgroundName;

	[SerializeField]
	private TextMeshProUGUI _pastBackgroundDescription;

	[SerializeField]
	private Image _pastBackgroundIcon;

	[SerializeField]
	private TextMeshProUGUI _presentBackgroundName;

	[SerializeField]
	private TextMeshProUGUI _presentBackgroundDescription;

	[SerializeField]
	private Image _presentBackgroundIcon;

	[Space]
	[SerializeField]
	private DrifterAttributeTooltipElement _attributePrefab;

	[SerializeField]
	private RectTransform _pastAttributeParent;

	[SerializeField]
	private RectTransform _presentAttributeParent;

	[Header("Header")]
	[SerializeField]
	private Color _textColor = Color.white;

	[Header("Navigation")]
	[SerializeField]
	private Selectable _rerollButton;

	[SerializeField]
	private Selectable _preferenceDropdown;

	[SerializeField]
	private ScrollRectAxisScroller _scroller;

	[Header("Animation")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _animatorPropertySelected = "Selected";

	private DrifterRig _rig;

	private List<DrifterAttributeTooltipElement> _pastAttributes = new List<DrifterAttributeTooltipElement>();

	private List<DrifterAttributeTooltipElement> _presentAttributes = new List<DrifterAttributeTooltipElement>();

	private DrifterAttributes.AttributeType _attributeBias;

	private List<DrifterAttributeTooltipElement> _activeAttributes = new List<DrifterAttributeTooltipElement>();

	private CharacterPreview _leftNeighbor;

	private CharacterPreview _rightNeighbor;

	public AgentDescriptor AgentDescriptor { get; private set; }

	public Camera Camera { get; private set; }

	Agent.EGender ILocalizationGenderProvider.LocalizationGender => AgentDescriptor.Gender;

	private void OnEnable()
	{
		LocalizationManager.ParamManagers.AddUnique(this);
		FocusManager.CurrentSelectedGameObjectChanged.AddListener(OnSelectableGameObjectChanged);
	}

	private void OnDisable()
	{
		LocalizationManager.ParamManagers.Remove(this);
		FocusManager.CurrentSelectedGameObjectChanged.RemoveListener(OnSelectableGameObjectChanged);
	}

	public void Initialize(Transform cameraParent, Vector3 position)
	{
		AgentDescriptor = AgentDescriptor.CreateInstance();
		Camera = Object.Instantiate(_cameraPrefab, cameraParent);
		Camera.transform.localPosition = position;
		RenderTexture renderTexture = new RenderTexture(1024, 1024, 24, GraphicsFormat.R8G8B8A8_UNorm);
		renderTexture.Create();
		Camera.targetTexture = renderTexture;
		_portrait.texture = renderTexture;
		GenerateCharacterMesh(AgentDescriptor, Camera.transform, _cameraOffset);
		SetInfo();
	}

	public void InitializeHorizontalNavigation(CharacterPreview leftNeighbor, CharacterPreview rightNeighbor)
	{
		_leftNeighbor = leftNeighbor;
		_rightNeighbor = rightNeighbor;
		InitializeLeftToRightNavigation(this, _rightNeighbor);
	}

	public void Reroll()
	{
		ListPool<DrifterAttributesEffect>.List list = ListPool<DrifterAttributesEffect>.List.Get();
		ListPool<DrifterAttributesEffect>.List list2 = ListPool<DrifterAttributesEffect>.List.Get();
		DrifterAttributes.AttributeType bias = DrifterAttributes.AttributeType.None;
		DrifterAttributes.AttributeType bias2 = DrifterAttributes.AttributeType.None;
		int num = Random.Range(0, 100);
		if (num < 45)
		{
			bias = _attributeBias;
		}
		else if (num < 90)
		{
			bias2 = _attributeBias;
		}
		else
		{
			bias = (bias2 = _attributeBias);
		}
		PopulateBackgrounds(AgentDescriptor.Properties.PastBackgrounds, list, bias);
		PopulateBackgrounds(AgentDescriptor.Properties.PresentBackgrounds, list2, bias2);
		AgentDescriptor.Reroll(list.GetRandom(), list2.GetRandom());
		list.Dispose();
		list2.Dispose();
		GenerateCharacterMesh(AgentDescriptor, Camera.transform, _cameraOffset);
		SetInfo();
		InitializeLeftToRightNavigation(_leftNeighbor, this);
		InitializeLeftToRightNavigation(this, _rightNeighbor);
	}

	private void PopulateBackgrounds(IReadOnlyList<DrifterAttributesEffect> source, List<DrifterAttributesEffect> target, DrifterAttributes.AttributeType bias = DrifterAttributes.AttributeType.None)
	{
		if (bias == DrifterAttributes.AttributeType.None)
		{
			target.AddRange(source);
			return;
		}
		foreach (DrifterAttributesEffect item in source)
		{
			if (item.ReturnContainsAttributeType(bias))
			{
				target.Add(item);
			}
		}
	}

	public void SetAttributeBias(DrifterAttributes.AttributeType attributeBias)
	{
		_attributeBias = attributeBias;
	}

	private DrifterRig GenerateCharacterMesh(AgentDescriptor agentDescriptor, Transform parent, Vector3 position)
	{
		if (_rig == null || _rig.Gender != agentDescriptor.Gender)
		{
			Object.Destroy(_rig);
			_rig = DrifterRig.Instantiate(agentDescriptor);
		}
		Transform obj = _rig.transform;
		obj.parent = parent;
		obj.localPosition = position;
		obj.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
		agentDescriptor.ApplyLooksForPortrait(_rig, DrifterLookCamera.DynamicPortrait, applyAlternativeLook: false);
		_rig.SetShadows(active: false);
		_rig.SetPortraitLayer();
		_rig.MeshAnimator.Initialize();
		_rig.MeshAnimator.UpdatePortraitAnimator(AgentDescriptor, Activity.CrewScreenPortrait);
		_rig.MeshAnimator.Animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		_rig.MeshAnimator.Animator.SetTrigger("Transition Trigger");
		return _rig;
	}

	private void SetInfo()
	{
		_name.text = AgentDescriptor.Name;
		_pastBackgroundName.text = AgentDescriptor.PastBackground.Name;
		_pastBackgroundDescription.text = AgentDescriptor.PastBackground.Description;
		_pastBackgroundIcon.sprite = AgentDescriptor.PastBackground.IconProperties.Sprite;
		_presentBackgroundName.text = AgentDescriptor.PresentBackground.Name;
		_presentBackgroundDescription.text = AgentDescriptor.PresentBackground.Description;
		_presentBackgroundIcon.sprite = AgentDescriptor.PresentBackground.IconProperties.Sprite;
		_activeAttributes.Clear();
		SetModifiers(AgentDescriptor.PastBackground.Modifiers, _pastAttributeParent, ref _pastAttributes);
		SetModifiers(AgentDescriptor.PresentBackground.Modifiers, _presentAttributeParent, ref _presentAttributes);
		if (0 < _activeAttributes.Count)
		{
			DrifterAttributeTooltipElement drifterAttributeTooltipElement = _activeAttributes[0];
			_preferenceDropdown.SetSelectOnUp(drifterAttributeTooltipElement.Selectable);
			_rerollButton.SetSelectOnUp(drifterAttributeTooltipElement.Selectable);
			drifterAttributeTooltipElement.Selectable.SetSelectOnDown(_preferenceDropdown);
			for (int i = 1; i < _activeAttributes.Count; i++)
			{
				DrifterAttributeTooltipElement drifterAttributeTooltipElement2 = drifterAttributeTooltipElement;
				drifterAttributeTooltipElement = _activeAttributes[i];
				drifterAttributeTooltipElement2.Selectable.SetSelectOnUp(drifterAttributeTooltipElement.Selectable);
				drifterAttributeTooltipElement.Selectable.SetSelectOnDown(drifterAttributeTooltipElement2.Selectable);
			}
		}
	}

	private void SetModifiers(DrifterAttributeModifier[] modifiers, RectTransform parent, ref List<DrifterAttributeTooltipElement> previews)
	{
		foreach (DrifterAttributeTooltipElement preview in previews)
		{
			preview.Selectable.ClearNavigation();
			preview.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < modifiers.Length; i++)
		{
			DrifterAttributeModifier modifier = modifiers[i];
			DrifterAttributeTooltipElement drifterAttributeTooltipElement;
			if (i >= previews.Count)
			{
				drifterAttributeTooltipElement = Object.Instantiate(_attributePrefab, parent);
				previews.Add(drifterAttributeTooltipElement);
			}
			else
			{
				drifterAttributeTooltipElement = previews[i];
				drifterAttributeTooltipElement.gameObject.SetActive(value: true);
			}
			drifterAttributeTooltipElement.SetModifier(AgentDescriptor.Properties.AttributeProperties, modifier, _textColor);
			_activeAttributes.Insert(0, drifterAttributeTooltipElement);
		}
	}

	private void InitializeLeftToRightNavigation(CharacterPreview left, CharacterPreview right)
	{
		if (left == null || right == null)
		{
			return;
		}
		int num = Mathf.Max(left._activeAttributes.Count, right._activeAttributes.Count);
		bool flag = true;
		bool flag2 = true;
		DrifterAttributeTooltipElement drifterAttributeTooltipElement = null;
		DrifterAttributeTooltipElement drifterAttributeTooltipElement2 = null;
		for (int i = 0; i < num; i++)
		{
			if (i < left._activeAttributes.Count)
			{
				drifterAttributeTooltipElement = left._activeAttributes[i];
			}
			else
			{
				flag = false;
			}
			if (i < right._activeAttributes.Count)
			{
				drifterAttributeTooltipElement2 = right._activeAttributes[i];
			}
			else
			{
				flag2 = false;
			}
			if (flag)
			{
				drifterAttributeTooltipElement.Selectable.SetSelectOnRight(drifterAttributeTooltipElement2.Selectable);
			}
			if (flag2)
			{
				drifterAttributeTooltipElement2.Selectable.SetSelectOnLeft(drifterAttributeTooltipElement.Selectable);
			}
		}
	}

	private void OnSelectableGameObjectChanged(GameObject gameObject)
	{
		bool value = HasGameObject(gameObject);
		if ((bool)_animator)
		{
			_animator.SetBool(_animatorPropertySelected, value);
		}
		if ((bool)_scroller)
		{
			_scroller.enabled = value;
		}
	}

	private bool HasGameObject(GameObject gameObject)
	{
		if (_rerollButton.gameObject == gameObject || _preferenceDropdown.gameObject == gameObject)
		{
			return true;
		}
		foreach (DrifterAttributeTooltipElement activeAttribute in _activeAttributes)
		{
			if (activeAttribute.gameObject == gameObject)
			{
				return true;
			}
		}
		return false;
	}
}
