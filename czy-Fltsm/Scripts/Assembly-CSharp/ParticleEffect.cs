using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ParticleEffect : IEffect
{
	[Tooltip("The trigger that activates this particle effect.")]
	public EffectTrigger Trigger;

	[Tooltip("The particle controller that is used as the prefab for this effect.")]
	public ParticleController Controller;

	[Tooltip("The number of instances that should be spawned when the ParticleEffect is initialized.")]
	public int MinimumCount;

	[Tooltip("The maximum amount of instances that can be spawned of this ParticleEffect (Currently only used for capacity).")]
	public int MaximumCount = 5;

	private int _instanceCount;

	private Queue<ParticleController> _idleControllers;

	private Queue<ParticleController> _activeControllers;

	public void Initialize()
	{
		_idleControllers = new Queue<ParticleController>(MaximumCount);
		_activeControllers = new Queue<ParticleController>(MaximumCount);
		LoadingScreen.AddEnumeratorTask(InstantiateMinimum, MinimumCount);
	}

	public void Update()
	{
		if (0 < _activeControllers.Count && !_activeControllers.Peek().IsAlive)
		{
			_idleControllers.Enqueue(_activeControllers.Dequeue());
		}
	}

	private void InstantiateMinimum(int index)
	{
		_idleControllers.Enqueue(InstantiateController());
	}

	public bool Activate(EffectTrigger trigger, Transform parent, Vector3 localPosition)
	{
		if (Trigger == trigger)
		{
			ParticleController particleController = ((0 < _idleControllers.Count) ? _idleControllers.Dequeue() : ((_instanceCount >= MaximumCount) ? InstantiateController() : InstantiateController()));
			particleController.transform.SetParent(parent);
			particleController.transform.localPosition = localPosition;
			particleController.Initialize(parent, localPosition);
			particleController.Play();
			_activeControllers.Enqueue(particleController);
			return true;
		}
		return false;
	}

	private ParticleController InstantiateController()
	{
		ParticleController particleController = UnityEngine.Object.Instantiate(Controller);
		particleController.DisablePooling();
		_instanceCount++;
		return particleController;
	}

	private void DestroyController(ParticleController controller)
	{
		UnityEngine.Object.Destroy(controller.gameObject);
		_instanceCount--;
	}
}
