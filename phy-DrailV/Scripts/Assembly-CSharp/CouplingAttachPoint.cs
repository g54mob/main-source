using System;
using UnityEngine;

public class CouplingAttachPoint : MonoBehaviour
{
	private const float SEARCH_RADIUS = 0.35f;

	private static int _layer = 0;

	private static readonly Collider[] searchResults = new Collider[10];

	private static int Layer
	{
		get
		{
			if (_layer == 0)
			{
				_layer = LayerMask.NameToLayer("Laser_Pointer_Target");
			}
			return _layer;
		}
	}

	public event Action<bool> AttachStateChanged;

	public static CouplingAttachPoint FindClosestAttachPoint(Vector3 toPosition, CouplingAttachPoint exclude)
	{
		return FindClosest(toPosition, 1 << Layer, 0.35f, exclude);
	}

	public static T FindClosest<T>(Vector3 toPosition, int layerMask, float searchRadius, T exclude) where T : MonoBehaviour
	{
		int num = Physics.OverlapSphereNonAlloc(toPosition, searchRadius, searchResults, layerMask, QueryTriggerInteraction.Collide);
		T result = null;
		float num2 = float.PositiveInfinity;
		for (int i = 0; i < num; i++)
		{
			T component = searchResults[i].GetComponent<T>();
			if ((bool)component && !(exclude == component))
			{
				float num3 = Vector3.Distance(toPosition, component.transform.position);
				if (num3 < num2)
				{
					num2 = num3;
					result = component;
				}
			}
		}
		return result;
	}

	private void Awake()
	{
		if (GetComponentsInChildren<Collider>().Length == 0)
		{
			Debug.LogError("CouplingAttachPoint must have at least one collider", base.gameObject);
		}
		base.gameObject.SetLayersRecursive(Layer);
	}

	public void SetAttachState(bool attached)
	{
		this.AttachStateChanged?.Invoke(attached);
	}
}
