using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;

namespace Timberborn.BlockObjectAccesses
{
	public class HighBlockObjectAccessesAdder : BaseComponent, IStartableComponent
	{
		public void Start()
		{
			AddAccessesAboveGround();
		}

		private void AddAccessesAboveGround()
		{
			int z = GetComponent<BlockObject>().Blocks.Size.z;
			GetComponent<BlockObjectAccessible>().SetNumberOfAccessLevelsAboveGround(z);
		}
	}
}
