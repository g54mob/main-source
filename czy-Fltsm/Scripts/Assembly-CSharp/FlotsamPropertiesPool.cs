using System.Collections.Generic;
using UnityEngine;

public class FlotsamPropertiesPool
{
	private int _visualPrefabCount;

	private Queue<FlotsamBehaviour>[] _interactableFlotsam;

	private Queue<FlotsamBehaviour>[] _nonInteractableFlotsam;

	private Quaternion _rotation;

	public FlotsamProperties Properties { get; private set; }

	public FlotsamPropertiesPool(FlotsamProperties properties)
	{
		Properties = properties;
		_visualPrefabCount = properties.VisualPrefabs.Count;
		_interactableFlotsam = ReturnQueue(_visualPrefabCount);
		_nonInteractableFlotsam = ReturnQueue(_visualPrefabCount);
		_rotation = Quaternion.identity;
	}

	public int AquireInteractable(out FlotsamBehaviour flotsam, Vector3 position, int preferredIndex = -1)
	{
		return Aquire(out flotsam, _interactableFlotsam, Properties.FlotsamPrefab, position, interactable: true, preferredIndex);
	}

	public int AquireNonInteractable(out FlotsamBehaviour flotsam, Vector3 position, int preferredIndex = -1)
	{
		return Aquire(out flotsam, _nonInteractableFlotsam, Properties.FlotsamPrefab.NonInteractablePrefab, position, interactable: false, preferredIndex);
	}

	private int Aquire(out FlotsamBehaviour flotsam, Queue<FlotsamBehaviour>[] instances, FlotsamBehaviour prefab, Vector3 position, bool interactable, int preferredVisualPrefabIndex)
	{
		int num = ((preferredVisualPrefabIndex >= 0 && _visualPrefabCount > preferredVisualPrefabIndex) ? preferredVisualPrefabIndex : Random.Range(0, _visualPrefabCount));
		if (TryReturnFlotsamBehaviourInstance(instances[num], out flotsam))
		{
			flotsam.Activate(position);
		}
		else
		{
			flotsam = Object.Instantiate(prefab, position, _rotation);
			flotsam.Initialize(Properties, num);
		}
		return num;
	}

	public void Release(FlotsamBehaviour flotsam)
	{
		if (flotsam.Interactable)
		{
			Release(flotsam, _interactableFlotsam[flotsam.VisualPrefabIndex]);
		}
		else
		{
			Release(flotsam, _nonInteractableFlotsam[flotsam.VisualPrefabIndex]);
		}
		flotsam.Deactivate();
	}

	private void Release(FlotsamBehaviour flotsam, Queue<FlotsamBehaviour> queue)
	{
		if (queue.Contains(flotsam))
		{
			Debug.LogErrorFormat("Releasing '{0}' instance, but it is already in it's FlotamPropertiesPool queue!", flotsam.name);
		}
		else
		{
			queue.Enqueue(flotsam);
		}
	}

	public void RemoveDestroyed()
	{
		RemovedDestroyed(_interactableFlotsam);
		RemovedDestroyed(_nonInteractableFlotsam);
	}

	private void RemovedDestroyed(Queue<FlotsamBehaviour>[] queues)
	{
		foreach (Queue<FlotsamBehaviour> queue in queues)
		{
			int count = queue.Count;
			for (int j = 0; j < count; j++)
			{
				FlotsamBehaviour flotsamBehaviour = queue.Dequeue();
				if ((bool)flotsamBehaviour && (bool)flotsamBehaviour.gameObject)
				{
					queue.Enqueue(flotsamBehaviour);
				}
			}
		}
	}

	public Queue<FlotsamBehaviour>[] ReturnQueue(int count)
	{
		Queue<FlotsamBehaviour>[] array = new Queue<FlotsamBehaviour>[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = new Queue<FlotsamBehaviour>();
		}
		return array;
	}

	private bool TryReturnFlotsamBehaviourInstance(Queue<FlotsamBehaviour> instances, out FlotsamBehaviour instance)
	{
		while (0 < instances.Count)
		{
			instance = instances.Dequeue();
			if (!(instance == null))
			{
				return true;
			}
		}
		instance = null;
		return false;
	}
}
