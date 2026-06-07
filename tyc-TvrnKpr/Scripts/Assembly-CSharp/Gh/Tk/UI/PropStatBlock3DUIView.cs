using UnityEngine;

namespace Gh.Tk.UI
{
	public class PropStatBlock3DUIView : MonoBehaviour
	{
		[SerializeField]
		private DirtStat3DUIView _dirtStatView;

		[SerializeField]
		protected CleanActionButton3DUIView _cleanButton;

		[SerializeField]
		private DamageStat3DUIView _damageStatView;

		[SerializeField]
		private RepairActionButton3DUIView _repairButton;

		[SerializeField]
		private RebuildPropActionButton3DUIView _rebuildButton;

		[SerializeField]
		private FireChanceStat3DUIView _fireChanceStatView;

		public Prop Prop { get; private set; }

		public void SetProp(Prop prop)
		{
		}

		private void SetPropDead(bool isDead)
		{
		}

		public void Refresh()
		{
		}
	}
}
