using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class IgnoreFloatingOriginScript : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("If this is set to <c>true</c> and the script is attached to a root level object, the root object will not be moved and its child objects will be moved instead.")]
		private bool _repositionChildren;

		public bool RepositionChildren
		{
			get
			{
				return _repositionChildren;
			}
			set
			{
				_repositionChildren = value;
			}
		}
	}
}
