using UnityEngine;

namespace Gh.Tk
{
	public class ExtractToNewPropCommand : ReParentBaseDecorationCommand
	{
		private CustomDecoProp _newGox;

		public ExtractToNewPropCommand(EntityObject[] eos)
			: base(null)
		{
		}

		protected override void ExecuteInternal()
		{
		}

		private Vector3 GetCoordForNewProp()
		{
			return default(Vector3);
		}

		protected override void UndoInternal()
		{
		}

		protected override void CleanUpWhenUndone()
		{
		}
	}
}
