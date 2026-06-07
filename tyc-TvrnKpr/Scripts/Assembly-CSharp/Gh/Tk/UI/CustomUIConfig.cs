using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class CustomUIConfig : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _rotation;

		[SerializeField]
		private Vector3 _uiRotationOffset;

		[SerializeField]
		private List<Transform> _transformsToEnable;

		[SerializeField]
		private List<Transform> _transformsToDisable;

		public void SetDefaultCustomRotation(Vector3 rotation)
		{
		}

		public void SetUIRotationOffset(Vector3 offset)
		{
		}

		public Vector3 GetUIRotation()
		{
			return default(Vector3);
		}

		public void UpdateForUILayer()
		{
		}
	}
}
