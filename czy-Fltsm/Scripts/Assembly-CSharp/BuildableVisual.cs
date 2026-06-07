using UnityEngine;
using UnityEngine.Events;

public class BuildableVisual : MonoBehaviour
{
	public class Event : UnityEvent<BuildableVisual>
	{
	}

	[SerializeField]
	private Transform _energyLinkTransform;

	private Buildable _buildable;

	private void OnEnable()
	{
		if (_buildable == null)
		{
			_buildable = GetComponentInParent<Buildable>();
		}
		_buildable?.RegisterVisual(this);
	}

	private void OnDestroy()
	{
		_buildable?.UnregisterVisual(this);
	}

	public Transform ReturnEnergyLinkTransform(Transform fallback)
	{
		if (!base.gameObject.activeInHierarchy || !_energyLinkTransform)
		{
			return fallback;
		}
		return _energyLinkTransform;
	}
}
