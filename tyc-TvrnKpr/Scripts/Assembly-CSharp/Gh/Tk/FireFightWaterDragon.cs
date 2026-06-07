using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class FireFightWaterDragon : GameObjectX
	{
		public static HashSet<FireFightWaterDragon> AllFireFightWaterDragons;

		public Transform CameraShakeSource;

		private DOTweenPath pathComponent;

		[PersistenceOptIn]
		private float _destroyDelay;

		[PersistenceOptIn]
		private bool _done;

		public int[] roarWayPoints;

		public int[] whooshWayPoints;

		public int[] splashWayPoints;

		public Stack<Vector3> toSplash;

		public override void Start()
		{
		}

		public override void SaveState(IDataStore data)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		private void OnWaypointChanged(int wayPoint)
		{
		}

		protected override void UpdateInternal()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
