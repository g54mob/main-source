using UnityEngine;

namespace Water2D
{
	[ExecuteInEditMode]
	public class Obstructor3D : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private Obstructor3DSO _data;

		[SerializeField]
		[HideInInspector]
		public WaterCryo<float> height;

		[HideInInspector]
		public Obstructor3DSO data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void CreateData()
		{
		}

		public void Destroy()
		{
		}

		private bool IsValid()
		{
			return false;
		}

		private void OnEnable()
		{
		}

		private void UpdateMaterialData()
		{
		}

		protected void OnDestroy()
		{
		}

		public static int GetLayerIdx(string layer)
		{
			return 0;
		}
	}
}
