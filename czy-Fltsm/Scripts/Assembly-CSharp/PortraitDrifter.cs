using UnityEngine;

public class PortraitDrifter : MonoBehaviour
{
	public enum PortraitType
	{
		Dynamic = 0,
		Static = 1
	}

	[SerializeField]
	private PortraitType _type;

	[SerializeField]
	private DrifterRig _maleDrifter;

	[SerializeField]
	private DrifterRig _femaleDrifter;

	private DrifterLookCamera _currentCamera;

	private DrifterRig _currentRig;

	private Agent.EGender _currentGender;

	private DrifterLookProperties.Indices _currentLook;

	private bool _updateLook;

	private bool _shouldBeEnabled;

	private bool _isEnabledStateDirty;

	private AgentDescriptor _agentToActivate;

	private Activity _agentActivityToSet = Activity.DynamicPortrait;

	private DrifterLookCamera _cameraToActivate;

	public AgentDescriptor CurrentAgent { get; private set; }

	private void Awake()
	{
		InitializeRig(_maleDrifter);
		InitializeRig(_femaleDrifter);
		DisableInternal();
	}

	private void LateUpdate()
	{
		if (_updateLook && CurrentAgent != null)
		{
			CurrentAgent.ApplyLooksForPortrait(_currentRig, _currentCamera, _currentCamera == DrifterLookCamera.DynamicPortrait);
			_updateLook = false;
		}
		if (_isEnabledStateDirty)
		{
			if (_shouldBeEnabled)
			{
				EnableInternal();
			}
			else
			{
				DisableInternal();
			}
			_isEnabledStateDirty = false;
		}
	}

	public void Enable(AgentDescriptor descriptor, DrifterLookCamera camera, Activity activity = Activity.DynamicPortrait)
	{
		_shouldBeEnabled = true;
		_isEnabledStateDirty = true;
		_agentToActivate = descriptor;
		_agentActivityToSet = activity;
		_cameraToActivate = camera;
		GameEventDispatcher.Dispatch(GameEventType.DrifterPortraitEnabled);
	}

	public bool Disable()
	{
		_shouldBeEnabled = false;
		_isEnabledStateDirty = true;
		_agentToActivate = null;
		GameEventDispatcher.Dispatch(GameEventType.DrifterPortraitDisabled);
		return !_shouldBeEnabled;
	}

	public bool IsEnabled()
	{
		return _shouldBeEnabled;
	}

	private void EnableInternal()
	{
		if (CurrentAgent == _agentToActivate && _currentGender == _agentToActivate.Gender && IsCurrentLook(_agentToActivate.LookIndices))
		{
			if (_currentRig.CurrentActivity != _agentActivityToSet && _type == PortraitType.Dynamic)
			{
				_currentRig.UpdatePortraitActivity(_agentToActivate, _agentActivityToSet, forceUpdate: true);
			}
			return;
		}
		DisableInternal();
		_currentRig = ((_agentToActivate.Gender == Agent.EGender.Male) ? _maleDrifter : _femaleDrifter);
		_currentGender = _agentToActivate.Gender;
		_currentLook = _agentToActivate.LookIndices;
		_currentCamera = _cameraToActivate;
		CurrentAgent = _agentToActivate;
		CurrentAgent.ApplyLooksForPortrait(_currentRig, _currentCamera, _currentCamera == DrifterLookCamera.DynamicPortrait);
		CurrentAgent.OnLookUpdated.AddListener(OnDrifterLookUpdated);
		_currentRig.gameObject.SetActive(value: true);
		if (_type == PortraitType.Dynamic)
		{
			_currentRig.SetPortraitLayer();
			_currentRig.UpdatePortraitActivity(_agentToActivate, _agentActivityToSet, forceUpdate: true);
		}
		else
		{
			_currentRig.SetHeadPortraitLayer();
		}
	}

	private void DisableInternal()
	{
		if (CurrentAgent != null)
		{
			CurrentAgent.OnLookUpdated.RemoveListener(OnDrifterLookUpdated);
			CurrentAgent = null;
		}
		if (_maleDrifter.gameObject.activeSelf || _femaleDrifter.gameObject.activeSelf)
		{
			_maleDrifter.gameObject.SetActive(value: false);
			_femaleDrifter.gameObject.SetActive(value: false);
		}
	}

	public void SetPortraitActivity(Activity activity)
	{
		if (CurrentAgent != null)
		{
			_currentRig.UpdatePortraitActivity(CurrentAgent, activity);
		}
		else if (_agentToActivate != null)
		{
			_agentActivityToSet = activity;
		}
	}

	private void InitializeRig(DrifterRig rig)
	{
		rig.SetShadows(active: false);
		switch (_type)
		{
		case PortraitType.Dynamic:
			rig.MeshAnimator.Initialize();
			rig.SetPortraitLayer();
			break;
		case PortraitType.Static:
			rig.SetHeadPortraitLayer();
			break;
		}
	}

	private void OnDrifterLookUpdated()
	{
		_updateLook = true;
	}

	private bool IsCurrentLook(DrifterLookProperties.Indices look)
	{
		if (_currentLook.BodyMaterial == look.BodyMaterial && _currentLook.EyesMaterial == look.EyesMaterial && _currentLook.MouthMaterial == look.MouthMaterial && _currentLook.Head == look.Head && _currentLook.Ears == look.Ears && _currentLook.Eyes == look.Eyes && _currentLook.Nose == look.Nose && _currentLook.Mouth == look.Mouth && _currentLook.Body == look.Body && _currentLook.HairMaterial == look.HairMaterial && _currentLook.Haircut == look.Haircut && _currentLook.Eyebrows == look.Eyebrows && _currentLook.Moustache == look.Moustache && _currentLook.Beard == look.Beard && _currentLook.TopMaterial == look.TopMaterial && _currentLook.PantsMaterial == look.PantsMaterial && _currentLook.ShoesMaterial == look.ShoesMaterial && _currentLook.Top == look.Top && _currentLook.Pants == look.Pants)
		{
			return _currentLook.Shoes == look.Shoes;
		}
		return false;
	}
}
