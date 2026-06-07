using DV.Utils;
using UnityEngine;

namespace DV.Optimizers
{
	[ExecuteAfter(typeof(DefaultOrder))]
	public class PlayerOnCarScriptsOptimizer : MonoBehaviour
	{
		public interface IOptimizable
		{
			void SetOptimizeState(bool enabled);
		}

		public MonoBehaviour[] scriptsToDisable;

		private TrainCar car;

		private bool prevWasOnCar = true;

		private void Awake()
		{
			car = TrainCar.Resolve(base.gameObject);
			if (car == null)
			{
				Debug.LogError("Unexpected state: Can't extract TrainCar. Destroying self, enabling all scripts", base.gameObject);
				MonoBehaviour[] array = scriptsToDisable;
				foreach (MonoBehaviour mb in array)
				{
					SetState(mb, enabled: true);
				}
				Object.Destroy(this);
			}
		}

		private void Start()
		{
			MonoBehaviour[] array = scriptsToDisable;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					return;
				}
			}
			Object.Destroy(this);
		}

		private void OnEnable()
		{
			OnCarChanged(PlayerManager.Car);
			PlayerManager.CarChanged += OnCarChanged;
		}

		private void OnDisable()
		{
			PlayerManager.CarChanged -= OnCarChanged;
		}

		private void SetState(Behaviour mb, bool enabled)
		{
			if (mb.TryGetComponent<IOptimizable>(out var component))
			{
				component.SetOptimizeState(enabled);
			}
			else
			{
				mb.enabled = enabled;
			}
		}

		private void OnCarChanged(TrainCar newCar)
		{
			bool flag = car == newCar;
			if (flag == prevWasOnCar)
			{
				return;
			}
			MonoBehaviour[] array = scriptsToDisable;
			foreach (MonoBehaviour monoBehaviour in array)
			{
				if (monoBehaviour != null)
				{
					SetState(monoBehaviour, flag);
				}
			}
			prevWasOnCar = flag;
		}
	}
}
