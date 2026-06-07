using UnityEngine;

namespace Gh.Tk
{
	public class CustomDecoProp : Prop
	{
		private GameObject _centerVisual;

		public bool AutoDestroyWhenEmpty;

		public override float Damage
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private GameObject CenterVisual => null;

		public override void Awake()
		{
		}

		protected override void OnDecorVolumeChanged()
		{
		}

		private new void UpdateStatusIconPosition()
		{
		}

		public override Vector3 GetStatusIconPosition(bool worldSpace = false)
		{
			return default(Vector3);
		}

		public override void IncreaseUsageFilth()
		{
		}

		public override void PostBuiltInit()
		{
		}

		internal override void OnEditingFinished()
		{
		}

		private void HandleInOrOutsideTavernChanges()
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		public override void RemoveHighlight()
		{
		}

		private void Update()
		{
		}

		public override sbyte GetEffectiveDecorOutput()
		{
			return 0;
		}
	}
}
