using UnityEngine;

namespace Water2D
{
	[ExecuteInEditMode]
	public class Obstructor : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private ObstructorSO _data;

		[SerializeField]
		[HideInInspector]
		[Range(0f, 1f)]
		public float height;

		[SerializeField]
		[HideInInspector]
		private SpriteRenderer sr;

		[SerializeField]
		[HideInInspector]
		public ObstructorSO data
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

		protected void Awake()
		{
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

		private void OnDrawGizmos()
		{
		}

		public static int GetLayerIdx(string layer)
		{
			return 0;
		}
	}
}
