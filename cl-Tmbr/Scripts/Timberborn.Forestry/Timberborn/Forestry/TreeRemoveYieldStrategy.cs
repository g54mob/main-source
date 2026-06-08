using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.ReservableSystem;
using Timberborn.Yielding;

namespace Timberborn.Forestry
{
	public class TreeRemoveYieldStrategy : BaseComponent, IAwakableComponent, IRemoveYieldStrategy
	{
		private readonly TreeCuttingArea _treeCuttingArea;

		private BlockObject _blockObject;

		public ReservableReacher Reacher { get; private set; }

		public string Id => "Cuttable";

		public bool IsStillRemovable => _treeCuttingArea.IsInCuttingArea(_blockObject.Coordinates);

		public event EventHandler<TreeCutter> CuttingStarted;

		public event EventHandler CuttingStopped;

		public TreeRemoveYieldStrategy(TreeCuttingArea treeCuttingArea)
		{
			_treeCuttingArea = treeCuttingArea;
		}

		public void Awake()
		{
			Reacher = GetComponent<TreeReacher>();
			_blockObject = GetComponent<BlockObject>();
		}

		public void StartCutting(TreeCutter treeCutter)
		{
			this.CuttingStarted?.Invoke(this, treeCutter);
		}

		public void StopCutting()
		{
			this.CuttingStopped?.Invoke(this, EventArgs.Empty);
		}
	}
}
