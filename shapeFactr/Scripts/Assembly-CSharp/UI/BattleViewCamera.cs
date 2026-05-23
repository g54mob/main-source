using Libs;
using UnityEngine;

namespace UI
{
	public class BattleViewCamera : SingletonMonoBehaviour<BattleViewCamera>
	{
		private Camera _camera;

		public Camera ViewCamera
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		private void Awake()
		{
		}

		private new void OnDestroy()
		{
		}
	}
}
