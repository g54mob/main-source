using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class BackgroundAnimation : MonoBehaviour, IPersistable, ILevelStaticObject, ILateRestoreState, ICustomSaveState, IUpdateable
	{
		[Header("level-unique id for persistence")]
		public string id;

		public int fromGameHour;

		public int toGameHour;

		public float minIntervalInGameHours;

		public float maxIntervalInGameHours;

		[PersistenceOptIn]
		private float _nextSpawnTime;

		[PersistenceOptIn]
		private bool _isAnimating;

		private GameObject[] _children;

		private AnimationEventObserver[] _animationEventObservers;

		[PersistenceOptIn]
		private string _animatingChildName;

		[PersistenceOptIn]
		public string Id
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnAnimationEvent(object sender, AnimationEventArgs e)
		{
		}

		private void StartAnimation()
		{
		}

		private void StopAnimation()
		{
		}

		private void ClearSounds()
		{
		}

		public void ResetState()
		{
		}

		public void LateRestoreState(IDataStore data)
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}

		public void UpdateObject()
		{
		}
	}
}
