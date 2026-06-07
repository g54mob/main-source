using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PropEngineAdvancedScript : BladedEngineScript
	{
		private PropEngineAdvancedData _data;

		public override void Initialize(bool remoteCraft)
		{
			_data = (PropEngineAdvancedData)base.Engine;
			base.Initialize(remoteCraft);
		}

		protected override Rigidbody GetBodyToAddForceTo()
		{
			if (_data.LegacyCotPos)
			{
				return base.Body;
			}
			return base.GetBodyToAddForceTo();
		}
	}
}
