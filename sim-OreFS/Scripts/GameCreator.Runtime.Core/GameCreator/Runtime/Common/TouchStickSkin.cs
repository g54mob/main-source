using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[CreateAssetMenu(fileName = "Touchstick Skin", menuName = "Game Creator/Developer/Touchstick Skin", order = 300)]
	public class TouchStickSkin : TSkin<GameObject>
	{
		private const string MSG = "A game object prefab with a Touchstick component";

		private const string ERR_NO_VALUE = "Prefab value cannot be empty";

		private const string ERR_TOUCHSTICK = "Prefab does not contain a 'TouchStick' component";

		public override string Description => "A game object prefab with a Touchstick component";

		public override string HasError
		{
			get
			{
				if (base.Value == null)
				{
					return "Prefab value cannot be empty";
				}
				if ((bool)base.Value.GetComponentInChildren<TTouchStick>())
				{
					return string.Empty;
				}
				return "Prefab does not contain a 'TouchStick' component";
			}
		}
	}
}
