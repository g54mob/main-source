using Gh.Tk.Story.Logic;
using UnityEngine;

namespace Gh.Tk
{
	public class TavernLock3DUIView : Button3DUIView
	{
		[SerializeField]
		private GuideNode _unlockNode;

		public override bool IsBlocked => false;

		public override bool IsLocked => false;

		public override bool IsHovered
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool IsTavernReadyToOpen()
		{
			return false;
		}

		protected override void Start()
		{
		}

		public void Invalidate()
		{
		}
	}
}
