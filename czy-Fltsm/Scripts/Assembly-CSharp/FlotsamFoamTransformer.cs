using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class FlotsamFoamTransformer : MonoBehaviour
{
	[Tooltip("If enabled transform will always try to follow the rotation of the original parent, even if reparented. Because we are dealing with foamquads only the y rotations will be respected. For the other rotations use the RotationOffsets.")]
	[SerializeField]
	private bool _maintainOriginalLocalParentRotation;

	[Tooltip("If enabled transform will always try to follow the local position relative to the original parent, even if reparented. Because we are dealing with foamquads only the xz positions will be respected. The y position will be controlled by the water and HeightOffset.")]
	[SerializeField]
	private bool _maintainOriginalLocalParentOffset;

	[Header("Transform offsets")]
	[Tooltip("How far above the water surface should the transform follow the water.")]
	[SerializeField]
	private float _heightOffset = 0.05f;

	[Tooltip("Offsets to use for the rotation of the foam.")]
	[SerializeField]
	private Vector3 _rotationOffsets = new Vector3(90f, 0f, 0f);

	private static Transform _foamParent;

	private Transform _originalParentTransform;

	private Renderer _targetFoamRenderer;

	private Buoyancy _parentBuoyancy;

	private Vector3 _targetPosition = Vector3.zero;

	private Vector3 _originalParentOffset = Vector3.zero;

	private Quaternion _originalParentRotation = Quaternion.identity;

	private void Start()
	{
		if (_foamParent == null)
		{
			_foamParent = new GameObject("FoamQuads").transform;
		}
		_originalParentTransform = base.transform.parent;
		_targetFoamRenderer = GetComponentInParent<Renderer>();
		_parentBuoyancy = GetComponentInParent<Buoyancy>();
		_originalParentOffset = base.transform.localPosition;
		_originalParentRotation = base.transform.localRotation;
		base.transform.parent = _foamParent;
		_targetPosition = _originalParentTransform.position + (_maintainOriginalLocalParentOffset ? _originalParentOffset : Vector3.zero);
		_targetPosition.y = _heightOffset;
		base.transform.position = _targetPosition;
	}

	private void Update()
	{
		if (_originalParentTransform == null || _targetFoamRenderer == null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		if (CompareTag("Flotsam"))
		{
			if (!GameManager.WorldManager.FlotsamParent.gameObject.activeSelf)
			{
				if (_targetFoamRenderer.enabled)
				{
					_targetFoamRenderer.enabled = false;
				}
				return;
			}
			if (!_targetFoamRenderer.enabled)
			{
				_targetFoamRenderer.enabled = true;
			}
		}
		if (_maintainOriginalLocalParentRotation)
		{
			Quaternion quaternion = _originalParentTransform.rotation * _originalParentRotation;
			quaternion = Quaternion.Euler(_rotationOffsets.x, quaternion.eulerAngles.y, _rotationOffsets.y);
			base.transform.rotation = quaternion;
		}
		else
		{
			base.transform.rotation = Quaternion.Euler(_rotationOffsets.x, _originalParentTransform.rotation.eulerAngles.y, _rotationOffsets.y);
		}
		_targetPosition = _originalParentTransform.position + (_maintainOriginalLocalParentOffset ? (_originalParentTransform.rotation * _originalParentOffset) : Vector3.zero);
		_targetPosition.y = _heightOffset;
		base.transform.position = _targetPosition;
	}
}
