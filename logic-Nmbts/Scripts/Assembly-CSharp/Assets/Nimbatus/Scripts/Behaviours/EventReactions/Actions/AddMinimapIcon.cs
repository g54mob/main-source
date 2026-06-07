using Assets.Nimbatus.Scripts.Common.MiniMap;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class AddMinimapIcon : NimbatusAction
	{
		public Texture2D Icon;

		private MinimapObject _minimapObject;

		public override void Execute()
		{
			if (Icon != null)
			{
				if (_minimapObject == null)
				{
					_minimapObject = OwnWorldObject.gameObject.AddComponent<MinimapObject>();
					_minimapObject.Icon = Icon;
				}
				else
				{
					_minimapObject.Icon = Icon;
				}
			}
		}
	}
}
