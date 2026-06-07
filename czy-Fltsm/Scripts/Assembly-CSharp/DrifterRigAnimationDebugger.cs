using UnityEngine;

public class DrifterRigAnimationDebugger : MonoBehaviour
{
	[SerializeField]
	private DrifterLookProperties _drifterLookProperties;

	[SerializeField]
	private int _attributeVariation;

	[SerializeField]
	private int Floor = 1;

	[SerializeField]
	private Activity _activity;

	[Header("UIComponents")]
	public ActivityDropDown _activityDropDown;

	private DrifterRig _drifterRig;

	private Animator _animator;

	private void Awake()
	{
		_drifterRig = Object.Instantiate(_drifterLookProperties.RigPrefab, base.transform);
		_drifterRig.MeshAnimator.Initialize();
		_drifterRig.Randomize(_drifterLookProperties);
		_drifterRig.SetAttributeVariation(_attributeVariation);
		_animator = _drifterRig.MeshAnimator.Animator;
		_animator.SetInteger("Floor", Floor);
		_activityDropDown.OnSelectionChanged.AddListener(OnActivityChanged);
		SetActivity(_activity);
	}

	private void OnDisable()
	{
		_activityDropDown.OnSelectionChanged.RemoveListener(OnActivityChanged);
	}

	public void TriggerTransition()
	{
		_animator.SetTrigger("Transition Trigger");
	}

	private void OnActivityChanged(Activity activity)
	{
		SetActivity(activity);
	}

	private void SetActivity(Activity activity)
	{
		_drifterRig.AnimationTools.ClearAnimationTools();
		_animator.SetInteger("Activity", (int)activity);
		_animator.SetTrigger("Activity Trigger");
	}
}
