using UnityEngine;

namespace Photon.Pun.Demo.PunBasics
{
	public class LoaderAnime : MonoBehaviour
	{
		[Tooltip("Angular Speed in degrees per seconds")]
		public float speed;

		[Tooltip("Radius os the loader")]
		public float radius;

		public GameObject particles;

		private Vector3 _offset;

		private Transform _transform;

		private Transform _particleTransform;

		private bool _isAnimating;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void StartLoaderAnimation()
		{
		}

		public void StopLoaderAnimation()
		{
		}
	}
}
