using PajamaLlama.Debugs;
using UnityEngine;

public class SelectionCollider : MonoBehaviour
{
	[Range(0f, 5f)]
	[Tooltip("The threshold at which an object should not scale its selection collider anymore.")]
	[SerializeField]
	private float _sizeThreshold = 1.25f;

	[Tooltip("Scale for the new collider used for selection.")]
	[SerializeField]
	private float _scaleFactor = 2f;

	public void Initialize(GameObject referenceGameobject)
	{
		Collider collider = FlotsamGame.CopyCollider(referenceGameobject, base.gameObject);
		collider.isTrigger = true;
		ScaleCollider(collider);
		base.gameObject.tag = referenceGameobject.tag;
		if (GetComponent<SelectionLink>() == null)
		{
			Debugger.Error($"No selectionLink component has been set on the SelectionCollider child of {referenceGameobject.name}.", this);
		}
	}

	private void ScaleCollider(Collider collider)
	{
		Quaternion rotation = base.transform.rotation;
		base.transform.rotation = Quaternion.identity;
		Vector3 bounds = collider.bounds.extents * 2f;
		base.transform.rotation = rotation;
		base.transform.localScale = ReturnScaleFactor(bounds);
	}

	private Vector3 ReturnScaleFactor(Vector3 bounds)
	{
		Vector3 one = Vector3.one;
		if (bounds.x < _sizeThreshold)
		{
			one.x = _scaleFactor;
		}
		if (bounds.y < _sizeThreshold)
		{
			one.y = _scaleFactor;
		}
		if (bounds.z < _sizeThreshold)
		{
			one.z = _scaleFactor;
		}
		return one;
	}
}
