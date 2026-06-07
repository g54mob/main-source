using System;
using UnityEngine;

[AddComponentMenu("Flotsam/Visuals/Rotation Helper")]
public class RotationHelper : MonoBehaviour
{
	private enum Rotation
	{
		None = 0,
		Initial = 1,
		Preset = 2
	}

	[Tooltip("Initialize the rotation helper when activating the object.")]
	[SerializeField]
	private bool _initializeOnStart;

	[Tooltip("Only run the helper during the fixed update.")]
	[SerializeField]
	private bool _onlyFixedUpdate;

	[Space]
	[SerializeField]
	private Rotation _rotationPreset;

	[SerializeField]
	[ConditionalEnumHide("_rotationPreset", 2, false)]
	private Vector3 _rotation = Vector3.zero;

	private bool _initialized;

	private Quaternion _initialRotation = Quaternion.identity;

	private void Start()
	{
		if (_initializeOnStart)
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		_initialRotation = base.transform.rotation;
		_initialized = true;
	}

	private void LateUpdate()
	{
		if (_initialized && !_onlyFixedUpdate)
		{
			SetRotation();
		}
	}

	private void FixedUpdate()
	{
		if (_initialized && _onlyFixedUpdate)
		{
			SetRotation();
		}
	}

	private void SetRotation()
	{
		switch (_rotationPreset)
		{
		case Rotation.Initial:
			base.transform.rotation = _initialRotation;
			break;
		case Rotation.Preset:
			base.transform.rotation = Quaternion.Euler(_rotation);
			break;
		default:
			throw new NotImplementedException($"Preset of type {_rotationPreset} has not been implemented yet in the rotation helper.");
		case Rotation.None:
			break;
		}
	}
}
