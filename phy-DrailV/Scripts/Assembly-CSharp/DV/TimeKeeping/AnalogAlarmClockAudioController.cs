using DV.CabControls;
using DV.Items;
using UnityEngine;

namespace DV.TimeKeeping
{
	public class AnalogAlarmClockAudioController : MonoBehaviour
	{
		[SerializeField]
		private AudioSource alarmAudioSource;

		[SerializeField]
		private AudioSource tickAudioSource;

		[SerializeField]
		private AudioSource incrementAudioSource;

		[SerializeField]
		private AudioSource alarmHandleMoveAudioSource;

		private ItemPositionHandler itemPositionHandler;

		private ItemBase item;

		private void Start()
		{
			itemPositionHandler = base.gameObject.AddComponent<ItemPositionHandler>();
			item = GetComponentInParent<ItemBase>();
			if (item == null)
			{
				Debug.LogError("AnalogAlarmClockAudioController requires a valid item ItemBase reference. Destroying self.");
				Object.Destroy(this);
			}
			else
			{
				item.AboutToBeDestroyed += OnItemAboutToBeDestroyed;
				itemPositionHandler.Initialize(item);
				base.transform.SetParent(WorldMover.OriginShiftParent);
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && !(item == null))
			{
				item.AboutToBeDestroyed -= OnItemAboutToBeDestroyed;
			}
		}

		private void OnItemAboutToBeDestroyed(ItemBase _)
		{
			Object.Destroy(base.gameObject);
		}

		private void LateUpdate()
		{
			base.transform.position = itemPositionHandler.ItemPosition;
		}

		public void PlayAlarmSound()
		{
			alarmAudioSource.Play();
		}

		public void PlayTickSound()
		{
			tickAudioSource.Play();
		}

		public void StopTickSound()
		{
			tickAudioSource.Stop();
		}

		public void PlayIncrementSound()
		{
			incrementAudioSource.Play();
		}

		public void PlayAlarmHandleMoveSound()
		{
			alarmHandleMoveAudioSource.Play();
		}
	}
}
