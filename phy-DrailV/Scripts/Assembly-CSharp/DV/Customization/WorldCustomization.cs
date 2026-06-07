using DV.Utils;
using UnityEngine;

namespace DV.Customization
{
	public sealed class WorldCustomization : SingletonCustomization<WorldCustomization>
	{
		public const string KEY = ":global:";

		public const float LOD_LOAD_DISTANCE = 128f;

		public const float LOD_CHECK_INTERVAL = 1f;

		private float checkDelay = 1f;

		private void Moved(WorldMover mover, Vector3 vector)
		{
			base.transform.position = WorldMover.currentMove;
		}

		protected override void Awake()
		{
			base.Awake();
			SingletonBehaviour<WorldMover>.Instance.WorldMoved += Moved;
			Moved(SingletonBehaviour<WorldMover>.Instance, Vector3.zero);
		}

		protected override void OnDestroy()
		{
			if (SingletonBehaviour<WorldMover>.Instance != null)
			{
				SingletonBehaviour<WorldMover>.Instance.WorldMoved -= Moved;
			}
			base.OnDestroy();
		}

		private void Update()
		{
			checkDelay -= Time.deltaTime;
			if (checkDelay < 0f)
			{
				checkDelay += 1f;
				RecheckAllLODStates();
			}
		}

		protected override bool ShouldLODBeLoaded(CustomizerBase customizer)
		{
			if (!(PlayerManager.ActiveCamera != null))
			{
				return false;
			}
			return (customizer.transform.position - PlayerManager.ActiveCamera.transform.position).sqrMagnitude < 16384f;
		}

		public override string GetIdentificationKey()
		{
			return ":global:";
		}
	}
}
