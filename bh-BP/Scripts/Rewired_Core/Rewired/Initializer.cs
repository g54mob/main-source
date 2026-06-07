using System.ComponentModel;
using UnityEngine;

namespace Rewired
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	public sealed class Initializer : MonoBehaviour
	{
		[SerializeField]
		private GameObject _inputManagerPrefab;

		[SerializeField]
		private bool _destroySelf;

		public GameObject inputManagerPrefab
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool destroySelf
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public bool Initialize()
		{
			return false;
		}
	}
}
