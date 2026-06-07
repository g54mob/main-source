using UnityEngine;

namespace Synty.Tools.SyntyPropBoneTool
{
	public class PropBone : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		private bool _wasSpawnedBySyntyTool;

		public bool WasSpawnedBySyntyTool
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
	}
}
