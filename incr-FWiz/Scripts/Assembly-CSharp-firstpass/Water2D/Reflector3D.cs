using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	[ExecuteInEditMode]
	public class Reflector3D : MonoBehaviour
	{
		[SerializeField]
		public WaterCryo<Vector3> displacement;

		[SerializeField]
		public WaterCryo<Vector3> rotation;

		[HideInInspector]
		[SerializeField]
		private Reflection3DSO _data;

		[HideInInspector]
		public Reflection3DSO data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		public void SetCallbacks()
		{
		}

		private void Start()
		{
		}

		public void CreateData()
		{
		}

		private bool IsValid()
		{
			return false;
		}

		public void DeleteData()
		{
		}

		public void UpdateData()
		{
		}

		private void DestroyPlus(UnityEngine.Object obj)
		{
		}

		protected void OnDestroy()
		{
		}
	}
}
