using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Water2D
{
	[Serializable]
	[RequireComponent(typeof(TilemapRenderer))]
	[RequireComponent(typeof(Tilemap))]
	[ExecuteInEditMode]
	public class ObstructorTilemap : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		[Range(0f, 1f)]
		public float height;

		[SerializeField]
		[HideInInspector]
		public GameObject obstructor;

		public void CreateData()
		{
		}

		public void Destroy()
		{
		}

		private void OnEnable()
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
